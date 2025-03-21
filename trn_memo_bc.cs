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
   public class trn_memo_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_memo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memo_bc( IGxContext context )
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
         ReadRow1U115( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1U115( ) ;
         standaloneModal( ) ;
         AddRow1U115( ) ;
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
            E111U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z575MemoId = A575MemoId;
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

      protected void CONFIRM_1U0( )
      {
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1U115( ) ;
            }
            else
            {
               CheckExtendedTable1U115( ) ;
               if ( AnyError == 0 )
               {
                  ZM1U115( 10) ;
                  ZM1U115( 11) ;
               }
               CloseExtendedTableCursors1U115( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            while ( AV32GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "MemoCategoryId") == 0 )
               {
                  AV14Insert_MemoCategoryId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ResidentId") == 0 )
               {
                  AV26Insert_ResidentId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV30Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
         }
      }

      protected void E111U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1U115( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z576MemoTitle = A576MemoTitle;
            Z577MemoDescription = A577MemoDescription;
            Z578MemoImage = A578MemoImage;
            Z579MemoDocument = A579MemoDocument;
            Z587MemoStartDateTime = A587MemoStartDateTime;
            Z588MemoEndDateTime = A588MemoEndDateTime;
            Z589MemoDuration = A589MemoDuration;
            Z590MemoRemoveDate = A590MemoRemoveDate;
            Z592MemoBgColorCode = A592MemoBgColorCode;
            Z593MemoForm = A593MemoForm;
            Z568MemoCategoryId = A568MemoCategoryId;
            Z62ResidentId = A62ResidentId;
            Z555SG_LocationId = A555SG_LocationId;
            Z556SG_OrganisationId = A556SG_OrganisationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z569MemoCategoryName = A569MemoCategoryName;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
         if ( GX_JID == -9 )
         {
            Z575MemoId = A575MemoId;
            Z576MemoTitle = A576MemoTitle;
            Z577MemoDescription = A577MemoDescription;
            Z578MemoImage = A578MemoImage;
            Z579MemoDocument = A579MemoDocument;
            Z587MemoStartDateTime = A587MemoStartDateTime;
            Z588MemoEndDateTime = A588MemoEndDateTime;
            Z589MemoDuration = A589MemoDuration;
            Z590MemoRemoveDate = A590MemoRemoveDate;
            Z592MemoBgColorCode = A592MemoBgColorCode;
            Z593MemoForm = A593MemoForm;
            Z568MemoCategoryId = A568MemoCategoryId;
            Z62ResidentId = A62ResidentId;
            Z555SG_LocationId = A555SG_LocationId;
            Z556SG_OrganisationId = A556SG_OrganisationId;
            Z569MemoCategoryName = A569MemoCategoryName;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Trn_Memo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A575MemoId) )
         {
            A575MemoId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1U115( )
      {
         /* Using cursor BC001U6 */
         pr_default.execute(4, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound115 = 1;
            A29LocationId = BC001U6_A29LocationId[0];
            A11OrganisationId = BC001U6_A11OrganisationId[0];
            A569MemoCategoryName = BC001U6_A569MemoCategoryName[0];
            A576MemoTitle = BC001U6_A576MemoTitle[0];
            A577MemoDescription = BC001U6_A577MemoDescription[0];
            A578MemoImage = BC001U6_A578MemoImage[0];
            n578MemoImage = BC001U6_n578MemoImage[0];
            A579MemoDocument = BC001U6_A579MemoDocument[0];
            n579MemoDocument = BC001U6_n579MemoDocument[0];
            A587MemoStartDateTime = BC001U6_A587MemoStartDateTime[0];
            n587MemoStartDateTime = BC001U6_n587MemoStartDateTime[0];
            A588MemoEndDateTime = BC001U6_A588MemoEndDateTime[0];
            n588MemoEndDateTime = BC001U6_n588MemoEndDateTime[0];
            A589MemoDuration = BC001U6_A589MemoDuration[0];
            n589MemoDuration = BC001U6_n589MemoDuration[0];
            A590MemoRemoveDate = BC001U6_A590MemoRemoveDate[0];
            A72ResidentSalutation = BC001U6_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001U6_A64ResidentGivenName[0];
            A65ResidentLastName = BC001U6_A65ResidentLastName[0];
            A71ResidentGUID = BC001U6_A71ResidentGUID[0];
            A592MemoBgColorCode = BC001U6_A592MemoBgColorCode[0];
            A593MemoForm = BC001U6_A593MemoForm[0];
            A568MemoCategoryId = BC001U6_A568MemoCategoryId[0];
            A62ResidentId = BC001U6_A62ResidentId[0];
            A555SG_LocationId = BC001U6_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001U6_A556SG_OrganisationId[0];
            ZM1U115( -9) ;
         }
         pr_default.close(4);
         OnLoadActions1U115( ) ;
      }

      protected void OnLoadActions1U115( )
      {
      }

      protected void CheckExtendedTable1U115( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001U4 */
         pr_default.execute(2, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_MemoCategory", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEMOCATEGORYID");
            AnyError = 1;
         }
         A569MemoCategoryName = BC001U4_A569MemoCategoryName[0];
         pr_default.close(2);
         /* Using cursor BC001U5 */
         pr_default.execute(3, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
         }
         A72ResidentSalutation = BC001U5_A72ResidentSalutation[0];
         A64ResidentGivenName = BC001U5_A64ResidentGivenName[0];
         A65ResidentLastName = BC001U5_A65ResidentLastName[0];
         A71ResidentGUID = BC001U5_A71ResidentGUID[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1U115( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1U115( )
      {
         /* Using cursor BC001U7 */
         pr_default.execute(5, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound115 = 1;
         }
         else
         {
            RcdFound115 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001U3 */
         pr_default.execute(1, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U115( 9) ;
            RcdFound115 = 1;
            A575MemoId = BC001U3_A575MemoId[0];
            A576MemoTitle = BC001U3_A576MemoTitle[0];
            A577MemoDescription = BC001U3_A577MemoDescription[0];
            A578MemoImage = BC001U3_A578MemoImage[0];
            n578MemoImage = BC001U3_n578MemoImage[0];
            A579MemoDocument = BC001U3_A579MemoDocument[0];
            n579MemoDocument = BC001U3_n579MemoDocument[0];
            A587MemoStartDateTime = BC001U3_A587MemoStartDateTime[0];
            n587MemoStartDateTime = BC001U3_n587MemoStartDateTime[0];
            A588MemoEndDateTime = BC001U3_A588MemoEndDateTime[0];
            n588MemoEndDateTime = BC001U3_n588MemoEndDateTime[0];
            A589MemoDuration = BC001U3_A589MemoDuration[0];
            n589MemoDuration = BC001U3_n589MemoDuration[0];
            A590MemoRemoveDate = BC001U3_A590MemoRemoveDate[0];
            A592MemoBgColorCode = BC001U3_A592MemoBgColorCode[0];
            A593MemoForm = BC001U3_A593MemoForm[0];
            A568MemoCategoryId = BC001U3_A568MemoCategoryId[0];
            A62ResidentId = BC001U3_A62ResidentId[0];
            A555SG_LocationId = BC001U3_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001U3_A556SG_OrganisationId[0];
            Z575MemoId = A575MemoId;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1U115( ) ;
            if ( AnyError == 1 )
            {
               RcdFound115 = 0;
               InitializeNonKey1U115( ) ;
            }
            Gx_mode = sMode115;
         }
         else
         {
            RcdFound115 = 0;
            InitializeNonKey1U115( ) ;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode115;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U115( ) ;
         if ( RcdFound115 == 0 )
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
         CONFIRM_1U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1U115( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001U2 */
            pr_default.execute(0, new Object[] {A575MemoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z576MemoTitle, BC001U2_A576MemoTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z577MemoDescription, BC001U2_A577MemoDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z578MemoImage, BC001U2_A578MemoImage[0]) != 0 ) || ( StringUtil.StrCmp(Z579MemoDocument, BC001U2_A579MemoDocument[0]) != 0 ) || ( Z587MemoStartDateTime != BC001U2_A587MemoStartDateTime[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z588MemoEndDateTime != BC001U2_A588MemoEndDateTime[0] ) || ( Z589MemoDuration != BC001U2_A589MemoDuration[0] ) || ( DateTimeUtil.ResetTime ( Z590MemoRemoveDate ) != DateTimeUtil.ResetTime ( BC001U2_A590MemoRemoveDate[0] ) ) || ( StringUtil.StrCmp(Z592MemoBgColorCode, BC001U2_A592MemoBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z593MemoForm, BC001U2_A593MemoForm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z568MemoCategoryId != BC001U2_A568MemoCategoryId[0] ) || ( Z62ResidentId != BC001U2_A62ResidentId[0] ) || ( Z555SG_LocationId != BC001U2_A555SG_LocationId[0] ) || ( Z556SG_OrganisationId != BC001U2_A556SG_OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Memo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U115( )
      {
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U115( 0) ;
            CheckOptimisticConcurrency1U115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U8 */
                     pr_default.execute(6, new Object[] {A575MemoId, A576MemoTitle, A577MemoDescription, n578MemoImage, A578MemoImage, n579MemoDocument, A579MemoDocument, n587MemoStartDateTime, A587MemoStartDateTime, n588MemoEndDateTime, A588MemoEndDateTime, n589MemoDuration, A589MemoDuration, A590MemoRemoveDate, A592MemoBgColorCode, A593MemoForm, A568MemoCategoryId, A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
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
               Load1U115( ) ;
            }
            EndLevel1U115( ) ;
         }
         CloseExtendedTableCursors1U115( ) ;
      }

      protected void Update1U115( )
      {
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U9 */
                     pr_default.execute(7, new Object[] {A576MemoTitle, A577MemoDescription, n578MemoImage, A578MemoImage, n579MemoDocument, A579MemoDocument, n587MemoStartDateTime, A587MemoStartDateTime, n588MemoEndDateTime, A588MemoEndDateTime, n589MemoDuration, A589MemoDuration, A590MemoRemoveDate, A592MemoBgColorCode, A593MemoForm, A568MemoCategoryId, A62ResidentId, A555SG_LocationId, A556SG_OrganisationId, A575MemoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U115( ) ;
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
            EndLevel1U115( ) ;
         }
         CloseExtendedTableCursors1U115( ) ;
      }

      protected void DeferredUpdate1U115( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U115( ) ;
            AfterConfirm1U115( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U115( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001U10 */
                  pr_default.execute(8, new Object[] {A575MemoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
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
         sMode115 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1U115( ) ;
         Gx_mode = sMode115;
      }

      protected void OnDeleteControls1U115( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001U11 */
            pr_default.execute(9, new Object[] {A568MemoCategoryId});
            A569MemoCategoryName = BC001U11_A569MemoCategoryName[0];
            pr_default.close(9);
            /* Using cursor BC001U12 */
            pr_default.execute(10, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
            A72ResidentSalutation = BC001U12_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001U12_A64ResidentGivenName[0];
            A65ResidentLastName = BC001U12_A65ResidentLastName[0];
            A71ResidentGUID = BC001U12_A71ResidentGUID[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel1U115( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U115( ) ;
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

      public void ScanKeyStart1U115( )
      {
         /* Scan By routine */
         /* Using cursor BC001U13 */
         pr_default.execute(11, new Object[] {A575MemoId});
         RcdFound115 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound115 = 1;
            A29LocationId = BC001U13_A29LocationId[0];
            A11OrganisationId = BC001U13_A11OrganisationId[0];
            A575MemoId = BC001U13_A575MemoId[0];
            A569MemoCategoryName = BC001U13_A569MemoCategoryName[0];
            A576MemoTitle = BC001U13_A576MemoTitle[0];
            A577MemoDescription = BC001U13_A577MemoDescription[0];
            A578MemoImage = BC001U13_A578MemoImage[0];
            n578MemoImage = BC001U13_n578MemoImage[0];
            A579MemoDocument = BC001U13_A579MemoDocument[0];
            n579MemoDocument = BC001U13_n579MemoDocument[0];
            A587MemoStartDateTime = BC001U13_A587MemoStartDateTime[0];
            n587MemoStartDateTime = BC001U13_n587MemoStartDateTime[0];
            A588MemoEndDateTime = BC001U13_A588MemoEndDateTime[0];
            n588MemoEndDateTime = BC001U13_n588MemoEndDateTime[0];
            A589MemoDuration = BC001U13_A589MemoDuration[0];
            n589MemoDuration = BC001U13_n589MemoDuration[0];
            A590MemoRemoveDate = BC001U13_A590MemoRemoveDate[0];
            A72ResidentSalutation = BC001U13_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001U13_A64ResidentGivenName[0];
            A65ResidentLastName = BC001U13_A65ResidentLastName[0];
            A71ResidentGUID = BC001U13_A71ResidentGUID[0];
            A592MemoBgColorCode = BC001U13_A592MemoBgColorCode[0];
            A593MemoForm = BC001U13_A593MemoForm[0];
            A568MemoCategoryId = BC001U13_A568MemoCategoryId[0];
            A62ResidentId = BC001U13_A62ResidentId[0];
            A555SG_LocationId = BC001U13_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001U13_A556SG_OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1U115( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound115 = 0;
         ScanKeyLoad1U115( ) ;
      }

      protected void ScanKeyLoad1U115( )
      {
         sMode115 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound115 = 1;
            A29LocationId = BC001U13_A29LocationId[0];
            A11OrganisationId = BC001U13_A11OrganisationId[0];
            A575MemoId = BC001U13_A575MemoId[0];
            A569MemoCategoryName = BC001U13_A569MemoCategoryName[0];
            A576MemoTitle = BC001U13_A576MemoTitle[0];
            A577MemoDescription = BC001U13_A577MemoDescription[0];
            A578MemoImage = BC001U13_A578MemoImage[0];
            n578MemoImage = BC001U13_n578MemoImage[0];
            A579MemoDocument = BC001U13_A579MemoDocument[0];
            n579MemoDocument = BC001U13_n579MemoDocument[0];
            A587MemoStartDateTime = BC001U13_A587MemoStartDateTime[0];
            n587MemoStartDateTime = BC001U13_n587MemoStartDateTime[0];
            A588MemoEndDateTime = BC001U13_A588MemoEndDateTime[0];
            n588MemoEndDateTime = BC001U13_n588MemoEndDateTime[0];
            A589MemoDuration = BC001U13_A589MemoDuration[0];
            n589MemoDuration = BC001U13_n589MemoDuration[0];
            A590MemoRemoveDate = BC001U13_A590MemoRemoveDate[0];
            A72ResidentSalutation = BC001U13_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001U13_A64ResidentGivenName[0];
            A65ResidentLastName = BC001U13_A65ResidentLastName[0];
            A71ResidentGUID = BC001U13_A71ResidentGUID[0];
            A592MemoBgColorCode = BC001U13_A592MemoBgColorCode[0];
            A593MemoForm = BC001U13_A593MemoForm[0];
            A568MemoCategoryId = BC001U13_A568MemoCategoryId[0];
            A62ResidentId = BC001U13_A62ResidentId[0];
            A555SG_LocationId = BC001U13_A555SG_LocationId[0];
            A556SG_OrganisationId = BC001U13_A556SG_OrganisationId[0];
         }
         Gx_mode = sMode115;
      }

      protected void ScanKeyEnd1U115( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1U115( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U115( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U115( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U115( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U115( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U115( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U115( )
      {
      }

      protected void send_integrity_lvl_hashes1U115( )
      {
      }

      protected void AddRow1U115( )
      {
         VarsToRow115( bcTrn_Memo) ;
      }

      protected void ReadRow1U115( )
      {
         RowToVars115( bcTrn_Memo, 1) ;
      }

      protected void InitializeNonKey1U115( )
      {
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         A569MemoCategoryName = "";
         A576MemoTitle = "";
         A577MemoDescription = "";
         A578MemoImage = "";
         n578MemoImage = false;
         A579MemoDocument = "";
         n579MemoDocument = false;
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         n587MemoStartDateTime = false;
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         n588MemoEndDateTime = false;
         A589MemoDuration = 0;
         n589MemoDuration = false;
         A590MemoRemoveDate = DateTime.MinValue;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A592MemoBgColorCode = "";
         A593MemoForm = "";
         A556SG_OrganisationId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
         Z576MemoTitle = "";
         Z577MemoDescription = "";
         Z578MemoImage = "";
         Z579MemoDocument = "";
         Z587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z589MemoDuration = 0;
         Z590MemoRemoveDate = DateTime.MinValue;
         Z592MemoBgColorCode = "";
         Z593MemoForm = "";
         Z568MemoCategoryId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         Z555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1U115( )
      {
         A575MemoId = Guid.NewGuid( );
         InitializeNonKey1U115( ) ;
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

      public void VarsToRow115( SdtTrn_Memo obj115 )
      {
         obj115.gxTpr_Mode = Gx_mode;
         obj115.gxTpr_Memocategoryid = A568MemoCategoryId;
         obj115.gxTpr_Memocategoryname = A569MemoCategoryName;
         obj115.gxTpr_Memotitle = A576MemoTitle;
         obj115.gxTpr_Memodescription = A577MemoDescription;
         obj115.gxTpr_Memoimage = A578MemoImage;
         obj115.gxTpr_Memodocument = A579MemoDocument;
         obj115.gxTpr_Memostartdatetime = A587MemoStartDateTime;
         obj115.gxTpr_Memoenddatetime = A588MemoEndDateTime;
         obj115.gxTpr_Memoduration = A589MemoDuration;
         obj115.gxTpr_Memoremovedate = A590MemoRemoveDate;
         obj115.gxTpr_Residentid = A62ResidentId;
         obj115.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj115.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj115.gxTpr_Residentlastname = A65ResidentLastName;
         obj115.gxTpr_Residentguid = A71ResidentGUID;
         obj115.gxTpr_Memobgcolorcode = A592MemoBgColorCode;
         obj115.gxTpr_Memoform = A593MemoForm;
         obj115.gxTpr_Sg_organisationid = A556SG_OrganisationId;
         obj115.gxTpr_Sg_locationid = A555SG_LocationId;
         obj115.gxTpr_Memoid = A575MemoId;
         obj115.gxTpr_Memoid_Z = Z575MemoId;
         obj115.gxTpr_Memocategoryid_Z = Z568MemoCategoryId;
         obj115.gxTpr_Memocategoryname_Z = Z569MemoCategoryName;
         obj115.gxTpr_Memotitle_Z = Z576MemoTitle;
         obj115.gxTpr_Memodescription_Z = Z577MemoDescription;
         obj115.gxTpr_Memoimage_Z = Z578MemoImage;
         obj115.gxTpr_Memodocument_Z = Z579MemoDocument;
         obj115.gxTpr_Memostartdatetime_Z = Z587MemoStartDateTime;
         obj115.gxTpr_Memoenddatetime_Z = Z588MemoEndDateTime;
         obj115.gxTpr_Memoduration_Z = Z589MemoDuration;
         obj115.gxTpr_Memoremovedate_Z = Z590MemoRemoveDate;
         obj115.gxTpr_Residentid_Z = Z62ResidentId;
         obj115.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj115.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj115.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj115.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj115.gxTpr_Memobgcolorcode_Z = Z592MemoBgColorCode;
         obj115.gxTpr_Memoform_Z = Z593MemoForm;
         obj115.gxTpr_Sg_organisationid_Z = Z556SG_OrganisationId;
         obj115.gxTpr_Sg_locationid_Z = Z555SG_LocationId;
         obj115.gxTpr_Memoimage_N = (short)(Convert.ToInt16(n578MemoImage));
         obj115.gxTpr_Memodocument_N = (short)(Convert.ToInt16(n579MemoDocument));
         obj115.gxTpr_Memostartdatetime_N = (short)(Convert.ToInt16(n587MemoStartDateTime));
         obj115.gxTpr_Memoenddatetime_N = (short)(Convert.ToInt16(n588MemoEndDateTime));
         obj115.gxTpr_Memoduration_N = (short)(Convert.ToInt16(n589MemoDuration));
         obj115.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow115( SdtTrn_Memo obj115 )
      {
         obj115.gxTpr_Memoid = A575MemoId;
         return  ;
      }

      public void RowToVars115( SdtTrn_Memo obj115 ,
                                int forceLoad )
      {
         Gx_mode = obj115.gxTpr_Mode;
         A568MemoCategoryId = obj115.gxTpr_Memocategoryid;
         A569MemoCategoryName = obj115.gxTpr_Memocategoryname;
         A576MemoTitle = obj115.gxTpr_Memotitle;
         A577MemoDescription = obj115.gxTpr_Memodescription;
         A578MemoImage = obj115.gxTpr_Memoimage;
         n578MemoImage = false;
         A579MemoDocument = obj115.gxTpr_Memodocument;
         n579MemoDocument = false;
         A587MemoStartDateTime = obj115.gxTpr_Memostartdatetime;
         n587MemoStartDateTime = false;
         A588MemoEndDateTime = obj115.gxTpr_Memoenddatetime;
         n588MemoEndDateTime = false;
         A589MemoDuration = obj115.gxTpr_Memoduration;
         n589MemoDuration = false;
         A590MemoRemoveDate = obj115.gxTpr_Memoremovedate;
         A62ResidentId = obj115.gxTpr_Residentid;
         A72ResidentSalutation = obj115.gxTpr_Residentsalutation;
         A64ResidentGivenName = obj115.gxTpr_Residentgivenname;
         A65ResidentLastName = obj115.gxTpr_Residentlastname;
         A71ResidentGUID = obj115.gxTpr_Residentguid;
         A592MemoBgColorCode = obj115.gxTpr_Memobgcolorcode;
         A593MemoForm = obj115.gxTpr_Memoform;
         A556SG_OrganisationId = obj115.gxTpr_Sg_organisationid;
         A555SG_LocationId = obj115.gxTpr_Sg_locationid;
         A575MemoId = obj115.gxTpr_Memoid;
         Z575MemoId = obj115.gxTpr_Memoid_Z;
         Z568MemoCategoryId = obj115.gxTpr_Memocategoryid_Z;
         Z569MemoCategoryName = obj115.gxTpr_Memocategoryname_Z;
         Z576MemoTitle = obj115.gxTpr_Memotitle_Z;
         Z577MemoDescription = obj115.gxTpr_Memodescription_Z;
         Z578MemoImage = obj115.gxTpr_Memoimage_Z;
         Z579MemoDocument = obj115.gxTpr_Memodocument_Z;
         Z587MemoStartDateTime = obj115.gxTpr_Memostartdatetime_Z;
         Z588MemoEndDateTime = obj115.gxTpr_Memoenddatetime_Z;
         Z589MemoDuration = obj115.gxTpr_Memoduration_Z;
         Z590MemoRemoveDate = obj115.gxTpr_Memoremovedate_Z;
         Z62ResidentId = obj115.gxTpr_Residentid_Z;
         Z72ResidentSalutation = obj115.gxTpr_Residentsalutation_Z;
         Z64ResidentGivenName = obj115.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj115.gxTpr_Residentlastname_Z;
         Z71ResidentGUID = obj115.gxTpr_Residentguid_Z;
         Z592MemoBgColorCode = obj115.gxTpr_Memobgcolorcode_Z;
         Z593MemoForm = obj115.gxTpr_Memoform_Z;
         Z556SG_OrganisationId = obj115.gxTpr_Sg_organisationid_Z;
         Z555SG_LocationId = obj115.gxTpr_Sg_locationid_Z;
         n578MemoImage = (bool)(Convert.ToBoolean(obj115.gxTpr_Memoimage_N));
         n579MemoDocument = (bool)(Convert.ToBoolean(obj115.gxTpr_Memodocument_N));
         n587MemoStartDateTime = (bool)(Convert.ToBoolean(obj115.gxTpr_Memostartdatetime_N));
         n588MemoEndDateTime = (bool)(Convert.ToBoolean(obj115.gxTpr_Memoenddatetime_N));
         n589MemoDuration = (bool)(Convert.ToBoolean(obj115.gxTpr_Memoduration_N));
         Gx_mode = obj115.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A575MemoId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1U115( ) ;
         ScanKeyStart1U115( ) ;
         if ( RcdFound115 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z575MemoId = A575MemoId;
         }
         ZM1U115( -9) ;
         OnLoadActions1U115( ) ;
         AddRow1U115( ) ;
         ScanKeyEnd1U115( ) ;
         if ( RcdFound115 == 0 )
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
         RowToVars115( bcTrn_Memo, 0) ;
         ScanKeyStart1U115( ) ;
         if ( RcdFound115 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z575MemoId = A575MemoId;
         }
         ZM1U115( -9) ;
         OnLoadActions1U115( ) ;
         AddRow1U115( ) ;
         ScanKeyEnd1U115( ) ;
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1U115( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1U115( ) ;
         }
         else
         {
            if ( RcdFound115 == 1 )
            {
               if ( A575MemoId != Z575MemoId )
               {
                  A575MemoId = Z575MemoId;
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
                  Update1U115( ) ;
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
                  if ( A575MemoId != Z575MemoId )
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
                        Insert1U115( ) ;
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
                        Insert1U115( ) ;
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
         RowToVars115( bcTrn_Memo, 1) ;
         SaveImpl( ) ;
         VarsToRow115( bcTrn_Memo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars115( bcTrn_Memo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U115( ) ;
         AfterTrn( ) ;
         VarsToRow115( bcTrn_Memo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow115( bcTrn_Memo) ;
         }
         else
         {
            SdtTrn_Memo auxBC = new SdtTrn_Memo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A575MemoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Memo);
               auxBC.Save();
               bcTrn_Memo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars115( bcTrn_Memo, 1) ;
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
         RowToVars115( bcTrn_Memo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U115( ) ;
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
               VarsToRow115( bcTrn_Memo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow115( bcTrn_Memo) ;
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
         RowToVars115( bcTrn_Memo, 0) ;
         GetKey1U115( ) ;
         if ( RcdFound115 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A575MemoId != Z575MemoId )
            {
               A575MemoId = Z575MemoId;
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
            if ( A575MemoId != Z575MemoId )
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
         context.RollbackDataStores("trn_memo_bc",pr_default);
         VarsToRow115( bcTrn_Memo) ;
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
         Gx_mode = bcTrn_Memo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Memo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Memo )
         {
            bcTrn_Memo = (SdtTrn_Memo)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Memo.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Memo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow115( bcTrn_Memo) ;
            }
            else
            {
               RowToVars115( bcTrn_Memo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Memo.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Memo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars115( bcTrn_Memo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Memo Trn_Memo_BC
      {
         get {
            return bcTrn_Memo ;
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
            return "trn_memo_Execute" ;
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
         pr_default.close(9);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z575MemoId = Guid.Empty;
         A575MemoId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV31Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV14Insert_MemoCategoryId = Guid.Empty;
         AV26Insert_ResidentId = Guid.Empty;
         AV29Insert_SG_OrganisationId = Guid.Empty;
         AV30Insert_SG_LocationId = Guid.Empty;
         Z576MemoTitle = "";
         A576MemoTitle = "";
         Z577MemoDescription = "";
         A577MemoDescription = "";
         Z578MemoImage = "";
         A578MemoImage = "";
         Z579MemoDocument = "";
         A579MemoDocument = "";
         Z587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z590MemoRemoveDate = DateTime.MinValue;
         A590MemoRemoveDate = DateTime.MinValue;
         Z592MemoBgColorCode = "";
         A592MemoBgColorCode = "";
         Z593MemoForm = "";
         A593MemoForm = "";
         Z568MemoCategoryId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z555SG_LocationId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         Z569MemoCategoryName = "";
         A569MemoCategoryName = "";
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         BC001U6_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001U6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001U6_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001U6_A569MemoCategoryName = new string[] {""} ;
         BC001U6_A576MemoTitle = new string[] {""} ;
         BC001U6_A577MemoDescription = new string[] {""} ;
         BC001U6_A578MemoImage = new string[] {""} ;
         BC001U6_n578MemoImage = new bool[] {false} ;
         BC001U6_A579MemoDocument = new string[] {""} ;
         BC001U6_n579MemoDocument = new bool[] {false} ;
         BC001U6_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U6_n587MemoStartDateTime = new bool[] {false} ;
         BC001U6_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U6_n588MemoEndDateTime = new bool[] {false} ;
         BC001U6_A589MemoDuration = new short[1] ;
         BC001U6_n589MemoDuration = new bool[] {false} ;
         BC001U6_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001U6_A72ResidentSalutation = new string[] {""} ;
         BC001U6_A64ResidentGivenName = new string[] {""} ;
         BC001U6_A65ResidentLastName = new string[] {""} ;
         BC001U6_A71ResidentGUID = new string[] {""} ;
         BC001U6_A592MemoBgColorCode = new string[] {""} ;
         BC001U6_A593MemoForm = new string[] {""} ;
         BC001U6_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001U6_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001U6_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001U6_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001U4_A569MemoCategoryName = new string[] {""} ;
         BC001U5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001U5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001U5_A72ResidentSalutation = new string[] {""} ;
         BC001U5_A64ResidentGivenName = new string[] {""} ;
         BC001U5_A65ResidentLastName = new string[] {""} ;
         BC001U5_A71ResidentGUID = new string[] {""} ;
         BC001U7_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001U3_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001U3_A576MemoTitle = new string[] {""} ;
         BC001U3_A577MemoDescription = new string[] {""} ;
         BC001U3_A578MemoImage = new string[] {""} ;
         BC001U3_n578MemoImage = new bool[] {false} ;
         BC001U3_A579MemoDocument = new string[] {""} ;
         BC001U3_n579MemoDocument = new bool[] {false} ;
         BC001U3_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U3_n587MemoStartDateTime = new bool[] {false} ;
         BC001U3_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U3_n588MemoEndDateTime = new bool[] {false} ;
         BC001U3_A589MemoDuration = new short[1] ;
         BC001U3_n589MemoDuration = new bool[] {false} ;
         BC001U3_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001U3_A592MemoBgColorCode = new string[] {""} ;
         BC001U3_A593MemoForm = new string[] {""} ;
         BC001U3_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001U3_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001U3_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001U3_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         sMode115 = "";
         BC001U2_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001U2_A576MemoTitle = new string[] {""} ;
         BC001U2_A577MemoDescription = new string[] {""} ;
         BC001U2_A578MemoImage = new string[] {""} ;
         BC001U2_n578MemoImage = new bool[] {false} ;
         BC001U2_A579MemoDocument = new string[] {""} ;
         BC001U2_n579MemoDocument = new bool[] {false} ;
         BC001U2_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U2_n587MemoStartDateTime = new bool[] {false} ;
         BC001U2_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U2_n588MemoEndDateTime = new bool[] {false} ;
         BC001U2_A589MemoDuration = new short[1] ;
         BC001U2_n589MemoDuration = new bool[] {false} ;
         BC001U2_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001U2_A592MemoBgColorCode = new string[] {""} ;
         BC001U2_A593MemoForm = new string[] {""} ;
         BC001U2_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001U2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001U2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001U2_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001U11_A569MemoCategoryName = new string[] {""} ;
         BC001U12_A72ResidentSalutation = new string[] {""} ;
         BC001U12_A64ResidentGivenName = new string[] {""} ;
         BC001U12_A65ResidentLastName = new string[] {""} ;
         BC001U12_A71ResidentGUID = new string[] {""} ;
         BC001U13_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001U13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001U13_A575MemoId = new Guid[] {Guid.Empty} ;
         BC001U13_A569MemoCategoryName = new string[] {""} ;
         BC001U13_A576MemoTitle = new string[] {""} ;
         BC001U13_A577MemoDescription = new string[] {""} ;
         BC001U13_A578MemoImage = new string[] {""} ;
         BC001U13_n578MemoImage = new bool[] {false} ;
         BC001U13_A579MemoDocument = new string[] {""} ;
         BC001U13_n579MemoDocument = new bool[] {false} ;
         BC001U13_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U13_n587MemoStartDateTime = new bool[] {false} ;
         BC001U13_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001U13_n588MemoEndDateTime = new bool[] {false} ;
         BC001U13_A589MemoDuration = new short[1] ;
         BC001U13_n589MemoDuration = new bool[] {false} ;
         BC001U13_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001U13_A72ResidentSalutation = new string[] {""} ;
         BC001U13_A64ResidentGivenName = new string[] {""} ;
         BC001U13_A65ResidentLastName = new string[] {""} ;
         BC001U13_A71ResidentGUID = new string[] {""} ;
         BC001U13_A592MemoBgColorCode = new string[] {""} ;
         BC001U13_A593MemoForm = new string[] {""} ;
         BC001U13_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001U13_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001U13_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001U13_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__default(),
            new Object[][] {
                new Object[] {
               BC001U2_A575MemoId, BC001U2_A576MemoTitle, BC001U2_A577MemoDescription, BC001U2_A578MemoImage, BC001U2_n578MemoImage, BC001U2_A579MemoDocument, BC001U2_n579MemoDocument, BC001U2_A587MemoStartDateTime, BC001U2_n587MemoStartDateTime, BC001U2_A588MemoEndDateTime,
               BC001U2_n588MemoEndDateTime, BC001U2_A589MemoDuration, BC001U2_n589MemoDuration, BC001U2_A590MemoRemoveDate, BC001U2_A592MemoBgColorCode, BC001U2_A593MemoForm, BC001U2_A568MemoCategoryId, BC001U2_A62ResidentId, BC001U2_A555SG_LocationId, BC001U2_A556SG_OrganisationId
               }
               , new Object[] {
               BC001U3_A575MemoId, BC001U3_A576MemoTitle, BC001U3_A577MemoDescription, BC001U3_A578MemoImage, BC001U3_n578MemoImage, BC001U3_A579MemoDocument, BC001U3_n579MemoDocument, BC001U3_A587MemoStartDateTime, BC001U3_n587MemoStartDateTime, BC001U3_A588MemoEndDateTime,
               BC001U3_n588MemoEndDateTime, BC001U3_A589MemoDuration, BC001U3_n589MemoDuration, BC001U3_A590MemoRemoveDate, BC001U3_A592MemoBgColorCode, BC001U3_A593MemoForm, BC001U3_A568MemoCategoryId, BC001U3_A62ResidentId, BC001U3_A555SG_LocationId, BC001U3_A556SG_OrganisationId
               }
               , new Object[] {
               BC001U4_A569MemoCategoryName
               }
               , new Object[] {
               BC001U5_A29LocationId, BC001U5_A11OrganisationId, BC001U5_A72ResidentSalutation, BC001U5_A64ResidentGivenName, BC001U5_A65ResidentLastName, BC001U5_A71ResidentGUID
               }
               , new Object[] {
               BC001U6_A29LocationId, BC001U6_A11OrganisationId, BC001U6_A575MemoId, BC001U6_A569MemoCategoryName, BC001U6_A576MemoTitle, BC001U6_A577MemoDescription, BC001U6_A578MemoImage, BC001U6_n578MemoImage, BC001U6_A579MemoDocument, BC001U6_n579MemoDocument,
               BC001U6_A587MemoStartDateTime, BC001U6_n587MemoStartDateTime, BC001U6_A588MemoEndDateTime, BC001U6_n588MemoEndDateTime, BC001U6_A589MemoDuration, BC001U6_n589MemoDuration, BC001U6_A590MemoRemoveDate, BC001U6_A72ResidentSalutation, BC001U6_A64ResidentGivenName, BC001U6_A65ResidentLastName,
               BC001U6_A71ResidentGUID, BC001U6_A592MemoBgColorCode, BC001U6_A593MemoForm, BC001U6_A568MemoCategoryId, BC001U6_A62ResidentId, BC001U6_A555SG_LocationId, BC001U6_A556SG_OrganisationId
               }
               , new Object[] {
               BC001U7_A575MemoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001U11_A569MemoCategoryName
               }
               , new Object[] {
               BC001U12_A72ResidentSalutation, BC001U12_A64ResidentGivenName, BC001U12_A65ResidentLastName, BC001U12_A71ResidentGUID
               }
               , new Object[] {
               BC001U13_A29LocationId, BC001U13_A11OrganisationId, BC001U13_A575MemoId, BC001U13_A569MemoCategoryName, BC001U13_A576MemoTitle, BC001U13_A577MemoDescription, BC001U13_A578MemoImage, BC001U13_n578MemoImage, BC001U13_A579MemoDocument, BC001U13_n579MemoDocument,
               BC001U13_A587MemoStartDateTime, BC001U13_n587MemoStartDateTime, BC001U13_A588MemoEndDateTime, BC001U13_n588MemoEndDateTime, BC001U13_A589MemoDuration, BC001U13_n589MemoDuration, BC001U13_A590MemoRemoveDate, BC001U13_A72ResidentSalutation, BC001U13_A64ResidentGivenName, BC001U13_A65ResidentLastName,
               BC001U13_A71ResidentGUID, BC001U13_A592MemoBgColorCode, BC001U13_A593MemoForm, BC001U13_A568MemoCategoryId, BC001U13_A62ResidentId, BC001U13_A555SG_LocationId, BC001U13_A556SG_OrganisationId
               }
            }
         );
         Z575MemoId = Guid.NewGuid( );
         A575MemoId = Guid.NewGuid( );
         AV31Pgmname = "Trn_Memo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z589MemoDuration ;
      private short A589MemoDuration ;
      private short Gx_BScreen ;
      private short RcdFound115 ;
      private int trnEnded ;
      private int AV32GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV31Pgmname ;
      private string Z593MemoForm ;
      private string A593MemoForm ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string sMode115 ;
      private DateTime Z587MemoStartDateTime ;
      private DateTime A587MemoStartDateTime ;
      private DateTime Z588MemoEndDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime Z590MemoRemoveDate ;
      private DateTime A590MemoRemoveDate ;
      private bool returnInSub ;
      private bool n578MemoImage ;
      private bool n579MemoDocument ;
      private bool n587MemoStartDateTime ;
      private bool n588MemoEndDateTime ;
      private bool n589MemoDuration ;
      private bool Gx_longc ;
      private string Z576MemoTitle ;
      private string A576MemoTitle ;
      private string Z577MemoDescription ;
      private string A577MemoDescription ;
      private string Z578MemoImage ;
      private string A578MemoImage ;
      private string Z579MemoDocument ;
      private string A579MemoDocument ;
      private string Z592MemoBgColorCode ;
      private string A592MemoBgColorCode ;
      private string Z569MemoCategoryName ;
      private string A569MemoCategoryName ;
      private string Z64ResidentGivenName ;
      private string A64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string A65ResidentLastName ;
      private string Z71ResidentGUID ;
      private string A71ResidentGUID ;
      private Guid Z575MemoId ;
      private Guid A575MemoId ;
      private Guid AV14Insert_MemoCategoryId ;
      private Guid AV26Insert_ResidentId ;
      private Guid AV29Insert_SG_OrganisationId ;
      private Guid AV30Insert_SG_LocationId ;
      private Guid Z568MemoCategoryId ;
      private Guid A568MemoCategoryId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z555SG_LocationId ;
      private Guid A555SG_LocationId ;
      private Guid Z556SG_OrganisationId ;
      private Guid A556SG_OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001U6_A29LocationId ;
      private Guid[] BC001U6_A11OrganisationId ;
      private Guid[] BC001U6_A575MemoId ;
      private string[] BC001U6_A569MemoCategoryName ;
      private string[] BC001U6_A576MemoTitle ;
      private string[] BC001U6_A577MemoDescription ;
      private string[] BC001U6_A578MemoImage ;
      private bool[] BC001U6_n578MemoImage ;
      private string[] BC001U6_A579MemoDocument ;
      private bool[] BC001U6_n579MemoDocument ;
      private DateTime[] BC001U6_A587MemoStartDateTime ;
      private bool[] BC001U6_n587MemoStartDateTime ;
      private DateTime[] BC001U6_A588MemoEndDateTime ;
      private bool[] BC001U6_n588MemoEndDateTime ;
      private short[] BC001U6_A589MemoDuration ;
      private bool[] BC001U6_n589MemoDuration ;
      private DateTime[] BC001U6_A590MemoRemoveDate ;
      private string[] BC001U6_A72ResidentSalutation ;
      private string[] BC001U6_A64ResidentGivenName ;
      private string[] BC001U6_A65ResidentLastName ;
      private string[] BC001U6_A71ResidentGUID ;
      private string[] BC001U6_A592MemoBgColorCode ;
      private string[] BC001U6_A593MemoForm ;
      private Guid[] BC001U6_A568MemoCategoryId ;
      private Guid[] BC001U6_A62ResidentId ;
      private Guid[] BC001U6_A555SG_LocationId ;
      private Guid[] BC001U6_A556SG_OrganisationId ;
      private string[] BC001U4_A569MemoCategoryName ;
      private Guid[] BC001U5_A29LocationId ;
      private Guid[] BC001U5_A11OrganisationId ;
      private string[] BC001U5_A72ResidentSalutation ;
      private string[] BC001U5_A64ResidentGivenName ;
      private string[] BC001U5_A65ResidentLastName ;
      private string[] BC001U5_A71ResidentGUID ;
      private Guid[] BC001U7_A575MemoId ;
      private Guid[] BC001U3_A575MemoId ;
      private string[] BC001U3_A576MemoTitle ;
      private string[] BC001U3_A577MemoDescription ;
      private string[] BC001U3_A578MemoImage ;
      private bool[] BC001U3_n578MemoImage ;
      private string[] BC001U3_A579MemoDocument ;
      private bool[] BC001U3_n579MemoDocument ;
      private DateTime[] BC001U3_A587MemoStartDateTime ;
      private bool[] BC001U3_n587MemoStartDateTime ;
      private DateTime[] BC001U3_A588MemoEndDateTime ;
      private bool[] BC001U3_n588MemoEndDateTime ;
      private short[] BC001U3_A589MemoDuration ;
      private bool[] BC001U3_n589MemoDuration ;
      private DateTime[] BC001U3_A590MemoRemoveDate ;
      private string[] BC001U3_A592MemoBgColorCode ;
      private string[] BC001U3_A593MemoForm ;
      private Guid[] BC001U3_A568MemoCategoryId ;
      private Guid[] BC001U3_A62ResidentId ;
      private Guid[] BC001U3_A555SG_LocationId ;
      private Guid[] BC001U3_A556SG_OrganisationId ;
      private Guid[] BC001U2_A575MemoId ;
      private string[] BC001U2_A576MemoTitle ;
      private string[] BC001U2_A577MemoDescription ;
      private string[] BC001U2_A578MemoImage ;
      private bool[] BC001U2_n578MemoImage ;
      private string[] BC001U2_A579MemoDocument ;
      private bool[] BC001U2_n579MemoDocument ;
      private DateTime[] BC001U2_A587MemoStartDateTime ;
      private bool[] BC001U2_n587MemoStartDateTime ;
      private DateTime[] BC001U2_A588MemoEndDateTime ;
      private bool[] BC001U2_n588MemoEndDateTime ;
      private short[] BC001U2_A589MemoDuration ;
      private bool[] BC001U2_n589MemoDuration ;
      private DateTime[] BC001U2_A590MemoRemoveDate ;
      private string[] BC001U2_A592MemoBgColorCode ;
      private string[] BC001U2_A593MemoForm ;
      private Guid[] BC001U2_A568MemoCategoryId ;
      private Guid[] BC001U2_A62ResidentId ;
      private Guid[] BC001U2_A555SG_LocationId ;
      private Guid[] BC001U2_A556SG_OrganisationId ;
      private string[] BC001U11_A569MemoCategoryName ;
      private string[] BC001U12_A72ResidentSalutation ;
      private string[] BC001U12_A64ResidentGivenName ;
      private string[] BC001U12_A65ResidentLastName ;
      private string[] BC001U12_A71ResidentGUID ;
      private Guid[] BC001U13_A29LocationId ;
      private Guid[] BC001U13_A11OrganisationId ;
      private Guid[] BC001U13_A575MemoId ;
      private string[] BC001U13_A569MemoCategoryName ;
      private string[] BC001U13_A576MemoTitle ;
      private string[] BC001U13_A577MemoDescription ;
      private string[] BC001U13_A578MemoImage ;
      private bool[] BC001U13_n578MemoImage ;
      private string[] BC001U13_A579MemoDocument ;
      private bool[] BC001U13_n579MemoDocument ;
      private DateTime[] BC001U13_A587MemoStartDateTime ;
      private bool[] BC001U13_n587MemoStartDateTime ;
      private DateTime[] BC001U13_A588MemoEndDateTime ;
      private bool[] BC001U13_n588MemoEndDateTime ;
      private short[] BC001U13_A589MemoDuration ;
      private bool[] BC001U13_n589MemoDuration ;
      private DateTime[] BC001U13_A590MemoRemoveDate ;
      private string[] BC001U13_A72ResidentSalutation ;
      private string[] BC001U13_A64ResidentGivenName ;
      private string[] BC001U13_A65ResidentLastName ;
      private string[] BC001U13_A71ResidentGUID ;
      private string[] BC001U13_A592MemoBgColorCode ;
      private string[] BC001U13_A593MemoForm ;
      private Guid[] BC001U13_A568MemoCategoryId ;
      private Guid[] BC001U13_A62ResidentId ;
      private Guid[] BC001U13_A555SG_LocationId ;
      private Guid[] BC001U13_A556SG_OrganisationId ;
      private SdtTrn_Memo bcTrn_Memo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memo_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_memo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_memo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001U2;
       prmBC001U2 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U3;
       prmBC001U3 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U4;
       prmBC001U4 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U5;
       prmBC001U5 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U6;
       prmBC001U6 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U7;
       prmBC001U7 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U8;
       prmBC001U8 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0) ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U9;
       prmBC001U9 = new Object[] {
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0) ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U10;
       prmBC001U10 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U11;
       prmBC001U11 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U12;
       prmBC001U12 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U13;
       prmBC001U13 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001U2", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId  FOR UPDATE OF Trn_Memo",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U3", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U4", "SELECT MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U5", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U6", "SELECT T3.LocationId, T3.OrganisationId, TM1.MemoId, T2.MemoCategoryName, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T3.ResidentSalutation, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoCategoryId, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM ((Trn_Memo TM1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = TM1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = TM1.SG_LocationId AND T3.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U7", "SELECT MemoId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U8", "SAVEPOINT gxupdate;INSERT INTO Trn_Memo(MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId) VALUES(:MemoId, :MemoTitle, :MemoDescription, :MemoImage, :MemoDocument, :MemoStartDateTime, :MemoEndDateTime, :MemoDuration, :MemoRemoveDate, :MemoBgColorCode, :MemoForm, :MemoCategoryId, :ResidentId, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001U8)
          ,new CursorDef("BC001U9", "SAVEPOINT gxupdate;UPDATE Trn_Memo SET MemoTitle=:MemoTitle, MemoDescription=:MemoDescription, MemoImage=:MemoImage, MemoDocument=:MemoDocument, MemoStartDateTime=:MemoStartDateTime, MemoEndDateTime=:MemoEndDateTime, MemoDuration=:MemoDuration, MemoRemoveDate=:MemoRemoveDate, MemoBgColorCode=:MemoBgColorCode, MemoForm=:MemoForm, MemoCategoryId=:MemoCategoryId, ResidentId=:ResidentId, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U9)
          ,new CursorDef("BC001U10", "SAVEPOINT gxupdate;DELETE FROM Trn_Memo  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U10)
          ,new CursorDef("BC001U11", "SELECT MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U12", "SELECT ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U13", "SELECT T3.LocationId, T3.OrganisationId, TM1.MemoId, T2.MemoCategoryName, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T3.ResidentSalutation, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoCategoryId, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM ((Trn_Memo TM1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = TM1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = TM1.SG_LocationId AND T3.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U13,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((short[]) buf[11])[0] = rslt.getShort(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((string[]) buf[14])[0] = rslt.getVarchar(10);
             ((string[]) buf[15])[0] = rslt.getString(11, 20);
             ((Guid[]) buf[16])[0] = rslt.getGuid(12);
             ((Guid[]) buf[17])[0] = rslt.getGuid(13);
             ((Guid[]) buf[18])[0] = rslt.getGuid(14);
             ((Guid[]) buf[19])[0] = rslt.getGuid(15);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((short[]) buf[11])[0] = rslt.getShort(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((string[]) buf[14])[0] = rslt.getVarchar(10);
             ((string[]) buf[15])[0] = rslt.getString(11, 20);
             ((Guid[]) buf[16])[0] = rslt.getGuid(12);
             ((Guid[]) buf[17])[0] = rslt.getGuid(13);
             ((Guid[]) buf[18])[0] = rslt.getGuid(14);
             ((Guid[]) buf[19])[0] = rslt.getGuid(15);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[13])[0] = rslt.wasNull(10);
             ((short[]) buf[14])[0] = rslt.getShort(11);
             ((bool[]) buf[15])[0] = rslt.wasNull(11);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(12);
             ((string[]) buf[17])[0] = rslt.getString(13, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(14);
             ((string[]) buf[19])[0] = rslt.getVarchar(15);
             ((string[]) buf[20])[0] = rslt.getVarchar(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getString(18, 20);
             ((Guid[]) buf[23])[0] = rslt.getGuid(19);
             ((Guid[]) buf[24])[0] = rslt.getGuid(20);
             ((Guid[]) buf[25])[0] = rslt.getGuid(21);
             ((Guid[]) buf[26])[0] = rslt.getGuid(22);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[13])[0] = rslt.wasNull(10);
             ((short[]) buf[14])[0] = rslt.getShort(11);
             ((bool[]) buf[15])[0] = rslt.wasNull(11);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(12);
             ((string[]) buf[17])[0] = rslt.getString(13, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(14);
             ((string[]) buf[19])[0] = rslt.getVarchar(15);
             ((string[]) buf[20])[0] = rslt.getVarchar(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getString(18, 20);
             ((Guid[]) buf[23])[0] = rslt.getGuid(19);
             ((Guid[]) buf[24])[0] = rslt.getGuid(20);
             ((Guid[]) buf[25])[0] = rslt.getGuid(21);
             ((Guid[]) buf[26])[0] = rslt.getGuid(22);
             return;
    }
 }

}

}
