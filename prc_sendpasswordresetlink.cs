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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_sendpasswordresetlink : GXProcedure
   {
      public prc_sendpasswordresetlink( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendpasswordresetlink( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGAMGUID ,
                           out bool aP1_isSuccessful )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV19isSuccessful = false ;
         initialize();
         ExecuteImpl();
         aP1_isSuccessful=this.AV19isSuccessful;
      }

      public bool executeUdp( string aP0_UserGAMGUID )
      {
         execute(aP0_UserGAMGUID, out aP1_isSuccessful);
         return AV19isSuccessful ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 out bool aP1_isSuccessful )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV19isSuccessful = false ;
         SubmitImpl();
         aP1_isSuccessful=this.AV19isSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15GAMUser.load( AV23UserGAMGUID);
         if ( AV15GAMUser.success() )
         {
            AV28KeyToChangePassword = AV15GAMUser.recoverpasswordbykey(out  AV30GAMErrorCollection);
            GXt_char1 = AV27LinkURL;
            new gam_buildappurl(context ).execute(  formatLink("urecoverpasswordstep2.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(AV23UserGAMGUID)),GXUtil.UrlEncode(StringUtil.RTrim(AV28KeyToChangePassword))}, new string[] {"UserGAMGUID","KeyToChangePassword"}) , out  GXt_char1) ;
            AV27LinkURL = GXt_char1;
            AV24Username = AV15GAMUser.gxTpr_Firstname + " " + AV15GAMUser.gxTpr_Lastname;
            if ( AV30GAMErrorCollection.Count == 0 )
            {
               AV22SMTPSession.Host = context.GetMessage( "comforta.yukon.software", "");
               AV22SMTPSession.Port = 465;
               AV22SMTPSession.Secure = 1;
               AV22SMTPSession.Authentication = 0;
               AV22SMTPSession.AuthenticationMethod = "";
               AV22SMTPSession.UserName = context.GetMessage( "no-reply@comforta.yukon.software", "");
               AV22SMTPSession.Password = context.GetMessage( "2uSFuxkquz", "");
               AV22SMTPSession.Sender.Address = context.GetMessage( "no-reply@comforta.yukon.software", "");
               AV22SMTPSession.Sender.Name = "Comforta Software";
               AV9MailRecipient.Address = AV15GAMUser.gxTpr_Email;
               AV9MailRecipient.Name = AV24Username;
               AV20MailMessage.Subject = "Password reset";
               AV20MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+context.GetMessage( "<div style=\"background-color: #008080; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear ", "")+AV24Username+context.GetMessage( ",</p><p>You are recieving this email because you requested for password reset.</p><p>Please click the button below to reset your paassword:</p>", "")+context.GetMessage( "</b></p><a href=\"", "")+AV27LinkURL+context.GetMessage( "\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #008080; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Reset Password</a>", "")+context.GetMessage( "<p>Please note that the link expires in 36 hours.</p>", "")+context.GetMessage( "</div></div>", "");
               AV20MailMessage.To.Add(AV9MailRecipient);
               AV22SMTPSession.Login();
               AV22SMTPSession.Send(AV20MailMessage);
               if ( ( AV22SMTPSession.ErrCode < 1 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV22SMTPSession.ErrDescription), context.GetMessage( "OK", "")) == 0 ) )
               {
                  AV22SMTPSession.Logout();
                  AV19isSuccessful = true;
               }
               else
               {
                  AV12ErrDescription = context.GetMessage( "Sending password reset email failed - ", "") + StringUtil.Str( (decimal)(AV22SMTPSession.ErrCode), 10, 2) + " " + AV22SMTPSession.ErrDescription;
                  AV19isSuccessful = false;
               }
            }
            else
            {
               AV31GXV1 = 1;
               while ( AV31GXV1 <= AV30GAMErrorCollection.Count )
               {
                  AV8GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30GAMErrorCollection.Item(AV31GXV1));
                  AV12ErrDescription += AV8GAMErrorItem.gxTpr_Message + " ";
                  AV31GXV1 = (int)(AV31GXV1+1);
               }
               AV19isSuccessful = false;
            }
         }
         else
         {
            AV12ErrDescription = context.GetMessage( "Failed to load user", "");
            AV19isSuccessful = false;
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
         AV15GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV28KeyToChangePassword = "";
         AV30GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV27LinkURL = "";
         GXt_char1 = "";
         AV24Username = "";
         AV22SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV20MailMessage = new GeneXus.Mail.GXMailMessage();
         AV12ErrDescription = "";
         AV8GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV31GXV1 ;
      private string AV28KeyToChangePassword ;
      private string GXt_char1 ;
      private string AV12ErrDescription ;
      private bool AV19isSuccessful ;
      private string AV23UserGAMGUID ;
      private string AV27LinkURL ;
      private string AV24Username ;
      private GeneXus.Mail.GXMailMessage AV20MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV9MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV22SMTPSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV15GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMErrorItem ;
      private bool aP1_isSuccessful ;
   }

}
