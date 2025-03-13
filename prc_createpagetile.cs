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
   public class prc_createpagetile : GXProcedure
   {
      public prc_createpagetile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createpagetile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TileName ,
                           out SdtSDT_MenuPage_RowsItem_TilesItem aP1_TilesItem )
      {
         this.AV9TileName = aP0_TileName;
         this.AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context) ;
         initialize();
         ExecuteImpl();
         aP1_TilesItem=this.AV8TilesItem;
      }

      public SdtSDT_MenuPage_RowsItem_TilesItem executeUdp( string aP0_TileName )
      {
         execute(aP0_TileName, out aP1_TilesItem);
         return AV8TilesItem ;
      }

      public void executeSubmit( string aP0_TileName ,
                                 out SdtSDT_MenuPage_RowsItem_TilesItem aP1_TilesItem )
      {
         this.AV9TileName = aP0_TileName;
         this.AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context) ;
         SubmitImpl();
         aP1_TilesItem=this.AV8TilesItem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV8TilesItem.gxTpr_Id = Guid.NewGuid( ).ToString().ToString();
         AV8TilesItem.gxTpr_Name = context.GetMessage( "Tile", "");
         AV8TilesItem.gxTpr_Text = context.GetMessage( "Tile", "");
         AV8TilesItem.gxTpr_Color = "";
         AV8TilesItem.gxTpr_Bgcolor = "";
         AV8TilesItem.gxTpr_Bgimageurl = "";
         AV8TilesItem.gxTpr_Opacity = 0;
         AV8TilesItem.gxTpr_Permissions = new();
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
         AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private string AV9TileName ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV8TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem aP1_TilesItem ;
   }

}
