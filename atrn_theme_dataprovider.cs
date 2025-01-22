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
   public class atrn_theme_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_theme_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>()  ;
         execute(out aP0_Gxm2rootcol);
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

      public atrn_theme_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_theme_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_Theme> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "05b80e4f-effe-4d46-afbd-7c72da5a4afc", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Minimalistic", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Merriweather serif", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#554940";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#7f3e3a";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c8653e";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#b3783e";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#d99e80";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c8ad94";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#668d63";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#7a8f92";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#a2ad9f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#c6c6c6";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "4ddc1f46-d08a-4c11-9280-0695be8b833f", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Modern", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Helvetica", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#173f5f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#535353";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#986b5d";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#20639b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#758a71";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#788799";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#a72928";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ec6665";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ee6809";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#eea622";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( context.GetMessage( "2db8770b-2e22-4522-870f-d0d8b3ea0ed3", ""));
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Retro", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Arial", "");
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "accentColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#653993";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "backgroundColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#06394f";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "borderColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#18668b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "buttonTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#126e68";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#ead1b5";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardBgColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#f09605";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "cardTextColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#f57f5c";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "primaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#dd5342";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "secondaryColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#b11d3b";
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm3trn_theme_color, 0);
         Gxm3trn_theme_color.gxTpr_Colorname = context.GetMessage( "textColor", "");
         Gxm3trn_theme_color.gxTpr_Colorcode = "#844a27";
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
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm3trn_theme_color = new SdtTrn_Theme_Color(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Theme> Gxm2rootcol ;
      private SdtTrn_Theme Gxm1trn_theme ;
      private SdtTrn_Theme_Color Gxm3trn_theme_color ;
      private GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol ;
   }

}
