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
   public class trn_organisationsetting_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisationsetting_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationsetting_bc( IGxContext context )
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
         ReadRow0F107( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F107( ) ;
         standaloneModal( ) ;
         AddRow0F107( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z100OrganisationSettingid = A100OrganisationSettingid;
               Z11OrganisationId = A11OrganisationId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F107( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F107( ) ;
            }
            else
            {
               CheckExtendedTable0F107( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F107( 7) ;
               }
               CloseExtendedTableCursors0F107( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV12WebSession.Remove(context.GetMessage( "SelectedBaseColor", ""));
         GX_msglist.addItem(context.GetMessage( "Saved successfully", ""));
      }

      protected void ZM0F107( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
            Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
            Z546OrganisationHasMyCare = A546OrganisationHasMyCare;
            Z547OrganisationHasMyLiving = A547OrganisationHasMyLiving;
            Z548OrganisationHasMyServices = A548OrganisationHasMyServices;
            Z549OrganisationHasDynamicForms = A549OrganisationHasDynamicForms;
            Z566OrganisationHasOwnBrand = A566OrganisationHasOwnBrand;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -6 )
         {
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
            Z101OrganisationSettingLogo = A101OrganisationSettingLogo;
            Z40000OrganisationSettingLogo_GXI = A40000OrganisationSettingLogo_GXI;
            Z102OrganisationSettingFavicon = A102OrganisationSettingFavicon;
            Z40001OrganisationSettingFavicon_GXI = A40001OrganisationSettingFavicon_GXI;
            Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
            Z105OrganisationSettingLanguage = A105OrganisationSettingLanguage;
            Z546OrganisationHasMyCare = A546OrganisationHasMyCare;
            Z547OrganisationHasMyLiving = A547OrganisationHasMyLiving;
            Z548OrganisationHasMyServices = A548OrganisationHasMyServices;
            Z549OrganisationHasDynamicForms = A549OrganisationHasDynamicForms;
            Z550OrganisationBrandTheme = A550OrganisationBrandTheme;
            Z551OrganisationCtaTheme = A551OrganisationCtaTheme;
            Z566OrganisationHasOwnBrand = A566OrganisationHasOwnBrand;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A100OrganisationSettingid) )
         {
            A100OrganisationSettingid = Guid.NewGuid( );
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), "")))) )
         {
            A103OrganisationSettingBaseColor = AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F107( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A100OrganisationSettingid, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound107 = 1;
            A103OrganisationSettingBaseColor = BC000F5_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F5_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F5_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F5_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F5_A105OrganisationSettingLanguage[0];
            A546OrganisationHasMyCare = BC000F5_A546OrganisationHasMyCare[0];
            A547OrganisationHasMyLiving = BC000F5_A547OrganisationHasMyLiving[0];
            A548OrganisationHasMyServices = BC000F5_A548OrganisationHasMyServices[0];
            A549OrganisationHasDynamicForms = BC000F5_A549OrganisationHasDynamicForms[0];
            A550OrganisationBrandTheme = BC000F5_A550OrganisationBrandTheme[0];
            A551OrganisationCtaTheme = BC000F5_A551OrganisationCtaTheme[0];
            A566OrganisationHasOwnBrand = BC000F5_A566OrganisationHasOwnBrand[0];
            A101OrganisationSettingLogo = BC000F5_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F5_A102OrganisationSettingFavicon[0];
            ZM0F107( -6) ;
         }
         pr_default.close(3);
         OnLoadActions0F107( ) ;
      }

      protected void OnLoadActions0F107( )
      {
      }

      protected void CheckExtendedTable0F107( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F107( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F107( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A100OrganisationSettingid, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A100OrganisationSettingid, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F107( 6) ;
            RcdFound107 = 1;
            A100OrganisationSettingid = BC000F3_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F3_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F3_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F3_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F3_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F3_A105OrganisationSettingLanguage[0];
            A546OrganisationHasMyCare = BC000F3_A546OrganisationHasMyCare[0];
            A547OrganisationHasMyLiving = BC000F3_A547OrganisationHasMyLiving[0];
            A548OrganisationHasMyServices = BC000F3_A548OrganisationHasMyServices[0];
            A549OrganisationHasDynamicForms = BC000F3_A549OrganisationHasDynamicForms[0];
            A550OrganisationBrandTheme = BC000F3_A550OrganisationBrandTheme[0];
            A551OrganisationCtaTheme = BC000F3_A551OrganisationCtaTheme[0];
            A566OrganisationHasOwnBrand = BC000F3_A566OrganisationHasOwnBrand[0];
            A11OrganisationId = BC000F3_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F3_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F3_A102OrganisationSettingFavicon[0];
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z11OrganisationId = A11OrganisationId;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey0F107( ) ;
            }
            Gx_mode = sMode107;
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey0F107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode107;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F107( ) ;
         if ( RcdFound107 == 0 )
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
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A100OrganisationSettingid, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103OrganisationSettingBaseColor, BC000F2_A103OrganisationSettingBaseColor[0]) != 0 ) || ( StringUtil.StrCmp(Z104OrganisationSettingFontSize, BC000F2_A104OrganisationSettingFontSize[0]) != 0 ) || ( Z546OrganisationHasMyCare != BC000F2_A546OrganisationHasMyCare[0] ) || ( Z547OrganisationHasMyLiving != BC000F2_A547OrganisationHasMyLiving[0] ) || ( Z548OrganisationHasMyServices != BC000F2_A548OrganisationHasMyServices[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z549OrganisationHasDynamicForms != BC000F2_A549OrganisationHasDynamicForms[0] ) || ( Z566OrganisationHasOwnBrand != BC000F2_A566OrganisationHasOwnBrand[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationSetting"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F107( )
      {
         BeforeValidate0F107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F107( 0) ;
            CheckOptimisticConcurrency0F107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A100OrganisationSettingid, A103OrganisationSettingBaseColor, A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A104OrganisationSettingFontSize, A105OrganisationSettingLanguage, A546OrganisationHasMyCare, A547OrganisationHasMyLiving, A548OrganisationHasMyServices, A549OrganisationHasDynamicForms, A550OrganisationBrandTheme, A551OrganisationCtaTheme, A566OrganisationHasOwnBrand, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
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
               Load0F107( ) ;
            }
            EndLevel0F107( ) ;
         }
         CloseExtendedTableCursors0F107( ) ;
      }

      protected void Update0F107( )
      {
         BeforeValidate0F107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F8 */
                     pr_default.execute(6, new Object[] {A103OrganisationSettingBaseColor, A104OrganisationSettingFontSize, A105OrganisationSettingLanguage, A546OrganisationHasMyCare, A547OrganisationHasMyLiving, A548OrganisationHasMyServices, A549OrganisationHasDynamicForms, A550OrganisationBrandTheme, A551OrganisationCtaTheme, A566OrganisationHasOwnBrand, A100OrganisationSettingid, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F107( ) ;
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
            EndLevel0F107( ) ;
         }
         CloseExtendedTableCursors0F107( ) ;
      }

      protected void DeferredUpdate0F107( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F9 */
            pr_default.execute(7, new Object[] {A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A100OrganisationSettingid, A11OrganisationId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F10 */
            pr_default.execute(8, new Object[] {A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A100OrganisationSettingid, A11OrganisationId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F107( ) ;
            AfterConfirm0F107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F11 */
                  pr_default.execute(9, new Object[] {A100OrganisationSettingid, A11OrganisationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
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
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F107( ) ;
         Gx_mode = sMode107;
      }

      protected void OnDeleteControls0F107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F107( ) ;
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

      public void ScanKeyStart0F107( )
      {
         /* Scan By routine */
         /* Using cursor BC000F12 */
         pr_default.execute(10, new Object[] {A100OrganisationSettingid, A11OrganisationId});
         RcdFound107 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A100OrganisationSettingid = BC000F12_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F12_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F12_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F12_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F12_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F12_A105OrganisationSettingLanguage[0];
            A546OrganisationHasMyCare = BC000F12_A546OrganisationHasMyCare[0];
            A547OrganisationHasMyLiving = BC000F12_A547OrganisationHasMyLiving[0];
            A548OrganisationHasMyServices = BC000F12_A548OrganisationHasMyServices[0];
            A549OrganisationHasDynamicForms = BC000F12_A549OrganisationHasDynamicForms[0];
            A550OrganisationBrandTheme = BC000F12_A550OrganisationBrandTheme[0];
            A551OrganisationCtaTheme = BC000F12_A551OrganisationCtaTheme[0];
            A566OrganisationHasOwnBrand = BC000F12_A566OrganisationHasOwnBrand[0];
            A11OrganisationId = BC000F12_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F12_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F12_A102OrganisationSettingFavicon[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F107( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound107 = 0;
         ScanKeyLoad0F107( ) ;
      }

      protected void ScanKeyLoad0F107( )
      {
         sMode107 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A100OrganisationSettingid = BC000F12_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F12_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F12_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F12_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F12_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F12_A105OrganisationSettingLanguage[0];
            A546OrganisationHasMyCare = BC000F12_A546OrganisationHasMyCare[0];
            A547OrganisationHasMyLiving = BC000F12_A547OrganisationHasMyLiving[0];
            A548OrganisationHasMyServices = BC000F12_A548OrganisationHasMyServices[0];
            A549OrganisationHasDynamicForms = BC000F12_A549OrganisationHasDynamicForms[0];
            A550OrganisationBrandTheme = BC000F12_A550OrganisationBrandTheme[0];
            A551OrganisationCtaTheme = BC000F12_A551OrganisationCtaTheme[0];
            A566OrganisationHasOwnBrand = BC000F12_A566OrganisationHasOwnBrand[0];
            A11OrganisationId = BC000F12_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F12_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F12_A102OrganisationSettingFavicon[0];
         }
         Gx_mode = sMode107;
      }

      protected void ScanKeyEnd0F107( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0F107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F107( )
      {
         /* Before Insert Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103OrganisationSettingBaseColor)) )
         {
            A103OrganisationSettingBaseColor = context.GetMessage( "Teal", "");
         }
      }

      protected void BeforeUpdate0F107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F107( )
      {
      }

      protected void send_integrity_lvl_hashes0F107( )
      {
      }

      protected void AddRow0F107( )
      {
         VarsToRow107( bcTrn_OrganisationSetting) ;
      }

      protected void ReadRow0F107( )
      {
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
      }

      protected void InitializeNonKey0F107( )
      {
         A103OrganisationSettingBaseColor = "";
         A101OrganisationSettingLogo = "";
         A40000OrganisationSettingLogo_GXI = "";
         A102OrganisationSettingFavicon = "";
         A40001OrganisationSettingFavicon_GXI = "";
         A104OrganisationSettingFontSize = "";
         A105OrganisationSettingLanguage = "";
         A546OrganisationHasMyCare = false;
         A547OrganisationHasMyLiving = false;
         A548OrganisationHasMyServices = false;
         A549OrganisationHasDynamicForms = false;
         A550OrganisationBrandTheme = "";
         A551OrganisationCtaTheme = "";
         A566OrganisationHasOwnBrand = false;
         Z103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         Z546OrganisationHasMyCare = false;
         Z547OrganisationHasMyLiving = false;
         Z548OrganisationHasMyServices = false;
         Z549OrganisationHasDynamicForms = false;
         Z566OrganisationHasOwnBrand = false;
      }

      protected void InitAll0F107( )
      {
         A100OrganisationSettingid = Guid.NewGuid( );
         A11OrganisationId = Guid.Empty;
         InitializeNonKey0F107( ) ;
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

      public void VarsToRow107( SdtTrn_OrganisationSetting obj107 )
      {
         obj107.gxTpr_Mode = Gx_mode;
         obj107.gxTpr_Organisationsettingbasecolor = A103OrganisationSettingBaseColor;
         obj107.gxTpr_Organisationsettinglogo = A101OrganisationSettingLogo;
         obj107.gxTpr_Organisationsettinglogo_gxi = A40000OrganisationSettingLogo_GXI;
         obj107.gxTpr_Organisationsettingfavicon = A102OrganisationSettingFavicon;
         obj107.gxTpr_Organisationsettingfavicon_gxi = A40001OrganisationSettingFavicon_GXI;
         obj107.gxTpr_Organisationsettingfontsize = A104OrganisationSettingFontSize;
         obj107.gxTpr_Organisationsettinglanguage = A105OrganisationSettingLanguage;
         obj107.gxTpr_Organisationhasmycare = A546OrganisationHasMyCare;
         obj107.gxTpr_Organisationhasmyliving = A547OrganisationHasMyLiving;
         obj107.gxTpr_Organisationhasmyservices = A548OrganisationHasMyServices;
         obj107.gxTpr_Organisationhasdynamicforms = A549OrganisationHasDynamicForms;
         obj107.gxTpr_Organisationbrandtheme = A550OrganisationBrandTheme;
         obj107.gxTpr_Organisationctatheme = A551OrganisationCtaTheme;
         obj107.gxTpr_Organisationhasownbrand = A566OrganisationHasOwnBrand;
         obj107.gxTpr_Organisationsettingid = A100OrganisationSettingid;
         obj107.gxTpr_Organisationid = A11OrganisationId;
         obj107.gxTpr_Organisationsettingid_Z = Z100OrganisationSettingid;
         obj107.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj107.gxTpr_Organisationsettingbasecolor_Z = Z103OrganisationSettingBaseColor;
         obj107.gxTpr_Organisationsettingfontsize_Z = Z104OrganisationSettingFontSize;
         obj107.gxTpr_Organisationhasmycare_Z = Z546OrganisationHasMyCare;
         obj107.gxTpr_Organisationhasmyliving_Z = Z547OrganisationHasMyLiving;
         obj107.gxTpr_Organisationhasmyservices_Z = Z548OrganisationHasMyServices;
         obj107.gxTpr_Organisationhasdynamicforms_Z = Z549OrganisationHasDynamicForms;
         obj107.gxTpr_Organisationhasownbrand_Z = Z566OrganisationHasOwnBrand;
         obj107.gxTpr_Organisationsettinglogo_gxi_Z = Z40000OrganisationSettingLogo_GXI;
         obj107.gxTpr_Organisationsettingfavicon_gxi_Z = Z40001OrganisationSettingFavicon_GXI;
         obj107.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow107( SdtTrn_OrganisationSetting obj107 )
      {
         obj107.gxTpr_Organisationsettingid = A100OrganisationSettingid;
         obj107.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars107( SdtTrn_OrganisationSetting obj107 ,
                                int forceLoad )
      {
         Gx_mode = obj107.gxTpr_Mode;
         A103OrganisationSettingBaseColor = obj107.gxTpr_Organisationsettingbasecolor;
         A101OrganisationSettingLogo = obj107.gxTpr_Organisationsettinglogo;
         A40000OrganisationSettingLogo_GXI = obj107.gxTpr_Organisationsettinglogo_gxi;
         A102OrganisationSettingFavicon = obj107.gxTpr_Organisationsettingfavicon;
         A40001OrganisationSettingFavicon_GXI = obj107.gxTpr_Organisationsettingfavicon_gxi;
         A104OrganisationSettingFontSize = obj107.gxTpr_Organisationsettingfontsize;
         A105OrganisationSettingLanguage = obj107.gxTpr_Organisationsettinglanguage;
         A546OrganisationHasMyCare = obj107.gxTpr_Organisationhasmycare;
         A547OrganisationHasMyLiving = obj107.gxTpr_Organisationhasmyliving;
         A548OrganisationHasMyServices = obj107.gxTpr_Organisationhasmyservices;
         A549OrganisationHasDynamicForms = obj107.gxTpr_Organisationhasdynamicforms;
         A550OrganisationBrandTheme = obj107.gxTpr_Organisationbrandtheme;
         A551OrganisationCtaTheme = obj107.gxTpr_Organisationctatheme;
         A566OrganisationHasOwnBrand = obj107.gxTpr_Organisationhasownbrand;
         A100OrganisationSettingid = obj107.gxTpr_Organisationsettingid;
         A11OrganisationId = obj107.gxTpr_Organisationid;
         Z100OrganisationSettingid = obj107.gxTpr_Organisationsettingid_Z;
         Z11OrganisationId = obj107.gxTpr_Organisationid_Z;
         Z103OrganisationSettingBaseColor = obj107.gxTpr_Organisationsettingbasecolor_Z;
         Z104OrganisationSettingFontSize = obj107.gxTpr_Organisationsettingfontsize_Z;
         Z546OrganisationHasMyCare = obj107.gxTpr_Organisationhasmycare_Z;
         Z547OrganisationHasMyLiving = obj107.gxTpr_Organisationhasmyliving_Z;
         Z548OrganisationHasMyServices = obj107.gxTpr_Organisationhasmyservices_Z;
         Z549OrganisationHasDynamicForms = obj107.gxTpr_Organisationhasdynamicforms_Z;
         Z566OrganisationHasOwnBrand = obj107.gxTpr_Organisationhasownbrand_Z;
         Z40000OrganisationSettingLogo_GXI = obj107.gxTpr_Organisationsettinglogo_gxi_Z;
         Z40001OrganisationSettingFavicon_GXI = obj107.gxTpr_Organisationsettingfavicon_gxi_Z;
         Gx_mode = obj107.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A100OrganisationSettingid = (Guid)getParm(obj,0);
         A11OrganisationId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F107( ) ;
         ScanKeyStart0F107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000F13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0F107( -6) ;
         OnLoadActions0F107( ) ;
         AddRow0F107( ) ;
         ScanKeyEnd0F107( ) ;
         if ( RcdFound107 == 0 )
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
         RowToVars107( bcTrn_OrganisationSetting, 0) ;
         ScanKeyStart0F107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000F13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0F107( -6) ;
         OnLoadActions0F107( ) ;
         AddRow0F107( ) ;
         ScanKeyEnd0F107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F107( ) ;
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( ( A100OrganisationSettingid != Z100OrganisationSettingid ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A100OrganisationSettingid = Z100OrganisationSettingid;
                  A11OrganisationId = Z11OrganisationId;
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
                  Update0F107( ) ;
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
                  if ( ( A100OrganisationSettingid != Z100OrganisationSettingid ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert0F107( ) ;
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
                        Insert0F107( ) ;
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
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
         SaveImpl( ) ;
         VarsToRow107( bcTrn_OrganisationSetting) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F107( ) ;
         AfterTrn( ) ;
         VarsToRow107( bcTrn_OrganisationSetting) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow107( bcTrn_OrganisationSetting) ;
         }
         else
         {
            SdtTrn_OrganisationSetting auxBC = new SdtTrn_OrganisationSetting(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A100OrganisationSettingid, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_OrganisationSetting);
               auxBC.Save();
               bcTrn_OrganisationSetting.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
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
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F107( ) ;
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
               VarsToRow107( bcTrn_OrganisationSetting) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow107( bcTrn_OrganisationSetting) ;
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
         RowToVars107( bcTrn_OrganisationSetting, 0) ;
         GetKey0F107( ) ;
         if ( RcdFound107 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A100OrganisationSettingid != Z100OrganisationSettingid ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A100OrganisationSettingid = Z100OrganisationSettingid;
               A11OrganisationId = Z11OrganisationId;
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
            if ( ( A100OrganisationSettingid != Z100OrganisationSettingid ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_organisationsetting_bc",pr_default);
         VarsToRow107( bcTrn_OrganisationSetting) ;
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
         Gx_mode = bcTrn_OrganisationSetting.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_OrganisationSetting.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_OrganisationSetting )
         {
            bcTrn_OrganisationSetting = (SdtTrn_OrganisationSetting)(sdt);
            if ( StringUtil.StrCmp(bcTrn_OrganisationSetting.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationSetting.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow107( bcTrn_OrganisationSetting) ;
            }
            else
            {
               RowToVars107( bcTrn_OrganisationSetting, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_OrganisationSetting.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationSetting.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars107( bcTrn_OrganisationSetting, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_OrganisationSetting Trn_OrganisationSetting_BC
      {
         get {
            return bcTrn_OrganisationSetting ;
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
            return "trn_organisationsetting_Execute" ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z100OrganisationSettingid = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z103OrganisationSettingBaseColor = "";
         A103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         A104OrganisationSettingFontSize = "";
         Z101OrganisationSettingLogo = "";
         A101OrganisationSettingLogo = "";
         Z40000OrganisationSettingLogo_GXI = "";
         A40000OrganisationSettingLogo_GXI = "";
         Z102OrganisationSettingFavicon = "";
         A102OrganisationSettingFavicon = "";
         Z40001OrganisationSettingFavicon_GXI = "";
         A40001OrganisationSettingFavicon_GXI = "";
         Z105OrganisationSettingLanguage = "";
         A105OrganisationSettingLanguage = "";
         Z550OrganisationBrandTheme = "";
         A550OrganisationBrandTheme = "";
         Z551OrganisationCtaTheme = "";
         A551OrganisationCtaTheme = "";
         BC000F5_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F5_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F5_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F5_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F5_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F5_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F5_A546OrganisationHasMyCare = new bool[] {false} ;
         BC000F5_A547OrganisationHasMyLiving = new bool[] {false} ;
         BC000F5_A548OrganisationHasMyServices = new bool[] {false} ;
         BC000F5_A549OrganisationHasDynamicForms = new bool[] {false} ;
         BC000F5_A550OrganisationBrandTheme = new string[] {""} ;
         BC000F5_A551OrganisationCtaTheme = new string[] {""} ;
         BC000F5_A566OrganisationHasOwnBrand = new bool[] {false} ;
         BC000F5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F5_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F5_A102OrganisationSettingFavicon = new string[] {""} ;
         BC000F4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F6_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F3_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F3_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F3_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F3_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F3_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F3_A546OrganisationHasMyCare = new bool[] {false} ;
         BC000F3_A547OrganisationHasMyLiving = new bool[] {false} ;
         BC000F3_A548OrganisationHasMyServices = new bool[] {false} ;
         BC000F3_A549OrganisationHasDynamicForms = new bool[] {false} ;
         BC000F3_A550OrganisationBrandTheme = new string[] {""} ;
         BC000F3_A551OrganisationCtaTheme = new string[] {""} ;
         BC000F3_A566OrganisationHasOwnBrand = new bool[] {false} ;
         BC000F3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F3_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F3_A102OrganisationSettingFavicon = new string[] {""} ;
         sMode107 = "";
         BC000F2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F2_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F2_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F2_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F2_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F2_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F2_A546OrganisationHasMyCare = new bool[] {false} ;
         BC000F2_A547OrganisationHasMyLiving = new bool[] {false} ;
         BC000F2_A548OrganisationHasMyServices = new bool[] {false} ;
         BC000F2_A549OrganisationHasDynamicForms = new bool[] {false} ;
         BC000F2_A550OrganisationBrandTheme = new string[] {""} ;
         BC000F2_A551OrganisationCtaTheme = new string[] {""} ;
         BC000F2_A566OrganisationHasOwnBrand = new bool[] {false} ;
         BC000F2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F2_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F2_A102OrganisationSettingFavicon = new string[] {""} ;
         BC000F12_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F12_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F12_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F12_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F12_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F12_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F12_A546OrganisationHasMyCare = new bool[] {false} ;
         BC000F12_A547OrganisationHasMyLiving = new bool[] {false} ;
         BC000F12_A548OrganisationHasMyServices = new bool[] {false} ;
         BC000F12_A549OrganisationHasDynamicForms = new bool[] {false} ;
         BC000F12_A550OrganisationBrandTheme = new string[] {""} ;
         BC000F12_A551OrganisationCtaTheme = new string[] {""} ;
         BC000F12_A566OrganisationHasOwnBrand = new bool[] {false} ;
         BC000F12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F12_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F12_A102OrganisationSettingFavicon = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000F13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A100OrganisationSettingid, BC000F2_A103OrganisationSettingBaseColor, BC000F2_A40000OrganisationSettingLogo_GXI, BC000F2_A40001OrganisationSettingFavicon_GXI, BC000F2_A104OrganisationSettingFontSize, BC000F2_A105OrganisationSettingLanguage, BC000F2_A546OrganisationHasMyCare, BC000F2_A547OrganisationHasMyLiving, BC000F2_A548OrganisationHasMyServices, BC000F2_A549OrganisationHasDynamicForms,
               BC000F2_A550OrganisationBrandTheme, BC000F2_A551OrganisationCtaTheme, BC000F2_A566OrganisationHasOwnBrand, BC000F2_A11OrganisationId, BC000F2_A101OrganisationSettingLogo, BC000F2_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F3_A100OrganisationSettingid, BC000F3_A103OrganisationSettingBaseColor, BC000F3_A40000OrganisationSettingLogo_GXI, BC000F3_A40001OrganisationSettingFavicon_GXI, BC000F3_A104OrganisationSettingFontSize, BC000F3_A105OrganisationSettingLanguage, BC000F3_A546OrganisationHasMyCare, BC000F3_A547OrganisationHasMyLiving, BC000F3_A548OrganisationHasMyServices, BC000F3_A549OrganisationHasDynamicForms,
               BC000F3_A550OrganisationBrandTheme, BC000F3_A551OrganisationCtaTheme, BC000F3_A566OrganisationHasOwnBrand, BC000F3_A11OrganisationId, BC000F3_A101OrganisationSettingLogo, BC000F3_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F4_A11OrganisationId
               }
               , new Object[] {
               BC000F5_A100OrganisationSettingid, BC000F5_A103OrganisationSettingBaseColor, BC000F5_A40000OrganisationSettingLogo_GXI, BC000F5_A40001OrganisationSettingFavicon_GXI, BC000F5_A104OrganisationSettingFontSize, BC000F5_A105OrganisationSettingLanguage, BC000F5_A546OrganisationHasMyCare, BC000F5_A547OrganisationHasMyLiving, BC000F5_A548OrganisationHasMyServices, BC000F5_A549OrganisationHasDynamicForms,
               BC000F5_A550OrganisationBrandTheme, BC000F5_A551OrganisationCtaTheme, BC000F5_A566OrganisationHasOwnBrand, BC000F5_A11OrganisationId, BC000F5_A101OrganisationSettingLogo, BC000F5_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F6_A100OrganisationSettingid, BC000F6_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F12_A100OrganisationSettingid, BC000F12_A103OrganisationSettingBaseColor, BC000F12_A40000OrganisationSettingLogo_GXI, BC000F12_A40001OrganisationSettingFavicon_GXI, BC000F12_A104OrganisationSettingFontSize, BC000F12_A105OrganisationSettingLanguage, BC000F12_A546OrganisationHasMyCare, BC000F12_A547OrganisationHasMyLiving, BC000F12_A548OrganisationHasMyServices, BC000F12_A549OrganisationHasDynamicForms,
               BC000F12_A550OrganisationBrandTheme, BC000F12_A551OrganisationCtaTheme, BC000F12_A566OrganisationHasOwnBrand, BC000F12_A11OrganisationId, BC000F12_A101OrganisationSettingLogo, BC000F12_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F13_A11OrganisationId
               }
            }
         );
         Z100OrganisationSettingid = Guid.NewGuid( );
         A100OrganisationSettingid = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound107 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode107 ;
      private bool returnInSub ;
      private bool Z546OrganisationHasMyCare ;
      private bool A546OrganisationHasMyCare ;
      private bool Z547OrganisationHasMyLiving ;
      private bool A547OrganisationHasMyLiving ;
      private bool Z548OrganisationHasMyServices ;
      private bool A548OrganisationHasMyServices ;
      private bool Z549OrganisationHasDynamicForms ;
      private bool A549OrganisationHasDynamicForms ;
      private bool Z566OrganisationHasOwnBrand ;
      private bool A566OrganisationHasOwnBrand ;
      private bool Gx_longc ;
      private string Z105OrganisationSettingLanguage ;
      private string A105OrganisationSettingLanguage ;
      private string Z550OrganisationBrandTheme ;
      private string A550OrganisationBrandTheme ;
      private string Z551OrganisationCtaTheme ;
      private string A551OrganisationCtaTheme ;
      private string Z103OrganisationSettingBaseColor ;
      private string A103OrganisationSettingBaseColor ;
      private string Z104OrganisationSettingFontSize ;
      private string A104OrganisationSettingFontSize ;
      private string Z40000OrganisationSettingLogo_GXI ;
      private string A40000OrganisationSettingLogo_GXI ;
      private string Z40001OrganisationSettingFavicon_GXI ;
      private string A40001OrganisationSettingFavicon_GXI ;
      private string Z101OrganisationSettingLogo ;
      private string A101OrganisationSettingLogo ;
      private string Z102OrganisationSettingFavicon ;
      private string A102OrganisationSettingFavicon ;
      private Guid Z100OrganisationSettingid ;
      private Guid A100OrganisationSettingid ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000F5_A100OrganisationSettingid ;
      private string[] BC000F5_A103OrganisationSettingBaseColor ;
      private string[] BC000F5_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F5_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F5_A104OrganisationSettingFontSize ;
      private string[] BC000F5_A105OrganisationSettingLanguage ;
      private bool[] BC000F5_A546OrganisationHasMyCare ;
      private bool[] BC000F5_A547OrganisationHasMyLiving ;
      private bool[] BC000F5_A548OrganisationHasMyServices ;
      private bool[] BC000F5_A549OrganisationHasDynamicForms ;
      private string[] BC000F5_A550OrganisationBrandTheme ;
      private string[] BC000F5_A551OrganisationCtaTheme ;
      private bool[] BC000F5_A566OrganisationHasOwnBrand ;
      private Guid[] BC000F5_A11OrganisationId ;
      private string[] BC000F5_A101OrganisationSettingLogo ;
      private string[] BC000F5_A102OrganisationSettingFavicon ;
      private Guid[] BC000F4_A11OrganisationId ;
      private Guid[] BC000F6_A100OrganisationSettingid ;
      private Guid[] BC000F6_A11OrganisationId ;
      private Guid[] BC000F3_A100OrganisationSettingid ;
      private string[] BC000F3_A103OrganisationSettingBaseColor ;
      private string[] BC000F3_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F3_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F3_A104OrganisationSettingFontSize ;
      private string[] BC000F3_A105OrganisationSettingLanguage ;
      private bool[] BC000F3_A546OrganisationHasMyCare ;
      private bool[] BC000F3_A547OrganisationHasMyLiving ;
      private bool[] BC000F3_A548OrganisationHasMyServices ;
      private bool[] BC000F3_A549OrganisationHasDynamicForms ;
      private string[] BC000F3_A550OrganisationBrandTheme ;
      private string[] BC000F3_A551OrganisationCtaTheme ;
      private bool[] BC000F3_A566OrganisationHasOwnBrand ;
      private Guid[] BC000F3_A11OrganisationId ;
      private string[] BC000F3_A101OrganisationSettingLogo ;
      private string[] BC000F3_A102OrganisationSettingFavicon ;
      private Guid[] BC000F2_A100OrganisationSettingid ;
      private string[] BC000F2_A103OrganisationSettingBaseColor ;
      private string[] BC000F2_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F2_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F2_A104OrganisationSettingFontSize ;
      private string[] BC000F2_A105OrganisationSettingLanguage ;
      private bool[] BC000F2_A546OrganisationHasMyCare ;
      private bool[] BC000F2_A547OrganisationHasMyLiving ;
      private bool[] BC000F2_A548OrganisationHasMyServices ;
      private bool[] BC000F2_A549OrganisationHasDynamicForms ;
      private string[] BC000F2_A550OrganisationBrandTheme ;
      private string[] BC000F2_A551OrganisationCtaTheme ;
      private bool[] BC000F2_A566OrganisationHasOwnBrand ;
      private Guid[] BC000F2_A11OrganisationId ;
      private string[] BC000F2_A101OrganisationSettingLogo ;
      private string[] BC000F2_A102OrganisationSettingFavicon ;
      private Guid[] BC000F12_A100OrganisationSettingid ;
      private string[] BC000F12_A103OrganisationSettingBaseColor ;
      private string[] BC000F12_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F12_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F12_A104OrganisationSettingFontSize ;
      private string[] BC000F12_A105OrganisationSettingLanguage ;
      private bool[] BC000F12_A546OrganisationHasMyCare ;
      private bool[] BC000F12_A547OrganisationHasMyLiving ;
      private bool[] BC000F12_A548OrganisationHasMyServices ;
      private bool[] BC000F12_A549OrganisationHasDynamicForms ;
      private string[] BC000F12_A550OrganisationBrandTheme ;
      private string[] BC000F12_A551OrganisationCtaTheme ;
      private bool[] BC000F12_A566OrganisationHasOwnBrand ;
      private Guid[] BC000F12_A11OrganisationId ;
      private string[] BC000F12_A101OrganisationSettingLogo ;
      private string[] BC000F12_A102OrganisationSettingFavicon ;
      private SdtTrn_OrganisationSetting bcTrn_OrganisationSetting ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000F13_A11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisationsetting_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisationsetting_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisationsetting_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000F2;
       prmBC000F2 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F3;
       prmBC000F3 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F4;
       prmBC000F4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F5;
       prmBC000F5 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F6;
       prmBC000F6 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F7;
       prmBC000F7 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationSettingBaseColor",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingLogo"} ,
       new ParDef("OrganisationSettingFavicon",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingFavicon_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingFavicon"} ,
       new ParDef("OrganisationSettingFontSize",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingLanguage",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasDynamicForms",GXType.Boolean,4,0) ,
       new ParDef("OrganisationBrandTheme",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationCtaTheme",GXType.LongVarChar,1000,0) ,
       new ParDef("OrganisationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F8;
       prmBC000F8 = new Object[] {
       new ParDef("OrganisationSettingBaseColor",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingFontSize",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingLanguage",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("OrganisationHasDynamicForms",GXType.Boolean,4,0) ,
       new ParDef("OrganisationBrandTheme",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationCtaTheme",GXType.LongVarChar,1000,0) ,
       new ParDef("OrganisationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F9;
       prmBC000F9 = new Object[] {
       new ParDef("OrganisationSettingLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingLogo"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F10;
       prmBC000F10 = new Object[] {
       new ParDef("OrganisationSettingFavicon",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingFavicon_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingFavicon"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F11;
       prmBC000F11 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F12;
       prmBC000F12 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F13;
       prmBC000F13 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000F2", "SELECT OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationHasDynamicForms, OrganisationBrandTheme, OrganisationCtaTheme, OrganisationHasOwnBrand, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_OrganisationSetting",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F3", "SELECT OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationHasDynamicForms, OrganisationBrandTheme, OrganisationCtaTheme, OrganisationHasOwnBrand, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F5", "SELECT TM1.OrganisationSettingid, TM1.OrganisationSettingBaseColor, TM1.OrganisationSettingLogo_GXI, TM1.OrganisationSettingFavicon_GXI, TM1.OrganisationSettingFontSize, TM1.OrganisationSettingLanguage, TM1.OrganisationHasMyCare, TM1.OrganisationHasMyLiving, TM1.OrganisationHasMyServices, TM1.OrganisationHasDynamicForms, TM1.OrganisationBrandTheme, TM1.OrganisationCtaTheme, TM1.OrganisationHasOwnBrand, TM1.OrganisationId, TM1.OrganisationSettingLogo, TM1.OrganisationSettingFavicon FROM Trn_OrganisationSetting TM1 WHERE TM1.OrganisationSettingid = :OrganisationSettingid and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationSettingid, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F6", "SELECT OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F7", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationSetting(OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo, OrganisationSettingLogo_GXI, OrganisationSettingFavicon, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationHasDynamicForms, OrganisationBrandTheme, OrganisationCtaTheme, OrganisationHasOwnBrand, OrganisationId) VALUES(:OrganisationSettingid, :OrganisationSettingBaseColor, :OrganisationSettingLogo, :OrganisationSettingLogo_GXI, :OrganisationSettingFavicon, :OrganisationSettingFavicon_GXI, :OrganisationSettingFontSize, :OrganisationSettingLanguage, :OrganisationHasMyCare, :OrganisationHasMyLiving, :OrganisationHasMyServices, :OrganisationHasDynamicForms, :OrganisationBrandTheme, :OrganisationCtaTheme, :OrganisationHasOwnBrand, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F7)
          ,new CursorDef("BC000F8", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingBaseColor=:OrganisationSettingBaseColor, OrganisationSettingFontSize=:OrganisationSettingFontSize, OrganisationSettingLanguage=:OrganisationSettingLanguage, OrganisationHasMyCare=:OrganisationHasMyCare, OrganisationHasMyLiving=:OrganisationHasMyLiving, OrganisationHasMyServices=:OrganisationHasMyServices, OrganisationHasDynamicForms=:OrganisationHasDynamicForms, OrganisationBrandTheme=:OrganisationBrandTheme, OrganisationCtaTheme=:OrganisationCtaTheme, OrganisationHasOwnBrand=:OrganisationHasOwnBrand  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F8)
          ,new CursorDef("BC000F9", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingLogo=:OrganisationSettingLogo, OrganisationSettingLogo_GXI=:OrganisationSettingLogo_GXI  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F9)
          ,new CursorDef("BC000F10", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingFavicon=:OrganisationSettingFavicon, OrganisationSettingFavicon_GXI=:OrganisationSettingFavicon_GXI  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F10)
          ,new CursorDef("BC000F11", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationSetting  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F11)
          ,new CursorDef("BC000F12", "SELECT TM1.OrganisationSettingid, TM1.OrganisationSettingBaseColor, TM1.OrganisationSettingLogo_GXI, TM1.OrganisationSettingFavicon_GXI, TM1.OrganisationSettingFontSize, TM1.OrganisationSettingLanguage, TM1.OrganisationHasMyCare, TM1.OrganisationHasMyLiving, TM1.OrganisationHasMyServices, TM1.OrganisationHasDynamicForms, TM1.OrganisationBrandTheme, TM1.OrganisationCtaTheme, TM1.OrganisationHasOwnBrand, TM1.OrganisationId, TM1.OrganisationSettingLogo, TM1.OrganisationSettingFavicon FROM Trn_OrganisationSetting TM1 WHERE TM1.OrganisationSettingid = :OrganisationSettingid and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationSettingid, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F13", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F13,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(3));
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(4));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(3));
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(4));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(3));
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(4));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(3));
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(4));
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
