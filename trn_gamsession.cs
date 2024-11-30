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
   public class trn_gamsession : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Gam Session", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_gamsession( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_gamsession( IGxContext context )
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
         chksesreload = new GXCheckbox();
         chksesendedbyotherlogin = new GXCheckbox();
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
         A481sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A481sesreload));
         AssignAttri("", false, "A481sesreload", A481sesreload);
         A496sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A496sesendedbyotherlogin));
         AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Gam Session", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtrepid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtrepid_Internalname, context.GetMessage( "repid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtrepid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A461repid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtrepid_Enabled!=0) ? context.localUtil.Format( (decimal)(A461repid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A461repid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtrepid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtrepid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestoken_Internalname, context.GetMessage( "sestoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestoken_Internalname, StringUtil.RTrim( A460sestoken), StringUtil.RTrim( context.localUtil.Format( A460sestoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestoken_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesdate_Internalname, context.GetMessage( "sesdate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesdate_Internalname, context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A469sesdate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesdate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsessts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsessts_Internalname, context.GetMessage( "sessts", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsessts_Internalname, StringUtil.RTrim( A462sessts), StringUtil.RTrim( context.localUtil.Format( A462sessts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsessts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsessts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestype_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestype_Internalname, context.GetMessage( "sestype", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestype_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A463sestype), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsestype_Enabled!=0) ? context.localUtil.Format( (decimal)(A463sestype), "ZZZ9") : context.localUtil.Format( (decimal)(A463sestype), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestype_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestype_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesurl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesurl_Internalname, context.GetMessage( "sesurl", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesurl_Internalname, A473sesurl, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtsesurl_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesipadd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesipadd_Internalname, context.GetMessage( "sesipadd", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesipadd_Internalname, StringUtil.RTrim( A474sesipadd), StringUtil.RTrim( context.localUtil.Format( A474sesipadd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesipadd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesipadd_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtopesysid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtopesysid_Internalname, context.GetMessage( "opesysid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtopesysid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466opesysid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtopesysid_Enabled!=0) ? context.localUtil.Format( (decimal)(A466opesysid), "ZZZ9") : context.localUtil.Format( (decimal)(A466opesysid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtopesysid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtopesysid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslastacc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslastacc_Internalname, context.GetMessage( "seslastacc", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtseslastacc_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtseslastacc_Internalname, context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A475seslastacc, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslastacc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslastacc_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtseslastacc_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtseslastacc_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestimeout_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestimeout_Internalname, context.GetMessage( "sestimeout", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A476sestimeout), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsestimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(A476sestimeout), "ZZZ9") : context.localUtil.Format( (decimal)(A476sestimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogatt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogatt_Internalname, context.GetMessage( "seslogatt", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtseslogatt_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A477seslogatt), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtseslogatt_Enabled!=0) ? context.localUtil.Format( (decimal)(A477seslogatt), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A477seslogatt), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslogatt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslogatt_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogdate_Internalname, context.GetMessage( "seslogdate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtseslogdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtseslogdate_Internalname, context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A478seslogdate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslogdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslogdate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtseslogdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtseslogdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesshareddata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesshareddata_Internalname, context.GetMessage( "sesshareddata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesshareddata_Internalname, A479sesshareddata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtsesshareddata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesenddate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesenddate_Internalname, context.GetMessage( "sesenddate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesenddate_Internalname, context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A480sesenddate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesenddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesenddate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chksesreload_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chksesreload_Internalname, context.GetMessage( "sesreload", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chksesreload_Internalname, StringUtil.BoolToStr( A481sesreload), "", context.GetMessage( "sesreload", ""), 1, chksesreload.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtbrwid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtbrwid_Internalname, context.GetMessage( "brwid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtbrwid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A472brwid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtbrwid_Enabled!=0) ? context.localUtil.Format( (decimal)(A472brwid), "ZZZ9") : context.localUtil.Format( (decimal)(A472brwid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtbrwid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtbrwid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslasturl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslasturl_Internalname, context.GetMessage( "seslasturl", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtseslasturl_Internalname, A482seslasturl, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", 0, 1, edtseslasturl_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogin_Internalname, context.GetMessage( "seslogin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtseslogin_Internalname, A483seslogin, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", 0, 1, edtseslogin_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken_Internalname, context.GetMessage( "sesexttoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesexttoken_Internalname, StringUtil.RTrim( A467sesexttoken), StringUtil.RTrim( context.localUtil.Format( A467sesexttoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesexttoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesexttoken_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtuserguid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtuserguid_Internalname, context.GetMessage( "userguid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtuserguid_Internalname, StringUtil.RTrim( A468userguid), StringUtil.RTrim( context.localUtil.Format( A468userguid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtuserguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtuserguid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesapptokenexp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesapptokenexp_Internalname, context.GetMessage( "sesapptokenexp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesapptokenexp_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesapptokenexp_Internalname, context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A484sesapptokenexp, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesapptokenexp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesapptokenexp_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesapptokenexp_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesapptokenexp_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesrefreshtoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesrefreshtoken_Internalname, context.GetMessage( "sesrefreshtoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesrefreshtoken_Internalname, StringUtil.RTrim( A464sesrefreshtoken), StringUtil.RTrim( context.localUtil.Format( A464sesrefreshtoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesrefreshtoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesrefreshtoken_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesappid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesappid_Internalname, context.GetMessage( "sesappid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesappid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A465sesappid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesappid_Enabled!=0) ? context.localUtil.Format( (decimal)(A465sesappid), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A465sesappid), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesappid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesappid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesdeviceid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesdeviceid_Internalname, context.GetMessage( "sesdeviceid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesdeviceid_Internalname, StringUtil.RTrim( A485sesdeviceid), StringUtil.RTrim( context.localUtil.Format( A485sesdeviceid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesdeviceid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesdeviceid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken2_Internalname, context.GetMessage( "sesexttoken2", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttoken2_Internalname, A486sesexttoken2, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", 0, 1, edtsesexttoken2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesauttypename_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesauttypename_Internalname, context.GetMessage( "sesauttypename", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesauttypename_Internalname, StringUtil.RTrim( A470sesauttypename), StringUtil.RTrim( context.localUtil.Format( A470sesauttypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesauttypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesauttypename_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthtokenmaxrenew_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthtokenmaxrenew_Internalname, context.GetMessage( "sesoauthtokenmaxrenew", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesoauthtokenmaxrenew_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A487sesoauthtokenmaxrenew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesoauthtokenmaxrenew_Enabled!=0) ? context.localUtil.Format( (decimal)(A487sesoauthtokenmaxrenew), "ZZZ9") : context.localUtil.Format( (decimal)(A487sesoauthtokenmaxrenew), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesoauthtokenmaxrenew_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesoauthtokenmaxrenew_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthtokenexpires_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthtokenexpires_Internalname, context.GetMessage( "sesoauthtokenexpires", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesoauthtokenexpires_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488sesoauthtokenexpires), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesoauthtokenexpires_Enabled!=0) ? context.localUtil.Format( (decimal)(A488sesoauthtokenexpires), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488sesoauthtokenexpires), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesoauthtokenexpires_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesoauthtokenexpires_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthscope_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthscope_Internalname, context.GetMessage( "sesoauthscope", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesoauthscope_Internalname, A489sesoauthscope, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", 0, 1, edtsesoauthscope_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken3_Internalname, context.GetMessage( "sesexttoken3", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttoken3_Internalname, A490sesexttoken3, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", 0, 1, edtsesexttoken3_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttokenexpires_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttokenexpires_Internalname, context.GetMessage( "sesexttokenexpires", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesexttokenexpires_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesexttokenexpires_Internalname, context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A491sesexttokenexpires, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesexttokenexpires_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesexttokenexpires_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesexttokenexpires_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesexttokenexpires_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttokenrefresh_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttokenrefresh_Internalname, context.GetMessage( "sesexttokenrefresh", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttokenrefresh_Internalname, A492sesexttokenrefresh, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", 0, 1, edtsesexttokenrefresh_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesjson_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesjson_Internalname, context.GetMessage( "sesjson", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesjson_Internalname, A493sesjson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", 0, 1, edtsesjson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesidtoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesidtoken_Internalname, context.GetMessage( "sesidtoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesidtoken_Internalname, A494sesidtoken, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", 0, 1, edtsesidtoken_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "4096", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesotp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesotp_Internalname, context.GetMessage( "sesotp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesotp_Internalname, A471sesotp, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", 0, 1, edtsesotp_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesotpexpire_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesotpexpire_Internalname, context.GetMessage( "sesotpexpire", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesotpexpire_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesotpexpire_Internalname, context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A495sesotpexpire, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesotpexpire_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesotpexpire_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesotpexpire_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesotpexpire_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chksesendedbyotherlogin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chksesendedbyotherlogin_Internalname, context.GetMessage( "sesendedbyotherlogin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chksesendedbyotherlogin_Internalname, StringUtil.BoolToStr( A496sesendedbyotherlogin), "", context.GetMessage( "sesendedbyotherlogin", ""), 1, chksesendedbyotherlogin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(214, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,214);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 223,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
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
            Z461repid = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z461repid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z460sestoken = cgiGet( "Z460sestoken");
            Z469sesdate = context.localUtil.CToT( cgiGet( "Z469sesdate"), 0);
            Z462sessts = cgiGet( "Z462sessts");
            Z463sestype = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z463sestype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z473sesurl = cgiGet( "Z473sesurl");
            Z474sesipadd = cgiGet( "Z474sesipadd");
            Z466opesysid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z466opesysid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z475seslastacc = context.localUtil.CToT( cgiGet( "Z475seslastacc"), 0);
            Z476sestimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z476sestimeout"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z477seslogatt = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z477seslogatt"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z478seslogdate = context.localUtil.CToT( cgiGet( "Z478seslogdate"), 0);
            Z480sesenddate = context.localUtil.CToT( cgiGet( "Z480sesenddate"), 0);
            Z481sesreload = StringUtil.StrToBool( cgiGet( "Z481sesreload"));
            Z472brwid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z472brwid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z482seslasturl = cgiGet( "Z482seslasturl");
            Z483seslogin = cgiGet( "Z483seslogin");
            Z467sesexttoken = cgiGet( "Z467sesexttoken");
            Z468userguid = cgiGet( "Z468userguid");
            Z484sesapptokenexp = context.localUtil.CToT( cgiGet( "Z484sesapptokenexp"), 0);
            Z464sesrefreshtoken = cgiGet( "Z464sesrefreshtoken");
            Z465sesappid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z465sesappid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z485sesdeviceid = cgiGet( "Z485sesdeviceid");
            Z486sesexttoken2 = cgiGet( "Z486sesexttoken2");
            Z470sesauttypename = cgiGet( "Z470sesauttypename");
            Z487sesoauthtokenmaxrenew = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z487sesoauthtokenmaxrenew"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z488sesoauthtokenexpires = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z488sesoauthtokenexpires"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z489sesoauthscope = cgiGet( "Z489sesoauthscope");
            Z491sesexttokenexpires = context.localUtil.CToT( cgiGet( "Z491sesexttokenexpires"), 0);
            Z492sesexttokenrefresh = cgiGet( "Z492sesexttokenrefresh");
            Z494sesidtoken = cgiGet( "Z494sesidtoken");
            Z471sesotp = cgiGet( "Z471sesotp");
            Z495sesotpexpire = context.localUtil.CToT( cgiGet( "Z495sesotpexpire"), 0);
            Z496sesendedbyotherlogin = StringUtil.StrToBool( cgiGet( "Z496sesendedbyotherlogin"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPID");
               AnyError = 1;
               GX_FocusControl = edtrepid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A461repid = 0;
               AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            }
            else
            {
               A461repid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            }
            A460sestoken = cgiGet( edtsestoken_Internalname);
            AssignAttri("", false, "A460sestoken", A460sestoken);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesdate", "")}), 1, "SESDATE");
               AnyError = 1;
               GX_FocusControl = edtsesdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A469sesdate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A469sesdate = context.localUtil.CToT( cgiGet( edtsesdate_Internalname));
               AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A462sessts = cgiGet( edtsessts_Internalname);
            AssignAttri("", false, "A462sessts", A462sessts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESTYPE");
               AnyError = 1;
               GX_FocusControl = edtsestype_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A463sestype = 0;
               AssignAttri("", false, "A463sestype", StringUtil.LTrimStr( (decimal)(A463sestype), 4, 0));
            }
            else
            {
               A463sestype = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A463sestype", StringUtil.LTrimStr( (decimal)(A463sestype), 4, 0));
            }
            A473sesurl = cgiGet( edtsesurl_Internalname);
            AssignAttri("", false, "A473sesurl", A473sesurl);
            A474sesipadd = cgiGet( edtsesipadd_Internalname);
            AssignAttri("", false, "A474sesipadd", A474sesipadd);
            if ( ( ( context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPESYSID");
               AnyError = 1;
               GX_FocusControl = edtopesysid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A466opesysid = 0;
               AssignAttri("", false, "A466opesysid", StringUtil.LTrimStr( (decimal)(A466opesysid), 4, 0));
            }
            else
            {
               A466opesysid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A466opesysid", StringUtil.LTrimStr( (decimal)(A466opesysid), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtseslastacc_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "seslastacc", "")}), 1, "SESLASTACC");
               AnyError = 1;
               GX_FocusControl = edtseslastacc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A475seslastacc = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A475seslastacc = context.localUtil.CToT( cgiGet( edtseslastacc_Internalname));
               AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESTIMEOUT");
               AnyError = 1;
               GX_FocusControl = edtsestimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A476sestimeout = 0;
               AssignAttri("", false, "A476sestimeout", StringUtil.LTrimStr( (decimal)(A476sestimeout), 4, 0));
            }
            else
            {
               A476sestimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A476sestimeout", StringUtil.LTrimStr( (decimal)(A476sestimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESLOGATT");
               AnyError = 1;
               GX_FocusControl = edtseslogatt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A477seslogatt = 0;
               AssignAttri("", false, "A477seslogatt", StringUtil.LTrimStr( (decimal)(A477seslogatt), 9, 0));
            }
            else
            {
               A477seslogatt = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A477seslogatt", StringUtil.LTrimStr( (decimal)(A477seslogatt), 9, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtseslogdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "seslogdate", "")}), 1, "SESLOGDATE");
               AnyError = 1;
               GX_FocusControl = edtseslogdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A478seslogdate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A478seslogdate = context.localUtil.CToT( cgiGet( edtseslogdate_Internalname));
               AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A479sesshareddata = cgiGet( edtsesshareddata_Internalname);
            AssignAttri("", false, "A479sesshareddata", A479sesshareddata);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesenddate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesenddate", "")}), 1, "SESENDDATE");
               AnyError = 1;
               GX_FocusControl = edtsesenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A480sesenddate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A480sesenddate = context.localUtil.CToT( cgiGet( edtsesenddate_Internalname));
               AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A481sesreload = StringUtil.StrToBool( cgiGet( chksesreload_Internalname));
            AssignAttri("", false, "A481sesreload", A481sesreload);
            if ( ( ( context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BRWID");
               AnyError = 1;
               GX_FocusControl = edtbrwid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A472brwid = 0;
               AssignAttri("", false, "A472brwid", StringUtil.LTrimStr( (decimal)(A472brwid), 4, 0));
            }
            else
            {
               A472brwid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A472brwid", StringUtil.LTrimStr( (decimal)(A472brwid), 4, 0));
            }
            A482seslasturl = cgiGet( edtseslasturl_Internalname);
            AssignAttri("", false, "A482seslasturl", A482seslasturl);
            A483seslogin = cgiGet( edtseslogin_Internalname);
            AssignAttri("", false, "A483seslogin", A483seslogin);
            A467sesexttoken = cgiGet( edtsesexttoken_Internalname);
            AssignAttri("", false, "A467sesexttoken", A467sesexttoken);
            A468userguid = cgiGet( edtuserguid_Internalname);
            AssignAttri("", false, "A468userguid", A468userguid);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesapptokenexp_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesapptokenexp", "")}), 1, "SESAPPTOKENEXP");
               AnyError = 1;
               GX_FocusControl = edtsesapptokenexp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A484sesapptokenexp = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A484sesapptokenexp = context.localUtil.CToT( cgiGet( edtsesapptokenexp_Internalname));
               AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A464sesrefreshtoken = cgiGet( edtsesrefreshtoken_Internalname);
            AssignAttri("", false, "A464sesrefreshtoken", A464sesrefreshtoken);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESAPPID");
               AnyError = 1;
               GX_FocusControl = edtsesappid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A465sesappid = 0;
               AssignAttri("", false, "A465sesappid", StringUtil.LTrimStr( (decimal)(A465sesappid), 18, 0));
            }
            else
            {
               A465sesappid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A465sesappid", StringUtil.LTrimStr( (decimal)(A465sesappid), 18, 0));
            }
            A485sesdeviceid = cgiGet( edtsesdeviceid_Internalname);
            AssignAttri("", false, "A485sesdeviceid", A485sesdeviceid);
            A486sesexttoken2 = cgiGet( edtsesexttoken2_Internalname);
            AssignAttri("", false, "A486sesexttoken2", A486sesexttoken2);
            A470sesauttypename = cgiGet( edtsesauttypename_Internalname);
            AssignAttri("", false, "A470sesauttypename", A470sesauttypename);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESOAUTHTOKENMAXRENEW");
               AnyError = 1;
               GX_FocusControl = edtsesoauthtokenmaxrenew_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A487sesoauthtokenmaxrenew = 0;
               AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A487sesoauthtokenmaxrenew), 4, 0));
            }
            else
            {
               A487sesoauthtokenmaxrenew = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A487sesoauthtokenmaxrenew), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESOAUTHTOKENEXPIRES");
               AnyError = 1;
               GX_FocusControl = edtsesoauthtokenexpires_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A488sesoauthtokenexpires = 0;
               AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A488sesoauthtokenexpires), 9, 0));
            }
            else
            {
               A488sesoauthtokenexpires = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A488sesoauthtokenexpires), 9, 0));
            }
            A489sesoauthscope = cgiGet( edtsesoauthscope_Internalname);
            AssignAttri("", false, "A489sesoauthscope", A489sesoauthscope);
            A490sesexttoken3 = cgiGet( edtsesexttoken3_Internalname);
            AssignAttri("", false, "A490sesexttoken3", A490sesexttoken3);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesexttokenexpires_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesexttokenexpires", "")}), 1, "SESEXTTOKENEXPIRES");
               AnyError = 1;
               GX_FocusControl = edtsesexttokenexpires_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A491sesexttokenexpires = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A491sesexttokenexpires = context.localUtil.CToT( cgiGet( edtsesexttokenexpires_Internalname));
               AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A492sesexttokenrefresh = cgiGet( edtsesexttokenrefresh_Internalname);
            AssignAttri("", false, "A492sesexttokenrefresh", A492sesexttokenrefresh);
            A493sesjson = cgiGet( edtsesjson_Internalname);
            AssignAttri("", false, "A493sesjson", A493sesjson);
            A494sesidtoken = cgiGet( edtsesidtoken_Internalname);
            AssignAttri("", false, "A494sesidtoken", A494sesidtoken);
            A471sesotp = cgiGet( edtsesotp_Internalname);
            AssignAttri("", false, "A471sesotp", A471sesotp);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesotpexpire_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesotpexpire", "")}), 1, "SESOTPEXPIRE");
               AnyError = 1;
               GX_FocusControl = edtsesotpexpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A495sesotpexpire = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A495sesotpexpire = context.localUtil.CToT( cgiGet( edtsesotpexpire_Internalname));
               AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A496sesendedbyotherlogin = StringUtil.StrToBool( cgiGet( chksesendedbyotherlogin_Internalname));
            AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
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
               A461repid = (int)(Math.Round(NumberUtil.Val( GetPar( "repid"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
               A460sestoken = GetPar( "sestoken");
               AssignAttri("", false, "A460sestoken", A460sestoken);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
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
               InitAll1H93( ) ;
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
         DisableAttributes1H93( ) ;
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

      protected void ResetCaption1H0( )
      {
      }

      protected void ZM1H93( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z469sesdate = T001H3_A469sesdate[0];
               Z462sessts = T001H3_A462sessts[0];
               Z463sestype = T001H3_A463sestype[0];
               Z473sesurl = T001H3_A473sesurl[0];
               Z474sesipadd = T001H3_A474sesipadd[0];
               Z466opesysid = T001H3_A466opesysid[0];
               Z475seslastacc = T001H3_A475seslastacc[0];
               Z476sestimeout = T001H3_A476sestimeout[0];
               Z477seslogatt = T001H3_A477seslogatt[0];
               Z478seslogdate = T001H3_A478seslogdate[0];
               Z480sesenddate = T001H3_A480sesenddate[0];
               Z481sesreload = T001H3_A481sesreload[0];
               Z472brwid = T001H3_A472brwid[0];
               Z482seslasturl = T001H3_A482seslasturl[0];
               Z483seslogin = T001H3_A483seslogin[0];
               Z467sesexttoken = T001H3_A467sesexttoken[0];
               Z468userguid = T001H3_A468userguid[0];
               Z484sesapptokenexp = T001H3_A484sesapptokenexp[0];
               Z464sesrefreshtoken = T001H3_A464sesrefreshtoken[0];
               Z465sesappid = T001H3_A465sesappid[0];
               Z485sesdeviceid = T001H3_A485sesdeviceid[0];
               Z486sesexttoken2 = T001H3_A486sesexttoken2[0];
               Z470sesauttypename = T001H3_A470sesauttypename[0];
               Z487sesoauthtokenmaxrenew = T001H3_A487sesoauthtokenmaxrenew[0];
               Z488sesoauthtokenexpires = T001H3_A488sesoauthtokenexpires[0];
               Z489sesoauthscope = T001H3_A489sesoauthscope[0];
               Z491sesexttokenexpires = T001H3_A491sesexttokenexpires[0];
               Z492sesexttokenrefresh = T001H3_A492sesexttokenrefresh[0];
               Z494sesidtoken = T001H3_A494sesidtoken[0];
               Z471sesotp = T001H3_A471sesotp[0];
               Z495sesotpexpire = T001H3_A495sesotpexpire[0];
               Z496sesendedbyotherlogin = T001H3_A496sesendedbyotherlogin[0];
            }
            else
            {
               Z469sesdate = A469sesdate;
               Z462sessts = A462sessts;
               Z463sestype = A463sestype;
               Z473sesurl = A473sesurl;
               Z474sesipadd = A474sesipadd;
               Z466opesysid = A466opesysid;
               Z475seslastacc = A475seslastacc;
               Z476sestimeout = A476sestimeout;
               Z477seslogatt = A477seslogatt;
               Z478seslogdate = A478seslogdate;
               Z480sesenddate = A480sesenddate;
               Z481sesreload = A481sesreload;
               Z472brwid = A472brwid;
               Z482seslasturl = A482seslasturl;
               Z483seslogin = A483seslogin;
               Z467sesexttoken = A467sesexttoken;
               Z468userguid = A468userguid;
               Z484sesapptokenexp = A484sesapptokenexp;
               Z464sesrefreshtoken = A464sesrefreshtoken;
               Z465sesappid = A465sesappid;
               Z485sesdeviceid = A485sesdeviceid;
               Z486sesexttoken2 = A486sesexttoken2;
               Z470sesauttypename = A470sesauttypename;
               Z487sesoauthtokenmaxrenew = A487sesoauthtokenmaxrenew;
               Z488sesoauthtokenexpires = A488sesoauthtokenexpires;
               Z489sesoauthscope = A489sesoauthscope;
               Z491sesexttokenexpires = A491sesexttokenexpires;
               Z492sesexttokenrefresh = A492sesexttokenrefresh;
               Z494sesidtoken = A494sesidtoken;
               Z471sesotp = A471sesotp;
               Z495sesotpexpire = A495sesotpexpire;
               Z496sesendedbyotherlogin = A496sesendedbyotherlogin;
            }
         }
         if ( GX_JID == -1 )
         {
            Z461repid = A461repid;
            Z460sestoken = A460sestoken;
            Z469sesdate = A469sesdate;
            Z462sessts = A462sessts;
            Z463sestype = A463sestype;
            Z473sesurl = A473sesurl;
            Z474sesipadd = A474sesipadd;
            Z466opesysid = A466opesysid;
            Z475seslastacc = A475seslastacc;
            Z476sestimeout = A476sestimeout;
            Z477seslogatt = A477seslogatt;
            Z478seslogdate = A478seslogdate;
            Z479sesshareddata = A479sesshareddata;
            Z480sesenddate = A480sesenddate;
            Z481sesreload = A481sesreload;
            Z472brwid = A472brwid;
            Z482seslasturl = A482seslasturl;
            Z483seslogin = A483seslogin;
            Z467sesexttoken = A467sesexttoken;
            Z468userguid = A468userguid;
            Z484sesapptokenexp = A484sesapptokenexp;
            Z464sesrefreshtoken = A464sesrefreshtoken;
            Z465sesappid = A465sesappid;
            Z485sesdeviceid = A485sesdeviceid;
            Z486sesexttoken2 = A486sesexttoken2;
            Z470sesauttypename = A470sesauttypename;
            Z487sesoauthtokenmaxrenew = A487sesoauthtokenmaxrenew;
            Z488sesoauthtokenexpires = A488sesoauthtokenexpires;
            Z489sesoauthscope = A489sesoauthscope;
            Z490sesexttoken3 = A490sesexttoken3;
            Z491sesexttokenexpires = A491sesexttokenexpires;
            Z492sesexttokenrefresh = A492sesexttokenrefresh;
            Z493sesjson = A493sesjson;
            Z494sesidtoken = A494sesidtoken;
            Z471sesotp = A471sesotp;
            Z495sesotpexpire = A495sesotpexpire;
            Z496sesendedbyotherlogin = A496sesendedbyotherlogin;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load1H93( )
      {
         /* Using cursor T001H4 */
         pr_datastore1.execute(2, new Object[] {A461repid, A460sestoken});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound93 = 1;
            A469sesdate = T001H4_A469sesdate[0];
            AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A462sessts = T001H4_A462sessts[0];
            AssignAttri("", false, "A462sessts", A462sessts);
            A463sestype = T001H4_A463sestype[0];
            AssignAttri("", false, "A463sestype", StringUtil.LTrimStr( (decimal)(A463sestype), 4, 0));
            A473sesurl = T001H4_A473sesurl[0];
            AssignAttri("", false, "A473sesurl", A473sesurl);
            A474sesipadd = T001H4_A474sesipadd[0];
            AssignAttri("", false, "A474sesipadd", A474sesipadd);
            A466opesysid = T001H4_A466opesysid[0];
            AssignAttri("", false, "A466opesysid", StringUtil.LTrimStr( (decimal)(A466opesysid), 4, 0));
            A475seslastacc = T001H4_A475seslastacc[0];
            AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A476sestimeout = T001H4_A476sestimeout[0];
            AssignAttri("", false, "A476sestimeout", StringUtil.LTrimStr( (decimal)(A476sestimeout), 4, 0));
            A477seslogatt = T001H4_A477seslogatt[0];
            AssignAttri("", false, "A477seslogatt", StringUtil.LTrimStr( (decimal)(A477seslogatt), 9, 0));
            A478seslogdate = T001H4_A478seslogdate[0];
            AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A479sesshareddata = T001H4_A479sesshareddata[0];
            AssignAttri("", false, "A479sesshareddata", A479sesshareddata);
            A480sesenddate = T001H4_A480sesenddate[0];
            AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A481sesreload = T001H4_A481sesreload[0];
            AssignAttri("", false, "A481sesreload", A481sesreload);
            A472brwid = T001H4_A472brwid[0];
            AssignAttri("", false, "A472brwid", StringUtil.LTrimStr( (decimal)(A472brwid), 4, 0));
            A482seslasturl = T001H4_A482seslasturl[0];
            AssignAttri("", false, "A482seslasturl", A482seslasturl);
            A483seslogin = T001H4_A483seslogin[0];
            AssignAttri("", false, "A483seslogin", A483seslogin);
            A467sesexttoken = T001H4_A467sesexttoken[0];
            AssignAttri("", false, "A467sesexttoken", A467sesexttoken);
            A468userguid = T001H4_A468userguid[0];
            AssignAttri("", false, "A468userguid", A468userguid);
            A484sesapptokenexp = T001H4_A484sesapptokenexp[0];
            AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A464sesrefreshtoken = T001H4_A464sesrefreshtoken[0];
            AssignAttri("", false, "A464sesrefreshtoken", A464sesrefreshtoken);
            A465sesappid = T001H4_A465sesappid[0];
            AssignAttri("", false, "A465sesappid", StringUtil.LTrimStr( (decimal)(A465sesappid), 18, 0));
            A485sesdeviceid = T001H4_A485sesdeviceid[0];
            AssignAttri("", false, "A485sesdeviceid", A485sesdeviceid);
            A486sesexttoken2 = T001H4_A486sesexttoken2[0];
            AssignAttri("", false, "A486sesexttoken2", A486sesexttoken2);
            A470sesauttypename = T001H4_A470sesauttypename[0];
            AssignAttri("", false, "A470sesauttypename", A470sesauttypename);
            A487sesoauthtokenmaxrenew = T001H4_A487sesoauthtokenmaxrenew[0];
            AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A487sesoauthtokenmaxrenew), 4, 0));
            A488sesoauthtokenexpires = T001H4_A488sesoauthtokenexpires[0];
            AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A488sesoauthtokenexpires), 9, 0));
            A489sesoauthscope = T001H4_A489sesoauthscope[0];
            AssignAttri("", false, "A489sesoauthscope", A489sesoauthscope);
            A490sesexttoken3 = T001H4_A490sesexttoken3[0];
            AssignAttri("", false, "A490sesexttoken3", A490sesexttoken3);
            A491sesexttokenexpires = T001H4_A491sesexttokenexpires[0];
            AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A492sesexttokenrefresh = T001H4_A492sesexttokenrefresh[0];
            AssignAttri("", false, "A492sesexttokenrefresh", A492sesexttokenrefresh);
            A493sesjson = T001H4_A493sesjson[0];
            AssignAttri("", false, "A493sesjson", A493sesjson);
            A494sesidtoken = T001H4_A494sesidtoken[0];
            AssignAttri("", false, "A494sesidtoken", A494sesidtoken);
            A471sesotp = T001H4_A471sesotp[0];
            AssignAttri("", false, "A471sesotp", A471sesotp);
            A495sesotpexpire = T001H4_A495sesotpexpire[0];
            AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A496sesendedbyotherlogin = T001H4_A496sesendedbyotherlogin[0];
            AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
            ZM1H93( -1) ;
         }
         pr_datastore1.close(2);
         OnLoadActions1H93( ) ;
      }

      protected void OnLoadActions1H93( )
      {
      }

      protected void CheckExtendedTable1H93( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1H93( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1H93( )
      {
         /* Using cursor T001H5 */
         pr_datastore1.execute(3, new Object[] {A461repid, A460sestoken});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001H3 */
         pr_datastore1.execute(1, new Object[] {A461repid, A460sestoken});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM1H93( 1) ;
            RcdFound93 = 1;
            A461repid = T001H3_A461repid[0];
            AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            A460sestoken = T001H3_A460sestoken[0];
            AssignAttri("", false, "A460sestoken", A460sestoken);
            A469sesdate = T001H3_A469sesdate[0];
            AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A462sessts = T001H3_A462sessts[0];
            AssignAttri("", false, "A462sessts", A462sessts);
            A463sestype = T001H3_A463sestype[0];
            AssignAttri("", false, "A463sestype", StringUtil.LTrimStr( (decimal)(A463sestype), 4, 0));
            A473sesurl = T001H3_A473sesurl[0];
            AssignAttri("", false, "A473sesurl", A473sesurl);
            A474sesipadd = T001H3_A474sesipadd[0];
            AssignAttri("", false, "A474sesipadd", A474sesipadd);
            A466opesysid = T001H3_A466opesysid[0];
            AssignAttri("", false, "A466opesysid", StringUtil.LTrimStr( (decimal)(A466opesysid), 4, 0));
            A475seslastacc = T001H3_A475seslastacc[0];
            AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A476sestimeout = T001H3_A476sestimeout[0];
            AssignAttri("", false, "A476sestimeout", StringUtil.LTrimStr( (decimal)(A476sestimeout), 4, 0));
            A477seslogatt = T001H3_A477seslogatt[0];
            AssignAttri("", false, "A477seslogatt", StringUtil.LTrimStr( (decimal)(A477seslogatt), 9, 0));
            A478seslogdate = T001H3_A478seslogdate[0];
            AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A479sesshareddata = T001H3_A479sesshareddata[0];
            AssignAttri("", false, "A479sesshareddata", A479sesshareddata);
            A480sesenddate = T001H3_A480sesenddate[0];
            AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A481sesreload = T001H3_A481sesreload[0];
            AssignAttri("", false, "A481sesreload", A481sesreload);
            A472brwid = T001H3_A472brwid[0];
            AssignAttri("", false, "A472brwid", StringUtil.LTrimStr( (decimal)(A472brwid), 4, 0));
            A482seslasturl = T001H3_A482seslasturl[0];
            AssignAttri("", false, "A482seslasturl", A482seslasturl);
            A483seslogin = T001H3_A483seslogin[0];
            AssignAttri("", false, "A483seslogin", A483seslogin);
            A467sesexttoken = T001H3_A467sesexttoken[0];
            AssignAttri("", false, "A467sesexttoken", A467sesexttoken);
            A468userguid = T001H3_A468userguid[0];
            AssignAttri("", false, "A468userguid", A468userguid);
            A484sesapptokenexp = T001H3_A484sesapptokenexp[0];
            AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A464sesrefreshtoken = T001H3_A464sesrefreshtoken[0];
            AssignAttri("", false, "A464sesrefreshtoken", A464sesrefreshtoken);
            A465sesappid = T001H3_A465sesappid[0];
            AssignAttri("", false, "A465sesappid", StringUtil.LTrimStr( (decimal)(A465sesappid), 18, 0));
            A485sesdeviceid = T001H3_A485sesdeviceid[0];
            AssignAttri("", false, "A485sesdeviceid", A485sesdeviceid);
            A486sesexttoken2 = T001H3_A486sesexttoken2[0];
            AssignAttri("", false, "A486sesexttoken2", A486sesexttoken2);
            A470sesauttypename = T001H3_A470sesauttypename[0];
            AssignAttri("", false, "A470sesauttypename", A470sesauttypename);
            A487sesoauthtokenmaxrenew = T001H3_A487sesoauthtokenmaxrenew[0];
            AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A487sesoauthtokenmaxrenew), 4, 0));
            A488sesoauthtokenexpires = T001H3_A488sesoauthtokenexpires[0];
            AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A488sesoauthtokenexpires), 9, 0));
            A489sesoauthscope = T001H3_A489sesoauthscope[0];
            AssignAttri("", false, "A489sesoauthscope", A489sesoauthscope);
            A490sesexttoken3 = T001H3_A490sesexttoken3[0];
            AssignAttri("", false, "A490sesexttoken3", A490sesexttoken3);
            A491sesexttokenexpires = T001H3_A491sesexttokenexpires[0];
            AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A492sesexttokenrefresh = T001H3_A492sesexttokenrefresh[0];
            AssignAttri("", false, "A492sesexttokenrefresh", A492sesexttokenrefresh);
            A493sesjson = T001H3_A493sesjson[0];
            AssignAttri("", false, "A493sesjson", A493sesjson);
            A494sesidtoken = T001H3_A494sesidtoken[0];
            AssignAttri("", false, "A494sesidtoken", A494sesidtoken);
            A471sesotp = T001H3_A471sesotp[0];
            AssignAttri("", false, "A471sesotp", A471sesotp);
            A495sesotpexpire = T001H3_A495sesotpexpire[0];
            AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A496sesendedbyotherlogin = T001H3_A496sesendedbyotherlogin[0];
            AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
            Z461repid = A461repid;
            Z460sestoken = A460sestoken;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1H93( ) ;
            if ( AnyError == 1 )
            {
               RcdFound93 = 0;
               InitializeNonKey1H93( ) ;
            }
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey1H93( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H93( ) ;
         if ( RcdFound93 == 0 )
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
         RcdFound93 = 0;
         /* Using cursor T001H6 */
         pr_datastore1.execute(4, new Object[] {A461repid, A460sestoken});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T001H6_A461repid[0] < A461repid ) || ( T001H6_A461repid[0] == A461repid ) && ( StringUtil.StrCmp(T001H6_A460sestoken[0], A460sestoken) < 0 ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T001H6_A461repid[0] > A461repid ) || ( T001H6_A461repid[0] == A461repid ) && ( StringUtil.StrCmp(T001H6_A460sestoken[0], A460sestoken) > 0 ) ) )
            {
               A461repid = T001H6_A461repid[0];
               AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
               A460sestoken = T001H6_A460sestoken[0];
               AssignAttri("", false, "A460sestoken", A460sestoken);
               RcdFound93 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound93 = 0;
         /* Using cursor T001H7 */
         pr_datastore1.execute(5, new Object[] {A461repid, A460sestoken});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T001H7_A461repid[0] > A461repid ) || ( T001H7_A461repid[0] == A461repid ) && ( StringUtil.StrCmp(T001H7_A460sestoken[0], A460sestoken) > 0 ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T001H7_A461repid[0] < A461repid ) || ( T001H7_A461repid[0] == A461repid ) && ( StringUtil.StrCmp(T001H7_A460sestoken[0], A460sestoken) < 0 ) ) )
            {
               A461repid = T001H7_A461repid[0];
               AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
               A460sestoken = T001H7_A460sestoken[0];
               AssignAttri("", false, "A460sestoken", A460sestoken);
               RcdFound93 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1H93( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1H93( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound93 == 1 )
            {
               if ( ( A461repid != Z461repid ) || ( StringUtil.StrCmp(A460sestoken, Z460sestoken) != 0 ) )
               {
                  A461repid = Z461repid;
                  AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
                  A460sestoken = Z460sestoken;
                  AssignAttri("", false, "A460sestoken", A460sestoken);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REPID");
                  AnyError = 1;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1H93( ) ;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A461repid != Z461repid ) || ( StringUtil.StrCmp(A460sestoken, Z460sestoken) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1H93( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REPID");
                     AnyError = 1;
                     GX_FocusControl = edtrepid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtrepid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1H93( ) ;
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
         if ( ( A461repid != Z461repid ) || ( StringUtil.StrCmp(A460sestoken, Z460sestoken) != 0 ) )
         {
            A461repid = Z461repid;
            AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            A460sestoken = Z460sestoken;
            AssignAttri("", false, "A460sestoken", A460sestoken);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REPID");
            AnyError = 1;
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtrepid_Internalname;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REPID");
            AnyError = 1;
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1H93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H93( ) ;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
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
         ScanStart1H93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound93 != 0 )
            {
               ScanNext1H93( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H93( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1H93( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001H2 */
            pr_datastore1.execute(0, new Object[] {A461repid, A460sestoken});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"session"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( Z469sesdate != T001H2_A469sesdate[0] ) || ( StringUtil.StrCmp(Z462sessts, T001H2_A462sessts[0]) != 0 ) || ( Z463sestype != T001H2_A463sestype[0] ) || ( StringUtil.StrCmp(Z473sesurl, T001H2_A473sesurl[0]) != 0 ) || ( StringUtil.StrCmp(Z474sesipadd, T001H2_A474sesipadd[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z466opesysid != T001H2_A466opesysid[0] ) || ( Z475seslastacc != T001H2_A475seslastacc[0] ) || ( Z476sestimeout != T001H2_A476sestimeout[0] ) || ( Z477seslogatt != T001H2_A477seslogatt[0] ) || ( Z478seslogdate != T001H2_A478seslogdate[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z480sesenddate != T001H2_A480sesenddate[0] ) || ( Z481sesreload != T001H2_A481sesreload[0] ) || ( Z472brwid != T001H2_A472brwid[0] ) || ( StringUtil.StrCmp(Z482seslasturl, T001H2_A482seslasturl[0]) != 0 ) || ( StringUtil.StrCmp(Z483seslogin, T001H2_A483seslogin[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z467sesexttoken, T001H2_A467sesexttoken[0]) != 0 ) || ( StringUtil.StrCmp(Z468userguid, T001H2_A468userguid[0]) != 0 ) || ( Z484sesapptokenexp != T001H2_A484sesapptokenexp[0] ) || ( StringUtil.StrCmp(Z464sesrefreshtoken, T001H2_A464sesrefreshtoken[0]) != 0 ) || ( Z465sesappid != T001H2_A465sesappid[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z485sesdeviceid, T001H2_A485sesdeviceid[0]) != 0 ) || ( StringUtil.StrCmp(Z486sesexttoken2, T001H2_A486sesexttoken2[0]) != 0 ) || ( StringUtil.StrCmp(Z470sesauttypename, T001H2_A470sesauttypename[0]) != 0 ) || ( Z487sesoauthtokenmaxrenew != T001H2_A487sesoauthtokenmaxrenew[0] ) || ( Z488sesoauthtokenexpires != T001H2_A488sesoauthtokenexpires[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z489sesoauthscope, T001H2_A489sesoauthscope[0]) != 0 ) || ( Z491sesexttokenexpires != T001H2_A491sesexttokenexpires[0] ) || ( StringUtil.StrCmp(Z492sesexttokenrefresh, T001H2_A492sesexttokenrefresh[0]) != 0 ) || ( StringUtil.StrCmp(Z494sesidtoken, T001H2_A494sesidtoken[0]) != 0 ) || ( StringUtil.StrCmp(Z471sesotp, T001H2_A471sesotp[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z495sesotpexpire != T001H2_A495sesotpexpire[0] ) || ( Z496sesendedbyotherlogin != T001H2_A496sesendedbyotherlogin[0] ) )
            {
               if ( Z469sesdate != T001H2_A469sesdate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesdate");
                  GXUtil.WriteLogRaw("Old: ",Z469sesdate);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A469sesdate[0]);
               }
               if ( StringUtil.StrCmp(Z462sessts, T001H2_A462sessts[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sessts");
                  GXUtil.WriteLogRaw("Old: ",Z462sessts);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A462sessts[0]);
               }
               if ( Z463sestype != T001H2_A463sestype[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sestype");
                  GXUtil.WriteLogRaw("Old: ",Z463sestype);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A463sestype[0]);
               }
               if ( StringUtil.StrCmp(Z473sesurl, T001H2_A473sesurl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesurl");
                  GXUtil.WriteLogRaw("Old: ",Z473sesurl);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A473sesurl[0]);
               }
               if ( StringUtil.StrCmp(Z474sesipadd, T001H2_A474sesipadd[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesipadd");
                  GXUtil.WriteLogRaw("Old: ",Z474sesipadd);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A474sesipadd[0]);
               }
               if ( Z466opesysid != T001H2_A466opesysid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"opesysid");
                  GXUtil.WriteLogRaw("Old: ",Z466opesysid);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A466opesysid[0]);
               }
               if ( Z475seslastacc != T001H2_A475seslastacc[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslastacc");
                  GXUtil.WriteLogRaw("Old: ",Z475seslastacc);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A475seslastacc[0]);
               }
               if ( Z476sestimeout != T001H2_A476sestimeout[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sestimeout");
                  GXUtil.WriteLogRaw("Old: ",Z476sestimeout);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A476sestimeout[0]);
               }
               if ( Z477seslogatt != T001H2_A477seslogatt[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogatt");
                  GXUtil.WriteLogRaw("Old: ",Z477seslogatt);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A477seslogatt[0]);
               }
               if ( Z478seslogdate != T001H2_A478seslogdate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogdate");
                  GXUtil.WriteLogRaw("Old: ",Z478seslogdate);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A478seslogdate[0]);
               }
               if ( Z480sesenddate != T001H2_A480sesenddate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesenddate");
                  GXUtil.WriteLogRaw("Old: ",Z480sesenddate);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A480sesenddate[0]);
               }
               if ( Z481sesreload != T001H2_A481sesreload[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesreload");
                  GXUtil.WriteLogRaw("Old: ",Z481sesreload);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A481sesreload[0]);
               }
               if ( Z472brwid != T001H2_A472brwid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"brwid");
                  GXUtil.WriteLogRaw("Old: ",Z472brwid);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A472brwid[0]);
               }
               if ( StringUtil.StrCmp(Z482seslasturl, T001H2_A482seslasturl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslasturl");
                  GXUtil.WriteLogRaw("Old: ",Z482seslasturl);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A482seslasturl[0]);
               }
               if ( StringUtil.StrCmp(Z483seslogin, T001H2_A483seslogin[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogin");
                  GXUtil.WriteLogRaw("Old: ",Z483seslogin);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A483seslogin[0]);
               }
               if ( StringUtil.StrCmp(Z467sesexttoken, T001H2_A467sesexttoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttoken");
                  GXUtil.WriteLogRaw("Old: ",Z467sesexttoken);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A467sesexttoken[0]);
               }
               if ( StringUtil.StrCmp(Z468userguid, T001H2_A468userguid[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"userguid");
                  GXUtil.WriteLogRaw("Old: ",Z468userguid);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A468userguid[0]);
               }
               if ( Z484sesapptokenexp != T001H2_A484sesapptokenexp[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesapptokenexp");
                  GXUtil.WriteLogRaw("Old: ",Z484sesapptokenexp);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A484sesapptokenexp[0]);
               }
               if ( StringUtil.StrCmp(Z464sesrefreshtoken, T001H2_A464sesrefreshtoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesrefreshtoken");
                  GXUtil.WriteLogRaw("Old: ",Z464sesrefreshtoken);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A464sesrefreshtoken[0]);
               }
               if ( Z465sesappid != T001H2_A465sesappid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesappid");
                  GXUtil.WriteLogRaw("Old: ",Z465sesappid);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A465sesappid[0]);
               }
               if ( StringUtil.StrCmp(Z485sesdeviceid, T001H2_A485sesdeviceid[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesdeviceid");
                  GXUtil.WriteLogRaw("Old: ",Z485sesdeviceid);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A485sesdeviceid[0]);
               }
               if ( StringUtil.StrCmp(Z486sesexttoken2, T001H2_A486sesexttoken2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttoken2");
                  GXUtil.WriteLogRaw("Old: ",Z486sesexttoken2);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A486sesexttoken2[0]);
               }
               if ( StringUtil.StrCmp(Z470sesauttypename, T001H2_A470sesauttypename[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesauttypename");
                  GXUtil.WriteLogRaw("Old: ",Z470sesauttypename);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A470sesauttypename[0]);
               }
               if ( Z487sesoauthtokenmaxrenew != T001H2_A487sesoauthtokenmaxrenew[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthtokenmaxrenew");
                  GXUtil.WriteLogRaw("Old: ",Z487sesoauthtokenmaxrenew);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A487sesoauthtokenmaxrenew[0]);
               }
               if ( Z488sesoauthtokenexpires != T001H2_A488sesoauthtokenexpires[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthtokenexpires");
                  GXUtil.WriteLogRaw("Old: ",Z488sesoauthtokenexpires);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A488sesoauthtokenexpires[0]);
               }
               if ( StringUtil.StrCmp(Z489sesoauthscope, T001H2_A489sesoauthscope[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthscope");
                  GXUtil.WriteLogRaw("Old: ",Z489sesoauthscope);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A489sesoauthscope[0]);
               }
               if ( Z491sesexttokenexpires != T001H2_A491sesexttokenexpires[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttokenexpires");
                  GXUtil.WriteLogRaw("Old: ",Z491sesexttokenexpires);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A491sesexttokenexpires[0]);
               }
               if ( StringUtil.StrCmp(Z492sesexttokenrefresh, T001H2_A492sesexttokenrefresh[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttokenrefresh");
                  GXUtil.WriteLogRaw("Old: ",Z492sesexttokenrefresh);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A492sesexttokenrefresh[0]);
               }
               if ( StringUtil.StrCmp(Z494sesidtoken, T001H2_A494sesidtoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesidtoken");
                  GXUtil.WriteLogRaw("Old: ",Z494sesidtoken);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A494sesidtoken[0]);
               }
               if ( StringUtil.StrCmp(Z471sesotp, T001H2_A471sesotp[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesotp");
                  GXUtil.WriteLogRaw("Old: ",Z471sesotp);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A471sesotp[0]);
               }
               if ( Z495sesotpexpire != T001H2_A495sesotpexpire[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesotpexpire");
                  GXUtil.WriteLogRaw("Old: ",Z495sesotpexpire);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A495sesotpexpire[0]);
               }
               if ( Z496sesendedbyotherlogin != T001H2_A496sesendedbyotherlogin[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesendedbyotherlogin");
                  GXUtil.WriteLogRaw("Old: ",Z496sesendedbyotherlogin);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A496sesendedbyotherlogin[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"session"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H93( )
      {
         BeforeValidate1H93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H93( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H93( 0) ;
            CheckOptimisticConcurrency1H93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H8 */
                     pr_datastore1.execute(6, new Object[] {A461repid, A460sestoken, A469sesdate, A462sessts, A463sestype, A473sesurl, A474sesipadd, A466opesysid, A475seslastacc, A476sestimeout, A477seslogatt, A478seslogdate, A479sesshareddata, A480sesenddate, A481sesreload, A472brwid, A482seslasturl, A483seslogin, A467sesexttoken, A468userguid, A484sesapptokenexp, A464sesrefreshtoken, A465sesappid, A485sesdeviceid, A486sesexttoken2, A470sesauttypename, A487sesoauthtokenmaxrenew, A488sesoauthtokenexpires, A489sesoauthscope, A490sesexttoken3, A491sesexttokenexpires, A492sesexttokenrefresh, A493sesjson, A494sesidtoken, A471sesotp, A495sesotpexpire, A496sesendedbyotherlogin});
                     pr_datastore1.close(6);
                     pr_datastore1.SmartCacheProvider.SetUpdated("session");
                     if ( (pr_datastore1.getStatus(6) == 1) )
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
                           ResetCaption1H0( ) ;
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
               Load1H93( ) ;
            }
            EndLevel1H93( ) ;
         }
         CloseExtendedTableCursors1H93( ) ;
      }

      protected void Update1H93( )
      {
         BeforeValidate1H93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H93( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H9 */
                     pr_datastore1.execute(7, new Object[] {A469sesdate, A462sessts, A463sestype, A473sesurl, A474sesipadd, A466opesysid, A475seslastacc, A476sestimeout, A477seslogatt, A478seslogdate, A479sesshareddata, A480sesenddate, A481sesreload, A472brwid, A482seslasturl, A483seslogin, A467sesexttoken, A468userguid, A484sesapptokenexp, A464sesrefreshtoken, A465sesappid, A485sesdeviceid, A486sesexttoken2, A470sesauttypename, A487sesoauthtokenmaxrenew, A488sesoauthtokenexpires, A489sesoauthscope, A490sesexttoken3, A491sesexttokenexpires, A492sesexttokenrefresh, A493sesjson, A494sesidtoken, A471sesotp, A495sesotpexpire, A496sesendedbyotherlogin, A461repid, A460sestoken});
                     pr_datastore1.close(7);
                     pr_datastore1.SmartCacheProvider.SetUpdated("session");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"session"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1H93( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1H0( ) ;
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
            EndLevel1H93( ) ;
         }
         CloseExtendedTableCursors1H93( ) ;
      }

      protected void DeferredUpdate1H93( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1H93( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H93( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H93( ) ;
            AfterConfirm1H93( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H93( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001H10 */
                  pr_datastore1.execute(8, new Object[] {A461repid, A460sestoken});
                  pr_datastore1.close(8);
                  pr_datastore1.SmartCacheProvider.SetUpdated("session");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound93 == 0 )
                        {
                           InitAll1H93( ) ;
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
                        ResetCaption1H0( ) ;
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1H93( ) ;
         Gx_mode = sMode93;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1H93( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1H93( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H93( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_gamsession",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_gamsession",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1H93( )
      {
         /* Using cursor T001H11 */
         pr_datastore1.execute(9);
         RcdFound93 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound93 = 1;
            A461repid = T001H11_A461repid[0];
            AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            A460sestoken = T001H11_A460sestoken[0];
            AssignAttri("", false, "A460sestoken", A460sestoken);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1H93( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound93 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound93 = 1;
            A461repid = T001H11_A461repid[0];
            AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
            A460sestoken = T001H11_A460sestoken[0];
            AssignAttri("", false, "A460sestoken", A460sestoken);
         }
      }

      protected void ScanEnd1H93( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm1H93( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H93( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H93( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H93( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H93( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H93( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H93( )
      {
         edtrepid_Enabled = 0;
         AssignProp("", false, edtrepid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtrepid_Enabled), 5, 0), true);
         edtsestoken_Enabled = 0;
         AssignProp("", false, edtsestoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestoken_Enabled), 5, 0), true);
         edtsesdate_Enabled = 0;
         AssignProp("", false, edtsesdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesdate_Enabled), 5, 0), true);
         edtsessts_Enabled = 0;
         AssignProp("", false, edtsessts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsessts_Enabled), 5, 0), true);
         edtsestype_Enabled = 0;
         AssignProp("", false, edtsestype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestype_Enabled), 5, 0), true);
         edtsesurl_Enabled = 0;
         AssignProp("", false, edtsesurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesurl_Enabled), 5, 0), true);
         edtsesipadd_Enabled = 0;
         AssignProp("", false, edtsesipadd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesipadd_Enabled), 5, 0), true);
         edtopesysid_Enabled = 0;
         AssignProp("", false, edtopesysid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtopesysid_Enabled), 5, 0), true);
         edtseslastacc_Enabled = 0;
         AssignProp("", false, edtseslastacc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslastacc_Enabled), 5, 0), true);
         edtsestimeout_Enabled = 0;
         AssignProp("", false, edtsestimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestimeout_Enabled), 5, 0), true);
         edtseslogatt_Enabled = 0;
         AssignProp("", false, edtseslogatt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogatt_Enabled), 5, 0), true);
         edtseslogdate_Enabled = 0;
         AssignProp("", false, edtseslogdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogdate_Enabled), 5, 0), true);
         edtsesshareddata_Enabled = 0;
         AssignProp("", false, edtsesshareddata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesshareddata_Enabled), 5, 0), true);
         edtsesenddate_Enabled = 0;
         AssignProp("", false, edtsesenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesenddate_Enabled), 5, 0), true);
         chksesreload.Enabled = 0;
         AssignProp("", false, chksesreload_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chksesreload.Enabled), 5, 0), true);
         edtbrwid_Enabled = 0;
         AssignProp("", false, edtbrwid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtbrwid_Enabled), 5, 0), true);
         edtseslasturl_Enabled = 0;
         AssignProp("", false, edtseslasturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslasturl_Enabled), 5, 0), true);
         edtseslogin_Enabled = 0;
         AssignProp("", false, edtseslogin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogin_Enabled), 5, 0), true);
         edtsesexttoken_Enabled = 0;
         AssignProp("", false, edtsesexttoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken_Enabled), 5, 0), true);
         edtuserguid_Enabled = 0;
         AssignProp("", false, edtuserguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtuserguid_Enabled), 5, 0), true);
         edtsesapptokenexp_Enabled = 0;
         AssignProp("", false, edtsesapptokenexp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesapptokenexp_Enabled), 5, 0), true);
         edtsesrefreshtoken_Enabled = 0;
         AssignProp("", false, edtsesrefreshtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesrefreshtoken_Enabled), 5, 0), true);
         edtsesappid_Enabled = 0;
         AssignProp("", false, edtsesappid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesappid_Enabled), 5, 0), true);
         edtsesdeviceid_Enabled = 0;
         AssignProp("", false, edtsesdeviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesdeviceid_Enabled), 5, 0), true);
         edtsesexttoken2_Enabled = 0;
         AssignProp("", false, edtsesexttoken2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken2_Enabled), 5, 0), true);
         edtsesauttypename_Enabled = 0;
         AssignProp("", false, edtsesauttypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesauttypename_Enabled), 5, 0), true);
         edtsesoauthtokenmaxrenew_Enabled = 0;
         AssignProp("", false, edtsesoauthtokenmaxrenew_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthtokenmaxrenew_Enabled), 5, 0), true);
         edtsesoauthtokenexpires_Enabled = 0;
         AssignProp("", false, edtsesoauthtokenexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthtokenexpires_Enabled), 5, 0), true);
         edtsesoauthscope_Enabled = 0;
         AssignProp("", false, edtsesoauthscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthscope_Enabled), 5, 0), true);
         edtsesexttoken3_Enabled = 0;
         AssignProp("", false, edtsesexttoken3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken3_Enabled), 5, 0), true);
         edtsesexttokenexpires_Enabled = 0;
         AssignProp("", false, edtsesexttokenexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttokenexpires_Enabled), 5, 0), true);
         edtsesexttokenrefresh_Enabled = 0;
         AssignProp("", false, edtsesexttokenrefresh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttokenrefresh_Enabled), 5, 0), true);
         edtsesjson_Enabled = 0;
         AssignProp("", false, edtsesjson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesjson_Enabled), 5, 0), true);
         edtsesidtoken_Enabled = 0;
         AssignProp("", false, edtsesidtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesidtoken_Enabled), 5, 0), true);
         edtsesotp_Enabled = 0;
         AssignProp("", false, edtsesotp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesotp_Enabled), 5, 0), true);
         edtsesotpexpire_Enabled = 0;
         AssignProp("", false, edtsesotpexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesotpexpire_Enabled), 5, 0), true);
         chksesendedbyotherlogin.Enabled = 0;
         AssignProp("", false, chksesendedbyotherlogin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chksesendedbyotherlogin.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1H93( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1H0( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_gamsession.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z461repid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z461repid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z460sestoken", StringUtil.RTrim( Z460sestoken));
         GxWebStd.gx_hidden_field( context, "Z469sesdate", context.localUtil.TToC( Z469sesdate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z462sessts", StringUtil.RTrim( Z462sessts));
         GxWebStd.gx_hidden_field( context, "Z463sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z463sestype), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z473sesurl", Z473sesurl);
         GxWebStd.gx_hidden_field( context, "Z474sesipadd", StringUtil.RTrim( Z474sesipadd));
         GxWebStd.gx_hidden_field( context, "Z466opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466opesysid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z475seslastacc", context.localUtil.TToC( Z475seslastacc, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z476sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z476sestimeout), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z477seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z477seslogatt), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z478seslogdate", context.localUtil.TToC( Z478seslogdate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z480sesenddate", context.localUtil.TToC( Z480sesenddate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z481sesreload", Z481sesreload);
         GxWebStd.gx_hidden_field( context, "Z472brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z472brwid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z482seslasturl", Z482seslasturl);
         GxWebStd.gx_hidden_field( context, "Z483seslogin", Z483seslogin);
         GxWebStd.gx_hidden_field( context, "Z467sesexttoken", StringUtil.RTrim( Z467sesexttoken));
         GxWebStd.gx_hidden_field( context, "Z468userguid", StringUtil.RTrim( Z468userguid));
         GxWebStd.gx_hidden_field( context, "Z484sesapptokenexp", context.localUtil.TToC( Z484sesapptokenexp, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z464sesrefreshtoken", StringUtil.RTrim( Z464sesrefreshtoken));
         GxWebStd.gx_hidden_field( context, "Z465sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465sesappid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z485sesdeviceid", StringUtil.RTrim( Z485sesdeviceid));
         GxWebStd.gx_hidden_field( context, "Z486sesexttoken2", Z486sesexttoken2);
         GxWebStd.gx_hidden_field( context, "Z470sesauttypename", StringUtil.RTrim( Z470sesauttypename));
         GxWebStd.gx_hidden_field( context, "Z487sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487sesoauthtokenmaxrenew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z488sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488sesoauthtokenexpires), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z489sesoauthscope", Z489sesoauthscope);
         GxWebStd.gx_hidden_field( context, "Z491sesexttokenexpires", context.localUtil.TToC( Z491sesexttokenexpires, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z492sesexttokenrefresh", Z492sesexttokenrefresh);
         GxWebStd.gx_hidden_field( context, "Z494sesidtoken", Z494sesidtoken);
         GxWebStd.gx_hidden_field( context, "Z471sesotp", Z471sesotp);
         GxWebStd.gx_hidden_field( context, "Z495sesotpexpire", context.localUtil.TToC( Z495sesotpexpire, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z496sesendedbyotherlogin", Z496sesendedbyotherlogin);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("trn_gamsession.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_GamSession" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Gam Session", "") ;
      }

      protected void InitializeNonKey1H93( )
      {
         A469sesdate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A462sessts = "";
         AssignAttri("", false, "A462sessts", A462sessts);
         A463sestype = 0;
         AssignAttri("", false, "A463sestype", StringUtil.LTrimStr( (decimal)(A463sestype), 4, 0));
         A473sesurl = "";
         AssignAttri("", false, "A473sesurl", A473sesurl);
         A474sesipadd = "";
         AssignAttri("", false, "A474sesipadd", A474sesipadd);
         A466opesysid = 0;
         AssignAttri("", false, "A466opesysid", StringUtil.LTrimStr( (decimal)(A466opesysid), 4, 0));
         A475seslastacc = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A476sestimeout = 0;
         AssignAttri("", false, "A476sestimeout", StringUtil.LTrimStr( (decimal)(A476sestimeout), 4, 0));
         A477seslogatt = 0;
         AssignAttri("", false, "A477seslogatt", StringUtil.LTrimStr( (decimal)(A477seslogatt), 9, 0));
         A478seslogdate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A479sesshareddata = "";
         AssignAttri("", false, "A479sesshareddata", A479sesshareddata);
         A480sesenddate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A481sesreload = false;
         AssignAttri("", false, "A481sesreload", A481sesreload);
         A472brwid = 0;
         AssignAttri("", false, "A472brwid", StringUtil.LTrimStr( (decimal)(A472brwid), 4, 0));
         A482seslasturl = "";
         AssignAttri("", false, "A482seslasturl", A482seslasturl);
         A483seslogin = "";
         AssignAttri("", false, "A483seslogin", A483seslogin);
         A467sesexttoken = "";
         AssignAttri("", false, "A467sesexttoken", A467sesexttoken);
         A468userguid = "";
         AssignAttri("", false, "A468userguid", A468userguid);
         A484sesapptokenexp = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A464sesrefreshtoken = "";
         AssignAttri("", false, "A464sesrefreshtoken", A464sesrefreshtoken);
         A465sesappid = 0;
         AssignAttri("", false, "A465sesappid", StringUtil.LTrimStr( (decimal)(A465sesappid), 18, 0));
         A485sesdeviceid = "";
         AssignAttri("", false, "A485sesdeviceid", A485sesdeviceid);
         A486sesexttoken2 = "";
         AssignAttri("", false, "A486sesexttoken2", A486sesexttoken2);
         A470sesauttypename = "";
         AssignAttri("", false, "A470sesauttypename", A470sesauttypename);
         A487sesoauthtokenmaxrenew = 0;
         AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A487sesoauthtokenmaxrenew), 4, 0));
         A488sesoauthtokenexpires = 0;
         AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A488sesoauthtokenexpires), 9, 0));
         A489sesoauthscope = "";
         AssignAttri("", false, "A489sesoauthscope", A489sesoauthscope);
         A490sesexttoken3 = "";
         AssignAttri("", false, "A490sesexttoken3", A490sesexttoken3);
         A491sesexttokenexpires = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A492sesexttokenrefresh = "";
         AssignAttri("", false, "A492sesexttokenrefresh", A492sesexttokenrefresh);
         A493sesjson = "";
         AssignAttri("", false, "A493sesjson", A493sesjson);
         A494sesidtoken = "";
         AssignAttri("", false, "A494sesidtoken", A494sesidtoken);
         A471sesotp = "";
         AssignAttri("", false, "A471sesotp", A471sesotp);
         A495sesotpexpire = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A496sesendedbyotherlogin = false;
         AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
         Z469sesdate = (DateTime)(DateTime.MinValue);
         Z462sessts = "";
         Z463sestype = 0;
         Z473sesurl = "";
         Z474sesipadd = "";
         Z466opesysid = 0;
         Z475seslastacc = (DateTime)(DateTime.MinValue);
         Z476sestimeout = 0;
         Z477seslogatt = 0;
         Z478seslogdate = (DateTime)(DateTime.MinValue);
         Z480sesenddate = (DateTime)(DateTime.MinValue);
         Z481sesreload = false;
         Z472brwid = 0;
         Z482seslasturl = "";
         Z483seslogin = "";
         Z467sesexttoken = "";
         Z468userguid = "";
         Z484sesapptokenexp = (DateTime)(DateTime.MinValue);
         Z464sesrefreshtoken = "";
         Z465sesappid = 0;
         Z485sesdeviceid = "";
         Z486sesexttoken2 = "";
         Z470sesauttypename = "";
         Z487sesoauthtokenmaxrenew = 0;
         Z488sesoauthtokenexpires = 0;
         Z489sesoauthscope = "";
         Z491sesexttokenexpires = (DateTime)(DateTime.MinValue);
         Z492sesexttokenrefresh = "";
         Z494sesidtoken = "";
         Z471sesotp = "";
         Z495sesotpexpire = (DateTime)(DateTime.MinValue);
         Z496sesendedbyotherlogin = false;
      }

      protected void InitAll1H93( )
      {
         A461repid = 0;
         AssignAttri("", false, "A461repid", StringUtil.LTrimStr( (decimal)(A461repid), 9, 0));
         A460sestoken = "";
         AssignAttri("", false, "A460sestoken", A460sestoken);
         InitializeNonKey1H93( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112115434533", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("trn_gamsession.js", "?2024112115434533", false, true);
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
         edtrepid_Internalname = "REPID";
         edtsestoken_Internalname = "SESTOKEN";
         edtsesdate_Internalname = "SESDATE";
         edtsessts_Internalname = "SESSTS";
         edtsestype_Internalname = "SESTYPE";
         edtsesurl_Internalname = "SESURL";
         edtsesipadd_Internalname = "SESIPADD";
         edtopesysid_Internalname = "OPESYSID";
         edtseslastacc_Internalname = "SESLASTACC";
         edtsestimeout_Internalname = "SESTIMEOUT";
         edtseslogatt_Internalname = "SESLOGATT";
         edtseslogdate_Internalname = "SESLOGDATE";
         edtsesshareddata_Internalname = "SESSHAREDDATA";
         edtsesenddate_Internalname = "SESENDDATE";
         chksesreload_Internalname = "SESRELOAD";
         edtbrwid_Internalname = "BRWID";
         edtseslasturl_Internalname = "SESLASTURL";
         edtseslogin_Internalname = "SESLOGIN";
         edtsesexttoken_Internalname = "SESEXTTOKEN";
         edtuserguid_Internalname = "USERGUID";
         edtsesapptokenexp_Internalname = "SESAPPTOKENEXP";
         edtsesrefreshtoken_Internalname = "SESREFRESHTOKEN";
         edtsesappid_Internalname = "SESAPPID";
         edtsesdeviceid_Internalname = "SESDEVICEID";
         edtsesexttoken2_Internalname = "SESEXTTOKEN2";
         edtsesauttypename_Internalname = "SESAUTTYPENAME";
         edtsesoauthtokenmaxrenew_Internalname = "SESOAUTHTOKENMAXRENEW";
         edtsesoauthtokenexpires_Internalname = "SESOAUTHTOKENEXPIRES";
         edtsesoauthscope_Internalname = "SESOAUTHSCOPE";
         edtsesexttoken3_Internalname = "SESEXTTOKEN3";
         edtsesexttokenexpires_Internalname = "SESEXTTOKENEXPIRES";
         edtsesexttokenrefresh_Internalname = "SESEXTTOKENREFRESH";
         edtsesjson_Internalname = "SESJSON";
         edtsesidtoken_Internalname = "SESIDTOKEN";
         edtsesotp_Internalname = "SESOTP";
         edtsesotpexpire_Internalname = "SESOTPEXPIRE";
         chksesendedbyotherlogin_Internalname = "SESENDEDBYOTHERLOGIN";
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
         Form.Caption = context.GetMessage( "Trn_Gam Session", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chksesendedbyotherlogin.Enabled = 1;
         edtsesotpexpire_Jsonclick = "";
         edtsesotpexpire_Enabled = 1;
         edtsesotp_Enabled = 1;
         edtsesidtoken_Enabled = 1;
         edtsesjson_Enabled = 1;
         edtsesexttokenrefresh_Enabled = 1;
         edtsesexttokenexpires_Jsonclick = "";
         edtsesexttokenexpires_Enabled = 1;
         edtsesexttoken3_Enabled = 1;
         edtsesoauthscope_Enabled = 1;
         edtsesoauthtokenexpires_Jsonclick = "";
         edtsesoauthtokenexpires_Enabled = 1;
         edtsesoauthtokenmaxrenew_Jsonclick = "";
         edtsesoauthtokenmaxrenew_Enabled = 1;
         edtsesauttypename_Jsonclick = "";
         edtsesauttypename_Enabled = 1;
         edtsesexttoken2_Enabled = 1;
         edtsesdeviceid_Jsonclick = "";
         edtsesdeviceid_Enabled = 1;
         edtsesappid_Jsonclick = "";
         edtsesappid_Enabled = 1;
         edtsesrefreshtoken_Jsonclick = "";
         edtsesrefreshtoken_Enabled = 1;
         edtsesapptokenexp_Jsonclick = "";
         edtsesapptokenexp_Enabled = 1;
         edtuserguid_Jsonclick = "";
         edtuserguid_Enabled = 1;
         edtsesexttoken_Jsonclick = "";
         edtsesexttoken_Enabled = 1;
         edtseslogin_Enabled = 1;
         edtseslasturl_Enabled = 1;
         edtbrwid_Jsonclick = "";
         edtbrwid_Enabled = 1;
         chksesreload.Enabled = 1;
         edtsesenddate_Jsonclick = "";
         edtsesenddate_Enabled = 1;
         edtsesshareddata_Enabled = 1;
         edtseslogdate_Jsonclick = "";
         edtseslogdate_Enabled = 1;
         edtseslogatt_Jsonclick = "";
         edtseslogatt_Enabled = 1;
         edtsestimeout_Jsonclick = "";
         edtsestimeout_Enabled = 1;
         edtseslastacc_Jsonclick = "";
         edtseslastacc_Enabled = 1;
         edtopesysid_Jsonclick = "";
         edtopesysid_Enabled = 1;
         edtsesipadd_Jsonclick = "";
         edtsesipadd_Enabled = 1;
         edtsesurl_Enabled = 1;
         edtsestype_Jsonclick = "";
         edtsestype_Enabled = 1;
         edtsessts_Jsonclick = "";
         edtsessts_Enabled = 1;
         edtsesdate_Jsonclick = "";
         edtsesdate_Enabled = 1;
         edtsestoken_Jsonclick = "";
         edtsestoken_Enabled = 1;
         edtrepid_Jsonclick = "";
         edtrepid_Enabled = 1;
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
         chksesreload.Name = "SESRELOAD";
         chksesreload.WebTags = "";
         chksesreload.Caption = context.GetMessage( "sesreload", "");
         AssignProp("", false, chksesreload_Internalname, "TitleCaption", chksesreload.Caption, true);
         chksesreload.CheckedValue = "false";
         A481sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A481sesreload));
         AssignAttri("", false, "A481sesreload", A481sesreload);
         chksesendedbyotherlogin.Name = "SESENDEDBYOTHERLOGIN";
         chksesendedbyotherlogin.WebTags = "";
         chksesendedbyotherlogin.Caption = context.GetMessage( "sesendedbyotherlogin", "");
         AssignProp("", false, chksesendedbyotherlogin_Internalname, "TitleCaption", chksesendedbyotherlogin.Caption, true);
         chksesendedbyotherlogin.CheckedValue = "false";
         A496sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A496sesendedbyotherlogin));
         AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtsesdate_Internalname;
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

      public void Valid_Sestoken( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A481sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A481sesreload));
         A496sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A496sesendedbyotherlogin));
         /*  Sending validation outputs */
         AssignAttri("", false, "A469sesdate", context.localUtil.TToC( A469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A462sessts", StringUtil.RTrim( A462sessts));
         AssignAttri("", false, "A463sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(A463sestype), 4, 0, ".", "")));
         AssignAttri("", false, "A473sesurl", A473sesurl);
         AssignAttri("", false, "A474sesipadd", StringUtil.RTrim( A474sesipadd));
         AssignAttri("", false, "A466opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A466opesysid), 4, 0, ".", "")));
         AssignAttri("", false, "A475seslastacc", context.localUtil.TToC( A475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A476sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(A476sestimeout), 4, 0, ".", "")));
         AssignAttri("", false, "A477seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(A477seslogatt), 9, 0, ".", "")));
         AssignAttri("", false, "A478seslogdate", context.localUtil.TToC( A478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A479sesshareddata", A479sesshareddata);
         AssignAttri("", false, "A480sesenddate", context.localUtil.TToC( A480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A481sesreload", A481sesreload);
         AssignAttri("", false, "A472brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A472brwid), 4, 0, ".", "")));
         AssignAttri("", false, "A482seslasturl", A482seslasturl);
         AssignAttri("", false, "A483seslogin", A483seslogin);
         AssignAttri("", false, "A467sesexttoken", StringUtil.RTrim( A467sesexttoken));
         AssignAttri("", false, "A468userguid", StringUtil.RTrim( A468userguid));
         AssignAttri("", false, "A484sesapptokenexp", context.localUtil.TToC( A484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A464sesrefreshtoken", StringUtil.RTrim( A464sesrefreshtoken));
         AssignAttri("", false, "A465sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A465sesappid), 18, 0, ".", "")));
         AssignAttri("", false, "A485sesdeviceid", StringUtil.RTrim( A485sesdeviceid));
         AssignAttri("", false, "A486sesexttoken2", A486sesexttoken2);
         AssignAttri("", false, "A470sesauttypename", StringUtil.RTrim( A470sesauttypename));
         AssignAttri("", false, "A487sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(A487sesoauthtokenmaxrenew), 4, 0, ".", "")));
         AssignAttri("", false, "A488sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(A488sesoauthtokenexpires), 9, 0, ".", "")));
         AssignAttri("", false, "A489sesoauthscope", A489sesoauthscope);
         AssignAttri("", false, "A490sesexttoken3", A490sesexttoken3);
         AssignAttri("", false, "A491sesexttokenexpires", context.localUtil.TToC( A491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A492sesexttokenrefresh", A492sesexttokenrefresh);
         AssignAttri("", false, "A493sesjson", A493sesjson);
         AssignAttri("", false, "A494sesidtoken", A494sesidtoken);
         AssignAttri("", false, "A471sesotp", A471sesotp);
         AssignAttri("", false, "A495sesotpexpire", context.localUtil.TToC( A495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A496sesendedbyotherlogin", A496sesendedbyotherlogin);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z461repid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z461repid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z460sestoken", StringUtil.RTrim( Z460sestoken));
         GxWebStd.gx_hidden_field( context, "Z469sesdate", context.localUtil.TToC( Z469sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z462sessts", StringUtil.RTrim( Z462sessts));
         GxWebStd.gx_hidden_field( context, "Z463sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z463sestype), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z473sesurl", Z473sesurl);
         GxWebStd.gx_hidden_field( context, "Z474sesipadd", StringUtil.RTrim( Z474sesipadd));
         GxWebStd.gx_hidden_field( context, "Z466opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466opesysid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z475seslastacc", context.localUtil.TToC( Z475seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z476sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z476sestimeout), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z477seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z477seslogatt), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z478seslogdate", context.localUtil.TToC( Z478seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z479sesshareddata", Z479sesshareddata);
         GxWebStd.gx_hidden_field( context, "Z480sesenddate", context.localUtil.TToC( Z480sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z481sesreload", StringUtil.BoolToStr( Z481sesreload));
         GxWebStd.gx_hidden_field( context, "Z472brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z472brwid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z482seslasturl", Z482seslasturl);
         GxWebStd.gx_hidden_field( context, "Z483seslogin", Z483seslogin);
         GxWebStd.gx_hidden_field( context, "Z467sesexttoken", StringUtil.RTrim( Z467sesexttoken));
         GxWebStd.gx_hidden_field( context, "Z468userguid", StringUtil.RTrim( Z468userguid));
         GxWebStd.gx_hidden_field( context, "Z484sesapptokenexp", context.localUtil.TToC( Z484sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z464sesrefreshtoken", StringUtil.RTrim( Z464sesrefreshtoken));
         GxWebStd.gx_hidden_field( context, "Z465sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465sesappid), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z485sesdeviceid", StringUtil.RTrim( Z485sesdeviceid));
         GxWebStd.gx_hidden_field( context, "Z486sesexttoken2", Z486sesexttoken2);
         GxWebStd.gx_hidden_field( context, "Z470sesauttypename", StringUtil.RTrim( Z470sesauttypename));
         GxWebStd.gx_hidden_field( context, "Z487sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487sesoauthtokenmaxrenew), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z488sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488sesoauthtokenexpires), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z489sesoauthscope", Z489sesoauthscope);
         GxWebStd.gx_hidden_field( context, "Z490sesexttoken3", Z490sesexttoken3);
         GxWebStd.gx_hidden_field( context, "Z491sesexttokenexpires", context.localUtil.TToC( Z491sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z492sesexttokenrefresh", Z492sesexttokenrefresh);
         GxWebStd.gx_hidden_field( context, "Z493sesjson", Z493sesjson);
         GxWebStd.gx_hidden_field( context, "Z494sesidtoken", Z494sesidtoken);
         GxWebStd.gx_hidden_field( context, "Z471sesotp", Z471sesotp);
         GxWebStd.gx_hidden_field( context, "Z495sesotpexpire", context.localUtil.TToC( Z495sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z496sesendedbyotherlogin", StringUtil.BoolToStr( Z496sesendedbyotherlogin));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("VALID_REPID","""{"handler":"Valid_Repid","iparms":[{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("VALID_REPID",""","oparms":[{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("VALID_SESTOKEN","""{"handler":"Valid_Sestoken","iparms":[{"av":"A461repid","fld":"REPID","pic":"ZZZZZZZZ9"},{"av":"A460sestoken","fld":"SESTOKEN"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("VALID_SESTOKEN",""","oparms":[{"av":"A469sesdate","fld":"SESDATE","pic":"99/99/9999 99:99:99"},{"av":"A462sessts","fld":"SESSTS"},{"av":"A463sestype","fld":"SESTYPE","pic":"ZZZ9"},{"av":"A473sesurl","fld":"SESURL"},{"av":"A474sesipadd","fld":"SESIPADD"},{"av":"A466opesysid","fld":"OPESYSID","pic":"ZZZ9"},{"av":"A475seslastacc","fld":"SESLASTACC","pic":"99/99/9999 99:99:99"},{"av":"A476sestimeout","fld":"SESTIMEOUT","pic":"ZZZ9"},{"av":"A477seslogatt","fld":"SESLOGATT","pic":"ZZZZZZZZ9"},{"av":"A478seslogdate","fld":"SESLOGDATE","pic":"99/99/9999 99:99:99"},{"av":"A479sesshareddata","fld":"SESSHAREDDATA"},{"av":"A480sesenddate","fld":"SESENDDATE","pic":"99/99/9999 99:99:99"},{"av":"A472brwid","fld":"BRWID","pic":"ZZZ9"},{"av":"A482seslasturl","fld":"SESLASTURL"},{"av":"A483seslogin","fld":"SESLOGIN"},{"av":"A467sesexttoken","fld":"SESEXTTOKEN"},{"av":"A468userguid","fld":"USERGUID"},{"av":"A484sesapptokenexp","fld":"SESAPPTOKENEXP","pic":"99/99/9999 99:99:99"},{"av":"A464sesrefreshtoken","fld":"SESREFRESHTOKEN"},{"av":"A465sesappid","fld":"SESAPPID","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"A485sesdeviceid","fld":"SESDEVICEID"},{"av":"A486sesexttoken2","fld":"SESEXTTOKEN2"},{"av":"A470sesauttypename","fld":"SESAUTTYPENAME"},{"av":"A487sesoauthtokenmaxrenew","fld":"SESOAUTHTOKENMAXRENEW","pic":"ZZZ9"},{"av":"A488sesoauthtokenexpires","fld":"SESOAUTHTOKENEXPIRES","pic":"ZZZZZZZZ9"},{"av":"A489sesoauthscope","fld":"SESOAUTHSCOPE"},{"av":"A490sesexttoken3","fld":"SESEXTTOKEN3"},{"av":"A491sesexttokenexpires","fld":"SESEXTTOKENEXPIRES","pic":"99/99/9999 99:99:99"},{"av":"A492sesexttokenrefresh","fld":"SESEXTTOKENREFRESH"},{"av":"A493sesjson","fld":"SESJSON"},{"av":"A494sesidtoken","fld":"SESIDTOKEN"},{"av":"A471sesotp","fld":"SESOTP"},{"av":"A495sesotpexpire","fld":"SESOTPEXPIRE","pic":"99/99/9999 99:99:99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z461repid"},{"av":"Z460sestoken"},{"av":"Z469sesdate"},{"av":"Z462sessts"},{"av":"Z463sestype"},{"av":"Z473sesurl"},{"av":"Z474sesipadd"},{"av":"Z466opesysid"},{"av":"Z475seslastacc"},{"av":"Z476sestimeout"},{"av":"Z477seslogatt"},{"av":"Z478seslogdate"},{"av":"Z479sesshareddata"},{"av":"Z480sesenddate"},{"av":"Z481sesreload"},{"av":"Z472brwid"},{"av":"Z482seslasturl"},{"av":"Z483seslogin"},{"av":"Z467sesexttoken"},{"av":"Z468userguid"},{"av":"Z484sesapptokenexp"},{"av":"Z464sesrefreshtoken"},{"av":"Z465sesappid"},{"av":"Z485sesdeviceid"},{"av":"Z486sesexttoken2"},{"av":"Z470sesauttypename"},{"av":"Z487sesoauthtokenmaxrenew"},{"av":"Z488sesoauthtokenexpires"},{"av":"Z489sesoauthscope"},{"av":"Z490sesexttoken3"},{"av":"Z491sesexttokenexpires"},{"av":"Z492sesexttokenrefresh"},{"av":"Z493sesjson"},{"av":"Z494sesidtoken"},{"av":"Z471sesotp"},{"av":"Z495sesotpexpire"},{"av":"Z496sesendedbyotherlogin"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A481sesreload","fld":"SESRELOAD"},{"av":"A496sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
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
         pr_datastore1.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z460sestoken = "";
         Z469sesdate = (DateTime)(DateTime.MinValue);
         Z462sessts = "";
         Z473sesurl = "";
         Z474sesipadd = "";
         Z475seslastacc = (DateTime)(DateTime.MinValue);
         Z478seslogdate = (DateTime)(DateTime.MinValue);
         Z480sesenddate = (DateTime)(DateTime.MinValue);
         Z482seslasturl = "";
         Z483seslogin = "";
         Z467sesexttoken = "";
         Z468userguid = "";
         Z484sesapptokenexp = (DateTime)(DateTime.MinValue);
         Z464sesrefreshtoken = "";
         Z485sesdeviceid = "";
         Z486sesexttoken2 = "";
         Z470sesauttypename = "";
         Z489sesoauthscope = "";
         Z491sesexttokenexpires = (DateTime)(DateTime.MinValue);
         Z492sesexttokenrefresh = "";
         Z494sesidtoken = "";
         Z471sesotp = "";
         Z495sesotpexpire = (DateTime)(DateTime.MinValue);
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
         A460sestoken = "";
         A469sesdate = (DateTime)(DateTime.MinValue);
         A462sessts = "";
         A473sesurl = "";
         A474sesipadd = "";
         A475seslastacc = (DateTime)(DateTime.MinValue);
         A478seslogdate = (DateTime)(DateTime.MinValue);
         A479sesshareddata = "";
         A480sesenddate = (DateTime)(DateTime.MinValue);
         A482seslasturl = "";
         A483seslogin = "";
         A467sesexttoken = "";
         A468userguid = "";
         A484sesapptokenexp = (DateTime)(DateTime.MinValue);
         A464sesrefreshtoken = "";
         A485sesdeviceid = "";
         A486sesexttoken2 = "";
         A470sesauttypename = "";
         A489sesoauthscope = "";
         A490sesexttoken3 = "";
         A491sesexttokenexpires = (DateTime)(DateTime.MinValue);
         A492sesexttokenrefresh = "";
         A493sesjson = "";
         A494sesidtoken = "";
         A471sesotp = "";
         A495sesotpexpire = (DateTime)(DateTime.MinValue);
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
         Z479sesshareddata = "";
         Z490sesexttoken3 = "";
         Z493sesjson = "";
         T001H4_A461repid = new int[1] ;
         T001H4_A460sestoken = new string[] {""} ;
         T001H4_A469sesdate = new DateTime[] {DateTime.MinValue} ;
         T001H4_A462sessts = new string[] {""} ;
         T001H4_A463sestype = new short[1] ;
         T001H4_A473sesurl = new string[] {""} ;
         T001H4_A474sesipadd = new string[] {""} ;
         T001H4_A466opesysid = new short[1] ;
         T001H4_A475seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001H4_A476sestimeout = new short[1] ;
         T001H4_A477seslogatt = new int[1] ;
         T001H4_A478seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001H4_A479sesshareddata = new string[] {""} ;
         T001H4_A480sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001H4_A481sesreload = new bool[] {false} ;
         T001H4_A472brwid = new short[1] ;
         T001H4_A482seslasturl = new string[] {""} ;
         T001H4_A483seslogin = new string[] {""} ;
         T001H4_A467sesexttoken = new string[] {""} ;
         T001H4_A468userguid = new string[] {""} ;
         T001H4_A484sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001H4_A464sesrefreshtoken = new string[] {""} ;
         T001H4_A465sesappid = new long[1] ;
         T001H4_A485sesdeviceid = new string[] {""} ;
         T001H4_A486sesexttoken2 = new string[] {""} ;
         T001H4_A470sesauttypename = new string[] {""} ;
         T001H4_A487sesoauthtokenmaxrenew = new short[1] ;
         T001H4_A488sesoauthtokenexpires = new int[1] ;
         T001H4_A489sesoauthscope = new string[] {""} ;
         T001H4_A490sesexttoken3 = new string[] {""} ;
         T001H4_A491sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001H4_A492sesexttokenrefresh = new string[] {""} ;
         T001H4_A493sesjson = new string[] {""} ;
         T001H4_A494sesidtoken = new string[] {""} ;
         T001H4_A471sesotp = new string[] {""} ;
         T001H4_A495sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001H4_A496sesendedbyotherlogin = new bool[] {false} ;
         T001H5_A461repid = new int[1] ;
         T001H5_A460sestoken = new string[] {""} ;
         T001H3_A461repid = new int[1] ;
         T001H3_A460sestoken = new string[] {""} ;
         T001H3_A469sesdate = new DateTime[] {DateTime.MinValue} ;
         T001H3_A462sessts = new string[] {""} ;
         T001H3_A463sestype = new short[1] ;
         T001H3_A473sesurl = new string[] {""} ;
         T001H3_A474sesipadd = new string[] {""} ;
         T001H3_A466opesysid = new short[1] ;
         T001H3_A475seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001H3_A476sestimeout = new short[1] ;
         T001H3_A477seslogatt = new int[1] ;
         T001H3_A478seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001H3_A479sesshareddata = new string[] {""} ;
         T001H3_A480sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001H3_A481sesreload = new bool[] {false} ;
         T001H3_A472brwid = new short[1] ;
         T001H3_A482seslasturl = new string[] {""} ;
         T001H3_A483seslogin = new string[] {""} ;
         T001H3_A467sesexttoken = new string[] {""} ;
         T001H3_A468userguid = new string[] {""} ;
         T001H3_A484sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001H3_A464sesrefreshtoken = new string[] {""} ;
         T001H3_A465sesappid = new long[1] ;
         T001H3_A485sesdeviceid = new string[] {""} ;
         T001H3_A486sesexttoken2 = new string[] {""} ;
         T001H3_A470sesauttypename = new string[] {""} ;
         T001H3_A487sesoauthtokenmaxrenew = new short[1] ;
         T001H3_A488sesoauthtokenexpires = new int[1] ;
         T001H3_A489sesoauthscope = new string[] {""} ;
         T001H3_A490sesexttoken3 = new string[] {""} ;
         T001H3_A491sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001H3_A492sesexttokenrefresh = new string[] {""} ;
         T001H3_A493sesjson = new string[] {""} ;
         T001H3_A494sesidtoken = new string[] {""} ;
         T001H3_A471sesotp = new string[] {""} ;
         T001H3_A495sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001H3_A496sesendedbyotherlogin = new bool[] {false} ;
         sMode93 = "";
         T001H6_A461repid = new int[1] ;
         T001H6_A460sestoken = new string[] {""} ;
         T001H7_A461repid = new int[1] ;
         T001H7_A460sestoken = new string[] {""} ;
         T001H2_A461repid = new int[1] ;
         T001H2_A460sestoken = new string[] {""} ;
         T001H2_A469sesdate = new DateTime[] {DateTime.MinValue} ;
         T001H2_A462sessts = new string[] {""} ;
         T001H2_A463sestype = new short[1] ;
         T001H2_A473sesurl = new string[] {""} ;
         T001H2_A474sesipadd = new string[] {""} ;
         T001H2_A466opesysid = new short[1] ;
         T001H2_A475seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001H2_A476sestimeout = new short[1] ;
         T001H2_A477seslogatt = new int[1] ;
         T001H2_A478seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001H2_A479sesshareddata = new string[] {""} ;
         T001H2_A480sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001H2_A481sesreload = new bool[] {false} ;
         T001H2_A472brwid = new short[1] ;
         T001H2_A482seslasturl = new string[] {""} ;
         T001H2_A483seslogin = new string[] {""} ;
         T001H2_A467sesexttoken = new string[] {""} ;
         T001H2_A468userguid = new string[] {""} ;
         T001H2_A484sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001H2_A464sesrefreshtoken = new string[] {""} ;
         T001H2_A465sesappid = new long[1] ;
         T001H2_A485sesdeviceid = new string[] {""} ;
         T001H2_A486sesexttoken2 = new string[] {""} ;
         T001H2_A470sesauttypename = new string[] {""} ;
         T001H2_A487sesoauthtokenmaxrenew = new short[1] ;
         T001H2_A488sesoauthtokenexpires = new int[1] ;
         T001H2_A489sesoauthscope = new string[] {""} ;
         T001H2_A490sesexttoken3 = new string[] {""} ;
         T001H2_A491sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001H2_A492sesexttokenrefresh = new string[] {""} ;
         T001H2_A493sesjson = new string[] {""} ;
         T001H2_A494sesidtoken = new string[] {""} ;
         T001H2_A471sesotp = new string[] {""} ;
         T001H2_A495sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001H2_A496sesendedbyotherlogin = new bool[] {false} ;
         T001H11_A461repid = new int[1] ;
         T001H11_A460sestoken = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ460sestoken = "";
         ZZ469sesdate = (DateTime)(DateTime.MinValue);
         ZZ462sessts = "";
         ZZ473sesurl = "";
         ZZ474sesipadd = "";
         ZZ475seslastacc = (DateTime)(DateTime.MinValue);
         ZZ478seslogdate = (DateTime)(DateTime.MinValue);
         ZZ479sesshareddata = "";
         ZZ480sesenddate = (DateTime)(DateTime.MinValue);
         ZZ482seslasturl = "";
         ZZ483seslogin = "";
         ZZ467sesexttoken = "";
         ZZ468userguid = "";
         ZZ484sesapptokenexp = (DateTime)(DateTime.MinValue);
         ZZ464sesrefreshtoken = "";
         ZZ485sesdeviceid = "";
         ZZ486sesexttoken2 = "";
         ZZ470sesauttypename = "";
         ZZ489sesoauthscope = "";
         ZZ490sesexttoken3 = "";
         ZZ491sesexttokenexpires = (DateTime)(DateTime.MinValue);
         ZZ492sesexttokenrefresh = "";
         ZZ493sesjson = "";
         ZZ494sesidtoken = "";
         ZZ471sesotp = "";
         ZZ495sesotpexpire = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__datastore1(),
            new Object[][] {
                new Object[] {
               T001H2_A461repid, T001H2_A460sestoken, T001H2_A469sesdate, T001H2_A462sessts, T001H2_A463sestype, T001H2_A473sesurl, T001H2_A474sesipadd, T001H2_A466opesysid, T001H2_A475seslastacc, T001H2_A476sestimeout,
               T001H2_A477seslogatt, T001H2_A478seslogdate, T001H2_A479sesshareddata, T001H2_A480sesenddate, T001H2_A481sesreload, T001H2_A472brwid, T001H2_A482seslasturl, T001H2_A483seslogin, T001H2_A467sesexttoken, T001H2_A468userguid,
               T001H2_A484sesapptokenexp, T001H2_A464sesrefreshtoken, T001H2_A465sesappid, T001H2_A485sesdeviceid, T001H2_A486sesexttoken2, T001H2_A470sesauttypename, T001H2_A487sesoauthtokenmaxrenew, T001H2_A488sesoauthtokenexpires, T001H2_A489sesoauthscope, T001H2_A490sesexttoken3,
               T001H2_A491sesexttokenexpires, T001H2_A492sesexttokenrefresh, T001H2_A493sesjson, T001H2_A494sesidtoken, T001H2_A471sesotp, T001H2_A495sesotpexpire, T001H2_A496sesendedbyotherlogin
               }
               , new Object[] {
               T001H3_A461repid, T001H3_A460sestoken, T001H3_A469sesdate, T001H3_A462sessts, T001H3_A463sestype, T001H3_A473sesurl, T001H3_A474sesipadd, T001H3_A466opesysid, T001H3_A475seslastacc, T001H3_A476sestimeout,
               T001H3_A477seslogatt, T001H3_A478seslogdate, T001H3_A479sesshareddata, T001H3_A480sesenddate, T001H3_A481sesreload, T001H3_A472brwid, T001H3_A482seslasturl, T001H3_A483seslogin, T001H3_A467sesexttoken, T001H3_A468userguid,
               T001H3_A484sesapptokenexp, T001H3_A464sesrefreshtoken, T001H3_A465sesappid, T001H3_A485sesdeviceid, T001H3_A486sesexttoken2, T001H3_A470sesauttypename, T001H3_A487sesoauthtokenmaxrenew, T001H3_A488sesoauthtokenexpires, T001H3_A489sesoauthscope, T001H3_A490sesexttoken3,
               T001H3_A491sesexttokenexpires, T001H3_A492sesexttokenrefresh, T001H3_A493sesjson, T001H3_A494sesidtoken, T001H3_A471sesotp, T001H3_A495sesotpexpire, T001H3_A496sesendedbyotherlogin
               }
               , new Object[] {
               T001H4_A461repid, T001H4_A460sestoken, T001H4_A469sesdate, T001H4_A462sessts, T001H4_A463sestype, T001H4_A473sesurl, T001H4_A474sesipadd, T001H4_A466opesysid, T001H4_A475seslastacc, T001H4_A476sestimeout,
               T001H4_A477seslogatt, T001H4_A478seslogdate, T001H4_A479sesshareddata, T001H4_A480sesenddate, T001H4_A481sesreload, T001H4_A472brwid, T001H4_A482seslasturl, T001H4_A483seslogin, T001H4_A467sesexttoken, T001H4_A468userguid,
               T001H4_A484sesapptokenexp, T001H4_A464sesrefreshtoken, T001H4_A465sesappid, T001H4_A485sesdeviceid, T001H4_A486sesexttoken2, T001H4_A470sesauttypename, T001H4_A487sesoauthtokenmaxrenew, T001H4_A488sesoauthtokenexpires, T001H4_A489sesoauthscope, T001H4_A490sesexttoken3,
               T001H4_A491sesexttokenexpires, T001H4_A492sesexttokenrefresh, T001H4_A493sesjson, T001H4_A494sesidtoken, T001H4_A471sesotp, T001H4_A495sesotpexpire, T001H4_A496sesendedbyotherlogin
               }
               , new Object[] {
               T001H5_A461repid, T001H5_A460sestoken
               }
               , new Object[] {
               T001H6_A461repid, T001H6_A460sestoken
               }
               , new Object[] {
               T001H7_A461repid, T001H7_A460sestoken
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001H11_A461repid, T001H11_A460sestoken
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__default(),
            new Object[][] {
            }
         );
      }

      private short Z463sestype ;
      private short Z466opesysid ;
      private short Z476sestimeout ;
      private short Z472brwid ;
      private short Z487sesoauthtokenmaxrenew ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A463sestype ;
      private short A466opesysid ;
      private short A476sestimeout ;
      private short A472brwid ;
      private short A487sesoauthtokenmaxrenew ;
      private short RcdFound93 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ463sestype ;
      private short ZZ466opesysid ;
      private short ZZ476sestimeout ;
      private short ZZ472brwid ;
      private short ZZ487sesoauthtokenmaxrenew ;
      private int Z461repid ;
      private int Z477seslogatt ;
      private int Z488sesoauthtokenexpires ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A461repid ;
      private int edtrepid_Enabled ;
      private int edtsestoken_Enabled ;
      private int edtsesdate_Enabled ;
      private int edtsessts_Enabled ;
      private int edtsestype_Enabled ;
      private int edtsesurl_Enabled ;
      private int edtsesipadd_Enabled ;
      private int edtopesysid_Enabled ;
      private int edtseslastacc_Enabled ;
      private int edtsestimeout_Enabled ;
      private int A477seslogatt ;
      private int edtseslogatt_Enabled ;
      private int edtseslogdate_Enabled ;
      private int edtsesshareddata_Enabled ;
      private int edtsesenddate_Enabled ;
      private int edtbrwid_Enabled ;
      private int edtseslasturl_Enabled ;
      private int edtseslogin_Enabled ;
      private int edtsesexttoken_Enabled ;
      private int edtuserguid_Enabled ;
      private int edtsesapptokenexp_Enabled ;
      private int edtsesrefreshtoken_Enabled ;
      private int edtsesappid_Enabled ;
      private int edtsesdeviceid_Enabled ;
      private int edtsesexttoken2_Enabled ;
      private int edtsesauttypename_Enabled ;
      private int edtsesoauthtokenmaxrenew_Enabled ;
      private int A488sesoauthtokenexpires ;
      private int edtsesoauthtokenexpires_Enabled ;
      private int edtsesoauthscope_Enabled ;
      private int edtsesexttoken3_Enabled ;
      private int edtsesexttokenexpires_Enabled ;
      private int edtsesexttokenrefresh_Enabled ;
      private int edtsesjson_Enabled ;
      private int edtsesidtoken_Enabled ;
      private int edtsesotp_Enabled ;
      private int edtsesotpexpire_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ461repid ;
      private int ZZ477seslogatt ;
      private int ZZ488sesoauthtokenexpires ;
      private long Z465sesappid ;
      private long A465sesappid ;
      private long ZZ465sesappid ;
      private string sPrefix ;
      private string Z460sestoken ;
      private string Z462sessts ;
      private string Z474sesipadd ;
      private string Z467sesexttoken ;
      private string Z468userguid ;
      private string Z464sesrefreshtoken ;
      private string Z485sesdeviceid ;
      private string Z470sesauttypename ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtrepid_Internalname ;
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
      private string edtrepid_Jsonclick ;
      private string edtsestoken_Internalname ;
      private string A460sestoken ;
      private string edtsestoken_Jsonclick ;
      private string edtsesdate_Internalname ;
      private string edtsesdate_Jsonclick ;
      private string edtsessts_Internalname ;
      private string A462sessts ;
      private string edtsessts_Jsonclick ;
      private string edtsestype_Internalname ;
      private string edtsestype_Jsonclick ;
      private string edtsesurl_Internalname ;
      private string edtsesipadd_Internalname ;
      private string A474sesipadd ;
      private string edtsesipadd_Jsonclick ;
      private string edtopesysid_Internalname ;
      private string edtopesysid_Jsonclick ;
      private string edtseslastacc_Internalname ;
      private string edtseslastacc_Jsonclick ;
      private string edtsestimeout_Internalname ;
      private string edtsestimeout_Jsonclick ;
      private string edtseslogatt_Internalname ;
      private string edtseslogatt_Jsonclick ;
      private string edtseslogdate_Internalname ;
      private string edtseslogdate_Jsonclick ;
      private string edtsesshareddata_Internalname ;
      private string edtsesenddate_Internalname ;
      private string edtsesenddate_Jsonclick ;
      private string chksesreload_Internalname ;
      private string edtbrwid_Internalname ;
      private string edtbrwid_Jsonclick ;
      private string edtseslasturl_Internalname ;
      private string edtseslogin_Internalname ;
      private string edtsesexttoken_Internalname ;
      private string A467sesexttoken ;
      private string edtsesexttoken_Jsonclick ;
      private string edtuserguid_Internalname ;
      private string A468userguid ;
      private string edtuserguid_Jsonclick ;
      private string edtsesapptokenexp_Internalname ;
      private string edtsesapptokenexp_Jsonclick ;
      private string edtsesrefreshtoken_Internalname ;
      private string A464sesrefreshtoken ;
      private string edtsesrefreshtoken_Jsonclick ;
      private string edtsesappid_Internalname ;
      private string edtsesappid_Jsonclick ;
      private string edtsesdeviceid_Internalname ;
      private string A485sesdeviceid ;
      private string edtsesdeviceid_Jsonclick ;
      private string edtsesexttoken2_Internalname ;
      private string edtsesauttypename_Internalname ;
      private string A470sesauttypename ;
      private string edtsesauttypename_Jsonclick ;
      private string edtsesoauthtokenmaxrenew_Internalname ;
      private string edtsesoauthtokenmaxrenew_Jsonclick ;
      private string edtsesoauthtokenexpires_Internalname ;
      private string edtsesoauthtokenexpires_Jsonclick ;
      private string edtsesoauthscope_Internalname ;
      private string edtsesexttoken3_Internalname ;
      private string edtsesexttokenexpires_Internalname ;
      private string edtsesexttokenexpires_Jsonclick ;
      private string edtsesexttokenrefresh_Internalname ;
      private string edtsesjson_Internalname ;
      private string edtsesidtoken_Internalname ;
      private string edtsesotp_Internalname ;
      private string edtsesotpexpire_Internalname ;
      private string edtsesotpexpire_Jsonclick ;
      private string chksesendedbyotherlogin_Internalname ;
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
      private string sMode93 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ460sestoken ;
      private string ZZ462sessts ;
      private string ZZ474sesipadd ;
      private string ZZ467sesexttoken ;
      private string ZZ468userguid ;
      private string ZZ464sesrefreshtoken ;
      private string ZZ485sesdeviceid ;
      private string ZZ470sesauttypename ;
      private DateTime Z469sesdate ;
      private DateTime Z475seslastacc ;
      private DateTime Z478seslogdate ;
      private DateTime Z480sesenddate ;
      private DateTime Z484sesapptokenexp ;
      private DateTime Z491sesexttokenexpires ;
      private DateTime Z495sesotpexpire ;
      private DateTime A469sesdate ;
      private DateTime A475seslastacc ;
      private DateTime A478seslogdate ;
      private DateTime A480sesenddate ;
      private DateTime A484sesapptokenexp ;
      private DateTime A491sesexttokenexpires ;
      private DateTime A495sesotpexpire ;
      private DateTime ZZ469sesdate ;
      private DateTime ZZ475seslastacc ;
      private DateTime ZZ478seslogdate ;
      private DateTime ZZ480sesenddate ;
      private DateTime ZZ484sesapptokenexp ;
      private DateTime ZZ491sesexttokenexpires ;
      private DateTime ZZ495sesotpexpire ;
      private bool Z481sesreload ;
      private bool Z496sesendedbyotherlogin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A481sesreload ;
      private bool A496sesendedbyotherlogin ;
      private bool Gx_longc ;
      private bool ZZ481sesreload ;
      private bool ZZ496sesendedbyotherlogin ;
      private string A479sesshareddata ;
      private string A490sesexttoken3 ;
      private string A493sesjson ;
      private string Z479sesshareddata ;
      private string Z490sesexttoken3 ;
      private string Z493sesjson ;
      private string ZZ479sesshareddata ;
      private string ZZ490sesexttoken3 ;
      private string ZZ493sesjson ;
      private string Z473sesurl ;
      private string Z482seslasturl ;
      private string Z483seslogin ;
      private string Z486sesexttoken2 ;
      private string Z489sesoauthscope ;
      private string Z492sesexttokenrefresh ;
      private string Z494sesidtoken ;
      private string Z471sesotp ;
      private string A473sesurl ;
      private string A482seslasturl ;
      private string A483seslogin ;
      private string A486sesexttoken2 ;
      private string A489sesoauthscope ;
      private string A492sesexttokenrefresh ;
      private string A494sesidtoken ;
      private string A471sesotp ;
      private string ZZ473sesurl ;
      private string ZZ482seslasturl ;
      private string ZZ483seslogin ;
      private string ZZ486sesexttoken2 ;
      private string ZZ489sesoauthscope ;
      private string ZZ492sesexttokenrefresh ;
      private string ZZ494sesidtoken ;
      private string ZZ471sesotp ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chksesreload ;
      private GXCheckbox chksesendedbyotherlogin ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T001H4_A461repid ;
      private string[] T001H4_A460sestoken ;
      private DateTime[] T001H4_A469sesdate ;
      private string[] T001H4_A462sessts ;
      private short[] T001H4_A463sestype ;
      private string[] T001H4_A473sesurl ;
      private string[] T001H4_A474sesipadd ;
      private short[] T001H4_A466opesysid ;
      private DateTime[] T001H4_A475seslastacc ;
      private short[] T001H4_A476sestimeout ;
      private int[] T001H4_A477seslogatt ;
      private DateTime[] T001H4_A478seslogdate ;
      private string[] T001H4_A479sesshareddata ;
      private DateTime[] T001H4_A480sesenddate ;
      private bool[] T001H4_A481sesreload ;
      private short[] T001H4_A472brwid ;
      private string[] T001H4_A482seslasturl ;
      private string[] T001H4_A483seslogin ;
      private string[] T001H4_A467sesexttoken ;
      private string[] T001H4_A468userguid ;
      private DateTime[] T001H4_A484sesapptokenexp ;
      private string[] T001H4_A464sesrefreshtoken ;
      private long[] T001H4_A465sesappid ;
      private string[] T001H4_A485sesdeviceid ;
      private string[] T001H4_A486sesexttoken2 ;
      private string[] T001H4_A470sesauttypename ;
      private short[] T001H4_A487sesoauthtokenmaxrenew ;
      private int[] T001H4_A488sesoauthtokenexpires ;
      private string[] T001H4_A489sesoauthscope ;
      private string[] T001H4_A490sesexttoken3 ;
      private DateTime[] T001H4_A491sesexttokenexpires ;
      private string[] T001H4_A492sesexttokenrefresh ;
      private string[] T001H4_A493sesjson ;
      private string[] T001H4_A494sesidtoken ;
      private string[] T001H4_A471sesotp ;
      private DateTime[] T001H4_A495sesotpexpire ;
      private bool[] T001H4_A496sesendedbyotherlogin ;
      private int[] T001H5_A461repid ;
      private string[] T001H5_A460sestoken ;
      private int[] T001H3_A461repid ;
      private string[] T001H3_A460sestoken ;
      private DateTime[] T001H3_A469sesdate ;
      private string[] T001H3_A462sessts ;
      private short[] T001H3_A463sestype ;
      private string[] T001H3_A473sesurl ;
      private string[] T001H3_A474sesipadd ;
      private short[] T001H3_A466opesysid ;
      private DateTime[] T001H3_A475seslastacc ;
      private short[] T001H3_A476sestimeout ;
      private int[] T001H3_A477seslogatt ;
      private DateTime[] T001H3_A478seslogdate ;
      private string[] T001H3_A479sesshareddata ;
      private DateTime[] T001H3_A480sesenddate ;
      private bool[] T001H3_A481sesreload ;
      private short[] T001H3_A472brwid ;
      private string[] T001H3_A482seslasturl ;
      private string[] T001H3_A483seslogin ;
      private string[] T001H3_A467sesexttoken ;
      private string[] T001H3_A468userguid ;
      private DateTime[] T001H3_A484sesapptokenexp ;
      private string[] T001H3_A464sesrefreshtoken ;
      private long[] T001H3_A465sesappid ;
      private string[] T001H3_A485sesdeviceid ;
      private string[] T001H3_A486sesexttoken2 ;
      private string[] T001H3_A470sesauttypename ;
      private short[] T001H3_A487sesoauthtokenmaxrenew ;
      private int[] T001H3_A488sesoauthtokenexpires ;
      private string[] T001H3_A489sesoauthscope ;
      private string[] T001H3_A490sesexttoken3 ;
      private DateTime[] T001H3_A491sesexttokenexpires ;
      private string[] T001H3_A492sesexttokenrefresh ;
      private string[] T001H3_A493sesjson ;
      private string[] T001H3_A494sesidtoken ;
      private string[] T001H3_A471sesotp ;
      private DateTime[] T001H3_A495sesotpexpire ;
      private bool[] T001H3_A496sesendedbyotherlogin ;
      private int[] T001H6_A461repid ;
      private string[] T001H6_A460sestoken ;
      private int[] T001H7_A461repid ;
      private string[] T001H7_A460sestoken ;
      private int[] T001H2_A461repid ;
      private string[] T001H2_A460sestoken ;
      private DateTime[] T001H2_A469sesdate ;
      private string[] T001H2_A462sessts ;
      private short[] T001H2_A463sestype ;
      private string[] T001H2_A473sesurl ;
      private string[] T001H2_A474sesipadd ;
      private short[] T001H2_A466opesysid ;
      private DateTime[] T001H2_A475seslastacc ;
      private short[] T001H2_A476sestimeout ;
      private int[] T001H2_A477seslogatt ;
      private DateTime[] T001H2_A478seslogdate ;
      private string[] T001H2_A479sesshareddata ;
      private DateTime[] T001H2_A480sesenddate ;
      private bool[] T001H2_A481sesreload ;
      private short[] T001H2_A472brwid ;
      private string[] T001H2_A482seslasturl ;
      private string[] T001H2_A483seslogin ;
      private string[] T001H2_A467sesexttoken ;
      private string[] T001H2_A468userguid ;
      private DateTime[] T001H2_A484sesapptokenexp ;
      private string[] T001H2_A464sesrefreshtoken ;
      private long[] T001H2_A465sesappid ;
      private string[] T001H2_A485sesdeviceid ;
      private string[] T001H2_A486sesexttoken2 ;
      private string[] T001H2_A470sesauttypename ;
      private short[] T001H2_A487sesoauthtokenmaxrenew ;
      private int[] T001H2_A488sesoauthtokenexpires ;
      private string[] T001H2_A489sesoauthscope ;
      private string[] T001H2_A490sesexttoken3 ;
      private DateTime[] T001H2_A491sesexttokenexpires ;
      private string[] T001H2_A492sesexttokenrefresh ;
      private string[] T001H2_A493sesjson ;
      private string[] T001H2_A494sesidtoken ;
      private string[] T001H2_A471sesotp ;
      private DateTime[] T001H2_A495sesotpexpire ;
      private bool[] T001H2_A496sesendedbyotherlogin ;
      private IDataStoreProvider pr_default ;
      private int[] T001H11_A461repid ;
      private string[] T001H11_A460sestoken ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_gamsession__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001H2;
          prmT001H2 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H3;
          prmT001H3 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H4;
          prmT001H4 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H5;
          prmT001H5 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H6;
          prmT001H6 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H7;
          prmT001H7 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H8;
          prmT001H8 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0) ,
          new ParDef("sesdate",GXType.DateTime,10,8) ,
          new ParDef("sessts",GXType.Char,1,0) ,
          new ParDef("sestype",GXType.Int16,4,0) ,
          new ParDef("sesurl",GXType.VarChar,2048,0) ,
          new ParDef("sesipadd",GXType.Char,60,0) ,
          new ParDef("opesysid",GXType.Int16,4,0) ,
          new ParDef("seslastacc",GXType.DateTime,10,8) ,
          new ParDef("sestimeout",GXType.Int16,4,0) ,
          new ParDef("seslogatt",GXType.Int32,9,0) ,
          new ParDef("seslogdate",GXType.DateTime,10,8) ,
          new ParDef("sesshareddata",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesenddate",GXType.DateTime,10,8) ,
          new ParDef("sesreload",GXType.Boolean,1,0) ,
          new ParDef("brwid",GXType.Int16,4,0) ,
          new ParDef("seslasturl",GXType.VarChar,2048,0) ,
          new ParDef("seslogin",GXType.VarChar,250,0) ,
          new ParDef("sesexttoken",GXType.Char,120,0) ,
          new ParDef("userguid",GXType.Char,40,0) ,
          new ParDef("sesapptokenexp",GXType.DateTime,10,8) ,
          new ParDef("sesrefreshtoken",GXType.Char,40,0) ,
          new ParDef("sesappid",GXType.Int64,18,0) ,
          new ParDef("sesdeviceid",GXType.Char,40,0) ,
          new ParDef("sesexttoken2",GXType.VarChar,1024,0) ,
          new ParDef("sesauttypename",GXType.Char,60,0) ,
          new ParDef("sesoauthtokenmaxrenew",GXType.Int16,4,0) ,
          new ParDef("sesoauthtokenexpires",GXType.Int32,9,0) ,
          new ParDef("sesoauthscope",GXType.VarChar,2048,0) ,
          new ParDef("sesexttoken3",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesexttokenexpires",GXType.DateTime,10,8) ,
          new ParDef("sesexttokenrefresh",GXType.VarChar,2000,0) ,
          new ParDef("sesjson",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesidtoken",GXType.VarChar,4096,0) ,
          new ParDef("sesotp",GXType.VarChar,250,0) ,
          new ParDef("sesotpexpire",GXType.DateTime,10,8) ,
          new ParDef("sesendedbyotherlogin",GXType.Boolean,1,0)
          };
          Object[] prmT001H9;
          prmT001H9 = new Object[] {
          new ParDef("sesdate",GXType.DateTime,10,8) ,
          new ParDef("sessts",GXType.Char,1,0) ,
          new ParDef("sestype",GXType.Int16,4,0) ,
          new ParDef("sesurl",GXType.VarChar,2048,0) ,
          new ParDef("sesipadd",GXType.Char,60,0) ,
          new ParDef("opesysid",GXType.Int16,4,0) ,
          new ParDef("seslastacc",GXType.DateTime,10,8) ,
          new ParDef("sestimeout",GXType.Int16,4,0) ,
          new ParDef("seslogatt",GXType.Int32,9,0) ,
          new ParDef("seslogdate",GXType.DateTime,10,8) ,
          new ParDef("sesshareddata",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesenddate",GXType.DateTime,10,8) ,
          new ParDef("sesreload",GXType.Boolean,1,0) ,
          new ParDef("brwid",GXType.Int16,4,0) ,
          new ParDef("seslasturl",GXType.VarChar,2048,0) ,
          new ParDef("seslogin",GXType.VarChar,250,0) ,
          new ParDef("sesexttoken",GXType.Char,120,0) ,
          new ParDef("userguid",GXType.Char,40,0) ,
          new ParDef("sesapptokenexp",GXType.DateTime,10,8) ,
          new ParDef("sesrefreshtoken",GXType.Char,40,0) ,
          new ParDef("sesappid",GXType.Int64,18,0) ,
          new ParDef("sesdeviceid",GXType.Char,40,0) ,
          new ParDef("sesexttoken2",GXType.VarChar,1024,0) ,
          new ParDef("sesauttypename",GXType.Char,60,0) ,
          new ParDef("sesoauthtokenmaxrenew",GXType.Int16,4,0) ,
          new ParDef("sesoauthtokenexpires",GXType.Int32,9,0) ,
          new ParDef("sesoauthscope",GXType.VarChar,2048,0) ,
          new ParDef("sesexttoken3",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesexttokenexpires",GXType.DateTime,10,8) ,
          new ParDef("sesexttokenrefresh",GXType.VarChar,2000,0) ,
          new ParDef("sesjson",GXType.LongVarChar,2097152,0) ,
          new ParDef("sesidtoken",GXType.VarChar,4096,0) ,
          new ParDef("sesotp",GXType.VarChar,250,0) ,
          new ParDef("sesotpexpire",GXType.DateTime,10,8) ,
          new ParDef("sesendedbyotherlogin",GXType.Boolean,1,0) ,
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H10;
          prmT001H10 = new Object[] {
          new ParDef("repid",GXType.Int32,9,0) ,
          new ParDef("sestoken",GXType.Char,120,0)
          };
          Object[] prmT001H11;
          prmT001H11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001H2", "SELECT repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin FROM gam.session WHERE repid = :repid AND sestoken = :sestoken  FOR UPDATE OF session NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H3", "SELECT repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin FROM gam.session WHERE repid = :repid AND sestoken = :sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H4", "SELECT TM1.repid, TM1.sestoken, TM1.sesdate, TM1.sessts, TM1.sestype, TM1.sesurl, TM1.sesipadd, TM1.opesysid, TM1.seslastacc, TM1.sestimeout, TM1.seslogatt, TM1.seslogdate, TM1.sesshareddata, TM1.sesenddate, TM1.sesreload, TM1.brwid, TM1.seslasturl, TM1.seslogin, TM1.sesexttoken, TM1.userguid, TM1.sesapptokenexp, TM1.sesrefreshtoken, TM1.sesappid, TM1.sesdeviceid, TM1.sesexttoken2, TM1.sesauttypename, TM1.sesoauthtokenmaxrenew, TM1.sesoauthtokenexpires, TM1.sesoauthscope, TM1.sesexttoken3, TM1.sesexttokenexpires, TM1.sesexttokenrefresh, TM1.sesjson, TM1.sesidtoken, TM1.sesotp, TM1.sesotpexpire, TM1.sesendedbyotherlogin FROM gam.session TM1 WHERE TM1.repid = :repid and TM1.sestoken = ( :sestoken) ORDER BY TM1.repid, TM1.sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H5", "SELECT repid, sestoken FROM gam.session WHERE repid = :repid AND sestoken = :sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H6", "SELECT repid, sestoken FROM gam.session WHERE ( repid > :repid or repid = :repid and sestoken > ( :sestoken)) ORDER BY repid, sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H7", "SELECT repid, sestoken FROM gam.session WHERE ( repid < :repid or repid = :repid and sestoken < ( :sestoken)) ORDER BY repid DESC, sestoken DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H8", "SAVEPOINT gxupdate;INSERT INTO gam.session(repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin) VALUES(:repid, :sestoken, :sesdate, :sessts, :sestype, :sesurl, :sesipadd, :opesysid, :seslastacc, :sestimeout, :seslogatt, :seslogdate, :sesshareddata, :sesenddate, :sesreload, :brwid, :seslasturl, :seslogin, :sesexttoken, :userguid, :sesapptokenexp, :sesrefreshtoken, :sesappid, :sesdeviceid, :sesexttoken2, :sesauttypename, :sesoauthtokenmaxrenew, :sesoauthtokenexpires, :sesoauthscope, :sesexttoken3, :sesexttokenexpires, :sesexttokenrefresh, :sesjson, :sesidtoken, :sesotp, :sesotpexpire, :sesendedbyotherlogin);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001H8)
             ,new CursorDef("T001H9", "SAVEPOINT gxupdate;UPDATE gam.session SET sesdate=:sesdate, sessts=:sessts, sestype=:sestype, sesurl=:sesurl, sesipadd=:sesipadd, opesysid=:opesysid, seslastacc=:seslastacc, sestimeout=:sestimeout, seslogatt=:seslogatt, seslogdate=:seslogdate, sesshareddata=:sesshareddata, sesenddate=:sesenddate, sesreload=:sesreload, brwid=:brwid, seslasturl=:seslasturl, seslogin=:seslogin, sesexttoken=:sesexttoken, userguid=:userguid, sesapptokenexp=:sesapptokenexp, sesrefreshtoken=:sesrefreshtoken, sesappid=:sesappid, sesdeviceid=:sesdeviceid, sesexttoken2=:sesexttoken2, sesauttypename=:sesauttypename, sesoauthtokenmaxrenew=:sesoauthtokenmaxrenew, sesoauthtokenexpires=:sesoauthtokenexpires, sesoauthscope=:sesoauthscope, sesexttoken3=:sesexttoken3, sesexttokenexpires=:sesexttokenexpires, sesexttokenrefresh=:sesexttokenrefresh, sesjson=:sesjson, sesidtoken=:sesidtoken, sesotp=:sesotp, sesotpexpire=:sesotpexpire, sesendedbyotherlogin=:sesendedbyotherlogin  WHERE repid = :repid AND sestoken = :sestoken;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001H9)
             ,new CursorDef("T001H10", "SAVEPOINT gxupdate;DELETE FROM gam.session  WHERE repid = :repid AND sestoken = :sestoken;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001H10)
             ,new CursorDef("T001H11", "SELECT repid, sestoken FROM gam.session ORDER BY repid, sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H11,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 120);
                ((string[]) buf[19])[0] = rslt.getString(20, 40);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
                ((string[]) buf[21])[0] = rslt.getString(22, 40);
                ((long[]) buf[22])[0] = rslt.getLong(23);
                ((string[]) buf[23])[0] = rslt.getString(24, 40);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getString(26, 60);
                ((short[]) buf[26])[0] = rslt.getShort(27);
                ((int[]) buf[27])[0] = rslt.getInt(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
                ((string[]) buf[33])[0] = rslt.getVarchar(34);
                ((string[]) buf[34])[0] = rslt.getVarchar(35);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[36])[0] = rslt.getBool(37);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 120);
                ((string[]) buf[19])[0] = rslt.getString(20, 40);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
                ((string[]) buf[21])[0] = rslt.getString(22, 40);
                ((long[]) buf[22])[0] = rslt.getLong(23);
                ((string[]) buf[23])[0] = rslt.getString(24, 40);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getString(26, 60);
                ((short[]) buf[26])[0] = rslt.getShort(27);
                ((int[]) buf[27])[0] = rslt.getInt(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
                ((string[]) buf[33])[0] = rslt.getVarchar(34);
                ((string[]) buf[34])[0] = rslt.getVarchar(35);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[36])[0] = rslt.getBool(37);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 120);
                ((string[]) buf[19])[0] = rslt.getString(20, 40);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
                ((string[]) buf[21])[0] = rslt.getString(22, 40);
                ((long[]) buf[22])[0] = rslt.getLong(23);
                ((string[]) buf[23])[0] = rslt.getString(24, 40);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getString(26, 60);
                ((short[]) buf[26])[0] = rslt.getShort(27);
                ((int[]) buf[27])[0] = rslt.getInt(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
                ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
                ((string[]) buf[33])[0] = rslt.getVarchar(34);
                ((string[]) buf[34])[0] = rslt.getVarchar(35);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[36])[0] = rslt.getBool(37);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_gamsession__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_gamsession__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
