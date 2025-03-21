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
   public class trn_memocategory_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_memocategory_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memocategory_bc( IGxContext context )
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
         ReadRow1S113( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1S113( ) ;
         standaloneModal( ) ;
         AddRow1S113( ) ;
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
            E111S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z568MemoCategoryId = A568MemoCategoryId;
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

      protected void CONFIRM_1S0( )
      {
         BeforeValidate1S113( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1S113( ) ;
            }
            else
            {
               CheckExtendedTable1S113( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1S113( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1S113( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z569MemoCategoryName = A569MemoCategoryName;
         }
         if ( GX_JID == -3 )
         {
            Z568MemoCategoryId = A568MemoCategoryId;
            Z569MemoCategoryName = A569MemoCategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A568MemoCategoryId) )
         {
            A568MemoCategoryId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1S113( )
      {
         /* Using cursor BC001S4 */
         pr_default.execute(2, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound113 = 1;
            A569MemoCategoryName = BC001S4_A569MemoCategoryName[0];
            ZM1S113( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1S113( ) ;
      }

      protected void OnLoadActions1S113( )
      {
      }

      protected void CheckExtendedTable1S113( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1S113( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1S113( )
      {
         /* Using cursor BC001S5 */
         pr_default.execute(3, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound113 = 1;
         }
         else
         {
            RcdFound113 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001S3 */
         pr_default.execute(1, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1S113( 3) ;
            RcdFound113 = 1;
            A568MemoCategoryId = BC001S3_A568MemoCategoryId[0];
            A569MemoCategoryName = BC001S3_A569MemoCategoryName[0];
            Z568MemoCategoryId = A568MemoCategoryId;
            sMode113 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1S113( ) ;
            if ( AnyError == 1 )
            {
               RcdFound113 = 0;
               InitializeNonKey1S113( ) ;
            }
            Gx_mode = sMode113;
         }
         else
         {
            RcdFound113 = 0;
            InitializeNonKey1S113( ) ;
            sMode113 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode113;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1S113( ) ;
         if ( RcdFound113 == 0 )
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
         CONFIRM_1S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1S113( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001S2 */
            pr_default.execute(0, new Object[] {A568MemoCategoryId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MemoCategory"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z569MemoCategoryName, BC001S2_A569MemoCategoryName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_MemoCategory"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1S113( )
      {
         BeforeValidate1S113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S113( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1S113( 0) ;
            CheckOptimisticConcurrency1S113( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S113( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1S113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001S6 */
                     pr_default.execute(4, new Object[] {A568MemoCategoryId, A569MemoCategoryName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
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
               Load1S113( ) ;
            }
            EndLevel1S113( ) ;
         }
         CloseExtendedTableCursors1S113( ) ;
      }

      protected void Update1S113( )
      {
         BeforeValidate1S113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S113( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S113( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S113( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1S113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001S7 */
                     pr_default.execute(5, new Object[] {A569MemoCategoryName, A568MemoCategoryId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MemoCategory"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1S113( ) ;
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
            EndLevel1S113( ) ;
         }
         CloseExtendedTableCursors1S113( ) ;
      }

      protected void DeferredUpdate1S113( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1S113( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S113( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1S113( ) ;
            AfterConfirm1S113( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1S113( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001S8 */
                  pr_default.execute(6, new Object[] {A568MemoCategoryId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
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
         sMode113 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1S113( ) ;
         Gx_mode = sMode113;
      }

      protected void OnDeleteControls1S113( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001S9 */
            pr_default.execute(7, new Object[] {A568MemoCategoryId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Memo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1S113( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1S113( ) ;
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

      public void ScanKeyStart1S113( )
      {
         /* Scan By routine */
         /* Using cursor BC001S10 */
         pr_default.execute(8, new Object[] {A568MemoCategoryId});
         RcdFound113 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound113 = 1;
            A568MemoCategoryId = BC001S10_A568MemoCategoryId[0];
            A569MemoCategoryName = BC001S10_A569MemoCategoryName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1S113( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound113 = 0;
         ScanKeyLoad1S113( ) ;
      }

      protected void ScanKeyLoad1S113( )
      {
         sMode113 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound113 = 1;
            A568MemoCategoryId = BC001S10_A568MemoCategoryId[0];
            A569MemoCategoryName = BC001S10_A569MemoCategoryName[0];
         }
         Gx_mode = sMode113;
      }

      protected void ScanKeyEnd1S113( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1S113( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1S113( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1S113( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1S113( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1S113( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1S113( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1S113( )
      {
      }

      protected void send_integrity_lvl_hashes1S113( )
      {
      }

      protected void AddRow1S113( )
      {
         VarsToRow113( bcTrn_MemoCategory) ;
      }

      protected void ReadRow1S113( )
      {
         RowToVars113( bcTrn_MemoCategory, 1) ;
      }

      protected void InitializeNonKey1S113( )
      {
         A569MemoCategoryName = "";
         Z569MemoCategoryName = "";
      }

      protected void InitAll1S113( )
      {
         A568MemoCategoryId = Guid.NewGuid( );
         InitializeNonKey1S113( ) ;
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

      public void VarsToRow113( SdtTrn_MemoCategory obj113 )
      {
         obj113.gxTpr_Mode = Gx_mode;
         obj113.gxTpr_Memocategoryname = A569MemoCategoryName;
         obj113.gxTpr_Memocategoryid = A568MemoCategoryId;
         obj113.gxTpr_Memocategoryid_Z = Z568MemoCategoryId;
         obj113.gxTpr_Memocategoryname_Z = Z569MemoCategoryName;
         obj113.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow113( SdtTrn_MemoCategory obj113 )
      {
         obj113.gxTpr_Memocategoryid = A568MemoCategoryId;
         return  ;
      }

      public void RowToVars113( SdtTrn_MemoCategory obj113 ,
                                int forceLoad )
      {
         Gx_mode = obj113.gxTpr_Mode;
         A569MemoCategoryName = obj113.gxTpr_Memocategoryname;
         A568MemoCategoryId = obj113.gxTpr_Memocategoryid;
         Z568MemoCategoryId = obj113.gxTpr_Memocategoryid_Z;
         Z569MemoCategoryName = obj113.gxTpr_Memocategoryname_Z;
         Gx_mode = obj113.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A568MemoCategoryId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1S113( ) ;
         ScanKeyStart1S113( ) ;
         if ( RcdFound113 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z568MemoCategoryId = A568MemoCategoryId;
         }
         ZM1S113( -3) ;
         OnLoadActions1S113( ) ;
         AddRow1S113( ) ;
         ScanKeyEnd1S113( ) ;
         if ( RcdFound113 == 0 )
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
         RowToVars113( bcTrn_MemoCategory, 0) ;
         ScanKeyStart1S113( ) ;
         if ( RcdFound113 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z568MemoCategoryId = A568MemoCategoryId;
         }
         ZM1S113( -3) ;
         OnLoadActions1S113( ) ;
         AddRow1S113( ) ;
         ScanKeyEnd1S113( ) ;
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1S113( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1S113( ) ;
         }
         else
         {
            if ( RcdFound113 == 1 )
            {
               if ( A568MemoCategoryId != Z568MemoCategoryId )
               {
                  A568MemoCategoryId = Z568MemoCategoryId;
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
                  Update1S113( ) ;
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
                  if ( A568MemoCategoryId != Z568MemoCategoryId )
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
                        Insert1S113( ) ;
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
                        Insert1S113( ) ;
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
         RowToVars113( bcTrn_MemoCategory, 1) ;
         SaveImpl( ) ;
         VarsToRow113( bcTrn_MemoCategory) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars113( bcTrn_MemoCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1S113( ) ;
         AfterTrn( ) ;
         VarsToRow113( bcTrn_MemoCategory) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow113( bcTrn_MemoCategory) ;
         }
         else
         {
            SdtTrn_MemoCategory auxBC = new SdtTrn_MemoCategory(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A568MemoCategoryId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_MemoCategory);
               auxBC.Save();
               bcTrn_MemoCategory.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars113( bcTrn_MemoCategory, 1) ;
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
         RowToVars113( bcTrn_MemoCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1S113( ) ;
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
               VarsToRow113( bcTrn_MemoCategory) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow113( bcTrn_MemoCategory) ;
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
         RowToVars113( bcTrn_MemoCategory, 0) ;
         GetKey1S113( ) ;
         if ( RcdFound113 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A568MemoCategoryId != Z568MemoCategoryId )
            {
               A568MemoCategoryId = Z568MemoCategoryId;
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
            if ( A568MemoCategoryId != Z568MemoCategoryId )
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
         context.RollbackDataStores("trn_memocategory_bc",pr_default);
         VarsToRow113( bcTrn_MemoCategory) ;
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
         Gx_mode = bcTrn_MemoCategory.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_MemoCategory.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_MemoCategory )
         {
            bcTrn_MemoCategory = (SdtTrn_MemoCategory)(sdt);
            if ( StringUtil.StrCmp(bcTrn_MemoCategory.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MemoCategory.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow113( bcTrn_MemoCategory) ;
            }
            else
            {
               RowToVars113( bcTrn_MemoCategory, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_MemoCategory.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MemoCategory.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars113( bcTrn_MemoCategory, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_MemoCategory Trn_MemoCategory_BC
      {
         get {
            return bcTrn_MemoCategory ;
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
            return "trn_memocategory_Execute" ;
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
         Z568MemoCategoryId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z569MemoCategoryName = "";
         A569MemoCategoryName = "";
         BC001S4_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001S4_A569MemoCategoryName = new string[] {""} ;
         BC001S5_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001S3_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001S3_A569MemoCategoryName = new string[] {""} ;
         sMode113 = "";
         BC001S2_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001S2_A569MemoCategoryName = new string[] {""} ;
         BC001S9_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001S10_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001S10_A569MemoCategoryName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__default(),
            new Object[][] {
                new Object[] {
               BC001S2_A568MemoCategoryId, BC001S2_A569MemoCategoryName
               }
               , new Object[] {
               BC001S3_A568MemoCategoryId, BC001S3_A569MemoCategoryName
               }
               , new Object[] {
               BC001S4_A568MemoCategoryId, BC001S4_A569MemoCategoryName
               }
               , new Object[] {
               BC001S5_A568MemoCategoryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001S9_A575MemoId
               }
               , new Object[] {
               BC001S10_A568MemoCategoryId, BC001S10_A569MemoCategoryName
               }
            }
         );
         Z568MemoCategoryId = Guid.NewGuid( );
         A568MemoCategoryId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121S2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound113 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode113 ;
      private bool returnInSub ;
      private string Z569MemoCategoryName ;
      private string A569MemoCategoryName ;
      private Guid Z568MemoCategoryId ;
      private Guid A568MemoCategoryId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001S4_A568MemoCategoryId ;
      private string[] BC001S4_A569MemoCategoryName ;
      private Guid[] BC001S5_A568MemoCategoryId ;
      private Guid[] BC001S3_A568MemoCategoryId ;
      private string[] BC001S3_A569MemoCategoryName ;
      private Guid[] BC001S2_A568MemoCategoryId ;
      private string[] BC001S2_A569MemoCategoryName ;
      private Guid[] BC001S9_A575MemoId ;
      private Guid[] BC001S10_A568MemoCategoryId ;
      private string[] BC001S10_A569MemoCategoryName ;
      private SdtTrn_MemoCategory bcTrn_MemoCategory ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memocategory_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_memocategory_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_memocategory_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001S2;
       prmBC001S2 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S3;
       prmBC001S3 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S4;
       prmBC001S4 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S5;
       prmBC001S5 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S6;
       prmBC001S6 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoCategoryName",GXType.VarChar,100,0)
       };
       Object[] prmBC001S7;
       prmBC001S7 = new Object[] {
       new ParDef("MemoCategoryName",GXType.VarChar,100,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S8;
       prmBC001S8 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S9;
       prmBC001S9 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001S10;
       prmBC001S10 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001S2", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId  FOR UPDATE OF Trn_MemoCategory",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001S3", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001S4", "SELECT TM1.MemoCategoryId, TM1.MemoCategoryName FROM Trn_MemoCategory TM1 WHERE TM1.MemoCategoryId = :MemoCategoryId ORDER BY TM1.MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001S5", "SELECT MemoCategoryId FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001S6", "SAVEPOINT gxupdate;INSERT INTO Trn_MemoCategory(MemoCategoryId, MemoCategoryName) VALUES(:MemoCategoryId, :MemoCategoryName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001S6)
          ,new CursorDef("BC001S7", "SAVEPOINT gxupdate;UPDATE Trn_MemoCategory SET MemoCategoryName=:MemoCategoryName  WHERE MemoCategoryId = :MemoCategoryId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001S7)
          ,new CursorDef("BC001S8", "SAVEPOINT gxupdate;DELETE FROM Trn_MemoCategory  WHERE MemoCategoryId = :MemoCategoryId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001S8)
          ,new CursorDef("BC001S9", "SELECT MemoId FROM Trn_Memo WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001S10", "SELECT TM1.MemoCategoryId, TM1.MemoCategoryName FROM Trn_MemoCategory TM1 WHERE TM1.MemoCategoryId = :MemoCategoryId ORDER BY TM1.MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S10,100, GxCacheFrequency.OFF ,true,false )
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
