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
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "Reception", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "Reception", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV17TilesItem.gxTpr_Action.gxTpr_Objecttype = "Content";
         AV17TilesItem.gxTpr_Action.gxTpr_Objectid = AV10ReceptionPageId.ToString();
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
      }

      protected void S121( )
      {
         /* 'CALENDARANDMYACTIVITYTILES' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "Calendar", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "Calendar", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "My Activity", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "My Activity", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV16SDT_MenuPage.gxTpr_Rows.Add(AV18RowsItem, 0);
      }

      protected void S131( )
      {
         /* 'LOCATIONTILE' Routine */
         returnInSub = false;
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV18RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
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
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "My Care", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "My Care", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV17TilesItem.gxTpr_Permissions.Add("My Care", 0);
         AV17TilesItem.gxTpr_Action.gxTpr_Objecttype = "Menu";
         AV17TilesItem.gxTpr_Action.gxTpr_Objectid = AV12CarePageId.ToString();
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "My Living", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "My Living", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV17TilesItem.gxTpr_Permissions.Add("My Living", 0);
         AV17TilesItem.gxTpr_Action.gxTpr_Objecttype = "Menu";
         AV17TilesItem.gxTpr_Action.gxTpr_Objectid = AV13LivingPageId.ToString();
         AV18RowsItem.gxTpr_Tiles.Add(AV17TilesItem, 0);
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV17TilesItem.gxTpr_Name = context.GetMessage( "My Services", "");
         AV17TilesItem.gxTpr_Text = context.GetMessage( "My Services", "");
         AV17TilesItem.gxTpr_Color = "";
         AV17TilesItem.gxTpr_Bgcolor = "";
         AV17TilesItem.gxTpr_Bgimageurl = "";
         AV17TilesItem.gxTpr_Opacity = 0;
         AV17TilesItem.gxTpr_Permissions.Add("My Services", 0);
         AV17TilesItem.gxTpr_Action.gxTpr_Objecttype = "Menu";
         AV17TilesItem.gxTpr_Action.gxTpr_Objectid = AV14ServicesPageId.ToString();
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
         AV16SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV17TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV18RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private Guid AV10ReceptionPageId ;
      private Guid AV11LocationPageId ;
      private Guid AV12CarePageId ;
      private Guid AV13LivingPageId ;
      private Guid AV14ServicesPageId ;
      private SdtTrn_AppVersion_Page AV15BC_HomePage ;
      private SdtSDT_MenuPage AV16SDT_MenuPage ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV17TilesItem ;
      private SdtSDT_MenuPage_RowsItem AV18RowsItem ;
      private SdtTrn_AppVersion_Page aP5_BC_HomePage ;
   }

}
