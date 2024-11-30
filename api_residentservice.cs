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
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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

      protected void E11012( )
      {
         /* Loginwithqrcode_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E12012( )
      {
         /* Getresidentinformation_After Routine */
         returnInSub = false;
         if ( AV22SDT_Resident.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E13012( )
      {
         /* Getorganisationinformation_After Routine */
         returnInSub = false;
         if ( AV23SDT_Organisation.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E14012( )
      {
         /* Getlocationinformation_After Routine */
         returnInSub = false;
         if ( AV18SDT_Location.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E15012( )
      {
         /* Agendalocation_After Routine */
         returnInSub = false;
         if ( AV59SDT_AgendaLocation.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      protected void E16012( )
      {
         /* Getresidentnotificationhistory_After Routine */
         returnInSub = false;
         if ( AV80SDT_ResidentNotification.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         this.AV7secretKey = aP0_secretKey;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* LoginWithQrCode Constructor */
         new prc_loginresident(context ).execute(  AV7secretKey, out  AV17result) ;
         /* Execute user event: Loginwithqrcode.After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_loginResult=this.AV21loginResult;
            return;
         }
         aP1_loginResult=this.AV21loginResult;
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         this.AV8userId = aP0_userId;
         AV22SDT_Resident = new SdtSDT_Resident(context);
         initialize();
         /* GetResidentInformation Constructor */
         new prc_getresidentinformation(context ).execute(  AV8userId, out  AV17result) ;
         /* Execute user event: Getresidentinformation.After */
         E12012 ();
         if ( returnInSub )
         {
            aP1_SDT_Resident=this.AV22SDT_Resident;
            return;
         }
         aP1_SDT_Resident=this.AV22SDT_Resident;
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         this.AV16organisationId = aP0_organisationId;
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         initialize();
         /* GetOrganisationInformation Constructor */
         new prc_getorganisationinformation(context ).execute(  AV16organisationId, out  AV17result) ;
         /* Execute user event: Getorganisationinformation.After */
         E13012 ();
         if ( returnInSub )
         {
            aP1_SDT_Organisation=this.AV23SDT_Organisation;
            return;
         }
         aP1_SDT_Organisation=this.AV23SDT_Organisation;
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         this.AV12locationId = aP0_locationId;
         AV18SDT_Location = new SdtSDT_Location(context);
         initialize();
         /* GetLocationInformation Constructor */
         new prc_getlocationinformation(context ).execute(  AV12locationId, out  AV17result) ;
         /* Execute user event: Getlocationinformation.After */
         E14012 ();
         if ( returnInSub )
         {
            aP1_SDT_Location=this.AV18SDT_Location;
            return;
         }
         aP1_SDT_Location=this.AV18SDT_Location;
      }

      public void gxep_getresidentnotificationhistory( string aP0_ResidentId ,
                                                       out GXBaseCollection<SdtSDT_ResidentNotification> aP1_SDT_ResidentNotification )
      {
         this.AV74ResidentId = aP0_ResidentId;
         AV80SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version2");
         initialize();
         /* GetResidentNotificationHistory Constructor */
         new prc_getresidentnotificationhistory(context ).execute(  AV74ResidentId, out  AV17result) ;
         /* Execute user event: Getresidentnotificationhistory.After */
         E16012 ();
         if ( returnInSub )
         {
            aP1_SDT_ResidentNotification=this.AV80SDT_ResidentNotification;
            return;
         }
         aP1_SDT_ResidentNotification=this.AV80SDT_ResidentNotification;
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         this.AV10DeviceToken = aP0_DeviceToken;
         this.AV9DeviceID = aP1_DeviceID;
         this.AV11DeviceType = aP2_DeviceType;
         this.AV14NotificationPlatform = aP3_NotificationPlatform;
         this.AV15NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV8userId = aP5_userId;
         initialize();
         /* RegisterDevice Constructor */
         new prc_registermobiledevice(context ).execute(  AV10DeviceToken,  AV9DeviceID,  AV11DeviceType,  AV14NotificationPlatform,  AV15NotificationPlatformId,  AV8userId, out  AV17result) ;
         aP6_result=this.AV17result;
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         out string aP2_result )
      {
         this.AV19title = aP0_title;
         this.AV13message = aP1_message;
         initialize();
         /* SendNotification Constructor */
         new prc_sendnotification(context ).execute(  AV19title,  AV13message, out  AV17result) ;
         aP2_result=this.AV17result;
      }

      public void gxep_agendalocation( string aP0_ResidentId ,
                                       string aP1_StartDate ,
                                       string aP2_EndDate ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation )
      {
         this.AV74ResidentId = aP0_ResidentId;
         this.AV81StartDate = aP1_StartDate;
         this.AV79EndDate = aP2_EndDate;
         AV59SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         initialize();
         /* AgendaLocation Constructor */
         new prc_agendalocationapi(context ).execute(  AV74ResidentId,  AV81StartDate,  AV79EndDate, out  AV17result) ;
         /* Execute user event: Agendalocation.After */
         E15012 ();
         if ( returnInSub )
         {
            aP3_SDT_AgendaLocation=this.AV59SDT_AgendaLocation;
            return;
         }
         aP3_SDT_AgendaLocation=this.AV59SDT_AgendaLocation;
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         initialize();
         /* SendDynamicForm Constructor */
         new prc_dynamicformapi(context ).execute( out  AV17result) ;
         aP0_result=this.AV17result;
      }

      public void gxep_uploadmedia( Guid aP0_MediaId ,
                                    string aP1_MediaName ,
                                    string aP2_MediaImageData ,
                                    int aP3_MediaSize ,
                                    string aP4_MediaType ,
                                    out SdtTrn_Media aP5_BC_Trn_Media )
      {
         this.AV46MediaId = aP0_MediaId;
         this.AV47MediaName = aP1_MediaName;
         this.AV49MediaImageData = aP2_MediaImageData;
         this.AV51MediaSize = aP3_MediaSize;
         this.AV52MediaType = aP4_MediaType;
         initialize();
         /* UploadMedia Constructor */
         new prc_uploadmedia(context ).execute(  AV46MediaId,  AV47MediaName,  AV49MediaImageData,  AV51MediaSize,  AV52MediaType, out  AV50BC_Trn_Media) ;
         aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
      }

      public void gxep_getpages( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* GetPages Constructor */
         new prc_getpages(context ).execute(  AV12locationId,  AV16organisationId, out  AV44SDT_PageCollection) ;
         aP2_SDT_PageCollection=this.AV44SDT_PageCollection;
      }

      public void gxep_pagesapi( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* PagesAPI Constructor */
         new prc_pagesapi(context ).execute(  AV12locationId,  AV16organisationId, out  AV70SDT_MobilePageCollection) ;
         aP2_SDT_MobilePageCollection=this.AV70SDT_MobilePageCollection;
      }

      public void gxep_pageapi( Guid aP0_PageId ,
                                Guid aP1_locationId ,
                                Guid aP2_organisationId ,
                                out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         this.AV54PageId = aP0_PageId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         initialize();
         /* PageAPI Constructor */
         new prc_pageapi(context ).execute(  AV54PageId,  AV12locationId,  AV16organisationId, out  AV75SDT_MobilePage) ;
         aP3_SDT_MobilePage=this.AV75SDT_MobilePage;
      }

      public void gxep_contentpagesapi( Guid aP0_locationId ,
                                        Guid aP1_organisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* ContentPagesAPI Constructor */
         new prc_contentpagesapi(context ).execute(  AV12locationId,  AV16organisationId, out  AV69SDT_ContentPageCollection) ;
         aP2_SDT_ContentPageCollection=this.AV69SDT_ContentPageCollection;
      }

      public void gxep_contentpageapi( Guid aP0_PageId ,
                                       Guid aP1_locationId ,
                                       Guid aP2_organisationId ,
                                       out SdtSDT_ContentPage aP3_SDT_ContentPage )
      {
         this.AV54PageId = aP0_PageId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         initialize();
         /* ContentPageAPI Constructor */
         new prc_contentpageapi(context ).execute(  AV54PageId,  AV12locationId,  AV16organisationId, out  AV82SDT_ContentPage) ;
         aP3_SDT_ContentPage=this.AV82SDT_ContentPage;
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page )
      {
         this.AV54PageId = aP0_PageId;
         initialize();
         /* GetSinglePage Constructor */
         new prc_getsinglepage(context ).execute(  AV54PageId, out  AV55SDT_Page) ;
         aP1_SDT_Page=this.AV55SDT_Page;
      }

      public void gxep_listpages( Guid aP0_locationId ,
                                  Guid aP1_organisationId ,
                                  out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* ListPages Constructor */
         new prc_listpages(context ).execute(  AV12locationId,  AV16organisationId, out  AV64SDT_PageStructureCollection) ;
         aP2_SDT_PageStructureCollection=this.AV64SDT_PageStructureCollection;
      }

      public void gxep_createpage( string aP0_PageName ,
                                   out string aP1_result )
      {
         this.AV60PageName = aP0_PageName;
         initialize();
         /* CreatePage Constructor */
         new prc_createpage(context ).execute(  AV60PageName, ref  AV17result) ;
         aP1_result=this.AV17result;
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result )
      {
         this.AV54PageId = aP0_PageId;
         initialize();
         /* CreateContentPage Constructor */
         new prc_createcontentpage(context ).execute(  AV54PageId, out  AV17result) ;
         aP1_result=this.AV17result;
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         this.AV54PageId = aP0_PageId;
         this.AV58PageJsonContent = aP1_PageJsonContent;
         this.AV56PageGJSHtml = aP2_PageGJSHtml;
         this.AV57PageGJSJson = aP3_PageGJSJson;
         this.AV55SDT_Page = aP4_SDT_Page;
         initialize();
         /* SavePage Constructor */
         new prc_savepage(context ).execute(  AV54PageId,  AV58PageJsonContent,  AV56PageGJSHtml,  AV57PageGJSJson,  AV55SDT_Page, ref  AV17result) ;
         aP5_result=this.AV17result;
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageName ,
                                   string aP2_PageJsonContent ,
                                   string aP3_PageGJSHtml ,
                                   string aP4_PageGJSJson ,
                                   bool aP5_PageIsPublished ,
                                   out string aP6_result )
      {
         this.AV54PageId = aP0_PageId;
         this.AV60PageName = aP1_PageName;
         this.AV58PageJsonContent = aP2_PageJsonContent;
         this.AV56PageGJSHtml = aP3_PageGJSHtml;
         this.AV57PageGJSJson = aP4_PageGJSJson;
         this.AV65PageIsPublished = aP5_PageIsPublished;
         initialize();
         /* UpdatePage Constructor */
         new prc_updatepage(context ).execute( ref  AV54PageId, ref  AV60PageName, ref  AV58PageJsonContent, ref  AV56PageGJSHtml, ref  AV57PageGJSJson, ref  AV65PageIsPublished, out  AV17result) ;
         aP6_result=this.AV17result;
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result )
      {
         this.AV61ParentPageId = aP0_ParentPageId;
         this.AV62ChildPageId = aP1_ChildPageId;
         initialize();
         /* AddPageCildren Constructor */
         new prc_addpagechildren(context ).execute(  AV61ParentPageId,  AV62ChildPageId, out  AV17result) ;
         aP2_result=this.AV17result;
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            Guid aP1_locationId ,
                                            Guid aP2_organisationId ,
                                            out SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV71ThemeId = aP0_ThemeId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         initialize();
         /* UpdateLocationTheme Constructor */
         new prc_updatelocationtheme(context ).execute(  AV71ThemeId,  AV12locationId,  AV16organisationId,  AV72SDT_Theme) ;
         aP3_SDT_Theme=this.AV72SDT_Theme;
      }

      public void gxep_productsericeapi( Guid aP0_ProductServiceId ,
                                         out SdtSDT_ProductService aP1_SDT_ProductService )
      {
         this.AV66ProductServiceId = aP0_ProductServiceId;
         initialize();
         /* ProductSericeAPI Constructor */
         new prc_productserviceapi(context ).execute(  AV66ProductServiceId, ref  AV67SDT_ProductService) ;
         aP1_SDT_ProductService=this.AV67SDT_ProductService;
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtTrn_Theme aP2_Location_BC_Trn_Theme )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* GetLocationTheme Constructor */
         new prc_getlocationtheme(context ).execute( ref  AV12locationId, ref  AV16organisationId, out  AV77Location_BC_Trn_Theme) ;
         aP2_Location_BC_Trn_Theme=this.AV77Location_BC_Trn_Theme;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV17result = "";
         AV20SDT_LoginResidentResponse = new SdtSDT_LoginResidentResponse(context);
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         AV22SDT_Resident = new SdtSDT_Resident(context);
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         AV18SDT_Location = new SdtSDT_Location(context);
         AV59SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV80SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version2");
         AV50BC_Trn_Media = new SdtTrn_Media(context);
         AV44SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV70SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         AV75SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV69SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2");
         AV82SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV64SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV72SDT_Theme = new SdtSDT_Theme(context);
         AV67SDT_ProductService = new SdtSDT_ProductService(context);
         AV77Location_BC_Trn_Theme = new SdtTrn_Theme(context);
         /* GeneXus formulas. */
      }

      protected short AV11DeviceType ;
      protected int AV51MediaSize ;
      protected string Gx_restmethod ;
      protected string AV10DeviceToken ;
      protected string AV9DeviceID ;
      protected string AV52MediaType ;
      protected bool returnInSub ;
      protected bool AV65PageIsPublished ;
      protected string AV17result ;
      protected string AV7secretKey ;
      protected string AV49MediaImageData ;
      protected string AV58PageJsonContent ;
      protected string AV56PageGJSHtml ;
      protected string AV57PageGJSJson ;
      protected string AV8userId ;
      protected string AV74ResidentId ;
      protected string AV14NotificationPlatform ;
      protected string AV15NotificationPlatformId ;
      protected string AV19title ;
      protected string AV13message ;
      protected string AV81StartDate ;
      protected string AV79EndDate ;
      protected string AV47MediaName ;
      protected string AV60PageName ;
      protected Guid AV16organisationId ;
      protected Guid AV12locationId ;
      protected Guid AV46MediaId ;
      protected Guid AV54PageId ;
      protected Guid AV61ParentPageId ;
      protected Guid AV62ChildPageId ;
      protected Guid AV71ThemeId ;
      protected Guid AV66ProductServiceId ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse AV20SDT_LoginResidentResponse ;
      protected SdtSDT_LoginResidentResponse AV21loginResult ;
      protected SdtSDT_Resident AV22SDT_Resident ;
      protected SdtSDT_Organisation AV23SDT_Organisation ;
      protected SdtSDT_Location AV18SDT_Location ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> AV59SDT_AgendaLocation ;
      protected GXBaseCollection<SdtSDT_ResidentNotification> AV80SDT_ResidentNotification ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected GXBaseCollection<SdtSDT_ResidentNotification> aP1_SDT_ResidentNotification ;
      protected string aP6_result ;
      protected string aP2_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media AV50BC_Trn_Media ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected GXBaseCollection<SdtSDT_Page> AV44SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> AV70SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection ;
      protected SdtSDT_MobilePage AV75SDT_MobilePage ;
      protected SdtSDT_MobilePage aP3_SDT_MobilePage ;
      protected GXBaseCollection<SdtSDT_ContentPage> AV69SDT_ContentPageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_ContentPage AV82SDT_ContentPage ;
      protected SdtSDT_ContentPage aP3_SDT_ContentPage ;
      protected SdtSDT_Page AV55SDT_Page ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> AV64SDT_PageStructureCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection ;
      protected string aP1_result ;
      protected string aP5_result ;
      protected SdtSDT_Theme AV72SDT_Theme ;
      protected SdtSDT_Theme aP3_SDT_Theme ;
      protected SdtSDT_ProductService AV67SDT_ProductService ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected SdtTrn_Theme AV77Location_BC_Trn_Theme ;
      protected SdtTrn_Theme aP2_Location_BC_Trn_Theme ;
   }

}
