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
   public class wp_manageorganisationprovisioning : GXDataArea
   {
      public wp_manageorganisationprovisioning( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_manageorganisationprovisioning( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId )
      {
         this.AV17OrganisationId = aP0_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavOrganisationhasmycare = new GXCheckbox();
         chkavOrganisationhasmyliving = new GXCheckbox();
         chkavOrganisationhasmyservices = new GXCheckbox();
         chkavOrganisationhasdynamicforms = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "OrganisationId");
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
               gxfirstwebparm = GetFirstPar( "OrganisationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "OrganisationId");
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
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
            return "wp_manageorganisationprovisioning_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PAAT2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAT2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_manageorganisationprovisioning.aspx"+UrlEncode(AV17OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_manageorganisationprovisioning.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV17OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV17OrganisationId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDBRANDTHEME", AV20SelectedBrandTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDBRANDTHEME", AV20SelectedBrandTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV17OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV17OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGES", AV9ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGES", AV9ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Accentcolorvalue", StringUtil.RTrim( Themeselector_Accentcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Backgroundcolorvalue", StringUtil.RTrim( Themeselector_Backgroundcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Bordercolorvalue", StringUtil.RTrim( Themeselector_Bordercolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Buttonbgcolorvalue", StringUtil.RTrim( Themeselector_Buttonbgcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Buttontextcolorvalue", StringUtil.RTrim( Themeselector_Buttontextcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Cardbgcolorvalue", StringUtil.RTrim( Themeselector_Cardbgcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Cardtextcolorvalue", StringUtil.RTrim( Themeselector_Cardtextcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Primarycolorvalue", StringUtil.RTrim( Themeselector_Primarycolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Secondarycolorvalue", StringUtil.RTrim( Themeselector_Secondarycolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Textcolorvalue", StringUtil.RTrim( Themeselector_Textcolorvalue));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor1", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor1));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor2", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor2));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor3", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor3));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor4", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor4));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEAT2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAT2( ) ;
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
         GXEncryptionTmp = "wp_manageorganisationprovisioning.aspx"+UrlEncode(AV17OrganisationId.ToString());
         return formatLink("wp_manageorganisationprovisioning.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ManageOrganisationProvisioning" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Organisation Provisioning", "") ;
      }

      protected void WBAT0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Organisation Provisioning", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ManageOrganisationProvisioning.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAgreementfields_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmycare_Internalname, context.GetMessage( "Organisation Has My Care", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmycare_Internalname, StringUtil.BoolToStr( AV14OrganisationHasMyCare), "", context.GetMessage( "Organisation Has My Care", ""), 1, chkavOrganisationhasmycare.Enabled, "true", context.GetMessage( "Grant access to the 'My Care' category", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(23, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmyliving_Internalname, context.GetMessage( "Organisation Has My Living", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyliving_Internalname, StringUtil.BoolToStr( AV15OrganisationHasMyLiving), "", context.GetMessage( "Organisation Has My Living", ""), 1, chkavOrganisationhasmyliving.Enabled, "true", context.GetMessage( "Grant access to the 'My Living' category", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmyservices_Internalname, context.GetMessage( "Organisation Has My Services", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyservices_Internalname, StringUtil.BoolToStr( AV16OrganisationHasMyServices), "", context.GetMessage( "Organisation Has My Services", ""), 1, chkavOrganisationhasmyservices.Enabled, "true", context.GetMessage( "Grant access to the 'My Services' category", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasdynamicforms_Internalname, context.GetMessage( "Organisation Has Dynamic Forms", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasdynamicforms_Internalname, StringUtil.BoolToStr( AV13OrganisationHasDynamicForms), "", context.GetMessage( "Organisation Has Dynamic Forms", ""), 1, chkavOrganisationhasdynamicforms.Enabled, "true", context.GetMessage( "Grant access to apply 'Dynamic Forms'", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandthemetable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblThemelabel_Internalname, context.GetMessage( "Your Brand Theme", ""), "", "", lblThemelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucThemeselector.SetProperty("SelectedTheme", AV20SelectedBrandTheme);
            ucThemeselector.Render(context, "uc_themeselector", Themeselector_Internalname, "THEMESELECTORContainer");
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
            GxWebStd.gx_div_start( context, divCtatable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop10", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCtatheme_Internalname, context.GetMessage( "Call To Action Theme", ""), "", "", lblCtatheme_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCalltoactionthemeselector.SetProperty("ResultTheme", AV23SelectedCtaTheme);
            ucCalltoactionthemeselector.Render(context, "uc_ctathemeselector", Calltoactionthemeselector_Internalname, "CALLTOACTIONTHEMESELECTORContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageOrganisationProvisioning.htm");
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
         wbLoad = true;
      }

      protected void STARTAT2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Organisation Provisioning", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAT0( ) ;
      }

      protected void WSAT2( )
      {
         STARTAT2( ) ;
         EVTAT2( ) ;
      }

      protected void EVTAT2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11AT2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E12AT2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13AT2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WEAT2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PAAT2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_manageorganisationprovisioning.aspx")), "wp_manageorganisationprovisioning.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_manageorganisationprovisioning.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV17OrganisationId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV17OrganisationId", AV17OrganisationId.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV17OrganisationId, context));
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = chkavOrganisationhasmycare_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV14OrganisationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV14OrganisationHasMyCare));
         AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
         AV15OrganisationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV15OrganisationHasMyLiving));
         AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
         AV16OrganisationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV16OrganisationHasMyServices));
         AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
         AV13OrganisationHasDynamicForms = StringUtil.StrToBool( StringUtil.BoolToStr( AV13OrganisationHasDynamicForms));
         AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAT2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAT2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13AT2 ();
            WBAT0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAT2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAT0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AT2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDBRANDTHEME"), AV20SelectedBrandTheme);
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDCTATHEME"), AV23SelectedCtaTheme);
            /* Read saved values. */
            Themeselector_Accentcolorvalue = cgiGet( "THEMESELECTOR_Accentcolorvalue");
            Themeselector_Backgroundcolorvalue = cgiGet( "THEMESELECTOR_Backgroundcolorvalue");
            Themeselector_Bordercolorvalue = cgiGet( "THEMESELECTOR_Bordercolorvalue");
            Themeselector_Buttonbgcolorvalue = cgiGet( "THEMESELECTOR_Buttonbgcolorvalue");
            Themeselector_Buttontextcolorvalue = cgiGet( "THEMESELECTOR_Buttontextcolorvalue");
            Themeselector_Cardbgcolorvalue = cgiGet( "THEMESELECTOR_Cardbgcolorvalue");
            Themeselector_Cardtextcolorvalue = cgiGet( "THEMESELECTOR_Cardtextcolorvalue");
            Themeselector_Primarycolorvalue = cgiGet( "THEMESELECTOR_Primarycolorvalue");
            Themeselector_Secondarycolorvalue = cgiGet( "THEMESELECTOR_Secondarycolorvalue");
            Themeselector_Textcolorvalue = cgiGet( "THEMESELECTOR_Textcolorvalue");
            Calltoactionthemeselector_Ctacolor1 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor1");
            Calltoactionthemeselector_Ctacolor2 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor2");
            Calltoactionthemeselector_Ctacolor3 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor3");
            Calltoactionthemeselector_Ctacolor4 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor4");
            /* Read variables values. */
            AV14OrganisationHasMyCare = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmycare_Internalname));
            AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
            AV15OrganisationHasMyLiving = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyliving_Internalname));
            AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
            AV16OrganisationHasMyServices = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyservices_Internalname));
            AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
            AV13OrganisationHasDynamicForms = StringUtil.StrToBool( cgiGet( chkavOrganisationhasdynamicforms_Internalname));
            AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11AT2 ();
         if (returnInSub) return;
      }

      protected void E11AT2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV26GXLvl11 = 0;
         /* Using cursor H00AT2 */
         pr_default.execute(0, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H00AT2_A11OrganisationId[0];
            A100OrganisationSettingid = H00AT2_A100OrganisationSettingid[0];
            A549OrganisationHasDynamicForms = H00AT2_A549OrganisationHasDynamicForms[0];
            A546OrganisationHasMyCare = H00AT2_A546OrganisationHasMyCare[0];
            A547OrganisationHasMyLiving = H00AT2_A547OrganisationHasMyLiving[0];
            A548OrganisationHasMyServices = H00AT2_A548OrganisationHasMyServices[0];
            A550OrganisationBrandTheme = H00AT2_A550OrganisationBrandTheme[0];
            A551OrganisationCtaTheme = H00AT2_A551OrganisationCtaTheme[0];
            AV26GXLvl11 = 1;
            AV18OrganisationSettingId = A100OrganisationSettingid;
            AssignAttri("", false, "AV18OrganisationSettingId", AV18OrganisationSettingId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
            AV13OrganisationHasDynamicForms = A549OrganisationHasDynamicForms;
            AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
            AV14OrganisationHasMyCare = A546OrganisationHasMyCare;
            AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
            AV15OrganisationHasMyLiving = A547OrganisationHasMyLiving;
            AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
            AV16OrganisationHasMyServices = A548OrganisationHasMyServices;
            AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
            AV11OrganisationBrandTheme = A550OrganisationBrandTheme;
            AV12OrganisationCtaTheme = A551OrganisationCtaTheme;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV26GXLvl11 == 0 )
         {
            AV24isNewSetting = true;
            AssignAttri("", false, "AV24isNewSetting", AV24isNewSetting);
            GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         }
         if ( AV5DefaultBrandTheme.FromJSonString(AV11OrganisationBrandTheme, null) )
         {
            Themeselector_Accentcolorvalue = AV5DefaultBrandTheme.gxTpr_Accentcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "accentColorValue", Themeselector_Accentcolorvalue);
            Themeselector_Backgroundcolorvalue = AV5DefaultBrandTheme.gxTpr_Backgroundcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "backgroundColorValue", Themeselector_Backgroundcolorvalue);
            Themeselector_Bordercolorvalue = AV5DefaultBrandTheme.gxTpr_Bordercolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "borderColorValue", Themeselector_Bordercolorvalue);
            Themeselector_Buttonbgcolorvalue = AV5DefaultBrandTheme.gxTpr_Buttonbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonBGColorValue", Themeselector_Buttonbgcolorvalue);
            Themeselector_Buttontextcolorvalue = AV5DefaultBrandTheme.gxTpr_Buttontextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonTextColorValue", Themeselector_Buttontextcolorvalue);
            Themeselector_Cardbgcolorvalue = AV5DefaultBrandTheme.gxTpr_Cardbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardBgColorValue", Themeselector_Cardbgcolorvalue);
            Themeselector_Cardtextcolorvalue = AV5DefaultBrandTheme.gxTpr_Cardtextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardTextColorValue", Themeselector_Cardtextcolorvalue);
            Themeselector_Primarycolorvalue = AV5DefaultBrandTheme.gxTpr_Primarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "primaryColorValue", Themeselector_Primarycolorvalue);
            Themeselector_Secondarycolorvalue = AV5DefaultBrandTheme.gxTpr_Secondarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "secondaryColorValue", Themeselector_Secondarycolorvalue);
            Themeselector_Textcolorvalue = AV5DefaultBrandTheme.gxTpr_Textcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "textColorValue", Themeselector_Textcolorvalue);
         }
         if ( AV6DefaultCtaTheme.FromJSonString(AV12OrganisationCtaTheme, null) )
         {
            Calltoactionthemeselector_Ctacolor1 = AV6DefaultCtaTheme.gxTpr_Ctacolor1;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor1", Calltoactionthemeselector_Ctacolor1);
            Calltoactionthemeselector_Ctacolor2 = AV6DefaultCtaTheme.gxTpr_Ctacolor2;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor2", Calltoactionthemeselector_Ctacolor2);
            Calltoactionthemeselector_Ctacolor3 = AV6DefaultCtaTheme.gxTpr_Ctacolor3;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor3", Calltoactionthemeselector_Ctacolor3);
            Calltoactionthemeselector_Ctacolor4 = AV6DefaultCtaTheme.gxTpr_Ctacolor4;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor4", Calltoactionthemeselector_Ctacolor4);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12AT2 ();
         if (returnInSub) return;
      }

      protected void E12AT2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV24isNewSetting )
         {
            AV21Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
            AV21Trn_OrganisationSetting.gxTpr_Organisationsettingid = Guid.NewGuid( );
            AV21Trn_OrganisationSetting.gxTpr_Organisationid = AV17OrganisationId;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmycare = AV14OrganisationHasMyCare;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyliving = AV15OrganisationHasMyLiving;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyservices = AV16OrganisationHasMyServices;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasdynamicforms = AV13OrganisationHasDynamicForms;
            AV21Trn_OrganisationSetting.gxTpr_Organisationbrandtheme = AV20SelectedBrandTheme.ToJSonString(false, true);
            AV21Trn_OrganisationSetting.gxTpr_Organisationctatheme = AV23SelectedCtaTheme.ToJSonString(false, true);
            AV21Trn_OrganisationSetting.Insert();
         }
         else
         {
            AV21Trn_OrganisationSetting.Load(AV18OrganisationSettingId, AV17OrganisationId);
            if ( AV21Trn_OrganisationSetting.Success() )
            {
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmycare = AV14OrganisationHasMyCare;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyliving = AV15OrganisationHasMyLiving;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyservices = AV16OrganisationHasMyServices;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasdynamicforms = AV13OrganisationHasDynamicForms;
               AV21Trn_OrganisationSetting.gxTpr_Organisationbrandtheme = AV20SelectedBrandTheme.ToJSonString(false, true);
               AV21Trn_OrganisationSetting.gxTpr_Organisationctatheme = AV23SelectedCtaTheme.ToJSonString(false, true);
               AV21Trn_OrganisationSetting.Save();
            }
         }
         if ( AV21Trn_OrganisationSetting.Success() )
         {
            context.CommitDataStores("wp_manageorganisationprovisioning",pr_default);
            AV22websession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Provisions updated successfully", ""));
            CallWebObject(formatLink("trn_organisationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV9ErrorMessages = AV21Trn_OrganisationSetting.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9ErrorMessages", AV9ErrorMessages);
      }

      protected void S112( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV9ErrorMessages.Count )
         {
            AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV9ErrorMessages.Item(AV27GXV1));
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error",  AV25Message.gxTpr_Description,  "error",  "",  "true",  ""));
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         AV9ErrorMessages.Clear();
      }

      protected void nextLoad( )
      {
      }

      protected void E13AT2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17OrganisationId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV17OrganisationId", AV17OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV17OrganisationId, context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PAAT2( ) ;
         WSAT2( ) ;
         WEAT2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025361263794", true, true);
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
         context.AddJavascriptSource("wp_manageorganisationprovisioning.js", "?2025361263794", false, true);
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavOrganisationhasmycare.Name = "vORGANISATIONHASMYCARE";
         chkavOrganisationhasmycare.WebTags = "";
         chkavOrganisationhasmycare.Caption = context.GetMessage( "Organisation Has My Care", "");
         AssignProp("", false, chkavOrganisationhasmycare_Internalname, "TitleCaption", chkavOrganisationhasmycare.Caption, true);
         chkavOrganisationhasmycare.CheckedValue = "false";
         AV14OrganisationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV14OrganisationHasMyCare));
         AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
         chkavOrganisationhasmyliving.Name = "vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyliving.WebTags = "";
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         AssignProp("", false, chkavOrganisationhasmyliving_Internalname, "TitleCaption", chkavOrganisationhasmyliving.Caption, true);
         chkavOrganisationhasmyliving.CheckedValue = "false";
         AV15OrganisationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV15OrganisationHasMyLiving));
         AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
         chkavOrganisationhasmyservices.Name = "vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasmyservices.WebTags = "";
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         AssignProp("", false, chkavOrganisationhasmyservices_Internalname, "TitleCaption", chkavOrganisationhasmyservices.Caption, true);
         chkavOrganisationhasmyservices.CheckedValue = "false";
         AV16OrganisationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV16OrganisationHasMyServices));
         AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
         chkavOrganisationhasdynamicforms.Name = "vORGANISATIONHASDYNAMICFORMS";
         chkavOrganisationhasdynamicforms.WebTags = "";
         chkavOrganisationhasdynamicforms.Caption = context.GetMessage( "Organisation Has Dynamic Forms", "");
         AssignProp("", false, chkavOrganisationhasdynamicforms_Internalname, "TitleCaption", chkavOrganisationhasdynamicforms.Caption, true);
         chkavOrganisationhasdynamicforms.CheckedValue = "false";
         AV13OrganisationHasDynamicForms = StringUtil.StrToBool( StringUtil.BoolToStr( AV13OrganisationHasDynamicForms));
         AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavOrganisationhasmycare_Internalname = "vORGANISATIONHASMYCARE";
         chkavOrganisationhasmyliving_Internalname = "vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyservices_Internalname = "vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasdynamicforms_Internalname = "vORGANISATIONHASDYNAMICFORMS";
         divAgreementfields_Internalname = "AGREEMENTFIELDS";
         lblThemelabel_Internalname = "THEMELABEL";
         Themeselector_Internalname = "THEMESELECTOR";
         divBrandtable_Internalname = "BRANDTABLE";
         lblCtatheme_Internalname = "CTATHEME";
         Calltoactionthemeselector_Internalname = "CALLTOACTIONTHEMESELECTOR";
         divCtatable_Internalname = "CTATABLE";
         divBrandthemetable_Internalname = "BRANDTHEMETABLE";
         divGroupattributes_Internalname = "GROUPATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
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
         chkavOrganisationhasdynamicforms.Caption = context.GetMessage( "Organisation Has Dynamic Forms", "");
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         chkavOrganisationhasmycare.Caption = context.GetMessage( "Organisation Has My Care", "");
         chkavOrganisationhasdynamicforms.Enabled = 1;
         chkavOrganisationhasmyservices.Enabled = 1;
         chkavOrganisationhasmyliving.Enabled = 1;
         chkavOrganisationhasmycare.Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Calltoactionthemeselector_Ctacolor4 = "#C4A082";
         Calltoactionthemeselector_Ctacolor3 = "#B2B997";
         Calltoactionthemeselector_Ctacolor2 = "#D4A76A";
         Calltoactionthemeselector_Ctacolor1 = "#2C405A";
         Themeselector_Textcolorvalue = "#B7B7B7";
         Themeselector_Secondarycolorvalue = "#E9C4AA";
         Themeselector_Primarycolorvalue = "#C4A082";
         Themeselector_Cardtextcolorvalue = "#B2B997";
         Themeselector_Cardbgcolorvalue = "#969674";
         Themeselector_Buttontextcolorvalue = "#D4A76A";
         Themeselector_Buttonbgcolorvalue = "#A48F79";
         Themeselector_Bordercolorvalue = "#666E61";
         Themeselector_Backgroundcolorvalue = "#2C405A";
         Themeselector_Accentcolorvalue = "#393736";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Organisation Provisioning", "");
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV15OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV16OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV13OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV24isNewSetting","fld":"vISNEWSETTING","hsh":true},{"av":"AV17OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV18OrganisationSettingId","fld":"vORGANISATIONSETTINGID","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E12AT2","iparms":[{"av":"AV24isNewSetting","fld":"vISNEWSETTING","hsh":true},{"av":"AV17OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV14OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV15OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV16OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV13OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV20SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV23SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV18OrganisationSettingId","fld":"vORGANISATIONSETTINGID","hsh":true},{"av":"AV9ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9ErrorMessages","fld":"vERRORMESSAGES"}]}""");
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

      public override void initialize( )
      {
         wcpOAV17OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18OrganisationSettingId = Guid.Empty;
         AV20SelectedBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV23SelectedCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblThemelabel_Jsonclick = "";
         ucThemeselector = new GXUserControl();
         lblCtatheme_Jsonclick = "";
         ucCalltoactionthemeselector = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00AT2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00AT2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         H00AT2_A549OrganisationHasDynamicForms = new bool[] {false} ;
         H00AT2_A546OrganisationHasMyCare = new bool[] {false} ;
         H00AT2_A547OrganisationHasMyLiving = new bool[] {false} ;
         H00AT2_A548OrganisationHasMyServices = new bool[] {false} ;
         H00AT2_A550OrganisationBrandTheme = new string[] {""} ;
         H00AT2_A551OrganisationCtaTheme = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         A550OrganisationBrandTheme = "";
         A551OrganisationCtaTheme = "";
         AV11OrganisationBrandTheme = "";
         AV12OrganisationCtaTheme = "";
         AV5DefaultBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV6DefaultCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV21Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
         AV22websession = context.GetSession();
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__default(),
            new Object[][] {
                new Object[] {
               H00AT2_A11OrganisationId, H00AT2_A100OrganisationSettingid, H00AT2_A549OrganisationHasDynamicForms, H00AT2_A546OrganisationHasMyCare, H00AT2_A547OrganisationHasMyLiving, H00AT2_A548OrganisationHasMyServices, H00AT2_A550OrganisationBrandTheme, H00AT2_A551OrganisationCtaTheme
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV26GXLvl11 ;
      private short nGXWrapped ;
      private int AV27GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Themeselector_Accentcolorvalue ;
      private string Themeselector_Backgroundcolorvalue ;
      private string Themeselector_Bordercolorvalue ;
      private string Themeselector_Buttonbgcolorvalue ;
      private string Themeselector_Buttontextcolorvalue ;
      private string Themeselector_Cardbgcolorvalue ;
      private string Themeselector_Cardtextcolorvalue ;
      private string Themeselector_Primarycolorvalue ;
      private string Themeselector_Secondarycolorvalue ;
      private string Themeselector_Textcolorvalue ;
      private string Calltoactionthemeselector_Ctacolor1 ;
      private string Calltoactionthemeselector_Ctacolor2 ;
      private string Calltoactionthemeselector_Ctacolor3 ;
      private string Calltoactionthemeselector_Ctacolor4 ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGroupattributes_Internalname ;
      private string divAgreementfields_Internalname ;
      private string chkavOrganisationhasmycare_Internalname ;
      private string TempTags ;
      private string chkavOrganisationhasmyliving_Internalname ;
      private string chkavOrganisationhasmyservices_Internalname ;
      private string chkavOrganisationhasdynamicforms_Internalname ;
      private string divBrandthemetable_Internalname ;
      private string divBrandtable_Internalname ;
      private string lblThemelabel_Internalname ;
      private string lblThemelabel_Jsonclick ;
      private string Themeselector_Internalname ;
      private string divCtatable_Internalname ;
      private string lblCtatheme_Internalname ;
      private string lblCtatheme_Jsonclick ;
      private string Calltoactionthemeselector_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24isNewSetting ;
      private bool wbLoad ;
      private bool AV14OrganisationHasMyCare ;
      private bool AV15OrganisationHasMyLiving ;
      private bool AV16OrganisationHasMyServices ;
      private bool AV13OrganisationHasDynamicForms ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A549OrganisationHasDynamicForms ;
      private bool A546OrganisationHasMyCare ;
      private bool A547OrganisationHasMyLiving ;
      private bool A548OrganisationHasMyServices ;
      private string A550OrganisationBrandTheme ;
      private string A551OrganisationCtaTheme ;
      private string AV11OrganisationBrandTheme ;
      private string AV12OrganisationCtaTheme ;
      private Guid AV17OrganisationId ;
      private Guid wcpOAV17OrganisationId ;
      private Guid AV18OrganisationSettingId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private GXUserControl ucThemeselector ;
      private GXUserControl ucCalltoactionthemeselector ;
      private IGxSession AV22websession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavOrganisationhasmycare ;
      private GXCheckbox chkavOrganisationhasmyliving ;
      private GXCheckbox chkavOrganisationhasmyservices ;
      private GXCheckbox chkavOrganisationhasdynamicforms ;
      private SdtSDT_BrandThemeColors AV20SelectedBrandTheme ;
      private SdtSDT_CtaThemeColors AV23SelectedCtaTheme ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ErrorMessages ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00AT2_A11OrganisationId ;
      private Guid[] H00AT2_A100OrganisationSettingid ;
      private bool[] H00AT2_A549OrganisationHasDynamicForms ;
      private bool[] H00AT2_A546OrganisationHasMyCare ;
      private bool[] H00AT2_A547OrganisationHasMyLiving ;
      private bool[] H00AT2_A548OrganisationHasMyServices ;
      private string[] H00AT2_A550OrganisationBrandTheme ;
      private string[] H00AT2_A551OrganisationCtaTheme ;
      private SdtSDT_BrandThemeColors AV5DefaultBrandTheme ;
      private SdtSDT_CtaThemeColors AV6DefaultCtaTheme ;
      private SdtTrn_OrganisationSetting AV21Trn_OrganisationSetting ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_manageorganisationprovisioning__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_manageorganisationprovisioning__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_manageorganisationprovisioning__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00AT2;
       prmH00AT2 = new Object[] {
       new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00AT2", "SELECT OrganisationId, OrganisationSettingid, OrganisationHasDynamicForms, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationBrandTheme, OrganisationCtaTheme FROM Trn_OrganisationSetting WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AT2,100, GxCacheFrequency.OFF ,false,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             return;
    }
 }

}

}
