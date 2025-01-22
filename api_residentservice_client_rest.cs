using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_residentservice : GXProcedure
   {
      public api_residentservice( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "Comforta_version2DevelopmentNETPostgreSQL/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         restCliLoginWithQrCode = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-login";
         restCliLoginWithQrCode.Location = restLocation;
         restCliLoginWithQrCode.HttpMethod = "POST";
         restCliLoginWithQrCode.AddBodyVar("secretKey", (string)(aP0_secretKey));
         restCliLoginWithQrCode.RestExecute();
         if ( restCliLoginWithQrCode.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithQrCode.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithQrCode.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithQrCode.StatusCode;
            aP1_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP1_loginResult = restCliLoginWithQrCode.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* LoginWithQrCode Constructor */
      }

      public void gxep_loginwithusernamepassword( string aP0_username ,
                                                  string aP1_password ,
                                                  out SdtSDT_LoginResidentResponse aP2_loginResult )
      {
         restCliLoginWithUsernamePassword = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-login-username-password";
         restCliLoginWithUsernamePassword.Location = restLocation;
         restCliLoginWithUsernamePassword.HttpMethod = "POST";
         restCliLoginWithUsernamePassword.AddBodyVar("username", (string)(aP0_username));
         restCliLoginWithUsernamePassword.AddBodyVar("password", (string)(aP1_password));
         restCliLoginWithUsernamePassword.RestExecute();
         if ( restCliLoginWithUsernamePassword.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithUsernamePassword.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithUsernamePassword.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithUsernamePassword.StatusCode;
            aP2_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP2_loginResult = restCliLoginWithUsernamePassword.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* LoginWithUsernamePassword Constructor */
      }

      public void gxep_changeuserpassword( string aP0_userId ,
                                           string aP1_password ,
                                           string aP2_passwordNew ,
                                           out string aP3_result )
      {
         restCliChangeUserPassword = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-change-password";
         restCliChangeUserPassword.Location = restLocation;
         restCliChangeUserPassword.HttpMethod = "POST";
         restCliChangeUserPassword.AddBodyVar("userId", (string)(aP0_userId));
         restCliChangeUserPassword.AddBodyVar("password", (string)(aP1_password));
         restCliChangeUserPassword.AddBodyVar("passwordNew", (string)(aP2_passwordNew));
         restCliChangeUserPassword.RestExecute();
         if ( restCliChangeUserPassword.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliChangeUserPassword.ErrorCode;
            gxProperties.ErrorMessage = restCliChangeUserPassword.ErrorMessage;
            gxProperties.StatusCode = restCliChangeUserPassword.StatusCode;
            aP3_result = "";
         }
         else
         {
            aP3_result = restCliChangeUserPassword.GetBodyString("result");
         }
         /* ChangeUserPassword Constructor */
      }

      public void gxep_refreshauthtoken( string aP0_refreshToken ,
                                         out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         restCliRefreshAuthToken = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/refresh-token";
         restCliRefreshAuthToken.Location = restLocation;
         restCliRefreshAuthToken.HttpMethod = "POST";
         restCliRefreshAuthToken.AddBodyVar("refreshToken", (string)(aP0_refreshToken));
         restCliRefreshAuthToken.RestExecute();
         if ( restCliRefreshAuthToken.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRefreshAuthToken.ErrorCode;
            gxProperties.ErrorMessage = restCliRefreshAuthToken.ErrorMessage;
            gxProperties.StatusCode = restCliRefreshAuthToken.StatusCode;
            aP1_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP1_loginResult = restCliRefreshAuthToken.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* RefreshAuthToken Constructor */
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         restCliGetResidentInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident";
         restCliGetResidentInformation.Location = restLocation;
         restCliGetResidentInformation.HttpMethod = "GET";
         restCliGetResidentInformation.AddQueryVar("Userid", (string)(aP0_userId));
         restCliGetResidentInformation.RestExecute();
         if ( restCliGetResidentInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentInformation.StatusCode;
            aP1_SDT_Resident = new SdtSDT_Resident();
         }
         else
         {
            aP1_SDT_Resident = restCliGetResidentInformation.GetBodySdt<SdtSDT_Resident>("SDT_Resident");
         }
         /* GetResidentInformation Constructor */
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         restCliGetOrganisationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/organisation";
         restCliGetOrganisationInformation.Location = restLocation;
         restCliGetOrganisationInformation.HttpMethod = "GET";
         restCliGetOrganisationInformation.AddQueryVar("Organisationid", (Guid)(aP0_organisationId));
         restCliGetOrganisationInformation.RestExecute();
         if ( restCliGetOrganisationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetOrganisationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetOrganisationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetOrganisationInformation.StatusCode;
            aP1_SDT_Organisation = new SdtSDT_Organisation();
         }
         else
         {
            aP1_SDT_Organisation = restCliGetOrganisationInformation.GetBodySdt<SdtSDT_Organisation>("SDT_Organisation");
         }
         /* GetOrganisationInformation Constructor */
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         restCliGetLocationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/location";
         restCliGetLocationInformation.Location = restLocation;
         restCliGetLocationInformation.HttpMethod = "GET";
         restCliGetLocationInformation.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetLocationInformation.RestExecute();
         if ( restCliGetLocationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationInformation.StatusCode;
            aP1_SDT_Location = new SdtSDT_Location();
         }
         else
         {
            aP1_SDT_Location = restCliGetLocationInformation.GetBodySdt<SdtSDT_Location>("SDT_Location");
         }
         /* GetLocationInformation Constructor */
      }

      public void gxep_getresidentnotificationhistory( string aP0_ResidentId ,
                                                       out GXBaseCollection<SdtSDT_ResidentNotification> aP1_SDT_ResidentNotification )
      {
         restCliGetResidentNotificationHistory = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/notification-history";
         restCliGetResidentNotificationHistory.Location = restLocation;
         restCliGetResidentNotificationHistory.HttpMethod = "GET";
         restCliGetResidentNotificationHistory.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliGetResidentNotificationHistory.RestExecute();
         if ( restCliGetResidentNotificationHistory.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentNotificationHistory.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentNotificationHistory.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentNotificationHistory.StatusCode;
            aP1_SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>();
         }
         else
         {
            aP1_SDT_ResidentNotification = restCliGetResidentNotificationHistory.GetBodySdtCollection<SdtSDT_ResidentNotification>("SDT_ResidentNotification");
         }
         /* GetResidentNotificationHistory Constructor */
      }

      public void gxep_updateresidentavatar( string aP0_Base64Image ,
                                             string aP1_ResidentId ,
                                             out string aP2_result )
      {
         restCliUpdateResidentAvatar = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/update-avatar";
         restCliUpdateResidentAvatar.Location = restLocation;
         restCliUpdateResidentAvatar.HttpMethod = "POST";
         restCliUpdateResidentAvatar.AddBodyVar("Base64Image", (string)(aP0_Base64Image));
         restCliUpdateResidentAvatar.AddBodyVar("ResidentId", (string)(aP1_ResidentId));
         restCliUpdateResidentAvatar.RestExecute();
         if ( restCliUpdateResidentAvatar.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateResidentAvatar.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateResidentAvatar.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateResidentAvatar.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliUpdateResidentAvatar.GetBodyString("result");
         }
         /* UpdateResidentAvatar Constructor */
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         restCliRegisterDevice = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/register-device";
         restCliRegisterDevice.Location = restLocation;
         restCliRegisterDevice.HttpMethod = "POST";
         restCliRegisterDevice.AddBodyVar("DeviceToken", (string)(aP0_DeviceToken));
         restCliRegisterDevice.AddBodyVar("DeviceID", (string)(aP1_DeviceID));
         restCliRegisterDevice.AddBodyVar("DeviceType", (short)(aP2_DeviceType));
         restCliRegisterDevice.AddBodyVar("NotificationPlatform", (string)(aP3_NotificationPlatform));
         restCliRegisterDevice.AddBodyVar("NotificationPlatformId", (string)(aP4_NotificationPlatformId));
         restCliRegisterDevice.AddBodyVar("userId", (string)(aP5_userId));
         restCliRegisterDevice.RestExecute();
         if ( restCliRegisterDevice.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRegisterDevice.ErrorCode;
            gxProperties.ErrorMessage = restCliRegisterDevice.ErrorMessage;
            gxProperties.StatusCode = restCliRegisterDevice.StatusCode;
            aP6_result = "";
         }
         else
         {
            aP6_result = restCliRegisterDevice.GetBodyString("result");
         }
         /* RegisterDevice Constructor */
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         out string aP2_result )
      {
         restCliSendNotification = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/send-notification";
         restCliSendNotification.Location = restLocation;
         restCliSendNotification.HttpMethod = "POST";
         restCliSendNotification.AddBodyVar("title", (string)(aP0_title));
         restCliSendNotification.AddBodyVar("message", (string)(aP1_message));
         restCliSendNotification.RestExecute();
         if ( restCliSendNotification.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendNotification.ErrorCode;
            gxProperties.ErrorMessage = restCliSendNotification.ErrorMessage;
            gxProperties.StatusCode = restCliSendNotification.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliSendNotification.GetBodyString("result");
         }
         /* SendNotification Constructor */
      }

      public void gxep_agendalocation( string aP0_ResidentId ,
                                       string aP1_StartDate ,
                                       string aP2_EndDate ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation )
      {
         restCliAgendaLocation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/agenda-events";
         restCliAgendaLocation.Location = restLocation;
         restCliAgendaLocation.HttpMethod = "GET";
         restCliAgendaLocation.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliAgendaLocation.AddQueryVar("Startdate", (string)(aP1_StartDate));
         restCliAgendaLocation.AddQueryVar("Enddate", (string)(aP2_EndDate));
         restCliAgendaLocation.RestExecute();
         if ( restCliAgendaLocation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAgendaLocation.ErrorCode;
            gxProperties.ErrorMessage = restCliAgendaLocation.ErrorMessage;
            gxProperties.StatusCode = restCliAgendaLocation.StatusCode;
            aP3_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         }
         else
         {
            aP3_SDT_AgendaLocation = restCliAgendaLocation.GetBodySdtCollection<SdtSDT_AgendaLocation>("SDT_AgendaLocation");
         }
         /* AgendaLocation Constructor */
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         restCliSendDynamicForm = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/form/dynamic-form";
         restCliSendDynamicForm.Location = restLocation;
         restCliSendDynamicForm.HttpMethod = "GET";
         restCliSendDynamicForm.RestExecute();
         if ( restCliSendDynamicForm.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendDynamicForm.ErrorCode;
            gxProperties.ErrorMessage = restCliSendDynamicForm.ErrorMessage;
            gxProperties.StatusCode = restCliSendDynamicForm.StatusCode;
            aP0_result = "";
         }
         else
         {
            aP0_result = restCliSendDynamicForm.GetBodyString("result");
         }
         /* SendDynamicForm Constructor */
      }

      public void gxep_uploadmedia( string aP0_MediaName ,
                                    string aP1_MediaImageData ,
                                    int aP2_MediaSize ,
                                    string aP3_MediaType ,
                                    out SdtTrn_Media aP4_BC_Trn_Media ,
                                    out SdtSDT_Error aP5_error )
      {
         restCliUploadMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload";
         restCliUploadMedia.Location = restLocation;
         restCliUploadMedia.HttpMethod = "POST";
         restCliUploadMedia.AddBodyVar("MediaName", (string)(aP0_MediaName));
         restCliUploadMedia.AddBodyVar("MediaImageData", (string)(aP1_MediaImageData));
         restCliUploadMedia.AddBodyVar("MediaSize", (int)(aP2_MediaSize));
         restCliUploadMedia.AddBodyVar("MediaType", (string)(aP3_MediaType));
         restCliUploadMedia.RestExecute();
         if ( restCliUploadMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadMedia.ErrorMessage;
            gxProperties.StatusCode = restCliUploadMedia.StatusCode;
            aP4_BC_Trn_Media = new SdtTrn_Media();
            aP5_error = new SdtSDT_Error();
         }
         else
         {
            aP4_BC_Trn_Media = restCliUploadMedia.GetBodySdt<SdtTrn_Media>("BC_Trn_Media");
            aP5_error = restCliUploadMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UploadMedia Constructor */
      }

      public void gxep_deletemedia( Guid aP0_MediaId ,
                                    out string aP1_result ,
                                    out SdtSDT_Error aP2_error )
      {
         restCliDeleteMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/delete";
         restCliDeleteMedia.Location = restLocation;
         restCliDeleteMedia.HttpMethod = "GET";
         restCliDeleteMedia.AddQueryVar("Mediaid", (Guid)(aP0_MediaId));
         restCliDeleteMedia.RestExecute();
         if ( restCliDeleteMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteMedia.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteMedia.StatusCode;
            aP1_result = "";
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_result = restCliDeleteMedia.GetBodyString("result");
            aP2_error = restCliDeleteMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteMedia Constructor */
      }

      public void gxep_getmedia( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         restCliGetMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/media";
         restCliGetMedia.Location = restLocation;
         restCliGetMedia.HttpMethod = "GET";
         restCliGetMedia.RestExecute();
         if ( restCliGetMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliGetMedia.ErrorMessage;
            gxProperties.StatusCode = restCliGetMedia.StatusCode;
            aP0_SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_MediaCollection = restCliGetMedia.GetBodySdtCollection<SdtSDT_Media>("SDT_MediaCollection");
            aP1_error = restCliGetMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetMedia Constructor */
      }

      public void gxep_getpages( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         restCliGetPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list";
         restCliGetPages.Location = restLocation;
         restCliGetPages.HttpMethod = "GET";
         restCliGetPages.RestExecute();
         if ( restCliGetPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetPages.ErrorCode;
            gxProperties.ErrorMessage = restCliGetPages.ErrorMessage;
            gxProperties.StatusCode = restCliGetPages.StatusCode;
            aP0_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_PageCollection = restCliGetPages.GetBodySdtCollection<SdtSDT_Page>("SDT_PageCollection");
            aP1_error = restCliGetPages.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetPages Constructor */
      }

      public void gxep_pagesapi( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection )
      {
         restCliPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages";
         restCliPagesAPI.Location = restLocation;
         restCliPagesAPI.HttpMethod = "GET";
         restCliPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliPagesAPI.RestExecute();
         if ( restCliPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliPagesAPI.StatusCode;
            aP2_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         }
         else
         {
            aP2_SDT_MobilePageCollection = restCliPagesAPI.GetBodySdtCollection<SdtSDT_MobilePage>("SDT_MobilePageCollection");
         }
         /* PagesAPI Constructor */
      }

      public void gxep_pageapi( Guid aP0_PageId ,
                                Guid aP1_locationId ,
                                Guid aP2_organisationId ,
                                out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         restCliPageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/page";
         restCliPageAPI.Location = restLocation;
         restCliPageAPI.HttpMethod = "GET";
         restCliPageAPI.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliPageAPI.AddQueryVar("Locationid", (Guid)(aP1_locationId));
         restCliPageAPI.AddQueryVar("Organisationid", (Guid)(aP2_organisationId));
         restCliPageAPI.RestExecute();
         if ( restCliPageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliPageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliPageAPI.StatusCode;
            aP3_SDT_MobilePage = new SdtSDT_MobilePage();
         }
         else
         {
            aP3_SDT_MobilePage = restCliPageAPI.GetBodySdt<SdtSDT_MobilePage>("SDT_MobilePage");
         }
         /* PageAPI Constructor */
      }

      public void gxep_contentpagesapi( Guid aP0_locationId ,
                                        Guid aP1_organisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         restCliContentPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/content-pages";
         restCliContentPagesAPI.Location = restLocation;
         restCliContentPagesAPI.HttpMethod = "GET";
         restCliContentPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliContentPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliContentPagesAPI.RestExecute();
         if ( restCliContentPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliContentPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliContentPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliContentPagesAPI.StatusCode;
            aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         }
         else
         {
            aP2_SDT_ContentPageCollection = restCliContentPagesAPI.GetBodySdtCollection<SdtSDT_ContentPage>("SDT_ContentPageCollection");
         }
         /* ContentPagesAPI Constructor */
      }

      public void gxep_contentpageapi( Guid aP0_PageId ,
                                       Guid aP1_locationId ,
                                       Guid aP2_organisationId ,
                                       out SdtSDT_ContentPage aP3_SDT_ContentPage )
      {
         restCliContentPageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/content-page";
         restCliContentPageAPI.Location = restLocation;
         restCliContentPageAPI.HttpMethod = "GET";
         restCliContentPageAPI.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliContentPageAPI.AddQueryVar("Locationid", (Guid)(aP1_locationId));
         restCliContentPageAPI.AddQueryVar("Organisationid", (Guid)(aP2_organisationId));
         restCliContentPageAPI.RestExecute();
         if ( restCliContentPageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliContentPageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliContentPageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliContentPageAPI.StatusCode;
            aP3_SDT_ContentPage = new SdtSDT_ContentPage();
         }
         else
         {
            aP3_SDT_ContentPage = restCliContentPageAPI.GetBodySdt<SdtSDT_ContentPage>("SDT_ContentPage");
         }
         /* ContentPageAPI Constructor */
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page ,
                                      out SdtSDT_Error aP2_error )
      {
         restCliGetSinglePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/singlepage";
         restCliGetSinglePage.Location = restLocation;
         restCliGetSinglePage.HttpMethod = "GET";
         restCliGetSinglePage.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliGetSinglePage.RestExecute();
         if ( restCliGetSinglePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetSinglePage.ErrorCode;
            gxProperties.ErrorMessage = restCliGetSinglePage.ErrorMessage;
            gxProperties.StatusCode = restCliGetSinglePage.StatusCode;
            aP1_SDT_Page = new SdtSDT_Page();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_Page = restCliGetSinglePage.GetBodySdt<SdtSDT_Page>("SDT_Page");
            aP2_error = restCliGetSinglePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetSinglePage Constructor */
      }

      public void gxep_deletepage( Guid aP0_PageId ,
                                   out SdtSDT_Error aP1_error )
      {
         restCliDeletePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/deletepage";
         restCliDeletePage.Location = restLocation;
         restCliDeletePage.HttpMethod = "GET";
         restCliDeletePage.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliDeletePage.RestExecute();
         if ( restCliDeletePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeletePage.ErrorCode;
            gxProperties.ErrorMessage = restCliDeletePage.ErrorMessage;
            gxProperties.StatusCode = restCliDeletePage.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliDeletePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeletePage Constructor */
      }

      public void gxep_listpages( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         restCliListPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/tree";
         restCliListPages.Location = restLocation;
         restCliListPages.HttpMethod = "GET";
         restCliListPages.RestExecute();
         if ( restCliListPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliListPages.ErrorCode;
            gxProperties.ErrorMessage = restCliListPages.ErrorMessage;
            gxProperties.StatusCode = restCliListPages.StatusCode;
            aP0_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_PageStructureCollection = restCliListPages.GetBodySdtCollection<SdtSDT_PageStructure>("SDT_PageStructureCollection");
            aP1_error = restCliListPages.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ListPages Constructor */
      }

      public void gxep_createpage( string aP0_PageName ,
                                   string aP1_PageJsonContent ,
                                   out string aP2_result ,
                                   out SdtSDT_Error aP3_error )
      {
         restCliCreatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-page";
         restCliCreatePage.Location = restLocation;
         restCliCreatePage.HttpMethod = "POST";
         restCliCreatePage.AddBodyVar("PageName", (string)(aP0_PageName));
         restCliCreatePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliCreatePage.RestExecute();
         if ( restCliCreatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreatePage.ErrorMessage;
            gxProperties.StatusCode = restCliCreatePage.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliCreatePage.GetBodyString("result");
            aP3_error = restCliCreatePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreatePage Constructor */
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliCreateContentPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-content-page";
         restCliCreateContentPage.Location = restLocation;
         restCliCreateContentPage.HttpMethod = "POST";
         restCliCreateContentPage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliCreateContentPage.RestExecute();
         if ( restCliCreateContentPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateContentPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateContentPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateContentPage.StatusCode;
            aP1_result = "";
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_result = restCliCreateContentPage.GetBodyString("result");
            aP2_error = restCliCreateContentPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateContentPage Constructor */
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         restCliSavePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/save-page";
         restCliSavePage.Location = restLocation;
         restCliSavePage.HttpMethod = "POST";
         restCliSavePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliSavePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliSavePage.AddBodyVar("PageGJSHtml", (string)(aP2_PageGJSHtml));
         restCliSavePage.AddBodyVar("PageGJSJson", (string)(aP3_PageGJSJson));
         restCliSavePage.AddBodyVar("SDT_Page", aP4_SDT_Page);
         restCliSavePage.RestExecute();
         if ( restCliSavePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSavePage.ErrorCode;
            gxProperties.ErrorMessage = restCliSavePage.ErrorMessage;
            gxProperties.StatusCode = restCliSavePage.StatusCode;
            aP5_result = "";
         }
         else
         {
            aP5_result = restCliSavePage.GetBodyString("result");
         }
         /* SavePage Constructor */
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageName ,
                                   string aP2_PageJsonContent ,
                                   string aP3_PageGJSHtml ,
                                   string aP4_PageGJSJson ,
                                   bool aP5_PageIsPublished ,
                                   bool aP6_IsNotifyResidents ,
                                   out string aP7_result ,
                                   out SdtSDT_Error aP8_error )
      {
         restCliUpdatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/update-page";
         restCliUpdatePage.Location = restLocation;
         restCliUpdatePage.HttpMethod = "POST";
         restCliUpdatePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliUpdatePage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliUpdatePage.AddBodyVar("PageJsonContent", (string)(aP2_PageJsonContent));
         restCliUpdatePage.AddBodyVar("PageGJSHtml", (string)(aP3_PageGJSHtml));
         restCliUpdatePage.AddBodyVar("PageGJSJson", (string)(aP4_PageGJSJson));
         restCliUpdatePage.AddBodyVar("PageIsPublished", aP5_PageIsPublished);
         restCliUpdatePage.AddBodyVar("IsNotifyResidents", aP6_IsNotifyResidents);
         restCliUpdatePage.RestExecute();
         if ( restCliUpdatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePage.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePage.StatusCode;
            aP7_result = "";
            aP8_error = new SdtSDT_Error();
         }
         else
         {
            aP7_result = restCliUpdatePage.GetBodyString("result");
            aP8_error = restCliUpdatePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePage Constructor */
      }

      public void gxep_updatepagebatch( GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                        bool aP1_IsNotifyResidents ,
                                        out string aP2_result ,
                                        out SdtSDT_Error aP3_error )
      {
         restCliUpdatePageBatch = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/update-pages-batch";
         restCliUpdatePageBatch.Location = restLocation;
         restCliUpdatePageBatch.HttpMethod = "POST";
         restCliUpdatePageBatch.AddBodyVar("PagesList", aP0_PagesList);
         restCliUpdatePageBatch.AddBodyVar("IsNotifyResidents", aP1_IsNotifyResidents);
         restCliUpdatePageBatch.RestExecute();
         if ( restCliUpdatePageBatch.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePageBatch.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePageBatch.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePageBatch.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliUpdatePageBatch.GetBodyString("result");
            aP3_error = restCliUpdatePageBatch.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePageBatch Constructor */
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result ,
                                       out SdtSDT_Error aP3_error )
      {
         restCliAddPageCildren = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/add-page-children";
         restCliAddPageCildren.Location = restLocation;
         restCliAddPageCildren.HttpMethod = "POST";
         restCliAddPageCildren.AddBodyVar("ParentPageId", (Guid)(aP0_ParentPageId));
         restCliAddPageCildren.AddBodyVar("ChildPageId", (Guid)(aP1_ChildPageId));
         restCliAddPageCildren.RestExecute();
         if ( restCliAddPageCildren.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAddPageCildren.ErrorCode;
            gxProperties.ErrorMessage = restCliAddPageCildren.ErrorMessage;
            gxProperties.StatusCode = restCliAddPageCildren.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliAddPageCildren.GetBodyString("result");
            aP3_error = restCliAddPageCildren.GetBodySdt<SdtSDT_Error>("error");
         }
         /* AddPageCildren Constructor */
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            out SdtSDT_Theme aP1_SDT_Theme ,
                                            out SdtSDT_Error aP2_error )
      {
         restCliUpdateLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/update-location-theme/";
         restCliUpdateLocationTheme.Location = restLocation;
         restCliUpdateLocationTheme.HttpMethod = "POST";
         restCliUpdateLocationTheme.AddBodyVar("ThemeId", (Guid)(aP0_ThemeId));
         restCliUpdateLocationTheme.RestExecute();
         if ( restCliUpdateLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateLocationTheme.StatusCode;
            aP1_SDT_Theme = new SdtSDT_Theme();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_Theme = restCliUpdateLocationTheme.GetBodySdt<SdtSDT_Theme>("SDT_Theme");
            aP2_error = restCliUpdateLocationTheme.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateLocationTheme Constructor */
      }

      public void gxep_productserviceapi( Guid aP0_ProductServiceId ,
                                          out SdtSDT_ProductService aP1_SDT_ProductService ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliProductServiceAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/productservice/";
         restCliProductServiceAPI.Location = restLocation;
         restCliProductServiceAPI.HttpMethod = "GET";
         restCliProductServiceAPI.AddQueryVar("Productserviceid", (Guid)(aP0_ProductServiceId));
         restCliProductServiceAPI.RestExecute();
         if ( restCliProductServiceAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliProductServiceAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliProductServiceAPI.ErrorMessage;
            gxProperties.StatusCode = restCliProductServiceAPI.StatusCode;
            aP1_SDT_ProductService = new SdtSDT_ProductService();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_ProductService = restCliProductServiceAPI.GetBodySdt<SdtSDT_ProductService>("SDT_ProductService");
            aP2_error = restCliProductServiceAPI.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ProductServiceAPI Constructor */
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtSDT_LocationTheme aP2_SDT_LocationTheme )
      {
         restCliGetLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/location-theme/";
         restCliGetLocationTheme.Location = restLocation;
         restCliGetLocationTheme.HttpMethod = "GET";
         restCliGetLocationTheme.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetLocationTheme.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliGetLocationTheme.RestExecute();
         if ( restCliGetLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationTheme.StatusCode;
            aP2_SDT_LocationTheme = new SdtSDT_LocationTheme();
         }
         else
         {
            aP2_SDT_LocationTheme = restCliGetLocationTheme.GetBodySdt<SdtSDT_LocationTheme>("SDT_LocationTheme");
         }
         /* GetLocationTheme Constructor */
      }

      public void gxep_toolboxgetlocationtheme( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                                out SdtSDT_Error aP1_error )
      {
         restCliToolboxGetLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/location-theme/";
         restCliToolboxGetLocationTheme.Location = restLocation;
         restCliToolboxGetLocationTheme.HttpMethod = "GET";
         restCliToolboxGetLocationTheme.RestExecute();
         if ( restCliToolboxGetLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliToolboxGetLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliToolboxGetLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliToolboxGetLocationTheme.StatusCode;
            aP0_SDT_LocationTheme = new SdtSDT_LocationTheme();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_LocationTheme = restCliToolboxGetLocationTheme.GetBodySdt<SdtSDT_LocationTheme>("SDT_LocationTheme");
            aP1_error = restCliToolboxGetLocationTheme.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ToolboxGetLocationTheme Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliLoginWithQrCode = new GXRestAPIClient();
         aP1_loginResult = new SdtSDT_LoginResidentResponse();
         restCliLoginWithUsernamePassword = new GXRestAPIClient();
         aP2_loginResult = new SdtSDT_LoginResidentResponse();
         restCliChangeUserPassword = new GXRestAPIClient();
         aP3_result = "";
         restCliRefreshAuthToken = new GXRestAPIClient();
         restCliGetResidentInformation = new GXRestAPIClient();
         aP1_SDT_Resident = new SdtSDT_Resident();
         restCliGetOrganisationInformation = new GXRestAPIClient();
         aP1_SDT_Organisation = new SdtSDT_Organisation();
         restCliGetLocationInformation = new GXRestAPIClient();
         aP1_SDT_Location = new SdtSDT_Location();
         restCliGetResidentNotificationHistory = new GXRestAPIClient();
         aP1_SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>();
         restCliUpdateResidentAvatar = new GXRestAPIClient();
         aP2_result = "";
         restCliRegisterDevice = new GXRestAPIClient();
         aP6_result = "";
         restCliSendNotification = new GXRestAPIClient();
         restCliAgendaLocation = new GXRestAPIClient();
         aP3_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         restCliSendDynamicForm = new GXRestAPIClient();
         aP0_result = "";
         restCliUploadMedia = new GXRestAPIClient();
         aP4_BC_Trn_Media = new SdtTrn_Media();
         aP5_error = new SdtSDT_Error();
         restCliDeleteMedia = new GXRestAPIClient();
         aP1_result = "";
         aP2_error = new SdtSDT_Error();
         restCliGetMedia = new GXRestAPIClient();
         aP0_SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>();
         aP1_error = new SdtSDT_Error();
         restCliGetPages = new GXRestAPIClient();
         aP0_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
         restCliPagesAPI = new GXRestAPIClient();
         aP2_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         restCliPageAPI = new GXRestAPIClient();
         aP3_SDT_MobilePage = new SdtSDT_MobilePage();
         restCliContentPagesAPI = new GXRestAPIClient();
         aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         restCliContentPageAPI = new GXRestAPIClient();
         aP3_SDT_ContentPage = new SdtSDT_ContentPage();
         restCliGetSinglePage = new GXRestAPIClient();
         aP1_SDT_Page = new SdtSDT_Page();
         restCliDeletePage = new GXRestAPIClient();
         restCliListPages = new GXRestAPIClient();
         aP0_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         restCliCreatePage = new GXRestAPIClient();
         aP3_error = new SdtSDT_Error();
         restCliCreateContentPage = new GXRestAPIClient();
         restCliSavePage = new GXRestAPIClient();
         aP5_result = "";
         restCliUpdatePage = new GXRestAPIClient();
         aP7_result = "";
         aP8_error = new SdtSDT_Error();
         restCliUpdatePageBatch = new GXRestAPIClient();
         restCliAddPageCildren = new GXRestAPIClient();
         restCliUpdateLocationTheme = new GXRestAPIClient();
         aP1_SDT_Theme = new SdtSDT_Theme();
         restCliProductServiceAPI = new GXRestAPIClient();
         aP1_SDT_ProductService = new SdtSDT_ProductService();
         restCliGetLocationTheme = new GXRestAPIClient();
         aP2_SDT_LocationTheme = new SdtSDT_LocationTheme();
         restCliToolboxGetLocationTheme = new GXRestAPIClient();
         aP0_SDT_LocationTheme = new SdtSDT_LocationTheme();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLoginWithQrCode ;
      protected GXRestAPIClient restCliLoginWithUsernamePassword ;
      protected GXRestAPIClient restCliChangeUserPassword ;
      protected GXRestAPIClient restCliRefreshAuthToken ;
      protected GXRestAPIClient restCliGetResidentInformation ;
      protected GXRestAPIClient restCliGetOrganisationInformation ;
      protected GXRestAPIClient restCliGetLocationInformation ;
      protected GXRestAPIClient restCliGetResidentNotificationHistory ;
      protected GXRestAPIClient restCliUpdateResidentAvatar ;
      protected GXRestAPIClient restCliRegisterDevice ;
      protected GXRestAPIClient restCliSendNotification ;
      protected GXRestAPIClient restCliAgendaLocation ;
      protected GXRestAPIClient restCliSendDynamicForm ;
      protected GXRestAPIClient restCliUploadMedia ;
      protected GXRestAPIClient restCliDeleteMedia ;
      protected GXRestAPIClient restCliGetMedia ;
      protected GXRestAPIClient restCliGetPages ;
      protected GXRestAPIClient restCliPagesAPI ;
      protected GXRestAPIClient restCliPageAPI ;
      protected GXRestAPIClient restCliContentPagesAPI ;
      protected GXRestAPIClient restCliContentPageAPI ;
      protected GXRestAPIClient restCliGetSinglePage ;
      protected GXRestAPIClient restCliDeletePage ;
      protected GXRestAPIClient restCliListPages ;
      protected GXRestAPIClient restCliCreatePage ;
      protected GXRestAPIClient restCliCreateContentPage ;
      protected GXRestAPIClient restCliSavePage ;
      protected GXRestAPIClient restCliUpdatePage ;
      protected GXRestAPIClient restCliUpdatePageBatch ;
      protected GXRestAPIClient restCliAddPageCildren ;
      protected GXRestAPIClient restCliUpdateLocationTheme ;
      protected GXRestAPIClient restCliProductServiceAPI ;
      protected GXRestAPIClient restCliGetLocationTheme ;
      protected GXRestAPIClient restCliToolboxGetLocationTheme ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_LoginResidentResponse aP2_loginResult ;
      protected string aP3_result ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected GXBaseCollection<SdtSDT_ResidentNotification> aP1_SDT_ResidentNotification ;
      protected string aP2_result ;
      protected string aP6_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media aP4_BC_Trn_Media ;
      protected SdtSDT_Error aP5_error ;
      protected string aP1_result ;
      protected SdtSDT_Error aP2_error ;
      protected GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
      protected SdtSDT_Error aP1_error ;
      protected GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection ;
      protected SdtSDT_MobilePage aP3_SDT_MobilePage ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_ContentPage aP3_SDT_ContentPage ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      protected SdtSDT_Error aP3_error ;
      protected string aP5_result ;
      protected string aP7_result ;
      protected SdtSDT_Error aP8_error ;
      protected SdtSDT_Theme aP1_SDT_Theme ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected SdtSDT_LocationTheme aP2_SDT_LocationTheme ;
      protected SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
   }

}
