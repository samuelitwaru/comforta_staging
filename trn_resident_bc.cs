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
   public class trn_resident_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_resident_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_resident_bc( IGxContext context )
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
         ReadRow0916( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0916( ) ;
         standaloneModal( ) ;
         AddRow0916( ) ;
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
            E11092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z62ResidentId = A62ResidentId;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0916( ) ;
            }
            else
            {
               CheckExtendedTable0916( ) ;
               if ( AnyError == 0 )
               {
                  ZM0916( 33) ;
                  ZM0916( 34) ;
                  ZM0916( 35) ;
               }
               CloseExtendedTableCursors0916( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0923( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0920( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode16;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
         }
      }

      protected void CONFIRM_0920( )
      {
         nGXsfl_20_idx = 0;
         while ( nGXsfl_20_idx < bcTrn_Resident.gxTpr_Networkcompany.Count )
         {
            ReadRow0920( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound20 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_20 != 0 ) )
            {
               GetKey0920( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound20 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0920( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0920( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0920( 39) ;
                        }
                        CloseExtendedTableCursors0920( ) ;
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
                  if ( RcdFound20 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0920( ) ;
                        Load0920( ) ;
                        BeforeValidate0920( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0920( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0920( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0920( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0920( 39) ;
                              }
                              CloseExtendedTableCursors0920( ) ;
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
               VarsToRow20( ((SdtTrn_Resident_NetworkCompany)bcTrn_Resident.gxTpr_Networkcompany.Item(nGXsfl_20_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0923( )
      {
         nGXsfl_23_idx = 0;
         while ( nGXsfl_23_idx < bcTrn_Resident.gxTpr_Networkindividual.Count )
         {
            ReadRow0923( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound23 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_23 != 0 ) )
            {
               GetKey0923( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound23 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0923( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0923( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0923( 37) ;
                        }
                        CloseExtendedTableCursors0923( ) ;
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
                  if ( RcdFound23 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0923( ) ;
                        Load0923( ) ;
                        BeforeValidate0923( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0923( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_23 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0923( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0923( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0923( 37) ;
                              }
                              CloseExtendedTableCursors0923( ) ;
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
               VarsToRow23( ((SdtTrn_Resident_NetworkIndividual)bcTrn_Resident.gxTpr_Networkindividual.Item(nGXsfl_23_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV45Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV46GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV15Insert_ResidentTypeId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MedicalIndicationId") == 0 )
               {
                  AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               AV46GXV1 = (int)(AV46GXV1+1);
            }
         }
      }

      protected void E11092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV45Pgmname) ;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM0916( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z71ResidentGUID = A71ResidentGUID;
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z354ResidentCountry = A354ResidentCountry;
            Z355ResidentCity = A355ResidentCity;
            Z356ResidentZipCode = A356ResidentZipCode;
            Z357ResidentAddressLine1 = A357ResidentAddressLine1;
            Z358ResidentAddressLine2 = A358ResidentAddressLine2;
            Z444ResidentHomePhone = A444ResidentHomePhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
            Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
         }
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z97ResidentTypeName = A97ResidentTypeName;
         }
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
         if ( GX_JID == -32 )
         {
            Z62ResidentId = A62ResidentId;
            Z71ResidentGUID = A71ResidentGUID;
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z354ResidentCountry = A354ResidentCountry;
            Z355ResidentCity = A355ResidentCity;
            Z356ResidentZipCode = A356ResidentZipCode;
            Z357ResidentAddressLine1 = A357ResidentAddressLine1;
            Z358ResidentAddressLine2 = A358ResidentAddressLine2;
            Z444ResidentHomePhone = A444ResidentHomePhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
            Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV45Pgmname = "Trn_Resident_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) )
         {
            A62ResidentId = Guid.NewGuid( );
         }
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0916( )
      {
         /* Using cursor BC000913 */
         pr_default.execute(11, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound16 = 1;
            A71ResidentGUID = BC000913_A71ResidentGUID[0];
            A66ResidentInitials = BC000913_A66ResidentInitials[0];
            A70ResidentPhone = BC000913_A70ResidentPhone[0];
            A72ResidentSalutation = BC000913_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC000913_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC000913_A64ResidentGivenName[0];
            A65ResidentLastName = BC000913_A65ResidentLastName[0];
            A67ResidentEmail = BC000913_A67ResidentEmail[0];
            A68ResidentGender = BC000913_A68ResidentGender[0];
            A354ResidentCountry = BC000913_A354ResidentCountry[0];
            A355ResidentCity = BC000913_A355ResidentCity[0];
            A356ResidentZipCode = BC000913_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC000913_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC000913_A358ResidentAddressLine2[0];
            A444ResidentHomePhone = BC000913_A444ResidentHomePhone[0];
            A73ResidentBirthDate = BC000913_A73ResidentBirthDate[0];
            A97ResidentTypeName = BC000913_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC000913_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC000913_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC000913_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = BC000913_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = BC000913_A446ResidentHomePhoneNumber[0];
            A96ResidentTypeId = BC000913_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC000913_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000913_n98MedicalIndicationId[0];
            ZM0916( -32) ;
         }
         pr_default.close(11);
         OnLoadActions0916( ) ;
      }

      protected void OnLoadActions0916( )
      {
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
      }

      protected void CheckExtendedTable0916( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000910 */
         pr_default.execute(8, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(8);
         if ( ! ( ( StringUtil.StrCmp(A72ResidentSalutation, "Mr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Mrs") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Dr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Miss") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Salutation", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A63ResidentBsnNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "BSN number contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Given Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         new prc_getnameinitials(context ).execute(  A64ResidentGivenName,  A65ResidentLastName, out  A66ResidentInitials) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Last Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A67ResidentEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A68ResidentGender, "Male") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Female") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000911 */
         pr_default.execute(9, new Object[] {A96ResidentTypeId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
         }
         A97ResidentTypeName = BC000911_A97ResidentTypeName[0];
         pr_default.close(9);
         /* Using cursor BC000912 */
         pr_default.execute(10, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = BC000912_A99MedicalIndicationName[0];
         pr_default.close(10);
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A376ResidentPhoneNumber)) && ! GxRegex.IsMatch(A376ResidentPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A446ResidentHomePhoneNumber)) && ! GxRegex.IsMatch(A446ResidentHomePhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0916( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0916( )
      {
         /* Using cursor BC000914 */
         pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00099 */
         pr_default.execute(7, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0916( 32) ;
            RcdFound16 = 1;
            A62ResidentId = BC00099_A62ResidentId[0];
            A71ResidentGUID = BC00099_A71ResidentGUID[0];
            A66ResidentInitials = BC00099_A66ResidentInitials[0];
            A70ResidentPhone = BC00099_A70ResidentPhone[0];
            A72ResidentSalutation = BC00099_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC00099_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC00099_A64ResidentGivenName[0];
            A65ResidentLastName = BC00099_A65ResidentLastName[0];
            A67ResidentEmail = BC00099_A67ResidentEmail[0];
            A68ResidentGender = BC00099_A68ResidentGender[0];
            A354ResidentCountry = BC00099_A354ResidentCountry[0];
            A355ResidentCity = BC00099_A355ResidentCity[0];
            A356ResidentZipCode = BC00099_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC00099_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC00099_A358ResidentAddressLine2[0];
            A444ResidentHomePhone = BC00099_A444ResidentHomePhone[0];
            A73ResidentBirthDate = BC00099_A73ResidentBirthDate[0];
            A375ResidentPhoneCode = BC00099_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC00099_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = BC00099_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = BC00099_A446ResidentHomePhoneNumber[0];
            A29LocationId = BC00099_A29LocationId[0];
            A11OrganisationId = BC00099_A11OrganisationId[0];
            A96ResidentTypeId = BC00099_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC00099_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC00099_n98MedicalIndicationId[0];
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0916( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0916( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0916( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0916( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0916( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00098 */
            pr_default.execute(6, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z71ResidentGUID, BC00098_A71ResidentGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z66ResidentInitials, BC00098_A66ResidentInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z70ResidentPhone, BC00098_A70ResidentPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z72ResidentSalutation, BC00098_A72ResidentSalutation[0]) != 0 ) || ( StringUtil.StrCmp(Z63ResidentBsnNumber, BC00098_A63ResidentBsnNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z64ResidentGivenName, BC00098_A64ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z65ResidentLastName, BC00098_A65ResidentLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z67ResidentEmail, BC00098_A67ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z68ResidentGender, BC00098_A68ResidentGender[0]) != 0 ) || ( StringUtil.StrCmp(Z354ResidentCountry, BC00098_A354ResidentCountry[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z355ResidentCity, BC00098_A355ResidentCity[0]) != 0 ) || ( StringUtil.StrCmp(Z356ResidentZipCode, BC00098_A356ResidentZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z357ResidentAddressLine1, BC00098_A357ResidentAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z358ResidentAddressLine2, BC00098_A358ResidentAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z444ResidentHomePhone, BC00098_A444ResidentHomePhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( BC00098_A73ResidentBirthDate[0] ) ) || ( StringUtil.StrCmp(Z375ResidentPhoneCode, BC00098_A375ResidentPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z376ResidentPhoneNumber, BC00098_A376ResidentPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z445ResidentHomePhoneCode, BC00098_A445ResidentHomePhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z446ResidentHomePhoneNumber, BC00098_A446ResidentHomePhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z96ResidentTypeId != BC00098_A96ResidentTypeId[0] ) || ( Z98MedicalIndicationId != BC00098_A98MedicalIndicationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Resident"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0916( )
      {
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0916( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0916( 0) ;
            CheckOptimisticConcurrency0916( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0916( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0916( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000915 */
                     pr_default.execute(13, new Object[] {A62ResidentId, A71ResidentGUID, A66ResidentInitials, A70ResidentPhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A444ResidentHomePhone, A73ResidentBirthDate, A375ResidentPhoneCode, A376ResidentPhoneNumber, A445ResidentHomePhoneCode, A446ResidentHomePhoneNumber, A29LocationId, A11OrganisationId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(13) == 1) )
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
                           ProcessLevel0916( ) ;
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
               Load0916( ) ;
            }
            EndLevel0916( ) ;
         }
         CloseExtendedTableCursors0916( ) ;
      }

      protected void Update0916( )
      {
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0916( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0916( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0916( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0916( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000916 */
                     pr_default.execute(14, new Object[] {A71ResidentGUID, A66ResidentInitials, A70ResidentPhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A444ResidentHomePhone, A73ResidentBirthDate, A375ResidentPhoneCode, A376ResidentPhoneNumber, A445ResidentHomePhoneCode, A446ResidentHomePhoneNumber, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId, A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0916( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( IsUpd( )  )
                        {
                           new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  AV36GAMErrorResponse) ;
                        }
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0916( ) ;
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
            EndLevel0916( ) ;
         }
         CloseExtendedTableCursors0916( ) ;
      }

      protected void DeferredUpdate0916( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0916( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0916( ) ;
            AfterConfirm0916( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0916( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0923( ) ;
                  while ( RcdFound23 != 0 )
                  {
                     getByPrimaryKey0923( ) ;
                     Delete0923( ) ;
                     ScanKeyNext0923( ) ;
                  }
                  ScanKeyEnd0923( ) ;
                  ScanKeyStart0920( ) ;
                  while ( RcdFound20 != 0 )
                  {
                     getByPrimaryKey0920( ) ;
                     Delete0920( ) ;
                     ScanKeyNext0920( ) ;
                  }
                  ScanKeyEnd0920( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000917 */
                     pr_default.execute(15, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        if ( IsDlt( )  )
                        {
                           new prc_deletegamuseraccount(context ).execute(  A71ResidentGUID, out  AV36GAMErrorResponse) ;
                        }
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0916( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0916( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000918 */
            pr_default.execute(16, new Object[] {A96ResidentTypeId});
            A97ResidentTypeName = BC000918_A97ResidentTypeName[0];
            pr_default.close(16);
            /* Using cursor BC000919 */
            pr_default.execute(17, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = BC000919_A99MedicalIndicationName[0];
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0923( )
      {
         nGXsfl_23_idx = 0;
         while ( nGXsfl_23_idx < bcTrn_Resident.gxTpr_Networkindividual.Count )
         {
            ReadRow0923( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound23 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_23 != 0 ) )
            {
               standaloneNotModal0923( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0923( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0923( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0923( ) ;
                  }
               }
            }
            KeyVarsToRow23( ((SdtTrn_Resident_NetworkIndividual)bcTrn_Resident.gxTpr_Networkindividual.Item(nGXsfl_23_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_23_idx = 0;
            while ( nGXsfl_23_idx < bcTrn_Resident.gxTpr_Networkindividual.Count )
            {
               ReadRow0923( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound23 == 0 )
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
                  bcTrn_Resident.gxTpr_Networkindividual.RemoveElement(nGXsfl_23_idx);
                  nGXsfl_23_idx = (int)(nGXsfl_23_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0923( ) ;
                  VarsToRow23( ((SdtTrn_Resident_NetworkIndividual)bcTrn_Resident.gxTpr_Networkindividual.Item(nGXsfl_23_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0923( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_23 = 0;
         nIsMod_23 = 0;
      }

      protected void ProcessNestedLevel0920( )
      {
         nGXsfl_20_idx = 0;
         while ( nGXsfl_20_idx < bcTrn_Resident.gxTpr_Networkcompany.Count )
         {
            ReadRow0920( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound20 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_20 != 0 ) )
            {
               standaloneNotModal0920( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0920( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0920( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0920( ) ;
                  }
               }
            }
            KeyVarsToRow20( ((SdtTrn_Resident_NetworkCompany)bcTrn_Resident.gxTpr_Networkcompany.Item(nGXsfl_20_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_20_idx = 0;
            while ( nGXsfl_20_idx < bcTrn_Resident.gxTpr_Networkcompany.Count )
            {
               ReadRow0920( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound20 == 0 )
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
                  bcTrn_Resident.gxTpr_Networkcompany.RemoveElement(nGXsfl_20_idx);
                  nGXsfl_20_idx = (int)(nGXsfl_20_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0920( ) ;
                  VarsToRow20( ((SdtTrn_Resident_NetworkCompany)bcTrn_Resident.gxTpr_Networkcompany.Item(nGXsfl_20_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0920( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_20 = 0;
         nIsMod_20 = 0;
      }

      protected void ProcessLevel0916( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0923( ) ;
         ProcessNestedLevel0920( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         /* ' Update level parameters */
      }

      protected void EndLevel0916( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0916( ) ;
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

      public void ScanKeyStart0916( )
      {
         /* Scan By routine */
         /* Using cursor BC000920 */
         pr_default.execute(18, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = BC000920_A62ResidentId[0];
            A71ResidentGUID = BC000920_A71ResidentGUID[0];
            A66ResidentInitials = BC000920_A66ResidentInitials[0];
            A70ResidentPhone = BC000920_A70ResidentPhone[0];
            A72ResidentSalutation = BC000920_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC000920_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC000920_A64ResidentGivenName[0];
            A65ResidentLastName = BC000920_A65ResidentLastName[0];
            A67ResidentEmail = BC000920_A67ResidentEmail[0];
            A68ResidentGender = BC000920_A68ResidentGender[0];
            A354ResidentCountry = BC000920_A354ResidentCountry[0];
            A355ResidentCity = BC000920_A355ResidentCity[0];
            A356ResidentZipCode = BC000920_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC000920_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC000920_A358ResidentAddressLine2[0];
            A444ResidentHomePhone = BC000920_A444ResidentHomePhone[0];
            A73ResidentBirthDate = BC000920_A73ResidentBirthDate[0];
            A97ResidentTypeName = BC000920_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC000920_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC000920_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC000920_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = BC000920_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = BC000920_A446ResidentHomePhoneNumber[0];
            A29LocationId = BC000920_A29LocationId[0];
            A11OrganisationId = BC000920_A11OrganisationId[0];
            A96ResidentTypeId = BC000920_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC000920_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000920_n98MedicalIndicationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0916( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound16 = 0;
         ScanKeyLoad0916( ) ;
      }

      protected void ScanKeyLoad0916( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = BC000920_A62ResidentId[0];
            A71ResidentGUID = BC000920_A71ResidentGUID[0];
            A66ResidentInitials = BC000920_A66ResidentInitials[0];
            A70ResidentPhone = BC000920_A70ResidentPhone[0];
            A72ResidentSalutation = BC000920_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC000920_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC000920_A64ResidentGivenName[0];
            A65ResidentLastName = BC000920_A65ResidentLastName[0];
            A67ResidentEmail = BC000920_A67ResidentEmail[0];
            A68ResidentGender = BC000920_A68ResidentGender[0];
            A354ResidentCountry = BC000920_A354ResidentCountry[0];
            A355ResidentCity = BC000920_A355ResidentCity[0];
            A356ResidentZipCode = BC000920_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = BC000920_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = BC000920_A358ResidentAddressLine2[0];
            A444ResidentHomePhone = BC000920_A444ResidentHomePhone[0];
            A73ResidentBirthDate = BC000920_A73ResidentBirthDate[0];
            A97ResidentTypeName = BC000920_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC000920_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = BC000920_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = BC000920_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = BC000920_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = BC000920_A446ResidentHomePhoneNumber[0];
            A29LocationId = BC000920_A29LocationId[0];
            A11OrganisationId = BC000920_A11OrganisationId[0];
            A96ResidentTypeId = BC000920_A96ResidentTypeId[0];
            A98MedicalIndicationId = BC000920_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000920_n98MedicalIndicationId[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0916( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0916( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0916( )
      {
         /* Before Insert Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  A71ResidentGUID) ;
         }
      }

      protected void BeforeUpdate0916( )
      {
         /* Before Update Rules */
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeDelete0916( )
      {
         /* Before Delete Rules */
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeComplete0916( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0916( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0916( )
      {
      }

      protected void ZM0923( short GX_JID )
      {
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z388NetworkIndividualPhoneNumber = A388NetworkIndividualPhoneNumber;
            Z387NetworkIndividualPhoneCode = A387NetworkIndividualPhoneCode;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z344NetworkIndividualCountry = A344NetworkIndividualCountry;
            Z345NetworkIndividualCity = A345NetworkIndividualCity;
            Z346NetworkIndividualZipCode = A346NetworkIndividualZipCode;
            Z347NetworkIndividualAddressLine1 = A347NetworkIndividualAddressLine1;
            Z348NetworkIndividualAddressLine2 = A348NetworkIndividualAddressLine2;
         }
         if ( GX_JID == -36 )
         {
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z74NetworkIndividualId = A74NetworkIndividualId;
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z388NetworkIndividualPhoneNumber = A388NetworkIndividualPhoneNumber;
            Z387NetworkIndividualPhoneCode = A387NetworkIndividualPhoneCode;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z344NetworkIndividualCountry = A344NetworkIndividualCountry;
            Z345NetworkIndividualCity = A345NetworkIndividualCity;
            Z346NetworkIndividualZipCode = A346NetworkIndividualZipCode;
            Z347NetworkIndividualAddressLine1 = A347NetworkIndividualAddressLine1;
            Z348NetworkIndividualAddressLine2 = A348NetworkIndividualAddressLine2;
         }
      }

      protected void standaloneNotModal0923( )
      {
      }

      protected void standaloneModal0923( )
      {
      }

      protected void Load0923( )
      {
         /* Using cursor BC000921 */
         pr_default.execute(19, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound23 = 1;
            A75NetworkIndividualBsnNumber = BC000921_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000921_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000921_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000921_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000921_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = BC000921_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = BC000921_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = BC000921_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000921_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000921_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000921_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000921_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000921_A348NetworkIndividualAddressLine2[0];
            ZM0923( -36) ;
         }
         pr_default.close(19);
         OnLoadActions0923( ) ;
      }

      protected void OnLoadActions0923( )
      {
      }

      protected void CheckExtendedTable0923( )
      {
         Gx_BScreen = 1;
         standaloneModal0923( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00097 */
         pr_default.execute(5, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkIndividual", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "NETWORKINDIVIDUALID");
            AnyError = 1;
         }
         A75NetworkIndividualBsnNumber = BC00097_A75NetworkIndividualBsnNumber[0];
         A76NetworkIndividualGivenName = BC00097_A76NetworkIndividualGivenName[0];
         A77NetworkIndividualLastName = BC00097_A77NetworkIndividualLastName[0];
         A78NetworkIndividualEmail = BC00097_A78NetworkIndividualEmail[0];
         A79NetworkIndividualPhone = BC00097_A79NetworkIndividualPhone[0];
         A388NetworkIndividualPhoneNumber = BC00097_A388NetworkIndividualPhoneNumber[0];
         A387NetworkIndividualPhoneCode = BC00097_A387NetworkIndividualPhoneCode[0];
         A81NetworkIndividualGender = BC00097_A81NetworkIndividualGender[0];
         A344NetworkIndividualCountry = BC00097_A344NetworkIndividualCountry[0];
         A345NetworkIndividualCity = BC00097_A345NetworkIndividualCity[0];
         A346NetworkIndividualZipCode = BC00097_A346NetworkIndividualZipCode[0];
         A347NetworkIndividualAddressLine1 = BC00097_A347NetworkIndividualAddressLine1[0];
         A348NetworkIndividualAddressLine2 = BC00097_A348NetworkIndividualAddressLine2[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0923( )
      {
         pr_default.close(5);
      }

      protected void enableDisable0923( )
      {
      }

      protected void GetKey0923( )
      {
         /* Using cursor BC000922 */
         pr_default.execute(20, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0923( )
      {
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(4) != 101) && ( BC00096_A62ResidentId[0] == A62ResidentId ) && ( BC00096_A29LocationId[0] == A29LocationId ) && ( BC00096_A11OrganisationId[0] == A11OrganisationId ) )
         {
            ZM0923( 36) ;
            RcdFound23 = 1;
            InitializeNonKey0923( ) ;
            A74NetworkIndividualId = BC00096_A74NetworkIndividualId[0];
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z74NetworkIndividualId = A74NetworkIndividualId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0923( ) ;
            Load0923( ) ;
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0923( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0923( ) ;
            Gx_mode = sMode23;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0923( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0923( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00095 */
            pr_default.execute(3, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNetworkIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNetworkIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0923( )
      {
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0923( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0923( 0) ;
            CheckOptimisticConcurrency0923( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0923( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0923( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000923 */
                     pr_default.execute(21, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkIndividual");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load0923( ) ;
            }
            EndLevel0923( ) ;
         }
         CloseExtendedTableCursors0923( ) ;
      }

      protected void Update0923( )
      {
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0923( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0923( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0923( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0923( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Trn_ResidentNetworkIndividual */
                     DeferredUpdate0923( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0923( ) ;
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
            EndLevel0923( ) ;
         }
         CloseExtendedTableCursors0923( ) ;
      }

      protected void DeferredUpdate0923( )
      {
      }

      protected void Delete0923( )
      {
         Gx_mode = "DLT";
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0923( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0923( ) ;
            AfterConfirm0923( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0923( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000924 */
                  pr_default.execute(22, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkIndividual");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0923( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0923( )
      {
         standaloneModal0923( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000925 */
            pr_default.execute(23, new Object[] {A74NetworkIndividualId});
            A75NetworkIndividualBsnNumber = BC000925_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000925_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000925_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000925_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000925_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = BC000925_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = BC000925_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = BC000925_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000925_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000925_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000925_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000925_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000925_A348NetworkIndividualAddressLine2[0];
            pr_default.close(23);
         }
      }

      protected void EndLevel0923( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0923( )
      {
         /* Scan By routine */
         /* Using cursor BC000926 */
         pr_default.execute(24, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound23 = 1;
            A75NetworkIndividualBsnNumber = BC000926_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000926_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000926_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000926_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000926_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = BC000926_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = BC000926_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = BC000926_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000926_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000926_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000926_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000926_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000926_A348NetworkIndividualAddressLine2[0];
            A74NetworkIndividualId = BC000926_A74NetworkIndividualId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0923( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound23 = 0;
         ScanKeyLoad0923( ) ;
      }

      protected void ScanKeyLoad0923( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound23 = 1;
            A75NetworkIndividualBsnNumber = BC000926_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000926_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000926_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000926_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000926_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = BC000926_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = BC000926_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = BC000926_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000926_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000926_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000926_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000926_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000926_A348NetworkIndividualAddressLine2[0];
            A74NetworkIndividualId = BC000926_A74NetworkIndividualId[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0923( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0923( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0923( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0923( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0923( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0923( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0923( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0923( )
      {
      }

      protected void send_integrity_lvl_hashes0923( )
      {
      }

      protected void ZM0920( short GX_JID )
      {
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z392NetworkCompanyPhoneNumber = A392NetworkCompanyPhoneNumber;
            Z391NetworkCompanyPhoneCode = A391NetworkCompanyPhoneCode;
            Z349NetworkCompanyCountry = A349NetworkCompanyCountry;
            Z350NetworkCompanyCity = A350NetworkCompanyCity;
            Z351NetworkCompanyZipCode = A351NetworkCompanyZipCode;
            Z352NetworkCompanyAddressLine1 = A352NetworkCompanyAddressLine1;
            Z353NetworkCompanyAddressLine2 = A353NetworkCompanyAddressLine2;
         }
         if ( GX_JID == -38 )
         {
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z392NetworkCompanyPhoneNumber = A392NetworkCompanyPhoneNumber;
            Z391NetworkCompanyPhoneCode = A391NetworkCompanyPhoneCode;
            Z349NetworkCompanyCountry = A349NetworkCompanyCountry;
            Z350NetworkCompanyCity = A350NetworkCompanyCity;
            Z351NetworkCompanyZipCode = A351NetworkCompanyZipCode;
            Z352NetworkCompanyAddressLine1 = A352NetworkCompanyAddressLine1;
            Z353NetworkCompanyAddressLine2 = A353NetworkCompanyAddressLine2;
         }
      }

      protected void standaloneNotModal0920( )
      {
      }

      protected void standaloneModal0920( )
      {
      }

      protected void Load0920( )
      {
         /* Using cursor BC000927 */
         pr_default.execute(25, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound20 = 1;
            A83NetworkCompanyKvkNumber = BC000927_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000927_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000927_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000927_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = BC000927_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = BC000927_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = BC000927_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000927_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000927_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000927_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000927_A353NetworkCompanyAddressLine2[0];
            ZM0920( -38) ;
         }
         pr_default.close(25);
         OnLoadActions0920( ) ;
      }

      protected void OnLoadActions0920( )
      {
      }

      protected void CheckExtendedTable0920( )
      {
         Gx_BScreen = 1;
         standaloneModal0920( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkCompany", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "NETWORKCOMPANYID");
            AnyError = 1;
         }
         A83NetworkCompanyKvkNumber = BC00094_A83NetworkCompanyKvkNumber[0];
         A84NetworkCompanyName = BC00094_A84NetworkCompanyName[0];
         A85NetworkCompanyEmail = BC00094_A85NetworkCompanyEmail[0];
         A86NetworkCompanyPhone = BC00094_A86NetworkCompanyPhone[0];
         A392NetworkCompanyPhoneNumber = BC00094_A392NetworkCompanyPhoneNumber[0];
         A391NetworkCompanyPhoneCode = BC00094_A391NetworkCompanyPhoneCode[0];
         A349NetworkCompanyCountry = BC00094_A349NetworkCompanyCountry[0];
         A350NetworkCompanyCity = BC00094_A350NetworkCompanyCity[0];
         A351NetworkCompanyZipCode = BC00094_A351NetworkCompanyZipCode[0];
         A352NetworkCompanyAddressLine1 = BC00094_A352NetworkCompanyAddressLine1[0];
         A353NetworkCompanyAddressLine2 = BC00094_A353NetworkCompanyAddressLine2[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0920( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0920( )
      {
      }

      protected void GetKey0920( )
      {
         /* Using cursor BC000928 */
         pr_default.execute(26, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0920( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) && ( BC00093_A62ResidentId[0] == A62ResidentId ) && ( BC00093_A29LocationId[0] == A29LocationId ) && ( BC00093_A11OrganisationId[0] == A11OrganisationId ) )
         {
            ZM0920( 38) ;
            RcdFound20 = 1;
            InitializeNonKey0920( ) ;
            A82NetworkCompanyId = BC00093_A82NetworkCompanyId[0];
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0920( ) ;
            Load0920( ) ;
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0920( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0920( ) ;
            Gx_mode = sMode20;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0920( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0920( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNetworkCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNetworkCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0920( )
      {
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0920( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0920( 0) ;
            CheckOptimisticConcurrency0920( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0920( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0920( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000929 */
                     pr_default.execute(27, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A82NetworkCompanyId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkCompany");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load0920( ) ;
            }
            EndLevel0920( ) ;
         }
         CloseExtendedTableCursors0920( ) ;
      }

      protected void Update0920( )
      {
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0920( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0920( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0920( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0920( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Trn_ResidentNetworkCompany */
                     DeferredUpdate0920( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0920( ) ;
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
            EndLevel0920( ) ;
         }
         CloseExtendedTableCursors0920( ) ;
      }

      protected void DeferredUpdate0920( )
      {
      }

      protected void Delete0920( )
      {
         Gx_mode = "DLT";
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0920( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0920( ) ;
            AfterConfirm0920( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0920( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000930 */
                  pr_default.execute(28, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkCompany");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0920( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0920( )
      {
         standaloneModal0920( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000931 */
            pr_default.execute(29, new Object[] {A82NetworkCompanyId});
            A83NetworkCompanyKvkNumber = BC000931_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000931_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000931_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000931_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = BC000931_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = BC000931_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = BC000931_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000931_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000931_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000931_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000931_A353NetworkCompanyAddressLine2[0];
            pr_default.close(29);
         }
      }

      protected void EndLevel0920( )
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

      public void ScanKeyStart0920( )
      {
         /* Scan By routine */
         /* Using cursor BC000932 */
         pr_default.execute(30, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound20 = 1;
            A83NetworkCompanyKvkNumber = BC000932_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000932_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000932_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000932_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = BC000932_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = BC000932_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = BC000932_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000932_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000932_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000932_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000932_A353NetworkCompanyAddressLine2[0];
            A82NetworkCompanyId = BC000932_A82NetworkCompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0920( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound20 = 0;
         ScanKeyLoad0920( ) ;
      }

      protected void ScanKeyLoad0920( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound20 = 1;
            A83NetworkCompanyKvkNumber = BC000932_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000932_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000932_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000932_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = BC000932_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = BC000932_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = BC000932_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000932_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000932_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000932_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000932_A353NetworkCompanyAddressLine2[0];
            A82NetworkCompanyId = BC000932_A82NetworkCompanyId[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0920( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm0920( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0920( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0920( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0920( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0920( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0920( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0920( )
      {
      }

      protected void send_integrity_lvl_hashes0920( )
      {
      }

      protected void send_integrity_lvl_hashes0916( )
      {
      }

      protected void AddRow0916( )
      {
         VarsToRow16( bcTrn_Resident) ;
      }

      protected void ReadRow0916( )
      {
         RowToVars16( bcTrn_Resident, 1) ;
      }

      protected void AddRow0923( )
      {
         SdtTrn_Resident_NetworkIndividual obj23;
         obj23 = new SdtTrn_Resident_NetworkIndividual(context);
         VarsToRow23( obj23) ;
         bcTrn_Resident.gxTpr_Networkindividual.Add(obj23, 0);
         obj23.gxTpr_Mode = "UPD";
         obj23.gxTpr_Modified = 0;
      }

      protected void ReadRow0923( )
      {
         nGXsfl_23_idx = (int)(nGXsfl_23_idx+1);
         RowToVars23( ((SdtTrn_Resident_NetworkIndividual)bcTrn_Resident.gxTpr_Networkindividual.Item(nGXsfl_23_idx)), 1) ;
      }

      protected void AddRow0920( )
      {
         SdtTrn_Resident_NetworkCompany obj20;
         obj20 = new SdtTrn_Resident_NetworkCompany(context);
         VarsToRow20( obj20) ;
         bcTrn_Resident.gxTpr_Networkcompany.Add(obj20, 0);
         obj20.gxTpr_Mode = "UPD";
         obj20.gxTpr_Modified = 0;
      }

      protected void ReadRow0920( )
      {
         nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
         RowToVars20( ((SdtTrn_Resident_NetworkCompany)bcTrn_Resident.gxTpr_Networkcompany.Item(nGXsfl_20_idx)), 1) ;
      }

      protected void InitializeNonKey0916( )
      {
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A71ResidentGUID = "";
         A66ResidentInitials = "";
         AV36GAMErrorResponse = "";
         A70ResidentPhone = "";
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A354ResidentCountry = "";
         A355ResidentCity = "";
         A356ResidentZipCode = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         A444ResidentHomePhone = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = "";
         A375ResidentPhoneCode = "";
         A376ResidentPhoneNumber = "";
         A445ResidentHomePhoneCode = "";
         A446ResidentHomePhoneNumber = "";
         Z71ResidentGUID = "";
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
         Z72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z67ResidentEmail = "";
         Z68ResidentGender = "";
         Z354ResidentCountry = "";
         Z355ResidentCity = "";
         Z356ResidentZipCode = "";
         Z357ResidentAddressLine1 = "";
         Z358ResidentAddressLine2 = "";
         Z444ResidentHomePhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z375ResidentPhoneCode = "";
         Z376ResidentPhoneNumber = "";
         Z445ResidentHomePhoneCode = "";
         Z446ResidentHomePhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
      }

      protected void InitAll0916( )
      {
         A62ResidentId = Guid.NewGuid( );
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         InitializeNonKey0916( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0923( )
      {
         A75NetworkIndividualBsnNumber = "";
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         A79NetworkIndividualPhone = "";
         A388NetworkIndividualPhoneNumber = "";
         A387NetworkIndividualPhoneCode = "";
         A81NetworkIndividualGender = "";
         A344NetworkIndividualCountry = "";
         A345NetworkIndividualCity = "";
         A346NetworkIndividualZipCode = "";
         A347NetworkIndividualAddressLine1 = "";
         A348NetworkIndividualAddressLine2 = "";
      }

      protected void InitAll0923( )
      {
         A74NetworkIndividualId = Guid.Empty;
         InitializeNonKey0923( ) ;
      }

      protected void StandaloneModalInsert0923( )
      {
      }

      protected void InitializeNonKey0920( )
      {
         A83NetworkCompanyKvkNumber = "";
         A84NetworkCompanyName = "";
         A85NetworkCompanyEmail = "";
         A86NetworkCompanyPhone = "";
         A392NetworkCompanyPhoneNumber = "";
         A391NetworkCompanyPhoneCode = "";
         A349NetworkCompanyCountry = "";
         A350NetworkCompanyCity = "";
         A351NetworkCompanyZipCode = "";
         A352NetworkCompanyAddressLine1 = "";
         A353NetworkCompanyAddressLine2 = "";
      }

      protected void InitAll0920( )
      {
         A82NetworkCompanyId = Guid.Empty;
         InitializeNonKey0920( ) ;
      }

      protected void StandaloneModalInsert0920( )
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

      public void VarsToRow16( SdtTrn_Resident obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Residentguid = A71ResidentGUID;
         obj16.gxTpr_Residentinitials = A66ResidentInitials;
         obj16.gxTpr_Residentphone = A70ResidentPhone;
         obj16.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj16.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
         obj16.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj16.gxTpr_Residentlastname = A65ResidentLastName;
         obj16.gxTpr_Residentemail = A67ResidentEmail;
         obj16.gxTpr_Residentgender = A68ResidentGender;
         obj16.gxTpr_Residentcountry = A354ResidentCountry;
         obj16.gxTpr_Residentcity = A355ResidentCity;
         obj16.gxTpr_Residentzipcode = A356ResidentZipCode;
         obj16.gxTpr_Residentaddressline1 = A357ResidentAddressLine1;
         obj16.gxTpr_Residentaddressline2 = A358ResidentAddressLine2;
         obj16.gxTpr_Residenthomephone = A444ResidentHomePhone;
         obj16.gxTpr_Residentbirthdate = A73ResidentBirthDate;
         obj16.gxTpr_Residenttypeid = A96ResidentTypeId;
         obj16.gxTpr_Residenttypename = A97ResidentTypeName;
         obj16.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         obj16.gxTpr_Medicalindicationname = A99MedicalIndicationName;
         obj16.gxTpr_Residentphonecode = A375ResidentPhoneCode;
         obj16.gxTpr_Residentphonenumber = A376ResidentPhoneNumber;
         obj16.gxTpr_Residenthomephonecode = A445ResidentHomePhoneCode;
         obj16.gxTpr_Residenthomephonenumber = A446ResidentHomePhoneNumber;
         obj16.gxTpr_Residentid = A62ResidentId;
         obj16.gxTpr_Locationid = A29LocationId;
         obj16.gxTpr_Organisationid = A11OrganisationId;
         obj16.gxTpr_Residentid_Z = Z62ResidentId;
         obj16.gxTpr_Locationid_Z = Z29LocationId;
         obj16.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj16.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj16.gxTpr_Residentbsnnumber_Z = Z63ResidentBsnNumber;
         obj16.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj16.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj16.gxTpr_Residentinitials_Z = Z66ResidentInitials;
         obj16.gxTpr_Residentemail_Z = Z67ResidentEmail;
         obj16.gxTpr_Residentgender_Z = Z68ResidentGender;
         obj16.gxTpr_Residentcountry_Z = Z354ResidentCountry;
         obj16.gxTpr_Residentcity_Z = Z355ResidentCity;
         obj16.gxTpr_Residentzipcode_Z = Z356ResidentZipCode;
         obj16.gxTpr_Residentaddressline1_Z = Z357ResidentAddressLine1;
         obj16.gxTpr_Residentaddressline2_Z = Z358ResidentAddressLine2;
         obj16.gxTpr_Residentphone_Z = Z70ResidentPhone;
         obj16.gxTpr_Residenthomephone_Z = Z444ResidentHomePhone;
         obj16.gxTpr_Residentbirthdate_Z = Z73ResidentBirthDate;
         obj16.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj16.gxTpr_Residenttypeid_Z = Z96ResidentTypeId;
         obj16.gxTpr_Residenttypename_Z = Z97ResidentTypeName;
         obj16.gxTpr_Medicalindicationid_Z = Z98MedicalIndicationId;
         obj16.gxTpr_Medicalindicationname_Z = Z99MedicalIndicationName;
         obj16.gxTpr_Residentphonecode_Z = Z375ResidentPhoneCode;
         obj16.gxTpr_Residentphonenumber_Z = Z376ResidentPhoneNumber;
         obj16.gxTpr_Residenthomephonecode_Z = Z445ResidentHomePhoneCode;
         obj16.gxTpr_Residenthomephonenumber_Z = Z446ResidentHomePhoneNumber;
         obj16.gxTpr_Medicalindicationid_N = (short)(Convert.ToInt16(n98MedicalIndicationId));
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtTrn_Resident obj16 )
      {
         obj16.gxTpr_Residentid = A62ResidentId;
         obj16.gxTpr_Locationid = A29LocationId;
         obj16.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars16( SdtTrn_Resident obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A71ResidentGUID = obj16.gxTpr_Residentguid;
         A66ResidentInitials = obj16.gxTpr_Residentinitials;
         A70ResidentPhone = obj16.gxTpr_Residentphone;
         A72ResidentSalutation = obj16.gxTpr_Residentsalutation;
         A63ResidentBsnNumber = obj16.gxTpr_Residentbsnnumber;
         A64ResidentGivenName = obj16.gxTpr_Residentgivenname;
         A65ResidentLastName = obj16.gxTpr_Residentlastname;
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A67ResidentEmail = obj16.gxTpr_Residentemail;
         }
         A68ResidentGender = obj16.gxTpr_Residentgender;
         A354ResidentCountry = obj16.gxTpr_Residentcountry;
         A355ResidentCity = obj16.gxTpr_Residentcity;
         A356ResidentZipCode = obj16.gxTpr_Residentzipcode;
         A357ResidentAddressLine1 = obj16.gxTpr_Residentaddressline1;
         A358ResidentAddressLine2 = obj16.gxTpr_Residentaddressline2;
         A444ResidentHomePhone = obj16.gxTpr_Residenthomephone;
         A73ResidentBirthDate = obj16.gxTpr_Residentbirthdate;
         A96ResidentTypeId = obj16.gxTpr_Residenttypeid;
         A97ResidentTypeName = obj16.gxTpr_Residenttypename;
         A98MedicalIndicationId = obj16.gxTpr_Medicalindicationid;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = obj16.gxTpr_Medicalindicationname;
         A375ResidentPhoneCode = obj16.gxTpr_Residentphonecode;
         A376ResidentPhoneNumber = obj16.gxTpr_Residentphonenumber;
         A445ResidentHomePhoneCode = obj16.gxTpr_Residenthomephonecode;
         A446ResidentHomePhoneNumber = obj16.gxTpr_Residenthomephonenumber;
         A62ResidentId = obj16.gxTpr_Residentid;
         A29LocationId = obj16.gxTpr_Locationid;
         A11OrganisationId = obj16.gxTpr_Organisationid;
         Z62ResidentId = obj16.gxTpr_Residentid_Z;
         Z29LocationId = obj16.gxTpr_Locationid_Z;
         Z11OrganisationId = obj16.gxTpr_Organisationid_Z;
         Z72ResidentSalutation = obj16.gxTpr_Residentsalutation_Z;
         Z63ResidentBsnNumber = obj16.gxTpr_Residentbsnnumber_Z;
         Z64ResidentGivenName = obj16.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj16.gxTpr_Residentlastname_Z;
         Z66ResidentInitials = obj16.gxTpr_Residentinitials_Z;
         Z67ResidentEmail = obj16.gxTpr_Residentemail_Z;
         Z68ResidentGender = obj16.gxTpr_Residentgender_Z;
         Z354ResidentCountry = obj16.gxTpr_Residentcountry_Z;
         Z355ResidentCity = obj16.gxTpr_Residentcity_Z;
         Z356ResidentZipCode = obj16.gxTpr_Residentzipcode_Z;
         Z357ResidentAddressLine1 = obj16.gxTpr_Residentaddressline1_Z;
         Z358ResidentAddressLine2 = obj16.gxTpr_Residentaddressline2_Z;
         Z70ResidentPhone = obj16.gxTpr_Residentphone_Z;
         Z444ResidentHomePhone = obj16.gxTpr_Residenthomephone_Z;
         Z73ResidentBirthDate = obj16.gxTpr_Residentbirthdate_Z;
         Z71ResidentGUID = obj16.gxTpr_Residentguid_Z;
         Z96ResidentTypeId = obj16.gxTpr_Residenttypeid_Z;
         Z97ResidentTypeName = obj16.gxTpr_Residenttypename_Z;
         Z98MedicalIndicationId = obj16.gxTpr_Medicalindicationid_Z;
         Z99MedicalIndicationName = obj16.gxTpr_Medicalindicationname_Z;
         Z375ResidentPhoneCode = obj16.gxTpr_Residentphonecode_Z;
         Z376ResidentPhoneNumber = obj16.gxTpr_Residentphonenumber_Z;
         Z445ResidentHomePhoneCode = obj16.gxTpr_Residenthomephonecode_Z;
         Z446ResidentHomePhoneNumber = obj16.gxTpr_Residenthomephonenumber_Z;
         n98MedicalIndicationId = (bool)(Convert.ToBoolean(obj16.gxTpr_Medicalindicationid_N));
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow23( SdtTrn_Resident_NetworkIndividual obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Networkindividualbsnnumber = A75NetworkIndividualBsnNumber;
         obj23.gxTpr_Networkindividualgivenname = A76NetworkIndividualGivenName;
         obj23.gxTpr_Networkindividuallastname = A77NetworkIndividualLastName;
         obj23.gxTpr_Networkindividualemail = A78NetworkIndividualEmail;
         obj23.gxTpr_Networkindividualphone = A79NetworkIndividualPhone;
         obj23.gxTpr_Networkindividualphonenumber = A388NetworkIndividualPhoneNumber;
         obj23.gxTpr_Networkindividualphonecode = A387NetworkIndividualPhoneCode;
         obj23.gxTpr_Networkindividualgender = A81NetworkIndividualGender;
         obj23.gxTpr_Networkindividualcountry = A344NetworkIndividualCountry;
         obj23.gxTpr_Networkindividualcity = A345NetworkIndividualCity;
         obj23.gxTpr_Networkindividualzipcode = A346NetworkIndividualZipCode;
         obj23.gxTpr_Networkindividualaddressline1 = A347NetworkIndividualAddressLine1;
         obj23.gxTpr_Networkindividualaddressline2 = A348NetworkIndividualAddressLine2;
         obj23.gxTpr_Networkindividualid = A74NetworkIndividualId;
         obj23.gxTpr_Networkindividualid_Z = Z74NetworkIndividualId;
         obj23.gxTpr_Networkindividualbsnnumber_Z = Z75NetworkIndividualBsnNumber;
         obj23.gxTpr_Networkindividualgivenname_Z = Z76NetworkIndividualGivenName;
         obj23.gxTpr_Networkindividuallastname_Z = Z77NetworkIndividualLastName;
         obj23.gxTpr_Networkindividualemail_Z = Z78NetworkIndividualEmail;
         obj23.gxTpr_Networkindividualphone_Z = Z79NetworkIndividualPhone;
         obj23.gxTpr_Networkindividualphonenumber_Z = Z388NetworkIndividualPhoneNumber;
         obj23.gxTpr_Networkindividualphonecode_Z = Z387NetworkIndividualPhoneCode;
         obj23.gxTpr_Networkindividualgender_Z = Z81NetworkIndividualGender;
         obj23.gxTpr_Networkindividualcountry_Z = Z344NetworkIndividualCountry;
         obj23.gxTpr_Networkindividualcity_Z = Z345NetworkIndividualCity;
         obj23.gxTpr_Networkindividualzipcode_Z = Z346NetworkIndividualZipCode;
         obj23.gxTpr_Networkindividualaddressline1_Z = Z347NetworkIndividualAddressLine1;
         obj23.gxTpr_Networkindividualaddressline2_Z = Z348NetworkIndividualAddressLine2;
         obj23.gxTpr_Modified = nIsMod_23;
         return  ;
      }

      public void KeyVarsToRow23( SdtTrn_Resident_NetworkIndividual obj23 )
      {
         obj23.gxTpr_Networkindividualid = A74NetworkIndividualId;
         return  ;
      }

      public void RowToVars23( SdtTrn_Resident_NetworkIndividual obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A75NetworkIndividualBsnNumber = obj23.gxTpr_Networkindividualbsnnumber;
         A76NetworkIndividualGivenName = obj23.gxTpr_Networkindividualgivenname;
         A77NetworkIndividualLastName = obj23.gxTpr_Networkindividuallastname;
         A78NetworkIndividualEmail = obj23.gxTpr_Networkindividualemail;
         A79NetworkIndividualPhone = obj23.gxTpr_Networkindividualphone;
         A388NetworkIndividualPhoneNumber = obj23.gxTpr_Networkindividualphonenumber;
         A387NetworkIndividualPhoneCode = obj23.gxTpr_Networkindividualphonecode;
         A81NetworkIndividualGender = obj23.gxTpr_Networkindividualgender;
         A344NetworkIndividualCountry = obj23.gxTpr_Networkindividualcountry;
         A345NetworkIndividualCity = obj23.gxTpr_Networkindividualcity;
         A346NetworkIndividualZipCode = obj23.gxTpr_Networkindividualzipcode;
         A347NetworkIndividualAddressLine1 = obj23.gxTpr_Networkindividualaddressline1;
         A348NetworkIndividualAddressLine2 = obj23.gxTpr_Networkindividualaddressline2;
         A74NetworkIndividualId = obj23.gxTpr_Networkindividualid;
         Z74NetworkIndividualId = obj23.gxTpr_Networkindividualid_Z;
         Z75NetworkIndividualBsnNumber = obj23.gxTpr_Networkindividualbsnnumber_Z;
         Z76NetworkIndividualGivenName = obj23.gxTpr_Networkindividualgivenname_Z;
         Z77NetworkIndividualLastName = obj23.gxTpr_Networkindividuallastname_Z;
         Z78NetworkIndividualEmail = obj23.gxTpr_Networkindividualemail_Z;
         Z79NetworkIndividualPhone = obj23.gxTpr_Networkindividualphone_Z;
         Z388NetworkIndividualPhoneNumber = obj23.gxTpr_Networkindividualphonenumber_Z;
         Z387NetworkIndividualPhoneCode = obj23.gxTpr_Networkindividualphonecode_Z;
         Z81NetworkIndividualGender = obj23.gxTpr_Networkindividualgender_Z;
         Z344NetworkIndividualCountry = obj23.gxTpr_Networkindividualcountry_Z;
         Z345NetworkIndividualCity = obj23.gxTpr_Networkindividualcity_Z;
         Z346NetworkIndividualZipCode = obj23.gxTpr_Networkindividualzipcode_Z;
         Z347NetworkIndividualAddressLine1 = obj23.gxTpr_Networkindividualaddressline1_Z;
         Z348NetworkIndividualAddressLine2 = obj23.gxTpr_Networkindividualaddressline2_Z;
         nIsMod_23 = obj23.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow20( SdtTrn_Resident_NetworkCompany obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Networkcompanykvknumber = A83NetworkCompanyKvkNumber;
         obj20.gxTpr_Networkcompanyname = A84NetworkCompanyName;
         obj20.gxTpr_Networkcompanyemail = A85NetworkCompanyEmail;
         obj20.gxTpr_Networkcompanyphone = A86NetworkCompanyPhone;
         obj20.gxTpr_Networkcompanyphonenumber = A392NetworkCompanyPhoneNumber;
         obj20.gxTpr_Networkcompanyphonecode = A391NetworkCompanyPhoneCode;
         obj20.gxTpr_Networkcompanycountry = A349NetworkCompanyCountry;
         obj20.gxTpr_Networkcompanycity = A350NetworkCompanyCity;
         obj20.gxTpr_Networkcompanyzipcode = A351NetworkCompanyZipCode;
         obj20.gxTpr_Networkcompanyaddressline1 = A352NetworkCompanyAddressLine1;
         obj20.gxTpr_Networkcompanyaddressline2 = A353NetworkCompanyAddressLine2;
         obj20.gxTpr_Networkcompanyid = A82NetworkCompanyId;
         obj20.gxTpr_Networkcompanyid_Z = Z82NetworkCompanyId;
         obj20.gxTpr_Networkcompanykvknumber_Z = Z83NetworkCompanyKvkNumber;
         obj20.gxTpr_Networkcompanyname_Z = Z84NetworkCompanyName;
         obj20.gxTpr_Networkcompanyemail_Z = Z85NetworkCompanyEmail;
         obj20.gxTpr_Networkcompanyphone_Z = Z86NetworkCompanyPhone;
         obj20.gxTpr_Networkcompanyphonenumber_Z = Z392NetworkCompanyPhoneNumber;
         obj20.gxTpr_Networkcompanyphonecode_Z = Z391NetworkCompanyPhoneCode;
         obj20.gxTpr_Networkcompanycountry_Z = Z349NetworkCompanyCountry;
         obj20.gxTpr_Networkcompanycity_Z = Z350NetworkCompanyCity;
         obj20.gxTpr_Networkcompanyzipcode_Z = Z351NetworkCompanyZipCode;
         obj20.gxTpr_Networkcompanyaddressline1_Z = Z352NetworkCompanyAddressLine1;
         obj20.gxTpr_Networkcompanyaddressline2_Z = Z353NetworkCompanyAddressLine2;
         obj20.gxTpr_Modified = nIsMod_20;
         return  ;
      }

      public void KeyVarsToRow20( SdtTrn_Resident_NetworkCompany obj20 )
      {
         obj20.gxTpr_Networkcompanyid = A82NetworkCompanyId;
         return  ;
      }

      public void RowToVars20( SdtTrn_Resident_NetworkCompany obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A83NetworkCompanyKvkNumber = obj20.gxTpr_Networkcompanykvknumber;
         A84NetworkCompanyName = obj20.gxTpr_Networkcompanyname;
         A85NetworkCompanyEmail = obj20.gxTpr_Networkcompanyemail;
         A86NetworkCompanyPhone = obj20.gxTpr_Networkcompanyphone;
         A392NetworkCompanyPhoneNumber = obj20.gxTpr_Networkcompanyphonenumber;
         A391NetworkCompanyPhoneCode = obj20.gxTpr_Networkcompanyphonecode;
         A349NetworkCompanyCountry = obj20.gxTpr_Networkcompanycountry;
         A350NetworkCompanyCity = obj20.gxTpr_Networkcompanycity;
         A351NetworkCompanyZipCode = obj20.gxTpr_Networkcompanyzipcode;
         A352NetworkCompanyAddressLine1 = obj20.gxTpr_Networkcompanyaddressline1;
         A353NetworkCompanyAddressLine2 = obj20.gxTpr_Networkcompanyaddressline2;
         A82NetworkCompanyId = obj20.gxTpr_Networkcompanyid;
         Z82NetworkCompanyId = obj20.gxTpr_Networkcompanyid_Z;
         Z83NetworkCompanyKvkNumber = obj20.gxTpr_Networkcompanykvknumber_Z;
         Z84NetworkCompanyName = obj20.gxTpr_Networkcompanyname_Z;
         Z85NetworkCompanyEmail = obj20.gxTpr_Networkcompanyemail_Z;
         Z86NetworkCompanyPhone = obj20.gxTpr_Networkcompanyphone_Z;
         Z392NetworkCompanyPhoneNumber = obj20.gxTpr_Networkcompanyphonenumber_Z;
         Z391NetworkCompanyPhoneCode = obj20.gxTpr_Networkcompanyphonecode_Z;
         Z349NetworkCompanyCountry = obj20.gxTpr_Networkcompanycountry_Z;
         Z350NetworkCompanyCity = obj20.gxTpr_Networkcompanycity_Z;
         Z351NetworkCompanyZipCode = obj20.gxTpr_Networkcompanyzipcode_Z;
         Z352NetworkCompanyAddressLine1 = obj20.gxTpr_Networkcompanyaddressline1_Z;
         Z353NetworkCompanyAddressLine2 = obj20.gxTpr_Networkcompanyaddressline2_Z;
         nIsMod_20 = obj20.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A62ResidentId = (Guid)getParm(obj,0);
         A29LocationId = (Guid)getParm(obj,1);
         A11OrganisationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0916( ) ;
         ScanKeyStart0916( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000933 */
            pr_default.execute(31, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(31) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(31);
         }
         else
         {
            Gx_mode = "UPD";
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0916( -32) ;
         OnLoadActions0916( ) ;
         AddRow0916( ) ;
         bcTrn_Resident.gxTpr_Networkindividual.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0923( ) ;
            nGXsfl_23_idx = 1;
            while ( RcdFound23 != 0 )
            {
               Z62ResidentId = A62ResidentId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               Z74NetworkIndividualId = A74NetworkIndividualId;
               ZM0923( -36) ;
               OnLoadActions0923( ) ;
               nRcdExists_23 = 1;
               nIsMod_23 = 0;
               AddRow0923( ) ;
               nGXsfl_23_idx = (int)(nGXsfl_23_idx+1);
               ScanKeyNext0923( ) ;
            }
            ScanKeyEnd0923( ) ;
         }
         bcTrn_Resident.gxTpr_Networkcompany.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0920( ) ;
            nGXsfl_20_idx = 1;
            while ( RcdFound20 != 0 )
            {
               Z82NetworkCompanyId = A82NetworkCompanyId;
               Z62ResidentId = A62ResidentId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               ZM0920( -38) ;
               OnLoadActions0920( ) ;
               nRcdExists_20 = 1;
               nIsMod_20 = 0;
               AddRow0920( ) ;
               nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
               ScanKeyNext0920( ) ;
            }
            ScanKeyEnd0920( ) ;
         }
         ScanKeyEnd0916( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcTrn_Resident, 0) ;
         ScanKeyStart0916( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000933 */
            pr_default.execute(31, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(31) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(31);
         }
         else
         {
            Gx_mode = "UPD";
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0916( -32) ;
         OnLoadActions0916( ) ;
         AddRow0916( ) ;
         bcTrn_Resident.gxTpr_Networkindividual.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0923( ) ;
            nGXsfl_23_idx = 1;
            while ( RcdFound23 != 0 )
            {
               Z62ResidentId = A62ResidentId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               Z74NetworkIndividualId = A74NetworkIndividualId;
               ZM0923( -36) ;
               OnLoadActions0923( ) ;
               nRcdExists_23 = 1;
               nIsMod_23 = 0;
               AddRow0923( ) ;
               nGXsfl_23_idx = (int)(nGXsfl_23_idx+1);
               ScanKeyNext0923( ) ;
            }
            ScanKeyEnd0923( ) ;
         }
         bcTrn_Resident.gxTpr_Networkcompany.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0920( ) ;
            nGXsfl_20_idx = 1;
            while ( RcdFound20 != 0 )
            {
               Z82NetworkCompanyId = A82NetworkCompanyId;
               Z62ResidentId = A62ResidentId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               ZM0920( -38) ;
               OnLoadActions0920( ) ;
               nRcdExists_20 = 1;
               nIsMod_20 = 0;
               AddRow0920( ) ;
               nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
               ScanKeyNext0920( ) ;
            }
            ScanKeyEnd0920( ) ;
         }
         ScanKeyEnd0916( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0916( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0916( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A62ResidentId = Z62ResidentId;
                  A29LocationId = Z29LocationId;
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
                  Update0916( ) ;
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
                  if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert0916( ) ;
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
                        Insert0916( ) ;
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
         RowToVars16( bcTrn_Resident, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcTrn_Resident) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcTrn_Resident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0916( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcTrn_Resident) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcTrn_Resident) ;
         }
         else
         {
            SdtTrn_Resident auxBC = new SdtTrn_Resident(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A62ResidentId, A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Resident);
               auxBC.Save();
               bcTrn_Resident.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars16( bcTrn_Resident, 1) ;
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
         RowToVars16( bcTrn_Resident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0916( ) ;
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
               VarsToRow16( bcTrn_Resident) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcTrn_Resident) ;
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
         RowToVars16( bcTrn_Resident, 0) ;
         GetKey0916( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A62ResidentId = Z62ResidentId;
               A29LocationId = Z29LocationId;
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
            if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_resident_bc",pr_default);
         VarsToRow16( bcTrn_Resident) ;
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
         Gx_mode = bcTrn_Resident.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Resident.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Resident )
         {
            bcTrn_Resident = (SdtTrn_Resident)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Resident.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Resident.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcTrn_Resident) ;
            }
            else
            {
               RowToVars16( bcTrn_Resident, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Resident.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Resident.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcTrn_Resident, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Resident Trn_Resident_BC
      {
         get {
            return bcTrn_Resident ;
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
            return "trn_resident_Execute" ;
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
         pr_default.close(29);
         pr_default.close(4);
         pr_default.close(23);
         pr_default.close(7);
         pr_default.close(31);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         sMode16 = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV45Pgmname = "";
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV15Insert_ResidentTypeId = Guid.Empty;
         AV16Insert_MedicalIndicationId = Guid.Empty;
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z66ResidentInitials = "";
         A66ResidentInitials = "";
         Z70ResidentPhone = "";
         A70ResidentPhone = "";
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         A63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z67ResidentEmail = "";
         A67ResidentEmail = "";
         Z68ResidentGender = "";
         A68ResidentGender = "";
         Z354ResidentCountry = "";
         A354ResidentCountry = "";
         Z355ResidentCity = "";
         A355ResidentCity = "";
         Z356ResidentZipCode = "";
         A356ResidentZipCode = "";
         Z357ResidentAddressLine1 = "";
         A357ResidentAddressLine1 = "";
         Z358ResidentAddressLine2 = "";
         A358ResidentAddressLine2 = "";
         Z444ResidentHomePhone = "";
         A444ResidentHomePhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         A73ResidentBirthDate = DateTime.MinValue;
         Z375ResidentPhoneCode = "";
         A375ResidentPhoneCode = "";
         Z376ResidentPhoneNumber = "";
         A376ResidentPhoneNumber = "";
         Z445ResidentHomePhoneCode = "";
         A445ResidentHomePhoneCode = "";
         Z446ResidentHomePhoneNumber = "";
         A446ResidentHomePhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         Z97ResidentTypeName = "";
         A97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         A99MedicalIndicationName = "";
         GXt_guid1 = Guid.Empty;
         BC000913_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000913_A71ResidentGUID = new string[] {""} ;
         BC000913_A66ResidentInitials = new string[] {""} ;
         BC000913_A70ResidentPhone = new string[] {""} ;
         BC000913_A72ResidentSalutation = new string[] {""} ;
         BC000913_A63ResidentBsnNumber = new string[] {""} ;
         BC000913_A64ResidentGivenName = new string[] {""} ;
         BC000913_A65ResidentLastName = new string[] {""} ;
         BC000913_A67ResidentEmail = new string[] {""} ;
         BC000913_A68ResidentGender = new string[] {""} ;
         BC000913_A354ResidentCountry = new string[] {""} ;
         BC000913_A355ResidentCity = new string[] {""} ;
         BC000913_A356ResidentZipCode = new string[] {""} ;
         BC000913_A357ResidentAddressLine1 = new string[] {""} ;
         BC000913_A358ResidentAddressLine2 = new string[] {""} ;
         BC000913_A444ResidentHomePhone = new string[] {""} ;
         BC000913_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC000913_A97ResidentTypeName = new string[] {""} ;
         BC000913_A99MedicalIndicationName = new string[] {""} ;
         BC000913_A375ResidentPhoneCode = new string[] {""} ;
         BC000913_A376ResidentPhoneNumber = new string[] {""} ;
         BC000913_A445ResidentHomePhoneCode = new string[] {""} ;
         BC000913_A446ResidentHomePhoneNumber = new string[] {""} ;
         BC000913_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000913_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000913_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000913_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000913_n98MedicalIndicationId = new bool[] {false} ;
         BC000910_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000911_A97ResidentTypeName = new string[] {""} ;
         BC000912_A99MedicalIndicationName = new string[] {""} ;
         GXt_char2 = "";
         BC000914_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000914_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000914_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00099_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00099_A71ResidentGUID = new string[] {""} ;
         BC00099_A66ResidentInitials = new string[] {""} ;
         BC00099_A70ResidentPhone = new string[] {""} ;
         BC00099_A72ResidentSalutation = new string[] {""} ;
         BC00099_A63ResidentBsnNumber = new string[] {""} ;
         BC00099_A64ResidentGivenName = new string[] {""} ;
         BC00099_A65ResidentLastName = new string[] {""} ;
         BC00099_A67ResidentEmail = new string[] {""} ;
         BC00099_A68ResidentGender = new string[] {""} ;
         BC00099_A354ResidentCountry = new string[] {""} ;
         BC00099_A355ResidentCity = new string[] {""} ;
         BC00099_A356ResidentZipCode = new string[] {""} ;
         BC00099_A357ResidentAddressLine1 = new string[] {""} ;
         BC00099_A358ResidentAddressLine2 = new string[] {""} ;
         BC00099_A444ResidentHomePhone = new string[] {""} ;
         BC00099_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC00099_A375ResidentPhoneCode = new string[] {""} ;
         BC00099_A376ResidentPhoneNumber = new string[] {""} ;
         BC00099_A445ResidentHomePhoneCode = new string[] {""} ;
         BC00099_A446ResidentHomePhoneNumber = new string[] {""} ;
         BC00099_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00099_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00099_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC00099_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC00099_n98MedicalIndicationId = new bool[] {false} ;
         BC00098_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00098_A71ResidentGUID = new string[] {""} ;
         BC00098_A66ResidentInitials = new string[] {""} ;
         BC00098_A70ResidentPhone = new string[] {""} ;
         BC00098_A72ResidentSalutation = new string[] {""} ;
         BC00098_A63ResidentBsnNumber = new string[] {""} ;
         BC00098_A64ResidentGivenName = new string[] {""} ;
         BC00098_A65ResidentLastName = new string[] {""} ;
         BC00098_A67ResidentEmail = new string[] {""} ;
         BC00098_A68ResidentGender = new string[] {""} ;
         BC00098_A354ResidentCountry = new string[] {""} ;
         BC00098_A355ResidentCity = new string[] {""} ;
         BC00098_A356ResidentZipCode = new string[] {""} ;
         BC00098_A357ResidentAddressLine1 = new string[] {""} ;
         BC00098_A358ResidentAddressLine2 = new string[] {""} ;
         BC00098_A444ResidentHomePhone = new string[] {""} ;
         BC00098_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC00098_A375ResidentPhoneCode = new string[] {""} ;
         BC00098_A376ResidentPhoneNumber = new string[] {""} ;
         BC00098_A445ResidentHomePhoneCode = new string[] {""} ;
         BC00098_A446ResidentHomePhoneNumber = new string[] {""} ;
         BC00098_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00098_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00098_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC00098_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC00098_n98MedicalIndicationId = new bool[] {false} ;
         AV36GAMErrorResponse = "";
         BC000918_A97ResidentTypeName = new string[] {""} ;
         BC000919_A99MedicalIndicationName = new string[] {""} ;
         BC000920_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000920_A71ResidentGUID = new string[] {""} ;
         BC000920_A66ResidentInitials = new string[] {""} ;
         BC000920_A70ResidentPhone = new string[] {""} ;
         BC000920_A72ResidentSalutation = new string[] {""} ;
         BC000920_A63ResidentBsnNumber = new string[] {""} ;
         BC000920_A64ResidentGivenName = new string[] {""} ;
         BC000920_A65ResidentLastName = new string[] {""} ;
         BC000920_A67ResidentEmail = new string[] {""} ;
         BC000920_A68ResidentGender = new string[] {""} ;
         BC000920_A354ResidentCountry = new string[] {""} ;
         BC000920_A355ResidentCity = new string[] {""} ;
         BC000920_A356ResidentZipCode = new string[] {""} ;
         BC000920_A357ResidentAddressLine1 = new string[] {""} ;
         BC000920_A358ResidentAddressLine2 = new string[] {""} ;
         BC000920_A444ResidentHomePhone = new string[] {""} ;
         BC000920_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC000920_A97ResidentTypeName = new string[] {""} ;
         BC000920_A99MedicalIndicationName = new string[] {""} ;
         BC000920_A375ResidentPhoneCode = new string[] {""} ;
         BC000920_A376ResidentPhoneNumber = new string[] {""} ;
         BC000920_A445ResidentHomePhoneCode = new string[] {""} ;
         BC000920_A446ResidentHomePhoneNumber = new string[] {""} ;
         BC000920_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000920_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000920_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000920_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000920_n98MedicalIndicationId = new bool[] {false} ;
         Z75NetworkIndividualBsnNumber = "";
         A75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         A76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         A77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         A78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         A79NetworkIndividualPhone = "";
         Z388NetworkIndividualPhoneNumber = "";
         A388NetworkIndividualPhoneNumber = "";
         Z387NetworkIndividualPhoneCode = "";
         A387NetworkIndividualPhoneCode = "";
         Z81NetworkIndividualGender = "";
         A81NetworkIndividualGender = "";
         Z344NetworkIndividualCountry = "";
         A344NetworkIndividualCountry = "";
         Z345NetworkIndividualCity = "";
         A345NetworkIndividualCity = "";
         Z346NetworkIndividualZipCode = "";
         A346NetworkIndividualZipCode = "";
         Z347NetworkIndividualAddressLine1 = "";
         A347NetworkIndividualAddressLine1 = "";
         Z348NetworkIndividualAddressLine2 = "";
         A348NetworkIndividualAddressLine2 = "";
         Z74NetworkIndividualId = Guid.Empty;
         A74NetworkIndividualId = Guid.Empty;
         BC000921_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000921_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000921_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000921_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000921_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000921_A77NetworkIndividualLastName = new string[] {""} ;
         BC000921_A78NetworkIndividualEmail = new string[] {""} ;
         BC000921_A79NetworkIndividualPhone = new string[] {""} ;
         BC000921_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000921_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000921_A81NetworkIndividualGender = new string[] {""} ;
         BC000921_A344NetworkIndividualCountry = new string[] {""} ;
         BC000921_A345NetworkIndividualCity = new string[] {""} ;
         BC000921_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000921_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000921_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000921_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC00097_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC00097_A76NetworkIndividualGivenName = new string[] {""} ;
         BC00097_A77NetworkIndividualLastName = new string[] {""} ;
         BC00097_A78NetworkIndividualEmail = new string[] {""} ;
         BC00097_A79NetworkIndividualPhone = new string[] {""} ;
         BC00097_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC00097_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC00097_A81NetworkIndividualGender = new string[] {""} ;
         BC00097_A344NetworkIndividualCountry = new string[] {""} ;
         BC00097_A345NetworkIndividualCity = new string[] {""} ;
         BC00097_A346NetworkIndividualZipCode = new string[] {""} ;
         BC00097_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC00097_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000922_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000922_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000922_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000922_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC00096_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00096_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00096_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00096_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         sMode23 = "";
         BC00095_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00095_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00095_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00095_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000925_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000925_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000925_A77NetworkIndividualLastName = new string[] {""} ;
         BC000925_A78NetworkIndividualEmail = new string[] {""} ;
         BC000925_A79NetworkIndividualPhone = new string[] {""} ;
         BC000925_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000925_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000925_A81NetworkIndividualGender = new string[] {""} ;
         BC000925_A344NetworkIndividualCountry = new string[] {""} ;
         BC000925_A345NetworkIndividualCity = new string[] {""} ;
         BC000925_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000925_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000925_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000926_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000926_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000926_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000926_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000926_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000926_A77NetworkIndividualLastName = new string[] {""} ;
         BC000926_A78NetworkIndividualEmail = new string[] {""} ;
         BC000926_A79NetworkIndividualPhone = new string[] {""} ;
         BC000926_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000926_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000926_A81NetworkIndividualGender = new string[] {""} ;
         BC000926_A344NetworkIndividualCountry = new string[] {""} ;
         BC000926_A345NetworkIndividualCity = new string[] {""} ;
         BC000926_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000926_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000926_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000926_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         Z83NetworkCompanyKvkNumber = "";
         A83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         A84NetworkCompanyName = "";
         Z85NetworkCompanyEmail = "";
         A85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         A86NetworkCompanyPhone = "";
         Z392NetworkCompanyPhoneNumber = "";
         A392NetworkCompanyPhoneNumber = "";
         Z391NetworkCompanyPhoneCode = "";
         A391NetworkCompanyPhoneCode = "";
         Z349NetworkCompanyCountry = "";
         A349NetworkCompanyCountry = "";
         Z350NetworkCompanyCity = "";
         A350NetworkCompanyCity = "";
         Z351NetworkCompanyZipCode = "";
         A351NetworkCompanyZipCode = "";
         Z352NetworkCompanyAddressLine1 = "";
         A352NetworkCompanyAddressLine1 = "";
         Z353NetworkCompanyAddressLine2 = "";
         A353NetworkCompanyAddressLine2 = "";
         Z82NetworkCompanyId = Guid.Empty;
         A82NetworkCompanyId = Guid.Empty;
         BC000927_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000927_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000927_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000927_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000927_A84NetworkCompanyName = new string[] {""} ;
         BC000927_A85NetworkCompanyEmail = new string[] {""} ;
         BC000927_A86NetworkCompanyPhone = new string[] {""} ;
         BC000927_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000927_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000927_A349NetworkCompanyCountry = new string[] {""} ;
         BC000927_A350NetworkCompanyCity = new string[] {""} ;
         BC000927_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000927_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000927_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000927_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC00094_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC00094_A84NetworkCompanyName = new string[] {""} ;
         BC00094_A85NetworkCompanyEmail = new string[] {""} ;
         BC00094_A86NetworkCompanyPhone = new string[] {""} ;
         BC00094_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC00094_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC00094_A349NetworkCompanyCountry = new string[] {""} ;
         BC00094_A350NetworkCompanyCity = new string[] {""} ;
         BC00094_A351NetworkCompanyZipCode = new string[] {""} ;
         BC00094_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC00094_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000928_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000928_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000928_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000928_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00093_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00093_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00093_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00093_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         sMode20 = "";
         BC00092_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00092_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00092_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00092_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000931_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000931_A84NetworkCompanyName = new string[] {""} ;
         BC000931_A85NetworkCompanyEmail = new string[] {""} ;
         BC000931_A86NetworkCompanyPhone = new string[] {""} ;
         BC000931_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000931_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000931_A349NetworkCompanyCountry = new string[] {""} ;
         BC000931_A350NetworkCompanyCity = new string[] {""} ;
         BC000931_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000931_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000931_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000932_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000932_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000932_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000932_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000932_A84NetworkCompanyName = new string[] {""} ;
         BC000932_A85NetworkCompanyEmail = new string[] {""} ;
         BC000932_A86NetworkCompanyPhone = new string[] {""} ;
         BC000932_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000932_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000932_A349NetworkCompanyCountry = new string[] {""} ;
         BC000932_A350NetworkCompanyCity = new string[] {""} ;
         BC000932_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000932_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000932_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000932_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000933_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A62ResidentId, BC00092_A29LocationId, BC00092_A11OrganisationId, BC00092_A82NetworkCompanyId
               }
               , new Object[] {
               BC00093_A62ResidentId, BC00093_A29LocationId, BC00093_A11OrganisationId, BC00093_A82NetworkCompanyId
               }
               , new Object[] {
               BC00094_A83NetworkCompanyKvkNumber, BC00094_A84NetworkCompanyName, BC00094_A85NetworkCompanyEmail, BC00094_A86NetworkCompanyPhone, BC00094_A392NetworkCompanyPhoneNumber, BC00094_A391NetworkCompanyPhoneCode, BC00094_A349NetworkCompanyCountry, BC00094_A350NetworkCompanyCity, BC00094_A351NetworkCompanyZipCode, BC00094_A352NetworkCompanyAddressLine1,
               BC00094_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               BC00095_A62ResidentId, BC00095_A29LocationId, BC00095_A11OrganisationId, BC00095_A74NetworkIndividualId
               }
               , new Object[] {
               BC00096_A62ResidentId, BC00096_A29LocationId, BC00096_A11OrganisationId, BC00096_A74NetworkIndividualId
               }
               , new Object[] {
               BC00097_A75NetworkIndividualBsnNumber, BC00097_A76NetworkIndividualGivenName, BC00097_A77NetworkIndividualLastName, BC00097_A78NetworkIndividualEmail, BC00097_A79NetworkIndividualPhone, BC00097_A388NetworkIndividualPhoneNumber, BC00097_A387NetworkIndividualPhoneCode, BC00097_A81NetworkIndividualGender, BC00097_A344NetworkIndividualCountry, BC00097_A345NetworkIndividualCity,
               BC00097_A346NetworkIndividualZipCode, BC00097_A347NetworkIndividualAddressLine1, BC00097_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               BC00098_A62ResidentId, BC00098_A71ResidentGUID, BC00098_A66ResidentInitials, BC00098_A70ResidentPhone, BC00098_A72ResidentSalutation, BC00098_A63ResidentBsnNumber, BC00098_A64ResidentGivenName, BC00098_A65ResidentLastName, BC00098_A67ResidentEmail, BC00098_A68ResidentGender,
               BC00098_A354ResidentCountry, BC00098_A355ResidentCity, BC00098_A356ResidentZipCode, BC00098_A357ResidentAddressLine1, BC00098_A358ResidentAddressLine2, BC00098_A444ResidentHomePhone, BC00098_A73ResidentBirthDate, BC00098_A375ResidentPhoneCode, BC00098_A376ResidentPhoneNumber, BC00098_A445ResidentHomePhoneCode,
               BC00098_A446ResidentHomePhoneNumber, BC00098_A29LocationId, BC00098_A11OrganisationId, BC00098_A96ResidentTypeId, BC00098_A98MedicalIndicationId, BC00098_n98MedicalIndicationId
               }
               , new Object[] {
               BC00099_A62ResidentId, BC00099_A71ResidentGUID, BC00099_A66ResidentInitials, BC00099_A70ResidentPhone, BC00099_A72ResidentSalutation, BC00099_A63ResidentBsnNumber, BC00099_A64ResidentGivenName, BC00099_A65ResidentLastName, BC00099_A67ResidentEmail, BC00099_A68ResidentGender,
               BC00099_A354ResidentCountry, BC00099_A355ResidentCity, BC00099_A356ResidentZipCode, BC00099_A357ResidentAddressLine1, BC00099_A358ResidentAddressLine2, BC00099_A444ResidentHomePhone, BC00099_A73ResidentBirthDate, BC00099_A375ResidentPhoneCode, BC00099_A376ResidentPhoneNumber, BC00099_A445ResidentHomePhoneCode,
               BC00099_A446ResidentHomePhoneNumber, BC00099_A29LocationId, BC00099_A11OrganisationId, BC00099_A96ResidentTypeId, BC00099_A98MedicalIndicationId, BC00099_n98MedicalIndicationId
               }
               , new Object[] {
               BC000910_A29LocationId
               }
               , new Object[] {
               BC000911_A97ResidentTypeName
               }
               , new Object[] {
               BC000912_A99MedicalIndicationName
               }
               , new Object[] {
               BC000913_A62ResidentId, BC000913_A71ResidentGUID, BC000913_A66ResidentInitials, BC000913_A70ResidentPhone, BC000913_A72ResidentSalutation, BC000913_A63ResidentBsnNumber, BC000913_A64ResidentGivenName, BC000913_A65ResidentLastName, BC000913_A67ResidentEmail, BC000913_A68ResidentGender,
               BC000913_A354ResidentCountry, BC000913_A355ResidentCity, BC000913_A356ResidentZipCode, BC000913_A357ResidentAddressLine1, BC000913_A358ResidentAddressLine2, BC000913_A444ResidentHomePhone, BC000913_A73ResidentBirthDate, BC000913_A97ResidentTypeName, BC000913_A99MedicalIndicationName, BC000913_A375ResidentPhoneCode,
               BC000913_A376ResidentPhoneNumber, BC000913_A445ResidentHomePhoneCode, BC000913_A446ResidentHomePhoneNumber, BC000913_A29LocationId, BC000913_A11OrganisationId, BC000913_A96ResidentTypeId, BC000913_A98MedicalIndicationId, BC000913_n98MedicalIndicationId
               }
               , new Object[] {
               BC000914_A62ResidentId, BC000914_A29LocationId, BC000914_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000918_A97ResidentTypeName
               }
               , new Object[] {
               BC000919_A99MedicalIndicationName
               }
               , new Object[] {
               BC000920_A62ResidentId, BC000920_A71ResidentGUID, BC000920_A66ResidentInitials, BC000920_A70ResidentPhone, BC000920_A72ResidentSalutation, BC000920_A63ResidentBsnNumber, BC000920_A64ResidentGivenName, BC000920_A65ResidentLastName, BC000920_A67ResidentEmail, BC000920_A68ResidentGender,
               BC000920_A354ResidentCountry, BC000920_A355ResidentCity, BC000920_A356ResidentZipCode, BC000920_A357ResidentAddressLine1, BC000920_A358ResidentAddressLine2, BC000920_A444ResidentHomePhone, BC000920_A73ResidentBirthDate, BC000920_A97ResidentTypeName, BC000920_A99MedicalIndicationName, BC000920_A375ResidentPhoneCode,
               BC000920_A376ResidentPhoneNumber, BC000920_A445ResidentHomePhoneCode, BC000920_A446ResidentHomePhoneNumber, BC000920_A29LocationId, BC000920_A11OrganisationId, BC000920_A96ResidentTypeId, BC000920_A98MedicalIndicationId, BC000920_n98MedicalIndicationId
               }
               , new Object[] {
               BC000921_A62ResidentId, BC000921_A29LocationId, BC000921_A11OrganisationId, BC000921_A75NetworkIndividualBsnNumber, BC000921_A76NetworkIndividualGivenName, BC000921_A77NetworkIndividualLastName, BC000921_A78NetworkIndividualEmail, BC000921_A79NetworkIndividualPhone, BC000921_A388NetworkIndividualPhoneNumber, BC000921_A387NetworkIndividualPhoneCode,
               BC000921_A81NetworkIndividualGender, BC000921_A344NetworkIndividualCountry, BC000921_A345NetworkIndividualCity, BC000921_A346NetworkIndividualZipCode, BC000921_A347NetworkIndividualAddressLine1, BC000921_A348NetworkIndividualAddressLine2, BC000921_A74NetworkIndividualId
               }
               , new Object[] {
               BC000922_A62ResidentId, BC000922_A29LocationId, BC000922_A11OrganisationId, BC000922_A74NetworkIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000925_A75NetworkIndividualBsnNumber, BC000925_A76NetworkIndividualGivenName, BC000925_A77NetworkIndividualLastName, BC000925_A78NetworkIndividualEmail, BC000925_A79NetworkIndividualPhone, BC000925_A388NetworkIndividualPhoneNumber, BC000925_A387NetworkIndividualPhoneCode, BC000925_A81NetworkIndividualGender, BC000925_A344NetworkIndividualCountry, BC000925_A345NetworkIndividualCity,
               BC000925_A346NetworkIndividualZipCode, BC000925_A347NetworkIndividualAddressLine1, BC000925_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               BC000926_A62ResidentId, BC000926_A29LocationId, BC000926_A11OrganisationId, BC000926_A75NetworkIndividualBsnNumber, BC000926_A76NetworkIndividualGivenName, BC000926_A77NetworkIndividualLastName, BC000926_A78NetworkIndividualEmail, BC000926_A79NetworkIndividualPhone, BC000926_A388NetworkIndividualPhoneNumber, BC000926_A387NetworkIndividualPhoneCode,
               BC000926_A81NetworkIndividualGender, BC000926_A344NetworkIndividualCountry, BC000926_A345NetworkIndividualCity, BC000926_A346NetworkIndividualZipCode, BC000926_A347NetworkIndividualAddressLine1, BC000926_A348NetworkIndividualAddressLine2, BC000926_A74NetworkIndividualId
               }
               , new Object[] {
               BC000927_A62ResidentId, BC000927_A29LocationId, BC000927_A11OrganisationId, BC000927_A83NetworkCompanyKvkNumber, BC000927_A84NetworkCompanyName, BC000927_A85NetworkCompanyEmail, BC000927_A86NetworkCompanyPhone, BC000927_A392NetworkCompanyPhoneNumber, BC000927_A391NetworkCompanyPhoneCode, BC000927_A349NetworkCompanyCountry,
               BC000927_A350NetworkCompanyCity, BC000927_A351NetworkCompanyZipCode, BC000927_A352NetworkCompanyAddressLine1, BC000927_A353NetworkCompanyAddressLine2, BC000927_A82NetworkCompanyId
               }
               , new Object[] {
               BC000928_A82NetworkCompanyId, BC000928_A62ResidentId, BC000928_A29LocationId, BC000928_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000931_A83NetworkCompanyKvkNumber, BC000931_A84NetworkCompanyName, BC000931_A85NetworkCompanyEmail, BC000931_A86NetworkCompanyPhone, BC000931_A392NetworkCompanyPhoneNumber, BC000931_A391NetworkCompanyPhoneCode, BC000931_A349NetworkCompanyCountry, BC000931_A350NetworkCompanyCity, BC000931_A351NetworkCompanyZipCode, BC000931_A352NetworkCompanyAddressLine1,
               BC000931_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               BC000932_A62ResidentId, BC000932_A29LocationId, BC000932_A11OrganisationId, BC000932_A83NetworkCompanyKvkNumber, BC000932_A84NetworkCompanyName, BC000932_A85NetworkCompanyEmail, BC000932_A86NetworkCompanyPhone, BC000932_A392NetworkCompanyPhoneNumber, BC000932_A391NetworkCompanyPhoneCode, BC000932_A349NetworkCompanyCountry,
               BC000932_A350NetworkCompanyCity, BC000932_A351NetworkCompanyZipCode, BC000932_A352NetworkCompanyAddressLine1, BC000932_A353NetworkCompanyAddressLine2, BC000932_A82NetworkCompanyId
               }
               , new Object[] {
               BC000933_A29LocationId
               }
            }
         );
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         AV45Pgmname = "Trn_Resident_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12092 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_20 ;
      private short RcdFound20 ;
      private short nIsMod_23 ;
      private short RcdFound23 ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nRcdExists_23 ;
      private short nRcdExists_20 ;
      private short Gxremove23 ;
      private short Gxremove20 ;
      private int trnEnded ;
      private int nGXsfl_20_idx=1 ;
      private int nGXsfl_23_idx=1 ;
      private int AV46GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private string AV45Pgmname ;
      private string Z66ResidentInitials ;
      private string A66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string A70ResidentPhone ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string Z444ResidentHomePhone ;
      private string A444ResidentHomePhone ;
      private string GXt_char2 ;
      private string Z79NetworkIndividualPhone ;
      private string A79NetworkIndividualPhone ;
      private string sMode23 ;
      private string Z86NetworkCompanyPhone ;
      private string A86NetworkCompanyPhone ;
      private string sMode20 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool returnInSub ;
      private bool n98MedicalIndicationId ;
      private bool Gx_longc ;
      private string AV36GAMErrorResponse ;
      private string Z71ResidentGUID ;
      private string A71ResidentGUID ;
      private string Z63ResidentBsnNumber ;
      private string A63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string A64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string A65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string A67ResidentEmail ;
      private string Z68ResidentGender ;
      private string A68ResidentGender ;
      private string Z354ResidentCountry ;
      private string A354ResidentCountry ;
      private string Z355ResidentCity ;
      private string A355ResidentCity ;
      private string Z356ResidentZipCode ;
      private string A356ResidentZipCode ;
      private string Z357ResidentAddressLine1 ;
      private string A357ResidentAddressLine1 ;
      private string Z358ResidentAddressLine2 ;
      private string A358ResidentAddressLine2 ;
      private string Z375ResidentPhoneCode ;
      private string A375ResidentPhoneCode ;
      private string Z376ResidentPhoneNumber ;
      private string A376ResidentPhoneNumber ;
      private string Z445ResidentHomePhoneCode ;
      private string A445ResidentHomePhoneCode ;
      private string Z446ResidentHomePhoneNumber ;
      private string A446ResidentHomePhoneNumber ;
      private string Z97ResidentTypeName ;
      private string A97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string A99MedicalIndicationName ;
      private string Z75NetworkIndividualBsnNumber ;
      private string A75NetworkIndividualBsnNumber ;
      private string Z76NetworkIndividualGivenName ;
      private string A76NetworkIndividualGivenName ;
      private string Z77NetworkIndividualLastName ;
      private string A77NetworkIndividualLastName ;
      private string Z78NetworkIndividualEmail ;
      private string A78NetworkIndividualEmail ;
      private string Z388NetworkIndividualPhoneNumber ;
      private string A388NetworkIndividualPhoneNumber ;
      private string Z387NetworkIndividualPhoneCode ;
      private string A387NetworkIndividualPhoneCode ;
      private string Z81NetworkIndividualGender ;
      private string A81NetworkIndividualGender ;
      private string Z344NetworkIndividualCountry ;
      private string A344NetworkIndividualCountry ;
      private string Z345NetworkIndividualCity ;
      private string A345NetworkIndividualCity ;
      private string Z346NetworkIndividualZipCode ;
      private string A346NetworkIndividualZipCode ;
      private string Z347NetworkIndividualAddressLine1 ;
      private string A347NetworkIndividualAddressLine1 ;
      private string Z348NetworkIndividualAddressLine2 ;
      private string A348NetworkIndividualAddressLine2 ;
      private string Z83NetworkCompanyKvkNumber ;
      private string A83NetworkCompanyKvkNumber ;
      private string Z84NetworkCompanyName ;
      private string A84NetworkCompanyName ;
      private string Z85NetworkCompanyEmail ;
      private string A85NetworkCompanyEmail ;
      private string Z392NetworkCompanyPhoneNumber ;
      private string A392NetworkCompanyPhoneNumber ;
      private string Z391NetworkCompanyPhoneCode ;
      private string A391NetworkCompanyPhoneCode ;
      private string Z349NetworkCompanyCountry ;
      private string A349NetworkCompanyCountry ;
      private string Z350NetworkCompanyCity ;
      private string A350NetworkCompanyCity ;
      private string Z351NetworkCompanyZipCode ;
      private string A351NetworkCompanyZipCode ;
      private string Z352NetworkCompanyAddressLine1 ;
      private string A352NetworkCompanyAddressLine1 ;
      private string Z353NetworkCompanyAddressLine2 ;
      private string A353NetworkCompanyAddressLine2 ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV15Insert_ResidentTypeId ;
      private Guid AV16Insert_MedicalIndicationId ;
      private Guid Z96ResidentTypeId ;
      private Guid A96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid A98MedicalIndicationId ;
      private Guid GXt_guid1 ;
      private Guid Z74NetworkIndividualId ;
      private Guid A74NetworkIndividualId ;
      private Guid Z82NetworkCompanyId ;
      private Guid A82NetworkCompanyId ;
      private IGxSession AV14WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Resident bcTrn_Resident ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000913_A62ResidentId ;
      private string[] BC000913_A71ResidentGUID ;
      private string[] BC000913_A66ResidentInitials ;
      private string[] BC000913_A70ResidentPhone ;
      private string[] BC000913_A72ResidentSalutation ;
      private string[] BC000913_A63ResidentBsnNumber ;
      private string[] BC000913_A64ResidentGivenName ;
      private string[] BC000913_A65ResidentLastName ;
      private string[] BC000913_A67ResidentEmail ;
      private string[] BC000913_A68ResidentGender ;
      private string[] BC000913_A354ResidentCountry ;
      private string[] BC000913_A355ResidentCity ;
      private string[] BC000913_A356ResidentZipCode ;
      private string[] BC000913_A357ResidentAddressLine1 ;
      private string[] BC000913_A358ResidentAddressLine2 ;
      private string[] BC000913_A444ResidentHomePhone ;
      private DateTime[] BC000913_A73ResidentBirthDate ;
      private string[] BC000913_A97ResidentTypeName ;
      private string[] BC000913_A99MedicalIndicationName ;
      private string[] BC000913_A375ResidentPhoneCode ;
      private string[] BC000913_A376ResidentPhoneNumber ;
      private string[] BC000913_A445ResidentHomePhoneCode ;
      private string[] BC000913_A446ResidentHomePhoneNumber ;
      private Guid[] BC000913_A29LocationId ;
      private Guid[] BC000913_A11OrganisationId ;
      private Guid[] BC000913_A96ResidentTypeId ;
      private Guid[] BC000913_A98MedicalIndicationId ;
      private bool[] BC000913_n98MedicalIndicationId ;
      private Guid[] BC000910_A29LocationId ;
      private string[] BC000911_A97ResidentTypeName ;
      private string[] BC000912_A99MedicalIndicationName ;
      private Guid[] BC000914_A62ResidentId ;
      private Guid[] BC000914_A29LocationId ;
      private Guid[] BC000914_A11OrganisationId ;
      private Guid[] BC00099_A62ResidentId ;
      private string[] BC00099_A71ResidentGUID ;
      private string[] BC00099_A66ResidentInitials ;
      private string[] BC00099_A70ResidentPhone ;
      private string[] BC00099_A72ResidentSalutation ;
      private string[] BC00099_A63ResidentBsnNumber ;
      private string[] BC00099_A64ResidentGivenName ;
      private string[] BC00099_A65ResidentLastName ;
      private string[] BC00099_A67ResidentEmail ;
      private string[] BC00099_A68ResidentGender ;
      private string[] BC00099_A354ResidentCountry ;
      private string[] BC00099_A355ResidentCity ;
      private string[] BC00099_A356ResidentZipCode ;
      private string[] BC00099_A357ResidentAddressLine1 ;
      private string[] BC00099_A358ResidentAddressLine2 ;
      private string[] BC00099_A444ResidentHomePhone ;
      private DateTime[] BC00099_A73ResidentBirthDate ;
      private string[] BC00099_A375ResidentPhoneCode ;
      private string[] BC00099_A376ResidentPhoneNumber ;
      private string[] BC00099_A445ResidentHomePhoneCode ;
      private string[] BC00099_A446ResidentHomePhoneNumber ;
      private Guid[] BC00099_A29LocationId ;
      private Guid[] BC00099_A11OrganisationId ;
      private Guid[] BC00099_A96ResidentTypeId ;
      private Guid[] BC00099_A98MedicalIndicationId ;
      private bool[] BC00099_n98MedicalIndicationId ;
      private Guid[] BC00098_A62ResidentId ;
      private string[] BC00098_A71ResidentGUID ;
      private string[] BC00098_A66ResidentInitials ;
      private string[] BC00098_A70ResidentPhone ;
      private string[] BC00098_A72ResidentSalutation ;
      private string[] BC00098_A63ResidentBsnNumber ;
      private string[] BC00098_A64ResidentGivenName ;
      private string[] BC00098_A65ResidentLastName ;
      private string[] BC00098_A67ResidentEmail ;
      private string[] BC00098_A68ResidentGender ;
      private string[] BC00098_A354ResidentCountry ;
      private string[] BC00098_A355ResidentCity ;
      private string[] BC00098_A356ResidentZipCode ;
      private string[] BC00098_A357ResidentAddressLine1 ;
      private string[] BC00098_A358ResidentAddressLine2 ;
      private string[] BC00098_A444ResidentHomePhone ;
      private DateTime[] BC00098_A73ResidentBirthDate ;
      private string[] BC00098_A375ResidentPhoneCode ;
      private string[] BC00098_A376ResidentPhoneNumber ;
      private string[] BC00098_A445ResidentHomePhoneCode ;
      private string[] BC00098_A446ResidentHomePhoneNumber ;
      private Guid[] BC00098_A29LocationId ;
      private Guid[] BC00098_A11OrganisationId ;
      private Guid[] BC00098_A96ResidentTypeId ;
      private Guid[] BC00098_A98MedicalIndicationId ;
      private bool[] BC00098_n98MedicalIndicationId ;
      private string[] BC000918_A97ResidentTypeName ;
      private string[] BC000919_A99MedicalIndicationName ;
      private Guid[] BC000920_A62ResidentId ;
      private string[] BC000920_A71ResidentGUID ;
      private string[] BC000920_A66ResidentInitials ;
      private string[] BC000920_A70ResidentPhone ;
      private string[] BC000920_A72ResidentSalutation ;
      private string[] BC000920_A63ResidentBsnNumber ;
      private string[] BC000920_A64ResidentGivenName ;
      private string[] BC000920_A65ResidentLastName ;
      private string[] BC000920_A67ResidentEmail ;
      private string[] BC000920_A68ResidentGender ;
      private string[] BC000920_A354ResidentCountry ;
      private string[] BC000920_A355ResidentCity ;
      private string[] BC000920_A356ResidentZipCode ;
      private string[] BC000920_A357ResidentAddressLine1 ;
      private string[] BC000920_A358ResidentAddressLine2 ;
      private string[] BC000920_A444ResidentHomePhone ;
      private DateTime[] BC000920_A73ResidentBirthDate ;
      private string[] BC000920_A97ResidentTypeName ;
      private string[] BC000920_A99MedicalIndicationName ;
      private string[] BC000920_A375ResidentPhoneCode ;
      private string[] BC000920_A376ResidentPhoneNumber ;
      private string[] BC000920_A445ResidentHomePhoneCode ;
      private string[] BC000920_A446ResidentHomePhoneNumber ;
      private Guid[] BC000920_A29LocationId ;
      private Guid[] BC000920_A11OrganisationId ;
      private Guid[] BC000920_A96ResidentTypeId ;
      private Guid[] BC000920_A98MedicalIndicationId ;
      private bool[] BC000920_n98MedicalIndicationId ;
      private Guid[] BC000921_A62ResidentId ;
      private Guid[] BC000921_A29LocationId ;
      private Guid[] BC000921_A11OrganisationId ;
      private string[] BC000921_A75NetworkIndividualBsnNumber ;
      private string[] BC000921_A76NetworkIndividualGivenName ;
      private string[] BC000921_A77NetworkIndividualLastName ;
      private string[] BC000921_A78NetworkIndividualEmail ;
      private string[] BC000921_A79NetworkIndividualPhone ;
      private string[] BC000921_A388NetworkIndividualPhoneNumber ;
      private string[] BC000921_A387NetworkIndividualPhoneCode ;
      private string[] BC000921_A81NetworkIndividualGender ;
      private string[] BC000921_A344NetworkIndividualCountry ;
      private string[] BC000921_A345NetworkIndividualCity ;
      private string[] BC000921_A346NetworkIndividualZipCode ;
      private string[] BC000921_A347NetworkIndividualAddressLine1 ;
      private string[] BC000921_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000921_A74NetworkIndividualId ;
      private string[] BC00097_A75NetworkIndividualBsnNumber ;
      private string[] BC00097_A76NetworkIndividualGivenName ;
      private string[] BC00097_A77NetworkIndividualLastName ;
      private string[] BC00097_A78NetworkIndividualEmail ;
      private string[] BC00097_A79NetworkIndividualPhone ;
      private string[] BC00097_A388NetworkIndividualPhoneNumber ;
      private string[] BC00097_A387NetworkIndividualPhoneCode ;
      private string[] BC00097_A81NetworkIndividualGender ;
      private string[] BC00097_A344NetworkIndividualCountry ;
      private string[] BC00097_A345NetworkIndividualCity ;
      private string[] BC00097_A346NetworkIndividualZipCode ;
      private string[] BC00097_A347NetworkIndividualAddressLine1 ;
      private string[] BC00097_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000922_A62ResidentId ;
      private Guid[] BC000922_A29LocationId ;
      private Guid[] BC000922_A11OrganisationId ;
      private Guid[] BC000922_A74NetworkIndividualId ;
      private Guid[] BC00096_A62ResidentId ;
      private Guid[] BC00096_A29LocationId ;
      private Guid[] BC00096_A11OrganisationId ;
      private Guid[] BC00096_A74NetworkIndividualId ;
      private Guid[] BC00095_A62ResidentId ;
      private Guid[] BC00095_A29LocationId ;
      private Guid[] BC00095_A11OrganisationId ;
      private Guid[] BC00095_A74NetworkIndividualId ;
      private string[] BC000925_A75NetworkIndividualBsnNumber ;
      private string[] BC000925_A76NetworkIndividualGivenName ;
      private string[] BC000925_A77NetworkIndividualLastName ;
      private string[] BC000925_A78NetworkIndividualEmail ;
      private string[] BC000925_A79NetworkIndividualPhone ;
      private string[] BC000925_A388NetworkIndividualPhoneNumber ;
      private string[] BC000925_A387NetworkIndividualPhoneCode ;
      private string[] BC000925_A81NetworkIndividualGender ;
      private string[] BC000925_A344NetworkIndividualCountry ;
      private string[] BC000925_A345NetworkIndividualCity ;
      private string[] BC000925_A346NetworkIndividualZipCode ;
      private string[] BC000925_A347NetworkIndividualAddressLine1 ;
      private string[] BC000925_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000926_A62ResidentId ;
      private Guid[] BC000926_A29LocationId ;
      private Guid[] BC000926_A11OrganisationId ;
      private string[] BC000926_A75NetworkIndividualBsnNumber ;
      private string[] BC000926_A76NetworkIndividualGivenName ;
      private string[] BC000926_A77NetworkIndividualLastName ;
      private string[] BC000926_A78NetworkIndividualEmail ;
      private string[] BC000926_A79NetworkIndividualPhone ;
      private string[] BC000926_A388NetworkIndividualPhoneNumber ;
      private string[] BC000926_A387NetworkIndividualPhoneCode ;
      private string[] BC000926_A81NetworkIndividualGender ;
      private string[] BC000926_A344NetworkIndividualCountry ;
      private string[] BC000926_A345NetworkIndividualCity ;
      private string[] BC000926_A346NetworkIndividualZipCode ;
      private string[] BC000926_A347NetworkIndividualAddressLine1 ;
      private string[] BC000926_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000926_A74NetworkIndividualId ;
      private Guid[] BC000927_A62ResidentId ;
      private Guid[] BC000927_A29LocationId ;
      private Guid[] BC000927_A11OrganisationId ;
      private string[] BC000927_A83NetworkCompanyKvkNumber ;
      private string[] BC000927_A84NetworkCompanyName ;
      private string[] BC000927_A85NetworkCompanyEmail ;
      private string[] BC000927_A86NetworkCompanyPhone ;
      private string[] BC000927_A392NetworkCompanyPhoneNumber ;
      private string[] BC000927_A391NetworkCompanyPhoneCode ;
      private string[] BC000927_A349NetworkCompanyCountry ;
      private string[] BC000927_A350NetworkCompanyCity ;
      private string[] BC000927_A351NetworkCompanyZipCode ;
      private string[] BC000927_A352NetworkCompanyAddressLine1 ;
      private string[] BC000927_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000927_A82NetworkCompanyId ;
      private string[] BC00094_A83NetworkCompanyKvkNumber ;
      private string[] BC00094_A84NetworkCompanyName ;
      private string[] BC00094_A85NetworkCompanyEmail ;
      private string[] BC00094_A86NetworkCompanyPhone ;
      private string[] BC00094_A392NetworkCompanyPhoneNumber ;
      private string[] BC00094_A391NetworkCompanyPhoneCode ;
      private string[] BC00094_A349NetworkCompanyCountry ;
      private string[] BC00094_A350NetworkCompanyCity ;
      private string[] BC00094_A351NetworkCompanyZipCode ;
      private string[] BC00094_A352NetworkCompanyAddressLine1 ;
      private string[] BC00094_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000928_A82NetworkCompanyId ;
      private Guid[] BC000928_A62ResidentId ;
      private Guid[] BC000928_A29LocationId ;
      private Guid[] BC000928_A11OrganisationId ;
      private Guid[] BC00093_A62ResidentId ;
      private Guid[] BC00093_A29LocationId ;
      private Guid[] BC00093_A11OrganisationId ;
      private Guid[] BC00093_A82NetworkCompanyId ;
      private Guid[] BC00092_A62ResidentId ;
      private Guid[] BC00092_A29LocationId ;
      private Guid[] BC00092_A11OrganisationId ;
      private Guid[] BC00092_A82NetworkCompanyId ;
      private string[] BC000931_A83NetworkCompanyKvkNumber ;
      private string[] BC000931_A84NetworkCompanyName ;
      private string[] BC000931_A85NetworkCompanyEmail ;
      private string[] BC000931_A86NetworkCompanyPhone ;
      private string[] BC000931_A392NetworkCompanyPhoneNumber ;
      private string[] BC000931_A391NetworkCompanyPhoneCode ;
      private string[] BC000931_A349NetworkCompanyCountry ;
      private string[] BC000931_A350NetworkCompanyCity ;
      private string[] BC000931_A351NetworkCompanyZipCode ;
      private string[] BC000931_A352NetworkCompanyAddressLine1 ;
      private string[] BC000931_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000932_A62ResidentId ;
      private Guid[] BC000932_A29LocationId ;
      private Guid[] BC000932_A11OrganisationId ;
      private string[] BC000932_A83NetworkCompanyKvkNumber ;
      private string[] BC000932_A84NetworkCompanyName ;
      private string[] BC000932_A85NetworkCompanyEmail ;
      private string[] BC000932_A86NetworkCompanyPhone ;
      private string[] BC000932_A392NetworkCompanyPhoneNumber ;
      private string[] BC000932_A391NetworkCompanyPhoneCode ;
      private string[] BC000932_A349NetworkCompanyCountry ;
      private string[] BC000932_A350NetworkCompanyCity ;
      private string[] BC000932_A351NetworkCompanyZipCode ;
      private string[] BC000932_A352NetworkCompanyAddressLine1 ;
      private string[] BC000932_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000932_A82NetworkCompanyId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000933_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_resident_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_resident_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_resident_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new ForEachCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00092;
       prmBC00092 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00093;
       prmBC00093 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00094;
       prmBC00094 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00095;
       prmBC00095 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00096;
       prmBC00096 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00097;
       prmBC00097 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00098;
       prmBC00098 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00099;
       prmBC00099 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000910;
       prmBC000910 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000911;
       prmBC000911 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000912;
       prmBC000912 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000913;
       prmBC000913 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000914;
       prmBC000914 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000915;
       prmBC000915 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000916;
       prmBC000916 = new Object[] {
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000917;
       prmBC000917 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000918;
       prmBC000918 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000919;
       prmBC000919 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000920;
       prmBC000920 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000921;
       prmBC000921 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000922;
       prmBC000922 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000923;
       prmBC000923 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000924;
       prmBC000924 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000925;
       prmBC000925 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000926;
       prmBC000926 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000927;
       prmBC000927 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000928;
       prmBC000928 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000929;
       prmBC000929 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000930;
       prmBC000930 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000931;
       prmBC000931 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000932;
       prmBC000932 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000933;
       prmBC000933 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00092", "SELECT ResidentId, LocationId, OrganisationId, NetworkCompanyId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_ResidentNetworkCompany",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00093", "SELECT ResidentId, LocationId, OrganisationId, NetworkCompanyId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00094", "SELECT NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneNumber, NetworkCompanyPhoneCode, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00095", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId  FOR UPDATE OF Trn_ResidentNetworkIndividual",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00096", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00097", "SELECT NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00097,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00098", "SELECT ResidentId, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00099", "SELECT ResidentId, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000910", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000910,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000911", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000911,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000912", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000912,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000913", "SELECT TM1.ResidentId, TM1.ResidentGUID, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCountry, TM1.ResidentCity, TM1.ResidentZipCode, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentHomePhone, TM1.ResidentBirthDate, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneCode, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneCode, TM1.ResidentHomePhoneNumber, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId FROM ((Trn_Resident TM1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000913,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000914", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000914,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000915", "SAVEPOINT gxupdate;INSERT INTO Trn_Resident(ResidentId, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId) VALUES(:ResidentId, :ResidentGUID, :ResidentInitials, :ResidentPhone, :ResidentSalutation, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentCountry, :ResidentCity, :ResidentZipCode, :ResidentAddressLine1, :ResidentAddressLine2, :ResidentHomePhone, :ResidentBirthDate, :ResidentPhoneCode, :ResidentPhoneNumber, :ResidentHomePhoneCode, :ResidentHomePhoneNumber, :LocationId, :OrganisationId, :ResidentTypeId, :MedicalIndicationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000915)
          ,new CursorDef("BC000916", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentGUID=:ResidentGUID, ResidentInitials=:ResidentInitials, ResidentPhone=:ResidentPhone, ResidentSalutation=:ResidentSalutation, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentCountry=:ResidentCountry, ResidentCity=:ResidentCity, ResidentZipCode=:ResidentZipCode, ResidentAddressLine1=:ResidentAddressLine1, ResidentAddressLine2=:ResidentAddressLine2, ResidentHomePhone=:ResidentHomePhone, ResidentBirthDate=:ResidentBirthDate, ResidentPhoneCode=:ResidentPhoneCode, ResidentPhoneNumber=:ResidentPhoneNumber, ResidentHomePhoneCode=:ResidentHomePhoneCode, ResidentHomePhoneNumber=:ResidentHomePhoneNumber, ResidentTypeId=:ResidentTypeId, MedicalIndicationId=:MedicalIndicationId  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000916)
          ,new CursorDef("BC000917", "SAVEPOINT gxupdate;DELETE FROM Trn_Resident  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000917)
          ,new CursorDef("BC000918", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000918,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000919", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000919,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000920", "SELECT TM1.ResidentId, TM1.ResidentGUID, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCountry, TM1.ResidentCity, TM1.ResidentZipCode, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentHomePhone, TM1.ResidentBirthDate, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneCode, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneCode, TM1.ResidentHomePhoneNumber, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId FROM ((Trn_Resident TM1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000920,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000921", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2, T1.NetworkIndividualId FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId and T1.NetworkIndividualId = :NetworkIndividualId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000921,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000922", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000922,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000923", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNetworkIndividual(ResidentId, LocationId, OrganisationId, NetworkIndividualId) VALUES(:ResidentId, :LocationId, :OrganisationId, :NetworkIndividualId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000923)
          ,new CursorDef("BC000924", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNetworkIndividual  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000924)
          ,new CursorDef("BC000925", "SELECT NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000925,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000926", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2, T1.NetworkIndividualId FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000926,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000927", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2, T1.NetworkCompanyId FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.NetworkCompanyId = :NetworkCompanyId and T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.NetworkCompanyId, T1.ResidentId, T1.LocationId, T1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000927,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000928", "SELECT NetworkCompanyId, ResidentId, LocationId, OrganisationId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000928,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000929", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNetworkCompany(ResidentId, LocationId, OrganisationId, NetworkCompanyId) VALUES(:ResidentId, :LocationId, :OrganisationId, :NetworkCompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000929)
          ,new CursorDef("BC000930", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNetworkCompany  WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000930)
          ,new CursorDef("BC000931", "SELECT NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneNumber, NetworkCompanyPhoneCode, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000931,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000932", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2, T1.NetworkCompanyId FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.NetworkCompanyId, T1.ResidentId, T1.LocationId, T1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000932,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000933", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000933,1, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
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
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
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
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
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
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((Guid[]) buf[25])[0] = rslt.getGuid(26);
             ((Guid[]) buf[26])[0] = rslt.getGuid(27);
             ((bool[]) buf[27])[0] = rslt.wasNull(27);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 17 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
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
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((Guid[]) buf[25])[0] = rslt.getGuid(26);
             ((Guid[]) buf[26])[0] = rslt.getGuid(27);
             ((bool[]) buf[27])[0] = rslt.wasNull(27);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
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
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 23 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
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
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 29 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             return;
          case 31 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
