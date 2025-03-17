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
   public class prc_createservicepage : GXProcedure
   {
      public prc_createservicepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createservicepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_ProductServiceId ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ProductServiceId = aP1_ProductServiceId;
         this.AV26PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV24SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV26PageItem;
         aP3_SDT_Error=this.AV24SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_ProductServiceId ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_ProductServiceId, out aP2_PageItem, out aP3_SDT_Error);
         return AV24SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_ProductServiceId ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ProductServiceId = aP1_ProductServiceId;
         this.AV26PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV24SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV26PageItem;
         aP3_SDT_Error=this.AV24SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV24SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV24SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV13LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV13LocationId = GXt_guid1;
         GXt_guid1 = AV14OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV14OrganisationId = GXt_guid1;
         AV12BC_Trn_ProductService.Load(AV10ProductServiceId, AV13LocationId, AV14OrganisationId);
         AV23BC_Trn_AppVersion.Load(AV9AppVersionId);
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A543AppVersionId = P00BR2_A543AppVersionId[0];
            AV28GXLvl18 = 0;
            /* Using cursor P00BR3 */
            pr_default.execute(1, new Object[] {A543AppVersionId, AV10ProductServiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A521PageId = P00BR3_A521PageId[0];
               A523PageStructure = P00BR3_A523PageStructure[0];
               AV28GXLvl18 = 1;
               AV22BC_Page.gxTpr_Pageid = AV10ProductServiceId;
               AV22BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
               AV22BC_Page.gxTpr_Pagetype = "Content";
               AV22BC_Page.gxTpr_Pagestructure = A523PageStructure;
               AV8SDT_ContentPage.FromJSonString(A523PageStructure, null);
               AV26PageItem.FromJSonString(AV22BC_Page.ToJSonString(true, true), null);
               AV26PageItem.gxTpr_Pagecontentstructure = AV8SDT_ContentPage;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV28GXLvl18 == 0 )
            {
               /* Execute user subroutine: 'CREATENEWSERVICEPAGE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWSERVICEPAGE' Routine */
         returnInSub = false;
         AV22BC_Page.gxTpr_Pageid = AV12BC_Trn_ProductService.gxTpr_Productserviceid;
         AV22BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
         AV22BC_Page.gxTpr_Pagetype = "Content";
         AV8SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
         AV16ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productserviceimage_gxi;
         AV8SDT_ContentPage.gxTpr_Content.Add(AV16ContentItem, 0);
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
         AV16ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productservicedescription;
         AV8SDT_ContentPage.gxTpr_Content.Add(AV16ContentItem, 0);
         new prc_logtoserver(context ).execute(  ">>"+AV8SDT_ContentPage.ToJSonString(false, true)) ;
         AV22BC_Page.gxTpr_Pagestructure = AV8SDT_ContentPage.ToJSonString(false, true);
         AV23BC_Trn_AppVersion.gxTpr_Page.Add(AV22BC_Page, 0);
         AV23BC_Trn_AppVersion.Save();
         if ( AV23BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createservicepage",pr_default);
            AV26PageItem.FromJSonString(AV22BC_Page.ToJSonString(true, true), null);
            AV26PageItem.gxTpr_Pagecontentstructure = AV8SDT_ContentPage;
         }
         else
         {
            AV30GXV2 = 1;
            AV29GXV1 = AV23BC_Trn_AppVersion.GetMessages();
            while ( AV30GXV2 <= AV29GXV1.Count )
            {
               AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV29GXV1.Item(AV30GXV2));
               AV24SDT_Error.gxTpr_Message = AV25Message.gxTpr_Description;
               AV30GXV2 = (int)(AV30GXV2+1);
            }
         }
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
         AV26PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV24SDT_Error = new SdtSDT_Error(context);
         AV13LocationId = Guid.Empty;
         AV14OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV23BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00BR2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A543AppVersionId = Guid.Empty;
         P00BR3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BR3_A521PageId = new Guid[] {Guid.Empty} ;
         P00BR3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A523PageStructure = "";
         AV22BC_Page = new SdtTrn_AppVersion_Page(context);
         AV8SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV29GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A543AppVersionId
               }
               , new Object[] {
               P00BR3_A543AppVersionId, P00BR3_A521PageId, P00BR3_A523PageStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28GXLvl18 ;
      private int AV30GXV2 ;
      private bool returnInSub ;
      private string A523PageStructure ;
      private Guid AV9AppVersionId ;
      private Guid AV10ProductServiceId ;
      private Guid AV13LocationId ;
      private Guid AV14OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A543AppVersionId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV26PageItem ;
      private SdtSDT_Error AV24SDT_Error ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private SdtTrn_AppVersion AV23BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BR2_A543AppVersionId ;
      private Guid[] P00BR3_A543AppVersionId ;
      private Guid[] P00BR3_A521PageId ;
      private string[] P00BR3_A523PageStructure ;
      private SdtTrn_AppVersion_Page AV22BC_Page ;
      private SdtSDT_ContentPage AV8SDT_ContentPage ;
      private SdtSDT_ContentPage_ContentItem AV16ContentItem ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV29GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createservicepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createservicepage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createservicepage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00BR2;
       prmP00BR2 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BR3;
       prmP00BR3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BR2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BR3", "SELECT AppVersionId, PageId, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV10ProductServiceId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR3,1, GxCacheFrequency.OFF ,false,true )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
    }
 }

}

}
