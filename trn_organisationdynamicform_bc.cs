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
   public class trn_organisationdynamicform_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisationdynamicform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationdynamicform_bc( IGxContext context )
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
         ReadRow1O104( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1O104( ) ;
         standaloneModal( ) ;
         AddRow1O104( ) ;
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
               Z542OrganisationDynamicFormId = A542OrganisationDynamicFormId;
               Z11OrganisationId = A11OrganisationId;
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

      protected void CONFIRM_1O0( )
      {
         BeforeValidate1O104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1O104( ) ;
            }
            else
            {
               CheckExtendedTable1O104( ) ;
               if ( AnyError == 0 )
               {
                  ZM1O104( 6) ;
                  ZM1O104( 7) ;
               }
               CloseExtendedTableCursors1O104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1O104( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -5 )
         {
            Z542OrganisationDynamicFormId = A542OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
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
         if ( IsIns( )  && (Guid.Empty==A542OrganisationDynamicFormId) )
         {
            A542OrganisationDynamicFormId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1O104( )
      {
         /* Using cursor BC001O6 */
         pr_default.execute(4, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound104 = 1;
            A208WWPFormReferenceName = BC001O6_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001O6_A209WWPFormTitle[0];
            A231WWPFormDate = BC001O6_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001O6_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001O6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001O6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001O6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001O6_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001O6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001O6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001O6_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = BC001O6_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001O6_A207WWPFormVersionNumber[0];
            ZM1O104( -5) ;
         }
         pr_default.close(4);
         OnLoadActions1O104( ) ;
      }

      protected void OnLoadActions1O104( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable1O104( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001O4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001O5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC001O5_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC001O5_A209WWPFormTitle[0];
         A231WWPFormDate = BC001O5_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC001O5_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC001O5_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC001O5_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC001O5_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC001O5_A234WWPFormInstantiated[0];
         A240WWPFormType = BC001O5_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC001O5_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC001O5_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CloseExtendedTableCursors1O104( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1O104( )
      {
         /* Using cursor BC001O7 */
         pr_default.execute(5, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001O3 */
         pr_default.execute(1, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1O104( 5) ;
            RcdFound104 = 1;
            A542OrganisationDynamicFormId = BC001O3_A542OrganisationDynamicFormId[0];
            A11OrganisationId = BC001O3_A11OrganisationId[0];
            A206WWPFormId = BC001O3_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001O3_A207WWPFormVersionNumber[0];
            Z542OrganisationDynamicFormId = A542OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1O104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey1O104( ) ;
            }
            Gx_mode = sMode104;
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey1O104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode104;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1O104( ) ;
         if ( RcdFound104 == 0 )
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
         CONFIRM_1O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1O104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001O2 */
            pr_default.execute(0, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != BC001O2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC001O2_A207WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O104( )
      {
         BeforeValidate1O104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O104( 0) ;
            CheckOptimisticConcurrency1O104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001O8 */
                     pr_default.execute(6, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
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
               Load1O104( ) ;
            }
            EndLevel1O104( ) ;
         }
         CloseExtendedTableCursors1O104( ) ;
      }

      protected void Update1O104( )
      {
         BeforeValidate1O104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1O104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001O9 */
                     pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A542OrganisationDynamicFormId, A11OrganisationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1O104( ) ;
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
            EndLevel1O104( ) ;
         }
         CloseExtendedTableCursors1O104( ) ;
      }

      protected void DeferredUpdate1O104( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1O104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O104( ) ;
            AfterConfirm1O104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001O10 */
                  pr_default.execute(8, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1O104( ) ;
         Gx_mode = sMode104;
      }

      protected void OnDeleteControls1O104( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001O11 */
            pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001O11_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001O11_A209WWPFormTitle[0];
            A231WWPFormDate = BC001O11_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001O11_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001O11_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001O11_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001O11_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001O11_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001O11_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001O11_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001O11_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel1O104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1O104( ) ;
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

      public void ScanKeyStart1O104( )
      {
         /* Using cursor BC001O12 */
         pr_default.execute(10, new Object[] {A542OrganisationDynamicFormId, A11OrganisationId});
         RcdFound104 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound104 = 1;
            A542OrganisationDynamicFormId = BC001O12_A542OrganisationDynamicFormId[0];
            A208WWPFormReferenceName = BC001O12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001O12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001O12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001O12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001O12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001O12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001O12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001O12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001O12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001O12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001O12_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001O12_A11OrganisationId[0];
            A206WWPFormId = BC001O12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001O12_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1O104( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound104 = 0;
         ScanKeyLoad1O104( ) ;
      }

      protected void ScanKeyLoad1O104( )
      {
         sMode104 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound104 = 1;
            A542OrganisationDynamicFormId = BC001O12_A542OrganisationDynamicFormId[0];
            A208WWPFormReferenceName = BC001O12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001O12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001O12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001O12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001O12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001O12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001O12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001O12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001O12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001O12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001O12_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001O12_A11OrganisationId[0];
            A206WWPFormId = BC001O12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001O12_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode104;
      }

      protected void ScanKeyEnd1O104( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1O104( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O104( )
      {
      }

      protected void send_integrity_lvl_hashes1O104( )
      {
      }

      protected void AddRow1O104( )
      {
         VarsToRow104( bcTrn_OrganisationDynamicForm) ;
      }

      protected void ReadRow1O104( )
      {
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
      }

      protected void InitializeNonKey1O104( )
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

      protected void InitAll1O104( )
      {
         A542OrganisationDynamicFormId = Guid.NewGuid( );
         A11OrganisationId = Guid.Empty;
         InitializeNonKey1O104( ) ;
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

      public void VarsToRow104( SdtTrn_OrganisationDynamicForm obj104 )
      {
         obj104.gxTpr_Mode = Gx_mode;
         obj104.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj104.gxTpr_Wwpformid = A206WWPFormId;
         obj104.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj104.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj104.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj104.gxTpr_Wwpformdate = A231WWPFormDate;
         obj104.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj104.gxTpr_Wwpformresume = A216WWPFormResume;
         obj104.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj104.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj104.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj104.gxTpr_Wwpformtype = A240WWPFormType;
         obj104.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj104.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj104.gxTpr_Organisationdynamicformid = A542OrganisationDynamicFormId;
         obj104.gxTpr_Organisationid = A11OrganisationId;
         obj104.gxTpr_Organisationdynamicformid_Z = Z542OrganisationDynamicFormId;
         obj104.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj104.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj104.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj104.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj104.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj104.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj104.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj104.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj104.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj104.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj104.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj104.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj104.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj104.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow104( SdtTrn_OrganisationDynamicForm obj104 )
      {
         obj104.gxTpr_Organisationdynamicformid = A542OrganisationDynamicFormId;
         obj104.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars104( SdtTrn_OrganisationDynamicForm obj104 ,
                                int forceLoad )
      {
         Gx_mode = obj104.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj104.gxTpr_Wwpformlatestversionnumber;
         A206WWPFormId = obj104.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj104.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj104.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj104.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj104.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj104.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj104.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj104.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj104.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj104.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj104.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj104.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj104.gxTpr_Wwpformisfordynamicvalidations;
         A542OrganisationDynamicFormId = obj104.gxTpr_Organisationdynamicformid;
         A11OrganisationId = obj104.gxTpr_Organisationid;
         Z542OrganisationDynamicFormId = obj104.gxTpr_Organisationdynamicformid_Z;
         Z11OrganisationId = obj104.gxTpr_Organisationid_Z;
         Z206WWPFormId = obj104.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj104.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj104.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj104.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj104.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj104.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj104.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj104.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj104.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj104.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj104.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj104.gxTpr_Wwpformisfordynamicvalidations_Z;
         Gx_mode = obj104.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A542OrganisationDynamicFormId = (Guid)getParm(obj,0);
         A11OrganisationId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1O104( ) ;
         ScanKeyStart1O104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001O13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z542OrganisationDynamicFormId = A542OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM1O104( -5) ;
         OnLoadActions1O104( ) ;
         AddRow1O104( ) ;
         ScanKeyEnd1O104( ) ;
         if ( RcdFound104 == 0 )
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
         RowToVars104( bcTrn_OrganisationDynamicForm, 0) ;
         ScanKeyStart1O104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001O13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z542OrganisationDynamicFormId = A542OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM1O104( -5) ;
         OnLoadActions1O104( ) ;
         AddRow1O104( ) ;
         ScanKeyEnd1O104( ) ;
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1O104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1O104( ) ;
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( ( A542OrganisationDynamicFormId != Z542OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A542OrganisationDynamicFormId = Z542OrganisationDynamicFormId;
                  A11OrganisationId = Z11OrganisationId;
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
                  Update1O104( ) ;
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
                  if ( ( A542OrganisationDynamicFormId != Z542OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert1O104( ) ;
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
                        Insert1O104( ) ;
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
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
         SaveImpl( ) ;
         VarsToRow104( bcTrn_OrganisationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1O104( ) ;
         AfterTrn( ) ;
         VarsToRow104( bcTrn_OrganisationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow104( bcTrn_OrganisationDynamicForm) ;
         }
         else
         {
            SdtTrn_OrganisationDynamicForm auxBC = new SdtTrn_OrganisationDynamicForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A542OrganisationDynamicFormId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_OrganisationDynamicForm);
               auxBC.Save();
               bcTrn_OrganisationDynamicForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
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
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1O104( ) ;
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
               VarsToRow104( bcTrn_OrganisationDynamicForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow104( bcTrn_OrganisationDynamicForm) ;
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
         RowToVars104( bcTrn_OrganisationDynamicForm, 0) ;
         GetKey1O104( ) ;
         if ( RcdFound104 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A542OrganisationDynamicFormId != Z542OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A542OrganisationDynamicFormId = Z542OrganisationDynamicFormId;
               A11OrganisationId = Z11OrganisationId;
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
            if ( ( A542OrganisationDynamicFormId != Z542OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_organisationdynamicform_bc",pr_default);
         VarsToRow104( bcTrn_OrganisationDynamicForm) ;
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
         Gx_mode = bcTrn_OrganisationDynamicForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_OrganisationDynamicForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_OrganisationDynamicForm )
         {
            bcTrn_OrganisationDynamicForm = (SdtTrn_OrganisationDynamicForm)(sdt);
            if ( StringUtil.StrCmp(bcTrn_OrganisationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationDynamicForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow104( bcTrn_OrganisationDynamicForm) ;
            }
            else
            {
               RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_OrganisationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationDynamicForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars104( bcTrn_OrganisationDynamicForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_OrganisationDynamicForm Trn_OrganisationDynamicForm_BC
      {
         get {
            return bcTrn_OrganisationDynamicForm ;
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
            return "trn_organisationdynamicform_Execute" ;
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
         pr_default.close(11);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z542OrganisationDynamicFormId = Guid.Empty;
         A542OrganisationDynamicFormId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
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
         BC001O6_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001O6_A208WWPFormReferenceName = new string[] {""} ;
         BC001O6_A209WWPFormTitle = new string[] {""} ;
         BC001O6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001O6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001O6_A216WWPFormResume = new short[1] ;
         BC001O6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001O6_A233WWPFormValidations = new string[] {""} ;
         BC001O6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001O6_A240WWPFormType = new short[1] ;
         BC001O6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001O6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001O6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O6_A206WWPFormId = new short[1] ;
         BC001O6_A207WWPFormVersionNumber = new short[1] ;
         BC001O4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O5_A208WWPFormReferenceName = new string[] {""} ;
         BC001O5_A209WWPFormTitle = new string[] {""} ;
         BC001O5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001O5_A232WWPFormIsWizard = new bool[] {false} ;
         BC001O5_A216WWPFormResume = new short[1] ;
         BC001O5_A235WWPFormResumeMessage = new string[] {""} ;
         BC001O5_A233WWPFormValidations = new string[] {""} ;
         BC001O5_A234WWPFormInstantiated = new bool[] {false} ;
         BC001O5_A240WWPFormType = new short[1] ;
         BC001O5_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001O5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001O7_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001O7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O3_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001O3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O3_A206WWPFormId = new short[1] ;
         BC001O3_A207WWPFormVersionNumber = new short[1] ;
         sMode104 = "";
         BC001O2_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001O2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O2_A206WWPFormId = new short[1] ;
         BC001O2_A207WWPFormVersionNumber = new short[1] ;
         BC001O11_A208WWPFormReferenceName = new string[] {""} ;
         BC001O11_A209WWPFormTitle = new string[] {""} ;
         BC001O11_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001O11_A232WWPFormIsWizard = new bool[] {false} ;
         BC001O11_A216WWPFormResume = new short[1] ;
         BC001O11_A235WWPFormResumeMessage = new string[] {""} ;
         BC001O11_A233WWPFormValidations = new string[] {""} ;
         BC001O11_A234WWPFormInstantiated = new bool[] {false} ;
         BC001O11_A240WWPFormType = new short[1] ;
         BC001O11_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001O11_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001O12_A542OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001O12_A208WWPFormReferenceName = new string[] {""} ;
         BC001O12_A209WWPFormTitle = new string[] {""} ;
         BC001O12_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001O12_A232WWPFormIsWizard = new bool[] {false} ;
         BC001O12_A216WWPFormResume = new short[1] ;
         BC001O12_A235WWPFormResumeMessage = new string[] {""} ;
         BC001O12_A233WWPFormValidations = new string[] {""} ;
         BC001O12_A234WWPFormInstantiated = new bool[] {false} ;
         BC001O12_A240WWPFormType = new short[1] ;
         BC001O12_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001O12_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001O12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001O12_A206WWPFormId = new short[1] ;
         BC001O12_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001O13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__default(),
            new Object[][] {
                new Object[] {
               BC001O2_A542OrganisationDynamicFormId, BC001O2_A11OrganisationId, BC001O2_A206WWPFormId, BC001O2_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001O3_A542OrganisationDynamicFormId, BC001O3_A11OrganisationId, BC001O3_A206WWPFormId, BC001O3_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001O4_A11OrganisationId
               }
               , new Object[] {
               BC001O5_A208WWPFormReferenceName, BC001O5_A209WWPFormTitle, BC001O5_A231WWPFormDate, BC001O5_A232WWPFormIsWizard, BC001O5_A216WWPFormResume, BC001O5_A235WWPFormResumeMessage, BC001O5_A233WWPFormValidations, BC001O5_A234WWPFormInstantiated, BC001O5_A240WWPFormType, BC001O5_A241WWPFormSectionRefElements,
               BC001O5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001O6_A542OrganisationDynamicFormId, BC001O6_A208WWPFormReferenceName, BC001O6_A209WWPFormTitle, BC001O6_A231WWPFormDate, BC001O6_A232WWPFormIsWizard, BC001O6_A216WWPFormResume, BC001O6_A235WWPFormResumeMessage, BC001O6_A233WWPFormValidations, BC001O6_A234WWPFormInstantiated, BC001O6_A240WWPFormType,
               BC001O6_A241WWPFormSectionRefElements, BC001O6_A242WWPFormIsForDynamicValidations, BC001O6_A11OrganisationId, BC001O6_A206WWPFormId, BC001O6_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001O7_A542OrganisationDynamicFormId, BC001O7_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001O11_A208WWPFormReferenceName, BC001O11_A209WWPFormTitle, BC001O11_A231WWPFormDate, BC001O11_A232WWPFormIsWizard, BC001O11_A216WWPFormResume, BC001O11_A235WWPFormResumeMessage, BC001O11_A233WWPFormValidations, BC001O11_A234WWPFormInstantiated, BC001O11_A240WWPFormType, BC001O11_A241WWPFormSectionRefElements,
               BC001O11_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001O12_A542OrganisationDynamicFormId, BC001O12_A208WWPFormReferenceName, BC001O12_A209WWPFormTitle, BC001O12_A231WWPFormDate, BC001O12_A232WWPFormIsWizard, BC001O12_A216WWPFormResume, BC001O12_A235WWPFormResumeMessage, BC001O12_A233WWPFormValidations, BC001O12_A234WWPFormInstantiated, BC001O12_A240WWPFormType,
               BC001O12_A241WWPFormSectionRefElements, BC001O12_A242WWPFormIsForDynamicValidations, BC001O12_A11OrganisationId, BC001O12_A206WWPFormId, BC001O12_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001O13_A11OrganisationId
               }
            }
         );
         Z542OrganisationDynamicFormId = Guid.NewGuid( );
         A542OrganisationDynamicFormId = Guid.NewGuid( );
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
      private short RcdFound104 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode104 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
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
      private Guid Z542OrganisationDynamicFormId ;
      private Guid A542OrganisationDynamicFormId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001O6_A542OrganisationDynamicFormId ;
      private string[] BC001O6_A208WWPFormReferenceName ;
      private string[] BC001O6_A209WWPFormTitle ;
      private DateTime[] BC001O6_A231WWPFormDate ;
      private bool[] BC001O6_A232WWPFormIsWizard ;
      private short[] BC001O6_A216WWPFormResume ;
      private string[] BC001O6_A235WWPFormResumeMessage ;
      private string[] BC001O6_A233WWPFormValidations ;
      private bool[] BC001O6_A234WWPFormInstantiated ;
      private short[] BC001O6_A240WWPFormType ;
      private string[] BC001O6_A241WWPFormSectionRefElements ;
      private bool[] BC001O6_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001O6_A11OrganisationId ;
      private short[] BC001O6_A206WWPFormId ;
      private short[] BC001O6_A207WWPFormVersionNumber ;
      private Guid[] BC001O4_A11OrganisationId ;
      private string[] BC001O5_A208WWPFormReferenceName ;
      private string[] BC001O5_A209WWPFormTitle ;
      private DateTime[] BC001O5_A231WWPFormDate ;
      private bool[] BC001O5_A232WWPFormIsWizard ;
      private short[] BC001O5_A216WWPFormResume ;
      private string[] BC001O5_A235WWPFormResumeMessage ;
      private string[] BC001O5_A233WWPFormValidations ;
      private bool[] BC001O5_A234WWPFormInstantiated ;
      private short[] BC001O5_A240WWPFormType ;
      private string[] BC001O5_A241WWPFormSectionRefElements ;
      private bool[] BC001O5_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001O7_A542OrganisationDynamicFormId ;
      private Guid[] BC001O7_A11OrganisationId ;
      private Guid[] BC001O3_A542OrganisationDynamicFormId ;
      private Guid[] BC001O3_A11OrganisationId ;
      private short[] BC001O3_A206WWPFormId ;
      private short[] BC001O3_A207WWPFormVersionNumber ;
      private Guid[] BC001O2_A542OrganisationDynamicFormId ;
      private Guid[] BC001O2_A11OrganisationId ;
      private short[] BC001O2_A206WWPFormId ;
      private short[] BC001O2_A207WWPFormVersionNumber ;
      private string[] BC001O11_A208WWPFormReferenceName ;
      private string[] BC001O11_A209WWPFormTitle ;
      private DateTime[] BC001O11_A231WWPFormDate ;
      private bool[] BC001O11_A232WWPFormIsWizard ;
      private short[] BC001O11_A216WWPFormResume ;
      private string[] BC001O11_A235WWPFormResumeMessage ;
      private string[] BC001O11_A233WWPFormValidations ;
      private bool[] BC001O11_A234WWPFormInstantiated ;
      private short[] BC001O11_A240WWPFormType ;
      private string[] BC001O11_A241WWPFormSectionRefElements ;
      private bool[] BC001O11_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001O12_A542OrganisationDynamicFormId ;
      private string[] BC001O12_A208WWPFormReferenceName ;
      private string[] BC001O12_A209WWPFormTitle ;
      private DateTime[] BC001O12_A231WWPFormDate ;
      private bool[] BC001O12_A232WWPFormIsWizard ;
      private short[] BC001O12_A216WWPFormResume ;
      private string[] BC001O12_A235WWPFormResumeMessage ;
      private string[] BC001O12_A233WWPFormValidations ;
      private bool[] BC001O12_A234WWPFormInstantiated ;
      private short[] BC001O12_A240WWPFormType ;
      private string[] BC001O12_A241WWPFormSectionRefElements ;
      private bool[] BC001O12_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001O12_A11OrganisationId ;
      private short[] BC001O12_A206WWPFormId ;
      private short[] BC001O12_A207WWPFormVersionNumber ;
      private SdtTrn_OrganisationDynamicForm bcTrn_OrganisationDynamicForm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001O13_A11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisationdynamicform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisationdynamicform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisationdynamicform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001O2;
       prmBC001O2 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O3;
       prmBC001O3 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O4;
       prmBC001O4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O5;
       prmBC001O5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001O6;
       prmBC001O6 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O7;
       prmBC001O7 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O8;
       prmBC001O8 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001O9;
       prmBC001O9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O10;
       prmBC001O10 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O11;
       prmBC001O11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001O12;
       prmBC001O12 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001O13;
       prmBC001O13 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001O2", "SELECT OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_OrganisationDynamicForm",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O3", "SELECT OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O6", "SELECT TM1.OrganisationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_OrganisationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.OrganisationDynamicFormId = :OrganisationDynamicFormId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationDynamicFormId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O7", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O8", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationDynamicForm(OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber) VALUES(:OrganisationDynamicFormId, :OrganisationId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O8)
          ,new CursorDef("BC001O9", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O9)
          ,new CursorDef("BC001O10", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationDynamicForm  WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O10)
          ,new CursorDef("BC001O11", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O12", "SELECT TM1.OrganisationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_OrganisationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.OrganisationDynamicFormId = :OrganisationDynamicFormId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationDynamicFormId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O12,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001O13", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O13,1, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
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
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
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
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
