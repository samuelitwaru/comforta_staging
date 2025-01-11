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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_createcontentpage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createcontentpage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_createcontentpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createcontentpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           out string aP1_Response ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         this.AV22Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
         aP2_Error=this.AV22Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_PageId ,
                                      out string aP1_Response )
      {
         execute(aP0_PageId, out aP1_Response, out aP2_Error);
         return AV22Error ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 out string aP1_Response ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         this.AV22Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Response=this.AV17Response;
         aP2_Error=this.AV22Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV22Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV22Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV24Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV25Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P008Z2 */
            pr_default.execute(0, new Object[] {AV12PageId, AV24Udparg1, AV25Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P008Z2_A11OrganisationId[0];
               A29LocationId = P008Z2_A29LocationId[0];
               A58ProductServiceId = P008Z2_A58ProductServiceId[0];
               AV18BC_Trn_ProductService.Load(AV12PageId, new prc_getuserlocationid(context).executeUdp( ), new prc_getuserorganisationid(context).executeUdp( ));
               AV16PageName = AV18BC_Trn_ProductService.gxTpr_Productservicename;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( ! (Guid.Empty==AV18BC_Trn_ProductService.gxTpr_Productserviceid) )
            {
               AV8BC_Trn_Page = new SdtTrn_Page(context);
               AV8BC_Trn_Page.Load(AV12PageId, AV16PageName, AV19LocationId);
               AV8BC_Trn_Page.gxTpr_Trn_pageid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
               AV8BC_Trn_Page.gxTpr_Trn_pagename = AV18BC_Trn_ProductService.gxTpr_Productservicename;
               AV8BC_Trn_Page.gxTpr_Productserviceid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
               AV8BC_Trn_Page.gxTpr_Pagejsoncontent = AV13PageJsonContent;
               AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
               AV8BC_Trn_Page.gxTpr_Pagegjsjson = "";
               AV8BC_Trn_Page.gxTpr_Pageiscontentpage = true;
               AV8BC_Trn_Page.gxTpr_Pageispublished = false;
               GXt_guid1 = Guid.Empty;
               new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Locationid = GXt_guid1;
               GXt_guid1 = Guid.Empty;
               new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Organisationid = GXt_guid1;
               AV8BC_Trn_Page.Save();
               if ( AV8BC_Trn_Page.Success() )
               {
                  context.CommitDataStores("prc_createcontentpage",pr_default);
                  AV17Response = context.GetMessage( "Content page saved successfully", "");
                  new prc_logtofile(context ).execute(  AV17Response) ;
               }
               else
               {
                  AV27GXV2 = 1;
                  AV26GXV1 = AV8BC_Trn_Page.GetMessages();
                  while ( AV27GXV2 <= AV26GXV1.Count )
                  {
                     AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV26GXV1.Item(AV27GXV2));
                     new prc_logtofile(context ).execute(  ">>>>> "+AV9Message.gxTpr_Description) ;
                     AV27GXV2 = (int)(AV27GXV2+1);
                  }
               }
            }
            AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
            cleanup();
            if (true) return;
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
         AV17Response = "";
         AV22Error = new SdtSDT_Error(context);
         AV24Udparg1 = Guid.Empty;
         AV25Udparg2 = Guid.Empty;
         P008Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Z2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Z2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV18BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV16PageName = "";
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV19LocationId = Guid.Empty;
         AV13PageJsonContent = "";
         GXt_guid1 = Guid.Empty;
         AV26GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__default(),
            new Object[][] {
                new Object[] {
               P008Z2_A11OrganisationId, P008Z2_A29LocationId, P008Z2_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27GXV2 ;
      private string AV17Response ;
      private string AV13PageJsonContent ;
      private string AV16PageName ;
      private Guid AV12PageId ;
      private Guid AV24Udparg1 ;
      private Guid AV25Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid AV19LocationId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV22Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008Z2_A11OrganisationId ;
      private Guid[] P008Z2_A29LocationId ;
      private Guid[] P008Z2_A58ProductServiceId ;
      private SdtTrn_ProductService AV18BC_Trn_ProductService ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV26GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private string aP1_Response ;
      private SdtSDT_Error aP2_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createcontentpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       return "DATASTORE1";
    }

 }

 public class aprc_createcontentpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createcontentpage__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP008Z2;
       prmP008Z2 = new Object[] {
       new ParDef("AV12PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV24Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV25Udparg2",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008Z2", "SELECT OrganisationId, LocationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :AV12PageId and LocationId = :AV24Udparg1 and OrganisationId = :AV25Udparg2 ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z2,1, GxCacheFrequency.OFF ,true,true )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
