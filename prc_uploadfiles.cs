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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_uploadfiles : GXProcedure
   {
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

      public prc_uploadfiles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_uploadfiles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GxFile aP0_File ,
                           out string aP1_response )
      {
         this.AV9File = aP0_File;
         this.AV10response = "" ;
         initialize();
         ExecuteImpl();
         aP0_File=this.AV9File;
         aP1_response=this.AV10response;
      }

      public string executeUdp( ref GxFile aP0_File )
      {
         execute(ref aP0_File, out aP1_response);
         return AV10response ;
      }

      public void executeSubmit( ref GxFile aP0_File ,
                                 out string aP1_response )
      {
         this.AV9File = aP0_File;
         this.AV10response = "" ;
         SubmitImpl();
         aP0_File=this.AV9File;
         aP1_response=this.AV10response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  ">>>>>>>>>>>>>>>>>>>>>>"+AV9File.GetName()) ;
         new prc_logtofile(context ).execute(  AV8HttpRequest.ToString()) ;
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
         AV10response = "";
         AV8HttpRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private string AV10response ;
      private GxHttpRequest AV8HttpRequest ;
      private GxFile AV9File ;
      private GxFile aP0_File ;
      private string aP1_response ;
   }

}
