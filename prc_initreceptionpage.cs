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
   public class prc_initreceptionpage : GXProcedure
   {
      public prc_initreceptionpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initreceptionpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref Guid aP0_LocationId ,
                           ref Guid aP1_OrganisationId ,
                           out SdtTrn_AppVersion_Page aP2_BC_Page )
      {
         this.AV13LocationId = aP0_LocationId;
         this.AV14OrganisationId = aP1_OrganisationId;
         this.AV8BC_Page = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV13LocationId;
         aP1_OrganisationId=this.AV14OrganisationId;
         aP2_BC_Page=this.AV8BC_Page;
      }

      public SdtTrn_AppVersion_Page executeUdp( ref Guid aP0_LocationId ,
                                                ref Guid aP1_OrganisationId )
      {
         execute(ref aP0_LocationId, ref aP1_OrganisationId, out aP2_BC_Page);
         return AV8BC_Page ;
      }

      public void executeSubmit( ref Guid aP0_LocationId ,
                                 ref Guid aP1_OrganisationId ,
                                 out SdtTrn_AppVersion_Page aP2_BC_Page )
      {
         this.AV13LocationId = aP0_LocationId;
         this.AV14OrganisationId = aP1_OrganisationId;
         this.AV8BC_Page = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP0_LocationId=this.AV13LocationId;
         aP1_OrganisationId=this.AV14OrganisationId;
         aP2_BC_Page=this.AV8BC_Page;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9BC_Trn_Location.Load(AV13LocationId, AV14OrganisationId);
         AV8BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV8BC_Page.gxTpr_Pagename = "Reception";
         AV8BC_Page.gxTpr_Pagetype = "Content";
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV11ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
         AV11ContentItem.gxTpr_Contentvalue = AV9BC_Trn_Location.gxTpr_Locationimage_gxi;
         AV10SDT_ContentPage.gxTpr_Content.Add(AV11ContentItem, 0);
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV11ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
         AV11ContentItem.gxTpr_Contentvalue = AV9BC_Trn_Location.gxTpr_Locationdescription;
         AV10SDT_ContentPage.gxTpr_Content.Add(AV11ContentItem, 0);
         AV12CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV12CtaItem.gxTpr_Ctaid = Guid.NewGuid( );
         AV12CtaItem.gxTpr_Ctalabel = "CALL US";
         AV12CtaItem.gxTpr_Ctatype = "Phone";
         AV12CtaItem.gxTpr_Ctaaction = AV9BC_Trn_Location.gxTpr_Locationphone;
         AV12CtaItem.gxTpr_Ctabuttontype = "Round";
         AV10SDT_ContentPage.gxTpr_Cta.Add(AV12CtaItem, 0);
         AV12CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV12CtaItem.gxTpr_Ctaid = Guid.NewGuid( );
         AV12CtaItem.gxTpr_Ctalabel = "EMAIL US";
         AV12CtaItem.gxTpr_Ctatype = "Phone";
         AV12CtaItem.gxTpr_Ctaaction = AV9BC_Trn_Location.gxTpr_Locationphone;
         AV12CtaItem.gxTpr_Ctabuttontype = "Round";
         AV10SDT_ContentPage.gxTpr_Cta.Add(AV12CtaItem, 0);
         AV8BC_Page.gxTpr_Pagestructure = AV10SDT_ContentPage.ToJSonString(false, true);
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
         AV8BC_Page = new SdtTrn_AppVersion_Page(context);
         AV9BC_Trn_Location = new SdtTrn_Location(context);
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV10SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV12CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         /* GeneXus formulas. */
      }

      private Guid AV13LocationId ;
      private Guid AV14OrganisationId ;
      private Guid aP0_LocationId ;
      private Guid aP1_OrganisationId ;
      private SdtTrn_AppVersion_Page AV8BC_Page ;
      private SdtTrn_Location AV9BC_Trn_Location ;
      private SdtSDT_ContentPage_ContentItem AV11ContentItem ;
      private SdtSDT_ContentPage AV10SDT_ContentPage ;
      private SdtSDT_ContentPage_CtaItem AV12CtaItem ;
      private SdtTrn_AppVersion_Page aP2_BC_Page ;
   }

}
