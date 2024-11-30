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
   public class trn_audit_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_audit_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_audit_bc( IGxContext context )
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
         ReadRow1D84( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1D84( ) ;
         standaloneModal( ) ;
         AddRow1D84( ) ;
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
            E111D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z415AuditId = A415AuditId;
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

      protected void CONFIRM_1D0( )
      {
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1D84( ) ;
            }
            else
            {
               CheckExtendedTable1D84( ) ;
               if ( AnyError == 0 )
               {
                  ZM1D84( 8) ;
               }
               CloseExtendedTableCursors1D84( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E111D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1D84( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z416AuditDate = A416AuditDate;
            Z417AuditTableName = A417AuditTableName;
            Z419AuditShortDescription = A419AuditShortDescription;
            Z420GAMUserId = A420GAMUserId;
            Z421AuditUserName = A421AuditUserName;
            Z422AuditAction = A422AuditAction;
            Z11OrganisationId = A11OrganisationId;
            Z435AuditDisplayDescription = A435AuditDisplayDescription;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z435AuditDisplayDescription = A435AuditDisplayDescription;
         }
         if ( GX_JID == -7 )
         {
            Z415AuditId = A415AuditId;
            Z416AuditDate = A416AuditDate;
            Z417AuditTableName = A417AuditTableName;
            Z418AuditDescription = A418AuditDescription;
            Z419AuditShortDescription = A419AuditShortDescription;
            Z420GAMUserId = A420GAMUserId;
            Z421AuditUserName = A421AuditUserName;
            Z422AuditAction = A422AuditAction;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Trn_Audit_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A415AuditId) )
         {
            A415AuditId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1D84( )
      {
         /* Using cursor BC001D5 */
         pr_default.execute(3, new Object[] {A415AuditId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound84 = 1;
            A416AuditDate = BC001D5_A416AuditDate[0];
            A417AuditTableName = BC001D5_A417AuditTableName[0];
            A418AuditDescription = BC001D5_A418AuditDescription[0];
            A419AuditShortDescription = BC001D5_A419AuditShortDescription[0];
            A420GAMUserId = BC001D5_A420GAMUserId[0];
            A421AuditUserName = BC001D5_A421AuditUserName[0];
            A422AuditAction = BC001D5_A422AuditAction[0];
            A11OrganisationId = BC001D5_A11OrganisationId[0];
            ZM1D84( -7) ;
         }
         pr_default.close(3);
         OnLoadActions1D84( ) ;
      }

      protected void OnLoadActions1D84( )
      {
         A435AuditDisplayDescription = StringUtil.Substring( A419AuditShortDescription, 161, 240);
      }

      protected void CheckExtendedTable1D84( )
      {
         standaloneModal( ) ;
         A435AuditDisplayDescription = StringUtil.Substring( A419AuditShortDescription, 161, 240);
         /* Using cursor BC001D4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1D84( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D84( )
      {
         /* Using cursor BC001D6 */
         pr_default.execute(4, new Object[] {A415AuditId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound84 = 1;
         }
         else
         {
            RcdFound84 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001D3 */
         pr_default.execute(1, new Object[] {A415AuditId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D84( 7) ;
            RcdFound84 = 1;
            A415AuditId = BC001D3_A415AuditId[0];
            A416AuditDate = BC001D3_A416AuditDate[0];
            A417AuditTableName = BC001D3_A417AuditTableName[0];
            A418AuditDescription = BC001D3_A418AuditDescription[0];
            A419AuditShortDescription = BC001D3_A419AuditShortDescription[0];
            A420GAMUserId = BC001D3_A420GAMUserId[0];
            A421AuditUserName = BC001D3_A421AuditUserName[0];
            A422AuditAction = BC001D3_A422AuditAction[0];
            A11OrganisationId = BC001D3_A11OrganisationId[0];
            Z415AuditId = A415AuditId;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1D84( ) ;
            if ( AnyError == 1 )
            {
               RcdFound84 = 0;
               InitializeNonKey1D84( ) ;
            }
            Gx_mode = sMode84;
         }
         else
         {
            RcdFound84 = 0;
            InitializeNonKey1D84( ) ;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode84;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D84( ) ;
         if ( RcdFound84 == 0 )
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
         CONFIRM_1D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1D84( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001D2 */
            pr_default.execute(0, new Object[] {A415AuditId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z416AuditDate != BC001D2_A416AuditDate[0] ) || ( StringUtil.StrCmp(Z417AuditTableName, BC001D2_A417AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z419AuditShortDescription, BC001D2_A419AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z420GAMUserId, BC001D2_A420GAMUserId[0]) != 0 ) || ( StringUtil.StrCmp(Z421AuditUserName, BC001D2_A421AuditUserName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z422AuditAction, BC001D2_A422AuditAction[0]) != 0 ) || ( Z11OrganisationId != BC001D2_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D84( )
      {
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D84( 0) ;
            CheckOptimisticConcurrency1D84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D7 */
                     pr_default.execute(5, new Object[] {A415AuditId, A416AuditDate, A417AuditTableName, A418AuditDescription, A419AuditShortDescription, A420GAMUserId, A421AuditUserName, A422AuditAction, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load1D84( ) ;
            }
            EndLevel1D84( ) ;
         }
         CloseExtendedTableCursors1D84( ) ;
      }

      protected void Update1D84( )
      {
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D8 */
                     pr_default.execute(6, new Object[] {A416AuditDate, A417AuditTableName, A418AuditDescription, A419AuditShortDescription, A420GAMUserId, A421AuditUserName, A422AuditAction, A11OrganisationId, A415AuditId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D84( ) ;
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
            EndLevel1D84( ) ;
         }
         CloseExtendedTableCursors1D84( ) ;
      }

      protected void DeferredUpdate1D84( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D84( ) ;
            AfterConfirm1D84( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D84( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001D9 */
                  pr_default.execute(7, new Object[] {A415AuditId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
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
         sMode84 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1D84( ) ;
         Gx_mode = sMode84;
      }

      protected void OnDeleteControls1D84( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A435AuditDisplayDescription = StringUtil.Substring( A419AuditShortDescription, 161, 240);
         }
      }

      protected void EndLevel1D84( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D84( ) ;
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

      public void ScanKeyStart1D84( )
      {
         /* Scan By routine */
         /* Using cursor BC001D10 */
         pr_default.execute(8, new Object[] {A415AuditId});
         RcdFound84 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound84 = 1;
            A415AuditId = BC001D10_A415AuditId[0];
            A416AuditDate = BC001D10_A416AuditDate[0];
            A417AuditTableName = BC001D10_A417AuditTableName[0];
            A418AuditDescription = BC001D10_A418AuditDescription[0];
            A419AuditShortDescription = BC001D10_A419AuditShortDescription[0];
            A420GAMUserId = BC001D10_A420GAMUserId[0];
            A421AuditUserName = BC001D10_A421AuditUserName[0];
            A422AuditAction = BC001D10_A422AuditAction[0];
            A11OrganisationId = BC001D10_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1D84( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound84 = 0;
         ScanKeyLoad1D84( ) ;
      }

      protected void ScanKeyLoad1D84( )
      {
         sMode84 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound84 = 1;
            A415AuditId = BC001D10_A415AuditId[0];
            A416AuditDate = BC001D10_A416AuditDate[0];
            A417AuditTableName = BC001D10_A417AuditTableName[0];
            A418AuditDescription = BC001D10_A418AuditDescription[0];
            A419AuditShortDescription = BC001D10_A419AuditShortDescription[0];
            A420GAMUserId = BC001D10_A420GAMUserId[0];
            A421AuditUserName = BC001D10_A421AuditUserName[0];
            A422AuditAction = BC001D10_A422AuditAction[0];
            A11OrganisationId = BC001D10_A11OrganisationId[0];
         }
         Gx_mode = sMode84;
      }

      protected void ScanKeyEnd1D84( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1D84( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D84( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D84( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D84( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D84( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D84( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D84( )
      {
      }

      protected void send_integrity_lvl_hashes1D84( )
      {
      }

      protected void AddRow1D84( )
      {
         VarsToRow84( bcTrn_Audit) ;
      }

      protected void ReadRow1D84( )
      {
         RowToVars84( bcTrn_Audit, 1) ;
      }

      protected void InitializeNonKey1D84( )
      {
         A435AuditDisplayDescription = "";
         A416AuditDate = (DateTime)(DateTime.MinValue);
         A417AuditTableName = "";
         A418AuditDescription = "";
         A419AuditShortDescription = "";
         A420GAMUserId = "";
         A421AuditUserName = "";
         A422AuditAction = "";
         A11OrganisationId = Guid.Empty;
         Z416AuditDate = (DateTime)(DateTime.MinValue);
         Z417AuditTableName = "";
         Z419AuditShortDescription = "";
         Z420GAMUserId = "";
         Z421AuditUserName = "";
         Z422AuditAction = "";
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1D84( )
      {
         A415AuditId = Guid.NewGuid( );
         InitializeNonKey1D84( ) ;
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

      public void VarsToRow84( SdtTrn_Audit obj84 )
      {
         obj84.gxTpr_Mode = Gx_mode;
         obj84.gxTpr_Auditdisplaydescription = A435AuditDisplayDescription;
         obj84.gxTpr_Auditdate = A416AuditDate;
         obj84.gxTpr_Audittablename = A417AuditTableName;
         obj84.gxTpr_Auditdescription = A418AuditDescription;
         obj84.gxTpr_Auditshortdescription = A419AuditShortDescription;
         obj84.gxTpr_Gamuserid = A420GAMUserId;
         obj84.gxTpr_Auditusername = A421AuditUserName;
         obj84.gxTpr_Auditaction = A422AuditAction;
         obj84.gxTpr_Organisationid = A11OrganisationId;
         obj84.gxTpr_Auditid = A415AuditId;
         obj84.gxTpr_Auditid_Z = Z415AuditId;
         obj84.gxTpr_Auditdate_Z = Z416AuditDate;
         obj84.gxTpr_Audittablename_Z = Z417AuditTableName;
         obj84.gxTpr_Auditshortdescription_Z = Z419AuditShortDescription;
         obj84.gxTpr_Gamuserid_Z = Z420GAMUserId;
         obj84.gxTpr_Auditusername_Z = Z421AuditUserName;
         obj84.gxTpr_Auditaction_Z = Z422AuditAction;
         obj84.gxTpr_Auditdisplaydescription_Z = Z435AuditDisplayDescription;
         obj84.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj84.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow84( SdtTrn_Audit obj84 )
      {
         obj84.gxTpr_Auditid = A415AuditId;
         return  ;
      }

      public void RowToVars84( SdtTrn_Audit obj84 ,
                               int forceLoad )
      {
         Gx_mode = obj84.gxTpr_Mode;
         A435AuditDisplayDescription = obj84.gxTpr_Auditdisplaydescription;
         A416AuditDate = obj84.gxTpr_Auditdate;
         A417AuditTableName = obj84.gxTpr_Audittablename;
         A418AuditDescription = obj84.gxTpr_Auditdescription;
         A419AuditShortDescription = obj84.gxTpr_Auditshortdescription;
         A420GAMUserId = obj84.gxTpr_Gamuserid;
         A421AuditUserName = obj84.gxTpr_Auditusername;
         A422AuditAction = obj84.gxTpr_Auditaction;
         A11OrganisationId = obj84.gxTpr_Organisationid;
         A415AuditId = obj84.gxTpr_Auditid;
         Z415AuditId = obj84.gxTpr_Auditid_Z;
         Z416AuditDate = obj84.gxTpr_Auditdate_Z;
         Z417AuditTableName = obj84.gxTpr_Audittablename_Z;
         Z419AuditShortDescription = obj84.gxTpr_Auditshortdescription_Z;
         Z420GAMUserId = obj84.gxTpr_Gamuserid_Z;
         Z421AuditUserName = obj84.gxTpr_Auditusername_Z;
         Z422AuditAction = obj84.gxTpr_Auditaction_Z;
         Z435AuditDisplayDescription = obj84.gxTpr_Auditdisplaydescription_Z;
         Z11OrganisationId = obj84.gxTpr_Organisationid_Z;
         Gx_mode = obj84.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A415AuditId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1D84( ) ;
         ScanKeyStart1D84( ) ;
         if ( RcdFound84 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z415AuditId = A415AuditId;
         }
         ZM1D84( -7) ;
         OnLoadActions1D84( ) ;
         AddRow1D84( ) ;
         ScanKeyEnd1D84( ) ;
         if ( RcdFound84 == 0 )
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
         RowToVars84( bcTrn_Audit, 0) ;
         ScanKeyStart1D84( ) ;
         if ( RcdFound84 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z415AuditId = A415AuditId;
         }
         ZM1D84( -7) ;
         OnLoadActions1D84( ) ;
         AddRow1D84( ) ;
         ScanKeyEnd1D84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1D84( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1D84( ) ;
         }
         else
         {
            if ( RcdFound84 == 1 )
            {
               if ( A415AuditId != Z415AuditId )
               {
                  A415AuditId = Z415AuditId;
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
                  Update1D84( ) ;
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
                  if ( A415AuditId != Z415AuditId )
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
                        Insert1D84( ) ;
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
                        Insert1D84( ) ;
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
         RowToVars84( bcTrn_Audit, 1) ;
         SaveImpl( ) ;
         VarsToRow84( bcTrn_Audit) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars84( bcTrn_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D84( ) ;
         AfterTrn( ) ;
         VarsToRow84( bcTrn_Audit) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow84( bcTrn_Audit) ;
         }
         else
         {
            SdtTrn_Audit auxBC = new SdtTrn_Audit(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A415AuditId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Audit);
               auxBC.Save();
               bcTrn_Audit.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars84( bcTrn_Audit, 1) ;
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
         RowToVars84( bcTrn_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D84( ) ;
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
               VarsToRow84( bcTrn_Audit) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow84( bcTrn_Audit) ;
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
         RowToVars84( bcTrn_Audit, 0) ;
         GetKey1D84( ) ;
         if ( RcdFound84 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A415AuditId != Z415AuditId )
            {
               A415AuditId = Z415AuditId;
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
            if ( A415AuditId != Z415AuditId )
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
         context.RollbackDataStores("trn_audit_bc",pr_default);
         VarsToRow84( bcTrn_Audit) ;
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
         Gx_mode = bcTrn_Audit.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Audit.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Audit )
         {
            bcTrn_Audit = (SdtTrn_Audit)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Audit.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Audit.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow84( bcTrn_Audit) ;
            }
            else
            {
               RowToVars84( bcTrn_Audit, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Audit.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Audit.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars84( bcTrn_Audit, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Audit Trn_Audit_BC
      {
         get {
            return bcTrn_Audit ;
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
            return "trn_audit_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z415AuditId = Guid.Empty;
         A415AuditId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV23Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationId = Guid.Empty;
         Z416AuditDate = (DateTime)(DateTime.MinValue);
         A416AuditDate = (DateTime)(DateTime.MinValue);
         Z417AuditTableName = "";
         A417AuditTableName = "";
         Z419AuditShortDescription = "";
         A419AuditShortDescription = "";
         Z420GAMUserId = "";
         A420GAMUserId = "";
         Z421AuditUserName = "";
         A421AuditUserName = "";
         Z422AuditAction = "";
         A422AuditAction = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z435AuditDisplayDescription = "";
         A435AuditDisplayDescription = "";
         Z418AuditDescription = "";
         A418AuditDescription = "";
         BC001D5_A415AuditId = new Guid[] {Guid.Empty} ;
         BC001D5_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC001D5_A417AuditTableName = new string[] {""} ;
         BC001D5_A418AuditDescription = new string[] {""} ;
         BC001D5_A419AuditShortDescription = new string[] {""} ;
         BC001D5_A420GAMUserId = new string[] {""} ;
         BC001D5_A421AuditUserName = new string[] {""} ;
         BC001D5_A422AuditAction = new string[] {""} ;
         BC001D5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001D4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001D6_A415AuditId = new Guid[] {Guid.Empty} ;
         BC001D3_A415AuditId = new Guid[] {Guid.Empty} ;
         BC001D3_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC001D3_A417AuditTableName = new string[] {""} ;
         BC001D3_A418AuditDescription = new string[] {""} ;
         BC001D3_A419AuditShortDescription = new string[] {""} ;
         BC001D3_A420GAMUserId = new string[] {""} ;
         BC001D3_A421AuditUserName = new string[] {""} ;
         BC001D3_A422AuditAction = new string[] {""} ;
         BC001D3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode84 = "";
         BC001D2_A415AuditId = new Guid[] {Guid.Empty} ;
         BC001D2_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC001D2_A417AuditTableName = new string[] {""} ;
         BC001D2_A418AuditDescription = new string[] {""} ;
         BC001D2_A419AuditShortDescription = new string[] {""} ;
         BC001D2_A420GAMUserId = new string[] {""} ;
         BC001D2_A421AuditUserName = new string[] {""} ;
         BC001D2_A422AuditAction = new string[] {""} ;
         BC001D2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001D10_A415AuditId = new Guid[] {Guid.Empty} ;
         BC001D10_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC001D10_A417AuditTableName = new string[] {""} ;
         BC001D10_A418AuditDescription = new string[] {""} ;
         BC001D10_A419AuditShortDescription = new string[] {""} ;
         BC001D10_A420GAMUserId = new string[] {""} ;
         BC001D10_A421AuditUserName = new string[] {""} ;
         BC001D10_A422AuditAction = new string[] {""} ;
         BC001D10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__default(),
            new Object[][] {
                new Object[] {
               BC001D2_A415AuditId, BC001D2_A416AuditDate, BC001D2_A417AuditTableName, BC001D2_A418AuditDescription, BC001D2_A419AuditShortDescription, BC001D2_A420GAMUserId, BC001D2_A421AuditUserName, BC001D2_A422AuditAction, BC001D2_A11OrganisationId
               }
               , new Object[] {
               BC001D3_A415AuditId, BC001D3_A416AuditDate, BC001D3_A417AuditTableName, BC001D3_A418AuditDescription, BC001D3_A419AuditShortDescription, BC001D3_A420GAMUserId, BC001D3_A421AuditUserName, BC001D3_A422AuditAction, BC001D3_A11OrganisationId
               }
               , new Object[] {
               BC001D4_A11OrganisationId
               }
               , new Object[] {
               BC001D5_A415AuditId, BC001D5_A416AuditDate, BC001D5_A417AuditTableName, BC001D5_A418AuditDescription, BC001D5_A419AuditShortDescription, BC001D5_A420GAMUserId, BC001D5_A421AuditUserName, BC001D5_A422AuditAction, BC001D5_A11OrganisationId
               }
               , new Object[] {
               BC001D6_A415AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001D10_A415AuditId, BC001D10_A416AuditDate, BC001D10_A417AuditTableName, BC001D10_A418AuditDescription, BC001D10_A419AuditShortDescription, BC001D10_A420GAMUserId, BC001D10_A421AuditUserName, BC001D10_A422AuditAction, BC001D10_A11OrganisationId
               }
            }
         );
         Z415AuditId = Guid.NewGuid( );
         A415AuditId = Guid.NewGuid( );
         AV23Pgmname = "Trn_Audit_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121D2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound84 ;
      private int trnEnded ;
      private int AV24GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string Z420GAMUserId ;
      private string A420GAMUserId ;
      private string sMode84 ;
      private DateTime Z416AuditDate ;
      private DateTime A416AuditDate ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z418AuditDescription ;
      private string A418AuditDescription ;
      private string Z417AuditTableName ;
      private string A417AuditTableName ;
      private string Z419AuditShortDescription ;
      private string A419AuditShortDescription ;
      private string Z421AuditUserName ;
      private string A421AuditUserName ;
      private string Z422AuditAction ;
      private string A422AuditAction ;
      private string Z435AuditDisplayDescription ;
      private string A435AuditDisplayDescription ;
      private Guid Z415AuditId ;
      private Guid A415AuditId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001D5_A415AuditId ;
      private DateTime[] BC001D5_A416AuditDate ;
      private string[] BC001D5_A417AuditTableName ;
      private string[] BC001D5_A418AuditDescription ;
      private string[] BC001D5_A419AuditShortDescription ;
      private string[] BC001D5_A420GAMUserId ;
      private string[] BC001D5_A421AuditUserName ;
      private string[] BC001D5_A422AuditAction ;
      private Guid[] BC001D5_A11OrganisationId ;
      private Guid[] BC001D4_A11OrganisationId ;
      private Guid[] BC001D6_A415AuditId ;
      private Guid[] BC001D3_A415AuditId ;
      private DateTime[] BC001D3_A416AuditDate ;
      private string[] BC001D3_A417AuditTableName ;
      private string[] BC001D3_A418AuditDescription ;
      private string[] BC001D3_A419AuditShortDescription ;
      private string[] BC001D3_A420GAMUserId ;
      private string[] BC001D3_A421AuditUserName ;
      private string[] BC001D3_A422AuditAction ;
      private Guid[] BC001D3_A11OrganisationId ;
      private Guid[] BC001D2_A415AuditId ;
      private DateTime[] BC001D2_A416AuditDate ;
      private string[] BC001D2_A417AuditTableName ;
      private string[] BC001D2_A418AuditDescription ;
      private string[] BC001D2_A419AuditShortDescription ;
      private string[] BC001D2_A420GAMUserId ;
      private string[] BC001D2_A421AuditUserName ;
      private string[] BC001D2_A422AuditAction ;
      private Guid[] BC001D2_A11OrganisationId ;
      private Guid[] BC001D10_A415AuditId ;
      private DateTime[] BC001D10_A416AuditDate ;
      private string[] BC001D10_A417AuditTableName ;
      private string[] BC001D10_A418AuditDescription ;
      private string[] BC001D10_A419AuditShortDescription ;
      private string[] BC001D10_A420GAMUserId ;
      private string[] BC001D10_A421AuditUserName ;
      private string[] BC001D10_A422AuditAction ;
      private Guid[] BC001D10_A11OrganisationId ;
      private SdtTrn_Audit bcTrn_Audit ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_audit_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_audit_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_audit_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001D2;
       prmBC001D2 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D3;
       prmBC001D3 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D4;
       prmBC001D4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D5;
       prmBC001D5 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D6;
       prmBC001D6 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D7;
       prmBC001D7 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D8;
       prmBC001D8 = new Object[] {
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D9;
       prmBC001D9 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001D10;
       prmBC001D10 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001D2", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId FROM Trn_Audit WHERE AuditId = :AuditId  FOR UPDATE OF Trn_Audit",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001D3", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001D4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001D5", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.GAMUserId, TM1.AuditUserName, TM1.AuditAction, TM1.OrganisationId FROM Trn_Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001D6", "SELECT AuditId FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001D7", "SAVEPOINT gxupdate;INSERT INTO Trn_Audit(AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId) VALUES(:AuditId, :AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :GAMUserId, :AuditUserName, :AuditAction, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001D7)
          ,new CursorDef("BC001D8", "SAVEPOINT gxupdate;UPDATE Trn_Audit SET AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, GAMUserId=:GAMUserId, AuditUserName=:AuditUserName, AuditAction=:AuditAction, OrganisationId=:OrganisationId  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001D8)
          ,new CursorDef("BC001D9", "SAVEPOINT gxupdate;DELETE FROM Trn_Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001D9)
          ,new CursorDef("BC001D10", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.GAMUserId, TM1.AuditUserName, TM1.AuditAction, TM1.OrganisationId FROM Trn_Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D10,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             return;
    }
 }

}

}
