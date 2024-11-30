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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class loadaudittrn_resident : GXProcedure
   {
      public loadaudittrn_resident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittrn_resident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_ResidentId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId ,
                           string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ResidentId = aP2_ResidentId;
         this.AV18LocationId = aP3_LocationId;
         this.AV19OrganisationId = aP4_OrganisationId;
         this.AV15ActualMode = aP5_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_ResidentId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId ,
                                 string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ResidentId = aP2_ResidentId;
         this.AV18LocationId = aP3_LocationId;
         this.AV19OrganisationId = aP4_OrganisationId;
         this.AV15ActualMode = aP5_ActualMode;
         SubmitImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P008G2 */
         pr_default.execute(0, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P008G2_A11OrganisationId[0];
            A29LocationId = P008G2_A29LocationId[0];
            A62ResidentId = P008G2_A62ResidentId[0];
            A72ResidentSalutation = P008G2_A72ResidentSalutation[0];
            A63ResidentBsnNumber = P008G2_A63ResidentBsnNumber[0];
            A64ResidentGivenName = P008G2_A64ResidentGivenName[0];
            A65ResidentLastName = P008G2_A65ResidentLastName[0];
            A66ResidentInitials = P008G2_A66ResidentInitials[0];
            A67ResidentEmail = P008G2_A67ResidentEmail[0];
            A68ResidentGender = P008G2_A68ResidentGender[0];
            A354ResidentCountry = P008G2_A354ResidentCountry[0];
            A355ResidentCity = P008G2_A355ResidentCity[0];
            A356ResidentZipCode = P008G2_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = P008G2_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = P008G2_A358ResidentAddressLine2[0];
            A70ResidentPhone = P008G2_A70ResidentPhone[0];
            A444ResidentHomePhone = P008G2_A444ResidentHomePhone[0];
            A73ResidentBirthDate = P008G2_A73ResidentBirthDate[0];
            A71ResidentGUID = P008G2_A71ResidentGUID[0];
            A96ResidentTypeId = P008G2_A96ResidentTypeId[0];
            A97ResidentTypeName = P008G2_A97ResidentTypeName[0];
            A98MedicalIndicationId = P008G2_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P008G2_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P008G2_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = P008G2_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = P008G2_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = P008G2_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = P008G2_A446ResidentHomePhoneNumber[0];
            A97ResidentTypeName = P008G2_A97ResidentTypeName[0];
            A99MedicalIndicationName = P008G2_A99MedicalIndicationName[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Resident";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A62ResidentId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A29LocationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A11OrganisationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentSalutation";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Salutation", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A72ResidentSalutation;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentBsnNumber";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "BSN Number", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A63ResidentBsnNumber;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGivenName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A64ResidentGivenName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentLastName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A65ResidentLastName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentInitials";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A66ResidentInitials;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentEmail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A67ResidentEmail;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGender";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Gender", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A68ResidentGender;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentCountry";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Country", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A354ResidentCountry;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentCity";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "City", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A355ResidentCity;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentZipCode";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Zip Code", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A356ResidentZipCode;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentAddressLine1";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Address Line 1", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A357ResidentAddressLine1;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentAddressLine2";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Address Line 2", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A358ResidentAddressLine2;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A70ResidentPhone;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Home Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A444ResidentHomePhone;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentBirthDate";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Birth Date", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A73ResidentBirthDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGUID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GUID", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A71ResidentGUID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentTypeId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Resident Type", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A96ResidentTypeId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentTypeName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Resident Type Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A97ResidentTypeName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MedicalIndicationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Medical Indication", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A98MedicalIndicationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MedicalIndicationName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Medical Indication Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A99MedicalIndicationName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhoneCode";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Mobile Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A375ResidentPhoneCode;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhoneNumber";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A376ResidentPhoneNumber;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhoneCode";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Home Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A445ResidentHomePhoneCode;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhoneNumber";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A446ResidentHomePhoneNumber;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Using cursor P008G3 */
            pr_default.execute(1, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A74NetworkIndividualId = P008G3_A74NetworkIndividualId[0];
               A75NetworkIndividualBsnNumber = P008G3_A75NetworkIndividualBsnNumber[0];
               A76NetworkIndividualGivenName = P008G3_A76NetworkIndividualGivenName[0];
               A77NetworkIndividualLastName = P008G3_A77NetworkIndividualLastName[0];
               A78NetworkIndividualEmail = P008G3_A78NetworkIndividualEmail[0];
               A79NetworkIndividualPhone = P008G3_A79NetworkIndividualPhone[0];
               A388NetworkIndividualPhoneNumber = P008G3_A388NetworkIndividualPhoneNumber[0];
               A387NetworkIndividualPhoneCode = P008G3_A387NetworkIndividualPhoneCode[0];
               A81NetworkIndividualGender = P008G3_A81NetworkIndividualGender[0];
               A344NetworkIndividualCountry = P008G3_A344NetworkIndividualCountry[0];
               A345NetworkIndividualCity = P008G3_A345NetworkIndividualCity[0];
               A346NetworkIndividualZipCode = P008G3_A346NetworkIndividualZipCode[0];
               A347NetworkIndividualAddressLine1 = P008G3_A347NetworkIndividualAddressLine1[0];
               A348NetworkIndividualAddressLine2 = P008G3_A348NetworkIndividualAddressLine2[0];
               A75NetworkIndividualBsnNumber = P008G3_A75NetworkIndividualBsnNumber[0];
               A76NetworkIndividualGivenName = P008G3_A76NetworkIndividualGivenName[0];
               A77NetworkIndividualLastName = P008G3_A77NetworkIndividualLastName[0];
               A78NetworkIndividualEmail = P008G3_A78NetworkIndividualEmail[0];
               A79NetworkIndividualPhone = P008G3_A79NetworkIndividualPhone[0];
               A388NetworkIndividualPhoneNumber = P008G3_A388NetworkIndividualPhoneNumber[0];
               A387NetworkIndividualPhoneCode = P008G3_A387NetworkIndividualPhoneCode[0];
               A81NetworkIndividualGender = P008G3_A81NetworkIndividualGender[0];
               A344NetworkIndividualCountry = P008G3_A344NetworkIndividualCountry[0];
               A345NetworkIndividualCity = P008G3_A345NetworkIndividualCity[0];
               A346NetworkIndividualZipCode = P008G3_A346NetworkIndividualZipCode[0];
               A347NetworkIndividualAddressLine1 = P008G3_A347NetworkIndividualAddressLine1[0];
               A348NetworkIndividualAddressLine2 = P008G3_A348NetworkIndividualAddressLine2[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_ResidentNetworkIndividual";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Trn_Network Individual", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A74NetworkIndividualId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualBsnNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Bsn Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A75NetworkIndividualBsnNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualGivenName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual First Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A76NetworkIndividualGivenName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualLastName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Last Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A77NetworkIndividualLastName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Email", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A78NetworkIndividualEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A79NetworkIndividualPhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A388NetworkIndividualPhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone Code", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A387NetworkIndividualPhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualGender";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Gender", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A81NetworkIndividualGender;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualCountry";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Country", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A344NetworkIndividualCountry;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualCity";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual City", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A345NetworkIndividualCity;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualZipCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Zip Code", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A346NetworkIndividualZipCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualAddressLine1";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Address Line1", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A347NetworkIndividualAddressLine1;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualAddressLine2";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Address Line2", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A348NetworkIndividualAddressLine2;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P008G4 */
            pr_default.execute(2, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A82NetworkCompanyId = P008G4_A82NetworkCompanyId[0];
               A83NetworkCompanyKvkNumber = P008G4_A83NetworkCompanyKvkNumber[0];
               A84NetworkCompanyName = P008G4_A84NetworkCompanyName[0];
               A85NetworkCompanyEmail = P008G4_A85NetworkCompanyEmail[0];
               A86NetworkCompanyPhone = P008G4_A86NetworkCompanyPhone[0];
               A392NetworkCompanyPhoneNumber = P008G4_A392NetworkCompanyPhoneNumber[0];
               A391NetworkCompanyPhoneCode = P008G4_A391NetworkCompanyPhoneCode[0];
               A349NetworkCompanyCountry = P008G4_A349NetworkCompanyCountry[0];
               A350NetworkCompanyCity = P008G4_A350NetworkCompanyCity[0];
               A351NetworkCompanyZipCode = P008G4_A351NetworkCompanyZipCode[0];
               A352NetworkCompanyAddressLine1 = P008G4_A352NetworkCompanyAddressLine1[0];
               A353NetworkCompanyAddressLine2 = P008G4_A353NetworkCompanyAddressLine2[0];
               A83NetworkCompanyKvkNumber = P008G4_A83NetworkCompanyKvkNumber[0];
               A84NetworkCompanyName = P008G4_A84NetworkCompanyName[0];
               A85NetworkCompanyEmail = P008G4_A85NetworkCompanyEmail[0];
               A86NetworkCompanyPhone = P008G4_A86NetworkCompanyPhone[0];
               A392NetworkCompanyPhoneNumber = P008G4_A392NetworkCompanyPhoneNumber[0];
               A391NetworkCompanyPhoneCode = P008G4_A391NetworkCompanyPhoneCode[0];
               A349NetworkCompanyCountry = P008G4_A349NetworkCompanyCountry[0];
               A350NetworkCompanyCity = P008G4_A350NetworkCompanyCity[0];
               A351NetworkCompanyZipCode = P008G4_A351NetworkCompanyZipCode[0];
               A352NetworkCompanyAddressLine1 = P008G4_A352NetworkCompanyAddressLine1[0];
               A353NetworkCompanyAddressLine2 = P008G4_A353NetworkCompanyAddressLine2[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_ResidentNetworkCompany";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Trn_Network Company", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A82NetworkCompanyId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyKvkNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Kvk Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A83NetworkCompanyKvkNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A84NetworkCompanyName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Email", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A85NetworkCompanyEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A86NetworkCompanyPhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A392NetworkCompanyPhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone Code", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A391NetworkCompanyPhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyCountry";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Country", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A349NetworkCompanyCountry;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyCity";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company City", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A350NetworkCompanyCity;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyZipCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Zip Code", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A351NetworkCompanyZipCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyAddressLine1";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Address Line1", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A352NetworkCompanyAddressLine1;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyAddressLine2";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Address Line2", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A353NetworkCompanyAddressLine2;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P008G7 */
         pr_default.execute(3, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11OrganisationId = P008G7_A11OrganisationId[0];
            A29LocationId = P008G7_A29LocationId[0];
            A62ResidentId = P008G7_A62ResidentId[0];
            A72ResidentSalutation = P008G7_A72ResidentSalutation[0];
            A63ResidentBsnNumber = P008G7_A63ResidentBsnNumber[0];
            A64ResidentGivenName = P008G7_A64ResidentGivenName[0];
            A65ResidentLastName = P008G7_A65ResidentLastName[0];
            A66ResidentInitials = P008G7_A66ResidentInitials[0];
            A67ResidentEmail = P008G7_A67ResidentEmail[0];
            A68ResidentGender = P008G7_A68ResidentGender[0];
            A354ResidentCountry = P008G7_A354ResidentCountry[0];
            A355ResidentCity = P008G7_A355ResidentCity[0];
            A356ResidentZipCode = P008G7_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = P008G7_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = P008G7_A358ResidentAddressLine2[0];
            A70ResidentPhone = P008G7_A70ResidentPhone[0];
            A444ResidentHomePhone = P008G7_A444ResidentHomePhone[0];
            A73ResidentBirthDate = P008G7_A73ResidentBirthDate[0];
            A71ResidentGUID = P008G7_A71ResidentGUID[0];
            A96ResidentTypeId = P008G7_A96ResidentTypeId[0];
            A97ResidentTypeName = P008G7_A97ResidentTypeName[0];
            A98MedicalIndicationId = P008G7_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P008G7_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P008G7_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = P008G7_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = P008G7_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = P008G7_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = P008G7_A446ResidentHomePhoneNumber[0];
            A40000GXC1 = P008G7_A40000GXC1[0];
            n40000GXC1 = P008G7_n40000GXC1[0];
            A40001GXC2 = P008G7_A40001GXC2[0];
            n40001GXC2 = P008G7_n40001GXC2[0];
            A97ResidentTypeName = P008G7_A97ResidentTypeName[0];
            A99MedicalIndicationName = P008G7_A99MedicalIndicationName[0];
            A40000GXC1 = P008G7_A40000GXC1[0];
            n40000GXC1 = P008G7_n40000GXC1[0];
            A40001GXC2 = P008G7_A40001GXC2[0];
            n40001GXC2 = P008G7_n40001GXC2[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Resident";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A62ResidentId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentSalutation";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Salutation", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A72ResidentSalutation;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentBsnNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "BSN Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A63ResidentBsnNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGivenName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A64ResidentGivenName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentLastName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A65ResidentLastName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentInitials";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A66ResidentInitials;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A67ResidentEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGender";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Gender", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A68ResidentGender;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentCountry";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Country", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A354ResidentCountry;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentCity";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "City", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A355ResidentCity;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentZipCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Zip Code", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A356ResidentZipCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentAddressLine1";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Address Line 1", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A357ResidentAddressLine1;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentAddressLine2";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Address Line 2", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358ResidentAddressLine2;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A70ResidentPhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Home Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A444ResidentHomePhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentBirthDate";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Birth Date", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A73ResidentBirthDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentGUID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GUID", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A71ResidentGUID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentTypeId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Resident Type", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A96ResidentTypeId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentTypeName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Resident Type Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A97ResidentTypeName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MedicalIndicationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Medical Indication", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A98MedicalIndicationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MedicalIndicationName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Medical Indication Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A99MedicalIndicationName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Mobile Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A375ResidentPhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A376ResidentPhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Home Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A445ResidentHomePhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentHomePhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A446ResidentHomePhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               /* Using cursor P008G8 */
               pr_default.execute(4, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A74NetworkIndividualId = P008G8_A74NetworkIndividualId[0];
                  A75NetworkIndividualBsnNumber = P008G8_A75NetworkIndividualBsnNumber[0];
                  A76NetworkIndividualGivenName = P008G8_A76NetworkIndividualGivenName[0];
                  A77NetworkIndividualLastName = P008G8_A77NetworkIndividualLastName[0];
                  A78NetworkIndividualEmail = P008G8_A78NetworkIndividualEmail[0];
                  A79NetworkIndividualPhone = P008G8_A79NetworkIndividualPhone[0];
                  A388NetworkIndividualPhoneNumber = P008G8_A388NetworkIndividualPhoneNumber[0];
                  A387NetworkIndividualPhoneCode = P008G8_A387NetworkIndividualPhoneCode[0];
                  A81NetworkIndividualGender = P008G8_A81NetworkIndividualGender[0];
                  A344NetworkIndividualCountry = P008G8_A344NetworkIndividualCountry[0];
                  A345NetworkIndividualCity = P008G8_A345NetworkIndividualCity[0];
                  A346NetworkIndividualZipCode = P008G8_A346NetworkIndividualZipCode[0];
                  A347NetworkIndividualAddressLine1 = P008G8_A347NetworkIndividualAddressLine1[0];
                  A348NetworkIndividualAddressLine2 = P008G8_A348NetworkIndividualAddressLine2[0];
                  A75NetworkIndividualBsnNumber = P008G8_A75NetworkIndividualBsnNumber[0];
                  A76NetworkIndividualGivenName = P008G8_A76NetworkIndividualGivenName[0];
                  A77NetworkIndividualLastName = P008G8_A77NetworkIndividualLastName[0];
                  A78NetworkIndividualEmail = P008G8_A78NetworkIndividualEmail[0];
                  A79NetworkIndividualPhone = P008G8_A79NetworkIndividualPhone[0];
                  A388NetworkIndividualPhoneNumber = P008G8_A388NetworkIndividualPhoneNumber[0];
                  A387NetworkIndividualPhoneCode = P008G8_A387NetworkIndividualPhoneCode[0];
                  A81NetworkIndividualGender = P008G8_A81NetworkIndividualGender[0];
                  A344NetworkIndividualCountry = P008G8_A344NetworkIndividualCountry[0];
                  A345NetworkIndividualCity = P008G8_A345NetworkIndividualCity[0];
                  A346NetworkIndividualZipCode = P008G8_A346NetworkIndividualZipCode[0];
                  A347NetworkIndividualAddressLine1 = P008G8_A347NetworkIndividualAddressLine1[0];
                  A348NetworkIndividualAddressLine2 = P008G8_A348NetworkIndividualAddressLine2[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_ResidentNetworkIndividual";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualId";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Trn_Network Individual", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A74NetworkIndividualId.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualBsnNumber";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Bsn Number", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A75NetworkIndividualBsnNumber;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualGivenName";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual First Name", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A76NetworkIndividualGivenName;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualLastName";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Last Name", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A77NetworkIndividualLastName;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualEmail";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Email", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A78NetworkIndividualEmail;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhone";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A79NetworkIndividualPhone;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhoneNumber";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone Number", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A388NetworkIndividualPhoneNumber;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualPhoneCode";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Phone Code", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A387NetworkIndividualPhoneCode;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualGender";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Gender", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A81NetworkIndividualGender;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualCountry";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Country", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A344NetworkIndividualCountry;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualCity";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual City", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NetworkIndividualCity;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualZipCode";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Zip Code", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A346NetworkIndividualZipCode;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualAddressLine1";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Address Line1", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A347NetworkIndividualAddressLine1;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkIndividualAddressLine2";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Individual Address Line2", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A348NetworkIndividualAddressLine2;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               /* Using cursor P008G9 */
               pr_default.execute(5, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A82NetworkCompanyId = P008G9_A82NetworkCompanyId[0];
                  A83NetworkCompanyKvkNumber = P008G9_A83NetworkCompanyKvkNumber[0];
                  A84NetworkCompanyName = P008G9_A84NetworkCompanyName[0];
                  A85NetworkCompanyEmail = P008G9_A85NetworkCompanyEmail[0];
                  A86NetworkCompanyPhone = P008G9_A86NetworkCompanyPhone[0];
                  A392NetworkCompanyPhoneNumber = P008G9_A392NetworkCompanyPhoneNumber[0];
                  A391NetworkCompanyPhoneCode = P008G9_A391NetworkCompanyPhoneCode[0];
                  A349NetworkCompanyCountry = P008G9_A349NetworkCompanyCountry[0];
                  A350NetworkCompanyCity = P008G9_A350NetworkCompanyCity[0];
                  A351NetworkCompanyZipCode = P008G9_A351NetworkCompanyZipCode[0];
                  A352NetworkCompanyAddressLine1 = P008G9_A352NetworkCompanyAddressLine1[0];
                  A353NetworkCompanyAddressLine2 = P008G9_A353NetworkCompanyAddressLine2[0];
                  A83NetworkCompanyKvkNumber = P008G9_A83NetworkCompanyKvkNumber[0];
                  A84NetworkCompanyName = P008G9_A84NetworkCompanyName[0];
                  A85NetworkCompanyEmail = P008G9_A85NetworkCompanyEmail[0];
                  A86NetworkCompanyPhone = P008G9_A86NetworkCompanyPhone[0];
                  A392NetworkCompanyPhoneNumber = P008G9_A392NetworkCompanyPhoneNumber[0];
                  A391NetworkCompanyPhoneCode = P008G9_A391NetworkCompanyPhoneCode[0];
                  A349NetworkCompanyCountry = P008G9_A349NetworkCompanyCountry[0];
                  A350NetworkCompanyCity = P008G9_A350NetworkCompanyCity[0];
                  A351NetworkCompanyZipCode = P008G9_A351NetworkCompanyZipCode[0];
                  A352NetworkCompanyAddressLine1 = P008G9_A352NetworkCompanyAddressLine1[0];
                  A353NetworkCompanyAddressLine2 = P008G9_A353NetworkCompanyAddressLine2[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_ResidentNetworkCompany";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyId";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Trn_Network Company", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A82NetworkCompanyId.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyKvkNumber";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Kvk Number", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A83NetworkCompanyKvkNumber;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyName";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Name", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A84NetworkCompanyName;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyEmail";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Email", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A85NetworkCompanyEmail;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhone";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A86NetworkCompanyPhone;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhoneNumber";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone Number", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392NetworkCompanyPhoneNumber;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyPhoneCode";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Phone Code", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A391NetworkCompanyPhoneCode;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyCountry";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Country", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A349NetworkCompanyCountry;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyCity";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company City", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A350NetworkCompanyCity;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyZipCode";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Zip Code", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A351NetworkCompanyZipCode;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyAddressLine1";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Address Line1", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A352NetworkCompanyAddressLine1;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NetworkCompanyAddressLine2";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Network Company Address Line2", "");
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A353NetworkCompanyAddressLine2;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV24CountUpdatedNetworkIndividualId = 0;
               AV27CountUpdatedNetworkCompanyId = 0;
               AV36GXV1 = 1;
               while ( AV36GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV36GXV1));
                  if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "Trn_Resident") == 0 )
                  {
                     AV37GXV2 = 1;
                     while ( AV37GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV37GXV2));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A62ResidentId.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LocationId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "OrganisationId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentSalutation") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A72ResidentSalutation;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentBsnNumber") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A63ResidentBsnNumber;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentGivenName") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A64ResidentGivenName;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentLastName") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A65ResidentLastName;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentInitials") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A66ResidentInitials;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentEmail") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A67ResidentEmail;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentGender") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A68ResidentGender;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentCountry") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A354ResidentCountry;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentCity") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A355ResidentCity;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentZipCode") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A356ResidentZipCode;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentAddressLine1") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A357ResidentAddressLine1;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentAddressLine2") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358ResidentAddressLine2;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentPhone") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A70ResidentPhone;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentHomePhone") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A444ResidentHomePhone;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentBirthDate") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A73ResidentBirthDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentGUID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A71ResidentGUID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentTypeId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A96ResidentTypeId.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentTypeName") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A97ResidentTypeName;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MedicalIndicationId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A98MedicalIndicationId.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MedicalIndicationName") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A99MedicalIndicationName;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentPhoneCode") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A375ResidentPhoneCode;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentPhoneNumber") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A376ResidentPhoneNumber;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentHomePhoneCode") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A445ResidentHomePhoneCode;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentHomePhoneNumber") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A446ResidentHomePhoneNumber;
                        }
                        AV37GXV2 = (int)(AV37GXV2+1);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "Trn_ResidentNetworkIndividual") == 0 )
                  {
                     AV23CountKeyAttributes = 0;
                     AV38GXV3 = 1;
                     while ( AV38GXV3 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV38GXV3));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualId") == 0 )
                        {
                           AV25KeyNetworkIndividualId = StringUtil.StrToGuid( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue);
                           AV23CountKeyAttributes = (short)(AV23CountKeyAttributes+1);
                           if ( AV23CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV38GXV3 = (int)(AV38GXV3+1);
                     }
                     AV39GXLvl1037 = 0;
                     /* Using cursor P008G10 */
                     pr_default.execute(6, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, AV25KeyNetworkIndividualId});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A74NetworkIndividualId = P008G10_A74NetworkIndividualId[0];
                        A75NetworkIndividualBsnNumber = P008G10_A75NetworkIndividualBsnNumber[0];
                        A76NetworkIndividualGivenName = P008G10_A76NetworkIndividualGivenName[0];
                        A77NetworkIndividualLastName = P008G10_A77NetworkIndividualLastName[0];
                        A78NetworkIndividualEmail = P008G10_A78NetworkIndividualEmail[0];
                        A79NetworkIndividualPhone = P008G10_A79NetworkIndividualPhone[0];
                        A388NetworkIndividualPhoneNumber = P008G10_A388NetworkIndividualPhoneNumber[0];
                        A387NetworkIndividualPhoneCode = P008G10_A387NetworkIndividualPhoneCode[0];
                        A81NetworkIndividualGender = P008G10_A81NetworkIndividualGender[0];
                        A344NetworkIndividualCountry = P008G10_A344NetworkIndividualCountry[0];
                        A345NetworkIndividualCity = P008G10_A345NetworkIndividualCity[0];
                        A346NetworkIndividualZipCode = P008G10_A346NetworkIndividualZipCode[0];
                        A347NetworkIndividualAddressLine1 = P008G10_A347NetworkIndividualAddressLine1[0];
                        A348NetworkIndividualAddressLine2 = P008G10_A348NetworkIndividualAddressLine2[0];
                        A75NetworkIndividualBsnNumber = P008G10_A75NetworkIndividualBsnNumber[0];
                        A76NetworkIndividualGivenName = P008G10_A76NetworkIndividualGivenName[0];
                        A77NetworkIndividualLastName = P008G10_A77NetworkIndividualLastName[0];
                        A78NetworkIndividualEmail = P008G10_A78NetworkIndividualEmail[0];
                        A79NetworkIndividualPhone = P008G10_A79NetworkIndividualPhone[0];
                        A388NetworkIndividualPhoneNumber = P008G10_A388NetworkIndividualPhoneNumber[0];
                        A387NetworkIndividualPhoneCode = P008G10_A387NetworkIndividualPhoneCode[0];
                        A81NetworkIndividualGender = P008G10_A81NetworkIndividualGender[0];
                        A344NetworkIndividualCountry = P008G10_A344NetworkIndividualCountry[0];
                        A345NetworkIndividualCity = P008G10_A345NetworkIndividualCity[0];
                        A346NetworkIndividualZipCode = P008G10_A346NetworkIndividualZipCode[0];
                        A347NetworkIndividualAddressLine1 = P008G10_A347NetworkIndividualAddressLine1[0];
                        A348NetworkIndividualAddressLine2 = P008G10_A348NetworkIndividualAddressLine2[0];
                        AV39GXLvl1037 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV24CountUpdatedNetworkIndividualId = (short)(AV24CountUpdatedNetworkIndividualId+1);
                        AV40GXV4 = 1;
                        while ( AV40GXV4 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV40GXV4));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualId") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A74NetworkIndividualId.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualBsnNumber") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A75NetworkIndividualBsnNumber;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualGivenName") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A76NetworkIndividualGivenName;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualLastName") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A77NetworkIndividualLastName;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualEmail") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A78NetworkIndividualEmail;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualPhone") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A79NetworkIndividualPhone;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualPhoneNumber") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A388NetworkIndividualPhoneNumber;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualPhoneCode") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A387NetworkIndividualPhoneCode;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualGender") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A81NetworkIndividualGender;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualCountry") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A344NetworkIndividualCountry;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualCity") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NetworkIndividualCity;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualZipCode") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A346NetworkIndividualZipCode;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualAddressLine1") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A347NetworkIndividualAddressLine1;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualAddressLine2") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A348NetworkIndividualAddressLine2;
                           }
                           AV40GXV4 = (int)(AV40GXV4+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(6);
                     if ( AV39GXLvl1037 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "Trn_ResidentNetworkCompany") == 0 )
                  {
                     AV23CountKeyAttributes = 0;
                     AV41GXV5 = 1;
                     while ( AV41GXV5 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV41GXV5));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyId") == 0 )
                        {
                           AV28KeyNetworkCompanyId = StringUtil.StrToGuid( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue);
                           AV23CountKeyAttributes = (short)(AV23CountKeyAttributes+1);
                           if ( AV23CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV41GXV5 = (int)(AV41GXV5+1);
                     }
                     AV42GXLvl1106 = 0;
                     /* Using cursor P008G11 */
                     pr_default.execute(7, new Object[] {AV28KeyNetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
                     while ( (pr_default.getStatus(7) != 101) )
                     {
                        A82NetworkCompanyId = P008G11_A82NetworkCompanyId[0];
                        A83NetworkCompanyKvkNumber = P008G11_A83NetworkCompanyKvkNumber[0];
                        A84NetworkCompanyName = P008G11_A84NetworkCompanyName[0];
                        A85NetworkCompanyEmail = P008G11_A85NetworkCompanyEmail[0];
                        A86NetworkCompanyPhone = P008G11_A86NetworkCompanyPhone[0];
                        A392NetworkCompanyPhoneNumber = P008G11_A392NetworkCompanyPhoneNumber[0];
                        A391NetworkCompanyPhoneCode = P008G11_A391NetworkCompanyPhoneCode[0];
                        A349NetworkCompanyCountry = P008G11_A349NetworkCompanyCountry[0];
                        A350NetworkCompanyCity = P008G11_A350NetworkCompanyCity[0];
                        A351NetworkCompanyZipCode = P008G11_A351NetworkCompanyZipCode[0];
                        A352NetworkCompanyAddressLine1 = P008G11_A352NetworkCompanyAddressLine1[0];
                        A353NetworkCompanyAddressLine2 = P008G11_A353NetworkCompanyAddressLine2[0];
                        A83NetworkCompanyKvkNumber = P008G11_A83NetworkCompanyKvkNumber[0];
                        A84NetworkCompanyName = P008G11_A84NetworkCompanyName[0];
                        A85NetworkCompanyEmail = P008G11_A85NetworkCompanyEmail[0];
                        A86NetworkCompanyPhone = P008G11_A86NetworkCompanyPhone[0];
                        A392NetworkCompanyPhoneNumber = P008G11_A392NetworkCompanyPhoneNumber[0];
                        A391NetworkCompanyPhoneCode = P008G11_A391NetworkCompanyPhoneCode[0];
                        A349NetworkCompanyCountry = P008G11_A349NetworkCompanyCountry[0];
                        A350NetworkCompanyCity = P008G11_A350NetworkCompanyCity[0];
                        A351NetworkCompanyZipCode = P008G11_A351NetworkCompanyZipCode[0];
                        A352NetworkCompanyAddressLine1 = P008G11_A352NetworkCompanyAddressLine1[0];
                        A353NetworkCompanyAddressLine2 = P008G11_A353NetworkCompanyAddressLine2[0];
                        AV42GXLvl1106 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV27CountUpdatedNetworkCompanyId = (short)(AV27CountUpdatedNetworkCompanyId+1);
                        AV43GXV6 = 1;
                        while ( AV43GXV6 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV43GXV6));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyId") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A82NetworkCompanyId.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyKvkNumber") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A83NetworkCompanyKvkNumber;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyName") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A84NetworkCompanyName;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyEmail") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A85NetworkCompanyEmail;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyPhone") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A86NetworkCompanyPhone;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyPhoneNumber") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392NetworkCompanyPhoneNumber;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyPhoneCode") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A391NetworkCompanyPhoneCode;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyCountry") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A349NetworkCompanyCountry;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyCity") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A350NetworkCompanyCity;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyZipCode") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A351NetworkCompanyZipCode;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyAddressLine1") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A352NetworkCompanyAddressLine1;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyAddressLine2") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A353NetworkCompanyAddressLine2;
                           }
                           AV43GXV6 = (int)(AV43GXV6+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(7);
                     if ( AV42GXLvl1106 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  AV36GXV1 = (int)(AV36GXV1+1);
               }
               if ( AV24CountUpdatedNetworkIndividualId < A40000GXC1 )
               {
                  AV20AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P008G12 */
                  pr_default.execute(8, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A11OrganisationId = P008G12_A11OrganisationId[0];
                     A29LocationId = P008G12_A29LocationId[0];
                     A62ResidentId = P008G12_A62ResidentId[0];
                     A74NetworkIndividualId = P008G12_A74NetworkIndividualId[0];
                     A75NetworkIndividualBsnNumber = P008G12_A75NetworkIndividualBsnNumber[0];
                     A76NetworkIndividualGivenName = P008G12_A76NetworkIndividualGivenName[0];
                     A77NetworkIndividualLastName = P008G12_A77NetworkIndividualLastName[0];
                     A78NetworkIndividualEmail = P008G12_A78NetworkIndividualEmail[0];
                     A79NetworkIndividualPhone = P008G12_A79NetworkIndividualPhone[0];
                     A388NetworkIndividualPhoneNumber = P008G12_A388NetworkIndividualPhoneNumber[0];
                     A387NetworkIndividualPhoneCode = P008G12_A387NetworkIndividualPhoneCode[0];
                     A81NetworkIndividualGender = P008G12_A81NetworkIndividualGender[0];
                     A344NetworkIndividualCountry = P008G12_A344NetworkIndividualCountry[0];
                     A345NetworkIndividualCity = P008G12_A345NetworkIndividualCity[0];
                     A346NetworkIndividualZipCode = P008G12_A346NetworkIndividualZipCode[0];
                     A347NetworkIndividualAddressLine1 = P008G12_A347NetworkIndividualAddressLine1[0];
                     A348NetworkIndividualAddressLine2 = P008G12_A348NetworkIndividualAddressLine2[0];
                     A75NetworkIndividualBsnNumber = P008G12_A75NetworkIndividualBsnNumber[0];
                     A76NetworkIndividualGivenName = P008G12_A76NetworkIndividualGivenName[0];
                     A77NetworkIndividualLastName = P008G12_A77NetworkIndividualLastName[0];
                     A78NetworkIndividualEmail = P008G12_A78NetworkIndividualEmail[0];
                     A79NetworkIndividualPhone = P008G12_A79NetworkIndividualPhone[0];
                     A388NetworkIndividualPhoneNumber = P008G12_A388NetworkIndividualPhoneNumber[0];
                     A387NetworkIndividualPhoneCode = P008G12_A387NetworkIndividualPhoneCode[0];
                     A81NetworkIndividualGender = P008G12_A81NetworkIndividualGender[0];
                     A344NetworkIndividualCountry = P008G12_A344NetworkIndividualCountry[0];
                     A345NetworkIndividualCity = P008G12_A345NetworkIndividualCity[0];
                     A346NetworkIndividualZipCode = P008G12_A346NetworkIndividualZipCode[0];
                     A347NetworkIndividualAddressLine1 = P008G12_A347NetworkIndividualAddressLine1[0];
                     A348NetworkIndividualAddressLine2 = P008G12_A348NetworkIndividualAddressLine2[0];
                     AV25KeyNetworkIndividualId = A74NetworkIndividualId;
                     AV26RecordExistsNetworkIndividualId = false;
                     AV45GXV7 = 1;
                     while ( AV45GXV7 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV45GXV7));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "Trn_ResidentNetworkIndividual") == 0 )
                        {
                           AV23CountKeyAttributes = 0;
                           AV46GXV8 = 1;
                           while ( AV46GXV8 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV46GXV8));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkIndividualId") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( AV25KeyNetworkIndividualId.ToString())) == 0 )
                                 {
                                    AV26RecordExistsNetworkIndividualId = true;
                                    AV23CountKeyAttributes = (short)(AV23CountKeyAttributes+1);
                                    if ( AV23CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV46GXV8 = (int)(AV46GXV8+1);
                           }
                        }
                        AV45GXV7 = (int)(AV45GXV7+1);
                     }
                     if ( ! ( AV26RecordExistsNetworkIndividualId ) )
                     {
                        AV21AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV21AuditingObjectRecordItemNew.gxTpr_Tablename = "Trn_ResidentNetworkIndividual";
                        AV21AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV20AuditingObjectNewRecords.gxTpr_Record.Add(AV21AuditingObjectRecordItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualId";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Trn_Network Individual", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A74NetworkIndividualId.ToString();
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualBsnNumber";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Bsn Number", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A75NetworkIndividualBsnNumber;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualGivenName";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual First Name", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A76NetworkIndividualGivenName;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualLastName";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Last Name", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A77NetworkIndividualLastName;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualEmail";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Email", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A78NetworkIndividualEmail;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualPhone";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Phone", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A79NetworkIndividualPhone;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualPhoneNumber";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Phone Number", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A388NetworkIndividualPhoneNumber;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualPhoneCode";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Phone Code", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A387NetworkIndividualPhoneCode;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualGender";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Gender", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A81NetworkIndividualGender;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualCountry";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Country", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A344NetworkIndividualCountry;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualCity";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual City", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A345NetworkIndividualCity;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualZipCode";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Zip Code", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A346NetworkIndividualZipCode;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualAddressLine1";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Address Line1", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A347NetworkIndividualAddressLine1;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkIndividualAddressLine2";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Individual Address Line2", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A348NetworkIndividualAddressLine2;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                     }
                     pr_default.readNext(8);
                  }
                  pr_default.close(8);
                  AV47GXV9 = 1;
                  while ( AV47GXV9 <= AV20AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV20AuditingObjectNewRecords.gxTpr_Record.Item(AV47GXV9));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV47GXV9 = (int)(AV47GXV9+1);
                  }
               }
               if ( AV27CountUpdatedNetworkCompanyId < A40001GXC2 )
               {
                  AV20AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P008G13 */
                  pr_default.execute(9, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A11OrganisationId = P008G13_A11OrganisationId[0];
                     A29LocationId = P008G13_A29LocationId[0];
                     A62ResidentId = P008G13_A62ResidentId[0];
                     A82NetworkCompanyId = P008G13_A82NetworkCompanyId[0];
                     A83NetworkCompanyKvkNumber = P008G13_A83NetworkCompanyKvkNumber[0];
                     A84NetworkCompanyName = P008G13_A84NetworkCompanyName[0];
                     A85NetworkCompanyEmail = P008G13_A85NetworkCompanyEmail[0];
                     A86NetworkCompanyPhone = P008G13_A86NetworkCompanyPhone[0];
                     A392NetworkCompanyPhoneNumber = P008G13_A392NetworkCompanyPhoneNumber[0];
                     A391NetworkCompanyPhoneCode = P008G13_A391NetworkCompanyPhoneCode[0];
                     A349NetworkCompanyCountry = P008G13_A349NetworkCompanyCountry[0];
                     A350NetworkCompanyCity = P008G13_A350NetworkCompanyCity[0];
                     A351NetworkCompanyZipCode = P008G13_A351NetworkCompanyZipCode[0];
                     A352NetworkCompanyAddressLine1 = P008G13_A352NetworkCompanyAddressLine1[0];
                     A353NetworkCompanyAddressLine2 = P008G13_A353NetworkCompanyAddressLine2[0];
                     A83NetworkCompanyKvkNumber = P008G13_A83NetworkCompanyKvkNumber[0];
                     A84NetworkCompanyName = P008G13_A84NetworkCompanyName[0];
                     A85NetworkCompanyEmail = P008G13_A85NetworkCompanyEmail[0];
                     A86NetworkCompanyPhone = P008G13_A86NetworkCompanyPhone[0];
                     A392NetworkCompanyPhoneNumber = P008G13_A392NetworkCompanyPhoneNumber[0];
                     A391NetworkCompanyPhoneCode = P008G13_A391NetworkCompanyPhoneCode[0];
                     A349NetworkCompanyCountry = P008G13_A349NetworkCompanyCountry[0];
                     A350NetworkCompanyCity = P008G13_A350NetworkCompanyCity[0];
                     A351NetworkCompanyZipCode = P008G13_A351NetworkCompanyZipCode[0];
                     A352NetworkCompanyAddressLine1 = P008G13_A352NetworkCompanyAddressLine1[0];
                     A353NetworkCompanyAddressLine2 = P008G13_A353NetworkCompanyAddressLine2[0];
                     AV28KeyNetworkCompanyId = A82NetworkCompanyId;
                     AV29RecordExistsNetworkCompanyId = false;
                     AV49GXV10 = 1;
                     while ( AV49GXV10 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV49GXV10));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "Trn_ResidentNetworkCompany") == 0 )
                        {
                           AV23CountKeyAttributes = 0;
                           AV50GXV11 = 1;
                           while ( AV50GXV11 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV50GXV11));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NetworkCompanyId") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( AV28KeyNetworkCompanyId.ToString())) == 0 )
                                 {
                                    AV29RecordExistsNetworkCompanyId = true;
                                    AV23CountKeyAttributes = (short)(AV23CountKeyAttributes+1);
                                    if ( AV23CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV50GXV11 = (int)(AV50GXV11+1);
                           }
                        }
                        AV49GXV10 = (int)(AV49GXV10+1);
                     }
                     if ( ! ( AV29RecordExistsNetworkCompanyId ) )
                     {
                        AV21AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV21AuditingObjectRecordItemNew.gxTpr_Tablename = "Trn_ResidentNetworkCompany";
                        AV21AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV20AuditingObjectNewRecords.gxTpr_Record.Add(AV21AuditingObjectRecordItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyId";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Trn_Network Company", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A82NetworkCompanyId.ToString();
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyKvkNumber";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Kvk Number", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A83NetworkCompanyKvkNumber;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyName";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Name", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A84NetworkCompanyName;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyEmail";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Email", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A85NetworkCompanyEmail;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyPhone";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Phone", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A86NetworkCompanyPhone;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyPhoneNumber";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Phone Number", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A392NetworkCompanyPhoneNumber;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyPhoneCode";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Phone Code", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A391NetworkCompanyPhoneCode;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyCountry";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Country", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A349NetworkCompanyCountry;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyCity";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company City", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A350NetworkCompanyCity;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyZipCode";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Zip Code", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A351NetworkCompanyZipCode;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyAddressLine1";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Address Line1", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A352NetworkCompanyAddressLine1;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                        AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NetworkCompanyAddressLine2";
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = context.GetMessage( "Network Company Address Line2", "");
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV22AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A353NetworkCompanyAddressLine2;
                        AV21AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV22AuditingObjectRecordItemAttributeItemNew, 0);
                     }
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  AV51GXV12 = 1;
                  while ( AV51GXV12 <= AV20AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV20AuditingObjectNewRecords.gxTpr_Record.Item(AV51GXV12));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV51GXV12 = (int)(AV51GXV12+1);
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P008G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G2_A72ResidentSalutation = new string[] {""} ;
         P008G2_A63ResidentBsnNumber = new string[] {""} ;
         P008G2_A64ResidentGivenName = new string[] {""} ;
         P008G2_A65ResidentLastName = new string[] {""} ;
         P008G2_A66ResidentInitials = new string[] {""} ;
         P008G2_A67ResidentEmail = new string[] {""} ;
         P008G2_A68ResidentGender = new string[] {""} ;
         P008G2_A354ResidentCountry = new string[] {""} ;
         P008G2_A355ResidentCity = new string[] {""} ;
         P008G2_A356ResidentZipCode = new string[] {""} ;
         P008G2_A357ResidentAddressLine1 = new string[] {""} ;
         P008G2_A358ResidentAddressLine2 = new string[] {""} ;
         P008G2_A70ResidentPhone = new string[] {""} ;
         P008G2_A444ResidentHomePhone = new string[] {""} ;
         P008G2_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P008G2_A71ResidentGUID = new string[] {""} ;
         P008G2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P008G2_A97ResidentTypeName = new string[] {""} ;
         P008G2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P008G2_n98MedicalIndicationId = new bool[] {false} ;
         P008G2_A99MedicalIndicationName = new string[] {""} ;
         P008G2_A375ResidentPhoneCode = new string[] {""} ;
         P008G2_A376ResidentPhoneNumber = new string[] {""} ;
         P008G2_A445ResidentHomePhoneCode = new string[] {""} ;
         P008G2_A446ResidentHomePhoneNumber = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A354ResidentCountry = "";
         A355ResidentCity = "";
         A356ResidentZipCode = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         A70ResidentPhone = "";
         A444ResidentHomePhone = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A71ResidentGUID = "";
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A375ResidentPhoneCode = "";
         A376ResidentPhoneNumber = "";
         A445ResidentHomePhoneCode = "";
         A446ResidentHomePhoneNumber = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P008G3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G3_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         P008G3_A75NetworkIndividualBsnNumber = new string[] {""} ;
         P008G3_A76NetworkIndividualGivenName = new string[] {""} ;
         P008G3_A77NetworkIndividualLastName = new string[] {""} ;
         P008G3_A78NetworkIndividualEmail = new string[] {""} ;
         P008G3_A79NetworkIndividualPhone = new string[] {""} ;
         P008G3_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         P008G3_A387NetworkIndividualPhoneCode = new string[] {""} ;
         P008G3_A81NetworkIndividualGender = new string[] {""} ;
         P008G3_A344NetworkIndividualCountry = new string[] {""} ;
         P008G3_A345NetworkIndividualCity = new string[] {""} ;
         P008G3_A346NetworkIndividualZipCode = new string[] {""} ;
         P008G3_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         P008G3_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         A74NetworkIndividualId = Guid.Empty;
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
         P008G4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G4_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G4_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         P008G4_A83NetworkCompanyKvkNumber = new string[] {""} ;
         P008G4_A84NetworkCompanyName = new string[] {""} ;
         P008G4_A85NetworkCompanyEmail = new string[] {""} ;
         P008G4_A86NetworkCompanyPhone = new string[] {""} ;
         P008G4_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         P008G4_A391NetworkCompanyPhoneCode = new string[] {""} ;
         P008G4_A349NetworkCompanyCountry = new string[] {""} ;
         P008G4_A350NetworkCompanyCity = new string[] {""} ;
         P008G4_A351NetworkCompanyZipCode = new string[] {""} ;
         P008G4_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         P008G4_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         A82NetworkCompanyId = Guid.Empty;
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
         P008G7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G7_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G7_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G7_A72ResidentSalutation = new string[] {""} ;
         P008G7_A63ResidentBsnNumber = new string[] {""} ;
         P008G7_A64ResidentGivenName = new string[] {""} ;
         P008G7_A65ResidentLastName = new string[] {""} ;
         P008G7_A66ResidentInitials = new string[] {""} ;
         P008G7_A67ResidentEmail = new string[] {""} ;
         P008G7_A68ResidentGender = new string[] {""} ;
         P008G7_A354ResidentCountry = new string[] {""} ;
         P008G7_A355ResidentCity = new string[] {""} ;
         P008G7_A356ResidentZipCode = new string[] {""} ;
         P008G7_A357ResidentAddressLine1 = new string[] {""} ;
         P008G7_A358ResidentAddressLine2 = new string[] {""} ;
         P008G7_A70ResidentPhone = new string[] {""} ;
         P008G7_A444ResidentHomePhone = new string[] {""} ;
         P008G7_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P008G7_A71ResidentGUID = new string[] {""} ;
         P008G7_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P008G7_A97ResidentTypeName = new string[] {""} ;
         P008G7_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P008G7_n98MedicalIndicationId = new bool[] {false} ;
         P008G7_A99MedicalIndicationName = new string[] {""} ;
         P008G7_A375ResidentPhoneCode = new string[] {""} ;
         P008G7_A376ResidentPhoneNumber = new string[] {""} ;
         P008G7_A445ResidentHomePhoneCode = new string[] {""} ;
         P008G7_A446ResidentHomePhoneNumber = new string[] {""} ;
         P008G7_A40000GXC1 = new int[1] ;
         P008G7_n40000GXC1 = new bool[] {false} ;
         P008G7_A40001GXC2 = new int[1] ;
         P008G7_n40001GXC2 = new bool[] {false} ;
         P008G8_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G8_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G8_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         P008G8_A75NetworkIndividualBsnNumber = new string[] {""} ;
         P008G8_A76NetworkIndividualGivenName = new string[] {""} ;
         P008G8_A77NetworkIndividualLastName = new string[] {""} ;
         P008G8_A78NetworkIndividualEmail = new string[] {""} ;
         P008G8_A79NetworkIndividualPhone = new string[] {""} ;
         P008G8_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         P008G8_A387NetworkIndividualPhoneCode = new string[] {""} ;
         P008G8_A81NetworkIndividualGender = new string[] {""} ;
         P008G8_A344NetworkIndividualCountry = new string[] {""} ;
         P008G8_A345NetworkIndividualCity = new string[] {""} ;
         P008G8_A346NetworkIndividualZipCode = new string[] {""} ;
         P008G8_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         P008G8_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         P008G9_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G9_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G9_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         P008G9_A83NetworkCompanyKvkNumber = new string[] {""} ;
         P008G9_A84NetworkCompanyName = new string[] {""} ;
         P008G9_A85NetworkCompanyEmail = new string[] {""} ;
         P008G9_A86NetworkCompanyPhone = new string[] {""} ;
         P008G9_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         P008G9_A391NetworkCompanyPhoneCode = new string[] {""} ;
         P008G9_A349NetworkCompanyCountry = new string[] {""} ;
         P008G9_A350NetworkCompanyCity = new string[] {""} ;
         P008G9_A351NetworkCompanyZipCode = new string[] {""} ;
         P008G9_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         P008G9_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         AV25KeyNetworkIndividualId = Guid.Empty;
         P008G10_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G10_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G10_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         P008G10_A75NetworkIndividualBsnNumber = new string[] {""} ;
         P008G10_A76NetworkIndividualGivenName = new string[] {""} ;
         P008G10_A77NetworkIndividualLastName = new string[] {""} ;
         P008G10_A78NetworkIndividualEmail = new string[] {""} ;
         P008G10_A79NetworkIndividualPhone = new string[] {""} ;
         P008G10_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         P008G10_A387NetworkIndividualPhoneCode = new string[] {""} ;
         P008G10_A81NetworkIndividualGender = new string[] {""} ;
         P008G10_A344NetworkIndividualCountry = new string[] {""} ;
         P008G10_A345NetworkIndividualCity = new string[] {""} ;
         P008G10_A346NetworkIndividualZipCode = new string[] {""} ;
         P008G10_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         P008G10_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         AV28KeyNetworkCompanyId = Guid.Empty;
         P008G11_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G11_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G11_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         P008G11_A83NetworkCompanyKvkNumber = new string[] {""} ;
         P008G11_A84NetworkCompanyName = new string[] {""} ;
         P008G11_A85NetworkCompanyEmail = new string[] {""} ;
         P008G11_A86NetworkCompanyPhone = new string[] {""} ;
         P008G11_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         P008G11_A391NetworkCompanyPhoneCode = new string[] {""} ;
         P008G11_A349NetworkCompanyCountry = new string[] {""} ;
         P008G11_A350NetworkCompanyCity = new string[] {""} ;
         P008G11_A351NetworkCompanyZipCode = new string[] {""} ;
         P008G11_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         P008G11_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         AV20AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         P008G12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G12_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G12_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G12_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         P008G12_A75NetworkIndividualBsnNumber = new string[] {""} ;
         P008G12_A76NetworkIndividualGivenName = new string[] {""} ;
         P008G12_A77NetworkIndividualLastName = new string[] {""} ;
         P008G12_A78NetworkIndividualEmail = new string[] {""} ;
         P008G12_A79NetworkIndividualPhone = new string[] {""} ;
         P008G12_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         P008G12_A387NetworkIndividualPhoneCode = new string[] {""} ;
         P008G12_A81NetworkIndividualGender = new string[] {""} ;
         P008G12_A344NetworkIndividualCountry = new string[] {""} ;
         P008G12_A345NetworkIndividualCity = new string[] {""} ;
         P008G12_A346NetworkIndividualZipCode = new string[] {""} ;
         P008G12_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         P008G12_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         AV21AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV22AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P008G13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008G13_A29LocationId = new Guid[] {Guid.Empty} ;
         P008G13_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008G13_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         P008G13_A83NetworkCompanyKvkNumber = new string[] {""} ;
         P008G13_A84NetworkCompanyName = new string[] {""} ;
         P008G13_A85NetworkCompanyEmail = new string[] {""} ;
         P008G13_A86NetworkCompanyPhone = new string[] {""} ;
         P008G13_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         P008G13_A391NetworkCompanyPhoneCode = new string[] {""} ;
         P008G13_A349NetworkCompanyCountry = new string[] {""} ;
         P008G13_A350NetworkCompanyCity = new string[] {""} ;
         P008G13_A351NetworkCompanyZipCode = new string[] {""} ;
         P008G13_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         P008G13_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_resident__default(),
            new Object[][] {
                new Object[] {
               P008G2_A11OrganisationId, P008G2_A29LocationId, P008G2_A62ResidentId, P008G2_A72ResidentSalutation, P008G2_A63ResidentBsnNumber, P008G2_A64ResidentGivenName, P008G2_A65ResidentLastName, P008G2_A66ResidentInitials, P008G2_A67ResidentEmail, P008G2_A68ResidentGender,
               P008G2_A354ResidentCountry, P008G2_A355ResidentCity, P008G2_A356ResidentZipCode, P008G2_A357ResidentAddressLine1, P008G2_A358ResidentAddressLine2, P008G2_A70ResidentPhone, P008G2_A444ResidentHomePhone, P008G2_A73ResidentBirthDate, P008G2_A71ResidentGUID, P008G2_A96ResidentTypeId,
               P008G2_A97ResidentTypeName, P008G2_A98MedicalIndicationId, P008G2_n98MedicalIndicationId, P008G2_A99MedicalIndicationName, P008G2_A375ResidentPhoneCode, P008G2_A376ResidentPhoneNumber, P008G2_A445ResidentHomePhoneCode, P008G2_A446ResidentHomePhoneNumber
               }
               , new Object[] {
               P008G3_A62ResidentId, P008G3_A29LocationId, P008G3_A11OrganisationId, P008G3_A74NetworkIndividualId, P008G3_A75NetworkIndividualBsnNumber, P008G3_A76NetworkIndividualGivenName, P008G3_A77NetworkIndividualLastName, P008G3_A78NetworkIndividualEmail, P008G3_A79NetworkIndividualPhone, P008G3_A388NetworkIndividualPhoneNumber,
               P008G3_A387NetworkIndividualPhoneCode, P008G3_A81NetworkIndividualGender, P008G3_A344NetworkIndividualCountry, P008G3_A345NetworkIndividualCity, P008G3_A346NetworkIndividualZipCode, P008G3_A347NetworkIndividualAddressLine1, P008G3_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               P008G4_A62ResidentId, P008G4_A29LocationId, P008G4_A11OrganisationId, P008G4_A82NetworkCompanyId, P008G4_A83NetworkCompanyKvkNumber, P008G4_A84NetworkCompanyName, P008G4_A85NetworkCompanyEmail, P008G4_A86NetworkCompanyPhone, P008G4_A392NetworkCompanyPhoneNumber, P008G4_A391NetworkCompanyPhoneCode,
               P008G4_A349NetworkCompanyCountry, P008G4_A350NetworkCompanyCity, P008G4_A351NetworkCompanyZipCode, P008G4_A352NetworkCompanyAddressLine1, P008G4_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               P008G7_A11OrganisationId, P008G7_A29LocationId, P008G7_A62ResidentId, P008G7_A72ResidentSalutation, P008G7_A63ResidentBsnNumber, P008G7_A64ResidentGivenName, P008G7_A65ResidentLastName, P008G7_A66ResidentInitials, P008G7_A67ResidentEmail, P008G7_A68ResidentGender,
               P008G7_A354ResidentCountry, P008G7_A355ResidentCity, P008G7_A356ResidentZipCode, P008G7_A357ResidentAddressLine1, P008G7_A358ResidentAddressLine2, P008G7_A70ResidentPhone, P008G7_A444ResidentHomePhone, P008G7_A73ResidentBirthDate, P008G7_A71ResidentGUID, P008G7_A96ResidentTypeId,
               P008G7_A97ResidentTypeName, P008G7_A98MedicalIndicationId, P008G7_n98MedicalIndicationId, P008G7_A99MedicalIndicationName, P008G7_A375ResidentPhoneCode, P008G7_A376ResidentPhoneNumber, P008G7_A445ResidentHomePhoneCode, P008G7_A446ResidentHomePhoneNumber, P008G7_A40000GXC1, P008G7_n40000GXC1,
               P008G7_A40001GXC2, P008G7_n40001GXC2
               }
               , new Object[] {
               P008G8_A62ResidentId, P008G8_A29LocationId, P008G8_A11OrganisationId, P008G8_A74NetworkIndividualId, P008G8_A75NetworkIndividualBsnNumber, P008G8_A76NetworkIndividualGivenName, P008G8_A77NetworkIndividualLastName, P008G8_A78NetworkIndividualEmail, P008G8_A79NetworkIndividualPhone, P008G8_A388NetworkIndividualPhoneNumber,
               P008G8_A387NetworkIndividualPhoneCode, P008G8_A81NetworkIndividualGender, P008G8_A344NetworkIndividualCountry, P008G8_A345NetworkIndividualCity, P008G8_A346NetworkIndividualZipCode, P008G8_A347NetworkIndividualAddressLine1, P008G8_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               P008G9_A62ResidentId, P008G9_A29LocationId, P008G9_A11OrganisationId, P008G9_A82NetworkCompanyId, P008G9_A83NetworkCompanyKvkNumber, P008G9_A84NetworkCompanyName, P008G9_A85NetworkCompanyEmail, P008G9_A86NetworkCompanyPhone, P008G9_A392NetworkCompanyPhoneNumber, P008G9_A391NetworkCompanyPhoneCode,
               P008G9_A349NetworkCompanyCountry, P008G9_A350NetworkCompanyCity, P008G9_A351NetworkCompanyZipCode, P008G9_A352NetworkCompanyAddressLine1, P008G9_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               P008G10_A62ResidentId, P008G10_A29LocationId, P008G10_A11OrganisationId, P008G10_A74NetworkIndividualId, P008G10_A75NetworkIndividualBsnNumber, P008G10_A76NetworkIndividualGivenName, P008G10_A77NetworkIndividualLastName, P008G10_A78NetworkIndividualEmail, P008G10_A79NetworkIndividualPhone, P008G10_A388NetworkIndividualPhoneNumber,
               P008G10_A387NetworkIndividualPhoneCode, P008G10_A81NetworkIndividualGender, P008G10_A344NetworkIndividualCountry, P008G10_A345NetworkIndividualCity, P008G10_A346NetworkIndividualZipCode, P008G10_A347NetworkIndividualAddressLine1, P008G10_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               P008G11_A62ResidentId, P008G11_A29LocationId, P008G11_A11OrganisationId, P008G11_A82NetworkCompanyId, P008G11_A83NetworkCompanyKvkNumber, P008G11_A84NetworkCompanyName, P008G11_A85NetworkCompanyEmail, P008G11_A86NetworkCompanyPhone, P008G11_A392NetworkCompanyPhoneNumber, P008G11_A391NetworkCompanyPhoneCode,
               P008G11_A349NetworkCompanyCountry, P008G11_A350NetworkCompanyCity, P008G11_A351NetworkCompanyZipCode, P008G11_A352NetworkCompanyAddressLine1, P008G11_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               P008G12_A11OrganisationId, P008G12_A29LocationId, P008G12_A62ResidentId, P008G12_A74NetworkIndividualId, P008G12_A75NetworkIndividualBsnNumber, P008G12_A76NetworkIndividualGivenName, P008G12_A77NetworkIndividualLastName, P008G12_A78NetworkIndividualEmail, P008G12_A79NetworkIndividualPhone, P008G12_A388NetworkIndividualPhoneNumber,
               P008G12_A387NetworkIndividualPhoneCode, P008G12_A81NetworkIndividualGender, P008G12_A344NetworkIndividualCountry, P008G12_A345NetworkIndividualCity, P008G12_A346NetworkIndividualZipCode, P008G12_A347NetworkIndividualAddressLine1, P008G12_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               P008G13_A11OrganisationId, P008G13_A29LocationId, P008G13_A62ResidentId, P008G13_A82NetworkCompanyId, P008G13_A83NetworkCompanyKvkNumber, P008G13_A84NetworkCompanyName, P008G13_A85NetworkCompanyEmail, P008G13_A86NetworkCompanyPhone, P008G13_A392NetworkCompanyPhoneNumber, P008G13_A391NetworkCompanyPhoneCode,
               P008G13_A349NetworkCompanyCountry, P008G13_A350NetworkCompanyCity, P008G13_A351NetworkCompanyZipCode, P008G13_A352NetworkCompanyAddressLine1, P008G13_A353NetworkCompanyAddressLine2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24CountUpdatedNetworkIndividualId ;
      private short AV27CountUpdatedNetworkCompanyId ;
      private short AV23CountKeyAttributes ;
      private short AV39GXLvl1037 ;
      private short AV42GXLvl1106 ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int AV36GXV1 ;
      private int AV37GXV2 ;
      private int AV38GXV3 ;
      private int AV40GXV4 ;
      private int AV41GXV5 ;
      private int AV43GXV6 ;
      private int AV45GXV7 ;
      private int AV46GXV8 ;
      private int AV47GXV9 ;
      private int AV49GXV10 ;
      private int AV50GXV11 ;
      private int AV51GXV12 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string A444ResidentHomePhone ;
      private string A79NetworkIndividualPhone ;
      private string A86NetworkCompanyPhone ;
      private DateTime A73ResidentBirthDate ;
      private bool returnInSub ;
      private bool n98MedicalIndicationId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool AV26RecordExistsNetworkIndividualId ;
      private bool AV29RecordExistsNetworkCompanyId ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A354ResidentCountry ;
      private string A355ResidentCity ;
      private string A356ResidentZipCode ;
      private string A357ResidentAddressLine1 ;
      private string A358ResidentAddressLine2 ;
      private string A71ResidentGUID ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A375ResidentPhoneCode ;
      private string A376ResidentPhoneNumber ;
      private string A445ResidentHomePhoneCode ;
      private string A446ResidentHomePhoneNumber ;
      private string A75NetworkIndividualBsnNumber ;
      private string A76NetworkIndividualGivenName ;
      private string A77NetworkIndividualLastName ;
      private string A78NetworkIndividualEmail ;
      private string A388NetworkIndividualPhoneNumber ;
      private string A387NetworkIndividualPhoneCode ;
      private string A81NetworkIndividualGender ;
      private string A344NetworkIndividualCountry ;
      private string A345NetworkIndividualCity ;
      private string A346NetworkIndividualZipCode ;
      private string A347NetworkIndividualAddressLine1 ;
      private string A348NetworkIndividualAddressLine2 ;
      private string A83NetworkCompanyKvkNumber ;
      private string A84NetworkCompanyName ;
      private string A85NetworkCompanyEmail ;
      private string A392NetworkCompanyPhoneNumber ;
      private string A391NetworkCompanyPhoneCode ;
      private string A349NetworkCompanyCountry ;
      private string A350NetworkCompanyCity ;
      private string A351NetworkCompanyZipCode ;
      private string A352NetworkCompanyAddressLine1 ;
      private string A353NetworkCompanyAddressLine2 ;
      private Guid AV17ResidentId ;
      private Guid AV18LocationId ;
      private Guid AV19OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid A74NetworkIndividualId ;
      private Guid A82NetworkCompanyId ;
      private Guid AV25KeyNetworkIndividualId ;
      private Guid AV28KeyNetworkCompanyId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008G2_A11OrganisationId ;
      private Guid[] P008G2_A29LocationId ;
      private Guid[] P008G2_A62ResidentId ;
      private string[] P008G2_A72ResidentSalutation ;
      private string[] P008G2_A63ResidentBsnNumber ;
      private string[] P008G2_A64ResidentGivenName ;
      private string[] P008G2_A65ResidentLastName ;
      private string[] P008G2_A66ResidentInitials ;
      private string[] P008G2_A67ResidentEmail ;
      private string[] P008G2_A68ResidentGender ;
      private string[] P008G2_A354ResidentCountry ;
      private string[] P008G2_A355ResidentCity ;
      private string[] P008G2_A356ResidentZipCode ;
      private string[] P008G2_A357ResidentAddressLine1 ;
      private string[] P008G2_A358ResidentAddressLine2 ;
      private string[] P008G2_A70ResidentPhone ;
      private string[] P008G2_A444ResidentHomePhone ;
      private DateTime[] P008G2_A73ResidentBirthDate ;
      private string[] P008G2_A71ResidentGUID ;
      private Guid[] P008G2_A96ResidentTypeId ;
      private string[] P008G2_A97ResidentTypeName ;
      private Guid[] P008G2_A98MedicalIndicationId ;
      private bool[] P008G2_n98MedicalIndicationId ;
      private string[] P008G2_A99MedicalIndicationName ;
      private string[] P008G2_A375ResidentPhoneCode ;
      private string[] P008G2_A376ResidentPhoneNumber ;
      private string[] P008G2_A445ResidentHomePhoneCode ;
      private string[] P008G2_A446ResidentHomePhoneNumber ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P008G3_A62ResidentId ;
      private Guid[] P008G3_A29LocationId ;
      private Guid[] P008G3_A11OrganisationId ;
      private Guid[] P008G3_A74NetworkIndividualId ;
      private string[] P008G3_A75NetworkIndividualBsnNumber ;
      private string[] P008G3_A76NetworkIndividualGivenName ;
      private string[] P008G3_A77NetworkIndividualLastName ;
      private string[] P008G3_A78NetworkIndividualEmail ;
      private string[] P008G3_A79NetworkIndividualPhone ;
      private string[] P008G3_A388NetworkIndividualPhoneNumber ;
      private string[] P008G3_A387NetworkIndividualPhoneCode ;
      private string[] P008G3_A81NetworkIndividualGender ;
      private string[] P008G3_A344NetworkIndividualCountry ;
      private string[] P008G3_A345NetworkIndividualCity ;
      private string[] P008G3_A346NetworkIndividualZipCode ;
      private string[] P008G3_A347NetworkIndividualAddressLine1 ;
      private string[] P008G3_A348NetworkIndividualAddressLine2 ;
      private Guid[] P008G4_A62ResidentId ;
      private Guid[] P008G4_A29LocationId ;
      private Guid[] P008G4_A11OrganisationId ;
      private Guid[] P008G4_A82NetworkCompanyId ;
      private string[] P008G4_A83NetworkCompanyKvkNumber ;
      private string[] P008G4_A84NetworkCompanyName ;
      private string[] P008G4_A85NetworkCompanyEmail ;
      private string[] P008G4_A86NetworkCompanyPhone ;
      private string[] P008G4_A392NetworkCompanyPhoneNumber ;
      private string[] P008G4_A391NetworkCompanyPhoneCode ;
      private string[] P008G4_A349NetworkCompanyCountry ;
      private string[] P008G4_A350NetworkCompanyCity ;
      private string[] P008G4_A351NetworkCompanyZipCode ;
      private string[] P008G4_A352NetworkCompanyAddressLine1 ;
      private string[] P008G4_A353NetworkCompanyAddressLine2 ;
      private Guid[] P008G7_A11OrganisationId ;
      private Guid[] P008G7_A29LocationId ;
      private Guid[] P008G7_A62ResidentId ;
      private string[] P008G7_A72ResidentSalutation ;
      private string[] P008G7_A63ResidentBsnNumber ;
      private string[] P008G7_A64ResidentGivenName ;
      private string[] P008G7_A65ResidentLastName ;
      private string[] P008G7_A66ResidentInitials ;
      private string[] P008G7_A67ResidentEmail ;
      private string[] P008G7_A68ResidentGender ;
      private string[] P008G7_A354ResidentCountry ;
      private string[] P008G7_A355ResidentCity ;
      private string[] P008G7_A356ResidentZipCode ;
      private string[] P008G7_A357ResidentAddressLine1 ;
      private string[] P008G7_A358ResidentAddressLine2 ;
      private string[] P008G7_A70ResidentPhone ;
      private string[] P008G7_A444ResidentHomePhone ;
      private DateTime[] P008G7_A73ResidentBirthDate ;
      private string[] P008G7_A71ResidentGUID ;
      private Guid[] P008G7_A96ResidentTypeId ;
      private string[] P008G7_A97ResidentTypeName ;
      private Guid[] P008G7_A98MedicalIndicationId ;
      private bool[] P008G7_n98MedicalIndicationId ;
      private string[] P008G7_A99MedicalIndicationName ;
      private string[] P008G7_A375ResidentPhoneCode ;
      private string[] P008G7_A376ResidentPhoneNumber ;
      private string[] P008G7_A445ResidentHomePhoneCode ;
      private string[] P008G7_A446ResidentHomePhoneNumber ;
      private int[] P008G7_A40000GXC1 ;
      private bool[] P008G7_n40000GXC1 ;
      private int[] P008G7_A40001GXC2 ;
      private bool[] P008G7_n40001GXC2 ;
      private Guid[] P008G8_A62ResidentId ;
      private Guid[] P008G8_A29LocationId ;
      private Guid[] P008G8_A11OrganisationId ;
      private Guid[] P008G8_A74NetworkIndividualId ;
      private string[] P008G8_A75NetworkIndividualBsnNumber ;
      private string[] P008G8_A76NetworkIndividualGivenName ;
      private string[] P008G8_A77NetworkIndividualLastName ;
      private string[] P008G8_A78NetworkIndividualEmail ;
      private string[] P008G8_A79NetworkIndividualPhone ;
      private string[] P008G8_A388NetworkIndividualPhoneNumber ;
      private string[] P008G8_A387NetworkIndividualPhoneCode ;
      private string[] P008G8_A81NetworkIndividualGender ;
      private string[] P008G8_A344NetworkIndividualCountry ;
      private string[] P008G8_A345NetworkIndividualCity ;
      private string[] P008G8_A346NetworkIndividualZipCode ;
      private string[] P008G8_A347NetworkIndividualAddressLine1 ;
      private string[] P008G8_A348NetworkIndividualAddressLine2 ;
      private Guid[] P008G9_A62ResidentId ;
      private Guid[] P008G9_A29LocationId ;
      private Guid[] P008G9_A11OrganisationId ;
      private Guid[] P008G9_A82NetworkCompanyId ;
      private string[] P008G9_A83NetworkCompanyKvkNumber ;
      private string[] P008G9_A84NetworkCompanyName ;
      private string[] P008G9_A85NetworkCompanyEmail ;
      private string[] P008G9_A86NetworkCompanyPhone ;
      private string[] P008G9_A392NetworkCompanyPhoneNumber ;
      private string[] P008G9_A391NetworkCompanyPhoneCode ;
      private string[] P008G9_A349NetworkCompanyCountry ;
      private string[] P008G9_A350NetworkCompanyCity ;
      private string[] P008G9_A351NetworkCompanyZipCode ;
      private string[] P008G9_A352NetworkCompanyAddressLine1 ;
      private string[] P008G9_A353NetworkCompanyAddressLine2 ;
      private Guid[] P008G10_A62ResidentId ;
      private Guid[] P008G10_A29LocationId ;
      private Guid[] P008G10_A11OrganisationId ;
      private Guid[] P008G10_A74NetworkIndividualId ;
      private string[] P008G10_A75NetworkIndividualBsnNumber ;
      private string[] P008G10_A76NetworkIndividualGivenName ;
      private string[] P008G10_A77NetworkIndividualLastName ;
      private string[] P008G10_A78NetworkIndividualEmail ;
      private string[] P008G10_A79NetworkIndividualPhone ;
      private string[] P008G10_A388NetworkIndividualPhoneNumber ;
      private string[] P008G10_A387NetworkIndividualPhoneCode ;
      private string[] P008G10_A81NetworkIndividualGender ;
      private string[] P008G10_A344NetworkIndividualCountry ;
      private string[] P008G10_A345NetworkIndividualCity ;
      private string[] P008G10_A346NetworkIndividualZipCode ;
      private string[] P008G10_A347NetworkIndividualAddressLine1 ;
      private string[] P008G10_A348NetworkIndividualAddressLine2 ;
      private Guid[] P008G11_A62ResidentId ;
      private Guid[] P008G11_A29LocationId ;
      private Guid[] P008G11_A11OrganisationId ;
      private Guid[] P008G11_A82NetworkCompanyId ;
      private string[] P008G11_A83NetworkCompanyKvkNumber ;
      private string[] P008G11_A84NetworkCompanyName ;
      private string[] P008G11_A85NetworkCompanyEmail ;
      private string[] P008G11_A86NetworkCompanyPhone ;
      private string[] P008G11_A392NetworkCompanyPhoneNumber ;
      private string[] P008G11_A391NetworkCompanyPhoneCode ;
      private string[] P008G11_A349NetworkCompanyCountry ;
      private string[] P008G11_A350NetworkCompanyCity ;
      private string[] P008G11_A351NetworkCompanyZipCode ;
      private string[] P008G11_A352NetworkCompanyAddressLine1 ;
      private string[] P008G11_A353NetworkCompanyAddressLine2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV20AuditingObjectNewRecords ;
      private Guid[] P008G12_A11OrganisationId ;
      private Guid[] P008G12_A29LocationId ;
      private Guid[] P008G12_A62ResidentId ;
      private Guid[] P008G12_A74NetworkIndividualId ;
      private string[] P008G12_A75NetworkIndividualBsnNumber ;
      private string[] P008G12_A76NetworkIndividualGivenName ;
      private string[] P008G12_A77NetworkIndividualLastName ;
      private string[] P008G12_A78NetworkIndividualEmail ;
      private string[] P008G12_A79NetworkIndividualPhone ;
      private string[] P008G12_A388NetworkIndividualPhoneNumber ;
      private string[] P008G12_A387NetworkIndividualPhoneCode ;
      private string[] P008G12_A81NetworkIndividualGender ;
      private string[] P008G12_A344NetworkIndividualCountry ;
      private string[] P008G12_A345NetworkIndividualCity ;
      private string[] P008G12_A346NetworkIndividualZipCode ;
      private string[] P008G12_A347NetworkIndividualAddressLine1 ;
      private string[] P008G12_A348NetworkIndividualAddressLine2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV21AuditingObjectRecordItemNew ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV22AuditingObjectRecordItemAttributeItemNew ;
      private Guid[] P008G13_A11OrganisationId ;
      private Guid[] P008G13_A29LocationId ;
      private Guid[] P008G13_A62ResidentId ;
      private Guid[] P008G13_A82NetworkCompanyId ;
      private string[] P008G13_A83NetworkCompanyKvkNumber ;
      private string[] P008G13_A84NetworkCompanyName ;
      private string[] P008G13_A85NetworkCompanyEmail ;
      private string[] P008G13_A86NetworkCompanyPhone ;
      private string[] P008G13_A392NetworkCompanyPhoneNumber ;
      private string[] P008G13_A391NetworkCompanyPhoneCode ;
      private string[] P008G13_A349NetworkCompanyCountry ;
      private string[] P008G13_A350NetworkCompanyCity ;
      private string[] P008G13_A351NetworkCompanyZipCode ;
      private string[] P008G13_A352NetworkCompanyAddressLine1 ;
      private string[] P008G13_A353NetworkCompanyAddressLine2 ;
   }

   public class loadaudittrn_resident__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008G2;
          prmP008G2 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G3;
          prmP008G3 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G4;
          prmP008G4 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G7;
          prmP008G7 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G8;
          prmP008G8 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G9;
          prmP008G9 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G10;
          prmP008G10 = new Object[] {
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV25KeyNetworkIndividualId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G11;
          prmP008G11 = new Object[] {
          new ParDef("AV28KeyNetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G12;
          prmP008G12 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008G13;
          prmP008G13 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008G2", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T1.ResidentHomePhone, T1.ResidentBirthDate, T1.ResidentGUID, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentPhoneCode, T1.ResidentPhoneNumber, T1.ResidentHomePhoneCode, T1.ResidentHomePhoneNumber FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P008G3", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2 FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G4", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkCompanyId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2 FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G7", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T1.ResidentHomePhone, T1.ResidentBirthDate, T1.ResidentGUID, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentPhoneCode, T1.ResidentPhoneNumber, T1.ResidentHomePhoneCode, T1.ResidentHomePhoneNumber, COALESCE( T4.GXC1, 0) AS GXC1, COALESCE( T5.GXC2, 0) AS GXC2 FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId),  (SELECT COUNT(*) AS GXC1 FROM Trn_ResidentNetworkIndividual WHERE (ResidentId = :AV17ResidentId) AND (LocationId = :AV18LocationId) AND (OrganisationId = :AV19OrganisationId) ) T4,  (SELECT COUNT(*) AS GXC2 FROM Trn_ResidentNetworkCompany WHERE (ResidentId = :AV17ResidentId) AND (LocationId = :AV18LocationId) AND (OrganisationId = :AV19OrganisationId) ) T5 WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P008G8", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2 FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G9", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkCompanyId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2 FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G10", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2 FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId and T1.NetworkIndividualId = :AV25KeyNetworkIndividualId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G11", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkCompanyId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2 FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.NetworkCompanyId = :AV28KeyNetworkCompanyId and T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.NetworkCompanyId, T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G12", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.NetworkIndividualId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2 FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G13", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.NetworkCompanyId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2 FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G13,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
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
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((Guid[]) buf[19])[0] = rslt.getGuid(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[21])[0] = rslt.getGuid(22);
                ((bool[]) buf[22])[0] = rslt.wasNull(22);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((string[]) buf[25])[0] = rslt.getVarchar(25);
                ((string[]) buf[26])[0] = rslt.getVarchar(26);
                ((string[]) buf[27])[0] = rslt.getVarchar(27);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
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
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((Guid[]) buf[19])[0] = rslt.getGuid(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[21])[0] = rslt.getGuid(22);
                ((bool[]) buf[22])[0] = rslt.wasNull(22);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((string[]) buf[25])[0] = rslt.getVarchar(25);
                ((string[]) buf[26])[0] = rslt.getVarchar(26);
                ((string[]) buf[27])[0] = rslt.getVarchar(27);
                ((int[]) buf[28])[0] = rslt.getInt(28);
                ((bool[]) buf[29])[0] = rslt.wasNull(28);
                ((int[]) buf[30])[0] = rslt.getInt(29);
                ((bool[]) buf[31])[0] = rslt.wasNull(29);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
                return;
       }
    }

 }

}
