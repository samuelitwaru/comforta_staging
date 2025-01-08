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
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( "05b80e4f-effe-4d46-afbd-7c72da5a4afc");
         Gxm1trn_theme.gxTpr_Trn_themename = "Minimalistic";
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = "Merriweather, serif";
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( "4ddc1f46-d08a-4c11-9280-0695be8b833f");
         Gxm1trn_theme.gxTpr_Trn_themename = "Modern";
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = "Helvetica";
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themeid = StringUtil.StrToGuid( "2db8770b-2e22-4522-870f-d0d8b3ea0ed3");
         Gxm1trn_theme.gxTpr_Trn_themename = "Retro";
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = "Arial";
         Gxm1trn_theme.gxTpr_Trn_themefontsize = 10;
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
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Theme> Gxm2rootcol ;
      private SdtTrn_Theme Gxm1trn_theme ;
      private GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol ;
   }

}
