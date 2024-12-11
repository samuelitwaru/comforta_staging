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
   public class prc_senduseractivationlink : GXProcedure
   {
      public prc_senduseractivationlink( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_senduseractivationlink( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGAMGUID ,
                           ref string aP1_baseUrl ,
                           ref bool aP2_isSuccessful ,
                           ref string aP3_ErrDescription ,
                           ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors )
      {
         this.AV18UserGAMGUID = aP0_UserGAMGUID;
         this.AV23baseUrl = aP1_baseUrl;
         this.AV14isSuccessful = aP2_isSuccessful;
         this.AV26ErrDescription = aP3_ErrDescription;
         this.AV11GAMErrors = aP4_GAMErrors;
         initialize();
         ExecuteImpl();
         aP1_baseUrl=this.AV23baseUrl;
         aP2_isSuccessful=this.AV14isSuccessful;
         aP3_ErrDescription=this.AV26ErrDescription;
         aP4_GAMErrors=this.AV11GAMErrors;
      }

      public GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> executeUdp( string aP0_UserGAMGUID ,
                                                                                            ref string aP1_baseUrl ,
                                                                                            ref bool aP2_isSuccessful ,
                                                                                            ref string aP3_ErrDescription )
      {
         execute(aP0_UserGAMGUID, ref aP1_baseUrl, ref aP2_isSuccessful, ref aP3_ErrDescription, ref aP4_GAMErrors);
         return AV11GAMErrors ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 ref string aP1_baseUrl ,
                                 ref bool aP2_isSuccessful ,
                                 ref string aP3_ErrDescription ,
                                 ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors )
      {
         this.AV18UserGAMGUID = aP0_UserGAMGUID;
         this.AV23baseUrl = aP1_baseUrl;
         this.AV14isSuccessful = aP2_isSuccessful;
         this.AV26ErrDescription = aP3_ErrDescription;
         this.AV11GAMErrors = aP4_GAMErrors;
         SubmitImpl();
         aP1_baseUrl=this.AV23baseUrl;
         aP2_isSuccessful=this.AV14isSuccessful;
         aP3_ErrDescription=this.AV26ErrDescription;
         aP4_GAMErrors=this.AV11GAMErrors;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV16Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV12GAMUser.load( AV18UserGAMGUID);
            if ( AV12GAMUser.success() )
            {
               AV19Username = AV12GAMUser.gxTpr_Firstname + " " + AV12GAMUser.gxTpr_Lastname;
               AV9ActivactionKey = AV12GAMUser.getnewactivationkey(out  AV11GAMErrors);
               if ( AV11GAMErrors.Count == 0 )
               {
                  AV17SMTPSession.Host = "comforta.yukon.software";
                  AV17SMTPSession.Port = 465;
                  AV17SMTPSession.Secure = 1;
                  AV17SMTPSession.Authentication = 0;
                  AV17SMTPSession.AuthenticationMethod = "";
                  AV17SMTPSession.UserName = "no-reply@comforta.yukon.software";
                  AV17SMTPSession.Password = "2uSFuxkquz";
                  AV17SMTPSession.Sender.Address = "no-reply@comforta.yukon.software";
                  AV17SMTPSession.Sender.Name = "Comforta Software";
                  AV8MailRecipient.Address = AV12GAMUser.gxTpr_Email;
                  AV8MailRecipient.Name = AV19Username;
                  AV15MailMessage.Subject = "Welcome to Comforta";
                  AV15MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+"<div style=\"background-color: #008080; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear "+AV19Username+",</p><p>Welcome to Comforta Software! We are thrilled to have you on board.</p><p>To get started, we need to verify your email address. Please click the button below to activate your account:</p>"+"</b></p><a href=\""+AV23baseUrl+"WP_UserActivation.aspx?ActivationKey="+AV9ActivactionKey+"&GamGuid="+AV12GAMUser.gxTpr_Guid+"\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #008080; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Verify Email</a>"+"<p>Please note that the link expires in 36 hours.</p>"+"<p>Once you have activated your account and set a password, you will gain access to the platform.</p>"+"<br><p>Healthy Living!</p><p>Comforta Software</p></div></div>";
                  AV15MailMessage.To.Add(AV8MailRecipient);
                  AV17SMTPSession.Login();
                  AV17SMTPSession.Send(AV15MailMessage);
                  if ( AV17SMTPSession.ErrCode == 0 )
                  {
                     AV17SMTPSession.Logout();
                     AV14isSuccessful = true;
                  }
                  else
                  {
                     AV26ErrDescription = "Sending activation email failed - " + StringUtil.Str( (decimal)(AV17SMTPSession.ErrCode), 10, 2) + " " + AV17SMTPSession.ErrDescription;
                     AV14isSuccessful = false;
                     new prc_logtofile(context ).execute(  "Error Sending Mail: "+AV17SMTPSession.ErrDescription) ;
                  }
               }
               else
               {
                  AV26ErrDescription = "Sending activation email failed - ";
                  AV27GXV1 = 1;
                  while ( AV27GXV1 <= AV11GAMErrors.Count )
                  {
                     AV25GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrors.Item(AV27GXV1));
                     AV26ErrDescription += AV25GAMErrorItem.gxTpr_Message + " ";
                     AV27GXV1 = (int)(AV27GXV1+1);
                  }
                  AV14isSuccessful = false;
               }
            }
            else
            {
               AV26ErrDescription = "Failed to load user";
               AV14isSuccessful = false;
            }
         }
         else
         {
            AV26ErrDescription = "Unknown user activation method - " + AV16Repository.gxTpr_Useractivationmethod + " - " + "U";
            AV14isSuccessful = false;
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
         AV16Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV19Username = "";
         AV9ActivactionKey = "";
         AV17SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV8MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV25GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV27GXV1 ;
      private string AV26ErrDescription ;
      private string AV9ActivactionKey ;
      private bool AV14isSuccessful ;
      private string AV18UserGAMGUID ;
      private string AV23baseUrl ;
      private string AV19Username ;
      private GeneXus.Mail.GXMailMessage AV15MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV8MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV17SMTPSession ;
      private string aP1_baseUrl ;
      private bool aP2_isSuccessful ;
      private string aP3_ErrDescription ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV16Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV25GAMErrorItem ;
   }

}
