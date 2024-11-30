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
   public class trn_col_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_col_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_col_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1972( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1972( ) ;
         standaloneModal( ) ;
         AddRow1972( ) ;
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
            E11192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z328Trn_ColId = A328Trn_ColId;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1972( ) ;
            }
            else
            {
               CheckExtendedTable1972( ) ;
               if ( AnyError == 0 )
               {
                  ZM1972( 9) ;
                  ZM1972( 10) ;
               }
               CloseExtendedTableCursors1972( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12192( )
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
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "Trn_RowId") == 0 )
               {
                  AV13Insert_Trn_RowId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "TileId") == 0 )
               {
                  AV26Insert_TileId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
         }
      }

      protected void E11192( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1972( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z327Trn_ColName = A327Trn_ColName;
            Z319Trn_RowId = A319Trn_RowId;
            Z407TileId = A407TileId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z328Trn_ColId = A328Trn_ColId;
            Z327Trn_ColName = A327Trn_ColName;
            Z319Trn_RowId = A319Trn_RowId;
            Z407TileId = A407TileId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV27Pgmname = "Trn_Col_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A328Trn_ColId) )
         {
            A328Trn_ColId = Guid.NewGuid( );
         }
         A327Trn_ColName = Guid.NewGuid( ).ToString();
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1972( )
      {
         /* Using cursor BC00196 */
         pr_default.execute(4, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound72 = 1;
            A327Trn_ColName = BC00196_A327Trn_ColName[0];
            A319Trn_RowId = BC00196_A319Trn_RowId[0];
            A407TileId = BC00196_A407TileId[0];
            ZM1972( -8) ;
         }
         pr_default.close(4);
         OnLoadActions1972( ) ;
      }

      protected void OnLoadActions1972( )
      {
      }

      protected void CheckExtendedTable1972( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00194 */
         pr_default.execute(2, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Row", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_ROWID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00195 */
         pr_default.execute(3, new Object[] {A407TileId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TILEID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1972( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1972( )
      {
         /* Using cursor BC00197 */
         pr_default.execute(5, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00193 */
         pr_default.execute(1, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1972( 8) ;
            RcdFound72 = 1;
            A328Trn_ColId = BC00193_A328Trn_ColId[0];
            A327Trn_ColName = BC00193_A327Trn_ColName[0];
            A319Trn_RowId = BC00193_A319Trn_RowId[0];
            A407TileId = BC00193_A407TileId[0];
            Z328Trn_ColId = A328Trn_ColId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1972( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1972( ) ;
            }
            Gx_mode = sMode72;
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1972( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode72;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1972( ) ;
         if ( RcdFound72 == 0 )
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
         CONFIRM_190( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1972( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00192 */
            pr_default.execute(0, new Object[] {A328Trn_ColId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z327Trn_ColName, BC00192_A327Trn_ColName[0]) != 0 ) || ( Z319Trn_RowId != BC00192_A319Trn_RowId[0] ) || ( Z407TileId != BC00192_A407TileId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Col"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1972( )
      {
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1972( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1972( 0) ;
            CheckOptimisticConcurrency1972( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1972( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1972( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00198 */
                     pr_default.execute(6, new Object[] {A328Trn_ColId, A327Trn_ColName, A319Trn_RowId, A407TileId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
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
               Load1972( ) ;
            }
            EndLevel1972( ) ;
         }
         CloseExtendedTableCursors1972( ) ;
      }

      protected void Update1972( )
      {
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1972( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1972( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1972( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1972( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00199 */
                     pr_default.execute(7, new Object[] {A327Trn_ColName, A319Trn_RowId, A407TileId, A328Trn_ColId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1972( ) ;
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
            EndLevel1972( ) ;
         }
         CloseExtendedTableCursors1972( ) ;
      }

      protected void DeferredUpdate1972( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1972( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1972( ) ;
            AfterConfirm1972( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1972( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001910 */
                  pr_default.execute(8, new Object[] {A328Trn_ColId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1972( ) ;
         Gx_mode = sMode72;
      }

      protected void OnDeleteControls1972( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1972( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1972( ) ;
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

      public void ScanKeyStart1972( )
      {
         /* Scan By routine */
         /* Using cursor BC001911 */
         pr_default.execute(9, new Object[] {A328Trn_ColId});
         RcdFound72 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound72 = 1;
            A328Trn_ColId = BC001911_A328Trn_ColId[0];
            A327Trn_ColName = BC001911_A327Trn_ColName[0];
            A319Trn_RowId = BC001911_A319Trn_RowId[0];
            A407TileId = BC001911_A407TileId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1972( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound72 = 0;
         ScanKeyLoad1972( ) ;
      }

      protected void ScanKeyLoad1972( )
      {
         sMode72 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound72 = 1;
            A328Trn_ColId = BC001911_A328Trn_ColId[0];
            A327Trn_ColName = BC001911_A327Trn_ColName[0];
            A319Trn_RowId = BC001911_A319Trn_RowId[0];
            A407TileId = BC001911_A407TileId[0];
         }
         Gx_mode = sMode72;
      }

      protected void ScanKeyEnd1972( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1972( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1972( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1972( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1972( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1972( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1972( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1972( )
      {
      }

      protected void send_integrity_lvl_hashes1972( )
      {
      }

      protected void AddRow1972( )
      {
         VarsToRow72( bcTrn_Col) ;
      }

      protected void ReadRow1972( )
      {
         RowToVars72( bcTrn_Col, 1) ;
      }

      protected void InitializeNonKey1972( )
      {
         A327Trn_ColName = "";
         A319Trn_RowId = Guid.Empty;
         A407TileId = Guid.Empty;
         Z327Trn_ColName = "";
         Z319Trn_RowId = Guid.Empty;
         Z407TileId = Guid.Empty;
      }

      protected void InitAll1972( )
      {
         A328Trn_ColId = Guid.NewGuid( );
         InitializeNonKey1972( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A327Trn_ColName = i327Trn_ColName;
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

      public void VarsToRow72( SdtTrn_Col obj72 )
      {
         obj72.gxTpr_Mode = Gx_mode;
         obj72.gxTpr_Trn_colname = A327Trn_ColName;
         obj72.gxTpr_Trn_rowid = A319Trn_RowId;
         obj72.gxTpr_Tileid = A407TileId;
         obj72.gxTpr_Trn_colid = A328Trn_ColId;
         obj72.gxTpr_Trn_colid_Z = Z328Trn_ColId;
         obj72.gxTpr_Trn_rowid_Z = Z319Trn_RowId;
         obj72.gxTpr_Trn_colname_Z = Z327Trn_ColName;
         obj72.gxTpr_Tileid_Z = Z407TileId;
         obj72.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow72( SdtTrn_Col obj72 )
      {
         obj72.gxTpr_Trn_colid = A328Trn_ColId;
         return  ;
      }

      public void RowToVars72( SdtTrn_Col obj72 ,
                               int forceLoad )
      {
         Gx_mode = obj72.gxTpr_Mode;
         A327Trn_ColName = obj72.gxTpr_Trn_colname;
         A319Trn_RowId = obj72.gxTpr_Trn_rowid;
         A407TileId = obj72.gxTpr_Tileid;
         A328Trn_ColId = obj72.gxTpr_Trn_colid;
         Z328Trn_ColId = obj72.gxTpr_Trn_colid_Z;
         Z319Trn_RowId = obj72.gxTpr_Trn_rowid_Z;
         Z327Trn_ColName = obj72.gxTpr_Trn_colname_Z;
         Z407TileId = obj72.gxTpr_Tileid_Z;
         Gx_mode = obj72.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A328Trn_ColId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1972( ) ;
         ScanKeyStart1972( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z328Trn_ColId = A328Trn_ColId;
         }
         ZM1972( -8) ;
         OnLoadActions1972( ) ;
         AddRow1972( ) ;
         ScanKeyEnd1972( ) ;
         if ( RcdFound72 == 0 )
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
         RowToVars72( bcTrn_Col, 0) ;
         ScanKeyStart1972( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z328Trn_ColId = A328Trn_ColId;
         }
         ZM1972( -8) ;
         OnLoadActions1972( ) ;
         AddRow1972( ) ;
         ScanKeyEnd1972( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1972( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1972( ) ;
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A328Trn_ColId != Z328Trn_ColId )
               {
                  A328Trn_ColId = Z328Trn_ColId;
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
                  Update1972( ) ;
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
                  if ( A328Trn_ColId != Z328Trn_ColId )
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
                        Insert1972( ) ;
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
                        Insert1972( ) ;
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
         RowToVars72( bcTrn_Col, 1) ;
         SaveImpl( ) ;
         VarsToRow72( bcTrn_Col) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_Col, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1972( ) ;
         AfterTrn( ) ;
         VarsToRow72( bcTrn_Col) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow72( bcTrn_Col) ;
         }
         else
         {
            SdtTrn_Col auxBC = new SdtTrn_Col(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A328Trn_ColId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Col);
               auxBC.Save();
               bcTrn_Col.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars72( bcTrn_Col, 1) ;
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
         RowToVars72( bcTrn_Col, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1972( ) ;
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
               VarsToRow72( bcTrn_Col) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow72( bcTrn_Col) ;
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
         RowToVars72( bcTrn_Col, 0) ;
         GetKey1972( ) ;
         if ( RcdFound72 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A328Trn_ColId != Z328Trn_ColId )
            {
               A328Trn_ColId = Z328Trn_ColId;
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
            if ( A328Trn_ColId != Z328Trn_ColId )
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
         context.RollbackDataStores("trn_col_bc",pr_default);
         VarsToRow72( bcTrn_Col) ;
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
         Gx_mode = bcTrn_Col.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Col.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Col )
         {
            bcTrn_Col = (SdtTrn_Col)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Col.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Col.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow72( bcTrn_Col) ;
            }
            else
            {
               RowToVars72( bcTrn_Col, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Col.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Col.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars72( bcTrn_Col, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Col Trn_Col_BC
      {
         get {
            return bcTrn_Col ;
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
            return "trn_col_Execute" ;
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
         Z328Trn_ColId = Guid.Empty;
         A328Trn_ColId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV27Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_Trn_RowId = Guid.Empty;
         AV26Insert_TileId = Guid.Empty;
         Z327Trn_ColName = "";
         A327Trn_ColName = "";
         Z319Trn_RowId = Guid.Empty;
         A319Trn_RowId = Guid.Empty;
         Z407TileId = Guid.Empty;
         A407TileId = Guid.Empty;
         BC00196_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC00196_A327Trn_ColName = new string[] {""} ;
         BC00196_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00196_A407TileId = new Guid[] {Guid.Empty} ;
         BC00194_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00195_A407TileId = new Guid[] {Guid.Empty} ;
         BC00197_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC00193_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC00193_A327Trn_ColName = new string[] {""} ;
         BC00193_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00193_A407TileId = new Guid[] {Guid.Empty} ;
         sMode72 = "";
         BC00192_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC00192_A327Trn_ColName = new string[] {""} ;
         BC00192_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00192_A407TileId = new Guid[] {Guid.Empty} ;
         BC001911_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC001911_A327Trn_ColName = new string[] {""} ;
         BC001911_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC001911_A407TileId = new Guid[] {Guid.Empty} ;
         i327Trn_ColName = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_col_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_col_bc__default(),
            new Object[][] {
                new Object[] {
               BC00192_A328Trn_ColId, BC00192_A327Trn_ColName, BC00192_A319Trn_RowId, BC00192_A407TileId
               }
               , new Object[] {
               BC00193_A328Trn_ColId, BC00193_A327Trn_ColName, BC00193_A319Trn_RowId, BC00193_A407TileId
               }
               , new Object[] {
               BC00194_A319Trn_RowId
               }
               , new Object[] {
               BC00195_A407TileId
               }
               , new Object[] {
               BC00196_A328Trn_ColId, BC00196_A327Trn_ColName, BC00196_A319Trn_RowId, BC00196_A407TileId
               }
               , new Object[] {
               BC00197_A328Trn_ColId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001911_A328Trn_ColId, BC001911_A327Trn_ColName, BC001911_A319Trn_RowId, BC001911_A407TileId
               }
            }
         );
         Z328Trn_ColId = Guid.NewGuid( );
         A328Trn_ColId = Guid.NewGuid( );
         AV27Pgmname = "Trn_Col_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12192 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound72 ;
      private int trnEnded ;
      private int AV28GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV27Pgmname ;
      private string sMode72 ;
      private bool returnInSub ;
      private string Z327Trn_ColName ;
      private string A327Trn_ColName ;
      private string i327Trn_ColName ;
      private Guid Z328Trn_ColId ;
      private Guid A328Trn_ColId ;
      private Guid AV13Insert_Trn_RowId ;
      private Guid AV26Insert_TileId ;
      private Guid Z319Trn_RowId ;
      private Guid A319Trn_RowId ;
      private Guid Z407TileId ;
      private Guid A407TileId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00196_A328Trn_ColId ;
      private string[] BC00196_A327Trn_ColName ;
      private Guid[] BC00196_A319Trn_RowId ;
      private Guid[] BC00196_A407TileId ;
      private Guid[] BC00194_A319Trn_RowId ;
      private Guid[] BC00195_A407TileId ;
      private Guid[] BC00197_A328Trn_ColId ;
      private Guid[] BC00193_A328Trn_ColId ;
      private string[] BC00193_A327Trn_ColName ;
      private Guid[] BC00193_A319Trn_RowId ;
      private Guid[] BC00193_A407TileId ;
      private Guid[] BC00192_A328Trn_ColId ;
      private string[] BC00192_A327Trn_ColName ;
      private Guid[] BC00192_A319Trn_RowId ;
      private Guid[] BC00192_A407TileId ;
      private Guid[] BC001911_A328Trn_ColId ;
      private string[] BC001911_A327Trn_ColName ;
      private Guid[] BC001911_A319Trn_RowId ;
      private Guid[] BC001911_A407TileId ;
      private SdtTrn_Col bcTrn_Col ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_col_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_col_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00192;
        prmBC00192 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00193;
        prmBC00193 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00194;
        prmBC00194 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00195;
        prmBC00195 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00196;
        prmBC00196 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00197;
        prmBC00197 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00198;
        prmBC00198 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ColName",GXType.VarChar,100,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00199;
        prmBC00199 = new Object[] {
        new ParDef("Trn_ColName",GXType.VarChar,100,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001910;
        prmBC001910 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001911;
        prmBC001911 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00192", "SELECT Trn_ColId, Trn_ColName, Trn_RowId, TileId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId  FOR UPDATE OF Trn_Col",true, GxErrorMask.GX_NOMASK, false, this,prmBC00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00193", "SELECT Trn_ColId, Trn_ColName, Trn_RowId, TileId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00194", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00195", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00195,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00196", "SELECT TM1.Trn_ColId, TM1.Trn_ColName, TM1.Trn_RowId, TM1.TileId FROM Trn_Col TM1 WHERE TM1.Trn_ColId = :Trn_ColId ORDER BY TM1.Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00196,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00197", "SELECT Trn_ColId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00197,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00198", "SAVEPOINT gxupdate;INSERT INTO Trn_Col(Trn_ColId, Trn_ColName, Trn_RowId, TileId) VALUES(:Trn_ColId, :Trn_ColName, :Trn_RowId, :TileId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00198)
           ,new CursorDef("BC00199", "SAVEPOINT gxupdate;UPDATE Trn_Col SET Trn_ColName=:Trn_ColName, Trn_RowId=:Trn_RowId, TileId=:TileId  WHERE Trn_ColId = :Trn_ColId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00199)
           ,new CursorDef("BC001910", "SAVEPOINT gxupdate;DELETE FROM Trn_Col  WHERE Trn_ColId = :Trn_ColId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001910)
           ,new CursorDef("BC001911", "SELECT TM1.Trn_ColId, TM1.Trn_ColName, TM1.Trn_RowId, TM1.TileId FROM Trn_Col TM1 WHERE TM1.Trn_ColId = :Trn_ColId ORDER BY TM1.Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001911,100, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
     }
  }

}

}
