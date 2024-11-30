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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_locationdynamicform_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_locationdynamicform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationdynamicform_bc( IGxContext context )
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
         ReadRow1B79( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1B79( ) ;
         standaloneModal( ) ;
         AddRow1B79( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z395LocationDynamicFormId = A395LocationDynamicFormId;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B79( ) ;
            }
            else
            {
               CheckExtendedTable1B79( ) ;
               if ( AnyError == 0 )
               {
                  ZM1B79( 7) ;
                  ZM1B79( 8) ;
               }
               CloseExtendedTableCursors1B79( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1B79( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -6 )
         {
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
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
         if ( IsIns( )  && (Guid.Empty==A395LocationDynamicFormId) )
         {
            A395LocationDynamicFormId = Guid.NewGuid( );
            n395LocationDynamicFormId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1B79( )
      {
         /* Using cursor BC001B6 */
         pr_default.execute(4, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound79 = 1;
            A208WWPFormReferenceName = BC001B6_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001B6_A209WWPFormTitle[0];
            A231WWPFormDate = BC001B6_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001B6_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001B6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001B6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001B6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001B6_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001B6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001B6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001B6_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = BC001B6_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001B6_A207WWPFormVersionNumber[0];
            ZM1B79( -6) ;
         }
         pr_default.close(4);
         OnLoadActions1B79( ) ;
      }

      protected void OnLoadActions1B79( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable1B79( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001B4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001B5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC001B5_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC001B5_A209WWPFormTitle[0];
         A231WWPFormDate = BC001B5_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC001B5_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC001B5_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC001B5_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC001B5_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC001B5_A234WWPFormInstantiated[0];
         A240WWPFormType = BC001B5_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC001B5_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC001B5_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CloseExtendedTableCursors1B79( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1B79( )
      {
         /* Using cursor BC001B7 */
         pr_default.execute(5, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001B3 */
         pr_default.execute(1, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B79( 6) ;
            RcdFound79 = 1;
            A395LocationDynamicFormId = BC001B3_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001B3_n395LocationDynamicFormId[0];
            A11OrganisationId = BC001B3_A11OrganisationId[0];
            A29LocationId = BC001B3_A29LocationId[0];
            A206WWPFormId = BC001B3_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001B3_A207WWPFormVersionNumber[0];
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1B79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey1B79( ) ;
            }
            Gx_mode = sMode79;
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey1B79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode79;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B79( ) ;
         if ( RcdFound79 == 0 )
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
         CONFIRM_1B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1B79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001B2 */
            pr_default.execute(0, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != BC001B2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC001B2_A207WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_LocationDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B79( )
      {
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B79( 0) ;
            CheckOptimisticConcurrency1B79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B8 */
                     pr_default.execute(6, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load1B79( ) ;
            }
            EndLevel1B79( ) ;
         }
         CloseExtendedTableCursors1B79( ) ;
      }

      protected void Update1B79( )
      {
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B9 */
                     pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B79( ) ;
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
            EndLevel1B79( ) ;
         }
         CloseExtendedTableCursors1B79( ) ;
      }

      protected void DeferredUpdate1B79( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B79( ) ;
            AfterConfirm1B79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001B10 */
                  pr_default.execute(8, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1B79( ) ;
         Gx_mode = sMode79;
      }

      protected void OnDeleteControls1B79( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001B11 */
            pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001B11_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001B11_A209WWPFormTitle[0];
            A231WWPFormDate = BC001B11_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001B11_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001B11_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001B11_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001B11_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001B11_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001B11_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001B11_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001B11_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001B12 */
            pr_default.execute(10, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_CallToAction", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1B79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B79( ) ;
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

      public void ScanKeyStart1B79( )
      {
         /* Using cursor BC001B13 */
         pr_default.execute(11, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         RcdFound79 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound79 = 1;
            A395LocationDynamicFormId = BC001B13_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001B13_n395LocationDynamicFormId[0];
            A208WWPFormReferenceName = BC001B13_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001B13_A209WWPFormTitle[0];
            A231WWPFormDate = BC001B13_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001B13_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001B13_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001B13_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001B13_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001B13_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001B13_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001B13_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001B13_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001B13_A11OrganisationId[0];
            A29LocationId = BC001B13_A29LocationId[0];
            A206WWPFormId = BC001B13_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001B13_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1B79( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound79 = 0;
         ScanKeyLoad1B79( ) ;
      }

      protected void ScanKeyLoad1B79( )
      {
         sMode79 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound79 = 1;
            A395LocationDynamicFormId = BC001B13_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = BC001B13_n395LocationDynamicFormId[0];
            A208WWPFormReferenceName = BC001B13_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001B13_A209WWPFormTitle[0];
            A231WWPFormDate = BC001B13_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001B13_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001B13_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001B13_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001B13_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001B13_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001B13_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001B13_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001B13_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001B13_A11OrganisationId[0];
            A29LocationId = BC001B13_A29LocationId[0];
            A206WWPFormId = BC001B13_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001B13_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode79;
      }

      protected void ScanKeyEnd1B79( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1B79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B79( )
      {
      }

      protected void send_integrity_lvl_hashes1B79( )
      {
      }

      protected void AddRow1B79( )
      {
         VarsToRow79( bcTrn_LocationDynamicForm) ;
      }

      protected void ReadRow1B79( )
      {
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
      }

      protected void InitializeNonKey1B79( )
      {
         A219WWPFormLatestVersionNumber = 0;
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
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
      }

      protected void InitAll1B79( )
      {
         A395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         InitializeNonKey1B79( ) ;
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

      public void VarsToRow79( SdtTrn_LocationDynamicForm obj79 )
      {
         obj79.gxTpr_Mode = Gx_mode;
         obj79.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj79.gxTpr_Wwpformid = A206WWPFormId;
         obj79.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj79.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj79.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj79.gxTpr_Wwpformdate = A231WWPFormDate;
         obj79.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj79.gxTpr_Wwpformresume = A216WWPFormResume;
         obj79.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj79.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj79.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj79.gxTpr_Wwpformtype = A240WWPFormType;
         obj79.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj79.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj79.gxTpr_Locationdynamicformid = A395LocationDynamicFormId;
         obj79.gxTpr_Organisationid = A11OrganisationId;
         obj79.gxTpr_Locationid = A29LocationId;
         obj79.gxTpr_Locationdynamicformid_Z = Z395LocationDynamicFormId;
         obj79.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj79.gxTpr_Locationid_Z = Z29LocationId;
         obj79.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj79.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj79.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj79.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj79.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj79.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj79.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj79.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj79.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj79.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj79.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj79.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj79.gxTpr_Locationdynamicformid_N = (short)(Convert.ToInt16(n395LocationDynamicFormId));
         obj79.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow79( SdtTrn_LocationDynamicForm obj79 )
      {
         obj79.gxTpr_Locationdynamicformid = A395LocationDynamicFormId;
         obj79.gxTpr_Organisationid = A11OrganisationId;
         obj79.gxTpr_Locationid = A29LocationId;
         return  ;
      }

      public void RowToVars79( SdtTrn_LocationDynamicForm obj79 ,
                               int forceLoad )
      {
         Gx_mode = obj79.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj79.gxTpr_Wwpformlatestversionnumber;
         A206WWPFormId = obj79.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj79.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj79.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj79.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj79.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj79.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj79.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj79.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj79.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj79.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj79.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj79.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj79.gxTpr_Wwpformisfordynamicvalidations;
         A395LocationDynamicFormId = obj79.gxTpr_Locationdynamicformid;
         n395LocationDynamicFormId = false;
         A11OrganisationId = obj79.gxTpr_Organisationid;
         A29LocationId = obj79.gxTpr_Locationid;
         Z395LocationDynamicFormId = obj79.gxTpr_Locationdynamicformid_Z;
         Z11OrganisationId = obj79.gxTpr_Organisationid_Z;
         Z29LocationId = obj79.gxTpr_Locationid_Z;
         Z206WWPFormId = obj79.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj79.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj79.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj79.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj79.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj79.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj79.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj79.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj79.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj79.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj79.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj79.gxTpr_Wwpformisfordynamicvalidations_Z;
         n395LocationDynamicFormId = (bool)(Convert.ToBoolean(obj79.gxTpr_Locationdynamicformid_N));
         Gx_mode = obj79.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A395LocationDynamicFormId = (Guid)getParm(obj,0);
         n395LocationDynamicFormId = false;
         A11OrganisationId = (Guid)getParm(obj,1);
         A29LocationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1B79( ) ;
         ScanKeyStart1B79( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001B14 */
            pr_default.execute(12, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM1B79( -6) ;
         OnLoadActions1B79( ) ;
         AddRow1B79( ) ;
         ScanKeyEnd1B79( ) ;
         if ( RcdFound79 == 0 )
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
         RowToVars79( bcTrn_LocationDynamicForm, 0) ;
         ScanKeyStart1B79( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001B14 */
            pr_default.execute(12, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM1B79( -6) ;
         OnLoadActions1B79( ) ;
         AddRow1B79( ) ;
         ScanKeyEnd1B79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1B79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1B79( ) ;
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A395LocationDynamicFormId = Z395LocationDynamicFormId;
                  n395LocationDynamicFormId = false;
                  A11OrganisationId = Z11OrganisationId;
                  A29LocationId = Z29LocationId;
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
                  Update1B79( ) ;
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
                  if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
                        Insert1B79( ) ;
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
                        Insert1B79( ) ;
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
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
         SaveImpl( ) ;
         VarsToRow79( bcTrn_LocationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B79( ) ;
         AfterTrn( ) ;
         VarsToRow79( bcTrn_LocationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow79( bcTrn_LocationDynamicForm) ;
         }
         else
         {
            SdtTrn_LocationDynamicForm auxBC = new SdtTrn_LocationDynamicForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A395LocationDynamicFormId, A11OrganisationId, A29LocationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_LocationDynamicForm);
               auxBC.Save();
               bcTrn_LocationDynamicForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
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
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B79( ) ;
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
               VarsToRow79( bcTrn_LocationDynamicForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow79( bcTrn_LocationDynamicForm) ;
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
         RowToVars79( bcTrn_LocationDynamicForm, 0) ;
         GetKey1B79( ) ;
         if ( RcdFound79 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
            {
               A395LocationDynamicFormId = Z395LocationDynamicFormId;
               n395LocationDynamicFormId = false;
               A11OrganisationId = Z11OrganisationId;
               A29LocationId = Z29LocationId;
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
            if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
         context.RollbackDataStores("trn_locationdynamicform_bc",pr_default);
         VarsToRow79( bcTrn_LocationDynamicForm) ;
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
         Gx_mode = bcTrn_LocationDynamicForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_LocationDynamicForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_LocationDynamicForm )
         {
            bcTrn_LocationDynamicForm = (SdtTrn_LocationDynamicForm)(sdt);
            if ( StringUtil.StrCmp(bcTrn_LocationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationDynamicForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow79( bcTrn_LocationDynamicForm) ;
            }
            else
            {
               RowToVars79( bcTrn_LocationDynamicForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_LocationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationDynamicForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars79( bcTrn_LocationDynamicForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_LocationDynamicForm Trn_LocationDynamicForm_BC
      {
         get {
            return bcTrn_LocationDynamicForm ;
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
            return "trn_loacationdynamicform_Execute" ;
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
         pr_default.close(12);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z395LocationDynamicFormId = Guid.Empty;
         A395LocationDynamicFormId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
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
         BC001B6_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001B6_n395LocationDynamicFormId = new bool[] {false} ;
         BC001B6_A208WWPFormReferenceName = new string[] {""} ;
         BC001B6_A209WWPFormTitle = new string[] {""} ;
         BC001B6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001B6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001B6_A216WWPFormResume = new short[1] ;
         BC001B6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001B6_A233WWPFormValidations = new string[] {""} ;
         BC001B6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001B6_A240WWPFormType = new short[1] ;
         BC001B6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001B6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001B6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001B6_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B6_A206WWPFormId = new short[1] ;
         BC001B6_A207WWPFormVersionNumber = new short[1] ;
         BC001B4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B5_A208WWPFormReferenceName = new string[] {""} ;
         BC001B5_A209WWPFormTitle = new string[] {""} ;
         BC001B5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001B5_A232WWPFormIsWizard = new bool[] {false} ;
         BC001B5_A216WWPFormResume = new short[1] ;
         BC001B5_A235WWPFormResumeMessage = new string[] {""} ;
         BC001B5_A233WWPFormValidations = new string[] {""} ;
         BC001B5_A234WWPFormInstantiated = new bool[] {false} ;
         BC001B5_A240WWPFormType = new short[1] ;
         BC001B5_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001B5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001B7_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001B7_n395LocationDynamicFormId = new bool[] {false} ;
         BC001B7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001B7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001B3_n395LocationDynamicFormId = new bool[] {false} ;
         BC001B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001B3_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B3_A206WWPFormId = new short[1] ;
         BC001B3_A207WWPFormVersionNumber = new short[1] ;
         sMode79 = "";
         BC001B2_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001B2_n395LocationDynamicFormId = new bool[] {false} ;
         BC001B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001B2_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B2_A206WWPFormId = new short[1] ;
         BC001B2_A207WWPFormVersionNumber = new short[1] ;
         BC001B11_A208WWPFormReferenceName = new string[] {""} ;
         BC001B11_A209WWPFormTitle = new string[] {""} ;
         BC001B11_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001B11_A232WWPFormIsWizard = new bool[] {false} ;
         BC001B11_A216WWPFormResume = new short[1] ;
         BC001B11_A235WWPFormResumeMessage = new string[] {""} ;
         BC001B11_A233WWPFormValidations = new string[] {""} ;
         BC001B11_A234WWPFormInstantiated = new bool[] {false} ;
         BC001B11_A240WWPFormType = new short[1] ;
         BC001B11_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001B11_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001B12_A367CallToActionId = new Guid[] {Guid.Empty} ;
         BC001B13_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001B13_n395LocationDynamicFormId = new bool[] {false} ;
         BC001B13_A208WWPFormReferenceName = new string[] {""} ;
         BC001B13_A209WWPFormTitle = new string[] {""} ;
         BC001B13_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001B13_A232WWPFormIsWizard = new bool[] {false} ;
         BC001B13_A216WWPFormResume = new short[1] ;
         BC001B13_A235WWPFormResumeMessage = new string[] {""} ;
         BC001B13_A233WWPFormValidations = new string[] {""} ;
         BC001B13_A234WWPFormInstantiated = new bool[] {false} ;
         BC001B13_A240WWPFormType = new short[1] ;
         BC001B13_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001B13_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001B13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001B13_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001B13_A206WWPFormId = new short[1] ;
         BC001B13_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001B14_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__default(),
            new Object[][] {
                new Object[] {
               BC001B2_A395LocationDynamicFormId, BC001B2_A11OrganisationId, BC001B2_A29LocationId, BC001B2_A206WWPFormId, BC001B2_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001B3_A395LocationDynamicFormId, BC001B3_A11OrganisationId, BC001B3_A29LocationId, BC001B3_A206WWPFormId, BC001B3_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001B4_A29LocationId
               }
               , new Object[] {
               BC001B5_A208WWPFormReferenceName, BC001B5_A209WWPFormTitle, BC001B5_A231WWPFormDate, BC001B5_A232WWPFormIsWizard, BC001B5_A216WWPFormResume, BC001B5_A235WWPFormResumeMessage, BC001B5_A233WWPFormValidations, BC001B5_A234WWPFormInstantiated, BC001B5_A240WWPFormType, BC001B5_A241WWPFormSectionRefElements,
               BC001B5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001B6_A395LocationDynamicFormId, BC001B6_A208WWPFormReferenceName, BC001B6_A209WWPFormTitle, BC001B6_A231WWPFormDate, BC001B6_A232WWPFormIsWizard, BC001B6_A216WWPFormResume, BC001B6_A235WWPFormResumeMessage, BC001B6_A233WWPFormValidations, BC001B6_A234WWPFormInstantiated, BC001B6_A240WWPFormType,
               BC001B6_A241WWPFormSectionRefElements, BC001B6_A242WWPFormIsForDynamicValidations, BC001B6_A11OrganisationId, BC001B6_A29LocationId, BC001B6_A206WWPFormId, BC001B6_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001B7_A395LocationDynamicFormId, BC001B7_A11OrganisationId, BC001B7_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B11_A208WWPFormReferenceName, BC001B11_A209WWPFormTitle, BC001B11_A231WWPFormDate, BC001B11_A232WWPFormIsWizard, BC001B11_A216WWPFormResume, BC001B11_A235WWPFormResumeMessage, BC001B11_A233WWPFormValidations, BC001B11_A234WWPFormInstantiated, BC001B11_A240WWPFormType, BC001B11_A241WWPFormSectionRefElements,
               BC001B11_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001B12_A367CallToActionId
               }
               , new Object[] {
               BC001B13_A395LocationDynamicFormId, BC001B13_A208WWPFormReferenceName, BC001B13_A209WWPFormTitle, BC001B13_A231WWPFormDate, BC001B13_A232WWPFormIsWizard, BC001B13_A216WWPFormResume, BC001B13_A235WWPFormResumeMessage, BC001B13_A233WWPFormValidations, BC001B13_A234WWPFormInstantiated, BC001B13_A240WWPFormType,
               BC001B13_A241WWPFormSectionRefElements, BC001B13_A242WWPFormIsForDynamicValidations, BC001B13_A11OrganisationId, BC001B13_A29LocationId, BC001B13_A206WWPFormId, BC001B13_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001B14_A29LocationId
               }
            }
         );
         Z395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
         A395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short Z219WWPFormLatestVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Z240WWPFormType ;
      private short A240WWPFormType ;
      private short Gx_BScreen ;
      private short RcdFound79 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode79 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n395LocationDynamicFormId ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private Guid Z395LocationDynamicFormId ;
      private Guid A395LocationDynamicFormId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001B6_A395LocationDynamicFormId ;
      private bool[] BC001B6_n395LocationDynamicFormId ;
      private string[] BC001B6_A208WWPFormReferenceName ;
      private string[] BC001B6_A209WWPFormTitle ;
      private DateTime[] BC001B6_A231WWPFormDate ;
      private bool[] BC001B6_A232WWPFormIsWizard ;
      private short[] BC001B6_A216WWPFormResume ;
      private string[] BC001B6_A235WWPFormResumeMessage ;
      private string[] BC001B6_A233WWPFormValidations ;
      private bool[] BC001B6_A234WWPFormInstantiated ;
      private short[] BC001B6_A240WWPFormType ;
      private string[] BC001B6_A241WWPFormSectionRefElements ;
      private bool[] BC001B6_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001B6_A11OrganisationId ;
      private Guid[] BC001B6_A29LocationId ;
      private short[] BC001B6_A206WWPFormId ;
      private short[] BC001B6_A207WWPFormVersionNumber ;
      private Guid[] BC001B4_A29LocationId ;
      private string[] BC001B5_A208WWPFormReferenceName ;
      private string[] BC001B5_A209WWPFormTitle ;
      private DateTime[] BC001B5_A231WWPFormDate ;
      private bool[] BC001B5_A232WWPFormIsWizard ;
      private short[] BC001B5_A216WWPFormResume ;
      private string[] BC001B5_A235WWPFormResumeMessage ;
      private string[] BC001B5_A233WWPFormValidations ;
      private bool[] BC001B5_A234WWPFormInstantiated ;
      private short[] BC001B5_A240WWPFormType ;
      private string[] BC001B5_A241WWPFormSectionRefElements ;
      private bool[] BC001B5_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001B7_A395LocationDynamicFormId ;
      private bool[] BC001B7_n395LocationDynamicFormId ;
      private Guid[] BC001B7_A11OrganisationId ;
      private Guid[] BC001B7_A29LocationId ;
      private Guid[] BC001B3_A395LocationDynamicFormId ;
      private bool[] BC001B3_n395LocationDynamicFormId ;
      private Guid[] BC001B3_A11OrganisationId ;
      private Guid[] BC001B3_A29LocationId ;
      private short[] BC001B3_A206WWPFormId ;
      private short[] BC001B3_A207WWPFormVersionNumber ;
      private Guid[] BC001B2_A395LocationDynamicFormId ;
      private bool[] BC001B2_n395LocationDynamicFormId ;
      private Guid[] BC001B2_A11OrganisationId ;
      private Guid[] BC001B2_A29LocationId ;
      private short[] BC001B2_A206WWPFormId ;
      private short[] BC001B2_A207WWPFormVersionNumber ;
      private string[] BC001B11_A208WWPFormReferenceName ;
      private string[] BC001B11_A209WWPFormTitle ;
      private DateTime[] BC001B11_A231WWPFormDate ;
      private bool[] BC001B11_A232WWPFormIsWizard ;
      private short[] BC001B11_A216WWPFormResume ;
      private string[] BC001B11_A235WWPFormResumeMessage ;
      private string[] BC001B11_A233WWPFormValidations ;
      private bool[] BC001B11_A234WWPFormInstantiated ;
      private short[] BC001B11_A240WWPFormType ;
      private string[] BC001B11_A241WWPFormSectionRefElements ;
      private bool[] BC001B11_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001B12_A367CallToActionId ;
      private Guid[] BC001B13_A395LocationDynamicFormId ;
      private bool[] BC001B13_n395LocationDynamicFormId ;
      private string[] BC001B13_A208WWPFormReferenceName ;
      private string[] BC001B13_A209WWPFormTitle ;
      private DateTime[] BC001B13_A231WWPFormDate ;
      private bool[] BC001B13_A232WWPFormIsWizard ;
      private short[] BC001B13_A216WWPFormResume ;
      private string[] BC001B13_A235WWPFormResumeMessage ;
      private string[] BC001B13_A233WWPFormValidations ;
      private bool[] BC001B13_A234WWPFormInstantiated ;
      private short[] BC001B13_A240WWPFormType ;
      private string[] BC001B13_A241WWPFormSectionRefElements ;
      private bool[] BC001B13_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001B13_A11OrganisationId ;
      private Guid[] BC001B13_A29LocationId ;
      private short[] BC001B13_A206WWPFormId ;
      private short[] BC001B13_A207WWPFormVersionNumber ;
      private SdtTrn_LocationDynamicForm bcTrn_LocationDynamicForm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001B14_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_locationdynamicform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_locationdynamicform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_locationdynamicform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
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
       Object[] prmBC001B2;
       prmBC001B2 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B3;
       prmBC001B3 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B4;
       prmBC001B4 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B5;
       prmBC001B5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001B6;
       prmBC001B6 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B7;
       prmBC001B7 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B8;
       prmBC001B8 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001B9;
       prmBC001B9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B10;
       prmBC001B10 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B11;
       prmBC001B11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001B12;
       prmBC001B12 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B13;
       prmBC001B13 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001B14;
       prmBC001B14 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001B2", "SELECT LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_LocationDynamicForm",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B3", "SELECT LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B6", "SELECT TM1.LocationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_LocationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.LocationDynamicFormId = :LocationDynamicFormId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationDynamicFormId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B7", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B8", "SAVEPOINT gxupdate;INSERT INTO Trn_LocationDynamicForm(LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber) VALUES(:LocationDynamicFormId, :OrganisationId, :LocationId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001B8)
          ,new CursorDef("BC001B9", "SAVEPOINT gxupdate;UPDATE Trn_LocationDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001B9)
          ,new CursorDef("BC001B10", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationDynamicForm  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001B10)
          ,new CursorDef("BC001B11", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B12", "SELECT CallToActionId FROM Trn_CallToAction WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001B13", "SELECT TM1.LocationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_LocationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.LocationDynamicFormId = :LocationDynamicFormId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationDynamicFormId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B13,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001B14", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B14,1, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
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
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             ((short[]) buf[15])[0] = rslt.getShort(16);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
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
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             ((short[]) buf[15])[0] = rslt.getShort(16);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
