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
   public class trn_appversion_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_appversion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversion_bc( IGxContext context )
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
         ReadRow1Q109( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Q109( ) ;
         standaloneModal( ) ;
         AddRow1Q109( ) ;
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
               Z543AppVersionId = A543AppVersionId;
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

      protected void CONFIRM_1Q0( )
      {
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Q109( ) ;
            }
            else
            {
               CheckExtendedTable1Q109( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Q109( 11) ;
                  ZM1Q109( 12) ;
               }
               CloseExtendedTableCursors1Q109( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode109 = Gx_mode;
            CONFIRM_1Q110( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode109;
            }
            /* Restore parent mode. */
            Gx_mode = sMode109;
         }
      }

      protected void CONFIRM_1Q110( )
      {
         nGXsfl_110_idx = 0;
         while ( nGXsfl_110_idx < bcTrn_AppVersion.gxTpr_Page.Count )
         {
            ReadRow1Q110( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound110 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_110 != 0 ) )
            {
               GetKey1Q110( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound110 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1Q110( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound110 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1Q110( ) ;
                        Load1Q110( ) ;
                        BeforeValidate1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1Q110( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_110 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1Q110( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1Q110( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1Q110( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow110( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_110_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM1Q109( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z544AppVersionName = A544AppVersionName;
            Z561IsActive = A561IsActive;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z543AppVersionId = A543AppVersionId;
            Z544AppVersionName = A544AppVersionName;
            Z561IsActive = A561IsActive;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A543AppVersionId) )
         {
            A543AppVersionId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1Q109( )
      {
         /* Using cursor BC001Q8 */
         pr_default.execute(6, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound109 = 1;
            A544AppVersionName = BC001Q8_A544AppVersionName[0];
            A561IsActive = BC001Q8_A561IsActive[0];
            A29LocationId = BC001Q8_A29LocationId[0];
            n29LocationId = BC001Q8_n29LocationId[0];
            A11OrganisationId = BC001Q8_A11OrganisationId[0];
            n11OrganisationId = BC001Q8_n11OrganisationId[0];
            ZM1Q109( -9) ;
         }
         pr_default.close(6);
         OnLoadActions1Q109( ) ;
      }

      protected void OnLoadActions1Q109( )
      {
      }

      protected void CheckExtendedTable1Q109( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001Q9 */
         pr_default.execute(7, new Object[] {A544AppVersionName, n29LocationId, A29LocationId, A543AppVersionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "App Version Name", "")+","+context.GetMessage( "Location Id", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         /* Using cursor BC001Q7 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(5);
         /* Using cursor BC001Q6 */
         pr_default.execute(4, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1Q109( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Q109( )
      {
         /* Using cursor BC001Q10 */
         pr_default.execute(8, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Q5 */
         pr_default.execute(3, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1Q109( 9) ;
            RcdFound109 = 1;
            A543AppVersionId = BC001Q5_A543AppVersionId[0];
            A544AppVersionName = BC001Q5_A544AppVersionName[0];
            A561IsActive = BC001Q5_A561IsActive[0];
            A29LocationId = BC001Q5_A29LocationId[0];
            n29LocationId = BC001Q5_n29LocationId[0];
            A11OrganisationId = BC001Q5_A11OrganisationId[0];
            n11OrganisationId = BC001Q5_n11OrganisationId[0];
            Z543AppVersionId = A543AppVersionId;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Q109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey1Q109( ) ;
            }
            Gx_mode = sMode109;
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey1Q109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode109;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q109( ) ;
         if ( RcdFound109 == 0 )
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
         CONFIRM_1Q0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Q109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Q4 */
            pr_default.execute(2, new Object[] {A543AppVersionId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z544AppVersionName, BC001Q4_A544AppVersionName[0]) != 0 ) || ( Z561IsActive != BC001Q4_A561IsActive[0] ) || ( Z29LocationId != BC001Q4_A29LocationId[0] ) || ( Z11OrganisationId != BC001Q4_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q109( )
      {
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q109( 0) ;
            CheckOptimisticConcurrency1Q109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q11 */
                     pr_default.execute(9, new Object[] {A543AppVersionId, A544AppVersionName, A561IsActive, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel1Q109( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load1Q109( ) ;
            }
            EndLevel1Q109( ) ;
         }
         CloseExtendedTableCursors1Q109( ) ;
      }

      protected void Update1Q109( )
      {
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q12 */
                     pr_default.execute(10, new Object[] {A544AppVersionName, A561IsActive, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId, A543AppVersionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q109( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1Q109( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel1Q109( ) ;
         }
         CloseExtendedTableCursors1Q109( ) ;
      }

      protected void DeferredUpdate1Q109( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q109( ) ;
            AfterConfirm1Q109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q109( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1Q110( ) ;
                  while ( RcdFound110 != 0 )
                  {
                     getByPrimaryKey1Q110( ) ;
                     Delete1Q110( ) ;
                     ScanKeyNext1Q110( ) ;
                  }
                  ScanKeyEnd1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q13 */
                     pr_default.execute(11, new Object[] {A543AppVersionId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
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
         }
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Q109( ) ;
         Gx_mode = sMode109;
      }

      protected void OnDeleteControls1Q109( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel1Q110( )
      {
         nGXsfl_110_idx = 0;
         while ( nGXsfl_110_idx < bcTrn_AppVersion.gxTpr_Page.Count )
         {
            ReadRow1Q110( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound110 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_110 != 0 ) )
            {
               standaloneNotModal1Q110( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1Q110( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1Q110( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1Q110( ) ;
                  }
               }
            }
            KeyVarsToRow110( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_110_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_110_idx = 0;
            while ( nGXsfl_110_idx < bcTrn_AppVersion.gxTpr_Page.Count )
            {
               ReadRow1Q110( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound110 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_AppVersion.gxTpr_Page.RemoveElement(nGXsfl_110_idx);
                  nGXsfl_110_idx = (int)(nGXsfl_110_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1Q110( ) ;
                  VarsToRow110( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_110_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1Q110( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_110 = 0;
         nIsMod_110 = 0;
      }

      protected void ProcessLevel1Q109( )
      {
         /* Save parent mode. */
         sMode109 = Gx_mode;
         ProcessNestedLevel1Q110( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode109;
         /* ' Update level parameters */
      }

      protected void EndLevel1Q109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Q109( ) ;
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

      public void ScanKeyStart1Q109( )
      {
         /* Using cursor BC001Q14 */
         pr_default.execute(12, new Object[] {A543AppVersionId});
         RcdFound109 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound109 = 1;
            A543AppVersionId = BC001Q14_A543AppVersionId[0];
            A544AppVersionName = BC001Q14_A544AppVersionName[0];
            A561IsActive = BC001Q14_A561IsActive[0];
            A29LocationId = BC001Q14_A29LocationId[0];
            n29LocationId = BC001Q14_n29LocationId[0];
            A11OrganisationId = BC001Q14_A11OrganisationId[0];
            n11OrganisationId = BC001Q14_n11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Q109( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound109 = 0;
         ScanKeyLoad1Q109( ) ;
      }

      protected void ScanKeyLoad1Q109( )
      {
         sMode109 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound109 = 1;
            A543AppVersionId = BC001Q14_A543AppVersionId[0];
            A544AppVersionName = BC001Q14_A544AppVersionName[0];
            A561IsActive = BC001Q14_A561IsActive[0];
            A29LocationId = BC001Q14_A29LocationId[0];
            n29LocationId = BC001Q14_n29LocationId[0];
            A11OrganisationId = BC001Q14_A11OrganisationId[0];
            n11OrganisationId = BC001Q14_n11OrganisationId[0];
         }
         Gx_mode = sMode109;
      }

      protected void ScanKeyEnd1Q109( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1Q109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q109( )
      {
      }

      protected void ZM1Q110( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z567IsPredefined = A567IsPredefined;
            Z522PageName = A522PageName;
            Z545PageType = A545PageType;
         }
         if ( GX_JID == -13 )
         {
            Z543AppVersionId = A543AppVersionId;
            Z521PageId = A521PageId;
            Z567IsPredefined = A567IsPredefined;
            Z522PageName = A522PageName;
            Z523PageStructure = A523PageStructure;
            Z562PagePublishedStructure = A562PagePublishedStructure;
            Z545PageType = A545PageType;
         }
      }

      protected void standaloneNotModal1Q110( )
      {
      }

      protected void standaloneModal1Q110( )
      {
         if ( IsIns( )  && (Guid.Empty==A521PageId) )
         {
            A521PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A567IsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A567IsPredefined = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1Q110( )
      {
         /* Using cursor BC001Q15 */
         pr_default.execute(13, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound110 = 1;
            A567IsPredefined = BC001Q15_A567IsPredefined[0];
            A522PageName = BC001Q15_A522PageName[0];
            A523PageStructure = BC001Q15_A523PageStructure[0];
            A562PagePublishedStructure = BC001Q15_A562PagePublishedStructure[0];
            A545PageType = BC001Q15_A545PageType[0];
            ZM1Q110( -13) ;
         }
         pr_default.close(13);
         OnLoadActions1Q110( ) ;
      }

      protected void OnLoadActions1Q110( )
      {
      }

      protected void CheckExtendedTable1Q110( )
      {
         Gx_BScreen = 1;
         standaloneModal1Q110( ) ;
         Gx_BScreen = 0;
         if ( ! ( ( StringUtil.StrCmp(A545PageType, "Menu") == 0 ) || ( StringUtil.StrCmp(A545PageType, "Content") == 0 ) || ( StringUtil.StrCmp(A545PageType, "WebLink") == 0 ) || ( StringUtil.StrCmp(A545PageType, "DynamicForm") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Page Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1Q110( )
      {
      }

      protected void enableDisable1Q110( )
      {
      }

      protected void GetKey1Q110( )
      {
         /* Using cursor BC001Q16 */
         pr_default.execute(14, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound110 = 1;
         }
         else
         {
            RcdFound110 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey1Q110( )
      {
         /* Using cursor BC001Q3 */
         pr_default.execute(1, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q110( 13) ;
            RcdFound110 = 1;
            InitializeNonKey1Q110( ) ;
            A521PageId = BC001Q3_A521PageId[0];
            A567IsPredefined = BC001Q3_A567IsPredefined[0];
            A522PageName = BC001Q3_A522PageName[0];
            A523PageStructure = BC001Q3_A523PageStructure[0];
            A562PagePublishedStructure = BC001Q3_A562PagePublishedStructure[0];
            A545PageType = BC001Q3_A545PageType[0];
            Z543AppVersionId = A543AppVersionId;
            Z521PageId = A521PageId;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1Q110( ) ;
            Load1Q110( ) ;
            Gx_mode = sMode110;
         }
         else
         {
            RcdFound110 = 0;
            InitializeNonKey1Q110( ) ;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1Q110( ) ;
            Gx_mode = sMode110;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1Q110( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1Q110( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Q2 */
            pr_default.execute(0, new Object[] {A543AppVersionId, A521PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z567IsPredefined != BC001Q2_A567IsPredefined[0] ) || ( StringUtil.StrCmp(Z522PageName, BC001Q2_A522PageName[0]) != 0 ) || ( StringUtil.StrCmp(Z545PageType, BC001Q2_A545PageType[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersionPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q110( )
      {
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q110( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q110( 0) ;
            CheckOptimisticConcurrency1Q110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q17 */
                     pr_default.execute(15, new Object[] {A543AppVersionId, A521PageId, A567IsPredefined, A522PageName, A523PageStructure, A562PagePublishedStructure, A545PageType});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load1Q110( ) ;
            }
            EndLevel1Q110( ) ;
         }
         CloseExtendedTableCursors1Q110( ) ;
      }

      protected void Update1Q110( )
      {
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q110( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q18 */
                     pr_default.execute(16, new Object[] {A567IsPredefined, A522PageName, A523PageStructure, A562PagePublishedStructure, A545PageType, A543AppVersionId, A521PageId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q110( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1Q110( ) ;
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
            EndLevel1Q110( ) ;
         }
         CloseExtendedTableCursors1Q110( ) ;
      }

      protected void DeferredUpdate1Q110( )
      {
      }

      protected void Delete1Q110( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q110( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q110( ) ;
            AfterConfirm1Q110( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q110( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Q19 */
                  pr_default.execute(17, new Object[] {A543AppVersionId, A521PageId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode110 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Q110( ) ;
         Gx_mode = sMode110;
      }

      protected void OnDeleteControls1Q110( )
      {
         standaloneModal1Q110( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1Q110( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1Q110( )
      {
         /* Scan By routine */
         /* Using cursor BC001Q20 */
         pr_default.execute(18, new Object[] {A543AppVersionId});
         RcdFound110 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound110 = 1;
            A521PageId = BC001Q20_A521PageId[0];
            A567IsPredefined = BC001Q20_A567IsPredefined[0];
            A522PageName = BC001Q20_A522PageName[0];
            A523PageStructure = BC001Q20_A523PageStructure[0];
            A562PagePublishedStructure = BC001Q20_A562PagePublishedStructure[0];
            A545PageType = BC001Q20_A545PageType[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Q110( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound110 = 0;
         ScanKeyLoad1Q110( ) ;
      }

      protected void ScanKeyLoad1Q110( )
      {
         sMode110 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound110 = 1;
            A521PageId = BC001Q20_A521PageId[0];
            A567IsPredefined = BC001Q20_A567IsPredefined[0];
            A522PageName = BC001Q20_A522PageName[0];
            A523PageStructure = BC001Q20_A523PageStructure[0];
            A562PagePublishedStructure = BC001Q20_A562PagePublishedStructure[0];
            A545PageType = BC001Q20_A545PageType[0];
         }
         Gx_mode = sMode110;
      }

      protected void ScanKeyEnd1Q110( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1Q110( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q110( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q110( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q110( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q110( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q110( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q110( )
      {
      }

      protected void send_integrity_lvl_hashes1Q110( )
      {
      }

      protected void send_integrity_lvl_hashes1Q109( )
      {
      }

      protected void AddRow1Q109( )
      {
         VarsToRow109( bcTrn_AppVersion) ;
      }

      protected void ReadRow1Q109( )
      {
         RowToVars109( bcTrn_AppVersion, 1) ;
      }

      protected void AddRow1Q110( )
      {
         SdtTrn_AppVersion_Page obj110;
         obj110 = new SdtTrn_AppVersion_Page(context);
         VarsToRow110( obj110) ;
         bcTrn_AppVersion.gxTpr_Page.Add(obj110, 0);
         obj110.gxTpr_Mode = "UPD";
         obj110.gxTpr_Modified = 0;
      }

      protected void ReadRow1Q110( )
      {
         nGXsfl_110_idx = (int)(nGXsfl_110_idx+1);
         RowToVars110( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_110_idx)), 1) ;
      }

      protected void InitializeNonKey1Q109( )
      {
         A544AppVersionName = "";
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         A561IsActive = false;
         Z544AppVersionName = "";
         Z561IsActive = false;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1Q109( )
      {
         A543AppVersionId = Guid.NewGuid( );
         InitializeNonKey1Q109( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1Q110( )
      {
         A522PageName = "";
         A523PageStructure = "";
         A562PagePublishedStructure = "";
         A545PageType = "";
         A567IsPredefined = false;
         Z567IsPredefined = false;
         Z522PageName = "";
         Z545PageType = "";
      }

      protected void InitAll1Q110( )
      {
         A521PageId = Guid.NewGuid( );
         InitializeNonKey1Q110( ) ;
      }

      protected void StandaloneModalInsert1Q110( )
      {
         A567IsPredefined = i567IsPredefined;
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

      public void VarsToRow109( SdtTrn_AppVersion obj109 )
      {
         obj109.gxTpr_Mode = Gx_mode;
         obj109.gxTpr_Appversionname = A544AppVersionName;
         obj109.gxTpr_Locationid = A29LocationId;
         obj109.gxTpr_Organisationid = A11OrganisationId;
         obj109.gxTpr_Isactive = A561IsActive;
         obj109.gxTpr_Appversionid = A543AppVersionId;
         obj109.gxTpr_Appversionid_Z = Z543AppVersionId;
         obj109.gxTpr_Appversionname_Z = Z544AppVersionName;
         obj109.gxTpr_Locationid_Z = Z29LocationId;
         obj109.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj109.gxTpr_Isactive_Z = Z561IsActive;
         obj109.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj109.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj109.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow109( SdtTrn_AppVersion obj109 )
      {
         obj109.gxTpr_Appversionid = A543AppVersionId;
         return  ;
      }

      public void RowToVars109( SdtTrn_AppVersion obj109 ,
                                int forceLoad )
      {
         Gx_mode = obj109.gxTpr_Mode;
         A544AppVersionName = obj109.gxTpr_Appversionname;
         A29LocationId = obj109.gxTpr_Locationid;
         n29LocationId = false;
         A11OrganisationId = obj109.gxTpr_Organisationid;
         n11OrganisationId = false;
         A561IsActive = obj109.gxTpr_Isactive;
         A543AppVersionId = obj109.gxTpr_Appversionid;
         Z543AppVersionId = obj109.gxTpr_Appversionid_Z;
         Z544AppVersionName = obj109.gxTpr_Appversionname_Z;
         Z29LocationId = obj109.gxTpr_Locationid_Z;
         Z11OrganisationId = obj109.gxTpr_Organisationid_Z;
         Z561IsActive = obj109.gxTpr_Isactive_Z;
         n29LocationId = (bool)(Convert.ToBoolean(obj109.gxTpr_Locationid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj109.gxTpr_Organisationid_N));
         Gx_mode = obj109.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow110( SdtTrn_AppVersion_Page obj110 )
      {
         obj110.gxTpr_Mode = Gx_mode;
         obj110.gxTpr_Pagename = A522PageName;
         obj110.gxTpr_Pagestructure = A523PageStructure;
         obj110.gxTpr_Pagepublishedstructure = A562PagePublishedStructure;
         obj110.gxTpr_Pagetype = A545PageType;
         obj110.gxTpr_Ispredefined = A567IsPredefined;
         obj110.gxTpr_Pageid = A521PageId;
         obj110.gxTpr_Pageid_Z = Z521PageId;
         obj110.gxTpr_Pagename_Z = Z522PageName;
         obj110.gxTpr_Ispredefined_Z = Z567IsPredefined;
         obj110.gxTpr_Pagetype_Z = Z545PageType;
         obj110.gxTpr_Modified = nIsMod_110;
         return  ;
      }

      public void KeyVarsToRow110( SdtTrn_AppVersion_Page obj110 )
      {
         obj110.gxTpr_Pageid = A521PageId;
         return  ;
      }

      public void RowToVars110( SdtTrn_AppVersion_Page obj110 ,
                                int forceLoad )
      {
         Gx_mode = obj110.gxTpr_Mode;
         A522PageName = obj110.gxTpr_Pagename;
         A523PageStructure = obj110.gxTpr_Pagestructure;
         A562PagePublishedStructure = obj110.gxTpr_Pagepublishedstructure;
         A545PageType = obj110.gxTpr_Pagetype;
         A567IsPredefined = obj110.gxTpr_Ispredefined;
         A521PageId = obj110.gxTpr_Pageid;
         Z521PageId = obj110.gxTpr_Pageid_Z;
         Z522PageName = obj110.gxTpr_Pagename_Z;
         Z567IsPredefined = obj110.gxTpr_Ispredefined_Z;
         Z545PageType = obj110.gxTpr_Pagetype_Z;
         nIsMod_110 = obj110.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A543AppVersionId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Q109( ) ;
         ScanKeyStart1Q109( ) ;
         if ( RcdFound109 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z543AppVersionId = A543AppVersionId;
         }
         ZM1Q109( -9) ;
         OnLoadActions1Q109( ) ;
         AddRow1Q109( ) ;
         bcTrn_AppVersion.gxTpr_Page.ClearCollection();
         if ( RcdFound109 == 1 )
         {
            ScanKeyStart1Q110( ) ;
            nGXsfl_110_idx = 1;
            while ( RcdFound110 != 0 )
            {
               Z543AppVersionId = A543AppVersionId;
               Z521PageId = A521PageId;
               ZM1Q110( -13) ;
               OnLoadActions1Q110( ) ;
               nRcdExists_110 = 1;
               nIsMod_110 = 0;
               AddRow1Q110( ) ;
               nGXsfl_110_idx = (int)(nGXsfl_110_idx+1);
               ScanKeyNext1Q110( ) ;
            }
            ScanKeyEnd1Q110( ) ;
         }
         ScanKeyEnd1Q109( ) ;
         if ( RcdFound109 == 0 )
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
         RowToVars109( bcTrn_AppVersion, 0) ;
         ScanKeyStart1Q109( ) ;
         if ( RcdFound109 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z543AppVersionId = A543AppVersionId;
         }
         ZM1Q109( -9) ;
         OnLoadActions1Q109( ) ;
         AddRow1Q109( ) ;
         bcTrn_AppVersion.gxTpr_Page.ClearCollection();
         if ( RcdFound109 == 1 )
         {
            ScanKeyStart1Q110( ) ;
            nGXsfl_110_idx = 1;
            while ( RcdFound110 != 0 )
            {
               Z543AppVersionId = A543AppVersionId;
               Z521PageId = A521PageId;
               ZM1Q110( -13) ;
               OnLoadActions1Q110( ) ;
               nRcdExists_110 = 1;
               nIsMod_110 = 0;
               AddRow1Q110( ) ;
               nGXsfl_110_idx = (int)(nGXsfl_110_idx+1);
               ScanKeyNext1Q110( ) ;
            }
            ScanKeyEnd1Q110( ) ;
         }
         ScanKeyEnd1Q109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Q109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Q109( ) ;
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( A543AppVersionId != Z543AppVersionId )
               {
                  A543AppVersionId = Z543AppVersionId;
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
                  Update1Q109( ) ;
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
                  if ( A543AppVersionId != Z543AppVersionId )
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
                        Insert1Q109( ) ;
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
                        Insert1Q109( ) ;
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
         RowToVars109( bcTrn_AppVersion, 1) ;
         SaveImpl( ) ;
         VarsToRow109( bcTrn_AppVersion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars109( bcTrn_AppVersion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Q109( ) ;
         AfterTrn( ) ;
         VarsToRow109( bcTrn_AppVersion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow109( bcTrn_AppVersion) ;
         }
         else
         {
            SdtTrn_AppVersion auxBC = new SdtTrn_AppVersion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A543AppVersionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AppVersion);
               auxBC.Save();
               bcTrn_AppVersion.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars109( bcTrn_AppVersion, 1) ;
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
         RowToVars109( bcTrn_AppVersion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Q109( ) ;
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
               VarsToRow109( bcTrn_AppVersion) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow109( bcTrn_AppVersion) ;
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
         RowToVars109( bcTrn_AppVersion, 0) ;
         GetKey1Q109( ) ;
         if ( RcdFound109 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A543AppVersionId != Z543AppVersionId )
            {
               A543AppVersionId = Z543AppVersionId;
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
            if ( A543AppVersionId != Z543AppVersionId )
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
         context.RollbackDataStores("trn_appversion_bc",pr_default);
         VarsToRow109( bcTrn_AppVersion) ;
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
         Gx_mode = bcTrn_AppVersion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AppVersion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AppVersion )
         {
            bcTrn_AppVersion = (SdtTrn_AppVersion)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AppVersion.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppVersion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow109( bcTrn_AppVersion) ;
            }
            else
            {
               RowToVars109( bcTrn_AppVersion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AppVersion.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppVersion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars109( bcTrn_AppVersion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AppVersion Trn_AppVersion_BC
      {
         get {
            return bcTrn_AppVersion ;
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
            return "trn_appversion_Execute" ;
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
         pr_default.close(3);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z543AppVersionId = Guid.Empty;
         A543AppVersionId = Guid.Empty;
         sMode109 = "";
         Z544AppVersionName = "";
         A544AppVersionName = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         BC001Q8_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q8_A544AppVersionName = new string[] {""} ;
         BC001Q8_A561IsActive = new bool[] {false} ;
         BC001Q8_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001Q8_n29LocationId = new bool[] {false} ;
         BC001Q8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001Q8_n11OrganisationId = new bool[] {false} ;
         BC001Q9_A544AppVersionName = new string[] {""} ;
         BC001Q7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001Q7_n29LocationId = new bool[] {false} ;
         BC001Q6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001Q6_n11OrganisationId = new bool[] {false} ;
         BC001Q10_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q5_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q5_A544AppVersionName = new string[] {""} ;
         BC001Q5_A561IsActive = new bool[] {false} ;
         BC001Q5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001Q5_n29LocationId = new bool[] {false} ;
         BC001Q5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001Q5_n11OrganisationId = new bool[] {false} ;
         BC001Q4_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q4_A544AppVersionName = new string[] {""} ;
         BC001Q4_A561IsActive = new bool[] {false} ;
         BC001Q4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001Q4_n29LocationId = new bool[] {false} ;
         BC001Q4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001Q4_n11OrganisationId = new bool[] {false} ;
         BC001Q14_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q14_A544AppVersionName = new string[] {""} ;
         BC001Q14_A561IsActive = new bool[] {false} ;
         BC001Q14_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001Q14_n29LocationId = new bool[] {false} ;
         BC001Q14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001Q14_n11OrganisationId = new bool[] {false} ;
         Z522PageName = "";
         A522PageName = "";
         Z545PageType = "";
         A545PageType = "";
         Z521PageId = Guid.Empty;
         A521PageId = Guid.Empty;
         Z523PageStructure = "";
         A523PageStructure = "";
         Z562PagePublishedStructure = "";
         A562PagePublishedStructure = "";
         BC001Q15_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q15_A521PageId = new Guid[] {Guid.Empty} ;
         BC001Q15_A567IsPredefined = new bool[] {false} ;
         BC001Q15_A522PageName = new string[] {""} ;
         BC001Q15_A523PageStructure = new string[] {""} ;
         BC001Q15_A562PagePublishedStructure = new string[] {""} ;
         BC001Q15_A545PageType = new string[] {""} ;
         BC001Q16_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q16_A521PageId = new Guid[] {Guid.Empty} ;
         BC001Q3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q3_A521PageId = new Guid[] {Guid.Empty} ;
         BC001Q3_A567IsPredefined = new bool[] {false} ;
         BC001Q3_A522PageName = new string[] {""} ;
         BC001Q3_A523PageStructure = new string[] {""} ;
         BC001Q3_A562PagePublishedStructure = new string[] {""} ;
         BC001Q3_A545PageType = new string[] {""} ;
         sMode110 = "";
         BC001Q2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q2_A521PageId = new Guid[] {Guid.Empty} ;
         BC001Q2_A567IsPredefined = new bool[] {false} ;
         BC001Q2_A522PageName = new string[] {""} ;
         BC001Q2_A523PageStructure = new string[] {""} ;
         BC001Q2_A562PagePublishedStructure = new string[] {""} ;
         BC001Q2_A545PageType = new string[] {""} ;
         BC001Q20_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC001Q20_A521PageId = new Guid[] {Guid.Empty} ;
         BC001Q20_A567IsPredefined = new bool[] {false} ;
         BC001Q20_A522PageName = new string[] {""} ;
         BC001Q20_A523PageStructure = new string[] {""} ;
         BC001Q20_A562PagePublishedStructure = new string[] {""} ;
         BC001Q20_A545PageType = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Q2_A543AppVersionId, BC001Q2_A521PageId, BC001Q2_A567IsPredefined, BC001Q2_A522PageName, BC001Q2_A523PageStructure, BC001Q2_A562PagePublishedStructure, BC001Q2_A545PageType
               }
               , new Object[] {
               BC001Q3_A543AppVersionId, BC001Q3_A521PageId, BC001Q3_A567IsPredefined, BC001Q3_A522PageName, BC001Q3_A523PageStructure, BC001Q3_A562PagePublishedStructure, BC001Q3_A545PageType
               }
               , new Object[] {
               BC001Q4_A543AppVersionId, BC001Q4_A544AppVersionName, BC001Q4_A561IsActive, BC001Q4_A29LocationId, BC001Q4_n29LocationId, BC001Q4_A11OrganisationId, BC001Q4_n11OrganisationId
               }
               , new Object[] {
               BC001Q5_A543AppVersionId, BC001Q5_A544AppVersionName, BC001Q5_A561IsActive, BC001Q5_A29LocationId, BC001Q5_n29LocationId, BC001Q5_A11OrganisationId, BC001Q5_n11OrganisationId
               }
               , new Object[] {
               BC001Q6_A11OrganisationId
               }
               , new Object[] {
               BC001Q7_A29LocationId
               }
               , new Object[] {
               BC001Q8_A543AppVersionId, BC001Q8_A544AppVersionName, BC001Q8_A561IsActive, BC001Q8_A29LocationId, BC001Q8_n29LocationId, BC001Q8_A11OrganisationId, BC001Q8_n11OrganisationId
               }
               , new Object[] {
               BC001Q9_A544AppVersionName
               }
               , new Object[] {
               BC001Q10_A543AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Q14_A543AppVersionId, BC001Q14_A544AppVersionName, BC001Q14_A561IsActive, BC001Q14_A29LocationId, BC001Q14_n29LocationId, BC001Q14_A11OrganisationId, BC001Q14_n11OrganisationId
               }
               , new Object[] {
               BC001Q15_A543AppVersionId, BC001Q15_A521PageId, BC001Q15_A567IsPredefined, BC001Q15_A522PageName, BC001Q15_A523PageStructure, BC001Q15_A562PagePublishedStructure, BC001Q15_A545PageType
               }
               , new Object[] {
               BC001Q16_A543AppVersionId, BC001Q16_A521PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Q20_A543AppVersionId, BC001Q20_A521PageId, BC001Q20_A567IsPredefined, BC001Q20_A522PageName, BC001Q20_A523PageStructure, BC001Q20_A562PagePublishedStructure, BC001Q20_A545PageType
               }
            }
         );
         Z521PageId = Guid.NewGuid( );
         A521PageId = Guid.NewGuid( );
         Z543AppVersionId = Guid.NewGuid( );
         A543AppVersionId = Guid.NewGuid( );
         Z567IsPredefined = false;
         A567IsPredefined = false;
         i567IsPredefined = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_110 ;
      private short RcdFound110 ;
      private short Gx_BScreen ;
      private short RcdFound109 ;
      private short nRcdExists_110 ;
      private short Gxremove110 ;
      private int trnEnded ;
      private int nGXsfl_110_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode109 ;
      private string sMode110 ;
      private bool Z561IsActive ;
      private bool A561IsActive ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool Z567IsPredefined ;
      private bool A567IsPredefined ;
      private bool i567IsPredefined ;
      private string Z523PageStructure ;
      private string A523PageStructure ;
      private string Z562PagePublishedStructure ;
      private string A562PagePublishedStructure ;
      private string Z544AppVersionName ;
      private string A544AppVersionName ;
      private string Z522PageName ;
      private string A522PageName ;
      private string Z545PageType ;
      private string A545PageType ;
      private Guid Z543AppVersionId ;
      private Guid A543AppVersionId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z521PageId ;
      private Guid A521PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion bcTrn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001Q8_A543AppVersionId ;
      private string[] BC001Q8_A544AppVersionName ;
      private bool[] BC001Q8_A561IsActive ;
      private Guid[] BC001Q8_A29LocationId ;
      private bool[] BC001Q8_n29LocationId ;
      private Guid[] BC001Q8_A11OrganisationId ;
      private bool[] BC001Q8_n11OrganisationId ;
      private string[] BC001Q9_A544AppVersionName ;
      private Guid[] BC001Q7_A29LocationId ;
      private bool[] BC001Q7_n29LocationId ;
      private Guid[] BC001Q6_A11OrganisationId ;
      private bool[] BC001Q6_n11OrganisationId ;
      private Guid[] BC001Q10_A543AppVersionId ;
      private Guid[] BC001Q5_A543AppVersionId ;
      private string[] BC001Q5_A544AppVersionName ;
      private bool[] BC001Q5_A561IsActive ;
      private Guid[] BC001Q5_A29LocationId ;
      private bool[] BC001Q5_n29LocationId ;
      private Guid[] BC001Q5_A11OrganisationId ;
      private bool[] BC001Q5_n11OrganisationId ;
      private Guid[] BC001Q4_A543AppVersionId ;
      private string[] BC001Q4_A544AppVersionName ;
      private bool[] BC001Q4_A561IsActive ;
      private Guid[] BC001Q4_A29LocationId ;
      private bool[] BC001Q4_n29LocationId ;
      private Guid[] BC001Q4_A11OrganisationId ;
      private bool[] BC001Q4_n11OrganisationId ;
      private Guid[] BC001Q14_A543AppVersionId ;
      private string[] BC001Q14_A544AppVersionName ;
      private bool[] BC001Q14_A561IsActive ;
      private Guid[] BC001Q14_A29LocationId ;
      private bool[] BC001Q14_n29LocationId ;
      private Guid[] BC001Q14_A11OrganisationId ;
      private bool[] BC001Q14_n11OrganisationId ;
      private Guid[] BC001Q15_A543AppVersionId ;
      private Guid[] BC001Q15_A521PageId ;
      private bool[] BC001Q15_A567IsPredefined ;
      private string[] BC001Q15_A522PageName ;
      private string[] BC001Q15_A523PageStructure ;
      private string[] BC001Q15_A562PagePublishedStructure ;
      private string[] BC001Q15_A545PageType ;
      private Guid[] BC001Q16_A543AppVersionId ;
      private Guid[] BC001Q16_A521PageId ;
      private Guid[] BC001Q3_A543AppVersionId ;
      private Guid[] BC001Q3_A521PageId ;
      private bool[] BC001Q3_A567IsPredefined ;
      private string[] BC001Q3_A522PageName ;
      private string[] BC001Q3_A523PageStructure ;
      private string[] BC001Q3_A562PagePublishedStructure ;
      private string[] BC001Q3_A545PageType ;
      private Guid[] BC001Q2_A543AppVersionId ;
      private Guid[] BC001Q2_A521PageId ;
      private bool[] BC001Q2_A567IsPredefined ;
      private string[] BC001Q2_A522PageName ;
      private string[] BC001Q2_A523PageStructure ;
      private string[] BC001Q2_A562PagePublishedStructure ;
      private string[] BC001Q2_A545PageType ;
      private Guid[] BC001Q20_A543AppVersionId ;
      private Guid[] BC001Q20_A521PageId ;
      private bool[] BC001Q20_A567IsPredefined ;
      private string[] BC001Q20_A522PageName ;
      private string[] BC001Q20_A523PageStructure ;
      private string[] BC001Q20_A562PagePublishedStructure ;
      private string[] BC001Q20_A545PageType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appversion_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appversion_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appversion_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new ForEachCursor(def[18])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001Q2;
       prmBC001Q2 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q3;
       prmBC001Q3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q4;
       prmBC001Q4 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q5;
       prmBC001Q5 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q6;
       prmBC001Q6 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001Q7;
       prmBC001Q7 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001Q8;
       prmBC001Q8 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q9;
       prmBC001Q9 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q10;
       prmBC001Q10 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q11;
       prmBC001Q11 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001Q12;
       prmBC001Q12 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q13;
       prmBC001Q13 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q14;
       prmBC001Q14 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q15;
       prmBC001Q15 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q16;
       prmBC001Q16 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q17;
       prmBC001Q17 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0)
       };
       Object[] prmBC001Q18;
       prmBC001Q18 = new Object[] {
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q19;
       prmBC001Q19 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001Q20;
       prmBC001Q20 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001Q2", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q3", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q4", "SELECT AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q5", "SELECT AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q6", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q8", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.LocationId, TM1.OrganisationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q9", "SELECT AppVersionName FROM Trn_AppVersion WHERE (AppVersionName = :AppVersionName AND LocationId = :LocationId) AND (Not ( AppVersionId = :AppVersionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q10", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q11", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId) VALUES(:AppVersionId, :AppVersionName, :IsActive, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q11)
          ,new CursorDef("BC001Q12", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName, IsActive=:IsActive, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q12)
          ,new CursorDef("BC001Q13", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q13)
          ,new CursorDef("BC001Q14", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.LocationId, TM1.OrganisationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q14,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q15", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :PageId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q15,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q16", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001Q17", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersionPage(AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType) VALUES(:AppVersionId, :PageId, :IsPredefined, :PageName, :PageStructure, :PagePublishedStructure, :PageType);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001Q17)
          ,new CursorDef("BC001Q18", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET IsPredefined=:IsPredefined, PageName=:PageName, PageStructure=:PageStructure, PagePublishedStructure=:PagePublishedStructure, PageType=:PageType  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q18)
          ,new CursorDef("BC001Q19", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q19)
          ,new CursorDef("BC001Q20", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q20,11, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
    }
 }

}

}
