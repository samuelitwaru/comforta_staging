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
   public class trn_device_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_device_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_device_bc( IGxContext context )
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
         ReadRow1A78( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1A78( ) ;
         standaloneModal( ) ;
         AddRow1A78( ) ;
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
               Z361DeviceId = A361DeviceId;
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

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A78( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A78( ) ;
            }
            else
            {
               CheckExtendedTable1A78( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1A78( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1A78( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z362DeviceType = A362DeviceType;
            Z363DeviceToken = A363DeviceToken;
            Z364DeviceName = A364DeviceName;
            Z365DeviceUserId = A365DeviceUserId;
         }
         if ( GX_JID == -2 )
         {
            Z361DeviceId = A361DeviceId;
            Z362DeviceType = A362DeviceType;
            Z363DeviceToken = A363DeviceToken;
            Z364DeviceName = A364DeviceName;
            Z365DeviceUserId = A365DeviceUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1A78( )
      {
         /* Using cursor BC001A4 */
         pr_default.execute(2, new Object[] {A361DeviceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound78 = 1;
            A362DeviceType = BC001A4_A362DeviceType[0];
            A363DeviceToken = BC001A4_A363DeviceToken[0];
            A364DeviceName = BC001A4_A364DeviceName[0];
            A365DeviceUserId = BC001A4_A365DeviceUserId[0];
            ZM1A78( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1A78( ) ;
      }

      protected void OnLoadActions1A78( )
      {
      }

      protected void CheckExtendedTable1A78( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A362DeviceType == 0 ) || ( A362DeviceType == 1 ) || ( A362DeviceType == 2 ) || ( A362DeviceType == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Device Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1A78( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1A78( )
      {
         /* Using cursor BC001A5 */
         pr_default.execute(3, new Object[] {A361DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001A3 */
         pr_default.execute(1, new Object[] {A361DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A78( 2) ;
            RcdFound78 = 1;
            A361DeviceId = BC001A3_A361DeviceId[0];
            A362DeviceType = BC001A3_A362DeviceType[0];
            A363DeviceToken = BC001A3_A363DeviceToken[0];
            A364DeviceName = BC001A3_A364DeviceName[0];
            A365DeviceUserId = BC001A3_A365DeviceUserId[0];
            Z361DeviceId = A361DeviceId;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1A78( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey1A78( ) ;
            }
            Gx_mode = sMode78;
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey1A78( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode78;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A78( ) ;
         if ( RcdFound78 == 0 )
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
         CONFIRM_1A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1A78( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001A2 */
            pr_default.execute(0, new Object[] {A361DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z362DeviceType != BC001A2_A362DeviceType[0] ) || ( StringUtil.StrCmp(Z363DeviceToken, BC001A2_A363DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z364DeviceName, BC001A2_A364DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z365DeviceUserId, BC001A2_A365DeviceUserId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A78( )
      {
         BeforeValidate1A78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A78( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A78( 0) ;
            CheckOptimisticConcurrency1A78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A6 */
                     pr_default.execute(4, new Object[] {A361DeviceId, A362DeviceType, A363DeviceToken, A364DeviceName, A365DeviceUserId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load1A78( ) ;
            }
            EndLevel1A78( ) ;
         }
         CloseExtendedTableCursors1A78( ) ;
      }

      protected void Update1A78( )
      {
         BeforeValidate1A78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A78( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A7 */
                     pr_default.execute(5, new Object[] {A362DeviceType, A363DeviceToken, A364DeviceName, A365DeviceUserId, A361DeviceId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A78( ) ;
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
            EndLevel1A78( ) ;
         }
         CloseExtendedTableCursors1A78( ) ;
      }

      protected void DeferredUpdate1A78( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1A78( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A78( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A78( ) ;
            AfterConfirm1A78( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A78( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001A8 */
                  pr_default.execute(6, new Object[] {A361DeviceId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1A78( ) ;
         Gx_mode = sMode78;
      }

      protected void OnDeleteControls1A78( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1A78( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A78( ) ;
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

      public void ScanKeyStart1A78( )
      {
         /* Using cursor BC001A9 */
         pr_default.execute(7, new Object[] {A361DeviceId});
         RcdFound78 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound78 = 1;
            A361DeviceId = BC001A9_A361DeviceId[0];
            A362DeviceType = BC001A9_A362DeviceType[0];
            A363DeviceToken = BC001A9_A363DeviceToken[0];
            A364DeviceName = BC001A9_A364DeviceName[0];
            A365DeviceUserId = BC001A9_A365DeviceUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1A78( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound78 = 0;
         ScanKeyLoad1A78( ) ;
      }

      protected void ScanKeyLoad1A78( )
      {
         sMode78 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound78 = 1;
            A361DeviceId = BC001A9_A361DeviceId[0];
            A362DeviceType = BC001A9_A362DeviceType[0];
            A363DeviceToken = BC001A9_A363DeviceToken[0];
            A364DeviceName = BC001A9_A364DeviceName[0];
            A365DeviceUserId = BC001A9_A365DeviceUserId[0];
         }
         Gx_mode = sMode78;
      }

      protected void ScanKeyEnd1A78( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1A78( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A78( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A78( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A78( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A78( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A78( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A78( )
      {
      }

      protected void send_integrity_lvl_hashes1A78( )
      {
      }

      protected void AddRow1A78( )
      {
         VarsToRow78( bcTrn_Device) ;
      }

      protected void ReadRow1A78( )
      {
         RowToVars78( bcTrn_Device, 1) ;
      }

      protected void InitializeNonKey1A78( )
      {
         A362DeviceType = 0;
         A363DeviceToken = "";
         A364DeviceName = "";
         A365DeviceUserId = "";
         Z362DeviceType = 0;
         Z363DeviceToken = "";
         Z364DeviceName = "";
         Z365DeviceUserId = "";
      }

      protected void InitAll1A78( )
      {
         A361DeviceId = "";
         InitializeNonKey1A78( ) ;
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

      public void VarsToRow78( SdtTrn_Device obj78 )
      {
         obj78.gxTpr_Mode = Gx_mode;
         obj78.gxTpr_Devicetype = A362DeviceType;
         obj78.gxTpr_Devicetoken = A363DeviceToken;
         obj78.gxTpr_Devicename = A364DeviceName;
         obj78.gxTpr_Deviceuserid = A365DeviceUserId;
         obj78.gxTpr_Deviceid = A361DeviceId;
         obj78.gxTpr_Deviceid_Z = Z361DeviceId;
         obj78.gxTpr_Devicetype_Z = Z362DeviceType;
         obj78.gxTpr_Devicetoken_Z = Z363DeviceToken;
         obj78.gxTpr_Devicename_Z = Z364DeviceName;
         obj78.gxTpr_Deviceuserid_Z = Z365DeviceUserId;
         obj78.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow78( SdtTrn_Device obj78 )
      {
         obj78.gxTpr_Deviceid = A361DeviceId;
         return  ;
      }

      public void RowToVars78( SdtTrn_Device obj78 ,
                               int forceLoad )
      {
         Gx_mode = obj78.gxTpr_Mode;
         A362DeviceType = obj78.gxTpr_Devicetype;
         A363DeviceToken = obj78.gxTpr_Devicetoken;
         A364DeviceName = obj78.gxTpr_Devicename;
         A365DeviceUserId = obj78.gxTpr_Deviceuserid;
         A361DeviceId = obj78.gxTpr_Deviceid;
         Z361DeviceId = obj78.gxTpr_Deviceid_Z;
         Z362DeviceType = obj78.gxTpr_Devicetype_Z;
         Z363DeviceToken = obj78.gxTpr_Devicetoken_Z;
         Z364DeviceName = obj78.gxTpr_Devicename_Z;
         Z365DeviceUserId = obj78.gxTpr_Deviceuserid_Z;
         Gx_mode = obj78.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A361DeviceId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1A78( ) ;
         ScanKeyStart1A78( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z361DeviceId = A361DeviceId;
         }
         ZM1A78( -2) ;
         OnLoadActions1A78( ) ;
         AddRow1A78( ) ;
         ScanKeyEnd1A78( ) ;
         if ( RcdFound78 == 0 )
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
         RowToVars78( bcTrn_Device, 0) ;
         ScanKeyStart1A78( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z361DeviceId = A361DeviceId;
         }
         ZM1A78( -2) ;
         OnLoadActions1A78( ) ;
         AddRow1A78( ) ;
         ScanKeyEnd1A78( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1A78( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1A78( ) ;
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( StringUtil.StrCmp(A361DeviceId, Z361DeviceId) != 0 )
               {
                  A361DeviceId = Z361DeviceId;
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
                  Update1A78( ) ;
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
                  if ( StringUtil.StrCmp(A361DeviceId, Z361DeviceId) != 0 )
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
                        Insert1A78( ) ;
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
                        Insert1A78( ) ;
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
         RowToVars78( bcTrn_Device, 1) ;
         SaveImpl( ) ;
         VarsToRow78( bcTrn_Device) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars78( bcTrn_Device, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A78( ) ;
         AfterTrn( ) ;
         VarsToRow78( bcTrn_Device) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow78( bcTrn_Device) ;
         }
         else
         {
            SdtTrn_Device auxBC = new SdtTrn_Device(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A361DeviceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Device);
               auxBC.Save();
               bcTrn_Device.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars78( bcTrn_Device, 1) ;
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
         RowToVars78( bcTrn_Device, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A78( ) ;
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
               VarsToRow78( bcTrn_Device) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow78( bcTrn_Device) ;
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
         RowToVars78( bcTrn_Device, 0) ;
         GetKey1A78( ) ;
         if ( RcdFound78 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A361DeviceId, Z361DeviceId) != 0 )
            {
               A361DeviceId = Z361DeviceId;
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
            if ( StringUtil.StrCmp(A361DeviceId, Z361DeviceId) != 0 )
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
         context.RollbackDataStores("trn_device_bc",pr_default);
         VarsToRow78( bcTrn_Device) ;
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
         Gx_mode = bcTrn_Device.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Device.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Device )
         {
            bcTrn_Device = (SdtTrn_Device)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Device.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Device.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow78( bcTrn_Device) ;
            }
            else
            {
               RowToVars78( bcTrn_Device, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Device.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Device.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars78( bcTrn_Device, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Device Trn_Device_BC
      {
         get {
            return bcTrn_Device ;
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
            return "trn_device_Execute" ;
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
         Z361DeviceId = "";
         A361DeviceId = "";
         Z363DeviceToken = "";
         A363DeviceToken = "";
         Z364DeviceName = "";
         A364DeviceName = "";
         Z365DeviceUserId = "";
         A365DeviceUserId = "";
         BC001A4_A361DeviceId = new string[] {""} ;
         BC001A4_A362DeviceType = new short[1] ;
         BC001A4_A363DeviceToken = new string[] {""} ;
         BC001A4_A364DeviceName = new string[] {""} ;
         BC001A4_A365DeviceUserId = new string[] {""} ;
         BC001A5_A361DeviceId = new string[] {""} ;
         BC001A3_A361DeviceId = new string[] {""} ;
         BC001A3_A362DeviceType = new short[1] ;
         BC001A3_A363DeviceToken = new string[] {""} ;
         BC001A3_A364DeviceName = new string[] {""} ;
         BC001A3_A365DeviceUserId = new string[] {""} ;
         sMode78 = "";
         BC001A2_A361DeviceId = new string[] {""} ;
         BC001A2_A362DeviceType = new short[1] ;
         BC001A2_A363DeviceToken = new string[] {""} ;
         BC001A2_A364DeviceName = new string[] {""} ;
         BC001A2_A365DeviceUserId = new string[] {""} ;
         BC001A9_A361DeviceId = new string[] {""} ;
         BC001A9_A362DeviceType = new short[1] ;
         BC001A9_A363DeviceToken = new string[] {""} ;
         BC001A9_A364DeviceName = new string[] {""} ;
         BC001A9_A365DeviceUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__default(),
            new Object[][] {
                new Object[] {
               BC001A2_A361DeviceId, BC001A2_A362DeviceType, BC001A2_A363DeviceToken, BC001A2_A364DeviceName, BC001A2_A365DeviceUserId
               }
               , new Object[] {
               BC001A3_A361DeviceId, BC001A3_A362DeviceType, BC001A3_A363DeviceToken, BC001A3_A364DeviceName, BC001A3_A365DeviceUserId
               }
               , new Object[] {
               BC001A4_A361DeviceId, BC001A4_A362DeviceType, BC001A4_A363DeviceToken, BC001A4_A364DeviceName, BC001A4_A365DeviceUserId
               }
               , new Object[] {
               BC001A5_A361DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001A9_A361DeviceId, BC001A9_A362DeviceType, BC001A9_A363DeviceToken, BC001A9_A364DeviceName, BC001A9_A365DeviceUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z362DeviceType ;
      private short A362DeviceType ;
      private short RcdFound78 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z361DeviceId ;
      private string A361DeviceId ;
      private string Z363DeviceToken ;
      private string A363DeviceToken ;
      private string Z364DeviceName ;
      private string A364DeviceName ;
      private string sMode78 ;
      private string Z365DeviceUserId ;
      private string A365DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC001A4_A361DeviceId ;
      private short[] BC001A4_A362DeviceType ;
      private string[] BC001A4_A363DeviceToken ;
      private string[] BC001A4_A364DeviceName ;
      private string[] BC001A4_A365DeviceUserId ;
      private string[] BC001A5_A361DeviceId ;
      private string[] BC001A3_A361DeviceId ;
      private short[] BC001A3_A362DeviceType ;
      private string[] BC001A3_A363DeviceToken ;
      private string[] BC001A3_A364DeviceName ;
      private string[] BC001A3_A365DeviceUserId ;
      private string[] BC001A2_A361DeviceId ;
      private short[] BC001A2_A362DeviceType ;
      private string[] BC001A2_A363DeviceToken ;
      private string[] BC001A2_A364DeviceName ;
      private string[] BC001A2_A365DeviceUserId ;
      private string[] BC001A9_A361DeviceId ;
      private short[] BC001A9_A362DeviceType ;
      private string[] BC001A9_A363DeviceToken ;
      private string[] BC001A9_A364DeviceName ;
      private string[] BC001A9_A365DeviceUserId ;
      private SdtTrn_Device bcTrn_Device ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_device_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_device_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_device_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001A2;
       prmBC001A2 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A3;
       prmBC001A3 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A4;
       prmBC001A4 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A5;
       prmBC001A5 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A6;
       prmBC001A6 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0) ,
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60)
       };
       Object[] prmBC001A7;
       prmBC001A7 = new Object[] {
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60) ,
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A8;
       prmBC001A8 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC001A9;
       prmBC001A9 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001A2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Trn_Device",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001A3", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001A4", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserId FROM Trn_Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001A5", "SELECT DeviceId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001A6", "SAVEPOINT gxupdate;INSERT INTO Trn_Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001A6)
          ,new CursorDef("BC001A7", "SAVEPOINT gxupdate;UPDATE Trn_Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserId=:DeviceUserId  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001A7)
          ,new CursorDef("BC001A8", "SAVEPOINT gxupdate;DELETE FROM Trn_Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001A8)
          ,new CursorDef("BC001A9", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserId FROM Trn_Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A9,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
    }
 }

}

}
