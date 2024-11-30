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
   public class trn_preferredgensupplier_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_preferredgensupplier_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_preferredgensupplier_bc( IGxContext context )
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
         ReadRow1F86( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1F86( ) ;
         standaloneModal( ) ;
         AddRow1F86( ) ;
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
               Z427PreferredGenSupplierId = A427PreferredGenSupplierId;
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

      protected void CONFIRM_1F0( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1F86( ) ;
            }
            else
            {
               CheckExtendedTable1F86( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1F86( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1F86( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z426PreferredSupplierGenId = A426PreferredSupplierGenId;
            Z429PreferredGenOrganisationId = A429PreferredGenOrganisationId;
         }
         if ( GX_JID == -7 )
         {
            Z427PreferredGenSupplierId = A427PreferredGenSupplierId;
            Z426PreferredSupplierGenId = A426PreferredSupplierGenId;
            Z429PreferredGenOrganisationId = A429PreferredGenOrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A426PreferredSupplierGenId) )
         {
            A426PreferredSupplierGenId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (Guid.Empty==A427PreferredGenSupplierId) )
         {
            A427PreferredGenSupplierId = Guid.NewGuid( );
         }
         GXt_guid1 = A429PreferredGenOrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A429PreferredGenOrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1F86( )
      {
         /* Using cursor BC001F4 */
         pr_default.execute(2, new Object[] {A427PreferredGenSupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound86 = 1;
            A426PreferredSupplierGenId = BC001F4_A426PreferredSupplierGenId[0];
            A429PreferredGenOrganisationId = BC001F4_A429PreferredGenOrganisationId[0];
            ZM1F86( -7) ;
         }
         pr_default.close(2);
         OnLoadActions1F86( ) ;
      }

      protected void OnLoadActions1F86( )
      {
      }

      protected void CheckExtendedTable1F86( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1F86( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1F86( )
      {
         /* Using cursor BC001F5 */
         pr_default.execute(3, new Object[] {A427PreferredGenSupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001F3 */
         pr_default.execute(1, new Object[] {A427PreferredGenSupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F86( 7) ;
            RcdFound86 = 1;
            A427PreferredGenSupplierId = BC001F3_A427PreferredGenSupplierId[0];
            A426PreferredSupplierGenId = BC001F3_A426PreferredSupplierGenId[0];
            A429PreferredGenOrganisationId = BC001F3_A429PreferredGenOrganisationId[0];
            Z427PreferredGenSupplierId = A427PreferredGenSupplierId;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1F86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey1F86( ) ;
            }
            Gx_mode = sMode86;
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey1F86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode86;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F86( ) ;
         if ( RcdFound86 == 0 )
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
         CONFIRM_1F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1F86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001F2 */
            pr_default.execute(0, new Object[] {A427PreferredGenSupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z426PreferredSupplierGenId != BC001F2_A426PreferredSupplierGenId[0] ) || ( Z429PreferredGenOrganisationId != BC001F2_A429PreferredGenOrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F86( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F86( 0) ;
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F6 */
                     pr_default.execute(4, new Object[] {A427PreferredGenSupplierId, A426PreferredSupplierGenId, A429PreferredGenOrganisationId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
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
               Load1F86( ) ;
            }
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void Update1F86( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F7 */
                     pr_default.execute(5, new Object[] {A426PreferredSupplierGenId, A429PreferredGenOrganisationId, A427PreferredGenSupplierId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F86( ) ;
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
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void DeferredUpdate1F86( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F86( ) ;
            AfterConfirm1F86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001F8 */
                  pr_default.execute(6, new Object[] {A427PreferredGenSupplierId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1F86( ) ;
         Gx_mode = sMode86;
      }

      protected void OnDeleteControls1F86( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1F86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F86( ) ;
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

      public void ScanKeyStart1F86( )
      {
         /* Using cursor BC001F9 */
         pr_default.execute(7, new Object[] {A427PreferredGenSupplierId});
         RcdFound86 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound86 = 1;
            A427PreferredGenSupplierId = BC001F9_A427PreferredGenSupplierId[0];
            A426PreferredSupplierGenId = BC001F9_A426PreferredSupplierGenId[0];
            A429PreferredGenOrganisationId = BC001F9_A429PreferredGenOrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1F86( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound86 = 0;
         ScanKeyLoad1F86( ) ;
      }

      protected void ScanKeyLoad1F86( )
      {
         sMode86 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound86 = 1;
            A427PreferredGenSupplierId = BC001F9_A427PreferredGenSupplierId[0];
            A426PreferredSupplierGenId = BC001F9_A426PreferredSupplierGenId[0];
            A429PreferredGenOrganisationId = BC001F9_A429PreferredGenOrganisationId[0];
         }
         Gx_mode = sMode86;
      }

      protected void ScanKeyEnd1F86( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1F86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F86( )
      {
      }

      protected void send_integrity_lvl_hashes1F86( )
      {
      }

      protected void AddRow1F86( )
      {
         VarsToRow86( bcTrn_PreferredGenSupplier) ;
      }

      protected void ReadRow1F86( )
      {
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
      }

      protected void InitializeNonKey1F86( )
      {
         A429PreferredGenOrganisationId = Guid.Empty;
         A426PreferredSupplierGenId = Guid.NewGuid( );
         Z426PreferredSupplierGenId = Guid.Empty;
         Z429PreferredGenOrganisationId = Guid.Empty;
      }

      protected void InitAll1F86( )
      {
         A427PreferredGenSupplierId = Guid.NewGuid( );
         InitializeNonKey1F86( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A426PreferredSupplierGenId = i426PreferredSupplierGenId;
         A429PreferredGenOrganisationId = i429PreferredGenOrganisationId;
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

      public void VarsToRow86( SdtTrn_PreferredGenSupplier obj86 )
      {
         obj86.gxTpr_Mode = Gx_mode;
         obj86.gxTpr_Preferredgenorganisationid = A429PreferredGenOrganisationId;
         obj86.gxTpr_Preferredsuppliergenid = A426PreferredSupplierGenId;
         obj86.gxTpr_Preferredgensupplierid = A427PreferredGenSupplierId;
         obj86.gxTpr_Preferredgensupplierid_Z = Z427PreferredGenSupplierId;
         obj86.gxTpr_Preferredgenorganisationid_Z = Z429PreferredGenOrganisationId;
         obj86.gxTpr_Preferredsuppliergenid_Z = Z426PreferredSupplierGenId;
         obj86.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow86( SdtTrn_PreferredGenSupplier obj86 )
      {
         obj86.gxTpr_Preferredgensupplierid = A427PreferredGenSupplierId;
         return  ;
      }

      public void RowToVars86( SdtTrn_PreferredGenSupplier obj86 ,
                               int forceLoad )
      {
         Gx_mode = obj86.gxTpr_Mode;
         A429PreferredGenOrganisationId = obj86.gxTpr_Preferredgenorganisationid;
         A426PreferredSupplierGenId = obj86.gxTpr_Preferredsuppliergenid;
         A427PreferredGenSupplierId = obj86.gxTpr_Preferredgensupplierid;
         Z427PreferredGenSupplierId = obj86.gxTpr_Preferredgensupplierid_Z;
         Z429PreferredGenOrganisationId = obj86.gxTpr_Preferredgenorganisationid_Z;
         Z426PreferredSupplierGenId = obj86.gxTpr_Preferredsuppliergenid_Z;
         Gx_mode = obj86.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A427PreferredGenSupplierId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1F86( ) ;
         ScanKeyStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z427PreferredGenSupplierId = A427PreferredGenSupplierId;
         }
         ZM1F86( -7) ;
         OnLoadActions1F86( ) ;
         AddRow1F86( ) ;
         ScanKeyEnd1F86( ) ;
         if ( RcdFound86 == 0 )
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
         RowToVars86( bcTrn_PreferredGenSupplier, 0) ;
         ScanKeyStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z427PreferredGenSupplierId = A427PreferredGenSupplierId;
         }
         ZM1F86( -7) ;
         OnLoadActions1F86( ) ;
         AddRow1F86( ) ;
         ScanKeyEnd1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1F86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1F86( ) ;
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( A427PreferredGenSupplierId != Z427PreferredGenSupplierId )
               {
                  A427PreferredGenSupplierId = Z427PreferredGenSupplierId;
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
                  Update1F86( ) ;
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
                  if ( A427PreferredGenSupplierId != Z427PreferredGenSupplierId )
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
                        Insert1F86( ) ;
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
                        Insert1F86( ) ;
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
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
         SaveImpl( ) ;
         VarsToRow86( bcTrn_PreferredGenSupplier) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F86( ) ;
         AfterTrn( ) ;
         VarsToRow86( bcTrn_PreferredGenSupplier) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow86( bcTrn_PreferredGenSupplier) ;
         }
         else
         {
            SdtTrn_PreferredGenSupplier auxBC = new SdtTrn_PreferredGenSupplier(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A427PreferredGenSupplierId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_PreferredGenSupplier);
               auxBC.Save();
               bcTrn_PreferredGenSupplier.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
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
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F86( ) ;
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
               VarsToRow86( bcTrn_PreferredGenSupplier) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow86( bcTrn_PreferredGenSupplier) ;
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
         RowToVars86( bcTrn_PreferredGenSupplier, 0) ;
         GetKey1F86( ) ;
         if ( RcdFound86 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A427PreferredGenSupplierId != Z427PreferredGenSupplierId )
            {
               A427PreferredGenSupplierId = Z427PreferredGenSupplierId;
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
            if ( A427PreferredGenSupplierId != Z427PreferredGenSupplierId )
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
         context.RollbackDataStores("trn_preferredgensupplier_bc",pr_default);
         VarsToRow86( bcTrn_PreferredGenSupplier) ;
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
         Gx_mode = bcTrn_PreferredGenSupplier.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_PreferredGenSupplier.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_PreferredGenSupplier )
         {
            bcTrn_PreferredGenSupplier = (SdtTrn_PreferredGenSupplier)(sdt);
            if ( StringUtil.StrCmp(bcTrn_PreferredGenSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredGenSupplier.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow86( bcTrn_PreferredGenSupplier) ;
            }
            else
            {
               RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_PreferredGenSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredGenSupplier.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars86( bcTrn_PreferredGenSupplier, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_PreferredGenSupplier Trn_PreferredGenSupplier_BC
      {
         get {
            return bcTrn_PreferredGenSupplier ;
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
            return "trn_preferredgensupplier_Execute" ;
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
         Z427PreferredGenSupplierId = Guid.Empty;
         A427PreferredGenSupplierId = Guid.Empty;
         Z426PreferredSupplierGenId = Guid.Empty;
         A426PreferredSupplierGenId = Guid.Empty;
         Z429PreferredGenOrganisationId = Guid.Empty;
         A429PreferredGenOrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC001F4_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC001F4_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC001F4_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         BC001F5_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC001F3_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC001F3_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC001F3_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         sMode86 = "";
         BC001F2_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC001F2_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC001F2_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         BC001F9_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC001F9_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC001F9_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         i426PreferredSupplierGenId = Guid.Empty;
         i429PreferredGenOrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__default(),
            new Object[][] {
                new Object[] {
               BC001F2_A427PreferredGenSupplierId, BC001F2_A426PreferredSupplierGenId, BC001F2_A429PreferredGenOrganisationId
               }
               , new Object[] {
               BC001F3_A427PreferredGenSupplierId, BC001F3_A426PreferredSupplierGenId, BC001F3_A429PreferredGenOrganisationId
               }
               , new Object[] {
               BC001F4_A427PreferredGenSupplierId, BC001F4_A426PreferredSupplierGenId, BC001F4_A429PreferredGenOrganisationId
               }
               , new Object[] {
               BC001F5_A427PreferredGenSupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001F9_A427PreferredGenSupplierId, BC001F9_A426PreferredSupplierGenId, BC001F9_A429PreferredGenOrganisationId
               }
            }
         );
         Z426PreferredSupplierGenId = Guid.NewGuid( );
         A426PreferredSupplierGenId = Guid.NewGuid( );
         i426PreferredSupplierGenId = Guid.NewGuid( );
         Z427PreferredGenSupplierId = Guid.NewGuid( );
         A427PreferredGenSupplierId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound86 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode86 ;
      private Guid Z427PreferredGenSupplierId ;
      private Guid A427PreferredGenSupplierId ;
      private Guid Z426PreferredSupplierGenId ;
      private Guid A426PreferredSupplierGenId ;
      private Guid Z429PreferredGenOrganisationId ;
      private Guid A429PreferredGenOrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i426PreferredSupplierGenId ;
      private Guid i429PreferredGenOrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001F4_A427PreferredGenSupplierId ;
      private Guid[] BC001F4_A426PreferredSupplierGenId ;
      private Guid[] BC001F4_A429PreferredGenOrganisationId ;
      private Guid[] BC001F5_A427PreferredGenSupplierId ;
      private Guid[] BC001F3_A427PreferredGenSupplierId ;
      private Guid[] BC001F3_A426PreferredSupplierGenId ;
      private Guid[] BC001F3_A429PreferredGenOrganisationId ;
      private Guid[] BC001F2_A427PreferredGenSupplierId ;
      private Guid[] BC001F2_A426PreferredSupplierGenId ;
      private Guid[] BC001F2_A429PreferredGenOrganisationId ;
      private Guid[] BC001F9_A427PreferredGenSupplierId ;
      private Guid[] BC001F9_A426PreferredSupplierGenId ;
      private Guid[] BC001F9_A429PreferredGenOrganisationId ;
      private SdtTrn_PreferredGenSupplier bcTrn_PreferredGenSupplier ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_preferredgensupplier_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_preferredgensupplier_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_preferredgensupplier_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001F2;
       prmBC001F2 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F3;
       prmBC001F3 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F4;
       prmBC001F4 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F5;
       prmBC001F5 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F6;
       prmBC001F6 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenOrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F7;
       prmBC001F7 = new Object[] {
       new ParDef("PreferredSupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F8;
       prmBC001F8 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F9;
       prmBC001F9 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001F2", "SELECT PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId  FOR UPDATE OF Trn_PreferredGenSupplier",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F3", "SELECT PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F4", "SELECT TM1.PreferredGenSupplierId, TM1.PreferredSupplierGenId, TM1.PreferredGenOrganisationId FROM Trn_PreferredGenSupplier TM1 WHERE TM1.PreferredGenSupplierId = :PreferredGenSupplierId ORDER BY TM1.PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F5", "SELECT PreferredGenSupplierId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F6", "SAVEPOINT gxupdate;INSERT INTO Trn_PreferredGenSupplier(PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId) VALUES(:PreferredGenSupplierId, :PreferredSupplierGenId, :PreferredGenOrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001F6)
          ,new CursorDef("BC001F7", "SAVEPOINT gxupdate;UPDATE Trn_PreferredGenSupplier SET PreferredSupplierGenId=:PreferredSupplierGenId, PreferredGenOrganisationId=:PreferredGenOrganisationId  WHERE PreferredGenSupplierId = :PreferredGenSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F7)
          ,new CursorDef("BC001F8", "SAVEPOINT gxupdate;DELETE FROM Trn_PreferredGenSupplier  WHERE PreferredGenSupplierId = :PreferredGenSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F8)
          ,new CursorDef("BC001F9", "SELECT TM1.PreferredGenSupplierId, TM1.PreferredSupplierGenId, TM1.PreferredGenOrganisationId FROM Trn_PreferredGenSupplier TM1 WHERE TM1.PreferredGenSupplierId = :PreferredGenSupplierId ORDER BY TM1.PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F9,100, GxCacheFrequency.OFF ,true,false )
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
