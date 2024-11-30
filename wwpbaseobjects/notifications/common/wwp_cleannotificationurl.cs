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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_cleannotificationurl : GXProcedure
   {
      public wwp_cleannotificationurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_cleannotificationurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_Url )
      {
         this.AV8Url = aP0_Url;
         initialize();
         ExecuteImpl();
         aP0_Url=this.AV8Url;
      }

      public string executeUdp( )
      {
         execute(ref aP0_Url);
         return AV8Url ;
      }

      public void executeSubmit( ref string aP0_Url )
      {
         this.AV8Url = aP0_Url;
         SubmitImpl();
         aP0_Url=this.AV8Url;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Url = StringUtil.Substring( AV8Url, StringUtil.StringSearchRev( AV8Url, "/", -1)+1, -1);
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
         /* GeneXus formulas. */
      }

      private string AV8Url ;
      private string aP0_Url ;
   }

}
