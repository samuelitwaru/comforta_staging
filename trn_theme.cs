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
   public class trn_theme : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
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
            gxLoad_18( A11OrganisationId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_ctacolor") == 0 )
         {
            gxnrGridlevel_ctacolor_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_icon") == 0 )
         {
            gxnrGridlevel_icon_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_color") == 0 )
         {
            gxnrGridlevel_color_newrow_invoke( ) ;
            return  ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_theme.aspx")), "trn_theme.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_theme.aspx")))) ;
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
                  AV13Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  AssignAttri("", false, "AV13Trn_ThemeId", AV13Trn_ThemeId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV13Trn_ThemeId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Theme", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_ctacolor_newrow_invoke( )
      {
         nRC_GXsfl_42 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_42"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_42_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_42_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_42_idx = GetPar( "sGXsfl_42_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_ctacolor_newrow( ) ;
         /* End function gxnrGridlevel_ctacolor_newrow_invoke */
      }

      protected void gxnrGridlevel_icon_newrow_invoke( )
      {
         nRC_GXsfl_51 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_51"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_51_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_51_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_51_idx = GetPar( "sGXsfl_51_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_icon_newrow( ) ;
         /* End function gxnrGridlevel_icon_newrow_invoke */
      }

      protected void gxnrGridlevel_color_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_color_newrow( ) ;
         /* End function gxnrGridlevel_color_newrow_invoke */
      }

      public trn_theme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_ThemeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13Trn_ThemeId = aP1_Trn_ThemeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbIconCategory = new GXCombobox();
         cmbColorName = new GXCombobox();
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
            return "trn_theme_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Theme.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeId_Internalname, A247Trn_ThemeId.ToString(), A247Trn_ThemeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeName_Internalname, A248Trn_ThemeName, StringUtil.RTrim( context.localUtil.Format( A248Trn_ThemeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontFamily_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontFamily_Internalname, context.GetMessage( "Font Family", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontFamily_Internalname, A260Trn_ThemeFontFamily, StringUtil.RTrim( context.localUtil.Format( A260Trn_ThemeFontFamily, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontFamily_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontFamily_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontSize_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontSize_Internalname, context.GetMessage( "Font Size", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontSize_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A399Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTrn_ThemeFontSize_Enabled!=0) ? context.localUtil.Format( (decimal)(A399Trn_ThemeFontSize), "ZZZ9") : context.localUtil.Format( (decimal)(A399Trn_ThemeFontSize), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontSize_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontSize_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Theme.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_ctacolor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_ctacolor( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_icon_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_icon( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Colors", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_color_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_color( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_ctacolor( )
      {
         /*  Grid Control  */
         StartGridControl42( ) ;
         nGXsfl_42_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount112 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_112 = 1;
               ScanStart0W112( ) ;
               while ( RcdFound112 != 0 )
               {
                  init_level_properties112( ) ;
                  getByPrimaryKey0W112( ) ;
                  AddRow0W112( ) ;
                  ScanNext0W112( ) ;
               }
               ScanEnd0W112( ) ;
               nBlankRcdCount112 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0W112( ) ;
            standaloneModal0W112( ) ;
            sMode112 = Gx_mode;
            while ( nGXsfl_42_idx < nRC_GXsfl_42 )
            {
               bGXsfl_42_Refreshing = true;
               ReadRow0W112( ) ;
               edtCtaColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORID_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               edtCtaColorName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorName_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               edtCtaColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorCode_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               if ( ( nRcdExists_112 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0W112( ) ;
               }
               SendRow0W112( ) ;
               bGXsfl_42_Refreshing = false;
            }
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount112 = 5;
            nRcdExists_112 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0W112( ) ;
               while ( RcdFound112 != 0 )
               {
                  sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_42112( ) ;
                  init_level_properties112( ) ;
                  standaloneNotModal0W112( ) ;
                  getByPrimaryKey0W112( ) ;
                  standaloneModal0W112( ) ;
                  AddRow0W112( ) ;
                  ScanNext0W112( ) ;
               }
               ScanEnd0W112( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode112 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx+1), 4, 0), 4, "0");
            SubsflControlProps_42112( ) ;
            InitAll0W112( ) ;
            init_level_properties112( ) ;
            nRcdExists_112 = 0;
            nIsMod_112 = 0;
            nRcdDeleted_112 = 0;
            nBlankRcdCount112 = (short)(nBlankRcdUsr112+nBlankRcdCount112);
            fRowAdded = 0;
            while ( nBlankRcdCount112 > 0 )
            {
               A563CtaColorId = Guid.Empty;
               standaloneNotModal0W112( ) ;
               standaloneModal0W112( ) ;
               AddRow0W112( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCtaColorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount112 = (short)(nBlankRcdCount112-1);
            }
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_ctacolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_ctacolor", Gridlevel_ctacolorContainer, subGridlevel_ctacolor_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_ctacolorContainerData", Gridlevel_ctacolorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_ctacolorContainerData"+"V", Gridlevel_ctacolorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_ctacolorContainerData"+"V"+"\" value='"+Gridlevel_ctacolorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_icon( )
      {
         /*  Grid Control  */
         StartGridControl51( ) ;
         nGXsfl_51_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount87 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_87 = 1;
               ScanStart0W87( ) ;
               while ( RcdFound87 != 0 )
               {
                  init_level_properties87( ) ;
                  getByPrimaryKey0W87( ) ;
                  AddRow0W87( ) ;
                  ScanNext0W87( ) ;
               }
               ScanEnd0W87( ) ;
               nBlankRcdCount87 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0W87( ) ;
            standaloneModal0W87( ) ;
            sMode87 = Gx_mode;
            while ( nGXsfl_51_idx < nRC_GXsfl_51 )
            {
               bGXsfl_51_Refreshing = true;
               ReadRow0W87( ) ;
               edtIconId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONID_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconId_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtIconName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONNAME_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconName_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               cmbIconCategory.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbIconCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIconCategory.Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtIconSVG_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONSVG_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconSVG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconSVG_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               if ( ( nRcdExists_87 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0W87( ) ;
               }
               SendRow0W87( ) ;
               bGXsfl_51_Refreshing = false;
            }
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount87 = 5;
            nRcdExists_87 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0W87( ) ;
               while ( RcdFound87 != 0 )
               {
                  sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5187( ) ;
                  init_level_properties87( ) ;
                  standaloneNotModal0W87( ) ;
                  getByPrimaryKey0W87( ) ;
                  standaloneModal0W87( ) ;
                  AddRow0W87( ) ;
                  ScanNext0W87( ) ;
               }
               ScanEnd0W87( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode87 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5187( ) ;
            InitAll0W87( ) ;
            init_level_properties87( ) ;
            nRcdExists_87 = 0;
            nIsMod_87 = 0;
            nRcdDeleted_87 = 0;
            nBlankRcdCount87 = (short)(nBlankRcdUsr87+nBlankRcdCount87);
            fRowAdded = 0;
            while ( nBlankRcdCount87 > 0 )
            {
               A261IconId = Guid.Empty;
               standaloneNotModal0W87( ) ;
               standaloneModal0W87( ) ;
               AddRow0W87( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIconId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount87 = (short)(nBlankRcdCount87-1);
            }
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_iconContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_icon", Gridlevel_iconContainer, subGridlevel_icon_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_iconContainerData", Gridlevel_iconContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_iconContainerData"+"V", Gridlevel_iconContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_iconContainerData"+"V"+"\" value='"+Gridlevel_iconContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_color( )
      {
         /*  Grid Control  */
         StartGridControl64( ) ;
         nGXsfl_64_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount47 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_47 = 1;
               ScanStart0W47( ) ;
               while ( RcdFound47 != 0 )
               {
                  init_level_properties47( ) ;
                  getByPrimaryKey0W47( ) ;
                  AddRow0W47( ) ;
                  ScanNext0W47( ) ;
               }
               ScanEnd0W47( ) ;
               nBlankRcdCount47 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0W47( ) ;
            standaloneModal0W47( ) ;
            sMode47 = Gx_mode;
            while ( nGXsfl_64_idx < nRC_GXsfl_64 )
            {
               bGXsfl_64_Refreshing = true;
               ReadRow0W47( ) ;
               edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               if ( ( nRcdExists_47 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0W47( ) ;
               }
               SendRow0W47( ) ;
               bGXsfl_64_Refreshing = false;
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount47 = 5;
            nRcdExists_47 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0W47( ) ;
               while ( RcdFound47 != 0 )
               {
                  sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6447( ) ;
                  init_level_properties47( ) ;
                  standaloneNotModal0W47( ) ;
                  getByPrimaryKey0W47( ) ;
                  standaloneModal0W47( ) ;
                  AddRow0W47( ) ;
                  ScanNext0W47( ) ;
               }
               ScanEnd0W47( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode47 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6447( ) ;
            InitAll0W47( ) ;
            init_level_properties47( ) ;
            nRcdExists_47 = 0;
            nIsMod_47 = 0;
            nRcdDeleted_47 = 0;
            nBlankRcdCount47 = (short)(nBlankRcdUsr47+nBlankRcdCount47);
            fRowAdded = 0;
            while ( nBlankRcdCount47 > 0 )
            {
               A249ColorId = Guid.Empty;
               standaloneNotModal0W47( ) ;
               standaloneModal0W47( ) ;
               AddRow0W47( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = cmbColorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount47 = (short)(nBlankRcdCount47-1);
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_colorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_color", Gridlevel_colorContainer, subGridlevel_color_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData", Gridlevel_colorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData"+"V", Gridlevel_colorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_colorContainerData"+"V"+"\" value='"+Gridlevel_colorContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z247Trn_ThemeId"));
               Z248Trn_ThemeName = cgiGet( "Z248Trn_ThemeName");
               Z260Trn_ThemeFontFamily = cgiGet( "Z260Trn_ThemeFontFamily");
               Z399Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z399Trn_ThemeFontSize"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = false;
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_42 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_42"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_51 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_51"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               AV13Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "vTRN_THEMEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "ORGANISATIONID"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_ThemeId_Internalname), "") == 0 )
               {
                  A247Trn_ThemeId = Guid.Empty;
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               }
               else
               {
                  try
                  {
                     A247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( edtTrn_ThemeId_Internalname));
                     n247Trn_ThemeId = false;
                     AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A248Trn_ThemeName = cgiGet( edtTrn_ThemeName_Internalname);
               AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
               A260Trn_ThemeFontFamily = cgiGet( edtTrn_ThemeFontFamily_Internalname);
               AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRN_THEMEFONTSIZE");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeFontSize_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A399Trn_ThemeFontSize = 0;
                  AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
               }
               else
               {
                  A399Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A247Trn_ThemeId != Z247Trn_ThemeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_theme:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A247Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV13Trn_ThemeId) )
                  {
                     A247Trn_ThemeId = AV13Trn_ThemeId;
                     n247Trn_ThemeId = false;
                     AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                     {
                        A247Trn_ThemeId = Guid.NewGuid( );
                        n247Trn_ThemeId = false;
                        AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
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
                     sMode46 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV13Trn_ThemeId) )
                     {
                        A247Trn_ThemeId = AV13Trn_ThemeId;
                        n247Trn_ThemeId = false;
                        AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                        {
                           A247Trn_ThemeId = Guid.NewGuid( );
                           n247Trn_ThemeId = false;
                           AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                        }
                     }
                     Gx_mode = sMode46;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound46 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120W2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E120W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0W46( ) ;
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
            DisableAttributes0W46( ) ;
         }
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W46( ) ;
            }
            else
            {
               CheckExtendedTable0W46( ) ;
               CloseExtendedTableCursors0W46( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode46 = Gx_mode;
            CONFIRM_0W112( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0W87( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode46;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     IsConfirmed = 1;
                     AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0W47( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow0W47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               GetKey0W47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W47( ) ;
                        CloseExtendedTableCursors0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( nRcdDeleted_47 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0W47( ) ;
                        Load0W47( ) ;
                        BeforeValidate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W47( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0W47( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W47( ) ;
                              CloseExtendedTableCursors0W47( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A249ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A250ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A251ColorCode) ;
            ChangePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_64_idx, Z249ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_64_idx, Z250ColorName) ;
            ChangePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_64_idx, Z251ColorCode) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0W87( )
      {
         nGXsfl_51_idx = 0;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            ReadRow0W87( ) ;
            if ( ( nRcdExists_87 != 0 ) || ( nIsMod_87 != 0 ) )
            {
               GetKey0W87( ) ;
               if ( ( nRcdExists_87 == 0 ) && ( nRcdDeleted_87 == 0 ) )
               {
                  if ( RcdFound87 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0W87( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W87( ) ;
                        CloseExtendedTableCursors0W87( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ICONID_" + sGXsfl_51_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtIconId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound87 != 0 )
                  {
                     if ( nRcdDeleted_87 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0W87( ) ;
                        Load0W87( ) ;
                        BeforeValidate0W87( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W87( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_87 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0W87( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W87( ) ;
                              CloseExtendedTableCursors0W87( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_87 == 0 )
                     {
                        GXCCtl = "ICONID_" + sGXsfl_51_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIconId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIconId_Internalname, A261IconId.ToString()) ;
            ChangePostValue( edtIconName_Internalname, A262IconName) ;
            ChangePostValue( cmbIconCategory_Internalname, A443IconCategory) ;
            ChangePostValue( edtIconSVG_Internalname, A263IconSVG) ;
            ChangePostValue( "ZT_"+"Z261IconId_"+sGXsfl_51_idx, Z261IconId.ToString()) ;
            ChangePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx, Z443IconCategory) ;
            ChangePostValue( "ZT_"+"Z262IconName_"+sGXsfl_51_idx, Z262IconName) ;
            ChangePostValue( "nRcdDeleted_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_87 != 0 )
            {
               ChangePostValue( "ICONID_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0W112( )
      {
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            ReadRow0W112( ) ;
            if ( ( nRcdExists_112 != 0 ) || ( nIsMod_112 != 0 ) )
            {
               GetKey0W112( ) ;
               if ( ( nRcdExists_112 == 0 ) && ( nRcdDeleted_112 == 0 ) )
               {
                  if ( RcdFound112 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0W112( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W112( ) ;
                        CloseExtendedTableCursors0W112( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCtaColorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound112 != 0 )
                  {
                     if ( nRcdDeleted_112 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0W112( ) ;
                        Load0W112( ) ;
                        BeforeValidate0W112( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W112( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_112 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0W112( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W112( ) ;
                              CloseExtendedTableCursors0W112( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_112 == 0 )
                     {
                        GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCtaColorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCtaColorId_Internalname, A563CtaColorId.ToString()) ;
            ChangePostValue( edtCtaColorName_Internalname, A564CtaColorName) ;
            ChangePostValue( edtCtaColorCode_Internalname, A565CtaColorCode) ;
            ChangePostValue( "ZT_"+"Z563CtaColorId_"+sGXsfl_42_idx, Z563CtaColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z564CtaColorName_"+sGXsfl_42_idx, Z564CtaColorName) ;
            ChangePostValue( "ZT_"+"Z565CtaColorCode_"+sGXsfl_42_idx, Z565CtaColorCode) ;
            ChangePostValue( "nRcdDeleted_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_112 != 0 )
            {
               ChangePostValue( "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0W0( )
      {
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV14Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_OrganisationId", AV14Insert_OrganisationId.ToString());
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E120W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_themeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0W46( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z248Trn_ThemeName = T000W9_A248Trn_ThemeName[0];
               Z260Trn_ThemeFontFamily = T000W9_A260Trn_ThemeFontFamily[0];
               Z399Trn_ThemeFontSize = T000W9_A399Trn_ThemeFontSize[0];
               Z11OrganisationId = T000W9_A11OrganisationId[0];
            }
            else
            {
               Z248Trn_ThemeName = A248Trn_ThemeName;
               Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
               Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
            Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV16Pgmname = "Trn_Theme";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_ThemeId_Enabled = 1;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            A247Trn_ThemeId = AV13Trn_ThemeId;
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               A247Trn_ThemeId = Guid.NewGuid( );
               n247Trn_ThemeId = false;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W46( )
      {
         /* Using cursor T000W11 */
         pr_default.execute(9, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A248Trn_ThemeName = T000W11_A248Trn_ThemeName[0];
            AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
            A260Trn_ThemeFontFamily = T000W11_A260Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
            A399Trn_ThemeFontSize = T000W11_A399Trn_ThemeFontSize[0];
            AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
            A11OrganisationId = T000W11_A11OrganisationId[0];
            n11OrganisationId = T000W11_n11OrganisationId[0];
            ZM0W46( -17) ;
         }
         pr_default.close(9);
         OnLoadActions0W46( ) ;
      }

      protected void OnLoadActions0W46( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_OrganisationId) )
         {
            A11OrganisationId = AV14Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A11OrganisationId) )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               n11OrganisationId = true;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
         }
      }

      protected void CheckExtendedTable0W46( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_OrganisationId) )
         {
            A11OrganisationId = AV14Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A11OrganisationId) )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               n11OrganisationId = true;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
         }
         /* Using cursor T000W10 */
         pr_default.execute(8, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(8);
      }

      protected void CloseExtendedTableCursors0W46( )
      {
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( Guid A11OrganisationId )
      {
         /* Using cursor T000W12 */
         pr_default.execute(10, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0W46( )
      {
         /* Using cursor T000W13 */
         pr_default.execute(11, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0W46( 17) ;
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W9_A247Trn_ThemeId[0];
            n247Trn_ThemeId = T000W9_n247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            A248Trn_ThemeName = T000W9_A248Trn_ThemeName[0];
            AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
            A260Trn_ThemeFontFamily = T000W9_A260Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
            A399Trn_ThemeFontSize = T000W9_A399Trn_ThemeFontSize[0];
            AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
            A11OrganisationId = T000W9_A11OrganisationId[0];
            n11OrganisationId = T000W9_n11OrganisationId[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W46( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey0W46( ) ;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey0W46( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W46( ) ;
         if ( RcdFound46 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound46 = 0;
         /* Using cursor T000W14 */
         pr_default.execute(12, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000W14_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000W14_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) > 0 ) ) )
            {
               A247Trn_ThemeId = T000W14_A247Trn_ThemeId[0];
               n247Trn_ThemeId = T000W14_n247Trn_ThemeId[0];
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               RcdFound46 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound46 = 0;
         /* Using cursor T000W15 */
         pr_default.execute(13, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T000W15_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T000W15_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) < 0 ) ) )
            {
               A247Trn_ThemeId = T000W15_A247Trn_ThemeId[0];
               n247Trn_ThemeId = T000W15_n247Trn_ThemeId[0];
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               RcdFound46 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W46( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W46( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  A247Trn_ThemeId = Z247Trn_ThemeId;
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_THEMEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0W46( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W46( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0W46( ) ;
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
         if ( A247Trn_ThemeId != Z247Trn_ThemeId )
         {
            A247Trn_ThemeId = Z247Trn_ThemeId;
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0W46( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W8 */
            pr_default.execute(6, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z248Trn_ThemeName, T000W8_A248Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, T000W8_A260Trn_ThemeFontFamily[0]) != 0 ) || ( Z399Trn_ThemeFontSize != T000W8_A399Trn_ThemeFontSize[0] ) || ( Z11OrganisationId != T000W8_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z248Trn_ThemeName, T000W8_A248Trn_ThemeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeName");
                  GXUtil.WriteLogRaw("Old: ",Z248Trn_ThemeName);
                  GXUtil.WriteLogRaw("Current: ",T000W8_A248Trn_ThemeName[0]);
               }
               if ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, T000W8_A260Trn_ThemeFontFamily[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontFamily");
                  GXUtil.WriteLogRaw("Old: ",Z260Trn_ThemeFontFamily);
                  GXUtil.WriteLogRaw("Current: ",T000W8_A260Trn_ThemeFontFamily[0]);
               }
               if ( Z399Trn_ThemeFontSize != T000W8_A399Trn_ThemeFontSize[0] )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontSize");
                  GXUtil.WriteLogRaw("Old: ",Z399Trn_ThemeFontSize);
                  GXUtil.WriteLogRaw("Current: ",T000W8_A399Trn_ThemeFontSize[0]);
               }
               if ( Z11OrganisationId != T000W8_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000W8_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W46( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W46( 0) ;
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W16 */
                     pr_default.execute(14, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize, n11OrganisationId, A11OrganisationId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ProcessLevel0W46( ) ;
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
               Load0W46( ) ;
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void Update0W46( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W17 */
                     pr_default.execute(15, new Object[] {A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize, n11OrganisationId, A11OrganisationId, n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W46( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0W46( ) ;
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
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void DeferredUpdate0W46( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W46( ) ;
            AfterConfirm0W46( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W46( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0W112( ) ;
                  while ( RcdFound112 != 0 )
                  {
                     getByPrimaryKey0W112( ) ;
                     Delete0W112( ) ;
                     ScanNext0W112( ) ;
                  }
                  ScanEnd0W112( ) ;
                  ScanStart0W87( ) ;
                  while ( RcdFound87 != 0 )
                  {
                     getByPrimaryKey0W87( ) ;
                     Delete0W87( ) ;
                     ScanNext0W87( ) ;
                  }
                  ScanEnd0W87( ) ;
                  ScanStart0W47( ) ;
                  while ( RcdFound47 != 0 )
                  {
                     getByPrimaryKey0W47( ) ;
                     Delete0W47( ) ;
                     ScanNext0W47( ) ;
                  }
                  ScanEnd0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W18 */
                     pr_default.execute(16, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         }
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W46( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W46( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000W19 */
            pr_default.execute(17, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0W112( )
      {
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            ReadRow0W112( ) ;
            if ( ( nRcdExists_112 != 0 ) || ( nIsMod_112 != 0 ) )
            {
               standaloneNotModal0W112( ) ;
               GetKey0W112( ) ;
               if ( ( nRcdExists_112 == 0 ) && ( nRcdDeleted_112 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0W112( ) ;
               }
               else
               {
                  if ( RcdFound112 != 0 )
                  {
                     if ( ( nRcdDeleted_112 != 0 ) && ( nRcdExists_112 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0W112( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_112 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0W112( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_112 == 0 )
                     {
                        GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCtaColorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCtaColorId_Internalname, A563CtaColorId.ToString()) ;
            ChangePostValue( edtCtaColorName_Internalname, A564CtaColorName) ;
            ChangePostValue( edtCtaColorCode_Internalname, A565CtaColorCode) ;
            ChangePostValue( "ZT_"+"Z563CtaColorId_"+sGXsfl_42_idx, Z563CtaColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z564CtaColorName_"+sGXsfl_42_idx, Z564CtaColorName) ;
            ChangePostValue( "ZT_"+"Z565CtaColorCode_"+sGXsfl_42_idx, Z565CtaColorCode) ;
            ChangePostValue( "nRcdDeleted_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_112_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_112), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_112 != 0 )
            {
               ChangePostValue( "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W112( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_112 = 0;
         nIsMod_112 = 0;
         nRcdDeleted_112 = 0;
      }

      protected void ProcessNestedLevel0W87( )
      {
         nGXsfl_51_idx = 0;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            ReadRow0W87( ) ;
            if ( ( nRcdExists_87 != 0 ) || ( nIsMod_87 != 0 ) )
            {
               standaloneNotModal0W87( ) ;
               GetKey0W87( ) ;
               if ( ( nRcdExists_87 == 0 ) && ( nRcdDeleted_87 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0W87( ) ;
               }
               else
               {
                  if ( RcdFound87 != 0 )
                  {
                     if ( ( nRcdDeleted_87 != 0 ) && ( nRcdExists_87 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0W87( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_87 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0W87( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_87 == 0 )
                     {
                        GXCCtl = "ICONID_" + sGXsfl_51_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIconId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIconId_Internalname, A261IconId.ToString()) ;
            ChangePostValue( edtIconName_Internalname, A262IconName) ;
            ChangePostValue( cmbIconCategory_Internalname, A443IconCategory) ;
            ChangePostValue( edtIconSVG_Internalname, A263IconSVG) ;
            ChangePostValue( "ZT_"+"Z261IconId_"+sGXsfl_51_idx, Z261IconId.ToString()) ;
            ChangePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx, Z443IconCategory) ;
            ChangePostValue( "ZT_"+"Z262IconName_"+sGXsfl_51_idx, Z262IconName) ;
            ChangePostValue( "nRcdDeleted_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_87_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_87 != 0 )
            {
               ChangePostValue( "ICONID_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W87( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_87 = 0;
         nIsMod_87 = 0;
         nRcdDeleted_87 = 0;
      }

      protected void ProcessNestedLevel0W47( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow0W47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               standaloneNotModal0W47( ) ;
               GetKey0W47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0W47( ) ;
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( ( nRcdDeleted_47 != 0 ) && ( nRcdExists_47 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0W47( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0W47( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A249ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A250ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A251ColorCode) ;
            ChangePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_64_idx, Z249ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_64_idx, Z250ColorName) ;
            ChangePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_64_idx, Z251ColorCode) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
         nRcdDeleted_47 = 0;
      }

      protected void ProcessLevel0W46( )
      {
         /* Save parent mode. */
         sMode46 = Gx_mode;
         ProcessNestedLevel0W112( ) ;
         ProcessNestedLevel0W87( ) ;
         ProcessNestedLevel0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0W46( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_theme",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_theme",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W46( )
      {
         /* Scan By routine */
         /* Using cursor T000W20 */
         pr_default.execute(18);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W20_A247Trn_ThemeId[0];
            n247Trn_ThemeId = T000W20_n247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W46( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W20_A247Trn_ThemeId[0];
            n247Trn_ThemeId = T000W20_n247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
      }

      protected void ScanEnd0W46( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0W46( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W46( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W46( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W46( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W46( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W46( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W46( )
      {
         edtTrn_ThemeId_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         edtTrn_ThemeName_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeName_Enabled), 5, 0), true);
         edtTrn_ThemeFontFamily_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontFamily_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontFamily_Enabled), 5, 0), true);
         edtTrn_ThemeFontSize_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontSize_Enabled), 5, 0), true);
      }

      protected void ZM0W112( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z564CtaColorName = T000W7_A564CtaColorName[0];
               Z565CtaColorCode = T000W7_A565CtaColorCode[0];
            }
            else
            {
               Z564CtaColorName = A564CtaColorName;
               Z565CtaColorCode = A565CtaColorCode;
            }
         }
         if ( GX_JID == -19 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z563CtaColorId = A563CtaColorId;
            Z564CtaColorName = A564CtaColorName;
            Z565CtaColorCode = A565CtaColorCode;
         }
      }

      protected void standaloneNotModal0W112( )
      {
      }

      protected void standaloneModal0W112( )
      {
         if ( IsIns( )  && (Guid.Empty==A563CtaColorId) && ( Gx_BScreen == 0 ) )
         {
            A563CtaColorId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCtaColorId_Enabled = 0;
            AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         }
         else
         {
            edtCtaColorId_Enabled = 1;
            AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W112( )
      {
         /* Using cursor T000W21 */
         pr_default.execute(19, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound112 = 1;
            A564CtaColorName = T000W21_A564CtaColorName[0];
            A565CtaColorCode = T000W21_A565CtaColorCode[0];
            ZM0W112( -19) ;
         }
         pr_default.close(19);
         OnLoadActions0W112( ) ;
      }

      protected void OnLoadActions0W112( )
      {
      }

      protected void CheckExtendedTable0W112( )
      {
         nIsDirty_112 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0W112( ) ;
         /* Using cursor T000W22 */
         pr_default.execute(20, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A564CtaColorName, A563CtaColorId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
      }

      protected void CloseExtendedTableCursors0W112( )
      {
      }

      protected void enableDisable0W112( )
      {
      }

      protected void GetKey0W112( )
      {
         /* Using cursor T000W23 */
         pr_default.execute(21, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound112 = 1;
         }
         else
         {
            RcdFound112 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0W112( )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0W112( 19) ;
            RcdFound112 = 1;
            InitializeNonKey0W112( ) ;
            A563CtaColorId = T000W7_A563CtaColorId[0];
            A564CtaColorName = T000W7_A564CtaColorName[0];
            A565CtaColorCode = T000W7_A565CtaColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z563CtaColorId = A563CtaColorId;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W112( ) ;
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound112 = 0;
            InitializeNonKey0W112( ) ;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0W112( ) ;
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W112( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0W112( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W6 */
            pr_default.execute(4, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z564CtaColorName, T000W6_A564CtaColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z565CtaColorCode, T000W6_A565CtaColorCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z564CtaColorName, T000W6_A564CtaColorName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"CtaColorName");
                  GXUtil.WriteLogRaw("Old: ",Z564CtaColorName);
                  GXUtil.WriteLogRaw("Current: ",T000W6_A564CtaColorName[0]);
               }
               if ( StringUtil.StrCmp(Z565CtaColorCode, T000W6_A565CtaColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"CtaColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z565CtaColorCode);
                  GXUtil.WriteLogRaw("Current: ",T000W6_A565CtaColorCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeCtaColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W112( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W112( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W112( 0) ;
            CheckOptimisticConcurrency0W112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W24 */
                     pr_default.execute(22, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId, A564CtaColorName, A565CtaColorCode});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load0W112( ) ;
            }
            EndLevel0W112( ) ;
         }
         CloseExtendedTableCursors0W112( ) ;
      }

      protected void Update0W112( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W112( ) ;
         }
         if ( ( nIsMod_112 != 0 ) || ( nIsDirty_112 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0W112( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0W112( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0W112( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000W25 */
                        pr_default.execute(23, new Object[] {A564CtaColorName, A565CtaColorCode, n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0W112( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0W112( ) ;
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
               EndLevel0W112( ) ;
            }
         }
         CloseExtendedTableCursors0W112( ) ;
      }

      protected void DeferredUpdate0W112( )
      {
      }

      protected void Delete0W112( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W112( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W112( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W112( ) ;
            AfterConfirm0W112( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W112( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W26 */
                  pr_default.execute(24, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A563CtaColorId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
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
         sMode112 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W112( ) ;
         Gx_mode = sMode112;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W112( )
      {
         standaloneModal0W112( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W112( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W112( )
      {
         /* Scan By routine */
         /* Using cursor T000W27 */
         pr_default.execute(25, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound112 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound112 = 1;
            A563CtaColorId = T000W27_A563CtaColorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W112( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound112 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound112 = 1;
            A563CtaColorId = T000W27_A563CtaColorId[0];
         }
      }

      protected void ScanEnd0W112( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0W112( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W112( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W112( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W112( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W112( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W112( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W112( )
      {
         edtCtaColorId_Enabled = 0;
         AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         edtCtaColorName_Enabled = 0;
         AssignProp("", false, edtCtaColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorName_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         edtCtaColorCode_Enabled = 0;
         AssignProp("", false, edtCtaColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorCode_Enabled), 5, 0), !bGXsfl_42_Refreshing);
      }

      protected void send_integrity_lvl_hashes0W112( )
      {
      }

      protected void ZM0W87( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z443IconCategory = T000W5_A443IconCategory[0];
               Z262IconName = T000W5_A262IconName[0];
            }
            else
            {
               Z443IconCategory = A443IconCategory;
               Z262IconName = A262IconName;
            }
         }
         if ( GX_JID == -21 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            Z443IconCategory = A443IconCategory;
            Z262IconName = A262IconName;
            Z263IconSVG = A263IconSVG;
         }
      }

      protected void standaloneNotModal0W87( )
      {
      }

      protected void standaloneModal0W87( )
      {
         if ( IsIns( )  && (Guid.Empty==A261IconId) && ( Gx_BScreen == 0 ) )
         {
            A261IconId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtIconId_Enabled = 0;
            AssignProp("", false, edtIconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconId_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         }
         else
         {
            edtIconId_Enabled = 1;
            AssignProp("", false, edtIconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconId_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W87( )
      {
         /* Using cursor T000W28 */
         pr_default.execute(26, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound87 = 1;
            A443IconCategory = T000W28_A443IconCategory[0];
            A262IconName = T000W28_A262IconName[0];
            A263IconSVG = T000W28_A263IconSVG[0];
            ZM0W87( -21) ;
         }
         pr_default.close(26);
         OnLoadActions0W87( ) ;
      }

      protected void OnLoadActions0W87( )
      {
      }

      protected void CheckExtendedTable0W87( )
      {
         nIsDirty_87 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0W87( ) ;
         /* Using cursor T000W29 */
         pr_default.execute(27, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A262IconName, A443IconCategory, A261IconId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(27);
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbIconCategory_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0W87( )
      {
      }

      protected void enableDisable0W87( )
      {
      }

      protected void GetKey0W87( )
      {
         /* Using cursor T000W30 */
         pr_default.execute(28, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound87 = 1;
         }
         else
         {
            RcdFound87 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0W87( )
      {
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0W87( 21) ;
            RcdFound87 = 1;
            InitializeNonKey0W87( ) ;
            A261IconId = T000W5_A261IconId[0];
            A443IconCategory = T000W5_A443IconCategory[0];
            A262IconName = T000W5_A262IconName[0];
            A263IconSVG = T000W5_A263IconSVG[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W87( ) ;
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound87 = 0;
            InitializeNonKey0W87( ) ;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0W87( ) ;
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W87( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0W87( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W4 */
            pr_default.execute(2, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z443IconCategory, T000W4_A443IconCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z262IconName, T000W4_A262IconName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z443IconCategory, T000W4_A443IconCategory[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"IconCategory");
                  GXUtil.WriteLogRaw("Old: ",Z443IconCategory);
                  GXUtil.WriteLogRaw("Current: ",T000W4_A443IconCategory[0]);
               }
               if ( StringUtil.StrCmp(Z262IconName, T000W4_A262IconName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"IconName");
                  GXUtil.WriteLogRaw("Old: ",Z262IconName);
                  GXUtil.WriteLogRaw("Current: ",T000W4_A262IconName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeIcon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W87( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W87( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W87( 0) ;
            CheckOptimisticConcurrency0W87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W31 */
                     pr_default.execute(29, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId, A443IconCategory, A262IconName, A263IconSVG});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load0W87( ) ;
            }
            EndLevel0W87( ) ;
         }
         CloseExtendedTableCursors0W87( ) ;
      }

      protected void Update0W87( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W87( ) ;
         }
         if ( ( nIsMod_87 != 0 ) || ( nIsDirty_87 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0W87( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0W87( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0W87( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000W32 */
                        pr_default.execute(30, new Object[] {A443IconCategory, A262IconName, A263IconSVG, n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
                        pr_default.close(30);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                        if ( (pr_default.getStatus(30) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0W87( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0W87( ) ;
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
               EndLevel0W87( ) ;
            }
         }
         CloseExtendedTableCursors0W87( ) ;
      }

      protected void DeferredUpdate0W87( )
      {
      }

      protected void Delete0W87( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W87( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W87( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W87( ) ;
            AfterConfirm0W87( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W87( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W33 */
                  pr_default.execute(31, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A261IconId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
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
         sMode87 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W87( ) ;
         Gx_mode = sMode87;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W87( )
      {
         standaloneModal0W87( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W87( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W87( )
      {
         /* Scan By routine */
         /* Using cursor T000W34 */
         pr_default.execute(32, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound87 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound87 = 1;
            A261IconId = T000W34_A261IconId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W87( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound87 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound87 = 1;
            A261IconId = T000W34_A261IconId[0];
         }
      }

      protected void ScanEnd0W87( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0W87( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W87( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W87( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W87( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W87( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W87( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W87( )
      {
         edtIconId_Enabled = 0;
         AssignProp("", false, edtIconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconId_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         edtIconName_Enabled = 0;
         AssignProp("", false, edtIconName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconName_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         cmbIconCategory.Enabled = 0;
         AssignProp("", false, cmbIconCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIconCategory.Enabled), 5, 0), !bGXsfl_51_Refreshing);
         edtIconSVG_Enabled = 0;
         AssignProp("", false, edtIconSVG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconSVG_Enabled), 5, 0), !bGXsfl_51_Refreshing);
      }

      protected void send_integrity_lvl_hashes0W87( )
      {
      }

      protected void ZM0W47( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z250ColorName = T000W3_A250ColorName[0];
               Z251ColorCode = T000W3_A251ColorCode[0];
            }
            else
            {
               Z250ColorName = A250ColorName;
               Z251ColorCode = A251ColorCode;
            }
         }
         if ( GX_JID == -23 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
      }

      protected void standaloneNotModal0W47( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void standaloneModal0W47( )
      {
         if ( IsIns( )  && (Guid.Empty==A249ColorId) && ( Gx_BScreen == 0 ) )
         {
            A249ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W47( )
      {
         /* Using cursor T000W35 */
         pr_default.execute(33, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound47 = 1;
            A250ColorName = T000W35_A250ColorName[0];
            A251ColorCode = T000W35_A251ColorCode[0];
            ZM0W47( -23) ;
         }
         pr_default.close(33);
         OnLoadActions0W47( ) ;
      }

      protected void OnLoadActions0W47( )
      {
      }

      protected void CheckExtendedTable0W47( )
      {
         nIsDirty_47 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0W47( ) ;
         /* Using cursor T000W36 */
         pr_default.execute(34, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A249ColorId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(34);
         /* Using cursor T000W37 */
         pr_default.execute(35, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A251ColorCode, A249ColorId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(35);
      }

      protected void CloseExtendedTableCursors0W47( )
      {
      }

      protected void enableDisable0W47( )
      {
      }

      protected void GetKey0W47( )
      {
         /* Using cursor T000W38 */
         pr_default.execute(36, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(36);
      }

      protected void getByPrimaryKey0W47( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W47( 23) ;
            RcdFound47 = 1;
            InitializeNonKey0W47( ) ;
            A249ColorId = T000W3_A249ColorId[0];
            A250ColorName = T000W3_A250ColorName[0];
            A251ColorCode = T000W3_A251ColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey0W47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0W47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W47( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0W47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250ColorName, T000W2_A250ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z251ColorCode, T000W2_A251ColorCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z250ColorName, T000W2_A250ColorName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorName");
                  GXUtil.WriteLogRaw("Old: ",Z250ColorName);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A250ColorName[0]);
               }
               if ( StringUtil.StrCmp(Z251ColorCode, T000W2_A251ColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z251ColorCode);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A251ColorCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W47( 0) ;
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W39 */
                     pr_default.execute(37, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                     pr_default.close(37);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(37) == 1) )
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
               Load0W47( ) ;
            }
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void Update0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( ( nIsMod_47 != 0 ) || ( nIsDirty_47 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0W47( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000W40 */
                        pr_default.execute(38, new Object[] {A250ColorName, A251ColorCode, n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
                        pr_default.close(38);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                        if ( (pr_default.getStatus(38) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0W47( ) ;
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
               EndLevel0W47( ) ;
            }
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void DeferredUpdate0W47( )
      {
      }

      protected void Delete0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W47( ) ;
            AfterConfirm0W47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W41 */
                  pr_default.execute(39, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A249ColorId});
                  pr_default.close(39);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W47( ) ;
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W47( )
      {
         standaloneModal0W47( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W47( )
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

      public void ScanStart0W47( )
      {
         /* Scan By routine */
         /* Using cursor T000W42 */
         pr_default.execute(40, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = T000W42_A249ColorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W47( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = T000W42_A249ColorId[0];
         }
      }

      protected void ScanEnd0W47( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm0W47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W47( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         cmbColorName.Enabled = 0;
         AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtColorCode_Enabled = 0;
         AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void send_integrity_lvl_hashes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W46( )
      {
      }

      protected void SubsflControlProps_42112( )
      {
         edtCtaColorId_Internalname = "CTACOLORID_"+sGXsfl_42_idx;
         edtCtaColorName_Internalname = "CTACOLORNAME_"+sGXsfl_42_idx;
         edtCtaColorCode_Internalname = "CTACOLORCODE_"+sGXsfl_42_idx;
      }

      protected void SubsflControlProps_fel_42112( )
      {
         edtCtaColorId_Internalname = "CTACOLORID_"+sGXsfl_42_fel_idx;
         edtCtaColorName_Internalname = "CTACOLORNAME_"+sGXsfl_42_fel_idx;
         edtCtaColorCode_Internalname = "CTACOLORCODE_"+sGXsfl_42_fel_idx;
      }

      protected void AddRow0W112( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_42112( ) ;
         SendRow0W112( ) ;
      }

      protected void SendRow0W112( )
      {
         Gridlevel_ctacolorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_ctacolor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
            }
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 0;
            subGridlevel_ctacolor_Backcolor = subGridlevel_ctacolor_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Uniform";
            }
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
            }
            subGridlevel_ctacolor_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 1;
            if ( ((int)((nGXsfl_42_idx) % (2))) == 0 )
            {
               subGridlevel_ctacolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
               {
                  subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Even";
               }
            }
            else
            {
               subGridlevel_ctacolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
               {
                  subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_112_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorId_Internalname,A563CtaColorId.ToString(),A563CtaColorId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)42,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_112_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorName_Internalname,(string)A564CtaColorName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)42,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_112_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorCode_Internalname,(string)A565CtaColorCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)42,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_ctacolorRow);
         send_integrity_lvl_hashes0W112( ) ;
         GXCCtl = "Z563CtaColorId_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z563CtaColorId.ToString());
         GXCCtl = "Z564CtaColorName_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z564CtaColorName);
         GXCCtl = "Z565CtaColorCode_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z565CtaColorCode);
         GXCCtl = "nRcdDeleted_112_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_112), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_112_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_112), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_112_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_112), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_42_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_ctacolorContainer.AddRow(Gridlevel_ctacolorRow);
      }

      protected void ReadRow0W112( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_42112( ) ;
         edtCtaColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORID_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCtaColorName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCtaColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtCtaColorId_Internalname), "") == 0 )
         {
            A563CtaColorId = Guid.Empty;
         }
         else
         {
            try
            {
               A563CtaColorId = StringUtil.StrToGuid( cgiGet( edtCtaColorId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCtaColorId_Internalname;
               wbErr = true;
            }
         }
         A564CtaColorName = cgiGet( edtCtaColorName_Internalname);
         A565CtaColorCode = cgiGet( edtCtaColorCode_Internalname);
         GXCCtl = "Z563CtaColorId_" + sGXsfl_42_idx;
         Z563CtaColorId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z564CtaColorName_" + sGXsfl_42_idx;
         Z564CtaColorName = cgiGet( GXCCtl);
         GXCCtl = "Z565CtaColorCode_" + sGXsfl_42_idx;
         Z565CtaColorCode = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_112_" + sGXsfl_42_idx;
         nRcdDeleted_112 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_112_" + sGXsfl_42_idx;
         nRcdExists_112 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_112_" + sGXsfl_42_idx;
         nIsMod_112 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_5187( )
      {
         edtIconId_Internalname = "ICONID_"+sGXsfl_51_idx;
         edtIconName_Internalname = "ICONNAME_"+sGXsfl_51_idx;
         cmbIconCategory_Internalname = "ICONCATEGORY_"+sGXsfl_51_idx;
         edtIconSVG_Internalname = "ICONSVG_"+sGXsfl_51_idx;
      }

      protected void SubsflControlProps_fel_5187( )
      {
         edtIconId_Internalname = "ICONID_"+sGXsfl_51_fel_idx;
         edtIconName_Internalname = "ICONNAME_"+sGXsfl_51_fel_idx;
         cmbIconCategory_Internalname = "ICONCATEGORY_"+sGXsfl_51_fel_idx;
         edtIconSVG_Internalname = "ICONSVG_"+sGXsfl_51_fel_idx;
      }

      protected void AddRow0W87( )
      {
         nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5187( ) ;
         SendRow0W87( ) ;
      }

      protected void SendRow0W87( )
      {
         Gridlevel_iconRow = GXWebRow.GetNew(context);
         if ( subGridlevel_icon_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_icon_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
            }
         }
         else if ( subGridlevel_icon_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_icon_Backstyle = 0;
            subGridlevel_icon_Backcolor = subGridlevel_icon_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Uniform";
            }
         }
         else if ( subGridlevel_icon_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_icon_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
            }
            subGridlevel_icon_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_icon_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_icon_Backstyle = 1;
            if ( ((int)((nGXsfl_51_idx) % (2))) == 0 )
            {
               subGridlevel_icon_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
               {
                  subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Even";
               }
            }
            else
            {
               subGridlevel_icon_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
               {
                  subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconId_Internalname,A261IconId.ToString(),A261IconId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)51,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconName_Internalname,(string)A262IconName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_51_idx + "',51)\"";
         if ( ( cmbIconCategory.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
            cmbIconCategory.Name = GXCCtl;
            cmbIconCategory.WebTags = "";
            cmbIconCategory.addItem("General", context.GetMessage( "General", ""), 0);
            cmbIconCategory.addItem("Services", context.GetMessage( "Services", ""), 0);
            cmbIconCategory.addItem("Living", context.GetMessage( "Living", ""), 0);
            cmbIconCategory.addItem("Health", context.GetMessage( "Health", ""), 0);
            if ( cmbIconCategory.ItemCount > 0 )
            {
               A443IconCategory = cmbIconCategory.getValidValue(A443IconCategory);
            }
         }
         /* ComboBox */
         Gridlevel_iconRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIconCategory,(string)cmbIconCategory_Internalname,StringUtil.RTrim( A443IconCategory),(short)1,(string)cmbIconCategory_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbIconCategory.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"",(bool)true,(short)0});
         cmbIconCategory.CurrentValue = StringUtil.RTrim( A443IconCategory);
         AssignProp("", false, cmbIconCategory_Internalname, "Values", (string)(cmbIconCategory.ToJavascriptSource()), !bGXsfl_51_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconSVG_Internalname,(string)A263IconSVG,(string)A263IconSVG,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconSVG_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconSVG_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)51,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_iconRow);
         send_integrity_lvl_hashes0W87( ) ;
         GXCCtl = "Z261IconId_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z261IconId.ToString());
         GXCCtl = "Z443IconCategory_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z443IconCategory);
         GXCCtl = "Z262IconName_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z262IconName);
         GXCCtl = "nRcdDeleted_87_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_87_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_87_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_51_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "ICONID_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_iconContainer.AddRow(Gridlevel_iconRow);
      }

      protected void ReadRow0W87( )
      {
         nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5187( ) ;
         edtIconId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONID_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtIconName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONNAME_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbIconCategory.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtIconSVG_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONSVG_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtIconId_Internalname), "") == 0 )
         {
            A261IconId = Guid.Empty;
         }
         else
         {
            try
            {
               A261IconId = StringUtil.StrToGuid( cgiGet( edtIconId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "ICONID_" + sGXsfl_51_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtIconId_Internalname;
               wbErr = true;
            }
         }
         A262IconName = cgiGet( edtIconName_Internalname);
         cmbIconCategory.Name = cmbIconCategory_Internalname;
         cmbIconCategory.CurrentValue = cgiGet( cmbIconCategory_Internalname);
         A443IconCategory = cgiGet( cmbIconCategory_Internalname);
         A263IconSVG = cgiGet( edtIconSVG_Internalname);
         GXCCtl = "Z261IconId_" + sGXsfl_51_idx;
         Z261IconId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z443IconCategory_" + sGXsfl_51_idx;
         Z443IconCategory = cgiGet( GXCCtl);
         GXCCtl = "Z262IconName_" + sGXsfl_51_idx;
         Z262IconName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_87_" + sGXsfl_51_idx;
         nRcdDeleted_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_87_" + sGXsfl_51_idx;
         nRcdExists_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_87_" + sGXsfl_51_idx;
         nIsMod_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_6447( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_64_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_64_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_6447( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_64_fel_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_64_fel_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_64_fel_idx;
      }

      protected void AddRow0W47( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6447( ) ;
         SendRow0W47( ) ;
      }

      protected void SendRow0W47( )
      {
         Gridlevel_colorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_color_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            subGridlevel_color_Backcolor = subGridlevel_color_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Uniform";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
            subGridlevel_color_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_color_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Even";
               }
            }
            else
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorId_Internalname,A249ColorId.ToString(),A249ColorId.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtColorId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)64,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_64_idx + "',64)\"";
         if ( ( cmbColorName.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "COLORNAME_" + sGXsfl_64_idx;
            cmbColorName.Name = GXCCtl;
            cmbColorName.WebTags = "";
            cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
            cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
            cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
            cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
            cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
            cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
            cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
            cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
            cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
            cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
            if ( cmbColorName.ItemCount > 0 )
            {
               A250ColorName = cmbColorName.getValidValue(A250ColorName);
            }
         }
         /* ComboBox */
         Gridlevel_colorRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbColorName,(string)cmbColorName_Internalname,StringUtil.RTrim( A250ColorName),(short)1,(string)cmbColorName_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbColorName.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"",(string)"",(bool)true,(short)0});
         cmbColorName.CurrentValue = StringUtil.RTrim( A250ColorName);
         AssignProp("", false, cmbColorName_Internalname, "Values", (string)(cmbColorName.ToJavascriptSource()), !bGXsfl_64_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorCode_Internalname,(string)A251ColorCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtColorCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_colorRow);
         send_integrity_lvl_hashes0W47( ) ;
         GXCCtl = "Z249ColorId_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z249ColorId.ToString());
         GXCCtl = "Z250ColorName_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z250ColorName);
         GXCCtl = "Z251ColorCode_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z251ColorCode);
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_47_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_47_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_64_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_colorContainer.AddRow(Gridlevel_colorRow);
      }

      protected void ReadRow0W47( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6447( ) ;
         edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A249ColorId = StringUtil.StrToGuid( cgiGet( edtColorId_Internalname));
         cmbColorName.Name = cmbColorName_Internalname;
         cmbColorName.CurrentValue = cgiGet( cmbColorName_Internalname);
         A250ColorName = cgiGet( cmbColorName_Internalname);
         A251ColorCode = cgiGet( edtColorCode_Internalname);
         GXCCtl = "Z249ColorId_" + sGXsfl_64_idx;
         Z249ColorId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z250ColorName_" + sGXsfl_64_idx;
         Z250ColorName = cgiGet( GXCCtl);
         GXCCtl = "Z251ColorCode_" + sGXsfl_64_idx;
         Z251ColorCode = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_64_idx;
         nRcdDeleted_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_47_" + sGXsfl_64_idx;
         nRcdExists_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_47_" + sGXsfl_64_idx;
         nIsMod_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtColorId_Enabled = edtColorId_Enabled;
         defedtIconId_Enabled = edtIconId_Enabled;
         defedtCtaColorId_Enabled = edtCtaColorId_Enabled;
      }

      protected void ConfirmValues0W0( )
      {
         nGXsfl_42_idx = 0;
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_42112( ) ;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
            SubsflControlProps_42112( ) ;
            ChangePostValue( "Z563CtaColorId_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z563CtaColorId_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z563CtaColorId_"+sGXsfl_42_idx) ;
            ChangePostValue( "Z564CtaColorName_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z564CtaColorName_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z564CtaColorName_"+sGXsfl_42_idx) ;
            ChangePostValue( "Z565CtaColorCode_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z565CtaColorCode_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z565CtaColorCode_"+sGXsfl_42_idx) ;
         }
         nGXsfl_51_idx = 0;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5187( ) ;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_5187( ) ;
            ChangePostValue( "Z261IconId_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z261IconId_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z261IconId_"+sGXsfl_51_idx) ;
            ChangePostValue( "Z443IconCategory_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx) ;
            ChangePostValue( "Z262IconName_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z262IconName_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z262IconName_"+sGXsfl_51_idx) ;
         }
         nGXsfl_64_idx = 0;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6447( ) ;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_6447( ) ;
            ChangePostValue( "Z249ColorId_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z249ColorId_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z250ColorName_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z250ColorName_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z251ColorCode_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z251ColorCode_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_64_idx) ;
         }
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13Trn_ThemeId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_theme:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z247Trn_ThemeId", Z247Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z248Trn_ThemeName", Z248Trn_ThemeName);
         GxWebStd.gx_hidden_field( context, "Z260Trn_ThemeFontFamily", Z260Trn_ThemeFontFamily);
         GxWebStd.gx_hidden_field( context, "Z399Trn_ThemeFontSize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z399Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_42", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_42_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_51", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_51_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_64_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
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
         GxWebStd.gx_hidden_field( context, "vTRN_THEMEID", AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV13Trn_ThemeId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV14Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13Trn_ThemeId.ToString());
         return formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Theme" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Theme", "") ;
      }

      protected void InitializeNonKey0W46( )
      {
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A248Trn_ThemeName = "";
         AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
         A260Trn_ThemeFontFamily = "";
         AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
         A399Trn_ThemeFontSize = 0;
         AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         Z399Trn_ThemeFontSize = 0;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0W46( )
      {
         A247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         InitializeNonKey0W46( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0W112( )
      {
         A564CtaColorName = "";
         A565CtaColorCode = "";
         Z564CtaColorName = "";
         Z565CtaColorCode = "";
      }

      protected void InitAll0W112( )
      {
         A563CtaColorId = Guid.NewGuid( );
         InitializeNonKey0W112( ) ;
      }

      protected void StandaloneModalInsert0W112( )
      {
      }

      protected void InitializeNonKey0W87( )
      {
         A443IconCategory = "";
         A262IconName = "";
         A263IconSVG = "";
         Z443IconCategory = "";
         Z262IconName = "";
      }

      protected void InitAll0W87( )
      {
         A261IconId = Guid.NewGuid( );
         InitializeNonKey0W87( ) ;
      }

      protected void StandaloneModalInsert0W87( )
      {
      }

      protected void InitializeNonKey0W47( )
      {
         A250ColorName = "";
         A251ColorCode = "";
         Z250ColorName = "";
         Z251ColorCode = "";
      }

      protected void InitAll0W47( )
      {
         A249ColorId = Guid.NewGuid( );
         InitializeNonKey0W47( ) ;
      }

      protected void StandaloneModalInsert0W47( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253152155844", true, true);
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
         context.AddJavascriptSource("trn_theme.js", "?20253152155844", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties112( )
      {
         edtCtaColorId_Enabled = defedtCtaColorId_Enabled;
         AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
      }

      protected void init_level_properties87( )
      {
         edtIconId_Enabled = defedtIconId_Enabled;
         AssignProp("", false, edtIconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconId_Enabled), 5, 0), !bGXsfl_51_Refreshing);
      }

      protected void init_level_properties47( )
      {
         edtColorId_Enabled = defedtColorId_Enabled;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void StartGridControl42( )
      {
         Gridlevel_ctacolorContainer.AddObjectProperty("GridName", "Gridlevel_ctacolor");
         Gridlevel_ctacolorContainer.AddObjectProperty("Header", subGridlevel_ctacolor_Header);
         Gridlevel_ctacolorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_ctacolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_ctacolorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A563CtaColorId.ToString()));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A564CtaColorName));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A565CtaColorCode));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Selectedindex), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowselection), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowhovering), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl51( )
      {
         Gridlevel_iconContainer.AddObjectProperty("GridName", "Gridlevel_icon");
         Gridlevel_iconContainer.AddObjectProperty("Header", subGridlevel_icon_Header);
         Gridlevel_iconContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_iconContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_iconContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A261IconId.ToString()));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconId_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A262IconName));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A443IconCategory));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A263IconSVG));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Selectedindex), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowselection), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowhovering), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl64( )
      {
         Gridlevel_colorContainer.AddObjectProperty("GridName", "Gridlevel_color");
         Gridlevel_colorContainer.AddObjectProperty("Header", subGridlevel_color_Header);
         Gridlevel_colorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_colorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_colorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A249ColorId.ToString()));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A250ColorName));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A251ColorCode));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectedindex), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowselection), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowhovering), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTrn_ThemeId_Internalname = "TRN_THEMEID";
         edtTrn_ThemeName_Internalname = "TRN_THEMENAME";
         edtTrn_ThemeFontFamily_Internalname = "TRN_THEMEFONTFAMILY";
         edtTrn_ThemeFontSize_Internalname = "TRN_THEMEFONTSIZE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtCtaColorId_Internalname = "CTACOLORID";
         edtCtaColorName_Internalname = "CTACOLORNAME";
         edtCtaColorCode_Internalname = "CTACOLORCODE";
         divTableleaflevel_ctacolor_Internalname = "TABLELEAFLEVEL_CTACOLOR";
         edtIconId_Internalname = "ICONID";
         edtIconName_Internalname = "ICONNAME";
         cmbIconCategory_Internalname = "ICONCATEGORY";
         edtIconSVG_Internalname = "ICONSVG";
         divTableleaflevel_icon_Internalname = "TABLELEAFLEVEL_ICON";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtColorId_Internalname = "COLORID";
         cmbColorName_Internalname = "COLORNAME";
         edtColorCode_Internalname = "COLORCODE";
         divTableleaflevel_color_Internalname = "TABLELEAFLEVEL_COLOR";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_ctacolor_Internalname = "GRIDLEVEL_CTACOLOR";
         subGridlevel_icon_Internalname = "GRIDLEVEL_ICON";
         subGridlevel_color_Internalname = "GRIDLEVEL_COLOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_color_Allowcollapsing = 0;
         subGridlevel_color_Allowselection = 0;
         subGridlevel_color_Header = "";
         subGridlevel_icon_Allowcollapsing = 0;
         subGridlevel_icon_Allowselection = 0;
         subGridlevel_icon_Header = "";
         subGridlevel_ctacolor_Allowcollapsing = 0;
         subGridlevel_ctacolor_Allowselection = 0;
         subGridlevel_ctacolor_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Theme", "");
         edtColorCode_Jsonclick = "";
         cmbColorName_Jsonclick = "";
         edtColorId_Jsonclick = "";
         subGridlevel_color_Class = "WorkWith";
         subGridlevel_color_Backcolorstyle = 0;
         edtIconSVG_Jsonclick = "";
         cmbIconCategory_Jsonclick = "";
         edtIconName_Jsonclick = "";
         edtIconId_Jsonclick = "";
         subGridlevel_icon_Class = "WorkWith";
         subGridlevel_icon_Backcolorstyle = 0;
         edtCtaColorCode_Jsonclick = "";
         edtCtaColorName_Jsonclick = "";
         edtCtaColorId_Jsonclick = "";
         subGridlevel_ctacolor_Class = "WorkWith";
         subGridlevel_ctacolor_Backcolorstyle = 0;
         edtColorCode_Enabled = 1;
         cmbColorName.Enabled = 1;
         edtColorId_Enabled = 0;
         edtIconSVG_Enabled = 1;
         cmbIconCategory.Enabled = 1;
         edtIconName_Enabled = 1;
         edtIconId_Enabled = 1;
         edtCtaColorCode_Enabled = 1;
         edtCtaColorName_Enabled = 1;
         edtCtaColorId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_ThemeFontSize_Jsonclick = "";
         edtTrn_ThemeFontSize_Enabled = 1;
         edtTrn_ThemeFontFamily_Jsonclick = "";
         edtTrn_ThemeFontFamily_Enabled = 1;
         edtTrn_ThemeName_Jsonclick = "";
         edtTrn_ThemeName_Enabled = 1;
         edtTrn_ThemeId_Jsonclick = "";
         edtTrn_ThemeId_Enabled = 1;
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

      protected void gxnrGridlevel_ctacolor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_42112( ) ;
         while ( nGXsfl_42_idx <= nRC_GXsfl_42 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0W112( ) ;
            standaloneModal0W112( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0W112( ) ;
            nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
            SubsflControlProps_42112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_ctacolorContainer)) ;
         /* End function gxnrGridlevel_ctacolor_newrow */
      }

      protected void gxnrGridlevel_icon_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5187( ) ;
         while ( nGXsfl_51_idx <= nRC_GXsfl_51 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0W87( ) ;
            standaloneModal0W87( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0W87( ) ;
            nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_5187( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_iconContainer)) ;
         /* End function gxnrGridlevel_icon_newrow */
      }

      protected void gxnrGridlevel_color_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6447( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0W47( ) ;
            standaloneModal0W47( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0W47( ) ;
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_6447( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_colorContainer)) ;
         /* End function gxnrGridlevel_color_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
         cmbIconCategory.Name = GXCCtl;
         cmbIconCategory.WebTags = "";
         cmbIconCategory.addItem("General", context.GetMessage( "General", ""), 0);
         cmbIconCategory.addItem("Services", context.GetMessage( "Services", ""), 0);
         cmbIconCategory.addItem("Living", context.GetMessage( "Living", ""), 0);
         cmbIconCategory.addItem("Health", context.GetMessage( "Health", ""), 0);
         if ( cmbIconCategory.ItemCount > 0 )
         {
            A443IconCategory = cmbIconCategory.getValidValue(A443IconCategory);
         }
         GXCCtl = "COLORNAME_" + sGXsfl_64_idx;
         cmbColorName.Name = GXCCtl;
         cmbColorName.WebTags = "";
         cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
         cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
         cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
         cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
         cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
         cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
         cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
         cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
         cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
         cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
         if ( cmbColorName.ItemCount > 0 )
         {
            A250ColorName = cmbColorName.getValidValue(A250ColorName);
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

      public void Valid_Ctacolorname( )
      {
         n247Trn_ThemeId = false;
         /* Using cursor T000W43 */
         pr_default.execute(41, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A564CtaColorName, A563CtaColorId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(41);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Iconcategory( )
      {
         n247Trn_ThemeId = false;
         A443IconCategory = cmbIconCategory.CurrentValue;
         /* Using cursor T000W44 */
         pr_default.execute(42, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A262IconName, A443IconCategory, A261IconId});
         if ( (pr_default.getStatus(42) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(42);
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "ICONCATEGORY");
            AnyError = 1;
            GX_FocusControl = cmbIconCategory_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Colorname( )
      {
         n247Trn_ThemeId = false;
         A250ColorName = cmbColorName.CurrentValue;
         /* Using cursor T000W45 */
         pr_default.execute(43, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A249ColorId});
         if ( (pr_default.getStatus(43) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(43);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Colorcode( )
      {
         n247Trn_ThemeId = false;
         A250ColorName = cmbColorName.CurrentValue;
         /* Using cursor T000W46 */
         pr_default.execute(44, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId, A250ColorName, A251ColorCode, A249ColorId});
         if ( (pr_default.getStatus(44) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(44);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV13Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120W2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRN_THEMEID","""{"handler":"Valid_Trn_themeid","iparms":[]}""");
         setEventMetadata("VALID_CTACOLORID","""{"handler":"Valid_Ctacolorid","iparms":[]}""");
         setEventMetadata("VALID_CTACOLORNAME","""{"handler":"Valid_Ctacolorname","iparms":[{"av":"A247Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"A564CtaColorName","fld":"CTACOLORNAME"},{"av":"A563CtaColorId","fld":"CTACOLORID"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Ctacolorcode","iparms":[]}""");
         setEventMetadata("VALID_ICONID","""{"handler":"Valid_Iconid","iparms":[]}""");
         setEventMetadata("VALID_ICONNAME","""{"handler":"Valid_Iconname","iparms":[]}""");
         setEventMetadata("VALID_ICONCATEGORY","""{"handler":"Valid_Iconcategory","iparms":[{"av":"A247Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"A262IconName","fld":"ICONNAME"},{"av":"cmbIconCategory"},{"av":"A443IconCategory","fld":"ICONCATEGORY"},{"av":"A261IconId","fld":"ICONID"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Iconsvg","iparms":[]}""");
         setEventMetadata("VALID_COLORID","""{"handler":"Valid_Colorid","iparms":[]}""");
         setEventMetadata("VALID_COLORNAME","""{"handler":"Valid_Colorname","iparms":[{"av":"A247Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"cmbColorName"},{"av":"A250ColorName","fld":"COLORNAME"},{"av":"A249ColorId","fld":"COLORID"}]}""");
         setEventMetadata("VALID_COLORCODE","""{"handler":"Valid_Colorcode","iparms":[{"av":"A247Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"cmbColorName"},{"av":"A250ColorName","fld":"COLORNAME"},{"av":"A251ColorCode","fld":"COLORCODE"},{"av":"A249ColorId","fld":"COLORID"}]}""");
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
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(7);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV13Trn_ThemeId = Guid.Empty;
         Z247Trn_ThemeId = Guid.Empty;
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         Z11OrganisationId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         Z563CtaColorId = Guid.Empty;
         Z564CtaColorName = "";
         Z565CtaColorCode = "";
         Z261IconId = Guid.Empty;
         Z443IconCategory = "";
         Z262IconName = "";
         Z249ColorId = Guid.Empty;
         Z250ColorName = "";
         Z251ColorCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A247Trn_ThemeId = Guid.Empty;
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         lblTextblock1_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_ctacolorContainer = new GXWebGrid( context);
         sMode112 = "";
         A563CtaColorId = Guid.Empty;
         sStyleString = "";
         Gridlevel_iconContainer = new GXWebGrid( context);
         sMode87 = "";
         A261IconId = Guid.Empty;
         Gridlevel_colorContainer = new GXWebGrid( context);
         sMode47 = "";
         A249ColorId = Guid.Empty;
         AV14Insert_OrganisationId = Guid.Empty;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode46 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A250ColorName = "";
         A251ColorCode = "";
         GXCCtl = "";
         A262IconName = "";
         A443IconCategory = "";
         A263IconSVG = "";
         A564CtaColorName = "";
         A565CtaColorCode = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T000W11_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W11_n247Trn_ThemeId = new bool[] {false} ;
         T000W11_A248Trn_ThemeName = new string[] {""} ;
         T000W11_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W11_A399Trn_ThemeFontSize = new short[1] ;
         T000W11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W11_n11OrganisationId = new bool[] {false} ;
         T000W10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W10_n11OrganisationId = new bool[] {false} ;
         T000W12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W12_n11OrganisationId = new bool[] {false} ;
         T000W13_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W13_n247Trn_ThemeId = new bool[] {false} ;
         T000W9_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W9_n247Trn_ThemeId = new bool[] {false} ;
         T000W9_A248Trn_ThemeName = new string[] {""} ;
         T000W9_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W9_A399Trn_ThemeFontSize = new short[1] ;
         T000W9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W9_n11OrganisationId = new bool[] {false} ;
         T000W14_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W14_n247Trn_ThemeId = new bool[] {false} ;
         T000W15_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W15_n247Trn_ThemeId = new bool[] {false} ;
         T000W8_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W8_n247Trn_ThemeId = new bool[] {false} ;
         T000W8_A248Trn_ThemeName = new string[] {""} ;
         T000W8_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W8_A399Trn_ThemeFontSize = new short[1] ;
         T000W8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W8_n11OrganisationId = new bool[] {false} ;
         T000W19_A29LocationId = new Guid[] {Guid.Empty} ;
         T000W19_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000W19_n11OrganisationId = new bool[] {false} ;
         T000W20_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W20_n247Trn_ThemeId = new bool[] {false} ;
         T000W21_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W21_n247Trn_ThemeId = new bool[] {false} ;
         T000W21_A563CtaColorId = new Guid[] {Guid.Empty} ;
         T000W21_A564CtaColorName = new string[] {""} ;
         T000W21_A565CtaColorCode = new string[] {""} ;
         T000W22_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W22_n247Trn_ThemeId = new bool[] {false} ;
         T000W23_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W23_n247Trn_ThemeId = new bool[] {false} ;
         T000W23_A563CtaColorId = new Guid[] {Guid.Empty} ;
         T000W7_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W7_n247Trn_ThemeId = new bool[] {false} ;
         T000W7_A563CtaColorId = new Guid[] {Guid.Empty} ;
         T000W7_A564CtaColorName = new string[] {""} ;
         T000W7_A565CtaColorCode = new string[] {""} ;
         T000W6_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W6_n247Trn_ThemeId = new bool[] {false} ;
         T000W6_A563CtaColorId = new Guid[] {Guid.Empty} ;
         T000W6_A564CtaColorName = new string[] {""} ;
         T000W6_A565CtaColorCode = new string[] {""} ;
         T000W27_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W27_n247Trn_ThemeId = new bool[] {false} ;
         T000W27_A563CtaColorId = new Guid[] {Guid.Empty} ;
         Z263IconSVG = "";
         T000W28_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W28_n247Trn_ThemeId = new bool[] {false} ;
         T000W28_A261IconId = new Guid[] {Guid.Empty} ;
         T000W28_A443IconCategory = new string[] {""} ;
         T000W28_A262IconName = new string[] {""} ;
         T000W28_A263IconSVG = new string[] {""} ;
         T000W29_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W29_n247Trn_ThemeId = new bool[] {false} ;
         T000W30_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W30_n247Trn_ThemeId = new bool[] {false} ;
         T000W30_A261IconId = new Guid[] {Guid.Empty} ;
         T000W5_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W5_n247Trn_ThemeId = new bool[] {false} ;
         T000W5_A261IconId = new Guid[] {Guid.Empty} ;
         T000W5_A443IconCategory = new string[] {""} ;
         T000W5_A262IconName = new string[] {""} ;
         T000W5_A263IconSVG = new string[] {""} ;
         T000W4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W4_n247Trn_ThemeId = new bool[] {false} ;
         T000W4_A261IconId = new Guid[] {Guid.Empty} ;
         T000W4_A443IconCategory = new string[] {""} ;
         T000W4_A262IconName = new string[] {""} ;
         T000W4_A263IconSVG = new string[] {""} ;
         T000W34_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W34_n247Trn_ThemeId = new bool[] {false} ;
         T000W34_A261IconId = new Guid[] {Guid.Empty} ;
         T000W35_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W35_n247Trn_ThemeId = new bool[] {false} ;
         T000W35_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W35_A250ColorName = new string[] {""} ;
         T000W35_A251ColorCode = new string[] {""} ;
         T000W36_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W36_n247Trn_ThemeId = new bool[] {false} ;
         T000W37_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W37_n247Trn_ThemeId = new bool[] {false} ;
         T000W38_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W38_n247Trn_ThemeId = new bool[] {false} ;
         T000W38_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W3_n247Trn_ThemeId = new bool[] {false} ;
         T000W3_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W3_A250ColorName = new string[] {""} ;
         T000W3_A251ColorCode = new string[] {""} ;
         T000W2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W2_n247Trn_ThemeId = new bool[] {false} ;
         T000W2_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W2_A250ColorName = new string[] {""} ;
         T000W2_A251ColorCode = new string[] {""} ;
         T000W42_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W42_n247Trn_ThemeId = new bool[] {false} ;
         T000W42_A249ColorId = new Guid[] {Guid.Empty} ;
         Gridlevel_ctacolorRow = new GXWebRow();
         subGridlevel_ctacolor_Linesclass = "";
         ROClassString = "";
         Gridlevel_iconRow = new GXWebRow();
         subGridlevel_icon_Linesclass = "";
         Gridlevel_colorRow = new GXWebRow();
         subGridlevel_color_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridlevel_ctacolorColumn = new GXWebColumn();
         Gridlevel_iconColumn = new GXWebColumn();
         Gridlevel_colorColumn = new GXWebColumn();
         T000W43_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W43_n247Trn_ThemeId = new bool[] {false} ;
         T000W44_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W44_n247Trn_ThemeId = new bool[] {false} ;
         T000W45_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W45_n247Trn_ThemeId = new bool[] {false} ;
         T000W46_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W46_n247Trn_ThemeId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__default(),
            new Object[][] {
                new Object[] {
               T000W2_A247Trn_ThemeId, T000W2_A249ColorId, T000W2_A250ColorName, T000W2_A251ColorCode
               }
               , new Object[] {
               T000W3_A247Trn_ThemeId, T000W3_A249ColorId, T000W3_A250ColorName, T000W3_A251ColorCode
               }
               , new Object[] {
               T000W4_A247Trn_ThemeId, T000W4_A261IconId, T000W4_A443IconCategory, T000W4_A262IconName, T000W4_A263IconSVG
               }
               , new Object[] {
               T000W5_A247Trn_ThemeId, T000W5_A261IconId, T000W5_A443IconCategory, T000W5_A262IconName, T000W5_A263IconSVG
               }
               , new Object[] {
               T000W6_A247Trn_ThemeId, T000W6_A563CtaColorId, T000W6_A564CtaColorName, T000W6_A565CtaColorCode
               }
               , new Object[] {
               T000W7_A247Trn_ThemeId, T000W7_A563CtaColorId, T000W7_A564CtaColorName, T000W7_A565CtaColorCode
               }
               , new Object[] {
               T000W8_A247Trn_ThemeId, T000W8_A248Trn_ThemeName, T000W8_A260Trn_ThemeFontFamily, T000W8_A399Trn_ThemeFontSize, T000W8_A11OrganisationId, T000W8_n11OrganisationId
               }
               , new Object[] {
               T000W9_A247Trn_ThemeId, T000W9_A248Trn_ThemeName, T000W9_A260Trn_ThemeFontFamily, T000W9_A399Trn_ThemeFontSize, T000W9_A11OrganisationId, T000W9_n11OrganisationId
               }
               , new Object[] {
               T000W10_A11OrganisationId
               }
               , new Object[] {
               T000W11_A247Trn_ThemeId, T000W11_A248Trn_ThemeName, T000W11_A260Trn_ThemeFontFamily, T000W11_A399Trn_ThemeFontSize, T000W11_A11OrganisationId, T000W11_n11OrganisationId
               }
               , new Object[] {
               T000W12_A11OrganisationId
               }
               , new Object[] {
               T000W13_A247Trn_ThemeId
               }
               , new Object[] {
               T000W14_A247Trn_ThemeId
               }
               , new Object[] {
               T000W15_A247Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W19_A29LocationId, T000W19_A11OrganisationId
               }
               , new Object[] {
               T000W20_A247Trn_ThemeId
               }
               , new Object[] {
               T000W21_A247Trn_ThemeId, T000W21_A563CtaColorId, T000W21_A564CtaColorName, T000W21_A565CtaColorCode
               }
               , new Object[] {
               T000W22_A247Trn_ThemeId
               }
               , new Object[] {
               T000W23_A247Trn_ThemeId, T000W23_A563CtaColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W27_A247Trn_ThemeId, T000W27_A563CtaColorId
               }
               , new Object[] {
               T000W28_A247Trn_ThemeId, T000W28_A261IconId, T000W28_A443IconCategory, T000W28_A262IconName, T000W28_A263IconSVG
               }
               , new Object[] {
               T000W29_A247Trn_ThemeId
               }
               , new Object[] {
               T000W30_A247Trn_ThemeId, T000W30_A261IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W34_A247Trn_ThemeId, T000W34_A261IconId
               }
               , new Object[] {
               T000W35_A247Trn_ThemeId, T000W35_A249ColorId, T000W35_A250ColorName, T000W35_A251ColorCode
               }
               , new Object[] {
               T000W36_A247Trn_ThemeId
               }
               , new Object[] {
               T000W37_A247Trn_ThemeId
               }
               , new Object[] {
               T000W38_A247Trn_ThemeId, T000W38_A249ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W42_A247Trn_ThemeId, T000W42_A249ColorId
               }
               , new Object[] {
               T000W43_A247Trn_ThemeId
               }
               , new Object[] {
               T000W44_A247Trn_ThemeId
               }
               , new Object[] {
               T000W45_A247Trn_ThemeId
               }
               , new Object[] {
               T000W46_A247Trn_ThemeId
               }
            }
         );
         Z249ColorId = Guid.NewGuid( );
         A249ColorId = Guid.NewGuid( );
         Z261IconId = Guid.NewGuid( );
         A261IconId = Guid.NewGuid( );
         Z563CtaColorId = Guid.NewGuid( );
         A563CtaColorId = Guid.NewGuid( );
         Z247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         A247Trn_ThemeId = Guid.NewGuid( );
         n247Trn_ThemeId = false;
         AV16Pgmname = "Trn_Theme";
      }

      private short Z399Trn_ThemeFontSize ;
      private short nRcdDeleted_112 ;
      private short nRcdExists_112 ;
      private short nIsMod_112 ;
      private short nRcdDeleted_87 ;
      private short nRcdExists_87 ;
      private short nIsMod_87 ;
      private short nRcdDeleted_47 ;
      private short nRcdExists_47 ;
      private short nIsMod_47 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A399Trn_ThemeFontSize ;
      private short nBlankRcdCount112 ;
      private short RcdFound112 ;
      private short nBlankRcdUsr112 ;
      private short nBlankRcdCount87 ;
      private short RcdFound87 ;
      private short nBlankRcdUsr87 ;
      private short nBlankRcdCount47 ;
      private short RcdFound47 ;
      private short nBlankRcdUsr47 ;
      private short RcdFound46 ;
      private short nIsDirty_112 ;
      private short nIsDirty_87 ;
      private short nIsDirty_47 ;
      private short subGridlevel_ctacolor_Backcolorstyle ;
      private short subGridlevel_ctacolor_Backstyle ;
      private short subGridlevel_icon_Backcolorstyle ;
      private short subGridlevel_icon_Backstyle ;
      private short subGridlevel_color_Backcolorstyle ;
      private short subGridlevel_color_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_ctacolor_Allowselection ;
      private short subGridlevel_ctacolor_Allowhovering ;
      private short subGridlevel_ctacolor_Allowcollapsing ;
      private short subGridlevel_ctacolor_Collapsed ;
      private short subGridlevel_icon_Allowselection ;
      private short subGridlevel_icon_Allowhovering ;
      private short subGridlevel_icon_Allowcollapsing ;
      private short subGridlevel_icon_Collapsed ;
      private short subGridlevel_color_Allowselection ;
      private short subGridlevel_color_Allowhovering ;
      private short subGridlevel_color_Allowcollapsing ;
      private short subGridlevel_color_Collapsed ;
      private int nRC_GXsfl_42 ;
      private int nGXsfl_42_idx=1 ;
      private int nRC_GXsfl_51 ;
      private int nGXsfl_51_idx=1 ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int trnEnded ;
      private int edtTrn_ThemeId_Enabled ;
      private int edtTrn_ThemeName_Enabled ;
      private int edtTrn_ThemeFontFamily_Enabled ;
      private int edtTrn_ThemeFontSize_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCtaColorId_Enabled ;
      private int edtCtaColorName_Enabled ;
      private int edtCtaColorCode_Enabled ;
      private int fRowAdded ;
      private int edtIconId_Enabled ;
      private int edtIconName_Enabled ;
      private int edtIconSVG_Enabled ;
      private int edtColorId_Enabled ;
      private int edtColorCode_Enabled ;
      private int AV17GXV1 ;
      private int subGridlevel_ctacolor_Backcolor ;
      private int subGridlevel_ctacolor_Allbackcolor ;
      private int subGridlevel_icon_Backcolor ;
      private int subGridlevel_icon_Allbackcolor ;
      private int subGridlevel_color_Backcolor ;
      private int subGridlevel_color_Allbackcolor ;
      private int defedtColorId_Enabled ;
      private int defedtIconId_Enabled ;
      private int defedtCtaColorId_Enabled ;
      private int idxLst ;
      private int subGridlevel_ctacolor_Selectedindex ;
      private int subGridlevel_ctacolor_Selectioncolor ;
      private int subGridlevel_ctacolor_Hoveringcolor ;
      private int subGridlevel_icon_Selectedindex ;
      private int subGridlevel_icon_Selectioncolor ;
      private int subGridlevel_icon_Hoveringcolor ;
      private int subGridlevel_color_Selectedindex ;
      private int subGridlevel_color_Selectioncolor ;
      private int subGridlevel_color_Hoveringcolor ;
      private long GRIDLEVEL_CTACOLOR_nFirstRecordOnPage ;
      private long GRIDLEVEL_ICON_nFirstRecordOnPage ;
      private long GRIDLEVEL_COLOR_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_ThemeId_Internalname ;
      private string sGXsfl_42_idx="0001" ;
      private string sGXsfl_51_idx="0001" ;
      private string sGXsfl_64_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_ThemeId_Jsonclick ;
      private string edtTrn_ThemeName_Internalname ;
      private string edtTrn_ThemeName_Jsonclick ;
      private string edtTrn_ThemeFontFamily_Internalname ;
      private string edtTrn_ThemeFontFamily_Jsonclick ;
      private string edtTrn_ThemeFontSize_Internalname ;
      private string edtTrn_ThemeFontSize_Jsonclick ;
      private string divTableleaflevel_ctacolor_Internalname ;
      private string divTableleaflevel_icon_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTableleaflevel_color_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode112 ;
      private string edtCtaColorId_Internalname ;
      private string edtCtaColorName_Internalname ;
      private string edtCtaColorCode_Internalname ;
      private string sStyleString ;
      private string subGridlevel_ctacolor_Internalname ;
      private string sMode87 ;
      private string edtIconId_Internalname ;
      private string edtIconName_Internalname ;
      private string cmbIconCategory_Internalname ;
      private string edtIconSVG_Internalname ;
      private string subGridlevel_icon_Internalname ;
      private string sMode47 ;
      private string edtColorId_Internalname ;
      private string cmbColorName_Internalname ;
      private string edtColorCode_Internalname ;
      private string subGridlevel_color_Internalname ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode46 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_42_fel_idx="0001" ;
      private string subGridlevel_ctacolor_Class ;
      private string subGridlevel_ctacolor_Linesclass ;
      private string ROClassString ;
      private string edtCtaColorId_Jsonclick ;
      private string edtCtaColorName_Jsonclick ;
      private string edtCtaColorCode_Jsonclick ;
      private string sGXsfl_51_fel_idx="0001" ;
      private string subGridlevel_icon_Class ;
      private string subGridlevel_icon_Linesclass ;
      private string edtIconId_Jsonclick ;
      private string edtIconName_Jsonclick ;
      private string cmbIconCategory_Jsonclick ;
      private string edtIconSVG_Jsonclick ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGridlevel_color_Class ;
      private string subGridlevel_color_Linesclass ;
      private string edtColorId_Jsonclick ;
      private string cmbColorName_Jsonclick ;
      private string edtColorCode_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_ctacolor_Header ;
      private string subGridlevel_icon_Header ;
      private string subGridlevel_color_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool bGXsfl_42_Refreshing=false ;
      private bool bGXsfl_51_Refreshing=false ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n247Trn_ThemeId ;
      private bool returnInSub ;
      private string A263IconSVG ;
      private string Z263IconSVG ;
      private string Z248Trn_ThemeName ;
      private string Z260Trn_ThemeFontFamily ;
      private string Z564CtaColorName ;
      private string Z565CtaColorCode ;
      private string Z443IconCategory ;
      private string Z262IconName ;
      private string Z250ColorName ;
      private string Z251ColorCode ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private string A250ColorName ;
      private string A251ColorCode ;
      private string A262IconName ;
      private string A443IconCategory ;
      private string A564CtaColorName ;
      private string A565CtaColorCode ;
      private Guid wcpOAV13Trn_ThemeId ;
      private Guid Z247Trn_ThemeId ;
      private Guid Z11OrganisationId ;
      private Guid N11OrganisationId ;
      private Guid Z563CtaColorId ;
      private Guid Z261IconId ;
      private Guid Z249ColorId ;
      private Guid A11OrganisationId ;
      private Guid AV13Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid A563CtaColorId ;
      private Guid A261IconId ;
      private Guid A249ColorId ;
      private Guid AV14Insert_OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_ctacolorContainer ;
      private GXWebGrid Gridlevel_iconContainer ;
      private GXWebGrid Gridlevel_colorContainer ;
      private GXWebRow Gridlevel_ctacolorRow ;
      private GXWebRow Gridlevel_iconRow ;
      private GXWebRow Gridlevel_colorRow ;
      private GXWebColumn Gridlevel_ctacolorColumn ;
      private GXWebColumn Gridlevel_iconColumn ;
      private GXWebColumn Gridlevel_colorColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbIconCategory ;
      private GXCombobox cmbColorName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000W11_A247Trn_ThemeId ;
      private bool[] T000W11_n247Trn_ThemeId ;
      private string[] T000W11_A248Trn_ThemeName ;
      private string[] T000W11_A260Trn_ThemeFontFamily ;
      private short[] T000W11_A399Trn_ThemeFontSize ;
      private Guid[] T000W11_A11OrganisationId ;
      private bool[] T000W11_n11OrganisationId ;
      private Guid[] T000W10_A11OrganisationId ;
      private bool[] T000W10_n11OrganisationId ;
      private Guid[] T000W12_A11OrganisationId ;
      private bool[] T000W12_n11OrganisationId ;
      private Guid[] T000W13_A247Trn_ThemeId ;
      private bool[] T000W13_n247Trn_ThemeId ;
      private Guid[] T000W9_A247Trn_ThemeId ;
      private bool[] T000W9_n247Trn_ThemeId ;
      private string[] T000W9_A248Trn_ThemeName ;
      private string[] T000W9_A260Trn_ThemeFontFamily ;
      private short[] T000W9_A399Trn_ThemeFontSize ;
      private Guid[] T000W9_A11OrganisationId ;
      private bool[] T000W9_n11OrganisationId ;
      private Guid[] T000W14_A247Trn_ThemeId ;
      private bool[] T000W14_n247Trn_ThemeId ;
      private Guid[] T000W15_A247Trn_ThemeId ;
      private bool[] T000W15_n247Trn_ThemeId ;
      private Guid[] T000W8_A247Trn_ThemeId ;
      private bool[] T000W8_n247Trn_ThemeId ;
      private string[] T000W8_A248Trn_ThemeName ;
      private string[] T000W8_A260Trn_ThemeFontFamily ;
      private short[] T000W8_A399Trn_ThemeFontSize ;
      private Guid[] T000W8_A11OrganisationId ;
      private bool[] T000W8_n11OrganisationId ;
      private Guid[] T000W19_A29LocationId ;
      private Guid[] T000W19_A11OrganisationId ;
      private bool[] T000W19_n11OrganisationId ;
      private Guid[] T000W20_A247Trn_ThemeId ;
      private bool[] T000W20_n247Trn_ThemeId ;
      private Guid[] T000W21_A247Trn_ThemeId ;
      private bool[] T000W21_n247Trn_ThemeId ;
      private Guid[] T000W21_A563CtaColorId ;
      private string[] T000W21_A564CtaColorName ;
      private string[] T000W21_A565CtaColorCode ;
      private Guid[] T000W22_A247Trn_ThemeId ;
      private bool[] T000W22_n247Trn_ThemeId ;
      private Guid[] T000W23_A247Trn_ThemeId ;
      private bool[] T000W23_n247Trn_ThemeId ;
      private Guid[] T000W23_A563CtaColorId ;
      private Guid[] T000W7_A247Trn_ThemeId ;
      private bool[] T000W7_n247Trn_ThemeId ;
      private Guid[] T000W7_A563CtaColorId ;
      private string[] T000W7_A564CtaColorName ;
      private string[] T000W7_A565CtaColorCode ;
      private Guid[] T000W6_A247Trn_ThemeId ;
      private bool[] T000W6_n247Trn_ThemeId ;
      private Guid[] T000W6_A563CtaColorId ;
      private string[] T000W6_A564CtaColorName ;
      private string[] T000W6_A565CtaColorCode ;
      private Guid[] T000W27_A247Trn_ThemeId ;
      private bool[] T000W27_n247Trn_ThemeId ;
      private Guid[] T000W27_A563CtaColorId ;
      private Guid[] T000W28_A247Trn_ThemeId ;
      private bool[] T000W28_n247Trn_ThemeId ;
      private Guid[] T000W28_A261IconId ;
      private string[] T000W28_A443IconCategory ;
      private string[] T000W28_A262IconName ;
      private string[] T000W28_A263IconSVG ;
      private Guid[] T000W29_A247Trn_ThemeId ;
      private bool[] T000W29_n247Trn_ThemeId ;
      private Guid[] T000W30_A247Trn_ThemeId ;
      private bool[] T000W30_n247Trn_ThemeId ;
      private Guid[] T000W30_A261IconId ;
      private Guid[] T000W5_A247Trn_ThemeId ;
      private bool[] T000W5_n247Trn_ThemeId ;
      private Guid[] T000W5_A261IconId ;
      private string[] T000W5_A443IconCategory ;
      private string[] T000W5_A262IconName ;
      private string[] T000W5_A263IconSVG ;
      private Guid[] T000W4_A247Trn_ThemeId ;
      private bool[] T000W4_n247Trn_ThemeId ;
      private Guid[] T000W4_A261IconId ;
      private string[] T000W4_A443IconCategory ;
      private string[] T000W4_A262IconName ;
      private string[] T000W4_A263IconSVG ;
      private Guid[] T000W34_A247Trn_ThemeId ;
      private bool[] T000W34_n247Trn_ThemeId ;
      private Guid[] T000W34_A261IconId ;
      private Guid[] T000W35_A247Trn_ThemeId ;
      private bool[] T000W35_n247Trn_ThemeId ;
      private Guid[] T000W35_A249ColorId ;
      private string[] T000W35_A250ColorName ;
      private string[] T000W35_A251ColorCode ;
      private Guid[] T000W36_A247Trn_ThemeId ;
      private bool[] T000W36_n247Trn_ThemeId ;
      private Guid[] T000W37_A247Trn_ThemeId ;
      private bool[] T000W37_n247Trn_ThemeId ;
      private Guid[] T000W38_A247Trn_ThemeId ;
      private bool[] T000W38_n247Trn_ThemeId ;
      private Guid[] T000W38_A249ColorId ;
      private Guid[] T000W3_A247Trn_ThemeId ;
      private bool[] T000W3_n247Trn_ThemeId ;
      private Guid[] T000W3_A249ColorId ;
      private string[] T000W3_A250ColorName ;
      private string[] T000W3_A251ColorCode ;
      private Guid[] T000W2_A247Trn_ThemeId ;
      private bool[] T000W2_n247Trn_ThemeId ;
      private Guid[] T000W2_A249ColorId ;
      private string[] T000W2_A250ColorName ;
      private string[] T000W2_A251ColorCode ;
      private Guid[] T000W42_A247Trn_ThemeId ;
      private bool[] T000W42_n247Trn_ThemeId ;
      private Guid[] T000W42_A249ColorId ;
      private Guid[] T000W43_A247Trn_ThemeId ;
      private bool[] T000W43_n247Trn_ThemeId ;
      private Guid[] T000W44_A247Trn_ThemeId ;
      private bool[] T000W44_n247Trn_ThemeId ;
      private Guid[] T000W45_A247Trn_ThemeId ;
      private bool[] T000W45_n247Trn_ThemeId ;
      private Guid[] T000W46_A247Trn_ThemeId ;
      private bool[] T000W46_n247Trn_ThemeId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_theme__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new UpdateCursor(def[23])
      ,new UpdateCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new ForEachCursor(def[27])
      ,new ForEachCursor(def[28])
      ,new UpdateCursor(def[29])
      ,new UpdateCursor(def[30])
      ,new UpdateCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new ForEachCursor(def[34])
      ,new ForEachCursor(def[35])
      ,new ForEachCursor(def[36])
      ,new UpdateCursor(def[37])
      ,new UpdateCursor(def[38])
      ,new UpdateCursor(def[39])
      ,new ForEachCursor(def[40])
      ,new ForEachCursor(def[41])
      ,new ForEachCursor(def[42])
      ,new ForEachCursor(def[43])
      ,new ForEachCursor(def[44])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000W2;
       prmT000W2 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W3;
       prmT000W3 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W4;
       prmT000W4 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W5;
       prmT000W5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W6;
       prmT000W6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W7;
       prmT000W7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W8;
       prmT000W8 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W9;
       prmT000W9 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W10;
       prmT000W10 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W11;
       prmT000W11 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W12;
       prmT000W12 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W13;
       prmT000W13 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W14;
       prmT000W14 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W15;
       prmT000W15 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W16;
       prmT000W16 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W17;
       prmT000W17 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W18;
       prmT000W18 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W19;
       prmT000W19 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W20;
       prmT000W20 = new Object[] {
       };
       Object[] prmT000W21;
       prmT000W21 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W22;
       prmT000W22 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W23;
       prmT000W23 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W24;
       prmT000W24 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmT000W25;
       prmT000W25 = new Object[] {
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W26;
       prmT000W26 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W27;
       prmT000W27 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W28;
       prmT000W28 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W29;
       prmT000W29 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W30;
       prmT000W30 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W31;
       prmT000W31 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT000W32;
       prmT000W32 = new Object[] {
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W33;
       prmT000W33 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W34;
       prmT000W34 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W35;
       prmT000W35 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W36;
       prmT000W36 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W37;
       prmT000W37 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W38;
       prmT000W38 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W39;
       prmT000W39 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmT000W40;
       prmT000W40 = new Object[] {
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W41;
       prmT000W41 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W42;
       prmT000W42 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000W43;
       prmT000W43 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W44;
       prmT000W44 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W45;
       prmT000W45 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000W46;
       prmT000W46 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000W2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W4", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId  FOR UPDATE OF Trn_ThemeIcon NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W5", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W6", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId  FOR UPDATE OF Trn_ThemeCtaColor NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W7", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W8", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W9", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W10", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W11", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.OrganisationId FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W11,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W12", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W13", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W14", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId > :Trn_ThemeId) ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000W15", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId < :Trn_ThemeId) ORDER BY Trn_ThemeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000W16", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily, :Trn_ThemeFontSize, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W16)
          ,new CursorDef("T000W17", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize, OrganisationId=:OrganisationId  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W17)
          ,new CursorDef("T000W18", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W18)
          ,new CursorDef("T000W19", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W19,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000W20", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W20,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W21", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W21,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W22", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W23", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W23,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W24", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W24)
          ,new CursorDef("T000W25", "SAVEPOINT gxupdate;UPDATE Trn_ThemeCtaColor SET CtaColorName=:CtaColorName, CtaColorCode=:CtaColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W25)
          ,new CursorDef("T000W26", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W26)
          ,new CursorDef("T000W27", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W27,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W28", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId and IconId = :IconId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W28,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W29", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W29,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W30", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W30,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W31", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconCategory, IconName, IconSVG) VALUES(:Trn_ThemeId, :IconId, :IconCategory, :IconName, :IconSVG);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W31)
          ,new CursorDef("T000W32", "SAVEPOINT gxupdate;UPDATE Trn_ThemeIcon SET IconCategory=:IconCategory, IconName=:IconName, IconSVG=:IconSVG  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W32)
          ,new CursorDef("T000W33", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W33)
          ,new CursorDef("T000W34", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W34,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W35", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W35,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W36", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W36,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W37", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W37,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W38", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W38,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W39", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W39)
          ,new CursorDef("T000W40", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W40)
          ,new CursorDef("T000W41", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W41)
          ,new CursorDef("T000W42", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W42,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W43", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W43,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W44", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W44,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W45", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W45,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000W46", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W46,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 27 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 28 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 32 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 33 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 34 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 35 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 36 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 40 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 41 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 42 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 43 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 44 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
