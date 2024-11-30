using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_creategamuseraccount : GXProcedure
   {
      public prc_creategamuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_creategamuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Email ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           string aP3_RoleName ,
                           out string aP4_GAMUserGUID )
      {
         this.AV8Email = aP0_Email;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV12RoleName = aP3_RoleName;
         this.AV9GAMUserGUID = "" ;
         initialize();
         ExecuteImpl();
         aP4_GAMUserGUID=this.AV9GAMUserGUID;
      }

      public string executeUdp( string aP0_Email ,
                                string aP1_GivenName ,
                                string aP2_LastName ,
                                string aP3_RoleName )
      {
         execute(aP0_Email, aP1_GivenName, aP2_LastName, aP3_RoleName, out aP4_GAMUserGUID);
         return AV9GAMUserGUID ;
      }

      public void executeSubmit( string aP0_Email ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 string aP3_RoleName ,
                                 out string aP4_GAMUserGUID )
      {
         this.AV8Email = aP0_Email;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV12RoleName = aP3_RoleName;
         this.AV9GAMUserGUID = "" ;
         SubmitImpl();
         aP4_GAMUserGUID=this.AV9GAMUserGUID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV13GAMUser.gxTpr_Name = AV8Email;
         AV13GAMUser.gxTpr_Firstname = AV10GivenName;
         AV13GAMUser.gxTpr_Lastname = AV11LastName;
         AV13GAMUser.gxTpr_Email = AV8Email;
         AV13GAMUser.gxTpr_Password = Guid.NewGuid( ).ToString();
         AV13GAMUser.gxTpr_Authenticationtypename = "local";
         AV13GAMUser.gxTpr_Namespace = "Comforta";
         AV13GAMUser.save();
         if ( AV13GAMUser.success() )
         {
            AV9GAMUserGUID = AV13GAMUser.gxTpr_Guid;
            context.CommitDataStores("prc_creategamuseraccount",pr_default);
            AV16Role = AV14GAMRole.getbyname(AV12RoleName, out  AV15GAMErrorCollection);
            if ( AV13GAMUser.addrole(AV16Role, out  AV15GAMErrorCollection) )
            {
               AV13GAMUser.save();
               context.CommitDataStores("prc_creategamuseraccount",pr_default);
            }
            if ( StringUtil.StrCmp(AV12RoleName, "Resident") != 0 )
            {
               GXt_char1 = AV19HttpRequest.BaseURL;
               new prc_senduseractivationlink(context).executeSubmit(  AV13GAMUser.gxTpr_Guid, ref  GXt_char1, out  AV18isSuccessful) ;
               if ( AV18isSuccessful )
               {
                  new prc_logtofile(context ).execute(  "Email Sent: "+AV12RoleName) ;
                  context.CommitDataStores("prc_creategamuseraccount",pr_default);
               }
               else
               {
                  new prc_logtofile(context ).execute(  "No Email Sent : "+AV12RoleName) ;
               }
            }
            else
            {
               new prc_activateresidentaccount(context ).execute(  AV9GAMUserGUID) ;
            }
         }
         else
         {
            AV15GAMErrorCollection = AV13GAMUser.geterrors();
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9GAMUserGUID = "";
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV15GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV19HttpRequest = new GxHttpRequest( context);
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_creategamuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_creategamuseraccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private bool AV18isSuccessful ;
      private string AV8Email ;
      private string AV10GivenName ;
      private string AV11LastName ;
      private string AV12RoleName ;
      private string AV9GAMUserGUID ;
      private GxHttpRequest AV19HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV16Role ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV14GAMRole ;
      private string aP4_GAMUserGUID ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_creategamuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class prc_creategamuseraccount__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
