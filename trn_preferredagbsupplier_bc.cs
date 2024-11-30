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
   public class trn_preferredagbsupplier_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_preferredagbsupplier_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_preferredagbsupplier_bc( IGxContext context )
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
         ReadRow1E85( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1E85( ) ;
         standaloneModal( ) ;
         AddRow1E85( ) ;
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
               Z428PreferredAgbSupplierId = A428PreferredAgbSupplierId;
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

      protected void CONFIRM_1E0( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1E85( ) ;
            }
            else
            {
               CheckExtendedTable1E85( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1E85( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1E85( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z430PreferredAgbOrganisationId = A430PreferredAgbOrganisationId;
            Z425PreferredSupplierAgbId = A425PreferredSupplierAgbId;
         }
         if ( GX_JID == -6 )
         {
            Z428PreferredAgbSupplierId = A428PreferredAgbSupplierId;
            Z430PreferredAgbOrganisationId = A430PreferredAgbOrganisationId;
            Z425PreferredSupplierAgbId = A425PreferredSupplierAgbId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A428PreferredAgbSupplierId) )
         {
            A428PreferredAgbSupplierId = Guid.NewGuid( );
         }
         GXt_guid1 = A430PreferredAgbOrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A430PreferredAgbOrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1E85( )
      {
         /* Using cursor BC001E4 */
         pr_default.execute(2, new Object[] {A428PreferredAgbSupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound85 = 1;
            A430PreferredAgbOrganisationId = BC001E4_A430PreferredAgbOrganisationId[0];
            A425PreferredSupplierAgbId = BC001E4_A425PreferredSupplierAgbId[0];
            ZM1E85( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1E85( ) ;
      }

      protected void OnLoadActions1E85( )
      {
      }

      protected void CheckExtendedTable1E85( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1E85( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1E85( )
      {
         /* Using cursor BC001E5 */
         pr_default.execute(3, new Object[] {A428PreferredAgbSupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001E3 */
         pr_default.execute(1, new Object[] {A428PreferredAgbSupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E85( 6) ;
            RcdFound85 = 1;
            A428PreferredAgbSupplierId = BC001E3_A428PreferredAgbSupplierId[0];
            A430PreferredAgbOrganisationId = BC001E3_A430PreferredAgbOrganisationId[0];
            A425PreferredSupplierAgbId = BC001E3_A425PreferredSupplierAgbId[0];
            Z428PreferredAgbSupplierId = A428PreferredAgbSupplierId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1E85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey1E85( ) ;
            }
            Gx_mode = sMode85;
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey1E85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode85;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E85( ) ;
         if ( RcdFound85 == 0 )
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
         CONFIRM_1E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1E85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001E2 */
            pr_default.execute(0, new Object[] {A428PreferredAgbSupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z430PreferredAgbOrganisationId != BC001E2_A430PreferredAgbOrganisationId[0] ) || ( Z425PreferredSupplierAgbId != BC001E2_A425PreferredSupplierAgbId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E85( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E85( 0) ;
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E6 */
                     pr_default.execute(4, new Object[] {A428PreferredAgbSupplierId, A430PreferredAgbOrganisationId, A425PreferredSupplierAgbId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
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
               Load1E85( ) ;
            }
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void Update1E85( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E7 */
                     pr_default.execute(5, new Object[] {A430PreferredAgbOrganisationId, A425PreferredSupplierAgbId, A428PreferredAgbSupplierId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E85( ) ;
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
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void DeferredUpdate1E85( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E85( ) ;
            AfterConfirm1E85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001E8 */
                  pr_default.execute(6, new Object[] {A428PreferredAgbSupplierId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1E85( ) ;
         Gx_mode = sMode85;
      }

      protected void OnDeleteControls1E85( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1E85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E85( ) ;
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

      public void ScanKeyStart1E85( )
      {
         /* Using cursor BC001E9 */
         pr_default.execute(7, new Object[] {A428PreferredAgbSupplierId});
         RcdFound85 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound85 = 1;
            A428PreferredAgbSupplierId = BC001E9_A428PreferredAgbSupplierId[0];
            A430PreferredAgbOrganisationId = BC001E9_A430PreferredAgbOrganisationId[0];
            A425PreferredSupplierAgbId = BC001E9_A425PreferredSupplierAgbId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1E85( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound85 = 0;
         ScanKeyLoad1E85( ) ;
      }

      protected void ScanKeyLoad1E85( )
      {
         sMode85 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound85 = 1;
            A428PreferredAgbSupplierId = BC001E9_A428PreferredAgbSupplierId[0];
            A430PreferredAgbOrganisationId = BC001E9_A430PreferredAgbOrganisationId[0];
            A425PreferredSupplierAgbId = BC001E9_A425PreferredSupplierAgbId[0];
         }
         Gx_mode = sMode85;
      }

      protected void ScanKeyEnd1E85( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1E85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E85( )
      {
      }

      protected void send_integrity_lvl_hashes1E85( )
      {
      }

      protected void AddRow1E85( )
      {
         VarsToRow85( bcTrn_PreferredAgbSupplier) ;
      }

      protected void ReadRow1E85( )
      {
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
      }

      protected void InitializeNonKey1E85( )
      {
         A430PreferredAgbOrganisationId = Guid.Empty;
         A425PreferredSupplierAgbId = Guid.Empty;
         Z430PreferredAgbOrganisationId = Guid.Empty;
         Z425PreferredSupplierAgbId = Guid.Empty;
      }

      protected void InitAll1E85( )
      {
         A428PreferredAgbSupplierId = Guid.NewGuid( );
         InitializeNonKey1E85( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A430PreferredAgbOrganisationId = i430PreferredAgbOrganisationId;
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

      public void VarsToRow85( SdtTrn_PreferredAgbSupplier obj85 )
      {
         obj85.gxTpr_Mode = Gx_mode;
         obj85.gxTpr_Preferredagborganisationid = A430PreferredAgbOrganisationId;
         obj85.gxTpr_Preferredsupplieragbid = A425PreferredSupplierAgbId;
         obj85.gxTpr_Preferredagbsupplierid = A428PreferredAgbSupplierId;
         obj85.gxTpr_Preferredagbsupplierid_Z = Z428PreferredAgbSupplierId;
         obj85.gxTpr_Preferredagborganisationid_Z = Z430PreferredAgbOrganisationId;
         obj85.gxTpr_Preferredsupplieragbid_Z = Z425PreferredSupplierAgbId;
         obj85.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow85( SdtTrn_PreferredAgbSupplier obj85 )
      {
         obj85.gxTpr_Preferredagbsupplierid = A428PreferredAgbSupplierId;
         return  ;
      }

      public void RowToVars85( SdtTrn_PreferredAgbSupplier obj85 ,
                               int forceLoad )
      {
         Gx_mode = obj85.gxTpr_Mode;
         A430PreferredAgbOrganisationId = obj85.gxTpr_Preferredagborganisationid;
         A425PreferredSupplierAgbId = obj85.gxTpr_Preferredsupplieragbid;
         A428PreferredAgbSupplierId = obj85.gxTpr_Preferredagbsupplierid;
         Z428PreferredAgbSupplierId = obj85.gxTpr_Preferredagbsupplierid_Z;
         Z430PreferredAgbOrganisationId = obj85.gxTpr_Preferredagborganisationid_Z;
         Z425PreferredSupplierAgbId = obj85.gxTpr_Preferredsupplieragbid_Z;
         Gx_mode = obj85.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A428PreferredAgbSupplierId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1E85( ) ;
         ScanKeyStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z428PreferredAgbSupplierId = A428PreferredAgbSupplierId;
         }
         ZM1E85( -6) ;
         OnLoadActions1E85( ) ;
         AddRow1E85( ) ;
         ScanKeyEnd1E85( ) ;
         if ( RcdFound85 == 0 )
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
         RowToVars85( bcTrn_PreferredAgbSupplier, 0) ;
         ScanKeyStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z428PreferredAgbSupplierId = A428PreferredAgbSupplierId;
         }
         ZM1E85( -6) ;
         OnLoadActions1E85( ) ;
         AddRow1E85( ) ;
         ScanKeyEnd1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1E85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1E85( ) ;
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( A428PreferredAgbSupplierId != Z428PreferredAgbSupplierId )
               {
                  A428PreferredAgbSupplierId = Z428PreferredAgbSupplierId;
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
                  Update1E85( ) ;
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
                  if ( A428PreferredAgbSupplierId != Z428PreferredAgbSupplierId )
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
                        Insert1E85( ) ;
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
                        Insert1E85( ) ;
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
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
         SaveImpl( ) ;
         VarsToRow85( bcTrn_PreferredAgbSupplier) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E85( ) ;
         AfterTrn( ) ;
         VarsToRow85( bcTrn_PreferredAgbSupplier) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow85( bcTrn_PreferredAgbSupplier) ;
         }
         else
         {
            SdtTrn_PreferredAgbSupplier auxBC = new SdtTrn_PreferredAgbSupplier(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A428PreferredAgbSupplierId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_PreferredAgbSupplier);
               auxBC.Save();
               bcTrn_PreferredAgbSupplier.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
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
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E85( ) ;
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
               VarsToRow85( bcTrn_PreferredAgbSupplier) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow85( bcTrn_PreferredAgbSupplier) ;
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
         RowToVars85( bcTrn_PreferredAgbSupplier, 0) ;
         GetKey1E85( ) ;
         if ( RcdFound85 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A428PreferredAgbSupplierId != Z428PreferredAgbSupplierId )
            {
               A428PreferredAgbSupplierId = Z428PreferredAgbSupplierId;
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
            if ( A428PreferredAgbSupplierId != Z428PreferredAgbSupplierId )
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
         context.RollbackDataStores("trn_preferredagbsupplier_bc",pr_default);
         VarsToRow85( bcTrn_PreferredAgbSupplier) ;
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
         Gx_mode = bcTrn_PreferredAgbSupplier.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_PreferredAgbSupplier.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_PreferredAgbSupplier )
         {
            bcTrn_PreferredAgbSupplier = (SdtTrn_PreferredAgbSupplier)(sdt);
            if ( StringUtil.StrCmp(bcTrn_PreferredAgbSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredAgbSupplier.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow85( bcTrn_PreferredAgbSupplier) ;
            }
            else
            {
               RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_PreferredAgbSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredAgbSupplier.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars85( bcTrn_PreferredAgbSupplier, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_PreferredAgbSupplier Trn_PreferredAgbSupplier_BC
      {
         get {
            return bcTrn_PreferredAgbSupplier ;
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
            return GAMSecurityLevel.SecurityLow ;
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
         Z428PreferredAgbSupplierId = Guid.Empty;
         A428PreferredAgbSupplierId = Guid.Empty;
         Z430PreferredAgbOrganisationId = Guid.Empty;
         A430PreferredAgbOrganisationId = Guid.Empty;
         Z425PreferredSupplierAgbId = Guid.Empty;
         A425PreferredSupplierAgbId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC001E4_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC001E4_A430PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC001E4_A425PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         BC001E5_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC001E3_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC001E3_A430PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC001E3_A425PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         sMode85 = "";
         BC001E2_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC001E2_A430PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC001E2_A425PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         BC001E9_A428PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC001E9_A430PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC001E9_A425PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         i430PreferredAgbOrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__default(),
            new Object[][] {
                new Object[] {
               BC001E2_A428PreferredAgbSupplierId, BC001E2_A430PreferredAgbOrganisationId, BC001E2_A425PreferredSupplierAgbId
               }
               , new Object[] {
               BC001E3_A428PreferredAgbSupplierId, BC001E3_A430PreferredAgbOrganisationId, BC001E3_A425PreferredSupplierAgbId
               }
               , new Object[] {
               BC001E4_A428PreferredAgbSupplierId, BC001E4_A430PreferredAgbOrganisationId, BC001E4_A425PreferredSupplierAgbId
               }
               , new Object[] {
               BC001E5_A428PreferredAgbSupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001E9_A428PreferredAgbSupplierId, BC001E9_A430PreferredAgbOrganisationId, BC001E9_A425PreferredSupplierAgbId
               }
            }
         );
         Z428PreferredAgbSupplierId = Guid.NewGuid( );
         A428PreferredAgbSupplierId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound85 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode85 ;
      private Guid Z428PreferredAgbSupplierId ;
      private Guid A428PreferredAgbSupplierId ;
      private Guid Z430PreferredAgbOrganisationId ;
      private Guid A430PreferredAgbOrganisationId ;
      private Guid Z425PreferredSupplierAgbId ;
      private Guid A425PreferredSupplierAgbId ;
      private Guid GXt_guid1 ;
      private Guid i430PreferredAgbOrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001E4_A428PreferredAgbSupplierId ;
      private Guid[] BC001E4_A430PreferredAgbOrganisationId ;
      private Guid[] BC001E4_A425PreferredSupplierAgbId ;
      private Guid[] BC001E5_A428PreferredAgbSupplierId ;
      private Guid[] BC001E3_A428PreferredAgbSupplierId ;
      private Guid[] BC001E3_A430PreferredAgbOrganisationId ;
      private Guid[] BC001E3_A425PreferredSupplierAgbId ;
      private Guid[] BC001E2_A428PreferredAgbSupplierId ;
      private Guid[] BC001E2_A430PreferredAgbOrganisationId ;
      private Guid[] BC001E2_A425PreferredSupplierAgbId ;
      private Guid[] BC001E9_A428PreferredAgbSupplierId ;
      private Guid[] BC001E9_A430PreferredAgbOrganisationId ;
      private Guid[] BC001E9_A425PreferredSupplierAgbId ;
      private SdtTrn_PreferredAgbSupplier bcTrn_PreferredAgbSupplier ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_preferredagbsupplier_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_preferredagbsupplier_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_preferredagbsupplier_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001E2;
       prmBC001E2 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E3;
       prmBC001E3 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E4;
       prmBC001E4 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E5;
       prmBC001E5 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E6;
       prmBC001E6 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredAgbOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierAgbId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E7;
       prmBC001E7 = new Object[] {
       new ParDef("PreferredAgbOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierAgbId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E8;
       prmBC001E8 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E9;
       prmBC001E9 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001E2", "SELECT PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId  FOR UPDATE OF Trn_PreferredAgbSupplier",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E3", "SELECT PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E4", "SELECT TM1.PreferredAgbSupplierId, TM1.PreferredAgbOrganisationId, TM1.PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier TM1 WHERE TM1.PreferredAgbSupplierId = :PreferredAgbSupplierId ORDER BY TM1.PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E5", "SELECT PreferredAgbSupplierId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E6", "SAVEPOINT gxupdate;INSERT INTO Trn_PreferredAgbSupplier(PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId) VALUES(:PreferredAgbSupplierId, :PreferredAgbOrganisationId, :PreferredSupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001E6)
          ,new CursorDef("BC001E7", "SAVEPOINT gxupdate;UPDATE Trn_PreferredAgbSupplier SET PreferredAgbOrganisationId=:PreferredAgbOrganisationId, PreferredSupplierAgbId=:PreferredSupplierAgbId  WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E7)
          ,new CursorDef("BC001E8", "SAVEPOINT gxupdate;DELETE FROM Trn_PreferredAgbSupplier  WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E8)
          ,new CursorDef("BC001E9", "SELECT TM1.PreferredAgbSupplierId, TM1.PreferredAgbOrganisationId, TM1.PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier TM1 WHERE TM1.PreferredAgbSupplierId = :PreferredAgbSupplierId ORDER BY TM1.PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E9,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
