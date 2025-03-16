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
   public class prc_inithomepage : GXProcedure
   {
      public prc_inithomepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_inithomepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_ReceptionPageId ,
                           Guid aP1_LocationPageId ,
                           Guid aP2_CarePageId ,
                           Guid aP3_LivingPageId ,
                           Guid aP4_ServicesPageId ,
                           out SdtTrn_AppVersion_Page aP5_BC_HomePage )
      {
         this.AV10ReceptionPageId = aP0_ReceptionPageId;
         this.AV11LocationPageId = aP1_LocationPageId;
         this.AV12CarePageId = aP2_CarePageId;
         this.AV13LivingPageId = aP3_LivingPageId;
         this.AV14ServicesPageId = aP4_ServicesPageId;
         this.AV15BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP5_BC_HomePage=this.AV15BC_HomePage;
      }

      public SdtTrn_AppVersion_Page executeUdp( Guid aP0_ReceptionPageId ,
                                                Guid aP1_LocationPageId ,
                                                Guid aP2_CarePageId ,
                                                Guid aP3_LivingPageId ,
                                                Guid aP4_ServicesPageId )
      {
         execute(aP0_ReceptionPageId, aP1_LocationPageId, aP2_CarePageId, aP3_LivingPageId, aP4_ServicesPageId, out aP5_BC_HomePage);
         return AV15BC_HomePage ;
      }

      public void executeSubmit( Guid aP0_ReceptionPageId ,
                                 Guid aP1_LocationPageId ,
                                 Guid aP2_CarePageId ,
                                 Guid aP3_LivingPageId ,
                                 Guid aP4_ServicesPageId ,
                                 out SdtTrn_AppVersion_Page aP5_BC_HomePage )
      {
         this.AV10ReceptionPageId = aP0_ReceptionPageId;
         this.AV11LocationPageId = aP1_LocationPageId;
         this.AV12CarePageId = aP2_CarePageId;
         this.AV13LivingPageId = aP3_LivingPageId;
         this.AV14ServicesPageId = aP4_ServicesPageId;
         this.AV15BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP5_BC_HomePage=this.AV15BC_HomePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV20baseUrl = AV19GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV15BC_HomePage.gxTpr_Pageid = Guid.NewGuid( );
         AV15BC_HomePage.gxTpr_Pagename = "Home";
         AV15BC_HomePage.gxTpr_Pagetype = "Menu";
         /* Execute user subroutine: 'RECEPTIONTILE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CALENDARANDMYACTIVITYTILES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'LOCATIONTILE' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SERVICESTILES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV15BC_HomePage.gxTpr_Pagestructure = AV16SDT_MenuPage.ToJSonString(false, true);
         cleanup();
      }

      protected void S111( )
      {
         /* 'RECEPTIONTILE' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Reception", ""),  "#000000",  context.GetMessage( "center", ""),  context.GetMessage( "Reception", ""),  0,  "",  AV20baseUrl+context.GetMessage( "/media/receptie-197@3x.png", ""),  AV10ReceptionPageId.ToString(),  "Content",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
      }

      protected void S121( )
      {
         /* 'CALENDARANDMYACTIVITYTILES' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  "",  "#000000",  context.GetMessage( "center", ""),  context.GetMessage( "Calendar", ""),  0,  "",  AV20baseUrl+context.GetMessage( "/media/Calendar.png", ""),  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Activity", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  "",  "",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
      }

      protected void S131( )
      {
         /* 'LOCATIONTILE' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Location", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  AV20baseUrl+context.GetMessage( "/media/LocationInfo.png", ""),  AV11LocationPageId.ToString(),  "Content",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "Location", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "Location", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV17TilesItem.gxTpr_Action.gxTpr_Objecttype = "Content";
         AV17TilesItem.gxTpr_Action.gxTpr_Objectid = AV11LocationPageId.ToString();
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
      }

      protected void S141( )
      {
         /* 'SERVICESTILES' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Care", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV12CarePageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Living", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV13LivingPageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV17TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Services", ""),  "#000000",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV14ServicesPageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV17TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
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
         AV15BC_HomePage = new SdtTrn_AppVersion_Page(context);
         AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV20baseUrl = "";
         AV16SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private string AV20baseUrl ;
      private Guid AV10ReceptionPageId ;
      private Guid AV11LocationPageId ;
      private Guid AV12CarePageId ;
      private Guid AV13LivingPageId ;
      private Guid AV14ServicesPageId ;
      private SdtTrn_AppVersion_Page AV15BC_HomePage ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV19GAMApplication ;
      private SdtSDT_MenuPage AV16SDT_MenuPage ;
      private SdtSDT_MenuPage_RowsItem AV18RowsItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV17TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 ;
      private SdtTrn_AppVersion_Page aP5_BC_HomePage ;
   }

}
