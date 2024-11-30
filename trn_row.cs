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
   public class trn_row : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A310Trn_PageId = StringUtil.StrToGuid( GetPar( "Trn_PageId"));
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A310Trn_PageId) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_row.aspx")), "trn_row.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_row.aspx")))) ;
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
                  AV7Trn_RowId = StringUtil.StrToGuid( GetPar( "Trn_RowId"));
                  AssignAttri("", false, "AV7Trn_RowId", AV7Trn_RowId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_ROWID", GetSecureSignedToken( "", AV7Trn_RowId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Row", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_row( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_row( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_RowId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Trn_RowId = aP1_Trn_RowId;
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
            return "trn_row_Execute" ;
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Row.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_RowId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_RowId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_RowId_Internalname, A319Trn_RowId.ToString(), A319Trn_RowId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_RowId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_RowId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Row.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtrn_pageid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrn_pageid_Internalname, context.GetMessage( "Trn_Page", ""), "", "", lblTextblocktrn_pageid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Row.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_trn_pageid.SetProperty("Caption", Combo_trn_pageid_Caption);
         ucCombo_trn_pageid.SetProperty("Cls", Combo_trn_pageid_Cls);
         ucCombo_trn_pageid.SetProperty("DataListProc", Combo_trn_pageid_Datalistproc);
         ucCombo_trn_pageid.SetProperty("DataListProcParametersPrefix", Combo_trn_pageid_Datalistprocparametersprefix);
         ucCombo_trn_pageid.SetProperty("EmptyItem", Combo_trn_pageid_Emptyitem);
         ucCombo_trn_pageid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_trn_pageid.SetProperty("DropDownOptionsData", AV15Trn_PageId_Data);
         ucCombo_trn_pageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_trn_pageid_Internalname, "COMBO_TRN_PAGEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_PageId_Internalname, context.GetMessage( "Trn_Page Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_PageId_Internalname, A310Trn_PageId.ToString(), A310Trn_PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageId_Jsonclick, 0, "Attribute", "", "", "", "", edtTrn_PageId_Visible, edtTrn_PageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Row.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_RowName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_RowName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_RowName_Internalname, A320Trn_RowName, StringUtil.RTrim( context.localUtil.Format( A320Trn_RowName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_RowName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_RowName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Row.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Row.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Row.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Row.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_trn_pageid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombotrn_pageid_Internalname, AV20ComboTrn_PageId.ToString(), AV20ComboTrn_PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotrn_pageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotrn_pageid_Visible, edtavCombotrn_pageid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Row.htm");
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
         E11182 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTRN_PAGEID_DATA"), AV15Trn_PageId_Data);
               /* Read saved values. */
               Z319Trn_RowId = StringUtil.StrToGuid( cgiGet( "Z319Trn_RowId"));
               Z320Trn_RowName = cgiGet( "Z320Trn_RowName");
               Z310Trn_PageId = StringUtil.StrToGuid( cgiGet( "Z310Trn_PageId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N310Trn_PageId = StringUtil.StrToGuid( cgiGet( "N310Trn_PageId"));
               AV7Trn_RowId = StringUtil.StrToGuid( cgiGet( "vTRN_ROWID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_Trn_PageId = StringUtil.StrToGuid( cgiGet( "vINSERT_TRN_PAGEID"));
               A318Trn_PageName = cgiGet( "TRN_PAGENAME");
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_trn_pageid_Objectcall = cgiGet( "COMBO_TRN_PAGEID_Objectcall");
               Combo_trn_pageid_Class = cgiGet( "COMBO_TRN_PAGEID_Class");
               Combo_trn_pageid_Icontype = cgiGet( "COMBO_TRN_PAGEID_Icontype");
               Combo_trn_pageid_Icon = cgiGet( "COMBO_TRN_PAGEID_Icon");
               Combo_trn_pageid_Caption = cgiGet( "COMBO_TRN_PAGEID_Caption");
               Combo_trn_pageid_Tooltip = cgiGet( "COMBO_TRN_PAGEID_Tooltip");
               Combo_trn_pageid_Cls = cgiGet( "COMBO_TRN_PAGEID_Cls");
               Combo_trn_pageid_Selectedvalue_set = cgiGet( "COMBO_TRN_PAGEID_Selectedvalue_set");
               Combo_trn_pageid_Selectedvalue_get = cgiGet( "COMBO_TRN_PAGEID_Selectedvalue_get");
               Combo_trn_pageid_Selectedtext_set = cgiGet( "COMBO_TRN_PAGEID_Selectedtext_set");
               Combo_trn_pageid_Selectedtext_get = cgiGet( "COMBO_TRN_PAGEID_Selectedtext_get");
               Combo_trn_pageid_Gamoauthtoken = cgiGet( "COMBO_TRN_PAGEID_Gamoauthtoken");
               Combo_trn_pageid_Ddointernalname = cgiGet( "COMBO_TRN_PAGEID_Ddointernalname");
               Combo_trn_pageid_Titlecontrolalign = cgiGet( "COMBO_TRN_PAGEID_Titlecontrolalign");
               Combo_trn_pageid_Dropdownoptionstype = cgiGet( "COMBO_TRN_PAGEID_Dropdownoptionstype");
               Combo_trn_pageid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Enabled"));
               Combo_trn_pageid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Visible"));
               Combo_trn_pageid_Titlecontrolidtoreplace = cgiGet( "COMBO_TRN_PAGEID_Titlecontrolidtoreplace");
               Combo_trn_pageid_Datalisttype = cgiGet( "COMBO_TRN_PAGEID_Datalisttype");
               Combo_trn_pageid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Allowmultipleselection"));
               Combo_trn_pageid_Datalistfixedvalues = cgiGet( "COMBO_TRN_PAGEID_Datalistfixedvalues");
               Combo_trn_pageid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Isgriditem"));
               Combo_trn_pageid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Hasdescription"));
               Combo_trn_pageid_Datalistproc = cgiGet( "COMBO_TRN_PAGEID_Datalistproc");
               Combo_trn_pageid_Datalistprocparametersprefix = cgiGet( "COMBO_TRN_PAGEID_Datalistprocparametersprefix");
               Combo_trn_pageid_Remoteservicesparameters = cgiGet( "COMBO_TRN_PAGEID_Remoteservicesparameters");
               Combo_trn_pageid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TRN_PAGEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_trn_pageid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Includeonlyselectedoption"));
               Combo_trn_pageid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Includeselectalloption"));
               Combo_trn_pageid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Emptyitem"));
               Combo_trn_pageid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_PAGEID_Includeaddnewoption"));
               Combo_trn_pageid_Htmltemplate = cgiGet( "COMBO_TRN_PAGEID_Htmltemplate");
               Combo_trn_pageid_Multiplevaluestype = cgiGet( "COMBO_TRN_PAGEID_Multiplevaluestype");
               Combo_trn_pageid_Loadingdata = cgiGet( "COMBO_TRN_PAGEID_Loadingdata");
               Combo_trn_pageid_Noresultsfound = cgiGet( "COMBO_TRN_PAGEID_Noresultsfound");
               Combo_trn_pageid_Emptyitemtext = cgiGet( "COMBO_TRN_PAGEID_Emptyitemtext");
               Combo_trn_pageid_Onlyselectedvalues = cgiGet( "COMBO_TRN_PAGEID_Onlyselectedvalues");
               Combo_trn_pageid_Selectalltext = cgiGet( "COMBO_TRN_PAGEID_Selectalltext");
               Combo_trn_pageid_Multiplevaluesseparator = cgiGet( "COMBO_TRN_PAGEID_Multiplevaluesseparator");
               Combo_trn_pageid_Addnewoptiontext = cgiGet( "COMBO_TRN_PAGEID_Addnewoptiontext");
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_RowId_Internalname), "") == 0 )
               {
                  A319Trn_RowId = Guid.Empty;
                  AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
               }
               else
               {
                  try
                  {
                     A319Trn_RowId = StringUtil.StrToGuid( cgiGet( edtTrn_RowId_Internalname));
                     AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_ROWID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_RowId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
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
               A320Trn_RowName = cgiGet( edtTrn_RowName_Internalname);
               AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
               AV20ComboTrn_PageId = StringUtil.StrToGuid( cgiGet( edtavCombotrn_pageid_Internalname));
               AssignAttri("", false, "AV20ComboTrn_PageId", AV20ComboTrn_PageId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Row");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A319Trn_RowId != Z319Trn_RowId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_row:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A319Trn_RowId = StringUtil.StrToGuid( GetPar( "Trn_RowId"));
                  AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7Trn_RowId) )
                  {
                     A319Trn_RowId = AV7Trn_RowId;
                     AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A319Trn_RowId) && ( Gx_BScreen == 0 ) )
                     {
                        A319Trn_RowId = Guid.NewGuid( );
                        AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
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
                     sMode70 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7Trn_RowId) )
                     {
                        A319Trn_RowId = AV7Trn_RowId;
                        AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A319Trn_RowId) && ( Gx_BScreen == 0 ) )
                        {
                           A319Trn_RowId = Guid.NewGuid( );
                           AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                        }
                     }
                     Gx_mode = sMode70;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound70 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_180( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_ROWID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_RowId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_TRN_PAGEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_trn_pageid.Onoptionclicked */
                           E12182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13182 ();
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
            E13182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1870( ) ;
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
            DisableAttributes1870( ) ;
         }
         AssignProp("", false, edtavCombotrn_pageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotrn_pageid_Enabled), 5, 0), true);
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1870( ) ;
            }
            else
            {
               CheckExtendedTable1870( ) ;
               CloseExtendedTableCursors1870( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption180( )
      {
      }

      protected void E11182( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_trn_pageid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "GAMOAuthToken", Combo_trn_pageid_Gamoauthtoken);
         edtTrn_PageId_Visible = 0;
         AssignProp("", false, edtTrn_PageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Visible), 5, 0), true);
         AV20ComboTrn_PageId = Guid.Empty;
         AssignAttri("", false, "AV20ComboTrn_PageId", AV20ComboTrn_PageId.ToString());
         edtavCombotrn_pageid_Visible = 0;
         AssignProp("", false, edtavCombotrn_pageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotrn_pageid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTRN_PAGEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "Trn_PageId") == 0 )
               {
                  AV13Insert_Trn_PageId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_Trn_PageId", AV13Insert_Trn_PageId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_Trn_PageId) )
                  {
                     AV20ComboTrn_PageId = AV13Insert_Trn_PageId;
                     AssignAttri("", false, "AV20ComboTrn_PageId", AV20ComboTrn_PageId.ToString());
                     Combo_trn_pageid_Selectedvalue_set = StringUtil.Trim( AV20ComboTrn_PageId.ToString());
                     ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "SelectedValue_set", Combo_trn_pageid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new trn_rowloaddvcombo(context ).execute(  "Trn_PageId",  "GET",  false,  AV7Trn_RowId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_trn_pageid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "SelectedText_set", Combo_trn_pageid_Selectedtext_set);
                     Combo_trn_pageid_Enabled = false;
                     ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_pageid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
      }

      protected void E13182( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_rowww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12182( )
      {
         /* Combo_trn_pageid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboTrn_PageId = StringUtil.StrToGuid( Combo_trn_pageid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboTrn_PageId", AV20ComboTrn_PageId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTRN_PAGEID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new trn_rowloaddvcombo(context ).execute(  "Trn_PageId",  Gx_mode,  false,  AV7Trn_RowId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_trn_pageid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "SelectedValue_set", Combo_trn_pageid_Selectedvalue_set);
         Combo_trn_pageid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "SelectedText_set", Combo_trn_pageid_Selectedtext_set);
         AV20ComboTrn_PageId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboTrn_PageId", AV20ComboTrn_PageId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_trn_pageid_Enabled = false;
            ucCombo_trn_pageid.SendProperty(context, "", false, Combo_trn_pageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_pageid_Enabled));
         }
      }

      protected void ZM1870( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z320Trn_RowName = T00183_A320Trn_RowName[0];
               Z310Trn_PageId = T00183_A310Trn_PageId[0];
            }
            else
            {
               Z320Trn_RowName = A320Trn_RowName;
               Z310Trn_PageId = A310Trn_PageId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z319Trn_RowId = A319Trn_RowId;
            Z320Trn_RowName = A320Trn_RowName;
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV23Pgmname = "Trn_Row";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7Trn_RowId) )
         {
            edtTrn_RowId_Enabled = 0;
            AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_RowId_Enabled = 1;
            AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7Trn_RowId) )
         {
            edtTrn_RowId_Enabled = 0;
            AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_Trn_PageId) )
         {
            edtTrn_PageId_Enabled = 0;
            AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_PageId_Enabled = 1;
            AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A320Trn_RowName = Guid.NewGuid( ).ToString();
         AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_Trn_PageId) )
         {
            A310Trn_PageId = AV13Insert_Trn_PageId;
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         }
         else
         {
            A310Trn_PageId = AV20ComboTrn_PageId;
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
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
         if ( ! (Guid.Empty==AV7Trn_RowId) )
         {
            A319Trn_RowId = AV7Trn_RowId;
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A319Trn_RowId) && ( Gx_BScreen == 0 ) )
            {
               A319Trn_RowId = Guid.NewGuid( );
               AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00184 */
            pr_default.execute(2, new Object[] {A310Trn_PageId});
            A318Trn_PageName = T00184_A318Trn_PageName[0];
            pr_default.close(2);
         }
      }

      protected void Load1870( )
      {
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound70 = 1;
            A320Trn_RowName = T00185_A320Trn_RowName[0];
            AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
            A318Trn_PageName = T00185_A318Trn_PageName[0];
            A310Trn_PageId = T00185_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            ZM1870( -12) ;
         }
         pr_default.close(3);
         OnLoadActions1870( ) ;
      }

      protected void OnLoadActions1870( )
      {
      }

      protected void CheckExtendedTable1870( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A318Trn_PageName = T00184_A318Trn_PageName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1870( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( Guid A310Trn_PageId )
      {
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A318Trn_PageName = T00186_A318Trn_PageName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A318Trn_PageName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1870( )
      {
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1870( 12) ;
            RcdFound70 = 1;
            A319Trn_RowId = T00183_A319Trn_RowId[0];
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            A320Trn_RowName = T00183_A320Trn_RowName[0];
            AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
            A310Trn_PageId = T00183_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            Z319Trn_RowId = A319Trn_RowId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1870( ) ;
            if ( AnyError == 1 )
            {
               RcdFound70 = 0;
               InitializeNonKey1870( ) ;
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1870( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1870( ) ;
         if ( RcdFound70 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound70 = 0;
         /* Using cursor T00188 */
         pr_default.execute(6, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00188_A319Trn_RowId[0], A319Trn_RowId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00188_A319Trn_RowId[0], A319Trn_RowId, 0) > 0 ) ) )
            {
               A319Trn_RowId = T00188_A319Trn_RowId[0];
               AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
               RcdFound70 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound70 = 0;
         /* Using cursor T00189 */
         pr_default.execute(7, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00189_A319Trn_RowId[0], A319Trn_RowId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00189_A319Trn_RowId[0], A319Trn_RowId, 0) < 0 ) ) )
            {
               A319Trn_RowId = T00189_A319Trn_RowId[0];
               AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
               RcdFound70 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1870( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1870( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound70 == 1 )
            {
               if ( A319Trn_RowId != Z319Trn_RowId )
               {
                  A319Trn_RowId = Z319Trn_RowId;
                  AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_ROWID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_RowId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_RowId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1870( ) ;
                  GX_FocusControl = edtTrn_RowId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A319Trn_RowId != Z319Trn_RowId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_RowId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1870( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_ROWID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_RowId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_RowId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1870( ) ;
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
         if ( A319Trn_RowId != Z319Trn_RowId )
         {
            A319Trn_RowId = Z319Trn_RowId;
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_ROWID");
            AnyError = 1;
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1870( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A319Trn_RowId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Row"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z320Trn_RowName, T00182_A320Trn_RowName[0]) != 0 ) || ( Z310Trn_PageId != T00182_A310Trn_PageId[0] ) )
            {
               if ( StringUtil.StrCmp(Z320Trn_RowName, T00182_A320Trn_RowName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_row:[seudo value changed for attri]"+"Trn_RowName");
                  GXUtil.WriteLogRaw("Old: ",Z320Trn_RowName);
                  GXUtil.WriteLogRaw("Current: ",T00182_A320Trn_RowName[0]);
               }
               if ( Z310Trn_PageId != T00182_A310Trn_PageId[0] )
               {
                  GXUtil.WriteLog("trn_row:[seudo value changed for attri]"+"Trn_PageId");
                  GXUtil.WriteLogRaw("Old: ",Z310Trn_PageId);
                  GXUtil.WriteLogRaw("Current: ",T00182_A310Trn_PageId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Row"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1870( )
      {
         if ( ! IsAuthorized("trn_row_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1870( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1870( 0) ;
            CheckOptimisticConcurrency1870( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1870( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1870( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001810 */
                     pr_default.execute(8, new Object[] {A319Trn_RowId, A320Trn_RowName, A310Trn_PageId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
                     if ( (pr_default.getStatus(8) == 1) )
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
               Load1870( ) ;
            }
            EndLevel1870( ) ;
         }
         CloseExtendedTableCursors1870( ) ;
      }

      protected void Update1870( )
      {
         if ( ! IsAuthorized("trn_row_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1870( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1870( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1870( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1870( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001811 */
                     pr_default.execute(9, new Object[] {A320Trn_RowName, A310Trn_PageId, A319Trn_RowId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Row"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1870( ) ;
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
            EndLevel1870( ) ;
         }
         CloseExtendedTableCursors1870( ) ;
      }

      protected void DeferredUpdate1870( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_row_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1870( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1870( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1870( ) ;
            AfterConfirm1870( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1870( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001812 */
                  pr_default.execute(10, new Object[] {A319Trn_RowId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1870( ) ;
         Gx_mode = sMode70;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1870( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001813 */
            pr_default.execute(11, new Object[] {A310Trn_PageId});
            A318Trn_PageName = T001813_A318Trn_PageName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001814 */
            pr_default.execute(12, new Object[] {A319Trn_RowId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1870( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1870( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_row",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_row",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1870( )
      {
         /* Scan By routine */
         /* Using cursor T001815 */
         pr_default.execute(13);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound70 = 1;
            A319Trn_RowId = T001815_A319Trn_RowId[0];
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1870( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound70 = 1;
            A319Trn_RowId = T001815_A319Trn_RowId[0];
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         }
      }

      protected void ScanEnd1870( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1870( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1870( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1870( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1870( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1870( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1870( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1870( )
      {
         edtTrn_RowId_Enabled = 0;
         AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         edtTrn_PageId_Enabled = 0;
         AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         edtTrn_RowName_Enabled = 0;
         AssignProp("", false, edtTrn_RowName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowName_Enabled), 5, 0), true);
         edtavCombotrn_pageid_Enabled = 0;
         AssignProp("", false, edtavCombotrn_pageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotrn_pageid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1870( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_row.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_RowId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_row.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Row");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_row:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z319Trn_RowId", Z319Trn_RowId.ToString());
         GxWebStd.gx_hidden_field( context, "Z320Trn_RowName", Z320Trn_RowName);
         GxWebStd.gx_hidden_field( context, "Z310Trn_PageId", Z310Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N310Trn_PageId", A310Trn_PageId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_PAGEID_DATA", AV15Trn_PageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_PAGEID_DATA", AV15Trn_PageId_Data);
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
         GxWebStd.gx_hidden_field( context, "vTRN_ROWID", AV7Trn_RowId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_ROWID", GetSecureSignedToken( "", AV7Trn_RowId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TRN_PAGEID", AV13Insert_Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "TRN_PAGENAME", A318Trn_PageName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Objectcall", StringUtil.RTrim( Combo_trn_pageid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Cls", StringUtil.RTrim( Combo_trn_pageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_trn_pageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Selectedtext_set", StringUtil.RTrim( Combo_trn_pageid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Gamoauthtoken", StringUtil.RTrim( Combo_trn_pageid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Enabled", StringUtil.BoolToStr( Combo_trn_pageid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Datalistproc", StringUtil.RTrim( Combo_trn_pageid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_trn_pageid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_PAGEID_Emptyitem", StringUtil.BoolToStr( Combo_trn_pageid_Emptyitem));
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_row.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_RowId.ToString());
         return formatLink("trn_row.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Row" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Row", "") ;
      }

      protected void InitializeNonKey1870( )
      {
         A310Trn_PageId = Guid.Empty;
         AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         A320Trn_RowName = "";
         AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
         A318Trn_PageName = "";
         AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
         Z320Trn_RowName = "";
         Z310Trn_PageId = Guid.Empty;
      }

      protected void InitAll1870( )
      {
         A319Trn_RowId = Guid.NewGuid( );
         AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         InitializeNonKey1870( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A320Trn_RowName = i320Trn_RowName;
         AssignAttri("", false, "A320Trn_RowName", A320Trn_RowName);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241161037873", true, true);
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
         context.AddJavascriptSource("trn_row.js", "?20241161037874", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTrn_RowId_Internalname = "TRN_ROWID";
         lblTextblocktrn_pageid_Internalname = "TEXTBLOCKTRN_PAGEID";
         Combo_trn_pageid_Internalname = "COMBO_TRN_PAGEID";
         edtTrn_PageId_Internalname = "TRN_PAGEID";
         divTablesplittedtrn_pageid_Internalname = "TABLESPLITTEDTRN_PAGEID";
         edtTrn_RowName_Internalname = "TRN_ROWNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotrn_pageid_Internalname = "vCOMBOTRN_PAGEID";
         divSectionattribute_trn_pageid_Internalname = "SECTIONATTRIBUTE_TRN_PAGEID";
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
         Form.Caption = context.GetMessage( "Trn_Row", "");
         edtavCombotrn_pageid_Jsonclick = "";
         edtavCombotrn_pageid_Enabled = 0;
         edtavCombotrn_pageid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_RowName_Jsonclick = "";
         edtTrn_RowName_Enabled = 1;
         edtTrn_PageId_Jsonclick = "";
         edtTrn_PageId_Enabled = 1;
         edtTrn_PageId_Visible = 1;
         Combo_trn_pageid_Emptyitem = Convert.ToBoolean( 0);
         Combo_trn_pageid_Datalistprocparametersprefix = " \"ComboName\": \"Trn_PageId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_RowId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_trn_pageid_Datalistproc = "Trn_RowLoadDVCombo";
         Combo_trn_pageid_Cls = "ExtendedCombo Attribute";
         Combo_trn_pageid_Caption = "";
         Combo_trn_pageid_Enabled = Convert.ToBoolean( -1);
         edtTrn_RowId_Jsonclick = "";
         edtTrn_RowId_Enabled = 1;
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

      public void Valid_Trn_pageid( )
      {
         /* Using cursor T001813 */
         pr_default.execute(11, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
         }
         A318Trn_PageName = T001813_A318Trn_PageName[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Trn_RowId","fld":"vTRN_ROWID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Trn_RowId","fld":"vTRN_ROWID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13182","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_TRN_PAGEID.ONOPTIONCLICKED","""{"handler":"E12182","iparms":[{"av":"Combo_trn_pageid_Selectedvalue_get","ctrl":"COMBO_TRN_PAGEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_TRN_PAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboTrn_PageId","fld":"vCOMBOTRN_PAGEID"}]}""");
         setEventMetadata("VALID_TRN_ROWID","""{"handler":"Valid_Trn_rowid","iparms":[]}""");
         setEventMetadata("VALID_TRN_PAGEID","""{"handler":"Valid_Trn_pageid","iparms":[{"av":"A310Trn_PageId","fld":"TRN_PAGEID"},{"av":"A318Trn_PageName","fld":"TRN_PAGENAME"}]""");
         setEventMetadata("VALID_TRN_PAGEID",""","oparms":[{"av":"A318Trn_PageName","fld":"TRN_PAGENAME"}]}""");
         setEventMetadata("VALIDV_COMBOTRN_PAGEID","""{"handler":"Validv_Combotrn_pageid","iparms":[]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7Trn_RowId = Guid.Empty;
         Z319Trn_RowId = Guid.Empty;
         Z320Trn_RowName = "";
         Z310Trn_PageId = Guid.Empty;
         N310Trn_PageId = Guid.Empty;
         Combo_trn_pageid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A310Trn_PageId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A319Trn_RowId = Guid.Empty;
         lblTextblocktrn_pageid_Jsonclick = "";
         ucCombo_trn_pageid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15Trn_PageId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A320Trn_RowName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboTrn_PageId = Guid.Empty;
         AV13Insert_Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         AV23Pgmname = "";
         Combo_trn_pageid_Objectcall = "";
         Combo_trn_pageid_Class = "";
         Combo_trn_pageid_Icontype = "";
         Combo_trn_pageid_Icon = "";
         Combo_trn_pageid_Tooltip = "";
         Combo_trn_pageid_Selectedvalue_set = "";
         Combo_trn_pageid_Selectedtext_set = "";
         Combo_trn_pageid_Selectedtext_get = "";
         Combo_trn_pageid_Gamoauthtoken = "";
         Combo_trn_pageid_Ddointernalname = "";
         Combo_trn_pageid_Titlecontrolalign = "";
         Combo_trn_pageid_Dropdownoptionstype = "";
         Combo_trn_pageid_Titlecontrolidtoreplace = "";
         Combo_trn_pageid_Datalisttype = "";
         Combo_trn_pageid_Datalistfixedvalues = "";
         Combo_trn_pageid_Remoteservicesparameters = "";
         Combo_trn_pageid_Htmltemplate = "";
         Combo_trn_pageid_Multiplevaluestype = "";
         Combo_trn_pageid_Loadingdata = "";
         Combo_trn_pageid_Noresultsfound = "";
         Combo_trn_pageid_Emptyitemtext = "";
         Combo_trn_pageid_Onlyselectedvalues = "";
         Combo_trn_pageid_Selectalltext = "";
         Combo_trn_pageid_Multiplevaluesseparator = "";
         Combo_trn_pageid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode70 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z318Trn_PageName = "";
         T00184_A318Trn_PageName = new string[] {""} ;
         T00185_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00185_A320Trn_RowName = new string[] {""} ;
         T00185_A318Trn_PageName = new string[] {""} ;
         T00185_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00186_A318Trn_PageName = new string[] {""} ;
         T00187_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00183_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00183_A320Trn_RowName = new string[] {""} ;
         T00183_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00188_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00189_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00182_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00182_A320Trn_RowName = new string[] {""} ;
         T00182_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001813_A318Trn_PageName = new string[] {""} ;
         T001814_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T001815_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i320Trn_RowName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_row__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_row__default(),
            new Object[][] {
                new Object[] {
               T00182_A319Trn_RowId, T00182_A320Trn_RowName, T00182_A310Trn_PageId
               }
               , new Object[] {
               T00183_A319Trn_RowId, T00183_A320Trn_RowName, T00183_A310Trn_PageId
               }
               , new Object[] {
               T00184_A318Trn_PageName
               }
               , new Object[] {
               T00185_A319Trn_RowId, T00185_A320Trn_RowName, T00185_A318Trn_PageName, T00185_A310Trn_PageId
               }
               , new Object[] {
               T00186_A318Trn_PageName
               }
               , new Object[] {
               T00187_A319Trn_RowId
               }
               , new Object[] {
               T00188_A319Trn_RowId
               }
               , new Object[] {
               T00189_A319Trn_RowId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001813_A318Trn_PageName
               }
               , new Object[] {
               T001814_A328Trn_ColId
               }
               , new Object[] {
               T001815_A319Trn_RowId
               }
            }
         );
         Z319Trn_RowId = Guid.NewGuid( );
         A319Trn_RowId = Guid.NewGuid( );
         AV23Pgmname = "Trn_Row";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound70 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_RowId_Enabled ;
      private int edtTrn_PageId_Visible ;
      private int edtTrn_PageId_Enabled ;
      private int edtTrn_RowName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombotrn_pageid_Visible ;
      private int edtavCombotrn_pageid_Enabled ;
      private int Combo_trn_pageid_Datalistupdateminimumcharacters ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_trn_pageid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_RowId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_RowId_Jsonclick ;
      private string divTablesplittedtrn_pageid_Internalname ;
      private string lblTextblocktrn_pageid_Internalname ;
      private string lblTextblocktrn_pageid_Jsonclick ;
      private string Combo_trn_pageid_Caption ;
      private string Combo_trn_pageid_Cls ;
      private string Combo_trn_pageid_Datalistproc ;
      private string Combo_trn_pageid_Datalistprocparametersprefix ;
      private string Combo_trn_pageid_Internalname ;
      private string edtTrn_PageId_Internalname ;
      private string edtTrn_PageId_Jsonclick ;
      private string edtTrn_RowName_Internalname ;
      private string edtTrn_RowName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_trn_pageid_Internalname ;
      private string edtavCombotrn_pageid_Internalname ;
      private string edtavCombotrn_pageid_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_trn_pageid_Objectcall ;
      private string Combo_trn_pageid_Class ;
      private string Combo_trn_pageid_Icontype ;
      private string Combo_trn_pageid_Icon ;
      private string Combo_trn_pageid_Tooltip ;
      private string Combo_trn_pageid_Selectedvalue_set ;
      private string Combo_trn_pageid_Selectedtext_set ;
      private string Combo_trn_pageid_Selectedtext_get ;
      private string Combo_trn_pageid_Gamoauthtoken ;
      private string Combo_trn_pageid_Ddointernalname ;
      private string Combo_trn_pageid_Titlecontrolalign ;
      private string Combo_trn_pageid_Dropdownoptionstype ;
      private string Combo_trn_pageid_Titlecontrolidtoreplace ;
      private string Combo_trn_pageid_Datalisttype ;
      private string Combo_trn_pageid_Datalistfixedvalues ;
      private string Combo_trn_pageid_Remoteservicesparameters ;
      private string Combo_trn_pageid_Htmltemplate ;
      private string Combo_trn_pageid_Multiplevaluestype ;
      private string Combo_trn_pageid_Loadingdata ;
      private string Combo_trn_pageid_Noresultsfound ;
      private string Combo_trn_pageid_Emptyitemtext ;
      private string Combo_trn_pageid_Onlyselectedvalues ;
      private string Combo_trn_pageid_Selectalltext ;
      private string Combo_trn_pageid_Multiplevaluesseparator ;
      private string Combo_trn_pageid_Addnewoptiontext ;
      private string hsh ;
      private string sMode70 ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_trn_pageid_Emptyitem ;
      private bool Combo_trn_pageid_Enabled ;
      private bool Combo_trn_pageid_Visible ;
      private bool Combo_trn_pageid_Allowmultipleselection ;
      private bool Combo_trn_pageid_Isgriditem ;
      private bool Combo_trn_pageid_Hasdescription ;
      private bool Combo_trn_pageid_Includeonlyselectedoption ;
      private bool Combo_trn_pageid_Includeselectalloption ;
      private bool Combo_trn_pageid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z320Trn_RowName ;
      private string A320Trn_RowName ;
      private string A318Trn_PageName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z318Trn_PageName ;
      private string i320Trn_RowName ;
      private Guid wcpOAV7Trn_RowId ;
      private Guid Z319Trn_RowId ;
      private Guid Z310Trn_PageId ;
      private Guid N310Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid AV7Trn_RowId ;
      private Guid A319Trn_RowId ;
      private Guid AV20ComboTrn_PageId ;
      private Guid AV13Insert_Trn_PageId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_trn_pageid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Trn_PageId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00184_A318Trn_PageName ;
      private Guid[] T00185_A319Trn_RowId ;
      private string[] T00185_A320Trn_RowName ;
      private string[] T00185_A318Trn_PageName ;
      private Guid[] T00185_A310Trn_PageId ;
      private string[] T00186_A318Trn_PageName ;
      private Guid[] T00187_A319Trn_RowId ;
      private Guid[] T00183_A319Trn_RowId ;
      private string[] T00183_A320Trn_RowName ;
      private Guid[] T00183_A310Trn_PageId ;
      private Guid[] T00188_A319Trn_RowId ;
      private Guid[] T00189_A319Trn_RowId ;
      private Guid[] T00182_A319Trn_RowId ;
      private string[] T00182_A320Trn_RowName ;
      private Guid[] T00182_A310Trn_PageId ;
      private string[] T001813_A318Trn_PageName ;
      private Guid[] T001814_A328Trn_ColId ;
      private Guid[] T001815_A319Trn_RowId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_row__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_row__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00182;
        prmT00182 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00183;
        prmT00183 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00184;
        prmT00184 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00185;
        prmT00185 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00186;
        prmT00186 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00187;
        prmT00187 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00188;
        prmT00188 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00189;
        prmT00189 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001810;
        prmT001810 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001811;
        prmT001811 = new Object[] {
        new ParDef("Trn_RowName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001812;
        prmT001812 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001813;
        prmT001813 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001814;
        prmT001814 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001815;
        prmT001815 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00182", "SELECT Trn_RowId, Trn_RowName, Trn_PageId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId  FOR UPDATE OF Trn_Row NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00183", "SELECT Trn_RowId, Trn_RowName, Trn_PageId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00184", "SELECT Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00185", "SELECT TM1.Trn_RowId, TM1.Trn_RowName, T2.Trn_PageName, TM1.Trn_PageId FROM (Trn_Row TM1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.Trn_PageId) WHERE TM1.Trn_RowId = :Trn_RowId ORDER BY TM1.Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00186", "SELECT Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00187", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00188", "SELECT Trn_RowId FROM Trn_Row WHERE ( Trn_RowId > :Trn_RowId) ORDER BY Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00188,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00189", "SELECT Trn_RowId FROM Trn_Row WHERE ( Trn_RowId < :Trn_RowId) ORDER BY Trn_RowId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00189,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001810", "SAVEPOINT gxupdate;INSERT INTO Trn_Row(Trn_RowId, Trn_RowName, Trn_PageId) VALUES(:Trn_RowId, :Trn_RowName, :Trn_PageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001810)
           ,new CursorDef("T001811", "SAVEPOINT gxupdate;UPDATE Trn_Row SET Trn_RowName=:Trn_RowName, Trn_PageId=:Trn_PageId  WHERE Trn_RowId = :Trn_RowId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001811)
           ,new CursorDef("T001812", "SAVEPOINT gxupdate;DELETE FROM Trn_Row  WHERE Trn_RowId = :Trn_RowId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001812)
           ,new CursorDef("T001813", "SELECT Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001813,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001814", "SELECT Trn_ColId FROM Trn_Col WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001814,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001815", "SELECT Trn_RowId FROM Trn_Row ORDER BY Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001815,100, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
