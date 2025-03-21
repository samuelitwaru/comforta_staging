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
   public class trn_location_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_location_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_location_bc( IGxContext context )
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
         ReadRow046( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey046( ) ;
         standaloneModal( ) ;
         AddRow046( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z29LocationId = A29LocationId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               if ( AnyError == 0 )
               {
                  ZM046( 22) ;
                  ZM046( 23) ;
               }
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
         AV31ReceptionDescriptionVar = context.GetMessage( "Welkom bij de receptie van onze app. Hier kunt u al uw vragen stellen en krijgt u direct hulp van ons team. Of het nu gaat om technische ondersteuning, informatie over diensten, of algemene vragen, wij zijn er om u te helpen.", "");
         imgReceptionimagevar_gximage = "ReceptionImageFile";
         AV30ReceptionImageVar = context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( ));
         AV33Receptionimagevar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( )), context);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            while ( AV35GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV26TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "Trn_ThemeId") == 0 )
               {
                  AV25Insert_Trn_ThemeId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
               }
               AV35GXV1 = (int)(AV35GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z35LocationPhone = A35LocationPhone;
            Z339LocationZipCode = A339LocationZipCode;
            Z31LocationName = A31LocationName;
            Z359LocationCountry = A359LocationCountry;
            Z338LocationCity = A338LocationCity;
            Z340LocationAddressLine1 = A340LocationAddressLine1;
            Z341LocationAddressLine2 = A341LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z383LocationPhoneCode = A383LocationPhoneCode;
            Z384LocationPhoneNumber = A384LocationPhoneNumber;
            Z596LocationHasMyCare = A596LocationHasMyCare;
            Z597LocationHasMyServices = A597LocationHasMyServices;
            Z598LocationHasMyLiving = A598LocationHasMyLiving;
            Z599LocationHasOwnBrand = A599LocationHasOwnBrand;
            Z518ToolBoxDefaultProfileImage = A518ToolBoxDefaultProfileImage;
            Z517ToolBoxDefaultLogo = A517ToolBoxDefaultLogo;
            Z601ReceptionDescription = A601ReceptionDescription;
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -21 )
         {
            Z29LocationId = A29LocationId;
            Z35LocationPhone = A35LocationPhone;
            Z339LocationZipCode = A339LocationZipCode;
            Z31LocationName = A31LocationName;
            Z506LocationImage = A506LocationImage;
            Z40000LocationImage_GXI = A40000LocationImage_GXI;
            Z359LocationCountry = A359LocationCountry;
            Z338LocationCity = A338LocationCity;
            Z340LocationAddressLine1 = A340LocationAddressLine1;
            Z341LocationAddressLine2 = A341LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z383LocationPhoneCode = A383LocationPhoneCode;
            Z384LocationPhoneNumber = A384LocationPhoneNumber;
            Z36LocationDescription = A36LocationDescription;
            Z594LocationBrandTheme = A594LocationBrandTheme;
            Z595LocationCtaTheme = A595LocationCtaTheme;
            Z596LocationHasMyCare = A596LocationHasMyCare;
            Z597LocationHasMyServices = A597LocationHasMyServices;
            Z598LocationHasMyLiving = A598LocationHasMyLiving;
            Z599LocationHasOwnBrand = A599LocationHasOwnBrand;
            Z518ToolBoxDefaultProfileImage = A518ToolBoxDefaultProfileImage;
            Z517ToolBoxDefaultLogo = A517ToolBoxDefaultLogo;
            Z600ReceptionImage = A600ReceptionImage;
            Z40001ReceptionImage_GXI = A40001ReceptionImage_GXI;
            Z601ReceptionDescription = A601ReceptionDescription;
            Z11OrganisationId = A11OrganisationId;
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV34Pgmname = "Trn_Location_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A29LocationId) )
         {
            A29LocationId = Guid.NewGuid( );
            n29LocationId = false;
         }
         if ( IsIns( )  && (false==A599LocationHasOwnBrand) && ( Gx_BScreen == 0 ) )
         {
            A599LocationHasOwnBrand = false;
         }
         if ( IsIns( )  && (false==A598LocationHasMyLiving) && ( Gx_BScreen == 0 ) )
         {
            A598LocationHasMyLiving = false;
         }
         if ( IsIns( )  && (false==A597LocationHasMyServices) && ( Gx_BScreen == 0 ) )
         {
            A597LocationHasMyServices = false;
         }
         if ( IsIns( )  && (false==A596LocationHasMyCare) && ( Gx_BScreen == 0 ) )
         {
            A596LocationHasMyCare = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A601ReceptionDescription)) && ( Gx_BScreen == 0 ) )
         {
            A601ReceptionDescription = AV31ReceptionDescriptionVar;
            n601ReceptionDescription = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A600ReceptionImage)) && ( Gx_BScreen == 0 ) )
         {
            A600ReceptionImage = AV30ReceptionImageVar;
            n600ReceptionImage = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load046( )
      {
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A35LocationPhone = BC00046_A35LocationPhone[0];
            A339LocationZipCode = BC00046_A339LocationZipCode[0];
            A31LocationName = BC00046_A31LocationName[0];
            A40000LocationImage_GXI = BC00046_A40000LocationImage_GXI[0];
            A359LocationCountry = BC00046_A359LocationCountry[0];
            A338LocationCity = BC00046_A338LocationCity[0];
            A340LocationAddressLine1 = BC00046_A340LocationAddressLine1[0];
            A341LocationAddressLine2 = BC00046_A341LocationAddressLine2[0];
            A34LocationEmail = BC00046_A34LocationEmail[0];
            A383LocationPhoneCode = BC00046_A383LocationPhoneCode[0];
            A384LocationPhoneNumber = BC00046_A384LocationPhoneNumber[0];
            A36LocationDescription = BC00046_A36LocationDescription[0];
            A594LocationBrandTheme = BC00046_A594LocationBrandTheme[0];
            n594LocationBrandTheme = BC00046_n594LocationBrandTheme[0];
            A595LocationCtaTheme = BC00046_A595LocationCtaTheme[0];
            n595LocationCtaTheme = BC00046_n595LocationCtaTheme[0];
            A596LocationHasMyCare = BC00046_A596LocationHasMyCare[0];
            A597LocationHasMyServices = BC00046_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = BC00046_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = BC00046_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = BC00046_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = BC00046_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = BC00046_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = BC00046_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC00046_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC00046_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = BC00046_A601ReceptionDescription[0];
            n601ReceptionDescription = BC00046_n601ReceptionDescription[0];
            A247Trn_ThemeId = BC00046_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC00046_n247Trn_ThemeId[0];
            A506LocationImage = BC00046_A506LocationImage[0];
            A600ReceptionImage = BC00046_A600ReceptionImage[0];
            n600ReceptionImage = BC00046_n600ReceptionImage[0];
            ZM046( -21) ;
         }
         pr_default.close(4);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         A339LocationZipCode = StringUtil.Upper( A339LocationZipCode);
         GXt_char1 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char1) ;
         A35LocationPhone = GXt_char1;
         if ( (Guid.Empty==A247Trn_ThemeId) )
         {
            A247Trn_ThemeId = Guid.Empty;
            n247Trn_ThemeId = false;
            n247Trn_ThemeId = true;
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid2 = A247Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid2) ;
               A247Trn_ThemeId = GXt_guid2;
               n247Trn_ThemeId = false;
            }
         }
      }

      protected void CheckExtendedTable046( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         A339LocationZipCode = StringUtil.Upper( A339LocationZipCode);
         if ( ! GxRegex.IsMatch(A339LocationZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A339LocationZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A34LocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Location Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) && ! GxRegex.IsMatch(A34LocationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Email format is invalid", ""), 1, "");
            AnyError = 1;
         }
         GXt_char1 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char1) ;
         A35LocationPhone = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A384LocationPhoneNumber)) && ! GxRegex.IsMatch(A384LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A247Trn_ThemeId) )
         {
            A247Trn_ThemeId = Guid.Empty;
            n247Trn_ThemeId = false;
            n247Trn_ThemeId = true;
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid2 = A247Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid2) ;
               A247Trn_ThemeId = GXt_guid2;
               n247Trn_ThemeId = false;
            }
         }
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A247Trn_ThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Themes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey046( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 21) ;
            RcdFound6 = 1;
            A29LocationId = BC00043_A29LocationId[0];
            n29LocationId = BC00043_n29LocationId[0];
            A35LocationPhone = BC00043_A35LocationPhone[0];
            A339LocationZipCode = BC00043_A339LocationZipCode[0];
            A31LocationName = BC00043_A31LocationName[0];
            A40000LocationImage_GXI = BC00043_A40000LocationImage_GXI[0];
            A359LocationCountry = BC00043_A359LocationCountry[0];
            A338LocationCity = BC00043_A338LocationCity[0];
            A340LocationAddressLine1 = BC00043_A340LocationAddressLine1[0];
            A341LocationAddressLine2 = BC00043_A341LocationAddressLine2[0];
            A34LocationEmail = BC00043_A34LocationEmail[0];
            A383LocationPhoneCode = BC00043_A383LocationPhoneCode[0];
            A384LocationPhoneNumber = BC00043_A384LocationPhoneNumber[0];
            A36LocationDescription = BC00043_A36LocationDescription[0];
            A594LocationBrandTheme = BC00043_A594LocationBrandTheme[0];
            n594LocationBrandTheme = BC00043_n594LocationBrandTheme[0];
            A595LocationCtaTheme = BC00043_A595LocationCtaTheme[0];
            n595LocationCtaTheme = BC00043_n595LocationCtaTheme[0];
            A596LocationHasMyCare = BC00043_A596LocationHasMyCare[0];
            A597LocationHasMyServices = BC00043_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = BC00043_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = BC00043_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = BC00043_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = BC00043_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = BC00043_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = BC00043_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC00043_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC00043_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = BC00043_A601ReceptionDescription[0];
            n601ReceptionDescription = BC00043_n601ReceptionDescription[0];
            A11OrganisationId = BC00043_A11OrganisationId[0];
            n11OrganisationId = BC00043_n11OrganisationId[0];
            A247Trn_ThemeId = BC00043_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC00043_n247Trn_ThemeId[0];
            A506LocationImage = BC00043_A506LocationImage[0];
            A600ReceptionImage = BC00043_A600ReceptionImage[0];
            n600ReceptionImage = BC00043_n600ReceptionImage[0];
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z35LocationPhone, BC00042_A35LocationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z339LocationZipCode, BC00042_A339LocationZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z31LocationName, BC00042_A31LocationName[0]) != 0 ) || ( StringUtil.StrCmp(Z359LocationCountry, BC00042_A359LocationCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z338LocationCity, BC00042_A338LocationCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z340LocationAddressLine1, BC00042_A340LocationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z341LocationAddressLine2, BC00042_A341LocationAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z34LocationEmail, BC00042_A34LocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z383LocationPhoneCode, BC00042_A383LocationPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z384LocationPhoneNumber, BC00042_A384LocationPhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z596LocationHasMyCare != BC00042_A596LocationHasMyCare[0] ) || ( Z597LocationHasMyServices != BC00042_A597LocationHasMyServices[0] ) || ( Z598LocationHasMyLiving != BC00042_A598LocationHasMyLiving[0] ) || ( Z599LocationHasOwnBrand != BC00042_A599LocationHasOwnBrand[0] ) || ( StringUtil.StrCmp(Z518ToolBoxDefaultProfileImage, BC00042_A518ToolBoxDefaultProfileImage[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z517ToolBoxDefaultLogo, BC00042_A517ToolBoxDefaultLogo[0]) != 0 ) || ( StringUtil.StrCmp(Z601ReceptionDescription, BC00042_A601ReceptionDescription[0]) != 0 ) || ( Z247Trn_ThemeId != BC00042_A247Trn_ThemeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Location"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00048 */
                     pr_default.execute(6, new Object[] {n29LocationId, A29LocationId, A35LocationPhone, A339LocationZipCode, A31LocationName, A506LocationImage, A40000LocationImage_GXI, A359LocationCountry, A338LocationCity, A340LocationAddressLine1, A341LocationAddressLine2, A34LocationEmail, A383LocationPhoneCode, A384LocationPhoneNumber, A36LocationDescription, n594LocationBrandTheme, A594LocationBrandTheme, n595LocationCtaTheme, A595LocationCtaTheme, A596LocationHasMyCare, A597LocationHasMyServices, A598LocationHasMyLiving, A599LocationHasOwnBrand, n518ToolBoxDefaultProfileImage, A518ToolBoxDefaultProfileImage, n517ToolBoxDefaultLogo, A517ToolBoxDefaultLogo, n600ReceptionImage, A600ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n601ReceptionDescription, A601ReceptionDescription, n11OrganisationId, A11OrganisationId, n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {A35LocationPhone, A339LocationZipCode, A31LocationName, A359LocationCountry, A338LocationCity, A340LocationAddressLine1, A341LocationAddressLine2, A34LocationEmail, A383LocationPhoneCode, A384LocationPhoneNumber, A36LocationDescription, n594LocationBrandTheme, A594LocationBrandTheme, n595LocationCtaTheme, A595LocationCtaTheme, A596LocationHasMyCare, A597LocationHasMyServices, A598LocationHasMyLiving, A599LocationHasOwnBrand, n518ToolBoxDefaultProfileImage, A518ToolBoxDefaultProfileImage, n517ToolBoxDefaultLogo, A517ToolBoxDefaultLogo, n601ReceptionDescription, A601ReceptionDescription, n247Trn_ThemeId, A247Trn_ThemeId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000410 */
            pr_default.execute(8, new Object[] {A506LocationImage, A40000LocationImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000411 */
            pr_default.execute(9, new Object[] {n600ReceptionImage, A600ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000412 */
                  pr_default.execute(10, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel046( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentPackage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_AppVersion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda/Calendar", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000416 */
            pr_default.execute(14, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000417 */
            pr_default.execute(15, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000418 */
            pr_default.execute(16, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Receptionists", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000419 */
            pr_default.execute(17, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
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

      public void ScanKeyStart046( )
      {
         /* Scan By routine */
         /* Using cursor BC000420 */
         pr_default.execute(18, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = BC000420_A29LocationId[0];
            n29LocationId = BC000420_n29LocationId[0];
            A35LocationPhone = BC000420_A35LocationPhone[0];
            A339LocationZipCode = BC000420_A339LocationZipCode[0];
            A31LocationName = BC000420_A31LocationName[0];
            A40000LocationImage_GXI = BC000420_A40000LocationImage_GXI[0];
            A359LocationCountry = BC000420_A359LocationCountry[0];
            A338LocationCity = BC000420_A338LocationCity[0];
            A340LocationAddressLine1 = BC000420_A340LocationAddressLine1[0];
            A341LocationAddressLine2 = BC000420_A341LocationAddressLine2[0];
            A34LocationEmail = BC000420_A34LocationEmail[0];
            A383LocationPhoneCode = BC000420_A383LocationPhoneCode[0];
            A384LocationPhoneNumber = BC000420_A384LocationPhoneNumber[0];
            A36LocationDescription = BC000420_A36LocationDescription[0];
            A594LocationBrandTheme = BC000420_A594LocationBrandTheme[0];
            n594LocationBrandTheme = BC000420_n594LocationBrandTheme[0];
            A595LocationCtaTheme = BC000420_A595LocationCtaTheme[0];
            n595LocationCtaTheme = BC000420_n595LocationCtaTheme[0];
            A596LocationHasMyCare = BC000420_A596LocationHasMyCare[0];
            A597LocationHasMyServices = BC000420_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = BC000420_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = BC000420_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = BC000420_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = BC000420_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = BC000420_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = BC000420_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC000420_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC000420_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = BC000420_A601ReceptionDescription[0];
            n601ReceptionDescription = BC000420_n601ReceptionDescription[0];
            A11OrganisationId = BC000420_A11OrganisationId[0];
            n11OrganisationId = BC000420_n11OrganisationId[0];
            A247Trn_ThemeId = BC000420_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC000420_n247Trn_ThemeId[0];
            A506LocationImage = BC000420_A506LocationImage[0];
            A600ReceptionImage = BC000420_A600ReceptionImage[0];
            n600ReceptionImage = BC000420_n600ReceptionImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound6 = 0;
         ScanKeyLoad046( ) ;
      }

      protected void ScanKeyLoad046( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = BC000420_A29LocationId[0];
            n29LocationId = BC000420_n29LocationId[0];
            A35LocationPhone = BC000420_A35LocationPhone[0];
            A339LocationZipCode = BC000420_A339LocationZipCode[0];
            A31LocationName = BC000420_A31LocationName[0];
            A40000LocationImage_GXI = BC000420_A40000LocationImage_GXI[0];
            A359LocationCountry = BC000420_A359LocationCountry[0];
            A338LocationCity = BC000420_A338LocationCity[0];
            A340LocationAddressLine1 = BC000420_A340LocationAddressLine1[0];
            A341LocationAddressLine2 = BC000420_A341LocationAddressLine2[0];
            A34LocationEmail = BC000420_A34LocationEmail[0];
            A383LocationPhoneCode = BC000420_A383LocationPhoneCode[0];
            A384LocationPhoneNumber = BC000420_A384LocationPhoneNumber[0];
            A36LocationDescription = BC000420_A36LocationDescription[0];
            A594LocationBrandTheme = BC000420_A594LocationBrandTheme[0];
            n594LocationBrandTheme = BC000420_n594LocationBrandTheme[0];
            A595LocationCtaTheme = BC000420_A595LocationCtaTheme[0];
            n595LocationCtaTheme = BC000420_n595LocationCtaTheme[0];
            A596LocationHasMyCare = BC000420_A596LocationHasMyCare[0];
            A597LocationHasMyServices = BC000420_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = BC000420_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = BC000420_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = BC000420_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = BC000420_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = BC000420_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = BC000420_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC000420_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC000420_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = BC000420_A601ReceptionDescription[0];
            n601ReceptionDescription = BC000420_n601ReceptionDescription[0];
            A11OrganisationId = BC000420_A11OrganisationId[0];
            n11OrganisationId = BC000420_n11OrganisationId[0];
            A247Trn_ThemeId = BC000420_A247Trn_ThemeId[0];
            n247Trn_ThemeId = BC000420_n247Trn_ThemeId[0];
            A506LocationImage = BC000420_A506LocationImage[0];
            A600ReceptionImage = BC000420_A600ReceptionImage[0];
            n600ReceptionImage = BC000420_n600ReceptionImage[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd046( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void AddRow046( )
      {
         VarsToRow6( bcTrn_Location) ;
      }

      protected void ReadRow046( )
      {
         RowToVars6( bcTrn_Location, 1) ;
      }

      protected void InitializeNonKey046( )
      {
         A35LocationPhone = "";
         A339LocationZipCode = "";
         A31LocationName = "";
         A506LocationImage = "";
         A40000LocationImage_GXI = "";
         A359LocationCountry = "";
         A338LocationCity = "";
         A340LocationAddressLine1 = "";
         A341LocationAddressLine2 = "";
         A34LocationEmail = "";
         A383LocationPhoneCode = "";
         A384LocationPhoneNumber = "";
         A36LocationDescription = "";
         A594LocationBrandTheme = "";
         n594LocationBrandTheme = false;
         A595LocationCtaTheme = "";
         n595LocationCtaTheme = false;
         A518ToolBoxDefaultProfileImage = "";
         n518ToolBoxDefaultProfileImage = false;
         A517ToolBoxDefaultLogo = "";
         n517ToolBoxDefaultLogo = false;
         A40001ReceptionImage_GXI = "";
         n40001ReceptionImage_GXI = false;
         A596LocationHasMyCare = false;
         A597LocationHasMyServices = false;
         A598LocationHasMyLiving = false;
         A599LocationHasOwnBrand = false;
         A600ReceptionImage = AV30ReceptionImageVar;
         n600ReceptionImage = false;
         A601ReceptionDescription = AV31ReceptionDescriptionVar;
         n601ReceptionDescription = false;
         A247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         Z35LocationPhone = "";
         Z339LocationZipCode = "";
         Z31LocationName = "";
         Z359LocationCountry = "";
         Z338LocationCity = "";
         Z340LocationAddressLine1 = "";
         Z341LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z383LocationPhoneCode = "";
         Z384LocationPhoneNumber = "";
         Z596LocationHasMyCare = false;
         Z597LocationHasMyServices = false;
         Z598LocationHasMyLiving = false;
         Z599LocationHasOwnBrand = false;
         Z518ToolBoxDefaultProfileImage = "";
         Z517ToolBoxDefaultLogo = "";
         Z601ReceptionDescription = "";
         Z247Trn_ThemeId = Guid.Empty;
      }

      protected void InitAll046( )
      {
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A599LocationHasOwnBrand = i599LocationHasOwnBrand;
         A598LocationHasMyLiving = i598LocationHasMyLiving;
         A597LocationHasMyServices = i597LocationHasMyServices;
         A596LocationHasMyCare = i596LocationHasMyCare;
         A601ReceptionDescription = i601ReceptionDescription;
         n601ReceptionDescription = false;
         A600ReceptionImage = i600ReceptionImage;
         n600ReceptionImage = false;
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

      public void VarsToRow6( SdtTrn_Location obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Locationphone = A35LocationPhone;
         obj6.gxTpr_Locationzipcode = A339LocationZipCode;
         obj6.gxTpr_Locationname = A31LocationName;
         obj6.gxTpr_Locationimage = A506LocationImage;
         obj6.gxTpr_Locationimage_gxi = A40000LocationImage_GXI;
         obj6.gxTpr_Locationcountry = A359LocationCountry;
         obj6.gxTpr_Locationcity = A338LocationCity;
         obj6.gxTpr_Locationaddressline1 = A340LocationAddressLine1;
         obj6.gxTpr_Locationaddressline2 = A341LocationAddressLine2;
         obj6.gxTpr_Locationemail = A34LocationEmail;
         obj6.gxTpr_Locationphonecode = A383LocationPhoneCode;
         obj6.gxTpr_Locationphonenumber = A384LocationPhoneNumber;
         obj6.gxTpr_Locationdescription = A36LocationDescription;
         obj6.gxTpr_Locationbrandtheme = A594LocationBrandTheme;
         obj6.gxTpr_Locationctatheme = A595LocationCtaTheme;
         obj6.gxTpr_Toolboxdefaultprofileimage = A518ToolBoxDefaultProfileImage;
         obj6.gxTpr_Toolboxdefaultlogo = A517ToolBoxDefaultLogo;
         obj6.gxTpr_Receptionimage_gxi = A40001ReceptionImage_GXI;
         obj6.gxTpr_Locationhasmycare = A596LocationHasMyCare;
         obj6.gxTpr_Locationhasmyservices = A597LocationHasMyServices;
         obj6.gxTpr_Locationhasmyliving = A598LocationHasMyLiving;
         obj6.gxTpr_Locationhasownbrand = A599LocationHasOwnBrand;
         obj6.gxTpr_Receptionimage = A600ReceptionImage;
         obj6.gxTpr_Receptiondescription = A601ReceptionDescription;
         obj6.gxTpr_Trn_themeid = A247Trn_ThemeId;
         obj6.gxTpr_Locationid = A29LocationId;
         obj6.gxTpr_Organisationid = A11OrganisationId;
         obj6.gxTpr_Locationid_Z = Z29LocationId;
         obj6.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj6.gxTpr_Locationname_Z = Z31LocationName;
         obj6.gxTpr_Locationcountry_Z = Z359LocationCountry;
         obj6.gxTpr_Locationcity_Z = Z338LocationCity;
         obj6.gxTpr_Locationzipcode_Z = Z339LocationZipCode;
         obj6.gxTpr_Locationaddressline1_Z = Z340LocationAddressLine1;
         obj6.gxTpr_Locationaddressline2_Z = Z341LocationAddressLine2;
         obj6.gxTpr_Locationemail_Z = Z34LocationEmail;
         obj6.gxTpr_Locationphonecode_Z = Z383LocationPhoneCode;
         obj6.gxTpr_Locationphonenumber_Z = Z384LocationPhoneNumber;
         obj6.gxTpr_Locationphone_Z = Z35LocationPhone;
         obj6.gxTpr_Locationhasmycare_Z = Z596LocationHasMyCare;
         obj6.gxTpr_Locationhasmyservices_Z = Z597LocationHasMyServices;
         obj6.gxTpr_Locationhasmyliving_Z = Z598LocationHasMyLiving;
         obj6.gxTpr_Locationhasownbrand_Z = Z599LocationHasOwnBrand;
         obj6.gxTpr_Toolboxdefaultprofileimage_Z = Z518ToolBoxDefaultProfileImage;
         obj6.gxTpr_Toolboxdefaultlogo_Z = Z517ToolBoxDefaultLogo;
         obj6.gxTpr_Receptiondescription_Z = Z601ReceptionDescription;
         obj6.gxTpr_Trn_themeid_Z = Z247Trn_ThemeId;
         obj6.gxTpr_Locationimage_gxi_Z = Z40000LocationImage_GXI;
         obj6.gxTpr_Receptionimage_gxi_Z = Z40001ReceptionImage_GXI;
         obj6.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj6.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj6.gxTpr_Locationbrandtheme_N = (short)(Convert.ToInt16(n594LocationBrandTheme));
         obj6.gxTpr_Locationctatheme_N = (short)(Convert.ToInt16(n595LocationCtaTheme));
         obj6.gxTpr_Toolboxdefaultprofileimage_N = (short)(Convert.ToInt16(n518ToolBoxDefaultProfileImage));
         obj6.gxTpr_Toolboxdefaultlogo_N = (short)(Convert.ToInt16(n517ToolBoxDefaultLogo));
         obj6.gxTpr_Receptionimage_N = (short)(Convert.ToInt16(n600ReceptionImage));
         obj6.gxTpr_Receptiondescription_N = (short)(Convert.ToInt16(n601ReceptionDescription));
         obj6.gxTpr_Trn_themeid_N = (short)(Convert.ToInt16(n247Trn_ThemeId));
         obj6.gxTpr_Receptionimage_gxi_N = (short)(Convert.ToInt16(n40001ReceptionImage_GXI));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtTrn_Location obj6 )
      {
         obj6.gxTpr_Locationid = A29LocationId;
         obj6.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars6( SdtTrn_Location obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A35LocationPhone = obj6.gxTpr_Locationphone;
         A339LocationZipCode = obj6.gxTpr_Locationzipcode;
         A31LocationName = obj6.gxTpr_Locationname;
         A506LocationImage = obj6.gxTpr_Locationimage;
         A40000LocationImage_GXI = obj6.gxTpr_Locationimage_gxi;
         A359LocationCountry = obj6.gxTpr_Locationcountry;
         A338LocationCity = obj6.gxTpr_Locationcity;
         A340LocationAddressLine1 = obj6.gxTpr_Locationaddressline1;
         A341LocationAddressLine2 = obj6.gxTpr_Locationaddressline2;
         A34LocationEmail = obj6.gxTpr_Locationemail;
         A383LocationPhoneCode = obj6.gxTpr_Locationphonecode;
         A384LocationPhoneNumber = obj6.gxTpr_Locationphonenumber;
         A36LocationDescription = obj6.gxTpr_Locationdescription;
         A594LocationBrandTheme = obj6.gxTpr_Locationbrandtheme;
         n594LocationBrandTheme = false;
         A595LocationCtaTheme = obj6.gxTpr_Locationctatheme;
         n595LocationCtaTheme = false;
         A518ToolBoxDefaultProfileImage = obj6.gxTpr_Toolboxdefaultprofileimage;
         n518ToolBoxDefaultProfileImage = false;
         A517ToolBoxDefaultLogo = obj6.gxTpr_Toolboxdefaultlogo;
         n517ToolBoxDefaultLogo = false;
         A40001ReceptionImage_GXI = obj6.gxTpr_Receptionimage_gxi;
         n40001ReceptionImage_GXI = false;
         A596LocationHasMyCare = obj6.gxTpr_Locationhasmycare;
         A597LocationHasMyServices = obj6.gxTpr_Locationhasmyservices;
         A598LocationHasMyLiving = obj6.gxTpr_Locationhasmyliving;
         A599LocationHasOwnBrand = obj6.gxTpr_Locationhasownbrand;
         A600ReceptionImage = obj6.gxTpr_Receptionimage;
         n600ReceptionImage = false;
         A601ReceptionDescription = obj6.gxTpr_Receptiondescription;
         n601ReceptionDescription = false;
         A247Trn_ThemeId = obj6.gxTpr_Trn_themeid;
         n247Trn_ThemeId = false;
         A29LocationId = obj6.gxTpr_Locationid;
         n29LocationId = false;
         A11OrganisationId = obj6.gxTpr_Organisationid;
         n11OrganisationId = false;
         Z29LocationId = obj6.gxTpr_Locationid_Z;
         Z11OrganisationId = obj6.gxTpr_Organisationid_Z;
         Z31LocationName = obj6.gxTpr_Locationname_Z;
         Z359LocationCountry = obj6.gxTpr_Locationcountry_Z;
         Z338LocationCity = obj6.gxTpr_Locationcity_Z;
         Z339LocationZipCode = obj6.gxTpr_Locationzipcode_Z;
         Z340LocationAddressLine1 = obj6.gxTpr_Locationaddressline1_Z;
         Z341LocationAddressLine2 = obj6.gxTpr_Locationaddressline2_Z;
         Z34LocationEmail = obj6.gxTpr_Locationemail_Z;
         Z383LocationPhoneCode = obj6.gxTpr_Locationphonecode_Z;
         Z384LocationPhoneNumber = obj6.gxTpr_Locationphonenumber_Z;
         Z35LocationPhone = obj6.gxTpr_Locationphone_Z;
         Z596LocationHasMyCare = obj6.gxTpr_Locationhasmycare_Z;
         Z597LocationHasMyServices = obj6.gxTpr_Locationhasmyservices_Z;
         Z598LocationHasMyLiving = obj6.gxTpr_Locationhasmyliving_Z;
         Z599LocationHasOwnBrand = obj6.gxTpr_Locationhasownbrand_Z;
         Z518ToolBoxDefaultProfileImage = obj6.gxTpr_Toolboxdefaultprofileimage_Z;
         Z517ToolBoxDefaultLogo = obj6.gxTpr_Toolboxdefaultlogo_Z;
         Z601ReceptionDescription = obj6.gxTpr_Receptiondescription_Z;
         Z247Trn_ThemeId = obj6.gxTpr_Trn_themeid_Z;
         Z40000LocationImage_GXI = obj6.gxTpr_Locationimage_gxi_Z;
         Z40001ReceptionImage_GXI = obj6.gxTpr_Receptionimage_gxi_Z;
         n29LocationId = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj6.gxTpr_Organisationid_N));
         n594LocationBrandTheme = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationbrandtheme_N));
         n595LocationCtaTheme = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationctatheme_N));
         n518ToolBoxDefaultProfileImage = (bool)(Convert.ToBoolean(obj6.gxTpr_Toolboxdefaultprofileimage_N));
         n517ToolBoxDefaultLogo = (bool)(Convert.ToBoolean(obj6.gxTpr_Toolboxdefaultlogo_N));
         n600ReceptionImage = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptionimage_N));
         n601ReceptionDescription = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptiondescription_N));
         n247Trn_ThemeId = (bool)(Convert.ToBoolean(obj6.gxTpr_Trn_themeid_N));
         n40001ReceptionImage_GXI = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptionimage_gxi_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A29LocationId = (Guid)getParm(obj,0);
         n29LocationId = false;
         A11OrganisationId = (Guid)getParm(obj,1);
         n11OrganisationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey046( ) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000421 */
            pr_default.execute(19, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(19) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(19);
         }
         else
         {
            Gx_mode = "UPD";
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM046( -21) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcTrn_Location, 0) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000421 */
            pr_default.execute(19, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(19) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(19);
         }
         else
         {
            Gx_mode = "UPD";
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM046( -21) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert046( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A29LocationId = Z29LocationId;
                  n29LocationId = false;
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
                  Update046( ) ;
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
                  if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert046( ) ;
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
                        Insert046( ) ;
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
         RowToVars6( bcTrn_Location, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcTrn_Location) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcTrn_Location) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcTrn_Location) ;
         }
         else
         {
            SdtTrn_Location auxBC = new SdtTrn_Location(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Location);
               auxBC.Save();
               bcTrn_Location.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcTrn_Location, 1) ;
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
         RowToVars6( bcTrn_Location, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
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
               VarsToRow6( bcTrn_Location) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcTrn_Location) ;
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
         RowToVars6( bcTrn_Location, 0) ;
         GetKey046( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A29LocationId = Z29LocationId;
               n29LocationId = false;
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
            if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_location_bc",pr_default);
         VarsToRow6( bcTrn_Location) ;
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
         Gx_mode = bcTrn_Location.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Location.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Location )
         {
            bcTrn_Location = (SdtTrn_Location)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Location.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Location.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcTrn_Location) ;
            }
            else
            {
               RowToVars6( bcTrn_Location, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Location.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Location.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcTrn_Location, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Location Trn_Location_BC
      {
         get {
            return bcTrn_Location ;
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
            return "trn_location_Execute" ;
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
         pr_default.close(19);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV31ReceptionDescriptionVar = "";
         AV30ReceptionImageVar = "";
         imgReceptionimagevar_gximage = "";
         AV33Receptionimagevar_GXI = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV34Pgmname = "";
         AV26TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV25Insert_Trn_ThemeId = Guid.Empty;
         Z35LocationPhone = "";
         A35LocationPhone = "";
         Z339LocationZipCode = "";
         A339LocationZipCode = "";
         Z31LocationName = "";
         A31LocationName = "";
         Z359LocationCountry = "";
         A359LocationCountry = "";
         Z338LocationCity = "";
         A338LocationCity = "";
         Z340LocationAddressLine1 = "";
         A340LocationAddressLine1 = "";
         Z341LocationAddressLine2 = "";
         A341LocationAddressLine2 = "";
         Z34LocationEmail = "";
         A34LocationEmail = "";
         Z383LocationPhoneCode = "";
         A383LocationPhoneCode = "";
         Z384LocationPhoneNumber = "";
         A384LocationPhoneNumber = "";
         Z518ToolBoxDefaultProfileImage = "";
         A518ToolBoxDefaultProfileImage = "";
         Z517ToolBoxDefaultLogo = "";
         A517ToolBoxDefaultLogo = "";
         Z601ReceptionDescription = "";
         A601ReceptionDescription = "";
         Z247Trn_ThemeId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         Z506LocationImage = "";
         A506LocationImage = "";
         Z40000LocationImage_GXI = "";
         A40000LocationImage_GXI = "";
         Z36LocationDescription = "";
         A36LocationDescription = "";
         Z594LocationBrandTheme = "";
         A594LocationBrandTheme = "";
         Z595LocationCtaTheme = "";
         A595LocationCtaTheme = "";
         Z600ReceptionImage = "";
         A600ReceptionImage = "";
         Z40001ReceptionImage_GXI = "";
         A40001ReceptionImage_GXI = "";
         BC00046_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00046_n29LocationId = new bool[] {false} ;
         BC00046_A35LocationPhone = new string[] {""} ;
         BC00046_A339LocationZipCode = new string[] {""} ;
         BC00046_A31LocationName = new string[] {""} ;
         BC00046_A40000LocationImage_GXI = new string[] {""} ;
         BC00046_A359LocationCountry = new string[] {""} ;
         BC00046_A338LocationCity = new string[] {""} ;
         BC00046_A340LocationAddressLine1 = new string[] {""} ;
         BC00046_A341LocationAddressLine2 = new string[] {""} ;
         BC00046_A34LocationEmail = new string[] {""} ;
         BC00046_A383LocationPhoneCode = new string[] {""} ;
         BC00046_A384LocationPhoneNumber = new string[] {""} ;
         BC00046_A36LocationDescription = new string[] {""} ;
         BC00046_A594LocationBrandTheme = new string[] {""} ;
         BC00046_n594LocationBrandTheme = new bool[] {false} ;
         BC00046_A595LocationCtaTheme = new string[] {""} ;
         BC00046_n595LocationCtaTheme = new bool[] {false} ;
         BC00046_A596LocationHasMyCare = new bool[] {false} ;
         BC00046_A597LocationHasMyServices = new bool[] {false} ;
         BC00046_A598LocationHasMyLiving = new bool[] {false} ;
         BC00046_A599LocationHasOwnBrand = new bool[] {false} ;
         BC00046_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00046_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00046_A517ToolBoxDefaultLogo = new string[] {""} ;
         BC00046_n517ToolBoxDefaultLogo = new bool[] {false} ;
         BC00046_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00046_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00046_A601ReceptionDescription = new string[] {""} ;
         BC00046_n601ReceptionDescription = new bool[] {false} ;
         BC00046_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00046_n11OrganisationId = new bool[] {false} ;
         BC00046_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00046_n247Trn_ThemeId = new bool[] {false} ;
         BC00046_A506LocationImage = new string[] {""} ;
         BC00046_A600ReceptionImage = new string[] {""} ;
         BC00046_n600ReceptionImage = new bool[] {false} ;
         BC00044_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00044_n11OrganisationId = new bool[] {false} ;
         GXt_char1 = "";
         GXt_guid2 = Guid.Empty;
         BC00045_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00045_n247Trn_ThemeId = new bool[] {false} ;
         BC00047_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00047_n29LocationId = new bool[] {false} ;
         BC00047_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00047_n11OrganisationId = new bool[] {false} ;
         BC00043_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00043_n29LocationId = new bool[] {false} ;
         BC00043_A35LocationPhone = new string[] {""} ;
         BC00043_A339LocationZipCode = new string[] {""} ;
         BC00043_A31LocationName = new string[] {""} ;
         BC00043_A40000LocationImage_GXI = new string[] {""} ;
         BC00043_A359LocationCountry = new string[] {""} ;
         BC00043_A338LocationCity = new string[] {""} ;
         BC00043_A340LocationAddressLine1 = new string[] {""} ;
         BC00043_A341LocationAddressLine2 = new string[] {""} ;
         BC00043_A34LocationEmail = new string[] {""} ;
         BC00043_A383LocationPhoneCode = new string[] {""} ;
         BC00043_A384LocationPhoneNumber = new string[] {""} ;
         BC00043_A36LocationDescription = new string[] {""} ;
         BC00043_A594LocationBrandTheme = new string[] {""} ;
         BC00043_n594LocationBrandTheme = new bool[] {false} ;
         BC00043_A595LocationCtaTheme = new string[] {""} ;
         BC00043_n595LocationCtaTheme = new bool[] {false} ;
         BC00043_A596LocationHasMyCare = new bool[] {false} ;
         BC00043_A597LocationHasMyServices = new bool[] {false} ;
         BC00043_A598LocationHasMyLiving = new bool[] {false} ;
         BC00043_A599LocationHasOwnBrand = new bool[] {false} ;
         BC00043_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00043_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00043_A517ToolBoxDefaultLogo = new string[] {""} ;
         BC00043_n517ToolBoxDefaultLogo = new bool[] {false} ;
         BC00043_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00043_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00043_A601ReceptionDescription = new string[] {""} ;
         BC00043_n601ReceptionDescription = new bool[] {false} ;
         BC00043_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00043_n11OrganisationId = new bool[] {false} ;
         BC00043_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00043_n247Trn_ThemeId = new bool[] {false} ;
         BC00043_A506LocationImage = new string[] {""} ;
         BC00043_A600ReceptionImage = new string[] {""} ;
         BC00043_n600ReceptionImage = new bool[] {false} ;
         sMode6 = "";
         BC00042_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00042_n29LocationId = new bool[] {false} ;
         BC00042_A35LocationPhone = new string[] {""} ;
         BC00042_A339LocationZipCode = new string[] {""} ;
         BC00042_A31LocationName = new string[] {""} ;
         BC00042_A40000LocationImage_GXI = new string[] {""} ;
         BC00042_A359LocationCountry = new string[] {""} ;
         BC00042_A338LocationCity = new string[] {""} ;
         BC00042_A340LocationAddressLine1 = new string[] {""} ;
         BC00042_A341LocationAddressLine2 = new string[] {""} ;
         BC00042_A34LocationEmail = new string[] {""} ;
         BC00042_A383LocationPhoneCode = new string[] {""} ;
         BC00042_A384LocationPhoneNumber = new string[] {""} ;
         BC00042_A36LocationDescription = new string[] {""} ;
         BC00042_A594LocationBrandTheme = new string[] {""} ;
         BC00042_n594LocationBrandTheme = new bool[] {false} ;
         BC00042_A595LocationCtaTheme = new string[] {""} ;
         BC00042_n595LocationCtaTheme = new bool[] {false} ;
         BC00042_A596LocationHasMyCare = new bool[] {false} ;
         BC00042_A597LocationHasMyServices = new bool[] {false} ;
         BC00042_A598LocationHasMyLiving = new bool[] {false} ;
         BC00042_A599LocationHasOwnBrand = new bool[] {false} ;
         BC00042_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00042_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00042_A517ToolBoxDefaultLogo = new string[] {""} ;
         BC00042_n517ToolBoxDefaultLogo = new bool[] {false} ;
         BC00042_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00042_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00042_A601ReceptionDescription = new string[] {""} ;
         BC00042_n601ReceptionDescription = new bool[] {false} ;
         BC00042_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00042_n11OrganisationId = new bool[] {false} ;
         BC00042_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00042_n247Trn_ThemeId = new bool[] {false} ;
         BC00042_A506LocationImage = new string[] {""} ;
         BC00042_A600ReceptionImage = new string[] {""} ;
         BC00042_n600ReceptionImage = new bool[] {false} ;
         BC000413_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC000414_A543AppVersionId = new Guid[] {Guid.Empty} ;
         BC000415_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000416_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC000416_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000416_n11OrganisationId = new bool[] {false} ;
         BC000416_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000416_n29LocationId = new bool[] {false} ;
         BC000417_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000417_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000417_n29LocationId = new bool[] {false} ;
         BC000417_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000417_n11OrganisationId = new bool[] {false} ;
         BC000418_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000418_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000418_n11OrganisationId = new bool[] {false} ;
         BC000418_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000418_n29LocationId = new bool[] {false} ;
         BC000419_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000419_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000419_n29LocationId = new bool[] {false} ;
         BC000419_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000419_n11OrganisationId = new bool[] {false} ;
         BC000420_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000420_n29LocationId = new bool[] {false} ;
         BC000420_A35LocationPhone = new string[] {""} ;
         BC000420_A339LocationZipCode = new string[] {""} ;
         BC000420_A31LocationName = new string[] {""} ;
         BC000420_A40000LocationImage_GXI = new string[] {""} ;
         BC000420_A359LocationCountry = new string[] {""} ;
         BC000420_A338LocationCity = new string[] {""} ;
         BC000420_A340LocationAddressLine1 = new string[] {""} ;
         BC000420_A341LocationAddressLine2 = new string[] {""} ;
         BC000420_A34LocationEmail = new string[] {""} ;
         BC000420_A383LocationPhoneCode = new string[] {""} ;
         BC000420_A384LocationPhoneNumber = new string[] {""} ;
         BC000420_A36LocationDescription = new string[] {""} ;
         BC000420_A594LocationBrandTheme = new string[] {""} ;
         BC000420_n594LocationBrandTheme = new bool[] {false} ;
         BC000420_A595LocationCtaTheme = new string[] {""} ;
         BC000420_n595LocationCtaTheme = new bool[] {false} ;
         BC000420_A596LocationHasMyCare = new bool[] {false} ;
         BC000420_A597LocationHasMyServices = new bool[] {false} ;
         BC000420_A598LocationHasMyLiving = new bool[] {false} ;
         BC000420_A599LocationHasOwnBrand = new bool[] {false} ;
         BC000420_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         BC000420_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC000420_A517ToolBoxDefaultLogo = new string[] {""} ;
         BC000420_n517ToolBoxDefaultLogo = new bool[] {false} ;
         BC000420_A40001ReceptionImage_GXI = new string[] {""} ;
         BC000420_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC000420_A601ReceptionDescription = new string[] {""} ;
         BC000420_n601ReceptionDescription = new bool[] {false} ;
         BC000420_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000420_n11OrganisationId = new bool[] {false} ;
         BC000420_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000420_n247Trn_ThemeId = new bool[] {false} ;
         BC000420_A506LocationImage = new string[] {""} ;
         BC000420_A600ReceptionImage = new string[] {""} ;
         BC000420_n600ReceptionImage = new bool[] {false} ;
         i601ReceptionDescription = "";
         i600ReceptionImage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000421_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000421_n11OrganisationId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A29LocationId, BC00042_A35LocationPhone, BC00042_A339LocationZipCode, BC00042_A31LocationName, BC00042_A40000LocationImage_GXI, BC00042_A359LocationCountry, BC00042_A338LocationCity, BC00042_A340LocationAddressLine1, BC00042_A341LocationAddressLine2, BC00042_A34LocationEmail,
               BC00042_A383LocationPhoneCode, BC00042_A384LocationPhoneNumber, BC00042_A36LocationDescription, BC00042_A594LocationBrandTheme, BC00042_n594LocationBrandTheme, BC00042_A595LocationCtaTheme, BC00042_n595LocationCtaTheme, BC00042_A596LocationHasMyCare, BC00042_A597LocationHasMyServices, BC00042_A598LocationHasMyLiving,
               BC00042_A599LocationHasOwnBrand, BC00042_A518ToolBoxDefaultProfileImage, BC00042_n518ToolBoxDefaultProfileImage, BC00042_A517ToolBoxDefaultLogo, BC00042_n517ToolBoxDefaultLogo, BC00042_A40001ReceptionImage_GXI, BC00042_n40001ReceptionImage_GXI, BC00042_A601ReceptionDescription, BC00042_n601ReceptionDescription, BC00042_A11OrganisationId,
               BC00042_A247Trn_ThemeId, BC00042_n247Trn_ThemeId, BC00042_A506LocationImage, BC00042_A600ReceptionImage, BC00042_n600ReceptionImage
               }
               , new Object[] {
               BC00043_A29LocationId, BC00043_A35LocationPhone, BC00043_A339LocationZipCode, BC00043_A31LocationName, BC00043_A40000LocationImage_GXI, BC00043_A359LocationCountry, BC00043_A338LocationCity, BC00043_A340LocationAddressLine1, BC00043_A341LocationAddressLine2, BC00043_A34LocationEmail,
               BC00043_A383LocationPhoneCode, BC00043_A384LocationPhoneNumber, BC00043_A36LocationDescription, BC00043_A594LocationBrandTheme, BC00043_n594LocationBrandTheme, BC00043_A595LocationCtaTheme, BC00043_n595LocationCtaTheme, BC00043_A596LocationHasMyCare, BC00043_A597LocationHasMyServices, BC00043_A598LocationHasMyLiving,
               BC00043_A599LocationHasOwnBrand, BC00043_A518ToolBoxDefaultProfileImage, BC00043_n518ToolBoxDefaultProfileImage, BC00043_A517ToolBoxDefaultLogo, BC00043_n517ToolBoxDefaultLogo, BC00043_A40001ReceptionImage_GXI, BC00043_n40001ReceptionImage_GXI, BC00043_A601ReceptionDescription, BC00043_n601ReceptionDescription, BC00043_A11OrganisationId,
               BC00043_A247Trn_ThemeId, BC00043_n247Trn_ThemeId, BC00043_A506LocationImage, BC00043_A600ReceptionImage, BC00043_n600ReceptionImage
               }
               , new Object[] {
               BC00044_A11OrganisationId
               }
               , new Object[] {
               BC00045_A247Trn_ThemeId
               }
               , new Object[] {
               BC00046_A29LocationId, BC00046_A35LocationPhone, BC00046_A339LocationZipCode, BC00046_A31LocationName, BC00046_A40000LocationImage_GXI, BC00046_A359LocationCountry, BC00046_A338LocationCity, BC00046_A340LocationAddressLine1, BC00046_A341LocationAddressLine2, BC00046_A34LocationEmail,
               BC00046_A383LocationPhoneCode, BC00046_A384LocationPhoneNumber, BC00046_A36LocationDescription, BC00046_A594LocationBrandTheme, BC00046_n594LocationBrandTheme, BC00046_A595LocationCtaTheme, BC00046_n595LocationCtaTheme, BC00046_A596LocationHasMyCare, BC00046_A597LocationHasMyServices, BC00046_A598LocationHasMyLiving,
               BC00046_A599LocationHasOwnBrand, BC00046_A518ToolBoxDefaultProfileImage, BC00046_n518ToolBoxDefaultProfileImage, BC00046_A517ToolBoxDefaultLogo, BC00046_n517ToolBoxDefaultLogo, BC00046_A40001ReceptionImage_GXI, BC00046_n40001ReceptionImage_GXI, BC00046_A601ReceptionDescription, BC00046_n601ReceptionDescription, BC00046_A11OrganisationId,
               BC00046_A247Trn_ThemeId, BC00046_n247Trn_ThemeId, BC00046_A506LocationImage, BC00046_A600ReceptionImage, BC00046_n600ReceptionImage
               }
               , new Object[] {
               BC00047_A29LocationId, BC00047_A11OrganisationId
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
               BC000413_A554ResidentPackageId
               }
               , new Object[] {
               BC000414_A543AppVersionId
               }
               , new Object[] {
               BC000415_A303AgendaCalendarId
               }
               , new Object[] {
               BC000416_A395LocationDynamicFormId, BC000416_A11OrganisationId, BC000416_A29LocationId
               }
               , new Object[] {
               BC000417_A58ProductServiceId, BC000417_A29LocationId, BC000417_A11OrganisationId
               }
               , new Object[] {
               BC000418_A89ReceptionistId, BC000418_A11OrganisationId, BC000418_A29LocationId
               }
               , new Object[] {
               BC000419_A62ResidentId, BC000419_A29LocationId, BC000419_A11OrganisationId
               }
               , new Object[] {
               BC000420_A29LocationId, BC000420_A35LocationPhone, BC000420_A339LocationZipCode, BC000420_A31LocationName, BC000420_A40000LocationImage_GXI, BC000420_A359LocationCountry, BC000420_A338LocationCity, BC000420_A340LocationAddressLine1, BC000420_A341LocationAddressLine2, BC000420_A34LocationEmail,
               BC000420_A383LocationPhoneCode, BC000420_A384LocationPhoneNumber, BC000420_A36LocationDescription, BC000420_A594LocationBrandTheme, BC000420_n594LocationBrandTheme, BC000420_A595LocationCtaTheme, BC000420_n595LocationCtaTheme, BC000420_A596LocationHasMyCare, BC000420_A597LocationHasMyServices, BC000420_A598LocationHasMyLiving,
               BC000420_A599LocationHasOwnBrand, BC000420_A518ToolBoxDefaultProfileImage, BC000420_n518ToolBoxDefaultProfileImage, BC000420_A517ToolBoxDefaultLogo, BC000420_n517ToolBoxDefaultLogo, BC000420_A40001ReceptionImage_GXI, BC000420_n40001ReceptionImage_GXI, BC000420_A601ReceptionDescription, BC000420_n601ReceptionDescription, BC000420_A11OrganisationId,
               BC000420_A247Trn_ThemeId, BC000420_n247Trn_ThemeId, BC000420_A506LocationImage, BC000420_A600ReceptionImage, BC000420_n600ReceptionImage
               }
               , new Object[] {
               BC000421_A11OrganisationId
               }
            }
         );
         Z599LocationHasOwnBrand = false;
         A599LocationHasOwnBrand = false;
         i599LocationHasOwnBrand = false;
         Z598LocationHasMyLiving = false;
         A598LocationHasMyLiving = false;
         i598LocationHasMyLiving = false;
         Z597LocationHasMyServices = false;
         A597LocationHasMyServices = false;
         i597LocationHasMyServices = false;
         Z596LocationHasMyCare = false;
         A596LocationHasMyCare = false;
         i596LocationHasMyCare = false;
         Z29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         AV34Pgmname = "Trn_Location_BC";
         Z600ReceptionImage = "";
         n600ReceptionImage = false;
         A600ReceptionImage = "";
         n600ReceptionImage = false;
         i600ReceptionImage = "";
         n600ReceptionImage = false;
         Z601ReceptionDescription = "";
         n601ReceptionDescription = false;
         A601ReceptionDescription = "";
         n601ReceptionDescription = false;
         i601ReceptionDescription = "";
         n601ReceptionDescription = false;
         Z247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         A247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private int trnEnded ;
      private int AV35GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string imgReceptionimagevar_gximage ;
      private string AV34Pgmname ;
      private string Z35LocationPhone ;
      private string A35LocationPhone ;
      private string GXt_char1 ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool Z596LocationHasMyCare ;
      private bool A596LocationHasMyCare ;
      private bool Z597LocationHasMyServices ;
      private bool A597LocationHasMyServices ;
      private bool Z598LocationHasMyLiving ;
      private bool A598LocationHasMyLiving ;
      private bool Z599LocationHasOwnBrand ;
      private bool A599LocationHasOwnBrand ;
      private bool n29LocationId ;
      private bool n601ReceptionDescription ;
      private bool n600ReceptionImage ;
      private bool n11OrganisationId ;
      private bool n594LocationBrandTheme ;
      private bool n595LocationCtaTheme ;
      private bool n518ToolBoxDefaultProfileImage ;
      private bool n517ToolBoxDefaultLogo ;
      private bool n40001ReceptionImage_GXI ;
      private bool n247Trn_ThemeId ;
      private bool Gx_longc ;
      private bool i599LocationHasOwnBrand ;
      private bool i598LocationHasMyLiving ;
      private bool i597LocationHasMyServices ;
      private bool i596LocationHasMyCare ;
      private string Z36LocationDescription ;
      private string A36LocationDescription ;
      private string Z594LocationBrandTheme ;
      private string A594LocationBrandTheme ;
      private string Z595LocationCtaTheme ;
      private string A595LocationCtaTheme ;
      private string AV31ReceptionDescriptionVar ;
      private string AV33Receptionimagevar_GXI ;
      private string Z339LocationZipCode ;
      private string A339LocationZipCode ;
      private string Z31LocationName ;
      private string A31LocationName ;
      private string Z359LocationCountry ;
      private string A359LocationCountry ;
      private string Z338LocationCity ;
      private string A338LocationCity ;
      private string Z340LocationAddressLine1 ;
      private string A340LocationAddressLine1 ;
      private string Z341LocationAddressLine2 ;
      private string A341LocationAddressLine2 ;
      private string Z34LocationEmail ;
      private string A34LocationEmail ;
      private string Z383LocationPhoneCode ;
      private string A383LocationPhoneCode ;
      private string Z384LocationPhoneNumber ;
      private string A384LocationPhoneNumber ;
      private string Z518ToolBoxDefaultProfileImage ;
      private string A518ToolBoxDefaultProfileImage ;
      private string Z517ToolBoxDefaultLogo ;
      private string A517ToolBoxDefaultLogo ;
      private string Z601ReceptionDescription ;
      private string A601ReceptionDescription ;
      private string Z40000LocationImage_GXI ;
      private string A40000LocationImage_GXI ;
      private string Z40001ReceptionImage_GXI ;
      private string A40001ReceptionImage_GXI ;
      private string i601ReceptionDescription ;
      private string AV30ReceptionImageVar ;
      private string Z506LocationImage ;
      private string A506LocationImage ;
      private string Z600ReceptionImage ;
      private string A600ReceptionImage ;
      private string i600ReceptionImage ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV25Insert_Trn_ThemeId ;
      private Guid Z247Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid GXt_guid2 ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV26TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00046_A29LocationId ;
      private bool[] BC00046_n29LocationId ;
      private string[] BC00046_A35LocationPhone ;
      private string[] BC00046_A339LocationZipCode ;
      private string[] BC00046_A31LocationName ;
      private string[] BC00046_A40000LocationImage_GXI ;
      private string[] BC00046_A359LocationCountry ;
      private string[] BC00046_A338LocationCity ;
      private string[] BC00046_A340LocationAddressLine1 ;
      private string[] BC00046_A341LocationAddressLine2 ;
      private string[] BC00046_A34LocationEmail ;
      private string[] BC00046_A383LocationPhoneCode ;
      private string[] BC00046_A384LocationPhoneNumber ;
      private string[] BC00046_A36LocationDescription ;
      private string[] BC00046_A594LocationBrandTheme ;
      private bool[] BC00046_n594LocationBrandTheme ;
      private string[] BC00046_A595LocationCtaTheme ;
      private bool[] BC00046_n595LocationCtaTheme ;
      private bool[] BC00046_A596LocationHasMyCare ;
      private bool[] BC00046_A597LocationHasMyServices ;
      private bool[] BC00046_A598LocationHasMyLiving ;
      private bool[] BC00046_A599LocationHasOwnBrand ;
      private string[] BC00046_A518ToolBoxDefaultProfileImage ;
      private bool[] BC00046_n518ToolBoxDefaultProfileImage ;
      private string[] BC00046_A517ToolBoxDefaultLogo ;
      private bool[] BC00046_n517ToolBoxDefaultLogo ;
      private string[] BC00046_A40001ReceptionImage_GXI ;
      private bool[] BC00046_n40001ReceptionImage_GXI ;
      private string[] BC00046_A601ReceptionDescription ;
      private bool[] BC00046_n601ReceptionDescription ;
      private Guid[] BC00046_A11OrganisationId ;
      private bool[] BC00046_n11OrganisationId ;
      private Guid[] BC00046_A247Trn_ThemeId ;
      private bool[] BC00046_n247Trn_ThemeId ;
      private string[] BC00046_A506LocationImage ;
      private string[] BC00046_A600ReceptionImage ;
      private bool[] BC00046_n600ReceptionImage ;
      private Guid[] BC00044_A11OrganisationId ;
      private bool[] BC00044_n11OrganisationId ;
      private Guid[] BC00045_A247Trn_ThemeId ;
      private bool[] BC00045_n247Trn_ThemeId ;
      private Guid[] BC00047_A29LocationId ;
      private bool[] BC00047_n29LocationId ;
      private Guid[] BC00047_A11OrganisationId ;
      private bool[] BC00047_n11OrganisationId ;
      private Guid[] BC00043_A29LocationId ;
      private bool[] BC00043_n29LocationId ;
      private string[] BC00043_A35LocationPhone ;
      private string[] BC00043_A339LocationZipCode ;
      private string[] BC00043_A31LocationName ;
      private string[] BC00043_A40000LocationImage_GXI ;
      private string[] BC00043_A359LocationCountry ;
      private string[] BC00043_A338LocationCity ;
      private string[] BC00043_A340LocationAddressLine1 ;
      private string[] BC00043_A341LocationAddressLine2 ;
      private string[] BC00043_A34LocationEmail ;
      private string[] BC00043_A383LocationPhoneCode ;
      private string[] BC00043_A384LocationPhoneNumber ;
      private string[] BC00043_A36LocationDescription ;
      private string[] BC00043_A594LocationBrandTheme ;
      private bool[] BC00043_n594LocationBrandTheme ;
      private string[] BC00043_A595LocationCtaTheme ;
      private bool[] BC00043_n595LocationCtaTheme ;
      private bool[] BC00043_A596LocationHasMyCare ;
      private bool[] BC00043_A597LocationHasMyServices ;
      private bool[] BC00043_A598LocationHasMyLiving ;
      private bool[] BC00043_A599LocationHasOwnBrand ;
      private string[] BC00043_A518ToolBoxDefaultProfileImage ;
      private bool[] BC00043_n518ToolBoxDefaultProfileImage ;
      private string[] BC00043_A517ToolBoxDefaultLogo ;
      private bool[] BC00043_n517ToolBoxDefaultLogo ;
      private string[] BC00043_A40001ReceptionImage_GXI ;
      private bool[] BC00043_n40001ReceptionImage_GXI ;
      private string[] BC00043_A601ReceptionDescription ;
      private bool[] BC00043_n601ReceptionDescription ;
      private Guid[] BC00043_A11OrganisationId ;
      private bool[] BC00043_n11OrganisationId ;
      private Guid[] BC00043_A247Trn_ThemeId ;
      private bool[] BC00043_n247Trn_ThemeId ;
      private string[] BC00043_A506LocationImage ;
      private string[] BC00043_A600ReceptionImage ;
      private bool[] BC00043_n600ReceptionImage ;
      private Guid[] BC00042_A29LocationId ;
      private bool[] BC00042_n29LocationId ;
      private string[] BC00042_A35LocationPhone ;
      private string[] BC00042_A339LocationZipCode ;
      private string[] BC00042_A31LocationName ;
      private string[] BC00042_A40000LocationImage_GXI ;
      private string[] BC00042_A359LocationCountry ;
      private string[] BC00042_A338LocationCity ;
      private string[] BC00042_A340LocationAddressLine1 ;
      private string[] BC00042_A341LocationAddressLine2 ;
      private string[] BC00042_A34LocationEmail ;
      private string[] BC00042_A383LocationPhoneCode ;
      private string[] BC00042_A384LocationPhoneNumber ;
      private string[] BC00042_A36LocationDescription ;
      private string[] BC00042_A594LocationBrandTheme ;
      private bool[] BC00042_n594LocationBrandTheme ;
      private string[] BC00042_A595LocationCtaTheme ;
      private bool[] BC00042_n595LocationCtaTheme ;
      private bool[] BC00042_A596LocationHasMyCare ;
      private bool[] BC00042_A597LocationHasMyServices ;
      private bool[] BC00042_A598LocationHasMyLiving ;
      private bool[] BC00042_A599LocationHasOwnBrand ;
      private string[] BC00042_A518ToolBoxDefaultProfileImage ;
      private bool[] BC00042_n518ToolBoxDefaultProfileImage ;
      private string[] BC00042_A517ToolBoxDefaultLogo ;
      private bool[] BC00042_n517ToolBoxDefaultLogo ;
      private string[] BC00042_A40001ReceptionImage_GXI ;
      private bool[] BC00042_n40001ReceptionImage_GXI ;
      private string[] BC00042_A601ReceptionDescription ;
      private bool[] BC00042_n601ReceptionDescription ;
      private Guid[] BC00042_A11OrganisationId ;
      private bool[] BC00042_n11OrganisationId ;
      private Guid[] BC00042_A247Trn_ThemeId ;
      private bool[] BC00042_n247Trn_ThemeId ;
      private string[] BC00042_A506LocationImage ;
      private string[] BC00042_A600ReceptionImage ;
      private bool[] BC00042_n600ReceptionImage ;
      private Guid[] BC000413_A554ResidentPackageId ;
      private Guid[] BC000414_A543AppVersionId ;
      private Guid[] BC000415_A303AgendaCalendarId ;
      private Guid[] BC000416_A395LocationDynamicFormId ;
      private Guid[] BC000416_A11OrganisationId ;
      private bool[] BC000416_n11OrganisationId ;
      private Guid[] BC000416_A29LocationId ;
      private bool[] BC000416_n29LocationId ;
      private Guid[] BC000417_A58ProductServiceId ;
      private Guid[] BC000417_A29LocationId ;
      private bool[] BC000417_n29LocationId ;
      private Guid[] BC000417_A11OrganisationId ;
      private bool[] BC000417_n11OrganisationId ;
      private Guid[] BC000418_A89ReceptionistId ;
      private Guid[] BC000418_A11OrganisationId ;
      private bool[] BC000418_n11OrganisationId ;
      private Guid[] BC000418_A29LocationId ;
      private bool[] BC000418_n29LocationId ;
      private Guid[] BC000419_A62ResidentId ;
      private Guid[] BC000419_A29LocationId ;
      private bool[] BC000419_n29LocationId ;
      private Guid[] BC000419_A11OrganisationId ;
      private bool[] BC000419_n11OrganisationId ;
      private Guid[] BC000420_A29LocationId ;
      private bool[] BC000420_n29LocationId ;
      private string[] BC000420_A35LocationPhone ;
      private string[] BC000420_A339LocationZipCode ;
      private string[] BC000420_A31LocationName ;
      private string[] BC000420_A40000LocationImage_GXI ;
      private string[] BC000420_A359LocationCountry ;
      private string[] BC000420_A338LocationCity ;
      private string[] BC000420_A340LocationAddressLine1 ;
      private string[] BC000420_A341LocationAddressLine2 ;
      private string[] BC000420_A34LocationEmail ;
      private string[] BC000420_A383LocationPhoneCode ;
      private string[] BC000420_A384LocationPhoneNumber ;
      private string[] BC000420_A36LocationDescription ;
      private string[] BC000420_A594LocationBrandTheme ;
      private bool[] BC000420_n594LocationBrandTheme ;
      private string[] BC000420_A595LocationCtaTheme ;
      private bool[] BC000420_n595LocationCtaTheme ;
      private bool[] BC000420_A596LocationHasMyCare ;
      private bool[] BC000420_A597LocationHasMyServices ;
      private bool[] BC000420_A598LocationHasMyLiving ;
      private bool[] BC000420_A599LocationHasOwnBrand ;
      private string[] BC000420_A518ToolBoxDefaultProfileImage ;
      private bool[] BC000420_n518ToolBoxDefaultProfileImage ;
      private string[] BC000420_A517ToolBoxDefaultLogo ;
      private bool[] BC000420_n517ToolBoxDefaultLogo ;
      private string[] BC000420_A40001ReceptionImage_GXI ;
      private bool[] BC000420_n40001ReceptionImage_GXI ;
      private string[] BC000420_A601ReceptionDescription ;
      private bool[] BC000420_n601ReceptionDescription ;
      private Guid[] BC000420_A11OrganisationId ;
      private bool[] BC000420_n11OrganisationId ;
      private Guid[] BC000420_A247Trn_ThemeId ;
      private bool[] BC000420_n247Trn_ThemeId ;
      private string[] BC000420_A506LocationImage ;
      private string[] BC000420_A600ReceptionImage ;
      private bool[] BC000420_n600ReceptionImage ;
      private SdtTrn_Location bcTrn_Location ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000421_A11OrganisationId ;
      private bool[] BC000421_n11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_location_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_location_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_location_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00042;
       prmBC00042 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00043;
       prmBC00043 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00044;
       prmBC00044 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00045;
       prmBC00045 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00046;
       prmBC00046 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00047;
       prmBC00047 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00048;
       prmBC00048 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=22, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00049;
       prmBC00049 = new Object[] {
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000410;
       prmBC000410 = new Object[] {
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000411;
       prmBC000411 = new Object[] {
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000412;
       prmBC000412 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000413;
       prmBC000413 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000414;
       prmBC000414 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000415;
       prmBC000415 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000416;
       prmBC000416 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000417;
       prmBC000417 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000418;
       prmBC000418 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000419;
       prmBC000419 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000420;
       prmBC000420 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000421;
       prmBC000421 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00042", "SELECT LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00043", "SELECT LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00044", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00045", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00046", "SELECT TM1.LocationId, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCountry, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneCode, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00047", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00048", "SAVEPOINT gxupdate;INSERT INTO Trn_Location(LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId) VALUES(:LocationId, :LocationPhone, :LocationZipCode, :LocationName, :LocationImage, :LocationImage_GXI, :LocationCountry, :LocationCity, :LocationAddressLine1, :LocationAddressLine2, :LocationEmail, :LocationPhoneCode, :LocationPhoneNumber, :LocationDescription, :LocationBrandTheme, :LocationCtaTheme, :LocationHasMyCare, :LocationHasMyServices, :LocationHasMyLiving, :LocationHasOwnBrand, :ToolBoxDefaultProfileImage, :ToolBoxDefaultLogo, :ReceptionImage, :ReceptionImage_GXI, :ReceptionDescription, :OrganisationId, :Trn_ThemeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00048)
          ,new CursorDef("BC00049", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationPhone=:LocationPhone, LocationZipCode=:LocationZipCode, LocationName=:LocationName, LocationCountry=:LocationCountry, LocationCity=:LocationCity, LocationAddressLine1=:LocationAddressLine1, LocationAddressLine2=:LocationAddressLine2, LocationEmail=:LocationEmail, LocationPhoneCode=:LocationPhoneCode, LocationPhoneNumber=:LocationPhoneNumber, LocationDescription=:LocationDescription, LocationBrandTheme=:LocationBrandTheme, LocationCtaTheme=:LocationCtaTheme, LocationHasMyCare=:LocationHasMyCare, LocationHasMyServices=:LocationHasMyServices, LocationHasMyLiving=:LocationHasMyLiving, LocationHasOwnBrand=:LocationHasOwnBrand, ToolBoxDefaultProfileImage=:ToolBoxDefaultProfileImage, ToolBoxDefaultLogo=:ToolBoxDefaultLogo, ReceptionDescription=:ReceptionDescription, Trn_ThemeId=:Trn_ThemeId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00049)
          ,new CursorDef("BC000410", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationImage=:LocationImage, LocationImage_GXI=:LocationImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000410)
          ,new CursorDef("BC000411", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ReceptionImage=:ReceptionImage, ReceptionImage_GXI=:ReceptionImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000411)
          ,new CursorDef("BC000412", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000412)
          ,new CursorDef("BC000413", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE SG_LocationId = :LocationId AND SG_OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000414", "SELECT AppVersionId FROM Trn_AppVersion WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000415", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000416", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000417", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000417,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000418", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000418,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000419", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000419,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000420", "SELECT TM1.LocationId, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCountry, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneCode, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000420,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000421", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000421,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(5));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(5));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(5));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(5));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
