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
   public class prc_senduseractivationlinknocommit : GXProcedure
   {
      public prc_senduseractivationlinknocommit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_senduseractivationlinknocommit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGAMGUID ,
                           string aP1_baseUrl ,
                           ref bool aP2_isSuccessful ,
                           ref string aP3_ErrDescription ,
                           ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV10baseUrl = aP1_baseUrl;
         this.AV19isSuccessful = aP2_isSuccessful;
         this.AV11ErrDescription = aP3_ErrDescription;
         this.AV14GAMErrors = aP4_GAMErrors;
         initialize();
         ExecuteImpl();
         aP2_isSuccessful=this.AV19isSuccessful;
         aP3_ErrDescription=this.AV11ErrDescription;
         aP4_GAMErrors=this.AV14GAMErrors;
      }

      public GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> executeUdp( string aP0_UserGAMGUID ,
                                                                                            string aP1_baseUrl ,
                                                                                            ref bool aP2_isSuccessful ,
                                                                                            ref string aP3_ErrDescription )
      {
         execute(aP0_UserGAMGUID, aP1_baseUrl, ref aP2_isSuccessful, ref aP3_ErrDescription, ref aP4_GAMErrors);
         return AV14GAMErrors ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 string aP1_baseUrl ,
                                 ref bool aP2_isSuccessful ,
                                 ref string aP3_ErrDescription ,
                                 ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV10baseUrl = aP1_baseUrl;
         this.AV19isSuccessful = aP2_isSuccessful;
         this.AV11ErrDescription = aP3_ErrDescription;
         this.AV14GAMErrors = aP4_GAMErrors;
         SubmitImpl();
         aP2_isSuccessful=this.AV19isSuccessful;
         aP3_ErrDescription=this.AV11ErrDescription;
         aP4_GAMErrors=this.AV14GAMErrors;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV21Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV15GAMUser.load( AV23UserGAMGUID);
            if ( AV15GAMUser.success() )
            {
               AV11ErrDescription = "Post load";
               AV24Username = AV15GAMUser.gxTpr_Firstname + " " + AV15GAMUser.gxTpr_Lastname;
               AV9ActivactionKey = AV15GAMUser.getnewactivationkey(out  AV14GAMErrors);
               if ( AV14GAMErrors.Count == 0 )
               {
                  AV22SMTPSession.Host = "comforta.yukon.software";
                  AV22SMTPSession.Port = 465;
                  AV22SMTPSession.Secure = 1;
                  AV22SMTPSession.Authentication = 0;
                  AV22SMTPSession.AuthenticationMethod = "";
                  AV22SMTPSession.UserName = "no-reply@comforta.yukon.software";
                  AV22SMTPSession.Password = "2uSFuxkquz";
                  AV22SMTPSession.Sender.Address = "no-reply@comforta.yukon.software";
                  AV22SMTPSession.Sender.Name = "Comforta Software";
                  AV8MailRecipient.Address = AV15GAMUser.gxTpr_Email;
                  AV8MailRecipient.Name = AV24Username;
                  AV20MailMessage.Subject = "Welcome to Comforta";
                  AV20MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+"<div style=\"background-color: #008080; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear "+AV24Username+",</p><p>Welcome to Comforta Software! We are thrilled to have you on board.</p><p>To get started, we need to verify your email address. Please click the button below to activate your account:</p>"+"</b></p><a href=\""+AV10baseUrl+"WP_UserActivation.aspx?ActivationKey="+AV9ActivactionKey+"&GamGuid="+AV15GAMUser.gxTpr_Guid+"\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #008080; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Verify Email</a>"+"<p>Please note that the link expires in 36 hours.</p>"+"<p>Once you have activated your account and set a password, you will gain access to the platform.</p>"+"<br><p>Healthy Living!</p><p>Comforta Software</p></div></div>";
                  AV20MailMessage.To.Add(AV8MailRecipient);
                  AV22SMTPSession.Login();
                  AV22SMTPSession.Send(AV20MailMessage);
                  if ( AV22SMTPSession.ErrCode == 0 )
                  {
                     AV22SMTPSession.Logout();
                     AV19isSuccessful = true;
                  }
                  else
                  {
                     AV11ErrDescription = "Sending activation email failed - " + StringUtil.Str( (decimal)(AV22SMTPSession.ErrCode), 10, 2) + " " + AV22SMTPSession.ErrDescription;
                     AV19isSuccessful = false;
                  }
               }
               else
               {
                  AV11ErrDescription = "Sending activation email failed - ";
                  AV26GXV1 = 1;
                  while ( AV26GXV1 <= AV14GAMErrors.Count )
                  {
                     AV13GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14GAMErrors.Item(AV26GXV1));
                     AV11ErrDescription += AV13GAMErrorItem.gxTpr_Message + " ";
                     AV26GXV1 = (int)(AV26GXV1+1);
                  }
                  AV19isSuccessful = false;
               }
            }
            else
            {
               AV11ErrDescription = "Failed to load user";
               AV19isSuccessful = false;
            }
         }
         else
         {
            AV11ErrDescription = "Unknown user activation method - " + AV21Repository.gxTpr_Useractivationmethod + " - " + "U";
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
         AV21Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV15GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV24Username = "";
         AV9ActivactionKey = "";
         AV22SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV8MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV20MailMessage = new GeneXus.Mail.GXMailMessage();
         AV13GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV26GXV1 ;
      private string AV11ErrDescription ;
      private string AV9ActivactionKey ;
      private bool AV19isSuccessful ;
      private string AV23UserGAMGUID ;
      private string AV10baseUrl ;
      private string AV24Username ;
      private GeneXus.Mail.GXMailMessage AV20MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV8MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV22SMTPSession ;
      private bool aP2_isSuccessful ;
      private string aP3_ErrDescription ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP4_GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV21Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV15GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV13GAMErrorItem ;
   }

}
