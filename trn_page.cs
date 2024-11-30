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
   public class trn_page : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A58ProductServiceId, A29LocationId, A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_page.aspx")), "trn_page.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_page.aspx")))) ;
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
                  AV17Trn_PageId = StringUtil.StrToGuid( GetPar( "Trn_PageId"));
                  AssignAttri("", false, "AV17Trn_PageId", AV17Trn_PageId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_PAGEID", GetSecureSignedToken( "", AV17Trn_PageId, context));
                  AV18Trn_PageName = GetPar( "Trn_PageName");
                  AssignAttri("", false, "AV18Trn_PageName", AV18Trn_PageName);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_PAGENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Trn_PageName, "")), context));
                  AV19LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV19LocationId", AV19LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Page", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_page( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_page( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_PageId ,
                           string aP2_Trn_PageName ,
                           Guid aP3_LocationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV17Trn_PageId = aP1_Trn_PageId;
         this.AV18Trn_PageName = aP2_Trn_PageName;
         this.AV19LocationId = aP3_LocationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPageIsPublished = new GXCheckbox();
         cmbPageIsContentPage = new GXCombobox();
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
            return "trn_page_Execute" ;
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
         A434PageIsPublished = StringUtil.StrToBool( StringUtil.BoolToStr( A434PageIsPublished));
         n434PageIsPublished = false;
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            A439PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A439PageIsContentPage)));
            n439PageIsContentPage = false;
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
            AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", cmbPageIsContentPage.ToJavascriptSource(), true);
         }
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Page.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_PageId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_PageId_Internalname, A310Trn_PageId.ToString(), A310Trn_PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_PageName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_PageName_Internalname, A318Trn_PageName, StringUtil.RTrim( context.localUtil.Format( A318Trn_PageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklocationid_Internalname, context.GetMessage( "Location", ""), "", "", lblTextblocklocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationid.SetProperty("Caption", Combo_locationid_Caption);
         ucCombo_locationid.SetProperty("Cls", Combo_locationid_Cls);
         ucCombo_locationid.SetProperty("DataListProc", Combo_locationid_Datalistproc);
         ucCombo_locationid.SetProperty("EmptyItem", Combo_locationid_Emptyitem);
         ucCombo_locationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
         ucCombo_locationid.SetProperty("DropDownOptionsData", AV20LocationId_Data);
         ucCombo_locationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationid_Internalname, "COMBO_LOCATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageJsonContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageJsonContent_Internalname, context.GetMessage( "Json Content", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageJsonContent_Internalname, A431PageJsonContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtPageJsonContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSHtml_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageGJSHtml_Internalname, context.GetMessage( "GJSHtml", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageGJSHtml_Internalname, A432PageGJSHtml, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 1, 1, edtPageGJSHtml_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSJson_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageGJSJson_Internalname, context.GetMessage( "GJSJson", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageGJSJson_Internalname, A433PageGJSJson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", 0, 1, edtPageGJSJson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkPageIsPublished_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkPageIsPublished_Internalname, context.GetMessage( "Is Published", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkPageIsPublished_Internalname, StringUtil.BoolToStr( A434PageIsPublished), "", context.GetMessage( "Is Published", ""), 1, chkPageIsPublished.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,57);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPageIsContentPage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPageIsContentPage_Internalname, context.GetMessage( "Content Page", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPageIsContentPage, cmbPageIsContentPage_Internalname, StringUtil.BoolToStr( A439PageIsContentPage), 1, cmbPageIsContentPage_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbPageIsContentPage.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_Trn_Page.htm");
         cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", (string)(cmbPageIsContentPage.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageChildren_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageChildren_Internalname, context.GetMessage( "Children", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageChildren_Internalname, A437PageChildren, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", 0, 1, edtPageChildren_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedproductserviceid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproductserviceid_Internalname, context.GetMessage( "Product/Service", ""), "", "", lblTextblockproductserviceid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_productserviceid.SetProperty("Caption", Combo_productserviceid_Caption);
         ucCombo_productserviceid.SetProperty("Cls", Combo_productserviceid_Cls);
         ucCombo_productserviceid.SetProperty("DataListProc", Combo_productserviceid_Datalistproc);
         ucCombo_productserviceid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
         ucCombo_productserviceid.SetProperty("DropDownOptionsData", AV29ProductServiceId_Data);
         ucCombo_productserviceid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_productserviceid_Internalname, "COMBO_PRODUCTSERVICEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceId_Internalname, context.GetMessage( "Product Service Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationid_Internalname, context.GetMessage( "Organisations", ""), "", "", lblTextblockorganisationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationid.SetProperty("Caption", Combo_organisationid_Caption);
         ucCombo_organisationid.SetProperty("Cls", Combo_organisationid_Cls);
         ucCombo_organisationid.SetProperty("DataListProc", Combo_organisationid_Datalistproc);
         ucCombo_organisationid.SetProperty("DataListProcParametersPrefix", Combo_organisationid_Datalistprocparametersprefix);
         ucCombo_organisationid.SetProperty("EmptyItem", Combo_organisationid_Emptyitem);
         ucCombo_organisationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
         ucCombo_organisationid.SetProperty("DropDownOptionsData", AV32OrganisationId_Data);
         ucCombo_organisationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationid_Internalname, "COMBO_ORGANISATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_locationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationid_Internalname, AV25ComboLocationId.ToString(), AV25ComboLocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationid_Visible, edtavCombolocationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_productserviceid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboproductserviceid_Internalname, AV30ComboProductServiceId.ToString(), AV30ComboProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboproductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboproductserviceid_Visible, edtavComboproductserviceid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationid_Internalname, AV33ComboOrganisationId.ToString(), AV33ComboOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationid_Visible, edtavComboorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11172 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONID_DATA"), AV20LocationId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSERVICEID_DATA"), AV29ProductServiceId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONID_DATA"), AV32OrganisationId_Data);
               /* Read saved values. */
               Z310Trn_PageId = StringUtil.StrToGuid( cgiGet( "Z310Trn_PageId"));
               Z318Trn_PageName = cgiGet( "Z318Trn_PageName");
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z434PageIsPublished = StringUtil.StrToBool( cgiGet( "Z434PageIsPublished"));
               n434PageIsPublished = ((false==A434PageIsPublished) ? true : false);
               Z439PageIsContentPage = StringUtil.StrToBool( cgiGet( "Z439PageIsContentPage"));
               n439PageIsContentPage = ((false==A439PageIsContentPage) ? true : false);
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N58ProductServiceId = StringUtil.StrToGuid( cgiGet( "N58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               AV17Trn_PageId = StringUtil.StrToGuid( cgiGet( "vTRN_PAGEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV18Trn_PageName = cgiGet( "vTRN_PAGENAME");
               AV19LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV16Insert_ProductServiceId = StringUtil.StrToGuid( cgiGet( "vINSERT_PRODUCTSERVICEID"));
               AV14Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV34Pgmname = cgiGet( "vPGMNAME");
               Combo_locationid_Objectcall = cgiGet( "COMBO_LOCATIONID_Objectcall");
               Combo_locationid_Class = cgiGet( "COMBO_LOCATIONID_Class");
               Combo_locationid_Icontype = cgiGet( "COMBO_LOCATIONID_Icontype");
               Combo_locationid_Icon = cgiGet( "COMBO_LOCATIONID_Icon");
               Combo_locationid_Caption = cgiGet( "COMBO_LOCATIONID_Caption");
               Combo_locationid_Tooltip = cgiGet( "COMBO_LOCATIONID_Tooltip");
               Combo_locationid_Cls = cgiGet( "COMBO_LOCATIONID_Cls");
               Combo_locationid_Selectedvalue_set = cgiGet( "COMBO_LOCATIONID_Selectedvalue_set");
               Combo_locationid_Selectedvalue_get = cgiGet( "COMBO_LOCATIONID_Selectedvalue_get");
               Combo_locationid_Selectedtext_set = cgiGet( "COMBO_LOCATIONID_Selectedtext_set");
               Combo_locationid_Selectedtext_get = cgiGet( "COMBO_LOCATIONID_Selectedtext_get");
               Combo_locationid_Gamoauthtoken = cgiGet( "COMBO_LOCATIONID_Gamoauthtoken");
               Combo_locationid_Ddointernalname = cgiGet( "COMBO_LOCATIONID_Ddointernalname");
               Combo_locationid_Titlecontrolalign = cgiGet( "COMBO_LOCATIONID_Titlecontrolalign");
               Combo_locationid_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONID_Dropdownoptionstype");
               Combo_locationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Enabled"));
               Combo_locationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Visible"));
               Combo_locationid_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONID_Titlecontrolidtoreplace");
               Combo_locationid_Datalisttype = cgiGet( "COMBO_LOCATIONID_Datalisttype");
               Combo_locationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Allowmultipleselection"));
               Combo_locationid_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONID_Datalistfixedvalues");
               Combo_locationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Isgriditem"));
               Combo_locationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Hasdescription"));
               Combo_locationid_Datalistproc = cgiGet( "COMBO_LOCATIONID_Datalistproc");
               Combo_locationid_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONID_Datalistprocparametersprefix");
               Combo_locationid_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONID_Remoteservicesparameters");
               Combo_locationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeonlyselectedoption"));
               Combo_locationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeselectalloption"));
               Combo_locationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Emptyitem"));
               Combo_locationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeaddnewoption"));
               Combo_locationid_Htmltemplate = cgiGet( "COMBO_LOCATIONID_Htmltemplate");
               Combo_locationid_Multiplevaluestype = cgiGet( "COMBO_LOCATIONID_Multiplevaluestype");
               Combo_locationid_Loadingdata = cgiGet( "COMBO_LOCATIONID_Loadingdata");
               Combo_locationid_Noresultsfound = cgiGet( "COMBO_LOCATIONID_Noresultsfound");
               Combo_locationid_Emptyitemtext = cgiGet( "COMBO_LOCATIONID_Emptyitemtext");
               Combo_locationid_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONID_Onlyselectedvalues");
               Combo_locationid_Selectalltext = cgiGet( "COMBO_LOCATIONID_Selectalltext");
               Combo_locationid_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONID_Multiplevaluesseparator");
               Combo_locationid_Addnewoptiontext = cgiGet( "COMBO_LOCATIONID_Addnewoptiontext");
               Combo_locationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_productserviceid_Objectcall = cgiGet( "COMBO_PRODUCTSERVICEID_Objectcall");
               Combo_productserviceid_Class = cgiGet( "COMBO_PRODUCTSERVICEID_Class");
               Combo_productserviceid_Icontype = cgiGet( "COMBO_PRODUCTSERVICEID_Icontype");
               Combo_productserviceid_Icon = cgiGet( "COMBO_PRODUCTSERVICEID_Icon");
               Combo_productserviceid_Caption = cgiGet( "COMBO_PRODUCTSERVICEID_Caption");
               Combo_productserviceid_Tooltip = cgiGet( "COMBO_PRODUCTSERVICEID_Tooltip");
               Combo_productserviceid_Cls = cgiGet( "COMBO_PRODUCTSERVICEID_Cls");
               Combo_productserviceid_Selectedvalue_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_set");
               Combo_productserviceid_Selectedvalue_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_get");
               Combo_productserviceid_Selectedtext_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_set");
               Combo_productserviceid_Selectedtext_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_get");
               Combo_productserviceid_Gamoauthtoken = cgiGet( "COMBO_PRODUCTSERVICEID_Gamoauthtoken");
               Combo_productserviceid_Ddointernalname = cgiGet( "COMBO_PRODUCTSERVICEID_Ddointernalname");
               Combo_productserviceid_Titlecontrolalign = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolalign");
               Combo_productserviceid_Dropdownoptionstype = cgiGet( "COMBO_PRODUCTSERVICEID_Dropdownoptionstype");
               Combo_productserviceid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Enabled"));
               Combo_productserviceid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Visible"));
               Combo_productserviceid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolidtoreplace");
               Combo_productserviceid_Datalisttype = cgiGet( "COMBO_PRODUCTSERVICEID_Datalisttype");
               Combo_productserviceid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Allowmultipleselection"));
               Combo_productserviceid_Datalistfixedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistfixedvalues");
               Combo_productserviceid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Isgriditem"));
               Combo_productserviceid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Hasdescription"));
               Combo_productserviceid_Datalistproc = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistproc");
               Combo_productserviceid_Datalistprocparametersprefix = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix");
               Combo_productserviceid_Remoteservicesparameters = cgiGet( "COMBO_PRODUCTSERVICEID_Remoteservicesparameters");
               Combo_productserviceid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_productserviceid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeonlyselectedoption"));
               Combo_productserviceid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeselectalloption"));
               Combo_productserviceid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitem"));
               Combo_productserviceid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeaddnewoption"));
               Combo_productserviceid_Htmltemplate = cgiGet( "COMBO_PRODUCTSERVICEID_Htmltemplate");
               Combo_productserviceid_Multiplevaluestype = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluestype");
               Combo_productserviceid_Loadingdata = cgiGet( "COMBO_PRODUCTSERVICEID_Loadingdata");
               Combo_productserviceid_Noresultsfound = cgiGet( "COMBO_PRODUCTSERVICEID_Noresultsfound");
               Combo_productserviceid_Emptyitemtext = cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitemtext");
               Combo_productserviceid_Onlyselectedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Onlyselectedvalues");
               Combo_productserviceid_Selectalltext = cgiGet( "COMBO_PRODUCTSERVICEID_Selectalltext");
               Combo_productserviceid_Multiplevaluesseparator = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluesseparator");
               Combo_productserviceid_Addnewoptiontext = cgiGet( "COMBO_PRODUCTSERVICEID_Addnewoptiontext");
               Combo_productserviceid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationid_Objectcall = cgiGet( "COMBO_ORGANISATIONID_Objectcall");
               Combo_organisationid_Class = cgiGet( "COMBO_ORGANISATIONID_Class");
               Combo_organisationid_Icontype = cgiGet( "COMBO_ORGANISATIONID_Icontype");
               Combo_organisationid_Icon = cgiGet( "COMBO_ORGANISATIONID_Icon");
               Combo_organisationid_Caption = cgiGet( "COMBO_ORGANISATIONID_Caption");
               Combo_organisationid_Tooltip = cgiGet( "COMBO_ORGANISATIONID_Tooltip");
               Combo_organisationid_Cls = cgiGet( "COMBO_ORGANISATIONID_Cls");
               Combo_organisationid_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_set");
               Combo_organisationid_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_get");
               Combo_organisationid_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_set");
               Combo_organisationid_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_get");
               Combo_organisationid_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONID_Gamoauthtoken");
               Combo_organisationid_Ddointernalname = cgiGet( "COMBO_ORGANISATIONID_Ddointernalname");
               Combo_organisationid_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolalign");
               Combo_organisationid_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONID_Dropdownoptionstype");
               Combo_organisationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Enabled"));
               Combo_organisationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Visible"));
               Combo_organisationid_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolidtoreplace");
               Combo_organisationid_Datalisttype = cgiGet( "COMBO_ORGANISATIONID_Datalisttype");
               Combo_organisationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Allowmultipleselection"));
               Combo_organisationid_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONID_Datalistfixedvalues");
               Combo_organisationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Isgriditem"));
               Combo_organisationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Hasdescription"));
               Combo_organisationid_Datalistproc = cgiGet( "COMBO_ORGANISATIONID_Datalistproc");
               Combo_organisationid_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONID_Datalistprocparametersprefix");
               Combo_organisationid_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONID_Remoteservicesparameters");
               Combo_organisationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeonlyselectedoption"));
               Combo_organisationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeselectalloption"));
               Combo_organisationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Emptyitem"));
               Combo_organisationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeaddnewoption"));
               Combo_organisationid_Htmltemplate = cgiGet( "COMBO_ORGANISATIONID_Htmltemplate");
               Combo_organisationid_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluestype");
               Combo_organisationid_Loadingdata = cgiGet( "COMBO_ORGANISATIONID_Loadingdata");
               Combo_organisationid_Noresultsfound = cgiGet( "COMBO_ORGANISATIONID_Noresultsfound");
               Combo_organisationid_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONID_Emptyitemtext");
               Combo_organisationid_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONID_Onlyselectedvalues");
               Combo_organisationid_Selectalltext = cgiGet( "COMBO_ORGANISATIONID_Selectalltext");
               Combo_organisationid_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluesseparator");
               Combo_organisationid_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONID_Addnewoptiontext");
               Combo_organisationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_PageId_Internalname), "") == 0 )
               {
                  A310Trn_PageId = Guid.Empty;
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               }
               else
               {
                  try
                  {
                     A310Trn_PageId = StringUtil.StrToGuid( cgiGet( edtTrn_PageId_Internalname));
                     AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A318Trn_PageName = cgiGet( edtTrn_PageName_Internalname);
               AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
               if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
               {
                  A29LocationId = Guid.Empty;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                     AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A431PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
               n431PageJsonContent = false;
               AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
               n431PageJsonContent = (String.IsNullOrEmpty(StringUtil.RTrim( A431PageJsonContent)) ? true : false);
               A432PageGJSHtml = cgiGet( edtPageGJSHtml_Internalname);
               n432PageGJSHtml = false;
               AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
               n432PageGJSHtml = (String.IsNullOrEmpty(StringUtil.RTrim( A432PageGJSHtml)) ? true : false);
               A433PageGJSJson = cgiGet( edtPageGJSJson_Internalname);
               n433PageGJSJson = false;
               AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
               n433PageGJSJson = (String.IsNullOrEmpty(StringUtil.RTrim( A433PageGJSJson)) ? true : false);
               A434PageIsPublished = StringUtil.StrToBool( cgiGet( chkPageIsPublished_Internalname));
               n434PageIsPublished = false;
               AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
               n434PageIsPublished = ((false==A434PageIsPublished) ? true : false);
               cmbPageIsContentPage.CurrentValue = cgiGet( cmbPageIsContentPage_Internalname);
               A439PageIsContentPage = StringUtil.StrToBool( cgiGet( cmbPageIsContentPage_Internalname));
               n439PageIsContentPage = false;
               AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
               n439PageIsContentPage = ((false==A439PageIsContentPage) ? true : false);
               A437PageChildren = cgiGet( edtPageChildren_Internalname);
               n437PageChildren = false;
               AssignAttri("", false, "A437PageChildren", A437PageChildren);
               n437PageChildren = (String.IsNullOrEmpty(StringUtil.RTrim( A437PageChildren)) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                     n58ProductServiceId = false;
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               AV25ComboLocationId = StringUtil.StrToGuid( cgiGet( edtavCombolocationid_Internalname));
               AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
               AV30ComboProductServiceId = StringUtil.StrToGuid( cgiGet( edtavComboproductserviceid_Internalname));
               AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
               AV33ComboOrganisationId = StringUtil.StrToGuid( cgiGet( edtavComboorganisationid_Internalname));
               AssignAttri("", false, "AV33ComboOrganisationId", AV33ComboOrganisationId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Page");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) || ( A29LocationId != Z29LocationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_page:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A310Trn_PageId = StringUtil.StrToGuid( GetPar( "Trn_PageId"));
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  A318Trn_PageName = GetPar( "Trn_PageName");
                  AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV17Trn_PageId) )
                  {
                     A310Trn_PageId = AV17Trn_PageId;
                     AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) && ( Gx_BScreen == 0 ) )
                     {
                        A310Trn_PageId = Guid.NewGuid( );
                        AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
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
                     sMode98 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV17Trn_PageId) )
                     {
                        A310Trn_PageId = AV17Trn_PageId;
                        AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) && ( Gx_BScreen == 0 ) )
                        {
                           A310Trn_PageId = Guid.NewGuid( );
                           AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                        }
                     }
                     Gx_mode = sMode98;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound98 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_170( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_PAGEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_PageId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_locationid.Onoptionclicked */
                           E12172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_productserviceid.Onoptionclicked */
                           E13172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_organisationid.Onoptionclicked */
                           E14172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E15172 ();
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
            E15172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1798( ) ;
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
            DisableAttributes1798( ) ;
         }
         AssignProp("", false, edtavCombolocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1798( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1798( ) ;
            }
            else
            {
               CheckExtendedTable1798( ) ;
               CloseExtendedTableCursors1798( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption170( )
      {
      }

      protected void E11172( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV27GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV28GAMErrors);
         Combo_organisationid_Gamoauthtoken = AV27GAMSession.gxTpr_Token;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "GAMOAuthToken", Combo_organisationid_Gamoauthtoken);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         AV33ComboOrganisationId = Guid.Empty;
         AssignAttri("", false, "AV33ComboOrganisationId", AV33ComboOrganisationId.ToString());
         edtavComboorganisationid_Visible = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Visible), 5, 0), true);
         Combo_productserviceid_Gamoauthtoken = AV27GAMSession.gxTpr_Token;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "GAMOAuthToken", Combo_productserviceid_Gamoauthtoken);
         edtProductServiceId_Visible = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         AV30ComboProductServiceId = Guid.Empty;
         AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
         edtavComboproductserviceid_Visible = 0;
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Visible), 5, 0), true);
         Combo_locationid_Gamoauthtoken = AV27GAMSession.gxTpr_Token;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "GAMOAuthToken", Combo_locationid_Gamoauthtoken);
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         AV25ComboLocationId = Guid.Empty;
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         edtavCombolocationid_Visible = 0;
         AssignProp("", false, edtavCombolocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPRODUCTSERVICEID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            while ( AV35GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProductServiceId") == 0 )
               {
                  AV16Insert_ProductServiceId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV16Insert_ProductServiceId", AV16Insert_ProductServiceId.ToString());
                  if ( ! (Guid.Empty==AV16Insert_ProductServiceId) )
                  {
                     AV30ComboProductServiceId = AV16Insert_ProductServiceId;
                     AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
                     Combo_productserviceid_Selectedvalue_set = StringUtil.Trim( AV30ComboProductServiceId.ToString());
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
                     GXt_char2 = AV24Combo_DataJson;
                     new trn_pageloaddvcombo(context ).execute(  "ProductServiceId",  "GET",  false,  AV17Trn_PageId,  AV18Trn_PageName,  AV19LocationId,  AV14Insert_OrganisationId,  AV13Insert_LocationId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV22ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV22ComboSelectedValue", AV22ComboSelectedValue);
                     AssignAttri("", false, "AV23ComboSelectedText", AV23ComboSelectedText);
                     AV24Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV24Combo_DataJson", AV24Combo_DataJson);
                     Combo_productserviceid_Selectedtext_set = AV23ComboSelectedText;
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
                     Combo_productserviceid_Enabled = false;
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV14Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_OrganisationId", AV14Insert_OrganisationId.ToString());
                  if ( ! (Guid.Empty==AV14Insert_OrganisationId) )
                  {
                     AV33ComboOrganisationId = AV14Insert_OrganisationId;
                     AssignAttri("", false, "AV33ComboOrganisationId", AV33ComboOrganisationId.ToString());
                     Combo_organisationid_Selectedvalue_set = StringUtil.Trim( AV33ComboOrganisationId.ToString());
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
                     GXt_char2 = AV24Combo_DataJson;
                     new trn_pageloaddvcombo(context ).execute(  "OrganisationId",  "GET",  false,  AV17Trn_PageId,  AV18Trn_PageName,  AV19LocationId,  A11OrganisationId,  A29LocationId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV22ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV22ComboSelectedValue", AV22ComboSelectedValue);
                     AssignAttri("", false, "AV23ComboSelectedText", AV23ComboSelectedText);
                     AV24Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV24Combo_DataJson", AV24Combo_DataJson);
                     Combo_organisationid_Selectedtext_set = AV23ComboSelectedText;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
                     Combo_organisationid_Enabled = false;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
                  }
               }
               AV35GXV1 = (int)(AV35GXV1+1);
               AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            }
         }
      }

      protected void E15172( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_pageww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E14172( )
      {
         /* Combo_organisationid_Onoptionclicked Routine */
         returnInSub = false;
         AV26Cond_OrganisationId = A11OrganisationId;
         AV33ComboOrganisationId = StringUtil.StrToGuid( Combo_organisationid_Selectedvalue_get);
         AssignAttri("", false, "AV33ComboOrganisationId", AV33ComboOrganisationId.ToString());
         if ( AV26Cond_OrganisationId != AV33ComboOrganisationId )
         {
            AV25ComboLocationId = Guid.Empty;
            AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
            Combo_locationid_Selectedvalue_set = "";
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedValue_set", Combo_locationid_Selectedvalue_set);
            Combo_locationid_Selectedtext_set = "";
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedText_set", Combo_locationid_Selectedtext_set);
            AV30ComboProductServiceId = Guid.Empty;
            AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
            Combo_productserviceid_Selectedvalue_set = "";
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
            Combo_productserviceid_Selectedtext_set = "";
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void E13172( )
      {
         /* Combo_productserviceid_Onoptionclicked Routine */
         returnInSub = false;
         AV30ComboProductServiceId = StringUtil.StrToGuid( Combo_productserviceid_Selectedvalue_get);
         AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E12172( )
      {
         /* Combo_locationid_Onoptionclicked Routine */
         returnInSub = false;
         AV31Cond_LocationId = A29LocationId;
         AV25ComboLocationId = StringUtil.StrToGuid( Combo_locationid_Selectedvalue_get);
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         if ( AV31Cond_LocationId != AV25ComboLocationId )
         {
            AV30ComboProductServiceId = Guid.Empty;
            AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
            Combo_productserviceid_Selectedvalue_set = "";
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
            Combo_productserviceid_Selectedtext_set = "";
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'LOADCOMBOORGANISATIONID' Routine */
         returnInSub = false;
         GXt_char2 = AV24Combo_DataJson;
         new trn_pageloaddvcombo(context ).execute(  "OrganisationId",  Gx_mode,  false,  AV17Trn_PageId,  AV18Trn_PageName,  AV19LocationId,  A11OrganisationId,  A29LocationId,  "", out  AV22ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV22ComboSelectedValue", AV22ComboSelectedValue);
         AssignAttri("", false, "AV23ComboSelectedText", AV23ComboSelectedText);
         AV24Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV24Combo_DataJson", AV24Combo_DataJson);
         Combo_organisationid_Selectedvalue_set = AV22ComboSelectedValue;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
         Combo_organisationid_Selectedtext_set = AV23ComboSelectedText;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
         AV33ComboOrganisationId = StringUtil.StrToGuid( AV22ComboSelectedValue);
         AssignAttri("", false, "AV33ComboOrganisationId", AV33ComboOrganisationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationid_Enabled = false;
            ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPRODUCTSERVICEID' Routine */
         returnInSub = false;
         Combo_productserviceid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProductServiceId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_PageId\": \"00000000-0000-0000-0000-000000000000\", \"Trn_PageName\": \"\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"Cond_OrganisationId\": \"#%1#\", \"Cond_LocationId\": \"#%2#\"", edtOrganisationId_Internalname, edtLocationId_Internalname, "", "", "", "", "", "", "");
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "DataListProcParametersPrefix", Combo_productserviceid_Datalistprocparametersprefix);
         GXt_char2 = AV24Combo_DataJson;
         new trn_pageloaddvcombo(context ).execute(  "ProductServiceId",  Gx_mode,  false,  AV17Trn_PageId,  AV18Trn_PageName,  AV19LocationId,  A11OrganisationId,  A29LocationId,  "", out  AV22ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV22ComboSelectedValue", AV22ComboSelectedValue);
         AssignAttri("", false, "AV23ComboSelectedText", AV23ComboSelectedText);
         AV24Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV24Combo_DataJson", AV24Combo_DataJson);
         Combo_productserviceid_Selectedvalue_set = AV22ComboSelectedValue;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
         Combo_productserviceid_Selectedtext_set = AV23ComboSelectedText;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
         AV30ComboProductServiceId = StringUtil.StrToGuid( AV22ComboSelectedValue);
         AssignAttri("", false, "AV30ComboProductServiceId", AV30ComboProductServiceId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_productserviceid_Enabled = false;
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLOCATIONID' Routine */
         returnInSub = false;
         Combo_locationid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"LocationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_PageId\": \"00000000-0000-0000-0000-000000000000\", \"Trn_PageName\": \"\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"Cond_OrganisationId\": \"#%1#\", \"Cond_LocationId\": \"#%2#\"", edtOrganisationId_Internalname, edtLocationId_Internalname, "", "", "", "", "", "", "");
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "DataListProcParametersPrefix", Combo_locationid_Datalistprocparametersprefix);
         GXt_char2 = AV24Combo_DataJson;
         new trn_pageloaddvcombo(context ).execute(  "LocationId",  Gx_mode,  false,  AV17Trn_PageId,  AV18Trn_PageName,  AV19LocationId,  A11OrganisationId,  A29LocationId,  "", out  AV22ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV22ComboSelectedValue", AV22ComboSelectedValue);
         AssignAttri("", false, "AV23ComboSelectedText", AV23ComboSelectedText);
         AV24Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV24Combo_DataJson", AV24Combo_DataJson);
         Combo_locationid_Selectedvalue_set = AV22ComboSelectedValue;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedValue_set", Combo_locationid_Selectedvalue_set);
         Combo_locationid_Selectedtext_set = AV23ComboSelectedText;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedText_set", Combo_locationid_Selectedtext_set);
         AV25ComboLocationId = StringUtil.StrToGuid( AV22ComboSelectedValue);
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (Guid.Empty==AV19LocationId) )
         {
            Combo_locationid_Enabled = false;
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationid_Enabled));
         }
      }

      protected void ZM1798( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z434PageIsPublished = T00173_A434PageIsPublished[0];
               Z439PageIsContentPage = T00173_A439PageIsContentPage[0];
               Z11OrganisationId = T00173_A11OrganisationId[0];
               Z58ProductServiceId = T00173_A58ProductServiceId[0];
            }
            else
            {
               Z434PageIsPublished = A434PageIsPublished;
               Z439PageIsContentPage = A439PageIsContentPage;
               Z11OrganisationId = A11OrganisationId;
               Z58ProductServiceId = A58ProductServiceId;
            }
         }
         if ( GX_JID == -25 )
         {
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
            Z431PageJsonContent = A431PageJsonContent;
            Z432PageGJSHtml = A432PageGJSHtml;
            Z433PageGJSJson = A433PageGJSJson;
            Z434PageIsPublished = A434PageIsPublished;
            Z439PageIsContentPage = A439PageIsContentPage;
            Z437PageChildren = A437PageChildren;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z58ProductServiceId = A58ProductServiceId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV34Pgmname = "Trn_Page";
         AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV17Trn_PageId) )
         {
            edtTrn_PageId_Enabled = 0;
            AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_PageId_Enabled = 1;
            AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV17Trn_PageId) )
         {
            edtTrn_PageId_Enabled = 0;
            AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Trn_PageName)) )
         {
            A318Trn_PageName = AV18Trn_PageName;
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Trn_PageName)) )
         {
            edtTrn_PageName_Enabled = 0;
            AssignProp("", false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_PageName_Enabled = 1;
            AssignProp("", false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Trn_PageName)) )
         {
            edtTrn_PageName_Enabled = 0;
            AssignProp("", false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV19LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV19LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV19LocationId) )
         {
            A29LocationId = AV19LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = AV25ComboLocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV16Insert_ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV16Insert_ProductServiceId) )
         {
            A58ProductServiceId = AV16Insert_ProductServiceId;
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV30ComboProductServiceId) )
            {
               A58ProductServiceId = Guid.Empty;
               n58ProductServiceId = false;
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               n58ProductServiceId = true;
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV30ComboProductServiceId) )
               {
                  A58ProductServiceId = AV30ComboProductServiceId;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_OrganisationId) )
         {
            A11OrganisationId = AV14Insert_OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = AV33ComboOrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
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
         if ( ! (Guid.Empty==AV17Trn_PageId) )
         {
            A310Trn_PageId = AV17Trn_PageId;
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) && ( Gx_BScreen == 0 ) )
            {
               A310Trn_PageId = Guid.NewGuid( );
               AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            }
         }
         if ( IsIns( )  && (false==A439PageIsContentPage) && ( Gx_BScreen == 0 ) )
         {
            A439PageIsContentPage = false;
            n439PageIsContentPage = false;
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         }
         if ( IsIns( )  && (false==A434PageIsPublished) && ( Gx_BScreen == 0 ) )
         {
            A434PageIsPublished = false;
            n434PageIsPublished = false;
            AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1798( )
      {
         /* Using cursor T00176 */
         pr_default.execute(4, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound98 = 1;
            A431PageJsonContent = T00176_A431PageJsonContent[0];
            n431PageJsonContent = T00176_n431PageJsonContent[0];
            AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
            A432PageGJSHtml = T00176_A432PageGJSHtml[0];
            n432PageGJSHtml = T00176_n432PageGJSHtml[0];
            AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
            A433PageGJSJson = T00176_A433PageGJSJson[0];
            n433PageGJSJson = T00176_n433PageGJSJson[0];
            AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
            A434PageIsPublished = T00176_A434PageIsPublished[0];
            n434PageIsPublished = T00176_n434PageIsPublished[0];
            AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
            A439PageIsContentPage = T00176_A439PageIsContentPage[0];
            n439PageIsContentPage = T00176_n439PageIsContentPage[0];
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            A437PageChildren = T00176_A437PageChildren[0];
            n437PageChildren = T00176_n437PageChildren[0];
            AssignAttri("", false, "A437PageChildren", A437PageChildren);
            A11OrganisationId = T00176_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A58ProductServiceId = T00176_A58ProductServiceId[0];
            n58ProductServiceId = T00176_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            ZM1798( -25) ;
         }
         pr_default.close(4);
         OnLoadActions1798( ) ;
      }

      protected void OnLoadActions1798( )
      {
      }

      protected void CheckExtendedTable1798( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Page name cannot be empty.", ""), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00174 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T00177 */
         pr_default.execute(5, new Object[] {A318Trn_PageName, A29LocationId, A310Trn_PageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Page Name", "")+","+context.GetMessage( "Location Id", "")}), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1798( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_27( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00178 */
         pr_default.execute(6, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_28( Guid A58ProductServiceId ,
                                Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00179 */
         pr_default.execute(7, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey1798( )
      {
         /* Using cursor T001710 */
         pr_default.execute(8, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound98 = 1;
         }
         else
         {
            RcdFound98 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00173 */
         pr_default.execute(1, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1798( 25) ;
            RcdFound98 = 1;
            A310Trn_PageId = T00173_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            A318Trn_PageName = T00173_A318Trn_PageName[0];
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A431PageJsonContent = T00173_A431PageJsonContent[0];
            n431PageJsonContent = T00173_n431PageJsonContent[0];
            AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
            A432PageGJSHtml = T00173_A432PageGJSHtml[0];
            n432PageGJSHtml = T00173_n432PageGJSHtml[0];
            AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
            A433PageGJSJson = T00173_A433PageGJSJson[0];
            n433PageGJSJson = T00173_n433PageGJSJson[0];
            AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
            A434PageIsPublished = T00173_A434PageIsPublished[0];
            n434PageIsPublished = T00173_n434PageIsPublished[0];
            AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
            A439PageIsContentPage = T00173_A439PageIsContentPage[0];
            n439PageIsContentPage = T00173_n439PageIsContentPage[0];
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            A437PageChildren = T00173_A437PageChildren[0];
            n437PageChildren = T00173_n437PageChildren[0];
            AssignAttri("", false, "A437PageChildren", A437PageChildren);
            A29LocationId = T00173_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T00173_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A58ProductServiceId = T00173_A58ProductServiceId[0];
            n58ProductServiceId = T00173_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
            Z29LocationId = A29LocationId;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1798( ) ;
            if ( AnyError == 1 )
            {
               RcdFound98 = 0;
               InitializeNonKey1798( ) ;
            }
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound98 = 0;
            InitializeNonKey1798( ) ;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1798( ) ;
         if ( RcdFound98 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound98 = 0;
         /* Using cursor T001711 */
         pr_default.execute(9, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001711_A310Trn_PageId[0], A310Trn_PageId, 0) < 0 ) || ( T001711_A310Trn_PageId[0] == A310Trn_PageId ) && ( StringUtil.StrCmp(T001711_A318Trn_PageName[0], A318Trn_PageName) < 0 ) || ( StringUtil.StrCmp(T001711_A318Trn_PageName[0], A318Trn_PageName) == 0 ) && ( T001711_A310Trn_PageId[0] == A310Trn_PageId ) && ( GuidUtil.Compare(T001711_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001711_A310Trn_PageId[0], A310Trn_PageId, 0) > 0 ) || ( T001711_A310Trn_PageId[0] == A310Trn_PageId ) && ( StringUtil.StrCmp(T001711_A318Trn_PageName[0], A318Trn_PageName) > 0 ) || ( StringUtil.StrCmp(T001711_A318Trn_PageName[0], A318Trn_PageName) == 0 ) && ( T001711_A310Trn_PageId[0] == A310Trn_PageId ) && ( GuidUtil.Compare(T001711_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               A310Trn_PageId = T001711_A310Trn_PageId[0];
               AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               A318Trn_PageName = T001711_A318Trn_PageName[0];
               AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
               A29LocationId = T001711_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound98 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound98 = 0;
         /* Using cursor T001712 */
         pr_default.execute(10, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001712_A310Trn_PageId[0], A310Trn_PageId, 0) > 0 ) || ( T001712_A310Trn_PageId[0] == A310Trn_PageId ) && ( StringUtil.StrCmp(T001712_A318Trn_PageName[0], A318Trn_PageName) > 0 ) || ( StringUtil.StrCmp(T001712_A318Trn_PageName[0], A318Trn_PageName) == 0 ) && ( T001712_A310Trn_PageId[0] == A310Trn_PageId ) && ( GuidUtil.Compare(T001712_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001712_A310Trn_PageId[0], A310Trn_PageId, 0) < 0 ) || ( T001712_A310Trn_PageId[0] == A310Trn_PageId ) && ( StringUtil.StrCmp(T001712_A318Trn_PageName[0], A318Trn_PageName) < 0 ) || ( StringUtil.StrCmp(T001712_A318Trn_PageName[0], A318Trn_PageName) == 0 ) && ( T001712_A310Trn_PageId[0] == A310Trn_PageId ) && ( GuidUtil.Compare(T001712_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               A310Trn_PageId = T001712_A310Trn_PageId[0];
               AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               A318Trn_PageName = T001712_A318Trn_PageName[0];
               AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
               A29LocationId = T001712_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound98 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1798( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1798( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound98 == 1 )
            {
               if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) || ( A29LocationId != Z29LocationId ) )
               {
                  A310Trn_PageId = Z310Trn_PageId;
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  A318Trn_PageName = Z318Trn_PageName;
                  AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_PAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1798( ) ;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) || ( A29LocationId != Z29LocationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1798( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1798( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) || ( A29LocationId != Z29LocationId ) )
         {
            A310Trn_PageId = Z310Trn_PageId;
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            A318Trn_PageName = Z318Trn_PageName;
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1798( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00172 */
            pr_default.execute(0, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z434PageIsPublished != T00172_A434PageIsPublished[0] ) || ( Z439PageIsContentPage != T00172_A439PageIsContentPage[0] ) || ( Z11OrganisationId != T00172_A11OrganisationId[0] ) || ( Z58ProductServiceId != T00172_A58ProductServiceId[0] ) )
            {
               if ( Z434PageIsPublished != T00172_A434PageIsPublished[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"PageIsPublished");
                  GXUtil.WriteLogRaw("Old: ",Z434PageIsPublished);
                  GXUtil.WriteLogRaw("Current: ",T00172_A434PageIsPublished[0]);
               }
               if ( Z439PageIsContentPage != T00172_A439PageIsContentPage[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"PageIsContentPage");
                  GXUtil.WriteLogRaw("Old: ",Z439PageIsContentPage);
                  GXUtil.WriteLogRaw("Current: ",T00172_A439PageIsContentPage[0]);
               }
               if ( Z11OrganisationId != T00172_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T00172_A11OrganisationId[0]);
               }
               if ( Z58ProductServiceId != T00172_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T00172_A58ProductServiceId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1798( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1798( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1798( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1798( 0) ;
            CheckOptimisticConcurrency1798( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1798( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1798( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001713 */
                     pr_default.execute(11, new Object[] {A310Trn_PageId, A318Trn_PageName, n431PageJsonContent, A431PageJsonContent, n432PageGJSHtml, A432PageGJSHtml, n433PageGJSJson, A433PageGJSJson, n434PageIsPublished, A434PageIsPublished, n439PageIsContentPage, A439PageIsContentPage, n437PageChildren, A437PageChildren, A29LocationId, A11OrganisationId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ResetCaption170( ) ;
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
               Load1798( ) ;
            }
            EndLevel1798( ) ;
         }
         CloseExtendedTableCursors1798( ) ;
      }

      protected void Update1798( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1798( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1798( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1798( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1798( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1798( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001714 */
                     pr_default.execute(12, new Object[] {n431PageJsonContent, A431PageJsonContent, n432PageGJSHtml, A432PageGJSHtml, n433PageGJSJson, A433PageGJSJson, n434PageIsPublished, A434PageIsPublished, n439PageIsContentPage, A439PageIsContentPage, n437PageChildren, A437PageChildren, A11OrganisationId, n58ProductServiceId, A58ProductServiceId, A310Trn_PageId, A318Trn_PageName, A29LocationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1798( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
            EndLevel1798( ) ;
         }
         CloseExtendedTableCursors1798( ) ;
      }

      protected void DeferredUpdate1798( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1798( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1798( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1798( ) ;
            AfterConfirm1798( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1798( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001715 */
                  pr_default.execute(13, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
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
         sMode98 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1798( ) ;
         Gx_mode = sMode98;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1798( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1798( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1798( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_page",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues170( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_page",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1798( )
      {
         /* Scan By routine */
         /* Using cursor T001716 */
         pr_default.execute(14);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound98 = 1;
            A310Trn_PageId = T001716_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            A318Trn_PageName = T001716_A318Trn_PageName[0];
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A29LocationId = T001716_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1798( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound98 = 1;
            A310Trn_PageId = T001716_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            A318Trn_PageName = T001716_A318Trn_PageName[0];
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A29LocationId = T001716_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void ScanEnd1798( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1798( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1798( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1798( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1798( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1798( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1798( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1798( )
      {
         edtTrn_PageId_Enabled = 0;
         AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         edtTrn_PageName_Enabled = 0;
         AssignProp("", false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtPageJsonContent_Enabled = 0;
         AssignProp("", false, edtPageJsonContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Enabled), 5, 0), true);
         edtPageGJSHtml_Enabled = 0;
         AssignProp("", false, edtPageGJSHtml_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSHtml_Enabled), 5, 0), true);
         edtPageGJSJson_Enabled = 0;
         AssignProp("", false, edtPageGJSJson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSJson_Enabled), 5, 0), true);
         chkPageIsPublished.Enabled = 0;
         AssignProp("", false, chkPageIsPublished_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPageIsPublished.Enabled), 5, 0), true);
         cmbPageIsContentPage.Enabled = 0;
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageIsContentPage.Enabled), 5, 0), true);
         edtPageChildren_Enabled = 0;
         AssignProp("", false, edtPageChildren_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageChildren_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtavCombolocationid_Enabled = 0;
         AssignProp("", false, edtavCombolocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Enabled), 5, 0), true);
         edtavComboproductserviceid_Enabled = 0;
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Enabled), 5, 0), true);
         edtavComboorganisationid_Enabled = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1798( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues170( )
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
         GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV17Trn_PageId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV18Trn_PageName)) + "," + UrlEncode(AV19LocationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Page");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_page:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z310Trn_PageId", Z310Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z318Trn_PageName", Z318Trn_PageName);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "Z434PageIsPublished", Z434PageIsPublished);
         GxWebStd.gx_boolean_hidden_field( context, "Z439PageIsContentPage", Z439PageIsContentPage);
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N58ProductServiceId", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONID_DATA", AV20LocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONID_DATA", AV20LocationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSERVICEID_DATA", AV29ProductServiceId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSERVICEID_DATA", AV29ProductServiceId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONID_DATA", AV32OrganisationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONID_DATA", AV32OrganisationId_Data);
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
         GxWebStd.gx_hidden_field( context, "vTRN_PAGEID", AV17Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_PAGEID", GetSecureSignedToken( "", AV17Trn_PageId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTRN_PAGENAME", AV18Trn_PageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_PAGENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Trn_PageName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV19LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTSERVICEID", AV16Insert_ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV14Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Objectcall", StringUtil.RTrim( Combo_locationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Cls", StringUtil.RTrim( Combo_locationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_locationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Selectedtext_set", StringUtil.RTrim( Combo_locationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_locationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Enabled", StringUtil.BoolToStr( Combo_locationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Datalistproc", StringUtil.RTrim( Combo_locationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_locationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_locationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Objectcall", StringUtil.RTrim( Combo_productserviceid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Cls", StringUtil.RTrim( Combo_productserviceid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Selectedvalue_set", StringUtil.RTrim( Combo_productserviceid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Selectedtext_set", StringUtil.RTrim( Combo_productserviceid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Gamoauthtoken", StringUtil.RTrim( Combo_productserviceid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistproc", StringUtil.RTrim( Combo_productserviceid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_productserviceid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Objectcall", StringUtil.RTrim( Combo_organisationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Cls", StringUtil.RTrim( Combo_organisationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_organisationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedtext_set", StringUtil.RTrim( Combo_organisationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_organisationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistproc", StringUtil.RTrim( Combo_organisationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_organisationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Emptyitem", StringUtil.BoolToStr( Combo_organisationid_Emptyitem));
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
         GXEncryptionTmp = "trn_page.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV17Trn_PageId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV18Trn_PageName)) + "," + UrlEncode(AV19LocationId.ToString());
         return formatLink("trn_page.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Page" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Page", "") ;
      }

      protected void InitializeNonKey1798( )
      {
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A431PageJsonContent = "";
         n431PageJsonContent = false;
         AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
         n431PageJsonContent = (String.IsNullOrEmpty(StringUtil.RTrim( A431PageJsonContent)) ? true : false);
         A432PageGJSHtml = "";
         n432PageGJSHtml = false;
         AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
         n432PageGJSHtml = (String.IsNullOrEmpty(StringUtil.RTrim( A432PageGJSHtml)) ? true : false);
         A433PageGJSJson = "";
         n433PageGJSJson = false;
         AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
         n433PageGJSJson = (String.IsNullOrEmpty(StringUtil.RTrim( A433PageGJSJson)) ? true : false);
         A437PageChildren = "";
         n437PageChildren = false;
         AssignAttri("", false, "A437PageChildren", A437PageChildren);
         n437PageChildren = (String.IsNullOrEmpty(StringUtil.RTrim( A437PageChildren)) ? true : false);
         A434PageIsPublished = false;
         n434PageIsPublished = false;
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         A439PageIsContentPage = false;
         n439PageIsContentPage = false;
         AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         Z434PageIsPublished = false;
         Z439PageIsContentPage = false;
         Z11OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
      }

      protected void InitAll1798( )
      {
         A310Trn_PageId = Guid.NewGuid( );
         AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         A318Trn_PageName = "";
         AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         InitializeNonKey1798( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A439PageIsContentPage = i439PageIsContentPage;
         n439PageIsContentPage = false;
         AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         A434PageIsPublished = i434PageIsPublished;
         n434PageIsPublished = false;
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411271320415", true, true);
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
         context.AddJavascriptSource("trn_page.js", "?202411271320417", false, true);
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
         edtTrn_PageId_Internalname = "TRN_PAGEID";
         edtTrn_PageName_Internalname = "TRN_PAGENAME";
         lblTextblocklocationid_Internalname = "TEXTBLOCKLOCATIONID";
         Combo_locationid_Internalname = "COMBO_LOCATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         divTablesplittedlocationid_Internalname = "TABLESPLITTEDLOCATIONID";
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT";
         edtPageGJSHtml_Internalname = "PAGEGJSHTML";
         edtPageGJSJson_Internalname = "PAGEGJSJSON";
         chkPageIsPublished_Internalname = "PAGEISPUBLISHED";
         cmbPageIsContentPage_Internalname = "PAGEISCONTENTPAGE";
         edtPageChildren_Internalname = "PAGECHILDREN";
         lblTextblockproductserviceid_Internalname = "TEXTBLOCKPRODUCTSERVICEID";
         Combo_productserviceid_Internalname = "COMBO_PRODUCTSERVICEID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         divTablesplittedproductserviceid_Internalname = "TABLESPLITTEDPRODUCTSERVICEID";
         lblTextblockorganisationid_Internalname = "TEXTBLOCKORGANISATIONID";
         Combo_organisationid_Internalname = "COMBO_ORGANISATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divTablesplittedorganisationid_Internalname = "TABLESPLITTEDORGANISATIONID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombolocationid_Internalname = "vCOMBOLOCATIONID";
         divSectionattribute_locationid_Internalname = "SECTIONATTRIBUTE_LOCATIONID";
         edtavComboproductserviceid_Internalname = "vCOMBOPRODUCTSERVICEID";
         divSectionattribute_productserviceid_Internalname = "SECTIONATTRIBUTE_PRODUCTSERVICEID";
         edtavComboorganisationid_Internalname = "vCOMBOORGANISATIONID";
         divSectionattribute_organisationid_Internalname = "SECTIONATTRIBUTE_ORGANISATIONID";
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
         Form.Caption = context.GetMessage( "Trn_Page", "");
         Combo_locationid_Datalistprocparametersprefix = "";
         Combo_productserviceid_Datalistprocparametersprefix = "";
         edtavComboorganisationid_Jsonclick = "";
         edtavComboorganisationid_Enabled = 0;
         edtavComboorganisationid_Visible = 1;
         edtavComboproductserviceid_Jsonclick = "";
         edtavComboproductserviceid_Enabled = 0;
         edtavComboproductserviceid_Visible = 1;
         edtavCombolocationid_Jsonclick = "";
         edtavCombolocationid_Enabled = 0;
         edtavCombolocationid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         Combo_organisationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationid_Datalistprocparametersprefix = " \"ComboName\": \"OrganisationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_PageId\": \"00000000-0000-0000-0000-000000000000\", \"Trn_PageName\": \"\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_organisationid_Datalistproc = "Trn_PageLoadDVCombo";
         Combo_organisationid_Cls = "ExtendedCombo Attribute";
         Combo_organisationid_Caption = "";
         Combo_organisationid_Enabled = Convert.ToBoolean( -1);
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         edtProductServiceId_Visible = 1;
         Combo_productserviceid_Datalistproc = "Trn_PageLoadDVCombo";
         Combo_productserviceid_Cls = "ExtendedCombo Attribute";
         Combo_productserviceid_Caption = "";
         Combo_productserviceid_Enabled = Convert.ToBoolean( -1);
         edtPageChildren_Enabled = 1;
         cmbPageIsContentPage_Jsonclick = "";
         cmbPageIsContentPage.Enabled = 1;
         chkPageIsPublished.Enabled = 1;
         edtPageGJSJson_Enabled = 1;
         edtPageGJSHtml_Enabled = 1;
         edtPageJsonContent_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         Combo_locationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationid_Datalistproc = "Trn_PageLoadDVCombo";
         Combo_locationid_Cls = "ExtendedCombo Attribute";
         Combo_locationid_Caption = "";
         Combo_locationid_Enabled = Convert.ToBoolean( -1);
         edtTrn_PageName_Jsonclick = "";
         edtTrn_PageName_Enabled = 1;
         edtTrn_PageId_Jsonclick = "";
         edtTrn_PageId_Enabled = 1;
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

      protected void init_web_controls( )
      {
         chkPageIsPublished.Name = "PAGEISPUBLISHED";
         chkPageIsPublished.WebTags = "";
         chkPageIsPublished.Caption = context.GetMessage( "Is Published", "");
         AssignProp("", false, chkPageIsPublished_Internalname, "TitleCaption", chkPageIsPublished.Caption, true);
         chkPageIsPublished.CheckedValue = "false";
         if ( IsIns( ) && (false==A434PageIsPublished) )
         {
            A434PageIsPublished = false;
            n434PageIsPublished = false;
            AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         }
         cmbPageIsContentPage.Name = "PAGEISCONTENTPAGE";
         cmbPageIsContentPage.WebTags = "";
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A439PageIsContentPage) )
            {
               A439PageIsContentPage = false;
               n439PageIsContentPage = false;
               AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            }
         }
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

      public void Valid_Locationid( )
      {
         /* Using cursor T001717 */
         pr_default.execute(15, new Object[] {A318Trn_PageName, A29LocationId, A310Trn_PageId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Page Name", "")+","+context.GetMessage( "Location Id", "")}), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Organisationid( )
      {
         n58ProductServiceId = false;
         /* Using cursor T001718 */
         pr_default.execute(16, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(16);
         /* Using cursor T001719 */
         pr_default.execute(17, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
            }
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV17Trn_PageId","fld":"vTRN_PAGEID","hsh":true},{"av":"AV18Trn_PageName","fld":"vTRN_PAGENAME","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV17Trn_PageId","fld":"vTRN_PAGEID","hsh":true},{"av":"AV18Trn_PageName","fld":"vTRN_PAGENAME","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E15172","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED","""{"handler":"E14172","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"Combo_organisationid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONID","prop":"SelectedValue_get"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV33ComboOrganisationId","fld":"vCOMBOORGANISATIONID"},{"av":"AV25ComboLocationId","fld":"vCOMBOLOCATIONID"},{"av":"Combo_locationid_Selectedvalue_set","ctrl":"COMBO_LOCATIONID","prop":"SelectedValue_set"},{"av":"Combo_locationid_Selectedtext_set","ctrl":"COMBO_LOCATIONID","prop":"SelectedText_set"},{"av":"AV30ComboProductServiceId","fld":"vCOMBOPRODUCTSERVICEID"},{"av":"Combo_productserviceid_Selectedvalue_set","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedValue_set"},{"av":"Combo_productserviceid_Selectedtext_set","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedText_set"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED","""{"handler":"E13172","iparms":[{"av":"Combo_productserviceid_Selectedvalue_get","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedValue_get"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV30ComboProductServiceId","fld":"vCOMBOPRODUCTSERVICEID"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("COMBO_LOCATIONID.ONOPTIONCLICKED","""{"handler":"E12172","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"Combo_locationid_Selectedvalue_get","ctrl":"COMBO_LOCATIONID","prop":"SelectedValue_get"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("COMBO_LOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV25ComboLocationId","fld":"vCOMBOLOCATIONID"},{"av":"AV30ComboProductServiceId","fld":"vCOMBOPRODUCTSERVICEID"},{"av":"Combo_productserviceid_Selectedvalue_set","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedValue_set"},{"av":"Combo_productserviceid_Selectedtext_set","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedText_set"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALID_TRN_PAGEID","""{"handler":"Valid_Trn_pageid","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_TRN_PAGEID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALID_TRN_PAGENAME","""{"handler":"Valid_Trn_pagename","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_TRN_PAGENAME",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A318Trn_PageName","fld":"TRN_PAGENAME"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A310Trn_PageId","fld":"TRN_PAGEID"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONID","""{"handler":"Validv_Combolocationid","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALIDV_COMBOLOCATIONID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALIDV_COMBOPRODUCTSERVICEID","""{"handler":"Validv_Comboproductserviceid","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALIDV_COMBOPRODUCTSERVICEID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONID","""{"handler":"Validv_Comboorganisationid","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALIDV_COMBOORGANISATIONID",""","oparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]}""");
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
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV17Trn_PageId = Guid.Empty;
         wcpOAV18Trn_PageName = "";
         wcpOAV19LocationId = Guid.Empty;
         Z310Trn_PageId = Guid.Empty;
         Z318Trn_PageName = "";
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         N58ProductServiceId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         Combo_organisationid_Selectedvalue_get = "";
         Combo_productserviceid_Selectedvalue_get = "";
         Combo_locationid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         lblTextblocklocationid_Jsonclick = "";
         ucCombo_locationid = new GXUserControl();
         AV21DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV20LocationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         lblTextblockproductserviceid_Jsonclick = "";
         ucCombo_productserviceid = new GXUserControl();
         AV29ProductServiceId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockorganisationid_Jsonclick = "";
         ucCombo_organisationid = new GXUserControl();
         AV32OrganisationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV25ComboLocationId = Guid.Empty;
         AV30ComboProductServiceId = Guid.Empty;
         AV33ComboOrganisationId = Guid.Empty;
         AV16Insert_ProductServiceId = Guid.Empty;
         AV14Insert_OrganisationId = Guid.Empty;
         AV34Pgmname = "";
         Combo_locationid_Objectcall = "";
         Combo_locationid_Class = "";
         Combo_locationid_Icontype = "";
         Combo_locationid_Icon = "";
         Combo_locationid_Tooltip = "";
         Combo_locationid_Selectedvalue_set = "";
         Combo_locationid_Selectedtext_set = "";
         Combo_locationid_Selectedtext_get = "";
         Combo_locationid_Gamoauthtoken = "";
         Combo_locationid_Ddointernalname = "";
         Combo_locationid_Titlecontrolalign = "";
         Combo_locationid_Dropdownoptionstype = "";
         Combo_locationid_Titlecontrolidtoreplace = "";
         Combo_locationid_Datalisttype = "";
         Combo_locationid_Datalistfixedvalues = "";
         Combo_locationid_Remoteservicesparameters = "";
         Combo_locationid_Htmltemplate = "";
         Combo_locationid_Multiplevaluestype = "";
         Combo_locationid_Loadingdata = "";
         Combo_locationid_Noresultsfound = "";
         Combo_locationid_Emptyitemtext = "";
         Combo_locationid_Onlyselectedvalues = "";
         Combo_locationid_Selectalltext = "";
         Combo_locationid_Multiplevaluesseparator = "";
         Combo_locationid_Addnewoptiontext = "";
         Combo_productserviceid_Objectcall = "";
         Combo_productserviceid_Class = "";
         Combo_productserviceid_Icontype = "";
         Combo_productserviceid_Icon = "";
         Combo_productserviceid_Tooltip = "";
         Combo_productserviceid_Selectedvalue_set = "";
         Combo_productserviceid_Selectedtext_set = "";
         Combo_productserviceid_Selectedtext_get = "";
         Combo_productserviceid_Gamoauthtoken = "";
         Combo_productserviceid_Ddointernalname = "";
         Combo_productserviceid_Titlecontrolalign = "";
         Combo_productserviceid_Dropdownoptionstype = "";
         Combo_productserviceid_Titlecontrolidtoreplace = "";
         Combo_productserviceid_Datalisttype = "";
         Combo_productserviceid_Datalistfixedvalues = "";
         Combo_productserviceid_Remoteservicesparameters = "";
         Combo_productserviceid_Htmltemplate = "";
         Combo_productserviceid_Multiplevaluestype = "";
         Combo_productserviceid_Loadingdata = "";
         Combo_productserviceid_Noresultsfound = "";
         Combo_productserviceid_Emptyitemtext = "";
         Combo_productserviceid_Onlyselectedvalues = "";
         Combo_productserviceid_Selectalltext = "";
         Combo_productserviceid_Multiplevaluesseparator = "";
         Combo_productserviceid_Addnewoptiontext = "";
         Combo_organisationid_Objectcall = "";
         Combo_organisationid_Class = "";
         Combo_organisationid_Icontype = "";
         Combo_organisationid_Icon = "";
         Combo_organisationid_Tooltip = "";
         Combo_organisationid_Selectedvalue_set = "";
         Combo_organisationid_Selectedtext_set = "";
         Combo_organisationid_Selectedtext_get = "";
         Combo_organisationid_Gamoauthtoken = "";
         Combo_organisationid_Ddointernalname = "";
         Combo_organisationid_Titlecontrolalign = "";
         Combo_organisationid_Dropdownoptionstype = "";
         Combo_organisationid_Titlecontrolidtoreplace = "";
         Combo_organisationid_Datalisttype = "";
         Combo_organisationid_Datalistfixedvalues = "";
         Combo_organisationid_Remoteservicesparameters = "";
         Combo_organisationid_Htmltemplate = "";
         Combo_organisationid_Multiplevaluestype = "";
         Combo_organisationid_Loadingdata = "";
         Combo_organisationid_Noresultsfound = "";
         Combo_organisationid_Emptyitemtext = "";
         Combo_organisationid_Onlyselectedvalues = "";
         Combo_organisationid_Selectalltext = "";
         Combo_organisationid_Multiplevaluesseparator = "";
         Combo_organisationid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode98 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV28GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV24Combo_DataJson = "";
         AV13Insert_LocationId = Guid.Empty;
         AV22ComboSelectedValue = "";
         AV23ComboSelectedText = "";
         AV26Cond_OrganisationId = Guid.Empty;
         AV31Cond_LocationId = Guid.Empty;
         GXt_char2 = "";
         Z431PageJsonContent = "";
         Z432PageGJSHtml = "";
         Z433PageGJSJson = "";
         Z437PageChildren = "";
         T00176_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00176_A318Trn_PageName = new string[] {""} ;
         T00176_A431PageJsonContent = new string[] {""} ;
         T00176_n431PageJsonContent = new bool[] {false} ;
         T00176_A432PageGJSHtml = new string[] {""} ;
         T00176_n432PageGJSHtml = new bool[] {false} ;
         T00176_A433PageGJSJson = new string[] {""} ;
         T00176_n433PageGJSJson = new bool[] {false} ;
         T00176_A434PageIsPublished = new bool[] {false} ;
         T00176_n434PageIsPublished = new bool[] {false} ;
         T00176_A439PageIsContentPage = new bool[] {false} ;
         T00176_n439PageIsContentPage = new bool[] {false} ;
         T00176_A437PageChildren = new string[] {""} ;
         T00176_n437PageChildren = new bool[] {false} ;
         T00176_A29LocationId = new Guid[] {Guid.Empty} ;
         T00176_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00176_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00176_n58ProductServiceId = new bool[] {false} ;
         T00174_A29LocationId = new Guid[] {Guid.Empty} ;
         T00175_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00175_n58ProductServiceId = new bool[] {false} ;
         T00177_A318Trn_PageName = new string[] {""} ;
         T00178_A29LocationId = new Guid[] {Guid.Empty} ;
         T00179_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00179_n58ProductServiceId = new bool[] {false} ;
         T001710_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001710_A318Trn_PageName = new string[] {""} ;
         T001710_A29LocationId = new Guid[] {Guid.Empty} ;
         T00173_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00173_A318Trn_PageName = new string[] {""} ;
         T00173_A431PageJsonContent = new string[] {""} ;
         T00173_n431PageJsonContent = new bool[] {false} ;
         T00173_A432PageGJSHtml = new string[] {""} ;
         T00173_n432PageGJSHtml = new bool[] {false} ;
         T00173_A433PageGJSJson = new string[] {""} ;
         T00173_n433PageGJSJson = new bool[] {false} ;
         T00173_A434PageIsPublished = new bool[] {false} ;
         T00173_n434PageIsPublished = new bool[] {false} ;
         T00173_A439PageIsContentPage = new bool[] {false} ;
         T00173_n439PageIsContentPage = new bool[] {false} ;
         T00173_A437PageChildren = new string[] {""} ;
         T00173_n437PageChildren = new bool[] {false} ;
         T00173_A29LocationId = new Guid[] {Guid.Empty} ;
         T00173_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00173_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00173_n58ProductServiceId = new bool[] {false} ;
         T001711_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001711_A318Trn_PageName = new string[] {""} ;
         T001711_A29LocationId = new Guid[] {Guid.Empty} ;
         T001712_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001712_A318Trn_PageName = new string[] {""} ;
         T001712_A29LocationId = new Guid[] {Guid.Empty} ;
         T00172_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00172_A318Trn_PageName = new string[] {""} ;
         T00172_A431PageJsonContent = new string[] {""} ;
         T00172_n431PageJsonContent = new bool[] {false} ;
         T00172_A432PageGJSHtml = new string[] {""} ;
         T00172_n432PageGJSHtml = new bool[] {false} ;
         T00172_A433PageGJSJson = new string[] {""} ;
         T00172_n433PageGJSJson = new bool[] {false} ;
         T00172_A434PageIsPublished = new bool[] {false} ;
         T00172_n434PageIsPublished = new bool[] {false} ;
         T00172_A439PageIsContentPage = new bool[] {false} ;
         T00172_n439PageIsContentPage = new bool[] {false} ;
         T00172_A437PageChildren = new string[] {""} ;
         T00172_n437PageChildren = new bool[] {false} ;
         T00172_A29LocationId = new Guid[] {Guid.Empty} ;
         T00172_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00172_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00172_n58ProductServiceId = new bool[] {false} ;
         T001716_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001716_A318Trn_PageName = new string[] {""} ;
         T001716_A29LocationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001717_A318Trn_PageName = new string[] {""} ;
         T001718_A29LocationId = new Guid[] {Guid.Empty} ;
         T001719_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T001719_n58ProductServiceId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_page__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_page__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_page__default(),
            new Object[][] {
                new Object[] {
               T00172_A310Trn_PageId, T00172_A318Trn_PageName, T00172_A431PageJsonContent, T00172_n431PageJsonContent, T00172_A432PageGJSHtml, T00172_n432PageGJSHtml, T00172_A433PageGJSJson, T00172_n433PageGJSJson, T00172_A434PageIsPublished, T00172_n434PageIsPublished,
               T00172_A439PageIsContentPage, T00172_n439PageIsContentPage, T00172_A437PageChildren, T00172_n437PageChildren, T00172_A29LocationId, T00172_A11OrganisationId, T00172_A58ProductServiceId, T00172_n58ProductServiceId
               }
               , new Object[] {
               T00173_A310Trn_PageId, T00173_A318Trn_PageName, T00173_A431PageJsonContent, T00173_n431PageJsonContent, T00173_A432PageGJSHtml, T00173_n432PageGJSHtml, T00173_A433PageGJSJson, T00173_n433PageGJSJson, T00173_A434PageIsPublished, T00173_n434PageIsPublished,
               T00173_A439PageIsContentPage, T00173_n439PageIsContentPage, T00173_A437PageChildren, T00173_n437PageChildren, T00173_A29LocationId, T00173_A11OrganisationId, T00173_A58ProductServiceId, T00173_n58ProductServiceId
               }
               , new Object[] {
               T00174_A29LocationId
               }
               , new Object[] {
               T00175_A58ProductServiceId
               }
               , new Object[] {
               T00176_A310Trn_PageId, T00176_A318Trn_PageName, T00176_A431PageJsonContent, T00176_n431PageJsonContent, T00176_A432PageGJSHtml, T00176_n432PageGJSHtml, T00176_A433PageGJSJson, T00176_n433PageGJSJson, T00176_A434PageIsPublished, T00176_n434PageIsPublished,
               T00176_A439PageIsContentPage, T00176_n439PageIsContentPage, T00176_A437PageChildren, T00176_n437PageChildren, T00176_A29LocationId, T00176_A11OrganisationId, T00176_A58ProductServiceId, T00176_n58ProductServiceId
               }
               , new Object[] {
               T00177_A318Trn_PageName
               }
               , new Object[] {
               T00178_A29LocationId
               }
               , new Object[] {
               T00179_A58ProductServiceId
               }
               , new Object[] {
               T001710_A310Trn_PageId, T001710_A318Trn_PageName, T001710_A29LocationId
               }
               , new Object[] {
               T001711_A310Trn_PageId, T001711_A318Trn_PageName, T001711_A29LocationId
               }
               , new Object[] {
               T001712_A310Trn_PageId, T001712_A318Trn_PageName, T001712_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001716_A310Trn_PageId, T001716_A318Trn_PageName, T001716_A29LocationId
               }
               , new Object[] {
               T001717_A318Trn_PageName
               }
               , new Object[] {
               T001718_A29LocationId
               }
               , new Object[] {
               T001719_A58ProductServiceId
               }
            }
         );
         Z439PageIsContentPage = false;
         n439PageIsContentPage = false;
         A439PageIsContentPage = false;
         n439PageIsContentPage = false;
         i439PageIsContentPage = false;
         n439PageIsContentPage = false;
         Z434PageIsPublished = false;
         n434PageIsPublished = false;
         A434PageIsPublished = false;
         n434PageIsPublished = false;
         i434PageIsPublished = false;
         n434PageIsPublished = false;
         Z310Trn_PageId = Guid.NewGuid( );
         A310Trn_PageId = Guid.NewGuid( );
         AV34Pgmname = "Trn_Page";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound98 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_PageId_Enabled ;
      private int edtTrn_PageName_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtPageJsonContent_Enabled ;
      private int edtPageGJSHtml_Enabled ;
      private int edtPageGJSJson_Enabled ;
      private int edtPageChildren_Enabled ;
      private int edtProductServiceId_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombolocationid_Visible ;
      private int edtavCombolocationid_Enabled ;
      private int edtavComboproductserviceid_Visible ;
      private int edtavComboproductserviceid_Enabled ;
      private int edtavComboorganisationid_Visible ;
      private int edtavComboorganisationid_Enabled ;
      private int Combo_locationid_Datalistupdateminimumcharacters ;
      private int Combo_locationid_Gxcontroltype ;
      private int Combo_productserviceid_Datalistupdateminimumcharacters ;
      private int Combo_productserviceid_Gxcontroltype ;
      private int Combo_organisationid_Datalistupdateminimumcharacters ;
      private int Combo_organisationid_Gxcontroltype ;
      private int AV35GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_organisationid_Selectedvalue_get ;
      private string Combo_productserviceid_Selectedvalue_get ;
      private string Combo_locationid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_PageId_Internalname ;
      private string cmbPageIsContentPage_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_PageId_Jsonclick ;
      private string edtTrn_PageName_Internalname ;
      private string edtTrn_PageName_Jsonclick ;
      private string divTablesplittedlocationid_Internalname ;
      private string lblTextblocklocationid_Internalname ;
      private string lblTextblocklocationid_Jsonclick ;
      private string Combo_locationid_Caption ;
      private string Combo_locationid_Cls ;
      private string Combo_locationid_Datalistproc ;
      private string Combo_locationid_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtPageJsonContent_Internalname ;
      private string edtPageGJSHtml_Internalname ;
      private string edtPageGJSJson_Internalname ;
      private string chkPageIsPublished_Internalname ;
      private string cmbPageIsContentPage_Jsonclick ;
      private string edtPageChildren_Internalname ;
      private string divTablesplittedproductserviceid_Internalname ;
      private string lblTextblockproductserviceid_Internalname ;
      private string lblTextblockproductserviceid_Jsonclick ;
      private string Combo_productserviceid_Caption ;
      private string Combo_productserviceid_Cls ;
      private string Combo_productserviceid_Datalistproc ;
      private string Combo_productserviceid_Internalname ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string divTablesplittedorganisationid_Internalname ;
      private string lblTextblockorganisationid_Internalname ;
      private string lblTextblockorganisationid_Jsonclick ;
      private string Combo_organisationid_Caption ;
      private string Combo_organisationid_Cls ;
      private string Combo_organisationid_Datalistproc ;
      private string Combo_organisationid_Datalistprocparametersprefix ;
      private string Combo_organisationid_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_locationid_Internalname ;
      private string edtavCombolocationid_Internalname ;
      private string edtavCombolocationid_Jsonclick ;
      private string divSectionattribute_productserviceid_Internalname ;
      private string edtavComboproductserviceid_Internalname ;
      private string edtavComboproductserviceid_Jsonclick ;
      private string divSectionattribute_organisationid_Internalname ;
      private string edtavComboorganisationid_Internalname ;
      private string edtavComboorganisationid_Jsonclick ;
      private string AV34Pgmname ;
      private string Combo_locationid_Objectcall ;
      private string Combo_locationid_Class ;
      private string Combo_locationid_Icontype ;
      private string Combo_locationid_Icon ;
      private string Combo_locationid_Tooltip ;
      private string Combo_locationid_Selectedvalue_set ;
      private string Combo_locationid_Selectedtext_set ;
      private string Combo_locationid_Selectedtext_get ;
      private string Combo_locationid_Gamoauthtoken ;
      private string Combo_locationid_Ddointernalname ;
      private string Combo_locationid_Titlecontrolalign ;
      private string Combo_locationid_Dropdownoptionstype ;
      private string Combo_locationid_Titlecontrolidtoreplace ;
      private string Combo_locationid_Datalisttype ;
      private string Combo_locationid_Datalistfixedvalues ;
      private string Combo_locationid_Datalistprocparametersprefix ;
      private string Combo_locationid_Remoteservicesparameters ;
      private string Combo_locationid_Htmltemplate ;
      private string Combo_locationid_Multiplevaluestype ;
      private string Combo_locationid_Loadingdata ;
      private string Combo_locationid_Noresultsfound ;
      private string Combo_locationid_Emptyitemtext ;
      private string Combo_locationid_Onlyselectedvalues ;
      private string Combo_locationid_Selectalltext ;
      private string Combo_locationid_Multiplevaluesseparator ;
      private string Combo_locationid_Addnewoptiontext ;
      private string Combo_productserviceid_Objectcall ;
      private string Combo_productserviceid_Class ;
      private string Combo_productserviceid_Icontype ;
      private string Combo_productserviceid_Icon ;
      private string Combo_productserviceid_Tooltip ;
      private string Combo_productserviceid_Selectedvalue_set ;
      private string Combo_productserviceid_Selectedtext_set ;
      private string Combo_productserviceid_Selectedtext_get ;
      private string Combo_productserviceid_Gamoauthtoken ;
      private string Combo_productserviceid_Ddointernalname ;
      private string Combo_productserviceid_Titlecontrolalign ;
      private string Combo_productserviceid_Dropdownoptionstype ;
      private string Combo_productserviceid_Titlecontrolidtoreplace ;
      private string Combo_productserviceid_Datalisttype ;
      private string Combo_productserviceid_Datalistfixedvalues ;
      private string Combo_productserviceid_Datalistprocparametersprefix ;
      private string Combo_productserviceid_Remoteservicesparameters ;
      private string Combo_productserviceid_Htmltemplate ;
      private string Combo_productserviceid_Multiplevaluestype ;
      private string Combo_productserviceid_Loadingdata ;
      private string Combo_productserviceid_Noresultsfound ;
      private string Combo_productserviceid_Emptyitemtext ;
      private string Combo_productserviceid_Onlyselectedvalues ;
      private string Combo_productserviceid_Selectalltext ;
      private string Combo_productserviceid_Multiplevaluesseparator ;
      private string Combo_productserviceid_Addnewoptiontext ;
      private string Combo_organisationid_Objectcall ;
      private string Combo_organisationid_Class ;
      private string Combo_organisationid_Icontype ;
      private string Combo_organisationid_Icon ;
      private string Combo_organisationid_Tooltip ;
      private string Combo_organisationid_Selectedvalue_set ;
      private string Combo_organisationid_Selectedtext_set ;
      private string Combo_organisationid_Selectedtext_get ;
      private string Combo_organisationid_Gamoauthtoken ;
      private string Combo_organisationid_Ddointernalname ;
      private string Combo_organisationid_Titlecontrolalign ;
      private string Combo_organisationid_Dropdownoptionstype ;
      private string Combo_organisationid_Titlecontrolidtoreplace ;
      private string Combo_organisationid_Datalisttype ;
      private string Combo_organisationid_Datalistfixedvalues ;
      private string Combo_organisationid_Remoteservicesparameters ;
      private string Combo_organisationid_Htmltemplate ;
      private string Combo_organisationid_Multiplevaluestype ;
      private string Combo_organisationid_Loadingdata ;
      private string Combo_organisationid_Noresultsfound ;
      private string Combo_organisationid_Emptyitemtext ;
      private string Combo_organisationid_Onlyselectedvalues ;
      private string Combo_organisationid_Selectalltext ;
      private string Combo_organisationid_Multiplevaluesseparator ;
      private string Combo_organisationid_Addnewoptiontext ;
      private string hsh ;
      private string sMode98 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool Z434PageIsPublished ;
      private bool Z439PageIsContentPage ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n58ProductServiceId ;
      private bool wbErr ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool Combo_locationid_Emptyitem ;
      private bool Combo_organisationid_Emptyitem ;
      private bool Combo_locationid_Enabled ;
      private bool Combo_locationid_Visible ;
      private bool Combo_locationid_Allowmultipleselection ;
      private bool Combo_locationid_Isgriditem ;
      private bool Combo_locationid_Hasdescription ;
      private bool Combo_locationid_Includeonlyselectedoption ;
      private bool Combo_locationid_Includeselectalloption ;
      private bool Combo_locationid_Includeaddnewoption ;
      private bool Combo_productserviceid_Enabled ;
      private bool Combo_productserviceid_Visible ;
      private bool Combo_productserviceid_Allowmultipleselection ;
      private bool Combo_productserviceid_Isgriditem ;
      private bool Combo_productserviceid_Hasdescription ;
      private bool Combo_productserviceid_Includeonlyselectedoption ;
      private bool Combo_productserviceid_Includeselectalloption ;
      private bool Combo_productserviceid_Emptyitem ;
      private bool Combo_productserviceid_Includeaddnewoption ;
      private bool Combo_organisationid_Enabled ;
      private bool Combo_organisationid_Visible ;
      private bool Combo_organisationid_Allowmultipleselection ;
      private bool Combo_organisationid_Isgriditem ;
      private bool Combo_organisationid_Hasdescription ;
      private bool Combo_organisationid_Includeonlyselectedoption ;
      private bool Combo_organisationid_Includeselectalloption ;
      private bool Combo_organisationid_Includeaddnewoption ;
      private bool n431PageJsonContent ;
      private bool n432PageGJSHtml ;
      private bool n433PageGJSJson ;
      private bool n437PageChildren ;
      private bool returnInSub ;
      private bool i439PageIsContentPage ;
      private bool i434PageIsPublished ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string AV24Combo_DataJson ;
      private string Z431PageJsonContent ;
      private string Z432PageGJSHtml ;
      private string Z433PageGJSJson ;
      private string Z437PageChildren ;
      private string wcpOAV18Trn_PageName ;
      private string Z318Trn_PageName ;
      private string AV18Trn_PageName ;
      private string A318Trn_PageName ;
      private string AV22ComboSelectedValue ;
      private string AV23ComboSelectedText ;
      private Guid wcpOAV17Trn_PageId ;
      private Guid wcpOAV19LocationId ;
      private Guid Z310Trn_PageId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z58ProductServiceId ;
      private Guid N58ProductServiceId ;
      private Guid N11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid AV17Trn_PageId ;
      private Guid AV19LocationId ;
      private Guid A310Trn_PageId ;
      private Guid AV25ComboLocationId ;
      private Guid AV30ComboProductServiceId ;
      private Guid AV33ComboOrganisationId ;
      private Guid AV16Insert_ProductServiceId ;
      private Guid AV14Insert_OrganisationId ;
      private Guid AV13Insert_LocationId ;
      private Guid AV26Cond_OrganisationId ;
      private Guid AV31Cond_LocationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_locationid ;
      private GXUserControl ucCombo_productserviceid ;
      private GXUserControl ucCombo_organisationid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPageIsPublished ;
      private GXCombobox cmbPageIsContentPage ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20LocationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29ProductServiceId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32OrganisationId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV27GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV28GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00176_A310Trn_PageId ;
      private string[] T00176_A318Trn_PageName ;
      private string[] T00176_A431PageJsonContent ;
      private bool[] T00176_n431PageJsonContent ;
      private string[] T00176_A432PageGJSHtml ;
      private bool[] T00176_n432PageGJSHtml ;
      private string[] T00176_A433PageGJSJson ;
      private bool[] T00176_n433PageGJSJson ;
      private bool[] T00176_A434PageIsPublished ;
      private bool[] T00176_n434PageIsPublished ;
      private bool[] T00176_A439PageIsContentPage ;
      private bool[] T00176_n439PageIsContentPage ;
      private string[] T00176_A437PageChildren ;
      private bool[] T00176_n437PageChildren ;
      private Guid[] T00176_A29LocationId ;
      private Guid[] T00176_A11OrganisationId ;
      private Guid[] T00176_A58ProductServiceId ;
      private bool[] T00176_n58ProductServiceId ;
      private Guid[] T00174_A29LocationId ;
      private Guid[] T00175_A58ProductServiceId ;
      private bool[] T00175_n58ProductServiceId ;
      private string[] T00177_A318Trn_PageName ;
      private Guid[] T00178_A29LocationId ;
      private Guid[] T00179_A58ProductServiceId ;
      private bool[] T00179_n58ProductServiceId ;
      private Guid[] T001710_A310Trn_PageId ;
      private string[] T001710_A318Trn_PageName ;
      private Guid[] T001710_A29LocationId ;
      private Guid[] T00173_A310Trn_PageId ;
      private string[] T00173_A318Trn_PageName ;
      private string[] T00173_A431PageJsonContent ;
      private bool[] T00173_n431PageJsonContent ;
      private string[] T00173_A432PageGJSHtml ;
      private bool[] T00173_n432PageGJSHtml ;
      private string[] T00173_A433PageGJSJson ;
      private bool[] T00173_n433PageGJSJson ;
      private bool[] T00173_A434PageIsPublished ;
      private bool[] T00173_n434PageIsPublished ;
      private bool[] T00173_A439PageIsContentPage ;
      private bool[] T00173_n439PageIsContentPage ;
      private string[] T00173_A437PageChildren ;
      private bool[] T00173_n437PageChildren ;
      private Guid[] T00173_A29LocationId ;
      private Guid[] T00173_A11OrganisationId ;
      private Guid[] T00173_A58ProductServiceId ;
      private bool[] T00173_n58ProductServiceId ;
      private Guid[] T001711_A310Trn_PageId ;
      private string[] T001711_A318Trn_PageName ;
      private Guid[] T001711_A29LocationId ;
      private Guid[] T001712_A310Trn_PageId ;
      private string[] T001712_A318Trn_PageName ;
      private Guid[] T001712_A29LocationId ;
      private Guid[] T00172_A310Trn_PageId ;
      private string[] T00172_A318Trn_PageName ;
      private string[] T00172_A431PageJsonContent ;
      private bool[] T00172_n431PageJsonContent ;
      private string[] T00172_A432PageGJSHtml ;
      private bool[] T00172_n432PageGJSHtml ;
      private string[] T00172_A433PageGJSJson ;
      private bool[] T00172_n433PageGJSJson ;
      private bool[] T00172_A434PageIsPublished ;
      private bool[] T00172_n434PageIsPublished ;
      private bool[] T00172_A439PageIsContentPage ;
      private bool[] T00172_n439PageIsContentPage ;
      private string[] T00172_A437PageChildren ;
      private bool[] T00172_n437PageChildren ;
      private Guid[] T00172_A29LocationId ;
      private Guid[] T00172_A11OrganisationId ;
      private Guid[] T00172_A58ProductServiceId ;
      private bool[] T00172_n58ProductServiceId ;
      private Guid[] T001716_A310Trn_PageId ;
      private string[] T001716_A318Trn_PageName ;
      private Guid[] T001716_A29LocationId ;
      private string[] T001717_A318Trn_PageName ;
      private Guid[] T001718_A29LocationId ;
      private Guid[] T001719_A58ProductServiceId ;
      private bool[] T001719_n58ProductServiceId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_page__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_page__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_page__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00172;
       prmT00172 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00173;
       prmT00173 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00174;
       prmT00174 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00175;
       prmT00175 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00176;
       prmT00176 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00177;
       prmT00177 = new Object[] {
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00178;
       prmT00178 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00179;
       prmT00179 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001710;
       prmT001710 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001711;
       prmT001711 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001712;
       prmT001712 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001713;
       prmT001713 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001714;
       prmT001714 = new Object[] {
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001715;
       prmT001715 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001716;
       prmT001716 = new Object[] {
       };
       Object[] prmT001717;
       prmT001717 = new Object[] {
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001718;
       prmT001718 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001719;
       prmT001719 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00172", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, LocationId, OrganisationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName AND LocationId = :LocationId  FOR UPDATE OF Trn_Page NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00172,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00173", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, LocationId, OrganisationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00173,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00174", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00174,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00175", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00175,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00176", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsContentPage, TM1.PageChildren, TM1.LocationId, TM1.OrganisationId, TM1.ProductServiceId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId and TM1.Trn_PageName = ( :Trn_PageName) and TM1.LocationId = :LocationId ORDER BY TM1.Trn_PageId, TM1.Trn_PageName, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00176,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00177", "SELECT Trn_PageName FROM Trn_Page WHERE (Trn_PageName = :Trn_PageName AND LocationId = :LocationId) AND (Not ( Trn_PageId = :Trn_PageId and Trn_PageName = ( :Trn_PageName) and LocationId = :LocationId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00177,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00178", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00178,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00179", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00179,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001710", "SELECT Trn_PageId, Trn_PageName, LocationId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001710,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001711", "SELECT Trn_PageId, Trn_PageName, LocationId FROM Trn_Page WHERE ( Trn_PageId > :Trn_PageId or Trn_PageId = :Trn_PageId and Trn_PageName > ( :Trn_PageName) or Trn_PageName = ( :Trn_PageName) and Trn_PageId = :Trn_PageId and LocationId > :LocationId) ORDER BY Trn_PageId, Trn_PageName, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001711,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001712", "SELECT Trn_PageId, Trn_PageName, LocationId FROM Trn_Page WHERE ( Trn_PageId < :Trn_PageId or Trn_PageId = :Trn_PageId and Trn_PageName < ( :Trn_PageName) or Trn_PageName = ( :Trn_PageName) and Trn_PageId = :Trn_PageId and LocationId < :LocationId) ORDER BY Trn_PageId DESC, Trn_PageName DESC, LocationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001712,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001713", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, LocationId, OrganisationId, ProductServiceId) VALUES(:Trn_PageId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageIsContentPage, :PageChildren, :LocationId, :OrganisationId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001713)
          ,new CursorDef("T001714", "SAVEPOINT gxupdate;UPDATE Trn_Page SET PageJsonContent=:PageJsonContent, PageGJSHtml=:PageGJSHtml, PageGJSJson=:PageGJSJson, PageIsPublished=:PageIsPublished, PageIsContentPage=:PageIsContentPage, PageChildren=:PageChildren, OrganisationId=:OrganisationId, ProductServiceId=:ProductServiceId  WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001714)
          ,new CursorDef("T001715", "SAVEPOINT gxupdate;DELETE FROM Trn_Page  WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001715)
          ,new CursorDef("T001716", "SELECT Trn_PageId, Trn_PageName, LocationId FROM Trn_Page ORDER BY Trn_PageId, Trn_PageName, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001716,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001717", "SELECT Trn_PageName FROM Trn_Page WHERE (Trn_PageName = :Trn_PageName AND LocationId = :LocationId) AND (Not ( Trn_PageId = :Trn_PageId and Trn_PageName = ( :Trn_PageName) and LocationId = :LocationId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001717,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001718", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001718,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001719", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001719,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((Guid[]) buf[15])[0] = rslt.getGuid(10);
             ((Guid[]) buf[16])[0] = rslt.getGuid(11);
             ((bool[]) buf[17])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((Guid[]) buf[15])[0] = rslt.getGuid(10);
             ((Guid[]) buf[16])[0] = rslt.getGuid(11);
             ((bool[]) buf[17])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((Guid[]) buf[15])[0] = rslt.getGuid(10);
             ((Guid[]) buf[16])[0] = rslt.getGuid(11);
             ((bool[]) buf[17])[0] = rslt.wasNull(11);
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 15 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
