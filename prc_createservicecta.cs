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
   public class prc_createservicecta : GXProcedure
   {
      public prc_createservicecta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createservicecta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtSDT_Error aP0_SDT_Error )
      {
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( )
      {
         execute(out aP0_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( out SdtSDT_Error aP0_SDT_Error )
      {
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_Error=this.AV9SDT_Error;
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
         AV9SDT_Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private SdtSDT_Error AV9SDT_Error ;
      private SdtSDT_Error aP0_SDT_Error ;
   }

}
