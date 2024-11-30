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
   public class trn_col : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A319Trn_RowId = StringUtil.StrToGuid( GetPar( "Trn_RowId"));
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A319Trn_RowId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A407TileId = StringUtil.StrToGuid( GetPar( "TileId"));
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A407TileId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_col.aspx")), "trn_col.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_col.aspx")))) ;
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
                  AV7Trn_ColId = StringUtil.StrToGuid( GetPar( "Trn_ColId"));
                  AssignAttri("", false, "AV7Trn_ColId", AV7Trn_ColId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_COLID", GetSecureSignedToken( "", AV7Trn_ColId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Col", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_ColId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_col( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_col( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_ColId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Trn_ColId = aP1_Trn_ColId;
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
            return "trn_col_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Col.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ColId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ColId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ColId_Internalname, A328Trn_ColId.ToString(), A328Trn_ColId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ColId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ColId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Col.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtrn_rowid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrn_rowid_Internalname, context.GetMessage( "Trn_Row", ""), "", "", lblTextblocktrn_rowid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Col.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_trn_rowid.SetProperty("Caption", Combo_trn_rowid_Caption);
         ucCombo_trn_rowid.SetProperty("Cls", Combo_trn_rowid_Cls);
         ucCombo_trn_rowid.SetProperty("DataListProc", Combo_trn_rowid_Datalistproc);
         ucCombo_trn_rowid.SetProperty("DataListProcParametersPrefix", Combo_trn_rowid_Datalistprocparametersprefix);
         ucCombo_trn_rowid.SetProperty("EmptyItem", Combo_trn_rowid_Emptyitem);
         ucCombo_trn_rowid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_trn_rowid.SetProperty("DropDownOptionsData", AV15Trn_RowId_Data);
         ucCombo_trn_rowid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_trn_rowid_Internalname, "COMBO_TRN_ROWIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_RowId_Internalname, context.GetMessage( "Trn_Row Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_RowId_Internalname, A319Trn_RowId.ToString(), A319Trn_RowId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_RowId_Jsonclick, 0, "Attribute", "", "", "", "", edtTrn_RowId_Visible, edtTrn_RowId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Col.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ColName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ColName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ColName_Internalname, A327Trn_ColName, StringUtil.RTrim( context.localUtil.Format( A327Trn_ColName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ColName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ColName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Col.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Col.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Col.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Col.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_trn_rowid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombotrn_rowid_Internalname, AV20ComboTrn_RowId.ToString(), AV20ComboTrn_RowId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotrn_rowid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotrn_rowid_Visible, edtavCombotrn_rowid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Col.htm");
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
         E11192 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTRN_ROWID_DATA"), AV15Trn_RowId_Data);
               /* Read saved values. */
               Z328Trn_ColId = StringUtil.StrToGuid( cgiGet( "Z328Trn_ColId"));
               Z327Trn_ColName = cgiGet( "Z327Trn_ColName");
               Z319Trn_RowId = StringUtil.StrToGuid( cgiGet( "Z319Trn_RowId"));
               Z407TileId = StringUtil.StrToGuid( cgiGet( "Z407TileId"));
               A407TileId = StringUtil.StrToGuid( cgiGet( "Z407TileId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N319Trn_RowId = StringUtil.StrToGuid( cgiGet( "N319Trn_RowId"));
               N407TileId = StringUtil.StrToGuid( cgiGet( "N407TileId"));
               AV7Trn_ColId = StringUtil.StrToGuid( cgiGet( "vTRN_COLID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_Trn_RowId = StringUtil.StrToGuid( cgiGet( "vINSERT_TRN_ROWID"));
               AV26Insert_TileId = StringUtil.StrToGuid( cgiGet( "vINSERT_TILEID"));
               A407TileId = StringUtil.StrToGuid( cgiGet( "TILEID"));
               AV27Pgmname = cgiGet( "vPGMNAME");
               Combo_trn_rowid_Objectcall = cgiGet( "COMBO_TRN_ROWID_Objectcall");
               Combo_trn_rowid_Class = cgiGet( "COMBO_TRN_ROWID_Class");
               Combo_trn_rowid_Icontype = cgiGet( "COMBO_TRN_ROWID_Icontype");
               Combo_trn_rowid_Icon = cgiGet( "COMBO_TRN_ROWID_Icon");
               Combo_trn_rowid_Caption = cgiGet( "COMBO_TRN_ROWID_Caption");
               Combo_trn_rowid_Tooltip = cgiGet( "COMBO_TRN_ROWID_Tooltip");
               Combo_trn_rowid_Cls = cgiGet( "COMBO_TRN_ROWID_Cls");
               Combo_trn_rowid_Selectedvalue_set = cgiGet( "COMBO_TRN_ROWID_Selectedvalue_set");
               Combo_trn_rowid_Selectedvalue_get = cgiGet( "COMBO_TRN_ROWID_Selectedvalue_get");
               Combo_trn_rowid_Selectedtext_set = cgiGet( "COMBO_TRN_ROWID_Selectedtext_set");
               Combo_trn_rowid_Selectedtext_get = cgiGet( "COMBO_TRN_ROWID_Selectedtext_get");
               Combo_trn_rowid_Gamoauthtoken = cgiGet( "COMBO_TRN_ROWID_Gamoauthtoken");
               Combo_trn_rowid_Ddointernalname = cgiGet( "COMBO_TRN_ROWID_Ddointernalname");
               Combo_trn_rowid_Titlecontrolalign = cgiGet( "COMBO_TRN_ROWID_Titlecontrolalign");
               Combo_trn_rowid_Dropdownoptionstype = cgiGet( "COMBO_TRN_ROWID_Dropdownoptionstype");
               Combo_trn_rowid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Enabled"));
               Combo_trn_rowid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Visible"));
               Combo_trn_rowid_Titlecontrolidtoreplace = cgiGet( "COMBO_TRN_ROWID_Titlecontrolidtoreplace");
               Combo_trn_rowid_Datalisttype = cgiGet( "COMBO_TRN_ROWID_Datalisttype");
               Combo_trn_rowid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Allowmultipleselection"));
               Combo_trn_rowid_Datalistfixedvalues = cgiGet( "COMBO_TRN_ROWID_Datalistfixedvalues");
               Combo_trn_rowid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Isgriditem"));
               Combo_trn_rowid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Hasdescription"));
               Combo_trn_rowid_Datalistproc = cgiGet( "COMBO_TRN_ROWID_Datalistproc");
               Combo_trn_rowid_Datalistprocparametersprefix = cgiGet( "COMBO_TRN_ROWID_Datalistprocparametersprefix");
               Combo_trn_rowid_Remoteservicesparameters = cgiGet( "COMBO_TRN_ROWID_Remoteservicesparameters");
               Combo_trn_rowid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TRN_ROWID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_trn_rowid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Includeonlyselectedoption"));
               Combo_trn_rowid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Includeselectalloption"));
               Combo_trn_rowid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Emptyitem"));
               Combo_trn_rowid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TRN_ROWID_Includeaddnewoption"));
               Combo_trn_rowid_Htmltemplate = cgiGet( "COMBO_TRN_ROWID_Htmltemplate");
               Combo_trn_rowid_Multiplevaluestype = cgiGet( "COMBO_TRN_ROWID_Multiplevaluestype");
               Combo_trn_rowid_Loadingdata = cgiGet( "COMBO_TRN_ROWID_Loadingdata");
               Combo_trn_rowid_Noresultsfound = cgiGet( "COMBO_TRN_ROWID_Noresultsfound");
               Combo_trn_rowid_Emptyitemtext = cgiGet( "COMBO_TRN_ROWID_Emptyitemtext");
               Combo_trn_rowid_Onlyselectedvalues = cgiGet( "COMBO_TRN_ROWID_Onlyselectedvalues");
               Combo_trn_rowid_Selectalltext = cgiGet( "COMBO_TRN_ROWID_Selectalltext");
               Combo_trn_rowid_Multiplevaluesseparator = cgiGet( "COMBO_TRN_ROWID_Multiplevaluesseparator");
               Combo_trn_rowid_Addnewoptiontext = cgiGet( "COMBO_TRN_ROWID_Addnewoptiontext");
               Combo_trn_rowid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TRN_ROWID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_ColId_Internalname), "") == 0 )
               {
                  A328Trn_ColId = Guid.Empty;
                  AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
               }
               else
               {
                  try
                  {
                     A328Trn_ColId = StringUtil.StrToGuid( cgiGet( edtTrn_ColId_Internalname));
                     AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_COLID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ColId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
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
               A327Trn_ColName = cgiGet( edtTrn_ColName_Internalname);
               AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
               AV20ComboTrn_RowId = StringUtil.StrToGuid( cgiGet( edtavCombotrn_rowid_Internalname));
               AssignAttri("", false, "AV20ComboTrn_RowId", AV20ComboTrn_RowId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Col");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A328Trn_ColId != Z328Trn_ColId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_col:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A328Trn_ColId = StringUtil.StrToGuid( GetPar( "Trn_ColId"));
                  AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7Trn_ColId) )
                  {
                     A328Trn_ColId = AV7Trn_ColId;
                     AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A328Trn_ColId) && ( Gx_BScreen == 0 ) )
                     {
                        A328Trn_ColId = Guid.NewGuid( );
                        AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
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
                     sMode72 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7Trn_ColId) )
                     {
                        A328Trn_ColId = AV7Trn_ColId;
                        AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A328Trn_ColId) && ( Gx_BScreen == 0 ) )
                        {
                           A328Trn_ColId = Guid.NewGuid( );
                           AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                        }
                     }
                     Gx_mode = sMode72;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound72 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_190( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_COLID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ColId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_TRN_ROWID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_trn_rowid.Onoptionclicked */
                           E12192 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11192 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13192 ();
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
            E13192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1972( ) ;
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
            DisableAttributes1972( ) ;
         }
         AssignProp("", false, edtavCombotrn_rowid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotrn_rowid_Enabled), 5, 0), true);
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1972( ) ;
            }
            else
            {
               CheckExtendedTable1972( ) ;
               CloseExtendedTableCursors1972( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption190( )
      {
      }

      protected void E11192( )
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
         Combo_trn_rowid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "GAMOAuthToken", Combo_trn_rowid_Gamoauthtoken);
         edtTrn_RowId_Visible = 0;
         AssignProp("", false, edtTrn_RowId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Visible), 5, 0), true);
         AV20ComboTrn_RowId = Guid.Empty;
         AssignAttri("", false, "AV20ComboTrn_RowId", AV20ComboTrn_RowId.ToString());
         edtavCombotrn_rowid_Visible = 0;
         AssignProp("", false, edtavCombotrn_rowid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotrn_rowid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTRN_ROWID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "Trn_RowId") == 0 )
               {
                  AV13Insert_Trn_RowId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_Trn_RowId", AV13Insert_Trn_RowId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_Trn_RowId) )
                  {
                     AV20ComboTrn_RowId = AV13Insert_Trn_RowId;
                     AssignAttri("", false, "AV20ComboTrn_RowId", AV20ComboTrn_RowId.ToString());
                     Combo_trn_rowid_Selectedvalue_set = StringUtil.Trim( AV20ComboTrn_RowId.ToString());
                     ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "SelectedValue_set", Combo_trn_rowid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new trn_colloaddvcombo(context ).execute(  "Trn_RowId",  "GET",  false,  AV7Trn_ColId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_trn_rowid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "SelectedText_set", Combo_trn_rowid_Selectedtext_set);
                     Combo_trn_rowid_Enabled = false;
                     ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_rowid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "TileId") == 0 )
               {
                  AV26Insert_TileId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV26Insert_TileId", AV26Insert_TileId.ToString());
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
      }

      protected void E13192( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_colww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12192( )
      {
         /* Combo_trn_rowid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboTrn_RowId = StringUtil.StrToGuid( Combo_trn_rowid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboTrn_RowId", AV20ComboTrn_RowId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTRN_ROWID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new trn_colloaddvcombo(context ).execute(  "Trn_RowId",  Gx_mode,  false,  AV7Trn_ColId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_trn_rowid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "SelectedValue_set", Combo_trn_rowid_Selectedvalue_set);
         Combo_trn_rowid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "SelectedText_set", Combo_trn_rowid_Selectedtext_set);
         AV20ComboTrn_RowId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboTrn_RowId", AV20ComboTrn_RowId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_trn_rowid_Enabled = false;
            ucCombo_trn_rowid.SendProperty(context, "", false, Combo_trn_rowid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_trn_rowid_Enabled));
         }
      }

      protected void ZM1972( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z327Trn_ColName = T00193_A327Trn_ColName[0];
               Z319Trn_RowId = T00193_A319Trn_RowId[0];
               Z407TileId = T00193_A407TileId[0];
            }
            else
            {
               Z327Trn_ColName = A327Trn_ColName;
               Z319Trn_RowId = A319Trn_RowId;
               Z407TileId = A407TileId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z328Trn_ColId = A328Trn_ColId;
            Z327Trn_ColName = A327Trn_ColName;
            Z319Trn_RowId = A319Trn_RowId;
            Z407TileId = A407TileId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV27Pgmname = "Trn_Col";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7Trn_ColId) )
         {
            edtTrn_ColId_Enabled = 0;
            AssignProp("", false, edtTrn_ColId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ColId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_ColId_Enabled = 1;
            AssignProp("", false, edtTrn_ColId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ColId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7Trn_ColId) )
         {
            edtTrn_ColId_Enabled = 0;
            AssignProp("", false, edtTrn_ColId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ColId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_Trn_RowId) )
         {
            edtTrn_RowId_Enabled = 0;
            AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_RowId_Enabled = 1;
            AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A327Trn_ColName = Guid.NewGuid( ).ToString();
         AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV26Insert_TileId) )
         {
            A407TileId = AV26Insert_TileId;
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_Trn_RowId) )
         {
            A319Trn_RowId = AV13Insert_Trn_RowId;
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         }
         else
         {
            A319Trn_RowId = AV20ComboTrn_RowId;
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
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
         if ( ! (Guid.Empty==AV7Trn_ColId) )
         {
            A328Trn_ColId = AV7Trn_ColId;
            AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A328Trn_ColId) && ( Gx_BScreen == 0 ) )
            {
               A328Trn_ColId = Guid.NewGuid( );
               AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1972( )
      {
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound72 = 1;
            A327Trn_ColName = T00196_A327Trn_ColName[0];
            AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
            A319Trn_RowId = T00196_A319Trn_RowId[0];
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            A407TileId = T00196_A407TileId[0];
            ZM1972( -14) ;
         }
         pr_default.close(4);
         OnLoadActions1972( ) ;
      }

      protected void OnLoadActions1972( )
      {
      }

      protected void CheckExtendedTable1972( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Row", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_ROWID");
            AnyError = 1;
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {A407TileId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TILEID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1972( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( Guid A319Trn_RowId )
      {
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Row", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_ROWID");
            AnyError = 1;
            GX_FocusControl = edtTrn_RowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_16( Guid A407TileId )
      {
         /* Using cursor T00198 */
         pr_default.execute(6, new Object[] {A407TileId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TILEID");
            AnyError = 1;
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

      protected void GetKey1972( )
      {
         /* Using cursor T00199 */
         pr_default.execute(7, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1972( 14) ;
            RcdFound72 = 1;
            A328Trn_ColId = T00193_A328Trn_ColId[0];
            AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
            A327Trn_ColName = T00193_A327Trn_ColName[0];
            AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
            A319Trn_RowId = T00193_A319Trn_RowId[0];
            AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
            A407TileId = T00193_A407TileId[0];
            Z328Trn_ColId = A328Trn_ColId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1972( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1972( ) ;
            }
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1972( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1972( ) ;
         if ( RcdFound72 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound72 = 0;
         /* Using cursor T001910 */
         pr_default.execute(8, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001910_A328Trn_ColId[0], A328Trn_ColId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001910_A328Trn_ColId[0], A328Trn_ColId, 0) > 0 ) ) )
            {
               A328Trn_ColId = T001910_A328Trn_ColId[0];
               AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
               RcdFound72 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound72 = 0;
         /* Using cursor T001911 */
         pr_default.execute(9, new Object[] {A328Trn_ColId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001911_A328Trn_ColId[0], A328Trn_ColId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001911_A328Trn_ColId[0], A328Trn_ColId, 0) < 0 ) ) )
            {
               A328Trn_ColId = T001911_A328Trn_ColId[0];
               AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
               RcdFound72 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1972( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_ColId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1972( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A328Trn_ColId != Z328Trn_ColId )
               {
                  A328Trn_ColId = Z328Trn_ColId;
                  AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_COLID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ColId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_ColId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1972( ) ;
                  GX_FocusControl = edtTrn_ColId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A328Trn_ColId != Z328Trn_ColId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_ColId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1972( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_COLID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ColId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_ColId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1972( ) ;
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
         if ( A328Trn_ColId != Z328Trn_ColId )
         {
            A328Trn_ColId = Z328Trn_ColId;
            AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_COLID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ColId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_ColId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1972( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A328Trn_ColId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z327Trn_ColName, T00192_A327Trn_ColName[0]) != 0 ) || ( Z319Trn_RowId != T00192_A319Trn_RowId[0] ) || ( Z407TileId != T00192_A407TileId[0] ) )
            {
               if ( StringUtil.StrCmp(Z327Trn_ColName, T00192_A327Trn_ColName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_col:[seudo value changed for attri]"+"Trn_ColName");
                  GXUtil.WriteLogRaw("Old: ",Z327Trn_ColName);
                  GXUtil.WriteLogRaw("Current: ",T00192_A327Trn_ColName[0]);
               }
               if ( Z319Trn_RowId != T00192_A319Trn_RowId[0] )
               {
                  GXUtil.WriteLog("trn_col:[seudo value changed for attri]"+"Trn_RowId");
                  GXUtil.WriteLogRaw("Old: ",Z319Trn_RowId);
                  GXUtil.WriteLogRaw("Current: ",T00192_A319Trn_RowId[0]);
               }
               if ( Z407TileId != T00192_A407TileId[0] )
               {
                  GXUtil.WriteLog("trn_col:[seudo value changed for attri]"+"TileId");
                  GXUtil.WriteLogRaw("Old: ",Z407TileId);
                  GXUtil.WriteLogRaw("Current: ",T00192_A407TileId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Col"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1972( )
      {
         if ( ! IsAuthorized("trn_col_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1972( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1972( 0) ;
            CheckOptimisticConcurrency1972( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1972( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1972( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001912 */
                     pr_default.execute(10, new Object[] {A328Trn_ColId, A327Trn_ColName, A319Trn_RowId, A407TileId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
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
               Load1972( ) ;
            }
            EndLevel1972( ) ;
         }
         CloseExtendedTableCursors1972( ) ;
      }

      protected void Update1972( )
      {
         if ( ! IsAuthorized("trn_col_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1972( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1972( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1972( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1972( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001913 */
                     pr_default.execute(11, new Object[] {A327Trn_ColName, A319Trn_RowId, A407TileId, A328Trn_ColId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1972( ) ;
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
            EndLevel1972( ) ;
         }
         CloseExtendedTableCursors1972( ) ;
      }

      protected void DeferredUpdate1972( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_col_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1972( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1972( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1972( ) ;
            AfterConfirm1972( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1972( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001914 */
                  pr_default.execute(12, new Object[] {A328Trn_ColId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1972( ) ;
         Gx_mode = sMode72;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1972( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1972( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1972( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_col",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_col",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1972( )
      {
         /* Scan By routine */
         /* Using cursor T001915 */
         pr_default.execute(13);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound72 = 1;
            A328Trn_ColId = T001915_A328Trn_ColId[0];
            AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1972( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound72 = 1;
            A328Trn_ColId = T001915_A328Trn_ColId[0];
            AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
         }
      }

      protected void ScanEnd1972( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1972( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1972( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1972( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1972( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1972( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1972( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1972( )
      {
         edtTrn_ColId_Enabled = 0;
         AssignProp("", false, edtTrn_ColId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ColId_Enabled), 5, 0), true);
         edtTrn_RowId_Enabled = 0;
         AssignProp("", false, edtTrn_RowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_RowId_Enabled), 5, 0), true);
         edtTrn_ColName_Enabled = 0;
         AssignProp("", false, edtTrn_ColName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ColName_Enabled), 5, 0), true);
         edtavCombotrn_rowid_Enabled = 0;
         AssignProp("", false, edtavCombotrn_rowid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotrn_rowid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1972( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
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
         GXEncryptionTmp = "trn_col.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_ColId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_col.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Col");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_col:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z328Trn_ColId", Z328Trn_ColId.ToString());
         GxWebStd.gx_hidden_field( context, "Z327Trn_ColName", Z327Trn_ColName);
         GxWebStd.gx_hidden_field( context, "Z319Trn_RowId", Z319Trn_RowId.ToString());
         GxWebStd.gx_hidden_field( context, "Z407TileId", Z407TileId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N319Trn_RowId", A319Trn_RowId.ToString());
         GxWebStd.gx_hidden_field( context, "N407TileId", A407TileId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_ROWID_DATA", AV15Trn_RowId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_ROWID_DATA", AV15Trn_RowId_Data);
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
         GxWebStd.gx_hidden_field( context, "vTRN_COLID", AV7Trn_ColId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_COLID", GetSecureSignedToken( "", AV7Trn_ColId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TRN_ROWID", AV13Insert_Trn_RowId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_TILEID", AV26Insert_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "TILEID", A407TileId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Objectcall", StringUtil.RTrim( Combo_trn_rowid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Cls", StringUtil.RTrim( Combo_trn_rowid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Selectedvalue_set", StringUtil.RTrim( Combo_trn_rowid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Selectedtext_set", StringUtil.RTrim( Combo_trn_rowid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Gamoauthtoken", StringUtil.RTrim( Combo_trn_rowid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Enabled", StringUtil.BoolToStr( Combo_trn_rowid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Datalistproc", StringUtil.RTrim( Combo_trn_rowid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_trn_rowid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TRN_ROWID_Emptyitem", StringUtil.BoolToStr( Combo_trn_rowid_Emptyitem));
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
         GXEncryptionTmp = "trn_col.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_ColId.ToString());
         return formatLink("trn_col.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Col" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Col", "") ;
      }

      protected void InitializeNonKey1972( )
      {
         A319Trn_RowId = Guid.Empty;
         AssignAttri("", false, "A319Trn_RowId", A319Trn_RowId.ToString());
         A407TileId = Guid.Empty;
         AssignAttri("", false, "A407TileId", A407TileId.ToString());
         A327Trn_ColName = "";
         AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
         Z327Trn_ColName = "";
         Z319Trn_RowId = Guid.Empty;
         Z407TileId = Guid.Empty;
      }

      protected void InitAll1972( )
      {
         A328Trn_ColId = Guid.NewGuid( );
         AssignAttri("", false, "A328Trn_ColId", A328Trn_ColId.ToString());
         InitializeNonKey1972( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A327Trn_ColName = i327Trn_ColName;
         AssignAttri("", false, "A327Trn_ColName", A327Trn_ColName);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241189422368", true, true);
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
         context.AddJavascriptSource("trn_col.js", "?20241189422370", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTrn_ColId_Internalname = "TRN_COLID";
         lblTextblocktrn_rowid_Internalname = "TEXTBLOCKTRN_ROWID";
         Combo_trn_rowid_Internalname = "COMBO_TRN_ROWID";
         edtTrn_RowId_Internalname = "TRN_ROWID";
         divTablesplittedtrn_rowid_Internalname = "TABLESPLITTEDTRN_ROWID";
         edtTrn_ColName_Internalname = "TRN_COLNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotrn_rowid_Internalname = "vCOMBOTRN_ROWID";
         divSectionattribute_trn_rowid_Internalname = "SECTIONATTRIBUTE_TRN_ROWID";
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
         Form.Caption = context.GetMessage( "Trn_Col", "");
         edtavCombotrn_rowid_Jsonclick = "";
         edtavCombotrn_rowid_Enabled = 0;
         edtavCombotrn_rowid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_ColName_Jsonclick = "";
         edtTrn_ColName_Enabled = 1;
         edtTrn_RowId_Jsonclick = "";
         edtTrn_RowId_Enabled = 1;
         edtTrn_RowId_Visible = 1;
         Combo_trn_rowid_Emptyitem = Convert.ToBoolean( 0);
         Combo_trn_rowid_Datalistprocparametersprefix = " \"ComboName\": \"Trn_RowId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_ColId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_trn_rowid_Datalistproc = "Trn_ColLoadDVCombo";
         Combo_trn_rowid_Cls = "ExtendedCombo Attribute";
         Combo_trn_rowid_Caption = "";
         Combo_trn_rowid_Enabled = Convert.ToBoolean( -1);
         edtTrn_ColId_Jsonclick = "";
         edtTrn_ColId_Enabled = 1;
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

      public void Valid_Trn_rowid( )
      {
         /* Using cursor T001916 */
         pr_default.execute(14, new Object[] {A319Trn_RowId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Row", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_ROWID");
            AnyError = 1;
            GX_FocusControl = edtTrn_RowId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Trn_ColId","fld":"vTRN_COLID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Trn_ColId","fld":"vTRN_COLID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13192","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_TRN_ROWID.ONOPTIONCLICKED","""{"handler":"E12192","iparms":[{"av":"Combo_trn_rowid_Selectedvalue_get","ctrl":"COMBO_TRN_ROWID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_TRN_ROWID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboTrn_RowId","fld":"vCOMBOTRN_ROWID"}]}""");
         setEventMetadata("VALID_TRN_COLID","""{"handler":"Valid_Trn_colid","iparms":[]}""");
         setEventMetadata("VALID_TRN_ROWID","""{"handler":"Valid_Trn_rowid","iparms":[{"av":"A319Trn_RowId","fld":"TRN_ROWID"}]}""");
         setEventMetadata("VALIDV_COMBOTRN_ROWID","""{"handler":"Validv_Combotrn_rowid","iparms":[]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7Trn_ColId = Guid.Empty;
         Z328Trn_ColId = Guid.Empty;
         Z327Trn_ColName = "";
         Z319Trn_RowId = Guid.Empty;
         Z407TileId = Guid.Empty;
         N319Trn_RowId = Guid.Empty;
         N407TileId = Guid.Empty;
         Combo_trn_rowid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A319Trn_RowId = Guid.Empty;
         A407TileId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A328Trn_ColId = Guid.Empty;
         lblTextblocktrn_rowid_Jsonclick = "";
         ucCombo_trn_rowid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15Trn_RowId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A327Trn_ColName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboTrn_RowId = Guid.Empty;
         AV13Insert_Trn_RowId = Guid.Empty;
         AV26Insert_TileId = Guid.Empty;
         AV27Pgmname = "";
         Combo_trn_rowid_Objectcall = "";
         Combo_trn_rowid_Class = "";
         Combo_trn_rowid_Icontype = "";
         Combo_trn_rowid_Icon = "";
         Combo_trn_rowid_Tooltip = "";
         Combo_trn_rowid_Selectedvalue_set = "";
         Combo_trn_rowid_Selectedtext_set = "";
         Combo_trn_rowid_Selectedtext_get = "";
         Combo_trn_rowid_Gamoauthtoken = "";
         Combo_trn_rowid_Ddointernalname = "";
         Combo_trn_rowid_Titlecontrolalign = "";
         Combo_trn_rowid_Dropdownoptionstype = "";
         Combo_trn_rowid_Titlecontrolidtoreplace = "";
         Combo_trn_rowid_Datalisttype = "";
         Combo_trn_rowid_Datalistfixedvalues = "";
         Combo_trn_rowid_Remoteservicesparameters = "";
         Combo_trn_rowid_Htmltemplate = "";
         Combo_trn_rowid_Multiplevaluestype = "";
         Combo_trn_rowid_Loadingdata = "";
         Combo_trn_rowid_Noresultsfound = "";
         Combo_trn_rowid_Emptyitemtext = "";
         Combo_trn_rowid_Onlyselectedvalues = "";
         Combo_trn_rowid_Selectalltext = "";
         Combo_trn_rowid_Multiplevaluesseparator = "";
         Combo_trn_rowid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode72 = "";
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
         T00196_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T00196_A327Trn_ColName = new string[] {""} ;
         T00196_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00196_A407TileId = new Guid[] {Guid.Empty} ;
         T00194_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00195_A407TileId = new Guid[] {Guid.Empty} ;
         T00197_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00198_A407TileId = new Guid[] {Guid.Empty} ;
         T00199_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T00193_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T00193_A327Trn_ColName = new string[] {""} ;
         T00193_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00193_A407TileId = new Guid[] {Guid.Empty} ;
         T001910_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T001911_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T00192_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T00192_A327Trn_ColName = new string[] {""} ;
         T00192_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         T00192_A407TileId = new Guid[] {Guid.Empty} ;
         T001915_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i327Trn_ColName = "";
         T001916_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_col__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_col__default(),
            new Object[][] {
                new Object[] {
               T00192_A328Trn_ColId, T00192_A327Trn_ColName, T00192_A319Trn_RowId, T00192_A407TileId
               }
               , new Object[] {
               T00193_A328Trn_ColId, T00193_A327Trn_ColName, T00193_A319Trn_RowId, T00193_A407TileId
               }
               , new Object[] {
               T00194_A319Trn_RowId
               }
               , new Object[] {
               T00195_A407TileId
               }
               , new Object[] {
               T00196_A328Trn_ColId, T00196_A327Trn_ColName, T00196_A319Trn_RowId, T00196_A407TileId
               }
               , new Object[] {
               T00197_A319Trn_RowId
               }
               , new Object[] {
               T00198_A407TileId
               }
               , new Object[] {
               T00199_A328Trn_ColId
               }
               , new Object[] {
               T001910_A328Trn_ColId
               }
               , new Object[] {
               T001911_A328Trn_ColId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001915_A328Trn_ColId
               }
               , new Object[] {
               T001916_A319Trn_RowId
               }
            }
         );
         Z328Trn_ColId = Guid.NewGuid( );
         A328Trn_ColId = Guid.NewGuid( );
         AV27Pgmname = "Trn_Col";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound72 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_ColId_Enabled ;
      private int edtTrn_RowId_Visible ;
      private int edtTrn_RowId_Enabled ;
      private int edtTrn_ColName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombotrn_rowid_Visible ;
      private int edtavCombotrn_rowid_Enabled ;
      private int Combo_trn_rowid_Datalistupdateminimumcharacters ;
      private int Combo_trn_rowid_Gxcontroltype ;
      private int AV28GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_trn_rowid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_ColId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_ColId_Jsonclick ;
      private string divTablesplittedtrn_rowid_Internalname ;
      private string lblTextblocktrn_rowid_Internalname ;
      private string lblTextblocktrn_rowid_Jsonclick ;
      private string Combo_trn_rowid_Caption ;
      private string Combo_trn_rowid_Cls ;
      private string Combo_trn_rowid_Datalistproc ;
      private string Combo_trn_rowid_Datalistprocparametersprefix ;
      private string Combo_trn_rowid_Internalname ;
      private string edtTrn_RowId_Internalname ;
      private string edtTrn_RowId_Jsonclick ;
      private string edtTrn_ColName_Internalname ;
      private string edtTrn_ColName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_trn_rowid_Internalname ;
      private string edtavCombotrn_rowid_Internalname ;
      private string edtavCombotrn_rowid_Jsonclick ;
      private string AV27Pgmname ;
      private string Combo_trn_rowid_Objectcall ;
      private string Combo_trn_rowid_Class ;
      private string Combo_trn_rowid_Icontype ;
      private string Combo_trn_rowid_Icon ;
      private string Combo_trn_rowid_Tooltip ;
      private string Combo_trn_rowid_Selectedvalue_set ;
      private string Combo_trn_rowid_Selectedtext_set ;
      private string Combo_trn_rowid_Selectedtext_get ;
      private string Combo_trn_rowid_Gamoauthtoken ;
      private string Combo_trn_rowid_Ddointernalname ;
      private string Combo_trn_rowid_Titlecontrolalign ;
      private string Combo_trn_rowid_Dropdownoptionstype ;
      private string Combo_trn_rowid_Titlecontrolidtoreplace ;
      private string Combo_trn_rowid_Datalisttype ;
      private string Combo_trn_rowid_Datalistfixedvalues ;
      private string Combo_trn_rowid_Remoteservicesparameters ;
      private string Combo_trn_rowid_Htmltemplate ;
      private string Combo_trn_rowid_Multiplevaluestype ;
      private string Combo_trn_rowid_Loadingdata ;
      private string Combo_trn_rowid_Noresultsfound ;
      private string Combo_trn_rowid_Emptyitemtext ;
      private string Combo_trn_rowid_Onlyselectedvalues ;
      private string Combo_trn_rowid_Selectalltext ;
      private string Combo_trn_rowid_Multiplevaluesseparator ;
      private string Combo_trn_rowid_Addnewoptiontext ;
      private string hsh ;
      private string sMode72 ;
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
      private bool Combo_trn_rowid_Emptyitem ;
      private bool Combo_trn_rowid_Enabled ;
      private bool Combo_trn_rowid_Visible ;
      private bool Combo_trn_rowid_Allowmultipleselection ;
      private bool Combo_trn_rowid_Isgriditem ;
      private bool Combo_trn_rowid_Hasdescription ;
      private bool Combo_trn_rowid_Includeonlyselectedoption ;
      private bool Combo_trn_rowid_Includeselectalloption ;
      private bool Combo_trn_rowid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z327Trn_ColName ;
      private string A327Trn_ColName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string i327Trn_ColName ;
      private Guid wcpOAV7Trn_ColId ;
      private Guid Z328Trn_ColId ;
      private Guid Z319Trn_RowId ;
      private Guid Z407TileId ;
      private Guid N319Trn_RowId ;
      private Guid N407TileId ;
      private Guid A319Trn_RowId ;
      private Guid A407TileId ;
      private Guid AV7Trn_ColId ;
      private Guid A328Trn_ColId ;
      private Guid AV20ComboTrn_RowId ;
      private Guid AV13Insert_Trn_RowId ;
      private Guid AV26Insert_TileId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_trn_rowid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Trn_RowId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00196_A328Trn_ColId ;
      private string[] T00196_A327Trn_ColName ;
      private Guid[] T00196_A319Trn_RowId ;
      private Guid[] T00196_A407TileId ;
      private Guid[] T00194_A319Trn_RowId ;
      private Guid[] T00195_A407TileId ;
      private Guid[] T00197_A319Trn_RowId ;
      private Guid[] T00198_A407TileId ;
      private Guid[] T00199_A328Trn_ColId ;
      private Guid[] T00193_A328Trn_ColId ;
      private string[] T00193_A327Trn_ColName ;
      private Guid[] T00193_A319Trn_RowId ;
      private Guid[] T00193_A407TileId ;
      private Guid[] T001910_A328Trn_ColId ;
      private Guid[] T001911_A328Trn_ColId ;
      private Guid[] T00192_A328Trn_ColId ;
      private string[] T00192_A327Trn_ColName ;
      private Guid[] T00192_A319Trn_RowId ;
      private Guid[] T00192_A407TileId ;
      private Guid[] T001915_A328Trn_ColId ;
      private Guid[] T001916_A319Trn_RowId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_col__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_col__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00192;
        prmT00192 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00193;
        prmT00193 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00194;
        prmT00194 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00195;
        prmT00195 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00196;
        prmT00196 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00197;
        prmT00197 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00198;
        prmT00198 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00199;
        prmT00199 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001910;
        prmT001910 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001911;
        prmT001911 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001912;
        prmT001912 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ColName",GXType.VarChar,100,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001913;
        prmT001913 = new Object[] {
        new ParDef("Trn_ColName",GXType.VarChar,100,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001914;
        prmT001914 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001915;
        prmT001915 = new Object[] {
        };
        Object[] prmT001916;
        prmT001916 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00192", "SELECT Trn_ColId, Trn_ColName, Trn_RowId, TileId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId  FOR UPDATE OF Trn_Col NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00193", "SELECT Trn_ColId, Trn_ColName, Trn_RowId, TileId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00194", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00195", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00196", "SELECT TM1.Trn_ColId, TM1.Trn_ColName, TM1.Trn_RowId, TM1.TileId FROM Trn_Col TM1 WHERE TM1.Trn_ColId = :Trn_ColId ORDER BY TM1.Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00197", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00198", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00198,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00199", "SELECT Trn_ColId FROM Trn_Col WHERE Trn_ColId = :Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00199,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001910", "SELECT Trn_ColId FROM Trn_Col WHERE ( Trn_ColId > :Trn_ColId) ORDER BY Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001911", "SELECT Trn_ColId FROM Trn_Col WHERE ( Trn_ColId < :Trn_ColId) ORDER BY Trn_ColId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001912", "SAVEPOINT gxupdate;INSERT INTO Trn_Col(Trn_ColId, Trn_ColName, Trn_RowId, TileId) VALUES(:Trn_ColId, :Trn_ColName, :Trn_RowId, :TileId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001912)
           ,new CursorDef("T001913", "SAVEPOINT gxupdate;UPDATE Trn_Col SET Trn_ColName=:Trn_ColName, Trn_RowId=:Trn_RowId, TileId=:TileId  WHERE Trn_ColId = :Trn_ColId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001913)
           ,new CursorDef("T001914", "SAVEPOINT gxupdate;DELETE FROM Trn_Col  WHERE Trn_ColId = :Trn_ColId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001914)
           ,new CursorDef("T001915", "SELECT Trn_ColId FROM Trn_Col ORDER BY Trn_ColId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001915,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001916", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_RowId = :Trn_RowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001916,1, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
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
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
