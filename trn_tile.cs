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
   public class trn_tile : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Tile", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_tile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tile( IGxContext context )
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
         cmbTileTextAlignment = new GXCombobox();
         cmbTileIconAlignment = new GXCombobox();
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
            return "trn_tile_Execute" ;
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
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
            AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", cmbTileTextAlignment.ToJavascriptSource(), true);
         }
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
            AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", cmbTileIconAlignment.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Tile", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileId_Internalname, A407TileId.ToString(), A407TileId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileText_Internalname, context.GetMessage( "Text", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileText_Internalname, A515TileText, StringUtil.RTrim( context.localUtil.Format( A515TileText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileText_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTileTextAlignment_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTileTextAlignment_Internalname, context.GetMessage( "Text Alignment", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileTextAlignment, cmbTileTextAlignment_Internalname, StringUtil.RTrim( A405TileTextAlignment), 1, cmbTileTextAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileTextAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
         AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", (string)(cmbTileTextAlignment.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileTextColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileTextColor_Internalname, context.GetMessage( "Text Color", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileTextColor_Internalname, StringUtil.RTrim( A404TileTextColor), StringUtil.RTrim( context.localUtil.Format( A404TileTextColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileTextColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileTextColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileBGColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileBGColor_Internalname, context.GetMessage( "BGColor", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGColor_Internalname, StringUtil.RTrim( A402TileBGColor), StringUtil.RTrim( context.localUtil.Format( A402TileBGColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileBGColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileBGImageUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileBGImageUrl_Internalname, context.GetMessage( "BGImage Url", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGImageUrl_Internalname, A403TileBGImageUrl, StringUtil.RTrim( context.localUtil.Format( A403TileBGImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", A403TileBGImageUrl, "_blank", "", "", edtTileBGImageUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGImageUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileOpacity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileOpacity_Internalname, context.GetMessage( "Opacity", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileOpacity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A516TileOpacity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTileOpacity_Enabled!=0) ? context.localUtil.Format( (decimal)(A516TileOpacity), "ZZZ9") : context.localUtil.Format( (decimal)(A516TileOpacity), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileOpacity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileOpacity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileIcon_Internalname, context.GetMessage( "Icon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileIcon_Internalname, StringUtil.RTrim( A401TileIcon), StringUtil.RTrim( context.localUtil.Format( A401TileIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileIcon_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTileIconAlignment_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTileIconAlignment_Internalname, context.GetMessage( "Icon Alignment", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileIconAlignment, cmbTileIconAlignment_Internalname, StringUtil.RTrim( A406TileIconAlignment), 1, cmbTileIconAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileIconAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", (string)(cmbTileIconAlignment.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileIconColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileIconColor_Internalname, context.GetMessage( "Icon Color", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileIconColor_Internalname, StringUtil.RTrim( A438TileIconColor), StringUtil.RTrim( context.localUtil.Format( A438TileIconColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileIconColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileIconColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
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
            Z407TileId = StringUtil.StrToGuid( cgiGet( "Z407TileId"));
            Z515TileText = cgiGet( "Z515TileText");
            Z405TileTextAlignment = cgiGet( "Z405TileTextAlignment");
            Z404TileTextColor = cgiGet( "Z404TileTextColor");
            Z402TileBGColor = cgiGet( "Z402TileBGColor");
            Z403TileBGImageUrl = cgiGet( "Z403TileBGImageUrl");
            Z516TileOpacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z516TileOpacity"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z401TileIcon = cgiGet( "Z401TileIcon");
            Z406TileIconAlignment = cgiGet( "Z406TileIconAlignment");
            Z438TileIconColor = cgiGet( "Z438TileIconColor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtTileId_Internalname), "") == 0 )
            {
               A407TileId = Guid.Empty;
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
            }
            else
            {
               try
               {
                  A407TileId = StringUtil.StrToGuid( cgiGet( edtTileId_Internalname));
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TILEID");
                  AnyError = 1;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A515TileText = cgiGet( edtTileText_Internalname);
            AssignAttri("", false, "A515TileText", A515TileText);
            cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
            A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A404TileTextColor = cgiGet( edtTileTextColor_Internalname);
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A402TileBGColor = cgiGet( edtTileBGColor_Internalname);
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = cgiGet( edtTileBGImageUrl_Internalname);
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTileOpacity_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTileOpacity_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TILEOPACITY");
               AnyError = 1;
               GX_FocusControl = edtTileOpacity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A516TileOpacity = 0;
               AssignAttri("", false, "A516TileOpacity", StringUtil.LTrimStr( (decimal)(A516TileOpacity), 4, 0));
            }
            else
            {
               A516TileOpacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTileOpacity_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A516TileOpacity", StringUtil.LTrimStr( (decimal)(A516TileOpacity), 4, 0));
            }
            A401TileIcon = cgiGet( edtTileIcon_Internalname);
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
            A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A438TileIconColor = cgiGet( edtTileIconColor_Internalname);
            AssignAttri("", false, "A438TileIconColor", A438TileIconColor);
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
               A407TileId = StringUtil.StrToGuid( GetPar( "TileId"));
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A407TileId) && ( Gx_BScreen == 0 ) )
               {
                  A407TileId = Guid.NewGuid( );
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
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
               InitAll1L99( ) ;
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
         DisableAttributes1L99( ) ;
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

      protected void ResetCaption1L0( )
      {
      }

      protected void ZM1L99( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z515TileText = T001L3_A515TileText[0];
               Z405TileTextAlignment = T001L3_A405TileTextAlignment[0];
               Z404TileTextColor = T001L3_A404TileTextColor[0];
               Z402TileBGColor = T001L3_A402TileBGColor[0];
               Z403TileBGImageUrl = T001L3_A403TileBGImageUrl[0];
               Z516TileOpacity = T001L3_A516TileOpacity[0];
               Z401TileIcon = T001L3_A401TileIcon[0];
               Z406TileIconAlignment = T001L3_A406TileIconAlignment[0];
               Z438TileIconColor = T001L3_A438TileIconColor[0];
            }
            else
            {
               Z515TileText = A515TileText;
               Z405TileTextAlignment = A405TileTextAlignment;
               Z404TileTextColor = A404TileTextColor;
               Z402TileBGColor = A402TileBGColor;
               Z403TileBGImageUrl = A403TileBGImageUrl;
               Z516TileOpacity = A516TileOpacity;
               Z401TileIcon = A401TileIcon;
               Z406TileIconAlignment = A406TileIconAlignment;
               Z438TileIconColor = A438TileIconColor;
            }
         }
         if ( GX_JID == -6 )
         {
            Z407TileId = A407TileId;
            Z515TileText = A515TileText;
            Z405TileTextAlignment = A405TileTextAlignment;
            Z404TileTextColor = A404TileTextColor;
            Z402TileBGColor = A402TileBGColor;
            Z403TileBGImageUrl = A403TileBGImageUrl;
            Z516TileOpacity = A516TileOpacity;
            Z401TileIcon = A401TileIcon;
            Z406TileIconAlignment = A406TileIconAlignment;
            Z438TileIconColor = A438TileIconColor;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A407TileId) && ( Gx_BScreen == 0 ) )
         {
            A407TileId = Guid.NewGuid( );
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
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

      protected void Load1L99( )
      {
         /* Using cursor T001L4 */
         pr_default.execute(2, new Object[] {A407TileId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound99 = 1;
            A515TileText = T001L4_A515TileText[0];
            AssignAttri("", false, "A515TileText", A515TileText);
            A405TileTextAlignment = T001L4_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A404TileTextColor = T001L4_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A402TileBGColor = T001L4_A402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T001L4_A403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A516TileOpacity = T001L4_A516TileOpacity[0];
            AssignAttri("", false, "A516TileOpacity", StringUtil.LTrimStr( (decimal)(A516TileOpacity), 4, 0));
            A401TileIcon = T001L4_A401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A406TileIconAlignment = T001L4_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A438TileIconColor = T001L4_A438TileIconColor[0];
            AssignAttri("", false, "A438TileIconColor", A438TileIconColor);
            ZM1L99( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1L99( ) ;
      }

      protected void OnLoadActions1L99( )
      {
      }

      protected void CheckExtendedTable1L99( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Text Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILETEXTALIGNMENT");
            AnyError = 1;
            GX_FocusControl = cmbTileTextAlignment_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A403TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Tile BGImage Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILEBGIMAGEURL");
            AnyError = 1;
            GX_FocusControl = edtTileBGImageUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Icon Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILEICONALIGNMENT");
            AnyError = 1;
            GX_FocusControl = cmbTileIconAlignment_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1L99( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1L99( )
      {
         /* Using cursor T001L5 */
         pr_default.execute(3, new Object[] {A407TileId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound99 = 1;
         }
         else
         {
            RcdFound99 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001L3 */
         pr_default.execute(1, new Object[] {A407TileId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L99( 6) ;
            RcdFound99 = 1;
            A407TileId = T001L3_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            A515TileText = T001L3_A515TileText[0];
            AssignAttri("", false, "A515TileText", A515TileText);
            A405TileTextAlignment = T001L3_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A404TileTextColor = T001L3_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A402TileBGColor = T001L3_A402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T001L3_A403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A516TileOpacity = T001L3_A516TileOpacity[0];
            AssignAttri("", false, "A516TileOpacity", StringUtil.LTrimStr( (decimal)(A516TileOpacity), 4, 0));
            A401TileIcon = T001L3_A401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A406TileIconAlignment = T001L3_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A438TileIconColor = T001L3_A438TileIconColor[0];
            AssignAttri("", false, "A438TileIconColor", A438TileIconColor);
            Z407TileId = A407TileId;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1L99( ) ;
            if ( AnyError == 1 )
            {
               RcdFound99 = 0;
               InitializeNonKey1L99( ) ;
            }
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound99 = 0;
            InitializeNonKey1L99( ) ;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L99( ) ;
         if ( RcdFound99 == 0 )
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
         RcdFound99 = 0;
         /* Using cursor T001L6 */
         pr_default.execute(4, new Object[] {A407TileId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001L6_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001L6_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               A407TileId = T001L6_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound99 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound99 = 0;
         /* Using cursor T001L7 */
         pr_default.execute(5, new Object[] {A407TileId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001L7_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001L7_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               A407TileId = T001L7_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound99 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1L99( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1L99( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound99 == 1 )
            {
               if ( A407TileId != Z407TileId )
               {
                  A407TileId = Z407TileId;
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TILEID");
                  AnyError = 1;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1L99( ) ;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A407TileId != Z407TileId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1L99( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TILEID");
                     AnyError = 1;
                     GX_FocusControl = edtTileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1L99( ) ;
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
         if ( A407TileId != Z407TileId )
         {
            A407TileId = Z407TileId;
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TILEID");
            AnyError = 1;
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTileId_Internalname;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TILEID");
            AnyError = 1;
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTileText_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1L99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTileText_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L99( ) ;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTileText_Internalname;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTileText_Internalname;
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
         ScanStart1L99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound99 != 0 )
            {
               ScanNext1L99( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTileText_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L99( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1L99( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L2 */
            pr_default.execute(0, new Object[] {A407TileId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z515TileText, T001L2_A515TileText[0]) != 0 ) || ( StringUtil.StrCmp(Z405TileTextAlignment, T001L2_A405TileTextAlignment[0]) != 0 ) || ( StringUtil.StrCmp(Z404TileTextColor, T001L2_A404TileTextColor[0]) != 0 ) || ( StringUtil.StrCmp(Z402TileBGColor, T001L2_A402TileBGColor[0]) != 0 ) || ( StringUtil.StrCmp(Z403TileBGImageUrl, T001L2_A403TileBGImageUrl[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z516TileOpacity != T001L2_A516TileOpacity[0] ) || ( StringUtil.StrCmp(Z401TileIcon, T001L2_A401TileIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z406TileIconAlignment, T001L2_A406TileIconAlignment[0]) != 0 ) || ( StringUtil.StrCmp(Z438TileIconColor, T001L2_A438TileIconColor[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z515TileText, T001L2_A515TileText[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileText");
                  GXUtil.WriteLogRaw("Old: ",Z515TileText);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A515TileText[0]);
               }
               if ( StringUtil.StrCmp(Z405TileTextAlignment, T001L2_A405TileTextAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z405TileTextAlignment);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A405TileTextAlignment[0]);
               }
               if ( StringUtil.StrCmp(Z404TileTextColor, T001L2_A404TileTextColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextColor");
                  GXUtil.WriteLogRaw("Old: ",Z404TileTextColor);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A404TileTextColor[0]);
               }
               if ( StringUtil.StrCmp(Z402TileBGColor, T001L2_A402TileBGColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGColor");
                  GXUtil.WriteLogRaw("Old: ",Z402TileBGColor);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A402TileBGColor[0]);
               }
               if ( StringUtil.StrCmp(Z403TileBGImageUrl, T001L2_A403TileBGImageUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGImageUrl");
                  GXUtil.WriteLogRaw("Old: ",Z403TileBGImageUrl);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A403TileBGImageUrl[0]);
               }
               if ( Z516TileOpacity != T001L2_A516TileOpacity[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileOpacity");
                  GXUtil.WriteLogRaw("Old: ",Z516TileOpacity);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A516TileOpacity[0]);
               }
               if ( StringUtil.StrCmp(Z401TileIcon, T001L2_A401TileIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIcon");
                  GXUtil.WriteLogRaw("Old: ",Z401TileIcon);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A401TileIcon[0]);
               }
               if ( StringUtil.StrCmp(Z406TileIconAlignment, T001L2_A406TileIconAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIconAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z406TileIconAlignment);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A406TileIconAlignment[0]);
               }
               if ( StringUtil.StrCmp(Z438TileIconColor, T001L2_A438TileIconColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIconColor");
                  GXUtil.WriteLogRaw("Old: ",Z438TileIconColor);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A438TileIconColor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Tile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L99( )
      {
         if ( ! IsAuthorized("trn_tile_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L99( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L99( 0) ;
            CheckOptimisticConcurrency1L99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L8 */
                     pr_default.execute(6, new Object[] {A407TileId, A515TileText, A405TileTextAlignment, A404TileTextColor, A402TileBGColor, A403TileBGImageUrl, A516TileOpacity, A401TileIcon, A406TileIconAlignment, A438TileIconColor});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
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
                           ResetCaption1L0( ) ;
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
               Load1L99( ) ;
            }
            EndLevel1L99( ) ;
         }
         CloseExtendedTableCursors1L99( ) ;
      }

      protected void Update1L99( )
      {
         if ( ! IsAuthorized("trn_tile_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L99( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L9 */
                     pr_default.execute(7, new Object[] {A515TileText, A405TileTextAlignment, A404TileTextColor, A402TileBGColor, A403TileBGImageUrl, A516TileOpacity, A401TileIcon, A406TileIconAlignment, A438TileIconColor, A407TileId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L99( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1L0( ) ;
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
            EndLevel1L99( ) ;
         }
         CloseExtendedTableCursors1L99( ) ;
      }

      protected void DeferredUpdate1L99( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_tile_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1L99( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L99( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L99( ) ;
            AfterConfirm1L99( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L99( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001L10 */
                  pr_default.execute(8, new Object[] {A407TileId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound99 == 0 )
                        {
                           InitAll1L99( ) ;
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
                        ResetCaption1L0( ) ;
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
         sMode99 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L99( ) ;
         Gx_mode = sMode99;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L99( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1L99( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L99( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_tile",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_tile",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L99( )
      {
         /* Using cursor T001L11 */
         pr_default.execute(9);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound99 = 1;
            A407TileId = T001L11_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L99( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound99 = 1;
            A407TileId = T001L11_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
      }

      protected void ScanEnd1L99( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1L99( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L99( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L99( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L99( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L99( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L99( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L99( )
      {
         edtTileId_Enabled = 0;
         AssignProp("", false, edtTileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileId_Enabled), 5, 0), true);
         edtTileText_Enabled = 0;
         AssignProp("", false, edtTileText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileText_Enabled), 5, 0), true);
         cmbTileTextAlignment.Enabled = 0;
         AssignProp("", false, cmbTileTextAlignment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTileTextAlignment.Enabled), 5, 0), true);
         edtTileTextColor_Enabled = 0;
         AssignProp("", false, edtTileTextColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileTextColor_Enabled), 5, 0), true);
         edtTileBGColor_Enabled = 0;
         AssignProp("", false, edtTileBGColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileBGColor_Enabled), 5, 0), true);
         edtTileBGImageUrl_Enabled = 0;
         AssignProp("", false, edtTileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileBGImageUrl_Enabled), 5, 0), true);
         edtTileOpacity_Enabled = 0;
         AssignProp("", false, edtTileOpacity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileOpacity_Enabled), 5, 0), true);
         edtTileIcon_Enabled = 0;
         AssignProp("", false, edtTileIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileIcon_Enabled), 5, 0), true);
         cmbTileIconAlignment.Enabled = 0;
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTileIconAlignment.Enabled), 5, 0), true);
         edtTileIconColor_Enabled = 0;
         AssignProp("", false, edtTileIconColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileIconColor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1L99( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1L0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_tile.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z407TileId", Z407TileId.ToString());
         GxWebStd.gx_hidden_field( context, "Z515TileText", Z515TileText);
         GxWebStd.gx_hidden_field( context, "Z405TileTextAlignment", StringUtil.RTrim( Z405TileTextAlignment));
         GxWebStd.gx_hidden_field( context, "Z404TileTextColor", StringUtil.RTrim( Z404TileTextColor));
         GxWebStd.gx_hidden_field( context, "Z402TileBGColor", StringUtil.RTrim( Z402TileBGColor));
         GxWebStd.gx_hidden_field( context, "Z403TileBGImageUrl", Z403TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z516TileOpacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z516TileOpacity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z401TileIcon", StringUtil.RTrim( Z401TileIcon));
         GxWebStd.gx_hidden_field( context, "Z406TileIconAlignment", StringUtil.RTrim( Z406TileIconAlignment));
         GxWebStd.gx_hidden_field( context, "Z438TileIconColor", StringUtil.RTrim( Z438TileIconColor));
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
         return formatLink("trn_tile.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Tile" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Tile", "") ;
      }

      protected void InitializeNonKey1L99( )
      {
         A515TileText = "";
         AssignAttri("", false, "A515TileText", A515TileText);
         A405TileTextAlignment = "";
         AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         A404TileTextColor = "";
         AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
         A402TileBGColor = "";
         AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
         A403TileBGImageUrl = "";
         AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
         A516TileOpacity = 0;
         AssignAttri("", false, "A516TileOpacity", StringUtil.LTrimStr( (decimal)(A516TileOpacity), 4, 0));
         A401TileIcon = "";
         AssignAttri("", false, "A401TileIcon", A401TileIcon);
         A406TileIconAlignment = "";
         AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
         A438TileIconColor = "";
         AssignAttri("", false, "A438TileIconColor", A438TileIconColor);
         Z515TileText = "";
         Z405TileTextAlignment = "";
         Z404TileTextColor = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z516TileOpacity = 0;
         Z401TileIcon = "";
         Z406TileIconAlignment = "";
         Z438TileIconColor = "";
      }

      protected void InitAll1L99( )
      {
         A407TileId = Guid.NewGuid( );
         AssignAttri("", false, "A407TileId", A407TileId.ToString());
         InitializeNonKey1L99( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20252141615869", true, true);
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
         context.AddJavascriptSource("trn_tile.js", "?20252141615869", false, true);
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
         edtTileId_Internalname = "TILEID";
         edtTileText_Internalname = "TILETEXT";
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT";
         edtTileTextColor_Internalname = "TILETEXTCOLOR";
         edtTileBGColor_Internalname = "TILEBGCOLOR";
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL";
         edtTileOpacity_Internalname = "TILEOPACITY";
         edtTileIcon_Internalname = "TILEICON";
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT";
         edtTileIconColor_Internalname = "TILEICONCOLOR";
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
         Form.Caption = context.GetMessage( "Trn_Tile", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTileIconColor_Jsonclick = "";
         edtTileIconColor_Enabled = 1;
         cmbTileIconAlignment_Jsonclick = "";
         cmbTileIconAlignment.Enabled = 1;
         edtTileIcon_Jsonclick = "";
         edtTileIcon_Enabled = 1;
         edtTileOpacity_Jsonclick = "";
         edtTileOpacity_Enabled = 1;
         edtTileBGImageUrl_Jsonclick = "";
         edtTileBGImageUrl_Enabled = 1;
         edtTileBGColor_Jsonclick = "";
         edtTileBGColor_Enabled = 1;
         edtTileTextColor_Jsonclick = "";
         edtTileTextColor_Enabled = 1;
         cmbTileTextAlignment_Jsonclick = "";
         cmbTileTextAlignment.Enabled = 1;
         edtTileText_Jsonclick = "";
         edtTileText_Enabled = 1;
         edtTileId_Jsonclick = "";
         edtTileId_Enabled = 1;
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
         cmbTileTextAlignment.Name = "TILETEXTALIGNMENT";
         cmbTileTextAlignment.WebTags = "";
         cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         }
         cmbTileIconAlignment.Name = "TILEICONALIGNMENT";
         cmbTileIconAlignment.WebTags = "";
         cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTileText_Internalname;
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

      public void Valid_Tileid( )
      {
         A406TileIconAlignment = cmbTileIconAlignment.CurrentValue;
         cmbTileIconAlignment.CurrentValue = A406TileIconAlignment;
         A405TileTextAlignment = cmbTileTextAlignment.CurrentValue;
         cmbTileTextAlignment.CurrentValue = A405TileTextAlignment;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
            cmbTileTextAlignment.CurrentValue = A405TileTextAlignment;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
         }
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
            cmbTileIconAlignment.CurrentValue = A406TileIconAlignment;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A515TileText", A515TileText);
         AssignAttri("", false, "A405TileTextAlignment", StringUtil.RTrim( A405TileTextAlignment));
         cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
         AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", cmbTileTextAlignment.ToJavascriptSource(), true);
         AssignAttri("", false, "A404TileTextColor", StringUtil.RTrim( A404TileTextColor));
         AssignAttri("", false, "A402TileBGColor", StringUtil.RTrim( A402TileBGColor));
         AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
         AssignAttri("", false, "A516TileOpacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A516TileOpacity), 4, 0, ".", "")));
         AssignAttri("", false, "A401TileIcon", StringUtil.RTrim( A401TileIcon));
         AssignAttri("", false, "A406TileIconAlignment", StringUtil.RTrim( A406TileIconAlignment));
         cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", cmbTileIconAlignment.ToJavascriptSource(), true);
         AssignAttri("", false, "A438TileIconColor", StringUtil.RTrim( A438TileIconColor));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z407TileId", Z407TileId.ToString());
         GxWebStd.gx_hidden_field( context, "Z515TileText", Z515TileText);
         GxWebStd.gx_hidden_field( context, "Z405TileTextAlignment", StringUtil.RTrim( Z405TileTextAlignment));
         GxWebStd.gx_hidden_field( context, "Z404TileTextColor", StringUtil.RTrim( Z404TileTextColor));
         GxWebStd.gx_hidden_field( context, "Z402TileBGColor", StringUtil.RTrim( Z402TileBGColor));
         GxWebStd.gx_hidden_field( context, "Z403TileBGImageUrl", Z403TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z516TileOpacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z516TileOpacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z401TileIcon", StringUtil.RTrim( Z401TileIcon));
         GxWebStd.gx_hidden_field( context, "Z406TileIconAlignment", StringUtil.RTrim( Z406TileIconAlignment));
         GxWebStd.gx_hidden_field( context, "Z438TileIconColor", StringUtil.RTrim( Z438TileIconColor));
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
         setEventMetadata("VALID_TILEID","""{"handler":"Valid_Tileid","iparms":[{"av":"cmbTileIconAlignment"},{"av":"A406TileIconAlignment","fld":"TILEICONALIGNMENT"},{"av":"cmbTileTextAlignment"},{"av":"A405TileTextAlignment","fld":"TILETEXTALIGNMENT"},{"av":"A407TileId","fld":"TILEID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_TILEID",""","oparms":[{"av":"A515TileText","fld":"TILETEXT"},{"av":"cmbTileTextAlignment"},{"av":"A405TileTextAlignment","fld":"TILETEXTALIGNMENT"},{"av":"A404TileTextColor","fld":"TILETEXTCOLOR"},{"av":"A402TileBGColor","fld":"TILEBGCOLOR"},{"av":"A403TileBGImageUrl","fld":"TILEBGIMAGEURL"},{"av":"A516TileOpacity","fld":"TILEOPACITY","pic":"ZZZ9"},{"av":"A401TileIcon","fld":"TILEICON"},{"av":"cmbTileIconAlignment"},{"av":"A406TileIconAlignment","fld":"TILEICONALIGNMENT"},{"av":"A438TileIconColor","fld":"TILEICONCOLOR"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z407TileId"},{"av":"Z515TileText"},{"av":"Z405TileTextAlignment"},{"av":"Z404TileTextColor"},{"av":"Z402TileBGColor"},{"av":"Z403TileBGImageUrl"},{"av":"Z516TileOpacity"},{"av":"Z401TileIcon"},{"av":"Z406TileIconAlignment"},{"av":"Z438TileIconColor"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_TILETEXTALIGNMENT","""{"handler":"Valid_Tiletextalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEBGIMAGEURL","""{"handler":"Valid_Tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TILEICONALIGNMENT","""{"handler":"Valid_Tileiconalignment","iparms":[]}""");
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
         Z407TileId = Guid.Empty;
         Z515TileText = "";
         Z405TileTextAlignment = "";
         Z404TileTextColor = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z401TileIcon = "";
         Z406TileIconAlignment = "";
         Z438TileIconColor = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A407TileId = Guid.Empty;
         A515TileText = "";
         A404TileTextColor = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A401TileIcon = "";
         A438TileIconColor = "";
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
         T001L4_A407TileId = new Guid[] {Guid.Empty} ;
         T001L4_A515TileText = new string[] {""} ;
         T001L4_A405TileTextAlignment = new string[] {""} ;
         T001L4_A404TileTextColor = new string[] {""} ;
         T001L4_A402TileBGColor = new string[] {""} ;
         T001L4_A403TileBGImageUrl = new string[] {""} ;
         T001L4_A516TileOpacity = new short[1] ;
         T001L4_A401TileIcon = new string[] {""} ;
         T001L4_A406TileIconAlignment = new string[] {""} ;
         T001L4_A438TileIconColor = new string[] {""} ;
         T001L5_A407TileId = new Guid[] {Guid.Empty} ;
         T001L3_A407TileId = new Guid[] {Guid.Empty} ;
         T001L3_A515TileText = new string[] {""} ;
         T001L3_A405TileTextAlignment = new string[] {""} ;
         T001L3_A404TileTextColor = new string[] {""} ;
         T001L3_A402TileBGColor = new string[] {""} ;
         T001L3_A403TileBGImageUrl = new string[] {""} ;
         T001L3_A516TileOpacity = new short[1] ;
         T001L3_A401TileIcon = new string[] {""} ;
         T001L3_A406TileIconAlignment = new string[] {""} ;
         T001L3_A438TileIconColor = new string[] {""} ;
         sMode99 = "";
         T001L6_A407TileId = new Guid[] {Guid.Empty} ;
         T001L7_A407TileId = new Guid[] {Guid.Empty} ;
         T001L2_A407TileId = new Guid[] {Guid.Empty} ;
         T001L2_A515TileText = new string[] {""} ;
         T001L2_A405TileTextAlignment = new string[] {""} ;
         T001L2_A404TileTextColor = new string[] {""} ;
         T001L2_A402TileBGColor = new string[] {""} ;
         T001L2_A403TileBGImageUrl = new string[] {""} ;
         T001L2_A516TileOpacity = new short[1] ;
         T001L2_A401TileIcon = new string[] {""} ;
         T001L2_A406TileIconAlignment = new string[] {""} ;
         T001L2_A438TileIconColor = new string[] {""} ;
         T001L11_A407TileId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ407TileId = Guid.Empty;
         ZZ515TileText = "";
         ZZ405TileTextAlignment = "";
         ZZ404TileTextColor = "";
         ZZ402TileBGColor = "";
         ZZ403TileBGImageUrl = "";
         ZZ401TileIcon = "";
         ZZ406TileIconAlignment = "";
         ZZ438TileIconColor = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__default(),
            new Object[][] {
                new Object[] {
               T001L2_A407TileId, T001L2_A515TileText, T001L2_A405TileTextAlignment, T001L2_A404TileTextColor, T001L2_A402TileBGColor, T001L2_A403TileBGImageUrl, T001L2_A516TileOpacity, T001L2_A401TileIcon, T001L2_A406TileIconAlignment, T001L2_A438TileIconColor
               }
               , new Object[] {
               T001L3_A407TileId, T001L3_A515TileText, T001L3_A405TileTextAlignment, T001L3_A404TileTextColor, T001L3_A402TileBGColor, T001L3_A403TileBGImageUrl, T001L3_A516TileOpacity, T001L3_A401TileIcon, T001L3_A406TileIconAlignment, T001L3_A438TileIconColor
               }
               , new Object[] {
               T001L4_A407TileId, T001L4_A515TileText, T001L4_A405TileTextAlignment, T001L4_A404TileTextColor, T001L4_A402TileBGColor, T001L4_A403TileBGImageUrl, T001L4_A516TileOpacity, T001L4_A401TileIcon, T001L4_A406TileIconAlignment, T001L4_A438TileIconColor
               }
               , new Object[] {
               T001L5_A407TileId
               }
               , new Object[] {
               T001L6_A407TileId
               }
               , new Object[] {
               T001L7_A407TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L11_A407TileId
               }
            }
         );
         Z407TileId = Guid.NewGuid( );
         A407TileId = Guid.NewGuid( );
      }

      private short Z516TileOpacity ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A516TileOpacity ;
      private short Gx_BScreen ;
      private short RcdFound99 ;
      private short gxajaxcallmode ;
      private short ZZ516TileOpacity ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTileId_Enabled ;
      private int edtTileText_Enabled ;
      private int edtTileTextColor_Enabled ;
      private int edtTileBGColor_Enabled ;
      private int edtTileBGImageUrl_Enabled ;
      private int edtTileOpacity_Enabled ;
      private int edtTileIcon_Enabled ;
      private int edtTileIconColor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z405TileTextAlignment ;
      private string Z404TileTextColor ;
      private string Z402TileBGColor ;
      private string Z401TileIcon ;
      private string Z406TileIconAlignment ;
      private string Z438TileIconColor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTileId_Internalname ;
      private string A405TileTextAlignment ;
      private string cmbTileTextAlignment_Internalname ;
      private string A406TileIconAlignment ;
      private string cmbTileIconAlignment_Internalname ;
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
      private string edtTileId_Jsonclick ;
      private string edtTileText_Internalname ;
      private string edtTileText_Jsonclick ;
      private string cmbTileTextAlignment_Jsonclick ;
      private string edtTileTextColor_Internalname ;
      private string A404TileTextColor ;
      private string edtTileTextColor_Jsonclick ;
      private string edtTileBGColor_Internalname ;
      private string A402TileBGColor ;
      private string edtTileBGColor_Jsonclick ;
      private string edtTileBGImageUrl_Internalname ;
      private string edtTileBGImageUrl_Jsonclick ;
      private string edtTileOpacity_Internalname ;
      private string edtTileOpacity_Jsonclick ;
      private string edtTileIcon_Internalname ;
      private string A401TileIcon ;
      private string edtTileIcon_Jsonclick ;
      private string cmbTileIconAlignment_Jsonclick ;
      private string edtTileIconColor_Internalname ;
      private string A438TileIconColor ;
      private string edtTileIconColor_Jsonclick ;
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
      private string sMode99 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ405TileTextAlignment ;
      private string ZZ404TileTextColor ;
      private string ZZ402TileBGColor ;
      private string ZZ401TileIcon ;
      private string ZZ406TileIconAlignment ;
      private string ZZ438TileIconColor ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z515TileText ;
      private string Z403TileBGImageUrl ;
      private string A515TileText ;
      private string A403TileBGImageUrl ;
      private string ZZ515TileText ;
      private string ZZ403TileBGImageUrl ;
      private Guid Z407TileId ;
      private Guid A407TileId ;
      private Guid ZZ407TileId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTileTextAlignment ;
      private GXCombobox cmbTileIconAlignment ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001L4_A407TileId ;
      private string[] T001L4_A515TileText ;
      private string[] T001L4_A405TileTextAlignment ;
      private string[] T001L4_A404TileTextColor ;
      private string[] T001L4_A402TileBGColor ;
      private string[] T001L4_A403TileBGImageUrl ;
      private short[] T001L4_A516TileOpacity ;
      private string[] T001L4_A401TileIcon ;
      private string[] T001L4_A406TileIconAlignment ;
      private string[] T001L4_A438TileIconColor ;
      private Guid[] T001L5_A407TileId ;
      private Guid[] T001L3_A407TileId ;
      private string[] T001L3_A515TileText ;
      private string[] T001L3_A405TileTextAlignment ;
      private string[] T001L3_A404TileTextColor ;
      private string[] T001L3_A402TileBGColor ;
      private string[] T001L3_A403TileBGImageUrl ;
      private short[] T001L3_A516TileOpacity ;
      private string[] T001L3_A401TileIcon ;
      private string[] T001L3_A406TileIconAlignment ;
      private string[] T001L3_A438TileIconColor ;
      private Guid[] T001L6_A407TileId ;
      private Guid[] T001L7_A407TileId ;
      private Guid[] T001L2_A407TileId ;
      private string[] T001L2_A515TileText ;
      private string[] T001L2_A405TileTextAlignment ;
      private string[] T001L2_A404TileTextColor ;
      private string[] T001L2_A402TileBGColor ;
      private string[] T001L2_A403TileBGImageUrl ;
      private short[] T001L2_A516TileOpacity ;
      private string[] T001L2_A401TileIcon ;
      private string[] T001L2_A406TileIconAlignment ;
      private string[] T001L2_A438TileIconColor ;
      private Guid[] T001L11_A407TileId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_tile__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_tile__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_tile__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT001L2;
       prmT001L2 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L3;
       prmT001L3 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L4;
       prmT001L4 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L5;
       prmT001L5 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L6;
       prmT001L6 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L7;
       prmT001L7 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L8;
       prmT001L8 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("TileText",GXType.VarChar,40,0) ,
       new ParDef("TileTextAlignment",GXType.Char,20,0) ,
       new ParDef("TileTextColor",GXType.Char,20,0) ,
       new ParDef("TileBGColor",GXType.Char,20,0) ,
       new ParDef("TileBGImageUrl",GXType.VarChar,1000,0) ,
       new ParDef("TileOpacity",GXType.Int16,4,0) ,
       new ParDef("TileIcon",GXType.Char,20,0) ,
       new ParDef("TileIconAlignment",GXType.Char,20,0) ,
       new ParDef("TileIconColor",GXType.Char,20,0)
       };
       Object[] prmT001L9;
       prmT001L9 = new Object[] {
       new ParDef("TileText",GXType.VarChar,40,0) ,
       new ParDef("TileTextAlignment",GXType.Char,20,0) ,
       new ParDef("TileTextColor",GXType.Char,20,0) ,
       new ParDef("TileBGColor",GXType.Char,20,0) ,
       new ParDef("TileBGImageUrl",GXType.VarChar,1000,0) ,
       new ParDef("TileOpacity",GXType.Int16,4,0) ,
       new ParDef("TileIcon",GXType.Char,20,0) ,
       new ParDef("TileIconAlignment",GXType.Char,20,0) ,
       new ParDef("TileIconColor",GXType.Char,20,0) ,
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L10;
       prmT001L10 = new Object[] {
       new ParDef("TileId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L11;
       prmT001L11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001L2", "SELECT TileId, TileText, TileTextAlignment, TileTextColor, TileBGColor, TileBGImageUrl, TileOpacity, TileIcon, TileIconAlignment, TileIconColor FROM Trn_Tile WHERE TileId = :TileId  FOR UPDATE OF Trn_Tile NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L3", "SELECT TileId, TileText, TileTextAlignment, TileTextColor, TileBGColor, TileBGImageUrl, TileOpacity, TileIcon, TileIconAlignment, TileIconColor FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L4", "SELECT TM1.TileId, TM1.TileText, TM1.TileTextAlignment, TM1.TileTextColor, TM1.TileBGColor, TM1.TileBGImageUrl, TM1.TileOpacity, TM1.TileIcon, TM1.TileIconAlignment, TM1.TileIconColor FROM Trn_Tile TM1 WHERE TM1.TileId = :TileId ORDER BY TM1.TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L5", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L6", "SELECT TileId FROM Trn_Tile WHERE ( TileId > :TileId) ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L7", "SELECT TileId FROM Trn_Tile WHERE ( TileId < :TileId) ORDER BY TileId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L8", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(TileId, TileText, TileTextAlignment, TileTextColor, TileBGColor, TileBGImageUrl, TileOpacity, TileIcon, TileIconAlignment, TileIconColor) VALUES(:TileId, :TileText, :TileTextAlignment, :TileTextColor, :TileBGColor, :TileBGImageUrl, :TileOpacity, :TileIcon, :TileIconAlignment, :TileIconColor);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001L8)
          ,new CursorDef("T001L9", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET TileText=:TileText, TileTextAlignment=:TileTextAlignment, TileTextColor=:TileTextColor, TileBGColor=:TileBGColor, TileBGImageUrl=:TileBGImageUrl, TileOpacity=:TileOpacity, TileIcon=:TileIcon, TileIconAlignment=:TileIconAlignment, TileIconColor=:TileIconColor  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L9)
          ,new CursorDef("T001L10", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L10)
          ,new CursorDef("T001L11", "SELECT TileId FROM Trn_Tile ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((string[]) buf[9])[0] = rslt.getString(10, 20);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((string[]) buf[9])[0] = rslt.getString(10, 20);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((string[]) buf[9])[0] = rslt.getString(10, 20);
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
