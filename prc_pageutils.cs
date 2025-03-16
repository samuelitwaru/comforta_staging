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
   public class prc_pageutils : GXProcedure
   {
      public prc_pageutils( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pageutils( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_defaultmenupagetile( out SdtSDT_MenuPage_RowsItem_TilesItem aP0_TilesItem )
      {
         this.AV9TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context) ;
         initialize();
         /* DefaultMenuPageTile Constructor */
         AV9TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV9TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV9TilesItem.gxTpr_Name = context.GetMessage( "Tile", "");
         AV9TilesItem.gxTpr_Text = context.GetMessage( "Tile", "");
         AV9TilesItem.gxTpr_Color = "";
         AV9TilesItem.gxTpr_Bgcolor = "";
         AV9TilesItem.gxTpr_Align = context.GetMessage( "Center", "");
         AV9TilesItem.gxTpr_Bgimageurl = "";
         AV9TilesItem.gxTpr_Opacity = 0;
         AV9TilesItem.gxTpr_Permissions = new();
         ExecuteImpl();
         aP0_TilesItem=this.AV9TilesItem;
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
         AV9TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private SdtSDT_MenuPage_RowsItem_TilesItem AV9TilesItem ;
   }

}
