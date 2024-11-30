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
   public class trn_residentnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_residentnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentnotification_bc( IGxContext context )
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
         ReadRow1J96( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1J96( ) ;
         standaloneModal( ) ;
         AddRow1J96( ) ;
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
               Z497ResidentNotificationId = A497ResidentNotificationId;
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

      protected void CONFIRM_1J0( )
      {
         BeforeValidate1J96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1J96( ) ;
            }
            else
            {
               CheckExtendedTable1J96( ) ;
               if ( AnyError == 0 )
               {
                  ZM1J96( 7) ;
               }
               CloseExtendedTableCursors1J96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1J96( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z62ResidentId = A62ResidentId;
            Z498AppNotificationId = A498AppNotificationId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -6 )
         {
            Z497ResidentNotificationId = A497ResidentNotificationId;
            Z62ResidentId = A62ResidentId;
            Z498AppNotificationId = A498AppNotificationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) )
         {
            A62ResidentId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (Guid.Empty==A497ResidentNotificationId) )
         {
            A497ResidentNotificationId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1J96( )
      {
         /* Using cursor BC001J5 */
         pr_default.execute(3, new Object[] {A497ResidentNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound96 = 1;
            A62ResidentId = BC001J5_A62ResidentId[0];
            A498AppNotificationId = BC001J5_A498AppNotificationId[0];
            ZM1J96( -6) ;
         }
         pr_default.close(3);
         OnLoadActions1J96( ) ;
      }

      protected void OnLoadActions1J96( )
      {
      }

      protected void CheckExtendedTable1J96( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001J4 */
         pr_default.execute(2, new Object[] {A498AppNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_AppNotification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1J96( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1J96( )
      {
         /* Using cursor BC001J6 */
         pr_default.execute(4, new Object[] {A497ResidentNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001J3 */
         pr_default.execute(1, new Object[] {A497ResidentNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1J96( 6) ;
            RcdFound96 = 1;
            A497ResidentNotificationId = BC001J3_A497ResidentNotificationId[0];
            A62ResidentId = BC001J3_A62ResidentId[0];
            A498AppNotificationId = BC001J3_A498AppNotificationId[0];
            Z497ResidentNotificationId = A497ResidentNotificationId;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1J96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey1J96( ) ;
            }
            Gx_mode = sMode96;
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey1J96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode96;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1J96( ) ;
         if ( RcdFound96 == 0 )
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
         CONFIRM_1J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1J96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001J2 */
            pr_default.execute(0, new Object[] {A497ResidentNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z62ResidentId != BC001J2_A62ResidentId[0] ) || ( Z498AppNotificationId != BC001J2_A498AppNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J96( )
      {
         BeforeValidate1J96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J96( 0) ;
            CheckOptimisticConcurrency1J96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001J7 */
                     pr_default.execute(5, new Object[] {A497ResidentNotificationId, A62ResidentId, A498AppNotificationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
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
               Load1J96( ) ;
            }
            EndLevel1J96( ) ;
         }
         CloseExtendedTableCursors1J96( ) ;
      }

      protected void Update1J96( )
      {
         BeforeValidate1J96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1J96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001J8 */
                     pr_default.execute(6, new Object[] {A62ResidentId, A498AppNotificationId, A497ResidentNotificationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1J96( ) ;
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
            EndLevel1J96( ) ;
         }
         CloseExtendedTableCursors1J96( ) ;
      }

      protected void DeferredUpdate1J96( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1J96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J96( ) ;
            AfterConfirm1J96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001J9 */
                  pr_default.execute(7, new Object[] {A497ResidentNotificationId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1J96( ) ;
         Gx_mode = sMode96;
      }

      protected void OnDeleteControls1J96( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1J96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1J96( ) ;
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

      public void ScanKeyStart1J96( )
      {
         /* Using cursor BC001J10 */
         pr_default.execute(8, new Object[] {A497ResidentNotificationId});
         RcdFound96 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound96 = 1;
            A497ResidentNotificationId = BC001J10_A497ResidentNotificationId[0];
            A62ResidentId = BC001J10_A62ResidentId[0];
            A498AppNotificationId = BC001J10_A498AppNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1J96( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound96 = 0;
         ScanKeyLoad1J96( ) ;
      }

      protected void ScanKeyLoad1J96( )
      {
         sMode96 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound96 = 1;
            A497ResidentNotificationId = BC001J10_A497ResidentNotificationId[0];
            A62ResidentId = BC001J10_A62ResidentId[0];
            A498AppNotificationId = BC001J10_A498AppNotificationId[0];
         }
         Gx_mode = sMode96;
      }

      protected void ScanKeyEnd1J96( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1J96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J96( )
      {
      }

      protected void send_integrity_lvl_hashes1J96( )
      {
      }

      protected void AddRow1J96( )
      {
         VarsToRow96( bcTrn_ResidentNotification) ;
      }

      protected void ReadRow1J96( )
      {
         RowToVars96( bcTrn_ResidentNotification, 1) ;
      }

      protected void InitializeNonKey1J96( )
      {
         A498AppNotificationId = Guid.Empty;
         A62ResidentId = Guid.NewGuid( );
         Z62ResidentId = Guid.Empty;
         Z498AppNotificationId = Guid.Empty;
      }

      protected void InitAll1J96( )
      {
         A497ResidentNotificationId = Guid.NewGuid( );
         InitializeNonKey1J96( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A62ResidentId = i62ResidentId;
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

      public void VarsToRow96( SdtTrn_ResidentNotification obj96 )
      {
         obj96.gxTpr_Mode = Gx_mode;
         obj96.gxTpr_Appnotificationid = A498AppNotificationId;
         obj96.gxTpr_Residentid = A62ResidentId;
         obj96.gxTpr_Residentnotificationid = A497ResidentNotificationId;
         obj96.gxTpr_Residentnotificationid_Z = Z497ResidentNotificationId;
         obj96.gxTpr_Appnotificationid_Z = Z498AppNotificationId;
         obj96.gxTpr_Residentid_Z = Z62ResidentId;
         obj96.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow96( SdtTrn_ResidentNotification obj96 )
      {
         obj96.gxTpr_Residentnotificationid = A497ResidentNotificationId;
         return  ;
      }

      public void RowToVars96( SdtTrn_ResidentNotification obj96 ,
                               int forceLoad )
      {
         Gx_mode = obj96.gxTpr_Mode;
         A498AppNotificationId = obj96.gxTpr_Appnotificationid;
         A62ResidentId = obj96.gxTpr_Residentid;
         A497ResidentNotificationId = obj96.gxTpr_Residentnotificationid;
         Z497ResidentNotificationId = obj96.gxTpr_Residentnotificationid_Z;
         Z498AppNotificationId = obj96.gxTpr_Appnotificationid_Z;
         Z62ResidentId = obj96.gxTpr_Residentid_Z;
         Gx_mode = obj96.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A497ResidentNotificationId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1J96( ) ;
         ScanKeyStart1J96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z497ResidentNotificationId = A497ResidentNotificationId;
         }
         ZM1J96( -6) ;
         OnLoadActions1J96( ) ;
         AddRow1J96( ) ;
         ScanKeyEnd1J96( ) ;
         if ( RcdFound96 == 0 )
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
         RowToVars96( bcTrn_ResidentNotification, 0) ;
         ScanKeyStart1J96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z497ResidentNotificationId = A497ResidentNotificationId;
         }
         ZM1J96( -6) ;
         OnLoadActions1J96( ) ;
         AddRow1J96( ) ;
         ScanKeyEnd1J96( ) ;
         if ( RcdFound96 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1J96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1J96( ) ;
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( A497ResidentNotificationId != Z497ResidentNotificationId )
               {
                  A497ResidentNotificationId = Z497ResidentNotificationId;
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
                  Update1J96( ) ;
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
                  if ( A497ResidentNotificationId != Z497ResidentNotificationId )
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
                        Insert1J96( ) ;
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
                        Insert1J96( ) ;
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
         RowToVars96( bcTrn_ResidentNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow96( bcTrn_ResidentNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars96( bcTrn_ResidentNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1J96( ) ;
         AfterTrn( ) ;
         VarsToRow96( bcTrn_ResidentNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow96( bcTrn_ResidentNotification) ;
         }
         else
         {
            SdtTrn_ResidentNotification auxBC = new SdtTrn_ResidentNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A497ResidentNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ResidentNotification);
               auxBC.Save();
               bcTrn_ResidentNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars96( bcTrn_ResidentNotification, 1) ;
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
         RowToVars96( bcTrn_ResidentNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1J96( ) ;
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
               VarsToRow96( bcTrn_ResidentNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow96( bcTrn_ResidentNotification) ;
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
         RowToVars96( bcTrn_ResidentNotification, 0) ;
         GetKey1J96( ) ;
         if ( RcdFound96 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A497ResidentNotificationId != Z497ResidentNotificationId )
            {
               A497ResidentNotificationId = Z497ResidentNotificationId;
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
            if ( A497ResidentNotificationId != Z497ResidentNotificationId )
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
         context.RollbackDataStores("trn_residentnotification_bc",pr_default);
         VarsToRow96( bcTrn_ResidentNotification) ;
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
         Gx_mode = bcTrn_ResidentNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ResidentNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ResidentNotification )
         {
            bcTrn_ResidentNotification = (SdtTrn_ResidentNotification)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ResidentNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow96( bcTrn_ResidentNotification) ;
            }
            else
            {
               RowToVars96( bcTrn_ResidentNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ResidentNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars96( bcTrn_ResidentNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ResidentNotification Trn_ResidentNotification_BC
      {
         get {
            return bcTrn_ResidentNotification ;
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
            return "trn_residentnotification_Execute" ;
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
         Z497ResidentNotificationId = Guid.Empty;
         A497ResidentNotificationId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z498AppNotificationId = Guid.Empty;
         A498AppNotificationId = Guid.Empty;
         BC001J5_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001J5_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001J5_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001J4_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001J6_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001J3_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001J3_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001J3_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         sMode96 = "";
         BC001J2_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001J2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001J2_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001J10_A497ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001J10_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001J10_A498AppNotificationId = new Guid[] {Guid.Empty} ;
         i62ResidentId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001J2_A497ResidentNotificationId, BC001J2_A62ResidentId, BC001J2_A498AppNotificationId
               }
               , new Object[] {
               BC001J3_A497ResidentNotificationId, BC001J3_A62ResidentId, BC001J3_A498AppNotificationId
               }
               , new Object[] {
               BC001J4_A498AppNotificationId
               }
               , new Object[] {
               BC001J5_A497ResidentNotificationId, BC001J5_A62ResidentId, BC001J5_A498AppNotificationId
               }
               , new Object[] {
               BC001J6_A497ResidentNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001J10_A497ResidentNotificationId, BC001J10_A62ResidentId, BC001J10_A498AppNotificationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         i62ResidentId = Guid.NewGuid( );
         Z497ResidentNotificationId = Guid.NewGuid( );
         A497ResidentNotificationId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound96 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode96 ;
      private Guid Z497ResidentNotificationId ;
      private Guid A497ResidentNotificationId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z498AppNotificationId ;
      private Guid A498AppNotificationId ;
      private Guid i62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001J5_A497ResidentNotificationId ;
      private Guid[] BC001J5_A62ResidentId ;
      private Guid[] BC001J5_A498AppNotificationId ;
      private Guid[] BC001J4_A498AppNotificationId ;
      private Guid[] BC001J6_A497ResidentNotificationId ;
      private Guid[] BC001J3_A497ResidentNotificationId ;
      private Guid[] BC001J3_A62ResidentId ;
      private Guid[] BC001J3_A498AppNotificationId ;
      private Guid[] BC001J2_A497ResidentNotificationId ;
      private Guid[] BC001J2_A62ResidentId ;
      private Guid[] BC001J2_A498AppNotificationId ;
      private Guid[] BC001J10_A497ResidentNotificationId ;
      private Guid[] BC001J10_A62ResidentId ;
      private Guid[] BC001J10_A498AppNotificationId ;
      private SdtTrn_ResidentNotification bcTrn_ResidentNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001J2;
       prmBC001J2 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J3;
       prmBC001J3 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J4;
       prmBC001J4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J5;
       prmBC001J5 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J6;
       prmBC001J6 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J7;
       prmBC001J7 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J8;
       prmBC001J8 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J9;
       prmBC001J9 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001J10;
       prmBC001J10 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001J2", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId  FOR UPDATE OF Trn_ResidentNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001J3", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001J4", "SELECT AppNotificationId FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001J5", "SELECT TM1.ResidentNotificationId, TM1.ResidentId, TM1.AppNotificationId FROM Trn_ResidentNotification TM1 WHERE TM1.ResidentNotificationId = :ResidentNotificationId ORDER BY TM1.ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001J6", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001J7", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNotification(ResidentNotificationId, ResidentId, AppNotificationId) VALUES(:ResidentNotificationId, :ResidentId, :AppNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J7)
          ,new CursorDef("BC001J8", "SAVEPOINT gxupdate;UPDATE Trn_ResidentNotification SET ResidentId=:ResidentId, AppNotificationId=:AppNotificationId  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J8)
          ,new CursorDef("BC001J9", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNotification  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J9)
          ,new CursorDef("BC001J10", "SELECT TM1.ResidentNotificationId, TM1.ResidentId, TM1.AppNotificationId FROM Trn_ResidentNotification TM1 WHERE TM1.ResidentNotificationId = :ResidentNotificationId ORDER BY TM1.ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J10,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
