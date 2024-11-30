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
   public class trn_row_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_row_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_row_bc( IGxContext context )
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
         ReadRow1870( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1870( ) ;
         standaloneModal( ) ;
         AddRow1870( ) ;
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
            E11182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z319Trn_RowId = A319Trn_RowId;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1870( ) ;
            }
            else
            {
               CheckExtendedTable1870( ) ;
               if ( AnyError == 0 )
               {
                  ZM1870( 8) ;
               }
               CloseExtendedTableCursors1870( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12182( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "Trn_PageId") == 0 )
               {
                  AV13Insert_Trn_PageId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E11182( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1870( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z320Trn_RowName = A320Trn_RowName;
            Z310Trn_PageId = A310Trn_PageId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z318Trn_PageName = A318Trn_PageName;
         }
         if ( GX_JID == -7 )
         {
            Z319Trn_RowId = A319Trn_RowId;
            Z320Trn_RowName = A320Trn_RowName;
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Trn_Row_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A319Trn_RowId) )
         {
            A319Trn_RowId = Guid.NewGuid( );
         }
         A320Trn_RowName = Guid.NewGuid( ).ToString();
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1870( )
      {
         /* Using cursor BC00185 */
         pr_default.execute(3, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound70 = 1;
            A320Trn_RowName = BC00185_A320Trn_RowName[0];
            A318Trn_PageName = BC00185_A318Trn_PageName[0];
            A310Trn_PageId = BC00185_A310Trn_PageId[0];
            ZM1870( -7) ;
         }
         pr_default.close(3);
         OnLoadActions1870( ) ;
      }

      protected void OnLoadActions1870( )
      {
      }

      protected void CheckExtendedTable1870( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00184 */
         pr_default.execute(2, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_PAGEID");
            AnyError = 1;
         }
         A318Trn_PageName = BC00184_A318Trn_PageName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1870( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1870( )
      {
         /* Using cursor BC00186 */
         pr_default.execute(4, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00183 */
         pr_default.execute(1, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1870( 7) ;
            RcdFound70 = 1;
            A319Trn_RowId = BC00183_A319Trn_RowId[0];
            A320Trn_RowName = BC00183_A320Trn_RowName[0];
            A310Trn_PageId = BC00183_A310Trn_PageId[0];
            Z319Trn_RowId = A319Trn_RowId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1870( ) ;
            if ( AnyError == 1 )
            {
               RcdFound70 = 0;
               InitializeNonKey1870( ) ;
            }
            Gx_mode = sMode70;
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1870( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode70;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1870( ) ;
         if ( RcdFound70 == 0 )
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
         CONFIRM_180( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1870( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00182 */
            pr_default.execute(0, new Object[] {A319Trn_RowId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Row"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z320Trn_RowName, BC00182_A320Trn_RowName[0]) != 0 ) || ( Z310Trn_PageId != BC00182_A310Trn_PageId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Row"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1870( )
      {
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1870( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1870( 0) ;
            CheckOptimisticConcurrency1870( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1870( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1870( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00187 */
                     pr_default.execute(5, new Object[] {A319Trn_RowId, A320Trn_RowName, A310Trn_PageId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
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
               Load1870( ) ;
            }
            EndLevel1870( ) ;
         }
         CloseExtendedTableCursors1870( ) ;
      }

      protected void Update1870( )
      {
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1870( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1870( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1870( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1870( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00188 */
                     pr_default.execute(6, new Object[] {A320Trn_RowName, A310Trn_PageId, A319Trn_RowId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Row"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1870( ) ;
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
            EndLevel1870( ) ;
         }
         CloseExtendedTableCursors1870( ) ;
      }

      protected void DeferredUpdate1870( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1870( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1870( ) ;
            AfterConfirm1870( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1870( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00189 */
                  pr_default.execute(7, new Object[] {A319Trn_RowId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1870( ) ;
         Gx_mode = sMode70;
      }

      protected void OnDeleteControls1870( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001810 */
            pr_default.execute(8, new Object[] {A310Trn_PageId});
            A318Trn_PageName = BC001810_A318Trn_PageName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001811 */
            pr_default.execute(9, new Object[] {A319Trn_RowId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1870( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1870( ) ;
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

      public void ScanKeyStart1870( )
      {
         /* Scan By routine */
         /* Using cursor BC001812 */
         pr_default.execute(10, new Object[] {A319Trn_RowId});
         RcdFound70 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound70 = 1;
            A319Trn_RowId = BC001812_A319Trn_RowId[0];
            A320Trn_RowName = BC001812_A320Trn_RowName[0];
            A318Trn_PageName = BC001812_A318Trn_PageName[0];
            A310Trn_PageId = BC001812_A310Trn_PageId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1870( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound70 = 0;
         ScanKeyLoad1870( ) ;
      }

      protected void ScanKeyLoad1870( )
      {
         sMode70 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound70 = 1;
            A319Trn_RowId = BC001812_A319Trn_RowId[0];
            A320Trn_RowName = BC001812_A320Trn_RowName[0];
            A318Trn_PageName = BC001812_A318Trn_PageName[0];
            A310Trn_PageId = BC001812_A310Trn_PageId[0];
         }
         Gx_mode = sMode70;
      }

      protected void ScanKeyEnd1870( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1870( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1870( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1870( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1870( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1870( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1870( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1870( )
      {
      }

      protected void send_integrity_lvl_hashes1870( )
      {
      }

      protected void AddRow1870( )
      {
         VarsToRow70( bcTrn_Row) ;
      }

      protected void ReadRow1870( )
      {
         RowToVars70( bcTrn_Row, 1) ;
      }

      protected void InitializeNonKey1870( )
      {
         A320Trn_RowName = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         Z320Trn_RowName = "";
         Z310Trn_PageId = Guid.Empty;
      }

      protected void InitAll1870( )
      {
         A319Trn_RowId = Guid.NewGuid( );
         InitializeNonKey1870( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A320Trn_RowName = i320Trn_RowName;
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

      public void VarsToRow70( SdtTrn_Row obj70 )
      {
         obj70.gxTpr_Mode = Gx_mode;
         obj70.gxTpr_Trn_rowname = A320Trn_RowName;
         obj70.gxTpr_Trn_pageid = A310Trn_PageId;
         obj70.gxTpr_Trn_pagename = A318Trn_PageName;
         obj70.gxTpr_Trn_rowid = A319Trn_RowId;
         obj70.gxTpr_Trn_rowid_Z = Z319Trn_RowId;
         obj70.gxTpr_Trn_rowname_Z = Z320Trn_RowName;
         obj70.gxTpr_Trn_pageid_Z = Z310Trn_PageId;
         obj70.gxTpr_Trn_pagename_Z = Z318Trn_PageName;
         obj70.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow70( SdtTrn_Row obj70 )
      {
         obj70.gxTpr_Trn_rowid = A319Trn_RowId;
         return  ;
      }

      public void RowToVars70( SdtTrn_Row obj70 ,
                               int forceLoad )
      {
         Gx_mode = obj70.gxTpr_Mode;
         A320Trn_RowName = obj70.gxTpr_Trn_rowname;
         A310Trn_PageId = obj70.gxTpr_Trn_pageid;
         A318Trn_PageName = obj70.gxTpr_Trn_pagename;
         A319Trn_RowId = obj70.gxTpr_Trn_rowid;
         Z319Trn_RowId = obj70.gxTpr_Trn_rowid_Z;
         Z320Trn_RowName = obj70.gxTpr_Trn_rowname_Z;
         Z310Trn_PageId = obj70.gxTpr_Trn_pageid_Z;
         Z318Trn_PageName = obj70.gxTpr_Trn_pagename_Z;
         Gx_mode = obj70.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A319Trn_RowId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1870( ) ;
         ScanKeyStart1870( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z319Trn_RowId = A319Trn_RowId;
         }
         ZM1870( -7) ;
         OnLoadActions1870( ) ;
         AddRow1870( ) ;
         ScanKeyEnd1870( ) ;
         if ( RcdFound70 == 0 )
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
         RowToVars70( bcTrn_Row, 0) ;
         ScanKeyStart1870( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z319Trn_RowId = A319Trn_RowId;
         }
         ZM1870( -7) ;
         OnLoadActions1870( ) ;
         AddRow1870( ) ;
         ScanKeyEnd1870( ) ;
         if ( RcdFound70 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1870( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1870( ) ;
         }
         else
         {
            if ( RcdFound70 == 1 )
            {
               if ( A319Trn_RowId != Z319Trn_RowId )
               {
                  A319Trn_RowId = Z319Trn_RowId;
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
                  Update1870( ) ;
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
                  if ( A319Trn_RowId != Z319Trn_RowId )
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
                        Insert1870( ) ;
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
                        Insert1870( ) ;
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
         RowToVars70( bcTrn_Row, 1) ;
         SaveImpl( ) ;
         VarsToRow70( bcTrn_Row) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars70( bcTrn_Row, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1870( ) ;
         AfterTrn( ) ;
         VarsToRow70( bcTrn_Row) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow70( bcTrn_Row) ;
         }
         else
         {
            SdtTrn_Row auxBC = new SdtTrn_Row(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A319Trn_RowId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Row);
               auxBC.Save();
               bcTrn_Row.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars70( bcTrn_Row, 1) ;
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
         RowToVars70( bcTrn_Row, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1870( ) ;
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
               VarsToRow70( bcTrn_Row) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow70( bcTrn_Row) ;
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
         RowToVars70( bcTrn_Row, 0) ;
         GetKey1870( ) ;
         if ( RcdFound70 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A319Trn_RowId != Z319Trn_RowId )
            {
               A319Trn_RowId = Z319Trn_RowId;
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
            if ( A319Trn_RowId != Z319Trn_RowId )
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
         context.RollbackDataStores("trn_row_bc",pr_default);
         VarsToRow70( bcTrn_Row) ;
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
         Gx_mode = bcTrn_Row.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Row.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Row )
         {
            bcTrn_Row = (SdtTrn_Row)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Row.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Row.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow70( bcTrn_Row) ;
            }
            else
            {
               RowToVars70( bcTrn_Row, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Row.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Row.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars70( bcTrn_Row, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Row Trn_Row_BC
      {
         get {
            return bcTrn_Row ;
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
            return "trn_row_Execute" ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z319Trn_RowId = Guid.Empty;
         A319Trn_RowId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV23Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_Trn_PageId = Guid.Empty;
         Z320Trn_RowName = "";
         A320Trn_RowName = "";
         Z310Trn_PageId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         Z318Trn_PageName = "";
         A318Trn_PageName = "";
         BC00185_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00185_A320Trn_RowName = new string[] {""} ;
         BC00185_A318Trn_PageName = new string[] {""} ;
         BC00185_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00184_A318Trn_PageName = new string[] {""} ;
         BC00186_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00183_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00183_A320Trn_RowName = new string[] {""} ;
         BC00183_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         sMode70 = "";
         BC00182_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC00182_A320Trn_RowName = new string[] {""} ;
         BC00182_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC001810_A318Trn_PageName = new string[] {""} ;
         BC001811_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC001812_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC001812_A320Trn_RowName = new string[] {""} ;
         BC001812_A318Trn_PageName = new string[] {""} ;
         BC001812_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         i320Trn_RowName = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_row_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_row_bc__default(),
            new Object[][] {
                new Object[] {
               BC00182_A319Trn_RowId, BC00182_A320Trn_RowName, BC00182_A310Trn_PageId
               }
               , new Object[] {
               BC00183_A319Trn_RowId, BC00183_A320Trn_RowName, BC00183_A310Trn_PageId
               }
               , new Object[] {
               BC00184_A318Trn_PageName
               }
               , new Object[] {
               BC00185_A319Trn_RowId, BC00185_A320Trn_RowName, BC00185_A318Trn_PageName, BC00185_A310Trn_PageId
               }
               , new Object[] {
               BC00186_A319Trn_RowId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001810_A318Trn_PageName
               }
               , new Object[] {
               BC001811_A328Trn_ColId
               }
               , new Object[] {
               BC001812_A319Trn_RowId, BC001812_A320Trn_RowName, BC001812_A318Trn_PageName, BC001812_A310Trn_PageId
               }
            }
         );
         Z319Trn_RowId = Guid.NewGuid( );
         A319Trn_RowId = Guid.NewGuid( );
         AV23Pgmname = "Trn_Row_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12182 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound70 ;
      private int trnEnded ;
      private int AV24GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string sMode70 ;
      private bool returnInSub ;
      private string Z320Trn_RowName ;
      private string A320Trn_RowName ;
      private string Z318Trn_PageName ;
      private string A318Trn_PageName ;
      private string i320Trn_RowName ;
      private Guid Z319Trn_RowId ;
      private Guid A319Trn_RowId ;
      private Guid AV13Insert_Trn_PageId ;
      private Guid Z310Trn_PageId ;
      private Guid A310Trn_PageId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00185_A319Trn_RowId ;
      private string[] BC00185_A320Trn_RowName ;
      private string[] BC00185_A318Trn_PageName ;
      private Guid[] BC00185_A310Trn_PageId ;
      private string[] BC00184_A318Trn_PageName ;
      private Guid[] BC00186_A319Trn_RowId ;
      private Guid[] BC00183_A319Trn_RowId ;
      private string[] BC00183_A320Trn_RowName ;
      private Guid[] BC00183_A310Trn_PageId ;
      private Guid[] BC00182_A319Trn_RowId ;
      private string[] BC00182_A320Trn_RowName ;
      private Guid[] BC00182_A310Trn_PageId ;
      private string[] BC001810_A318Trn_PageName ;
      private Guid[] BC001811_A328Trn_ColId ;
      private Guid[] BC001812_A319Trn_RowId ;
      private string[] BC001812_A320Trn_RowName ;
      private string[] BC001812_A318Trn_PageName ;
      private Guid[] BC001812_A310Trn_PageId ;
      private SdtTrn_Row bcTrn_Row ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_row_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_row_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00182;
        prmBC00182 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00183;
        prmBC00183 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00184;
        prmBC00184 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00185;
        prmBC00185 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00186;
        prmBC00186 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00187;
        prmBC00187 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00188;
        prmBC00188 = new Object[] {
        new ParDef("Trn_RowName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00189;
        prmBC00189 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001810;
        prmBC001810 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001811;
        prmBC001811 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001812;
        prmBC001812 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00182", "SELECT Trn_RowId, Trn_RowName, Trn_PageId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId  FOR UPDATE OF Trn_Row",true, GxErrorMask.GX_NOMASK, false, this,prmBC00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00183", "SELECT Trn_RowId, Trn_RowName, Trn_PageId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00184", "SELECT Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00185", "SELECT TM1.Trn_RowId, TM1.Trn_RowName, T2.Trn_PageName, TM1.Trn_PageId FROM (Trn_Row TM1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.Trn_PageId) WHERE TM1.Trn_RowId = :Trn_RowId ORDER BY TM1.Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00185,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00186", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00186,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00187", "SAVEPOINT gxupdate;INSERT INTO Trn_Row(Trn_RowId, Trn_RowName, Trn_PageId) VALUES(:Trn_RowId, :Trn_RowName, :Trn_PageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00187)
           ,new CursorDef("BC00188", "SAVEPOINT gxupdate;UPDATE Trn_Row SET Trn_RowName=:Trn_RowName, Trn_PageId=:Trn_PageId  WHERE Trn_RowId = :Trn_RowId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00188)
           ,new CursorDef("BC00189", "SAVEPOINT gxupdate;DELETE FROM Trn_Row  WHERE Trn_RowId = :Trn_RowId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00189)
           ,new CursorDef("BC001810", "SELECT Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001810,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001811", "SELECT Trn_ColId FROM Trn_Col WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001812", "SELECT TM1.Trn_RowId, TM1.Trn_RowName, T2.Trn_PageName, TM1.Trn_PageId FROM (Trn_Row TM1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.Trn_PageId) WHERE TM1.Trn_RowId = :Trn_RowId ORDER BY TM1.Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001812,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
     }
  }

}

}
