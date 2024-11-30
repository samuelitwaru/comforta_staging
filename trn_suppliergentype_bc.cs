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
   public class trn_suppliergentype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_suppliergentype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergentype_bc( IGxContext context )
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
         ReadRow1257( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1257( ) ;
         standaloneModal( ) ;
         AddRow1257( ) ;
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
            E11122 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z282SupplierGenTypeId = A282SupplierGenTypeId;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1257( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1257( ) ;
            }
            else
            {
               CheckExtendedTable1257( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1257( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12122( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11122( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1257( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z290SupplierGenTypeName = A290SupplierGenTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
            Z290SupplierGenTypeName = A290SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A282SupplierGenTypeId) )
         {
            A282SupplierGenTypeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1257( )
      {
         /* Using cursor BC00124 */
         pr_default.execute(2, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound57 = 1;
            A290SupplierGenTypeName = BC00124_A290SupplierGenTypeName[0];
            ZM1257( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1257( ) ;
      }

      protected void OnLoadActions1257( )
      {
      }

      protected void CheckExtendedTable1257( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A290SupplierGenTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1257( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1257( )
      {
         /* Using cursor BC00125 */
         pr_default.execute(3, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound57 = 1;
         }
         else
         {
            RcdFound57 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00123 */
         pr_default.execute(1, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1257( 4) ;
            RcdFound57 = 1;
            A282SupplierGenTypeId = BC00123_A282SupplierGenTypeId[0];
            A290SupplierGenTypeName = BC00123_A290SupplierGenTypeName[0];
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1257( ) ;
            if ( AnyError == 1 )
            {
               RcdFound57 = 0;
               InitializeNonKey1257( ) ;
            }
            Gx_mode = sMode57;
         }
         else
         {
            RcdFound57 = 0;
            InitializeNonKey1257( ) ;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode57;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1257( ) ;
         if ( RcdFound57 == 0 )
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
         CONFIRM_120( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1257( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00122 */
            pr_default.execute(0, new Object[] {A282SupplierGenTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z290SupplierGenTypeName, BC00122_A290SupplierGenTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGenType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1257( )
      {
         BeforeValidate1257( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1257( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1257( 0) ;
            CheckOptimisticConcurrency1257( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1257( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1257( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00126 */
                     pr_default.execute(4, new Object[] {A282SupplierGenTypeId, A290SupplierGenTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
               Load1257( ) ;
            }
            EndLevel1257( ) ;
         }
         CloseExtendedTableCursors1257( ) ;
      }

      protected void Update1257( )
      {
         BeforeValidate1257( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1257( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1257( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1257( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1257( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00127 */
                     pr_default.execute(5, new Object[] {A290SupplierGenTypeName, A282SupplierGenTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1257( ) ;
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
            EndLevel1257( ) ;
         }
         CloseExtendedTableCursors1257( ) ;
      }

      protected void DeferredUpdate1257( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1257( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1257( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1257( ) ;
            AfterConfirm1257( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1257( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00128 */
                  pr_default.execute(6, new Object[] {A282SupplierGenTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
         sMode57 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1257( ) ;
         Gx_mode = sMode57;
      }

      protected void OnDeleteControls1257( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00129 */
            pr_default.execute(7, new Object[] {A282SupplierGenTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierGen", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1257( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1257( ) ;
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

      public void ScanKeyStart1257( )
      {
         /* Scan By routine */
         /* Using cursor BC001210 */
         pr_default.execute(8, new Object[] {A282SupplierGenTypeId});
         RcdFound57 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound57 = 1;
            A282SupplierGenTypeId = BC001210_A282SupplierGenTypeId[0];
            A290SupplierGenTypeName = BC001210_A290SupplierGenTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1257( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound57 = 0;
         ScanKeyLoad1257( ) ;
      }

      protected void ScanKeyLoad1257( )
      {
         sMode57 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound57 = 1;
            A282SupplierGenTypeId = BC001210_A282SupplierGenTypeId[0];
            A290SupplierGenTypeName = BC001210_A290SupplierGenTypeName[0];
         }
         Gx_mode = sMode57;
      }

      protected void ScanKeyEnd1257( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1257( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1257( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1257( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1257( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1257( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1257( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1257( )
      {
      }

      protected void send_integrity_lvl_hashes1257( )
      {
      }

      protected void AddRow1257( )
      {
         VarsToRow57( bcTrn_SupplierGenType) ;
      }

      protected void ReadRow1257( )
      {
         RowToVars57( bcTrn_SupplierGenType, 1) ;
      }

      protected void InitializeNonKey1257( )
      {
         A290SupplierGenTypeName = "";
         Z290SupplierGenTypeName = "";
      }

      protected void InitAll1257( )
      {
         A282SupplierGenTypeId = Guid.NewGuid( );
         InitializeNonKey1257( ) ;
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

      public void VarsToRow57( SdtTrn_SupplierGenType obj57 )
      {
         obj57.gxTpr_Mode = Gx_mode;
         obj57.gxTpr_Suppliergentypename = A290SupplierGenTypeName;
         obj57.gxTpr_Suppliergentypeid = A282SupplierGenTypeId;
         obj57.gxTpr_Suppliergentypeid_Z = Z282SupplierGenTypeId;
         obj57.gxTpr_Suppliergentypename_Z = Z290SupplierGenTypeName;
         obj57.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow57( SdtTrn_SupplierGenType obj57 )
      {
         obj57.gxTpr_Suppliergentypeid = A282SupplierGenTypeId;
         return  ;
      }

      public void RowToVars57( SdtTrn_SupplierGenType obj57 ,
                               int forceLoad )
      {
         Gx_mode = obj57.gxTpr_Mode;
         A290SupplierGenTypeName = obj57.gxTpr_Suppliergentypename;
         A282SupplierGenTypeId = obj57.gxTpr_Suppliergentypeid;
         Z282SupplierGenTypeId = obj57.gxTpr_Suppliergentypeid_Z;
         Z290SupplierGenTypeName = obj57.gxTpr_Suppliergentypename_Z;
         Gx_mode = obj57.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A282SupplierGenTypeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1257( ) ;
         ScanKeyStart1257( ) ;
         if ( RcdFound57 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
         }
         ZM1257( -4) ;
         OnLoadActions1257( ) ;
         AddRow1257( ) ;
         ScanKeyEnd1257( ) ;
         if ( RcdFound57 == 0 )
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
         RowToVars57( bcTrn_SupplierGenType, 0) ;
         ScanKeyStart1257( ) ;
         if ( RcdFound57 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
         }
         ZM1257( -4) ;
         OnLoadActions1257( ) ;
         AddRow1257( ) ;
         ScanKeyEnd1257( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1257( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1257( ) ;
         }
         else
         {
            if ( RcdFound57 == 1 )
            {
               if ( A282SupplierGenTypeId != Z282SupplierGenTypeId )
               {
                  A282SupplierGenTypeId = Z282SupplierGenTypeId;
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
                  Update1257( ) ;
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
                  if ( A282SupplierGenTypeId != Z282SupplierGenTypeId )
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
                        Insert1257( ) ;
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
                        Insert1257( ) ;
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
         RowToVars57( bcTrn_SupplierGenType, 1) ;
         SaveImpl( ) ;
         VarsToRow57( bcTrn_SupplierGenType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars57( bcTrn_SupplierGenType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1257( ) ;
         AfterTrn( ) ;
         VarsToRow57( bcTrn_SupplierGenType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow57( bcTrn_SupplierGenType) ;
         }
         else
         {
            SdtTrn_SupplierGenType auxBC = new SdtTrn_SupplierGenType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A282SupplierGenTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierGenType);
               auxBC.Save();
               bcTrn_SupplierGenType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars57( bcTrn_SupplierGenType, 1) ;
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
         RowToVars57( bcTrn_SupplierGenType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1257( ) ;
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
               VarsToRow57( bcTrn_SupplierGenType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow57( bcTrn_SupplierGenType) ;
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
         RowToVars57( bcTrn_SupplierGenType, 0) ;
         GetKey1257( ) ;
         if ( RcdFound57 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A282SupplierGenTypeId != Z282SupplierGenTypeId )
            {
               A282SupplierGenTypeId = Z282SupplierGenTypeId;
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
            if ( A282SupplierGenTypeId != Z282SupplierGenTypeId )
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
         context.RollbackDataStores("trn_suppliergentype_bc",pr_default);
         VarsToRow57( bcTrn_SupplierGenType) ;
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
         Gx_mode = bcTrn_SupplierGenType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierGenType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierGenType )
         {
            bcTrn_SupplierGenType = (SdtTrn_SupplierGenType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierGenType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGenType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow57( bcTrn_SupplierGenType) ;
            }
            else
            {
               RowToVars57( bcTrn_SupplierGenType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierGenType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGenType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars57( bcTrn_SupplierGenType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierGenType Trn_SupplierGenType_BC
      {
         get {
            return bcTrn_SupplierGenType ;
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
            return "trn_suppliergentype_Execute" ;
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
         Z282SupplierGenTypeId = Guid.Empty;
         A282SupplierGenTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z290SupplierGenTypeName = "";
         A290SupplierGenTypeName = "";
         BC00124_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00124_A290SupplierGenTypeName = new string[] {""} ;
         BC00125_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00123_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00123_A290SupplierGenTypeName = new string[] {""} ;
         sMode57 = "";
         BC00122_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00122_A290SupplierGenTypeName = new string[] {""} ;
         BC00129_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001210_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC001210_A290SupplierGenTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__default(),
            new Object[][] {
                new Object[] {
               BC00122_A282SupplierGenTypeId, BC00122_A290SupplierGenTypeName
               }
               , new Object[] {
               BC00123_A282SupplierGenTypeId, BC00123_A290SupplierGenTypeName
               }
               , new Object[] {
               BC00124_A282SupplierGenTypeId, BC00124_A290SupplierGenTypeName
               }
               , new Object[] {
               BC00125_A282SupplierGenTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00129_A42SupplierGenId
               }
               , new Object[] {
               BC001210_A282SupplierGenTypeId, BC001210_A290SupplierGenTypeName
               }
            }
         );
         Z282SupplierGenTypeId = Guid.NewGuid( );
         A282SupplierGenTypeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12122 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound57 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode57 ;
      private bool returnInSub ;
      private string Z290SupplierGenTypeName ;
      private string A290SupplierGenTypeName ;
      private Guid Z282SupplierGenTypeId ;
      private Guid A282SupplierGenTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00124_A282SupplierGenTypeId ;
      private string[] BC00124_A290SupplierGenTypeName ;
      private Guid[] BC00125_A282SupplierGenTypeId ;
      private Guid[] BC00123_A282SupplierGenTypeId ;
      private string[] BC00123_A290SupplierGenTypeName ;
      private Guid[] BC00122_A282SupplierGenTypeId ;
      private string[] BC00122_A290SupplierGenTypeName ;
      private Guid[] BC00129_A42SupplierGenId ;
      private Guid[] BC001210_A282SupplierGenTypeId ;
      private string[] BC001210_A290SupplierGenTypeName ;
      private SdtTrn_SupplierGenType bcTrn_SupplierGenType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergentype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergentype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergentype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00122;
       prmBC00122 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00123;
       prmBC00123 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00124;
       prmBC00124 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00125;
       prmBC00125 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00126;
       prmBC00126 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC00127;
       prmBC00127 = new Object[] {
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00128;
       prmBC00128 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00129;
       prmBC00129 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001210;
       prmBC001210 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00122", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId  FOR UPDATE OF Trn_SupplierGenType",true, GxErrorMask.GX_NOMASK, false, this,prmBC00122,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00123", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00123,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00124", "SELECT TM1.SupplierGenTypeId, TM1.SupplierGenTypeName FROM Trn_SupplierGenType TM1 WHERE TM1.SupplierGenTypeId = :SupplierGenTypeId ORDER BY TM1.SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00124,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00125", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00125,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00126", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGenType(SupplierGenTypeId, SupplierGenTypeName) VALUES(:SupplierGenTypeId, :SupplierGenTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00126)
          ,new CursorDef("BC00127", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGenType SET SupplierGenTypeName=:SupplierGenTypeName  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00127)
          ,new CursorDef("BC00128", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGenType  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00128)
          ,new CursorDef("BC00129", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00129,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001210", "SELECT TM1.SupplierGenTypeId, TM1.SupplierGenTypeName FROM Trn_SupplierGenType TM1 WHERE TM1.SupplierGenTypeId = :SupplierGenTypeId ORDER BY TM1.SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001210,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
