using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_calltoaction_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_calltoaction_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_calltoaction_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1C80( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1C80( ) ;
         standaloneModal( ) ;
         AddRow1C80( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E111C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z367CallToActionId = A367CallToActionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C80( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C80( ) ;
            }
            else
            {
               CheckExtendedTable1C80( ) ;
               if ( AnyError == 0 )
               {
                  ZM1C80( 13) ;
                  ZM1C80( 14) ;
                  ZM1C80( 15) ;
               }
               CloseExtendedTableCursors1C80( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121C2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E111C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1C80( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z396CallToActionUrl = A396CallToActionUrl;
            Z397CallToActionName = A397CallToActionName;
            Z368CallToActionType = A368CallToActionType;
            Z370CallToActionPhone = A370CallToActionPhone;
            Z369CallToActionEmail = A369CallToActionEmail;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( GX_JID == -12 )
         {
            Z367CallToActionId = A367CallToActionId;
            Z396CallToActionUrl = A396CallToActionUrl;
            Z397CallToActionName = A397CallToActionName;
            Z368CallToActionType = A368CallToActionType;
            Z370CallToActionPhone = A370CallToActionPhone;
            Z369CallToActionEmail = A369CallToActionEmail;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z235WWPFormResumeMessage = A235WWPFormResumeMessage;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A367CallToActionId) )
         {
            A367CallToActionId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1C80( )
      {
         /* Using cursor BC001C7 */
         pr_default.execute(5, new Object[] {A367CallToActionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound80 = 1;
            A396CallToActionUrl = BC001C7_A396CallToActionUrl[0];
            A397CallToActionName = BC001C7_A397CallToActionName[0];
            A368CallToActionType = BC001C7_A368CallToActionType[0];
            A370CallToActionPhone = BC001C7_A370CallToActionPhone[0];
            A369CallToActionEmail = BC001C7_A369CallToActionEmail[0];
            A208WWPFormReferenceName = BC001C7_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001C7_A209WWPFormTitle[0];
            A231WWPFormDate = BC001C7_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001C7_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001C7_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001C7_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001C7_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001C7_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001C7_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001C7_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001C7_A242WWPFormIsForDynamicValidations[0];
            A58ProductServiceId = BC001C7_A58ProductServiceId[0];
            A29LocationId = BC001C7_A29LocationId[0];
            A11OrganisationId = BC001C7_A11OrganisationId[0];
            A395LocationDynamicFormId = BC001C7_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001C7_n395LocationDynamicFormId[0];
            A206WWPFormId = BC001C7_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001C7_A207WWPFormVersionNumber[0];
            ZM1C80( -12) ;
         }
         pr_default.close(5);
         OnLoadActions1C80( ) ;
      }

      protected void OnLoadActions1C80( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         if ( StringUtil.StrCmp(A368CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A396CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A368CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            A396CallToActionUrl = GXt_char2;
         }
      }

      protected void CheckExtendedTable1C80( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001C4 */
         pr_default.execute(2, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001C5 */
         pr_default.execute(3, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A395LocationDynamicFormId) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_LocationDynamicForm", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
            }
         }
         A206WWPFormId = BC001C5_A206WWPFormId[0];
         A207WWPFormVersionNumber = BC001C5_A207WWPFormVersionNumber[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         /* Using cursor BC001C6 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
            }
         }
         A208WWPFormReferenceName = BC001C6_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC001C6_A209WWPFormTitle[0];
         A231WWPFormDate = BC001C6_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC001C6_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC001C6_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC001C6_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC001C6_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC001C6_A234WWPFormInstantiated[0];
         A240WWPFormType = BC001C6_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC001C6_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC001C6_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(4);
         if ( StringUtil.StrCmp(A368CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A396CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A368CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            A396CallToActionUrl = GXt_char2;
         }
         if ( ! ( ( StringUtil.StrCmp(A368CallToActionType, "Phone") == 0 ) || ( StringUtil.StrCmp(A368CallToActionType, "Email") == 0 ) || ( StringUtil.StrCmp(A368CallToActionType, "Form") == 0 ) || ( StringUtil.StrCmp(A368CallToActionType, "SiteUrl") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Call To Action Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A396CallToActionUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Call To Action Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A369CallToActionEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Call To Action Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1C80( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C80( )
      {
         /* Using cursor BC001C8 */
         pr_default.execute(6, new Object[] {A367CallToActionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001C3 */
         pr_default.execute(1, new Object[] {A367CallToActionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C80( 12) ;
            RcdFound80 = 1;
            A367CallToActionId = BC001C3_A367CallToActionId[0];
            A396CallToActionUrl = BC001C3_A396CallToActionUrl[0];
            A397CallToActionName = BC001C3_A397CallToActionName[0];
            A368CallToActionType = BC001C3_A368CallToActionType[0];
            A370CallToActionPhone = BC001C3_A370CallToActionPhone[0];
            A369CallToActionEmail = BC001C3_A369CallToActionEmail[0];
            A58ProductServiceId = BC001C3_A58ProductServiceId[0];
            A29LocationId = BC001C3_A29LocationId[0];
            A11OrganisationId = BC001C3_A11OrganisationId[0];
            A395LocationDynamicFormId = BC001C3_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001C3_n395LocationDynamicFormId[0];
            Z367CallToActionId = A367CallToActionId;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1C80( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey1C80( ) ;
            }
            Gx_mode = sMode80;
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey1C80( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode80;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_1C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1C80( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001C2 */
            pr_default.execute(0, new Object[] {A367CallToActionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z396CallToActionUrl, BC001C2_A396CallToActionUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z397CallToActionName, BC001C2_A397CallToActionName[0]) != 0 ) || ( StringUtil.StrCmp(Z368CallToActionType, BC001C2_A368CallToActionType[0]) != 0 ) || ( StringUtil.StrCmp(Z370CallToActionPhone, BC001C2_A370CallToActionPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z369CallToActionEmail, BC001C2_A369CallToActionEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58ProductServiceId != BC001C2_A58ProductServiceId[0] ) || ( Z29LocationId != BC001C2_A29LocationId[0] ) || ( Z11OrganisationId != BC001C2_A11OrganisationId[0] ) || ( Z395LocationDynamicFormId != BC001C2_A395LocationDynamicFormId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_CallToAction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C80( )
      {
         BeforeValidate1C80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C80( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C80( 0) ;
            CheckOptimisticConcurrency1C80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C9 */
                     pr_default.execute(7, new Object[] {A367CallToActionId, A396CallToActionUrl, A397CallToActionName, A368CallToActionType, A370CallToActionPhone, A369CallToActionEmail, A58ProductServiceId, A29LocationId, A11OrganisationId, n395LocationDynamicFormId, A395LocationDynamicFormId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1C80( ) ;
            }
            EndLevel1C80( ) ;
         }
         CloseExtendedTableCursors1C80( ) ;
      }

      protected void Update1C80( )
      {
         BeforeValidate1C80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C80( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C10 */
                     pr_default.execute(8, new Object[] {A396CallToActionUrl, A397CallToActionName, A368CallToActionType, A370CallToActionPhone, A369CallToActionEmail, A58ProductServiceId, A29LocationId, A11OrganisationId, n395LocationDynamicFormId, A395LocationDynamicFormId, A367CallToActionId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C80( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1C80( ) ;
         }
         CloseExtendedTableCursors1C80( ) ;
      }

      protected void DeferredUpdate1C80( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1C80( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C80( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C80( ) ;
            AfterConfirm1C80( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C80( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001C11 */
                  pr_default.execute(9, new Object[] {A367CallToActionId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1C80( ) ;
         Gx_mode = sMode80;
      }

      protected void OnDeleteControls1C80( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001C12 */
            pr_default.execute(10, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
            A206WWPFormId = BC001C12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001C12_A207WWPFormVersionNumber[0];
            pr_default.close(10);
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001C13 */
            pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001C13_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001C13_A209WWPFormTitle[0];
            A231WWPFormDate = BC001C13_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001C13_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001C13_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001C13_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001C13_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001C13_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001C13_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001C13_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001C13_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel1C80( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C80( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1C80( )
      {
         /* Scan By routine */
         /* Using cursor BC001C14 */
         pr_default.execute(12, new Object[] {A367CallToActionId});
         RcdFound80 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound80 = 1;
            A367CallToActionId = BC001C14_A367CallToActionId[0];
            A396CallToActionUrl = BC001C14_A396CallToActionUrl[0];
            A397CallToActionName = BC001C14_A397CallToActionName[0];
            A368CallToActionType = BC001C14_A368CallToActionType[0];
            A370CallToActionPhone = BC001C14_A370CallToActionPhone[0];
            A369CallToActionEmail = BC001C14_A369CallToActionEmail[0];
            A208WWPFormReferenceName = BC001C14_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001C14_A209WWPFormTitle[0];
            A231WWPFormDate = BC001C14_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001C14_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001C14_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001C14_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001C14_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001C14_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001C14_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001C14_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001C14_A242WWPFormIsForDynamicValidations[0];
            A58ProductServiceId = BC001C14_A58ProductServiceId[0];
            A29LocationId = BC001C14_A29LocationId[0];
            A11OrganisationId = BC001C14_A11OrganisationId[0];
            A395LocationDynamicFormId = BC001C14_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001C14_n395LocationDynamicFormId[0];
            A206WWPFormId = BC001C14_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001C14_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1C80( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound80 = 0;
         ScanKeyLoad1C80( ) ;
      }

      protected void ScanKeyLoad1C80( )
      {
         sMode80 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound80 = 1;
            A367CallToActionId = BC001C14_A367CallToActionId[0];
            A396CallToActionUrl = BC001C14_A396CallToActionUrl[0];
            A397CallToActionName = BC001C14_A397CallToActionName[0];
            A368CallToActionType = BC001C14_A368CallToActionType[0];
            A370CallToActionPhone = BC001C14_A370CallToActionPhone[0];
            A369CallToActionEmail = BC001C14_A369CallToActionEmail[0];
            A208WWPFormReferenceName = BC001C14_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001C14_A209WWPFormTitle[0];
            A231WWPFormDate = BC001C14_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001C14_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001C14_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001C14_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001C14_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001C14_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001C14_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001C14_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001C14_A242WWPFormIsForDynamicValidations[0];
            A58ProductServiceId = BC001C14_A58ProductServiceId[0];
            A29LocationId = BC001C14_A29LocationId[0];
            A11OrganisationId = BC001C14_A11OrganisationId[0];
            A395LocationDynamicFormId = BC001C14_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001C14_n395LocationDynamicFormId[0];
            A206WWPFormId = BC001C14_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001C14_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode80;
      }

      protected void ScanKeyEnd1C80( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1C80( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C80( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C80( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C80( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C80( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C80( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C80( )
      {
      }

      protected void send_integrity_lvl_hashes1C80( )
      {
      }

      protected void AddRow1C80( )
      {
         VarsToRow80( bcTrn_CallToAction) ;
      }

      protected void ReadRow1C80( )
      {
         RowToVars80( bcTrn_CallToAction, 1) ;
      }

      protected void InitializeNonKey1C80( )
      {
         A396CallToActionUrl = "";
         A219WWPFormLatestVersionNumber = 0;
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A397CallToActionName = "";
         A368CallToActionType = "";
         A370CallToActionPhone = "";
         A369CallToActionEmail = "";
         A395LocationDynamicFormId = Guid.Empty;
         n395LocationDynamicFormId = false;
         A206WWPFormId = 0;
         A207WWPFormVersionNumber = 0;
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A232WWPFormIsWizard = false;
         A216WWPFormResume = 0;
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A234WWPFormInstantiated = false;
         A240WWPFormType = 0;
         A241WWPFormSectionRefElements = "";
         A242WWPFormIsForDynamicValidations = false;
         Z396CallToActionUrl = "";
         Z397CallToActionName = "";
         Z368CallToActionType = "";
         Z370CallToActionPhone = "";
         Z369CallToActionEmail = "";
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z395LocationDynamicFormId = Guid.Empty;
      }

      protected void InitAll1C80( )
      {
         A367CallToActionId = Guid.NewGuid( );
         InitializeNonKey1C80( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow80( SdtTrn_CallToAction obj80 )
      {
         obj80.gxTpr_Mode = Gx_mode;
         obj80.gxTpr_Calltoactionurl = A396CallToActionUrl;
         obj80.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj80.gxTpr_Productserviceid = A58ProductServiceId;
         obj80.gxTpr_Organisationid = A11OrganisationId;
         obj80.gxTpr_Locationid = A29LocationId;
         obj80.gxTpr_Calltoactionname = A397CallToActionName;
         obj80.gxTpr_Calltoactiontype = A368CallToActionType;
         obj80.gxTpr_Calltoactionphone = A370CallToActionPhone;
         obj80.gxTpr_Calltoactionemail = A369CallToActionEmail;
         obj80.gxTpr_Locationdynamicformid = A395LocationDynamicFormId;
         obj80.gxTpr_Wwpformid = A206WWPFormId;
         obj80.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj80.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj80.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj80.gxTpr_Wwpformdate = A231WWPFormDate;
         obj80.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj80.gxTpr_Wwpformresume = A216WWPFormResume;
         obj80.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj80.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj80.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj80.gxTpr_Wwpformtype = A240WWPFormType;
         obj80.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj80.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj80.gxTpr_Calltoactionid = A367CallToActionId;
         obj80.gxTpr_Calltoactionid_Z = Z367CallToActionId;
         obj80.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj80.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj80.gxTpr_Locationid_Z = Z29LocationId;
         obj80.gxTpr_Calltoactionname_Z = Z397CallToActionName;
         obj80.gxTpr_Calltoactiontype_Z = Z368CallToActionType;
         obj80.gxTpr_Calltoactionphone_Z = Z370CallToActionPhone;
         obj80.gxTpr_Calltoactionurl_Z = Z396CallToActionUrl;
         obj80.gxTpr_Calltoactionemail_Z = Z369CallToActionEmail;
         obj80.gxTpr_Locationdynamicformid_Z = Z395LocationDynamicFormId;
         obj80.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj80.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj80.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj80.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj80.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj80.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj80.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj80.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj80.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj80.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj80.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj80.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj80.gxTpr_Locationdynamicformid_N = (short)(Convert.ToInt16(n395LocationDynamicFormId));
         obj80.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow80( SdtTrn_CallToAction obj80 )
      {
         obj80.gxTpr_Calltoactionid = A367CallToActionId;
         return  ;
      }

      public void RowToVars80( SdtTrn_CallToAction obj80 ,
                               int forceLoad )
      {
         Gx_mode = obj80.gxTpr_Mode;
         A396CallToActionUrl = obj80.gxTpr_Calltoactionurl;
         A219WWPFormLatestVersionNumber = obj80.gxTpr_Wwpformlatestversionnumber;
         A58ProductServiceId = obj80.gxTpr_Productserviceid;
         A11OrganisationId = obj80.gxTpr_Organisationid;
         A29LocationId = obj80.gxTpr_Locationid;
         A397CallToActionName = obj80.gxTpr_Calltoactionname;
         A368CallToActionType = obj80.gxTpr_Calltoactiontype;
         A370CallToActionPhone = obj80.gxTpr_Calltoactionphone;
         A369CallToActionEmail = obj80.gxTpr_Calltoactionemail;
         A395LocationDynamicFormId = obj80.gxTpr_Locationdynamicformid;
         n395LocationDynamicFormId = false;
         A206WWPFormId = obj80.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj80.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj80.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj80.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj80.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj80.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj80.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj80.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj80.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj80.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj80.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj80.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj80.gxTpr_Wwpformisfordynamicvalidations;
         A367CallToActionId = obj80.gxTpr_Calltoactionid;
         Z367CallToActionId = obj80.gxTpr_Calltoactionid_Z;
         Z58ProductServiceId = obj80.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj80.gxTpr_Organisationid_Z;
         Z29LocationId = obj80.gxTpr_Locationid_Z;
         Z397CallToActionName = obj80.gxTpr_Calltoactionname_Z;
         Z368CallToActionType = obj80.gxTpr_Calltoactiontype_Z;
         Z370CallToActionPhone = obj80.gxTpr_Calltoactionphone_Z;
         Z396CallToActionUrl = obj80.gxTpr_Calltoactionurl_Z;
         Z369CallToActionEmail = obj80.gxTpr_Calltoactionemail_Z;
         Z395LocationDynamicFormId = obj80.gxTpr_Locationdynamicformid_Z;
         Z206WWPFormId = obj80.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj80.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj80.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj80.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj80.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj80.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj80.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj80.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj80.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj80.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj80.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj80.gxTpr_Wwpformisfordynamicvalidations_Z;
         n395LocationDynamicFormId = (bool)(Convert.ToBoolean(obj80.gxTpr_Locationdynamicformid_N));
         Gx_mode = obj80.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A367CallToActionId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1C80( ) ;
         ScanKeyStart1C80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z367CallToActionId = A367CallToActionId;
         }
         ZM1C80( -12) ;
         OnLoadActions1C80( ) ;
         AddRow1C80( ) ;
         ScanKeyEnd1C80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars80( bcTrn_CallToAction, 0) ;
         ScanKeyStart1C80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z367CallToActionId = A367CallToActionId;
         }
         ZM1C80( -12) ;
         OnLoadActions1C80( ) ;
         AddRow1C80( ) ;
         ScanKeyEnd1C80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1C80( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1C80( ) ;
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( A367CallToActionId != Z367CallToActionId )
               {
                  A367CallToActionId = Z367CallToActionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1C80( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A367CallToActionId != Z367CallToActionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1C80( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1C80( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcTrn_CallToAction, 1) ;
         SaveImpl( ) ;
         VarsToRow80( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcTrn_CallToAction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C80( ) ;
         AfterTrn( ) ;
         VarsToRow80( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow80( bcTrn_CallToAction) ;
         }
         else
         {
            SdtTrn_CallToAction auxBC = new SdtTrn_CallToAction(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A367CallToActionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_CallToAction);
               auxBC.Save();
               bcTrn_CallToAction.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcTrn_CallToAction, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcTrn_CallToAction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C80( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow80( bcTrn_CallToAction) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow80( bcTrn_CallToAction) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcTrn_CallToAction, 0) ;
         GetKey1C80( ) ;
         if ( RcdFound80 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A367CallToActionId != Z367CallToActionId )
            {
               A367CallToActionId = Z367CallToActionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A367CallToActionId != Z367CallToActionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_calltoaction_bc",pr_default);
         VarsToRow80( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_CallToAction.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_CallToAction.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_CallToAction )
         {
            bcTrn_CallToAction = (SdtTrn_CallToAction)(sdt);
            if ( StringUtil.StrCmp(bcTrn_CallToAction.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CallToAction.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow80( bcTrn_CallToAction) ;
            }
            else
            {
               RowToVars80( bcTrn_CallToAction, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_CallToAction.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CallToAction.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars80( bcTrn_CallToAction, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_CallToAction Trn_CallToAction_BC
      {
         get {
            return bcTrn_CallToAction ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_calltoaction_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z367CallToActionId = Guid.Empty;
         A367CallToActionId = Guid.Empty;
         Z396CallToActionUrl = "";
         A396CallToActionUrl = "";
         Z397CallToActionName = "";
         A397CallToActionName = "";
         Z368CallToActionType = "";
         A368CallToActionType = "";
         Z370CallToActionPhone = "";
         A370CallToActionPhone = "";
         Z369CallToActionEmail = "";
         A369CallToActionEmail = "";
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z395LocationDynamicFormId = Guid.Empty;
         A395LocationDynamicFormId = Guid.Empty;
         Z208WWPFormReferenceName = "";
         A208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         A209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z241WWPFormSectionRefElements = "";
         A241WWPFormSectionRefElements = "";
         Z235WWPFormResumeMessage = "";
         A235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         A233WWPFormValidations = "";
         BC001C7_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001C7_A396CallToActionUrl = new string[] {""} ;
         BC001C7_A397CallToActionName = new string[] {""} ;
         BC001C7_A368CallToActionType = new string[] {""} ;
         BC001C7_A370CallToActionPhone = new string[] {""} ;
         BC001C7_A369CallToActionEmail = new string[] {""} ;
         BC001C7_A208WWPFormReferenceName = new string[] {""} ;
         BC001C7_A209WWPFormTitle = new string[] {""} ;
         BC001C7_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001C7_A232WWPFormIsWizard = new bool[] {false} ;
         BC001C7_A216WWPFormResume = new short[1] ;
         BC001C7_A235WWPFormResumeMessage = new string[] {""} ;
         BC001C7_A233WWPFormValidations = new string[] {""} ;
         BC001C7_A234WWPFormInstantiated = new bool[] {false} ;
         BC001C7_A240WWPFormType = new short[1] ;
         BC001C7_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001C7_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001C7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001C7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C7_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001C7_n395LocationDynamicFormId = new bool[] {false} ;
         BC001C7_A206WWPFormId = new short[1] ;
         BC001C7_A207WWPFormVersionNumber = new short[1] ;
         BC001C4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001C5_A206WWPFormId = new short[1] ;
         BC001C5_A207WWPFormVersionNumber = new short[1] ;
         BC001C6_A208WWPFormReferenceName = new string[] {""} ;
         BC001C6_A209WWPFormTitle = new string[] {""} ;
         BC001C6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001C6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001C6_A216WWPFormResume = new short[1] ;
         BC001C6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001C6_A233WWPFormValidations = new string[] {""} ;
         BC001C6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001C6_A240WWPFormType = new short[1] ;
         BC001C6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001C6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         GXt_char2 = "";
         BC001C8_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001C3_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001C3_A396CallToActionUrl = new string[] {""} ;
         BC001C3_A397CallToActionName = new string[] {""} ;
         BC001C3_A368CallToActionType = new string[] {""} ;
         BC001C3_A370CallToActionPhone = new string[] {""} ;
         BC001C3_A369CallToActionEmail = new string[] {""} ;
         BC001C3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001C3_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001C3_n395LocationDynamicFormId = new bool[] {false} ;
         sMode80 = "";
         BC001C2_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001C2_A396CallToActionUrl = new string[] {""} ;
         BC001C2_A397CallToActionName = new string[] {""} ;
         BC001C2_A368CallToActionType = new string[] {""} ;
         BC001C2_A370CallToActionPhone = new string[] {""} ;
         BC001C2_A369CallToActionEmail = new string[] {""} ;
         BC001C2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001C2_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C2_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001C2_n395LocationDynamicFormId = new bool[] {false} ;
         BC001C12_A206WWPFormId = new short[1] ;
         BC001C12_A207WWPFormVersionNumber = new short[1] ;
         BC001C13_A208WWPFormReferenceName = new string[] {""} ;
         BC001C13_A209WWPFormTitle = new string[] {""} ;
         BC001C13_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001C13_A232WWPFormIsWizard = new bool[] {false} ;
         BC001C13_A216WWPFormResume = new short[1] ;
         BC001C13_A235WWPFormResumeMessage = new string[] {""} ;
         BC001C13_A233WWPFormValidations = new string[] {""} ;
         BC001C13_A234WWPFormInstantiated = new bool[] {false} ;
         BC001C13_A240WWPFormType = new short[1] ;
         BC001C13_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001C13_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001C14_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001C14_A396CallToActionUrl = new string[] {""} ;
         BC001C14_A397CallToActionName = new string[] {""} ;
         BC001C14_A368CallToActionType = new string[] {""} ;
         BC001C14_A370CallToActionPhone = new string[] {""} ;
         BC001C14_A369CallToActionEmail = new string[] {""} ;
         BC001C14_A208WWPFormReferenceName = new string[] {""} ;
         BC001C14_A209WWPFormTitle = new string[] {""} ;
         BC001C14_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001C14_A232WWPFormIsWizard = new bool[] {false} ;
         BC001C14_A216WWPFormResume = new short[1] ;
         BC001C14_A235WWPFormResumeMessage = new string[] {""} ;
         BC001C14_A233WWPFormValidations = new string[] {""} ;
         BC001C14_A234WWPFormInstantiated = new bool[] {false} ;
         BC001C14_A240WWPFormType = new short[1] ;
         BC001C14_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001C14_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001C14_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001C14_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C14_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001C14_n395LocationDynamicFormId = new bool[] {false} ;
         BC001C14_A206WWPFormId = new short[1] ;
         BC001C14_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__default(),
            new Object[][] {
                new Object[] {
               BC001C2_A367CallToActionId, BC001C2_A396CallToActionUrl, BC001C2_A397CallToActionName, BC001C2_A368CallToActionType, BC001C2_A370CallToActionPhone, BC001C2_A369CallToActionEmail, BC001C2_A58ProductServiceId, BC001C2_A29LocationId, BC001C2_A11OrganisationId, BC001C2_A395LocationDynamicFormId,
               BC001C2_n395LocationDynamicFormId
               }
               , new Object[] {
               BC001C3_A367CallToActionId, BC001C3_A396CallToActionUrl, BC001C3_A397CallToActionName, BC001C3_A368CallToActionType, BC001C3_A370CallToActionPhone, BC001C3_A369CallToActionEmail, BC001C3_A58ProductServiceId, BC001C3_A29LocationId, BC001C3_A11OrganisationId, BC001C3_A395LocationDynamicFormId,
               BC001C3_n395LocationDynamicFormId
               }
               , new Object[] {
               BC001C4_A58ProductServiceId
               }
               , new Object[] {
               BC001C5_A206WWPFormId, BC001C5_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001C6_A208WWPFormReferenceName, BC001C6_A209WWPFormTitle, BC001C6_A231WWPFormDate, BC001C6_A232WWPFormIsWizard, BC001C6_A216WWPFormResume, BC001C6_A235WWPFormResumeMessage, BC001C6_A233WWPFormValidations, BC001C6_A234WWPFormInstantiated, BC001C6_A240WWPFormType, BC001C6_A241WWPFormSectionRefElements,
               BC001C6_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001C7_A367CallToActionId, BC001C7_A396CallToActionUrl, BC001C7_A397CallToActionName, BC001C7_A368CallToActionType, BC001C7_A370CallToActionPhone, BC001C7_A369CallToActionEmail, BC001C7_A208WWPFormReferenceName, BC001C7_A209WWPFormTitle, BC001C7_A231WWPFormDate, BC001C7_A232WWPFormIsWizard,
               BC001C7_A216WWPFormResume, BC001C7_A235WWPFormResumeMessage, BC001C7_A233WWPFormValidations, BC001C7_A234WWPFormInstantiated, BC001C7_A240WWPFormType, BC001C7_A241WWPFormSectionRefElements, BC001C7_A242WWPFormIsForDynamicValidations, BC001C7_A58ProductServiceId, BC001C7_A29LocationId, BC001C7_A11OrganisationId,
               BC001C7_A395LocationDynamicFormId, BC001C7_n395LocationDynamicFormId, BC001C7_A206WWPFormId, BC001C7_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001C8_A367CallToActionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001C12_A206WWPFormId, BC001C12_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001C13_A208WWPFormReferenceName, BC001C13_A209WWPFormTitle, BC001C13_A231WWPFormDate, BC001C13_A232WWPFormIsWizard, BC001C13_A216WWPFormResume, BC001C13_A235WWPFormResumeMessage, BC001C13_A233WWPFormValidations, BC001C13_A234WWPFormInstantiated, BC001C13_A240WWPFormType, BC001C13_A241WWPFormSectionRefElements,
               BC001C13_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001C14_A367CallToActionId, BC001C14_A396CallToActionUrl, BC001C14_A397CallToActionName, BC001C14_A368CallToActionType, BC001C14_A370CallToActionPhone, BC001C14_A369CallToActionEmail, BC001C14_A208WWPFormReferenceName, BC001C14_A209WWPFormTitle, BC001C14_A231WWPFormDate, BC001C14_A232WWPFormIsWizard,
               BC001C14_A216WWPFormResume, BC001C14_A235WWPFormResumeMessage, BC001C14_A233WWPFormValidations, BC001C14_A234WWPFormInstantiated, BC001C14_A240WWPFormType, BC001C14_A241WWPFormSectionRefElements, BC001C14_A242WWPFormIsForDynamicValidations, BC001C14_A58ProductServiceId, BC001C14_A29LocationId, BC001C14_A11OrganisationId,
               BC001C14_A395LocationDynamicFormId, BC001C14_n395LocationDynamicFormId, BC001C14_A206WWPFormId, BC001C14_A207WWPFormVersionNumber
               }
            }
         );
         Z367CallToActionId = Guid.NewGuid( );
         A367CallToActionId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121C2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z219WWPFormLatestVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Z240WWPFormType ;
      private short A240WWPFormType ;
      private short Gx_BScreen ;
      private short RcdFound80 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z370CallToActionPhone ;
      private string A370CallToActionPhone ;
      private string GXt_char2 ;
      private string sMode80 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n395LocationDynamicFormId ;
      private bool Gx_longc ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z396CallToActionUrl ;
      private string A396CallToActionUrl ;
      private string Z397CallToActionName ;
      private string A397CallToActionName ;
      private string Z368CallToActionType ;
      private string A368CallToActionType ;
      private string Z369CallToActionEmail ;
      private string A369CallToActionEmail ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private Guid Z367CallToActionId ;
      private Guid A367CallToActionId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z395LocationDynamicFormId ;
      private Guid A395LocationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001C7_A367CallToActionId ;
      private string[] BC001C7_A396CallToActionUrl ;
      private string[] BC001C7_A397CallToActionName ;
      private string[] BC001C7_A368CallToActionType ;
      private string[] BC001C7_A370CallToActionPhone ;
      private string[] BC001C7_A369CallToActionEmail ;
      private string[] BC001C7_A208WWPFormReferenceName ;
      private string[] BC001C7_A209WWPFormTitle ;
      private DateTime[] BC001C7_A231WWPFormDate ;
      private bool[] BC001C7_A232WWPFormIsWizard ;
      private short[] BC001C7_A216WWPFormResume ;
      private string[] BC001C7_A235WWPFormResumeMessage ;
      private string[] BC001C7_A233WWPFormValidations ;
      private bool[] BC001C7_A234WWPFormInstantiated ;
      private short[] BC001C7_A240WWPFormType ;
      private string[] BC001C7_A241WWPFormSectionRefElements ;
      private bool[] BC001C7_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001C7_A58ProductServiceId ;
      private Guid[] BC001C7_A29LocationId ;
      private Guid[] BC001C7_A11OrganisationId ;
      private Guid[] BC001C7_A395LocationDynamicFormId ;
      private bool[] BC001C7_n395LocationDynamicFormId ;
      private short[] BC001C7_A206WWPFormId ;
      private short[] BC001C7_A207WWPFormVersionNumber ;
      private Guid[] BC001C4_A58ProductServiceId ;
      private short[] BC001C5_A206WWPFormId ;
      private short[] BC001C5_A207WWPFormVersionNumber ;
      private string[] BC001C6_A208WWPFormReferenceName ;
      private string[] BC001C6_A209WWPFormTitle ;
      private DateTime[] BC001C6_A231WWPFormDate ;
      private bool[] BC001C6_A232WWPFormIsWizard ;
      private short[] BC001C6_A216WWPFormResume ;
      private string[] BC001C6_A235WWPFormResumeMessage ;
      private string[] BC001C6_A233WWPFormValidations ;
      private bool[] BC001C6_A234WWPFormInstantiated ;
      private short[] BC001C6_A240WWPFormType ;
      private string[] BC001C6_A241WWPFormSectionRefElements ;
      private bool[] BC001C6_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001C8_A367CallToActionId ;
      private Guid[] BC001C3_A367CallToActionId ;
      private string[] BC001C3_A396CallToActionUrl ;
      private string[] BC001C3_A397CallToActionName ;
      private string[] BC001C3_A368CallToActionType ;
      private string[] BC001C3_A370CallToActionPhone ;
      private string[] BC001C3_A369CallToActionEmail ;
      private Guid[] BC001C3_A58ProductServiceId ;
      private Guid[] BC001C3_A29LocationId ;
      private Guid[] BC001C3_A11OrganisationId ;
      private Guid[] BC001C3_A395LocationDynamicFormId ;
      private bool[] BC001C3_n395LocationDynamicFormId ;
      private Guid[] BC001C2_A367CallToActionId ;
      private string[] BC001C2_A396CallToActionUrl ;
      private string[] BC001C2_A397CallToActionName ;
      private string[] BC001C2_A368CallToActionType ;
      private string[] BC001C2_A370CallToActionPhone ;
      private string[] BC001C2_A369CallToActionEmail ;
      private Guid[] BC001C2_A58ProductServiceId ;
      private Guid[] BC001C2_A29LocationId ;
      private Guid[] BC001C2_A11OrganisationId ;
      private Guid[] BC001C2_A395LocationDynamicFormId ;
      private bool[] BC001C2_n395LocationDynamicFormId ;
      private short[] BC001C12_A206WWPFormId ;
      private short[] BC001C12_A207WWPFormVersionNumber ;
      private string[] BC001C13_A208WWPFormReferenceName ;
      private string[] BC001C13_A209WWPFormTitle ;
      private DateTime[] BC001C13_A231WWPFormDate ;
      private bool[] BC001C13_A232WWPFormIsWizard ;
      private short[] BC001C13_A216WWPFormResume ;
      private string[] BC001C13_A235WWPFormResumeMessage ;
      private string[] BC001C13_A233WWPFormValidations ;
      private bool[] BC001C13_A234WWPFormInstantiated ;
      private short[] BC001C13_A240WWPFormType ;
      private string[] BC001C13_A241WWPFormSectionRefElements ;
      private bool[] BC001C13_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001C14_A367CallToActionId ;
      private string[] BC001C14_A396CallToActionUrl ;
      private string[] BC001C14_A397CallToActionName ;
      private string[] BC001C14_A368CallToActionType ;
      private string[] BC001C14_A370CallToActionPhone ;
      private string[] BC001C14_A369CallToActionEmail ;
      private string[] BC001C14_A208WWPFormReferenceName ;
      private string[] BC001C14_A209WWPFormTitle ;
      private DateTime[] BC001C14_A231WWPFormDate ;
      private bool[] BC001C14_A232WWPFormIsWizard ;
      private short[] BC001C14_A216WWPFormResume ;
      private string[] BC001C14_A235WWPFormResumeMessage ;
      private string[] BC001C14_A233WWPFormValidations ;
      private bool[] BC001C14_A234WWPFormInstantiated ;
      private short[] BC001C14_A240WWPFormType ;
      private string[] BC001C14_A241WWPFormSectionRefElements ;
      private bool[] BC001C14_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001C14_A58ProductServiceId ;
      private Guid[] BC001C14_A29LocationId ;
      private Guid[] BC001C14_A11OrganisationId ;
      private Guid[] BC001C14_A395LocationDynamicFormId ;
      private bool[] BC001C14_n395LocationDynamicFormId ;
      private short[] BC001C14_A206WWPFormId ;
      private short[] BC001C14_A207WWPFormVersionNumber ;
      private SdtTrn_CallToAction bcTrn_CallToAction ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_calltoaction_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_calltoaction_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_calltoaction_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001C2;
       prmBC001C2 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C3;
       prmBC001C3 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C4;
       prmBC001C4 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C5;
       prmBC001C5 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C6;
       prmBC001C6 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001C7;
       prmBC001C7 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C8;
       prmBC001C8 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C9;
       prmBC001C9 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001C10;
       prmBC001C10 = new Object[] {
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C11;
       prmBC001C11 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C12;
       prmBC001C12 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C13;
       prmBC001C13 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001C14;
       prmBC001C14 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001C2", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionEmail, ProductServiceId, LocationId, OrganisationId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId  FOR UPDATE OF Trn_CallToAction",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C3", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionEmail, ProductServiceId, LocationId, OrganisationId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C4", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C5", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C6", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C7", "SELECT TM1.CallToActionId, TM1.CallToActionUrl, TM1.CallToActionName, TM1.CallToActionType, TM1.CallToActionPhone, TM1.CallToActionEmail, T3.WWPFormReferenceName, T3.WWPFormTitle, T3.WWPFormDate, T3.WWPFormIsWizard, T3.WWPFormResume, T3.WWPFormResumeMessage, T3.WWPFormValidations, T3.WWPFormInstantiated, T3.WWPFormType, T3.WWPFormSectionRefElements, T3.WWPFormIsForDynamicValidations, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, TM1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber FROM ((Trn_CallToAction TM1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = TM1.LocationDynamicFormId AND T2.OrganisationId = TM1.OrganisationId AND T2.LocationId = TM1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE TM1.CallToActionId = :CallToActionId ORDER BY TM1.CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C8", "SELECT CallToActionId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C9", "SAVEPOINT gxupdate;INSERT INTO Trn_CallToAction(CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionEmail, ProductServiceId, LocationId, OrganisationId, LocationDynamicFormId) VALUES(:CallToActionId, :CallToActionUrl, :CallToActionName, :CallToActionType, :CallToActionPhone, :CallToActionEmail, :ProductServiceId, :LocationId, :OrganisationId, :LocationDynamicFormId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C9)
          ,new CursorDef("BC001C10", "SAVEPOINT gxupdate;UPDATE Trn_CallToAction SET CallToActionUrl=:CallToActionUrl, CallToActionName=:CallToActionName, CallToActionType=:CallToActionType, CallToActionPhone=:CallToActionPhone, CallToActionEmail=:CallToActionEmail, ProductServiceId=:ProductServiceId, LocationId=:LocationId, OrganisationId=:OrganisationId, LocationDynamicFormId=:LocationDynamicFormId  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C10)
          ,new CursorDef("BC001C11", "SAVEPOINT gxupdate;DELETE FROM Trn_CallToAction  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C11)
          ,new CursorDef("BC001C12", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C13", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C14", "SELECT TM1.CallToActionId, TM1.CallToActionUrl, TM1.CallToActionName, TM1.CallToActionType, TM1.CallToActionPhone, TM1.CallToActionEmail, T3.WWPFormReferenceName, T3.WWPFormTitle, T3.WWPFormDate, T3.WWPFormIsWizard, T3.WWPFormResume, T3.WWPFormResumeMessage, T3.WWPFormValidations, T3.WWPFormInstantiated, T3.WWPFormType, T3.WWPFormSectionRefElements, T3.WWPFormIsForDynamicValidations, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, TM1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber FROM ((Trn_CallToAction TM1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = TM1.LocationDynamicFormId AND T2.OrganisationId = TM1.OrganisationId AND T2.LocationId = TM1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE TM1.CallToActionId = :CallToActionId ORDER BY TM1.CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C14,100, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((bool[]) buf[16])[0] = rslt.getBool(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((bool[]) buf[21])[0] = rslt.wasNull(21);
             ((short[]) buf[22])[0] = rslt.getShort(22);
             ((short[]) buf[23])[0] = rslt.getShort(23);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((bool[]) buf[16])[0] = rslt.getBool(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((bool[]) buf[21])[0] = rslt.wasNull(21);
             ((short[]) buf[22])[0] = rslt.getShort(22);
             ((short[]) buf[23])[0] = rslt.getShort(23);
             return;
    }
 }

}

}
