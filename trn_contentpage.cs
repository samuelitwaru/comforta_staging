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
   public class trn_contentpage : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtrn_contentpage_cta") == 0 )
         {
            gxnrGridtrn_contentpage_cta_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Content Page", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridtrn_contentpage_cta_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtrn_contentpage_cta_newrow( ) ;
         /* End function gxnrGridtrn_contentpage_cta_newrow_invoke */
      }

      public trn_contentpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_contentpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCTAType = new GXCombobox();
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
            return "trn_contentpage_Execute" ;
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Content Page", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageId_Internalname, A521PageId.ToString(), A521PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPageId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageName_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageName_Internalname, A522PageName, StringUtil.RTrim( context.localUtil.Format( A522PageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageStructure_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageStructure_Internalname, context.GetMessage( "Structure", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageStructure_Internalname, A523PageStructure, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtPageStructure_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCtatable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecta_Internalname, context.GetMessage( "CTA", ""), "", "", lblTitlecta_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridtrn_contentpage_cta( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ContentPage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridtrn_contentpage_cta( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount102 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_102 = 1;
               ScanStart1M102( ) ;
               while ( RcdFound102 != 0 )
               {
                  init_level_properties102( ) ;
                  getByPrimaryKey1M102( ) ;
                  AddRow1M102( ) ;
                  ScanNext1M102( ) ;
               }
               ScanEnd1M102( ) ;
               nBlankRcdCount102 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1M102( ) ;
            standaloneModal1M102( ) ;
            sMode102 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow1M102( ) ;
               edtCTAId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTAID_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCTAId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtCTALabel_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTALABEL_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCTALabel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTALabel_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbCTAType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTATYPE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbCTAType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCTAType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtCTAAction_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTAACTION_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCTAAction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAAction_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_102 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1M102( ) ;
               }
               SendRow1M102( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount102 = 5;
            nRcdExists_102 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1M102( ) ;
               while ( RcdFound102 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_53102( ) ;
                  init_level_properties102( ) ;
                  standaloneNotModal1M102( ) ;
                  getByPrimaryKey1M102( ) ;
                  standaloneModal1M102( ) ;
                  AddRow1M102( ) ;
                  ScanNext1M102( ) ;
               }
               ScanEnd1M102( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode102 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_53102( ) ;
         InitAll1M102( ) ;
         init_level_properties102( ) ;
         nRcdExists_102 = 0;
         nIsMod_102 = 0;
         nRcdDeleted_102 = 0;
         nBlankRcdCount102 = (short)(nBlankRcdUsr102+nBlankRcdCount102);
         fRowAdded = 0;
         while ( nBlankRcdCount102 > 0 )
         {
            A524CTAId = Guid.Empty;
            standaloneNotModal1M102( ) ;
            standaloneModal1M102( ) ;
            AddRow1M102( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtCTAId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount102 = (short)(nBlankRcdCount102-1);
         }
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtrn_contentpage_ctaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtrn_contentpage_cta", Gridtrn_contentpage_ctaContainer, subGridtrn_contentpage_cta_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_contentpage_ctaContainerData", Gridtrn_contentpage_ctaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_contentpage_ctaContainerData"+"V", Gridtrn_contentpage_ctaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtrn_contentpage_ctaContainerData"+"V"+"\" value='"+Gridtrn_contentpage_ctaContainer.GridValuesHidden()+"'/>") ;
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z521PageId = StringUtil.StrToGuid( cgiGet( "Z521PageId"));
            Z522PageName = cgiGet( "Z522PageName");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtPageId_Internalname), "") == 0 )
            {
               A521PageId = Guid.Empty;
               AssignAttri("", false, "A521PageId", A521PageId.ToString());
            }
            else
            {
               try
               {
                  A521PageId = StringUtil.StrToGuid( cgiGet( edtPageId_Internalname));
                  AssignAttri("", false, "A521PageId", A521PageId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A522PageName = cgiGet( edtPageName_Internalname);
            AssignAttri("", false, "A522PageName", A522PageName);
            A523PageStructure = cgiGet( edtPageStructure_Internalname);
            AssignAttri("", false, "A523PageStructure", A523PageStructure);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
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
               A521PageId = StringUtil.StrToGuid( GetPar( "PageId"));
               AssignAttri("", false, "A521PageId", A521PageId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A521PageId) && ( Gx_BScreen == 0 ) )
               {
                  A521PageId = Guid.NewGuid( );
                  AssignAttri("", false, "A521PageId", A521PageId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1M101( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1M101( ) ;
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

      protected void CONFIRM_1M102( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow1M102( ) ;
            if ( ( nRcdExists_102 != 0 ) || ( nIsMod_102 != 0 ) )
            {
               GetKey1M102( ) ;
               if ( ( nRcdExists_102 == 0 ) && ( nRcdDeleted_102 == 0 ) )
               {
                  if ( RcdFound102 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1M102( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1M102( ) ;
                        CloseExtendedTableCursors1M102( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CTAID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCTAId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound102 != 0 )
                  {
                     if ( nRcdDeleted_102 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1M102( ) ;
                        Load1M102( ) ;
                        BeforeValidate1M102( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1M102( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_102 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1M102( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1M102( ) ;
                              CloseExtendedTableCursors1M102( ) ;
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
                     if ( nRcdDeleted_102 == 0 )
                     {
                        GXCCtl = "CTAID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCTAId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCTAId_Internalname, A524CTAId.ToString()) ;
            ChangePostValue( edtCTALabel_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbCTAType_Internalname, A526CTAType) ;
            ChangePostValue( edtCTAAction_Internalname, A527CTAAction) ;
            ChangePostValue( "ZT_"+"Z524CTAId_"+sGXsfl_53_idx, Z524CTAId.ToString()) ;
            ChangePostValue( "ZT_"+"Z525CTALabel_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z526CTAType_"+sGXsfl_53_idx, Z526CTAType) ;
            ChangePostValue( "ZT_"+"Z527CTAAction_"+sGXsfl_53_idx, Z527CTAAction) ;
            ChangePostValue( "nRcdDeleted_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_102 != 0 )
            {
               ChangePostValue( "CTAID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTALABEL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTALabel_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCTAType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTAACTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAAction_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1M0( )
      {
      }

      protected void ZM1M101( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z522PageName = T001M5_A522PageName[0];
            }
            else
            {
               Z522PageName = A522PageName;
            }
         }
         if ( GX_JID == -6 )
         {
            Z521PageId = A521PageId;
            Z522PageName = A522PageName;
            Z523PageStructure = A523PageStructure;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A521PageId) && ( Gx_BScreen == 0 ) )
         {
            A521PageId = Guid.NewGuid( );
            AssignAttri("", false, "A521PageId", A521PageId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1M101( )
      {
         /* Using cursor T001M6 */
         pr_default.execute(4, new Object[] {A521PageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound101 = 1;
            A522PageName = T001M6_A522PageName[0];
            AssignAttri("", false, "A522PageName", A522PageName);
            A523PageStructure = T001M6_A523PageStructure[0];
            AssignAttri("", false, "A523PageStructure", A523PageStructure);
            ZM1M101( -6) ;
         }
         pr_default.close(4);
         OnLoadActions1M101( ) ;
      }

      protected void OnLoadActions1M101( )
      {
      }

      protected void CheckExtendedTable1M101( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1M101( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1M101( )
      {
         /* Using cursor T001M7 */
         pr_default.execute(5, new Object[] {A521PageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001M5 */
         pr_default.execute(3, new Object[] {A521PageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1M101( 6) ;
            RcdFound101 = 1;
            A521PageId = T001M5_A521PageId[0];
            AssignAttri("", false, "A521PageId", A521PageId.ToString());
            A522PageName = T001M5_A522PageName[0];
            AssignAttri("", false, "A522PageName", A522PageName);
            A523PageStructure = T001M5_A523PageStructure[0];
            AssignAttri("", false, "A523PageStructure", A523PageStructure);
            Z521PageId = A521PageId;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1M101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey1M101( ) ;
            }
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey1M101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M101( ) ;
         if ( RcdFound101 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound101 = 0;
         /* Using cursor T001M8 */
         pr_default.execute(6, new Object[] {A521PageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001M8_A521PageId[0], A521PageId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001M8_A521PageId[0], A521PageId, 0) > 0 ) ) )
            {
               A521PageId = T001M8_A521PageId[0];
               AssignAttri("", false, "A521PageId", A521PageId.ToString());
               RcdFound101 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound101 = 0;
         /* Using cursor T001M9 */
         pr_default.execute(7, new Object[] {A521PageId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001M9_A521PageId[0], A521PageId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001M9_A521PageId[0], A521PageId, 0) < 0 ) ) )
            {
               A521PageId = T001M9_A521PageId[0];
               AssignAttri("", false, "A521PageId", A521PageId.ToString());
               RcdFound101 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1M101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1M101( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( A521PageId != Z521PageId )
               {
                  A521PageId = Z521PageId;
                  AssignAttri("", false, "A521PageId", A521PageId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1M101( ) ;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A521PageId != Z521PageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1M101( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1M101( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A521PageId != Z521PageId )
         {
            A521PageId = Z521PageId;
            AssignAttri("", false, "A521PageId", A521PageId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGEID");
            AnyError = 1;
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAGEID");
            AnyError = 1;
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1M101( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M101( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1M101( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound101 != 0 )
            {
               ScanNext1M101( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M101( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1M101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M4 */
            pr_default.execute(2, new Object[] {A521PageId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ContentPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z522PageName, T001M4_A522PageName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z522PageName, T001M4_A522PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_contentpage:[seudo value changed for attri]"+"PageName");
                  GXUtil.WriteLogRaw("Old: ",Z522PageName);
                  GXUtil.WriteLogRaw("Current: ",T001M4_A522PageName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ContentPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M101( )
      {
         if ( ! IsAuthorized("trn_contentpage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M101( 0) ;
            CheckOptimisticConcurrency1M101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M10 */
                     pr_default.execute(8, new Object[] {A521PageId, A522PageName, A523PageStructure});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPage");
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
                           ProcessLevel1M101( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1M0( ) ;
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
               Load1M101( ) ;
            }
            EndLevel1M101( ) ;
         }
         CloseExtendedTableCursors1M101( ) ;
      }

      protected void Update1M101( )
      {
         if ( ! IsAuthorized("trn_contentpage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M11 */
                     pr_default.execute(9, new Object[] {A522PageName, A523PageStructure, A521PageId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPage");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ContentPage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M101( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1M101( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1M0( ) ;
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
            EndLevel1M101( ) ;
         }
         CloseExtendedTableCursors1M101( ) ;
      }

      protected void DeferredUpdate1M101( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_contentpage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1M101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M101( ) ;
            AfterConfirm1M101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M101( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1M102( ) ;
                  while ( RcdFound102 != 0 )
                  {
                     getByPrimaryKey1M102( ) ;
                     Delete1M102( ) ;
                     ScanNext1M102( ) ;
                  }
                  ScanEnd1M102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M12 */
                     pr_default.execute(10, new Object[] {A521PageId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPage");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound101 == 0 )
                           {
                              InitAll1M101( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption1M0( ) ;
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
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M101( ) ;
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M101( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel1M102( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow1M102( ) ;
            if ( ( nRcdExists_102 != 0 ) || ( nIsMod_102 != 0 ) )
            {
               standaloneNotModal1M102( ) ;
               GetKey1M102( ) ;
               if ( ( nRcdExists_102 == 0 ) && ( nRcdDeleted_102 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1M102( ) ;
               }
               else
               {
                  if ( RcdFound102 != 0 )
                  {
                     if ( ( nRcdDeleted_102 != 0 ) && ( nRcdExists_102 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1M102( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_102 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1M102( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_102 == 0 )
                     {
                        GXCCtl = "CTAID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCTAId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCTAId_Internalname, A524CTAId.ToString()) ;
            ChangePostValue( edtCTALabel_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbCTAType_Internalname, A526CTAType) ;
            ChangePostValue( edtCTAAction_Internalname, A527CTAAction) ;
            ChangePostValue( "ZT_"+"Z524CTAId_"+sGXsfl_53_idx, Z524CTAId.ToString()) ;
            ChangePostValue( "ZT_"+"Z525CTALabel_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z526CTAType_"+sGXsfl_53_idx, Z526CTAType) ;
            ChangePostValue( "ZT_"+"Z527CTAAction_"+sGXsfl_53_idx, Z527CTAAction) ;
            ChangePostValue( "nRcdDeleted_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_102_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_102 != 0 )
            {
               ChangePostValue( "CTAID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTALABEL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTALabel_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCTAType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTAACTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAAction_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1M102( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_102 = 0;
         nIsMod_102 = 0;
         nRcdDeleted_102 = 0;
      }

      protected void ProcessLevel1M101( )
      {
         /* Save parent mode. */
         sMode101 = Gx_mode;
         ProcessNestedLevel1M102( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1M101( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M101( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_contentpage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_contentpage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1M101( )
      {
         /* Using cursor T001M13 */
         pr_default.execute(11);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound101 = 1;
            A521PageId = T001M13_A521PageId[0];
            AssignAttri("", false, "A521PageId", A521PageId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M101( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound101 = 1;
            A521PageId = T001M13_A521PageId[0];
            AssignAttri("", false, "A521PageId", A521PageId.ToString());
         }
      }

      protected void ScanEnd1M101( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1M101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M101( )
      {
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), true);
         edtPageName_Enabled = 0;
         AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), true);
         edtPageStructure_Enabled = 0;
         AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), true);
      }

      protected void ZM1M102( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z525CTALabel = T001M3_A525CTALabel[0];
               Z526CTAType = T001M3_A526CTAType[0];
               Z527CTAAction = T001M3_A527CTAAction[0];
            }
            else
            {
               Z525CTALabel = A525CTALabel;
               Z526CTAType = A526CTAType;
               Z527CTAAction = A527CTAAction;
            }
         }
         if ( GX_JID == -7 )
         {
            Z521PageId = A521PageId;
            Z524CTAId = A524CTAId;
            Z525CTALabel = A525CTALabel;
            Z526CTAType = A526CTAType;
            Z527CTAAction = A527CTAAction;
         }
      }

      protected void standaloneNotModal1M102( )
      {
      }

      protected void standaloneModal1M102( )
      {
         if ( IsIns( )  && (Guid.Empty==A524CTAId) && ( Gx_BScreen == 0 ) )
         {
            A524CTAId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCTAId_Enabled = 0;
            AssignProp("", false, edtCTAId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtCTAId_Enabled = 1;
            AssignProp("", false, edtCTAId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1M102( )
      {
         /* Using cursor T001M14 */
         pr_default.execute(12, new Object[] {A521PageId, A524CTAId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound102 = 1;
            A525CTALabel = T001M14_A525CTALabel[0];
            A526CTAType = T001M14_A526CTAType[0];
            A527CTAAction = T001M14_A527CTAAction[0];
            ZM1M102( -7) ;
         }
         pr_default.close(12);
         OnLoadActions1M102( ) ;
      }

      protected void OnLoadActions1M102( )
      {
      }

      protected void CheckExtendedTable1M102( )
      {
         nIsDirty_102 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1M102( ) ;
         if ( ! ( ( StringUtil.StrCmp(A526CTAType, "Phone") == 0 ) || ( StringUtil.StrCmp(A526CTAType, "Email") == 0 ) || ( StringUtil.StrCmp(A526CTAType, "Form") == 0 ) || ( StringUtil.StrCmp(A526CTAType, "SiteUrl") == 0 ) ) )
         {
            GXCCtl = "CTATYPE_" + sGXsfl_53_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "CTAType", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbCTAType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1M102( )
      {
      }

      protected void enableDisable1M102( )
      {
      }

      protected void GetKey1M102( )
      {
         /* Using cursor T001M15 */
         pr_default.execute(13, new Object[] {A521PageId, A524CTAId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey1M102( )
      {
         /* Using cursor T001M3 */
         pr_default.execute(1, new Object[] {A521PageId, A524CTAId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M102( 7) ;
            RcdFound102 = 1;
            InitializeNonKey1M102( ) ;
            A524CTAId = T001M3_A524CTAId[0];
            A525CTALabel = T001M3_A525CTALabel[0];
            A526CTAType = T001M3_A526CTAType[0];
            A527CTAAction = T001M3_A527CTAAction[0];
            Z521PageId = A521PageId;
            Z524CTAId = A524CTAId;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1M102( ) ;
            Load1M102( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey1M102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1M102( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1M102( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1M102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M2 */
            pr_default.execute(0, new Object[] {A521PageId, A524CTAId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ContentPageCTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z525CTALabel != T001M2_A525CTALabel[0] ) || ( StringUtil.StrCmp(Z526CTAType, T001M2_A526CTAType[0]) != 0 ) || ( StringUtil.StrCmp(Z527CTAAction, T001M2_A527CTAAction[0]) != 0 ) )
            {
               if ( Z525CTALabel != T001M2_A525CTALabel[0] )
               {
                  GXUtil.WriteLog("trn_contentpage:[seudo value changed for attri]"+"CTALabel");
                  GXUtil.WriteLogRaw("Old: ",Z525CTALabel);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A525CTALabel[0]);
               }
               if ( StringUtil.StrCmp(Z526CTAType, T001M2_A526CTAType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_contentpage:[seudo value changed for attri]"+"CTAType");
                  GXUtil.WriteLogRaw("Old: ",Z526CTAType);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A526CTAType[0]);
               }
               if ( StringUtil.StrCmp(Z527CTAAction, T001M2_A527CTAAction[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_contentpage:[seudo value changed for attri]"+"CTAAction");
                  GXUtil.WriteLogRaw("Old: ",Z527CTAAction);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A527CTAAction[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ContentPageCTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M102( )
      {
         if ( ! IsAuthorized("trn_contentpage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M102( 0) ;
            CheckOptimisticConcurrency1M102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M16 */
                     pr_default.execute(14, new Object[] {A521PageId, A524CTAId, A525CTALabel, A526CTAType, A527CTAAction});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPageCTA");
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
               Load1M102( ) ;
            }
            EndLevel1M102( ) ;
         }
         CloseExtendedTableCursors1M102( ) ;
      }

      protected void Update1M102( )
      {
         if ( ! IsAuthorized("trn_contentpage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1M102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M102( ) ;
         }
         if ( ( nIsMod_102 != 0 ) || ( nIsDirty_102 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1M102( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1M102( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1M102( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001M17 */
                        pr_default.execute(15, new Object[] {A525CTALabel, A526CTAType, A527CTAAction, A521PageId, A524CTAId});
                        pr_default.close(15);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPageCTA");
                        if ( (pr_default.getStatus(15) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ContentPageCTA"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1M102( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1M102( ) ;
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
               EndLevel1M102( ) ;
            }
         }
         CloseExtendedTableCursors1M102( ) ;
      }

      protected void DeferredUpdate1M102( )
      {
      }

      protected void Delete1M102( )
      {
         if ( ! IsAuthorized("trn_contentpage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1M102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M102( ) ;
            AfterConfirm1M102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001M18 */
                  pr_default.execute(16, new Object[] {A521PageId, A524CTAId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ContentPageCTA");
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
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M102( ) ;
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M102( )
      {
         standaloneModal1M102( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1M102( )
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

      public void ScanStart1M102( )
      {
         /* Scan By routine */
         /* Using cursor T001M19 */
         pr_default.execute(17, new Object[] {A521PageId});
         RcdFound102 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound102 = 1;
            A524CTAId = T001M19_A524CTAId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M102( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound102 = 1;
            A524CTAId = T001M19_A524CTAId[0];
         }
      }

      protected void ScanEnd1M102( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1M102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M102( )
      {
         edtCTAId_Enabled = 0;
         AssignProp("", false, edtCTAId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtCTALabel_Enabled = 0;
         AssignProp("", false, edtCTALabel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTALabel_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbCTAType.Enabled = 0;
         AssignProp("", false, cmbCTAType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCTAType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtCTAAction_Enabled = 0;
         AssignProp("", false, edtCTAAction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAAction_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes1M102( )
      {
      }

      protected void send_integrity_lvl_hashes1M101( )
      {
      }

      protected void SubsflControlProps_53102( )
      {
         edtCTAId_Internalname = "CTAID_"+sGXsfl_53_idx;
         edtCTALabel_Internalname = "CTALABEL_"+sGXsfl_53_idx;
         cmbCTAType_Internalname = "CTATYPE_"+sGXsfl_53_idx;
         edtCTAAction_Internalname = "CTAACTION_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_53102( )
      {
         edtCTAId_Internalname = "CTAID_"+sGXsfl_53_fel_idx;
         edtCTALabel_Internalname = "CTALABEL_"+sGXsfl_53_fel_idx;
         cmbCTAType_Internalname = "CTATYPE_"+sGXsfl_53_fel_idx;
         edtCTAAction_Internalname = "CTAACTION_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow1M102( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53102( ) ;
         SendRow1M102( ) ;
      }

      protected void SendRow1M102( )
      {
         Gridtrn_contentpage_ctaRow = GXWebRow.GetNew(context);
         if ( subGridtrn_contentpage_cta_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtrn_contentpage_cta_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtrn_contentpage_cta_Class, "") != 0 )
            {
               subGridtrn_contentpage_cta_Linesclass = subGridtrn_contentpage_cta_Class+"Odd";
            }
         }
         else if ( subGridtrn_contentpage_cta_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtrn_contentpage_cta_Backstyle = 0;
            subGridtrn_contentpage_cta_Backcolor = subGridtrn_contentpage_cta_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtrn_contentpage_cta_Class, "") != 0 )
            {
               subGridtrn_contentpage_cta_Linesclass = subGridtrn_contentpage_cta_Class+"Uniform";
            }
         }
         else if ( subGridtrn_contentpage_cta_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtrn_contentpage_cta_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtrn_contentpage_cta_Class, "") != 0 )
            {
               subGridtrn_contentpage_cta_Linesclass = subGridtrn_contentpage_cta_Class+"Odd";
            }
            subGridtrn_contentpage_cta_Backcolor = (int)(0x0);
         }
         else if ( subGridtrn_contentpage_cta_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtrn_contentpage_cta_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridtrn_contentpage_cta_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_contentpage_cta_Class, "") != 0 )
               {
                  subGridtrn_contentpage_cta_Linesclass = subGridtrn_contentpage_cta_Class+"Even";
               }
            }
            else
            {
               subGridtrn_contentpage_cta_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_contentpage_cta_Class, "") != 0 )
               {
                  subGridtrn_contentpage_cta_Linesclass = subGridtrn_contentpage_cta_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_102_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_contentpage_ctaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCTAId_Internalname,A524CTAId.ToString(),A524CTAId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCTAId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCTAId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)53,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_102_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_contentpage_ctaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCTALabel_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtCTALabel_Enabled!=0) ? context.localUtil.Format( (decimal)(A525CTALabel), "ZZZ9") : context.localUtil.Format( (decimal)(A525CTALabel), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCTALabel_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCTALabel_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_102_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_53_idx + "',53)\"";
         if ( ( cmbCTAType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "CTATYPE_" + sGXsfl_53_idx;
            cmbCTAType.Name = GXCCtl;
            cmbCTAType.WebTags = "";
            cmbCTAType.addItem("Phone", context.GetMessage( "Phone", ""), 0);
            cmbCTAType.addItem("Email", context.GetMessage( "Email", ""), 0);
            cmbCTAType.addItem("Form", context.GetMessage( "Form", ""), 0);
            cmbCTAType.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
            if ( cmbCTAType.ItemCount > 0 )
            {
               A526CTAType = cmbCTAType.getValidValue(A526CTAType);
            }
         }
         /* ComboBox */
         Gridtrn_contentpage_ctaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCTAType,(string)cmbCTAType_Internalname,StringUtil.RTrim( A526CTAType),(short)1,(string)cmbCTAType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbCTAType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(bool)true,(short)0});
         cmbCTAType.CurrentValue = StringUtil.RTrim( A526CTAType);
         AssignProp("", false, cmbCTAType_Internalname, "Values", (string)(cmbCTAType.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_102_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_contentpage_ctaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCTAAction_Internalname,(string)A527CTAAction,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCTAAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCTAAction_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridtrn_contentpage_ctaRow);
         send_integrity_lvl_hashes1M102( ) ;
         GXCCtl = "Z524CTAId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z524CTAId.ToString());
         GXCCtl = "Z525CTALabel_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z525CTALabel), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z526CTAType_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z526CTAType);
         GXCCtl = "Z527CTAAction_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z527CTAAction);
         GXCCtl = "nRcdDeleted_102_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_102_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_102_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CTAID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTALABEL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTALabel_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCTAType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTAACTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAAction_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridtrn_contentpage_ctaContainer.AddRow(Gridtrn_contentpage_ctaRow);
      }

      protected void ReadRow1M102( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53102( ) ;
         edtCTAId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTAID_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCTALabel_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTALABEL_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbCTAType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTATYPE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCTAAction_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTAACTION_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtCTAId_Internalname), "") == 0 )
         {
            A524CTAId = Guid.Empty;
         }
         else
         {
            try
            {
               A524CTAId = StringUtil.StrToGuid( cgiGet( edtCTAId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "CTAID_" + sGXsfl_53_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCTAId_Internalname;
               wbErr = true;
            }
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCTALabel_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCTALabel_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CTALABEL_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCTALabel_Internalname;
            wbErr = true;
            A525CTALabel = 0;
         }
         else
         {
            A525CTALabel = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCTALabel_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         cmbCTAType.Name = cmbCTAType_Internalname;
         cmbCTAType.CurrentValue = cgiGet( cmbCTAType_Internalname);
         A526CTAType = cgiGet( cmbCTAType_Internalname);
         A527CTAAction = cgiGet( edtCTAAction_Internalname);
         GXCCtl = "Z524CTAId_" + sGXsfl_53_idx;
         Z524CTAId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z525CTALabel_" + sGXsfl_53_idx;
         Z525CTALabel = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z526CTAType_" + sGXsfl_53_idx;
         Z526CTAType = cgiGet( GXCCtl);
         GXCCtl = "Z527CTAAction_" + sGXsfl_53_idx;
         Z527CTAAction = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_102_" + sGXsfl_53_idx;
         nRcdDeleted_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_102_" + sGXsfl_53_idx;
         nRcdExists_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_102_" + sGXsfl_53_idx;
         nIsMod_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCTAId_Enabled = edtCTAId_Enabled;
      }

      protected void ConfirmValues1M0( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53102( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_53102( ) ;
            ChangePostValue( "Z524CTAId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z524CTAId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z524CTAId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z525CTALabel_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z525CTALabel_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z525CTALabel_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z526CTAType_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z526CTAType_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z526CTAType_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z527CTAAction_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z527CTAAction_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z527CTAAction_"+sGXsfl_53_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_contentpage.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z521PageId", Z521PageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z522PageName", Z522PageName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("trn_contentpage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ContentPage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Content Page", "") ;
      }

      protected void InitializeNonKey1M101( )
      {
         A522PageName = "";
         AssignAttri("", false, "A522PageName", A522PageName);
         A523PageStructure = "";
         AssignAttri("", false, "A523PageStructure", A523PageStructure);
         Z522PageName = "";
      }

      protected void InitAll1M101( )
      {
         A521PageId = Guid.NewGuid( );
         AssignAttri("", false, "A521PageId", A521PageId.ToString());
         InitializeNonKey1M101( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1M102( )
      {
         A525CTALabel = 0;
         A526CTAType = "";
         A527CTAAction = "";
         Z525CTALabel = 0;
         Z526CTAType = "";
         Z527CTAAction = "";
      }

      protected void InitAll1M102( )
      {
         A524CTAId = Guid.NewGuid( );
         InitializeNonKey1M102( ) ;
      }

      protected void StandaloneModalInsert1M102( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025347313858", true, true);
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
         context.AddJavascriptSource("trn_contentpage.js", "?2025347313859", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties102( )
      {
         edtCTAId_Enabled = defedtCTAId_Enabled;
         AssignProp("", false, edtCTAId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCTAId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("GridName", "Gridtrn_contentpage_cta");
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Header", subGridtrn_contentpage_cta_Header);
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Class", "Grid");
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Backcolorstyle), 1, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("CmpContext", "");
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("InMasterPage", "false");
         Gridtrn_contentpage_ctaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A524CTAId.ToString()));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAId_Enabled), 5, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddColumnProperties(Gridtrn_contentpage_ctaColumn);
         Gridtrn_contentpage_ctaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A525CTALabel), 4, 0, ".", ""))));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTALabel_Enabled), 5, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddColumnProperties(Gridtrn_contentpage_ctaColumn);
         Gridtrn_contentpage_ctaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A526CTAType));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCTAType.Enabled), 5, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddColumnProperties(Gridtrn_contentpage_ctaColumn);
         Gridtrn_contentpage_ctaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A527CTAAction));
         Gridtrn_contentpage_ctaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCTAAction_Enabled), 5, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddColumnProperties(Gridtrn_contentpage_ctaColumn);
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Selectedindex), 4, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Allowselection), 1, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Selectioncolor), 9, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Allowhovering), 1, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Hoveringcolor), 9, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Allowcollapsing), 1, 0, ".", "")));
         Gridtrn_contentpage_ctaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_contentpage_cta_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtPageId_Internalname = "PAGEID";
         edtPageName_Internalname = "PAGENAME";
         edtPageStructure_Internalname = "PAGESTRUCTURE";
         lblTitlecta_Internalname = "TITLECTA";
         edtCTAId_Internalname = "CTAID";
         edtCTALabel_Internalname = "CTALABEL";
         cmbCTAType_Internalname = "CTATYPE";
         edtCTAAction_Internalname = "CTAACTION";
         divCtatable_Internalname = "CTATABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridtrn_contentpage_cta_Internalname = "GRIDTRN_CONTENTPAGE_CTA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridtrn_contentpage_cta_Allowcollapsing = 0;
         subGridtrn_contentpage_cta_Allowselection = 0;
         subGridtrn_contentpage_cta_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Content Page", "");
         edtCTAAction_Jsonclick = "";
         cmbCTAType_Jsonclick = "";
         edtCTALabel_Jsonclick = "";
         edtCTAId_Jsonclick = "";
         subGridtrn_contentpage_cta_Class = "Grid";
         subGridtrn_contentpage_cta_Backcolorstyle = 0;
         edtCTAAction_Enabled = 1;
         cmbCTAType.Enabled = 1;
         edtCTALabel_Enabled = 1;
         edtCTAId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPageStructure_Enabled = 1;
         edtPageName_Jsonclick = "";
         edtPageName_Enabled = 1;
         edtPageId_Jsonclick = "";
         edtPageId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void gxnrGridtrn_contentpage_cta_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_53102( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1M102( ) ;
            standaloneModal1M102( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1M102( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_53102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtrn_contentpage_ctaContainer)) ;
         /* End function gxnrGridtrn_contentpage_cta_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CTATYPE_" + sGXsfl_53_idx;
         cmbCTAType.Name = GXCCtl;
         cmbCTAType.WebTags = "";
         cmbCTAType.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbCTAType.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbCTAType.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbCTAType.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbCTAType.ItemCount > 0 )
         {
            A526CTAType = cmbCTAType.getValidValue(A526CTAType);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Pageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A522PageName", A522PageName);
         AssignAttri("", false, "A523PageStructure", A523PageStructure);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z521PageId", Z521PageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z522PageName", Z522PageName);
         GxWebStd.gx_hidden_field( context, "Z523PageStructure", Z523PageStructure);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_PAGEID","""{"handler":"Valid_Pageid","iparms":[{"av":"A521PageId","fld":"PAGEID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_PAGEID",""","oparms":[{"av":"A522PageName","fld":"PAGENAME"},{"av":"A523PageStructure","fld":"PAGESTRUCTURE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z521PageId"},{"av":"Z522PageName"},{"av":"Z523PageStructure"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CTAID","""{"handler":"Valid_Ctaid","iparms":[]}""");
         setEventMetadata("VALID_CTATYPE","""{"handler":"Valid_Ctatype","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Ctaaction","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z521PageId = Guid.Empty;
         Z522PageName = "";
         Z524CTAId = Guid.Empty;
         Z526CTAType = "";
         Z527CTAAction = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A521PageId = Guid.Empty;
         A522PageName = "";
         A523PageStructure = "";
         lblTitlecta_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtrn_contentpage_ctaContainer = new GXWebGrid( context);
         sMode102 = "";
         A524CTAId = Guid.Empty;
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A526CTAType = "";
         A527CTAAction = "";
         Z523PageStructure = "";
         T001M6_A521PageId = new Guid[] {Guid.Empty} ;
         T001M6_A522PageName = new string[] {""} ;
         T001M6_A523PageStructure = new string[] {""} ;
         T001M7_A521PageId = new Guid[] {Guid.Empty} ;
         T001M5_A521PageId = new Guid[] {Guid.Empty} ;
         T001M5_A522PageName = new string[] {""} ;
         T001M5_A523PageStructure = new string[] {""} ;
         sMode101 = "";
         T001M8_A521PageId = new Guid[] {Guid.Empty} ;
         T001M9_A521PageId = new Guid[] {Guid.Empty} ;
         T001M4_A521PageId = new Guid[] {Guid.Empty} ;
         T001M4_A522PageName = new string[] {""} ;
         T001M4_A523PageStructure = new string[] {""} ;
         T001M13_A521PageId = new Guid[] {Guid.Empty} ;
         T001M14_A521PageId = new Guid[] {Guid.Empty} ;
         T001M14_A524CTAId = new Guid[] {Guid.Empty} ;
         T001M14_A525CTALabel = new short[1] ;
         T001M14_A526CTAType = new string[] {""} ;
         T001M14_A527CTAAction = new string[] {""} ;
         T001M15_A521PageId = new Guid[] {Guid.Empty} ;
         T001M15_A524CTAId = new Guid[] {Guid.Empty} ;
         T001M3_A521PageId = new Guid[] {Guid.Empty} ;
         T001M3_A524CTAId = new Guid[] {Guid.Empty} ;
         T001M3_A525CTALabel = new short[1] ;
         T001M3_A526CTAType = new string[] {""} ;
         T001M3_A527CTAAction = new string[] {""} ;
         T001M2_A521PageId = new Guid[] {Guid.Empty} ;
         T001M2_A524CTAId = new Guid[] {Guid.Empty} ;
         T001M2_A525CTALabel = new short[1] ;
         T001M2_A526CTAType = new string[] {""} ;
         T001M2_A527CTAAction = new string[] {""} ;
         T001M19_A521PageId = new Guid[] {Guid.Empty} ;
         T001M19_A524CTAId = new Guid[] {Guid.Empty} ;
         Gridtrn_contentpage_ctaRow = new GXWebRow();
         subGridtrn_contentpage_cta_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridtrn_contentpage_ctaColumn = new GXWebColumn();
         ZZ521PageId = Guid.Empty;
         ZZ522PageName = "";
         ZZ523PageStructure = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_contentpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_contentpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_contentpage__default(),
            new Object[][] {
                new Object[] {
               T001M2_A521PageId, T001M2_A524CTAId, T001M2_A525CTALabel, T001M2_A526CTAType, T001M2_A527CTAAction
               }
               , new Object[] {
               T001M3_A521PageId, T001M3_A524CTAId, T001M3_A525CTALabel, T001M3_A526CTAType, T001M3_A527CTAAction
               }
               , new Object[] {
               T001M4_A521PageId, T001M4_A522PageName, T001M4_A523PageStructure
               }
               , new Object[] {
               T001M5_A521PageId, T001M5_A522PageName, T001M5_A523PageStructure
               }
               , new Object[] {
               T001M6_A521PageId, T001M6_A522PageName, T001M6_A523PageStructure
               }
               , new Object[] {
               T001M7_A521PageId
               }
               , new Object[] {
               T001M8_A521PageId
               }
               , new Object[] {
               T001M9_A521PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M13_A521PageId
               }
               , new Object[] {
               T001M14_A521PageId, T001M14_A524CTAId, T001M14_A525CTALabel, T001M14_A526CTAType, T001M14_A527CTAAction
               }
               , new Object[] {
               T001M15_A521PageId, T001M15_A524CTAId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M19_A521PageId, T001M19_A524CTAId
               }
            }
         );
         Z524CTAId = Guid.NewGuid( );
         A524CTAId = Guid.NewGuid( );
         Z521PageId = Guid.NewGuid( );
         A521PageId = Guid.NewGuid( );
      }

      private short Z525CTALabel ;
      private short nRcdDeleted_102 ;
      private short nRcdExists_102 ;
      private short nIsMod_102 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount102 ;
      private short RcdFound102 ;
      private short nBlankRcdUsr102 ;
      private short A525CTALabel ;
      private short RcdFound101 ;
      private short nIsDirty_102 ;
      private short subGridtrn_contentpage_cta_Backcolorstyle ;
      private short subGridtrn_contentpage_cta_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridtrn_contentpage_cta_Allowselection ;
      private short subGridtrn_contentpage_cta_Allowhovering ;
      private short subGridtrn_contentpage_cta_Allowcollapsing ;
      private short subGridtrn_contentpage_cta_Collapsed ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPageId_Enabled ;
      private int edtPageName_Enabled ;
      private int edtPageStructure_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtCTAId_Enabled ;
      private int edtCTALabel_Enabled ;
      private int edtCTAAction_Enabled ;
      private int fRowAdded ;
      private int subGridtrn_contentpage_cta_Backcolor ;
      private int subGridtrn_contentpage_cta_Allbackcolor ;
      private int defedtCTAId_Enabled ;
      private int idxLst ;
      private int subGridtrn_contentpage_cta_Selectedindex ;
      private int subGridtrn_contentpage_cta_Selectioncolor ;
      private int subGridtrn_contentpage_cta_Hoveringcolor ;
      private long GRIDTRN_CONTENTPAGE_CTA_nFirstRecordOnPage ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPageId_Internalname ;
      private string sGXsfl_53_idx="0001" ;
      private string Gx_mode ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtPageId_Jsonclick ;
      private string edtPageName_Internalname ;
      private string edtPageName_Jsonclick ;
      private string edtPageStructure_Internalname ;
      private string divCtatable_Internalname ;
      private string lblTitlecta_Internalname ;
      private string lblTitlecta_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode102 ;
      private string edtCTAId_Internalname ;
      private string edtCTALabel_Internalname ;
      private string cmbCTAType_Internalname ;
      private string edtCTAAction_Internalname ;
      private string sStyleString ;
      private string subGridtrn_contentpage_cta_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode101 ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridtrn_contentpage_cta_Class ;
      private string subGridtrn_contentpage_cta_Linesclass ;
      private string ROClassString ;
      private string edtCTAId_Jsonclick ;
      private string edtCTALabel_Jsonclick ;
      private string cmbCTAType_Jsonclick ;
      private string edtCTAAction_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridtrn_contentpage_cta_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private string A523PageStructure ;
      private string Z523PageStructure ;
      private string ZZ523PageStructure ;
      private string Z522PageName ;
      private string Z526CTAType ;
      private string Z527CTAAction ;
      private string A522PageName ;
      private string A526CTAType ;
      private string A527CTAAction ;
      private string ZZ522PageName ;
      private Guid Z521PageId ;
      private Guid Z524CTAId ;
      private Guid A521PageId ;
      private Guid A524CTAId ;
      private Guid ZZ521PageId ;
      private GXWebGrid Gridtrn_contentpage_ctaContainer ;
      private GXWebRow Gridtrn_contentpage_ctaRow ;
      private GXWebColumn Gridtrn_contentpage_ctaColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCTAType ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001M6_A521PageId ;
      private string[] T001M6_A522PageName ;
      private string[] T001M6_A523PageStructure ;
      private Guid[] T001M7_A521PageId ;
      private Guid[] T001M5_A521PageId ;
      private string[] T001M5_A522PageName ;
      private string[] T001M5_A523PageStructure ;
      private Guid[] T001M8_A521PageId ;
      private Guid[] T001M9_A521PageId ;
      private Guid[] T001M4_A521PageId ;
      private string[] T001M4_A522PageName ;
      private string[] T001M4_A523PageStructure ;
      private Guid[] T001M13_A521PageId ;
      private Guid[] T001M14_A521PageId ;
      private Guid[] T001M14_A524CTAId ;
      private short[] T001M14_A525CTALabel ;
      private string[] T001M14_A526CTAType ;
      private string[] T001M14_A527CTAAction ;
      private Guid[] T001M15_A521PageId ;
      private Guid[] T001M15_A524CTAId ;
      private Guid[] T001M3_A521PageId ;
      private Guid[] T001M3_A524CTAId ;
      private short[] T001M3_A525CTALabel ;
      private string[] T001M3_A526CTAType ;
      private string[] T001M3_A527CTAAction ;
      private Guid[] T001M2_A521PageId ;
      private Guid[] T001M2_A524CTAId ;
      private short[] T001M2_A525CTALabel ;
      private string[] T001M2_A526CTAType ;
      private string[] T001M2_A527CTAAction ;
      private Guid[] T001M19_A521PageId ;
      private Guid[] T001M19_A524CTAId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_contentpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_contentpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_contentpage__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new ForEachCursor(def[17])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001M2;
       prmT001M2 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M3;
       prmT001M3 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M4;
       prmT001M4 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M5;
       prmT001M5 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M6;
       prmT001M6 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M7;
       prmT001M7 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M8;
       prmT001M8 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M9;
       prmT001M9 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M10;
       prmT001M10 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT001M11;
       prmT001M11 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M12;
       prmT001M12 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M13;
       prmT001M13 = new Object[] {
       };
       Object[] prmT001M14;
       prmT001M14 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M15;
       prmT001M15 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M16;
       prmT001M16 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTALabel",GXType.Int16,4,0) ,
       new ParDef("CTAType",GXType.VarChar,100,0) ,
       new ParDef("CTAAction",GXType.VarChar,200,0)
       };
       Object[] prmT001M17;
       prmT001M17 = new Object[] {
       new ParDef("CTALabel",GXType.Int16,4,0) ,
       new ParDef("CTAType",GXType.VarChar,100,0) ,
       new ParDef("CTAAction",GXType.VarChar,200,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M18;
       prmT001M18 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CTAId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001M19;
       prmT001M19 = new Object[] {
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001M2", "SELECT PageId, CTAId, CTALabel, CTAType, CTAAction FROM Trn_ContentPageCTA WHERE PageId = :PageId AND CTAId = :CTAId  FOR UPDATE OF Trn_ContentPageCTA NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001M2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M3", "SELECT PageId, CTAId, CTALabel, CTAType, CTAAction FROM Trn_ContentPageCTA WHERE PageId = :PageId AND CTAId = :CTAId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M4", "SELECT PageId, PageName, PageStructure FROM Trn_ContentPage WHERE PageId = :PageId  FOR UPDATE OF Trn_ContentPage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001M4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M5", "SELECT PageId, PageName, PageStructure FROM Trn_ContentPage WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M6", "SELECT TM1.PageId, TM1.PageName, TM1.PageStructure FROM Trn_ContentPage TM1 WHERE TM1.PageId = :PageId ORDER BY TM1.PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M7", "SELECT PageId FROM Trn_ContentPage WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M8", "SELECT PageId FROM Trn_ContentPage WHERE ( PageId > :PageId) ORDER BY PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001M9", "SELECT PageId FROM Trn_ContentPage WHERE ( PageId < :PageId) ORDER BY PageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001M10", "SAVEPOINT gxupdate;INSERT INTO Trn_ContentPage(PageId, PageName, PageStructure) VALUES(:PageId, :PageName, :PageStructure);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001M10)
          ,new CursorDef("T001M11", "SAVEPOINT gxupdate;UPDATE Trn_ContentPage SET PageName=:PageName, PageStructure=:PageStructure  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M11)
          ,new CursorDef("T001M12", "SAVEPOINT gxupdate;DELETE FROM Trn_ContentPage  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M12)
          ,new CursorDef("T001M13", "SELECT PageId FROM Trn_ContentPage ORDER BY PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M13,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M14", "SELECT PageId, CTAId, CTALabel, CTAType, CTAAction FROM Trn_ContentPageCTA WHERE PageId = :PageId and CTAId = :CTAId ORDER BY PageId, CTAId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M14,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M15", "SELECT PageId, CTAId FROM Trn_ContentPageCTA WHERE PageId = :PageId AND CTAId = :CTAId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001M16", "SAVEPOINT gxupdate;INSERT INTO Trn_ContentPageCTA(PageId, CTAId, CTALabel, CTAType, CTAAction) VALUES(:PageId, :CTAId, :CTALabel, :CTAType, :CTAAction);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001M16)
          ,new CursorDef("T001M17", "SAVEPOINT gxupdate;UPDATE Trn_ContentPageCTA SET CTALabel=:CTALabel, CTAType=:CTAType, CTAAction=:CTAAction  WHERE PageId = :PageId AND CTAId = :CTAId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M17)
          ,new CursorDef("T001M18", "SAVEPOINT gxupdate;DELETE FROM Trn_ContentPageCTA  WHERE PageId = :PageId AND CTAId = :CTAId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M18)
          ,new CursorDef("T001M19", "SELECT PageId, CTAId FROM Trn_ContentPageCTA WHERE PageId = :PageId ORDER BY PageId, CTAId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M19,11, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
