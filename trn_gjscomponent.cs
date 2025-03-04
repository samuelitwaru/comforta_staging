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
   public class trn_gjscomponent : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_GJSComponent", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtGJSComponentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_gjscomponent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_gjscomponent( IGxContext context )
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
         chkGJSComponentSelectable = new GXCheckbox();
         chkGJSComponentCopyable = new GXCheckbox();
         chkGJSComponentEditable = new GXCheckbox();
         chkGJSComponentRemovable = new GXCheckbox();
         chkGJSComponentHighlightable = new GXCheckbox();
         chkGJSComponentHoverable = new GXCheckbox();
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
            return "trn_gjscomponent_Execute" ;
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
         A535GJSComponentSelectable = StringUtil.StrToBool( StringUtil.BoolToStr( A535GJSComponentSelectable));
         AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
         A537GJSComponentCopyable = StringUtil.StrToBool( StringUtil.BoolToStr( A537GJSComponentCopyable));
         AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
         A538GJSComponentEditable = StringUtil.StrToBool( StringUtil.BoolToStr( A538GJSComponentEditable));
         AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
         A539GJSComponentRemovable = StringUtil.StrToBool( StringUtil.BoolToStr( A539GJSComponentRemovable));
         AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
         A540GJSComponentHighlightable = StringUtil.StrToBool( StringUtil.BoolToStr( A540GJSComponentHighlightable));
         AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
         A541GJSComponentHoverable = StringUtil.StrToBool( StringUtil.BoolToStr( A541GJSComponentHoverable));
         AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_GJSComponent", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_GJSComponent.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_GJSComponent.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGJSComponentId_Internalname, A528GJSComponentId.ToString(), A528GJSComponentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGJSComponentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGJSComponentId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentType_Internalname, context.GetMessage( "Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGJSComponentType_Internalname, A529GJSComponentType, StringUtil.RTrim( context.localUtil.Format( A529GJSComponentType, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGJSComponentType_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGJSComponentType_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentClasses_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentClasses_Internalname, context.GetMessage( "Classes", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGJSComponentClasses_Internalname, A530GJSComponentClasses, StringUtil.RTrim( context.localUtil.Format( A530GJSComponentClasses, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGJSComponentClasses_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGJSComponentClasses_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Component", "start", true, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentContent_Internalname, context.GetMessage( "Content", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGJSComponentContent_Internalname, A531GJSComponentContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtGJSComponentContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentSyle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentSyle_Internalname, context.GetMessage( "Syle", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGJSComponentSyle_Internalname, A532GJSComponentSyle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtGJSComponentSyle_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentAttrbutes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentAttrbutes_Internalname, context.GetMessage( "Attrbutes", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGJSComponentAttrbutes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A533GJSComponentAttrbutes), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtGJSComponentAttrbutes_Enabled!=0) ? context.localUtil.Format( (decimal)(A533GJSComponentAttrbutes), "ZZZ9") : context.localUtil.Format( (decimal)(A533GJSComponentAttrbutes), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGJSComponentAttrbutes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGJSComponentAttrbutes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentTraits_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentTraits_Internalname, context.GetMessage( "Traits", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGJSComponentTraits_Internalname, A534GJSComponentTraits, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtGJSComponentTraits_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentSelectable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentSelectable_Internalname, context.GetMessage( "Selectable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentSelectable_Internalname, StringUtil.BoolToStr( A535GJSComponentSelectable), "", context.GetMessage( "Selectable", ""), 1, chkGJSComponentSelectable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGJSComponentDroppable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGJSComponentDroppable_Internalname, context.GetMessage( "Droppable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGJSComponentDroppable_Internalname, A536GJSComponentDroppable, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtGJSComponentDroppable_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentCopyable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentCopyable_Internalname, context.GetMessage( "Copyable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentCopyable_Internalname, StringUtil.BoolToStr( A537GJSComponentCopyable), "", context.GetMessage( "Copyable", ""), 1, chkGJSComponentCopyable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentEditable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentEditable_Internalname, context.GetMessage( "Editable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentEditable_Internalname, StringUtil.BoolToStr( A538GJSComponentEditable), "", context.GetMessage( "Editable", ""), 1, chkGJSComponentEditable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentRemovable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentRemovable_Internalname, context.GetMessage( "Removable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentRemovable_Internalname, StringUtil.BoolToStr( A539GJSComponentRemovable), "", context.GetMessage( "Removable", ""), 1, chkGJSComponentRemovable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentHighlightable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentHighlightable_Internalname, context.GetMessage( "Highlightable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentHighlightable_Internalname, StringUtil.BoolToStr( A540GJSComponentHighlightable), "", context.GetMessage( "Highlightable", ""), 1, chkGJSComponentHighlightable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkGJSComponentHoverable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkGJSComponentHoverable_Internalname, context.GetMessage( "Hoverable", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkGJSComponentHoverable_Internalname, StringUtil.BoolToStr( A541GJSComponentHoverable), "", context.GetMessage( "Hoverable", ""), 1, chkGJSComponentHoverable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GJSComponent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z528GJSComponentId = StringUtil.StrToGuid( cgiGet( "Z528GJSComponentId"));
            Z529GJSComponentType = cgiGet( "Z529GJSComponentType");
            Z530GJSComponentClasses = cgiGet( "Z530GJSComponentClasses");
            Z533GJSComponentAttrbutes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z533GJSComponentAttrbutes"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z535GJSComponentSelectable = StringUtil.StrToBool( cgiGet( "Z535GJSComponentSelectable"));
            Z537GJSComponentCopyable = StringUtil.StrToBool( cgiGet( "Z537GJSComponentCopyable"));
            Z538GJSComponentEditable = StringUtil.StrToBool( cgiGet( "Z538GJSComponentEditable"));
            Z539GJSComponentRemovable = StringUtil.StrToBool( cgiGet( "Z539GJSComponentRemovable"));
            Z540GJSComponentHighlightable = StringUtil.StrToBool( cgiGet( "Z540GJSComponentHighlightable"));
            Z541GJSComponentHoverable = StringUtil.StrToBool( cgiGet( "Z541GJSComponentHoverable"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtGJSComponentId_Internalname), "") == 0 )
            {
               A528GJSComponentId = Guid.Empty;
               AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
            }
            else
            {
               try
               {
                  A528GJSComponentId = StringUtil.StrToGuid( cgiGet( edtGJSComponentId_Internalname));
                  AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "GJSCOMPONENTID");
                  AnyError = 1;
                  GX_FocusControl = edtGJSComponentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A529GJSComponentType = cgiGet( edtGJSComponentType_Internalname);
            AssignAttri("", false, "A529GJSComponentType", A529GJSComponentType);
            A530GJSComponentClasses = cgiGet( edtGJSComponentClasses_Internalname);
            AssignAttri("", false, "A530GJSComponentClasses", A530GJSComponentClasses);
            A531GJSComponentContent = cgiGet( edtGJSComponentContent_Internalname);
            AssignAttri("", false, "A531GJSComponentContent", A531GJSComponentContent);
            A532GJSComponentSyle = cgiGet( edtGJSComponentSyle_Internalname);
            AssignAttri("", false, "A532GJSComponentSyle", A532GJSComponentSyle);
            if ( ( ( context.localUtil.CToN( cgiGet( edtGJSComponentAttrbutes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtGJSComponentAttrbutes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "GJSCOMPONENTATTRBUTES");
               AnyError = 1;
               GX_FocusControl = edtGJSComponentAttrbutes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A533GJSComponentAttrbutes = 0;
               AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrimStr( (decimal)(A533GJSComponentAttrbutes), 4, 0));
            }
            else
            {
               A533GJSComponentAttrbutes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtGJSComponentAttrbutes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrimStr( (decimal)(A533GJSComponentAttrbutes), 4, 0));
            }
            A534GJSComponentTraits = cgiGet( edtGJSComponentTraits_Internalname);
            AssignAttri("", false, "A534GJSComponentTraits", A534GJSComponentTraits);
            A535GJSComponentSelectable = StringUtil.StrToBool( cgiGet( chkGJSComponentSelectable_Internalname));
            AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
            A536GJSComponentDroppable = cgiGet( edtGJSComponentDroppable_Internalname);
            AssignAttri("", false, "A536GJSComponentDroppable", A536GJSComponentDroppable);
            A537GJSComponentCopyable = StringUtil.StrToBool( cgiGet( chkGJSComponentCopyable_Internalname));
            AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
            A538GJSComponentEditable = StringUtil.StrToBool( cgiGet( chkGJSComponentEditable_Internalname));
            AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
            A539GJSComponentRemovable = StringUtil.StrToBool( cgiGet( chkGJSComponentRemovable_Internalname));
            AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
            A540GJSComponentHighlightable = StringUtil.StrToBool( cgiGet( chkGJSComponentHighlightable_Internalname));
            AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
            A541GJSComponentHoverable = StringUtil.StrToBool( cgiGet( chkGJSComponentHoverable_Internalname));
            AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A528GJSComponentId = StringUtil.StrToGuid( GetPar( "GJSComponentId"));
               AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A528GJSComponentId) && ( Gx_BScreen == 0 ) )
               {
                  A528GJSComponentId = Guid.NewGuid( );
                  AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
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
               InitAll1N103( ) ;
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
         DisableAttributes1N103( ) ;
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

      protected void ResetCaption1N0( )
      {
      }

      protected void ZM1N103( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z529GJSComponentType = T001N3_A529GJSComponentType[0];
               Z530GJSComponentClasses = T001N3_A530GJSComponentClasses[0];
               Z533GJSComponentAttrbutes = T001N3_A533GJSComponentAttrbutes[0];
               Z535GJSComponentSelectable = T001N3_A535GJSComponentSelectable[0];
               Z537GJSComponentCopyable = T001N3_A537GJSComponentCopyable[0];
               Z538GJSComponentEditable = T001N3_A538GJSComponentEditable[0];
               Z539GJSComponentRemovable = T001N3_A539GJSComponentRemovable[0];
               Z540GJSComponentHighlightable = T001N3_A540GJSComponentHighlightable[0];
               Z541GJSComponentHoverable = T001N3_A541GJSComponentHoverable[0];
            }
            else
            {
               Z529GJSComponentType = A529GJSComponentType;
               Z530GJSComponentClasses = A530GJSComponentClasses;
               Z533GJSComponentAttrbutes = A533GJSComponentAttrbutes;
               Z535GJSComponentSelectable = A535GJSComponentSelectable;
               Z537GJSComponentCopyable = A537GJSComponentCopyable;
               Z538GJSComponentEditable = A538GJSComponentEditable;
               Z539GJSComponentRemovable = A539GJSComponentRemovable;
               Z540GJSComponentHighlightable = A540GJSComponentHighlightable;
               Z541GJSComponentHoverable = A541GJSComponentHoverable;
            }
         }
         if ( GX_JID == -4 )
         {
            Z528GJSComponentId = A528GJSComponentId;
            Z529GJSComponentType = A529GJSComponentType;
            Z530GJSComponentClasses = A530GJSComponentClasses;
            Z531GJSComponentContent = A531GJSComponentContent;
            Z532GJSComponentSyle = A532GJSComponentSyle;
            Z533GJSComponentAttrbutes = A533GJSComponentAttrbutes;
            Z534GJSComponentTraits = A534GJSComponentTraits;
            Z535GJSComponentSelectable = A535GJSComponentSelectable;
            Z536GJSComponentDroppable = A536GJSComponentDroppable;
            Z537GJSComponentCopyable = A537GJSComponentCopyable;
            Z538GJSComponentEditable = A538GJSComponentEditable;
            Z539GJSComponentRemovable = A539GJSComponentRemovable;
            Z540GJSComponentHighlightable = A540GJSComponentHighlightable;
            Z541GJSComponentHoverable = A541GJSComponentHoverable;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A528GJSComponentId) && ( Gx_BScreen == 0 ) )
         {
            A528GJSComponentId = Guid.NewGuid( );
            AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
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

      protected void Load1N103( )
      {
         /* Using cursor T001N4 */
         pr_default.execute(2, new Object[] {A528GJSComponentId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound103 = 1;
            A529GJSComponentType = T001N4_A529GJSComponentType[0];
            AssignAttri("", false, "A529GJSComponentType", A529GJSComponentType);
            A530GJSComponentClasses = T001N4_A530GJSComponentClasses[0];
            AssignAttri("", false, "A530GJSComponentClasses", A530GJSComponentClasses);
            A531GJSComponentContent = T001N4_A531GJSComponentContent[0];
            AssignAttri("", false, "A531GJSComponentContent", A531GJSComponentContent);
            A532GJSComponentSyle = T001N4_A532GJSComponentSyle[0];
            AssignAttri("", false, "A532GJSComponentSyle", A532GJSComponentSyle);
            A533GJSComponentAttrbutes = T001N4_A533GJSComponentAttrbutes[0];
            AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrimStr( (decimal)(A533GJSComponentAttrbutes), 4, 0));
            A534GJSComponentTraits = T001N4_A534GJSComponentTraits[0];
            AssignAttri("", false, "A534GJSComponentTraits", A534GJSComponentTraits);
            A535GJSComponentSelectable = T001N4_A535GJSComponentSelectable[0];
            AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
            A536GJSComponentDroppable = T001N4_A536GJSComponentDroppable[0];
            AssignAttri("", false, "A536GJSComponentDroppable", A536GJSComponentDroppable);
            A537GJSComponentCopyable = T001N4_A537GJSComponentCopyable[0];
            AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
            A538GJSComponentEditable = T001N4_A538GJSComponentEditable[0];
            AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
            A539GJSComponentRemovable = T001N4_A539GJSComponentRemovable[0];
            AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
            A540GJSComponentHighlightable = T001N4_A540GJSComponentHighlightable[0];
            AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
            A541GJSComponentHoverable = T001N4_A541GJSComponentHoverable[0];
            AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
            ZM1N103( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1N103( ) ;
      }

      protected void OnLoadActions1N103( )
      {
      }

      protected void CheckExtendedTable1N103( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A530GJSComponentClasses,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "GJSComponent Classes", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "GJSCOMPONENTCLASSES");
            AnyError = 1;
            GX_FocusControl = edtGJSComponentClasses_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1N103( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1N103( )
      {
         /* Using cursor T001N5 */
         pr_default.execute(3, new Object[] {A528GJSComponentId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001N3 */
         pr_default.execute(1, new Object[] {A528GJSComponentId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1N103( 4) ;
            RcdFound103 = 1;
            A528GJSComponentId = T001N3_A528GJSComponentId[0];
            AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
            A529GJSComponentType = T001N3_A529GJSComponentType[0];
            AssignAttri("", false, "A529GJSComponentType", A529GJSComponentType);
            A530GJSComponentClasses = T001N3_A530GJSComponentClasses[0];
            AssignAttri("", false, "A530GJSComponentClasses", A530GJSComponentClasses);
            A531GJSComponentContent = T001N3_A531GJSComponentContent[0];
            AssignAttri("", false, "A531GJSComponentContent", A531GJSComponentContent);
            A532GJSComponentSyle = T001N3_A532GJSComponentSyle[0];
            AssignAttri("", false, "A532GJSComponentSyle", A532GJSComponentSyle);
            A533GJSComponentAttrbutes = T001N3_A533GJSComponentAttrbutes[0];
            AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrimStr( (decimal)(A533GJSComponentAttrbutes), 4, 0));
            A534GJSComponentTraits = T001N3_A534GJSComponentTraits[0];
            AssignAttri("", false, "A534GJSComponentTraits", A534GJSComponentTraits);
            A535GJSComponentSelectable = T001N3_A535GJSComponentSelectable[0];
            AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
            A536GJSComponentDroppable = T001N3_A536GJSComponentDroppable[0];
            AssignAttri("", false, "A536GJSComponentDroppable", A536GJSComponentDroppable);
            A537GJSComponentCopyable = T001N3_A537GJSComponentCopyable[0];
            AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
            A538GJSComponentEditable = T001N3_A538GJSComponentEditable[0];
            AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
            A539GJSComponentRemovable = T001N3_A539GJSComponentRemovable[0];
            AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
            A540GJSComponentHighlightable = T001N3_A540GJSComponentHighlightable[0];
            AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
            A541GJSComponentHoverable = T001N3_A541GJSComponentHoverable[0];
            AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
            Z528GJSComponentId = A528GJSComponentId;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1N103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey1N103( ) ;
            }
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey1N103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1N103( ) ;
         if ( RcdFound103 == 0 )
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
         RcdFound103 = 0;
         /* Using cursor T001N6 */
         pr_default.execute(4, new Object[] {A528GJSComponentId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001N6_A528GJSComponentId[0], A528GJSComponentId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001N6_A528GJSComponentId[0], A528GJSComponentId, 0) > 0 ) ) )
            {
               A528GJSComponentId = T001N6_A528GJSComponentId[0];
               AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
               RcdFound103 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound103 = 0;
         /* Using cursor T001N7 */
         pr_default.execute(5, new Object[] {A528GJSComponentId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001N7_A528GJSComponentId[0], A528GJSComponentId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001N7_A528GJSComponentId[0], A528GJSComponentId, 0) < 0 ) ) )
            {
               A528GJSComponentId = T001N7_A528GJSComponentId[0];
               AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
               RcdFound103 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1N103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtGJSComponentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1N103( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A528GJSComponentId != Z528GJSComponentId )
               {
                  A528GJSComponentId = Z528GJSComponentId;
                  AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "GJSCOMPONENTID");
                  AnyError = 1;
                  GX_FocusControl = edtGJSComponentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtGJSComponentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1N103( ) ;
                  GX_FocusControl = edtGJSComponentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A528GJSComponentId != Z528GJSComponentId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtGJSComponentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1N103( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "GJSCOMPONENTID");
                     AnyError = 1;
                     GX_FocusControl = edtGJSComponentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtGJSComponentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1N103( ) ;
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
         if ( A528GJSComponentId != Z528GJSComponentId )
         {
            A528GJSComponentId = Z528GJSComponentId;
            AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "GJSCOMPONENTID");
            AnyError = 1;
            GX_FocusControl = edtGJSComponentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtGJSComponentId_Internalname;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "GJSCOMPONENTID");
            AnyError = 1;
            GX_FocusControl = edtGJSComponentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtGJSComponentType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1N103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGJSComponentType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1N103( ) ;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGJSComponentType_Internalname;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGJSComponentType_Internalname;
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
         ScanStart1N103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound103 != 0 )
            {
               ScanNext1N103( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGJSComponentType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1N103( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1N103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001N2 */
            pr_default.execute(0, new Object[] {A528GJSComponentId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_GJSComponent"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z529GJSComponentType, T001N2_A529GJSComponentType[0]) != 0 ) || ( StringUtil.StrCmp(Z530GJSComponentClasses, T001N2_A530GJSComponentClasses[0]) != 0 ) || ( Z533GJSComponentAttrbutes != T001N2_A533GJSComponentAttrbutes[0] ) || ( Z535GJSComponentSelectable != T001N2_A535GJSComponentSelectable[0] ) || ( Z537GJSComponentCopyable != T001N2_A537GJSComponentCopyable[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z538GJSComponentEditable != T001N2_A538GJSComponentEditable[0] ) || ( Z539GJSComponentRemovable != T001N2_A539GJSComponentRemovable[0] ) || ( Z540GJSComponentHighlightable != T001N2_A540GJSComponentHighlightable[0] ) || ( Z541GJSComponentHoverable != T001N2_A541GJSComponentHoverable[0] ) )
            {
               if ( StringUtil.StrCmp(Z529GJSComponentType, T001N2_A529GJSComponentType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentType");
                  GXUtil.WriteLogRaw("Old: ",Z529GJSComponentType);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A529GJSComponentType[0]);
               }
               if ( StringUtil.StrCmp(Z530GJSComponentClasses, T001N2_A530GJSComponentClasses[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentClasses");
                  GXUtil.WriteLogRaw("Old: ",Z530GJSComponentClasses);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A530GJSComponentClasses[0]);
               }
               if ( Z533GJSComponentAttrbutes != T001N2_A533GJSComponentAttrbutes[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentAttrbutes");
                  GXUtil.WriteLogRaw("Old: ",Z533GJSComponentAttrbutes);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A533GJSComponentAttrbutes[0]);
               }
               if ( Z535GJSComponentSelectable != T001N2_A535GJSComponentSelectable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentSelectable");
                  GXUtil.WriteLogRaw("Old: ",Z535GJSComponentSelectable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A535GJSComponentSelectable[0]);
               }
               if ( Z537GJSComponentCopyable != T001N2_A537GJSComponentCopyable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentCopyable");
                  GXUtil.WriteLogRaw("Old: ",Z537GJSComponentCopyable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A537GJSComponentCopyable[0]);
               }
               if ( Z538GJSComponentEditable != T001N2_A538GJSComponentEditable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentEditable");
                  GXUtil.WriteLogRaw("Old: ",Z538GJSComponentEditable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A538GJSComponentEditable[0]);
               }
               if ( Z539GJSComponentRemovable != T001N2_A539GJSComponentRemovable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentRemovable");
                  GXUtil.WriteLogRaw("Old: ",Z539GJSComponentRemovable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A539GJSComponentRemovable[0]);
               }
               if ( Z540GJSComponentHighlightable != T001N2_A540GJSComponentHighlightable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentHighlightable");
                  GXUtil.WriteLogRaw("Old: ",Z540GJSComponentHighlightable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A540GJSComponentHighlightable[0]);
               }
               if ( Z541GJSComponentHoverable != T001N2_A541GJSComponentHoverable[0] )
               {
                  GXUtil.WriteLog("trn_gjscomponent:[seudo value changed for attri]"+"GJSComponentHoverable");
                  GXUtil.WriteLogRaw("Old: ",Z541GJSComponentHoverable);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A541GJSComponentHoverable[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_GJSComponent"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1N103( )
      {
         if ( ! IsAuthorized("trn_gjscomponent_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1N103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1N103( 0) ;
            CheckOptimisticConcurrency1N103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1N103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N8 */
                     pr_default.execute(6, new Object[] {A528GJSComponentId, A529GJSComponentType, A530GJSComponentClasses, A531GJSComponentContent, A532GJSComponentSyle, A533GJSComponentAttrbutes, A534GJSComponentTraits, A535GJSComponentSelectable, A536GJSComponentDroppable, A537GJSComponentCopyable, A538GJSComponentEditable, A539GJSComponentRemovable, A540GJSComponentHighlightable, A541GJSComponentHoverable});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_GJSComponent");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption1N0( ) ;
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
               Load1N103( ) ;
            }
            EndLevel1N103( ) ;
         }
         CloseExtendedTableCursors1N103( ) ;
      }

      protected void Update1N103( )
      {
         if ( ! IsAuthorized("trn_gjscomponent_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1N103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1N103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N9 */
                     pr_default.execute(7, new Object[] {A529GJSComponentType, A530GJSComponentClasses, A531GJSComponentContent, A532GJSComponentSyle, A533GJSComponentAttrbutes, A534GJSComponentTraits, A535GJSComponentSelectable, A536GJSComponentDroppable, A537GJSComponentCopyable, A538GJSComponentEditable, A539GJSComponentRemovable, A540GJSComponentHighlightable, A541GJSComponentHoverable, A528GJSComponentId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_GJSComponent");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_GJSComponent"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1N103( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1N0( ) ;
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
            EndLevel1N103( ) ;
         }
         CloseExtendedTableCursors1N103( ) ;
      }

      protected void DeferredUpdate1N103( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_gjscomponent_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1N103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1N103( ) ;
            AfterConfirm1N103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1N103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001N10 */
                  pr_default.execute(8, new Object[] {A528GJSComponentId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_GJSComponent");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound103 == 0 )
                        {
                           InitAll1N103( ) ;
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
                        ResetCaption1N0( ) ;
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1N103( ) ;
         Gx_mode = sMode103;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1N103( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1N103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1N103( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_gjscomponent",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_gjscomponent",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1N103( )
      {
         /* Using cursor T001N11 */
         pr_default.execute(9);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound103 = 1;
            A528GJSComponentId = T001N11_A528GJSComponentId[0];
            AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1N103( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound103 = 1;
            A528GJSComponentId = T001N11_A528GJSComponentId[0];
            AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
         }
      }

      protected void ScanEnd1N103( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1N103( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1N103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1N103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1N103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1N103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1N103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1N103( )
      {
         edtGJSComponentId_Enabled = 0;
         AssignProp("", false, edtGJSComponentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentId_Enabled), 5, 0), true);
         edtGJSComponentType_Enabled = 0;
         AssignProp("", false, edtGJSComponentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentType_Enabled), 5, 0), true);
         edtGJSComponentClasses_Enabled = 0;
         AssignProp("", false, edtGJSComponentClasses_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentClasses_Enabled), 5, 0), true);
         edtGJSComponentContent_Enabled = 0;
         AssignProp("", false, edtGJSComponentContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentContent_Enabled), 5, 0), true);
         edtGJSComponentSyle_Enabled = 0;
         AssignProp("", false, edtGJSComponentSyle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentSyle_Enabled), 5, 0), true);
         edtGJSComponentAttrbutes_Enabled = 0;
         AssignProp("", false, edtGJSComponentAttrbutes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentAttrbutes_Enabled), 5, 0), true);
         edtGJSComponentTraits_Enabled = 0;
         AssignProp("", false, edtGJSComponentTraits_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentTraits_Enabled), 5, 0), true);
         chkGJSComponentSelectable.Enabled = 0;
         AssignProp("", false, chkGJSComponentSelectable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentSelectable.Enabled), 5, 0), true);
         edtGJSComponentDroppable_Enabled = 0;
         AssignProp("", false, edtGJSComponentDroppable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGJSComponentDroppable_Enabled), 5, 0), true);
         chkGJSComponentCopyable.Enabled = 0;
         AssignProp("", false, chkGJSComponentCopyable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentCopyable.Enabled), 5, 0), true);
         chkGJSComponentEditable.Enabled = 0;
         AssignProp("", false, chkGJSComponentEditable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentEditable.Enabled), 5, 0), true);
         chkGJSComponentRemovable.Enabled = 0;
         AssignProp("", false, chkGJSComponentRemovable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentRemovable.Enabled), 5, 0), true);
         chkGJSComponentHighlightable.Enabled = 0;
         AssignProp("", false, chkGJSComponentHighlightable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentHighlightable.Enabled), 5, 0), true);
         chkGJSComponentHoverable.Enabled = 0;
         AssignProp("", false, chkGJSComponentHoverable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkGJSComponentHoverable.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1N103( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1N0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_gjscomponent.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z528GJSComponentId", Z528GJSComponentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z529GJSComponentType", Z529GJSComponentType);
         GxWebStd.gx_hidden_field( context, "Z530GJSComponentClasses", Z530GJSComponentClasses);
         GxWebStd.gx_hidden_field( context, "Z533GJSComponentAttrbutes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z533GJSComponentAttrbutes), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z535GJSComponentSelectable", Z535GJSComponentSelectable);
         GxWebStd.gx_boolean_hidden_field( context, "Z537GJSComponentCopyable", Z537GJSComponentCopyable);
         GxWebStd.gx_boolean_hidden_field( context, "Z538GJSComponentEditable", Z538GJSComponentEditable);
         GxWebStd.gx_boolean_hidden_field( context, "Z539GJSComponentRemovable", Z539GJSComponentRemovable);
         GxWebStd.gx_boolean_hidden_field( context, "Z540GJSComponentHighlightable", Z540GJSComponentHighlightable);
         GxWebStd.gx_boolean_hidden_field( context, "Z541GJSComponentHoverable", Z541GJSComponentHoverable);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("trn_gjscomponent.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_GJSComponent" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_GJSComponent", "") ;
      }

      protected void InitializeNonKey1N103( )
      {
         A529GJSComponentType = "";
         AssignAttri("", false, "A529GJSComponentType", A529GJSComponentType);
         A530GJSComponentClasses = "";
         AssignAttri("", false, "A530GJSComponentClasses", A530GJSComponentClasses);
         A531GJSComponentContent = "";
         AssignAttri("", false, "A531GJSComponentContent", A531GJSComponentContent);
         A532GJSComponentSyle = "";
         AssignAttri("", false, "A532GJSComponentSyle", A532GJSComponentSyle);
         A533GJSComponentAttrbutes = 0;
         AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrimStr( (decimal)(A533GJSComponentAttrbutes), 4, 0));
         A534GJSComponentTraits = "";
         AssignAttri("", false, "A534GJSComponentTraits", A534GJSComponentTraits);
         A535GJSComponentSelectable = false;
         AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
         A536GJSComponentDroppable = "";
         AssignAttri("", false, "A536GJSComponentDroppable", A536GJSComponentDroppable);
         A537GJSComponentCopyable = false;
         AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
         A538GJSComponentEditable = false;
         AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
         A539GJSComponentRemovable = false;
         AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
         A540GJSComponentHighlightable = false;
         AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
         A541GJSComponentHoverable = false;
         AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
         Z529GJSComponentType = "";
         Z530GJSComponentClasses = "";
         Z533GJSComponentAttrbutes = 0;
         Z535GJSComponentSelectable = false;
         Z537GJSComponentCopyable = false;
         Z538GJSComponentEditable = false;
         Z539GJSComponentRemovable = false;
         Z540GJSComponentHighlightable = false;
         Z541GJSComponentHoverable = false;
      }

      protected void InitAll1N103( )
      {
         A528GJSComponentId = Guid.NewGuid( );
         AssignAttri("", false, "A528GJSComponentId", A528GJSComponentId.ToString());
         InitializeNonKey1N103( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202534106672", true, true);
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
         context.AddJavascriptSource("trn_gjscomponent.js", "?202534106672", false, true);
         /* End function include_jscripts */
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
         edtGJSComponentId_Internalname = "GJSCOMPONENTID";
         edtGJSComponentType_Internalname = "GJSCOMPONENTTYPE";
         edtGJSComponentClasses_Internalname = "GJSCOMPONENTCLASSES";
         edtGJSComponentContent_Internalname = "GJSCOMPONENTCONTENT";
         edtGJSComponentSyle_Internalname = "GJSCOMPONENTSYLE";
         edtGJSComponentAttrbutes_Internalname = "GJSCOMPONENTATTRBUTES";
         edtGJSComponentTraits_Internalname = "GJSCOMPONENTTRAITS";
         chkGJSComponentSelectable_Internalname = "GJSCOMPONENTSELECTABLE";
         edtGJSComponentDroppable_Internalname = "GJSCOMPONENTDROPPABLE";
         chkGJSComponentCopyable_Internalname = "GJSCOMPONENTCOPYABLE";
         chkGJSComponentEditable_Internalname = "GJSCOMPONENTEDITABLE";
         chkGJSComponentRemovable_Internalname = "GJSCOMPONENTREMOVABLE";
         chkGJSComponentHighlightable_Internalname = "GJSCOMPONENTHIGHLIGHTABLE";
         chkGJSComponentHoverable_Internalname = "GJSCOMPONENTHOVERABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = context.GetMessage( "Trn_GJSComponent", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkGJSComponentHoverable.Enabled = 1;
         chkGJSComponentHighlightable.Enabled = 1;
         chkGJSComponentRemovable.Enabled = 1;
         chkGJSComponentEditable.Enabled = 1;
         chkGJSComponentCopyable.Enabled = 1;
         edtGJSComponentDroppable_Enabled = 1;
         chkGJSComponentSelectable.Enabled = 1;
         edtGJSComponentTraits_Enabled = 1;
         edtGJSComponentAttrbutes_Jsonclick = "";
         edtGJSComponentAttrbutes_Enabled = 1;
         edtGJSComponentSyle_Enabled = 1;
         edtGJSComponentContent_Enabled = 1;
         edtGJSComponentClasses_Jsonclick = "";
         edtGJSComponentClasses_Enabled = 1;
         edtGJSComponentType_Jsonclick = "";
         edtGJSComponentType_Enabled = 1;
         edtGJSComponentId_Jsonclick = "";
         edtGJSComponentId_Enabled = 1;
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

      protected void init_web_controls( )
      {
         chkGJSComponentSelectable.Name = "GJSCOMPONENTSELECTABLE";
         chkGJSComponentSelectable.WebTags = "";
         chkGJSComponentSelectable.Caption = context.GetMessage( "Selectable", "");
         AssignProp("", false, chkGJSComponentSelectable_Internalname, "TitleCaption", chkGJSComponentSelectable.Caption, true);
         chkGJSComponentSelectable.CheckedValue = "false";
         A535GJSComponentSelectable = StringUtil.StrToBool( StringUtil.BoolToStr( A535GJSComponentSelectable));
         AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
         chkGJSComponentCopyable.Name = "GJSCOMPONENTCOPYABLE";
         chkGJSComponentCopyable.WebTags = "";
         chkGJSComponentCopyable.Caption = context.GetMessage( "Copyable", "");
         AssignProp("", false, chkGJSComponentCopyable_Internalname, "TitleCaption", chkGJSComponentCopyable.Caption, true);
         chkGJSComponentCopyable.CheckedValue = "false";
         A537GJSComponentCopyable = StringUtil.StrToBool( StringUtil.BoolToStr( A537GJSComponentCopyable));
         AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
         chkGJSComponentEditable.Name = "GJSCOMPONENTEDITABLE";
         chkGJSComponentEditable.WebTags = "";
         chkGJSComponentEditable.Caption = context.GetMessage( "Editable", "");
         AssignProp("", false, chkGJSComponentEditable_Internalname, "TitleCaption", chkGJSComponentEditable.Caption, true);
         chkGJSComponentEditable.CheckedValue = "false";
         A538GJSComponentEditable = StringUtil.StrToBool( StringUtil.BoolToStr( A538GJSComponentEditable));
         AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
         chkGJSComponentRemovable.Name = "GJSCOMPONENTREMOVABLE";
         chkGJSComponentRemovable.WebTags = "";
         chkGJSComponentRemovable.Caption = context.GetMessage( "Removable", "");
         AssignProp("", false, chkGJSComponentRemovable_Internalname, "TitleCaption", chkGJSComponentRemovable.Caption, true);
         chkGJSComponentRemovable.CheckedValue = "false";
         A539GJSComponentRemovable = StringUtil.StrToBool( StringUtil.BoolToStr( A539GJSComponentRemovable));
         AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
         chkGJSComponentHighlightable.Name = "GJSCOMPONENTHIGHLIGHTABLE";
         chkGJSComponentHighlightable.WebTags = "";
         chkGJSComponentHighlightable.Caption = context.GetMessage( "Highlightable", "");
         AssignProp("", false, chkGJSComponentHighlightable_Internalname, "TitleCaption", chkGJSComponentHighlightable.Caption, true);
         chkGJSComponentHighlightable.CheckedValue = "false";
         A540GJSComponentHighlightable = StringUtil.StrToBool( StringUtil.BoolToStr( A540GJSComponentHighlightable));
         AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
         chkGJSComponentHoverable.Name = "GJSCOMPONENTHOVERABLE";
         chkGJSComponentHoverable.WebTags = "";
         chkGJSComponentHoverable.Caption = context.GetMessage( "Hoverable", "");
         AssignProp("", false, chkGJSComponentHoverable_Internalname, "TitleCaption", chkGJSComponentHoverable.Caption, true);
         chkGJSComponentHoverable.CheckedValue = "false";
         A541GJSComponentHoverable = StringUtil.StrToBool( StringUtil.BoolToStr( A541GJSComponentHoverable));
         AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtGJSComponentType_Internalname;
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

      public void Valid_Gjscomponentid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A535GJSComponentSelectable = StringUtil.StrToBool( StringUtil.BoolToStr( A535GJSComponentSelectable));
         A537GJSComponentCopyable = StringUtil.StrToBool( StringUtil.BoolToStr( A537GJSComponentCopyable));
         A538GJSComponentEditable = StringUtil.StrToBool( StringUtil.BoolToStr( A538GJSComponentEditable));
         A539GJSComponentRemovable = StringUtil.StrToBool( StringUtil.BoolToStr( A539GJSComponentRemovable));
         A540GJSComponentHighlightable = StringUtil.StrToBool( StringUtil.BoolToStr( A540GJSComponentHighlightable));
         A541GJSComponentHoverable = StringUtil.StrToBool( StringUtil.BoolToStr( A541GJSComponentHoverable));
         /*  Sending validation outputs */
         AssignAttri("", false, "A529GJSComponentType", A529GJSComponentType);
         AssignAttri("", false, "A530GJSComponentClasses", A530GJSComponentClasses);
         AssignAttri("", false, "A531GJSComponentContent", A531GJSComponentContent);
         AssignAttri("", false, "A532GJSComponentSyle", A532GJSComponentSyle);
         AssignAttri("", false, "A533GJSComponentAttrbutes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A533GJSComponentAttrbutes), 4, 0, ".", "")));
         AssignAttri("", false, "A534GJSComponentTraits", A534GJSComponentTraits);
         AssignAttri("", false, "A535GJSComponentSelectable", A535GJSComponentSelectable);
         AssignAttri("", false, "A536GJSComponentDroppable", A536GJSComponentDroppable);
         AssignAttri("", false, "A537GJSComponentCopyable", A537GJSComponentCopyable);
         AssignAttri("", false, "A538GJSComponentEditable", A538GJSComponentEditable);
         AssignAttri("", false, "A539GJSComponentRemovable", A539GJSComponentRemovable);
         AssignAttri("", false, "A540GJSComponentHighlightable", A540GJSComponentHighlightable);
         AssignAttri("", false, "A541GJSComponentHoverable", A541GJSComponentHoverable);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z528GJSComponentId", Z528GJSComponentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z529GJSComponentType", Z529GJSComponentType);
         GxWebStd.gx_hidden_field( context, "Z530GJSComponentClasses", Z530GJSComponentClasses);
         GxWebStd.gx_hidden_field( context, "Z531GJSComponentContent", Z531GJSComponentContent);
         GxWebStd.gx_hidden_field( context, "Z532GJSComponentSyle", Z532GJSComponentSyle);
         GxWebStd.gx_hidden_field( context, "Z533GJSComponentAttrbutes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z533GJSComponentAttrbutes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z534GJSComponentTraits", Z534GJSComponentTraits);
         GxWebStd.gx_hidden_field( context, "Z535GJSComponentSelectable", StringUtil.BoolToStr( Z535GJSComponentSelectable));
         GxWebStd.gx_hidden_field( context, "Z536GJSComponentDroppable", Z536GJSComponentDroppable);
         GxWebStd.gx_hidden_field( context, "Z537GJSComponentCopyable", StringUtil.BoolToStr( Z537GJSComponentCopyable));
         GxWebStd.gx_hidden_field( context, "Z538GJSComponentEditable", StringUtil.BoolToStr( Z538GJSComponentEditable));
         GxWebStd.gx_hidden_field( context, "Z539GJSComponentRemovable", StringUtil.BoolToStr( Z539GJSComponentRemovable));
         GxWebStd.gx_hidden_field( context, "Z540GJSComponentHighlightable", StringUtil.BoolToStr( Z540GJSComponentHighlightable));
         GxWebStd.gx_hidden_field( context, "Z541GJSComponentHoverable", StringUtil.BoolToStr( Z541GJSComponentHoverable));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]}""");
         setEventMetadata("VALID_GJSCOMPONENTID","""{"handler":"Valid_Gjscomponentid","iparms":[{"av":"A528GJSComponentId","fld":"GJSCOMPONENTID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]""");
         setEventMetadata("VALID_GJSCOMPONENTID",""","oparms":[{"av":"A529GJSComponentType","fld":"GJSCOMPONENTTYPE"},{"av":"A530GJSComponentClasses","fld":"GJSCOMPONENTCLASSES"},{"av":"A531GJSComponentContent","fld":"GJSCOMPONENTCONTENT"},{"av":"A532GJSComponentSyle","fld":"GJSCOMPONENTSYLE"},{"av":"A533GJSComponentAttrbutes","fld":"GJSCOMPONENTATTRBUTES","pic":"ZZZ9"},{"av":"A534GJSComponentTraits","fld":"GJSCOMPONENTTRAITS"},{"av":"A536GJSComponentDroppable","fld":"GJSCOMPONENTDROPPABLE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z528GJSComponentId"},{"av":"Z529GJSComponentType"},{"av":"Z530GJSComponentClasses"},{"av":"Z531GJSComponentContent"},{"av":"Z532GJSComponentSyle"},{"av":"Z533GJSComponentAttrbutes"},{"av":"Z534GJSComponentTraits"},{"av":"Z535GJSComponentSelectable"},{"av":"Z536GJSComponentDroppable"},{"av":"Z537GJSComponentCopyable"},{"av":"Z538GJSComponentEditable"},{"av":"Z539GJSComponentRemovable"},{"av":"Z540GJSComponentHighlightable"},{"av":"Z541GJSComponentHoverable"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]}""");
         setEventMetadata("VALID_GJSCOMPONENTCLASSES","""{"handler":"Valid_Gjscomponentclasses","iparms":[{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]""");
         setEventMetadata("VALID_GJSCOMPONENTCLASSES",""","oparms":[{"av":"A535GJSComponentSelectable","fld":"GJSCOMPONENTSELECTABLE"},{"av":"A537GJSComponentCopyable","fld":"GJSCOMPONENTCOPYABLE"},{"av":"A538GJSComponentEditable","fld":"GJSCOMPONENTEDITABLE"},{"av":"A539GJSComponentRemovable","fld":"GJSCOMPONENTREMOVABLE"},{"av":"A540GJSComponentHighlightable","fld":"GJSCOMPONENTHIGHLIGHTABLE"},{"av":"A541GJSComponentHoverable","fld":"GJSCOMPONENTHOVERABLE"}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z528GJSComponentId = Guid.Empty;
         Z529GJSComponentType = "";
         Z530GJSComponentClasses = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A528GJSComponentId = Guid.Empty;
         A529GJSComponentType = "";
         A530GJSComponentClasses = "";
         A531GJSComponentContent = "";
         A532GJSComponentSyle = "";
         A534GJSComponentTraits = "";
         A536GJSComponentDroppable = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z531GJSComponentContent = "";
         Z532GJSComponentSyle = "";
         Z534GJSComponentTraits = "";
         Z536GJSComponentDroppable = "";
         T001N4_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N4_A529GJSComponentType = new string[] {""} ;
         T001N4_A530GJSComponentClasses = new string[] {""} ;
         T001N4_A531GJSComponentContent = new string[] {""} ;
         T001N4_A532GJSComponentSyle = new string[] {""} ;
         T001N4_A533GJSComponentAttrbutes = new short[1] ;
         T001N4_A534GJSComponentTraits = new string[] {""} ;
         T001N4_A535GJSComponentSelectable = new bool[] {false} ;
         T001N4_A536GJSComponentDroppable = new string[] {""} ;
         T001N4_A537GJSComponentCopyable = new bool[] {false} ;
         T001N4_A538GJSComponentEditable = new bool[] {false} ;
         T001N4_A539GJSComponentRemovable = new bool[] {false} ;
         T001N4_A540GJSComponentHighlightable = new bool[] {false} ;
         T001N4_A541GJSComponentHoverable = new bool[] {false} ;
         T001N5_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N3_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N3_A529GJSComponentType = new string[] {""} ;
         T001N3_A530GJSComponentClasses = new string[] {""} ;
         T001N3_A531GJSComponentContent = new string[] {""} ;
         T001N3_A532GJSComponentSyle = new string[] {""} ;
         T001N3_A533GJSComponentAttrbutes = new short[1] ;
         T001N3_A534GJSComponentTraits = new string[] {""} ;
         T001N3_A535GJSComponentSelectable = new bool[] {false} ;
         T001N3_A536GJSComponentDroppable = new string[] {""} ;
         T001N3_A537GJSComponentCopyable = new bool[] {false} ;
         T001N3_A538GJSComponentEditable = new bool[] {false} ;
         T001N3_A539GJSComponentRemovable = new bool[] {false} ;
         T001N3_A540GJSComponentHighlightable = new bool[] {false} ;
         T001N3_A541GJSComponentHoverable = new bool[] {false} ;
         sMode103 = "";
         T001N6_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N7_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N2_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         T001N2_A529GJSComponentType = new string[] {""} ;
         T001N2_A530GJSComponentClasses = new string[] {""} ;
         T001N2_A531GJSComponentContent = new string[] {""} ;
         T001N2_A532GJSComponentSyle = new string[] {""} ;
         T001N2_A533GJSComponentAttrbutes = new short[1] ;
         T001N2_A534GJSComponentTraits = new string[] {""} ;
         T001N2_A535GJSComponentSelectable = new bool[] {false} ;
         T001N2_A536GJSComponentDroppable = new string[] {""} ;
         T001N2_A537GJSComponentCopyable = new bool[] {false} ;
         T001N2_A538GJSComponentEditable = new bool[] {false} ;
         T001N2_A539GJSComponentRemovable = new bool[] {false} ;
         T001N2_A540GJSComponentHighlightable = new bool[] {false} ;
         T001N2_A541GJSComponentHoverable = new bool[] {false} ;
         T001N11_A528GJSComponentId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ528GJSComponentId = Guid.Empty;
         ZZ529GJSComponentType = "";
         ZZ530GJSComponentClasses = "";
         ZZ531GJSComponentContent = "";
         ZZ532GJSComponentSyle = "";
         ZZ534GJSComponentTraits = "";
         ZZ536GJSComponentDroppable = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_gjscomponent__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_gjscomponent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_gjscomponent__default(),
            new Object[][] {
                new Object[] {
               T001N2_A528GJSComponentId, T001N2_A529GJSComponentType, T001N2_A530GJSComponentClasses, T001N2_A531GJSComponentContent, T001N2_A532GJSComponentSyle, T001N2_A533GJSComponentAttrbutes, T001N2_A534GJSComponentTraits, T001N2_A535GJSComponentSelectable, T001N2_A536GJSComponentDroppable, T001N2_A537GJSComponentCopyable,
               T001N2_A538GJSComponentEditable, T001N2_A539GJSComponentRemovable, T001N2_A540GJSComponentHighlightable, T001N2_A541GJSComponentHoverable
               }
               , new Object[] {
               T001N3_A528GJSComponentId, T001N3_A529GJSComponentType, T001N3_A530GJSComponentClasses, T001N3_A531GJSComponentContent, T001N3_A532GJSComponentSyle, T001N3_A533GJSComponentAttrbutes, T001N3_A534GJSComponentTraits, T001N3_A535GJSComponentSelectable, T001N3_A536GJSComponentDroppable, T001N3_A537GJSComponentCopyable,
               T001N3_A538GJSComponentEditable, T001N3_A539GJSComponentRemovable, T001N3_A540GJSComponentHighlightable, T001N3_A541GJSComponentHoverable
               }
               , new Object[] {
               T001N4_A528GJSComponentId, T001N4_A529GJSComponentType, T001N4_A530GJSComponentClasses, T001N4_A531GJSComponentContent, T001N4_A532GJSComponentSyle, T001N4_A533GJSComponentAttrbutes, T001N4_A534GJSComponentTraits, T001N4_A535GJSComponentSelectable, T001N4_A536GJSComponentDroppable, T001N4_A537GJSComponentCopyable,
               T001N4_A538GJSComponentEditable, T001N4_A539GJSComponentRemovable, T001N4_A540GJSComponentHighlightable, T001N4_A541GJSComponentHoverable
               }
               , new Object[] {
               T001N5_A528GJSComponentId
               }
               , new Object[] {
               T001N6_A528GJSComponentId
               }
               , new Object[] {
               T001N7_A528GJSComponentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001N11_A528GJSComponentId
               }
            }
         );
         Z528GJSComponentId = Guid.NewGuid( );
         A528GJSComponentId = Guid.NewGuid( );
      }

      private short Z533GJSComponentAttrbutes ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A533GJSComponentAttrbutes ;
      private short Gx_BScreen ;
      private short RcdFound103 ;
      private short gxajaxcallmode ;
      private short ZZ533GJSComponentAttrbutes ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtGJSComponentId_Enabled ;
      private int edtGJSComponentType_Enabled ;
      private int edtGJSComponentClasses_Enabled ;
      private int edtGJSComponentContent_Enabled ;
      private int edtGJSComponentSyle_Enabled ;
      private int edtGJSComponentAttrbutes_Enabled ;
      private int edtGJSComponentTraits_Enabled ;
      private int edtGJSComponentDroppable_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtGJSComponentId_Internalname ;
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
      private string edtGJSComponentId_Jsonclick ;
      private string edtGJSComponentType_Internalname ;
      private string edtGJSComponentType_Jsonclick ;
      private string edtGJSComponentClasses_Internalname ;
      private string edtGJSComponentClasses_Jsonclick ;
      private string edtGJSComponentContent_Internalname ;
      private string edtGJSComponentSyle_Internalname ;
      private string edtGJSComponentAttrbutes_Internalname ;
      private string edtGJSComponentAttrbutes_Jsonclick ;
      private string edtGJSComponentTraits_Internalname ;
      private string chkGJSComponentSelectable_Internalname ;
      private string edtGJSComponentDroppable_Internalname ;
      private string chkGJSComponentCopyable_Internalname ;
      private string chkGJSComponentEditable_Internalname ;
      private string chkGJSComponentRemovable_Internalname ;
      private string chkGJSComponentHighlightable_Internalname ;
      private string chkGJSComponentHoverable_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode103 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z535GJSComponentSelectable ;
      private bool Z537GJSComponentCopyable ;
      private bool Z538GJSComponentEditable ;
      private bool Z539GJSComponentRemovable ;
      private bool Z540GJSComponentHighlightable ;
      private bool Z541GJSComponentHoverable ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A535GJSComponentSelectable ;
      private bool A537GJSComponentCopyable ;
      private bool A538GJSComponentEditable ;
      private bool A539GJSComponentRemovable ;
      private bool A540GJSComponentHighlightable ;
      private bool A541GJSComponentHoverable ;
      private bool Gx_longc ;
      private bool ZZ535GJSComponentSelectable ;
      private bool ZZ537GJSComponentCopyable ;
      private bool ZZ538GJSComponentEditable ;
      private bool ZZ539GJSComponentRemovable ;
      private bool ZZ540GJSComponentHighlightable ;
      private bool ZZ541GJSComponentHoverable ;
      private string A531GJSComponentContent ;
      private string A532GJSComponentSyle ;
      private string A534GJSComponentTraits ;
      private string A536GJSComponentDroppable ;
      private string Z531GJSComponentContent ;
      private string Z532GJSComponentSyle ;
      private string Z534GJSComponentTraits ;
      private string Z536GJSComponentDroppable ;
      private string ZZ531GJSComponentContent ;
      private string ZZ532GJSComponentSyle ;
      private string ZZ534GJSComponentTraits ;
      private string ZZ536GJSComponentDroppable ;
      private string Z529GJSComponentType ;
      private string Z530GJSComponentClasses ;
      private string A529GJSComponentType ;
      private string A530GJSComponentClasses ;
      private string ZZ529GJSComponentType ;
      private string ZZ530GJSComponentClasses ;
      private Guid Z528GJSComponentId ;
      private Guid A528GJSComponentId ;
      private Guid ZZ528GJSComponentId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkGJSComponentSelectable ;
      private GXCheckbox chkGJSComponentCopyable ;
      private GXCheckbox chkGJSComponentEditable ;
      private GXCheckbox chkGJSComponentRemovable ;
      private GXCheckbox chkGJSComponentHighlightable ;
      private GXCheckbox chkGJSComponentHoverable ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001N4_A528GJSComponentId ;
      private string[] T001N4_A529GJSComponentType ;
      private string[] T001N4_A530GJSComponentClasses ;
      private string[] T001N4_A531GJSComponentContent ;
      private string[] T001N4_A532GJSComponentSyle ;
      private short[] T001N4_A533GJSComponentAttrbutes ;
      private string[] T001N4_A534GJSComponentTraits ;
      private bool[] T001N4_A535GJSComponentSelectable ;
      private string[] T001N4_A536GJSComponentDroppable ;
      private bool[] T001N4_A537GJSComponentCopyable ;
      private bool[] T001N4_A538GJSComponentEditable ;
      private bool[] T001N4_A539GJSComponentRemovable ;
      private bool[] T001N4_A540GJSComponentHighlightable ;
      private bool[] T001N4_A541GJSComponentHoverable ;
      private Guid[] T001N5_A528GJSComponentId ;
      private Guid[] T001N3_A528GJSComponentId ;
      private string[] T001N3_A529GJSComponentType ;
      private string[] T001N3_A530GJSComponentClasses ;
      private string[] T001N3_A531GJSComponentContent ;
      private string[] T001N3_A532GJSComponentSyle ;
      private short[] T001N3_A533GJSComponentAttrbutes ;
      private string[] T001N3_A534GJSComponentTraits ;
      private bool[] T001N3_A535GJSComponentSelectable ;
      private string[] T001N3_A536GJSComponentDroppable ;
      private bool[] T001N3_A537GJSComponentCopyable ;
      private bool[] T001N3_A538GJSComponentEditable ;
      private bool[] T001N3_A539GJSComponentRemovable ;
      private bool[] T001N3_A540GJSComponentHighlightable ;
      private bool[] T001N3_A541GJSComponentHoverable ;
      private Guid[] T001N6_A528GJSComponentId ;
      private Guid[] T001N7_A528GJSComponentId ;
      private Guid[] T001N2_A528GJSComponentId ;
      private string[] T001N2_A529GJSComponentType ;
      private string[] T001N2_A530GJSComponentClasses ;
      private string[] T001N2_A531GJSComponentContent ;
      private string[] T001N2_A532GJSComponentSyle ;
      private short[] T001N2_A533GJSComponentAttrbutes ;
      private string[] T001N2_A534GJSComponentTraits ;
      private bool[] T001N2_A535GJSComponentSelectable ;
      private string[] T001N2_A536GJSComponentDroppable ;
      private bool[] T001N2_A537GJSComponentCopyable ;
      private bool[] T001N2_A538GJSComponentEditable ;
      private bool[] T001N2_A539GJSComponentRemovable ;
      private bool[] T001N2_A540GJSComponentHighlightable ;
      private bool[] T001N2_A541GJSComponentHoverable ;
      private Guid[] T001N11_A528GJSComponentId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_gjscomponent__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_gjscomponent__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_gjscomponent__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001N2;
       prmT001N2 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N3;
       prmT001N3 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N4;
       prmT001N4 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N5;
       prmT001N5 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N6;
       prmT001N6 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N7;
       prmT001N7 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N8;
       prmT001N8 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("GJSComponentType",GXType.VarChar,40,0) ,
       new ParDef("GJSComponentClasses",GXType.VarChar,1000,0) ,
       new ParDef("GJSComponentContent",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentSyle",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentAttrbutes",GXType.Int16,4,0) ,
       new ParDef("GJSComponentTraits",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentSelectable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentDroppable",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentCopyable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentEditable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentRemovable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentHighlightable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentHoverable",GXType.Boolean,4,0)
       };
       Object[] prmT001N9;
       prmT001N9 = new Object[] {
       new ParDef("GJSComponentType",GXType.VarChar,40,0) ,
       new ParDef("GJSComponentClasses",GXType.VarChar,1000,0) ,
       new ParDef("GJSComponentContent",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentSyle",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentAttrbutes",GXType.Int16,4,0) ,
       new ParDef("GJSComponentTraits",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentSelectable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentDroppable",GXType.LongVarChar,2097152,0) ,
       new ParDef("GJSComponentCopyable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentEditable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentRemovable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentHighlightable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentHoverable",GXType.Boolean,4,0) ,
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N10;
       prmT001N10 = new Object[] {
       new ParDef("GJSComponentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001N11;
       prmT001N11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001N2", "SELECT GJSComponentId, GJSComponentType, GJSComponentClasses, GJSComponentContent, GJSComponentSyle, GJSComponentAttrbutes, GJSComponentTraits, GJSComponentSelectable, GJSComponentDroppable, GJSComponentCopyable, GJSComponentEditable, GJSComponentRemovable, GJSComponentHighlightable, GJSComponentHoverable FROM Trn_GJSComponent WHERE GJSComponentId = :GJSComponentId  FOR UPDATE OF Trn_GJSComponent NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001N2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001N3", "SELECT GJSComponentId, GJSComponentType, GJSComponentClasses, GJSComponentContent, GJSComponentSyle, GJSComponentAttrbutes, GJSComponentTraits, GJSComponentSelectable, GJSComponentDroppable, GJSComponentCopyable, GJSComponentEditable, GJSComponentRemovable, GJSComponentHighlightable, GJSComponentHoverable FROM Trn_GJSComponent WHERE GJSComponentId = :GJSComponentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001N4", "SELECT TM1.GJSComponentId, TM1.GJSComponentType, TM1.GJSComponentClasses, TM1.GJSComponentContent, TM1.GJSComponentSyle, TM1.GJSComponentAttrbutes, TM1.GJSComponentTraits, TM1.GJSComponentSelectable, TM1.GJSComponentDroppable, TM1.GJSComponentCopyable, TM1.GJSComponentEditable, TM1.GJSComponentRemovable, TM1.GJSComponentHighlightable, TM1.GJSComponentHoverable FROM Trn_GJSComponent TM1 WHERE TM1.GJSComponentId = :GJSComponentId ORDER BY TM1.GJSComponentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001N5", "SELECT GJSComponentId FROM Trn_GJSComponent WHERE GJSComponentId = :GJSComponentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001N6", "SELECT GJSComponentId FROM Trn_GJSComponent WHERE ( GJSComponentId > :GJSComponentId) ORDER BY GJSComponentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001N7", "SELECT GJSComponentId FROM Trn_GJSComponent WHERE ( GJSComponentId < :GJSComponentId) ORDER BY GJSComponentId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001N8", "SAVEPOINT gxupdate;INSERT INTO Trn_GJSComponent(GJSComponentId, GJSComponentType, GJSComponentClasses, GJSComponentContent, GJSComponentSyle, GJSComponentAttrbutes, GJSComponentTraits, GJSComponentSelectable, GJSComponentDroppable, GJSComponentCopyable, GJSComponentEditable, GJSComponentRemovable, GJSComponentHighlightable, GJSComponentHoverable) VALUES(:GJSComponentId, :GJSComponentType, :GJSComponentClasses, :GJSComponentContent, :GJSComponentSyle, :GJSComponentAttrbutes, :GJSComponentTraits, :GJSComponentSelectable, :GJSComponentDroppable, :GJSComponentCopyable, :GJSComponentEditable, :GJSComponentRemovable, :GJSComponentHighlightable, :GJSComponentHoverable);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001N8)
          ,new CursorDef("T001N9", "SAVEPOINT gxupdate;UPDATE Trn_GJSComponent SET GJSComponentType=:GJSComponentType, GJSComponentClasses=:GJSComponentClasses, GJSComponentContent=:GJSComponentContent, GJSComponentSyle=:GJSComponentSyle, GJSComponentAttrbutes=:GJSComponentAttrbutes, GJSComponentTraits=:GJSComponentTraits, GJSComponentSelectable=:GJSComponentSelectable, GJSComponentDroppable=:GJSComponentDroppable, GJSComponentCopyable=:GJSComponentCopyable, GJSComponentEditable=:GJSComponentEditable, GJSComponentRemovable=:GJSComponentRemovable, GJSComponentHighlightable=:GJSComponentHighlightable, GJSComponentHoverable=:GJSComponentHoverable  WHERE GJSComponentId = :GJSComponentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001N9)
          ,new CursorDef("T001N10", "SAVEPOINT gxupdate;DELETE FROM Trn_GJSComponent  WHERE GJSComponentId = :GJSComponentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001N10)
          ,new CursorDef("T001N11", "SELECT GJSComponentId FROM Trn_GJSComponent ORDER BY GJSComponentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
