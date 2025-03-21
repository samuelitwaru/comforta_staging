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
   public class trn_bulletinboard_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_bulletinboard_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_bulletinboard_bc( IGxContext context )
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
         ReadRow1T114( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1T114( ) ;
         standaloneModal( ) ;
         AddRow1T114( ) ;
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
            E111T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z574BulletinBoardId = A574BulletinBoardId;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T114( ) ;
            }
            else
            {
               CheckExtendedTable1T114( ) ;
               if ( AnyError == 0 )
               {
                  ZM1T114( 9) ;
                  ZM1T114( 10) ;
               }
               CloseExtendedTableCursors1T114( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV14Insert_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
         }
      }

      protected void E111T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1T114( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z585BulletinBoardBgColorCode = A585BulletinBoardBgColorCode;
            Z586BulletinBoardForm = A586BulletinBoardForm;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z591BulletinBoardName = A591BulletinBoardName;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z13OrganisationName = A13OrganisationName;
            Z591BulletinBoardName = A591BulletinBoardName;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z31LocationName = A31LocationName;
            Z591BulletinBoardName = A591BulletinBoardName;
         }
         if ( GX_JID == -8 )
         {
            Z574BulletinBoardId = A574BulletinBoardId;
            Z585BulletinBoardBgColorCode = A585BulletinBoardBgColorCode;
            Z586BulletinBoardForm = A586BulletinBoardForm;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z13OrganisationName = A13OrganisationName;
            Z31LocationName = A31LocationName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV27Pgmname = "Trn_BulletinBoard_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A574BulletinBoardId) )
         {
            A574BulletinBoardId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1T114( )
      {
         /* Using cursor BC001T6 */
         pr_default.execute(4, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound114 = 1;
            A13OrganisationName = BC001T6_A13OrganisationName[0];
            A31LocationName = BC001T6_A31LocationName[0];
            A585BulletinBoardBgColorCode = BC001T6_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = BC001T6_A586BulletinBoardForm[0];
            A11OrganisationId = BC001T6_A11OrganisationId[0];
            A29LocationId = BC001T6_A29LocationId[0];
            ZM1T114( -8) ;
         }
         pr_default.close(4);
         OnLoadActions1T114( ) ;
      }

      protected void OnLoadActions1T114( )
      {
         A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
      }

      protected void CheckExtendedTable1T114( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001T4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         A13OrganisationName = BC001T4_A13OrganisationName[0];
         pr_default.close(2);
         /* Using cursor BC001T5 */
         pr_default.execute(3, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         A31LocationName = BC001T5_A31LocationName[0];
         pr_default.close(3);
         A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
      }

      protected void CloseExtendedTableCursors1T114( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1T114( )
      {
         /* Using cursor BC001T7 */
         pr_default.execute(5, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound114 = 1;
         }
         else
         {
            RcdFound114 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001T3 */
         pr_default.execute(1, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T114( 8) ;
            RcdFound114 = 1;
            A574BulletinBoardId = BC001T3_A574BulletinBoardId[0];
            A585BulletinBoardBgColorCode = BC001T3_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = BC001T3_A586BulletinBoardForm[0];
            A11OrganisationId = BC001T3_A11OrganisationId[0];
            A29LocationId = BC001T3_A29LocationId[0];
            Z574BulletinBoardId = A574BulletinBoardId;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1T114( ) ;
            if ( AnyError == 1 )
            {
               RcdFound114 = 0;
               InitializeNonKey1T114( ) ;
            }
            Gx_mode = sMode114;
         }
         else
         {
            RcdFound114 = 0;
            InitializeNonKey1T114( ) ;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode114;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T114( ) ;
         if ( RcdFound114 == 0 )
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
         CONFIRM_1T0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1T114( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001T2 */
            pr_default.execute(0, new Object[] {A574BulletinBoardId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_BulletinBoard"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z585BulletinBoardBgColorCode, BC001T2_A585BulletinBoardBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z586BulletinBoardForm, BC001T2_A586BulletinBoardForm[0]) != 0 ) || ( Z11OrganisationId != BC001T2_A11OrganisationId[0] ) || ( Z29LocationId != BC001T2_A29LocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_BulletinBoard"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T114( )
      {
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T114( 0) ;
            CheckOptimisticConcurrency1T114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T8 */
                     pr_default.execute(6, new Object[] {A574BulletinBoardId, A585BulletinBoardBgColorCode, A586BulletinBoardForm, A11OrganisationId, A29LocationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
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
               Load1T114( ) ;
            }
            EndLevel1T114( ) ;
         }
         CloseExtendedTableCursors1T114( ) ;
      }

      protected void Update1T114( )
      {
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T9 */
                     pr_default.execute(7, new Object[] {A585BulletinBoardBgColorCode, A586BulletinBoardForm, A11OrganisationId, A29LocationId, A574BulletinBoardId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_BulletinBoard"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T114( ) ;
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
            EndLevel1T114( ) ;
         }
         CloseExtendedTableCursors1T114( ) ;
      }

      protected void DeferredUpdate1T114( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T114( ) ;
            AfterConfirm1T114( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T114( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001T10 */
                  pr_default.execute(8, new Object[] {A574BulletinBoardId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
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
         sMode114 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1T114( ) ;
         Gx_mode = sMode114;
      }

      protected void OnDeleteControls1T114( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001T11 */
            pr_default.execute(9, new Object[] {A11OrganisationId});
            A13OrganisationName = BC001T11_A13OrganisationName[0];
            pr_default.close(9);
            /* Using cursor BC001T12 */
            pr_default.execute(10, new Object[] {A29LocationId, A11OrganisationId});
            A31LocationName = BC001T12_A31LocationName[0];
            pr_default.close(10);
            A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001T13 */
            pr_default.execute(11, new Object[] {A574BulletinBoardId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Memo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1T114( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T114( ) ;
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

      public void ScanKeyStart1T114( )
      {
         /* Scan By routine */
         /* Using cursor BC001T14 */
         pr_default.execute(12, new Object[] {A574BulletinBoardId});
         RcdFound114 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound114 = 1;
            A574BulletinBoardId = BC001T14_A574BulletinBoardId[0];
            A13OrganisationName = BC001T14_A13OrganisationName[0];
            A31LocationName = BC001T14_A31LocationName[0];
            A585BulletinBoardBgColorCode = BC001T14_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = BC001T14_A586BulletinBoardForm[0];
            A11OrganisationId = BC001T14_A11OrganisationId[0];
            A29LocationId = BC001T14_A29LocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1T114( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound114 = 0;
         ScanKeyLoad1T114( ) ;
      }

      protected void ScanKeyLoad1T114( )
      {
         sMode114 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound114 = 1;
            A574BulletinBoardId = BC001T14_A574BulletinBoardId[0];
            A13OrganisationName = BC001T14_A13OrganisationName[0];
            A31LocationName = BC001T14_A31LocationName[0];
            A585BulletinBoardBgColorCode = BC001T14_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = BC001T14_A586BulletinBoardForm[0];
            A11OrganisationId = BC001T14_A11OrganisationId[0];
            A29LocationId = BC001T14_A29LocationId[0];
         }
         Gx_mode = sMode114;
      }

      protected void ScanKeyEnd1T114( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1T114( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T114( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T114( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T114( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T114( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T114( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T114( )
      {
      }

      protected void send_integrity_lvl_hashes1T114( )
      {
      }

      protected void AddRow1T114( )
      {
         VarsToRow114( bcTrn_BulletinBoard) ;
      }

      protected void ReadRow1T114( )
      {
         RowToVars114( bcTrn_BulletinBoard, 1) ;
      }

      protected void InitializeNonKey1T114( )
      {
         A591BulletinBoardName = "";
         A11OrganisationId = Guid.Empty;
         A13OrganisationName = "";
         A29LocationId = Guid.Empty;
         A31LocationName = "";
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         Z585BulletinBoardBgColorCode = "";
         Z586BulletinBoardForm = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
      }

      protected void InitAll1T114( )
      {
         A574BulletinBoardId = Guid.NewGuid( );
         InitializeNonKey1T114( ) ;
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

      public void VarsToRow114( SdtTrn_BulletinBoard obj114 )
      {
         obj114.gxTpr_Mode = Gx_mode;
         obj114.gxTpr_Bulletinboardname = A591BulletinBoardName;
         obj114.gxTpr_Organisationid = A11OrganisationId;
         obj114.gxTpr_Organisationname = A13OrganisationName;
         obj114.gxTpr_Locationid = A29LocationId;
         obj114.gxTpr_Locationname = A31LocationName;
         obj114.gxTpr_Bulletinboardbgcolorcode = A585BulletinBoardBgColorCode;
         obj114.gxTpr_Bulletinboardform = A586BulletinBoardForm;
         obj114.gxTpr_Bulletinboardid = A574BulletinBoardId;
         obj114.gxTpr_Bulletinboardid_Z = Z574BulletinBoardId;
         obj114.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj114.gxTpr_Organisationname_Z = Z13OrganisationName;
         obj114.gxTpr_Locationid_Z = Z29LocationId;
         obj114.gxTpr_Locationname_Z = Z31LocationName;
         obj114.gxTpr_Bulletinboardname_Z = Z591BulletinBoardName;
         obj114.gxTpr_Bulletinboardbgcolorcode_Z = Z585BulletinBoardBgColorCode;
         obj114.gxTpr_Bulletinboardform_Z = Z586BulletinBoardForm;
         obj114.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow114( SdtTrn_BulletinBoard obj114 )
      {
         obj114.gxTpr_Bulletinboardid = A574BulletinBoardId;
         return  ;
      }

      public void RowToVars114( SdtTrn_BulletinBoard obj114 ,
                                int forceLoad )
      {
         Gx_mode = obj114.gxTpr_Mode;
         A591BulletinBoardName = obj114.gxTpr_Bulletinboardname;
         A11OrganisationId = obj114.gxTpr_Organisationid;
         A13OrganisationName = obj114.gxTpr_Organisationname;
         A29LocationId = obj114.gxTpr_Locationid;
         A31LocationName = obj114.gxTpr_Locationname;
         A585BulletinBoardBgColorCode = obj114.gxTpr_Bulletinboardbgcolorcode;
         A586BulletinBoardForm = obj114.gxTpr_Bulletinboardform;
         A574BulletinBoardId = obj114.gxTpr_Bulletinboardid;
         Z574BulletinBoardId = obj114.gxTpr_Bulletinboardid_Z;
         Z11OrganisationId = obj114.gxTpr_Organisationid_Z;
         Z13OrganisationName = obj114.gxTpr_Organisationname_Z;
         Z29LocationId = obj114.gxTpr_Locationid_Z;
         Z31LocationName = obj114.gxTpr_Locationname_Z;
         Z591BulletinBoardName = obj114.gxTpr_Bulletinboardname_Z;
         Z585BulletinBoardBgColorCode = obj114.gxTpr_Bulletinboardbgcolorcode_Z;
         Z586BulletinBoardForm = obj114.gxTpr_Bulletinboardform_Z;
         Gx_mode = obj114.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A574BulletinBoardId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1T114( ) ;
         ScanKeyStart1T114( ) ;
         if ( RcdFound114 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z574BulletinBoardId = A574BulletinBoardId;
         }
         ZM1T114( -8) ;
         OnLoadActions1T114( ) ;
         AddRow1T114( ) ;
         ScanKeyEnd1T114( ) ;
         if ( RcdFound114 == 0 )
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
         RowToVars114( bcTrn_BulletinBoard, 0) ;
         ScanKeyStart1T114( ) ;
         if ( RcdFound114 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z574BulletinBoardId = A574BulletinBoardId;
         }
         ZM1T114( -8) ;
         OnLoadActions1T114( ) ;
         AddRow1T114( ) ;
         ScanKeyEnd1T114( ) ;
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1T114( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1T114( ) ;
         }
         else
         {
            if ( RcdFound114 == 1 )
            {
               if ( A574BulletinBoardId != Z574BulletinBoardId )
               {
                  A574BulletinBoardId = Z574BulletinBoardId;
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
                  Update1T114( ) ;
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
                  if ( A574BulletinBoardId != Z574BulletinBoardId )
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
                        Insert1T114( ) ;
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
                        Insert1T114( ) ;
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
         RowToVars114( bcTrn_BulletinBoard, 1) ;
         SaveImpl( ) ;
         VarsToRow114( bcTrn_BulletinBoard) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars114( bcTrn_BulletinBoard, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T114( ) ;
         AfterTrn( ) ;
         VarsToRow114( bcTrn_BulletinBoard) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow114( bcTrn_BulletinBoard) ;
         }
         else
         {
            SdtTrn_BulletinBoard auxBC = new SdtTrn_BulletinBoard(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A574BulletinBoardId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_BulletinBoard);
               auxBC.Save();
               bcTrn_BulletinBoard.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars114( bcTrn_BulletinBoard, 1) ;
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
         RowToVars114( bcTrn_BulletinBoard, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T114( ) ;
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
               VarsToRow114( bcTrn_BulletinBoard) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow114( bcTrn_BulletinBoard) ;
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
         RowToVars114( bcTrn_BulletinBoard, 0) ;
         GetKey1T114( ) ;
         if ( RcdFound114 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A574BulletinBoardId != Z574BulletinBoardId )
            {
               A574BulletinBoardId = Z574BulletinBoardId;
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
            if ( A574BulletinBoardId != Z574BulletinBoardId )
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
         context.RollbackDataStores("trn_bulletinboard_bc",pr_default);
         VarsToRow114( bcTrn_BulletinBoard) ;
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
         Gx_mode = bcTrn_BulletinBoard.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_BulletinBoard.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_BulletinBoard )
         {
            bcTrn_BulletinBoard = (SdtTrn_BulletinBoard)(sdt);
            if ( StringUtil.StrCmp(bcTrn_BulletinBoard.gxTpr_Mode, "") == 0 )
            {
               bcTrn_BulletinBoard.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow114( bcTrn_BulletinBoard) ;
            }
            else
            {
               RowToVars114( bcTrn_BulletinBoard, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_BulletinBoard.gxTpr_Mode, "") == 0 )
            {
               bcTrn_BulletinBoard.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars114( bcTrn_BulletinBoard, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_BulletinBoard Trn_BulletinBoard_BC
      {
         get {
            return bcTrn_BulletinBoard ;
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
            return "trn_bulletinboard_Execute" ;
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
         pr_default.close(9);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z574BulletinBoardId = Guid.Empty;
         A574BulletinBoardId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV27Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationId = Guid.Empty;
         AV14Insert_LocationId = Guid.Empty;
         Z585BulletinBoardBgColorCode = "";
         A585BulletinBoardBgColorCode = "";
         Z586BulletinBoardForm = "";
         A586BulletinBoardForm = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z591BulletinBoardName = "";
         A591BulletinBoardName = "";
         Z13OrganisationName = "";
         A13OrganisationName = "";
         Z31LocationName = "";
         A31LocationName = "";
         BC001T6_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         BC001T6_A13OrganisationName = new string[] {""} ;
         BC001T6_A31LocationName = new string[] {""} ;
         BC001T6_A585BulletinBoardBgColorCode = new string[] {""} ;
         BC001T6_A586BulletinBoardForm = new string[] {""} ;
         BC001T6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001T6_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001T4_A13OrganisationName = new string[] {""} ;
         BC001T5_A31LocationName = new string[] {""} ;
         BC001T7_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         BC001T3_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         BC001T3_A585BulletinBoardBgColorCode = new string[] {""} ;
         BC001T3_A586BulletinBoardForm = new string[] {""} ;
         BC001T3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001T3_A29LocationId = new Guid[] {Guid.Empty} ;
         sMode114 = "";
         BC001T2_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         BC001T2_A585BulletinBoardBgColorCode = new string[] {""} ;
         BC001T2_A586BulletinBoardForm = new string[] {""} ;
         BC001T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001T2_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001T11_A13OrganisationName = new string[] {""} ;
         BC001T12_A31LocationName = new string[] {""} ;
         BC001T13_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001T14_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         BC001T14_A13OrganisationName = new string[] {""} ;
         BC001T14_A31LocationName = new string[] {""} ;
         BC001T14_A585BulletinBoardBgColorCode = new string[] {""} ;
         BC001T14_A586BulletinBoardForm = new string[] {""} ;
         BC001T14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001T14_A29LocationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard_bc__default(),
            new Object[][] {
                new Object[] {
               BC001T2_A574BulletinBoardId, BC001T2_A585BulletinBoardBgColorCode, BC001T2_A586BulletinBoardForm, BC001T2_A11OrganisationId, BC001T2_A29LocationId
               }
               , new Object[] {
               BC001T3_A574BulletinBoardId, BC001T3_A585BulletinBoardBgColorCode, BC001T3_A586BulletinBoardForm, BC001T3_A11OrganisationId, BC001T3_A29LocationId
               }
               , new Object[] {
               BC001T4_A13OrganisationName
               }
               , new Object[] {
               BC001T5_A31LocationName
               }
               , new Object[] {
               BC001T6_A574BulletinBoardId, BC001T6_A13OrganisationName, BC001T6_A31LocationName, BC001T6_A585BulletinBoardBgColorCode, BC001T6_A586BulletinBoardForm, BC001T6_A11OrganisationId, BC001T6_A29LocationId
               }
               , new Object[] {
               BC001T7_A574BulletinBoardId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001T11_A13OrganisationName
               }
               , new Object[] {
               BC001T12_A31LocationName
               }
               , new Object[] {
               BC001T13_A575MemoId
               }
               , new Object[] {
               BC001T14_A574BulletinBoardId, BC001T14_A13OrganisationName, BC001T14_A31LocationName, BC001T14_A585BulletinBoardBgColorCode, BC001T14_A586BulletinBoardForm, BC001T14_A11OrganisationId, BC001T14_A29LocationId
               }
            }
         );
         Z574BulletinBoardId = Guid.NewGuid( );
         A574BulletinBoardId = Guid.NewGuid( );
         AV27Pgmname = "Trn_BulletinBoard_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121T2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound114 ;
      private int trnEnded ;
      private int AV28GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV27Pgmname ;
      private string Z586BulletinBoardForm ;
      private string A586BulletinBoardForm ;
      private string sMode114 ;
      private bool returnInSub ;
      private string Z585BulletinBoardBgColorCode ;
      private string A585BulletinBoardBgColorCode ;
      private string Z591BulletinBoardName ;
      private string A591BulletinBoardName ;
      private string Z13OrganisationName ;
      private string A13OrganisationName ;
      private string Z31LocationName ;
      private string A31LocationName ;
      private Guid Z574BulletinBoardId ;
      private Guid A574BulletinBoardId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid AV14Insert_LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001T6_A574BulletinBoardId ;
      private string[] BC001T6_A13OrganisationName ;
      private string[] BC001T6_A31LocationName ;
      private string[] BC001T6_A585BulletinBoardBgColorCode ;
      private string[] BC001T6_A586BulletinBoardForm ;
      private Guid[] BC001T6_A11OrganisationId ;
      private Guid[] BC001T6_A29LocationId ;
      private string[] BC001T4_A13OrganisationName ;
      private string[] BC001T5_A31LocationName ;
      private Guid[] BC001T7_A574BulletinBoardId ;
      private Guid[] BC001T3_A574BulletinBoardId ;
      private string[] BC001T3_A585BulletinBoardBgColorCode ;
      private string[] BC001T3_A586BulletinBoardForm ;
      private Guid[] BC001T3_A11OrganisationId ;
      private Guid[] BC001T3_A29LocationId ;
      private Guid[] BC001T2_A574BulletinBoardId ;
      private string[] BC001T2_A585BulletinBoardBgColorCode ;
      private string[] BC001T2_A586BulletinBoardForm ;
      private Guid[] BC001T2_A11OrganisationId ;
      private Guid[] BC001T2_A29LocationId ;
      private string[] BC001T11_A13OrganisationName ;
      private string[] BC001T12_A31LocationName ;
      private Guid[] BC001T13_A575MemoId ;
      private Guid[] BC001T14_A574BulletinBoardId ;
      private string[] BC001T14_A13OrganisationName ;
      private string[] BC001T14_A31LocationName ;
      private string[] BC001T14_A585BulletinBoardBgColorCode ;
      private string[] BC001T14_A586BulletinBoardForm ;
      private Guid[] BC001T14_A11OrganisationId ;
      private Guid[] BC001T14_A29LocationId ;
      private SdtTrn_BulletinBoard bcTrn_BulletinBoard ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_bulletinboard_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_bulletinboard_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_bulletinboard_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001T2;
       prmBC001T2 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T3;
       prmBC001T3 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T4;
       prmBC001T4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T5;
       prmBC001T5 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T6;
       prmBC001T6 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T7;
       prmBC001T7 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T8;
       prmBC001T8 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("BulletinBoardBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("BulletinBoardForm",GXType.Char,20,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T9;
       prmBC001T9 = new Object[] {
       new ParDef("BulletinBoardBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("BulletinBoardForm",GXType.Char,20,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T10;
       prmBC001T10 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T11;
       prmBC001T11 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T12;
       prmBC001T12 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T13;
       prmBC001T13 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T14;
       prmBC001T14 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001T2", "SELECT BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId  FOR UPDATE OF Trn_BulletinBoard",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T3", "SELECT BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T4", "SELECT OrganisationName FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T5", "SELECT LocationName FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T6", "SELECT TM1.BulletinBoardId, T2.OrganisationName, T3.LocationName, TM1.BulletinBoardBgColorCode, TM1.BulletinBoardForm, TM1.OrganisationId, TM1.LocationId FROM ((Trn_BulletinBoard TM1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = TM1.OrganisationId) INNER JOIN Trn_Location T3 ON T3.LocationId = TM1.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.BulletinBoardId = :BulletinBoardId ORDER BY TM1.BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T7", "SELECT BulletinBoardId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T8", "SAVEPOINT gxupdate;INSERT INTO Trn_BulletinBoard(BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId) VALUES(:BulletinBoardId, :BulletinBoardBgColorCode, :BulletinBoardForm, :OrganisationId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001T8)
          ,new CursorDef("BC001T9", "SAVEPOINT gxupdate;UPDATE Trn_BulletinBoard SET BulletinBoardBgColorCode=:BulletinBoardBgColorCode, BulletinBoardForm=:BulletinBoardForm, OrganisationId=:OrganisationId, LocationId=:LocationId  WHERE BulletinBoardId = :BulletinBoardId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T9)
          ,new CursorDef("BC001T10", "SAVEPOINT gxupdate;DELETE FROM Trn_BulletinBoard  WHERE BulletinBoardId = :BulletinBoardId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T10)
          ,new CursorDef("BC001T11", "SELECT OrganisationName FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T12", "SELECT LocationName FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T13", "SELECT MemoId FROM Trn_Memo WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001T14", "SELECT TM1.BulletinBoardId, T2.OrganisationName, T3.LocationName, TM1.BulletinBoardBgColorCode, TM1.BulletinBoardForm, TM1.OrganisationId, TM1.LocationId FROM ((Trn_BulletinBoard TM1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = TM1.OrganisationId) INNER JOIN Trn_Location T3 ON T3.LocationId = TM1.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.BulletinBoardId = :BulletinBoardId ORDER BY TM1.BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T14,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             return;
    }
 }

}

}
