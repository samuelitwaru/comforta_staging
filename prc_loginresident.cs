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
   public class prc_loginresident : GXProcedure
   {
      public prc_loginresident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loginresident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_secretKey ,
                           out string aP1_response )
      {
         this.AV13secretKey = aP0_secretKey;
         this.AV16response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV16response;
      }

      public string executeUdp( string aP0_secretKey )
      {
         execute(aP0_secretKey, out aP1_response);
         return AV16response ;
      }

      public void executeSubmit( string aP0_secretKey ,
                                 out string aP1_response )
      {
         this.AV13secretKey = aP0_secretKey;
         this.AV16response = "" ;
         SubmitImpl();
         aP1_response=this.AV16response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9clientId = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getclientid();
         if ( StringUtil.StrCmp(AV11HttpRequest.ServerHost, "localhost") == 0 )
         {
            AV8baseUrl = "http://localhost:8082/Comforta_version2DevelopmentNETPostgreSQL";
         }
         else
         {
            AV8baseUrl = "https://staging.comforta.yukon.software";
         }
         AV14url = AV8baseUrl + "/oauth/access_token";
         new prc_logtofile(context ).execute(  AV14url) ;
         new prc_decodeqrcode(context ).execute(  AV13secretKey, out  AV15username, out  AV12password) ;
         AV10httpclient.AddHeader("Content-Type", "application/x-www-form-urlencoded");
         AV10httpclient.AddVariable("client_id", AV9clientId);
         AV10httpclient.AddVariable("grant_type", "password");
         AV10httpclient.AddVariable("scope", "gam_user_data");
         AV10httpclient.AddVariable("username", AV15username);
         AV10httpclient.AddVariable("password", AV12password);
         AV10httpclient.Execute("POST", AV14url);
         AV17result = AV10httpclient.ToString();
         if ( AV10httpclient.StatusCode != 200 )
         {
            AV19ErrorResponse.gxTpr_Message = AV10httpclient.ErrDescription;
            AV19ErrorResponse.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(AV10httpclient.StatusCode), 10, 2));
            AV16response = AV19ErrorResponse.ToJSonString(false, true);
         }
         else
         {
            AV18LoginResponse.FromJSonString(AV17result, null);
            AV16response = AV18LoginResponse.ToJSonString(false, true);
         }
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
         AV16response = "";
         AV9clientId = "";
         AV11HttpRequest = new GxHttpRequest( context);
         AV8baseUrl = "";
         AV14url = "";
         AV15username = "";
         AV12password = "";
         AV10httpclient = new GxHttpClient( context);
         AV17result = "";
         AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
         AV18LoginResponse = new SdtSDT_LoginResidentResponse(context);
         /* GeneXus formulas. */
      }

      private string AV13secretKey ;
      private string AV16response ;
      private string AV17result ;
      private string AV9clientId ;
      private string AV8baseUrl ;
      private string AV14url ;
      private string AV15username ;
      private string AV12password ;
      private GxHttpClient AV10httpclient ;
      private GxHttpRequest AV11HttpRequest ;
      private SdtSDT_ErrorResponse AV19ErrorResponse ;
      private SdtSDT_LoginResidentResponse AV18LoginResponse ;
      private string aP1_response ;
   }

}
