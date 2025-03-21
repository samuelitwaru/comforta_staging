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
   public class prc_createappversion : GXProcedure
   {
      public prc_createappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AppVersionName ,
                           bool aP1_IsActive ,
                           out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV22AppVersionName = aP0_AppVersionName;
         this.AV23IsActive = aP1_IsActive;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( string aP0_AppVersionName ,
                                      bool aP1_IsActive ,
                                      out SdtSDT_AppVersion aP2_SDT_AppVersion )
      {
         execute(aP0_AppVersionName, aP1_IsActive, out aP2_SDT_AppVersion, out aP3_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( string aP0_AppVersionName ,
                                 bool aP1_IsActive ,
                                 out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV22AppVersionName = aP0_AppVersionName;
         this.AV23IsActive = aP1_IsActive;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV10LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV10LocationId = GXt_guid1;
         GXt_guid1 = AV13OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV13OrganisationId = GXt_guid1;
         AV11BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
         AV11BC_Trn_AppVersion.gxTpr_Appversionname = AV22AppVersionName;
         AV11BC_Trn_AppVersion.gxTpr_Locationid = AV10LocationId;
         AV11BC_Trn_AppVersion.gxTpr_Organisationid = AV13OrganisationId;
         AV11BC_Trn_AppVersion.gxTpr_Isactive = AV23IsActive;
         GXt_SdtTrn_AppVersion_Page2 = AV12BC_ReceptionPage;
         new prc_initreceptionpage(context ).execute( ref  AV10LocationId, ref  AV13OrganisationId, out  GXt_SdtTrn_AppVersion_Page2) ;
         AV12BC_ReceptionPage = GXt_SdtTrn_AppVersion_Page2;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV12BC_ReceptionPage, 0);
         GXt_SdtTrn_AppVersion_Page2 = AV14BC_LocationPage;
         new prc_initlocationpage(context ).execute( ref  AV10LocationId, ref  AV13OrganisationId, out  GXt_SdtTrn_AppVersion_Page2) ;
         AV14BC_LocationPage = GXt_SdtTrn_AppVersion_Page2;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV14BC_LocationPage, 0);
         new prc_initservicepages(context ).execute( out  AV15BC_CarePage, out  AV16BC_LivingPage, out  AV17BC_ServicesPage) ;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV15BC_CarePage, 0);
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV16BC_LivingPage, 0);
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV17BC_ServicesPage, 0);
         new prc_logtoserver(context ).execute(  "3") ;
         AV19BC_WebLinkPage.gxTpr_Pageid = Guid.NewGuid( );
         AV19BC_WebLinkPage.gxTpr_Pagename = context.GetMessage( "Web Link", "");
         AV19BC_WebLinkPage.gxTpr_Ispredefined = true;
         AV19BC_WebLinkPage.gxTpr_Pagetype = "WebLink";
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV19BC_WebLinkPage, 0);
         AV20BC_DynamicFormPage.gxTpr_Pageid = Guid.NewGuid( );
         AV20BC_DynamicFormPage.gxTpr_Pagename = context.GetMessage( "Dynamic Form", "");
         AV20BC_DynamicFormPage.gxTpr_Ispredefined = true;
         AV20BC_DynamicFormPage.gxTpr_Pagetype = "DynamicForm";
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV20BC_DynamicFormPage, 0);
         AV25BC_MyActivityPage.gxTpr_Pageid = Guid.NewGuid( );
         AV25BC_MyActivityPage.gxTpr_Pagename = context.GetMessage( "My Activity", "");
         AV25BC_MyActivityPage.gxTpr_Ispredefined = true;
         AV25BC_MyActivityPage.gxTpr_Pagetype = "MyActivity";
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV25BC_MyActivityPage, 0);
         AV24BC_CalendarPage.gxTpr_Pageid = Guid.NewGuid( );
         AV24BC_CalendarPage.gxTpr_Pagename = context.GetMessage( "Calendar", "");
         AV24BC_CalendarPage.gxTpr_Ispredefined = true;
         AV24BC_CalendarPage.gxTpr_Pagetype = "Calendar";
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV24BC_CalendarPage, 0);
         GXt_SdtTrn_AppVersion_Page2 = AV18BC_HomePage;
         new prc_inithomepage(context ).execute(  AV12BC_ReceptionPage.gxTpr_Pageid,  AV14BC_LocationPage.gxTpr_Pageid,  AV15BC_CarePage.gxTpr_Pageid,  AV16BC_LivingPage.gxTpr_Pageid,  AV17BC_ServicesPage.gxTpr_Pageid,  AV25BC_MyActivityPage.gxTpr_Pageid,  AV24BC_CalendarPage.gxTpr_Pageid, out  GXt_SdtTrn_AppVersion_Page2) ;
         AV18BC_HomePage = GXt_SdtTrn_AppVersion_Page2;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV18BC_HomePage, 0);
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createappversion",pr_default);
            new prc_loadappversionsdt(context ).execute(  AV11BC_Trn_AppVersion, out  AV8SDT_AppVersion) ;
         }
         else
         {
            AV27GXV2 = 1;
            AV26GXV1 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV27GXV2 <= AV26GXV1.Count )
            {
               AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV26GXV1.Item(AV27GXV2));
               GX_msglist.addItem(AV21Message.gxTpr_Description);
               AV27GXV2 = (int)(AV27GXV2+1);
            }
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
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV10LocationId = Guid.Empty;
         AV13OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV12BC_ReceptionPage = new SdtTrn_AppVersion_Page(context);
         AV14BC_LocationPage = new SdtTrn_AppVersion_Page(context);
         AV15BC_CarePage = new SdtTrn_AppVersion_Page(context);
         AV16BC_LivingPage = new SdtTrn_AppVersion_Page(context);
         AV17BC_ServicesPage = new SdtTrn_AppVersion_Page(context);
         AV19BC_WebLinkPage = new SdtTrn_AppVersion_Page(context);
         AV20BC_DynamicFormPage = new SdtTrn_AppVersion_Page(context);
         AV25BC_MyActivityPage = new SdtTrn_AppVersion_Page(context);
         AV24BC_CalendarPage = new SdtTrn_AppVersion_Page(context);
         AV18BC_HomePage = new SdtTrn_AppVersion_Page(context);
         GXt_SdtTrn_AppVersion_Page2 = new SdtTrn_AppVersion_Page(context);
         AV26GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27GXV2 ;
      private bool AV23IsActive ;
      private string AV22AppVersionName ;
      private Guid AV10LocationId ;
      private Guid AV13OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV12BC_ReceptionPage ;
      private SdtTrn_AppVersion_Page AV14BC_LocationPage ;
      private SdtTrn_AppVersion_Page AV15BC_CarePage ;
      private SdtTrn_AppVersion_Page AV16BC_LivingPage ;
      private SdtTrn_AppVersion_Page AV17BC_ServicesPage ;
      private SdtTrn_AppVersion_Page AV19BC_WebLinkPage ;
      private SdtTrn_AppVersion_Page AV20BC_DynamicFormPage ;
      private SdtTrn_AppVersion_Page AV25BC_MyActivityPage ;
      private SdtTrn_AppVersion_Page AV24BC_CalendarPage ;
      private SdtTrn_AppVersion_Page AV18BC_HomePage ;
      private SdtTrn_AppVersion_Page GXt_SdtTrn_AppVersion_Page2 ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV26GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private SdtSDT_AppVersion aP2_SDT_AppVersion ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createappversion__default : DataStoreHelperBase, IDataStoreHelper
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
