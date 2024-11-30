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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_getsmtpparameters : GXProcedure
   {
      public wwp_getsmtpparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getsmtpparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT )
      {
         this.AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context) ;
         initialize();
         ExecuteImpl();
         aP0_SMTPParametersSDT=this.AV10SMTPParametersSDT;
      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT executeUdp( )
      {
         execute(out aP0_SMTPParametersSDT);
         return AV10SMTPParametersSDT ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT )
      {
         this.AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context) ;
         SubmitImpl();
         aP0_SMTPParametersSDT=this.AV10SMTPParametersSDT;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV12Pgmname,  "Getting SMTP Parameters") ;
         AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Host", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Host = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_integer(  "SMTP_Port", ref  AV9IntegerParameter) ;
         AV10SMTPParametersSDT.gxTpr_Port = (short)(AV9IntegerParameter);
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Username", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Username = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Password", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Password = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_boolean(  "SMTP_Authentication", ref  AV8BooleanParameter) ;
         if ( AV8BooleanParameter )
         {
            AV10SMTPParametersSDT.gxTpr_Authentication = 1;
         }
         else
         {
            AV10SMTPParametersSDT.gxTpr_Authentication = 0;
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_boolean(  "SMTP_Secure", ref  AV8BooleanParameter) ;
         if ( AV8BooleanParameter )
         {
            AV10SMTPParametersSDT.gxTpr_Secure = 1;
         }
         else
         {
            AV10SMTPParametersSDT.gxTpr_Secure = 0;
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_integer(  "SMTP_Timeout", ref  AV9IntegerParameter) ;
         AV10SMTPParametersSDT.gxTpr_Timeout = (short)(AV9IntegerParameter);
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV12Pgmname,  "SMTP Parameters: "+AV10SMTPParametersSDT.ToJSonString(false, true)) ;
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
         AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         AV12Pgmname = "";
         AV11TextParameter = "";
         AV12Pgmname = "WWPBaseObjects.Mail.WWP_GetSMTPParameters";
         /* GeneXus formulas. */
         AV12Pgmname = "WWPBaseObjects.Mail.WWP_GetSMTPParameters";
      }

      private long AV9IntegerParameter ;
      private string AV12Pgmname ;
      private bool AV8BooleanParameter ;
      private string AV11TextParameter ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT AV10SMTPParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT ;
   }

}
