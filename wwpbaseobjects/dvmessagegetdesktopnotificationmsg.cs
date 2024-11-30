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
namespace GeneXus.Programs.wwpbaseobjects {
   public class dvmessagegetdesktopnotificationmsg : GXProcedure
   {
      public dvmessagegetdesktopnotificationmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dvmessagegetdesktopnotificationmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Title ,
                           string aP1_Text ,
                           string aP2_DesktopNotificationIconUrl ,
                           string aP3_ClickRedirectURL ,
                           out string aP4_Parms )
      {
         this.AV12Title = aP0_Title;
         this.AV11Text = aP1_Text;
         this.AV9DesktopNotificationIconUrl = aP2_DesktopNotificationIconUrl;
         this.AV8ClickRedirectURL = aP3_ClickRedirectURL;
         this.AV10Parms = "" ;
         initialize();
         ExecuteImpl();
         aP4_Parms=this.AV10Parms;
      }

      public string executeUdp( string aP0_Title ,
                                string aP1_Text ,
                                string aP2_DesktopNotificationIconUrl ,
                                string aP3_ClickRedirectURL )
      {
         execute(aP0_Title, aP1_Text, aP2_DesktopNotificationIconUrl, aP3_ClickRedirectURL, out aP4_Parms);
         return AV10Parms ;
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Text ,
                                 string aP2_DesktopNotificationIconUrl ,
                                 string aP3_ClickRedirectURL ,
                                 out string aP4_Parms )
      {
         this.AV12Title = aP0_Title;
         this.AV11Text = aP1_Text;
         this.AV9DesktopNotificationIconUrl = aP2_DesktopNotificationIconUrl;
         this.AV8ClickRedirectURL = aP3_ClickRedirectURL;
         this.AV10Parms = "" ;
         SubmitImpl();
         aP4_Parms=this.AV10Parms;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV10Parms;
         new GeneXus.Programs.wwpbaseobjects.dvmessagegetadvancednotificationmsg(context ).execute(  AV12Title,  AV11Text,  AV13Type,  "",  "na",  "true",  AV9DesktopNotificationIconUrl,  AV8ClickRedirectURL, out  GXt_char1) ;
         AV10Parms = GXt_char1;
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
         AV10Parms = "";
         GXt_char1 = "";
         AV13Type = "";
         /* GeneXus formulas. */
      }

      private string AV12Title ;
      private string AV11Text ;
      private string GXt_char1 ;
      private string AV13Type ;
      private string AV9DesktopNotificationIconUrl ;
      private string AV8ClickRedirectURL ;
      private string AV10Parms ;
      private string aP4_Parms ;
   }

}
