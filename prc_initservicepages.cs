using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prc_initservicepages : GXProcedure
   {
      public prc_initservicepages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initservicepages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtTrn_AppVersion_Page aP0_BC_CarePage ,
                           out SdtTrn_AppVersion_Page aP1_BC_LivingPage ,
                           out SdtTrn_AppVersion_Page aP2_BC_ServicesPage )
      {
         this.AV15BC_CarePage = new SdtTrn_AppVersion_Page(context) ;
         this.AV18BC_LivingPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV17BC_ServicesPage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP0_BC_CarePage=this.AV15BC_CarePage;
         aP1_BC_LivingPage=this.AV18BC_LivingPage;
         aP2_BC_ServicesPage=this.AV17BC_ServicesPage;
      }

      public SdtTrn_AppVersion_Page executeUdp( out SdtTrn_AppVersion_Page aP0_BC_CarePage ,
                                                out SdtTrn_AppVersion_Page aP1_BC_LivingPage )
      {
         execute(out aP0_BC_CarePage, out aP1_BC_LivingPage, out aP2_BC_ServicesPage);
         return AV17BC_ServicesPage ;
      }

      public void executeSubmit( out SdtTrn_AppVersion_Page aP0_BC_CarePage ,
                                 out SdtTrn_AppVersion_Page aP1_BC_LivingPage ,
                                 out SdtTrn_AppVersion_Page aP2_BC_ServicesPage )
      {
         this.AV15BC_CarePage = new SdtTrn_AppVersion_Page(context) ;
         this.AV18BC_LivingPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV17BC_ServicesPage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP0_BC_CarePage=this.AV15BC_CarePage;
         aP1_BC_LivingPage=this.AV18BC_LivingPage;
         aP2_BC_ServicesPage=this.AV17BC_ServicesPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18BC_LivingPage.gxTpr_Pageid = Guid.NewGuid( );
         AV18BC_LivingPage.gxTpr_Pagename = "My Living";
         AV18BC_LivingPage.gxTpr_Pagetype = "Menu";
         AV20SDT_MenuPage = new SdtSDT_MenuPage(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV22TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Tile", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV22TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV23RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV23RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV23RowsItem.gxTpr_Tiles.Add(AV22TilesItem, 0);
         AV20SDT_MenuPage.gxTpr_Rows.Add(AV23RowsItem, 0);
         AV18BC_LivingPage.gxTpr_Pagestructure = AV20SDT_MenuPage.ToJSonString(false, true);
         AV15BC_CarePage.gxTpr_Pageid = Guid.NewGuid( );
         AV15BC_CarePage.gxTpr_Pagename = "My Care";
         AV15BC_CarePage.gxTpr_Pagetype = "Menu";
         AV20SDT_MenuPage = new SdtSDT_MenuPage(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV22TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Tile", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV22TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV23RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV23RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV23RowsItem.gxTpr_Tiles.Add(AV22TilesItem, 0);
         AV20SDT_MenuPage.gxTpr_Rows.Add(AV23RowsItem, 0);
         AV15BC_CarePage.gxTpr_Pagestructure = AV20SDT_MenuPage.ToJSonString(false, true);
         AV17BC_ServicesPage.gxTpr_Pageid = Guid.NewGuid( );
         AV17BC_ServicesPage.gxTpr_Pagename = "My Services";
         AV17BC_ServicesPage.gxTpr_Pagetype = "Menu";
         AV20SDT_MenuPage = new SdtSDT_MenuPage(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV22TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Tile", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV22TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV23RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV23RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV23RowsItem.gxTpr_Tiles.Add(AV22TilesItem, 0);
         AV20SDT_MenuPage.gxTpr_Rows.Add(AV23RowsItem, 0);
         AV17BC_ServicesPage.gxTpr_Pagestructure = AV20SDT_MenuPage.ToJSonString(false, true);
         cleanup();
      }

      protected void S111( )
      {
         /* 'DEFAULTMENUPAGETILE' Routine */
         returnInSub = false;
         new prc_pageutils(context ).gxep_defaultmenupagetile( out  AV22TilesItem) ;
         AV23RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV23RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV23RowsItem.gxTpr_Tiles.Add(AV22TilesItem, 0);
         AV20SDT_MenuPage.gxTpr_Rows.Add(AV23RowsItem, 0);
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
         AV15BC_CarePage = new SdtTrn_AppVersion_Page(context);
         AV18BC_LivingPage = new SdtTrn_AppVersion_Page(context);
         AV17BC_ServicesPage = new SdtTrn_AppVersion_Page(context);
         AV20SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV22TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV23RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private SdtTrn_AppVersion_Page AV15BC_CarePage ;
      private SdtTrn_AppVersion_Page AV18BC_LivingPage ;
      private SdtTrn_AppVersion_Page AV17BC_ServicesPage ;
      private SdtSDT_MenuPage AV20SDT_MenuPage ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV22TilesItem ;
      private SdtSDT_MenuPage_RowsItem AV23RowsItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 ;
      private SdtTrn_AppVersion_Page aP0_BC_CarePage ;
      private SdtTrn_AppVersion_Page aP1_BC_LivingPage ;
      private SdtTrn_AppVersion_Page aP2_BC_ServicesPage ;
   }

}
