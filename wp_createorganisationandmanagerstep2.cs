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
   public class wp_createorganisationandmanagerstep2 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wp_createorganisationandmanagerstep2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV41WebSessionKey = aP0_WebSessionKey;
         this.AV33PreviousStep = aP1_PreviousStep;
         this.AV11GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavManagergender = new GXCombobox();
         chkavManagerismainmanager = new GXCheckbox();
         cmbavSdt_managers__managergender = new GXCombobox();
         chkavSdt_managers__managerismainmanager = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV41WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
                  AV33PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
                  AV11GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV41WebSessionKey,(string)AV33PreviousStep,(bool)AV11GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_managerss") == 0 )
               {
                  gxnrGridsdt_managerss_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_managerss") == 0 )
               {
                  gxgrGridsdt_managerss_refresh_invoke( ) ;
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridsdt_managerss_newrow_invoke( )
      {
         nRC_GXsfl_71 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_71"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_71_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_71_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_71_idx = GetPar( "sGXsfl_71_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_managerss_newrow( ) ;
         /* End function gxnrGridsdt_managerss_newrow_invoke */
      }

      protected void gxgrGridsdt_managerss_refresh_invoke( )
      {
         subGridsdt_managerss_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_managerss_Rows"), "."), 18, MidpointRounding.ToEven));
         AV48ManagerIsMainManager = StringUtil.StrToBool( GetPar( "ManagerIsMainManager"));
         AV12HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_managerss_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA4H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_managers__managerid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__organisationid_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managergivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managergivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managerlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managerinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__manageremail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__manageremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managerphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managerphonecode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphonecode_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managerphonenumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphonenumber_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               cmbavSdt_managers__managergender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavSdt_managers__managergamguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managergamguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managergamguid_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               chkavSdt_managers__managerismainmanager.Enabled = 0;
               AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSdt_managers__managerismainmanager.Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavUedit_Enabled = 0;
               AssignProp(sPrefix, false, edtavUedit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUedit_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_71_Refreshing);
               WS4H2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "WP_Create Organisation And Manager Step2", "")) ;
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
         }
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createorganisationandmanagerstep2.aspx"+UrlEncode(StringUtil.RTrim(AV41WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV33PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV11GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_managers", AV35SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_managers", AV35SDT_Managers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_71", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_71), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGERPHONECODE_DATA", AV50ManagerPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGERPHONECODE_DATA", AV50ManagerPhoneCode_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41WebSessionKey", wcpOAV41WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33PreviousStep", wcpOAV33PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV11GoingBack", wcpOAV11GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV41WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_MANAGERS", AV35SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_MANAGERS", AV35SDT_Managers);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV42WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV42WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV36Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV36Trn_Manager);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSUCCESSFUL", AV63isSuccessful);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MANAGEREMAIL", A25ManagerEmail);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISALREADYEXISTINGINGAM", AV15isAlreadyExistingInGAM);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV33PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV11GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MANAGERPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_managerphonecode_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm4H2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WP_CreateOrganisationAndManagerStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Organisation And Manager Step2", "") ;
      }

      protected void WB4H0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep2.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Manager Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagergivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagergivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergivenname_Internalname, AV21ManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV21ManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagergivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagerlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerlastname_Internalname, AV24ManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV24ManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagerlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavManagergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavManagergender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavManagergender, cmbavManagergender_Internalname, StringUtil.RTrim( AV20ManagerGender), 1, cmbavManagergender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavManagergender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", (string)(cmbavManagergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManageremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManageremail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManageremail_Internalname, AV18ManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV18ManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavManageremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmanagerphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_managerphonecode_Internalname, context.GetMessage( "Phone ", ""), "", "", lblTextblockcombo_managerphonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_49_4H2( true) ;
         }
         else
         {
            wb_table1_49_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_49_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavManagerismainmanager_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavManagerismainmanager_Internalname, context.GetMessage( "Is Main Manager?", ""), "col-sm-4 AttributeCheckBoxLabel BootstrapTooltipRightLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            ClassString = "AttributeCheckBox BootstrapTooltipRight";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavManagerismainmanager_Internalname, StringUtil.BoolToStr( AV48ManagerIsMainManager), chkavManagerismainmanager.TooltipText, context.GetMessage( "Is Main Manager?", ""), 1, chkavManagerismainmanager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
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
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(71), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtnuinsert_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_managerssContainer.SetWrapped(nGXWrapped);
            StartGridControl71( ) ;
         }
         if ( wbEnd == 71 )
         {
            wbEnd = 0;
            nRC_GXsfl_71 = (int)(nGXsfl_71_idx-1);
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               AV70GXV1 = nGXsfl_71_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinishwizard_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(71), 2, 0)+","+"null"+");", context.GetMessage( "Finish", ""), bttBtnfinishwizard_Jsonclick, 5, context.GetMessage( "Finish", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFINISHWIZARD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateOrganisationAndManagerStep2.htm");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphonecode_Internalname, AV49ManagerPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV49ManagerPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerinitials_Internalname, StringUtil.RTrim( AV23ManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV23ManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphone_Internalname, StringUtil.RTrim( AV25ManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV25ManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerid_Internalname, AV22ManagerId.ToString(), AV22ManagerId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergamguid_Internalname, AV19ManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( AV19ManagerGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergamguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagergamguid_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* User Defined Control */
            ucGridsdt_managerss_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_managerss_empowerer_Internalname, sPrefix+"GRIDSDT_MANAGERSS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 71 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                  AV70GXV1 = nGXsfl_71_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4H2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Organisation And Manager Step2", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP4H0( ) ;
            }
         }
      }

      protected void WS4H2( )
      {
         START4H2( ) ;
         EVT4H2( ) ;
      }

      protected void EVT4H2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E114H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFINISHWIZARD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFinishWizard' */
                                    E124H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E134H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMANAGEREMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E144H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMANAGERPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E154H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_MANAGERSSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_managerss_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_managerss_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_managerss_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_managerss_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDSDT_MANAGERSS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VUEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VUEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              nGXsfl_71_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
                              SubsflControlProps_712( ) ;
                              AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                              if ( ( AV35SDT_Managers.Count >= AV70GXV1 ) && ( AV70GXV1 > 0 ) )
                              {
                                 AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
                                 AV55UEdit = cgiGet( edtavUedit_Internalname);
                                 AssignAttri(sPrefix, false, edtavUedit_Internalname, AV55UEdit);
                                 AV38UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV38UDelete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E164H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_managerss.Load */
                                          E174H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                                /* Execute user event: Enter */
                                                E184H2 ();
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUDELETE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E194H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUEDIT.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E204H2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP4H0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4H2( ) ;
            }
         }
      }

      protected void PA4H2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")), "wp_createorganisationandmanagerstep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavManagergivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_managerss_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_712( ) ;
         while ( nGXsfl_71_idx <= nRC_GXsfl_71 )
         {
            sendrow_712( ) ;
            nGXsfl_71_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_71_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_71_idx+1);
            sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
            SubsflControlProps_712( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_managerssContainer)) ;
         /* End function gxnrGridsdt_managerss_newrow */
      }

      protected void gxgrGridsdt_managerss_refresh( int subGridsdt_managerss_Rows ,
                                                    bool AV48ManagerIsMainManager ,
                                                    bool AV12HasValidationErrors ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_MANAGERSS_nCurrentRecord = 0;
         RF4H2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdt_managerss_refresh */
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
         if ( cmbavManagergender.ItemCount > 0 )
         {
            AV20ManagerGender = cmbavManagergender.getValidValue(AV20ManagerGender);
            AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
         }
         AV48ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( AV48ManagerIsMainManager));
         AssignAttri(sPrefix, false, "AV48ManagerIsMainManager", AV48ManagerIsMainManager);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         edtavUedit_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      protected void RF4H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_managerssContainer.ClearRows();
         }
         wbStart = 71;
         nGXsfl_71_idx = 1;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         bGXsfl_71_Refreshing = true;
         Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_managerssContainer.PageSize = subGridsdt_managerss_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_712( ) ;
            /* Execute user event: Gridsdt_managerss.Load */
            E174H2 ();
            if ( ( subGridsdt_managerss_Islastpage == 0 ) && ( GRIDSDT_MANAGERSS_nCurrentRecord > 0 ) && ( GRIDSDT_MANAGERSS_nGridOutOfScope == 0 ) && ( nGXsfl_71_idx == 1 ) )
            {
               GRIDSDT_MANAGERSS_nCurrentRecord = 0;
               GRIDSDT_MANAGERSS_nGridOutOfScope = 1;
               subgridsdt_managerss_firstpage( ) ;
               /* Execute user event: Gridsdt_managerss.Load */
               E174H2 ();
            }
            wbEnd = 71;
            WB4H0( ) ;
         }
         bGXsfl_71_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4H2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
      }

      protected int subGridsdt_managerss_fnc_Pagecount( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_managerss_fnc_Recordcount( )
      {
         return AV35SDT_Managers.Count ;
      }

      protected int subGridsdt_managerss_fnc_Recordsperpage( )
      {
         if ( subGridsdt_managerss_Rows > 0 )
         {
            return subGridsdt_managerss_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_managerss_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nFirstRecordOnPage/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_managerss_firstpage( )
      {
         GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_nextpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ( GRIDSDT_MANAGERSS_nRecordCount >= subGridsdt_managerss_fnc_Recordsperpage( ) ) && ( GRIDSDT_MANAGERSS_nEOF == 0 ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_MANAGERSS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_managerss_previouspage( )
      {
         if ( GRIDSDT_MANAGERSS_nFirstRecordOnPage >= subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage-subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_lastpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( GRIDSDT_MANAGERSS_nRecordCount > subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-subGridsdt_managerss_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_managerss_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(subGridsdt_managerss_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         edtavUedit_Enabled = 0;
         edtavUdelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_managers"), AV35SDT_Managers);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGERPHONECODE_DATA"), AV50ManagerPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_MANAGERS"), AV35SDT_Managers);
            /* Read saved values. */
            nRC_GXsfl_71 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_71"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV41WebSessionKey = cgiGet( sPrefix+"wcpOAV41WebSessionKey");
            wcpOAV33PreviousStep = cgiGet( sPrefix+"wcpOAV33PreviousStep");
            wcpOAV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV11GoingBack"));
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_MANAGERSS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_managerss_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
            nRC_GXsfl_71 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_71"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_71_fel_idx = 0;
            while ( nGXsfl_71_fel_idx < nRC_GXsfl_71 )
            {
               nGXsfl_71_fel_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_71_fel_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_71_fel_idx+1);
               sGXsfl_71_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_712( ) ;
               AV70GXV1 = (int)(nGXsfl_71_fel_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               if ( ( AV35SDT_Managers.Count >= AV70GXV1 ) && ( AV70GXV1 > 0 ) )
               {
                  AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
                  AV55UEdit = cgiGet( edtavUedit_Internalname);
                  AV38UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_71_fel_idx == 0 )
            {
               nGXsfl_71_idx = 1;
               sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
               SubsflControlProps_712( ) ;
            }
            nGXsfl_71_fel_idx = 1;
            /* Read variables values. */
            AV21ManagerGivenName = cgiGet( edtavManagergivenname_Internalname);
            AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
            AV24ManagerLastName = cgiGet( edtavManagerlastname_Internalname);
            AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
            cmbavManagergender.Name = cmbavManagergender_Internalname;
            cmbavManagergender.CurrentValue = cgiGet( cmbavManagergender_Internalname);
            AV20ManagerGender = cgiGet( cmbavManagergender_Internalname);
            AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
            AV18ManagerEmail = cgiGet( edtavManageremail_Internalname);
            AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
            AV52ManagerPhoneNumber = cgiGet( edtavManagerphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
            AV48ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkavManagerismainmanager_Internalname));
            AssignAttri(sPrefix, false, "AV48ManagerIsMainManager", AV48ManagerIsMainManager);
            AV49ManagerPhoneCode = cgiGet( edtavManagerphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
            AV23ManagerInitials = cgiGet( edtavManagerinitials_Internalname);
            AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
            AV25ManagerPhone = cgiGet( edtavManagerphone_Internalname);
            AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavManagerid_Internalname), "") == 0 )
            {
               AV22ManagerId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
            }
            else
            {
               try
               {
                  AV22ManagerId = StringUtil.StrToGuid( cgiGet( edtavManagerid_Internalname));
                  AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vMANAGERID");
                  GX_FocusControl = edtavManagerid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV19ManagerGAMGUID = cgiGet( edtavManagergamguid_Internalname);
            AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E164H2 ();
         if (returnInSub) return;
      }

      protected void E164H2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( (false==AV42WizardData.gxTpr_Step1.FromJSonString(AV40WebSession.Get(AV41WebSessionKey), null)) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
            CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         chkavManagerismainmanager.TooltipText = context.GetMessage( "Has permissions to add/edit/delete fellow managers", "");
         AssignProp(sPrefix, false, chkavManagerismainmanager_Internalname, "Tooltiptext", chkavManagerismainmanager.TooltipText, true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavManagerphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_managerphonecode_Htmltemplate = GXt_char2;
         ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "HTMLTemplate", Combo_managerphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOMANAGERPHONECODE' */
         S122 ();
         if (returnInSub) return;
         edtavManagerinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerinitials_Visible), 5, 0), true);
         edtavManagerphone_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerphone_Visible), 5, 0), true);
         edtavManagerid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerid_Visible), 5, 0), true);
         edtavManagergamguid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagergamguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagergamguid_Visible), 5, 0), true);
         Gridsdt_managerss_empowerer_Gridinternalname = subGridsdt_managerss_Internalname;
         ucGridsdt_managerss_empowerer.SendProperty(context, sPrefix, false, Gridsdt_managerss_empowerer_Internalname, "GridInternalName", Gridsdt_managerss_empowerer_Gridinternalname);
         subGridsdt_managerss_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49ManagerPhoneCode)) )
         {
            AV47defaultCountryPhoneCode = "+31";
            AV49ManagerPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
            Combo_managerphonecode_Selectedtext_set = AV47defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedText_set", Combo_managerphonecode_Selectedtext_set);
            Combo_managerphonecode_Selectedvalue_set = AV47defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
         }
         AV53IsEditing = false;
         GX_FocusControl = edtavManagergivenname_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      private void E174H2( )
      {
         /* Gridsdt_managerss_Load Routine */
         returnInSub = false;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV35SDT_Managers.Count )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
            AV55UEdit = "<i class=\"fas fa-pencil\"></i>";
            AssignAttri(sPrefix, false, edtavUedit_Internalname, AV55UEdit);
            AV38UDelete = "<i class=\"fa fa-times fas fa-xmark\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV38UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 71;
            }
            if ( ( subGridsdt_managerss_Islastpage == 1 ) || ( subGridsdt_managerss_Rows == 0 ) || ( ( GRIDSDT_MANAGERSS_nCurrentRecord >= GRIDSDT_MANAGERSS_nFirstRecordOnPage ) && ( GRIDSDT_MANAGERSS_nCurrentRecord < GRIDSDT_MANAGERSS_nFirstRecordOnPage + subGridsdt_managerss_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_712( ) ;
            }
            GRIDSDT_MANAGERSS_nEOF = (short)(((GRIDSDT_MANAGERSS_nCurrentRecord<GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, ".", "")));
            GRIDSDT_MANAGERSS_nCurrentRecord = (long)(GRIDSDT_MANAGERSS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_71_Refreshing )
            {
               DoAjaxLoad(71, Gridsdt_managerssRow);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E184H2 ();
         if (returnInSub) return;
      }

      protected void E184H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV12HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S152 ();
            if (returnInSub) return;
            AV40WebSession.Remove(AV41WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36Trn_Manager", AV36Trn_Manager);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_71_bak_idx = nGXsfl_71_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_71_idx = nGXsfl_71_bak_idx;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void E114H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S142 ();
         if (returnInSub) return;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
      }

      protected void E124H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* 'DoFinishWizard' Routine */
         returnInSub = false;
         if ( AV35SDT_Managers.Count > 0 )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S152 ();
            if (returnInSub) return;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Add at least 1 manager", ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36Trn_Manager", AV36Trn_Manager);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_71_bak_idx = nGXsfl_71_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_71_idx = nGXsfl_71_bak_idx;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void E134H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV12HasValidationErrors )
         {
            AV14isAlreadyAdded = false;
            AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV18ManagerEmail, out  AV9GAMErrors);
            if ( AV10GAMUser.success() )
            {
               AV15isAlreadyExistingInGAM = true;
               AssignAttri(sPrefix, false, "AV15isAlreadyExistingInGAM", AV15isAlreadyExistingInGAM);
            }
            AV83GXV14 = 1;
            while ( AV83GXV14 <= AV35SDT_Managers.Count )
            {
               AV34SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV83GXV14));
               if ( StringUtil.StrCmp(AV34SDT_Manager.gxTpr_Manageremail, AV18ManagerEmail) == 0 )
               {
                  AV14isAlreadyAdded = true;
                  if (true) break;
               }
               AV83GXV14 = (int)(AV83GXV14+1);
            }
            /* Using cursor H004H2 */
            pr_default.execute(0, new Object[] {AV18ManagerEmail});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = H004H2_A25ManagerEmail[0];
               AV68isAlreadyRegistered = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV14isAlreadyAdded || AV68isAlreadyRegistered )
            {
               GX_msglist.addItem(context.GetMessage( "This Manager email has already been added.", ""));
               AV35SDT_Managers = AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
               gx_BV71 = true;
            }
            else
            {
               if ( AV15isAlreadyExistingInGAM )
               {
                  GX_msglist.addItem(context.GetMessage( "This email is already used in the system.", ""));
                  AV35SDT_Managers = AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
                  gx_BV71 = true;
               }
               else
               {
                  AV34SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
                  AV34SDT_Manager.gxTpr_Managerid = Guid.NewGuid( );
                  AV34SDT_Manager.gxTpr_Managergivenname = AV21ManagerGivenName;
                  AV34SDT_Manager.gxTpr_Managerlastname = AV24ManagerLastName;
                  AV34SDT_Manager.gxTpr_Manageremail = AV18ManagerEmail;
                  AV34SDT_Manager.gxTpr_Managergender = AV20ManagerGender;
                  AV34SDT_Manager.gxTpr_Managerphonecode = AV49ManagerPhoneCode;
                  AV34SDT_Manager.gxTpr_Managerphonenumber = AV52ManagerPhoneNumber;
                  GXt_char2 = "";
                  new prc_concatenateintlphone(context ).execute(  AV49ManagerPhoneCode,  AV52ManagerPhoneNumber, out  GXt_char2) ;
                  AV34SDT_Manager.gxTpr_Managerphone = GXt_char2;
                  AV34SDT_Manager.gxTpr_Managerismainmanager = AV48ManagerIsMainManager;
                  AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers.Add(AV34SDT_Manager, 0);
                  AV35SDT_Managers = AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
                  gx_BV71 = true;
                  /* Execute user subroutine: 'CLEARFORMVALUES' */
                  S162 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_71_bak_idx = nGXsfl_71_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_71_idx = nGXsfl_71_bak_idx;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV42WizardData.FromJSonString(AV40WebSession.Get(AV41WebSessionKey), null);
         AV18ManagerEmail = AV42WizardData.gxTpr_Step2.gxTpr_Manageremail;
         AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
         AV23ManagerInitials = AV42WizardData.gxTpr_Step2.gxTpr_Managerinitials;
         AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
         AV49ManagerPhoneCode = AV42WizardData.gxTpr_Step2.gxTpr_Managerphonecode;
         AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
         AV52ManagerPhoneNumber = AV42WizardData.gxTpr_Step2.gxTpr_Managerphonenumber;
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV25ManagerPhone = AV42WizardData.gxTpr_Step2.gxTpr_Managerphone;
         AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
         AV48ManagerIsMainManager = AV42WizardData.gxTpr_Step2.gxTpr_Managerismainmanager;
         AssignAttri(sPrefix, false, "AV48ManagerIsMainManager", AV48ManagerIsMainManager);
         AV22ManagerId = AV42WizardData.gxTpr_Step2.gxTpr_Managerid;
         AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
         AV19ManagerGAMGUID = AV42WizardData.gxTpr_Step2.gxTpr_Managergamguid;
         AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
         AV21ManagerGivenName = AV42WizardData.gxTpr_Step2.gxTpr_Managergivenname;
         AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
         AV24ManagerLastName = AV42WizardData.gxTpr_Step2.gxTpr_Managerlastname;
         AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
         AV20ManagerGender = AV42WizardData.gxTpr_Step2.gxTpr_Managergender;
         AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         AV35SDT_Managers = AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
         gx_BV71 = true;
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV42WizardData.FromJSonString(AV40WebSession.Get(AV41WebSessionKey), null);
         AV42WizardData.gxTpr_Step2.gxTpr_Manageremail = AV18ManagerEmail;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerinitials = AV23ManagerInitials;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerphonecode = AV49ManagerPhoneCode;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerphonenumber = AV52ManagerPhoneNumber;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerphone = AV25ManagerPhone;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerismainmanager = AV48ManagerIsMainManager;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerid = AV22ManagerId;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergamguid = AV19ManagerGAMGUID;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergivenname = AV21ManagerGivenName;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerlastname = AV24ManagerLastName;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergender = AV20ManagerGender;
         AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV35SDT_Managers;
         AV40WebSession.Set(AV41WebSessionKey, AV42WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV8ErrorMessages.Clear();
         AV37Trn_Organisation = new SdtTrn_Organisation(context);
         AV37Trn_Organisation.gxTpr_Organisationid = AV42WizardData.gxTpr_Step1.gxTpr_Organisationid;
         AV37Trn_Organisation.gxTpr_Organisationname = AV42WizardData.gxTpr_Step1.gxTpr_Organisationname;
         AV37Trn_Organisation.gxTpr_Organisationemail = AV42WizardData.gxTpr_Step1.gxTpr_Organisationemail;
         AV37Trn_Organisation.gxTpr_Organisationkvknumber = AV42WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber;
         AV37Trn_Organisation.gxTpr_Organisationphonecode = AV42WizardData.gxTpr_Step1.gxTpr_Organisationphonecode;
         AV37Trn_Organisation.gxTpr_Organisationphonenumber = AV42WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber;
         AV37Trn_Organisation.gxTpr_Organisationphone = AV42WizardData.gxTpr_Step1.gxTpr_Organisationphone;
         AV37Trn_Organisation.gxTpr_Organisationvatnumber = AV42WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber;
         AV37Trn_Organisation.gxTpr_Organisationtypeid = AV42WizardData.gxTpr_Step1.gxTpr_Organisationtypeid;
         AV37Trn_Organisation.gxTpr_Organisationaddresscity = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity;
         AV37Trn_Organisation.gxTpr_Organisationaddresszipcode = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode;
         AV37Trn_Organisation.gxTpr_Organisationaddresscountry = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry;
         AV37Trn_Organisation.gxTpr_Organisationaddressline1 = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1;
         AV37Trn_Organisation.gxTpr_Organisationaddressline2 = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2;
         new GeneXus.Core.genexus.common.SdtLog(context).info(context.GetMessage( "Organisation ID: ", "")+AV37Trn_Organisation.gxTpr_Organisationid.ToString()) ;
         AV60count = 0;
         AV17isOrganisationInserted = AV37Trn_Organisation.Insert();
         if ( AV17isOrganisationInserted )
         {
            AV85GXV15 = 1;
            while ( AV85GXV15 <= AV35SDT_Managers.Count )
            {
               AV34SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV85GXV15));
               AV60count = (short)(AV60count+1);
               AV36Trn_Manager.gxTpr_Managerid = AV34SDT_Manager.gxTpr_Managerid;
               AV36Trn_Manager.gxTpr_Managergivenname = AV34SDT_Manager.gxTpr_Managergivenname;
               AV36Trn_Manager.gxTpr_Managerlastname = AV34SDT_Manager.gxTpr_Managerlastname;
               AV36Trn_Manager.gxTpr_Manageremail = AV34SDT_Manager.gxTpr_Manageremail;
               AV36Trn_Manager.gxTpr_Managerphone = AV34SDT_Manager.gxTpr_Managerphone;
               AV36Trn_Manager.gxTpr_Managerphonecode = AV34SDT_Manager.gxTpr_Managerphonecode;
               AV36Trn_Manager.gxTpr_Managerphonenumber = AV34SDT_Manager.gxTpr_Managerphonenumber;
               AV36Trn_Manager.gxTpr_Organisationid = AV37Trn_Organisation.gxTpr_Organisationid;
               AV36Trn_Manager.gxTpr_Managergender = AV34SDT_Manager.gxTpr_Managergender;
               AV36Trn_Manager.gxTpr_Managergamguid = Guid.NewGuid( ).ToString();
               AV36Trn_Manager.gxTpr_Managerismainmanager = AV34SDT_Manager.gxTpr_Managerismainmanager;
               AV16isManagerInserted = AV36Trn_Manager.Insert();
               if ( ! AV16isManagerInserted )
               {
                  AV87GXV17 = 1;
                  AV86GXV16 = AV36Trn_Manager.GetMessages();
                  while ( AV87GXV17 <= AV86GXV16.Count )
                  {
                     AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV86GXV16.Item(AV87GXV17));
                     AV8ErrorMessages.Add(AV7Error, 0);
                     AV87GXV17 = (int)(AV87GXV17+1);
                  }
               }
               else
               {
                  GXt_char2 = AV36Trn_Manager.gxTpr_Managergamguid;
                  new prc_creategamuseraccountnocommit(context ).execute(  AV36Trn_Manager.gxTpr_Manageremail,  AV36Trn_Manager.gxTpr_Managergivenname,  AV36Trn_Manager.gxTpr_Managerlastname,  "Organisation Manager", ref  GXt_char2, ref  AV61GAMErrorCollection, ref  AV63isSuccessful) ;
                  AV36Trn_Manager.gxTpr_Managergamguid = GXt_char2;
                  AssignAttri(sPrefix, false, "AV63isSuccessful", AV63isSuccessful);
                  AV88GXV18 = 1;
                  while ( AV88GXV18 <= AV61GAMErrorCollection.Count )
                  {
                     AV62GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV61GAMErrorCollection.Item(AV88GXV18));
                     AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
                     AV7Error.gxTpr_Id = Guid.NewGuid( ).ToString();
                     AV7Error.gxTpr_Type = 1;
                     AV7Error.gxTpr_Description = AV62GAMErrorItem.gxTpr_Message;
                     AV8ErrorMessages.Add(AV7Error, 0);
                     AV88GXV18 = (int)(AV88GXV18+1);
                  }
               }
               AV85GXV15 = (int)(AV85GXV15+1);
            }
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S162 ();
            if (returnInSub) return;
            if ( AV8ErrorMessages.Count > 0 )
            {
               context.RollbackDataStores("wp_createorganisationandmanagerstep2",pr_default);
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S172 ();
               if (returnInSub) return;
            }
            else
            {
               AV35SDT_Managers.Clear();
               gx_BV71 = true;
               context.CommitDataStores("wp_createorganisationandmanagerstep2",pr_default);
               CallWebObject(formatLink("trn_organisationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            AV8ErrorMessages = AV37Trn_Organisation.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S172 ();
            if (returnInSub) return;
         }
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21ManagerGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManagergivenname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ManagerLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManagerlastname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManagerEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManageremail_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ManagerEmail)) && ! GxRegex.IsMatch(AV18ManagerEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ManagerPhoneNumber)) && ! GxRegex.IsMatch(AV52ManagerPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMANAGERPHONECODE' Routine */
         returnInSub = false;
         AV90GXV20 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV89GXV19;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV89GXV19 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV90GXV20 <= AV89GXV19.Count )
         {
            AV51ManagerPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV89GXV19.Item(AV90GXV20));
            AV43Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV43Combo_DataItem.gxTpr_Id = AV51ManagerPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV45ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV45ComboTitles.Add(AV51ManagerPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV45ComboTitles.Add(AV51ManagerPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV43Combo_DataItem.gxTpr_Title = AV45ComboTitles.ToJSonString(false);
            AV50ManagerPhoneCode_Data.Add(AV43Combo_DataItem, 0);
            AV90GXV20 = (int)(AV90GXV20+1);
         }
         AV50ManagerPhoneCode_Data.Sort("Title");
         Combo_managerphonecode_Selectedvalue_set = AV49ManagerPhoneCode;
         ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
      }

      protected void E194H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV57IndexToDelete = (short)(AV35SDT_Managers.IndexOf(((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem))));
         if ( AV57IndexToDelete == AV35SDT_Managers.Count )
         {
            AV35SDT_Managers.RemoveItem(AV57IndexToDelete);
            gx_BV71 = true;
            AV40WebSession.Set(context.GetMessage( "isLastIndex", ""), context.GetMessage( "true", ""));
            AV40WebSession.Set(context.GetMessage( "Managers", ""), AV35SDT_Managers.ToJSonString(false));
         }
         else
         {
            AV35SDT_Managers.RemoveItem(AV57IndexToDelete);
            gx_BV71 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_71_bak_idx = nGXsfl_71_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_71_idx = nGXsfl_71_bak_idx;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
      }

      protected void E144H2( )
      {
         /* Manageremail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV18ManagerEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavManageremail_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E204H2( )
      {
         AV70GXV1 = (int)(nGXsfl_71_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1));
         }
         /* Uedit_Click Routine */
         returnInSub = false;
         AV21ManagerGivenName = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managergivenname;
         AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
         AV24ManagerLastName = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managerlastname;
         AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
         AV18ManagerEmail = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Manageremail;
         AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
         AV20ManagerGender = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managergender;
         AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         AV49ManagerPhoneCode = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managerphonecode;
         AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
         AV52ManagerPhoneNumber = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managerphonenumber;
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV48ManagerIsMainManager = ((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem)).gxTpr_Managerismainmanager;
         AssignAttri(sPrefix, false, "AV48ManagerIsMainManager", AV48ManagerIsMainManager);
         AV56IndexToEdit = (short)(AV35SDT_Managers.IndexOf(((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem))));
         if ( AV56IndexToEdit == AV35SDT_Managers.Count )
         {
            AV35SDT_Managers.RemoveItem(AV56IndexToEdit);
            gx_BV71 = true;
            AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV35SDT_Managers;
         }
         else
         {
            AV35SDT_Managers.RemoveItem(AV56IndexToEdit);
            gx_BV71 = true;
            AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV35SDT_Managers;
         }
         /*  Sending Event outputs  */
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_71_bak_idx = nGXsfl_71_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV48ManagerIsMainManager, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_71_idx = nGXsfl_71_bak_idx;
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
      }

      protected void E154H2( )
      {
         /* Managerphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV52ManagerPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ManagerPhoneNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavManagerphonenumber_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV91GXV21 = 1;
         while ( AV91GXV21 <= AV8ErrorMessages.Count )
         {
            AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV8ErrorMessages.Item(AV91GXV21));
            GX_msglist.addItem(context.GetMessage( "Error: ", "")+AV7Error.gxTpr_Description);
            AV91GXV21 = (int)(AV91GXV21+1);
         }
         AV8ErrorMessages.Clear();
      }

      protected void S162( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV22ManagerId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
         AV19ManagerGAMGUID = "";
         AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
         AV21ManagerGivenName = "";
         AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
         AV24ManagerLastName = "";
         AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
         AV18ManagerEmail = "";
         AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
         AV20ManagerGender = "";
         AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         AV23ManagerInitials = "";
         AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
         AV25ManagerPhone = "";
         AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
         AV52ManagerPhoneNumber = "";
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV48ManagerIsMainManager = false;
         AssignAttri(sPrefix, false, "AV48ManagerIsMainManager", AV48ManagerIsMainManager);
      }

      protected void wb_table1_49_4H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmanagerphonecode_Internalname, tblTablemergedmanagerphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_managerphonecode.SetProperty("Caption", Combo_managerphonecode_Caption);
            ucCombo_managerphonecode.SetProperty("Cls", Combo_managerphonecode_Cls);
            ucCombo_managerphonecode.SetProperty("EmptyItem", Combo_managerphonecode_Emptyitem);
            ucCombo_managerphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
            ucCombo_managerphonecode.SetProperty("DropDownOptionsData", AV50ManagerPhoneCode_Data);
            ucCombo_managerphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_managerphonecode_Internalname, sPrefix+"COMBO_MANAGERPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerphonenumber_Internalname, context.GetMessage( "Manager Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphonenumber_Internalname, AV52ManagerPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV52ManagerPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavManagerphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_49_4H2e( true) ;
         }
         else
         {
            wb_table1_49_4H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV41WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
         AV33PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
         AV11GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
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
         PA4H2( ) ;
         WS4H2( ) ;
         WE4H2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV41WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV33PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV11GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV41WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
            AV33PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
            AV11GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
         }
         wcpOAV41WebSessionKey = cgiGet( sPrefix+"wcpOAV41WebSessionKey");
         wcpOAV33PreviousStep = cgiGet( sPrefix+"wcpOAV33PreviousStep");
         wcpOAV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV11GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV41WebSessionKey, wcpOAV41WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV33PreviousStep, wcpOAV33PreviousStep) != 0 ) || ( AV11GoingBack != wcpOAV11GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV41WebSessionKey = AV41WebSessionKey;
         wcpOAV33PreviousStep = AV33PreviousStep;
         wcpOAV11GoingBack = AV11GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV41WebSessionKey = cgiGet( sPrefix+"AV41WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV41WebSessionKey) > 0 )
         {
            AV41WebSessionKey = cgiGet( sCtrlAV41WebSessionKey);
            AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
         }
         else
         {
            AV41WebSessionKey = cgiGet( sPrefix+"AV41WebSessionKey_PARM");
         }
         sCtrlAV33PreviousStep = cgiGet( sPrefix+"AV33PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV33PreviousStep) > 0 )
         {
            AV33PreviousStep = cgiGet( sCtrlAV33PreviousStep);
            AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
         }
         else
         {
            AV33PreviousStep = cgiGet( sPrefix+"AV33PreviousStep_PARM");
         }
         sCtrlAV11GoingBack = cgiGet( sPrefix+"AV11GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV11GoingBack) > 0 )
         {
            AV11GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV11GoingBack));
            AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
         }
         else
         {
            AV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV11GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA4H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS4H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41WebSessionKey_PARM", AV41WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV41WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33PreviousStep_PARM", AV33PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV33PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11GoingBack_PARM", StringUtil.BoolToStr( AV11GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11GoingBack_CTRL", StringUtil.RTrim( sCtrlAV11GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE4H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112914294691", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wp_createorganisationandmanagerstep2.js", "?2024112914294695", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_712( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_71_idx;
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_71_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_71_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_71_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_71_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_71_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_71_idx;
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE_"+sGXsfl_71_idx;
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER_"+sGXsfl_71_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_71_idx;
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID_"+sGXsfl_71_idx;
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER_"+sGXsfl_71_idx;
         edtavUedit_Internalname = sPrefix+"vUEDIT_"+sGXsfl_71_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_71_idx;
      }

      protected void SubsflControlProps_fel_712( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER_"+sGXsfl_71_fel_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_71_fel_idx;
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID_"+sGXsfl_71_fel_idx;
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER_"+sGXsfl_71_fel_idx;
         edtavUedit_Internalname = sPrefix+"vUEDIT_"+sGXsfl_71_fel_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_71_fel_idx;
      }

      protected void sendrow_712( )
      {
         sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
         SubsflControlProps_712( ) ;
         WB4H0( ) ;
         if ( ( subGridsdt_managerss_Rows * 1 == 0 ) || ( nGXsfl_71_idx <= subGridsdt_managerss_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_managerssRow = GXWebRow.GetNew(context,Gridsdt_managerssContainer);
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               subGridsdt_managerss_Backcolor = subGridsdt_managerss_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Uniform";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
               subGridsdt_managerss_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( ((int)((nGXsfl_71_idx) % (2))) == 0 )
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_71_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerid.ToString(),((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)71,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__organisationid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)71,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managergivenname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managergivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managergivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerlastname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__manageremail_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Manageremail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__manageremail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__manageremail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphone_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphonecode_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerphonecode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphonecode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerphonecode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphonenumber_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerphonenumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphonenumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerphonenumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            if ( ( cmbavSdt_managers__managergender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_71_idx;
               cmbavSdt_managers__managergender.Name = GXCCtl;
               cmbavSdt_managers__managergender.WebTags = "";
               cmbavSdt_managers__managergender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_managers__managergender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_managers__managergender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_managers__managergender.ItemCount > 0 )
               {
                  if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender)) )
                  {
                     ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender = cmbavSdt_managers__managergender.getValidValue(((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_managerssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_managers__managergender,(string)cmbavSdt_managers__managergender_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender),(short)1,(string)cmbavSdt_managers__managergender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_managers__managergender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_managers__managergender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender);
            AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Values", (string)(cmbavSdt_managers__managergender.ToJavascriptSource()), !bGXsfl_71_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managergamguid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managergamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managergamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)71,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "SDT_MANAGERS__MANAGERISMAINMANAGER_" + sGXsfl_71_idx;
            chkavSdt_managers__managerismainmanager.Name = GXCCtl;
            chkavSdt_managers__managerismainmanager.WebTags = "";
            chkavSdt_managers__managerismainmanager.Caption = "";
            AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "TitleCaption", chkavSdt_managers__managerismainmanager.Caption, !bGXsfl_71_Refreshing);
            chkavSdt_managers__managerismainmanager.CheckedValue = "false";
            Gridsdt_managerssRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdt_managers__managerismainmanager_Internalname,StringUtil.BoolToStr( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managerismainmanager),(string)"",(string)"",(short)-1,chkavSdt_managers__managerismainmanager.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(83, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,83);\""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUedit_Internalname,StringUtil.RTrim( AV55UEdit),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUEDIT.CLICK."+sGXsfl_71_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUedit_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUedit_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_71_idx + "',71)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV38UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_71_idx+"'",(string)"",(string)"",context.GetMessage( "Delete item", ""),(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)71,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4H2( ) ;
            Gridsdt_managerssContainer.AddRow(Gridsdt_managerssRow);
            nGXsfl_71_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_71_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_71_idx+1);
            sGXsfl_71_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_71_idx), 4, 0), 4, "0");
            SubsflControlProps_712( ) ;
         }
         /* End function sendrow_712 */
      }

      protected void init_web_controls( )
      {
         cmbavManagergender.Name = "vMANAGERGENDER";
         cmbavManagergender.WebTags = "";
         cmbavManagergender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavManagergender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavManagergender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavManagergender.ItemCount > 0 )
         {
         }
         chkavManagerismainmanager.Name = "vMANAGERISMAINMANAGER";
         chkavManagerismainmanager.WebTags = "";
         chkavManagerismainmanager.Caption = context.GetMessage( "Is Main Manager?", "");
         AssignProp(sPrefix, false, chkavManagerismainmanager_Internalname, "TitleCaption", chkavManagerismainmanager.Caption, true);
         chkavManagerismainmanager.CheckedValue = "false";
         GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_71_idx;
         cmbavSdt_managers__managergender.Name = GXCCtl;
         cmbavSdt_managers__managergender.WebTags = "";
         cmbavSdt_managers__managergender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_managers__managergender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_managers__managergender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_managers__managergender.ItemCount > 0 )
         {
            if ( ( AV70GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV70GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV70GXV1)).gxTpr_Managergender)) )
            {
            }
         }
         GXCCtl = "SDT_MANAGERS__MANAGERISMAINMANAGER_" + sGXsfl_71_idx;
         chkavSdt_managers__managerismainmanager.Name = GXCCtl;
         chkavSdt_managers__managerismainmanager.WebTags = "";
         chkavSdt_managers__managerismainmanager.Caption = "";
         AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "TitleCaption", chkavSdt_managers__managerismainmanager.Caption, !bGXsfl_71_Refreshing);
         chkavSdt_managers__managerismainmanager.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl71( )
      {
         if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"DivS\" data-gxgridid=\"71\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_managerss_Internalname, subGridsdt_managerss_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               subGridsdt_managerss_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
               }
            }
            else
            {
               subGridsdt_managerss_Titlebackstyle = 1;
               if ( subGridsdt_managerss_Backcolorstyle == 1 )
               {
                  subGridsdt_managerss_Titlebackcolor = subGridsdt_managerss_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager GAMGUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Is Main Manager", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         }
         else
         {
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
            Gridsdt_managerssContainer.AddObjectProperty("Header", subGridsdt_managerss_Header);
            Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphonecode_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphonenumber_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managergamguid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSdt_managers__managerismainmanager.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV55UEdit)));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUedit_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38UDelete)));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectedindex), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowselection), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowhovering), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavManagergivenname_Internalname = sPrefix+"vMANAGERGIVENNAME";
         edtavManagerlastname_Internalname = sPrefix+"vMANAGERLASTNAME";
         cmbavManagergender_Internalname = sPrefix+"vMANAGERGENDER";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtavManageremail_Internalname = sPrefix+"vMANAGEREMAIL";
         lblTextblockcombo_managerphonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_MANAGERPHONECODE";
         Combo_managerphonecode_Internalname = sPrefix+"COMBO_MANAGERPHONECODE";
         edtavManagerphonenumber_Internalname = sPrefix+"vMANAGERPHONENUMBER";
         tblTablemergedmanagerphonecode_Internalname = sPrefix+"TABLEMERGEDMANAGERPHONECODE";
         divTablesplittedmanagerphonecode_Internalname = sPrefix+"TABLESPLITTEDMANAGERPHONECODE";
         chkavManagerismainmanager_Internalname = sPrefix+"vMANAGERISMAINMANAGER";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID";
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID";
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME";
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME";
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS";
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL";
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE";
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE";
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER";
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER";
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID";
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER";
         edtavUedit_Internalname = sPrefix+"vUEDIT";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnfinishwizard_Internalname = sPrefix+"BTNFINISHWIZARD";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavManagerphonecode_Internalname = sPrefix+"vMANAGERPHONECODE";
         edtavManagerinitials_Internalname = sPrefix+"vMANAGERINITIALS";
         edtavManagerphone_Internalname = sPrefix+"vMANAGERPHONE";
         edtavManagerid_Internalname = sPrefix+"vMANAGERID";
         edtavManagergamguid_Internalname = sPrefix+"vMANAGERGAMGUID";
         Gridsdt_managerss_empowerer_Internalname = sPrefix+"GRIDSDT_MANAGERSS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_managerss_Internalname = sPrefix+"GRIDSDT_MANAGERSS";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGridsdt_managerss_Allowcollapsing = 0;
         subGridsdt_managerss_Allowselection = 0;
         subGridsdt_managerss_Header = "";
         chkavManagerismainmanager.Caption = context.GetMessage( "Is Main Manager?", "");
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         edtavUedit_Jsonclick = "";
         edtavUedit_Enabled = 1;
         chkavSdt_managers__managerismainmanager.Caption = "";
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         edtavSdt_managers__managergamguid_Jsonclick = "";
         edtavSdt_managers__managergamguid_Enabled = 0;
         cmbavSdt_managers__managergender_Jsonclick = "";
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managerphonenumber_Jsonclick = "";
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         edtavSdt_managers__managerphonecode_Jsonclick = "";
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphone_Jsonclick = "";
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__manageremail_Jsonclick = "";
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerinitials_Jsonclick = "";
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__managerlastname_Jsonclick = "";
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managergivenname_Jsonclick = "";
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__organisationid_Jsonclick = "";
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managerid_Jsonclick = "";
         edtavSdt_managers__managerid_Enabled = 0;
         subGridsdt_managerss_Class = "WorkWith";
         subGridsdt_managerss_Backcolorstyle = 0;
         edtavManagerphonenumber_Jsonclick = "";
         edtavManagerphonenumber_Enabled = 1;
         Combo_managerphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_managerphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_managerphonecode_Caption = "";
         Combo_managerphonecode_Htmltemplate = "";
         edtavManagergamguid_Jsonclick = "";
         edtavManagergamguid_Visible = 1;
         edtavManagerid_Jsonclick = "";
         edtavManagerid_Visible = 1;
         edtavManagerphone_Jsonclick = "";
         edtavManagerphone_Visible = 1;
         edtavManagerinitials_Jsonclick = "";
         edtavManagerinitials_Visible = 1;
         edtavManagerphonecode_Jsonclick = "";
         edtavManagerphonecode_Visible = 1;
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         chkavManagerismainmanager.TooltipText = "";
         chkavManagerismainmanager.Enabled = 1;
         edtavManageremail_Jsonclick = "";
         edtavManageremail_Enabled = 1;
         cmbavManagergender_Jsonclick = "";
         cmbavManagergender.Enabled = 1;
         edtavManagerlastname_Jsonclick = "";
         edtavManagerlastname_Enabled = 1;
         edtavManagergivenname_Jsonclick = "";
         edtavManagergivenname_Enabled = 1;
         chkavSdt_managers__managerismainmanager.Enabled = -1;
         edtavSdt_managers__managergamguid_Enabled = -1;
         cmbavSdt_managers__managergender.Enabled = -1;
         edtavSdt_managers__managerphonenumber_Enabled = -1;
         edtavSdt_managers__managerphonecode_Enabled = -1;
         edtavSdt_managers__managerphone_Enabled = -1;
         edtavSdt_managers__manageremail_Enabled = -1;
         edtavSdt_managers__managerinitials_Enabled = -1;
         edtavSdt_managers__managerlastname_Enabled = -1;
         edtavSdt_managers__managergivenname_Enabled = -1;
         edtavSdt_managers__organisationid_Enabled = -1;
         edtavSdt_managers__managerid_Enabled = -1;
         subGridsdt_managerss_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD","""{"handler":"E174H2","iparms":[]""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD",""","oparms":[{"av":"AV55UEdit","fld":"vUEDIT"},{"av":"AV38UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E184H2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV63isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV63isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E114H2","iparms":[{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV42WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOFINISHWIZARD'","""{"handler":"E124H2","iparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV63isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOFINISHWIZARD'",""","oparms":[{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV63isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E134H2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"A25ManagerEmail","fld":"MANAGEREMAIL"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV15isAlreadyExistingInGAM","fld":"vISALREADYEXISTINGINGAM"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV15isAlreadyExistingInGAM","fld":"vISALREADYEXISTINGINGAM"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E194H2","iparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71}]}""");
         setEventMetadata("VMANAGEREMAIL.CONTROLVALUECHANGED","""{"handler":"E144H2","iparms":[{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"}]""");
         setEventMetadata("VMANAGEREMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VUEDIT.CLICK","""{"handler":"E204H2","iparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUEDIT.CLICK",""","oparms":[{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"AV42WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("VMANAGERPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E154H2","iparms":[{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"}]""");
         setEventMetadata("VMANAGERPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_FIRSTPAGE","""{"handler":"subgridsdt_managerss_firstpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_PREVPAGE","""{"handler":"subgridsdt_managerss_previouspage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_NEXTPAGE","""{"handler":"subgridsdt_managerss_nextpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_LASTPAGE","""{"handler":"subgridsdt_managerss_lastpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":71},{"av":"nGXsfl_71_idx","ctrl":"GRID","prop":"GridCurrRow","grid":71},{"av":"nRC_GXsfl_71","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":71},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV48ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("VALIDV_MANAGERGENDER","""{"handler":"Validv_Managergender","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGEREMAIL","""{"handler":"Validv_Manageremail","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGERID","""{"handler":"Validv_Managerid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Udelete","iparms":[]}""");
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
         wcpOAV41WebSessionKey = "";
         wcpOAV33PreviousStep = "";
         Combo_managerphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV48ManagerIsMainManager = false;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35SDT_Managers = new GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_ManagersItem", "Comforta_version2");
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50ManagerPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV42WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         AV36Trn_Manager = new SdtTrn_Manager(context);
         AV8ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A25ManagerEmail = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV21ManagerGivenName = "";
         AV24ManagerLastName = "";
         AV20ManagerGender = "";
         AV18ManagerEmail = "";
         lblTextblockcombo_managerphonecode_Jsonclick = "";
         bttBtnuinsert_Jsonclick = "";
         Gridsdt_managerssContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         bttBtnfinishwizard_Jsonclick = "";
         AV49ManagerPhoneCode = "";
         AV23ManagerInitials = "";
         AV25ManagerPhone = "";
         AV22ManagerId = Guid.Empty;
         AV19ManagerGAMGUID = "";
         ucGridsdt_managerss_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV55UEdit = "";
         AV38UDelete = "";
         GXDecQS = "";
         AV52ManagerPhoneNumber = "";
         AV40WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         ucCombo_managerphonecode = new GXUserControl();
         Gridsdt_managerss_empowerer_Gridinternalname = "";
         AV47defaultCountryPhoneCode = "";
         Combo_managerphonecode_Selectedtext_set = "";
         Combo_managerphonecode_Selectedvalue_set = "";
         Gridsdt_managerssRow = new GXWebRow();
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV34SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
         H004H2_A21ManagerId = new Guid[] {Guid.Empty} ;
         H004H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004H2_A25ManagerEmail = new string[] {""} ;
         AV37Trn_Organisation = new SdtTrn_Organisation(context);
         AV86GXV16 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char2 = "";
         AV61GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV62GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV89GXV19 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV51ManagerPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV43Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV45ComboTitles = new GxSimpleCollection<string>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV41WebSessionKey = "";
         sCtrlAV33PreviousStep = "";
         sCtrlAV11GoingBack = "";
         subGridsdt_managerss_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_managerssColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__default(),
            new Object[][] {
                new Object[] {
               H004H2_A21ManagerId, H004H2_A11OrganisationId, H004H2_A25ManagerEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         edtavUedit_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      private short GRIDSDT_MANAGERSS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGridsdt_managerss_Backcolorstyle ;
      private short AV60count ;
      private short AV57IndexToDelete ;
      private short AV56IndexToEdit ;
      private short nGXWrapped ;
      private short subGridsdt_managerss_Backstyle ;
      private short subGridsdt_managerss_Titlebackstyle ;
      private short subGridsdt_managerss_Allowselection ;
      private short subGridsdt_managerss_Allowhovering ;
      private short subGridsdt_managerss_Allowcollapsing ;
      private short subGridsdt_managerss_Collapsed ;
      private int nRC_GXsfl_71 ;
      private int subGridsdt_managerss_Rows ;
      private int nGXsfl_71_idx=1 ;
      private int edtavSdt_managers__managerid_Enabled ;
      private int edtavSdt_managers__organisationid_Enabled ;
      private int edtavSdt_managers__managergivenname_Enabled ;
      private int edtavSdt_managers__managerlastname_Enabled ;
      private int edtavSdt_managers__managerinitials_Enabled ;
      private int edtavSdt_managers__manageremail_Enabled ;
      private int edtavSdt_managers__managerphone_Enabled ;
      private int edtavSdt_managers__managerphonecode_Enabled ;
      private int edtavSdt_managers__managerphonenumber_Enabled ;
      private int edtavSdt_managers__managergamguid_Enabled ;
      private int edtavUedit_Enabled ;
      private int edtavUdelete_Enabled ;
      private int edtavManagergivenname_Enabled ;
      private int edtavManagerlastname_Enabled ;
      private int edtavManageremail_Enabled ;
      private int AV70GXV1 ;
      private int edtavManagerphonecode_Visible ;
      private int edtavManagerinitials_Visible ;
      private int edtavManagerphone_Visible ;
      private int edtavManagerid_Visible ;
      private int edtavManagergamguid_Visible ;
      private int subGridsdt_managerss_Islastpage ;
      private int GRIDSDT_MANAGERSS_nGridOutOfScope ;
      private int nGXsfl_71_fel_idx=1 ;
      private int nGXsfl_71_bak_idx=1 ;
      private int AV83GXV14 ;
      private int AV85GXV15 ;
      private int AV87GXV17 ;
      private int AV88GXV18 ;
      private int AV90GXV20 ;
      private int AV91GXV21 ;
      private int edtavManagerphonenumber_Enabled ;
      private int idxLst ;
      private int subGridsdt_managerss_Backcolor ;
      private int subGridsdt_managerss_Allbackcolor ;
      private int subGridsdt_managerss_Titlebackcolor ;
      private int subGridsdt_managerss_Selectedindex ;
      private int subGridsdt_managerss_Selectioncolor ;
      private int subGridsdt_managerss_Hoveringcolor ;
      private long GRIDSDT_MANAGERSS_nFirstRecordOnPage ;
      private long GRIDSDT_MANAGERSS_nCurrentRecord ;
      private long GRIDSDT_MANAGERSS_nRecordCount ;
      private string Combo_managerphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_71_idx="0001" ;
      private string edtavSdt_managers__managerid_Internalname ;
      private string edtavSdt_managers__organisationid_Internalname ;
      private string edtavSdt_managers__managergivenname_Internalname ;
      private string edtavSdt_managers__managerlastname_Internalname ;
      private string edtavSdt_managers__managerinitials_Internalname ;
      private string edtavSdt_managers__manageremail_Internalname ;
      private string edtavSdt_managers__managerphone_Internalname ;
      private string edtavSdt_managers__managerphonecode_Internalname ;
      private string edtavSdt_managers__managerphonenumber_Internalname ;
      private string cmbavSdt_managers__managergender_Internalname ;
      private string edtavSdt_managers__managergamguid_Internalname ;
      private string chkavSdt_managers__managerismainmanager_Internalname ;
      private string edtavUedit_Internalname ;
      private string edtavUdelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string edtavManagergivenname_Internalname ;
      private string TempTags ;
      private string edtavManagergivenname_Jsonclick ;
      private string edtavManagerlastname_Internalname ;
      private string edtavManagerlastname_Jsonclick ;
      private string cmbavManagergender_Internalname ;
      private string cmbavManagergender_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string edtavManageremail_Internalname ;
      private string edtavManageremail_Jsonclick ;
      private string divTablesplittedmanagerphonecode_Internalname ;
      private string lblTextblockcombo_managerphonecode_Internalname ;
      private string lblTextblockcombo_managerphonecode_Jsonclick ;
      private string chkavManagerismainmanager_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGridsdt_managerss_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string bttBtnfinishwizard_Internalname ;
      private string bttBtnfinishwizard_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavManagerphonecode_Internalname ;
      private string edtavManagerphonecode_Jsonclick ;
      private string edtavManagerinitials_Internalname ;
      private string AV23ManagerInitials ;
      private string edtavManagerinitials_Jsonclick ;
      private string edtavManagerphone_Internalname ;
      private string AV25ManagerPhone ;
      private string edtavManagerphone_Jsonclick ;
      private string edtavManagerid_Internalname ;
      private string edtavManagerid_Jsonclick ;
      private string edtavManagergamguid_Internalname ;
      private string edtavManagergamguid_Jsonclick ;
      private string Gridsdt_managerss_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV55UEdit ;
      private string AV38UDelete ;
      private string GXDecQS ;
      private string sGXsfl_71_fel_idx="0001" ;
      private string edtavManagerphonenumber_Internalname ;
      private string Combo_managerphonecode_Htmltemplate ;
      private string Combo_managerphonecode_Internalname ;
      private string Gridsdt_managerss_empowerer_Gridinternalname ;
      private string Combo_managerphonecode_Selectedtext_set ;
      private string Combo_managerphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string tblTablemergedmanagerphonecode_Internalname ;
      private string Combo_managerphonecode_Caption ;
      private string Combo_managerphonecode_Cls ;
      private string edtavManagerphonenumber_Jsonclick ;
      private string sCtrlAV41WebSessionKey ;
      private string sCtrlAV33PreviousStep ;
      private string sCtrlAV11GoingBack ;
      private string subGridsdt_managerss_Class ;
      private string subGridsdt_managerss_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_managers__managerid_Jsonclick ;
      private string edtavSdt_managers__organisationid_Jsonclick ;
      private string edtavSdt_managers__managergivenname_Jsonclick ;
      private string edtavSdt_managers__managerlastname_Jsonclick ;
      private string edtavSdt_managers__managerinitials_Jsonclick ;
      private string edtavSdt_managers__manageremail_Jsonclick ;
      private string edtavSdt_managers__managerphone_Jsonclick ;
      private string edtavSdt_managers__managerphonecode_Jsonclick ;
      private string edtavSdt_managers__managerphonenumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_managers__managergender_Jsonclick ;
      private string edtavSdt_managers__managergamguid_Jsonclick ;
      private string edtavUedit_Jsonclick ;
      private string edtavUdelete_Jsonclick ;
      private string subGridsdt_managerss_Header ;
      private bool AV11GoingBack ;
      private bool wcpOAV11GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV48ManagerIsMainManager ;
      private bool AV12HasValidationErrors ;
      private bool bGXsfl_71_Refreshing=false ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool AV63isSuccessful ;
      private bool AV15isAlreadyExistingInGAM ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV53IsEditing ;
      private bool AV14isAlreadyAdded ;
      private bool AV68isAlreadyRegistered ;
      private bool gx_BV71 ;
      private bool AV17isOrganisationInserted ;
      private bool AV16isManagerInserted ;
      private bool Combo_managerphonecode_Emptyitem ;
      private string AV41WebSessionKey ;
      private string AV33PreviousStep ;
      private string wcpOAV41WebSessionKey ;
      private string wcpOAV33PreviousStep ;
      private string A25ManagerEmail ;
      private string AV21ManagerGivenName ;
      private string AV24ManagerLastName ;
      private string AV20ManagerGender ;
      private string AV18ManagerEmail ;
      private string AV49ManagerPhoneCode ;
      private string AV19ManagerGAMGUID ;
      private string AV52ManagerPhoneNumber ;
      private string AV47defaultCountryPhoneCode ;
      private Guid AV22ManagerId ;
      private IGxSession AV40WebSession ;
      private GXWebGrid Gridsdt_managerssContainer ;
      private GXWebRow Gridsdt_managerssRow ;
      private GXWebColumn Gridsdt_managerssColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucGridsdt_managerss_empowerer ;
      private GXUserControl ucCombo_managerphonecode ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavManagergender ;
      private GXCheckbox chkavManagerismainmanager ;
      private GXCombobox cmbavSdt_managers__managergender ;
      private GXCheckbox chkavSdt_managers__managerismainmanager ;
      private GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem> AV35SDT_Managers ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV50ManagerPhoneCode_Data ;
      private SdtWP_CreateOrganisationAndManagerData AV42WizardData ;
      private SdtTrn_Manager AV36Trn_Manager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8ErrorMessages ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrors ;
      private SdtSDT_Managers_SDT_ManagersItem AV34SDT_Manager ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004H2_A21ManagerId ;
      private Guid[] H004H2_A11OrganisationId ;
      private string[] H004H2_A25ManagerEmail ;
      private SdtTrn_Organisation AV37Trn_Organisation ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV86GXV16 ;
      private GeneXus.Utils.SdtMessages_Message AV7Error ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV61GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV62GAMErrorItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV89GXV19 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV51ManagerPhoneCode_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV43Combo_DataItem ;
      private GxSimpleCollection<string> AV45ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createorganisationandmanagerstep2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createorganisationandmanagerstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createorganisationandmanagerstep2__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmH004H2;
       prmH004H2 = new Object[] {
       new ParDef("AV18ManagerEmail",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("H004H2", "SELECT ManagerId, OrganisationId, ManagerEmail FROM Trn_Manager WHERE ManagerEmail = ( :AV18ManagerEmail) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H2,1, GxCacheFrequency.OFF ,false,true )
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
             return;
    }
 }

}

}
