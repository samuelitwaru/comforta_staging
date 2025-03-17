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
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithqrcode") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithusernamepassword") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_recoverpasswordstep1") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_changeuserpassword") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_refreshauthtoken") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getorganisationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentnotificationhistory") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentfilledforms") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateresidentavatar") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_registerdevice") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_sendnotification") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_agendalocation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_senddynamicform") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletemedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadlogo") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadprofileimage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_pagesapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_pageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_contentpagesapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_contentpageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getsinglepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_listpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createcontentpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createdynamicformpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepagebatch") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_addpagecildren") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatelocationtheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_productserviceapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getservices") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationtheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_toolboxgetlocationtheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getthemes") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getappversions") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_activateappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepagev2") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_publishpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createmenupage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createservicepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletepagev2") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

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
         /* Loginwithusernamepassword_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E13012( )
      {
         /* Changeuserpassword_After Routine */
         returnInSub = false;
         if ( AV97SDT_ChangeYourPassword.FromJSonString(AV17result, null) )
         {
            AV98ChangeYourPasswordResult = AV97SDT_ChangeYourPassword;
         }
      }

      protected void E14012( )
      {
         /* Recoverpasswordstep1_After Routine */
         returnInSub = false;
         if ( AV102SDT_RecoverPasswordStep1.FromJSonString(AV17result, null) )
         {
            AV103RecoverPasswordStep1Result = AV102SDT_RecoverPasswordStep1;
         }
      }

      protected void E15012( )
      {
         /* Refreshauthtoken_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E16012( )
      {
         /* Getresidentinformation_After Routine */
         returnInSub = false;
         if ( AV22SDT_Resident.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E17012( )
      {
         /* Getorganisationinformation_After Routine */
         returnInSub = false;
         if ( AV23SDT_Organisation.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E18012( )
      {
         /* Getlocationinformation_After Routine */
         returnInSub = false;
         if ( AV18SDT_Location.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E19012( )
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

      protected void E20012( )
      {
         /* Getresidentnotificationhistory_After Routine */
         returnInSub = false;
         AV110SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( AV110SDT_ApiListResponse.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      protected void E21012( )
      {
         /* Getresidentfilledforms_After Routine */
         returnInSub = false;
         AV110SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( AV110SDT_ApiListResponse.FromJSonString(AV17result, null) )
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

      public void gxep_loginwithusernamepassword( string aP0_username ,
                                                  string aP1_password ,
                                                  out SdtSDT_LoginResidentResponse aP2_loginResult )
      {
         this.AV93username = aP0_username;
         this.AV94password = aP1_password;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* LoginWithUsernamePassword Constructor */
         new prc_loginresident2(context ).execute(  AV93username,  AV94password, out  AV17result) ;
         /* Execute user event: Loginwithusernamepassword.After */
         E12012 ();
         if ( returnInSub )
         {
            aP2_loginResult=this.AV21loginResult;
            return;
         }
         aP2_loginResult=this.AV21loginResult;
      }

      public void gxep_recoverpasswordstep1( string aP0_username ,
                                             out SdtSDT_RecoverPasswordStep1 aP1_RecoverPasswordStep1Result )
      {
         this.AV93username = aP0_username;
         AV103RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1(context);
         initialize();
         /* RecoverPasswordStep1 Constructor */
         new prc_recoverpasswordstep1(context ).execute(  AV93username, out  AV17result) ;
         /* Execute user event: Recoverpasswordstep1.After */
         E14012 ();
         if ( returnInSub )
         {
            aP1_RecoverPasswordStep1Result=this.AV103RecoverPasswordStep1Result;
            return;
         }
         aP1_RecoverPasswordStep1Result=this.AV103RecoverPasswordStep1Result;
      }

      public void gxep_changeuserpassword( string aP0_userId ,
                                           string aP1_password ,
                                           string aP2_passwordNew ,
                                           out SdtSDT_ChangeYourPassword aP3_ChangeYourPasswordResult )
      {
         this.AV8userId = aP0_userId;
         this.AV94password = aP1_password;
         this.AV96passwordNew = aP2_passwordNew;
         AV98ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword(context);
         initialize();
         /* ChangeUserPassword Constructor */
         new prc_changeuserpassword(context ).execute(  AV8userId,  AV94password,  AV96passwordNew, out  AV17result) ;
         /* Execute user event: Changeuserpassword.After */
         E13012 ();
         if ( returnInSub )
         {
            aP3_ChangeYourPasswordResult=this.AV98ChangeYourPasswordResult;
            return;
         }
         aP3_ChangeYourPasswordResult=this.AV98ChangeYourPasswordResult;
      }

      public void gxep_refreshauthtoken( string aP0_refreshToken ,
                                         out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         this.AV89refreshToken = aP0_refreshToken;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* RefreshAuthToken Constructor */
         new prc_refreshauthtoken(context ).execute(  AV89refreshToken, out  AV17result) ;
         /* Execute user event: Refreshauthtoken.After */
         E15012 ();
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
         E16012 ();
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
         E17012 ();
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
         E18012 ();
         if ( returnInSub )
         {
            aP1_SDT_Location=this.AV18SDT_Location;
            return;
         }
         aP1_SDT_Location=this.AV18SDT_Location;
      }

      public void gxep_getresidentnotificationhistory( string aP0_ResidentId ,
                                                       short aP1_PageSize ,
                                                       short aP2_PageNumber ,
                                                       out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV74ResidentId = aP0_ResidentId;
         this.AV109PageSize = aP1_PageSize;
         this.AV108PageNumber = aP2_PageNumber;
         AV110SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetResidentNotificationHistory Constructor */
         new prc_getresidentnotificationhistory(context ).execute(  AV74ResidentId,  AV109PageSize,  AV108PageNumber, out  AV17result) ;
         /* Execute user event: Getresidentnotificationhistory.After */
         E20012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV110SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV110SDT_ApiListResponse;
      }

      public void gxep_getresidentfilledforms( string aP0_ResidentId ,
                                               short aP1_PageSize ,
                                               short aP2_PageNumber ,
                                               out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV74ResidentId = aP0_ResidentId;
         this.AV109PageSize = aP1_PageSize;
         this.AV108PageNumber = aP2_PageNumber;
         AV110SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetResidentFilledForms Constructor */
         new prc_getresidentfilledforms(context ).execute(  AV74ResidentId,  AV109PageSize,  AV108PageNumber, out  AV17result) ;
         /* Execute user event: Getresidentfilledforms.After */
         E21012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV110SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV110SDT_ApiListResponse;
      }

      public void gxep_updateresidentavatar( string aP0_Base64Image ,
                                             string aP1_ResidentId ,
                                             out string aP2_result )
      {
         this.AV86Base64Image = aP0_Base64Image;
         this.AV74ResidentId = aP1_ResidentId;
         initialize();
         /* UpdateResidentAvatar Constructor */
         new prc_updateresidentavatar(context ).execute(  AV86Base64Image,  AV74ResidentId, out  AV17result) ;
         aP2_result=this.AV17result;
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
                                         string aP2_userId ,
                                         out string aP3_result )
      {
         this.AV19title = aP0_title;
         this.AV13message = aP1_message;
         this.AV8userId = aP2_userId;
         initialize();
         /* SendNotification Constructor */
         new prc_sendnotification(context ).execute(  AV19title,  AV13message,  AV8userId, out  AV17result) ;
         aP3_result=this.AV17result;
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
         E19012 ();
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

      public void gxep_uploadmedia( string aP0_MediaName ,
                                    string aP1_MediaImageData ,
                                    int aP2_MediaSize ,
                                    string aP3_MediaType ,
                                    out SdtTrn_Media aP4_BC_Trn_Media ,
                                    out SdtSDT_Error aP5_error )
      {
         this.AV47MediaName = aP0_MediaName;
         this.AV49MediaImageData = aP1_MediaImageData;
         this.AV51MediaSize = aP2_MediaSize;
         this.AV52MediaType = aP3_MediaType;
         initialize();
         /* UploadMedia Constructor */
         new prc_uploadmedia(context ).execute(  AV47MediaName,  AV49MediaImageData,  AV51MediaSize,  AV52MediaType, out  AV50BC_Trn_Media, out  AV91error) ;
         aP4_BC_Trn_Media=this.AV50BC_Trn_Media;
         aP5_error=this.AV91error;
      }

      public void gxep_deletemedia( Guid aP0_MediaId ,
                                    out string aP1_result ,
                                    out SdtSDT_Error aP2_error )
      {
         this.AV46MediaId = aP0_MediaId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* DeleteMedia Constructor */
         new prc_deletemedia(context ).execute(  AV46MediaId, out  AV17result) ;
         aP1_result=this.AV17result;
         aP2_error=this.AV91error;
      }

      public void gxep_getmedia( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetMedia Constructor */
         new prc_getmedia(context ).execute( out  AV85SDT_MediaCollection) ;
         aP0_SDT_MediaCollection=this.AV85SDT_MediaCollection;
         aP1_error=this.AV91error;
      }

      public void gxep_uploadlogo( string aP0_LogoUrl ,
                                   out SdtSDT_Error aP1_error )
      {
         this.AV105LogoUrl = aP0_LogoUrl;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UploadLogo Constructor */
         new prc_uploadlogo(context ).execute(  AV105LogoUrl, out  AV91error) ;
         aP1_error=this.AV91error;
      }

      public void gxep_uploadprofileimage( string aP0_ProfileImageUrl ,
                                           out SdtSDT_Error aP1_error )
      {
         this.AV104ProfileImageUrl = aP0_ProfileImageUrl;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UploadProfileImage Constructor */
         new prc_uploadprofileimage(context ).execute(  AV104ProfileImageUrl, out  AV91error) ;
         aP1_error=this.AV91error;
      }

      public void gxep_getpages( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetPages Constructor */
         new prc_getpages(context ).execute( out  AV44SDT_PageCollection, out  AV91error) ;
         aP0_SDT_PageCollection=this.AV44SDT_PageCollection;
         aP1_error=this.AV91error;
      }

      public void gxep_pagesapi( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 string aP2_userId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         this.AV8userId = aP2_userId;
         initialize();
         /* PagesAPI Constructor */
         new prc_pagesapi(context ).execute(  AV12locationId,  AV16organisationId,  AV8userId, out  AV70SDT_MobilePageCollection) ;
         aP3_SDT_MobilePageCollection=this.AV70SDT_MobilePageCollection;
      }

      public void gxep_pageapi( Guid aP0_PageId ,
                                Guid aP1_locationId ,
                                Guid aP2_organisationId ,
                                string aP3_userId ,
                                out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV54PageId = aP0_PageId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         this.AV8userId = aP3_userId;
         initialize();
         /* PageAPI Constructor */
         new prc_pageapi(context ).execute(  AV54PageId,  AV12locationId,  AV16organisationId,  AV8userId, out  AV75SDT_MobilePage) ;
         aP4_SDT_MobilePage=this.AV75SDT_MobilePage;
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
                                       out SdtSDT_ContentPageV1 aP3_SDT_ContentPage )
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
                                      out SdtSDT_Page aP1_SDT_Page ,
                                      out SdtSDT_Error aP2_error )
      {
         this.AV54PageId = aP0_PageId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetSinglePage Constructor */
         new prc_getsinglepageapi(context ).execute(  AV54PageId, out  AV55SDT_Page, out  AV91error) ;
         aP1_SDT_Page=this.AV55SDT_Page;
         aP2_error=this.AV91error;
      }

      public void gxep_deletepage( Guid aP0_PageId ,
                                   out SdtSDT_Error aP1_error )
      {
         this.AV54PageId = aP0_PageId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* DeletePage Constructor */
         new prc_deletepageapi(context ).execute(  AV54PageId, out  AV91error) ;
         aP1_error=this.AV91error;
      }

      public void gxep_listpages( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* ListPages Constructor */
         new prc_listpages(context ).execute( out  AV64SDT_PageStructureCollection, out  AV91error) ;
         aP0_SDT_PageStructureCollection=this.AV64SDT_PageStructureCollection;
         aP1_error=this.AV91error;
      }

      public void gxep_createpage( string aP0_PageName ,
                                   string aP1_PageJsonContent ,
                                   out string aP2_result ,
                                   out SdtSDT_Error aP3_error )
      {
         this.AV60PageName = aP0_PageName;
         this.AV58PageJsonContent = aP1_PageJsonContent;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreatePage Constructor */
         new prc_createpage(context ).execute(  AV60PageName,  AV58PageJsonContent, ref  AV17result, out  AV91error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV91error;
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV54PageId = aP0_PageId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreateContentPage Constructor */
         new prc_createcontentpage(context ).execute(  AV54PageId, out  AV17result, out  AV91error) ;
         aP1_result=this.AV17result;
         aP2_error=this.AV91error;
      }

      public void gxep_createdynamicformpage( Guid aP0_FormId ,
                                              string aP1_PageName ,
                                              out SdtSDT_Page aP2_SDT_Page ,
                                              out SdtSDT_Error aP3_error )
      {
         this.AV100FormId = aP0_FormId;
         this.AV60PageName = aP1_PageName;
         AV55SDT_Page = new SdtSDT_Page(context);
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreateDynamicFormPage Constructor */
         new prc_createdynamicformpage(context ).execute(  AV100FormId,  AV60PageName, out  AV55SDT_Page, out  AV91error) ;
         aP2_SDT_Page=this.AV55SDT_Page;
         aP3_error=this.AV91error;
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
                                   bool aP6_IsNotifyResidents ,
                                   out string aP7_result ,
                                   out SdtSDT_Error aP8_error )
      {
         this.AV54PageId = aP0_PageId;
         this.AV60PageName = aP1_PageName;
         this.AV58PageJsonContent = aP2_PageJsonContent;
         this.AV56PageGJSHtml = aP3_PageGJSHtml;
         this.AV57PageGJSJson = aP4_PageGJSJson;
         this.AV65PageIsPublished = aP5_PageIsPublished;
         this.AV88IsNotifyResidents = aP6_IsNotifyResidents;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UpdatePage Constructor */
         new prc_updatepage(context ).execute( ref  AV54PageId, ref  AV60PageName, ref  AV58PageJsonContent, ref  AV56PageGJSHtml, ref  AV57PageGJSJson, ref  AV65PageIsPublished, ref  AV88IsNotifyResidents, out  AV17result, out  AV91error) ;
         aP7_result=this.AV17result;
         aP8_error=this.AV91error;
      }

      public void gxep_updatepagebatch( GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                        bool aP1_IsNotifyResidents ,
                                        out string aP2_result ,
                                        out SdtSDT_Error aP3_error )
      {
         this.AV92PagesList = aP0_PagesList;
         this.AV88IsNotifyResidents = aP1_IsNotifyResidents;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UpdatePageBatch Constructor */
         new prc_updatepagebatch(context ).execute( ref  AV92PagesList, ref  AV88IsNotifyResidents, out  AV17result, out  AV91error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV91error;
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV61ParentPageId = aP0_ParentPageId;
         this.AV62ChildPageId = aP1_ChildPageId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* AddPageCildren Constructor */
         new prc_addpagechildren(context ).execute(  AV61ParentPageId,  AV62ChildPageId, out  AV17result, out  AV91error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV91error;
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            out SdtSDT_Theme aP1_SDT_Theme ,
                                            out SdtSDT_Error aP2_error )
      {
         this.AV71ThemeId = aP0_ThemeId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UpdateLocationTheme Constructor */
         new prc_updatelocationtheme(context ).execute(  AV71ThemeId, out  AV72SDT_Theme, out  AV91error) ;
         aP1_SDT_Theme=this.AV72SDT_Theme;
         aP2_error=this.AV91error;
      }

      public void gxep_productserviceapi( Guid aP0_ProductServiceId ,
                                          out SdtSDT_ProductService aP1_SDT_ProductService ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV66ProductServiceId = aP0_ProductServiceId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* ProductServiceAPI Constructor */
         new prc_productserviceapi(context ).execute(  AV66ProductServiceId, out  AV67SDT_ProductService, out  AV91error) ;
         aP1_SDT_ProductService=this.AV67SDT_ProductService;
         aP2_error=this.AV91error;
      }

      public void gxep_getservices( out GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ,
                                    out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetServices Constructor */
         new prc_getservices(context ).execute(  AV101SDT_ProductServiceCollection, out  AV91error) ;
         aP0_SDT_ProductServiceCollection=this.AV101SDT_ProductServiceCollection;
         aP1_error=this.AV91error;
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtSDT_LocationTheme aP2_SDT_LocationTheme )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* GetLocationTheme Constructor */
         new prc_getlocationtheme(context ).execute( ref  AV12locationId, ref  AV16organisationId, out  AV83SDT_LocationTheme) ;
         aP2_SDT_LocationTheme=this.AV83SDT_LocationTheme;
      }

      public void gxep_toolboxgetlocationtheme( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                                out SdtSDT_Error aP1_error )
      {
         AV83SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* ToolboxGetLocationTheme Constructor */
         new prc_toolboxgetlocationtheme(context ).execute( out  AV83SDT_LocationTheme, out  AV91error) ;
         aP0_SDT_LocationTheme=this.AV83SDT_LocationTheme;
         aP1_error=this.AV91error;
      }

      public void gxep_getthemes( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetThemes Constructor */
         new prc_getthemes(context ).execute( out  AV111SDT_ThemeCollection, out  AV91error) ;
         aP0_SDT_ThemeCollection=this.AV111SDT_ThemeCollection;
         aP1_error=this.AV91error;
      }

      public void gxep_getappversions( out GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ,
                                       out SdtSDT_Error aP1_error )
      {
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* GetAppVersions Constructor */
         new prc_getappversions(context ).execute( ref  AV119AppVersions, ref  AV91error) ;
         aP0_AppVersions=this.AV119AppVersions;
         aP1_error=this.AV91error;
      }

      public void gxep_createappversion( string aP0_AppVersionName ,
                                         out SdtSDT_AppVersion aP1_AppVersion ,
                                         out SdtSDT_Error aP2_error )
      {
         this.AV122AppVersionName = aP0_AppVersionName;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreateAppVersion Constructor */
         new prc_createappversion(context ).execute(  AV122AppVersionName, out  AV121AppVersion, out  AV91error) ;
         aP1_AppVersion=this.AV121AppVersion;
         aP2_error=this.AV91error;
      }

      public void gxep_updateappversion( Guid aP0_AppVersionId ,
                                         string aP1_AppVersionName ,
                                         out SdtSDT_AppVersion aP2_AppVersion ,
                                         out SdtSDT_Error aP3_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         this.AV122AppVersionName = aP1_AppVersionName;
         AV121AppVersion = new SdtSDT_AppVersion(context);
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* UpdateAppVersion Constructor */
         new prc_updateappversion(context ).execute(  AV115AppVersionId,  AV122AppVersionName, out  AV121AppVersion, out  AV91error) ;
         aP2_AppVersion=this.AV121AppVersion;
         aP3_error=this.AV91error;
      }

      public void gxep_activateappversion( Guid aP0_AppVersionId ,
                                           out SdtSDT_AppVersion aP1_AppVersion ,
                                           out SdtSDT_Error aP2_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         AV121AppVersion = new SdtSDT_AppVersion(context);
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* ActivateAppVersion Constructor */
         new prc_activateappversion(context ).execute(  AV115AppVersionId, out  AV121AppVersion, out  AV91error) ;
         aP1_AppVersion=this.AV121AppVersion;
         aP2_error=this.AV91error;
      }

      public void gxep_savepagev2( Guid aP0_AppVersionId ,
                                   Guid aP1_PageId ,
                                   string aP2_PageName ,
                                   string aP3_PageType ,
                                   string aP4_PageStructure ,
                                   out SdtSDT_Error aP5_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         this.AV54PageId = aP1_PageId;
         this.AV60PageName = aP2_PageName;
         this.AV114PageType = aP3_PageType;
         this.AV113PageStructure = aP4_PageStructure;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* SavePageV2 Constructor */
         new prc_savepagev2(context ).execute(  AV115AppVersionId,  AV54PageId,  AV60PageName,  AV114PageType,  AV113PageStructure, out  AV91error) ;
         aP5_error=this.AV91error;
      }

      public void gxep_publishpages( Guid aP0_AppVersionId ,
                                     Guid aP1_PageId ,
                                     string aP2_PageName ,
                                     string aP3_PageType ,
                                     string aP4_PageStructure ,
                                     out SdtSDT_Error aP5_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         this.AV54PageId = aP1_PageId;
         this.AV60PageName = aP2_PageName;
         this.AV114PageType = aP3_PageType;
         this.AV113PageStructure = aP4_PageStructure;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* PublishPages Constructor */
         new prc_publishpages(context ).execute(  AV115AppVersionId, ref  AV117PageCollection, out  AV91error) ;
         aP5_error=this.AV91error;
      }

      public void gxep_createmenupage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       out SdtSDT_AppVersion_PagesItem aP2_MenuPage ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         this.AV60PageName = aP1_PageName;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreateMenuPage Constructor */
         new prc_createmenupage(context ).execute(  AV115AppVersionId,  AV60PageName, out  AV120MenuPage, out  AV91error) ;
         aP2_MenuPage=this.AV120MenuPage;
         aP3_error=this.AV91error;
      }

      public void gxep_createservicepage( Guid aP0_AppVersionId ,
                                          Guid aP1_ProductServiceId ,
                                          out SdtSDT_AppVersion_PagesItem aP2_ContentPage ,
                                          out SdtSDT_Error aP3_error )
      {
         this.AV115AppVersionId = aP0_AppVersionId;
         this.AV66ProductServiceId = aP1_ProductServiceId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* CreateServicePage Constructor */
         new prc_createservicepage(context ).execute(  AV115AppVersionId,  AV66ProductServiceId, out  AV118ContentPage, out  AV91error) ;
         aP2_ContentPage=this.AV118ContentPage;
         aP3_error=this.AV91error;
      }

      public void gxep_deletepagev2( Guid aP0_PageId ,
                                     out SdtSDT_Error aP1_error )
      {
         this.AV54PageId = aP0_PageId;
         AV91error = new SdtSDT_Error(context);
         initialize();
         /* DeletePageV2 Constructor */
         new prc_deletepage(context ).execute( ) ;
         aP1_error=this.AV91error;
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
         AV97SDT_ChangeYourPassword = new SdtSDT_ChangeYourPassword(context);
         AV98ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword(context);
         AV102SDT_RecoverPasswordStep1 = new SdtSDT_RecoverPasswordStep1(context);
         AV103RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1(context);
         AV22SDT_Resident = new SdtSDT_Resident(context);
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         AV18SDT_Location = new SdtSDT_Location(context);
         AV59SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV110SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         AV50BC_Trn_Media = new SdtTrn_Media(context);
         AV91error = new SdtSDT_Error(context);
         AV85SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2");
         AV44SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV70SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         AV75SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV69SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2");
         AV82SDT_ContentPage = new SdtSDT_ContentPageV1(context);
         AV64SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV72SDT_Theme = new SdtSDT_Theme(context);
         AV67SDT_ProductService = new SdtSDT_ProductService(context);
         AV101SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>( context, "SDT_ProductService", "Comforta_version2");
         AV83SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV111SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>( context, "SDT_Theme", "Comforta_version2");
         AV119AppVersions = new GXBaseCollection<SdtSDT_AppVersion>( context, "SDT_AppVersion", "Comforta_version2");
         AV121AppVersion = new SdtSDT_AppVersion(context);
         AV117PageCollection = new GXBaseCollection<SdtSDT_PageV2>( context, "SDT_PageV2", "Comforta_version2");
         AV120MenuPage = new SdtSDT_AppVersion_PagesItem(context);
         AV118ContentPage = new SdtSDT_AppVersion_PagesItem(context);
         /* GeneXus formulas. */
      }

      protected short AV109PageSize ;
      protected short AV108PageNumber ;
      protected short AV11DeviceType ;
      protected int AV51MediaSize ;
      protected string Gx_restmethod ;
      protected string AV10DeviceToken ;
      protected string AV9DeviceID ;
      protected string AV52MediaType ;
      protected bool returnInSub ;
      protected bool AV65PageIsPublished ;
      protected bool AV88IsNotifyResidents ;
      protected string AV17result ;
      protected string AV7secretKey ;
      protected string AV89refreshToken ;
      protected string AV86Base64Image ;
      protected string AV49MediaImageData ;
      protected string AV58PageJsonContent ;
      protected string AV56PageGJSHtml ;
      protected string AV57PageGJSJson ;
      protected string AV113PageStructure ;
      protected string AV93username ;
      protected string AV94password ;
      protected string AV8userId ;
      protected string AV96passwordNew ;
      protected string AV74ResidentId ;
      protected string AV14NotificationPlatform ;
      protected string AV15NotificationPlatformId ;
      protected string AV19title ;
      protected string AV13message ;
      protected string AV81StartDate ;
      protected string AV79EndDate ;
      protected string AV47MediaName ;
      protected string AV105LogoUrl ;
      protected string AV104ProfileImageUrl ;
      protected string AV60PageName ;
      protected string AV122AppVersionName ;
      protected string AV114PageType ;
      protected Guid AV16organisationId ;
      protected Guid AV12locationId ;
      protected Guid AV46MediaId ;
      protected Guid AV54PageId ;
      protected Guid AV100FormId ;
      protected Guid AV61ParentPageId ;
      protected Guid AV62ChildPageId ;
      protected Guid AV71ThemeId ;
      protected Guid AV66ProductServiceId ;
      protected Guid AV115AppVersionId ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse AV20SDT_LoginResidentResponse ;
      protected SdtSDT_LoginResidentResponse AV21loginResult ;
      protected SdtSDT_ChangeYourPassword AV97SDT_ChangeYourPassword ;
      protected SdtSDT_ChangeYourPassword AV98ChangeYourPasswordResult ;
      protected SdtSDT_RecoverPasswordStep1 AV102SDT_RecoverPasswordStep1 ;
      protected SdtSDT_RecoverPasswordStep1 AV103RecoverPasswordStep1Result ;
      protected SdtSDT_Resident AV22SDT_Resident ;
      protected SdtSDT_Organisation AV23SDT_Organisation ;
      protected SdtSDT_Location AV18SDT_Location ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> AV59SDT_AgendaLocation ;
      protected SdtSDT_ApiListResponse AV110SDT_ApiListResponse ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_LoginResidentResponse aP2_loginResult ;
      protected SdtSDT_RecoverPasswordStep1 aP1_RecoverPasswordStep1Result ;
      protected SdtSDT_ChangeYourPassword aP3_ChangeYourPasswordResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected SdtSDT_ApiListResponse aP3_SDT_ApiListResponse ;
      protected string aP2_result ;
      protected string aP6_result ;
      protected string aP3_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media AV50BC_Trn_Media ;
      protected SdtTrn_Media aP4_BC_Trn_Media ;
      protected SdtSDT_Error AV91error ;
      protected SdtSDT_Error aP5_error ;
      protected string aP1_result ;
      protected SdtSDT_Error aP2_error ;
      protected GXBaseCollection<SdtSDT_Media> AV85SDT_MediaCollection ;
      protected GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
      protected SdtSDT_Error aP1_error ;
      protected GXBaseCollection<SdtSDT_Page> AV44SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> AV70SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection ;
      protected SdtSDT_MobilePage AV75SDT_MobilePage ;
      protected SdtSDT_MobilePage aP4_SDT_MobilePage ;
      protected GXBaseCollection<SdtSDT_ContentPage> AV69SDT_ContentPageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_ContentPageV1 AV82SDT_ContentPage ;
      protected SdtSDT_ContentPageV1 aP3_SDT_ContentPage ;
      protected SdtSDT_Page AV55SDT_Page ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> AV64SDT_PageStructureCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      protected SdtSDT_Error aP3_error ;
      protected SdtSDT_Page aP2_SDT_Page ;
      protected string aP5_result ;
      protected string aP7_result ;
      protected SdtSDT_Error aP8_error ;
      protected GXBaseCollection<SdtSDT_PublishPage> AV92PagesList ;
      protected SdtSDT_Theme AV72SDT_Theme ;
      protected SdtSDT_Theme aP1_SDT_Theme ;
      protected SdtSDT_ProductService AV67SDT_ProductService ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected GXBaseCollection<SdtSDT_ProductService> AV101SDT_ProductServiceCollection ;
      protected GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ;
      protected SdtSDT_LocationTheme AV83SDT_LocationTheme ;
      protected SdtSDT_LocationTheme aP2_SDT_LocationTheme ;
      protected SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      protected GXBaseCollection<SdtSDT_Theme> AV111SDT_ThemeCollection ;
      protected GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ;
      protected GXBaseCollection<SdtSDT_AppVersion> AV119AppVersions ;
      protected GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ;
      protected SdtSDT_AppVersion AV121AppVersion ;
      protected SdtSDT_AppVersion aP1_AppVersion ;
      protected SdtSDT_AppVersion aP2_AppVersion ;
      protected GXBaseCollection<SdtSDT_PageV2> AV117PageCollection ;
      protected SdtSDT_AppVersion_PagesItem AV120MenuPage ;
      protected SdtSDT_AppVersion_PagesItem aP2_MenuPage ;
      protected SdtSDT_AppVersion_PagesItem AV118ContentPage ;
      protected SdtSDT_AppVersion_PagesItem aP2_ContentPage ;
   }

}
