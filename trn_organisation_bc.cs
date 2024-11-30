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
   public class trn_organisation_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisation_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisation_bc( IGxContext context )
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
         ReadRow013( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey013( ) ;
         standaloneModal( ) ;
         AddRow013( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
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

      protected void CONFIRM_010( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls013( ) ;
            }
            else
            {
               CheckExtendedTable013( ) ;
               if ( AnyError == 0 )
               {
                  ZM013( 14) ;
               }
               CloseExtendedTableCursors013( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationTypeId") == 0 )
               {
                  AV13Insert_OrganisationTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM013( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z17OrganisationPhone = A17OrganisationPhone;
            Z13OrganisationName = A13OrganisationName;
            Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
            Z16OrganisationEmail = A16OrganisationEmail;
            Z389OrganisationPhoneCode = A389OrganisationPhoneCode;
            Z390OrganisationPhoneNumber = A390OrganisationPhoneNumber;
            Z18OrganisationVATNumber = A18OrganisationVATNumber;
            Z331OrganisationAddressCountry = A331OrganisationAddressCountry;
            Z289OrganisationAddressCity = A289OrganisationAddressCity;
            Z288OrganisationAddressZipCode = A288OrganisationAddressZipCode;
            Z342OrganisationAddressLine1 = A342OrganisationAddressLine1;
            Z343OrganisationAddressLine2 = A343OrganisationAddressLine2;
            Z19OrganisationTypeId = A19OrganisationTypeId;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
         if ( GX_JID == -13 )
         {
            Z11OrganisationId = A11OrganisationId;
            Z17OrganisationPhone = A17OrganisationPhone;
            Z13OrganisationName = A13OrganisationName;
            Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
            Z16OrganisationEmail = A16OrganisationEmail;
            Z389OrganisationPhoneCode = A389OrganisationPhoneCode;
            Z390OrganisationPhoneNumber = A390OrganisationPhoneNumber;
            Z18OrganisationVATNumber = A18OrganisationVATNumber;
            Z331OrganisationAddressCountry = A331OrganisationAddressCountry;
            Z289OrganisationAddressCity = A289OrganisationAddressCity;
            Z288OrganisationAddressZipCode = A288OrganisationAddressZipCode;
            Z342OrganisationAddressLine1 = A342OrganisationAddressLine1;
            Z343OrganisationAddressLine2 = A343OrganisationAddressLine2;
            Z19OrganisationTypeId = A19OrganisationTypeId;
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31VatPattern = context.GetMessage( context.GetMessage( "[A-Za-z]{2}\\d{9}[A-Za-z]\\d{2}", ""), "");
         AV32Pgmname = "Trn_Organisation_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load013( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A17OrganisationPhone = BC00015_A17OrganisationPhone[0];
            A13OrganisationName = BC00015_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC00015_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC00015_A16OrganisationEmail[0];
            A389OrganisationPhoneCode = BC00015_A389OrganisationPhoneCode[0];
            A390OrganisationPhoneNumber = BC00015_A390OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC00015_A18OrganisationVATNumber[0];
            A331OrganisationAddressCountry = BC00015_A331OrganisationAddressCountry[0];
            A289OrganisationAddressCity = BC00015_A289OrganisationAddressCity[0];
            A288OrganisationAddressZipCode = BC00015_A288OrganisationAddressZipCode[0];
            A342OrganisationAddressLine1 = BC00015_A342OrganisationAddressLine1[0];
            A343OrganisationAddressLine2 = BC00015_A343OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC00015_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC00015_A19OrganisationTypeId[0];
            ZM013( -13) ;
         }
         pr_default.close(3);
         OnLoadActions013( ) ;
      }

      protected void OnLoadActions013( )
      {
         GXt_char1 = A17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  A389OrganisationPhoneCode,  A390OrganisationPhoneNumber, out  GXt_char1) ;
         A17OrganisationPhone = GXt_char1;
      }

      protected void CheckExtendedTable013( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A12OrganisationKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Organisation Kvk Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A12OrganisationKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KVK number must contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A16OrganisationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Organisation Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         GXt_char1 = A17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  A389OrganisationPhoneCode,  A390OrganisationPhoneNumber, out  GXt_char1) ;
         A17OrganisationPhone = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A390OrganisationPhoneNumber)) && ! GxRegex.IsMatch(A390OrganisationPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A18OrganisationVATNumber) != 14 )
         {
            GX_msglist.addItem(context.GetMessage( "VAT number must contain 14 characters", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONTYPEID");
            AnyError = 1;
         }
         A20OrganisationTypeName = BC00014_A20OrganisationTypeName[0];
         pr_default.close(2);
         if ( GxRegex.IsMatch(A18OrganisationVATNumber,AV31VatPattern) != true )
         {
            GX_msglist.addItem(context.GetMessage( "VAT number is incorrect", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors013( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey013( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM013( 13) ;
            RcdFound3 = 1;
            A11OrganisationId = BC00013_A11OrganisationId[0];
            n11OrganisationId = BC00013_n11OrganisationId[0];
            A17OrganisationPhone = BC00013_A17OrganisationPhone[0];
            A13OrganisationName = BC00013_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC00013_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC00013_A16OrganisationEmail[0];
            A389OrganisationPhoneCode = BC00013_A389OrganisationPhoneCode[0];
            A390OrganisationPhoneNumber = BC00013_A390OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC00013_A18OrganisationVATNumber[0];
            A331OrganisationAddressCountry = BC00013_A331OrganisationAddressCountry[0];
            A289OrganisationAddressCity = BC00013_A289OrganisationAddressCity[0];
            A288OrganisationAddressZipCode = BC00013_A288OrganisationAddressZipCode[0];
            A342OrganisationAddressLine1 = BC00013_A342OrganisationAddressLine1[0];
            A343OrganisationAddressLine2 = BC00013_A343OrganisationAddressLine2[0];
            A19OrganisationTypeId = BC00013_A19OrganisationTypeId[0];
            Z11OrganisationId = A11OrganisationId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load013( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey013( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey013( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey013( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency013( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z17OrganisationPhone, BC00012_A17OrganisationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z13OrganisationName, BC00012_A13OrganisationName[0]) != 0 ) || ( StringUtil.StrCmp(Z12OrganisationKvkNumber, BC00012_A12OrganisationKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z16OrganisationEmail, BC00012_A16OrganisationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z389OrganisationPhoneCode, BC00012_A389OrganisationPhoneCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z390OrganisationPhoneNumber, BC00012_A390OrganisationPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z18OrganisationVATNumber, BC00012_A18OrganisationVATNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z331OrganisationAddressCountry, BC00012_A331OrganisationAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z289OrganisationAddressCity, BC00012_A289OrganisationAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z288OrganisationAddressZipCode, BC00012_A288OrganisationAddressZipCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z342OrganisationAddressLine1, BC00012_A342OrganisationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z343OrganisationAddressLine2, BC00012_A343OrganisationAddressLine2[0]) != 0 ) || ( Z19OrganisationTypeId != BC00012_A19OrganisationTypeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Organisation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM013( 0) ;
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {n11OrganisationId, A11OrganisationId, A17OrganisationPhone, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A389OrganisationPhoneCode, A390OrganisationPhoneNumber, A18OrganisationVATNumber, A331OrganisationAddressCountry, A289OrganisationAddressCity, A288OrganisationAddressZipCode, A342OrganisationAddressLine1, A343OrganisationAddressLine2, A19OrganisationTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
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
               Load013( ) ;
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void Update013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A17OrganisationPhone, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A389OrganisationPhoneCode, A390OrganisationPhoneNumber, A18OrganisationVATNumber, A331OrganisationAddressCountry, A289OrganisationAddressCity, A288OrganisationAddressZipCode, A342OrganisationAddressLine1, A343OrganisationAddressLine2, A19OrganisationTypeId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate013( ) ;
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
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void DeferredUpdate013( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls013( ) ;
            AfterConfirm013( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete013( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00019 */
                  pr_default.execute(7, new Object[] {n11OrganisationId, A11OrganisationId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel013( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls013( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {A19OrganisationTypeId});
            A20OrganisationTypeName = BC000110_A20OrganisationTypeName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Organisation Setting", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierGen", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000114 */
            pr_default.execute(12, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Location", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000115 */
            pr_default.execute(13, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Manager", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel013( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete013( ) ;
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

      public void ScanKeyStart013( )
      {
         /* Scan By routine */
         /* Using cursor BC000116 */
         pr_default.execute(14, new Object[] {n11OrganisationId, A11OrganisationId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = BC000116_A11OrganisationId[0];
            n11OrganisationId = BC000116_n11OrganisationId[0];
            A17OrganisationPhone = BC000116_A17OrganisationPhone[0];
            A13OrganisationName = BC000116_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC000116_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC000116_A16OrganisationEmail[0];
            A389OrganisationPhoneCode = BC000116_A389OrganisationPhoneCode[0];
            A390OrganisationPhoneNumber = BC000116_A390OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC000116_A18OrganisationVATNumber[0];
            A331OrganisationAddressCountry = BC000116_A331OrganisationAddressCountry[0];
            A289OrganisationAddressCity = BC000116_A289OrganisationAddressCity[0];
            A288OrganisationAddressZipCode = BC000116_A288OrganisationAddressZipCode[0];
            A342OrganisationAddressLine1 = BC000116_A342OrganisationAddressLine1[0];
            A343OrganisationAddressLine2 = BC000116_A343OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC000116_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC000116_A19OrganisationTypeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext013( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound3 = 0;
         ScanKeyLoad013( ) ;
      }

      protected void ScanKeyLoad013( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = BC000116_A11OrganisationId[0];
            n11OrganisationId = BC000116_n11OrganisationId[0];
            A17OrganisationPhone = BC000116_A17OrganisationPhone[0];
            A13OrganisationName = BC000116_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC000116_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC000116_A16OrganisationEmail[0];
            A389OrganisationPhoneCode = BC000116_A389OrganisationPhoneCode[0];
            A390OrganisationPhoneNumber = BC000116_A390OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC000116_A18OrganisationVATNumber[0];
            A331OrganisationAddressCountry = BC000116_A331OrganisationAddressCountry[0];
            A289OrganisationAddressCity = BC000116_A289OrganisationAddressCity[0];
            A288OrganisationAddressZipCode = BC000116_A288OrganisationAddressZipCode[0];
            A342OrganisationAddressLine1 = BC000116_A342OrganisationAddressLine1[0];
            A343OrganisationAddressLine2 = BC000116_A343OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC000116_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC000116_A19OrganisationTypeId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd013( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm013( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert013( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate013( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete013( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete013( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate013( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes013( )
      {
      }

      protected void send_integrity_lvl_hashes013( )
      {
      }

      protected void AddRow013( )
      {
         VarsToRow3( bcTrn_Organisation) ;
      }

      protected void ReadRow013( )
      {
         RowToVars3( bcTrn_Organisation, 1) ;
      }

      protected void InitializeNonKey013( )
      {
         A17OrganisationPhone = "";
         A13OrganisationName = "";
         A12OrganisationKvkNumber = "";
         A16OrganisationEmail = "";
         A389OrganisationPhoneCode = "";
         A390OrganisationPhoneNumber = "";
         A18OrganisationVATNumber = "";
         A331OrganisationAddressCountry = "";
         A289OrganisationAddressCity = "";
         A288OrganisationAddressZipCode = "";
         A342OrganisationAddressLine1 = "";
         A343OrganisationAddressLine2 = "";
         A19OrganisationTypeId = Guid.Empty;
         A20OrganisationTypeName = "";
         Z17OrganisationPhone = "";
         Z13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         Z389OrganisationPhoneCode = "";
         Z390OrganisationPhoneNumber = "";
         Z18OrganisationVATNumber = "";
         Z331OrganisationAddressCountry = "";
         Z289OrganisationAddressCity = "";
         Z288OrganisationAddressZipCode = "";
         Z342OrganisationAddressLine1 = "";
         Z343OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
      }

      protected void InitAll013( )
      {
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         InitializeNonKey013( ) ;
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

      public void VarsToRow3( SdtTrn_Organisation obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Organisationphone = A17OrganisationPhone;
         obj3.gxTpr_Organisationname = A13OrganisationName;
         obj3.gxTpr_Organisationkvknumber = A12OrganisationKvkNumber;
         obj3.gxTpr_Organisationemail = A16OrganisationEmail;
         obj3.gxTpr_Organisationphonecode = A389OrganisationPhoneCode;
         obj3.gxTpr_Organisationphonenumber = A390OrganisationPhoneNumber;
         obj3.gxTpr_Organisationvatnumber = A18OrganisationVATNumber;
         obj3.gxTpr_Organisationaddresscountry = A331OrganisationAddressCountry;
         obj3.gxTpr_Organisationaddresscity = A289OrganisationAddressCity;
         obj3.gxTpr_Organisationaddresszipcode = A288OrganisationAddressZipCode;
         obj3.gxTpr_Organisationaddressline1 = A342OrganisationAddressLine1;
         obj3.gxTpr_Organisationaddressline2 = A343OrganisationAddressLine2;
         obj3.gxTpr_Organisationtypeid = A19OrganisationTypeId;
         obj3.gxTpr_Organisationtypename = A20OrganisationTypeName;
         obj3.gxTpr_Organisationid = A11OrganisationId;
         obj3.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj3.gxTpr_Organisationname_Z = Z13OrganisationName;
         obj3.gxTpr_Organisationkvknumber_Z = Z12OrganisationKvkNumber;
         obj3.gxTpr_Organisationemail_Z = Z16OrganisationEmail;
         obj3.gxTpr_Organisationphone_Z = Z17OrganisationPhone;
         obj3.gxTpr_Organisationphonecode_Z = Z389OrganisationPhoneCode;
         obj3.gxTpr_Organisationphonenumber_Z = Z390OrganisationPhoneNumber;
         obj3.gxTpr_Organisationvatnumber_Z = Z18OrganisationVATNumber;
         obj3.gxTpr_Organisationaddresscountry_Z = Z331OrganisationAddressCountry;
         obj3.gxTpr_Organisationaddresscity_Z = Z289OrganisationAddressCity;
         obj3.gxTpr_Organisationaddresszipcode_Z = Z288OrganisationAddressZipCode;
         obj3.gxTpr_Organisationaddressline1_Z = Z342OrganisationAddressLine1;
         obj3.gxTpr_Organisationaddressline2_Z = Z343OrganisationAddressLine2;
         obj3.gxTpr_Organisationtypeid_Z = Z19OrganisationTypeId;
         obj3.gxTpr_Organisationtypename_Z = Z20OrganisationTypeName;
         obj3.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtTrn_Organisation obj3 )
      {
         obj3.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars3( SdtTrn_Organisation obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A17OrganisationPhone = obj3.gxTpr_Organisationphone;
         A13OrganisationName = obj3.gxTpr_Organisationname;
         A12OrganisationKvkNumber = obj3.gxTpr_Organisationkvknumber;
         A16OrganisationEmail = obj3.gxTpr_Organisationemail;
         A389OrganisationPhoneCode = obj3.gxTpr_Organisationphonecode;
         A390OrganisationPhoneNumber = obj3.gxTpr_Organisationphonenumber;
         A18OrganisationVATNumber = obj3.gxTpr_Organisationvatnumber;
         A331OrganisationAddressCountry = obj3.gxTpr_Organisationaddresscountry;
         A289OrganisationAddressCity = obj3.gxTpr_Organisationaddresscity;
         A288OrganisationAddressZipCode = obj3.gxTpr_Organisationaddresszipcode;
         A342OrganisationAddressLine1 = obj3.gxTpr_Organisationaddressline1;
         A343OrganisationAddressLine2 = obj3.gxTpr_Organisationaddressline2;
         A19OrganisationTypeId = obj3.gxTpr_Organisationtypeid;
         A20OrganisationTypeName = obj3.gxTpr_Organisationtypename;
         A11OrganisationId = obj3.gxTpr_Organisationid;
         n11OrganisationId = false;
         Z11OrganisationId = obj3.gxTpr_Organisationid_Z;
         Z13OrganisationName = obj3.gxTpr_Organisationname_Z;
         Z12OrganisationKvkNumber = obj3.gxTpr_Organisationkvknumber_Z;
         Z16OrganisationEmail = obj3.gxTpr_Organisationemail_Z;
         Z17OrganisationPhone = obj3.gxTpr_Organisationphone_Z;
         Z389OrganisationPhoneCode = obj3.gxTpr_Organisationphonecode_Z;
         Z390OrganisationPhoneNumber = obj3.gxTpr_Organisationphonenumber_Z;
         Z18OrganisationVATNumber = obj3.gxTpr_Organisationvatnumber_Z;
         Z331OrganisationAddressCountry = obj3.gxTpr_Organisationaddresscountry_Z;
         Z289OrganisationAddressCity = obj3.gxTpr_Organisationaddresscity_Z;
         Z288OrganisationAddressZipCode = obj3.gxTpr_Organisationaddresszipcode_Z;
         Z342OrganisationAddressLine1 = obj3.gxTpr_Organisationaddressline1_Z;
         Z343OrganisationAddressLine2 = obj3.gxTpr_Organisationaddressline2_Z;
         Z19OrganisationTypeId = obj3.gxTpr_Organisationtypeid_Z;
         Z20OrganisationTypeName = obj3.gxTpr_Organisationtypename_Z;
         n11OrganisationId = (bool)(Convert.ToBoolean(obj3.gxTpr_Organisationid_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11OrganisationId = (Guid)getParm(obj,0);
         n11OrganisationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey013( ) ;
         ScanKeyStart013( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11OrganisationId = A11OrganisationId;
         }
         ZM013( -13) ;
         OnLoadActions013( ) ;
         AddRow013( ) ;
         ScanKeyEnd013( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcTrn_Organisation, 0) ;
         ScanKeyStart013( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11OrganisationId = A11OrganisationId;
         }
         ZM013( -13) ;
         OnLoadActions013( ) ;
         AddRow013( ) ;
         ScanKeyEnd013( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey013( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert013( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A11OrganisationId != Z11OrganisationId )
               {
                  A11OrganisationId = Z11OrganisationId;
                  n11OrganisationId = false;
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
                  Update013( ) ;
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
                  if ( A11OrganisationId != Z11OrganisationId )
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
                        Insert013( ) ;
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
                        Insert013( ) ;
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
         RowToVars3( bcTrn_Organisation, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcTrn_Organisation) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcTrn_Organisation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert013( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcTrn_Organisation) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bcTrn_Organisation) ;
         }
         else
         {
            SdtTrn_Organisation auxBC = new SdtTrn_Organisation(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Organisation);
               auxBC.Save();
               bcTrn_Organisation.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars3( bcTrn_Organisation, 1) ;
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
         RowToVars3( bcTrn_Organisation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert013( ) ;
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
               VarsToRow3( bcTrn_Organisation) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bcTrn_Organisation) ;
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
         RowToVars3( bcTrn_Organisation, 0) ;
         GetKey013( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11OrganisationId != Z11OrganisationId )
            {
               A11OrganisationId = Z11OrganisationId;
               n11OrganisationId = false;
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
            if ( A11OrganisationId != Z11OrganisationId )
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
         context.RollbackDataStores("trn_organisation_bc",pr_default);
         VarsToRow3( bcTrn_Organisation) ;
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
         Gx_mode = bcTrn_Organisation.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Organisation.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Organisation )
         {
            bcTrn_Organisation = (SdtTrn_Organisation)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Organisation.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Organisation.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcTrn_Organisation) ;
            }
            else
            {
               RowToVars3( bcTrn_Organisation, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Organisation.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Organisation.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcTrn_Organisation, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Organisation Trn_Organisation_BC
      {
         get {
            return bcTrn_Organisation ;
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
            return "trn_organisation_Execute" ;
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
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV32Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationTypeId = Guid.Empty;
         Z17OrganisationPhone = "";
         A17OrganisationPhone = "";
         Z13OrganisationName = "";
         A13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         A12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         A16OrganisationEmail = "";
         Z389OrganisationPhoneCode = "";
         A389OrganisationPhoneCode = "";
         Z390OrganisationPhoneNumber = "";
         A390OrganisationPhoneNumber = "";
         Z18OrganisationVATNumber = "";
         A18OrganisationVATNumber = "";
         Z331OrganisationAddressCountry = "";
         A331OrganisationAddressCountry = "";
         Z289OrganisationAddressCity = "";
         A289OrganisationAddressCity = "";
         Z288OrganisationAddressZipCode = "";
         A288OrganisationAddressZipCode = "";
         Z342OrganisationAddressLine1 = "";
         A342OrganisationAddressLine1 = "";
         Z343OrganisationAddressLine2 = "";
         A343OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
         A19OrganisationTypeId = Guid.Empty;
         Z20OrganisationTypeName = "";
         A20OrganisationTypeName = "";
         AV31VatPattern = "";
         BC00015_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00015_n11OrganisationId = new bool[] {false} ;
         BC00015_A17OrganisationPhone = new string[] {""} ;
         BC00015_A13OrganisationName = new string[] {""} ;
         BC00015_A12OrganisationKvkNumber = new string[] {""} ;
         BC00015_A16OrganisationEmail = new string[] {""} ;
         BC00015_A389OrganisationPhoneCode = new string[] {""} ;
         BC00015_A390OrganisationPhoneNumber = new string[] {""} ;
         BC00015_A18OrganisationVATNumber = new string[] {""} ;
         BC00015_A331OrganisationAddressCountry = new string[] {""} ;
         BC00015_A289OrganisationAddressCity = new string[] {""} ;
         BC00015_A288OrganisationAddressZipCode = new string[] {""} ;
         BC00015_A342OrganisationAddressLine1 = new string[] {""} ;
         BC00015_A343OrganisationAddressLine2 = new string[] {""} ;
         BC00015_A20OrganisationTypeName = new string[] {""} ;
         BC00015_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         GXt_char1 = "";
         BC00014_A20OrganisationTypeName = new string[] {""} ;
         BC00016_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00016_n11OrganisationId = new bool[] {false} ;
         BC00013_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00013_n11OrganisationId = new bool[] {false} ;
         BC00013_A17OrganisationPhone = new string[] {""} ;
         BC00013_A13OrganisationName = new string[] {""} ;
         BC00013_A12OrganisationKvkNumber = new string[] {""} ;
         BC00013_A16OrganisationEmail = new string[] {""} ;
         BC00013_A389OrganisationPhoneCode = new string[] {""} ;
         BC00013_A390OrganisationPhoneNumber = new string[] {""} ;
         BC00013_A18OrganisationVATNumber = new string[] {""} ;
         BC00013_A331OrganisationAddressCountry = new string[] {""} ;
         BC00013_A289OrganisationAddressCity = new string[] {""} ;
         BC00013_A288OrganisationAddressZipCode = new string[] {""} ;
         BC00013_A342OrganisationAddressLine1 = new string[] {""} ;
         BC00013_A343OrganisationAddressLine2 = new string[] {""} ;
         BC00013_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         sMode3 = "";
         BC00012_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00012_n11OrganisationId = new bool[] {false} ;
         BC00012_A17OrganisationPhone = new string[] {""} ;
         BC00012_A13OrganisationName = new string[] {""} ;
         BC00012_A12OrganisationKvkNumber = new string[] {""} ;
         BC00012_A16OrganisationEmail = new string[] {""} ;
         BC00012_A389OrganisationPhoneCode = new string[] {""} ;
         BC00012_A390OrganisationPhoneNumber = new string[] {""} ;
         BC00012_A18OrganisationVATNumber = new string[] {""} ;
         BC00012_A331OrganisationAddressCountry = new string[] {""} ;
         BC00012_A289OrganisationAddressCity = new string[] {""} ;
         BC00012_A288OrganisationAddressZipCode = new string[] {""} ;
         BC00012_A342OrganisationAddressLine1 = new string[] {""} ;
         BC00012_A343OrganisationAddressLine2 = new string[] {""} ;
         BC00012_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC000110_A20OrganisationTypeName = new string[] {""} ;
         BC000111_A415AuditId = new Guid[] {Guid.Empty} ;
         BC000112_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000113_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000114_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000114_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000114_n11OrganisationId = new bool[] {false} ;
         BC000115_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC000115_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000115_n11OrganisationId = new bool[] {false} ;
         BC000116_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000116_n11OrganisationId = new bool[] {false} ;
         BC000116_A17OrganisationPhone = new string[] {""} ;
         BC000116_A13OrganisationName = new string[] {""} ;
         BC000116_A12OrganisationKvkNumber = new string[] {""} ;
         BC000116_A16OrganisationEmail = new string[] {""} ;
         BC000116_A389OrganisationPhoneCode = new string[] {""} ;
         BC000116_A390OrganisationPhoneNumber = new string[] {""} ;
         BC000116_A18OrganisationVATNumber = new string[] {""} ;
         BC000116_A331OrganisationAddressCountry = new string[] {""} ;
         BC000116_A289OrganisationAddressCity = new string[] {""} ;
         BC000116_A288OrganisationAddressZipCode = new string[] {""} ;
         BC000116_A342OrganisationAddressLine1 = new string[] {""} ;
         BC000116_A343OrganisationAddressLine2 = new string[] {""} ;
         BC000116_A20OrganisationTypeName = new string[] {""} ;
         BC000116_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A11OrganisationId, BC00012_A17OrganisationPhone, BC00012_A13OrganisationName, BC00012_A12OrganisationKvkNumber, BC00012_A16OrganisationEmail, BC00012_A389OrganisationPhoneCode, BC00012_A390OrganisationPhoneNumber, BC00012_A18OrganisationVATNumber, BC00012_A331OrganisationAddressCountry, BC00012_A289OrganisationAddressCity,
               BC00012_A288OrganisationAddressZipCode, BC00012_A342OrganisationAddressLine1, BC00012_A343OrganisationAddressLine2, BC00012_A19OrganisationTypeId
               }
               , new Object[] {
               BC00013_A11OrganisationId, BC00013_A17OrganisationPhone, BC00013_A13OrganisationName, BC00013_A12OrganisationKvkNumber, BC00013_A16OrganisationEmail, BC00013_A389OrganisationPhoneCode, BC00013_A390OrganisationPhoneNumber, BC00013_A18OrganisationVATNumber, BC00013_A331OrganisationAddressCountry, BC00013_A289OrganisationAddressCity,
               BC00013_A288OrganisationAddressZipCode, BC00013_A342OrganisationAddressLine1, BC00013_A343OrganisationAddressLine2, BC00013_A19OrganisationTypeId
               }
               , new Object[] {
               BC00014_A20OrganisationTypeName
               }
               , new Object[] {
               BC00015_A11OrganisationId, BC00015_A17OrganisationPhone, BC00015_A13OrganisationName, BC00015_A12OrganisationKvkNumber, BC00015_A16OrganisationEmail, BC00015_A389OrganisationPhoneCode, BC00015_A390OrganisationPhoneNumber, BC00015_A18OrganisationVATNumber, BC00015_A331OrganisationAddressCountry, BC00015_A289OrganisationAddressCity,
               BC00015_A288OrganisationAddressZipCode, BC00015_A342OrganisationAddressLine1, BC00015_A343OrganisationAddressLine2, BC00015_A20OrganisationTypeName, BC00015_A19OrganisationTypeId
               }
               , new Object[] {
               BC00016_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000110_A20OrganisationTypeName
               }
               , new Object[] {
               BC000111_A415AuditId
               }
               , new Object[] {
               BC000112_A100OrganisationSettingid
               }
               , new Object[] {
               BC000113_A42SupplierGenId
               }
               , new Object[] {
               BC000114_A29LocationId, BC000114_A11OrganisationId
               }
               , new Object[] {
               BC000115_A21ManagerId, BC000115_A11OrganisationId
               }
               , new Object[] {
               BC000116_A11OrganisationId, BC000116_A17OrganisationPhone, BC000116_A13OrganisationName, BC000116_A12OrganisationKvkNumber, BC000116_A16OrganisationEmail, BC000116_A389OrganisationPhoneCode, BC000116_A390OrganisationPhoneNumber, BC000116_A18OrganisationVATNumber, BC000116_A331OrganisationAddressCountry, BC000116_A289OrganisationAddressCity,
               BC000116_A288OrganisationAddressZipCode, BC000116_A342OrganisationAddressLine1, BC000116_A343OrganisationAddressLine2, BC000116_A20OrganisationTypeName, BC000116_A19OrganisationTypeId
               }
            }
         );
         AV32Pgmname = "Trn_Organisation_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound3 ;
      private int trnEnded ;
      private int AV33GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV32Pgmname ;
      private string Z17OrganisationPhone ;
      private string A17OrganisationPhone ;
      private string GXt_char1 ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool n11OrganisationId ;
      private bool Gx_longc ;
      private string Z13OrganisationName ;
      private string A13OrganisationName ;
      private string Z12OrganisationKvkNumber ;
      private string A12OrganisationKvkNumber ;
      private string Z16OrganisationEmail ;
      private string A16OrganisationEmail ;
      private string Z389OrganisationPhoneCode ;
      private string A389OrganisationPhoneCode ;
      private string Z390OrganisationPhoneNumber ;
      private string A390OrganisationPhoneNumber ;
      private string Z18OrganisationVATNumber ;
      private string A18OrganisationVATNumber ;
      private string Z331OrganisationAddressCountry ;
      private string A331OrganisationAddressCountry ;
      private string Z289OrganisationAddressCity ;
      private string A289OrganisationAddressCity ;
      private string Z288OrganisationAddressZipCode ;
      private string A288OrganisationAddressZipCode ;
      private string Z342OrganisationAddressLine1 ;
      private string A342OrganisationAddressLine1 ;
      private string Z343OrganisationAddressLine2 ;
      private string A343OrganisationAddressLine2 ;
      private string Z20OrganisationTypeName ;
      private string A20OrganisationTypeName ;
      private string AV31VatPattern ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV13Insert_OrganisationTypeId ;
      private Guid Z19OrganisationTypeId ;
      private Guid A19OrganisationTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00015_A11OrganisationId ;
      private bool[] BC00015_n11OrganisationId ;
      private string[] BC00015_A17OrganisationPhone ;
      private string[] BC00015_A13OrganisationName ;
      private string[] BC00015_A12OrganisationKvkNumber ;
      private string[] BC00015_A16OrganisationEmail ;
      private string[] BC00015_A389OrganisationPhoneCode ;
      private string[] BC00015_A390OrganisationPhoneNumber ;
      private string[] BC00015_A18OrganisationVATNumber ;
      private string[] BC00015_A331OrganisationAddressCountry ;
      private string[] BC00015_A289OrganisationAddressCity ;
      private string[] BC00015_A288OrganisationAddressZipCode ;
      private string[] BC00015_A342OrganisationAddressLine1 ;
      private string[] BC00015_A343OrganisationAddressLine2 ;
      private string[] BC00015_A20OrganisationTypeName ;
      private Guid[] BC00015_A19OrganisationTypeId ;
      private string[] BC00014_A20OrganisationTypeName ;
      private Guid[] BC00016_A11OrganisationId ;
      private bool[] BC00016_n11OrganisationId ;
      private Guid[] BC00013_A11OrganisationId ;
      private bool[] BC00013_n11OrganisationId ;
      private string[] BC00013_A17OrganisationPhone ;
      private string[] BC00013_A13OrganisationName ;
      private string[] BC00013_A12OrganisationKvkNumber ;
      private string[] BC00013_A16OrganisationEmail ;
      private string[] BC00013_A389OrganisationPhoneCode ;
      private string[] BC00013_A390OrganisationPhoneNumber ;
      private string[] BC00013_A18OrganisationVATNumber ;
      private string[] BC00013_A331OrganisationAddressCountry ;
      private string[] BC00013_A289OrganisationAddressCity ;
      private string[] BC00013_A288OrganisationAddressZipCode ;
      private string[] BC00013_A342OrganisationAddressLine1 ;
      private string[] BC00013_A343OrganisationAddressLine2 ;
      private Guid[] BC00013_A19OrganisationTypeId ;
      private Guid[] BC00012_A11OrganisationId ;
      private bool[] BC00012_n11OrganisationId ;
      private string[] BC00012_A17OrganisationPhone ;
      private string[] BC00012_A13OrganisationName ;
      private string[] BC00012_A12OrganisationKvkNumber ;
      private string[] BC00012_A16OrganisationEmail ;
      private string[] BC00012_A389OrganisationPhoneCode ;
      private string[] BC00012_A390OrganisationPhoneNumber ;
      private string[] BC00012_A18OrganisationVATNumber ;
      private string[] BC00012_A331OrganisationAddressCountry ;
      private string[] BC00012_A289OrganisationAddressCity ;
      private string[] BC00012_A288OrganisationAddressZipCode ;
      private string[] BC00012_A342OrganisationAddressLine1 ;
      private string[] BC00012_A343OrganisationAddressLine2 ;
      private Guid[] BC00012_A19OrganisationTypeId ;
      private string[] BC000110_A20OrganisationTypeName ;
      private Guid[] BC000111_A415AuditId ;
      private Guid[] BC000112_A100OrganisationSettingid ;
      private Guid[] BC000113_A42SupplierGenId ;
      private Guid[] BC000114_A29LocationId ;
      private Guid[] BC000114_A11OrganisationId ;
      private bool[] BC000114_n11OrganisationId ;
      private Guid[] BC000115_A21ManagerId ;
      private Guid[] BC000115_A11OrganisationId ;
      private bool[] BC000115_n11OrganisationId ;
      private Guid[] BC000116_A11OrganisationId ;
      private bool[] BC000116_n11OrganisationId ;
      private string[] BC000116_A17OrganisationPhone ;
      private string[] BC000116_A13OrganisationName ;
      private string[] BC000116_A12OrganisationKvkNumber ;
      private string[] BC000116_A16OrganisationEmail ;
      private string[] BC000116_A389OrganisationPhoneCode ;
      private string[] BC000116_A390OrganisationPhoneNumber ;
      private string[] BC000116_A18OrganisationVATNumber ;
      private string[] BC000116_A331OrganisationAddressCountry ;
      private string[] BC000116_A289OrganisationAddressCity ;
      private string[] BC000116_A288OrganisationAddressZipCode ;
      private string[] BC000116_A342OrganisationAddressLine1 ;
      private string[] BC000116_A343OrganisationAddressLine2 ;
      private string[] BC000116_A20OrganisationTypeName ;
      private Guid[] BC000116_A19OrganisationTypeId ;
      private SdtTrn_Organisation bcTrn_Organisation ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisation_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisation_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisation_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00012;
       prmBC00012 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00013;
       prmBC00013 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00014;
       prmBC00014 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00015;
       prmBC00015 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00016;
       prmBC00016 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00017;
       prmBC00017 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationPhone",GXType.Char,20,0) ,
       new ParDef("OrganisationName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("OrganisationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("OrganisationVATNumber",GXType.VarChar,14,0) ,
       new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00018;
       prmBC00018 = new Object[] {
       new ParDef("OrganisationPhone",GXType.Char,20,0) ,
       new ParDef("OrganisationName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("OrganisationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("OrganisationVATNumber",GXType.VarChar,14,0) ,
       new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00019;
       prmBC00019 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000110;
       prmBC000110 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000111;
       prmBC000111 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000112;
       prmBC000112 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000113;
       prmBC000113 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000114;
       prmBC000114 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000115;
       prmBC000115 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000116;
       prmBC000116 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00012", "SELECT OrganisationId, OrganisationPhone, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Organisation",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00013", "SELECT OrganisationId, OrganisationPhone, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00014", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00015", "SELECT TM1.OrganisationId, TM1.OrganisationPhone, TM1.OrganisationName, TM1.OrganisationKvkNumber, TM1.OrganisationEmail, TM1.OrganisationPhoneCode, TM1.OrganisationPhoneNumber, TM1.OrganisationVATNumber, TM1.OrganisationAddressCountry, TM1.OrganisationAddressCity, TM1.OrganisationAddressZipCode, TM1.OrganisationAddressLine1, TM1.OrganisationAddressLine2, T2.OrganisationTypeName, TM1.OrganisationTypeId FROM (Trn_Organisation TM1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = TM1.OrganisationTypeId) WHERE TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00016", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00017", "SAVEPOINT gxupdate;INSERT INTO Trn_Organisation(OrganisationId, OrganisationPhone, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId) VALUES(:OrganisationId, :OrganisationPhone, :OrganisationName, :OrganisationKvkNumber, :OrganisationEmail, :OrganisationPhoneCode, :OrganisationPhoneNumber, :OrganisationVATNumber, :OrganisationAddressCountry, :OrganisationAddressCity, :OrganisationAddressZipCode, :OrganisationAddressLine1, :OrganisationAddressLine2, :OrganisationTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00017)
          ,new CursorDef("BC00018", "SAVEPOINT gxupdate;UPDATE Trn_Organisation SET OrganisationPhone=:OrganisationPhone, OrganisationName=:OrganisationName, OrganisationKvkNumber=:OrganisationKvkNumber, OrganisationEmail=:OrganisationEmail, OrganisationPhoneCode=:OrganisationPhoneCode, OrganisationPhoneNumber=:OrganisationPhoneNumber, OrganisationVATNumber=:OrganisationVATNumber, OrganisationAddressCountry=:OrganisationAddressCountry, OrganisationAddressCity=:OrganisationAddressCity, OrganisationAddressZipCode=:OrganisationAddressZipCode, OrganisationAddressLine1=:OrganisationAddressLine1, OrganisationAddressLine2=:OrganisationAddressLine2, OrganisationTypeId=:OrganisationTypeId  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00018)
          ,new CursorDef("BC00019", "SAVEPOINT gxupdate;DELETE FROM Trn_Organisation  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00019)
          ,new CursorDef("BC000110", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000111", "SELECT AuditId FROM Trn_Audit WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000112", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000113", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000114", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000115", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000115,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000116", "SELECT TM1.OrganisationId, TM1.OrganisationPhone, TM1.OrganisationName, TM1.OrganisationKvkNumber, TM1.OrganisationEmail, TM1.OrganisationPhoneCode, TM1.OrganisationPhoneNumber, TM1.OrganisationVATNumber, TM1.OrganisationAddressCountry, TM1.OrganisationAddressCity, TM1.OrganisationAddressZipCode, TM1.OrganisationAddressLine1, TM1.OrganisationAddressLine2, T2.OrganisationTypeName, TM1.OrganisationTypeId FROM (Trn_Organisation TM1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = TM1.OrganisationTypeId) WHERE TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000116,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
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
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             return;
    }
 }

}

}
