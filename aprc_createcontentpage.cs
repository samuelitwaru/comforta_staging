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
         Guid aP0_PageId = new Guid()  ;
         string aP1_Response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_PageId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_PageId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_Response=((string)(args[1]));
         }
         else
         {
            aP1_Response="";
         }
         execute(aP0_PageId, out aP1_Response);
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
                           out string aP1_Response )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
      }

      public string executeUdp( Guid aP0_PageId )
      {
         execute(aP0_PageId, out aP1_Response);
         return AV17Response ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 out string aP1_Response )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         SubmitImpl();
         aP1_Response=this.AV17Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV21UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV21UserName = GXt_char1;
         /* Using cursor P008Z2 */
         pr_default.execute(0, new Object[] {AV21UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P008Z2_A93ReceptionistEmail[0];
            A29LocationId = P008Z2_A29LocationId[0];
            A11OrganisationId = P008Z2_A11OrganisationId[0];
            A89ReceptionistId = P008Z2_A89ReceptionistId[0];
            AV19LocationId = A29LocationId;
            AV20OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P008Z3 */
         pr_default.execute(1, new Object[] {AV12PageId, AV19LocationId, AV20OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P008Z3_A11OrganisationId[0];
            A29LocationId = P008Z3_A29LocationId[0];
            A58ProductServiceId = P008Z3_A58ProductServiceId[0];
            AV18BC_Trn_ProductService.Load(AV12PageId, AV19LocationId, AV20OrganisationId);
            AV16PageName = AV18BC_Trn_ProductService.gxTpr_Productservicename;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> pag ", "")+AV12PageId.ToString()) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> pagname ", "")+AV16PageName) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> loc ", "")+AV19LocationId.ToString()) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> org ", "")+AV20OrganisationId.ToString()) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> usr ", "")+AV21UserName) ;
         if ( ! (Guid.Empty==AV18BC_Trn_ProductService.gxTpr_Productserviceid) )
         {
            AV8BC_Trn_Page = new SdtTrn_Page(context);
            new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> bc_page ", "")+AV8BC_Trn_Page.ToJSonString(true, true)) ;
            AV8BC_Trn_Page.Load(AV12PageId, AV16PageName, AV19LocationId);
            new prc_logtofile(context ).execute(  context.GetMessage( "CCP>>>> bc_page ", "")+AV8BC_Trn_Page.ToJSonString(true, true)) ;
            AV8BC_Trn_Page.gxTpr_Trn_pageid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
            AV8BC_Trn_Page.gxTpr_Trn_pagename = AV18BC_Trn_ProductService.gxTpr_Productservicename;
            AV8BC_Trn_Page.gxTpr_Productserviceid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
            AV8BC_Trn_Page.gxTpr_Pagejsoncontent = AV13PageJsonContent;
            AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
            AV8BC_Trn_Page.gxTpr_Pagegjsjson = "";
            AV8BC_Trn_Page.gxTpr_Pageiscontentpage = true;
            AV8BC_Trn_Page.gxTpr_Pageispublished = false;
            AV8BC_Trn_Page.gxTpr_Locationid = AV19LocationId;
            AV8BC_Trn_Page.gxTpr_Organisationid = AV20OrganisationId;
            AV8BC_Trn_Page.Save();
            if ( AV8BC_Trn_Page.Success() )
            {
               context.CommitDataStores("prc_createcontentpage",pr_default);
               AV17Response = context.GetMessage( "Content page saved successfully", "");
               new prc_logtofile(context ).execute(  AV17Response) ;
            }
            else
            {
               AV25GXV2 = 1;
               AV24GXV1 = AV8BC_Trn_Page.GetMessages();
               while ( AV25GXV2 <= AV24GXV1.Count )
               {
                  AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV24GXV1.Item(AV25GXV2));
                  new prc_logtofile(context ).execute(  ">>>>> "+AV9Message.gxTpr_Description) ;
                  AV25GXV2 = (int)(AV25GXV2+1);
               }
            }
         }
         AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
         new prc_logtofile(context ).execute(  AV17Response) ;
         cleanup();
         if (true) return;
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
         AV21UserName = "";
         GXt_char1 = "";
         P008Z2_A93ReceptionistEmail = new string[] {""} ;
         P008Z2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Z2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV19LocationId = Guid.Empty;
         AV20OrganisationId = Guid.Empty;
         P008Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Z3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Z3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         AV18BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV16PageName = "";
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV13PageJsonContent = "";
         AV24GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
               P008Z2_A93ReceptionistEmail, P008Z2_A29LocationId, P008Z2_A11OrganisationId, P008Z2_A89ReceptionistId
               }
               , new Object[] {
               P008Z3_A11OrganisationId, P008Z3_A29LocationId, P008Z3_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV25GXV2 ;
      private string GXt_char1 ;
      private string AV17Response ;
      private string AV13PageJsonContent ;
      private string AV21UserName ;
      private string A93ReceptionistEmail ;
      private string AV16PageName ;
      private Guid AV12PageId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private Guid AV19LocationId ;
      private Guid AV20OrganisationId ;
      private Guid A58ProductServiceId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008Z2_A93ReceptionistEmail ;
      private Guid[] P008Z2_A29LocationId ;
      private Guid[] P008Z2_A11OrganisationId ;
      private Guid[] P008Z2_A89ReceptionistId ;
      private Guid[] P008Z3_A11OrganisationId ;
      private Guid[] P008Z3_A29LocationId ;
      private Guid[] P008Z3_A58ProductServiceId ;
      private SdtTrn_ProductService AV18BC_Trn_ProductService ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private string aP1_Response ;
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
      ,new ForEachCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP008Z2;
       prmP008Z2 = new Object[] {
       new ParDef("AV21UserName",GXType.VarChar,100,0)
       };
       Object[] prmP008Z3;
       prmP008Z3 = new Object[] {
       new ParDef("AV12PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008Z2", "SELECT ReceptionistEmail, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV21UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z2,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P008Z3", "SELECT OrganisationId, LocationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :AV12PageId and LocationId = :AV19LocationId and OrganisationId = :AV20OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z3,1, GxCacheFrequency.OFF ,true,true )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
