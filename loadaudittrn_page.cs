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
   public class loadaudittrn_page : GXProcedure
   {
      public loadaudittrn_page( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittrn_page( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_Trn_PageId ,
                           Guid aP3_LocationId ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17Trn_PageId = aP2_Trn_PageId;
         this.AV19LocationId = aP3_LocationId;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_Trn_PageId ,
                                 Guid aP3_LocationId ,
                                 string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17Trn_PageId = aP2_Trn_PageId;
         this.AV19LocationId = aP3_LocationId;
         this.AV15ActualMode = aP4_ActualMode;
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
         /* Using cursor P00B12 */
         pr_default.execute(0, new Object[] {AV17Trn_PageId, AV19LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00B12_A29LocationId[0];
            A310Trn_PageId = P00B12_A310Trn_PageId[0];
            A318Trn_PageName = P00B12_A318Trn_PageName[0];
            A431PageJsonContent = P00B12_A431PageJsonContent[0];
            n431PageJsonContent = P00B12_n431PageJsonContent[0];
            A432PageGJSHtml = P00B12_A432PageGJSHtml[0];
            n432PageGJSHtml = P00B12_n432PageGJSHtml[0];
            A433PageGJSJson = P00B12_A433PageGJSJson[0];
            n433PageGJSJson = P00B12_n433PageGJSJson[0];
            A434PageIsPublished = P00B12_A434PageIsPublished[0];
            n434PageIsPublished = P00B12_n434PageIsPublished[0];
            A504PageIsPredefined = P00B12_A504PageIsPredefined[0];
            A439PageIsContentPage = P00B12_A439PageIsContentPage[0];
            n439PageIsContentPage = P00B12_n439PageIsContentPage[0];
            A514PageIsDynamicForm = P00B12_A514PageIsDynamicForm[0];
            A519PageIsWebLinkPage = P00B12_A519PageIsWebLinkPage[0];
            A437PageChildren = P00B12_A437PageChildren[0];
            n437PageChildren = P00B12_n437PageChildren[0];
            A58ProductServiceId = P00B12_A58ProductServiceId[0];
            n58ProductServiceId = P00B12_n58ProductServiceId[0];
            A11OrganisationId = P00B12_A11OrganisationId[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Page";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A310Trn_PageId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A318Trn_PageName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A29LocationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageJsonContent";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Json Content", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A431PageJsonContent;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSHtml";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSHtml", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A432PageGJSHtml;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSJson";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSJson", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A433PageGJSJson;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPublished";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Published", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A434PageIsPublished);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPredefined";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Predefined", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A504PageIsPredefined);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsContentPage";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Content Page", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A439PageIsContentPage);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsDynamicForm";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Dynamic Form", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A514PageIsDynamicForm);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsWebLinkPage";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Web Link Page", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A519PageIsWebLinkPage);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageChildren";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Children", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A437PageChildren;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ProductServiceId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Services", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A58ProductServiceId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A11OrganisationId.ToString();
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
         /* Using cursor P00B13 */
         pr_default.execute(1, new Object[] {AV17Trn_PageId, AV19LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00B13_A29LocationId[0];
            A310Trn_PageId = P00B13_A310Trn_PageId[0];
            A318Trn_PageName = P00B13_A318Trn_PageName[0];
            A431PageJsonContent = P00B13_A431PageJsonContent[0];
            n431PageJsonContent = P00B13_n431PageJsonContent[0];
            A432PageGJSHtml = P00B13_A432PageGJSHtml[0];
            n432PageGJSHtml = P00B13_n432PageGJSHtml[0];
            A433PageGJSJson = P00B13_A433PageGJSJson[0];
            n433PageGJSJson = P00B13_n433PageGJSJson[0];
            A434PageIsPublished = P00B13_A434PageIsPublished[0];
            n434PageIsPublished = P00B13_n434PageIsPublished[0];
            A504PageIsPredefined = P00B13_A504PageIsPredefined[0];
            A439PageIsContentPage = P00B13_A439PageIsContentPage[0];
            n439PageIsContentPage = P00B13_n439PageIsContentPage[0];
            A514PageIsDynamicForm = P00B13_A514PageIsDynamicForm[0];
            A519PageIsWebLinkPage = P00B13_A519PageIsWebLinkPage[0];
            A437PageChildren = P00B13_A437PageChildren[0];
            n437PageChildren = P00B13_n437PageChildren[0];
            A58ProductServiceId = P00B13_A58ProductServiceId[0];
            n58ProductServiceId = P00B13_n58ProductServiceId[0];
            A11OrganisationId = P00B13_A11OrganisationId[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Page";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A310Trn_PageId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A318Trn_PageName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageJsonContent";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Json Content", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A431PageJsonContent;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSHtml";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSHtml", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A432PageGJSHtml;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSJson";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSJson", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A433PageGJSJson;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPublished";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Published", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A434PageIsPublished);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPredefined";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Predefined", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A504PageIsPredefined);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsContentPage";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Content Page", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A439PageIsContentPage);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsDynamicForm";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Dynamic Form", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A514PageIsDynamicForm);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsWebLinkPage";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Web Link Page", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A519PageIsWebLinkPage);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageChildren";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Children", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A437PageChildren;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ProductServiceId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Services", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A58ProductServiceId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Trn_PageId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A310Trn_PageId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Trn_PageName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A318Trn_PageName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LocationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageJsonContent") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A431PageJsonContent;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageGJSHtml") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A432PageGJSHtml;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageGJSJson") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A433PageGJSJson;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsPublished") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A434PageIsPublished);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsPredefined") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A504PageIsPredefined);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsContentPage") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A439PageIsContentPage);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsDynamicForm") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A514PageIsDynamicForm);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsWebLinkPage") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A519PageIsWebLinkPage);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageChildren") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A437PageChildren;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ProductServiceId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A58ProductServiceId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "OrganisationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
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
         P00B12_A29LocationId = new Guid[] {Guid.Empty} ;
         P00B12_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00B12_A318Trn_PageName = new string[] {""} ;
         P00B12_A431PageJsonContent = new string[] {""} ;
         P00B12_n431PageJsonContent = new bool[] {false} ;
         P00B12_A432PageGJSHtml = new string[] {""} ;
         P00B12_n432PageGJSHtml = new bool[] {false} ;
         P00B12_A433PageGJSJson = new string[] {""} ;
         P00B12_n433PageGJSJson = new bool[] {false} ;
         P00B12_A434PageIsPublished = new bool[] {false} ;
         P00B12_n434PageIsPublished = new bool[] {false} ;
         P00B12_A504PageIsPredefined = new bool[] {false} ;
         P00B12_A439PageIsContentPage = new bool[] {false} ;
         P00B12_n439PageIsContentPage = new bool[] {false} ;
         P00B12_A514PageIsDynamicForm = new bool[] {false} ;
         P00B12_A519PageIsWebLinkPage = new bool[] {false} ;
         P00B12_A437PageChildren = new string[] {""} ;
         P00B12_n437PageChildren = new bool[] {false} ;
         P00B12_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00B12_n58ProductServiceId = new bool[] {false} ;
         P00B12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00B13_A29LocationId = new Guid[] {Guid.Empty} ;
         P00B13_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00B13_A318Trn_PageName = new string[] {""} ;
         P00B13_A431PageJsonContent = new string[] {""} ;
         P00B13_n431PageJsonContent = new bool[] {false} ;
         P00B13_A432PageGJSHtml = new string[] {""} ;
         P00B13_n432PageGJSHtml = new bool[] {false} ;
         P00B13_A433PageGJSJson = new string[] {""} ;
         P00B13_n433PageGJSJson = new bool[] {false} ;
         P00B13_A434PageIsPublished = new bool[] {false} ;
         P00B13_n434PageIsPublished = new bool[] {false} ;
         P00B13_A504PageIsPredefined = new bool[] {false} ;
         P00B13_A439PageIsContentPage = new bool[] {false} ;
         P00B13_n439PageIsContentPage = new bool[] {false} ;
         P00B13_A514PageIsDynamicForm = new bool[] {false} ;
         P00B13_A519PageIsWebLinkPage = new bool[] {false} ;
         P00B13_A437PageChildren = new string[] {""} ;
         P00B13_n437PageChildren = new bool[] {false} ;
         P00B13_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00B13_n58ProductServiceId = new bool[] {false} ;
         P00B13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_page__default(),
            new Object[][] {
                new Object[] {
               P00B12_A29LocationId, P00B12_A310Trn_PageId, P00B12_A318Trn_PageName, P00B12_A431PageJsonContent, P00B12_n431PageJsonContent, P00B12_A432PageGJSHtml, P00B12_n432PageGJSHtml, P00B12_A433PageGJSJson, P00B12_n433PageGJSJson, P00B12_A434PageIsPublished,
               P00B12_n434PageIsPublished, P00B12_A504PageIsPredefined, P00B12_A439PageIsContentPage, P00B12_n439PageIsContentPage, P00B12_A514PageIsDynamicForm, P00B12_A519PageIsWebLinkPage, P00B12_A437PageChildren, P00B12_n437PageChildren, P00B12_A58ProductServiceId, P00B12_n58ProductServiceId,
               P00B12_A11OrganisationId
               }
               , new Object[] {
               P00B13_A29LocationId, P00B13_A310Trn_PageId, P00B13_A318Trn_PageName, P00B13_A431PageJsonContent, P00B13_n431PageJsonContent, P00B13_A432PageGJSHtml, P00B13_n432PageGJSHtml, P00B13_A433PageGJSJson, P00B13_n433PageGJSJson, P00B13_A434PageIsPublished,
               P00B13_n434PageIsPublished, P00B13_A504PageIsPredefined, P00B13_A439PageIsContentPage, P00B13_n439PageIsContentPage, P00B13_A514PageIsDynamicForm, P00B13_A519PageIsWebLinkPage, P00B13_A437PageChildren, P00B13_n437PageChildren, P00B13_A58ProductServiceId, P00B13_n58ProductServiceId,
               P00B13_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private bool returnInSub ;
      private bool n431PageJsonContent ;
      private bool n432PageGJSHtml ;
      private bool n433PageGJSJson ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool A504PageIsPredefined ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A514PageIsDynamicForm ;
      private bool A519PageIsWebLinkPage ;
      private bool n437PageChildren ;
      private bool n58ProductServiceId ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid AV17Trn_PageId ;
      private Guid AV19LocationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00B12_A29LocationId ;
      private Guid[] P00B12_A310Trn_PageId ;
      private string[] P00B12_A318Trn_PageName ;
      private string[] P00B12_A431PageJsonContent ;
      private bool[] P00B12_n431PageJsonContent ;
      private string[] P00B12_A432PageGJSHtml ;
      private bool[] P00B12_n432PageGJSHtml ;
      private string[] P00B12_A433PageGJSJson ;
      private bool[] P00B12_n433PageGJSJson ;
      private bool[] P00B12_A434PageIsPublished ;
      private bool[] P00B12_n434PageIsPublished ;
      private bool[] P00B12_A504PageIsPredefined ;
      private bool[] P00B12_A439PageIsContentPage ;
      private bool[] P00B12_n439PageIsContentPage ;
      private bool[] P00B12_A514PageIsDynamicForm ;
      private bool[] P00B12_A519PageIsWebLinkPage ;
      private string[] P00B12_A437PageChildren ;
      private bool[] P00B12_n437PageChildren ;
      private Guid[] P00B12_A58ProductServiceId ;
      private bool[] P00B12_n58ProductServiceId ;
      private Guid[] P00B12_A11OrganisationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P00B13_A29LocationId ;
      private Guid[] P00B13_A310Trn_PageId ;
      private string[] P00B13_A318Trn_PageName ;
      private string[] P00B13_A431PageJsonContent ;
      private bool[] P00B13_n431PageJsonContent ;
      private string[] P00B13_A432PageGJSHtml ;
      private bool[] P00B13_n432PageGJSHtml ;
      private string[] P00B13_A433PageGJSJson ;
      private bool[] P00B13_n433PageGJSJson ;
      private bool[] P00B13_A434PageIsPublished ;
      private bool[] P00B13_n434PageIsPublished ;
      private bool[] P00B13_A504PageIsPredefined ;
      private bool[] P00B13_A439PageIsContentPage ;
      private bool[] P00B13_n439PageIsContentPage ;
      private bool[] P00B13_A514PageIsDynamicForm ;
      private bool[] P00B13_A519PageIsWebLinkPage ;
      private string[] P00B13_A437PageChildren ;
      private bool[] P00B13_n437PageChildren ;
      private Guid[] P00B13_A58ProductServiceId ;
      private bool[] P00B13_n58ProductServiceId ;
      private Guid[] P00B13_A11OrganisationId ;
   }

   public class loadaudittrn_page__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B12;
          prmP00B12 = new Object[] {
          new ParDef("AV17Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00B13;
          prmP00B13 = new Object[] {
          new ParDef("AV17Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B12", "SELECT LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :AV17Trn_PageId and LocationId = :AV19LocationId ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B13", "SELECT LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :AV17Trn_PageId and LocationId = :AV19LocationId ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B13,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((Guid[]) buf[18])[0] = rslt.getGuid(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((Guid[]) buf[20])[0] = rslt.getGuid(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((Guid[]) buf[18])[0] = rslt.getGuid(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((Guid[]) buf[20])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
