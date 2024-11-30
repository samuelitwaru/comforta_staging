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
         ReadRow0F25( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F25( ) ;
         standaloneModal( ) ;
         AddRow0F25( ) ;
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
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F25( ) ;
            }
            else
            {
               CheckExtendedTable0F25( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F25( 10) ;
               }
               CloseExtendedTableCursors0F25( ) ;
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
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV29Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV30GXV1 = 1;
            while ( AV30GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV30GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV30GXV1 = (int)(AV30GXV1+1);
            }
         }
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV12WebSession.Remove(context.GetMessage( "SelectedBaseColor", ""));
         GX_msglist.addItem(context.GetMessage( "Saved successfully", ""));
      }

      protected void ZM0F25( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
            Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
            Z101OrganisationSettingLogo = A101OrganisationSettingLogo;
            Z40000OrganisationSettingLogo_GXI = A40000OrganisationSettingLogo_GXI;
            Z102OrganisationSettingFavicon = A102OrganisationSettingFavicon;
            Z40001OrganisationSettingFavicon_GXI = A40001OrganisationSettingFavicon_GXI;
            Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
            Z105OrganisationSettingLanguage = A105OrganisationSettingLanguage;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV29Pgmname = "Trn_OrganisationSetting_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A100OrganisationSettingid) )
         {
            A100OrganisationSettingid = Guid.NewGuid( );
         }
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), "")))) )
         {
            A103OrganisationSettingBaseColor = AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F25( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
            A103OrganisationSettingBaseColor = BC000F5_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F5_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F5_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F5_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F5_A105OrganisationSettingLanguage[0];
            A11OrganisationId = BC000F5_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F5_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F5_A102OrganisationSettingFavicon[0];
            ZM0F25( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0F25( ) ;
      }

      protected void OnLoadActions0F25( )
      {
      }

      protected void CheckExtendedTable0F25( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F25( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F25( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F25( 9) ;
            RcdFound25 = 1;
            A100OrganisationSettingid = BC000F3_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F3_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F3_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F3_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F3_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F3_A105OrganisationSettingLanguage[0];
            A11OrganisationId = BC000F3_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F3_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F3_A102OrganisationSettingFavicon[0];
            Z100OrganisationSettingid = A100OrganisationSettingid;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0F25( ) ;
            }
            Gx_mode = sMode25;
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0F25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode25;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F25( ) ;
         if ( RcdFound25 == 0 )
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

      protected void CheckOptimisticConcurrency0F25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A100OrganisationSettingid});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103OrganisationSettingBaseColor, BC000F2_A103OrganisationSettingBaseColor[0]) != 0 ) || ( StringUtil.StrCmp(Z104OrganisationSettingFontSize, BC000F2_A104OrganisationSettingFontSize[0]) != 0 ) || ( Z11OrganisationId != BC000F2_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationSetting"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F25( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F25( 0) ;
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A100OrganisationSettingid, A103OrganisationSettingBaseColor, A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A104OrganisationSettingFontSize, A105OrganisationSettingLanguage, A11OrganisationId});
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
               Load0F25( ) ;
            }
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void Update0F25( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F8 */
                     pr_default.execute(6, new Object[] {A103OrganisationSettingBaseColor, A104OrganisationSettingFontSize, A105OrganisationSettingLanguage, A11OrganisationId, A100OrganisationSettingid});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F25( ) ;
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
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void DeferredUpdate0F25( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F9 */
            pr_default.execute(7, new Object[] {A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A100OrganisationSettingid});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F10 */
            pr_default.execute(8, new Object[] {A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A100OrganisationSettingid});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F25( ) ;
            AfterConfirm0F25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F11 */
                  pr_default.execute(9, new Object[] {A100OrganisationSettingid});
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F25( ) ;
         Gx_mode = sMode25;
      }

      protected void OnDeleteControls0F25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F25( ) ;
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

      public void ScanKeyStart0F25( )
      {
         /* Scan By routine */
         /* Using cursor BC000F12 */
         pr_default.execute(10, new Object[] {A100OrganisationSettingid});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound25 = 1;
            A100OrganisationSettingid = BC000F12_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F12_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F12_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F12_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F12_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F12_A105OrganisationSettingLanguage[0];
            A11OrganisationId = BC000F12_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F12_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F12_A102OrganisationSettingFavicon[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F25( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound25 = 0;
         ScanKeyLoad0F25( ) ;
      }

      protected void ScanKeyLoad0F25( )
      {
         sMode25 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound25 = 1;
            A100OrganisationSettingid = BC000F12_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = BC000F12_A103OrganisationSettingBaseColor[0];
            A40000OrganisationSettingLogo_GXI = BC000F12_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = BC000F12_A40001OrganisationSettingFavicon_GXI[0];
            A104OrganisationSettingFontSize = BC000F12_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = BC000F12_A105OrganisationSettingLanguage[0];
            A11OrganisationId = BC000F12_A11OrganisationId[0];
            A101OrganisationSettingLogo = BC000F12_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = BC000F12_A102OrganisationSettingFavicon[0];
         }
         Gx_mode = sMode25;
      }

      protected void ScanKeyEnd0F25( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0F25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F25( )
      {
         /* Before Insert Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103OrganisationSettingBaseColor)) )
         {
            A103OrganisationSettingBaseColor = context.GetMessage( "Teal", "");
         }
      }

      protected void BeforeUpdate0F25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F25( )
      {
      }

      protected void send_integrity_lvl_hashes0F25( )
      {
      }

      protected void AddRow0F25( )
      {
         VarsToRow25( bcTrn_OrganisationSetting) ;
      }

      protected void ReadRow0F25( )
      {
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
      }

      protected void InitializeNonKey0F25( )
      {
         A11OrganisationId = Guid.Empty;
         A103OrganisationSettingBaseColor = "";
         A101OrganisationSettingLogo = "";
         A40000OrganisationSettingLogo_GXI = "";
         A102OrganisationSettingFavicon = "";
         A40001OrganisationSettingFavicon_GXI = "";
         A104OrganisationSettingFontSize = "";
         A105OrganisationSettingLanguage = "";
         Z103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0F25( )
      {
         A100OrganisationSettingid = Guid.NewGuid( );
         InitializeNonKey0F25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A11OrganisationId = i11OrganisationId;
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

      public void VarsToRow25( SdtTrn_OrganisationSetting obj25 )
      {
         obj25.gxTpr_Mode = Gx_mode;
         obj25.gxTpr_Organisationid = A11OrganisationId;
         obj25.gxTpr_Organisationsettingbasecolor = A103OrganisationSettingBaseColor;
         obj25.gxTpr_Organisationsettinglogo = A101OrganisationSettingLogo;
         obj25.gxTpr_Organisationsettinglogo_gxi = A40000OrganisationSettingLogo_GXI;
         obj25.gxTpr_Organisationsettingfavicon = A102OrganisationSettingFavicon;
         obj25.gxTpr_Organisationsettingfavicon_gxi = A40001OrganisationSettingFavicon_GXI;
         obj25.gxTpr_Organisationsettingfontsize = A104OrganisationSettingFontSize;
         obj25.gxTpr_Organisationsettinglanguage = A105OrganisationSettingLanguage;
         obj25.gxTpr_Organisationsettingid = A100OrganisationSettingid;
         obj25.gxTpr_Organisationsettingid_Z = Z100OrganisationSettingid;
         obj25.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj25.gxTpr_Organisationsettingbasecolor_Z = Z103OrganisationSettingBaseColor;
         obj25.gxTpr_Organisationsettingfontsize_Z = Z104OrganisationSettingFontSize;
         obj25.gxTpr_Organisationsettinglogo_gxi_Z = Z40000OrganisationSettingLogo_GXI;
         obj25.gxTpr_Organisationsettingfavicon_gxi_Z = Z40001OrganisationSettingFavicon_GXI;
         obj25.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow25( SdtTrn_OrganisationSetting obj25 )
      {
         obj25.gxTpr_Organisationsettingid = A100OrganisationSettingid;
         return  ;
      }

      public void RowToVars25( SdtTrn_OrganisationSetting obj25 ,
                               int forceLoad )
      {
         Gx_mode = obj25.gxTpr_Mode;
         A11OrganisationId = obj25.gxTpr_Organisationid;
         A103OrganisationSettingBaseColor = obj25.gxTpr_Organisationsettingbasecolor;
         A101OrganisationSettingLogo = obj25.gxTpr_Organisationsettinglogo;
         A40000OrganisationSettingLogo_GXI = obj25.gxTpr_Organisationsettinglogo_gxi;
         A102OrganisationSettingFavicon = obj25.gxTpr_Organisationsettingfavicon;
         A40001OrganisationSettingFavicon_GXI = obj25.gxTpr_Organisationsettingfavicon_gxi;
         A104OrganisationSettingFontSize = obj25.gxTpr_Organisationsettingfontsize;
         A105OrganisationSettingLanguage = obj25.gxTpr_Organisationsettinglanguage;
         A100OrganisationSettingid = obj25.gxTpr_Organisationsettingid;
         Z100OrganisationSettingid = obj25.gxTpr_Organisationsettingid_Z;
         Z11OrganisationId = obj25.gxTpr_Organisationid_Z;
         Z103OrganisationSettingBaseColor = obj25.gxTpr_Organisationsettingbasecolor_Z;
         Z104OrganisationSettingFontSize = obj25.gxTpr_Organisationsettingfontsize_Z;
         Z40000OrganisationSettingLogo_GXI = obj25.gxTpr_Organisationsettinglogo_gxi_Z;
         Z40001OrganisationSettingFavicon_GXI = obj25.gxTpr_Organisationsettingfavicon_gxi_Z;
         Gx_mode = obj25.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A100OrganisationSettingid = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F25( ) ;
         ScanKeyStart0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z100OrganisationSettingid = A100OrganisationSettingid;
         }
         ZM0F25( -9) ;
         OnLoadActions0F25( ) ;
         AddRow0F25( ) ;
         ScanKeyEnd0F25( ) ;
         if ( RcdFound25 == 0 )
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
         RowToVars25( bcTrn_OrganisationSetting, 0) ;
         ScanKeyStart0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z100OrganisationSettingid = A100OrganisationSettingid;
         }
         ZM0F25( -9) ;
         OnLoadActions0F25( ) ;
         AddRow0F25( ) ;
         ScanKeyEnd0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F25( ) ;
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A100OrganisationSettingid != Z100OrganisationSettingid )
               {
                  A100OrganisationSettingid = Z100OrganisationSettingid;
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
                  Update0F25( ) ;
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
                  if ( A100OrganisationSettingid != Z100OrganisationSettingid )
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
                        Insert0F25( ) ;
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
                        Insert0F25( ) ;
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
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
         SaveImpl( ) ;
         VarsToRow25( bcTrn_OrganisationSetting) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F25( ) ;
         AfterTrn( ) ;
         VarsToRow25( bcTrn_OrganisationSetting) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow25( bcTrn_OrganisationSetting) ;
         }
         else
         {
            SdtTrn_OrganisationSetting auxBC = new SdtTrn_OrganisationSetting(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A100OrganisationSettingid);
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
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
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
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F25( ) ;
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
               VarsToRow25( bcTrn_OrganisationSetting) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow25( bcTrn_OrganisationSetting) ;
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
         RowToVars25( bcTrn_OrganisationSetting, 0) ;
         GetKey0F25( ) ;
         if ( RcdFound25 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A100OrganisationSettingid != Z100OrganisationSettingid )
            {
               A100OrganisationSettingid = Z100OrganisationSettingid;
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
            if ( A100OrganisationSettingid != Z100OrganisationSettingid )
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
         VarsToRow25( bcTrn_OrganisationSetting) ;
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
               VarsToRow25( bcTrn_OrganisationSetting) ;
            }
            else
            {
               RowToVars25( bcTrn_OrganisationSetting, 1) ;
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
         RowToVars25( bcTrn_OrganisationSetting, 1) ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z100OrganisationSettingid = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV29Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationId = Guid.Empty;
         Z103OrganisationSettingBaseColor = "";
         A103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         A104OrganisationSettingFontSize = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
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
         GXt_guid1 = Guid.Empty;
         BC000F5_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F5_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F5_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F5_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F5_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F5_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F5_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F5_A102OrganisationSettingFavicon = new string[] {""} ;
         BC000F4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F6_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F3_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F3_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F3_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F3_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F3_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F3_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F3_A102OrganisationSettingFavicon = new string[] {""} ;
         sMode25 = "";
         BC000F2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F2_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F2_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F2_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F2_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F2_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F2_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F2_A102OrganisationSettingFavicon = new string[] {""} ;
         BC000F12_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000F12_A103OrganisationSettingBaseColor = new string[] {""} ;
         BC000F12_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         BC000F12_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         BC000F12_A104OrganisationSettingFontSize = new string[] {""} ;
         BC000F12_A105OrganisationSettingLanguage = new string[] {""} ;
         BC000F12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000F12_A101OrganisationSettingLogo = new string[] {""} ;
         BC000F12_A102OrganisationSettingFavicon = new string[] {""} ;
         i11OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
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
               BC000F2_A100OrganisationSettingid, BC000F2_A103OrganisationSettingBaseColor, BC000F2_A40000OrganisationSettingLogo_GXI, BC000F2_A40001OrganisationSettingFavicon_GXI, BC000F2_A104OrganisationSettingFontSize, BC000F2_A105OrganisationSettingLanguage, BC000F2_A11OrganisationId, BC000F2_A101OrganisationSettingLogo, BC000F2_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F3_A100OrganisationSettingid, BC000F3_A103OrganisationSettingBaseColor, BC000F3_A40000OrganisationSettingLogo_GXI, BC000F3_A40001OrganisationSettingFavicon_GXI, BC000F3_A104OrganisationSettingFontSize, BC000F3_A105OrganisationSettingLanguage, BC000F3_A11OrganisationId, BC000F3_A101OrganisationSettingLogo, BC000F3_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F4_A11OrganisationId
               }
               , new Object[] {
               BC000F5_A100OrganisationSettingid, BC000F5_A103OrganisationSettingBaseColor, BC000F5_A40000OrganisationSettingLogo_GXI, BC000F5_A40001OrganisationSettingFavicon_GXI, BC000F5_A104OrganisationSettingFontSize, BC000F5_A105OrganisationSettingLanguage, BC000F5_A11OrganisationId, BC000F5_A101OrganisationSettingLogo, BC000F5_A102OrganisationSettingFavicon
               }
               , new Object[] {
               BC000F6_A100OrganisationSettingid
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
               BC000F12_A100OrganisationSettingid, BC000F12_A103OrganisationSettingBaseColor, BC000F12_A40000OrganisationSettingLogo_GXI, BC000F12_A40001OrganisationSettingFavicon_GXI, BC000F12_A104OrganisationSettingFontSize, BC000F12_A105OrganisationSettingLanguage, BC000F12_A11OrganisationId, BC000F12_A101OrganisationSettingLogo, BC000F12_A102OrganisationSettingFavicon
               }
            }
         );
         Z100OrganisationSettingid = Guid.NewGuid( );
         A100OrganisationSettingid = Guid.NewGuid( );
         AV29Pgmname = "Trn_OrganisationSetting_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private int trnEnded ;
      private int AV30GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV29Pgmname ;
      private string sMode25 ;
      private bool returnInSub ;
      private string Z105OrganisationSettingLanguage ;
      private string A105OrganisationSettingLanguage ;
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
      private Guid AV13Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000F5_A100OrganisationSettingid ;
      private string[] BC000F5_A103OrganisationSettingBaseColor ;
      private string[] BC000F5_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F5_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F5_A104OrganisationSettingFontSize ;
      private string[] BC000F5_A105OrganisationSettingLanguage ;
      private Guid[] BC000F5_A11OrganisationId ;
      private string[] BC000F5_A101OrganisationSettingLogo ;
      private string[] BC000F5_A102OrganisationSettingFavicon ;
      private Guid[] BC000F4_A11OrganisationId ;
      private Guid[] BC000F6_A100OrganisationSettingid ;
      private Guid[] BC000F3_A100OrganisationSettingid ;
      private string[] BC000F3_A103OrganisationSettingBaseColor ;
      private string[] BC000F3_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F3_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F3_A104OrganisationSettingFontSize ;
      private string[] BC000F3_A105OrganisationSettingLanguage ;
      private Guid[] BC000F3_A11OrganisationId ;
      private string[] BC000F3_A101OrganisationSettingLogo ;
      private string[] BC000F3_A102OrganisationSettingFavicon ;
      private Guid[] BC000F2_A100OrganisationSettingid ;
      private string[] BC000F2_A103OrganisationSettingBaseColor ;
      private string[] BC000F2_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F2_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F2_A104OrganisationSettingFontSize ;
      private string[] BC000F2_A105OrganisationSettingLanguage ;
      private Guid[] BC000F2_A11OrganisationId ;
      private string[] BC000F2_A101OrganisationSettingLogo ;
      private string[] BC000F2_A102OrganisationSettingFavicon ;
      private Guid[] BC000F12_A100OrganisationSettingid ;
      private string[] BC000F12_A103OrganisationSettingBaseColor ;
      private string[] BC000F12_A40000OrganisationSettingLogo_GXI ;
      private string[] BC000F12_A40001OrganisationSettingFavicon_GXI ;
      private string[] BC000F12_A104OrganisationSettingFontSize ;
      private string[] BC000F12_A105OrganisationSettingLanguage ;
      private Guid[] BC000F12_A11OrganisationId ;
      private string[] BC000F12_A101OrganisationSettingLogo ;
      private string[] BC000F12_A102OrganisationSettingFavicon ;
      private SdtTrn_OrganisationSetting bcTrn_OrganisationSetting ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000F2;
       prmBC000F2 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F3;
       prmBC000F3 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F4;
       prmBC000F4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F5;
       prmBC000F5 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F6;
       prmBC000F6 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
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
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F8;
       prmBC000F8 = new Object[] {
       new ParDef("OrganisationSettingBaseColor",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingFontSize",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingLanguage",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F9;
       prmBC000F9 = new Object[] {
       new ParDef("OrganisationSettingLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingLogo"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F10;
       prmBC000F10 = new Object[] {
       new ParDef("OrganisationSettingFavicon",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingFavicon_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingFavicon"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F11;
       prmBC000F11 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000F12;
       prmBC000F12 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000F2", "SELECT OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid  FOR UPDATE OF Trn_OrganisationSetting",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F3", "SELECT OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F5", "SELECT TM1.OrganisationSettingid, TM1.OrganisationSettingBaseColor, TM1.OrganisationSettingLogo_GXI, TM1.OrganisationSettingFavicon_GXI, TM1.OrganisationSettingFontSize, TM1.OrganisationSettingLanguage, TM1.OrganisationId, TM1.OrganisationSettingLogo, TM1.OrganisationSettingFavicon FROM Trn_OrganisationSetting TM1 WHERE TM1.OrganisationSettingid = :OrganisationSettingid ORDER BY TM1.OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F6", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000F7", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationSetting(OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingLogo, OrganisationSettingLogo_GXI, OrganisationSettingFavicon, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationId) VALUES(:OrganisationSettingid, :OrganisationSettingBaseColor, :OrganisationSettingLogo, :OrganisationSettingLogo_GXI, :OrganisationSettingFavicon, :OrganisationSettingFavicon_GXI, :OrganisationSettingFontSize, :OrganisationSettingLanguage, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F7)
          ,new CursorDef("BC000F8", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingBaseColor=:OrganisationSettingBaseColor, OrganisationSettingFontSize=:OrganisationSettingFontSize, OrganisationSettingLanguage=:OrganisationSettingLanguage, OrganisationId=:OrganisationId  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F8)
          ,new CursorDef("BC000F9", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingLogo=:OrganisationSettingLogo, OrganisationSettingLogo_GXI=:OrganisationSettingLogo_GXI  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F9)
          ,new CursorDef("BC000F10", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingFavicon=:OrganisationSettingFavicon, OrganisationSettingFavicon_GXI=:OrganisationSettingFavicon_GXI  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F10)
          ,new CursorDef("BC000F11", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationSetting  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F11)
          ,new CursorDef("BC000F12", "SELECT TM1.OrganisationSettingid, TM1.OrganisationSettingBaseColor, TM1.OrganisationSettingLogo_GXI, TM1.OrganisationSettingFavicon_GXI, TM1.OrganisationSettingFontSize, TM1.OrganisationSettingLanguage, TM1.OrganisationId, TM1.OrganisationSettingLogo, TM1.OrganisationSettingFavicon FROM Trn_OrganisationSetting TM1 WHERE TM1.OrganisationSettingid = :OrganisationSettingid ORDER BY TM1.OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
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
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
             return;
    }
 }

}

}
