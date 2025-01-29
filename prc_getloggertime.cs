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
   public class prc_getloggertime : GXProcedure
   {
      public prc_getloggertime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getloggertime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_LogTimeString )
      {
         this.AV9LogTimeString = "" ;
         initialize();
         ExecuteImpl();
         aP0_LogTimeString=this.AV9LogTimeString;
      }

      public string executeUdp( )
      {
         execute(out aP0_LogTimeString);
         return AV9LogTimeString ;
      }

      public void executeSubmit( out string aP0_LogTimeString )
      {
         this.AV9LogTimeString = "" ;
         SubmitImpl();
         aP0_LogTimeString=this.AV9LogTimeString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8LogTime = DateTimeUtil.ResetDate(DateTimeUtil.NowMS( context));
         AV9LogTimeString = context.localUtil.TToC( AV8LogTime, 0, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
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
         AV9LogTimeString = "";
         AV8LogTime = (DateTime)(DateTime.MinValue);
         /* GeneXus formulas. */
      }

      private string AV9LogTimeString ;
      private DateTime AV8LogTime ;
      private string aP0_LogTimeString ;
   }

}
