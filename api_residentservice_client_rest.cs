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
         restLocation.BaseUrl = "staging.comforta.yukon.software/api";
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

      public void gxep_uploadmedia( Guid aP0_MediaId ,
                                    string aP1_MediaName ,
                                    string aP2_MediaImageData ,
                                    int aP3_MediaSize ,
                                    string aP4_MediaType ,
                                    out SdtTrn_Media aP5_BC_Trn_Media )
      {
         restCliUploadMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload";
         restCliUploadMedia.Location = restLocation;
         restCliUploadMedia.HttpMethod = "POST";
         restCliUploadMedia.AddBodyVar("MediaId", (Guid)(aP0_MediaId));
         restCliUploadMedia.AddBodyVar("MediaName", (string)(aP1_MediaName));
         restCliUploadMedia.AddBodyVar("MediaImageData", (string)(aP2_MediaImageData));
         restCliUploadMedia.AddBodyVar("MediaSize", (int)(aP3_MediaSize));
         restCliUploadMedia.AddBodyVar("MediaType", (string)(aP4_MediaType));
         restCliUploadMedia.RestExecute();
         if ( restCliUploadMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadMedia.ErrorMessage;
            gxProperties.StatusCode = restCliUploadMedia.StatusCode;
            aP5_BC_Trn_Media = new SdtTrn_Media();
         }
         else
         {
            aP5_BC_Trn_Media = restCliUploadMedia.GetBodySdt<SdtTrn_Media>("BC_Trn_Media");
         }
         /* UploadMedia Constructor */
      }

      public void gxep_getpages( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         restCliGetPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list2";
         restCliGetPages.Location = restLocation;
         restCliGetPages.HttpMethod = "GET";
         restCliGetPages.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetPages.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliGetPages.RestExecute();
         if ( restCliGetPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetPages.ErrorCode;
            gxProperties.ErrorMessage = restCliGetPages.ErrorMessage;
            gxProperties.StatusCode = restCliGetPages.StatusCode;
            aP2_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
         }
         else
         {
            aP2_SDT_PageCollection = restCliGetPages.GetBodySdtCollection<SdtSDT_Page>("SDT_PageCollection");
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
                                      out SdtSDT_Page aP1_SDT_Page )
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
         }
         else
         {
            aP1_SDT_Page = restCliGetSinglePage.GetBodySdt<SdtSDT_Page>("SDT_Page");
         }
         /* GetSinglePage Constructor */
      }

      public void gxep_listpages( Guid aP0_locationId ,
                                  Guid aP1_organisationId ,
                                  out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         restCliListPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list";
         restCliListPages.Location = restLocation;
         restCliListPages.HttpMethod = "GET";
         restCliListPages.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliListPages.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliListPages.RestExecute();
         if ( restCliListPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliListPages.ErrorCode;
            gxProperties.ErrorMessage = restCliListPages.ErrorMessage;
            gxProperties.StatusCode = restCliListPages.StatusCode;
            aP2_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         }
         else
         {
            aP2_SDT_PageStructureCollection = restCliListPages.GetBodySdtCollection<SdtSDT_PageStructure>("SDT_PageStructureCollection");
         }
         /* ListPages Constructor */
      }

      public void gxep_createpage( string aP0_PageName ,
                                   out string aP1_result )
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
         restCliCreatePage.RestExecute();
         if ( restCliCreatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreatePage.ErrorMessage;
            gxProperties.StatusCode = restCliCreatePage.StatusCode;
            aP1_result = "";
         }
         else
         {
            aP1_result = restCliCreatePage.GetBodyString("result");
         }
         /* CreatePage Constructor */
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result )
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
         }
         else
         {
            aP1_result = restCliCreateContentPage.GetBodyString("result");
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
                                   out string aP6_result )
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
         restCliUpdatePage.RestExecute();
         if ( restCliUpdatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePage.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePage.StatusCode;
            aP6_result = "";
         }
         else
         {
            aP6_result = restCliUpdatePage.GetBodyString("result");
         }
         /* UpdatePage Constructor */
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result )
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
         }
         else
         {
            aP2_result = restCliAddPageCildren.GetBodyString("result");
         }
         /* AddPageCildren Constructor */
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            Guid aP1_locationId ,
                                            Guid aP2_organisationId ,
                                            out SdtSDT_Theme aP3_SDT_Theme )
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
         restCliUpdateLocationTheme.AddBodyVar("locationId", (Guid)(aP1_locationId));
         restCliUpdateLocationTheme.AddBodyVar("organisationId", (Guid)(aP2_organisationId));
         restCliUpdateLocationTheme.RestExecute();
         if ( restCliUpdateLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateLocationTheme.StatusCode;
            aP3_SDT_Theme = new SdtSDT_Theme();
         }
         else
         {
            aP3_SDT_Theme = restCliUpdateLocationTheme.GetBodySdt<SdtSDT_Theme>("SDT_Theme");
         }
         /* UpdateLocationTheme Constructor */
      }

      public void gxep_productsericeapi( Guid aP0_ProductServiceId ,
                                         out SdtSDT_ProductService aP1_SDT_ProductService )
      {
         restCliProductSericeAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/productservice/";
         restCliProductSericeAPI.Location = restLocation;
         restCliProductSericeAPI.HttpMethod = "GET";
         restCliProductSericeAPI.AddQueryVar("Productserviceid", (Guid)(aP0_ProductServiceId));
         restCliProductSericeAPI.RestExecute();
         if ( restCliProductSericeAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliProductSericeAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliProductSericeAPI.ErrorMessage;
            gxProperties.StatusCode = restCliProductSericeAPI.StatusCode;
            aP1_SDT_ProductService = new SdtSDT_ProductService();
         }
         else
         {
            aP1_SDT_ProductService = restCliProductSericeAPI.GetBodySdt<SdtSDT_ProductService>("SDT_ProductService");
         }
         /* ProductSericeAPI Constructor */
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtTrn_Theme aP2_Location_BC_Trn_Theme )
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
            aP2_Location_BC_Trn_Theme = new SdtTrn_Theme();
         }
         else
         {
            aP2_Location_BC_Trn_Theme = restCliGetLocationTheme.GetBodySdt<SdtTrn_Theme>("Location_BC_Trn_Theme");
         }
         /* GetLocationTheme Constructor */
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
         restCliGetResidentInformation = new GXRestAPIClient();
         aP1_SDT_Resident = new SdtSDT_Resident();
         restCliGetOrganisationInformation = new GXRestAPIClient();
         aP1_SDT_Organisation = new SdtSDT_Organisation();
         restCliGetLocationInformation = new GXRestAPIClient();
         aP1_SDT_Location = new SdtSDT_Location();
         restCliGetResidentNotificationHistory = new GXRestAPIClient();
         aP1_SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>();
         restCliRegisterDevice = new GXRestAPIClient();
         aP6_result = "";
         restCliSendNotification = new GXRestAPIClient();
         aP2_result = "";
         restCliAgendaLocation = new GXRestAPIClient();
         aP3_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         restCliSendDynamicForm = new GXRestAPIClient();
         aP0_result = "";
         restCliUploadMedia = new GXRestAPIClient();
         aP5_BC_Trn_Media = new SdtTrn_Media();
         restCliGetPages = new GXRestAPIClient();
         aP2_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
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
         restCliListPages = new GXRestAPIClient();
         aP2_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         restCliCreatePage = new GXRestAPIClient();
         aP1_result = "";
         restCliCreateContentPage = new GXRestAPIClient();
         restCliSavePage = new GXRestAPIClient();
         aP5_result = "";
         restCliUpdatePage = new GXRestAPIClient();
         restCliAddPageCildren = new GXRestAPIClient();
         restCliUpdateLocationTheme = new GXRestAPIClient();
         aP3_SDT_Theme = new SdtSDT_Theme();
         restCliProductSericeAPI = new GXRestAPIClient();
         aP1_SDT_ProductService = new SdtSDT_ProductService();
         restCliGetLocationTheme = new GXRestAPIClient();
         aP2_Location_BC_Trn_Theme = new SdtTrn_Theme();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLoginWithQrCode ;
      protected GXRestAPIClient restCliGetResidentInformation ;
      protected GXRestAPIClient restCliGetOrganisationInformation ;
      protected GXRestAPIClient restCliGetLocationInformation ;
      protected GXRestAPIClient restCliGetResidentNotificationHistory ;
      protected GXRestAPIClient restCliRegisterDevice ;
      protected GXRestAPIClient restCliSendNotification ;
      protected GXRestAPIClient restCliAgendaLocation ;
      protected GXRestAPIClient restCliSendDynamicForm ;
      protected GXRestAPIClient restCliUploadMedia ;
      protected GXRestAPIClient restCliGetPages ;
      protected GXRestAPIClient restCliPagesAPI ;
      protected GXRestAPIClient restCliPageAPI ;
      protected GXRestAPIClient restCliContentPagesAPI ;
      protected GXRestAPIClient restCliContentPageAPI ;
      protected GXRestAPIClient restCliGetSinglePage ;
      protected GXRestAPIClient restCliListPages ;
      protected GXRestAPIClient restCliCreatePage ;
      protected GXRestAPIClient restCliCreateContentPage ;
      protected GXRestAPIClient restCliSavePage ;
      protected GXRestAPIClient restCliUpdatePage ;
      protected GXRestAPIClient restCliAddPageCildren ;
      protected GXRestAPIClient restCliUpdateLocationTheme ;
      protected GXRestAPIClient restCliProductSericeAPI ;
      protected GXRestAPIClient restCliGetLocationTheme ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected GXBaseCollection<SdtSDT_ResidentNotification> aP1_SDT_ResidentNotification ;
      protected string aP6_result ;
      protected string aP2_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection ;
      protected SdtSDT_MobilePage aP3_SDT_MobilePage ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_ContentPage aP3_SDT_ContentPage ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection ;
      protected string aP1_result ;
      protected string aP5_result ;
      protected SdtSDT_Theme aP3_SDT_Theme ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected SdtTrn_Theme aP2_Location_BC_Trn_Theme ;
   }

}
