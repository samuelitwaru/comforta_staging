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
   public class trn_supplieragbtype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_supplieragbtype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbtype_bc( IGxContext context )
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
         ReadRow1156( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1156( ) ;
         standaloneModal( ) ;
         AddRow1156( ) ;
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
            E11112 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1156( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1156( ) ;
            }
            else
            {
               CheckExtendedTable1156( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1156( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12112( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11112( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1156( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z291SupplierAgbTypeName = A291SupplierAgbTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
            Z291SupplierAgbTypeName = A291SupplierAgbTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A283SupplierAgbTypeId) )
         {
            A283SupplierAgbTypeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1156( )
      {
         /* Using cursor BC00114 */
         pr_default.execute(2, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound56 = 1;
            A291SupplierAgbTypeName = BC00114_A291SupplierAgbTypeName[0];
            ZM1156( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1156( ) ;
      }

      protected void OnLoadActions1156( )
      {
      }

      protected void CheckExtendedTable1156( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A291SupplierAgbTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1156( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1156( )
      {
         /* Using cursor BC00115 */
         pr_default.execute(3, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00113 */
         pr_default.execute(1, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1156( 4) ;
            RcdFound56 = 1;
            A283SupplierAgbTypeId = BC00113_A283SupplierAgbTypeId[0];
            A291SupplierAgbTypeName = BC00113_A291SupplierAgbTypeName[0];
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1156( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1156( ) ;
            }
            Gx_mode = sMode56;
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1156( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode56;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1156( ) ;
         if ( RcdFound56 == 0 )
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
         CONFIRM_110( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1156( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00112 */
            pr_default.execute(0, new Object[] {A283SupplierAgbTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAgbType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z291SupplierAgbTypeName, BC00112_A291SupplierAgbTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierAgbType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1156( )
      {
         BeforeValidate1156( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1156( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1156( 0) ;
            CheckOptimisticConcurrency1156( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1156( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1156( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00116 */
                     pr_default.execute(4, new Object[] {A283SupplierAgbTypeId, A291SupplierAgbTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
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
               Load1156( ) ;
            }
            EndLevel1156( ) ;
         }
         CloseExtendedTableCursors1156( ) ;
      }

      protected void Update1156( )
      {
         BeforeValidate1156( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1156( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1156( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1156( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1156( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00117 */
                     pr_default.execute(5, new Object[] {A291SupplierAgbTypeName, A283SupplierAgbTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAgbType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1156( ) ;
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
            EndLevel1156( ) ;
         }
         CloseExtendedTableCursors1156( ) ;
      }

      protected void DeferredUpdate1156( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1156( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1156( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1156( ) ;
            AfterConfirm1156( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1156( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00118 */
                  pr_default.execute(6, new Object[] {A283SupplierAgbTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1156( ) ;
         Gx_mode = sMode56;
      }

      protected void OnDeleteControls1156( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00119 */
            pr_default.execute(7, new Object[] {A283SupplierAgbTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierAGB", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1156( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1156( ) ;
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

      public void ScanKeyStart1156( )
      {
         /* Scan By routine */
         /* Using cursor BC001110 */
         pr_default.execute(8, new Object[] {A283SupplierAgbTypeId});
         RcdFound56 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound56 = 1;
            A283SupplierAgbTypeId = BC001110_A283SupplierAgbTypeId[0];
            A291SupplierAgbTypeName = BC001110_A291SupplierAgbTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1156( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound56 = 0;
         ScanKeyLoad1156( ) ;
      }

      protected void ScanKeyLoad1156( )
      {
         sMode56 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound56 = 1;
            A283SupplierAgbTypeId = BC001110_A283SupplierAgbTypeId[0];
            A291SupplierAgbTypeName = BC001110_A291SupplierAgbTypeName[0];
         }
         Gx_mode = sMode56;
      }

      protected void ScanKeyEnd1156( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1156( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1156( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1156( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1156( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1156( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1156( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1156( )
      {
      }

      protected void send_integrity_lvl_hashes1156( )
      {
      }

      protected void AddRow1156( )
      {
         VarsToRow56( bcTrn_SupplierAgbType) ;
      }

      protected void ReadRow1156( )
      {
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
      }

      protected void InitializeNonKey1156( )
      {
         A291SupplierAgbTypeName = "";
         Z291SupplierAgbTypeName = "";
      }

      protected void InitAll1156( )
      {
         A283SupplierAgbTypeId = Guid.NewGuid( );
         InitializeNonKey1156( ) ;
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

      public void VarsToRow56( SdtTrn_SupplierAgbType obj56 )
      {
         obj56.gxTpr_Mode = Gx_mode;
         obj56.gxTpr_Supplieragbtypename = A291SupplierAgbTypeName;
         obj56.gxTpr_Supplieragbtypeid = A283SupplierAgbTypeId;
         obj56.gxTpr_Supplieragbtypeid_Z = Z283SupplierAgbTypeId;
         obj56.gxTpr_Supplieragbtypename_Z = Z291SupplierAgbTypeName;
         obj56.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow56( SdtTrn_SupplierAgbType obj56 )
      {
         obj56.gxTpr_Supplieragbtypeid = A283SupplierAgbTypeId;
         return  ;
      }

      public void RowToVars56( SdtTrn_SupplierAgbType obj56 ,
                               int forceLoad )
      {
         Gx_mode = obj56.gxTpr_Mode;
         A291SupplierAgbTypeName = obj56.gxTpr_Supplieragbtypename;
         A283SupplierAgbTypeId = obj56.gxTpr_Supplieragbtypeid;
         Z283SupplierAgbTypeId = obj56.gxTpr_Supplieragbtypeid_Z;
         Z291SupplierAgbTypeName = obj56.gxTpr_Supplieragbtypename_Z;
         Gx_mode = obj56.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A283SupplierAgbTypeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1156( ) ;
         ScanKeyStart1156( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
         }
         ZM1156( -4) ;
         OnLoadActions1156( ) ;
         AddRow1156( ) ;
         ScanKeyEnd1156( ) ;
         if ( RcdFound56 == 0 )
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
         RowToVars56( bcTrn_SupplierAgbType, 0) ;
         ScanKeyStart1156( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
         }
         ZM1156( -4) ;
         OnLoadActions1156( ) ;
         AddRow1156( ) ;
         ScanKeyEnd1156( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1156( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1156( ) ;
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( A283SupplierAgbTypeId != Z283SupplierAgbTypeId )
               {
                  A283SupplierAgbTypeId = Z283SupplierAgbTypeId;
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
                  Update1156( ) ;
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
                  if ( A283SupplierAgbTypeId != Z283SupplierAgbTypeId )
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
                        Insert1156( ) ;
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
                        Insert1156( ) ;
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
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
         SaveImpl( ) ;
         VarsToRow56( bcTrn_SupplierAgbType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1156( ) ;
         AfterTrn( ) ;
         VarsToRow56( bcTrn_SupplierAgbType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow56( bcTrn_SupplierAgbType) ;
         }
         else
         {
            SdtTrn_SupplierAgbType auxBC = new SdtTrn_SupplierAgbType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A283SupplierAgbTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierAgbType);
               auxBC.Save();
               bcTrn_SupplierAgbType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
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
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1156( ) ;
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
               VarsToRow56( bcTrn_SupplierAgbType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow56( bcTrn_SupplierAgbType) ;
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
         RowToVars56( bcTrn_SupplierAgbType, 0) ;
         GetKey1156( ) ;
         if ( RcdFound56 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A283SupplierAgbTypeId != Z283SupplierAgbTypeId )
            {
               A283SupplierAgbTypeId = Z283SupplierAgbTypeId;
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
            if ( A283SupplierAgbTypeId != Z283SupplierAgbTypeId )
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
         context.RollbackDataStores("trn_supplieragbtype_bc",pr_default);
         VarsToRow56( bcTrn_SupplierAgbType) ;
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
         Gx_mode = bcTrn_SupplierAgbType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierAgbType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierAgbType )
         {
            bcTrn_SupplierAgbType = (SdtTrn_SupplierAgbType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierAgbType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgbType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow56( bcTrn_SupplierAgbType) ;
            }
            else
            {
               RowToVars56( bcTrn_SupplierAgbType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierAgbType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgbType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars56( bcTrn_SupplierAgbType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierAgbType Trn_SupplierAgbType_BC
      {
         get {
            return bcTrn_SupplierAgbType ;
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
            return "trn_supplieragbtype_Execute" ;
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
         Z283SupplierAgbTypeId = Guid.Empty;
         A283SupplierAgbTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z291SupplierAgbTypeName = "";
         A291SupplierAgbTypeName = "";
         BC00114_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC00114_A291SupplierAgbTypeName = new string[] {""} ;
         BC00115_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC00113_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC00113_A291SupplierAgbTypeName = new string[] {""} ;
         sMode56 = "";
         BC00112_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC00112_A291SupplierAgbTypeName = new string[] {""} ;
         BC00119_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC001110_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC001110_A291SupplierAgbTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__default(),
            new Object[][] {
                new Object[] {
               BC00112_A283SupplierAgbTypeId, BC00112_A291SupplierAgbTypeName
               }
               , new Object[] {
               BC00113_A283SupplierAgbTypeId, BC00113_A291SupplierAgbTypeName
               }
               , new Object[] {
               BC00114_A283SupplierAgbTypeId, BC00114_A291SupplierAgbTypeName
               }
               , new Object[] {
               BC00115_A283SupplierAgbTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00119_A49SupplierAgbId
               }
               , new Object[] {
               BC001110_A283SupplierAgbTypeId, BC001110_A291SupplierAgbTypeName
               }
            }
         );
         Z283SupplierAgbTypeId = Guid.NewGuid( );
         A283SupplierAgbTypeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12112 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound56 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode56 ;
      private bool returnInSub ;
      private string Z291SupplierAgbTypeName ;
      private string A291SupplierAgbTypeName ;
      private Guid Z283SupplierAgbTypeId ;
      private Guid A283SupplierAgbTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00114_A283SupplierAgbTypeId ;
      private string[] BC00114_A291SupplierAgbTypeName ;
      private Guid[] BC00115_A283SupplierAgbTypeId ;
      private Guid[] BC00113_A283SupplierAgbTypeId ;
      private string[] BC00113_A291SupplierAgbTypeName ;
      private Guid[] BC00112_A283SupplierAgbTypeId ;
      private string[] BC00112_A291SupplierAgbTypeName ;
      private Guid[] BC00119_A49SupplierAgbId ;
      private Guid[] BC001110_A283SupplierAgbTypeId ;
      private string[] BC001110_A291SupplierAgbTypeName ;
      private SdtTrn_SupplierAgbType bcTrn_SupplierAgbType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplieragbtype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplieragbtype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_supplieragbtype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00112;
       prmBC00112 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00113;
       prmBC00113 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00114;
       prmBC00114 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00115;
       prmBC00115 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00116;
       prmBC00116 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierAgbTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC00117;
       prmBC00117 = new Object[] {
       new ParDef("SupplierAgbTypeName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00118;
       prmBC00118 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00119;
       prmBC00119 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001110;
       prmBC001110 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00112", "SELECT SupplierAgbTypeId, SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId  FOR UPDATE OF Trn_SupplierAgbType",true, GxErrorMask.GX_NOMASK, false, this,prmBC00112,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00113", "SELECT SupplierAgbTypeId, SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00113,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00114", "SELECT TM1.SupplierAgbTypeId, TM1.SupplierAgbTypeName FROM Trn_SupplierAgbType TM1 WHERE TM1.SupplierAgbTypeId = :SupplierAgbTypeId ORDER BY TM1.SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00114,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00115", "SELECT SupplierAgbTypeId FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00115,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00116", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierAgbType(SupplierAgbTypeId, SupplierAgbTypeName) VALUES(:SupplierAgbTypeId, :SupplierAgbTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00116)
          ,new CursorDef("BC00117", "SAVEPOINT gxupdate;UPDATE Trn_SupplierAgbType SET SupplierAgbTypeName=:SupplierAgbTypeName  WHERE SupplierAgbTypeId = :SupplierAgbTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00117)
          ,new CursorDef("BC00118", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierAgbType  WHERE SupplierAgbTypeId = :SupplierAgbTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00118)
          ,new CursorDef("BC00119", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00119,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001110", "SELECT TM1.SupplierAgbTypeId, TM1.SupplierAgbTypeName FROM Trn_SupplierAgbType TM1 WHERE TM1.SupplierAgbTypeId = :SupplierAgbTypeId ORDER BY TM1.SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001110,100, GxCacheFrequency.OFF ,true,false )
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
