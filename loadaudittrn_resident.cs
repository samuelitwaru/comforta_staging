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
         /* Using cursor P00AW2 */
         pr_default.execute(0, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00AW2_A11OrganisationId[0];
            A29LocationId = P00AW2_A29LocationId[0];
            A62ResidentId = P00AW2_A62ResidentId[0];
            A72ResidentSalutation = P00AW2_A72ResidentSalutation[0];
            A63ResidentBsnNumber = P00AW2_A63ResidentBsnNumber[0];
            A64ResidentGivenName = P00AW2_A64ResidentGivenName[0];
            A65ResidentLastName = P00AW2_A65ResidentLastName[0];
            A66ResidentInitials = P00AW2_A66ResidentInitials[0];
            A67ResidentEmail = P00AW2_A67ResidentEmail[0];
            A68ResidentGender = P00AW2_A68ResidentGender[0];
            A354ResidentCountry = P00AW2_A354ResidentCountry[0];
            A355ResidentCity = P00AW2_A355ResidentCity[0];
            A356ResidentZipCode = P00AW2_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = P00AW2_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = P00AW2_A358ResidentAddressLine2[0];
            A70ResidentPhone = P00AW2_A70ResidentPhone[0];
            A444ResidentHomePhone = P00AW2_A444ResidentHomePhone[0];
            A73ResidentBirthDate = P00AW2_A73ResidentBirthDate[0];
            A71ResidentGUID = P00AW2_A71ResidentGUID[0];
            A96ResidentTypeId = P00AW2_A96ResidentTypeId[0];
            n96ResidentTypeId = P00AW2_n96ResidentTypeId[0];
            A97ResidentTypeName = P00AW2_A97ResidentTypeName[0];
            A98MedicalIndicationId = P00AW2_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P00AW2_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P00AW2_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = P00AW2_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = P00AW2_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = P00AW2_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = P00AW2_A446ResidentHomePhoneNumber[0];
            A554ResidentPackageId = P00AW2_A554ResidentPackageId[0];
            n554ResidentPackageId = P00AW2_n554ResidentPackageId[0];
            A555SG_LocationId = P00AW2_A555SG_LocationId[0];
            A556SG_OrganisationId = P00AW2_A556SG_OrganisationId[0];
            A97ResidentTypeName = P00AW2_A97ResidentTypeName[0];
            A99MedicalIndicationName = P00AW2_A99MedicalIndicationName[0];
            A555SG_LocationId = P00AW2_A555SG_LocationId[0];
            A556SG_OrganisationId = P00AW2_A556SG_OrganisationId[0];
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A64ResidentGivenName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentLastName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Mobile Phone", "");
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
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPackageId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Access Rights Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A554ResidentPackageId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "SG_LocationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "SG_Location Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A555SG_LocationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "SG_OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "SG_Organisation Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A556SG_OrganisationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00AW3 */
         pr_default.execute(1, new Object[] {AV17ResidentId, AV18LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P00AW3_A11OrganisationId[0];
            A29LocationId = P00AW3_A29LocationId[0];
            A62ResidentId = P00AW3_A62ResidentId[0];
            A72ResidentSalutation = P00AW3_A72ResidentSalutation[0];
            A63ResidentBsnNumber = P00AW3_A63ResidentBsnNumber[0];
            A64ResidentGivenName = P00AW3_A64ResidentGivenName[0];
            A65ResidentLastName = P00AW3_A65ResidentLastName[0];
            A66ResidentInitials = P00AW3_A66ResidentInitials[0];
            A67ResidentEmail = P00AW3_A67ResidentEmail[0];
            A68ResidentGender = P00AW3_A68ResidentGender[0];
            A354ResidentCountry = P00AW3_A354ResidentCountry[0];
            A355ResidentCity = P00AW3_A355ResidentCity[0];
            A356ResidentZipCode = P00AW3_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = P00AW3_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = P00AW3_A358ResidentAddressLine2[0];
            A70ResidentPhone = P00AW3_A70ResidentPhone[0];
            A444ResidentHomePhone = P00AW3_A444ResidentHomePhone[0];
            A73ResidentBirthDate = P00AW3_A73ResidentBirthDate[0];
            A71ResidentGUID = P00AW3_A71ResidentGUID[0];
            A96ResidentTypeId = P00AW3_A96ResidentTypeId[0];
            n96ResidentTypeId = P00AW3_n96ResidentTypeId[0];
            A97ResidentTypeName = P00AW3_A97ResidentTypeName[0];
            A98MedicalIndicationId = P00AW3_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P00AW3_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P00AW3_A99MedicalIndicationName[0];
            A375ResidentPhoneCode = P00AW3_A375ResidentPhoneCode[0];
            A376ResidentPhoneNumber = P00AW3_A376ResidentPhoneNumber[0];
            A445ResidentHomePhoneCode = P00AW3_A445ResidentHomePhoneCode[0];
            A446ResidentHomePhoneNumber = P00AW3_A446ResidentHomePhoneNumber[0];
            A554ResidentPackageId = P00AW3_A554ResidentPackageId[0];
            n554ResidentPackageId = P00AW3_n554ResidentPackageId[0];
            A555SG_LocationId = P00AW3_A555SG_LocationId[0];
            A556SG_OrganisationId = P00AW3_A556SG_OrganisationId[0];
            A97ResidentTypeName = P00AW3_A97ResidentTypeName[0];
            A99MedicalIndicationName = P00AW3_A99MedicalIndicationName[0];
            A555SG_LocationId = P00AW3_A555SG_LocationId[0];
            A556SG_OrganisationId = P00AW3_A556SG_OrganisationId[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Resident";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A64ResidentGivenName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentLastName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Mobile Phone", "");
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
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ResidentPackageId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Access Rights Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A554ResidentPackageId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "SG_LocationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "SG_Location Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A555SG_LocationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "SG_OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "SG_Organisation Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A556SG_OrganisationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22GXV1 = 1;
               while ( AV22GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV22GXV1));
                  AV23GXV2 = 1;
                  while ( AV23GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV23GXV2));
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ResidentPackageId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A554ResidentPackageId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "SG_LocationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A555SG_LocationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "SG_OrganisationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A556SG_OrganisationId.ToString();
                     }
                     AV23GXV2 = (int)(AV23GXV2+1);
                  }
                  AV22GXV1 = (int)(AV22GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00AW2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AW2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AW2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00AW2_A72ResidentSalutation = new string[] {""} ;
         P00AW2_A63ResidentBsnNumber = new string[] {""} ;
         P00AW2_A64ResidentGivenName = new string[] {""} ;
         P00AW2_A65ResidentLastName = new string[] {""} ;
         P00AW2_A66ResidentInitials = new string[] {""} ;
         P00AW2_A67ResidentEmail = new string[] {""} ;
         P00AW2_A68ResidentGender = new string[] {""} ;
         P00AW2_A354ResidentCountry = new string[] {""} ;
         P00AW2_A355ResidentCity = new string[] {""} ;
         P00AW2_A356ResidentZipCode = new string[] {""} ;
         P00AW2_A357ResidentAddressLine1 = new string[] {""} ;
         P00AW2_A358ResidentAddressLine2 = new string[] {""} ;
         P00AW2_A70ResidentPhone = new string[] {""} ;
         P00AW2_A444ResidentHomePhone = new string[] {""} ;
         P00AW2_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P00AW2_A71ResidentGUID = new string[] {""} ;
         P00AW2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P00AW2_n96ResidentTypeId = new bool[] {false} ;
         P00AW2_A97ResidentTypeName = new string[] {""} ;
         P00AW2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P00AW2_n98MedicalIndicationId = new bool[] {false} ;
         P00AW2_A99MedicalIndicationName = new string[] {""} ;
         P00AW2_A375ResidentPhoneCode = new string[] {""} ;
         P00AW2_A376ResidentPhoneNumber = new string[] {""} ;
         P00AW2_A445ResidentHomePhoneCode = new string[] {""} ;
         P00AW2_A446ResidentHomePhoneNumber = new string[] {""} ;
         P00AW2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00AW2_n554ResidentPackageId = new bool[] {false} ;
         P00AW2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00AW2_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
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
         A554ResidentPackageId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00AW3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AW3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AW3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00AW3_A72ResidentSalutation = new string[] {""} ;
         P00AW3_A63ResidentBsnNumber = new string[] {""} ;
         P00AW3_A64ResidentGivenName = new string[] {""} ;
         P00AW3_A65ResidentLastName = new string[] {""} ;
         P00AW3_A66ResidentInitials = new string[] {""} ;
         P00AW3_A67ResidentEmail = new string[] {""} ;
         P00AW3_A68ResidentGender = new string[] {""} ;
         P00AW3_A354ResidentCountry = new string[] {""} ;
         P00AW3_A355ResidentCity = new string[] {""} ;
         P00AW3_A356ResidentZipCode = new string[] {""} ;
         P00AW3_A357ResidentAddressLine1 = new string[] {""} ;
         P00AW3_A358ResidentAddressLine2 = new string[] {""} ;
         P00AW3_A70ResidentPhone = new string[] {""} ;
         P00AW3_A444ResidentHomePhone = new string[] {""} ;
         P00AW3_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P00AW3_A71ResidentGUID = new string[] {""} ;
         P00AW3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P00AW3_n96ResidentTypeId = new bool[] {false} ;
         P00AW3_A97ResidentTypeName = new string[] {""} ;
         P00AW3_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P00AW3_n98MedicalIndicationId = new bool[] {false} ;
         P00AW3_A99MedicalIndicationName = new string[] {""} ;
         P00AW3_A375ResidentPhoneCode = new string[] {""} ;
         P00AW3_A376ResidentPhoneNumber = new string[] {""} ;
         P00AW3_A445ResidentHomePhoneCode = new string[] {""} ;
         P00AW3_A446ResidentHomePhoneNumber = new string[] {""} ;
         P00AW3_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00AW3_n554ResidentPackageId = new bool[] {false} ;
         P00AW3_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         P00AW3_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_resident__default(),
            new Object[][] {
                new Object[] {
               P00AW2_A11OrganisationId, P00AW2_A29LocationId, P00AW2_A62ResidentId, P00AW2_A72ResidentSalutation, P00AW2_A63ResidentBsnNumber, P00AW2_A64ResidentGivenName, P00AW2_A65ResidentLastName, P00AW2_A66ResidentInitials, P00AW2_A67ResidentEmail, P00AW2_A68ResidentGender,
               P00AW2_A354ResidentCountry, P00AW2_A355ResidentCity, P00AW2_A356ResidentZipCode, P00AW2_A357ResidentAddressLine1, P00AW2_A358ResidentAddressLine2, P00AW2_A70ResidentPhone, P00AW2_A444ResidentHomePhone, P00AW2_A73ResidentBirthDate, P00AW2_A71ResidentGUID, P00AW2_A96ResidentTypeId,
               P00AW2_n96ResidentTypeId, P00AW2_A97ResidentTypeName, P00AW2_A98MedicalIndicationId, P00AW2_n98MedicalIndicationId, P00AW2_A99MedicalIndicationName, P00AW2_A375ResidentPhoneCode, P00AW2_A376ResidentPhoneNumber, P00AW2_A445ResidentHomePhoneCode, P00AW2_A446ResidentHomePhoneNumber, P00AW2_A554ResidentPackageId,
               P00AW2_n554ResidentPackageId, P00AW2_A555SG_LocationId, P00AW2_A556SG_OrganisationId
               }
               , new Object[] {
               P00AW3_A11OrganisationId, P00AW3_A29LocationId, P00AW3_A62ResidentId, P00AW3_A72ResidentSalutation, P00AW3_A63ResidentBsnNumber, P00AW3_A64ResidentGivenName, P00AW3_A65ResidentLastName, P00AW3_A66ResidentInitials, P00AW3_A67ResidentEmail, P00AW3_A68ResidentGender,
               P00AW3_A354ResidentCountry, P00AW3_A355ResidentCity, P00AW3_A356ResidentZipCode, P00AW3_A357ResidentAddressLine1, P00AW3_A358ResidentAddressLine2, P00AW3_A70ResidentPhone, P00AW3_A444ResidentHomePhone, P00AW3_A73ResidentBirthDate, P00AW3_A71ResidentGUID, P00AW3_A96ResidentTypeId,
               P00AW3_n96ResidentTypeId, P00AW3_A97ResidentTypeName, P00AW3_A98MedicalIndicationId, P00AW3_n98MedicalIndicationId, P00AW3_A99MedicalIndicationName, P00AW3_A375ResidentPhoneCode, P00AW3_A376ResidentPhoneNumber, P00AW3_A445ResidentHomePhoneCode, P00AW3_A446ResidentHomePhoneNumber, P00AW3_A554ResidentPackageId,
               P00AW3_n554ResidentPackageId, P00AW3_A555SG_LocationId, P00AW3_A556SG_OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string A444ResidentHomePhone ;
      private DateTime A73ResidentBirthDate ;
      private bool returnInSub ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private bool n554ResidentPackageId ;
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
      private Guid AV17ResidentId ;
      private Guid AV18LocationId ;
      private Guid AV19OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid A554ResidentPackageId ;
      private Guid A555SG_LocationId ;
      private Guid A556SG_OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AW2_A11OrganisationId ;
      private Guid[] P00AW2_A29LocationId ;
      private Guid[] P00AW2_A62ResidentId ;
      private string[] P00AW2_A72ResidentSalutation ;
      private string[] P00AW2_A63ResidentBsnNumber ;
      private string[] P00AW2_A64ResidentGivenName ;
      private string[] P00AW2_A65ResidentLastName ;
      private string[] P00AW2_A66ResidentInitials ;
      private string[] P00AW2_A67ResidentEmail ;
      private string[] P00AW2_A68ResidentGender ;
      private string[] P00AW2_A354ResidentCountry ;
      private string[] P00AW2_A355ResidentCity ;
      private string[] P00AW2_A356ResidentZipCode ;
      private string[] P00AW2_A357ResidentAddressLine1 ;
      private string[] P00AW2_A358ResidentAddressLine2 ;
      private string[] P00AW2_A70ResidentPhone ;
      private string[] P00AW2_A444ResidentHomePhone ;
      private DateTime[] P00AW2_A73ResidentBirthDate ;
      private string[] P00AW2_A71ResidentGUID ;
      private Guid[] P00AW2_A96ResidentTypeId ;
      private bool[] P00AW2_n96ResidentTypeId ;
      private string[] P00AW2_A97ResidentTypeName ;
      private Guid[] P00AW2_A98MedicalIndicationId ;
      private bool[] P00AW2_n98MedicalIndicationId ;
      private string[] P00AW2_A99MedicalIndicationName ;
      private string[] P00AW2_A375ResidentPhoneCode ;
      private string[] P00AW2_A376ResidentPhoneNumber ;
      private string[] P00AW2_A445ResidentHomePhoneCode ;
      private string[] P00AW2_A446ResidentHomePhoneNumber ;
      private Guid[] P00AW2_A554ResidentPackageId ;
      private bool[] P00AW2_n554ResidentPackageId ;
      private Guid[] P00AW2_A555SG_LocationId ;
      private Guid[] P00AW2_A556SG_OrganisationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P00AW3_A11OrganisationId ;
      private Guid[] P00AW3_A29LocationId ;
      private Guid[] P00AW3_A62ResidentId ;
      private string[] P00AW3_A72ResidentSalutation ;
      private string[] P00AW3_A63ResidentBsnNumber ;
      private string[] P00AW3_A64ResidentGivenName ;
      private string[] P00AW3_A65ResidentLastName ;
      private string[] P00AW3_A66ResidentInitials ;
      private string[] P00AW3_A67ResidentEmail ;
      private string[] P00AW3_A68ResidentGender ;
      private string[] P00AW3_A354ResidentCountry ;
      private string[] P00AW3_A355ResidentCity ;
      private string[] P00AW3_A356ResidentZipCode ;
      private string[] P00AW3_A357ResidentAddressLine1 ;
      private string[] P00AW3_A358ResidentAddressLine2 ;
      private string[] P00AW3_A70ResidentPhone ;
      private string[] P00AW3_A444ResidentHomePhone ;
      private DateTime[] P00AW3_A73ResidentBirthDate ;
      private string[] P00AW3_A71ResidentGUID ;
      private Guid[] P00AW3_A96ResidentTypeId ;
      private bool[] P00AW3_n96ResidentTypeId ;
      private string[] P00AW3_A97ResidentTypeName ;
      private Guid[] P00AW3_A98MedicalIndicationId ;
      private bool[] P00AW3_n98MedicalIndicationId ;
      private string[] P00AW3_A99MedicalIndicationName ;
      private string[] P00AW3_A375ResidentPhoneCode ;
      private string[] P00AW3_A376ResidentPhoneNumber ;
      private string[] P00AW3_A445ResidentHomePhoneCode ;
      private string[] P00AW3_A446ResidentHomePhoneNumber ;
      private Guid[] P00AW3_A554ResidentPackageId ;
      private bool[] P00AW3_n554ResidentPackageId ;
      private Guid[] P00AW3_A555SG_LocationId ;
      private Guid[] P00AW3_A556SG_OrganisationId ;
   }

   public class loadaudittrn_resident__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AW2;
          prmP00AW2 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00AW3;
          prmP00AW3 = new Object[] {
          new ParDef("AV17ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AW2", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T1.ResidentHomePhone, T1.ResidentBirthDate, T1.ResidentGUID, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentPhoneCode, T1.ResidentPhoneNumber, T1.ResidentHomePhoneCode, T1.ResidentHomePhoneNumber, T1.ResidentPackageId, T4.SG_LocationId, T4.SG_OrganisationId FROM (((Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentPackage T4 ON T4.ResidentPackageId = T1.ResidentPackageId) WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AW3", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T1.ResidentHomePhone, T1.ResidentBirthDate, T1.ResidentGUID, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentPhoneCode, T1.ResidentPhoneNumber, T1.ResidentHomePhoneCode, T1.ResidentHomePhoneNumber, T1.ResidentPackageId, T4.SG_LocationId, T4.SG_OrganisationId FROM (((Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentPackage T4 ON T4.ResidentPackageId = T1.ResidentPackageId) WHERE T1.ResidentId = :AV17ResidentId and T1.LocationId = :AV18LocationId and T1.OrganisationId = :AV19OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((string[]) buf[21])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[22])[0] = rslt.getGuid(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((string[]) buf[26])[0] = rslt.getVarchar(25);
                ((string[]) buf[27])[0] = rslt.getVarchar(26);
                ((string[]) buf[28])[0] = rslt.getVarchar(27);
                ((Guid[]) buf[29])[0] = rslt.getGuid(28);
                ((bool[]) buf[30])[0] = rslt.wasNull(28);
                ((Guid[]) buf[31])[0] = rslt.getGuid(29);
                ((Guid[]) buf[32])[0] = rslt.getGuid(30);
                return;
             case 1 :
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
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((string[]) buf[21])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[22])[0] = rslt.getGuid(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((string[]) buf[26])[0] = rslt.getVarchar(25);
                ((string[]) buf[27])[0] = rslt.getVarchar(26);
                ((string[]) buf[28])[0] = rslt.getVarchar(27);
                ((Guid[]) buf[29])[0] = rslt.getGuid(28);
                ((bool[]) buf[30])[0] = rslt.wasNull(28);
                ((Guid[]) buf[31])[0] = rslt.getGuid(29);
                ((Guid[]) buf[32])[0] = rslt.getGuid(30);
                return;
       }
    }

 }

}
