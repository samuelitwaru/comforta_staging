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
   public class trn_supplieragb_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_supplieragb_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragb_bc( IGxContext context )
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
         ReadRow0711( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0711( ) ;
         standaloneModal( ) ;
         AddRow0711( ) ;
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
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z49SupplierAgbId = A49SupplierAgbId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0711( ) ;
            }
            else
            {
               CheckExtendedTable0711( ) ;
               if ( AnyError == 0 )
               {
                  ZM0711( 22) ;
               }
               CloseExtendedTableCursors0711( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12072( )
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
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierAgbTypeId") == 0 )
               {
                  AV13Insert_SupplierAgbTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
         }
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0711( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z56SupplierAgbPhone = A56SupplierAgbPhone;
            Z50SupplierAgbNumber = A50SupplierAgbNumber;
            Z51SupplierAgbName = A51SupplierAgbName;
            Z52SupplierAgbKvkNumber = A52SupplierAgbKvkNumber;
            Z332SupplierAGBAddressCountry = A332SupplierAGBAddressCountry;
            Z299SupplierAgbAddressCity = A299SupplierAgbAddressCity;
            Z298SupplierAgbAddressZipCode = A298SupplierAgbAddressZipCode;
            Z333SupplierAgbAddressLine1 = A333SupplierAgbAddressLine1;
            Z334SupplierAgbAddressLine2 = A334SupplierAgbAddressLine2;
            Z55SupplierAgbContactName = A55SupplierAgbContactName;
            Z377SupplierAgbPhoneCode = A377SupplierAgbPhoneCode;
            Z378SupplierAgbPhoneNumber = A378SupplierAgbPhoneNumber;
            Z57SupplierAgbEmail = A57SupplierAgbEmail;
            Z440SupplierAgbWebsite = A440SupplierAgbWebsite;
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z291SupplierAgbTypeName = A291SupplierAgbTypeName;
         }
         if ( GX_JID == -21 )
         {
            Z49SupplierAgbId = A49SupplierAgbId;
            Z56SupplierAgbPhone = A56SupplierAgbPhone;
            Z50SupplierAgbNumber = A50SupplierAgbNumber;
            Z51SupplierAgbName = A51SupplierAgbName;
            Z52SupplierAgbKvkNumber = A52SupplierAgbKvkNumber;
            Z332SupplierAGBAddressCountry = A332SupplierAGBAddressCountry;
            Z299SupplierAgbAddressCity = A299SupplierAgbAddressCity;
            Z298SupplierAgbAddressZipCode = A298SupplierAgbAddressZipCode;
            Z333SupplierAgbAddressLine1 = A333SupplierAgbAddressLine1;
            Z334SupplierAgbAddressLine2 = A334SupplierAgbAddressLine2;
            Z55SupplierAgbContactName = A55SupplierAgbContactName;
            Z377SupplierAgbPhoneCode = A377SupplierAgbPhoneCode;
            Z378SupplierAgbPhoneNumber = A378SupplierAgbPhoneNumber;
            Z57SupplierAgbEmail = A57SupplierAgbEmail;
            Z440SupplierAgbWebsite = A440SupplierAgbWebsite;
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
            Z291SupplierAgbTypeName = A291SupplierAgbTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Trn_SupplierAgb_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A49SupplierAgbId) )
         {
            A49SupplierAgbId = Guid.NewGuid( );
            n49SupplierAgbId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0711( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A56SupplierAgbPhone = BC00075_A56SupplierAgbPhone[0];
            A50SupplierAgbNumber = BC00075_A50SupplierAgbNumber[0];
            A291SupplierAgbTypeName = BC00075_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = BC00075_A51SupplierAgbName[0];
            A52SupplierAgbKvkNumber = BC00075_A52SupplierAgbKvkNumber[0];
            A332SupplierAGBAddressCountry = BC00075_A332SupplierAGBAddressCountry[0];
            A299SupplierAgbAddressCity = BC00075_A299SupplierAgbAddressCity[0];
            A298SupplierAgbAddressZipCode = BC00075_A298SupplierAgbAddressZipCode[0];
            A333SupplierAgbAddressLine1 = BC00075_A333SupplierAgbAddressLine1[0];
            A334SupplierAgbAddressLine2 = BC00075_A334SupplierAgbAddressLine2[0];
            A55SupplierAgbContactName = BC00075_A55SupplierAgbContactName[0];
            A377SupplierAgbPhoneCode = BC00075_A377SupplierAgbPhoneCode[0];
            A378SupplierAgbPhoneNumber = BC00075_A378SupplierAgbPhoneNumber[0];
            A57SupplierAgbEmail = BC00075_A57SupplierAgbEmail[0];
            A440SupplierAgbWebsite = BC00075_A440SupplierAgbWebsite[0];
            A283SupplierAgbTypeId = BC00075_A283SupplierAgbTypeId[0];
            ZM0711( -21) ;
         }
         pr_default.close(3);
         OnLoadActions0711( ) ;
      }

      protected void OnLoadActions0711( )
      {
         GXt_char1 = A56SupplierAgbPhone;
         new prc_concatenateintlphone(context ).execute(  A377SupplierAgbPhoneCode,  A378SupplierAgbPhoneNumber, out  GXt_char1) ;
         A56SupplierAgbPhone = GXt_char1;
      }

      protected void CheckExtendedTable0711( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A50SupplierAgbNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Number", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A50SupplierAgbNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "AGB Number should contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierAgbType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
         }
         A291SupplierAgbTypeName = BC00074_A291SupplierAgbTypeName[0];
         pr_default.close(2);
         if ( (Guid.Empty==A283SupplierAgbTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Type Id", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A52SupplierAgbKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Supplier Agb Kvk Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A52SupplierAgbKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KvK Number should contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A332SupplierAGBAddressCountry)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier AGBAddress Country", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A299SupplierAgbAddressCity)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Address City", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A298SupplierAgbAddressZipCode)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Address Zip Code", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A333SupplierAgbAddressLine1)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Address Line1", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         GXt_char1 = A56SupplierAgbPhone;
         new prc_concatenateintlphone(context ).execute(  A377SupplierAgbPhoneCode,  A378SupplierAgbPhoneNumber, out  GXt_char1) ;
         A56SupplierAgbPhone = GXt_char1;
         if ( ! ( GxRegex.IsMatch(A378SupplierAgbPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone contains 9 digits", ""), context.GetMessage( "Supplier Agb Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A378SupplierAgbPhoneNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A57SupplierAgbEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Supplier Agb Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! GxRegex.IsMatch(A440SupplierAgbWebsite,context.GetMessage( "^(https?:\\/\\/)?(www\\.)?[a-zA-Z0-9-]+(\\.[a-zA-Z]{2,})(\\/[^\\s]*)?$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A440SupplierAgbWebsite)) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid website format", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0711( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0711( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0711( 21) ;
            RcdFound11 = 1;
            A49SupplierAgbId = BC00073_A49SupplierAgbId[0];
            n49SupplierAgbId = BC00073_n49SupplierAgbId[0];
            A56SupplierAgbPhone = BC00073_A56SupplierAgbPhone[0];
            A50SupplierAgbNumber = BC00073_A50SupplierAgbNumber[0];
            A51SupplierAgbName = BC00073_A51SupplierAgbName[0];
            A52SupplierAgbKvkNumber = BC00073_A52SupplierAgbKvkNumber[0];
            A332SupplierAGBAddressCountry = BC00073_A332SupplierAGBAddressCountry[0];
            A299SupplierAgbAddressCity = BC00073_A299SupplierAgbAddressCity[0];
            A298SupplierAgbAddressZipCode = BC00073_A298SupplierAgbAddressZipCode[0];
            A333SupplierAgbAddressLine1 = BC00073_A333SupplierAgbAddressLine1[0];
            A334SupplierAgbAddressLine2 = BC00073_A334SupplierAgbAddressLine2[0];
            A55SupplierAgbContactName = BC00073_A55SupplierAgbContactName[0];
            A377SupplierAgbPhoneCode = BC00073_A377SupplierAgbPhoneCode[0];
            A378SupplierAgbPhoneNumber = BC00073_A378SupplierAgbPhoneNumber[0];
            A57SupplierAgbEmail = BC00073_A57SupplierAgbEmail[0];
            A440SupplierAgbWebsite = BC00073_A440SupplierAgbWebsite[0];
            A283SupplierAgbTypeId = BC00073_A283SupplierAgbTypeId[0];
            Z49SupplierAgbId = A49SupplierAgbId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0711( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0711( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0711( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0711( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_070( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0711( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAGB"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z56SupplierAgbPhone, BC00072_A56SupplierAgbPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z50SupplierAgbNumber, BC00072_A50SupplierAgbNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z51SupplierAgbName, BC00072_A51SupplierAgbName[0]) != 0 ) || ( StringUtil.StrCmp(Z52SupplierAgbKvkNumber, BC00072_A52SupplierAgbKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z332SupplierAGBAddressCountry, BC00072_A332SupplierAGBAddressCountry[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z299SupplierAgbAddressCity, BC00072_A299SupplierAgbAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z298SupplierAgbAddressZipCode, BC00072_A298SupplierAgbAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z333SupplierAgbAddressLine1, BC00072_A333SupplierAgbAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z334SupplierAgbAddressLine2, BC00072_A334SupplierAgbAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z55SupplierAgbContactName, BC00072_A55SupplierAgbContactName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z377SupplierAgbPhoneCode, BC00072_A377SupplierAgbPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z378SupplierAgbPhoneNumber, BC00072_A378SupplierAgbPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z57SupplierAgbEmail, BC00072_A57SupplierAgbEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z440SupplierAgbWebsite, BC00072_A440SupplierAgbWebsite[0]) != 0 ) || ( Z283SupplierAgbTypeId != BC00072_A283SupplierAgbTypeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierAGB"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0711( )
      {
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0711( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0711( 0) ;
            CheckOptimisticConcurrency0711( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0711( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0711( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00077 */
                     pr_default.execute(5, new Object[] {n49SupplierAgbId, A49SupplierAgbId, A56SupplierAgbPhone, A50SupplierAgbNumber, A51SupplierAgbName, A52SupplierAgbKvkNumber, A332SupplierAGBAddressCountry, A299SupplierAgbAddressCity, A298SupplierAgbAddressZipCode, A333SupplierAgbAddressLine1, A334SupplierAgbAddressLine2, A55SupplierAgbContactName, A377SupplierAgbPhoneCode, A378SupplierAgbPhoneNumber, A57SupplierAgbEmail, A440SupplierAgbWebsite, A283SupplierAgbTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
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
               Load0711( ) ;
            }
            EndLevel0711( ) ;
         }
         CloseExtendedTableCursors0711( ) ;
      }

      protected void Update0711( )
      {
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0711( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0711( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0711( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0711( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A56SupplierAgbPhone, A50SupplierAgbNumber, A51SupplierAgbName, A52SupplierAgbKvkNumber, A332SupplierAGBAddressCountry, A299SupplierAgbAddressCity, A298SupplierAgbAddressZipCode, A333SupplierAgbAddressLine1, A334SupplierAgbAddressLine2, A55SupplierAgbContactName, A377SupplierAgbPhoneCode, A378SupplierAgbPhoneNumber, A57SupplierAgbEmail, A440SupplierAgbWebsite, A283SupplierAgbTypeId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAGB"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0711( ) ;
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
            EndLevel0711( ) ;
         }
         CloseExtendedTableCursors0711( ) ;
      }

      protected void DeferredUpdate0711( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0711( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0711( ) ;
            AfterConfirm0711( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0711( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0711( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0711( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {A283SupplierAgbTypeId});
            A291SupplierAgbTypeName = BC000710_A291SupplierAgbTypeName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000711 */
            pr_default.execute(9, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ProductService", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0711( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0711( ) ;
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

      public void ScanKeyStart0711( )
      {
         /* Scan By routine */
         /* Using cursor BC000712 */
         pr_default.execute(10, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A49SupplierAgbId = BC000712_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000712_n49SupplierAgbId[0];
            A56SupplierAgbPhone = BC000712_A56SupplierAgbPhone[0];
            A50SupplierAgbNumber = BC000712_A50SupplierAgbNumber[0];
            A291SupplierAgbTypeName = BC000712_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = BC000712_A51SupplierAgbName[0];
            A52SupplierAgbKvkNumber = BC000712_A52SupplierAgbKvkNumber[0];
            A332SupplierAGBAddressCountry = BC000712_A332SupplierAGBAddressCountry[0];
            A299SupplierAgbAddressCity = BC000712_A299SupplierAgbAddressCity[0];
            A298SupplierAgbAddressZipCode = BC000712_A298SupplierAgbAddressZipCode[0];
            A333SupplierAgbAddressLine1 = BC000712_A333SupplierAgbAddressLine1[0];
            A334SupplierAgbAddressLine2 = BC000712_A334SupplierAgbAddressLine2[0];
            A55SupplierAgbContactName = BC000712_A55SupplierAgbContactName[0];
            A377SupplierAgbPhoneCode = BC000712_A377SupplierAgbPhoneCode[0];
            A378SupplierAgbPhoneNumber = BC000712_A378SupplierAgbPhoneNumber[0];
            A57SupplierAgbEmail = BC000712_A57SupplierAgbEmail[0];
            A440SupplierAgbWebsite = BC000712_A440SupplierAgbWebsite[0];
            A283SupplierAgbTypeId = BC000712_A283SupplierAgbTypeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0711( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound11 = 0;
         ScanKeyLoad0711( ) ;
      }

      protected void ScanKeyLoad0711( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound11 = 1;
            A49SupplierAgbId = BC000712_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000712_n49SupplierAgbId[0];
            A56SupplierAgbPhone = BC000712_A56SupplierAgbPhone[0];
            A50SupplierAgbNumber = BC000712_A50SupplierAgbNumber[0];
            A291SupplierAgbTypeName = BC000712_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = BC000712_A51SupplierAgbName[0];
            A52SupplierAgbKvkNumber = BC000712_A52SupplierAgbKvkNumber[0];
            A332SupplierAGBAddressCountry = BC000712_A332SupplierAGBAddressCountry[0];
            A299SupplierAgbAddressCity = BC000712_A299SupplierAgbAddressCity[0];
            A298SupplierAgbAddressZipCode = BC000712_A298SupplierAgbAddressZipCode[0];
            A333SupplierAgbAddressLine1 = BC000712_A333SupplierAgbAddressLine1[0];
            A334SupplierAgbAddressLine2 = BC000712_A334SupplierAgbAddressLine2[0];
            A55SupplierAgbContactName = BC000712_A55SupplierAgbContactName[0];
            A377SupplierAgbPhoneCode = BC000712_A377SupplierAgbPhoneCode[0];
            A378SupplierAgbPhoneNumber = BC000712_A378SupplierAgbPhoneNumber[0];
            A57SupplierAgbEmail = BC000712_A57SupplierAgbEmail[0];
            A440SupplierAgbWebsite = BC000712_A440SupplierAgbWebsite[0];
            A283SupplierAgbTypeId = BC000712_A283SupplierAgbTypeId[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0711( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0711( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0711( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0711( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0711( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0711( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0711( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0711( )
      {
      }

      protected void send_integrity_lvl_hashes0711( )
      {
      }

      protected void AddRow0711( )
      {
         VarsToRow11( bcTrn_SupplierAgb) ;
      }

      protected void ReadRow0711( )
      {
         RowToVars11( bcTrn_SupplierAgb, 1) ;
      }

      protected void InitializeNonKey0711( )
      {
         A56SupplierAgbPhone = "";
         A50SupplierAgbNumber = "";
         A283SupplierAgbTypeId = Guid.Empty;
         A291SupplierAgbTypeName = "";
         A51SupplierAgbName = "";
         A52SupplierAgbKvkNumber = "";
         A332SupplierAGBAddressCountry = "";
         A299SupplierAgbAddressCity = "";
         A298SupplierAgbAddressZipCode = "";
         A333SupplierAgbAddressLine1 = "";
         A334SupplierAgbAddressLine2 = "";
         A55SupplierAgbContactName = "";
         A377SupplierAgbPhoneCode = "";
         A378SupplierAgbPhoneNumber = "";
         A57SupplierAgbEmail = "";
         A440SupplierAgbWebsite = "";
         Z56SupplierAgbPhone = "";
         Z50SupplierAgbNumber = "";
         Z51SupplierAgbName = "";
         Z52SupplierAgbKvkNumber = "";
         Z332SupplierAGBAddressCountry = "";
         Z299SupplierAgbAddressCity = "";
         Z298SupplierAgbAddressZipCode = "";
         Z333SupplierAgbAddressLine1 = "";
         Z334SupplierAgbAddressLine2 = "";
         Z55SupplierAgbContactName = "";
         Z377SupplierAgbPhoneCode = "";
         Z378SupplierAgbPhoneNumber = "";
         Z57SupplierAgbEmail = "";
         Z440SupplierAgbWebsite = "";
         Z283SupplierAgbTypeId = Guid.Empty;
      }

      protected void InitAll0711( )
      {
         A49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         InitializeNonKey0711( ) ;
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

      public void VarsToRow11( SdtTrn_SupplierAgb obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Supplieragbphone = A56SupplierAgbPhone;
         obj11.gxTpr_Supplieragbnumber = A50SupplierAgbNumber;
         obj11.gxTpr_Supplieragbtypeid = A283SupplierAgbTypeId;
         obj11.gxTpr_Supplieragbtypename = A291SupplierAgbTypeName;
         obj11.gxTpr_Supplieragbname = A51SupplierAgbName;
         obj11.gxTpr_Supplieragbkvknumber = A52SupplierAgbKvkNumber;
         obj11.gxTpr_Supplieragbaddresscountry = A332SupplierAGBAddressCountry;
         obj11.gxTpr_Supplieragbaddresscity = A299SupplierAgbAddressCity;
         obj11.gxTpr_Supplieragbaddresszipcode = A298SupplierAgbAddressZipCode;
         obj11.gxTpr_Supplieragbaddressline1 = A333SupplierAgbAddressLine1;
         obj11.gxTpr_Supplieragbaddressline2 = A334SupplierAgbAddressLine2;
         obj11.gxTpr_Supplieragbcontactname = A55SupplierAgbContactName;
         obj11.gxTpr_Supplieragbphonecode = A377SupplierAgbPhoneCode;
         obj11.gxTpr_Supplieragbphonenumber = A378SupplierAgbPhoneNumber;
         obj11.gxTpr_Supplieragbemail = A57SupplierAgbEmail;
         obj11.gxTpr_Supplieragbwebsite = A440SupplierAgbWebsite;
         obj11.gxTpr_Supplieragbid = A49SupplierAgbId;
         obj11.gxTpr_Supplieragbid_Z = Z49SupplierAgbId;
         obj11.gxTpr_Supplieragbnumber_Z = Z50SupplierAgbNumber;
         obj11.gxTpr_Supplieragbtypeid_Z = Z283SupplierAgbTypeId;
         obj11.gxTpr_Supplieragbtypename_Z = Z291SupplierAgbTypeName;
         obj11.gxTpr_Supplieragbname_Z = Z51SupplierAgbName;
         obj11.gxTpr_Supplieragbkvknumber_Z = Z52SupplierAgbKvkNumber;
         obj11.gxTpr_Supplieragbaddresscountry_Z = Z332SupplierAGBAddressCountry;
         obj11.gxTpr_Supplieragbaddresscity_Z = Z299SupplierAgbAddressCity;
         obj11.gxTpr_Supplieragbaddresszipcode_Z = Z298SupplierAgbAddressZipCode;
         obj11.gxTpr_Supplieragbaddressline1_Z = Z333SupplierAgbAddressLine1;
         obj11.gxTpr_Supplieragbaddressline2_Z = Z334SupplierAgbAddressLine2;
         obj11.gxTpr_Supplieragbcontactname_Z = Z55SupplierAgbContactName;
         obj11.gxTpr_Supplieragbphone_Z = Z56SupplierAgbPhone;
         obj11.gxTpr_Supplieragbphonecode_Z = Z377SupplierAgbPhoneCode;
         obj11.gxTpr_Supplieragbphonenumber_Z = Z378SupplierAgbPhoneNumber;
         obj11.gxTpr_Supplieragbemail_Z = Z57SupplierAgbEmail;
         obj11.gxTpr_Supplieragbwebsite_Z = Z440SupplierAgbWebsite;
         obj11.gxTpr_Supplieragbid_N = (short)(Convert.ToInt16(n49SupplierAgbId));
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( SdtTrn_SupplierAgb obj11 )
      {
         obj11.gxTpr_Supplieragbid = A49SupplierAgbId;
         return  ;
      }

      public void RowToVars11( SdtTrn_SupplierAgb obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A56SupplierAgbPhone = obj11.gxTpr_Supplieragbphone;
         A50SupplierAgbNumber = obj11.gxTpr_Supplieragbnumber;
         A283SupplierAgbTypeId = obj11.gxTpr_Supplieragbtypeid;
         A291SupplierAgbTypeName = obj11.gxTpr_Supplieragbtypename;
         A51SupplierAgbName = obj11.gxTpr_Supplieragbname;
         A52SupplierAgbKvkNumber = obj11.gxTpr_Supplieragbkvknumber;
         A332SupplierAGBAddressCountry = obj11.gxTpr_Supplieragbaddresscountry;
         A299SupplierAgbAddressCity = obj11.gxTpr_Supplieragbaddresscity;
         A298SupplierAgbAddressZipCode = obj11.gxTpr_Supplieragbaddresszipcode;
         A333SupplierAgbAddressLine1 = obj11.gxTpr_Supplieragbaddressline1;
         A334SupplierAgbAddressLine2 = obj11.gxTpr_Supplieragbaddressline2;
         A55SupplierAgbContactName = obj11.gxTpr_Supplieragbcontactname;
         A377SupplierAgbPhoneCode = obj11.gxTpr_Supplieragbphonecode;
         A378SupplierAgbPhoneNumber = obj11.gxTpr_Supplieragbphonenumber;
         A57SupplierAgbEmail = obj11.gxTpr_Supplieragbemail;
         A440SupplierAgbWebsite = obj11.gxTpr_Supplieragbwebsite;
         A49SupplierAgbId = obj11.gxTpr_Supplieragbid;
         n49SupplierAgbId = false;
         Z49SupplierAgbId = obj11.gxTpr_Supplieragbid_Z;
         Z50SupplierAgbNumber = obj11.gxTpr_Supplieragbnumber_Z;
         Z283SupplierAgbTypeId = obj11.gxTpr_Supplieragbtypeid_Z;
         Z291SupplierAgbTypeName = obj11.gxTpr_Supplieragbtypename_Z;
         Z51SupplierAgbName = obj11.gxTpr_Supplieragbname_Z;
         Z52SupplierAgbKvkNumber = obj11.gxTpr_Supplieragbkvknumber_Z;
         Z332SupplierAGBAddressCountry = obj11.gxTpr_Supplieragbaddresscountry_Z;
         Z299SupplierAgbAddressCity = obj11.gxTpr_Supplieragbaddresscity_Z;
         Z298SupplierAgbAddressZipCode = obj11.gxTpr_Supplieragbaddresszipcode_Z;
         Z333SupplierAgbAddressLine1 = obj11.gxTpr_Supplieragbaddressline1_Z;
         Z334SupplierAgbAddressLine2 = obj11.gxTpr_Supplieragbaddressline2_Z;
         Z55SupplierAgbContactName = obj11.gxTpr_Supplieragbcontactname_Z;
         Z56SupplierAgbPhone = obj11.gxTpr_Supplieragbphone_Z;
         Z377SupplierAgbPhoneCode = obj11.gxTpr_Supplieragbphonecode_Z;
         Z378SupplierAgbPhoneNumber = obj11.gxTpr_Supplieragbphonenumber_Z;
         Z57SupplierAgbEmail = obj11.gxTpr_Supplieragbemail_Z;
         Z440SupplierAgbWebsite = obj11.gxTpr_Supplieragbwebsite_Z;
         n49SupplierAgbId = (bool)(Convert.ToBoolean(obj11.gxTpr_Supplieragbid_N));
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A49SupplierAgbId = (Guid)getParm(obj,0);
         n49SupplierAgbId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0711( ) ;
         ScanKeyStart0711( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z49SupplierAgbId = A49SupplierAgbId;
         }
         ZM0711( -21) ;
         OnLoadActions0711( ) ;
         AddRow0711( ) ;
         ScanKeyEnd0711( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcTrn_SupplierAgb, 0) ;
         ScanKeyStart0711( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z49SupplierAgbId = A49SupplierAgbId;
         }
         ZM0711( -21) ;
         OnLoadActions0711( ) ;
         AddRow0711( ) ;
         ScanKeyEnd0711( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0711( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0711( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A49SupplierAgbId != Z49SupplierAgbId )
               {
                  A49SupplierAgbId = Z49SupplierAgbId;
                  n49SupplierAgbId = false;
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
                  Update0711( ) ;
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
                  if ( A49SupplierAgbId != Z49SupplierAgbId )
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
                        Insert0711( ) ;
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
                        Insert0711( ) ;
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
         RowToVars11( bcTrn_SupplierAgb, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcTrn_SupplierAgb) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcTrn_SupplierAgb, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0711( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcTrn_SupplierAgb) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow11( bcTrn_SupplierAgb) ;
         }
         else
         {
            SdtTrn_SupplierAgb auxBC = new SdtTrn_SupplierAgb(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A49SupplierAgbId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierAgb);
               auxBC.Save();
               bcTrn_SupplierAgb.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars11( bcTrn_SupplierAgb, 1) ;
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
         RowToVars11( bcTrn_SupplierAgb, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0711( ) ;
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
               VarsToRow11( bcTrn_SupplierAgb) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow11( bcTrn_SupplierAgb) ;
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
         RowToVars11( bcTrn_SupplierAgb, 0) ;
         GetKey0711( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A49SupplierAgbId != Z49SupplierAgbId )
            {
               A49SupplierAgbId = Z49SupplierAgbId;
               n49SupplierAgbId = false;
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
            if ( A49SupplierAgbId != Z49SupplierAgbId )
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
         context.RollbackDataStores("trn_supplieragb_bc",pr_default);
         VarsToRow11( bcTrn_SupplierAgb) ;
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
         Gx_mode = bcTrn_SupplierAgb.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierAgb.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierAgb )
         {
            bcTrn_SupplierAgb = (SdtTrn_SupplierAgb)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierAgb.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgb.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcTrn_SupplierAgb) ;
            }
            else
            {
               RowToVars11( bcTrn_SupplierAgb, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierAgb.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgb.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcTrn_SupplierAgb, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierAgb Trn_SupplierAgb_BC
      {
         get {
            return bcTrn_SupplierAgb ;
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
            return "trn_supplieragb_Execute" ;
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
         Z49SupplierAgbId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV31Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_SupplierAgbTypeId = Guid.Empty;
         Z56SupplierAgbPhone = "";
         A56SupplierAgbPhone = "";
         Z50SupplierAgbNumber = "";
         A50SupplierAgbNumber = "";
         Z51SupplierAgbName = "";
         A51SupplierAgbName = "";
         Z52SupplierAgbKvkNumber = "";
         A52SupplierAgbKvkNumber = "";
         Z332SupplierAGBAddressCountry = "";
         A332SupplierAGBAddressCountry = "";
         Z299SupplierAgbAddressCity = "";
         A299SupplierAgbAddressCity = "";
         Z298SupplierAgbAddressZipCode = "";
         A298SupplierAgbAddressZipCode = "";
         Z333SupplierAgbAddressLine1 = "";
         A333SupplierAgbAddressLine1 = "";
         Z334SupplierAgbAddressLine2 = "";
         A334SupplierAgbAddressLine2 = "";
         Z55SupplierAgbContactName = "";
         A55SupplierAgbContactName = "";
         Z377SupplierAgbPhoneCode = "";
         A377SupplierAgbPhoneCode = "";
         Z378SupplierAgbPhoneNumber = "";
         A378SupplierAgbPhoneNumber = "";
         Z57SupplierAgbEmail = "";
         A57SupplierAgbEmail = "";
         Z440SupplierAgbWebsite = "";
         A440SupplierAgbWebsite = "";
         Z283SupplierAgbTypeId = Guid.Empty;
         A283SupplierAgbTypeId = Guid.Empty;
         Z291SupplierAgbTypeName = "";
         A291SupplierAgbTypeName = "";
         BC00075_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00075_n49SupplierAgbId = new bool[] {false} ;
         BC00075_A56SupplierAgbPhone = new string[] {""} ;
         BC00075_A50SupplierAgbNumber = new string[] {""} ;
         BC00075_A291SupplierAgbTypeName = new string[] {""} ;
         BC00075_A51SupplierAgbName = new string[] {""} ;
         BC00075_A52SupplierAgbKvkNumber = new string[] {""} ;
         BC00075_A332SupplierAGBAddressCountry = new string[] {""} ;
         BC00075_A299SupplierAgbAddressCity = new string[] {""} ;
         BC00075_A298SupplierAgbAddressZipCode = new string[] {""} ;
         BC00075_A333SupplierAgbAddressLine1 = new string[] {""} ;
         BC00075_A334SupplierAgbAddressLine2 = new string[] {""} ;
         BC00075_A55SupplierAgbContactName = new string[] {""} ;
         BC00075_A377SupplierAgbPhoneCode = new string[] {""} ;
         BC00075_A378SupplierAgbPhoneNumber = new string[] {""} ;
         BC00075_A57SupplierAgbEmail = new string[] {""} ;
         BC00075_A440SupplierAgbWebsite = new string[] {""} ;
         BC00075_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC00074_A291SupplierAgbTypeName = new string[] {""} ;
         GXt_char1 = "";
         BC00076_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00076_n49SupplierAgbId = new bool[] {false} ;
         BC00073_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00073_n49SupplierAgbId = new bool[] {false} ;
         BC00073_A56SupplierAgbPhone = new string[] {""} ;
         BC00073_A50SupplierAgbNumber = new string[] {""} ;
         BC00073_A51SupplierAgbName = new string[] {""} ;
         BC00073_A52SupplierAgbKvkNumber = new string[] {""} ;
         BC00073_A332SupplierAGBAddressCountry = new string[] {""} ;
         BC00073_A299SupplierAgbAddressCity = new string[] {""} ;
         BC00073_A298SupplierAgbAddressZipCode = new string[] {""} ;
         BC00073_A333SupplierAgbAddressLine1 = new string[] {""} ;
         BC00073_A334SupplierAgbAddressLine2 = new string[] {""} ;
         BC00073_A55SupplierAgbContactName = new string[] {""} ;
         BC00073_A377SupplierAgbPhoneCode = new string[] {""} ;
         BC00073_A378SupplierAgbPhoneNumber = new string[] {""} ;
         BC00073_A57SupplierAgbEmail = new string[] {""} ;
         BC00073_A440SupplierAgbWebsite = new string[] {""} ;
         BC00073_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         sMode11 = "";
         BC00072_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00072_n49SupplierAgbId = new bool[] {false} ;
         BC00072_A56SupplierAgbPhone = new string[] {""} ;
         BC00072_A50SupplierAgbNumber = new string[] {""} ;
         BC00072_A51SupplierAgbName = new string[] {""} ;
         BC00072_A52SupplierAgbKvkNumber = new string[] {""} ;
         BC00072_A332SupplierAGBAddressCountry = new string[] {""} ;
         BC00072_A299SupplierAgbAddressCity = new string[] {""} ;
         BC00072_A298SupplierAgbAddressZipCode = new string[] {""} ;
         BC00072_A333SupplierAgbAddressLine1 = new string[] {""} ;
         BC00072_A334SupplierAgbAddressLine2 = new string[] {""} ;
         BC00072_A55SupplierAgbContactName = new string[] {""} ;
         BC00072_A377SupplierAgbPhoneCode = new string[] {""} ;
         BC00072_A378SupplierAgbPhoneNumber = new string[] {""} ;
         BC00072_A57SupplierAgbEmail = new string[] {""} ;
         BC00072_A440SupplierAgbWebsite = new string[] {""} ;
         BC00072_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000710_A291SupplierAgbTypeName = new string[] {""} ;
         BC000711_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000711_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000711_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000712_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC000712_n49SupplierAgbId = new bool[] {false} ;
         BC000712_A56SupplierAgbPhone = new string[] {""} ;
         BC000712_A50SupplierAgbNumber = new string[] {""} ;
         BC000712_A291SupplierAgbTypeName = new string[] {""} ;
         BC000712_A51SupplierAgbName = new string[] {""} ;
         BC000712_A52SupplierAgbKvkNumber = new string[] {""} ;
         BC000712_A332SupplierAGBAddressCountry = new string[] {""} ;
         BC000712_A299SupplierAgbAddressCity = new string[] {""} ;
         BC000712_A298SupplierAgbAddressZipCode = new string[] {""} ;
         BC000712_A333SupplierAgbAddressLine1 = new string[] {""} ;
         BC000712_A334SupplierAgbAddressLine2 = new string[] {""} ;
         BC000712_A55SupplierAgbContactName = new string[] {""} ;
         BC000712_A377SupplierAgbPhoneCode = new string[] {""} ;
         BC000712_A378SupplierAgbPhoneNumber = new string[] {""} ;
         BC000712_A57SupplierAgbEmail = new string[] {""} ;
         BC000712_A440SupplierAgbWebsite = new string[] {""} ;
         BC000712_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragb_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragb_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragb_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A49SupplierAgbId, BC00072_A56SupplierAgbPhone, BC00072_A50SupplierAgbNumber, BC00072_A51SupplierAgbName, BC00072_A52SupplierAgbKvkNumber, BC00072_A332SupplierAGBAddressCountry, BC00072_A299SupplierAgbAddressCity, BC00072_A298SupplierAgbAddressZipCode, BC00072_A333SupplierAgbAddressLine1, BC00072_A334SupplierAgbAddressLine2,
               BC00072_A55SupplierAgbContactName, BC00072_A377SupplierAgbPhoneCode, BC00072_A378SupplierAgbPhoneNumber, BC00072_A57SupplierAgbEmail, BC00072_A440SupplierAgbWebsite, BC00072_A283SupplierAgbTypeId
               }
               , new Object[] {
               BC00073_A49SupplierAgbId, BC00073_A56SupplierAgbPhone, BC00073_A50SupplierAgbNumber, BC00073_A51SupplierAgbName, BC00073_A52SupplierAgbKvkNumber, BC00073_A332SupplierAGBAddressCountry, BC00073_A299SupplierAgbAddressCity, BC00073_A298SupplierAgbAddressZipCode, BC00073_A333SupplierAgbAddressLine1, BC00073_A334SupplierAgbAddressLine2,
               BC00073_A55SupplierAgbContactName, BC00073_A377SupplierAgbPhoneCode, BC00073_A378SupplierAgbPhoneNumber, BC00073_A57SupplierAgbEmail, BC00073_A440SupplierAgbWebsite, BC00073_A283SupplierAgbTypeId
               }
               , new Object[] {
               BC00074_A291SupplierAgbTypeName
               }
               , new Object[] {
               BC00075_A49SupplierAgbId, BC00075_A56SupplierAgbPhone, BC00075_A50SupplierAgbNumber, BC00075_A291SupplierAgbTypeName, BC00075_A51SupplierAgbName, BC00075_A52SupplierAgbKvkNumber, BC00075_A332SupplierAGBAddressCountry, BC00075_A299SupplierAgbAddressCity, BC00075_A298SupplierAgbAddressZipCode, BC00075_A333SupplierAgbAddressLine1,
               BC00075_A334SupplierAgbAddressLine2, BC00075_A55SupplierAgbContactName, BC00075_A377SupplierAgbPhoneCode, BC00075_A378SupplierAgbPhoneNumber, BC00075_A57SupplierAgbEmail, BC00075_A440SupplierAgbWebsite, BC00075_A283SupplierAgbTypeId
               }
               , new Object[] {
               BC00076_A49SupplierAgbId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A291SupplierAgbTypeName
               }
               , new Object[] {
               BC000711_A58ProductServiceId, BC000711_A29LocationId, BC000711_A11OrganisationId
               }
               , new Object[] {
               BC000712_A49SupplierAgbId, BC000712_A56SupplierAgbPhone, BC000712_A50SupplierAgbNumber, BC000712_A291SupplierAgbTypeName, BC000712_A51SupplierAgbName, BC000712_A52SupplierAgbKvkNumber, BC000712_A332SupplierAGBAddressCountry, BC000712_A299SupplierAgbAddressCity, BC000712_A298SupplierAgbAddressZipCode, BC000712_A333SupplierAgbAddressLine1,
               BC000712_A334SupplierAgbAddressLine2, BC000712_A55SupplierAgbContactName, BC000712_A377SupplierAgbPhoneCode, BC000712_A378SupplierAgbPhoneNumber, BC000712_A57SupplierAgbEmail, BC000712_A440SupplierAgbWebsite, BC000712_A283SupplierAgbTypeId
               }
            }
         );
         Z49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         A49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         AV31Pgmname = "Trn_SupplierAgb_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private int trnEnded ;
      private int AV32GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV31Pgmname ;
      private string Z56SupplierAgbPhone ;
      private string A56SupplierAgbPhone ;
      private string GXt_char1 ;
      private string sMode11 ;
      private bool returnInSub ;
      private bool n49SupplierAgbId ;
      private bool Gx_longc ;
      private string Z50SupplierAgbNumber ;
      private string A50SupplierAgbNumber ;
      private string Z51SupplierAgbName ;
      private string A51SupplierAgbName ;
      private string Z52SupplierAgbKvkNumber ;
      private string A52SupplierAgbKvkNumber ;
      private string Z332SupplierAGBAddressCountry ;
      private string A332SupplierAGBAddressCountry ;
      private string Z299SupplierAgbAddressCity ;
      private string A299SupplierAgbAddressCity ;
      private string Z298SupplierAgbAddressZipCode ;
      private string A298SupplierAgbAddressZipCode ;
      private string Z333SupplierAgbAddressLine1 ;
      private string A333SupplierAgbAddressLine1 ;
      private string Z334SupplierAgbAddressLine2 ;
      private string A334SupplierAgbAddressLine2 ;
      private string Z55SupplierAgbContactName ;
      private string A55SupplierAgbContactName ;
      private string Z377SupplierAgbPhoneCode ;
      private string A377SupplierAgbPhoneCode ;
      private string Z378SupplierAgbPhoneNumber ;
      private string A378SupplierAgbPhoneNumber ;
      private string Z57SupplierAgbEmail ;
      private string A57SupplierAgbEmail ;
      private string Z440SupplierAgbWebsite ;
      private string A440SupplierAgbWebsite ;
      private string Z291SupplierAgbTypeName ;
      private string A291SupplierAgbTypeName ;
      private Guid Z49SupplierAgbId ;
      private Guid A49SupplierAgbId ;
      private Guid AV13Insert_SupplierAgbTypeId ;
      private Guid Z283SupplierAgbTypeId ;
      private Guid A283SupplierAgbTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00075_A49SupplierAgbId ;
      private bool[] BC00075_n49SupplierAgbId ;
      private string[] BC00075_A56SupplierAgbPhone ;
      private string[] BC00075_A50SupplierAgbNumber ;
      private string[] BC00075_A291SupplierAgbTypeName ;
      private string[] BC00075_A51SupplierAgbName ;
      private string[] BC00075_A52SupplierAgbKvkNumber ;
      private string[] BC00075_A332SupplierAGBAddressCountry ;
      private string[] BC00075_A299SupplierAgbAddressCity ;
      private string[] BC00075_A298SupplierAgbAddressZipCode ;
      private string[] BC00075_A333SupplierAgbAddressLine1 ;
      private string[] BC00075_A334SupplierAgbAddressLine2 ;
      private string[] BC00075_A55SupplierAgbContactName ;
      private string[] BC00075_A377SupplierAgbPhoneCode ;
      private string[] BC00075_A378SupplierAgbPhoneNumber ;
      private string[] BC00075_A57SupplierAgbEmail ;
      private string[] BC00075_A440SupplierAgbWebsite ;
      private Guid[] BC00075_A283SupplierAgbTypeId ;
      private string[] BC00074_A291SupplierAgbTypeName ;
      private Guid[] BC00076_A49SupplierAgbId ;
      private bool[] BC00076_n49SupplierAgbId ;
      private Guid[] BC00073_A49SupplierAgbId ;
      private bool[] BC00073_n49SupplierAgbId ;
      private string[] BC00073_A56SupplierAgbPhone ;
      private string[] BC00073_A50SupplierAgbNumber ;
      private string[] BC00073_A51SupplierAgbName ;
      private string[] BC00073_A52SupplierAgbKvkNumber ;
      private string[] BC00073_A332SupplierAGBAddressCountry ;
      private string[] BC00073_A299SupplierAgbAddressCity ;
      private string[] BC00073_A298SupplierAgbAddressZipCode ;
      private string[] BC00073_A333SupplierAgbAddressLine1 ;
      private string[] BC00073_A334SupplierAgbAddressLine2 ;
      private string[] BC00073_A55SupplierAgbContactName ;
      private string[] BC00073_A377SupplierAgbPhoneCode ;
      private string[] BC00073_A378SupplierAgbPhoneNumber ;
      private string[] BC00073_A57SupplierAgbEmail ;
      private string[] BC00073_A440SupplierAgbWebsite ;
      private Guid[] BC00073_A283SupplierAgbTypeId ;
      private Guid[] BC00072_A49SupplierAgbId ;
      private bool[] BC00072_n49SupplierAgbId ;
      private string[] BC00072_A56SupplierAgbPhone ;
      private string[] BC00072_A50SupplierAgbNumber ;
      private string[] BC00072_A51SupplierAgbName ;
      private string[] BC00072_A52SupplierAgbKvkNumber ;
      private string[] BC00072_A332SupplierAGBAddressCountry ;
      private string[] BC00072_A299SupplierAgbAddressCity ;
      private string[] BC00072_A298SupplierAgbAddressZipCode ;
      private string[] BC00072_A333SupplierAgbAddressLine1 ;
      private string[] BC00072_A334SupplierAgbAddressLine2 ;
      private string[] BC00072_A55SupplierAgbContactName ;
      private string[] BC00072_A377SupplierAgbPhoneCode ;
      private string[] BC00072_A378SupplierAgbPhoneNumber ;
      private string[] BC00072_A57SupplierAgbEmail ;
      private string[] BC00072_A440SupplierAgbWebsite ;
      private Guid[] BC00072_A283SupplierAgbTypeId ;
      private string[] BC000710_A291SupplierAgbTypeName ;
      private Guid[] BC000711_A58ProductServiceId ;
      private Guid[] BC000711_A29LocationId ;
      private Guid[] BC000711_A11OrganisationId ;
      private Guid[] BC000712_A49SupplierAgbId ;
      private bool[] BC000712_n49SupplierAgbId ;
      private string[] BC000712_A56SupplierAgbPhone ;
      private string[] BC000712_A50SupplierAgbNumber ;
      private string[] BC000712_A291SupplierAgbTypeName ;
      private string[] BC000712_A51SupplierAgbName ;
      private string[] BC000712_A52SupplierAgbKvkNumber ;
      private string[] BC000712_A332SupplierAGBAddressCountry ;
      private string[] BC000712_A299SupplierAgbAddressCity ;
      private string[] BC000712_A298SupplierAgbAddressZipCode ;
      private string[] BC000712_A333SupplierAgbAddressLine1 ;
      private string[] BC000712_A334SupplierAgbAddressLine2 ;
      private string[] BC000712_A55SupplierAgbContactName ;
      private string[] BC000712_A377SupplierAgbPhoneCode ;
      private string[] BC000712_A378SupplierAgbPhoneNumber ;
      private string[] BC000712_A57SupplierAgbEmail ;
      private string[] BC000712_A440SupplierAgbWebsite ;
      private Guid[] BC000712_A283SupplierAgbTypeId ;
      private SdtTrn_SupplierAgb bcTrn_SupplierAgb ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplieragb_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplieragb_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_supplieragb_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00072;
       prmBC00072 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00073;
       prmBC00073 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00074;
       prmBC00074 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00075;
       prmBC00075 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00076;
       prmBC00076 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00077;
       prmBC00077 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierAgbPhone",GXType.Char,20,0) ,
       new ParDef("SupplierAgbNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierAgbName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierAGBAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierAgbPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierAgbEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00078;
       prmBC00078 = new Object[] {
       new ParDef("SupplierAgbPhone",GXType.Char,20,0) ,
       new ParDef("SupplierAgbNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierAgbName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierAGBAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierAgbPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierAgbEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00079;
       prmBC00079 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000710;
       prmBC000710 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000711;
       prmBC000711 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000712;
       prmBC000712 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00072", "SELECT SupplierAgbId, SupplierAgbPhone, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAGBAddressCountry, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhoneCode, SupplierAgbPhoneNumber, SupplierAgbEmail, SupplierAgbWebsite, SupplierAgbTypeId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId  FOR UPDATE OF Trn_SupplierAGB",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00073", "SELECT SupplierAgbId, SupplierAgbPhone, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAGBAddressCountry, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhoneCode, SupplierAgbPhoneNumber, SupplierAgbEmail, SupplierAgbWebsite, SupplierAgbTypeId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00074", "SELECT SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00075", "SELECT TM1.SupplierAgbId, TM1.SupplierAgbPhone, TM1.SupplierAgbNumber, T2.SupplierAgbTypeName, TM1.SupplierAgbName, TM1.SupplierAgbKvkNumber, TM1.SupplierAGBAddressCountry, TM1.SupplierAgbAddressCity, TM1.SupplierAgbAddressZipCode, TM1.SupplierAgbAddressLine1, TM1.SupplierAgbAddressLine2, TM1.SupplierAgbContactName, TM1.SupplierAgbPhoneCode, TM1.SupplierAgbPhoneNumber, TM1.SupplierAgbEmail, TM1.SupplierAgbWebsite, TM1.SupplierAgbTypeId FROM (Trn_SupplierAGB TM1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = TM1.SupplierAgbTypeId) WHERE TM1.SupplierAgbId = :SupplierAgbId ORDER BY TM1.SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00076", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00077", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierAGB(SupplierAgbId, SupplierAgbPhone, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAGBAddressCountry, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhoneCode, SupplierAgbPhoneNumber, SupplierAgbEmail, SupplierAgbWebsite, SupplierAgbTypeId) VALUES(:SupplierAgbId, :SupplierAgbPhone, :SupplierAgbNumber, :SupplierAgbName, :SupplierAgbKvkNumber, :SupplierAGBAddressCountry, :SupplierAgbAddressCity, :SupplierAgbAddressZipCode, :SupplierAgbAddressLine1, :SupplierAgbAddressLine2, :SupplierAgbContactName, :SupplierAgbPhoneCode, :SupplierAgbPhoneNumber, :SupplierAgbEmail, :SupplierAgbWebsite, :SupplierAgbTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00077)
          ,new CursorDef("BC00078", "SAVEPOINT gxupdate;UPDATE Trn_SupplierAGB SET SupplierAgbPhone=:SupplierAgbPhone, SupplierAgbNumber=:SupplierAgbNumber, SupplierAgbName=:SupplierAgbName, SupplierAgbKvkNumber=:SupplierAgbKvkNumber, SupplierAGBAddressCountry=:SupplierAGBAddressCountry, SupplierAgbAddressCity=:SupplierAgbAddressCity, SupplierAgbAddressZipCode=:SupplierAgbAddressZipCode, SupplierAgbAddressLine1=:SupplierAgbAddressLine1, SupplierAgbAddressLine2=:SupplierAgbAddressLine2, SupplierAgbContactName=:SupplierAgbContactName, SupplierAgbPhoneCode=:SupplierAgbPhoneCode, SupplierAgbPhoneNumber=:SupplierAgbPhoneNumber, SupplierAgbEmail=:SupplierAgbEmail, SupplierAgbWebsite=:SupplierAgbWebsite, SupplierAgbTypeId=:SupplierAgbTypeId  WHERE SupplierAgbId = :SupplierAgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00078)
          ,new CursorDef("BC00079", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierAGB  WHERE SupplierAgbId = :SupplierAgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00079)
          ,new CursorDef("BC000710", "SELECT SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000711", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000712", "SELECT TM1.SupplierAgbId, TM1.SupplierAgbPhone, TM1.SupplierAgbNumber, T2.SupplierAgbTypeName, TM1.SupplierAgbName, TM1.SupplierAgbKvkNumber, TM1.SupplierAGBAddressCountry, TM1.SupplierAgbAddressCity, TM1.SupplierAgbAddressZipCode, TM1.SupplierAgbAddressLine1, TM1.SupplierAgbAddressLine2, TM1.SupplierAgbContactName, TM1.SupplierAgbPhoneCode, TM1.SupplierAgbPhoneNumber, TM1.SupplierAgbEmail, TM1.SupplierAgbWebsite, TM1.SupplierAgbTypeId FROM (Trn_SupplierAGB TM1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = TM1.SupplierAgbTypeId) WHERE TM1.SupplierAgbId = :SupplierAgbId ORDER BY TM1.SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
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
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
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
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((Guid[]) buf[16])[0] = rslt.getGuid(17);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 10 :
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
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((Guid[]) buf[16])[0] = rslt.getGuid(17);
             return;
    }
 }

}

}
