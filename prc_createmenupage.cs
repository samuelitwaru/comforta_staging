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
   public class prc_createmenupage : GXProcedure
   {
      public prc_createmenupage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createmenupage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           out SdtSDT_MenuPage aP2_SDT_MenuPage ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV12PageName = aP1_PageName;
         this.AV13SDT_MenuPage = new SdtSDT_MenuPage(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_MenuPage=this.AV13SDT_MenuPage;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      out SdtSDT_MenuPage aP2_SDT_MenuPage )
      {
         execute(aP0_AppVersionId, aP1_PageName, out aP2_SDT_MenuPage, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 out SdtSDT_MenuPage aP2_SDT_MenuPage ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV12PageName = aP1_PageName;
         this.AV13SDT_MenuPage = new SdtSDT_MenuPage(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_MenuPage=this.AV13SDT_MenuPage;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV10BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV10BC_Page.gxTpr_Pagename = AV12PageName;
         AV10BC_Page.gxTpr_Pagetype = "Menu";
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         /* Execute user subroutine: 'DEFAULTMENUPAGETILE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10BC_Page.gxTpr_Pagestructure = AV13SDT_MenuPage.ToJSonString(false, true);
         cleanup();
      }

      protected void S111( )
      {
         /* 'DEFAULTMENUPAGETILE' Routine */
         returnInSub = false;
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV16TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Tile", ""), out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV16TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV17RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV17RowsItem.gxTpr_Id = Guid.NewGuid( ).ToString();
         AV17RowsItem.gxTpr_Tiles.Add(AV16TilesItem, 0);
         AV13SDT_MenuPage.gxTpr_Rows.Add(AV17RowsItem, 0);
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
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV10BC_Page = new SdtTrn_AppVersion_Page(context);
         AV16TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV17RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private string AV12PageName ;
      private Guid AV11AppVersionId ;
      private SdtSDT_MenuPage AV13SDT_MenuPage ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_AppVersion_Page AV10BC_Page ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV16TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 ;
      private SdtSDT_MenuPage_RowsItem AV17RowsItem ;
      private SdtSDT_MenuPage aP2_SDT_MenuPage ;
      private SdtSDT_Error aP3_SDT_Error ;
   }

}
