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
   public class prc_initweblinkanddynamicformpages : GXProcedure
   {
      public prc_initweblinkanddynamicformpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initweblinkanddynamicformpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtTrn_AppVersion_Page aP0_BC_WebLinkPage ,
                           out SdtTrn_AppVersion_Page aP1_BC_DynamicFormPage )
      {
         this.AV9BC_WebLinkPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV8BC_DynamicFormPage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP0_BC_WebLinkPage=this.AV9BC_WebLinkPage;
         aP1_BC_DynamicFormPage=this.AV8BC_DynamicFormPage;
      }

      public SdtTrn_AppVersion_Page executeUdp( out SdtTrn_AppVersion_Page aP0_BC_WebLinkPage )
      {
         execute(out aP0_BC_WebLinkPage, out aP1_BC_DynamicFormPage);
         return AV8BC_DynamicFormPage ;
      }

      public void executeSubmit( out SdtTrn_AppVersion_Page aP0_BC_WebLinkPage ,
                                 out SdtTrn_AppVersion_Page aP1_BC_DynamicFormPage )
      {
         this.AV9BC_WebLinkPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV8BC_DynamicFormPage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP0_BC_WebLinkPage=this.AV9BC_WebLinkPage;
         aP1_BC_DynamicFormPage=this.AV8BC_DynamicFormPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV9BC_WebLinkPage = new SdtTrn_AppVersion_Page(context);
         AV8BC_DynamicFormPage = new SdtTrn_AppVersion_Page(context);
         /* GeneXus formulas. */
      }

      private SdtTrn_AppVersion_Page AV9BC_WebLinkPage ;
      private SdtTrn_AppVersion_Page AV8BC_DynamicFormPage ;
      private SdtTrn_AppVersion_Page aP0_BC_WebLinkPage ;
      private SdtTrn_AppVersion_Page aP1_BC_DynamicFormPage ;
   }

}
