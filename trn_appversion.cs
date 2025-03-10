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
   public class trn_appversion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtrn_appversion_page") == 0 )
         {
            gxnrGridtrn_appversion_page_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_App Version", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridtrn_appversion_page_newrow_invoke( )
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
         gxnrGridtrn_appversion_page_newrow( ) ;
         /* End function gxnrGridtrn_appversion_page_newrow_invoke */
      }

      public trn_appversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversion( IGxContext context )
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
         cmbPageType = new GXCombobox();
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
            return "trn_appversion_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_App Version", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AppVersion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AppVersion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionId_Internalname, context.GetMessage( "Version Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionId_Internalname, A543AppVersionId.ToString(), A543AppVersionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionName_Internalname, context.GetMessage( "Version Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionName_Internalname, A544AppVersionName, StringUtil.RTrim( context.localUtil.Format( A544AppVersionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divPagetable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlepage_Internalname, context.GetMessage( "Page", ""), "", "", lblTitlepage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridtrn_appversion_page( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridtrn_appversion_page( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount110 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_110 = 1;
               ScanStart1Q110( ) ;
               while ( RcdFound110 != 0 )
               {
                  init_level_properties110( ) ;
                  getByPrimaryKey1Q110( ) ;
                  AddRow1Q110( ) ;
                  ScanNext1Q110( ) ;
               }
               ScanEnd1Q110( ) ;
               nBlankRcdCount110 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1Q110( ) ;
            standaloneModal1Q110( ) ;
            sMode110 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow1Q110( ) ;
               edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_110 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1Q110( ) ;
               }
               SendRow1Q110( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount110 = 5;
            nRcdExists_110 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1Q110( ) ;
               while ( RcdFound110 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_53110( ) ;
                  init_level_properties110( ) ;
                  standaloneNotModal1Q110( ) ;
                  getByPrimaryKey1Q110( ) ;
                  standaloneModal1Q110( ) ;
                  AddRow1Q110( ) ;
                  ScanNext1Q110( ) ;
               }
               ScanEnd1Q110( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode110 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_53110( ) ;
         InitAll1Q110( ) ;
         init_level_properties110( ) ;
         nRcdExists_110 = 0;
         nIsMod_110 = 0;
         nRcdDeleted_110 = 0;
         nBlankRcdCount110 = (short)(nBlankRcdUsr110+nBlankRcdCount110);
         fRowAdded = 0;
         while ( nBlankRcdCount110 > 0 )
         {
            A521PageId = Guid.Empty;
            standaloneNotModal1Q110( ) ;
            standaloneModal1Q110( ) ;
            AddRow1Q110( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount110 = (short)(nBlankRcdCount110-1);
         }
         Gx_mode = sMode110;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtrn_appversion_pageContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtrn_appversion_page", Gridtrn_appversion_pageContainer, subGridtrn_appversion_page_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_appversion_pageContainerData", Gridtrn_appversion_pageContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_appversion_pageContainerData"+"V", Gridtrn_appversion_pageContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtrn_appversion_pageContainerData"+"V"+"\" value='"+Gridtrn_appversion_pageContainer.GridValuesHidden()+"'/>") ;
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
            Z543AppVersionId = StringUtil.StrToGuid( cgiGet( "Z543AppVersionId"));
            Z544AppVersionName = cgiGet( "Z544AppVersionName");
            Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtAppVersionId_Internalname), "") == 0 )
            {
               A543AppVersionId = Guid.Empty;
               AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
            }
            else
            {
               try
               {
                  A543AppVersionId = StringUtil.StrToGuid( cgiGet( edtAppVersionId_Internalname));
                  AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "APPVERSIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A544AppVersionName = cgiGet( edtAppVersionName_Internalname);
            AssignAttri("", false, "A544AppVersionName", A544AppVersionName);
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
               A543AppVersionId = StringUtil.StrToGuid( GetPar( "AppVersionId"));
               AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A543AppVersionId) && ( Gx_BScreen == 0 ) )
               {
                  A543AppVersionId = Guid.NewGuid( );
                  AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
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
               InitAll1Q109( ) ;
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
         DisableAttributes1Q109( ) ;
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

      protected void CONFIRM_1Q110( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow1Q110( ) ;
            if ( ( nRcdExists_110 != 0 ) || ( nIsMod_110 != 0 ) )
            {
               GetKey1Q110( ) ;
               if ( ( nRcdExists_110 == 0 ) && ( nRcdDeleted_110 == 0 ) )
               {
                  if ( RcdFound110 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1Q110( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1Q110( ) ;
                        CloseExtendedTableCursors1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PAGEID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound110 != 0 )
                  {
                     if ( nRcdDeleted_110 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1Q110( ) ;
                        Load1Q110( ) ;
                        BeforeValidate1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1Q110( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_110 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1Q110( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1Q110( ) ;
                              CloseExtendedTableCursors1Q110( ) ;
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
                     if ( nRcdDeleted_110 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A521PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A522PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A523PageStructure) ;
            ChangePostValue( cmbPageType_Internalname, A545PageType) ;
            ChangePostValue( "ZT_"+"Z521PageId_"+sGXsfl_53_idx, Z521PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z522PageName_"+sGXsfl_53_idx, Z522PageName) ;
            ChangePostValue( "ZT_"+"Z545PageType_"+sGXsfl_53_idx, Z545PageType) ;
            ChangePostValue( "nRcdDeleted_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_110 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1Q0( )
      {
      }

      protected void ZM1Q109( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z544AppVersionName = T001Q5_A544AppVersionName[0];
               Z29LocationId = T001Q5_A29LocationId[0];
            }
            else
            {
               Z544AppVersionName = A544AppVersionName;
               Z29LocationId = A29LocationId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z543AppVersionId = A543AppVersionId;
            Z544AppVersionName = A544AppVersionName;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A29LocationId) && ( Gx_BScreen == 0 ) )
         {
            A29LocationId = Guid.NewGuid( );
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( IsIns( )  && (Guid.Empty==A543AppVersionId) && ( Gx_BScreen == 0 ) )
         {
            A543AppVersionId = Guid.NewGuid( );
            AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
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

      protected void Load1Q109( )
      {
         /* Using cursor T001Q6 */
         pr_default.execute(4, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound109 = 1;
            A544AppVersionName = T001Q6_A544AppVersionName[0];
            AssignAttri("", false, "A544AppVersionName", A544AppVersionName);
            A29LocationId = T001Q6_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            ZM1Q109( -8) ;
         }
         pr_default.close(4);
         OnLoadActions1Q109( ) ;
      }

      protected void OnLoadActions1Q109( )
      {
      }

      protected void CheckExtendedTable1Q109( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1Q109( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Q109( )
      {
         /* Using cursor T001Q7 */
         pr_default.execute(5, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Q5 */
         pr_default.execute(3, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1Q109( 8) ;
            RcdFound109 = 1;
            A543AppVersionId = T001Q5_A543AppVersionId[0];
            AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
            A544AppVersionName = T001Q5_A544AppVersionName[0];
            AssignAttri("", false, "A544AppVersionName", A544AppVersionName);
            A29LocationId = T001Q5_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            Z543AppVersionId = A543AppVersionId;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Q109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey1Q109( ) ;
            }
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey1Q109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q109( ) ;
         if ( RcdFound109 == 0 )
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
         RcdFound109 = 0;
         /* Using cursor T001Q8 */
         pr_default.execute(6, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001Q8_A543AppVersionId[0], A543AppVersionId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001Q8_A543AppVersionId[0], A543AppVersionId, 0) > 0 ) ) )
            {
               A543AppVersionId = T001Q8_A543AppVersionId[0];
               AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
               RcdFound109 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound109 = 0;
         /* Using cursor T001Q9 */
         pr_default.execute(7, new Object[] {A543AppVersionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001Q9_A543AppVersionId[0], A543AppVersionId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001Q9_A543AppVersionId[0], A543AppVersionId, 0) < 0 ) ) )
            {
               A543AppVersionId = T001Q9_A543AppVersionId[0];
               AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
               RcdFound109 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Q109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Q109( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( A543AppVersionId != Z543AppVersionId )
               {
                  A543AppVersionId = Z543AppVersionId;
                  AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APPVERSIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1Q109( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A543AppVersionId != Z543AppVersionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Q109( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APPVERSIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Q109( ) ;
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
         if ( A543AppVersionId != Z543AppVersionId )
         {
            A543AppVersionId = Z543AppVersionId;
            AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APPVERSIONID");
            AnyError = 1;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAppVersionId_Internalname;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "APPVERSIONID");
            AnyError = 1;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Q109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Q109( ) ;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
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
         ScanStart1Q109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound109 != 0 )
            {
               ScanNext1Q109( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Q109( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Q109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q4 */
            pr_default.execute(2, new Object[] {A543AppVersionId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z544AppVersionName, T001Q4_A544AppVersionName[0]) != 0 ) || ( Z29LocationId != T001Q4_A29LocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z544AppVersionName, T001Q4_A544AppVersionName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"AppVersionName");
                  GXUtil.WriteLogRaw("Old: ",Z544AppVersionName);
                  GXUtil.WriteLogRaw("Current: ",T001Q4_A544AppVersionName[0]);
               }
               if ( Z29LocationId != T001Q4_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001Q4_A29LocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q109( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q109( 0) ;
            CheckOptimisticConcurrency1Q109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q10 */
                     pr_default.execute(8, new Object[] {A543AppVersionId, A544AppVersionName, A29LocationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
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
                           ProcessLevel1Q109( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1Q0( ) ;
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
               Load1Q109( ) ;
            }
            EndLevel1Q109( ) ;
         }
         CloseExtendedTableCursors1Q109( ) ;
      }

      protected void Update1Q109( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q11 */
                     pr_default.execute(9, new Object[] {A544AppVersionName, A29LocationId, A543AppVersionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q109( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1Q109( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1Q0( ) ;
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
            EndLevel1Q109( ) ;
         }
         CloseExtendedTableCursors1Q109( ) ;
      }

      protected void DeferredUpdate1Q109( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Q109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q109( ) ;
            AfterConfirm1Q109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q109( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1Q110( ) ;
                  while ( RcdFound110 != 0 )
                  {
                     getByPrimaryKey1Q110( ) ;
                     Delete1Q110( ) ;
                     ScanNext1Q110( ) ;
                  }
                  ScanEnd1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q12 */
                     pr_default.execute(10, new Object[] {A543AppVersionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound109 == 0 )
                           {
                              InitAll1Q109( ) ;
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
                           ResetCaption1Q0( ) ;
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
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q109( ) ;
         Gx_mode = sMode109;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q109( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel1Q110( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow1Q110( ) ;
            if ( ( nRcdExists_110 != 0 ) || ( nIsMod_110 != 0 ) )
            {
               standaloneNotModal1Q110( ) ;
               GetKey1Q110( ) ;
               if ( ( nRcdExists_110 == 0 ) && ( nRcdDeleted_110 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1Q110( ) ;
               }
               else
               {
                  if ( RcdFound110 != 0 )
                  {
                     if ( ( nRcdDeleted_110 != 0 ) && ( nRcdExists_110 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1Q110( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_110 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1Q110( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_110 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A521PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A522PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A523PageStructure) ;
            ChangePostValue( cmbPageType_Internalname, A545PageType) ;
            ChangePostValue( "ZT_"+"Z521PageId_"+sGXsfl_53_idx, Z521PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z522PageName_"+sGXsfl_53_idx, Z522PageName) ;
            ChangePostValue( "ZT_"+"Z545PageType_"+sGXsfl_53_idx, Z545PageType) ;
            ChangePostValue( "nRcdDeleted_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_110_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_110), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_110 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1Q110( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_110 = 0;
         nIsMod_110 = 0;
         nRcdDeleted_110 = 0;
      }

      protected void ProcessLevel1Q109( )
      {
         /* Save parent mode. */
         sMode109 = Gx_mode;
         ProcessNestedLevel1Q110( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode109;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1Q109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Q109( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_appversion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_appversion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Q109( )
      {
         /* Using cursor T001Q13 */
         pr_default.execute(11);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound109 = 1;
            A543AppVersionId = T001Q13_A543AppVersionId[0];
            AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q109( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound109 = 1;
            A543AppVersionId = T001Q13_A543AppVersionId[0];
            AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
         }
      }

      protected void ScanEnd1Q109( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1Q109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q109( )
      {
         edtAppVersionId_Enabled = 0;
         AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         edtAppVersionName_Enabled = 0;
         AssignProp("", false, edtAppVersionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionName_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
      }

      protected void ZM1Q110( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z522PageName = T001Q3_A522PageName[0];
               Z545PageType = T001Q3_A545PageType[0];
            }
            else
            {
               Z522PageName = A522PageName;
               Z545PageType = A545PageType;
            }
         }
         if ( GX_JID == -9 )
         {
            Z543AppVersionId = A543AppVersionId;
            Z521PageId = A521PageId;
            Z522PageName = A522PageName;
            Z523PageStructure = A523PageStructure;
            Z545PageType = A545PageType;
         }
      }

      protected void standaloneNotModal1Q110( )
      {
      }

      protected void standaloneModal1Q110( )
      {
         if ( IsIns( )  && (Guid.Empty==A521PageId) && ( Gx_BScreen == 0 ) )
         {
            A521PageId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPageId_Enabled = 0;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtPageId_Enabled = 1;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1Q110( )
      {
         /* Using cursor T001Q14 */
         pr_default.execute(12, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound110 = 1;
            A522PageName = T001Q14_A522PageName[0];
            A523PageStructure = T001Q14_A523PageStructure[0];
            A545PageType = T001Q14_A545PageType[0];
            ZM1Q110( -9) ;
         }
         pr_default.close(12);
         OnLoadActions1Q110( ) ;
      }

      protected void OnLoadActions1Q110( )
      {
      }

      protected void CheckExtendedTable1Q110( )
      {
         nIsDirty_110 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1Q110( ) ;
         if ( ! ( ( StringUtil.StrCmp(A545PageType, "Menu") == 0 ) || ( StringUtil.StrCmp(A545PageType, "Content") == 0 ) ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_53_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Page Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPageType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1Q110( )
      {
      }

      protected void enableDisable1Q110( )
      {
      }

      protected void GetKey1Q110( )
      {
         /* Using cursor T001Q15 */
         pr_default.execute(13, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound110 = 1;
         }
         else
         {
            RcdFound110 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey1Q110( )
      {
         /* Using cursor T001Q3 */
         pr_default.execute(1, new Object[] {A543AppVersionId, A521PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q110( 9) ;
            RcdFound110 = 1;
            InitializeNonKey1Q110( ) ;
            A521PageId = T001Q3_A521PageId[0];
            A522PageName = T001Q3_A522PageName[0];
            A523PageStructure = T001Q3_A523PageStructure[0];
            A545PageType = T001Q3_A545PageType[0];
            Z543AppVersionId = A543AppVersionId;
            Z521PageId = A521PageId;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1Q110( ) ;
            Load1Q110( ) ;
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound110 = 0;
            InitializeNonKey1Q110( ) ;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1Q110( ) ;
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1Q110( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1Q110( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q2 */
            pr_default.execute(0, new Object[] {A543AppVersionId, A521PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z522PageName, T001Q2_A522PageName[0]) != 0 ) || ( StringUtil.StrCmp(Z545PageType, T001Q2_A545PageType[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z522PageName, T001Q2_A522PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageName");
                  GXUtil.WriteLogRaw("Old: ",Z522PageName);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A522PageName[0]);
               }
               if ( StringUtil.StrCmp(Z545PageType, T001Q2_A545PageType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageType");
                  GXUtil.WriteLogRaw("Old: ",Z545PageType);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A545PageType[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersionPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q110( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q110( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q110( 0) ;
            CheckOptimisticConcurrency1Q110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q16 */
                     pr_default.execute(14, new Object[] {A543AppVersionId, A521PageId, A522PageName, A523PageStructure, A545PageType});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
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
               Load1Q110( ) ;
            }
            EndLevel1Q110( ) ;
         }
         CloseExtendedTableCursors1Q110( ) ;
      }

      protected void Update1Q110( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q110( ) ;
         }
         if ( ( nIsMod_110 != 0 ) || ( nIsDirty_110 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1Q110( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1Q110( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1Q110( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001Q17 */
                        pr_default.execute(15, new Object[] {A522PageName, A523PageStructure, A545PageType, A543AppVersionId, A521PageId});
                        pr_default.close(15);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                        if ( (pr_default.getStatus(15) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1Q110( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1Q110( ) ;
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
               EndLevel1Q110( ) ;
            }
         }
         CloseExtendedTableCursors1Q110( ) ;
      }

      protected void DeferredUpdate1Q110( )
      {
      }

      protected void Delete1Q110( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Q110( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q110( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q110( ) ;
            AfterConfirm1Q110( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q110( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Q18 */
                  pr_default.execute(16, new Object[] {A543AppVersionId, A521PageId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
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
         sMode110 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q110( ) ;
         Gx_mode = sMode110;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q110( )
      {
         standaloneModal1Q110( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1Q110( )
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

      public void ScanStart1Q110( )
      {
         /* Scan By routine */
         /* Using cursor T001Q19 */
         pr_default.execute(17, new Object[] {A543AppVersionId});
         RcdFound110 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound110 = 1;
            A521PageId = T001Q19_A521PageId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q110( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound110 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound110 = 1;
            A521PageId = T001Q19_A521PageId[0];
         }
      }

      protected void ScanEnd1Q110( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1Q110( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q110( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q110( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q110( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q110( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q110( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q110( )
      {
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtPageName_Enabled = 0;
         AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtPageStructure_Enabled = 0;
         AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbPageType.Enabled = 0;
         AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes1Q110( )
      {
      }

      protected void send_integrity_lvl_hashes1Q109( )
      {
      }

      protected void SubsflControlProps_53110( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_53_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_53_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_53_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_53110( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_53_fel_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_53_fel_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_53_fel_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow1Q110( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53110( ) ;
         SendRow1Q110( ) ;
      }

      protected void SendRow1Q110( )
      {
         Gridtrn_appversion_pageRow = GXWebRow.GetNew(context);
         if ( subGridtrn_appversion_page_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
            }
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 0;
            subGridtrn_appversion_page_Backcolor = subGridtrn_appversion_page_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Uniform";
            }
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
            }
            subGridtrn_appversion_page_Backcolor = (int)(0x0);
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridtrn_appversion_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
               {
                  subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Even";
               }
            }
            else
            {
               subGridtrn_appversion_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
               {
                  subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_110_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageId_Internalname,A521PageId.ToString(),A521PageId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)53,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_110_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageName_Internalname,(string)A522PageName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_110_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageStructure_Internalname,(string)A523PageStructure,(string)A523PageStructure,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageStructure_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageStructure_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)53,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_110_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         if ( ( cmbPageType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_53_idx;
            cmbPageType.Name = GXCCtl;
            cmbPageType.WebTags = "";
            cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
            cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
            if ( cmbPageType.ItemCount > 0 )
            {
               A545PageType = cmbPageType.getValidValue(A545PageType);
            }
         }
         /* ComboBox */
         Gridtrn_appversion_pageRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPageType,(string)cmbPageType_Internalname,StringUtil.RTrim( A545PageType),(short)1,(string)cmbPageType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbPageType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
         cmbPageType.CurrentValue = StringUtil.RTrim( A545PageType);
         AssignProp("", false, cmbPageType_Internalname, "Values", (string)(cmbPageType.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         ajax_sending_grid_row(Gridtrn_appversion_pageRow);
         send_integrity_lvl_hashes1Q110( ) ;
         GXCCtl = "Z521PageId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z521PageId.ToString());
         GXCCtl = "Z522PageName_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z522PageName);
         GXCCtl = "Z545PageType_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z545PageType);
         GXCCtl = "nRcdDeleted_110_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_110), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_110_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_110), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_110_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_110), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAGEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGENAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGESTRUCTURE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGETYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridtrn_appversion_pageContainer.AddRow(Gridtrn_appversion_pageRow);
      }

      protected void ReadRow1Q110( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53110( ) ;
         edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_53_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtPageId_Internalname), "") == 0 )
         {
            A521PageId = Guid.Empty;
         }
         else
         {
            try
            {
               A521PageId = StringUtil.StrToGuid( cgiGet( edtPageId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "PAGEID_" + sGXsfl_53_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPageId_Internalname;
               wbErr = true;
            }
         }
         A522PageName = cgiGet( edtPageName_Internalname);
         A523PageStructure = cgiGet( edtPageStructure_Internalname);
         cmbPageType.Name = cmbPageType_Internalname;
         cmbPageType.CurrentValue = cgiGet( cmbPageType_Internalname);
         A545PageType = cgiGet( cmbPageType_Internalname);
         GXCCtl = "Z521PageId_" + sGXsfl_53_idx;
         Z521PageId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z522PageName_" + sGXsfl_53_idx;
         Z522PageName = cgiGet( GXCCtl);
         GXCCtl = "Z545PageType_" + sGXsfl_53_idx;
         Z545PageType = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_110_" + sGXsfl_53_idx;
         nRcdDeleted_110 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_110_" + sGXsfl_53_idx;
         nRcdExists_110 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_110_" + sGXsfl_53_idx;
         nIsMod_110 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPageId_Enabled = edtPageId_Enabled;
      }

      protected void ConfirmValues1Q0( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_53110( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_53110( ) ;
            ChangePostValue( "Z521PageId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z521PageId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z521PageId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z522PageName_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z522PageName_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z522PageName_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z545PageType_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z545PageType_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z545PageType_"+sGXsfl_53_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_appversion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z543AppVersionId", Z543AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z544AppVersionName", Z544AppVersionName);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
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
         return formatLink("trn_appversion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AppVersion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_App Version", "") ;
      }

      protected void InitializeNonKey1Q109( )
      {
         A544AppVersionName = "";
         AssignAttri("", false, "A544AppVersionName", A544AppVersionName);
         A29LocationId = Guid.NewGuid( );
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         Z544AppVersionName = "";
         Z29LocationId = Guid.Empty;
      }

      protected void InitAll1Q109( )
      {
         A543AppVersionId = Guid.NewGuid( );
         AssignAttri("", false, "A543AppVersionId", A543AppVersionId.ToString());
         InitializeNonKey1Q109( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
      }

      protected void InitializeNonKey1Q110( )
      {
         A522PageName = "";
         A523PageStructure = "";
         A545PageType = "";
         Z522PageName = "";
         Z545PageType = "";
      }

      protected void InitAll1Q110( )
      {
         A521PageId = Guid.NewGuid( );
         InitializeNonKey1Q110( ) ;
      }

      protected void StandaloneModalInsert1Q110( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025361461412", true, true);
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
         context.AddJavascriptSource("trn_appversion.js", "?2025361461412", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties110( )
      {
         edtPageId_Enabled = defedtPageId_Enabled;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridtrn_appversion_pageContainer.AddObjectProperty("GridName", "Gridtrn_appversion_page");
         Gridtrn_appversion_pageContainer.AddObjectProperty("Header", subGridtrn_appversion_page_Header);
         Gridtrn_appversion_pageContainer.AddObjectProperty("Class", "Grid");
         Gridtrn_appversion_pageContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Backcolorstyle), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("CmpContext", "");
         Gridtrn_appversion_pageContainer.AddObjectProperty("InMasterPage", "false");
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A521PageId.ToString()));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A522PageName));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A523PageStructure));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A545PageType));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Selectedindex), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowselection), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Selectioncolor), 9, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowhovering), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Hoveringcolor), 9, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowcollapsing), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Collapsed), 1, 0, ".", "")));
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
         edtAppVersionId_Internalname = "APPVERSIONID";
         edtAppVersionName_Internalname = "APPVERSIONNAME";
         edtLocationId_Internalname = "LOCATIONID";
         lblTitlepage_Internalname = "TITLEPAGE";
         edtPageId_Internalname = "PAGEID";
         edtPageName_Internalname = "PAGENAME";
         edtPageStructure_Internalname = "PAGESTRUCTURE";
         cmbPageType_Internalname = "PAGETYPE";
         divPagetable_Internalname = "PAGETABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridtrn_appversion_page_Internalname = "GRIDTRN_APPVERSION_PAGE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridtrn_appversion_page_Allowcollapsing = 0;
         subGridtrn_appversion_page_Allowselection = 0;
         subGridtrn_appversion_page_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_App Version", "");
         cmbPageType_Jsonclick = "";
         edtPageStructure_Jsonclick = "";
         edtPageName_Jsonclick = "";
         edtPageId_Jsonclick = "";
         subGridtrn_appversion_page_Class = "Grid";
         subGridtrn_appversion_page_Backcolorstyle = 0;
         cmbPageType.Enabled = 1;
         edtPageStructure_Enabled = 1;
         edtPageName_Enabled = 1;
         edtPageId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtAppVersionName_Jsonclick = "";
         edtAppVersionName_Enabled = 1;
         edtAppVersionId_Jsonclick = "";
         edtAppVersionId_Enabled = 1;
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

      protected void gxnrGridtrn_appversion_page_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_53110( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1Q110( ) ;
            standaloneModal1Q110( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1Q110( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_53110( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtrn_appversion_pageContainer)) ;
         /* End function gxnrGridtrn_appversion_page_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PAGETYPE_" + sGXsfl_53_idx;
         cmbPageType.Name = GXCCtl;
         cmbPageType.WebTags = "";
         cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
         cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
         if ( cmbPageType.ItemCount > 0 )
         {
            A545PageType = cmbPageType.getValidValue(A545PageType);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAppVersionName_Internalname;
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

      public void Valid_Appversionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A544AppVersionName", A544AppVersionName);
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z543AppVersionId", Z543AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z544AppVersionName", Z544AppVersionName);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
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
         setEventMetadata("VALID_APPVERSIONID","""{"handler":"Valid_Appversionid","iparms":[{"av":"A543AppVersionId","fld":"APPVERSIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_APPVERSIONID",""","oparms":[{"av":"A544AppVersionName","fld":"APPVERSIONNAME"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z543AppVersionId"},{"av":"Z544AppVersionName"},{"av":"Z29LocationId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_PAGEID","""{"handler":"Valid_Pageid","iparms":[]}""");
         setEventMetadata("VALID_PAGETYPE","""{"handler":"Valid_Pagetype","iparms":[]}""");
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
         Z543AppVersionId = Guid.Empty;
         Z544AppVersionName = "";
         Z29LocationId = Guid.Empty;
         Z521PageId = Guid.Empty;
         Z522PageName = "";
         Z545PageType = "";
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
         A543AppVersionId = Guid.Empty;
         A544AppVersionName = "";
         A29LocationId = Guid.Empty;
         lblTitlepage_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtrn_appversion_pageContainer = new GXWebGrid( context);
         sMode110 = "";
         A521PageId = Guid.Empty;
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A522PageName = "";
         A523PageStructure = "";
         A545PageType = "";
         T001Q6_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q6_A544AppVersionName = new string[] {""} ;
         T001Q6_A29LocationId = new Guid[] {Guid.Empty} ;
         T001Q7_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q5_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q5_A544AppVersionName = new string[] {""} ;
         T001Q5_A29LocationId = new Guid[] {Guid.Empty} ;
         sMode109 = "";
         T001Q8_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q9_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q4_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q4_A544AppVersionName = new string[] {""} ;
         T001Q4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001Q13_A543AppVersionId = new Guid[] {Guid.Empty} ;
         Z523PageStructure = "";
         T001Q14_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q14_A521PageId = new Guid[] {Guid.Empty} ;
         T001Q14_A522PageName = new string[] {""} ;
         T001Q14_A523PageStructure = new string[] {""} ;
         T001Q14_A545PageType = new string[] {""} ;
         T001Q15_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q15_A521PageId = new Guid[] {Guid.Empty} ;
         T001Q3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q3_A521PageId = new Guid[] {Guid.Empty} ;
         T001Q3_A522PageName = new string[] {""} ;
         T001Q3_A523PageStructure = new string[] {""} ;
         T001Q3_A545PageType = new string[] {""} ;
         T001Q2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q2_A521PageId = new Guid[] {Guid.Empty} ;
         T001Q2_A522PageName = new string[] {""} ;
         T001Q2_A523PageStructure = new string[] {""} ;
         T001Q2_A545PageType = new string[] {""} ;
         T001Q19_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T001Q19_A521PageId = new Guid[] {Guid.Empty} ;
         Gridtrn_appversion_pageRow = new GXWebRow();
         subGridtrn_appversion_page_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i29LocationId = Guid.Empty;
         Gridtrn_appversion_pageColumn = new GXWebColumn();
         ZZ543AppVersionId = Guid.Empty;
         ZZ544AppVersionName = "";
         ZZ29LocationId = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__default(),
            new Object[][] {
                new Object[] {
               T001Q2_A543AppVersionId, T001Q2_A521PageId, T001Q2_A522PageName, T001Q2_A523PageStructure, T001Q2_A545PageType
               }
               , new Object[] {
               T001Q3_A543AppVersionId, T001Q3_A521PageId, T001Q3_A522PageName, T001Q3_A523PageStructure, T001Q3_A545PageType
               }
               , new Object[] {
               T001Q4_A543AppVersionId, T001Q4_A544AppVersionName, T001Q4_A29LocationId
               }
               , new Object[] {
               T001Q5_A543AppVersionId, T001Q5_A544AppVersionName, T001Q5_A29LocationId
               }
               , new Object[] {
               T001Q6_A543AppVersionId, T001Q6_A544AppVersionName, T001Q6_A29LocationId
               }
               , new Object[] {
               T001Q7_A543AppVersionId
               }
               , new Object[] {
               T001Q8_A543AppVersionId
               }
               , new Object[] {
               T001Q9_A543AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q13_A543AppVersionId
               }
               , new Object[] {
               T001Q14_A543AppVersionId, T001Q14_A521PageId, T001Q14_A522PageName, T001Q14_A523PageStructure, T001Q14_A545PageType
               }
               , new Object[] {
               T001Q15_A543AppVersionId, T001Q15_A521PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q19_A543AppVersionId, T001Q19_A521PageId
               }
            }
         );
         Z521PageId = Guid.NewGuid( );
         A521PageId = Guid.NewGuid( );
         Z29LocationId = Guid.NewGuid( );
         A29LocationId = Guid.NewGuid( );
         i29LocationId = Guid.NewGuid( );
         Z543AppVersionId = Guid.NewGuid( );
         A543AppVersionId = Guid.NewGuid( );
      }

      private short nRcdDeleted_110 ;
      private short nRcdExists_110 ;
      private short nIsMod_110 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount110 ;
      private short RcdFound110 ;
      private short nBlankRcdUsr110 ;
      private short RcdFound109 ;
      private short nIsDirty_110 ;
      private short subGridtrn_appversion_page_Backcolorstyle ;
      private short subGridtrn_appversion_page_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridtrn_appversion_page_Allowselection ;
      private short subGridtrn_appversion_page_Allowhovering ;
      private short subGridtrn_appversion_page_Allowcollapsing ;
      private short subGridtrn_appversion_page_Collapsed ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAppVersionId_Enabled ;
      private int edtAppVersionName_Enabled ;
      private int edtLocationId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPageId_Enabled ;
      private int edtPageName_Enabled ;
      private int edtPageStructure_Enabled ;
      private int fRowAdded ;
      private int subGridtrn_appversion_page_Backcolor ;
      private int subGridtrn_appversion_page_Allbackcolor ;
      private int defedtPageId_Enabled ;
      private int idxLst ;
      private int subGridtrn_appversion_page_Selectedindex ;
      private int subGridtrn_appversion_page_Selectioncolor ;
      private int subGridtrn_appversion_page_Hoveringcolor ;
      private long GRIDTRN_APPVERSION_PAGE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAppVersionId_Internalname ;
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
      private string edtAppVersionId_Jsonclick ;
      private string edtAppVersionName_Internalname ;
      private string edtAppVersionName_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string divPagetable_Internalname ;
      private string lblTitlepage_Internalname ;
      private string lblTitlepage_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode110 ;
      private string edtPageId_Internalname ;
      private string edtPageName_Internalname ;
      private string edtPageStructure_Internalname ;
      private string cmbPageType_Internalname ;
      private string sStyleString ;
      private string subGridtrn_appversion_page_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode109 ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridtrn_appversion_page_Class ;
      private string subGridtrn_appversion_page_Linesclass ;
      private string ROClassString ;
      private string edtPageId_Jsonclick ;
      private string edtPageName_Jsonclick ;
      private string edtPageStructure_Jsonclick ;
      private string cmbPageType_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridtrn_appversion_page_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private string A523PageStructure ;
      private string Z523PageStructure ;
      private string Z544AppVersionName ;
      private string Z522PageName ;
      private string Z545PageType ;
      private string A544AppVersionName ;
      private string A522PageName ;
      private string A545PageType ;
      private string ZZ544AppVersionName ;
      private Guid Z543AppVersionId ;
      private Guid Z29LocationId ;
      private Guid Z521PageId ;
      private Guid A543AppVersionId ;
      private Guid A29LocationId ;
      private Guid A521PageId ;
      private Guid i29LocationId ;
      private Guid ZZ543AppVersionId ;
      private Guid ZZ29LocationId ;
      private GXWebGrid Gridtrn_appversion_pageContainer ;
      private GXWebRow Gridtrn_appversion_pageRow ;
      private GXWebColumn Gridtrn_appversion_pageColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPageType ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001Q6_A543AppVersionId ;
      private string[] T001Q6_A544AppVersionName ;
      private Guid[] T001Q6_A29LocationId ;
      private Guid[] T001Q7_A543AppVersionId ;
      private Guid[] T001Q5_A543AppVersionId ;
      private string[] T001Q5_A544AppVersionName ;
      private Guid[] T001Q5_A29LocationId ;
      private Guid[] T001Q8_A543AppVersionId ;
      private Guid[] T001Q9_A543AppVersionId ;
      private Guid[] T001Q4_A543AppVersionId ;
      private string[] T001Q4_A544AppVersionName ;
      private Guid[] T001Q4_A29LocationId ;
      private Guid[] T001Q13_A543AppVersionId ;
      private Guid[] T001Q14_A543AppVersionId ;
      private Guid[] T001Q14_A521PageId ;
      private string[] T001Q14_A522PageName ;
      private string[] T001Q14_A523PageStructure ;
      private string[] T001Q14_A545PageType ;
      private Guid[] T001Q15_A543AppVersionId ;
      private Guid[] T001Q15_A521PageId ;
      private Guid[] T001Q3_A543AppVersionId ;
      private Guid[] T001Q3_A521PageId ;
      private string[] T001Q3_A522PageName ;
      private string[] T001Q3_A523PageStructure ;
      private string[] T001Q3_A545PageType ;
      private Guid[] T001Q2_A543AppVersionId ;
      private Guid[] T001Q2_A521PageId ;
      private string[] T001Q2_A522PageName ;
      private string[] T001Q2_A523PageStructure ;
      private string[] T001Q2_A545PageType ;
      private Guid[] T001Q19_A543AppVersionId ;
      private Guid[] T001Q19_A521PageId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appversion__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT001Q2;
       prmT001Q2 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q3;
       prmT001Q3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q4;
       prmT001Q4 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q5;
       prmT001Q5 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q6;
       prmT001Q6 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q7;
       prmT001Q7 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q8;
       prmT001Q8 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q9;
       prmT001Q9 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q10;
       prmT001Q10 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q11;
       prmT001Q11 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q12;
       prmT001Q12 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q13;
       prmT001Q13 = new Object[] {
       };
       Object[] prmT001Q14;
       prmT001Q14 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q15;
       prmT001Q15 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q16;
       prmT001Q16 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0)
       };
       Object[] prmT001Q17;
       prmT001Q17 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q18;
       prmT001Q18 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Q19;
       prmT001Q19 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001Q2", "SELECT AppVersionId, PageId, PageName, PageStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId  FOR UPDATE OF Trn_AppVersionPage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q3", "SELECT AppVersionId, PageId, PageName, PageStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q4", "SELECT AppVersionId, AppVersionName, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId  FOR UPDATE OF Trn_AppVersion NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q5", "SELECT AppVersionId, AppVersionName, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q6", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.LocationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q7", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q8", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId > :AppVersionId) ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Q9", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId < :AppVersionId) ORDER BY AppVersionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Q10", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, LocationId) VALUES(:AppVersionId, :AppVersionName, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001Q10)
          ,new CursorDef("T001Q11", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName, LocationId=:LocationId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q11)
          ,new CursorDef("T001Q12", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q12)
          ,new CursorDef("T001Q13", "SELECT AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q13,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q14", "SELECT AppVersionId, PageId, PageName, PageStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :PageId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q14,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q15", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Q16", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersionPage(AppVersionId, PageId, PageName, PageStructure, PageType) VALUES(:AppVersionId, :PageId, :PageName, :PageStructure, :PageType);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001Q16)
          ,new CursorDef("T001Q17", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName, PageStructure=:PageStructure, PageType=:PageType  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q17)
          ,new CursorDef("T001Q18", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q18)
          ,new CursorDef("T001Q19", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q19,11, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
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
