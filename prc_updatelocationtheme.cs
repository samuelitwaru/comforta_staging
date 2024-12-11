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
   public class prc_updatelocationtheme : GXProcedure
   {
      public prc_updatelocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_ThemeId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           out SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_Theme=this.AV11SDT_Theme;
      }

      public SdtSDT_Theme executeUdp( Guid aP0_ThemeId ,
                                      Guid aP1_LocationId ,
                                      Guid aP2_OrganisationId )
      {
         execute(aP0_ThemeId, aP1_LocationId, aP2_OrganisationId, out aP3_SDT_Theme);
         return AV11SDT_Theme ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         SubmitImpl();
         aP3_SDT_Theme=this.AV11SDT_Theme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  "Reached Prc_UpdateLocationTheme") ;
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
         AV11SDT_Theme = new SdtSDT_Theme(context);
         /* GeneXus formulas. */
      }

      private Guid AV8ThemeId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private SdtSDT_Theme aP3_SDT_Theme ;
   }

}
