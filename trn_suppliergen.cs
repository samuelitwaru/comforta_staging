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
   public class trn_suppliergen : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action27") == 0 )
         {
            A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_27_069( A42SupplierGenId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"SUPPLIERGENCONTACTPHONE") == 0 )
         {
            A381SupplierGenPhoneCode = GetPar( "SupplierGenPhoneCode");
            AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
            A382SupplierGenPhoneNumber = GetPar( "SupplierGenPhoneNumber");
            AssignAttri("", false, "A382SupplierGenPhoneNumber", A382SupplierGenPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASASUPPLIERGENCONTACTPHONE069( A381SupplierGenPhoneCode, A382SupplierGenPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A282SupplierGenTypeId = StringUtil.StrToGuid( GetPar( "SupplierGenTypeId"));
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A282SupplierGenTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_suppliergen.aspx")), "trn_suppliergen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_suppliergen.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  AssignAttri("", false, "AV7SupplierGenId", AV7SupplierGenId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "General Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_suppliergen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_SupplierGenId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierGenId = aP1_SupplierGenId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Supplier Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGen.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenKvkNumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenKvkNumber_Internalname, A43SupplierGenKvkNumber, StringUtil.RTrim( context.localUtil.Format( A43SupplierGenKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "12345678", edtSupplierGenKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Name", ""), edtSupplierGenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergentypeid_Internalname, context.GetMessage( "Category", ""), "", "", lblTextblocksuppliergentypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergentypeid.SetProperty("Caption", Combo_suppliergentypeid_Caption);
         ucCombo_suppliergentypeid.SetProperty("Cls", Combo_suppliergentypeid_Cls);
         ucCombo_suppliergentypeid.SetProperty("EmptyItem", Combo_suppliergentypeid_Emptyitem);
         ucCombo_suppliergentypeid.SetProperty("IncludeAddNewOption", Combo_suppliergentypeid_Includeaddnewoption);
         ucCombo_suppliergentypeid.SetProperty("DropDownOptionsData", AV15SupplierGenTypeId_Data);
         ucCombo_suppliergentypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergentypeid_Internalname, "COMBO_SUPPLIERGENTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenTypeId_Internalname, context.GetMessage( "Supplier Gen Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeId_Internalname, A282SupplierGenTypeId.ToString(), A282SupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenTypeId_Visible, edtSupplierGenTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenContactName_Internalname, context.GetMessage( "Contact Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactName_Internalname, A47SupplierGenContactName, StringUtil.RTrim( context.localUtil.Format( A47SupplierGenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Contact Name", ""), edtSupplierGenContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenphonecode_Internalname, context.GetMessage( "Phone", ""), "", "", lblTextblocksuppliergenphonecode_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsuppliergenphonecode_Internalname, tblTablemergedsuppliergenphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_suppliergenphonecode.SetProperty("Caption", Combo_suppliergenphonecode_Caption);
         ucCombo_suppliergenphonecode.SetProperty("Cls", Combo_suppliergenphonecode_Cls);
         ucCombo_suppliergenphonecode.SetProperty("EmptyItem", Combo_suppliergenphonecode_Emptyitem);
         ucCombo_suppliergenphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenphonecode.SetProperty("DropDownOptionsData", AV27SupplierGenPhoneCode_Data);
         ucCombo_suppliergenphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenphonecode_Internalname, "COMBO_SUPPLIERGENPHONECODEContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='Invisible'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenPhoneCode_Internalname, context.GetMessage( "Supplier Gen Phone Code", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenPhoneCode_Internalname, A381SupplierGenPhoneCode, StringUtil.RTrim( context.localUtil.Format( A381SupplierGenPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenPhoneCode_Visible, edtSupplierGenPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenPhoneNumber_Internalname, context.GetMessage( "Supplier Gen Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenPhoneNumber_Internalname, A382SupplierGenPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A382SupplierGenPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "229 12 34 56", edtSupplierGenPhoneNumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtSupplierGenPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenWebsite_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenWebsite_Internalname, context.GetMessage( "Website", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenWebsite_Internalname, A441SupplierGenWebsite, StringUtil.RTrim( context.localUtil.Format( A441SupplierGenWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "www.website.com", ""), edtSupplierGenWebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenWebsite_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGen.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine1_Internalname, A336SupplierGenAddressLine1, StringUtil.RTrim( context.localUtil.Format( A336SupplierGenAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Address Line 1", ""), edtSupplierGenAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine2_Internalname, A337SupplierGenAddressLine2, StringUtil.RTrim( context.localUtil.Format( A337SupplierGenAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Address Line 2", ""), edtSupplierGenAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressZipCode_Internalname, A294SupplierGenAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A294SupplierGenAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtSupplierGenAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCity_Internalname, A295SupplierGenAddressCity, StringUtil.RTrim( context.localUtil.Format( A295SupplierGenAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "City", ""), edtSupplierGenAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenaddresscountry_Internalname, context.GetMessage( " Country", ""), "", "", lblTextblocksuppliergenaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenaddresscountry.SetProperty("Caption", Combo_suppliergenaddresscountry_Caption);
         ucCombo_suppliergenaddresscountry.SetProperty("Cls", Combo_suppliergenaddresscountry_Cls);
         ucCombo_suppliergenaddresscountry.SetProperty("EmptyItem", Combo_suppliergenaddresscountry_Emptyitem);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsData", AV23SupplierGenAddressCountry_Data);
         ucCombo_suppliergenaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenaddresscountry_Internalname, "COMBO_SUPPLIERGENADDRESSCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCountry_Internalname, context.GetMessage( "Supplier Gen Address Country", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCountry_Internalname, A335SupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( A335SupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenAddressCountry_Visible, edtSupplierGenAddressCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergentypeid_Internalname, AV20ComboSupplierGenTypeId.ToString(), AV20ComboSupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergentypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergentypeid_Visible, edtavCombosuppliergentypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenphonecode_Internalname, AV25ComboSupplierGenPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV25ComboSupplierGenPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenphonecode_Visible, edtavCombosuppliergenphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenaddresscountry_Internalname, AV24ComboSupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV24ComboSupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenaddresscountry_Visible, edtavCombosuppliergenaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, edtSupplierGenId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactPhone_Internalname, StringUtil.RTrim( A48SupplierGenContactPhone), StringUtil.RTrim( context.localUtil.Format( A48SupplierGenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierGenContactPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenContactPhone_Visible, edtSupplierGenContactPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENTYPEID_DATA"), AV15SupplierGenTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENPHONECODE_DATA"), AV27SupplierGenPhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENADDRESSCOUNTRY_DATA"), AV23SupplierGenAddressCountry_Data);
               /* Read saved values. */
               Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
               Z335SupplierGenAddressCountry = cgiGet( "Z335SupplierGenAddressCountry");
               Z381SupplierGenPhoneCode = cgiGet( "Z381SupplierGenPhoneCode");
               Z48SupplierGenContactPhone = cgiGet( "Z48SupplierGenContactPhone");
               Z43SupplierGenKvkNumber = cgiGet( "Z43SupplierGenKvkNumber");
               Z44SupplierGenCompanyName = cgiGet( "Z44SupplierGenCompanyName");
               Z295SupplierGenAddressCity = cgiGet( "Z295SupplierGenAddressCity");
               Z294SupplierGenAddressZipCode = cgiGet( "Z294SupplierGenAddressZipCode");
               Z336SupplierGenAddressLine1 = cgiGet( "Z336SupplierGenAddressLine1");
               Z337SupplierGenAddressLine2 = cgiGet( "Z337SupplierGenAddressLine2");
               Z47SupplierGenContactName = cgiGet( "Z47SupplierGenContactName");
               Z382SupplierGenPhoneNumber = cgiGet( "Z382SupplierGenPhoneNumber");
               Z441SupplierGenWebsite = cgiGet( "Z441SupplierGenWebsite");
               Z282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "Z282SupplierGenTypeId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = false;
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "N282SupplierGenTypeId"));
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               AV7SupplierGenId = StringUtil.StrToGuid( cgiGet( "vSUPPLIERGENID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERGENTYPEID"));
               AV28Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV30OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "ORGANISATIONID"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               A290SupplierGenTypeName = cgiGet( "SUPPLIERGENTYPENAME");
               AV32Pgmname = cgiGet( "vPGMNAME");
               Combo_suppliergentypeid_Objectcall = cgiGet( "COMBO_SUPPLIERGENTYPEID_Objectcall");
               Combo_suppliergentypeid_Class = cgiGet( "COMBO_SUPPLIERGENTYPEID_Class");
               Combo_suppliergentypeid_Icontype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icontype");
               Combo_suppliergentypeid_Icon = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icon");
               Combo_suppliergentypeid_Caption = cgiGet( "COMBO_SUPPLIERGENTYPEID_Caption");
               Combo_suppliergentypeid_Tooltip = cgiGet( "COMBO_SUPPLIERGENTYPEID_Tooltip");
               Combo_suppliergentypeid_Cls = cgiGet( "COMBO_SUPPLIERGENTYPEID_Cls");
               Combo_suppliergentypeid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set");
               Combo_suppliergentypeid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_get");
               Combo_suppliergentypeid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_set");
               Combo_suppliergentypeid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_get");
               Combo_suppliergentypeid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENTYPEID_Gamoauthtoken");
               Combo_suppliergentypeid_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENTYPEID_Ddointernalname");
               Combo_suppliergentypeid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolalign");
               Combo_suppliergentypeid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Dropdownoptionstype");
               Combo_suppliergentypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Enabled"));
               Combo_suppliergentypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Visible"));
               Combo_suppliergentypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolidtoreplace");
               Combo_suppliergentypeid_Datalisttype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalisttype");
               Combo_suppliergentypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Allowmultipleselection"));
               Combo_suppliergentypeid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistfixedvalues");
               Combo_suppliergentypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Isgriditem"));
               Combo_suppliergentypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Hasdescription"));
               Combo_suppliergentypeid_Datalistproc = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistproc");
               Combo_suppliergentypeid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistprocparametersprefix");
               Combo_suppliergentypeid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENTYPEID_Remoteservicesparameters");
               Combo_suppliergentypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergentypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeonlyselectedoption"));
               Combo_suppliergentypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeselectalloption"));
               Combo_suppliergentypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitem"));
               Combo_suppliergentypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeaddnewoption"));
               Combo_suppliergentypeid_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENTYPEID_Htmltemplate");
               Combo_suppliergentypeid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluestype");
               Combo_suppliergentypeid_Loadingdata = cgiGet( "COMBO_SUPPLIERGENTYPEID_Loadingdata");
               Combo_suppliergentypeid_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENTYPEID_Noresultsfound");
               Combo_suppliergentypeid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitemtext");
               Combo_suppliergentypeid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Onlyselectedvalues");
               Combo_suppliergentypeid_Selectalltext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectalltext");
               Combo_suppliergentypeid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluesseparator");
               Combo_suppliergentypeid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Addnewoptiontext");
               Combo_suppliergentypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenphonecode_Objectcall = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Objectcall");
               Combo_suppliergenphonecode_Class = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Class");
               Combo_suppliergenphonecode_Icontype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Icontype");
               Combo_suppliergenphonecode_Icon = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Icon");
               Combo_suppliergenphonecode_Caption = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Caption");
               Combo_suppliergenphonecode_Tooltip = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Tooltip");
               Combo_suppliergenphonecode_Cls = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Cls");
               Combo_suppliergenphonecode_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_set");
               Combo_suppliergenphonecode_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_get");
               Combo_suppliergenphonecode_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedtext_set");
               Combo_suppliergenphonecode_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectedtext_get");
               Combo_suppliergenphonecode_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Gamoauthtoken");
               Combo_suppliergenphonecode_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Ddointernalname");
               Combo_suppliergenphonecode_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Titlecontrolalign");
               Combo_suppliergenphonecode_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Dropdownoptionstype");
               Combo_suppliergenphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Enabled"));
               Combo_suppliergenphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Visible"));
               Combo_suppliergenphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Titlecontrolidtoreplace");
               Combo_suppliergenphonecode_Datalisttype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalisttype");
               Combo_suppliergenphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Allowmultipleselection"));
               Combo_suppliergenphonecode_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistfixedvalues");
               Combo_suppliergenphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Isgriditem"));
               Combo_suppliergenphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Hasdescription"));
               Combo_suppliergenphonecode_Datalistproc = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistproc");
               Combo_suppliergenphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistprocparametersprefix");
               Combo_suppliergenphonecode_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Remoteservicesparameters");
               Combo_suppliergenphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeonlyselectedoption"));
               Combo_suppliergenphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeselectalloption"));
               Combo_suppliergenphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Emptyitem"));
               Combo_suppliergenphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Includeaddnewoption"));
               Combo_suppliergenphonecode_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Htmltemplate");
               Combo_suppliergenphonecode_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Multiplevaluestype");
               Combo_suppliergenphonecode_Loadingdata = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Loadingdata");
               Combo_suppliergenphonecode_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Noresultsfound");
               Combo_suppliergenphonecode_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Emptyitemtext");
               Combo_suppliergenphonecode_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Onlyselectedvalues");
               Combo_suppliergenphonecode_Selectalltext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Selectalltext");
               Combo_suppliergenphonecode_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Multiplevaluesseparator");
               Combo_suppliergenphonecode_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENPHONECODE_Addnewoptiontext");
               Combo_suppliergenphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenaddresscountry_Objectcall = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall");
               Combo_suppliergenaddresscountry_Class = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Class");
               Combo_suppliergenaddresscountry_Icontype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icontype");
               Combo_suppliergenaddresscountry_Icon = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icon");
               Combo_suppliergenaddresscountry_Caption = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Caption");
               Combo_suppliergenaddresscountry_Tooltip = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Tooltip");
               Combo_suppliergenaddresscountry_Cls = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls");
               Combo_suppliergenaddresscountry_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set");
               Combo_suppliergenaddresscountry_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_get");
               Combo_suppliergenaddresscountry_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set");
               Combo_suppliergenaddresscountry_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_get");
               Combo_suppliergenaddresscountry_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gamoauthtoken");
               Combo_suppliergenaddresscountry_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname");
               Combo_suppliergenaddresscountry_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolalign");
               Combo_suppliergenaddresscountry_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Dropdownoptionstype");
               Combo_suppliergenaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled"));
               Combo_suppliergenaddresscountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Visible"));
               Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolidtoreplace");
               Combo_suppliergenaddresscountry_Datalisttype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalisttype");
               Combo_suppliergenaddresscountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Allowmultipleselection"));
               Combo_suppliergenaddresscountry_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistfixedvalues");
               Combo_suppliergenaddresscountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Isgriditem"));
               Combo_suppliergenaddresscountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Hasdescription"));
               Combo_suppliergenaddresscountry_Datalistproc = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistproc");
               Combo_suppliergenaddresscountry_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistprocparametersprefix");
               Combo_suppliergenaddresscountry_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Remoteservicesparameters");
               Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenaddresscountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeonlyselectedoption"));
               Combo_suppliergenaddresscountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeselectalloption"));
               Combo_suppliergenaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem"));
               Combo_suppliergenaddresscountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeaddnewoption"));
               Combo_suppliergenaddresscountry_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate");
               Combo_suppliergenaddresscountry_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluestype");
               Combo_suppliergenaddresscountry_Loadingdata = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Loadingdata");
               Combo_suppliergenaddresscountry_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Noresultsfound");
               Combo_suppliergenaddresscountry_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitemtext");
               Combo_suppliergenaddresscountry_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Onlyselectedvalues");
               Combo_suppliergenaddresscountry_Selectalltext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectalltext");
               Combo_suppliergenaddresscountry_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluesseparator");
               Combo_suppliergenaddresscountry_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Addnewoptiontext");
               Combo_suppliergenaddresscountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
               AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
               A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
               AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenTypeId_Internalname), "") == 0 )
               {
                  A282SupplierGenTypeId = Guid.Empty;
                  AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                     AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
               AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
               A381SupplierGenPhoneCode = cgiGet( edtSupplierGenPhoneCode_Internalname);
               AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
               A382SupplierGenPhoneNumber = cgiGet( edtSupplierGenPhoneNumber_Internalname);
               AssignAttri("", false, "A382SupplierGenPhoneNumber", A382SupplierGenPhoneNumber);
               A441SupplierGenWebsite = cgiGet( edtSupplierGenWebsite_Internalname);
               AssignAttri("", false, "A441SupplierGenWebsite", A441SupplierGenWebsite);
               A336SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
               AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
               A337SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
               AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
               A294SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
               AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
               A295SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
               AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
               A335SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
               AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
               AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtavCombosuppliergentypeid_Internalname));
               AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
               AV25ComboSupplierGenPhoneCode = cgiGet( edtavCombosuppliergenphonecode_Internalname);
               AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
               AV24ComboSupplierGenAddressCountry = cgiGet( edtavCombosuppliergenaddresscountry_Internalname);
               AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenId_Internalname), "") == 0 )
               {
                  A42SupplierGenId = Guid.Empty;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
               else
               {
                  try
                  {
                     A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
               AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A42SupplierGenId != Z42SupplierGenId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_suppliergen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7SupplierGenId) )
                  {
                     A42SupplierGenId = AV7SupplierGenId;
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                     {
                        A42SupplierGenId = Guid.NewGuid( );
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7SupplierGenId) )
                     {
                        A42SupplierGenId = AV7SupplierGenId;
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                        {
                           A42SupplierGenId = Guid.NewGuid( );
                           n42SupplierGenId = false;
                           AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                        }
                     }
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERGENID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierGenId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergentypeid.Onoptionclicked */
                           E12062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E13062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll069( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes069( ) ;
         }
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSupplierGenAddressCountry_Visible = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Visible), 5, 0), true);
         AV24ComboSupplierGenAddressCountry = "";
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         edtavCombosuppliergenaddresscountry_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "HTMLTemplate", Combo_suppliergenaddresscountry_Htmltemplate);
         edtSupplierGenPhoneCode_Visible = 0;
         AssignProp("", false, edtSupplierGenPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneCode_Visible), 5, 0), true);
         AV25ComboSupplierGenPhoneCode = "";
         AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
         edtavCombosuppliergenphonecode_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenphonecode_Htmltemplate = GXt_char2;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "HTMLTemplate", Combo_suppliergenphonecode_Htmltemplate);
         edtSupplierGenTypeId_Visible = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Visible), 5, 0), true);
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         edtavCombosuppliergentypeid_Visible = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENPHONECODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierGenTypeId") == 0 )
               {
                  AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_SupplierGenTypeId", AV13Insert_SupplierGenTypeId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
                  {
                     AV20ComboSupplierGenTypeId = AV13Insert_SupplierGenTypeId;
                     AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
                     Combo_suppliergentypeid_Selectedvalue_set = StringUtil.Trim( AV20ComboSupplierGenTypeId.ToString());
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
                     Combo_suppliergentypeid_Enabled = false;
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV28Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV28Insert_OrganisationId", AV28Insert_OrganisationId.ToString());
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtSupplierGenId_Visible = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         edtSupplierGenContactPhone_Visible = 0;
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24ComboSupplierGenAddressCountry = "Netherlands";
            AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
            Combo_suppliergenaddresscountry_Selectedtext_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedText_set", Combo_suppliergenaddresscountry_Selectedtext_set);
            Combo_suppliergenaddresscountry_Selectedvalue_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
         }
         AV26defaultCountryPhoneCode = "+31";
         AssignAttri("", false, "AV26defaultCountryPhoneCode", AV26defaultCountryPhoneCode);
         Combo_suppliergenphonecode_Selectedtext_set = AV26defaultCountryPhoneCode;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedText_set", Combo_suppliergenphonecode_Selectedtext_set);
         Combo_suppliergenphonecode_Selectedvalue_set = AV26defaultCountryPhoneCode;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_suppliergenphonecode_Selectedvalue_set);
         AV25ComboSupplierGenPhoneCode = AV26defaultCountryPhoneCode;
         AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
         GXt_guid3 = AV30OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
         AV30OrganisationId = GXt_guid3;
         AssignAttri("", false, "AV30OrganisationId", AV30OrganisationId.ToString());
         if ( (Guid.Empty==AV30OrganisationId) )
         {
            A11OrganisationId = Guid.Empty;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            n11OrganisationId = true;
         }
      }

      protected void E13062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_suppliergenww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12062( )
      {
         /* Combo_suppliergentypeid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_suppliergentypeid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            AV31DefaultSupplierGenTypeName = Combo_suppliergentypeid_Selectedtext_get;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewsuppliergentype.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(A282SupplierGenTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV31DefaultSupplierGenTypeName));
            context.PopUp(formatLink("wp_createnewsuppliergentype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_suppliergentypeid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
            new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  "NEW",  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
            AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
            AV17ComboSelectedValue = AV12WebSession.Get("SUPPLIERGENTYPEID");
            AV12WebSession.Remove("SUPPLIERGENTYPEID");
            Combo_suppliergentypeid_Selectedvalue_set = AV17ComboSelectedValue;
            ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
            AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
            AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         }
         else
         {
            AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( Combo_suppliergentypeid_Selectedvalue_get);
            AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
            GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
            new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  "NEW",  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
            AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SupplierGenTypeId_Data", AV15SupplierGenTypeId_Data);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV23SupplierGenAddressCountry_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenAddressCountry",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV23SupplierGenAddressCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergenaddresscountry_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
         AV24ComboSupplierGenAddressCountry = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenaddresscountry_Enabled = false;
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGENPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV27SupplierGenPhoneCode_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenPhoneCode",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV27SupplierGenPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergenphonecode_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "SelectedValue_set", Combo_suppliergenphonecode_Selectedvalue_set);
         AV25ComboSupplierGenPhoneCode = AV17ComboSelectedValue;
         AssignAttri("", false, "AV25ComboSupplierGenPhoneCode", AV25ComboSupplierGenPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenphonecode_Enabled = false;
            ucCombo_suppliergenphonecode.SendProperty(context, "", false, Combo_suppliergenphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenphonecode_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         GXt_boolean5 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean5) ;
         Combo_suppliergentypeid_Includeaddnewoption = GXt_boolean5;
         ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_suppliergentypeid_Includeaddnewoption));
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15SupplierGenTypeId_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_suppliergentypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
         AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergentypeid_Enabled = false;
            ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         }
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z335SupplierGenAddressCountry = T00063_A335SupplierGenAddressCountry[0];
               Z381SupplierGenPhoneCode = T00063_A381SupplierGenPhoneCode[0];
               Z48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
               Z43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
               Z44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
               Z295SupplierGenAddressCity = T00063_A295SupplierGenAddressCity[0];
               Z294SupplierGenAddressZipCode = T00063_A294SupplierGenAddressZipCode[0];
               Z336SupplierGenAddressLine1 = T00063_A336SupplierGenAddressLine1[0];
               Z337SupplierGenAddressLine2 = T00063_A337SupplierGenAddressLine2[0];
               Z47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
               Z382SupplierGenPhoneNumber = T00063_A382SupplierGenPhoneNumber[0];
               Z441SupplierGenWebsite = T00063_A441SupplierGenWebsite[0];
               Z282SupplierGenTypeId = T00063_A282SupplierGenTypeId[0];
               Z11OrganisationId = T00063_A11OrganisationId[0];
            }
            else
            {
               Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
               Z381SupplierGenPhoneCode = A381SupplierGenPhoneCode;
               Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
               Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
               Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
               Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
               Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
               Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
               Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
               Z47SupplierGenContactName = A47SupplierGenContactName;
               Z382SupplierGenPhoneNumber = A382SupplierGenPhoneNumber;
               Z441SupplierGenWebsite = A441SupplierGenWebsite;
               Z282SupplierGenTypeId = A282SupplierGenTypeId;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -29 )
         {
            Z42SupplierGenId = A42SupplierGenId;
            Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
            Z381SupplierGenPhoneCode = A381SupplierGenPhoneCode;
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
            Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
            Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
            Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z382SupplierGenPhoneNumber = A382SupplierGenPhoneNumber;
            Z441SupplierGenWebsite = A441SupplierGenWebsite;
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
            Z11OrganisationId = A11OrganisationId;
            Z290SupplierGenTypeName = A290SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV32Pgmname = "Trn_SupplierGen";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenId_Enabled = 1;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            edtSupplierGenTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenTypeId_Enabled = 1;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV28Insert_OrganisationId) )
         {
            A11OrganisationId = AV28Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( IsIns( )  && ! (Guid.Empty==AV30OrganisationId) )
            {
               A11OrganisationId = AV30OrganisationId;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            A282SupplierGenTypeId = AV13Insert_SupplierGenTypeId;
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         }
         else
         {
            A282SupplierGenTypeId = AV20ComboSupplierGenTypeId;
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         }
         A381SupplierGenPhoneCode = AV25ComboSupplierGenPhoneCode;
         AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
         A335SupplierGenAddressCountry = AV24ComboSupplierGenAddressCountry;
         AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            A42SupplierGenId = AV7SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
            {
               A42SupplierGenId = Guid.NewGuid( );
               n42SupplierGenId = false;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A282SupplierGenTypeId});
            A290SupplierGenTypeName = T00064_A290SupplierGenTypeName[0];
            pr_default.close(2);
         }
      }

      protected void Load069( )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A335SupplierGenAddressCountry = T00066_A335SupplierGenAddressCountry[0];
            AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
            A381SupplierGenPhoneCode = T00066_A381SupplierGenPhoneCode[0];
            AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
            A48SupplierGenContactPhone = T00066_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A43SupplierGenKvkNumber = T00066_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A290SupplierGenTypeName = T00066_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = T00066_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A295SupplierGenAddressCity = T00066_A295SupplierGenAddressCity[0];
            AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
            A294SupplierGenAddressZipCode = T00066_A294SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
            A336SupplierGenAddressLine1 = T00066_A336SupplierGenAddressLine1[0];
            AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
            A337SupplierGenAddressLine2 = T00066_A337SupplierGenAddressLine2[0];
            AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
            A47SupplierGenContactName = T00066_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A382SupplierGenPhoneNumber = T00066_A382SupplierGenPhoneNumber[0];
            AssignAttri("", false, "A382SupplierGenPhoneNumber", A382SupplierGenPhoneNumber);
            A441SupplierGenWebsite = T00066_A441SupplierGenWebsite[0];
            AssignAttri("", false, "A441SupplierGenWebsite", A441SupplierGenWebsite);
            A282SupplierGenTypeId = T00066_A282SupplierGenTypeId[0];
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            A11OrganisationId = T00066_A11OrganisationId[0];
            n11OrganisationId = T00066_n11OrganisationId[0];
            ZM069( -29) ;
         }
         pr_default.close(4);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
      }

      protected void CheckExtendedTable069( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A43SupplierGenKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43SupplierGenKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A43SupplierGenKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KvK number should contain 8 digits", ""), 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGenType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A290SupplierGenTypeName = T00064_A290SupplierGenTypeName[0];
         pr_default.close(2);
         if ( (Guid.Empty==A282SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Id", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Company Name", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENCOMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A335SupplierGenAddressCountry)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Country", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSCOUNTRY");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressCountry_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A295SupplierGenAddressCity)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address City", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSCITY");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressCity_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A294SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Zip Code", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A336SupplierGenAddressLine1)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Line1", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENADDRESSLINE1");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenAddressLine1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         if ( ! ( GxRegex.IsMatch(A382SupplierGenPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone contains 9 digits", ""), context.GetMessage( "Supplier Gen Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A382SupplierGenPhoneNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A441SupplierGenWebsite,context.GetMessage( "^(https?:\\/\\/)?(www\\.)?[a-zA-Z0-9-]+(\\.[a-zA-Z]{2,})(\\/[^\\s]*)?$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A441SupplierGenWebsite)) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid website format", ""), 1, "SUPPLIERGENWEBSITE");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenWebsite_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00065 */
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
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_30( Guid A282SupplierGenTypeId )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGenType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A290SupplierGenTypeName = T00067_A290SupplierGenTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A290SupplierGenTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_31( Guid A11OrganisationId )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey069( )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 29) ;
            RcdFound9 = 1;
            A42SupplierGenId = T00063_A42SupplierGenId[0];
            n42SupplierGenId = T00063_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A335SupplierGenAddressCountry = T00063_A335SupplierGenAddressCountry[0];
            AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
            A381SupplierGenPhoneCode = T00063_A381SupplierGenPhoneCode[0];
            AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
            A48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A295SupplierGenAddressCity = T00063_A295SupplierGenAddressCity[0];
            AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
            A294SupplierGenAddressZipCode = T00063_A294SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
            A336SupplierGenAddressLine1 = T00063_A336SupplierGenAddressLine1[0];
            AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
            A337SupplierGenAddressLine2 = T00063_A337SupplierGenAddressLine2[0];
            AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
            A47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A382SupplierGenPhoneNumber = T00063_A382SupplierGenPhoneNumber[0];
            AssignAttri("", false, "A382SupplierGenPhoneNumber", A382SupplierGenPhoneNumber);
            A441SupplierGenWebsite = T00063_A441SupplierGenWebsite[0];
            AssignAttri("", false, "A441SupplierGenWebsite", A441SupplierGenWebsite);
            A282SupplierGenTypeId = T00063_A282SupplierGenTypeId[0];
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            A11OrganisationId = T00063_A11OrganisationId[0];
            n11OrganisationId = T00063_n11OrganisationId[0];
            Z42SupplierGenId = A42SupplierGenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000610_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000610_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               A42SupplierGenId = T000610_A42SupplierGenId[0];
               n42SupplierGenId = T000610_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000611_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000611_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               A42SupplierGenId = T000611_A42SupplierGenId[0];
               n42SupplierGenId = T000611_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert069( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  A42SupplierGenId = Z42SupplierGenId;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERGENID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierGenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update069( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert069( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert069( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A42SupplierGenId != Z42SupplierGenId )
         {
            A42SupplierGenId = Z42SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z335SupplierGenAddressCountry, T00062_A335SupplierGenAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z381SupplierGenPhoneCode, T00062_A381SupplierGenPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z295SupplierGenAddressCity, T00062_A295SupplierGenAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z294SupplierGenAddressZipCode, T00062_A294SupplierGenAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z336SupplierGenAddressLine1, T00062_A336SupplierGenAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z337SupplierGenAddressLine2, T00062_A337SupplierGenAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z382SupplierGenPhoneNumber, T00062_A382SupplierGenPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z441SupplierGenWebsite, T00062_A441SupplierGenWebsite[0]) != 0 ) || ( Z282SupplierGenTypeId != T00062_A282SupplierGenTypeId[0] ) || ( Z11OrganisationId != T00062_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z335SupplierGenAddressCountry, T00062_A335SupplierGenAddressCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCountry");
                  GXUtil.WriteLogRaw("Old: ",Z335SupplierGenAddressCountry);
                  GXUtil.WriteLogRaw("Current: ",T00062_A335SupplierGenAddressCountry[0]);
               }
               if ( StringUtil.StrCmp(Z381SupplierGenPhoneCode, T00062_A381SupplierGenPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z381SupplierGenPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A381SupplierGenPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactPhone");
                  GXUtil.WriteLogRaw("Old: ",Z48SupplierGenContactPhone);
                  GXUtil.WriteLogRaw("Current: ",T00062_A48SupplierGenContactPhone[0]);
               }
               if ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z43SupplierGenKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43SupplierGenKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z44SupplierGenCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A44SupplierGenCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z295SupplierGenAddressCity, T00062_A295SupplierGenAddressCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCity");
                  GXUtil.WriteLogRaw("Old: ",Z295SupplierGenAddressCity);
                  GXUtil.WriteLogRaw("Current: ",T00062_A295SupplierGenAddressCity[0]);
               }
               if ( StringUtil.StrCmp(Z294SupplierGenAddressZipCode, T00062_A294SupplierGenAddressZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z294SupplierGenAddressZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A294SupplierGenAddressZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z336SupplierGenAddressLine1, T00062_A336SupplierGenAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z336SupplierGenAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00062_A336SupplierGenAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z337SupplierGenAddressLine2, T00062_A337SupplierGenAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z337SupplierGenAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00062_A337SupplierGenAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactName");
                  GXUtil.WriteLogRaw("Old: ",Z47SupplierGenContactName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A47SupplierGenContactName[0]);
               }
               if ( StringUtil.StrCmp(Z382SupplierGenPhoneNumber, T00062_A382SupplierGenPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z382SupplierGenPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A382SupplierGenPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z441SupplierGenWebsite, T00062_A441SupplierGenWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z441SupplierGenWebsite);
                  GXUtil.WriteLogRaw("Current: ",T00062_A441SupplierGenWebsite[0]);
               }
               if ( Z282SupplierGenTypeId != T00062_A282SupplierGenTypeId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z282SupplierGenTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A282SupplierGenTypeId[0]);
               }
               if ( Z11OrganisationId != T00062_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
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
                     /* Using cursor T000612 */
                     pr_default.execute(10, new Object[] {n42SupplierGenId, A42SupplierGenId, A335SupplierGenAddressCountry, A381SupplierGenPhoneCode, A48SupplierGenContactPhone, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A382SupplierGenPhoneNumber, A441SupplierGenWebsite, A282SupplierGenTypeId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
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
                     /* Using cursor T000613 */
                     pr_default.execute(11, new Object[] {A335SupplierGenAddressCountry, A381SupplierGenPhoneCode, A48SupplierGenContactPhone, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A382SupplierGenPhoneNumber, A441SupplierGenWebsite, A282SupplierGenTypeId, n11OrganisationId, A11OrganisationId, n42SupplierGenId, A42SupplierGenId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(11) == 103) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
         if ( ! IsAuthorized("trn_suppliergen_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
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
                  /* Using cursor T000614 */
                  pr_default.execute(12, new Object[] {n42SupplierGenId, A42SupplierGenId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     new prc_deletepreferredgensupplierrecord(context ).execute(  A42SupplierGenId,  A11OrganisationId) ;
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
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
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {A282SupplierGenTypeId});
            A290SupplierGenTypeName = T000615_A290SupplierGenTypeName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ProductService", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
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
            context.CommitDataStores("trn_suppliergen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_suppliergen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000617 */
         pr_default.execute(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000617_A42SupplierGenId[0];
            n42SupplierGenId = T000617_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000617_A42SupplierGenId[0];
            n42SupplierGenId = T000617_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(15);
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
         edtSupplierGenKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenKvkNumber_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp("", false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierGenTypeId_Enabled = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         edtSupplierGenContactName_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactName_Enabled), 5, 0), true);
         edtSupplierGenPhoneCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneCode_Enabled), 5, 0), true);
         edtSupplierGenPhoneNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenPhoneNumber_Enabled), 5, 0), true);
         edtSupplierGenWebsite_Enabled = 0;
         AssignProp("", false, edtSupplierGenWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenWebsite_Enabled), 5, 0), true);
         edtSupplierGenAddressLine1_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine1_Enabled), 5, 0), true);
         edtSupplierGenAddressLine2_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine2_Enabled), 5, 0), true);
         edtSupplierGenAddressZipCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressZipCode_Enabled), 5, 0), true);
         edtSupplierGenAddressCity_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCity_Enabled), 5, 0), true);
         edtSupplierGenAddressCountry_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Enabled), 5, 0), true);
         edtavCombosuppliergentypeid_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         edtavCombosuppliergenphonecode_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenphonecode_Enabled), 5, 0), true);
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         edtSupplierGenContactPhone_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_suppliergen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z335SupplierGenAddressCountry", Z335SupplierGenAddressCountry);
         GxWebStd.gx_hidden_field( context, "Z381SupplierGenPhoneCode", Z381SupplierGenPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z48SupplierGenContactPhone", StringUtil.RTrim( Z48SupplierGenContactPhone));
         GxWebStd.gx_hidden_field( context, "Z43SupplierGenKvkNumber", Z43SupplierGenKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z44SupplierGenCompanyName", Z44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "Z295SupplierGenAddressCity", Z295SupplierGenAddressCity);
         GxWebStd.gx_hidden_field( context, "Z294SupplierGenAddressZipCode", Z294SupplierGenAddressZipCode);
         GxWebStd.gx_hidden_field( context, "Z336SupplierGenAddressLine1", Z336SupplierGenAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z337SupplierGenAddressLine2", Z337SupplierGenAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z47SupplierGenContactName", Z47SupplierGenContactName);
         GxWebStd.gx_hidden_field( context, "Z382SupplierGenPhoneNumber", Z382SupplierGenPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z441SupplierGenWebsite", Z441SupplierGenWebsite);
         GxWebStd.gx_hidden_field( context, "Z282SupplierGenTypeId", Z282SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENPHONECODE_DATA", AV27SupplierGenPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENPHONECODE_DATA", AV27SupplierGenPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENID", AV7SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERGENTYPEID", AV13Insert_SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV28Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV30OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENTYPENAME", A290SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Objectcall", StringUtil.RTrim( Combo_suppliergentypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Cls", StringUtil.RTrim( Combo_suppliergentypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergentypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_suppliergentypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Includeaddnewoption", StringUtil.BoolToStr( Combo_suppliergentypeid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Objectcall", StringUtil.RTrim( Combo_suppliergenphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Cls", StringUtil.RTrim( Combo_suppliergenphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Enabled", StringUtil.BoolToStr( Combo_suppliergenphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_suppliergenphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall", StringUtil.RTrim( Combo_suppliergenaddresscountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_suppliergenaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_suppliergenaddresscountry_Htmltemplate));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         return formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierGen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "General Suppliers", "") ;
      }

      protected void InitializeNonKey069( )
      {
         A282SupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A335SupplierGenAddressCountry = "";
         AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
         A381SupplierGenPhoneCode = "";
         AssignAttri("", false, "A381SupplierGenPhoneCode", A381SupplierGenPhoneCode);
         A48SupplierGenContactPhone = "";
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         A43SupplierGenKvkNumber = "";
         AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
         A290SupplierGenTypeName = "";
         AssignAttri("", false, "A290SupplierGenTypeName", A290SupplierGenTypeName);
         A44SupplierGenCompanyName = "";
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
         A295SupplierGenAddressCity = "";
         AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
         A294SupplierGenAddressZipCode = "";
         AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
         A336SupplierGenAddressLine1 = "";
         AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
         A337SupplierGenAddressLine2 = "";
         AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
         A47SupplierGenContactName = "";
         AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
         A382SupplierGenPhoneNumber = "";
         AssignAttri("", false, "A382SupplierGenPhoneNumber", A382SupplierGenPhoneNumber);
         A441SupplierGenWebsite = "";
         AssignAttri("", false, "A441SupplierGenWebsite", A441SupplierGenWebsite);
         Z335SupplierGenAddressCountry = "";
         Z381SupplierGenPhoneCode = "";
         Z48SupplierGenContactPhone = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z382SupplierGenPhoneNumber = "";
         Z441SupplierGenWebsite = "";
         Z282SupplierGenTypeId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll069( )
      {
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A11OrganisationId = i11OrganisationId;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112914283867", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_suppliergen.js", "?2024112914283870", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         lblTextblocksuppliergentypeid_Internalname = "TEXTBLOCKSUPPLIERGENTYPEID";
         Combo_suppliergentypeid_Internalname = "COMBO_SUPPLIERGENTYPEID";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
         divTablesplittedsuppliergentypeid_Internalname = "TABLESPLITTEDSUPPLIERGENTYPEID";
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME";
         lblTextblocksuppliergenphonecode_Internalname = "TEXTBLOCKSUPPLIERGENPHONECODE";
         Combo_suppliergenphonecode_Internalname = "COMBO_SUPPLIERGENPHONECODE";
         edtSupplierGenPhoneCode_Internalname = "SUPPLIERGENPHONECODE";
         edtSupplierGenPhoneNumber_Internalname = "SUPPLIERGENPHONENUMBER";
         tblTablemergedsuppliergenphonecode_Internalname = "TABLEMERGEDSUPPLIERGENPHONECODE";
         divTablesplittedsuppliergenphonecode_Internalname = "TABLESPLITTEDSUPPLIERGENPHONECODE";
         edtSupplierGenWebsite_Internalname = "SUPPLIERGENWEBSITE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2";
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY";
         lblTextblocksuppliergenaddresscountry_Internalname = "TEXTBLOCKSUPPLIERGENADDRESSCOUNTRY";
         Combo_suppliergenaddresscountry_Internalname = "COMBO_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY";
         divTablesplittedsuppliergenaddresscountry_Internalname = "TABLESPLITTEDSUPPLIERGENADDRESSCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosuppliergentypeid_Internalname = "vCOMBOSUPPLIERGENTYPEID";
         divSectionattribute_suppliergentypeid_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENTYPEID";
         edtavCombosuppliergenphonecode_Internalname = "vCOMBOSUPPLIERGENPHONECODE";
         divSectionattribute_suppliergenphonecode_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENPHONECODE";
         edtavCombosuppliergenaddresscountry_Internalname = "vCOMBOSUPPLIERGENADDRESSCOUNTRY";
         divSectionattribute_suppliergenaddresscountry_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "General Suppliers", "");
         Combo_suppliergenphonecode_Htmltemplate = "";
         Combo_suppliergenaddresscountry_Htmltemplate = "";
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactPhone_Enabled = 1;
         edtSupplierGenContactPhone_Visible = 1;
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierGenId_Visible = 1;
         edtavCombosuppliergenaddresscountry_Jsonclick = "";
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         edtavCombosuppliergenaddresscountry_Visible = 1;
         edtavCombosuppliergenphonecode_Jsonclick = "";
         edtavCombosuppliergenphonecode_Enabled = 0;
         edtavCombosuppliergenphonecode_Visible = 1;
         edtavCombosuppliergentypeid_Jsonclick = "";
         edtavCombosuppliergentypeid_Enabled = 0;
         edtavCombosuppliergentypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSupplierGenAddressCountry_Jsonclick = "";
         edtSupplierGenAddressCountry_Enabled = 1;
         edtSupplierGenAddressCountry_Visible = 1;
         Combo_suppliergenaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_suppliergenaddresscountry_Caption = "";
         Combo_suppliergenaddresscountry_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCity_Enabled = 1;
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressZipCode_Enabled = 1;
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine2_Enabled = 1;
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressLine1_Enabled = 1;
         edtSupplierGenWebsite_Jsonclick = "";
         edtSupplierGenWebsite_Enabled = 1;
         edtSupplierGenPhoneNumber_Jsonclick = "";
         edtSupplierGenPhoneNumber_Enabled = 1;
         edtSupplierGenPhoneCode_Jsonclick = "";
         edtSupplierGenPhoneCode_Enabled = 1;
         edtSupplierGenPhoneCode_Visible = 1;
         Combo_suppliergenphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_suppliergenphonecode_Caption = "";
         Combo_suppliergenphonecode_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenContactName_Enabled = 1;
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenTypeId_Enabled = 1;
         edtSupplierGenTypeId_Visible = 1;
         Combo_suppliergentypeid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_suppliergentypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergentypeid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergentypeid_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Enabled = 1;
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtSupplierGenKvkNumber_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX14ASASUPPLIERGENCONTACTPHONE069( string A381SupplierGenPhoneCode ,
                                                        string A382SupplierGenPhoneNumber )
      {
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A48SupplierGenContactPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_27_069( Guid A42SupplierGenId ,
                                Guid A11OrganisationId )
      {
         new prc_deletepreferredgensupplierrecord(context ).execute(  A42SupplierGenId,  A11OrganisationId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Suppliergentypeid( )
      {
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGenType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
         }
         A290SupplierGenTypeName = T000615_A290SupplierGenTypeName[0];
         pr_default.close(13);
         if ( (Guid.Empty==A282SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Id", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A290SupplierGenTypeName", A290SupplierGenTypeName);
      }

      public void Valid_Suppliergenphonenumber( )
      {
         if ( ! ( GxRegex.IsMatch(A382SupplierGenPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone contains 9 digits", ""), context.GetMessage( "Supplier Gen Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
         }
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A381SupplierGenPhoneCode,  A382SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         if ( StringUtil.Len( A382SupplierGenPhoneNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "SUPPLIERGENPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A48SupplierGenContactPhone", StringUtil.RTrim( A48SupplierGenContactPhone));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13062","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED","""{"handler":"E12062","iparms":[{"av":"Combo_suppliergentypeid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedValue_get"},{"av":"Combo_suppliergentypeid_Selectedtext_get","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedText_get"},{"av":"A282SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_suppliergentypeid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedValue_set"},{"av":"AV15SupplierGenTypeId_Data","fld":"vSUPPLIERGENTYPEID_DATA"},{"av":"AV20ComboSupplierGenTypeId","fld":"vCOMBOSUPPLIERGENTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERGENKVKNUMBER","""{"handler":"Valid_Suppliergenkvknumber","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENCOMPANYNAME","""{"handler":"Valid_Suppliergencompanyname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[{"av":"A282SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"},{"av":"A290SupplierGenTypeName","fld":"SUPPLIERGENTYPENAME"}]""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID",""","oparms":[{"av":"A290SupplierGenTypeName","fld":"SUPPLIERGENTYPENAME"}]}""");
         setEventMetadata("VALID_SUPPLIERGENPHONECODE","""{"handler":"Valid_Suppliergenphonecode","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENPHONENUMBER","""{"handler":"Valid_Suppliergenphonenumber","iparms":[{"av":"A382SupplierGenPhoneNumber","fld":"SUPPLIERGENPHONENUMBER"},{"av":"A381SupplierGenPhoneCode","fld":"SUPPLIERGENPHONECODE"},{"av":"A48SupplierGenContactPhone","fld":"SUPPLIERGENCONTACTPHONE"}]""");
         setEventMetadata("VALID_SUPPLIERGENPHONENUMBER",""","oparms":[{"av":"A48SupplierGenContactPhone","fld":"SUPPLIERGENCONTACTPHONE"}]}""");
         setEventMetadata("VALID_SUPPLIERGENWEBSITE","""{"handler":"Valid_Suppliergenwebsite","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSLINE1","""{"handler":"Valid_Suppliergenaddressline1","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSZIPCODE","""{"handler":"Valid_Suppliergenaddresszipcode","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSCITY","""{"handler":"Valid_Suppliergenaddresscity","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENADDRESSCOUNTRY","""{"handler":"Valid_Suppliergenaddresscountry","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENTYPEID","""{"handler":"Validv_Combosuppliergentypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENPHONECODE","""{"handler":"Validv_Combosuppliergenphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENADDRESSCOUNTRY","""{"handler":"Validv_Combosuppliergenaddresscountry","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
         return  ;
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7SupplierGenId = Guid.Empty;
         Z42SupplierGenId = Guid.Empty;
         Z335SupplierGenAddressCountry = "";
         Z381SupplierGenPhoneCode = "";
         Z48SupplierGenContactPhone = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z382SupplierGenPhoneNumber = "";
         Z441SupplierGenWebsite = "";
         Z282SupplierGenTypeId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         N282SupplierGenTypeId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         Combo_suppliergenaddresscountry_Selectedvalue_get = "";
         Combo_suppliergenphonecode_Selectedvalue_get = "";
         Combo_suppliergentypeid_Selectedvalue_get = "";
         Combo_suppliergentypeid_Selectedtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A42SupplierGenId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A381SupplierGenPhoneCode = "";
         A382SupplierGenPhoneNumber = "";
         A282SupplierGenTypeId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A43SupplierGenKvkNumber = "";
         A44SupplierGenCompanyName = "";
         lblTextblocksuppliergentypeid_Jsonclick = "";
         ucCombo_suppliergentypeid = new GXUserControl();
         Combo_suppliergentypeid_Caption = "";
         AV15SupplierGenTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A47SupplierGenContactName = "";
         lblTextblocksuppliergenphonecode_Jsonclick = "";
         sStyleString = "";
         ucCombo_suppliergenphonecode = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27SupplierGenPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A441SupplierGenWebsite = "";
         A336SupplierGenAddressLine1 = "";
         A337SupplierGenAddressLine2 = "";
         A294SupplierGenAddressZipCode = "";
         A295SupplierGenAddressCity = "";
         lblTextblocksuppliergenaddresscountry_Jsonclick = "";
         ucCombo_suppliergenaddresscountry = new GXUserControl();
         AV23SupplierGenAddressCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A335SupplierGenAddressCountry = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AV25ComboSupplierGenPhoneCode = "";
         AV24ComboSupplierGenAddressCountry = "";
         gxphoneLink = "";
         A48SupplierGenContactPhone = "";
         AV13Insert_SupplierGenTypeId = Guid.Empty;
         AV28Insert_OrganisationId = Guid.Empty;
         AV30OrganisationId = Guid.Empty;
         A290SupplierGenTypeName = "";
         AV32Pgmname = "";
         Combo_suppliergentypeid_Objectcall = "";
         Combo_suppliergentypeid_Class = "";
         Combo_suppliergentypeid_Icontype = "";
         Combo_suppliergentypeid_Icon = "";
         Combo_suppliergentypeid_Tooltip = "";
         Combo_suppliergentypeid_Selectedvalue_set = "";
         Combo_suppliergentypeid_Selectedtext_set = "";
         Combo_suppliergentypeid_Gamoauthtoken = "";
         Combo_suppliergentypeid_Ddointernalname = "";
         Combo_suppliergentypeid_Titlecontrolalign = "";
         Combo_suppliergentypeid_Dropdownoptionstype = "";
         Combo_suppliergentypeid_Titlecontrolidtoreplace = "";
         Combo_suppliergentypeid_Datalisttype = "";
         Combo_suppliergentypeid_Datalistfixedvalues = "";
         Combo_suppliergentypeid_Datalistproc = "";
         Combo_suppliergentypeid_Datalistprocparametersprefix = "";
         Combo_suppliergentypeid_Remoteservicesparameters = "";
         Combo_suppliergentypeid_Htmltemplate = "";
         Combo_suppliergentypeid_Multiplevaluestype = "";
         Combo_suppliergentypeid_Loadingdata = "";
         Combo_suppliergentypeid_Noresultsfound = "";
         Combo_suppliergentypeid_Emptyitemtext = "";
         Combo_suppliergentypeid_Onlyselectedvalues = "";
         Combo_suppliergentypeid_Selectalltext = "";
         Combo_suppliergentypeid_Multiplevaluesseparator = "";
         Combo_suppliergentypeid_Addnewoptiontext = "";
         Combo_suppliergenphonecode_Objectcall = "";
         Combo_suppliergenphonecode_Class = "";
         Combo_suppliergenphonecode_Icontype = "";
         Combo_suppliergenphonecode_Icon = "";
         Combo_suppliergenphonecode_Tooltip = "";
         Combo_suppliergenphonecode_Selectedvalue_set = "";
         Combo_suppliergenphonecode_Selectedtext_set = "";
         Combo_suppliergenphonecode_Selectedtext_get = "";
         Combo_suppliergenphonecode_Gamoauthtoken = "";
         Combo_suppliergenphonecode_Ddointernalname = "";
         Combo_suppliergenphonecode_Titlecontrolalign = "";
         Combo_suppliergenphonecode_Dropdownoptionstype = "";
         Combo_suppliergenphonecode_Titlecontrolidtoreplace = "";
         Combo_suppliergenphonecode_Datalisttype = "";
         Combo_suppliergenphonecode_Datalistfixedvalues = "";
         Combo_suppliergenphonecode_Datalistproc = "";
         Combo_suppliergenphonecode_Datalistprocparametersprefix = "";
         Combo_suppliergenphonecode_Remoteservicesparameters = "";
         Combo_suppliergenphonecode_Multiplevaluestype = "";
         Combo_suppliergenphonecode_Loadingdata = "";
         Combo_suppliergenphonecode_Noresultsfound = "";
         Combo_suppliergenphonecode_Emptyitemtext = "";
         Combo_suppliergenphonecode_Onlyselectedvalues = "";
         Combo_suppliergenphonecode_Selectalltext = "";
         Combo_suppliergenphonecode_Multiplevaluesseparator = "";
         Combo_suppliergenphonecode_Addnewoptiontext = "";
         Combo_suppliergenaddresscountry_Objectcall = "";
         Combo_suppliergenaddresscountry_Class = "";
         Combo_suppliergenaddresscountry_Icontype = "";
         Combo_suppliergenaddresscountry_Icon = "";
         Combo_suppliergenaddresscountry_Tooltip = "";
         Combo_suppliergenaddresscountry_Selectedvalue_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_get = "";
         Combo_suppliergenaddresscountry_Gamoauthtoken = "";
         Combo_suppliergenaddresscountry_Ddointernalname = "";
         Combo_suppliergenaddresscountry_Titlecontrolalign = "";
         Combo_suppliergenaddresscountry_Dropdownoptionstype = "";
         Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = "";
         Combo_suppliergenaddresscountry_Datalisttype = "";
         Combo_suppliergenaddresscountry_Datalistfixedvalues = "";
         Combo_suppliergenaddresscountry_Datalistproc = "";
         Combo_suppliergenaddresscountry_Datalistprocparametersprefix = "";
         Combo_suppliergenaddresscountry_Remoteservicesparameters = "";
         Combo_suppliergenaddresscountry_Multiplevaluestype = "";
         Combo_suppliergenaddresscountry_Loadingdata = "";
         Combo_suppliergenaddresscountry_Noresultsfound = "";
         Combo_suppliergenaddresscountry_Emptyitemtext = "";
         Combo_suppliergenaddresscountry_Onlyselectedvalues = "";
         Combo_suppliergenaddresscountry_Selectalltext = "";
         Combo_suppliergenaddresscountry_Multiplevaluesseparator = "";
         Combo_suppliergenaddresscountry_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV26defaultCountryPhoneCode = "";
         GXt_guid3 = Guid.Empty;
         AV31DefaultSupplierGenTypeName = "";
         GXEncryptionTmp = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z290SupplierGenTypeName = "";
         T00064_A290SupplierGenTypeName = new string[] {""} ;
         T00066_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00066_n42SupplierGenId = new bool[] {false} ;
         T00066_A335SupplierGenAddressCountry = new string[] {""} ;
         T00066_A381SupplierGenPhoneCode = new string[] {""} ;
         T00066_A48SupplierGenContactPhone = new string[] {""} ;
         T00066_A43SupplierGenKvkNumber = new string[] {""} ;
         T00066_A290SupplierGenTypeName = new string[] {""} ;
         T00066_A44SupplierGenCompanyName = new string[] {""} ;
         T00066_A295SupplierGenAddressCity = new string[] {""} ;
         T00066_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00066_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00066_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00066_A47SupplierGenContactName = new string[] {""} ;
         T00066_A382SupplierGenPhoneNumber = new string[] {""} ;
         T00066_A441SupplierGenWebsite = new string[] {""} ;
         T00066_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00066_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00066_n11OrganisationId = new bool[] {false} ;
         T00065_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00065_n11OrganisationId = new bool[] {false} ;
         T00067_A290SupplierGenTypeName = new string[] {""} ;
         T00068_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00068_n11OrganisationId = new bool[] {false} ;
         T00069_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00069_n42SupplierGenId = new bool[] {false} ;
         T00063_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00063_n42SupplierGenId = new bool[] {false} ;
         T00063_A335SupplierGenAddressCountry = new string[] {""} ;
         T00063_A381SupplierGenPhoneCode = new string[] {""} ;
         T00063_A48SupplierGenContactPhone = new string[] {""} ;
         T00063_A43SupplierGenKvkNumber = new string[] {""} ;
         T00063_A44SupplierGenCompanyName = new string[] {""} ;
         T00063_A295SupplierGenAddressCity = new string[] {""} ;
         T00063_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00063_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00063_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00063_A47SupplierGenContactName = new string[] {""} ;
         T00063_A382SupplierGenPhoneNumber = new string[] {""} ;
         T00063_A441SupplierGenWebsite = new string[] {""} ;
         T00063_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00063_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00063_n11OrganisationId = new bool[] {false} ;
         T000610_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000610_n42SupplierGenId = new bool[] {false} ;
         T000611_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000611_n42SupplierGenId = new bool[] {false} ;
         T00062_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00062_n42SupplierGenId = new bool[] {false} ;
         T00062_A335SupplierGenAddressCountry = new string[] {""} ;
         T00062_A381SupplierGenPhoneCode = new string[] {""} ;
         T00062_A48SupplierGenContactPhone = new string[] {""} ;
         T00062_A43SupplierGenKvkNumber = new string[] {""} ;
         T00062_A44SupplierGenCompanyName = new string[] {""} ;
         T00062_A295SupplierGenAddressCity = new string[] {""} ;
         T00062_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00062_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00062_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00062_A47SupplierGenContactName = new string[] {""} ;
         T00062_A382SupplierGenPhoneNumber = new string[] {""} ;
         T00062_A441SupplierGenWebsite = new string[] {""} ;
         T00062_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00062_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00062_n11OrganisationId = new bool[] {false} ;
         T000615_A290SupplierGenTypeName = new string[] {""} ;
         T000616_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000616_A29LocationId = new Guid[] {Guid.Empty} ;
         T000616_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000616_n11OrganisationId = new bool[] {false} ;
         T000617_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000617_n42SupplierGenId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i11OrganisationId = Guid.Empty;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__default(),
            new Object[][] {
                new Object[] {
               T00062_A42SupplierGenId, T00062_A335SupplierGenAddressCountry, T00062_A381SupplierGenPhoneCode, T00062_A48SupplierGenContactPhone, T00062_A43SupplierGenKvkNumber, T00062_A44SupplierGenCompanyName, T00062_A295SupplierGenAddressCity, T00062_A294SupplierGenAddressZipCode, T00062_A336SupplierGenAddressLine1, T00062_A337SupplierGenAddressLine2,
               T00062_A47SupplierGenContactName, T00062_A382SupplierGenPhoneNumber, T00062_A441SupplierGenWebsite, T00062_A282SupplierGenTypeId, T00062_A11OrganisationId, T00062_n11OrganisationId
               }
               , new Object[] {
               T00063_A42SupplierGenId, T00063_A335SupplierGenAddressCountry, T00063_A381SupplierGenPhoneCode, T00063_A48SupplierGenContactPhone, T00063_A43SupplierGenKvkNumber, T00063_A44SupplierGenCompanyName, T00063_A295SupplierGenAddressCity, T00063_A294SupplierGenAddressZipCode, T00063_A336SupplierGenAddressLine1, T00063_A337SupplierGenAddressLine2,
               T00063_A47SupplierGenContactName, T00063_A382SupplierGenPhoneNumber, T00063_A441SupplierGenWebsite, T00063_A282SupplierGenTypeId, T00063_A11OrganisationId, T00063_n11OrganisationId
               }
               , new Object[] {
               T00064_A290SupplierGenTypeName
               }
               , new Object[] {
               T00065_A11OrganisationId
               }
               , new Object[] {
               T00066_A42SupplierGenId, T00066_A335SupplierGenAddressCountry, T00066_A381SupplierGenPhoneCode, T00066_A48SupplierGenContactPhone, T00066_A43SupplierGenKvkNumber, T00066_A290SupplierGenTypeName, T00066_A44SupplierGenCompanyName, T00066_A295SupplierGenAddressCity, T00066_A294SupplierGenAddressZipCode, T00066_A336SupplierGenAddressLine1,
               T00066_A337SupplierGenAddressLine2, T00066_A47SupplierGenContactName, T00066_A382SupplierGenPhoneNumber, T00066_A441SupplierGenWebsite, T00066_A282SupplierGenTypeId, T00066_A11OrganisationId, T00066_n11OrganisationId
               }
               , new Object[] {
               T00067_A290SupplierGenTypeName
               }
               , new Object[] {
               T00068_A11OrganisationId
               }
               , new Object[] {
               T00069_A42SupplierGenId
               }
               , new Object[] {
               T000610_A42SupplierGenId
               }
               , new Object[] {
               T000611_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000615_A290SupplierGenTypeName
               }
               , new Object[] {
               T000616_A58ProductServiceId, T000616_A29LocationId, T000616_A11OrganisationId
               }
               , new Object[] {
               T000617_A42SupplierGenId
               }
            }
         );
         Z42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AV32Pgmname = "Trn_SupplierGen";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenTypeId_Visible ;
      private int edtSupplierGenTypeId_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int edtSupplierGenPhoneCode_Visible ;
      private int edtSupplierGenPhoneCode_Enabled ;
      private int edtSupplierGenPhoneNumber_Enabled ;
      private int edtSupplierGenWebsite_Enabled ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenAddressCountry_Visible ;
      private int edtSupplierGenAddressCountry_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosuppliergentypeid_Visible ;
      private int edtavCombosuppliergentypeid_Enabled ;
      private int edtavCombosuppliergenphonecode_Visible ;
      private int edtavCombosuppliergenphonecode_Enabled ;
      private int edtavCombosuppliergenaddresscountry_Visible ;
      private int edtavCombosuppliergenaddresscountry_Enabled ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int edtSupplierGenContactPhone_Visible ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int Combo_suppliergentypeid_Datalistupdateminimumcharacters ;
      private int Combo_suppliergentypeid_Gxcontroltype ;
      private int Combo_suppliergenphonecode_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenphonecode_Gxcontroltype ;
      private int Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenaddresscountry_Gxcontroltype ;
      private int AV33GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z48SupplierGenContactPhone ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_get ;
      private string Combo_suppliergenphonecode_Selectedvalue_get ;
      private string Combo_suppliergentypeid_Selectedvalue_get ;
      private string Combo_suppliergentypeid_Selectedtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierGenKvkNumber_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string divTablesplittedsuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Jsonclick ;
      private string Combo_suppliergentypeid_Caption ;
      private string Combo_suppliergentypeid_Cls ;
      private string Combo_suppliergentypeid_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string edtSupplierGenContactName_Internalname ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string divTablesplittedsuppliergenphonecode_Internalname ;
      private string lblTextblocksuppliergenphonecode_Internalname ;
      private string lblTextblocksuppliergenphonecode_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedsuppliergenphonecode_Internalname ;
      private string Combo_suppliergenphonecode_Caption ;
      private string Combo_suppliergenphonecode_Cls ;
      private string Combo_suppliergenphonecode_Internalname ;
      private string edtSupplierGenPhoneCode_Internalname ;
      private string edtSupplierGenPhoneCode_Jsonclick ;
      private string edtSupplierGenPhoneNumber_Internalname ;
      private string edtSupplierGenPhoneNumber_Jsonclick ;
      private string edtSupplierGenWebsite_Internalname ;
      private string edtSupplierGenWebsite_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string divTablesplittedsuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Jsonclick ;
      private string Combo_suppliergenaddresscountry_Caption ;
      private string Combo_suppliergenaddresscountry_Cls ;
      private string Combo_suppliergenaddresscountry_Internalname ;
      private string edtSupplierGenAddressCountry_Internalname ;
      private string edtSupplierGenAddressCountry_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_suppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Jsonclick ;
      private string divSectionattribute_suppliergenphonecode_Internalname ;
      private string edtavCombosuppliergenphonecode_Internalname ;
      private string edtavCombosuppliergenphonecode_Jsonclick ;
      private string divSectionattribute_suppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Jsonclick ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string gxphoneLink ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string AV32Pgmname ;
      private string Combo_suppliergentypeid_Objectcall ;
      private string Combo_suppliergentypeid_Class ;
      private string Combo_suppliergentypeid_Icontype ;
      private string Combo_suppliergentypeid_Icon ;
      private string Combo_suppliergentypeid_Tooltip ;
      private string Combo_suppliergentypeid_Selectedvalue_set ;
      private string Combo_suppliergentypeid_Selectedtext_set ;
      private string Combo_suppliergentypeid_Gamoauthtoken ;
      private string Combo_suppliergentypeid_Ddointernalname ;
      private string Combo_suppliergentypeid_Titlecontrolalign ;
      private string Combo_suppliergentypeid_Dropdownoptionstype ;
      private string Combo_suppliergentypeid_Titlecontrolidtoreplace ;
      private string Combo_suppliergentypeid_Datalisttype ;
      private string Combo_suppliergentypeid_Datalistfixedvalues ;
      private string Combo_suppliergentypeid_Datalistproc ;
      private string Combo_suppliergentypeid_Datalistprocparametersprefix ;
      private string Combo_suppliergentypeid_Remoteservicesparameters ;
      private string Combo_suppliergentypeid_Htmltemplate ;
      private string Combo_suppliergentypeid_Multiplevaluestype ;
      private string Combo_suppliergentypeid_Loadingdata ;
      private string Combo_suppliergentypeid_Noresultsfound ;
      private string Combo_suppliergentypeid_Emptyitemtext ;
      private string Combo_suppliergentypeid_Onlyselectedvalues ;
      private string Combo_suppliergentypeid_Selectalltext ;
      private string Combo_suppliergentypeid_Multiplevaluesseparator ;
      private string Combo_suppliergentypeid_Addnewoptiontext ;
      private string Combo_suppliergenphonecode_Objectcall ;
      private string Combo_suppliergenphonecode_Class ;
      private string Combo_suppliergenphonecode_Icontype ;
      private string Combo_suppliergenphonecode_Icon ;
      private string Combo_suppliergenphonecode_Tooltip ;
      private string Combo_suppliergenphonecode_Selectedvalue_set ;
      private string Combo_suppliergenphonecode_Selectedtext_set ;
      private string Combo_suppliergenphonecode_Selectedtext_get ;
      private string Combo_suppliergenphonecode_Gamoauthtoken ;
      private string Combo_suppliergenphonecode_Ddointernalname ;
      private string Combo_suppliergenphonecode_Titlecontrolalign ;
      private string Combo_suppliergenphonecode_Dropdownoptionstype ;
      private string Combo_suppliergenphonecode_Titlecontrolidtoreplace ;
      private string Combo_suppliergenphonecode_Datalisttype ;
      private string Combo_suppliergenphonecode_Datalistfixedvalues ;
      private string Combo_suppliergenphonecode_Datalistproc ;
      private string Combo_suppliergenphonecode_Datalistprocparametersprefix ;
      private string Combo_suppliergenphonecode_Remoteservicesparameters ;
      private string Combo_suppliergenphonecode_Htmltemplate ;
      private string Combo_suppliergenphonecode_Multiplevaluestype ;
      private string Combo_suppliergenphonecode_Loadingdata ;
      private string Combo_suppliergenphonecode_Noresultsfound ;
      private string Combo_suppliergenphonecode_Emptyitemtext ;
      private string Combo_suppliergenphonecode_Onlyselectedvalues ;
      private string Combo_suppliergenphonecode_Selectalltext ;
      private string Combo_suppliergenphonecode_Multiplevaluesseparator ;
      private string Combo_suppliergenphonecode_Addnewoptiontext ;
      private string Combo_suppliergenaddresscountry_Objectcall ;
      private string Combo_suppliergenaddresscountry_Class ;
      private string Combo_suppliergenaddresscountry_Icontype ;
      private string Combo_suppliergenaddresscountry_Icon ;
      private string Combo_suppliergenaddresscountry_Tooltip ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_get ;
      private string Combo_suppliergenaddresscountry_Gamoauthtoken ;
      private string Combo_suppliergenaddresscountry_Ddointernalname ;
      private string Combo_suppliergenaddresscountry_Titlecontrolalign ;
      private string Combo_suppliergenaddresscountry_Dropdownoptionstype ;
      private string Combo_suppliergenaddresscountry_Titlecontrolidtoreplace ;
      private string Combo_suppliergenaddresscountry_Datalisttype ;
      private string Combo_suppliergenaddresscountry_Datalistfixedvalues ;
      private string Combo_suppliergenaddresscountry_Datalistproc ;
      private string Combo_suppliergenaddresscountry_Datalistprocparametersprefix ;
      private string Combo_suppliergenaddresscountry_Remoteservicesparameters ;
      private string Combo_suppliergenaddresscountry_Htmltemplate ;
      private string Combo_suppliergenaddresscountry_Multiplevaluestype ;
      private string Combo_suppliergenaddresscountry_Loadingdata ;
      private string Combo_suppliergenaddresscountry_Noresultsfound ;
      private string Combo_suppliergenaddresscountry_Emptyitemtext ;
      private string Combo_suppliergenaddresscountry_Onlyselectedvalues ;
      private string Combo_suppliergenaddresscountry_Selectalltext ;
      private string Combo_suppliergenaddresscountry_Multiplevaluesseparator ;
      private string Combo_suppliergenaddresscountry_Addnewoptiontext ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n42SupplierGenId ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool Combo_suppliergentypeid_Emptyitem ;
      private bool Combo_suppliergentypeid_Includeaddnewoption ;
      private bool Combo_suppliergenphonecode_Emptyitem ;
      private bool Combo_suppliergenaddresscountry_Emptyitem ;
      private bool Combo_suppliergentypeid_Enabled ;
      private bool Combo_suppliergentypeid_Visible ;
      private bool Combo_suppliergentypeid_Allowmultipleselection ;
      private bool Combo_suppliergentypeid_Isgriditem ;
      private bool Combo_suppliergentypeid_Hasdescription ;
      private bool Combo_suppliergentypeid_Includeonlyselectedoption ;
      private bool Combo_suppliergentypeid_Includeselectalloption ;
      private bool Combo_suppliergenphonecode_Enabled ;
      private bool Combo_suppliergenphonecode_Visible ;
      private bool Combo_suppliergenphonecode_Allowmultipleselection ;
      private bool Combo_suppliergenphonecode_Isgriditem ;
      private bool Combo_suppliergenphonecode_Hasdescription ;
      private bool Combo_suppliergenphonecode_Includeonlyselectedoption ;
      private bool Combo_suppliergenphonecode_Includeselectalloption ;
      private bool Combo_suppliergenphonecode_Includeaddnewoption ;
      private bool Combo_suppliergenaddresscountry_Enabled ;
      private bool Combo_suppliergenaddresscountry_Visible ;
      private bool Combo_suppliergenaddresscountry_Allowmultipleselection ;
      private bool Combo_suppliergenaddresscountry_Isgriditem ;
      private bool Combo_suppliergenaddresscountry_Hasdescription ;
      private bool Combo_suppliergenaddresscountry_Includeonlyselectedoption ;
      private bool Combo_suppliergenaddresscountry_Includeselectalloption ;
      private bool Combo_suppliergenaddresscountry_Includeaddnewoption ;
      private bool returnInSub ;
      private bool GXt_boolean5 ;
      private bool Gx_longc ;
      private string Z335SupplierGenAddressCountry ;
      private string Z381SupplierGenPhoneCode ;
      private string Z43SupplierGenKvkNumber ;
      private string Z44SupplierGenCompanyName ;
      private string Z295SupplierGenAddressCity ;
      private string Z294SupplierGenAddressZipCode ;
      private string Z336SupplierGenAddressLine1 ;
      private string Z337SupplierGenAddressLine2 ;
      private string Z47SupplierGenContactName ;
      private string Z382SupplierGenPhoneNumber ;
      private string Z441SupplierGenWebsite ;
      private string A381SupplierGenPhoneCode ;
      private string A382SupplierGenPhoneNumber ;
      private string A43SupplierGenKvkNumber ;
      private string A44SupplierGenCompanyName ;
      private string A47SupplierGenContactName ;
      private string A441SupplierGenWebsite ;
      private string A336SupplierGenAddressLine1 ;
      private string A337SupplierGenAddressLine2 ;
      private string A294SupplierGenAddressZipCode ;
      private string A295SupplierGenAddressCity ;
      private string A335SupplierGenAddressCountry ;
      private string AV25ComboSupplierGenPhoneCode ;
      private string AV24ComboSupplierGenAddressCountry ;
      private string A290SupplierGenTypeName ;
      private string AV26defaultCountryPhoneCode ;
      private string AV31DefaultSupplierGenTypeName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z290SupplierGenTypeName ;
      private Guid wcpOAV7SupplierGenId ;
      private Guid Z42SupplierGenId ;
      private Guid Z282SupplierGenTypeId ;
      private Guid Z11OrganisationId ;
      private Guid N282SupplierGenTypeId ;
      private Guid N11OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A11OrganisationId ;
      private Guid A282SupplierGenTypeId ;
      private Guid AV7SupplierGenId ;
      private Guid AV20ComboSupplierGenTypeId ;
      private Guid AV13Insert_SupplierGenTypeId ;
      private Guid AV28Insert_OrganisationId ;
      private Guid AV30OrganisationId ;
      private Guid GXt_guid3 ;
      private Guid i11OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_suppliergentypeid ;
      private GXUserControl ucCombo_suppliergenphonecode ;
      private GXUserControl ucCombo_suppliergenaddresscountry ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15SupplierGenTypeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27SupplierGenPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23SupplierGenAddressCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private IDataStoreProvider pr_default ;
      private string[] T00064_A290SupplierGenTypeName ;
      private Guid[] T00066_A42SupplierGenId ;
      private bool[] T00066_n42SupplierGenId ;
      private string[] T00066_A335SupplierGenAddressCountry ;
      private string[] T00066_A381SupplierGenPhoneCode ;
      private string[] T00066_A48SupplierGenContactPhone ;
      private string[] T00066_A43SupplierGenKvkNumber ;
      private string[] T00066_A290SupplierGenTypeName ;
      private string[] T00066_A44SupplierGenCompanyName ;
      private string[] T00066_A295SupplierGenAddressCity ;
      private string[] T00066_A294SupplierGenAddressZipCode ;
      private string[] T00066_A336SupplierGenAddressLine1 ;
      private string[] T00066_A337SupplierGenAddressLine2 ;
      private string[] T00066_A47SupplierGenContactName ;
      private string[] T00066_A382SupplierGenPhoneNumber ;
      private string[] T00066_A441SupplierGenWebsite ;
      private Guid[] T00066_A282SupplierGenTypeId ;
      private Guid[] T00066_A11OrganisationId ;
      private bool[] T00066_n11OrganisationId ;
      private Guid[] T00065_A11OrganisationId ;
      private bool[] T00065_n11OrganisationId ;
      private string[] T00067_A290SupplierGenTypeName ;
      private Guid[] T00068_A11OrganisationId ;
      private bool[] T00068_n11OrganisationId ;
      private Guid[] T00069_A42SupplierGenId ;
      private bool[] T00069_n42SupplierGenId ;
      private Guid[] T00063_A42SupplierGenId ;
      private bool[] T00063_n42SupplierGenId ;
      private string[] T00063_A335SupplierGenAddressCountry ;
      private string[] T00063_A381SupplierGenPhoneCode ;
      private string[] T00063_A48SupplierGenContactPhone ;
      private string[] T00063_A43SupplierGenKvkNumber ;
      private string[] T00063_A44SupplierGenCompanyName ;
      private string[] T00063_A295SupplierGenAddressCity ;
      private string[] T00063_A294SupplierGenAddressZipCode ;
      private string[] T00063_A336SupplierGenAddressLine1 ;
      private string[] T00063_A337SupplierGenAddressLine2 ;
      private string[] T00063_A47SupplierGenContactName ;
      private string[] T00063_A382SupplierGenPhoneNumber ;
      private string[] T00063_A441SupplierGenWebsite ;
      private Guid[] T00063_A282SupplierGenTypeId ;
      private Guid[] T00063_A11OrganisationId ;
      private bool[] T00063_n11OrganisationId ;
      private Guid[] T000610_A42SupplierGenId ;
      private bool[] T000610_n42SupplierGenId ;
      private Guid[] T000611_A42SupplierGenId ;
      private bool[] T000611_n42SupplierGenId ;
      private Guid[] T00062_A42SupplierGenId ;
      private bool[] T00062_n42SupplierGenId ;
      private string[] T00062_A335SupplierGenAddressCountry ;
      private string[] T00062_A381SupplierGenPhoneCode ;
      private string[] T00062_A48SupplierGenContactPhone ;
      private string[] T00062_A43SupplierGenKvkNumber ;
      private string[] T00062_A44SupplierGenCompanyName ;
      private string[] T00062_A295SupplierGenAddressCity ;
      private string[] T00062_A294SupplierGenAddressZipCode ;
      private string[] T00062_A336SupplierGenAddressLine1 ;
      private string[] T00062_A337SupplierGenAddressLine2 ;
      private string[] T00062_A47SupplierGenContactName ;
      private string[] T00062_A382SupplierGenPhoneNumber ;
      private string[] T00062_A441SupplierGenWebsite ;
      private Guid[] T00062_A282SupplierGenTypeId ;
      private Guid[] T00062_A11OrganisationId ;
      private bool[] T00062_n11OrganisationId ;
      private string[] T000615_A290SupplierGenTypeName ;
      private Guid[] T000616_A58ProductServiceId ;
      private Guid[] T000616_A29LocationId ;
      private Guid[] T000616_A11OrganisationId ;
      private bool[] T000616_n11OrganisationId ;
      private Guid[] T000617_A42SupplierGenId ;
      private bool[] T000617_n42SupplierGenId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergen__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergen__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergen__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00062;
       prmT00062 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00063;
       prmT00063 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00064;
       prmT00064 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00065;
       prmT00065 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00066;
       prmT00066 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00067;
       prmT00067 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00068;
       prmT00068 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00069;
       prmT00069 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000610;
       prmT000610 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000611;
       prmT000611 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000612;
       prmT000612 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000613;
       prmT000613 = new Object[] {
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,50,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000614;
       prmT000614 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000615;
       prmT000615 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000616;
       prmT000616 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000617;
       prmT000617 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00062", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierGen NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00063", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00064", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00065", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00066", "SELECT TM1.SupplierGenId, TM1.SupplierGenAddressCountry, TM1.SupplierGenPhoneCode, TM1.SupplierGenContactPhone, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressZipCode, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneNumber, TM1.SupplierGenWebsite, TM1.SupplierGenTypeId, TM1.OrganisationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00067", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00068", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00069", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000610", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId > :SupplierGenId) ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000611", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId < :SupplierGenId) ORDER BY SupplierGenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000612", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGen(SupplierGenId, SupplierGenAddressCountry, SupplierGenPhoneCode, SupplierGenContactPhone, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneNumber, SupplierGenWebsite, SupplierGenTypeId, OrganisationId) VALUES(:SupplierGenId, :SupplierGenAddressCountry, :SupplierGenPhoneCode, :SupplierGenContactPhone, :SupplierGenKvkNumber, :SupplierGenCompanyName, :SupplierGenAddressCity, :SupplierGenAddressZipCode, :SupplierGenAddressLine1, :SupplierGenAddressLine2, :SupplierGenContactName, :SupplierGenPhoneNumber, :SupplierGenWebsite, :SupplierGenTypeId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000612)
          ,new CursorDef("T000613", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGen SET SupplierGenAddressCountry=:SupplierGenAddressCountry, SupplierGenPhoneCode=:SupplierGenPhoneCode, SupplierGenContactPhone=:SupplierGenContactPhone, SupplierGenKvkNumber=:SupplierGenKvkNumber, SupplierGenCompanyName=:SupplierGenCompanyName, SupplierGenAddressCity=:SupplierGenAddressCity, SupplierGenAddressZipCode=:SupplierGenAddressZipCode, SupplierGenAddressLine1=:SupplierGenAddressLine1, SupplierGenAddressLine2=:SupplierGenAddressLine2, SupplierGenContactName=:SupplierGenContactName, SupplierGenPhoneNumber=:SupplierGenPhoneNumber, SupplierGenWebsite=:SupplierGenWebsite, SupplierGenTypeId=:SupplierGenTypeId, OrganisationId=:OrganisationId  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000613)
          ,new CursorDef("T000614", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000614)
          ,new CursorDef("T000615", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000616", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000617", "SELECT SupplierGenId FROM Trn_SupplierGen ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
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
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
             ((bool[]) buf[16])[0] = rslt.wasNull(16);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
