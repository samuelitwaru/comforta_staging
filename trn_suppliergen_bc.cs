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
   public class trn_suppliergen_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_suppliergen_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergen_bc( IGxContext context )
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
         ReadRow069( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey069( ) ;
         standaloneModal( ) ;
         AddRow069( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z42SupplierGenId = A42SupplierGenId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               if ( AnyError == 0 )
               {
                  ZM069( 23) ;
                  ZM069( 24) ;
               }
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12062( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierGenTypeId") == 0 )
               {
                  AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV28Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
         GXt_guid1 = AV30OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV30OrganisationId = GXt_guid1;
         if ( (Guid.Empty==AV30OrganisationId) )
         {
            A11OrganisationId = Guid.Empty;
            n11OrganisationId = false;
            n11OrganisationId = true;
         }
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
            Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
            Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
            Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
            Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z381SupplierGenPhoneCode = A381SupplierGenPhoneCode;
            Z382SupplierGenPhoneNumber = A382SupplierGenPhoneNumber;
            Z441SupplierGenWebsite = A441SupplierGenWebsite;
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z290SupplierGenTypeName = A290SupplierGenTypeName;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -22 )
         {
            Z42SupplierGenId = A42SupplierGenId;
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
            Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
            Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
            Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
            Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z381SupplierGenPhoneCode = A381SupplierGenPhoneCode;
            Z382SupplierGenPhoneNumber = A382SupplierGenPhoneNumber;
            Z441SupplierGenWebsite = A441SupplierGenWebsite;
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
            Z11OrganisationId = A11OrganisationId;
            Z290SupplierGenTypeName = A290SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV32Pgmname = "Trn_SupplierGen_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) )
         {
            A42SupplierGenId = Guid.NewGuid( );
            n42SupplierGenId = false;
         }
         if ( IsIns( )  && ! (Guid.Empty==AV30OrganisationId) )
         {
            A11OrganisationId = AV30OrganisationId;
            n11OrganisationId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load069( )
      {
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A48SupplierGenContactPhone = BC00066_A48SupplierGenContactPhone[0];
            A43SupplierGenKvkNumber = BC00066_A43SupplierGenKvkNumber[0];
            A290SupplierGenTypeName = BC00066_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC00066_A44SupplierGenCompanyName[0];
            A335SupplierGenAddressCountry = BC00066_A335SupplierGenAddressCountry[0];
            A295SupplierGenAddressCity = BC00066_A295SupplierGenAddressCity[0];
            A294SupplierGenAddressZipCode = BC00066_A294SupplierGenAddressZipCode[0];
            A336SupplierGenAddressLine1 = BC00066_A336SupplierGenAddressLine1[0];
            A337SupplierGenAddressLine2 = BC00066_A337SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC00066_A47SupplierGenContactName[0];
            A381SupplierGenPhoneCode = BC00066_A381SupplierGenPhoneCode[0];
            A382SupplierGenPhoneNumber = BC00066_A382SupplierGenPhoneNumber[0];
            A441SupplierGenWebsite = BC00066_A441SupplierGenWebsite[0];
            A282SupplierGenTypeId = BC00066_A282SupplierGenTypeId[0];
            A11OrganisationId = BC00066_A11OrganisationId[0];
            n11OrganisationId = BC00066_n11OrganisationId[0];
            ZM069( -22) ;
         }
         pr_default.close(4);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
      }

      protected void CheckExtendedTable069( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A43SupplierGenKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43SupplierGenKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A43SupplierGenKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KvK number should contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGenType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
         }
         A290SupplierGenTypeName = BC00064_A290SupplierGenTypeName[0];
         pr_default.close(2);
         if ( (Guid.Empty==A282SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Id", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Company Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A335SupplierGenAddressCountry)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Country", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A295SupplierGenAddressCity)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address City", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A294SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Zip Code", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A336SupplierGenAddressLine1)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Line1", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         if ( ! ( GxRegex.IsMatch(A382SupplierGenPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone contains 9 digits", ""), context.GetMessage( "Supplier Gen Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A382SupplierGenPhoneNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! GxRegex.IsMatch(A441SupplierGenWebsite,context.GetMessage( "^(https?:\\/\\/)?(www\\.)?[a-zA-Z0-9-]+(\\.[a-zA-Z]{2,})(\\/[^\\s]*)?$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A441SupplierGenWebsite)) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid website format", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey069( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 22) ;
            RcdFound9 = 1;
            A42SupplierGenId = BC00063_A42SupplierGenId[0];
            n42SupplierGenId = BC00063_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC00063_A48SupplierGenContactPhone[0];
            A43SupplierGenKvkNumber = BC00063_A43SupplierGenKvkNumber[0];
            A44SupplierGenCompanyName = BC00063_A44SupplierGenCompanyName[0];
            A335SupplierGenAddressCountry = BC00063_A335SupplierGenAddressCountry[0];
            A295SupplierGenAddressCity = BC00063_A295SupplierGenAddressCity[0];
            A294SupplierGenAddressZipCode = BC00063_A294SupplierGenAddressZipCode[0];
            A336SupplierGenAddressLine1 = BC00063_A336SupplierGenAddressLine1[0];
            A337SupplierGenAddressLine2 = BC00063_A337SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC00063_A47SupplierGenContactName[0];
            A381SupplierGenPhoneCode = BC00063_A381SupplierGenPhoneCode[0];
            A382SupplierGenPhoneNumber = BC00063_A382SupplierGenPhoneNumber[0];
            A441SupplierGenWebsite = BC00063_A441SupplierGenWebsite[0];
            A282SupplierGenTypeId = BC00063_A282SupplierGenTypeId[0];
            A11OrganisationId = BC00063_A11OrganisationId[0];
            n11OrganisationId = BC00063_n11OrganisationId[0];
            Z42SupplierGenId = A42SupplierGenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z48SupplierGenContactPhone, BC00062_A48SupplierGenContactPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, BC00062_A43SupplierGenKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44SupplierGenCompanyName, BC00062_A44SupplierGenCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z335SupplierGenAddressCountry, BC00062_A335SupplierGenAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z295SupplierGenAddressCity, BC00062_A295SupplierGenAddressCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z294SupplierGenAddressZipCode, BC00062_A294SupplierGenAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z336SupplierGenAddressLine1, BC00062_A336SupplierGenAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z337SupplierGenAddressLine2, BC00062_A337SupplierGenAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierGenContactName, BC00062_A47SupplierGenContactName[0]) != 0 ) || ( StringUtil.StrCmp(Z381SupplierGenPhoneCode, BC00062_A381SupplierGenPhoneCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z382SupplierGenPhoneNumber, BC00062_A382SupplierGenPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z441SupplierGenWebsite, BC00062_A441SupplierGenWebsite[0]) != 0 ) || ( Z282SupplierGenTypeId != BC00062_A282SupplierGenTypeId[0] ) || ( Z11OrganisationId != BC00062_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {n42SupplierGenId, A42SupplierGenId, A48SupplierGenContactPhone, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A335SupplierGenAddressCountry, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A381SupplierGenPhoneCode, A382SupplierGenPhoneNumber, A441SupplierGenWebsite, A282SupplierGenTypeId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00069 */
                     pr_default.execute(7, new Object[] {A48SupplierGenContactPhone, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A335SupplierGenAddressCountry, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A381SupplierGenPhoneCode, A382SupplierGenPhoneNumber, A441SupplierGenWebsite, A282SupplierGenTypeId, n11OrganisationId, A11OrganisationId, n42SupplierGenId, A42SupplierGenId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
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
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000610 */
                  pr_default.execute(8, new Object[] {n42SupplierGenId, A42SupplierGenId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     new prc_deletepreferredgensupplierrecord(context ).execute(  A42SupplierGenId,  A11OrganisationId) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel069( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {A282SupplierGenTypeId});
            A290SupplierGenTypeName = BC000611_A290SupplierGenTypeName[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000612 */
            pr_default.execute(10, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ProductService", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
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

      public void ScanKeyStart069( )
      {
         /* Scan By routine */
         /* Using cursor BC000613 */
         pr_default.execute(11, new Object[] {n42SupplierGenId, A42SupplierGenId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = BC000613_A42SupplierGenId[0];
            n42SupplierGenId = BC000613_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC000613_A48SupplierGenContactPhone[0];
            A43SupplierGenKvkNumber = BC000613_A43SupplierGenKvkNumber[0];
            A290SupplierGenTypeName = BC000613_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC000613_A44SupplierGenCompanyName[0];
            A335SupplierGenAddressCountry = BC000613_A335SupplierGenAddressCountry[0];
            A295SupplierGenAddressCity = BC000613_A295SupplierGenAddressCity[0];
            A294SupplierGenAddressZipCode = BC000613_A294SupplierGenAddressZipCode[0];
            A336SupplierGenAddressLine1 = BC000613_A336SupplierGenAddressLine1[0];
            A337SupplierGenAddressLine2 = BC000613_A337SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC000613_A47SupplierGenContactName[0];
            A381SupplierGenPhoneCode = BC000613_A381SupplierGenPhoneCode[0];
            A382SupplierGenPhoneNumber = BC000613_A382SupplierGenPhoneNumber[0];
            A441SupplierGenWebsite = BC000613_A441SupplierGenWebsite[0];
            A282SupplierGenTypeId = BC000613_A282SupplierGenTypeId[0];
            A11OrganisationId = BC000613_A11OrganisationId[0];
            n11OrganisationId = BC000613_n11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound9 = 0;
         ScanKeyLoad069( ) ;
      }

      protected void ScanKeyLoad069( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = BC000613_A42SupplierGenId[0];
            n42SupplierGenId = BC000613_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC000613_A48SupplierGenContactPhone[0];
            A43SupplierGenKvkNumber = BC000613_A43SupplierGenKvkNumber[0];
            A290SupplierGenTypeName = BC000613_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC000613_A44SupplierGenCompanyName[0];
            A335SupplierGenAddressCountry = BC000613_A335SupplierGenAddressCountry[0];
            A295SupplierGenAddressCity = BC000613_A295SupplierGenAddressCity[0];
            A294SupplierGenAddressZipCode = BC000613_A294SupplierGenAddressZipCode[0];
            A336SupplierGenAddressLine1 = BC000613_A336SupplierGenAddressLine1[0];
            A337SupplierGenAddressLine2 = BC000613_A337SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC000613_A47SupplierGenContactName[0];
            A381SupplierGenPhoneCode = BC000613_A381SupplierGenPhoneCode[0];
            A382SupplierGenPhoneNumber = BC000613_A382SupplierGenPhoneNumber[0];
            A441SupplierGenWebsite = BC000613_A441SupplierGenWebsite[0];
            A282SupplierGenTypeId = BC000613_A282SupplierGenTypeId[0];
            A11OrganisationId = BC000613_A11OrganisationId[0];
            n11OrganisationId = BC000613_n11OrganisationId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd069( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void AddRow069( )
      {
         VarsToRow9( bcTrn_SupplierGen) ;
      }

      protected void ReadRow069( )
      {
         RowToVars9( bcTrn_SupplierGen, 1) ;
      }

      protected void InitializeNonKey069( )
      {
         A48SupplierGenContactPhone = "";
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         A43SupplierGenKvkNumber = "";
         A282SupplierGenTypeId = Guid.Empty;
         A290SupplierGenTypeName = "";
         A44SupplierGenCompanyName = "";
         A335SupplierGenAddressCountry = "";
         A295SupplierGenAddressCity = "";
         A294SupplierGenAddressZipCode = "";
         A336SupplierGenAddressLine1 = "";
         A337SupplierGenAddressLine2 = "";
         A47SupplierGenContactName = "";
         A381SupplierGenPhoneCode = "";
         A382SupplierGenPhoneNumber = "";
         A441SupplierGenWebsite = "";
         Z48SupplierGenContactPhone = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z335SupplierGenAddressCountry = "";
         Z295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z381SupplierGenPhoneCode = "";
         Z382SupplierGenPhoneNumber = "";
         Z441SupplierGenWebsite = "";
         Z282SupplierGenTypeId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll069( )
      {
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A11OrganisationId = i11OrganisationId;
         n11OrganisationId = false;
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

      public void VarsToRow9( SdtTrn_SupplierGen obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Suppliergencontactphone = A48SupplierGenContactPhone;
         obj9.gxTpr_Organisationid = A11OrganisationId;
         obj9.gxTpr_Suppliergenkvknumber = A43SupplierGenKvkNumber;
         obj9.gxTpr_Suppliergentypeid = A282SupplierGenTypeId;
         obj9.gxTpr_Suppliergentypename = A290SupplierGenTypeName;
         obj9.gxTpr_Suppliergencompanyname = A44SupplierGenCompanyName;
         obj9.gxTpr_Suppliergenaddresscountry = A335SupplierGenAddressCountry;
         obj9.gxTpr_Suppliergenaddresscity = A295SupplierGenAddressCity;
         obj9.gxTpr_Suppliergenaddresszipcode = A294SupplierGenAddressZipCode;
         obj9.gxTpr_Suppliergenaddressline1 = A336SupplierGenAddressLine1;
         obj9.gxTpr_Suppliergenaddressline2 = A337SupplierGenAddressLine2;
         obj9.gxTpr_Suppliergencontactname = A47SupplierGenContactName;
         obj9.gxTpr_Suppliergenphonecode = A381SupplierGenPhoneCode;
         obj9.gxTpr_Suppliergenphonenumber = A382SupplierGenPhoneNumber;
         obj9.gxTpr_Suppliergenwebsite = A441SupplierGenWebsite;
         obj9.gxTpr_Suppliergenid = A42SupplierGenId;
         obj9.gxTpr_Suppliergenid_Z = Z42SupplierGenId;
         obj9.gxTpr_Suppliergenkvknumber_Z = Z43SupplierGenKvkNumber;
         obj9.gxTpr_Suppliergentypeid_Z = Z282SupplierGenTypeId;
         obj9.gxTpr_Suppliergentypename_Z = Z290SupplierGenTypeName;
         obj9.gxTpr_Suppliergencompanyname_Z = Z44SupplierGenCompanyName;
         obj9.gxTpr_Suppliergenaddresscountry_Z = Z335SupplierGenAddressCountry;
         obj9.gxTpr_Suppliergenaddresscity_Z = Z295SupplierGenAddressCity;
         obj9.gxTpr_Suppliergenaddresszipcode_Z = Z294SupplierGenAddressZipCode;
         obj9.gxTpr_Suppliergenaddressline1_Z = Z336SupplierGenAddressLine1;
         obj9.gxTpr_Suppliergenaddressline2_Z = Z337SupplierGenAddressLine2;
         obj9.gxTpr_Suppliergencontactname_Z = Z47SupplierGenContactName;
         obj9.gxTpr_Suppliergencontactphone_Z = Z48SupplierGenContactPhone;
         obj9.gxTpr_Suppliergenphonecode_Z = Z381SupplierGenPhoneCode;
         obj9.gxTpr_Suppliergenphonenumber_Z = Z382SupplierGenPhoneNumber;
         obj9.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj9.gxTpr_Suppliergenwebsite_Z = Z441SupplierGenWebsite;
         obj9.gxTpr_Suppliergenid_N = (short)(Convert.ToInt16(n42SupplierGenId));
         obj9.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtTrn_SupplierGen obj9 )
      {
         obj9.gxTpr_Suppliergenid = A42SupplierGenId;
         return  ;
      }

      public void RowToVars9( SdtTrn_SupplierGen obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A48SupplierGenContactPhone = obj9.gxTpr_Suppliergencontactphone;
         A11OrganisationId = obj9.gxTpr_Organisationid;
         n11OrganisationId = false;
         A43SupplierGenKvkNumber = obj9.gxTpr_Suppliergenkvknumber;
         A282SupplierGenTypeId = obj9.gxTpr_Suppliergentypeid;
         A290SupplierGenTypeName = obj9.gxTpr_Suppliergentypename;
         A44SupplierGenCompanyName = obj9.gxTpr_Suppliergencompanyname;
         A335SupplierGenAddressCountry = obj9.gxTpr_Suppliergenaddresscountry;
         A295SupplierGenAddressCity = obj9.gxTpr_Suppliergenaddresscity;
         A294SupplierGenAddressZipCode = obj9.gxTpr_Suppliergenaddresszipcode;
         A336SupplierGenAddressLine1 = obj9.gxTpr_Suppliergenaddressline1;
         A337SupplierGenAddressLine2 = obj9.gxTpr_Suppliergenaddressline2;
         A47SupplierGenContactName = obj9.gxTpr_Suppliergencontactname;
         A381SupplierGenPhoneCode = obj9.gxTpr_Suppliergenphonecode;
         A382SupplierGenPhoneNumber = obj9.gxTpr_Suppliergenphonenumber;
         A441SupplierGenWebsite = obj9.gxTpr_Suppliergenwebsite;
         A42SupplierGenId = obj9.gxTpr_Suppliergenid;
         n42SupplierGenId = false;
         Z42SupplierGenId = obj9.gxTpr_Suppliergenid_Z;
         Z43SupplierGenKvkNumber = obj9.gxTpr_Suppliergenkvknumber_Z;
         Z282SupplierGenTypeId = obj9.gxTpr_Suppliergentypeid_Z;
         Z290SupplierGenTypeName = obj9.gxTpr_Suppliergentypename_Z;
         Z44SupplierGenCompanyName = obj9.gxTpr_Suppliergencompanyname_Z;
         Z335SupplierGenAddressCountry = obj9.gxTpr_Suppliergenaddresscountry_Z;
         Z295SupplierGenAddressCity = obj9.gxTpr_Suppliergenaddresscity_Z;
         Z294SupplierGenAddressZipCode = obj9.gxTpr_Suppliergenaddresszipcode_Z;
         Z336SupplierGenAddressLine1 = obj9.gxTpr_Suppliergenaddressline1_Z;
         Z337SupplierGenAddressLine2 = obj9.gxTpr_Suppliergenaddressline2_Z;
         Z47SupplierGenContactName = obj9.gxTpr_Suppliergencontactname_Z;
         Z48SupplierGenContactPhone = obj9.gxTpr_Suppliergencontactphone_Z;
         Z381SupplierGenPhoneCode = obj9.gxTpr_Suppliergenphonecode_Z;
         Z382SupplierGenPhoneNumber = obj9.gxTpr_Suppliergenphonenumber_Z;
         Z11OrganisationId = obj9.gxTpr_Organisationid_Z;
         Z441SupplierGenWebsite = obj9.gxTpr_Suppliergenwebsite_Z;
         n42SupplierGenId = (bool)(Convert.ToBoolean(obj9.gxTpr_Suppliergenid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj9.gxTpr_Organisationid_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A42SupplierGenId = (Guid)getParm(obj,0);
         n42SupplierGenId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey069( ) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM069( -22) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcTrn_SupplierGen, 0) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM069( -22) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert069( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  A42SupplierGenId = Z42SupplierGenId;
                  n42SupplierGenId = false;
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
                  Update069( ) ;
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
                  if ( A42SupplierGenId != Z42SupplierGenId )
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
                        Insert069( ) ;
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
                        Insert069( ) ;
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcTrn_SupplierGen) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcTrn_SupplierGen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert069( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcTrn_SupplierGen) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcTrn_SupplierGen) ;
         }
         else
         {
            SdtTrn_SupplierGen auxBC = new SdtTrn_SupplierGen(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A42SupplierGenId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierGen);
               auxBC.Save();
               bcTrn_SupplierGen.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert069( ) ;
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
               VarsToRow9( bcTrn_SupplierGen) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcTrn_SupplierGen) ;
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
         RowToVars9( bcTrn_SupplierGen, 0) ;
         GetKey069( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A42SupplierGenId != Z42SupplierGenId )
            {
               A42SupplierGenId = Z42SupplierGenId;
               n42SupplierGenId = false;
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
            if ( A42SupplierGenId != Z42SupplierGenId )
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
         context.RollbackDataStores("trn_suppliergen_bc",pr_default);
         VarsToRow9( bcTrn_SupplierGen) ;
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
         Gx_mode = bcTrn_SupplierGen.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierGen.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierGen )
         {
            bcTrn_SupplierGen = (SdtTrn_SupplierGen)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierGen.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGen.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcTrn_SupplierGen) ;
            }
            else
            {
               RowToVars9( bcTrn_SupplierGen, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierGen.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGen.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcTrn_SupplierGen, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierGen Trn_SupplierGen_BC
      {
         get {
            return bcTrn_SupplierGen ;
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
            return "trn_suppliergen_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z42SupplierGenId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV32Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_SupplierGenTypeId = Guid.Empty;
         AV28Insert_OrganisationId = Guid.Empty;
         AV30OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z48SupplierGenContactPhone = "";
         A48SupplierGenContactPhone = "";
         Z43SupplierGenKvkNumber = "";
         A43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         A44SupplierGenCompanyName = "";
         Z335SupplierGenAddressCountry = "";
         A335SupplierGenAddressCountry = "";
         Z295SupplierGenAddressCity = "";
         A295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         A294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         A336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         A337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         A47SupplierGenContactName = "";
         Z381SupplierGenPhoneCode = "";
         A381SupplierGenPhoneCode = "";
         Z382SupplierGenPhoneNumber = "";
         A382SupplierGenPhoneNumber = "";
         Z441SupplierGenWebsite = "";
         A441SupplierGenWebsite = "";
         Z282SupplierGenTypeId = Guid.Empty;
         A282SupplierGenTypeId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z290SupplierGenTypeName = "";
         A290SupplierGenTypeName = "";
         BC00066_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00066_n42SupplierGenId = new bool[] {false} ;
         BC00066_A48SupplierGenContactPhone = new string[] {""} ;
         BC00066_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00066_A290SupplierGenTypeName = new string[] {""} ;
         BC00066_A44SupplierGenCompanyName = new string[] {""} ;
         BC00066_A335SupplierGenAddressCountry = new string[] {""} ;
         BC00066_A295SupplierGenAddressCity = new string[] {""} ;
         BC00066_A294SupplierGenAddressZipCode = new string[] {""} ;
         BC00066_A336SupplierGenAddressLine1 = new string[] {""} ;
         BC00066_A337SupplierGenAddressLine2 = new string[] {""} ;
         BC00066_A47SupplierGenContactName = new string[] {""} ;
         BC00066_A381SupplierGenPhoneCode = new string[] {""} ;
         BC00066_A382SupplierGenPhoneNumber = new string[] {""} ;
         BC00066_A441SupplierGenWebsite = new string[] {""} ;
         BC00066_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00066_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00066_n11OrganisationId = new bool[] {false} ;
         BC00064_A290SupplierGenTypeName = new string[] {""} ;
         GXt_char2 = "";
         BC00065_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00065_n11OrganisationId = new bool[] {false} ;
         BC00067_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00067_n42SupplierGenId = new bool[] {false} ;
         BC00063_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00063_n42SupplierGenId = new bool[] {false} ;
         BC00063_A48SupplierGenContactPhone = new string[] {""} ;
         BC00063_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00063_A44SupplierGenCompanyName = new string[] {""} ;
         BC00063_A335SupplierGenAddressCountry = new string[] {""} ;
         BC00063_A295SupplierGenAddressCity = new string[] {""} ;
         BC00063_A294SupplierGenAddressZipCode = new string[] {""} ;
         BC00063_A336SupplierGenAddressLine1 = new string[] {""} ;
         BC00063_A337SupplierGenAddressLine2 = new string[] {""} ;
         BC00063_A47SupplierGenContactName = new string[] {""} ;
         BC00063_A381SupplierGenPhoneCode = new string[] {""} ;
         BC00063_A382SupplierGenPhoneNumber = new string[] {""} ;
         BC00063_A441SupplierGenWebsite = new string[] {""} ;
         BC00063_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00063_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00063_n11OrganisationId = new bool[] {false} ;
         sMode9 = "";
         BC00062_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00062_n42SupplierGenId = new bool[] {false} ;
         BC00062_A48SupplierGenContactPhone = new string[] {""} ;
         BC00062_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00062_A44SupplierGenCompanyName = new string[] {""} ;
         BC00062_A335SupplierGenAddressCountry = new string[] {""} ;
         BC00062_A295SupplierGenAddressCity = new string[] {""} ;
         BC00062_A294SupplierGenAddressZipCode = new string[] {""} ;
         BC00062_A336SupplierGenAddressLine1 = new string[] {""} ;
         BC00062_A337SupplierGenAddressLine2 = new string[] {""} ;
         BC00062_A47SupplierGenContactName = new string[] {""} ;
         BC00062_A381SupplierGenPhoneCode = new string[] {""} ;
         BC00062_A382SupplierGenPhoneNumber = new string[] {""} ;
         BC00062_A441SupplierGenWebsite = new string[] {""} ;
         BC00062_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00062_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00062_n11OrganisationId = new bool[] {false} ;
         BC000611_A290SupplierGenTypeName = new string[] {""} ;
         BC000612_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000612_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000612_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000612_n11OrganisationId = new bool[] {false} ;
         BC000613_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000613_n42SupplierGenId = new bool[] {false} ;
         BC000613_A48SupplierGenContactPhone = new string[] {""} ;
         BC000613_A43SupplierGenKvkNumber = new string[] {""} ;
         BC000613_A290SupplierGenTypeName = new string[] {""} ;
         BC000613_A44SupplierGenCompanyName = new string[] {""} ;
         BC000613_A335SupplierGenAddressCountry = new string[] {""} ;
         BC000613_A295SupplierGenAddressCity = new string[] {""} ;
         BC000613_A294SupplierGenAddressZipCode = new string[] {""} ;
         BC000613_A336SupplierGenAddressLine1 = new string[] {""} ;
         BC000613_A337SupplierGenAddressLine2 = new string[] {""} ;
         BC000613_A47SupplierGenContactName = new string[] {""} ;
         BC000613_A381SupplierGenPhoneCode = new string[] {""} ;
         BC000613_A382SupplierGenPhoneNumber = new string[] {""} ;
         BC000613_A441SupplierGenWebsite = new string[] {""} ;
         BC000613_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000613_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000613_n11OrganisationId = new bool[] {false} ;
         i11OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A42SupplierGenId, BC00062_A48SupplierGenContactPhone, BC00062_A43SupplierGenKvkNumber, BC00062_A44SupplierGenCompanyName, BC00062_A335SupplierGenAddressCountry, BC00062_A295SupplierGenAddressCity, BC00062_A294SupplierGenAddressZipCode, BC00062_A336SupplierGenAddressLine1, BC00062_A337SupplierGenAddressLine2, BC00062_A47SupplierGenContactName,
               BC00062_A381SupplierGenPhoneCode, BC00062_A382SupplierGenPhoneNumber, BC00062_A441SupplierGenWebsite, BC00062_A282SupplierGenTypeId, BC00062_A11OrganisationId, BC00062_n11OrganisationId
               }
               , new Object[] {
               BC00063_A42SupplierGenId, BC00063_A48SupplierGenContactPhone, BC00063_A43SupplierGenKvkNumber, BC00063_A44SupplierGenCompanyName, BC00063_A335SupplierGenAddressCountry, BC00063_A295SupplierGenAddressCity, BC00063_A294SupplierGenAddressZipCode, BC00063_A336SupplierGenAddressLine1, BC00063_A337SupplierGenAddressLine2, BC00063_A47SupplierGenContactName,
               BC00063_A381SupplierGenPhoneCode, BC00063_A382SupplierGenPhoneNumber, BC00063_A441SupplierGenWebsite, BC00063_A282SupplierGenTypeId, BC00063_A11OrganisationId, BC00063_n11OrganisationId
               }
               , new Object[] {
               BC00064_A290SupplierGenTypeName
               }
               , new Object[] {
               BC00065_A11OrganisationId
               }
               , new Object[] {
               BC00066_A42SupplierGenId, BC00066_A48SupplierGenContactPhone, BC00066_A43SupplierGenKvkNumber, BC00066_A290SupplierGenTypeName, BC00066_A44SupplierGenCompanyName, BC00066_A335SupplierGenAddressCountry, BC00066_A295SupplierGenAddressCity, BC00066_A294SupplierGenAddressZipCode, BC00066_A336SupplierGenAddressLine1, BC00066_A337SupplierGenAddressLine2,
               BC00066_A47SupplierGenContactName, BC00066_A381SupplierGenPhoneCode, BC00066_A382SupplierGenPhoneNumber, BC00066_A441SupplierGenWebsite, BC00066_A282SupplierGenTypeId, BC00066_A11OrganisationId, BC00066_n11OrganisationId
               }
               , new Object[] {
               BC00067_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000611_A290SupplierGenTypeName
               }
               , new Object[] {
               BC000612_A58ProductServiceId, BC000612_A29LocationId, BC000612_A11OrganisationId
               }
               , new Object[] {
               BC000613_A42SupplierGenId, BC000613_A48SupplierGenContactPhone, BC000613_A43SupplierGenKvkNumber, BC000613_A290SupplierGenTypeName, BC000613_A44SupplierGenCompanyName, BC000613_A335SupplierGenAddressCountry, BC000613_A295SupplierGenAddressCity, BC000613_A294SupplierGenAddressZipCode, BC000613_A336SupplierGenAddressLine1, BC000613_A337SupplierGenAddressLine2,
               BC000613_A47SupplierGenContactName, BC000613_A381SupplierGenPhoneCode, BC000613_A382SupplierGenPhoneNumber, BC000613_A441SupplierGenWebsite, BC000613_A282SupplierGenTypeId, BC000613_A11OrganisationId, BC000613_n11OrganisationId
               }
            }
         );
         Z42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AV32Pgmname = "Trn_SupplierGen_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private int trnEnded ;
      private int AV33GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV32Pgmname ;
      private string Z48SupplierGenContactPhone ;
      private string A48SupplierGenContactPhone ;
      private string GXt_char2 ;
      private string sMode9 ;
      private bool returnInSub ;
      private bool n11OrganisationId ;
      private bool n42SupplierGenId ;
      private bool Gx_longc ;
      private string Z43SupplierGenKvkNumber ;
      private string A43SupplierGenKvkNumber ;
      private string Z44SupplierGenCompanyName ;
      private string A44SupplierGenCompanyName ;
      private string Z335SupplierGenAddressCountry ;
      private string A335SupplierGenAddressCountry ;
      private string Z295SupplierGenAddressCity ;
      private string A295SupplierGenAddressCity ;
      private string Z294SupplierGenAddressZipCode ;
      private string A294SupplierGenAddressZipCode ;
      private string Z336SupplierGenAddressLine1 ;
      private string A336SupplierGenAddressLine1 ;
      private string Z337SupplierGenAddressLine2 ;
      private string A337SupplierGenAddressLine2 ;
      private string Z47SupplierGenContactName ;
      private string A47SupplierGenContactName ;
      private string Z381SupplierGenPhoneCode ;
      private string A381SupplierGenPhoneCode ;
      private string Z382SupplierGenPhoneNumber ;
      private string A382SupplierGenPhoneNumber ;
      private string Z441SupplierGenWebsite ;
      private string A441SupplierGenWebsite ;
      private string Z290SupplierGenTypeName ;
      private string A290SupplierGenTypeName ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid AV13Insert_SupplierGenTypeId ;
      private Guid AV28Insert_OrganisationId ;
      private Guid AV30OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A11OrganisationId ;
      private Guid Z282SupplierGenTypeId ;
      private Guid A282SupplierGenTypeId ;
      private Guid Z11OrganisationId ;
      private Guid i11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00066_A42SupplierGenId ;
      private bool[] BC00066_n42SupplierGenId ;
      private string[] BC00066_A48SupplierGenContactPhone ;
      private string[] BC00066_A43SupplierGenKvkNumber ;
      private string[] BC00066_A290SupplierGenTypeName ;
      private string[] BC00066_A44SupplierGenCompanyName ;
      private string[] BC00066_A335SupplierGenAddressCountry ;
      private string[] BC00066_A295SupplierGenAddressCity ;
      private string[] BC00066_A294SupplierGenAddressZipCode ;
      private string[] BC00066_A336SupplierGenAddressLine1 ;
      private string[] BC00066_A337SupplierGenAddressLine2 ;
      private string[] BC00066_A47SupplierGenContactName ;
      private string[] BC00066_A381SupplierGenPhoneCode ;
      private string[] BC00066_A382SupplierGenPhoneNumber ;
      private string[] BC00066_A441SupplierGenWebsite ;
      private Guid[] BC00066_A282SupplierGenTypeId ;
      private Guid[] BC00066_A11OrganisationId ;
      private bool[] BC00066_n11OrganisationId ;
      private string[] BC00064_A290SupplierGenTypeName ;
      private Guid[] BC00065_A11OrganisationId ;
      private bool[] BC00065_n11OrganisationId ;
      private Guid[] BC00067_A42SupplierGenId ;
      private bool[] BC00067_n42SupplierGenId ;
      private Guid[] BC00063_A42SupplierGenId ;
      private bool[] BC00063_n42SupplierGenId ;
      private string[] BC00063_A48SupplierGenContactPhone ;
      private string[] BC00063_A43SupplierGenKvkNumber ;
      private string[] BC00063_A44SupplierGenCompanyName ;
      private string[] BC00063_A335SupplierGenAddressCountry ;
      private string[] BC00063_A295SupplierGenAddressCity ;
      private string[] BC00063_A294SupplierGenAddressZipCode ;
      private string[] BC00063_A336SupplierGenAddressLine1 ;
      private string[] BC00063_A337SupplierGenAddressLine2 ;
      private string[] BC00063_A47SupplierGenContactName ;
      private string[] BC00063_A381SupplierGenPhoneCode ;
      private string[] BC00063_A382SupplierGenPhoneNumber ;
      private string[] BC00063_A441SupplierGenWebsite ;
      private Guid[] BC00063_A282SupplierGenTypeId ;
      private Guid[] BC00063_A11OrganisationId ;
      private bool[] BC00063_n11OrganisationId ;
      private Guid[] BC00062_A42SupplierGenId ;
      private bool[] BC00062_n42SupplierGenId ;
      private string[] BC00062_A48SupplierGenContactPhone ;
      private string[] BC00062_A43SupplierGenKvkNumber ;
      private string[] BC00062_A44SupplierGenCompanyName ;
      private string[] BC00062_A335SupplierGenAddressCountry ;
      private string[] BC00062_A295SupplierGenAddressCity ;
      private string[] BC00062_A294SupplierGenAddressZipCode ;
      private string[] BC00062_A336SupplierGenAddressLine1 ;
      private string[] BC00062_A337SupplierGenAddressLine2 ;
      private string[] BC00062_A47SupplierGenContactName ;
      private string[] BC00062_A381SupplierGenPhoneCode ;
      private string[] BC00062_A382SupplierGenPhoneNumber ;
      private string[] BC00062_A441SupplierGenWebsite ;
      private Guid[] BC00062_A282SupplierGenTypeId ;
      private Guid[] BC00062_A11OrganisationId ;
      private bool[] BC00062_n11OrganisationId ;
      private string[] BC000611_A290SupplierGenTypeName ;
      private Guid[] BC000612_A58ProductServiceId ;
      private Guid[] BC000612_A29LocationId ;
      private Guid[] BC000612_A11OrganisationId ;
      private bool[] BC000612_n11OrganisationId ;
      private Guid[] BC000613_A42SupplierGenId ;
      private bool[] BC000613_n42SupplierGenId ;
      private string[] BC000613_A48SupplierGenContactPhone ;
      private string[] BC000613_A43SupplierGenKvkNumber ;
      private string[] BC000613_A290SupplierGenTypeName ;
      private string[] BC000613_A44SupplierGenCompanyName ;
      private string[] BC000613_A335SupplierGenAddressCountry ;
      private string[] BC000613_A295SupplierGenAddressCity ;
      private string[] BC000613_A294SupplierGenAddressZipCode ;
      private string[] BC000613_A336SupplierGenAddressLine1 ;
      private string[] BC000613_A337SupplierGenAddressLine2 ;
      private string[] BC000613_A47SupplierGenContactName ;
      private string[] BC000613_A381SupplierGenPhoneCode ;
      private string[] BC000613_A382SupplierGenPhoneNumber ;
      private string[] BC000613_A441SupplierGenWebsite ;
      private Guid[] BC000613_A282SupplierGenTypeId ;
      private Guid[] BC000613_A11OrganisationId ;
      private bool[] BC000613_n11OrganisationId ;
      private SdtTrn_SupplierGen bcTrn_SupplierGen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergen_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergen_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergen_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00062;
       prmBC00062 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00063;
       prmBC00063 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00064;
       prmBC00064 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00065;
       prmBC00065 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00066;
       prmBC00066 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00067;
       prmBC00067 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00068;
       prmBC00068 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00069;
       prmBC00069 = new Object[] {
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000610;
       prmBC000610 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000611;
       prmBC000611 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000612;
       prmBC000612 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000613;
       prmBC000613 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00062", "SELECT SupplierGenId, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierGen",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00063", "SELECT SupplierGenId, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00064", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00065", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00066", "SELECT TM1.SupplierGenId, TM1.SupplierGenContactPhone, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCountry, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressZipCode, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneCode, TM1.SupplierGenPhoneNumber, TM1.SupplierGenWebsite, TM1.SupplierGenTypeId, TM1.OrganisationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00067", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00068", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGen(SupplierGenId, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId) VALUES(:SupplierGenId, :SupplierGenContactPhone, :SupplierGenKvkNumber, :SupplierGenCompanyName, :SupplierGenAddressCountry, :SupplierGenAddressCity, :SupplierGenAddressZipCode, :SupplierGenAddressLine1, :SupplierGenAddressLine2, :SupplierGenContactName, :SupplierGenPhoneCode, :SupplierGenPhoneNumber, :SupplierGenWebsite, :SupplierGenTypeId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00068)
          ,new CursorDef("BC00069", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGen SET SupplierGenContactPhone=:SupplierGenContactPhone, SupplierGenKvkNumber=:SupplierGenKvkNumber, SupplierGenCompanyName=:SupplierGenCompanyName, SupplierGenAddressCountry=:SupplierGenAddressCountry, SupplierGenAddressCity=:SupplierGenAddressCity, SupplierGenAddressZipCode=:SupplierGenAddressZipCode, SupplierGenAddressLine1=:SupplierGenAddressLine1, SupplierGenAddressLine2=:SupplierGenAddressLine2, SupplierGenContactName=:SupplierGenContactName, SupplierGenPhoneCode=:SupplierGenPhoneCode, SupplierGenPhoneNumber=:SupplierGenPhoneNumber, SupplierGenWebsite=:SupplierGenWebsite, SupplierGenTypeId=:SupplierGenTypeId, OrganisationId=:OrganisationId  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00069)
          ,new CursorDef("BC000610", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000610)
          ,new CursorDef("BC000611", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000612", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000613", "SELECT TM1.SupplierGenId, TM1.SupplierGenContactPhone, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCountry, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressZipCode, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneCode, TM1.SupplierGenPhoneNumber, TM1.SupplierGenWebsite, TM1.SupplierGenTypeId, TM1.OrganisationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((bool[]) buf[15])[0] = rslt.wasNull(15);
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
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((bool[]) buf[15])[0] = rslt.wasNull(15);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
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
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
             ((bool[]) buf[16])[0] = rslt.wasNull(16);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 11 :
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
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
             ((bool[]) buf[16])[0] = rslt.wasNull(16);
             return;
    }
 }

}

}
