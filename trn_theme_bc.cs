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
   public class trn_theme_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_theme_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme_bc( IGxContext context )
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
         ReadRow0W46( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0W46( ) ;
         standaloneModal( ) ;
         AddRow0W46( ) ;
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
            E110W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W46( ) ;
            }
            else
            {
               CheckExtendedTable0W46( ) ;
               if ( AnyError == 0 )
               {
                  ZM0W46( 15) ;
               }
               CloseExtendedTableCursors0W46( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode46 = Gx_mode;
            CONFIRM_0W112( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0W87( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode46;
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode46;
         }
      }

      protected void CONFIRM_0W47( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0W47( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound47 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_47 != 0 ) )
            {
               GetKey0W47( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W47( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0W47( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0W47( ) ;
                        Load0W47( ) ;
                        BeforeValidate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W47( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0W47( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W47( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0W47( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0W87( )
      {
         nGXsfl_87_idx = 0;
         while ( nGXsfl_87_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0W87( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound87 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_87 != 0 ) )
            {
               GetKey0W87( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound87 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0W87( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W87( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0W87( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound87 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0W87( ) ;
                        Load0W87( ) ;
                        BeforeValidate0W87( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W87( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_87 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0W87( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W87( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0W87( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow87( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_87_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0W112( )
      {
         nGXsfl_112_idx = 0;
         while ( nGXsfl_112_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
         {
            ReadRow0W112( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound112 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_112 != 0 ) )
            {
               GetKey0W112( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound112 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0W112( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W112( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0W112( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound112 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0W112( ) ;
                        Load0W112( ) ;
                        BeforeValidate0W112( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W112( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_112 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0W112( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W112( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0W112( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow112( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_112_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV14Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
         }
      }

      protected void E110W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0W46( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
            Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -14 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
            Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV16Pgmname = "Trn_Theme_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) )
         {
            A247Trn_ThemeId = Guid.NewGuid( );
            n247Trn_ThemeId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W46( )
      {
         /* Using cursor BC000W11 */
         pr_default.execute(9, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A248Trn_ThemeName = BC000W11_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W11_A260Trn_ThemeFontFamily[0];
            A399Trn_ThemeFontSize = BC000W11_A399Trn_ThemeFontSize[0];
            A11OrganisationId = BC000W11_A11OrganisationId[0];
            n11OrganisationId = BC000W11_n11OrganisationId[0];
            ZM0W46( -14) ;
         }
         pr_default.close(9);
         OnLoadActions0W46( ) ;
      }

      protected void OnLoadActions0W46( )
      {
         if ( (Guid.Empty==A11OrganisationId) )
         {
            A11OrganisationId = Guid.Empty;
            n11OrganisationId = false;
            n11OrganisationId = true;
         }
      }

      protected void CheckExtendedTable0W46( )
      {
         standaloneModal( ) ;
         if ( (Guid.Empty==A11OrganisationId) )
         {
            A11OrganisationId = Guid.Empty;
            n11OrganisationId = false;
            n11OrganisationId = true;
         }
         /* Using cursor BC000W10 */
         pr_default.execute(8, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(8);
      }

      protected void CloseExtendedTableCursors0W46( )
      {
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W46( )
      {
         /* Using cursor BC000W12 */
         pr_default.execute(10, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000W9 */
         pr_default.execute(7, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0W46( 14) ;
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W9_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC000W9_n247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W9_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W9_A260Trn_ThemeFontFamily[0];
            A399Trn_ThemeFontSize = BC000W9_A399Trn_ThemeFontSize[0];
            A11OrganisationId = BC000W9_A11OrganisationId[0];
            n11OrganisationId = BC000W9_n11OrganisationId[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0W46( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey0W46( ) ;
            }
            Gx_mode = sMode46;
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey0W46( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode46;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W46( ) ;
         if ( RcdFound46 == 0 )
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
         CONFIRM_0W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0W46( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W8 */
            pr_default.execute(6, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z248Trn_ThemeName, BC000W8_A248Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, BC000W8_A260Trn_ThemeFontFamily[0]) != 0 ) || ( Z399Trn_ThemeFontSize != BC000W8_A399Trn_ThemeFontSize[0] ) || ( Z11OrganisationId != BC000W8_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W46( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W46( 0) ;
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W13 */
                     pr_default.execute(11, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize, n11OrganisationId, A11OrganisationId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel0W46( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0W46( ) ;
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void Update0W46( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W14 */
                     pr_default.execute(12, new Object[] {A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize, n11OrganisationId, A11OrganisationId, n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W46( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0W46( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void DeferredUpdate0W46( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W46( ) ;
            AfterConfirm0W46( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W46( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0W112( ) ;
                  while ( RcdFound112 != 0 )
                  {
                     getByPrimaryKey0W112( ) ;
                     Delete0W112( ) ;
                     ScanKeyNext0W112( ) ;
                  }
                  ScanKeyEnd0W112( ) ;
                  ScanKeyStart0W87( ) ;
                  while ( RcdFound87 != 0 )
                  {
                     getByPrimaryKey0W87( ) ;
                     Delete0W87( ) ;
                     ScanKeyNext0W87( ) ;
                  }
                  ScanKeyEnd0W87( ) ;
                  ScanKeyStart0W47( ) ;
                  while ( RcdFound47 != 0 )
                  {
                     getByPrimaryKey0W47( ) ;
                     Delete0W47( ) ;
                     ScanKeyNext0W47( ) ;
                  }
                  ScanKeyEnd0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W15 */
                     pr_default.execute(13, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         }
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W46( ) ;
         Gx_mode = sMode46;
      }

      protected void OnDeleteControls0W46( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000W16 */
            pr_default.execute(14, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0W112( )
      {
         nGXsfl_112_idx = 0;
         while ( nGXsfl_112_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
         {
            ReadRow0W112( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound112 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_112 != 0 ) )
            {
               standaloneNotModal0W112( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0W112( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0W112( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0W112( ) ;
                  }
               }
            }
            KeyVarsToRow112( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_112_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_112_idx = 0;
            while ( nGXsfl_112_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
            {
               ReadRow0W112( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound112 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_Theme.gxTpr_Ctacolor.RemoveElement(nGXsfl_112_idx);
                  nGXsfl_112_idx = (int)(nGXsfl_112_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0W112( ) ;
                  VarsToRow112( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_112_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W112( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_112 = 0;
         nIsMod_112 = 0;
      }

      protected void ProcessNestedLevel0W87( )
      {
         nGXsfl_87_idx = 0;
         while ( nGXsfl_87_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0W87( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound87 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_87 != 0 ) )
            {
               standaloneNotModal0W87( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0W87( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0W87( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0W87( ) ;
                  }
               }
            }
            KeyVarsToRow87( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_87_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_87_idx = 0;
            while ( nGXsfl_87_idx < bcTrn_Theme.gxTpr_Icon.Count )
            {
               ReadRow0W87( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound87 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_Theme.gxTpr_Icon.RemoveElement(nGXsfl_87_idx);
                  nGXsfl_87_idx = (int)(nGXsfl_87_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0W87( ) ;
                  VarsToRow87( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_87_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W87( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_87 = 0;
         nIsMod_87 = 0;
      }

      protected void ProcessNestedLevel0W47( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0W47( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound47 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_47 != 0 ) )
            {
               standaloneNotModal0W47( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0W47( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0W47( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0W47( ) ;
                  }
               }
            }
            KeyVarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_47_idx = 0;
            while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
            {
               ReadRow0W47( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_Theme.gxTpr_Color.RemoveElement(nGXsfl_47_idx);
                  nGXsfl_47_idx = (int)(nGXsfl_47_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0W47( ) ;
                  VarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
      }

      protected void ProcessLevel0W46( )
      {
         /* Save parent mode. */
         sMode46 = Gx_mode;
         ProcessNestedLevel0W112( ) ;
         ProcessNestedLevel0W87( ) ;
         ProcessNestedLevel0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode46;
         /* ' Update level parameters */
      }

      protected void EndLevel0W46( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W46( ) ;
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

      public void ScanKeyStart0W46( )
      {
         /* Scan By routine */
         /* Using cursor BC000W17 */
         pr_default.execute(15, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W17_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC000W17_n247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W17_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W17_A260Trn_ThemeFontFamily[0];
            A399Trn_ThemeFontSize = BC000W17_A399Trn_ThemeFontSize[0];
            A11OrganisationId = BC000W17_A11OrganisationId[0];
            n11OrganisationId = BC000W17_n11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W46( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound46 = 0;
         ScanKeyLoad0W46( ) ;
      }

      protected void ScanKeyLoad0W46( )
      {
         sMode46 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W17_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC000W17_n247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W17_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W17_A260Trn_ThemeFontFamily[0];
            A399Trn_ThemeFontSize = BC000W17_A399Trn_ThemeFontSize[0];
            A11OrganisationId = BC000W17_A11OrganisationId[0];
            n11OrganisationId = BC000W17_n11OrganisationId[0];
         }
         Gx_mode = sMode46;
      }

      protected void ScanKeyEnd0W46( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0W46( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W46( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W46( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W46( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W46( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W46( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W46( )
      {
      }

      protected void ZM0W112( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z564CtaColorName = A564CtaColorName;
            Z565CtaColorCode = A565CtaColorCode;
         }
         if ( GX_JID == -16 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z563CtaColorId = A563CtaColorId;
            Z564CtaColorName = A564CtaColorName;
            Z565CtaColorCode = A565CtaColorCode;
         }
      }

      protected void standaloneNotModal0W112( )
      {
      }

      protected void standaloneModal0W112( )
      {
         if ( IsIns( )  && (Guid.Empty==A563CtaColorId) )
         {
            A563CtaColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W112( )
      {
         /* Using cursor BC000W18 */
         pr_default.execute(16, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound112 = 1;
            A564CtaColorName = BC000W18_A564CtaColorName[0];
            A565CtaColorCode = BC000W18_A565CtaColorCode[0];
            ZM0W112( -16) ;
         }
         pr_default.close(16);
         OnLoadActions0W112( ) ;
      }

      protected void OnLoadActions0W112( )
      {
      }

      protected void CheckExtendedTable0W112( )
      {
         Gx_BScreen = 1;
         standaloneModal0W112( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000W19 */
         pr_default.execute(17, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A564CtaColorName, A563CtaColorId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(17);
      }

      protected void CloseExtendedTableCursors0W112( )
      {
      }

      protected void enableDisable0W112( )
      {
      }

      protected void GetKey0W112( )
      {
         /* Using cursor BC000W20 */
         pr_default.execute(18, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound112 = 1;
         }
         else
         {
            RcdFound112 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0W112( )
      {
         /* Using cursor BC000W7 */
         pr_default.execute(5, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0W112( 16) ;
            RcdFound112 = 1;
            InitializeNonKey0W112( ) ;
            A563CtaColorId = BC000W7_A563CtaColorId[0];
            A564CtaColorName = BC000W7_A564CtaColorName[0];
            A565CtaColorCode = BC000W7_A565CtaColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z563CtaColorId = A563CtaColorId;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W112( ) ;
            Load0W112( ) ;
            Gx_mode = sMode112;
         }
         else
         {
            RcdFound112 = 0;
            InitializeNonKey0W112( ) ;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W112( ) ;
            Gx_mode = sMode112;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W112( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0W112( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W6 */
            pr_default.execute(4, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z564CtaColorName, BC000W6_A564CtaColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z565CtaColorCode, BC000W6_A565CtaColorCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeCtaColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W112( )
      {
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W112( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W112( 0) ;
            CheckOptimisticConcurrency0W112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W21 */
                     pr_default.execute(19, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId, A564CtaColorName, A565CtaColorCode});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0W112( ) ;
            }
            EndLevel0W112( ) ;
         }
         CloseExtendedTableCursors0W112( ) ;
      }

      protected void Update0W112( )
      {
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W112( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W22 */
                     pr_default.execute(20, new Object[] {A564CtaColorName, A565CtaColorCode, n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W112( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0W112( ) ;
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
            EndLevel0W112( ) ;
         }
         CloseExtendedTableCursors0W112( ) ;
      }

      protected void DeferredUpdate0W112( )
      {
      }

      protected void Delete0W112( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W112( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W112( ) ;
            AfterConfirm0W112( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W112( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W23 */
                  pr_default.execute(21, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode112 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W112( ) ;
         Gx_mode = sMode112;
      }

      protected void OnDeleteControls0W112( )
      {
         standaloneModal0W112( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W112( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0W112( )
      {
         /* Scan By routine */
         /* Using cursor BC000W24 */
         pr_default.execute(22, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound112 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound112 = 1;
            A563CtaColorId = BC000W24_A563CtaColorId[0];
            A564CtaColorName = BC000W24_A564CtaColorName[0];
            A565CtaColorCode = BC000W24_A565CtaColorCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W112( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound112 = 0;
         ScanKeyLoad0W112( ) ;
      }

      protected void ScanKeyLoad0W112( )
      {
         sMode112 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound112 = 1;
            A563CtaColorId = BC000W24_A563CtaColorId[0];
            A564CtaColorName = BC000W24_A564CtaColorName[0];
            A565CtaColorCode = BC000W24_A565CtaColorCode[0];
         }
         Gx_mode = sMode112;
      }

      protected void ScanKeyEnd0W112( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0W112( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W112( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W112( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W112( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W112( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W112( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W112( )
      {
      }

      protected void send_integrity_lvl_hashes0W112( )
      {
      }

      protected void ZM0W87( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z443IconCategory = A443IconCategory;
            Z262IconName = A262IconName;
         }
         if ( GX_JID == -18 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            Z443IconCategory = A443IconCategory;
            Z262IconName = A262IconName;
            Z263IconSVG = A263IconSVG;
         }
      }

      protected void standaloneNotModal0W87( )
      {
      }

      protected void standaloneModal0W87( )
      {
         if ( IsIns( )  && (Guid.Empty==A261IconId) )
         {
            A261IconId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W87( )
      {
         /* Using cursor BC000W25 */
         pr_default.execute(23, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound87 = 1;
            A443IconCategory = BC000W25_A443IconCategory[0];
            A262IconName = BC000W25_A262IconName[0];
            A263IconSVG = BC000W25_A263IconSVG[0];
            ZM0W87( -18) ;
         }
         pr_default.close(23);
         OnLoadActions0W87( ) ;
      }

      protected void OnLoadActions0W87( )
      {
      }

      protected void CheckExtendedTable0W87( )
      {
         Gx_BScreen = 1;
         standaloneModal0W87( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000W26 */
         pr_default.execute(24, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A262IconName, A443IconCategory, A261IconId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(24);
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0W87( )
      {
      }

      protected void enableDisable0W87( )
      {
      }

      protected void GetKey0W87( )
      {
         /* Using cursor BC000W27 */
         pr_default.execute(25, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound87 = 1;
         }
         else
         {
            RcdFound87 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey0W87( )
      {
         /* Using cursor BC000W5 */
         pr_default.execute(3, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0W87( 18) ;
            RcdFound87 = 1;
            InitializeNonKey0W87( ) ;
            A261IconId = BC000W5_A261IconId[0];
            A443IconCategory = BC000W5_A443IconCategory[0];
            A262IconName = BC000W5_A262IconName[0];
            A263IconSVG = BC000W5_A263IconSVG[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W87( ) ;
            Load0W87( ) ;
            Gx_mode = sMode87;
         }
         else
         {
            RcdFound87 = 0;
            InitializeNonKey0W87( ) ;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W87( ) ;
            Gx_mode = sMode87;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W87( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0W87( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W4 */
            pr_default.execute(2, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z443IconCategory, BC000W4_A443IconCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z262IconName, BC000W4_A262IconName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeIcon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W87( )
      {
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W87( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W87( 0) ;
            CheckOptimisticConcurrency0W87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W28 */
                     pr_default.execute(26, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId, A443IconCategory, A262IconName, A263IconSVG});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(26) == 1) )
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
               Load0W87( ) ;
            }
            EndLevel0W87( ) ;
         }
         CloseExtendedTableCursors0W87( ) ;
      }

      protected void Update0W87( )
      {
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W87( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W29 */
                     pr_default.execute(27, new Object[] {A443IconCategory, A262IconName, A263IconSVG, n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(27) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W87( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0W87( ) ;
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
            EndLevel0W87( ) ;
         }
         CloseExtendedTableCursors0W87( ) ;
      }

      protected void DeferredUpdate0W87( )
      {
      }

      protected void Delete0W87( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W87( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W87( ) ;
            AfterConfirm0W87( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W87( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W30 */
                  pr_default.execute(28, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode87 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W87( ) ;
         Gx_mode = sMode87;
      }

      protected void OnDeleteControls0W87( )
      {
         standaloneModal0W87( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W87( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0W87( )
      {
         /* Scan By routine */
         /* Using cursor BC000W31 */
         pr_default.execute(29, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound87 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound87 = 1;
            A261IconId = BC000W31_A261IconId[0];
            A443IconCategory = BC000W31_A443IconCategory[0];
            A262IconName = BC000W31_A262IconName[0];
            A263IconSVG = BC000W31_A263IconSVG[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W87( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound87 = 0;
         ScanKeyLoad0W87( ) ;
      }

      protected void ScanKeyLoad0W87( )
      {
         sMode87 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound87 = 1;
            A261IconId = BC000W31_A261IconId[0];
            A443IconCategory = BC000W31_A443IconCategory[0];
            A262IconName = BC000W31_A262IconName[0];
            A263IconSVG = BC000W31_A263IconSVG[0];
         }
         Gx_mode = sMode87;
      }

      protected void ScanKeyEnd0W87( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0W87( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W87( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W87( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W87( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W87( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W87( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W87( )
      {
      }

      protected void send_integrity_lvl_hashes0W87( )
      {
      }

      protected void ZM0W47( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
         if ( GX_JID == -20 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
      }

      protected void standaloneNotModal0W47( )
      {
      }

      protected void standaloneModal0W47( )
      {
         if ( IsIns( )  && (Guid.Empty==A249ColorId) )
         {
            A249ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W47( )
      {
         /* Using cursor BC000W32 */
         pr_default.execute(30, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound47 = 1;
            A250ColorName = BC000W32_A250ColorName[0];
            A251ColorCode = BC000W32_A251ColorCode[0];
            ZM0W47( -20) ;
         }
         pr_default.close(30);
         OnLoadActions0W47( ) ;
      }

      protected void OnLoadActions0W47( )
      {
      }

      protected void CheckExtendedTable0W47( )
      {
         Gx_BScreen = 1;
         standaloneModal0W47( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000W33 */
         pr_default.execute(31, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A249ColorId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(31);
         /* Using cursor BC000W34 */
         pr_default.execute(32, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A251ColorCode, A249ColorId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(32);
      }

      protected void CloseExtendedTableCursors0W47( )
      {
      }

      protected void enableDisable0W47( )
      {
      }

      protected void GetKey0W47( )
      {
         /* Using cursor BC000W35 */
         pr_default.execute(33, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(33);
      }

      protected void getByPrimaryKey0W47( )
      {
         /* Using cursor BC000W3 */
         pr_default.execute(1, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W47( 20) ;
            RcdFound47 = 1;
            InitializeNonKey0W47( ) ;
            A249ColorId = BC000W3_A249ColorId[0];
            A250ColorName = BC000W3_A250ColorName[0];
            A251ColorCode = BC000W3_A251ColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W47( ) ;
            Load0W47( ) ;
            Gx_mode = sMode47;
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey0W47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W47( ) ;
            Gx_mode = sMode47;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W47( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0W47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W2 */
            pr_default.execute(0, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250ColorName, BC000W2_A250ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z251ColorCode, BC000W2_A251ColorCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W47( 0) ;
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W36 */
                     pr_default.execute(34, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(34) == 1) )
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
               Load0W47( ) ;
            }
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void Update0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W37 */
                     pr_default.execute(35, new Object[] {A250ColorName, A251ColorCode, n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
                     pr_default.close(35);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(35) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0W47( ) ;
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
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void DeferredUpdate0W47( )
      {
      }

      protected void Delete0W47( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W47( ) ;
            AfterConfirm0W47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W38 */
                  pr_default.execute(36, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
                  pr_default.close(36);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W47( ) ;
         Gx_mode = sMode47;
      }

      protected void OnDeleteControls0W47( )
      {
         standaloneModal0W47( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W47( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0W47( )
      {
         /* Scan By routine */
         /* Using cursor BC000W39 */
         pr_default.execute(37, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = BC000W39_A249ColorId[0];
            A250ColorName = BC000W39_A250ColorName[0];
            A251ColorCode = BC000W39_A251ColorCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W47( )
      {
         /* Scan next routine */
         pr_default.readNext(37);
         RcdFound47 = 0;
         ScanKeyLoad0W47( ) ;
      }

      protected void ScanKeyLoad0W47( )
      {
         sMode47 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = BC000W39_A249ColorId[0];
            A250ColorName = BC000W39_A250ColorName[0];
            A251ColorCode = BC000W39_A251ColorCode[0];
         }
         Gx_mode = sMode47;
      }

      protected void ScanKeyEnd0W47( )
      {
         pr_default.close(37);
      }

      protected void AfterConfirm0W47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W46( )
      {
      }

      protected void AddRow0W46( )
      {
         VarsToRow46( bcTrn_Theme) ;
      }

      protected void ReadRow0W46( )
      {
         RowToVars46( bcTrn_Theme, 1) ;
      }

      protected void AddRow0W112( )
      {
         SdtTrn_Theme_CtaColor obj112;
         obj112 = new SdtTrn_Theme_CtaColor(context);
         VarsToRow112( obj112) ;
         bcTrn_Theme.gxTpr_Ctacolor.Add(obj112, 0);
         obj112.gxTpr_Mode = "UPD";
         obj112.gxTpr_Modified = 0;
      }

      protected void ReadRow0W112( )
      {
         nGXsfl_112_idx = (int)(nGXsfl_112_idx+1);
         RowToVars112( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_112_idx)), 1) ;
      }

      protected void AddRow0W87( )
      {
         SdtTrn_Theme_Icon obj87;
         obj87 = new SdtTrn_Theme_Icon(context);
         VarsToRow87( obj87) ;
         bcTrn_Theme.gxTpr_Icon.Add(obj87, 0);
         obj87.gxTpr_Mode = "UPD";
         obj87.gxTpr_Modified = 0;
      }

      protected void ReadRow0W87( )
      {
         nGXsfl_87_idx = (int)(nGXsfl_87_idx+1);
         RowToVars87( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_87_idx)), 1) ;
      }

      protected void AddRow0W47( )
      {
         SdtTrn_Theme_Color obj47;
         obj47 = new SdtTrn_Theme_Color(context);
         VarsToRow47( obj47) ;
         bcTrn_Theme.gxTpr_Color.Add(obj47, 0);
         obj47.gxTpr_Mode = "UPD";
         obj47.gxTpr_Modified = 0;
      }

      protected void ReadRow0W47( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         RowToVars47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx)), 1) ;
      }

      protected void InitializeNonKey0W46( )
      {
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         A399Trn_ThemeFontSize = 0;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         Z399Trn_ThemeFontSize = 0;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0W46( )
      {
         A247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         InitializeNonKey0W46( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0W112( )
      {
         A564CtaColorName = "";
         A565CtaColorCode = "";
         Z564CtaColorName = "";
         Z565CtaColorCode = "";
      }

      protected void InitAll0W112( )
      {
         A563CtaColorId = Guid.NewGuid( );
         InitializeNonKey0W112( ) ;
      }

      protected void StandaloneModalInsert0W112( )
      {
      }

      protected void InitializeNonKey0W87( )
      {
         A443IconCategory = "";
         A262IconName = "";
         A263IconSVG = "";
         Z443IconCategory = "";
         Z262IconName = "";
      }

      protected void InitAll0W87( )
      {
         A261IconId = Guid.NewGuid( );
         InitializeNonKey0W87( ) ;
      }

      protected void StandaloneModalInsert0W87( )
      {
      }

      protected void InitializeNonKey0W47( )
      {
         A250ColorName = "";
         A251ColorCode = "";
         Z250ColorName = "";
         Z251ColorCode = "";
      }

      protected void InitAll0W47( )
      {
         A249ColorId = Guid.NewGuid( );
         InitializeNonKey0W47( ) ;
      }

      protected void StandaloneModalInsert0W47( )
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

      public void VarsToRow46( SdtTrn_Theme obj46 )
      {
         obj46.gxTpr_Mode = Gx_mode;
         obj46.gxTpr_Trn_themename = A248Trn_ThemeName;
         obj46.gxTpr_Trn_themefontfamily = A260Trn_ThemeFontFamily;
         obj46.gxTpr_Trn_themefontsize = A399Trn_ThemeFontSize;
         obj46.gxTpr_Organisationid = A11OrganisationId;
         obj46.gxTpr_Trn_themeid = A247Trn_ThemeId;
         obj46.gxTpr_Trn_themeid_Z = Z247Trn_ThemeId;
         obj46.gxTpr_Trn_themename_Z = Z248Trn_ThemeName;
         obj46.gxTpr_Trn_themefontfamily_Z = Z260Trn_ThemeFontFamily;
         obj46.gxTpr_Trn_themefontsize_Z = Z399Trn_ThemeFontSize;
         obj46.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj46.gxTpr_Trn_themeid_N = (short)(Convert.ToInt16(n247Trn_ThemeId));
         obj46.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj46.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow46( SdtTrn_Theme obj46 )
      {
         obj46.gxTpr_Trn_themeid = A247Trn_ThemeId;
         return  ;
      }

      public void RowToVars46( SdtTrn_Theme obj46 ,
                               int forceLoad )
      {
         Gx_mode = obj46.gxTpr_Mode;
         A248Trn_ThemeName = obj46.gxTpr_Trn_themename;
         A260Trn_ThemeFontFamily = obj46.gxTpr_Trn_themefontfamily;
         A399Trn_ThemeFontSize = obj46.gxTpr_Trn_themefontsize;
         A11OrganisationId = obj46.gxTpr_Organisationid;
         n11OrganisationId = false;
         A247Trn_ThemeId = obj46.gxTpr_Trn_themeid;
         n247Trn_ThemeId = false;
         Z247Trn_ThemeId = obj46.gxTpr_Trn_themeid_Z;
         Z248Trn_ThemeName = obj46.gxTpr_Trn_themename_Z;
         Z260Trn_ThemeFontFamily = obj46.gxTpr_Trn_themefontfamily_Z;
         Z399Trn_ThemeFontSize = obj46.gxTpr_Trn_themefontsize_Z;
         Z11OrganisationId = obj46.gxTpr_Organisationid_Z;
         n247Trn_ThemeId = (bool)(Convert.ToBoolean(obj46.gxTpr_Trn_themeid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj46.gxTpr_Organisationid_N));
         Gx_mode = obj46.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow112( SdtTrn_Theme_CtaColor obj112 )
      {
         obj112.gxTpr_Mode = Gx_mode;
         obj112.gxTpr_Ctacolorname = A564CtaColorName;
         obj112.gxTpr_Ctacolorcode = A565CtaColorCode;
         obj112.gxTpr_Ctacolorid = A563CtaColorId;
         obj112.gxTpr_Ctacolorid_Z = Z563CtaColorId;
         obj112.gxTpr_Ctacolorname_Z = Z564CtaColorName;
         obj112.gxTpr_Ctacolorcode_Z = Z565CtaColorCode;
         obj112.gxTpr_Modified = nIsMod_112;
         return  ;
      }

      public void KeyVarsToRow112( SdtTrn_Theme_CtaColor obj112 )
      {
         obj112.gxTpr_Ctacolorid = A563CtaColorId;
         return  ;
      }

      public void RowToVars112( SdtTrn_Theme_CtaColor obj112 ,
                                int forceLoad )
      {
         Gx_mode = obj112.gxTpr_Mode;
         A564CtaColorName = obj112.gxTpr_Ctacolorname;
         A565CtaColorCode = obj112.gxTpr_Ctacolorcode;
         A563CtaColorId = obj112.gxTpr_Ctacolorid;
         Z563CtaColorId = obj112.gxTpr_Ctacolorid_Z;
         Z564CtaColorName = obj112.gxTpr_Ctacolorname_Z;
         Z565CtaColorCode = obj112.gxTpr_Ctacolorcode_Z;
         nIsMod_112 = obj112.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow87( SdtTrn_Theme_Icon obj87 )
      {
         obj87.gxTpr_Mode = Gx_mode;
         obj87.gxTpr_Iconcategory = A443IconCategory;
         obj87.gxTpr_Iconname = A262IconName;
         obj87.gxTpr_Iconsvg = A263IconSVG;
         obj87.gxTpr_Iconid = A261IconId;
         obj87.gxTpr_Iconid_Z = Z261IconId;
         obj87.gxTpr_Iconcategory_Z = Z443IconCategory;
         obj87.gxTpr_Iconname_Z = Z262IconName;
         obj87.gxTpr_Modified = nIsMod_87;
         return  ;
      }

      public void KeyVarsToRow87( SdtTrn_Theme_Icon obj87 )
      {
         obj87.gxTpr_Iconid = A261IconId;
         return  ;
      }

      public void RowToVars87( SdtTrn_Theme_Icon obj87 ,
                               int forceLoad )
      {
         Gx_mode = obj87.gxTpr_Mode;
         A443IconCategory = obj87.gxTpr_Iconcategory;
         A262IconName = obj87.gxTpr_Iconname;
         A263IconSVG = obj87.gxTpr_Iconsvg;
         A261IconId = obj87.gxTpr_Iconid;
         Z261IconId = obj87.gxTpr_Iconid_Z;
         Z443IconCategory = obj87.gxTpr_Iconcategory_Z;
         Z262IconName = obj87.gxTpr_Iconname_Z;
         nIsMod_87 = obj87.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow47( SdtTrn_Theme_Color obj47 )
      {
         obj47.gxTpr_Mode = Gx_mode;
         obj47.gxTpr_Colorname = A250ColorName;
         obj47.gxTpr_Colorcode = A251ColorCode;
         obj47.gxTpr_Colorid = A249ColorId;
         obj47.gxTpr_Colorid_Z = Z249ColorId;
         obj47.gxTpr_Colorname_Z = Z250ColorName;
         obj47.gxTpr_Colorcode_Z = Z251ColorCode;
         obj47.gxTpr_Modified = nIsMod_47;
         return  ;
      }

      public void KeyVarsToRow47( SdtTrn_Theme_Color obj47 )
      {
         obj47.gxTpr_Colorid = A249ColorId;
         return  ;
      }

      public void RowToVars47( SdtTrn_Theme_Color obj47 ,
                               int forceLoad )
      {
         Gx_mode = obj47.gxTpr_Mode;
         A250ColorName = obj47.gxTpr_Colorname;
         A251ColorCode = obj47.gxTpr_Colorcode;
         A249ColorId = obj47.gxTpr_Colorid;
         Z249ColorId = obj47.gxTpr_Colorid_Z;
         Z250ColorName = obj47.gxTpr_Colorname_Z;
         Z251ColorCode = obj47.gxTpr_Colorcode_Z;
         nIsMod_47 = obj47.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A247Trn_ThemeId = (Guid)getParm(obj,0);
         n247Trn_ThemeId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0W46( ) ;
         ScanKeyStart0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
         ZM0W46( -14) ;
         OnLoadActions0W46( ) ;
         AddRow0W46( ) ;
         bcTrn_Theme.gxTpr_Ctacolor.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W112( ) ;
            nGXsfl_112_idx = 1;
            while ( RcdFound112 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z563CtaColorId = A563CtaColorId;
               ZM0W112( -16) ;
               OnLoadActions0W112( ) ;
               nRcdExists_112 = 1;
               nIsMod_112 = 0;
               AddRow0W112( ) ;
               nGXsfl_112_idx = (int)(nGXsfl_112_idx+1);
               ScanKeyNext0W112( ) ;
            }
            ScanKeyEnd0W112( ) ;
         }
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W87( ) ;
            nGXsfl_87_idx = 1;
            while ( RcdFound87 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z261IconId = A261IconId;
               ZM0W87( -18) ;
               OnLoadActions0W87( ) ;
               nRcdExists_87 = 1;
               nIsMod_87 = 0;
               AddRow0W87( ) ;
               nGXsfl_87_idx = (int)(nGXsfl_87_idx+1);
               ScanKeyNext0W87( ) ;
            }
            ScanKeyEnd0W87( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W47( ) ;
            nGXsfl_47_idx = 1;
            while ( RcdFound47 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z249ColorId = A249ColorId;
               ZM0W47( -20) ;
               OnLoadActions0W47( ) ;
               nRcdExists_47 = 1;
               nIsMod_47 = 0;
               AddRow0W47( ) ;
               nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
               ScanKeyNext0W47( ) ;
            }
            ScanKeyEnd0W47( ) ;
         }
         ScanKeyEnd0W46( ) ;
         if ( RcdFound46 == 0 )
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
         RowToVars46( bcTrn_Theme, 0) ;
         ScanKeyStart0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
         ZM0W46( -14) ;
         OnLoadActions0W46( ) ;
         AddRow0W46( ) ;
         bcTrn_Theme.gxTpr_Ctacolor.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W112( ) ;
            nGXsfl_112_idx = 1;
            while ( RcdFound112 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z563CtaColorId = A563CtaColorId;
               ZM0W112( -16) ;
               OnLoadActions0W112( ) ;
               nRcdExists_112 = 1;
               nIsMod_112 = 0;
               AddRow0W112( ) ;
               nGXsfl_112_idx = (int)(nGXsfl_112_idx+1);
               ScanKeyNext0W112( ) ;
            }
            ScanKeyEnd0W112( ) ;
         }
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W87( ) ;
            nGXsfl_87_idx = 1;
            while ( RcdFound87 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z261IconId = A261IconId;
               ZM0W87( -18) ;
               OnLoadActions0W87( ) ;
               nRcdExists_87 = 1;
               nIsMod_87 = 0;
               AddRow0W87( ) ;
               nGXsfl_87_idx = (int)(nGXsfl_87_idx+1);
               ScanKeyNext0W87( ) ;
            }
            ScanKeyEnd0W87( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W47( ) ;
            nGXsfl_47_idx = 1;
            while ( RcdFound47 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z249ColorId = A249ColorId;
               ZM0W47( -20) ;
               OnLoadActions0W47( ) ;
               nRcdExists_47 = 1;
               nIsMod_47 = 0;
               AddRow0W47( ) ;
               nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
               ScanKeyNext0W47( ) ;
            }
            ScanKeyEnd0W47( ) ;
         }
         ScanKeyEnd0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0W46( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0W46( ) ;
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  A247Trn_ThemeId = Z247Trn_ThemeId;
                  n247Trn_ThemeId = false;
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
                  Update0W46( ) ;
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
                  if ( A247Trn_ThemeId != Z247Trn_ThemeId )
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
                        Insert0W46( ) ;
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
                        Insert0W46( ) ;
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
         RowToVars46( bcTrn_Theme, 1) ;
         SaveImpl( ) ;
         VarsToRow46( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars46( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W46( ) ;
         AfterTrn( ) ;
         VarsToRow46( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow46( bcTrn_Theme) ;
         }
         else
         {
            SdtTrn_Theme auxBC = new SdtTrn_Theme(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A247Trn_ThemeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Theme);
               auxBC.Save();
               bcTrn_Theme.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars46( bcTrn_Theme, 1) ;
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
         RowToVars46( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W46( ) ;
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
               VarsToRow46( bcTrn_Theme) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow46( bcTrn_Theme) ;
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
         RowToVars46( bcTrn_Theme, 0) ;
         GetKey0W46( ) ;
         if ( RcdFound46 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A247Trn_ThemeId != Z247Trn_ThemeId )
            {
               A247Trn_ThemeId = Z247Trn_ThemeId;
               n247Trn_ThemeId = false;
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
            if ( A247Trn_ThemeId != Z247Trn_ThemeId )
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
         context.RollbackDataStores("trn_theme_bc",pr_default);
         VarsToRow46( bcTrn_Theme) ;
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
         Gx_mode = bcTrn_Theme.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Theme.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Theme )
         {
            bcTrn_Theme = (SdtTrn_Theme)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow46( bcTrn_Theme) ;
            }
            else
            {
               RowToVars46( bcTrn_Theme, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars46( bcTrn_Theme, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Theme Trn_Theme_BC
      {
         get {
            return bcTrn_Theme ;
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
            return "trn_theme_Execute" ;
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
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(7);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z247Trn_ThemeId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         sMode46 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV16Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV14Insert_OrganisationId = Guid.Empty;
         Z248Trn_ThemeName = "";
         A248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         A260Trn_ThemeFontFamily = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         BC000W11_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W11_n247Trn_ThemeId = new bool[] {false} ;
         BC000W11_A248Trn_ThemeName = new string[] {""} ;
         BC000W11_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W11_A399Trn_ThemeFontSize = new short[1] ;
         BC000W11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W11_n11OrganisationId = new bool[] {false} ;
         BC000W10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W10_n11OrganisationId = new bool[] {false} ;
         BC000W12_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W12_n247Trn_ThemeId = new bool[] {false} ;
         BC000W9_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W9_n247Trn_ThemeId = new bool[] {false} ;
         BC000W9_A248Trn_ThemeName = new string[] {""} ;
         BC000W9_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W9_A399Trn_ThemeFontSize = new short[1] ;
         BC000W9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W9_n11OrganisationId = new bool[] {false} ;
         BC000W8_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W8_n247Trn_ThemeId = new bool[] {false} ;
         BC000W8_A248Trn_ThemeName = new string[] {""} ;
         BC000W8_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W8_A399Trn_ThemeFontSize = new short[1] ;
         BC000W8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W8_n11OrganisationId = new bool[] {false} ;
         BC000W16_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000W16_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W16_n11OrganisationId = new bool[] {false} ;
         BC000W17_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W17_n247Trn_ThemeId = new bool[] {false} ;
         BC000W17_A248Trn_ThemeName = new string[] {""} ;
         BC000W17_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W17_A399Trn_ThemeFontSize = new short[1] ;
         BC000W17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000W17_n11OrganisationId = new bool[] {false} ;
         Z564CtaColorName = "";
         A564CtaColorName = "";
         Z565CtaColorCode = "";
         A565CtaColorCode = "";
         Z563CtaColorId = Guid.Empty;
         A563CtaColorId = Guid.Empty;
         BC000W18_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W18_n247Trn_ThemeId = new bool[] {false} ;
         BC000W18_A563CtaColorId = new Guid[] {Guid.Empty} ;
         BC000W18_A564CtaColorName = new string[] {""} ;
         BC000W18_A565CtaColorCode = new string[] {""} ;
         BC000W19_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W19_n247Trn_ThemeId = new bool[] {false} ;
         BC000W20_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W20_n247Trn_ThemeId = new bool[] {false} ;
         BC000W20_A563CtaColorId = new Guid[] {Guid.Empty} ;
         BC000W7_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W7_n247Trn_ThemeId = new bool[] {false} ;
         BC000W7_A563CtaColorId = new Guid[] {Guid.Empty} ;
         BC000W7_A564CtaColorName = new string[] {""} ;
         BC000W7_A565CtaColorCode = new string[] {""} ;
         sMode112 = "";
         BC000W6_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W6_n247Trn_ThemeId = new bool[] {false} ;
         BC000W6_A563CtaColorId = new Guid[] {Guid.Empty} ;
         BC000W6_A564CtaColorName = new string[] {""} ;
         BC000W6_A565CtaColorCode = new string[] {""} ;
         BC000W24_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W24_n247Trn_ThemeId = new bool[] {false} ;
         BC000W24_A563CtaColorId = new Guid[] {Guid.Empty} ;
         BC000W24_A564CtaColorName = new string[] {""} ;
         BC000W24_A565CtaColorCode = new string[] {""} ;
         Z443IconCategory = "";
         A443IconCategory = "";
         Z262IconName = "";
         A262IconName = "";
         Z261IconId = Guid.Empty;
         A261IconId = Guid.Empty;
         Z263IconSVG = "";
         A263IconSVG = "";
         BC000W25_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W25_n247Trn_ThemeId = new bool[] {false} ;
         BC000W25_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W25_A443IconCategory = new string[] {""} ;
         BC000W25_A262IconName = new string[] {""} ;
         BC000W25_A263IconSVG = new string[] {""} ;
         BC000W26_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W26_n247Trn_ThemeId = new bool[] {false} ;
         BC000W27_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W27_n247Trn_ThemeId = new bool[] {false} ;
         BC000W27_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W5_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W5_n247Trn_ThemeId = new bool[] {false} ;
         BC000W5_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W5_A443IconCategory = new string[] {""} ;
         BC000W5_A262IconName = new string[] {""} ;
         BC000W5_A263IconSVG = new string[] {""} ;
         sMode87 = "";
         BC000W4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W4_n247Trn_ThemeId = new bool[] {false} ;
         BC000W4_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W4_A443IconCategory = new string[] {""} ;
         BC000W4_A262IconName = new string[] {""} ;
         BC000W4_A263IconSVG = new string[] {""} ;
         BC000W31_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W31_n247Trn_ThemeId = new bool[] {false} ;
         BC000W31_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W31_A443IconCategory = new string[] {""} ;
         BC000W31_A262IconName = new string[] {""} ;
         BC000W31_A263IconSVG = new string[] {""} ;
         Z250ColorName = "";
         A250ColorName = "";
         Z251ColorCode = "";
         A251ColorCode = "";
         Z249ColorId = Guid.Empty;
         A249ColorId = Guid.Empty;
         BC000W32_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W32_n247Trn_ThemeId = new bool[] {false} ;
         BC000W32_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W32_A250ColorName = new string[] {""} ;
         BC000W32_A251ColorCode = new string[] {""} ;
         BC000W33_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W33_n247Trn_ThemeId = new bool[] {false} ;
         BC000W34_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W34_n247Trn_ThemeId = new bool[] {false} ;
         BC000W35_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W35_n247Trn_ThemeId = new bool[] {false} ;
         BC000W35_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W3_n247Trn_ThemeId = new bool[] {false} ;
         BC000W3_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W3_A250ColorName = new string[] {""} ;
         BC000W3_A251ColorCode = new string[] {""} ;
         sMode47 = "";
         BC000W2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W2_n247Trn_ThemeId = new bool[] {false} ;
         BC000W2_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W2_A250ColorName = new string[] {""} ;
         BC000W2_A251ColorCode = new string[] {""} ;
         BC000W39_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W39_n247Trn_ThemeId = new bool[] {false} ;
         BC000W39_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W39_A250ColorName = new string[] {""} ;
         BC000W39_A251ColorCode = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__default(),
            new Object[][] {
                new Object[] {
               BC000W2_A247Trn_ThemeId, BC000W2_A249ColorId, BC000W2_A250ColorName, BC000W2_A251ColorCode
               }
               , new Object[] {
               BC000W3_A247Trn_ThemeId, BC000W3_A249ColorId, BC000W3_A250ColorName, BC000W3_A251ColorCode
               }
               , new Object[] {
               BC000W4_A247Trn_ThemeId, BC000W4_A261IconId, BC000W4_A443IconCategory, BC000W4_A262IconName, BC000W4_A263IconSVG
               }
               , new Object[] {
               BC000W5_A247Trn_ThemeId, BC000W5_A261IconId, BC000W5_A443IconCategory, BC000W5_A262IconName, BC000W5_A263IconSVG
               }
               , new Object[] {
               BC000W6_A247Trn_ThemeId, BC000W6_A563CtaColorId, BC000W6_A564CtaColorName, BC000W6_A565CtaColorCode
               }
               , new Object[] {
               BC000W7_A247Trn_ThemeId, BC000W7_A563CtaColorId, BC000W7_A564CtaColorName, BC000W7_A565CtaColorCode
               }
               , new Object[] {
               BC000W8_A247Trn_ThemeId, BC000W8_A248Trn_ThemeName, BC000W8_A260Trn_ThemeFontFamily, BC000W8_A399Trn_ThemeFontSize, BC000W8_A11OrganisationId, BC000W8_n11OrganisationId
               }
               , new Object[] {
               BC000W9_A247Trn_ThemeId, BC000W9_A248Trn_ThemeName, BC000W9_A260Trn_ThemeFontFamily, BC000W9_A399Trn_ThemeFontSize, BC000W9_A11OrganisationId, BC000W9_n11OrganisationId
               }
               , new Object[] {
               BC000W10_A11OrganisationId
               }
               , new Object[] {
               BC000W11_A247Trn_ThemeId, BC000W11_A248Trn_ThemeName, BC000W11_A260Trn_ThemeFontFamily, BC000W11_A399Trn_ThemeFontSize, BC000W11_A11OrganisationId, BC000W11_n11OrganisationId
               }
               , new Object[] {
               BC000W12_A247Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W16_A29LocationId, BC000W16_A11OrganisationId
               }
               , new Object[] {
               BC000W17_A247Trn_ThemeId, BC000W17_A248Trn_ThemeName, BC000W17_A260Trn_ThemeFontFamily, BC000W17_A399Trn_ThemeFontSize, BC000W17_A11OrganisationId, BC000W17_n11OrganisationId
               }
               , new Object[] {
               BC000W18_A247Trn_ThemeId, BC000W18_A563CtaColorId, BC000W18_A564CtaColorName, BC000W18_A565CtaColorCode
               }
               , new Object[] {
               BC000W19_A247Trn_ThemeId
               }
               , new Object[] {
               BC000W20_A247Trn_ThemeId, BC000W20_A563CtaColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W24_A247Trn_ThemeId, BC000W24_A563CtaColorId, BC000W24_A564CtaColorName, BC000W24_A565CtaColorCode
               }
               , new Object[] {
               BC000W25_A247Trn_ThemeId, BC000W25_A261IconId, BC000W25_A443IconCategory, BC000W25_A262IconName, BC000W25_A263IconSVG
               }
               , new Object[] {
               BC000W26_A247Trn_ThemeId
               }
               , new Object[] {
               BC000W27_A247Trn_ThemeId, BC000W27_A261IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W31_A247Trn_ThemeId, BC000W31_A261IconId, BC000W31_A443IconCategory, BC000W31_A262IconName, BC000W31_A263IconSVG
               }
               , new Object[] {
               BC000W32_A247Trn_ThemeId, BC000W32_A249ColorId, BC000W32_A250ColorName, BC000W32_A251ColorCode
               }
               , new Object[] {
               BC000W33_A247Trn_ThemeId
               }
               , new Object[] {
               BC000W34_A247Trn_ThemeId
               }
               , new Object[] {
               BC000W35_A247Trn_ThemeId, BC000W35_A249ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W39_A247Trn_ThemeId, BC000W39_A249ColorId, BC000W39_A250ColorName, BC000W39_A251ColorCode
               }
            }
         );
         Z249ColorId = Guid.NewGuid( );
         A249ColorId = Guid.NewGuid( );
         Z261IconId = Guid.NewGuid( );
         A261IconId = Guid.NewGuid( );
         Z563CtaColorId = Guid.NewGuid( );
         A563CtaColorId = Guid.NewGuid( );
         Z247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         A247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         AV16Pgmname = "Trn_Theme_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_47 ;
      private short RcdFound47 ;
      private short nIsMod_87 ;
      private short RcdFound87 ;
      private short nIsMod_112 ;
      private short RcdFound112 ;
      private short Z399Trn_ThemeFontSize ;
      private short A399Trn_ThemeFontSize ;
      private short Gx_BScreen ;
      private short RcdFound46 ;
      private short nRcdExists_112 ;
      private short nRcdExists_87 ;
      private short nRcdExists_47 ;
      private short Gxremove112 ;
      private short Gxremove87 ;
      private short Gxremove47 ;
      private int trnEnded ;
      private int nGXsfl_47_idx=1 ;
      private int nGXsfl_87_idx=1 ;
      private int nGXsfl_112_idx=1 ;
      private int AV17GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode46 ;
      private string AV16Pgmname ;
      private string sMode112 ;
      private string sMode87 ;
      private string sMode47 ;
      private bool returnInSub ;
      private bool n247Trn_ThemeId ;
      private bool n11OrganisationId ;
      private string Z263IconSVG ;
      private string A263IconSVG ;
      private string Z248Trn_ThemeName ;
      private string A248Trn_ThemeName ;
      private string Z260Trn_ThemeFontFamily ;
      private string A260Trn_ThemeFontFamily ;
      private string Z564CtaColorName ;
      private string A564CtaColorName ;
      private string Z565CtaColorCode ;
      private string A565CtaColorCode ;
      private string Z443IconCategory ;
      private string A443IconCategory ;
      private string Z262IconName ;
      private string A262IconName ;
      private string Z250ColorName ;
      private string A250ColorName ;
      private string Z251ColorCode ;
      private string A251ColorCode ;
      private Guid Z247Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid AV14Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z563CtaColorId ;
      private Guid A563CtaColorId ;
      private Guid Z261IconId ;
      private Guid A261IconId ;
      private Guid Z249ColorId ;
      private Guid A249ColorId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Theme bcTrn_Theme ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000W11_A247Trn_ThemeId ;
      private bool[] BC000W11_n247Trn_ThemeId ;
      private string[] BC000W11_A248Trn_ThemeName ;
      private string[] BC000W11_A260Trn_ThemeFontFamily ;
      private short[] BC000W11_A399Trn_ThemeFontSize ;
      private Guid[] BC000W11_A11OrganisationId ;
      private bool[] BC000W11_n11OrganisationId ;
      private Guid[] BC000W10_A11OrganisationId ;
      private bool[] BC000W10_n11OrganisationId ;
      private Guid[] BC000W12_A247Trn_ThemeId ;
      private bool[] BC000W12_n247Trn_ThemeId ;
      private Guid[] BC000W9_A247Trn_ThemeId ;
      private bool[] BC000W9_n247Trn_ThemeId ;
      private string[] BC000W9_A248Trn_ThemeName ;
      private string[] BC000W9_A260Trn_ThemeFontFamily ;
      private short[] BC000W9_A399Trn_ThemeFontSize ;
      private Guid[] BC000W9_A11OrganisationId ;
      private bool[] BC000W9_n11OrganisationId ;
      private Guid[] BC000W8_A247Trn_ThemeId ;
      private bool[] BC000W8_n247Trn_ThemeId ;
      private string[] BC000W8_A248Trn_ThemeName ;
      private string[] BC000W8_A260Trn_ThemeFontFamily ;
      private short[] BC000W8_A399Trn_ThemeFontSize ;
      private Guid[] BC000W8_A11OrganisationId ;
      private bool[] BC000W8_n11OrganisationId ;
      private Guid[] BC000W16_A29LocationId ;
      private Guid[] BC000W16_A11OrganisationId ;
      private bool[] BC000W16_n11OrganisationId ;
      private Guid[] BC000W17_A247Trn_ThemeId ;
      private bool[] BC000W17_n247Trn_ThemeId ;
      private string[] BC000W17_A248Trn_ThemeName ;
      private string[] BC000W17_A260Trn_ThemeFontFamily ;
      private short[] BC000W17_A399Trn_ThemeFontSize ;
      private Guid[] BC000W17_A11OrganisationId ;
      private bool[] BC000W17_n11OrganisationId ;
      private Guid[] BC000W18_A247Trn_ThemeId ;
      private bool[] BC000W18_n247Trn_ThemeId ;
      private Guid[] BC000W18_A563CtaColorId ;
      private string[] BC000W18_A564CtaColorName ;
      private string[] BC000W18_A565CtaColorCode ;
      private Guid[] BC000W19_A247Trn_ThemeId ;
      private bool[] BC000W19_n247Trn_ThemeId ;
      private Guid[] BC000W20_A247Trn_ThemeId ;
      private bool[] BC000W20_n247Trn_ThemeId ;
      private Guid[] BC000W20_A563CtaColorId ;
      private Guid[] BC000W7_A247Trn_ThemeId ;
      private bool[] BC000W7_n247Trn_ThemeId ;
      private Guid[] BC000W7_A563CtaColorId ;
      private string[] BC000W7_A564CtaColorName ;
      private string[] BC000W7_A565CtaColorCode ;
      private Guid[] BC000W6_A247Trn_ThemeId ;
      private bool[] BC000W6_n247Trn_ThemeId ;
      private Guid[] BC000W6_A563CtaColorId ;
      private string[] BC000W6_A564CtaColorName ;
      private string[] BC000W6_A565CtaColorCode ;
      private Guid[] BC000W24_A247Trn_ThemeId ;
      private bool[] BC000W24_n247Trn_ThemeId ;
      private Guid[] BC000W24_A563CtaColorId ;
      private string[] BC000W24_A564CtaColorName ;
      private string[] BC000W24_A565CtaColorCode ;
      private Guid[] BC000W25_A247Trn_ThemeId ;
      private bool[] BC000W25_n247Trn_ThemeId ;
      private Guid[] BC000W25_A261IconId ;
      private string[] BC000W25_A443IconCategory ;
      private string[] BC000W25_A262IconName ;
      private string[] BC000W25_A263IconSVG ;
      private Guid[] BC000W26_A247Trn_ThemeId ;
      private bool[] BC000W26_n247Trn_ThemeId ;
      private Guid[] BC000W27_A247Trn_ThemeId ;
      private bool[] BC000W27_n247Trn_ThemeId ;
      private Guid[] BC000W27_A261IconId ;
      private Guid[] BC000W5_A247Trn_ThemeId ;
      private bool[] BC000W5_n247Trn_ThemeId ;
      private Guid[] BC000W5_A261IconId ;
      private string[] BC000W5_A443IconCategory ;
      private string[] BC000W5_A262IconName ;
      private string[] BC000W5_A263IconSVG ;
      private Guid[] BC000W4_A247Trn_ThemeId ;
      private bool[] BC000W4_n247Trn_ThemeId ;
      private Guid[] BC000W4_A261IconId ;
      private string[] BC000W4_A443IconCategory ;
      private string[] BC000W4_A262IconName ;
      private string[] BC000W4_A263IconSVG ;
      private Guid[] BC000W31_A247Trn_ThemeId ;
      private bool[] BC000W31_n247Trn_ThemeId ;
      private Guid[] BC000W31_A261IconId ;
      private string[] BC000W31_A443IconCategory ;
      private string[] BC000W31_A262IconName ;
      private string[] BC000W31_A263IconSVG ;
      private Guid[] BC000W32_A247Trn_ThemeId ;
      private bool[] BC000W32_n247Trn_ThemeId ;
      private Guid[] BC000W32_A249ColorId ;
      private string[] BC000W32_A250ColorName ;
      private string[] BC000W32_A251ColorCode ;
      private Guid[] BC000W33_A247Trn_ThemeId ;
      private bool[] BC000W33_n247Trn_ThemeId ;
      private Guid[] BC000W34_A247Trn_ThemeId ;
      private bool[] BC000W34_n247Trn_ThemeId ;
      private Guid[] BC000W35_A247Trn_ThemeId ;
      private bool[] BC000W35_n247Trn_ThemeId ;
      private Guid[] BC000W35_A249ColorId ;
      private Guid[] BC000W3_A247Trn_ThemeId ;
      private bool[] BC000W3_n247Trn_ThemeId ;
      private Guid[] BC000W3_A249ColorId ;
      private string[] BC000W3_A250ColorName ;
      private string[] BC000W3_A251ColorCode ;
      private Guid[] BC000W2_A247Trn_ThemeId ;
      private bool[] BC000W2_n247Trn_ThemeId ;
      private Guid[] BC000W2_A249ColorId ;
      private string[] BC000W2_A250ColorName ;
      private string[] BC000W2_A251ColorCode ;
      private Guid[] BC000W39_A247Trn_ThemeId ;
      private bool[] BC000W39_n247Trn_ThemeId ;
      private Guid[] BC000W39_A249ColorId ;
      private string[] BC000W39_A250ColorName ;
      private string[] BC000W39_A251ColorCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_theme_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new UpdateCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new ForEachCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new UpdateCursor(def[34])
      ,new UpdateCursor(def[35])
      ,new UpdateCursor(def[36])
      ,new ForEachCursor(def[37])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000W2;
       prmBC000W2 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W3;
       prmBC000W3 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W4;
       prmBC000W4 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W5;
       prmBC000W5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W6;
       prmBC000W6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W7;
       prmBC000W7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W8;
       prmBC000W8 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W9;
       prmBC000W9 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W10;
       prmBC000W10 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W11;
       prmBC000W11 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W12;
       prmBC000W12 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W13;
       prmBC000W13 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W14;
       prmBC000W14 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W15;
       prmBC000W15 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W16;
       prmBC000W16 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W17;
       prmBC000W17 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W18;
       prmBC000W18 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W19;
       prmBC000W19 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W20;
       prmBC000W20 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W21;
       prmBC000W21 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmBC000W22;
       prmBC000W22 = new Object[] {
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W23;
       prmBC000W23 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W24;
       prmBC000W24 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W25;
       prmBC000W25 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W26;
       prmBC000W26 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W27;
       prmBC000W27 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W28;
       prmBC000W28 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC000W29;
       prmBC000W29 = new Object[] {
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W30;
       prmBC000W30 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W31;
       prmBC000W31 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000W32;
       prmBC000W32 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W33;
       prmBC000W33 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W34;
       prmBC000W34 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W35;
       prmBC000W35 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W36;
       prmBC000W36 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmBC000W37;
       prmBC000W37 = new Object[] {
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W38;
       prmBC000W38 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W39;
       prmBC000W39 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000W2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W4", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId  FOR UPDATE OF Trn_ThemeIcon",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W5", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W6", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId  FOR UPDATE OF Trn_ThemeCtaColor",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W7", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W8", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W9", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W10", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W11", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.OrganisationId FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W11,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W12", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W13", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily, :Trn_ThemeFontSize, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W13)
          ,new CursorDef("BC000W14", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize, OrganisationId=:OrganisationId  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W14)
          ,new CursorDef("BC000W15", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W15)
          ,new CursorDef("BC000W16", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000W17", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.OrganisationId FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W17,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W18", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W18,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W19", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W19,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W20", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W21", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W21)
          ,new CursorDef("BC000W22", "SAVEPOINT gxupdate;UPDATE Trn_ThemeCtaColor SET CtaColorName=:CtaColorName, CtaColorCode=:CtaColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W22)
          ,new CursorDef("BC000W23", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W23)
          ,new CursorDef("BC000W24", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W24,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W25", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId and IconId = :IconId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W25,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W26", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W27", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W27,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W28", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconCategory, IconName, IconSVG) VALUES(:Trn_ThemeId, :IconId, :IconCategory, :IconName, :IconSVG);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W28)
          ,new CursorDef("BC000W29", "SAVEPOINT gxupdate;UPDATE Trn_ThemeIcon SET IconCategory=:IconCategory, IconName=:IconName, IconSVG=:IconSVG  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W29)
          ,new CursorDef("BC000W30", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W30)
          ,new CursorDef("BC000W31", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W31,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W32", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W32,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W33", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W33,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W34", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W34,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W35", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W35,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W36", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W36)
          ,new CursorDef("BC000W37", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W37)
          ,new CursorDef("BC000W38", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W38)
          ,new CursorDef("BC000W39", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W39,11, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 22 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 23 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 29 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
    }
    getresults30( cursor, rslt, buf) ;
 }

 public void getresults30( int cursor ,
                           IFieldGetter rslt ,
                           Object[] buf )
 {
    switch ( cursor )
    {
          case 30 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 31 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 32 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 33 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 37 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
