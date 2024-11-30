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
   public class wp_createresidentandnetworkstep1 : GXWebComponent
   {
      public wp_createresidentandnetworkstep1( )
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

      public wp_createresidentandnetworkstep1( IGxContext context )
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
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
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
         cmbavResidentsalutation = new GXCombobox();
         cmbavResidentgender = new GXCombobox();
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
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
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
            PA6Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS6Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Resident And Network Step1", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createresidentandnetworkstep1.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createresidentandnetworkstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTHOMEPHONECODE_DATA", AV47ResidentHomePhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTHOMEPHONECODE_DATA", AV47ResidentHomePhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTTYPEID_DATA", AV49ResidentTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTTYPEID_DATA", AV49ResidentTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMEDICALINDICATIONID_DATA", AV50MedicalIndicationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMEDICALINDICATIONID_DATA", AV50MedicalIndicationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTCOUNTRY_DATA", AV33ResidentCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTCOUNTRY_DATA", AV33ResidentCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV31CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDICALINDICATIONID", A98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTTYPEID", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Ddointernalname", StringUtil.RTrim( Combo_residenttypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_residentcountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDICALINDICATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_medicalindicationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDICALINDICATIONID_Selectedtext_get", StringUtil.RTrim( Combo_medicalindicationid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Selectedtext_get", StringUtil.RTrim( Combo_residenttypeid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_residenthomephonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Ddointernalname", StringUtil.RTrim( Combo_residenttypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_residentcountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDICALINDICATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_medicalindicationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MEDICALINDICATIONID_Selectedtext_get", StringUtil.RTrim( Combo_medicalindicationid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTTYPEID_Selectedtext_get", StringUtil.RTrim( Combo_residenttypeid_Selectedtext_get));
      }

      protected void RenderHtmlCloseForm6Q2( )
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
         return "WP_CreateResidentAndNetworkStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Resident And Network Step1", "") ;
      }

      protected void WB6Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createresidentandnetworkstep1.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Resident Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentsalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentsalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentsalutation, cmbavResidentsalutation_Internalname, StringUtil.RTrim( AV13ResidentSalutation), 1, cmbavResidentsalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavResidentsalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV13ResidentSalutation);
            AssignProp(sPrefix, false, cmbavResidentsalutation_Internalname, "Values", (string)(cmbavResidentsalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentgivenname_Internalname, AV14ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( AV14ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentlastname_Internalname, AV15ResidentLastName, StringUtil.RTrim( context.localUtil.Format( AV15ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentgender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentgender, cmbavResidentgender_Internalname, StringUtil.RTrim( AV16ResidentGender), 1, cmbavResidentgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResidentgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV16ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", (string)(cmbavResidentgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbirthdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbirthdate_Internalname, context.GetMessage( "Date Of Birth", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavResidentbirthdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavResidentbirthdate_Internalname, context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"), context.localUtil.Format( AV17ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbirthdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavResidentbirthdate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_bitmap( context, edtavResidentbirthdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavResidentbirthdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentemail_Internalname, AV18ResidentEmail, StringUtil.RTrim( context.localUtil.Format( AV18ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavResidentemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentphonecode_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblTextblockcombo_residentphonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_57_6Q2( true) ;
         }
         else
         {
            wb_table1_57_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_57_6Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidenthomephonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residenthomephonecode_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblTextblockcombo_residenthomephonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table2_71_6Q2( true) ;
         }
         else
         {
            wb_table2_71_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_71_6Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentbsnnumber_Internalname, AV12ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV12ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavResidentbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentbsnnumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidenttypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residenttypeid_Internalname, context.GetMessage( "Resident Type", ""), "", "", lblTextblockcombo_residenttypeid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residenttypeid.SetProperty("Caption", Combo_residenttypeid_Caption);
            ucCombo_residenttypeid.SetProperty("Cls", Combo_residenttypeid_Cls);
            ucCombo_residenttypeid.SetProperty("EmptyItem", Combo_residenttypeid_Emptyitem);
            ucCombo_residenttypeid.SetProperty("IncludeAddNewOption", Combo_residenttypeid_Includeaddnewoption);
            ucCombo_residenttypeid.SetProperty("DropDownOptionsData", AV49ResidentTypeId_Data);
            ucCombo_residenttypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenttypeid_Internalname, sPrefix+"COMBO_RESIDENTTYPEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmedicalindicationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_medicalindicationid_Internalname, context.GetMessage( "Medical Indication", ""), "", "", lblTextblockcombo_medicalindicationid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_medicalindicationid.SetProperty("Caption", Combo_medicalindicationid_Caption);
            ucCombo_medicalindicationid.SetProperty("Cls", Combo_medicalindicationid_Cls);
            ucCombo_medicalindicationid.SetProperty("EmptyItem", Combo_medicalindicationid_Emptyitem);
            ucCombo_medicalindicationid.SetProperty("IncludeAddNewOption", Combo_medicalindicationid_Includeaddnewoption);
            ucCombo_medicalindicationid.SetProperty("DropDownOptionsData", AV50MedicalIndicationId_Data);
            ucCombo_medicalindicationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_medicalindicationid_Internalname, sPrefix+"COMBO_MEDICALINDICATIONIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline1_Internalname, AV29ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV29ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline2_Internalname, AV30ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV30ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentzipcode_Internalname, AV28ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( AV28ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtavResidentzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcity_Internalname, AV27ResidentCity, StringUtil.RTrim( context.localUtil.Format( AV27ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentcity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_residentcountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentcountry.SetProperty("Caption", Combo_residentcountry_Caption);
            ucCombo_residentcountry.SetProperty("Cls", Combo_residentcountry_Cls);
            ucCombo_residentcountry.SetProperty("EmptyItem", Combo_residentcountry_Emptyitem);
            ucCombo_residentcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucCombo_residentcountry.SetProperty("DropDownOptionsData", AV33ResidentCountry_Data);
            ucCombo_residentcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentcountry_Internalname, sPrefix+"COMBO_RESIDENTCOUNTRYContainer");
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
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonecode_Internalname, AV39ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV39ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephonecode_Internalname, AV44ResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( AV44ResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenthomephonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenttypeid_Internalname, AV23ResidentTypeId.ToString(), AV23ResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenttypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenttypeid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMedicalindicationid_Internalname, AV25MedicalIndicationId.ToString(), AV25MedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMedicalindicationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavMedicalindicationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcountry_Internalname, AV26ResidentCountry, StringUtil.RTrim( context.localUtil.Format( AV26ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentcountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentid_Internalname, AV21ResidentId.ToString(), AV21ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphone_Internalname, StringUtil.RTrim( AV19ResidentPhone), StringUtil.RTrim( context.localUtil.Format( AV19ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephone_Internalname, StringUtil.RTrim( AV46ResidentHomePhone), StringUtil.RTrim( context.localUtil.Format( AV46ResidentHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephone_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenthomephone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenttypename_Internalname, AV24ResidentTypeName, StringUtil.RTrim( context.localUtil.Format( AV24ResidentTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenttypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenttypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Resident And Network Step1", ""), 0) ;
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
               STRUP6Q0( ) ;
            }
         }
      }

      protected void WS6Q2( )
      {
         START6Q2( ) ;
         EVT6Q2( ) ;
      }

      protected void EVT6Q2( )
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
                                 STRUP6Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESIDENTTYPEID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_residenttypeid.Onoptionclicked */
                                    E116Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_medicalindicationid.Onoptionclicked */
                                    E126Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E136Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E146Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
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
                                          E156Q2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E166Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E176Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTBSNNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E186Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTZIPCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E196Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E206Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTHOMEPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E216Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E226Q2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavResidentsalutation_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE6Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6Q2( ) ;
            }
         }
      }

      protected void PA6Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createresidentandnetworkstep1.aspx")), "wp_createresidentandnetworkstep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createresidentandnetworkstep1.aspx")))) ;
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
               GX_FocusControl = cmbavResidentsalutation_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
            AV13ResidentSalutation = cmbavResidentsalutation.getValidValue(AV13ResidentSalutation);
            AssignAttri(sPrefix, false, "AV13ResidentSalutation", AV13ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV13ResidentSalutation);
            AssignProp(sPrefix, false, cmbavResidentsalutation_Internalname, "Values", cmbavResidentsalutation.ToJavascriptSource(), true);
         }
         if ( cmbavResidentgender.ItemCount > 0 )
         {
            AV16ResidentGender = cmbavResidentgender.getValidValue(AV16ResidentGender);
            AssignAttri(sPrefix, false, "AV16ResidentGender", AV16ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV16ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", cmbavResidentgender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E146Q2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E226Q2 ();
            WB6Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E136Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTPHONECODE_DATA"), AV41ResidentPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTHOMEPHONECODE_DATA"), AV47ResidentHomePhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTTYPEID_DATA"), AV49ResidentTypeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMEDICALINDICATIONID_DATA"), AV50MedicalIndicationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTCOUNTRY_DATA"), AV33ResidentCountry_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_residenttypeid_Ddointernalname = cgiGet( sPrefix+"COMBO_RESIDENTTYPEID_Ddointernalname");
            Combo_residentcountry_Ddointernalname = cgiGet( sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname");
            Combo_medicalindicationid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_MEDICALINDICATIONID_Selectedvalue_get");
            Combo_medicalindicationid_Selectedtext_get = cgiGet( sPrefix+"COMBO_MEDICALINDICATIONID_Selectedtext_get");
            Combo_residenttypeid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_RESIDENTTYPEID_Selectedvalue_get");
            Combo_residenttypeid_Selectedtext_get = cgiGet( sPrefix+"COMBO_RESIDENTTYPEID_Selectedtext_get");
            /* Read variables values. */
            cmbavResidentsalutation.CurrentValue = cgiGet( cmbavResidentsalutation_Internalname);
            AV13ResidentSalutation = cgiGet( cmbavResidentsalutation_Internalname);
            AssignAttri(sPrefix, false, "AV13ResidentSalutation", AV13ResidentSalutation);
            AV14ResidentGivenName = cgiGet( edtavResidentgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV14ResidentGivenName", AV14ResidentGivenName);
            AV15ResidentLastName = cgiGet( edtavResidentlastname_Internalname);
            AssignAttri(sPrefix, false, "AV15ResidentLastName", AV15ResidentLastName);
            cmbavResidentgender.CurrentValue = cgiGet( cmbavResidentgender_Internalname);
            AV16ResidentGender = cgiGet( cmbavResidentgender_Internalname);
            AssignAttri(sPrefix, false, "AV16ResidentGender", AV16ResidentGender);
            if ( context.localUtil.VCDate( cgiGet( edtavResidentbirthdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Resident Birth Date", "")}), 1, "vRESIDENTBIRTHDATE");
               GX_FocusControl = edtavResidentbirthdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17ResidentBirthDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV17ResidentBirthDate", context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"));
            }
            else
            {
               AV17ResidentBirthDate = context.localUtil.CToD( cgiGet( edtavResidentbirthdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV17ResidentBirthDate", context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"));
            }
            AV18ResidentEmail = cgiGet( edtavResidentemail_Internalname);
            AssignAttri(sPrefix, false, "AV18ResidentEmail", AV18ResidentEmail);
            AV40ResidentPhoneNumber = cgiGet( edtavResidentphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV40ResidentPhoneNumber", AV40ResidentPhoneNumber);
            AV45ResidentHomePhoneNumber = cgiGet( edtavResidenthomephonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV45ResidentHomePhoneNumber", AV45ResidentHomePhoneNumber);
            AV12ResidentBsnNumber = cgiGet( edtavResidentbsnnumber_Internalname);
            AssignAttri(sPrefix, false, "AV12ResidentBsnNumber", AV12ResidentBsnNumber);
            AV29ResidentAddressLine1 = cgiGet( edtavResidentaddressline1_Internalname);
            AssignAttri(sPrefix, false, "AV29ResidentAddressLine1", AV29ResidentAddressLine1);
            AV30ResidentAddressLine2 = cgiGet( edtavResidentaddressline2_Internalname);
            AssignAttri(sPrefix, false, "AV30ResidentAddressLine2", AV30ResidentAddressLine2);
            AV28ResidentZipCode = cgiGet( edtavResidentzipcode_Internalname);
            AssignAttri(sPrefix, false, "AV28ResidentZipCode", AV28ResidentZipCode);
            AV27ResidentCity = cgiGet( edtavResidentcity_Internalname);
            AssignAttri(sPrefix, false, "AV27ResidentCity", AV27ResidentCity);
            AV39ResidentPhoneCode = cgiGet( edtavResidentphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV39ResidentPhoneCode", AV39ResidentPhoneCode);
            AV44ResidentHomePhoneCode = cgiGet( edtavResidenthomephonecode_Internalname);
            AssignAttri(sPrefix, false, "AV44ResidentHomePhoneCode", AV44ResidentHomePhoneCode);
            if ( StringUtil.StrCmp(cgiGet( edtavResidenttypeid_Internalname), "") == 0 )
            {
               AV23ResidentTypeId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
            }
            else
            {
               try
               {
                  AV23ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtavResidenttypeid_Internalname));
                  AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRESIDENTTYPEID");
                  GX_FocusControl = edtavResidenttypeid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavMedicalindicationid_Internalname), "") == 0 )
            {
               AV25MedicalIndicationId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
            }
            else
            {
               try
               {
                  AV25MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtavMedicalindicationid_Internalname));
                  AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vMEDICALINDICATIONID");
                  GX_FocusControl = edtavMedicalindicationid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV26ResidentCountry = cgiGet( edtavResidentcountry_Internalname);
            AssignAttri(sPrefix, false, "AV26ResidentCountry", AV26ResidentCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavResidentid_Internalname), "") == 0 )
            {
               AV21ResidentId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV21ResidentId", AV21ResidentId.ToString());
            }
            else
            {
               try
               {
                  AV21ResidentId = StringUtil.StrToGuid( cgiGet( edtavResidentid_Internalname));
                  AssignAttri(sPrefix, false, "AV21ResidentId", AV21ResidentId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRESIDENTID");
                  GX_FocusControl = edtavResidentid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV19ResidentPhone = cgiGet( edtavResidentphone_Internalname);
            AssignAttri(sPrefix, false, "AV19ResidentPhone", AV19ResidentPhone);
            AV46ResidentHomePhone = cgiGet( edtavResidenthomephone_Internalname);
            AssignAttri(sPrefix, false, "AV46ResidentHomePhone", AV46ResidentHomePhone);
            AV24ResidentTypeName = cgiGet( edtavResidenttypename_Internalname);
            AssignAttri(sPrefix, false, "AV24ResidentTypeName", AV24ResidentTypeName);
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
         E136Q2 ();
         if (returnInSub) return;
      }

      protected void E136Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavResidentcountry_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentcountry_Htmltemplate = GXt_char2;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "HTMLTemplate", Combo_residentcountry_Htmltemplate);
         edtavMedicalindicationid_Visible = 0;
         AssignProp(sPrefix, false, edtavMedicalindicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMedicalindicationid_Visible), 5, 0), true);
         edtavResidenttypeid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidenttypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttypeid_Visible), 5, 0), true);
         edtavResidenthomephonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavResidenthomephonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenthomephonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residenthomephonecode_Htmltemplate = GXt_char2;
         ucCombo_residenthomephonecode.SendProperty(context, sPrefix, false, Combo_residenthomephonecode_Internalname, "HTMLTemplate", Combo_residenthomephonecode_Htmltemplate);
         edtavResidentphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentphonecode_Htmltemplate = GXt_char2;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "HTMLTemplate", Combo_residentphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTHOMEPHONECODE' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMEDICALINDICATIONID' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTCOUNTRY' */
         S162 ();
         if (returnInSub) return;
         edtavResidentid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentid_Visible), 5, 0), true);
         edtavResidentphone_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphone_Visible), 5, 0), true);
         edtavResidenthomephone_Visible = 0;
         AssignProp(sPrefix, false, edtavResidenthomephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenthomephone_Visible), 5, 0), true);
         edtavResidenttypename_Visible = 0;
         AssignProp(sPrefix, false, edtavResidenttypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttypename_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ResidentCountry)) )
         {
            AV38defaultCountry = "Netherlands";
            Combo_residentcountry_Selectedtext_set = AV38defaultCountry;
            ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
            Combo_residentcountry_Selectedvalue_set = AV38defaultCountry;
            ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
            AV26ResidentCountry = AV38defaultCountry;
            AssignAttri(sPrefix, false, "AV26ResidentCountry", AV26ResidentCountry);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ResidentPhoneCode)) )
         {
            AV43defaultCountryPhoneCode = "+31";
            AV39ResidentPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV39ResidentPhoneCode", AV39ResidentPhoneCode);
            Combo_residentphonecode_Selectedtext_set = AV43defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
            Combo_residentphonecode_Selectedvalue_set = AV43defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44ResidentHomePhoneCode)) )
         {
            AV43defaultCountryPhoneCode = "+31";
            AV44ResidentHomePhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV44ResidentHomePhoneCode", AV44ResidentHomePhoneCode);
            Combo_residenthomephonecode_Selectedtext_set = AV43defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, sPrefix, false, Combo_residenthomephonecode_Internalname, "SelectedText_set", Combo_residenthomephonecode_Selectedtext_set);
            Combo_residenthomephonecode_Selectedvalue_set = AV43defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, sPrefix, false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
         }
      }

      protected void E146Q2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV7GoingBack = false;
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E156Q2 ();
         if (returnInSub) return;
      }

      protected void E156Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S182 ();
         if (returnInSub) return;
         if ( AV31CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S192 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E166Q2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_locationresidents.aspx") );
         context.wjLocDisableFrm = 1;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E126Q2( )
      {
         /* Combo_medicalindicationid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_medicalindicationid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            AV52DefaultMedicalIndicationName = Combo_medicalindicationid_Selectedtext_get;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewmedicalindication.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV25MedicalIndicationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV52DefaultMedicalIndicationName));
            context.PopUp(formatLink("wp_createnewmedicalindication.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_medicalindicationid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOMEDICALINDICATIONID' */
            S152 ();
            if (returnInSub) return;
            AV35ComboSelectedValue = AV51Session.Get("MEDICALINDICATIONID");
            AV51Session.Remove("MEDICALINDICATIONID");
            Combo_medicalindicationid_Selectedvalue_set = AV35ComboSelectedValue;
            ucCombo_medicalindicationid.SendProperty(context, sPrefix, false, Combo_medicalindicationid_Internalname, "SelectedValue_set", Combo_medicalindicationid_Selectedvalue_set);
            AV25MedicalIndicationId = StringUtil.StrToGuid( AV35ComboSelectedValue);
            AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
         }
         else
         {
            AV25MedicalIndicationId = StringUtil.StrToGuid( Combo_medicalindicationid_Selectedvalue_get);
            AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
            /* Execute user subroutine: 'LOADCOMBOMEDICALINDICATIONID' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50MedicalIndicationId_Data", AV50MedicalIndicationId_Data);
      }

      protected void E116Q2( )
      {
         /* Combo_residenttypeid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_residenttypeid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            AV53DefaultResidentTypeName = Combo_residenttypeid_Selectedtext_get;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewresidenttype.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV23ResidentTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV53DefaultResidentTypeName));
            context.PopUp(formatLink("wp_createnewresidenttype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_residenttypeid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
            S142 ();
            if (returnInSub) return;
            AV35ComboSelectedValue = AV51Session.Get("RESIDENTTYPEID");
            AV51Session.Remove("RESIDENTTYPEID");
            Combo_residenttypeid_Selectedvalue_set = AV35ComboSelectedValue;
            ucCombo_residenttypeid.SendProperty(context, sPrefix, false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
            AV23ResidentTypeId = StringUtil.StrToGuid( AV35ComboSelectedValue);
            AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
         }
         else
         {
            AV23ResidentTypeId = StringUtil.StrToGuid( Combo_residenttypeid_Selectedvalue_get);
            AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
            /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ResidentTypeId_Data", AV49ResidentTypeId_Data);
      }

      protected void S172( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV29ResidentAddressLine1 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline1;
         AssignAttri(sPrefix, false, "AV29ResidentAddressLine1", AV29ResidentAddressLine1);
         AV30ResidentAddressLine2 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline2;
         AssignAttri(sPrefix, false, "AV30ResidentAddressLine2", AV30ResidentAddressLine2);
         AV28ResidentZipCode = AV11WizardData.gxTpr_Step1.gxTpr_Residentzipcode;
         AssignAttri(sPrefix, false, "AV28ResidentZipCode", AV28ResidentZipCode);
         AV27ResidentCity = AV11WizardData.gxTpr_Step1.gxTpr_Residentcity;
         AssignAttri(sPrefix, false, "AV27ResidentCity", AV27ResidentCity);
         AV26ResidentCountry = AV11WizardData.gxTpr_Step1.gxTpr_Residentcountry;
         AssignAttri(sPrefix, false, "AV26ResidentCountry", AV26ResidentCountry);
         AV21ResidentId = AV11WizardData.gxTpr_Step1.gxTpr_Residentid;
         AssignAttri(sPrefix, false, "AV21ResidentId", AV21ResidentId.ToString());
         AV13ResidentSalutation = AV11WizardData.gxTpr_Step1.gxTpr_Residentsalutation;
         AssignAttri(sPrefix, false, "AV13ResidentSalutation", AV13ResidentSalutation);
         AV14ResidentGivenName = AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname;
         AssignAttri(sPrefix, false, "AV14ResidentGivenName", AV14ResidentGivenName);
         AV15ResidentLastName = AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname;
         AssignAttri(sPrefix, false, "AV15ResidentLastName", AV15ResidentLastName);
         AV16ResidentGender = AV11WizardData.gxTpr_Step1.gxTpr_Residentgender;
         AssignAttri(sPrefix, false, "AV16ResidentGender", AV16ResidentGender);
         AV17ResidentBirthDate = AV11WizardData.gxTpr_Step1.gxTpr_Residentbirthdate;
         AssignAttri(sPrefix, false, "AV17ResidentBirthDate", context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"));
         AV18ResidentEmail = AV11WizardData.gxTpr_Step1.gxTpr_Residentemail;
         AssignAttri(sPrefix, false, "AV18ResidentEmail", AV18ResidentEmail);
         AV39ResidentPhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Residentphonecode;
         AssignAttri(sPrefix, false, "AV39ResidentPhoneCode", AV39ResidentPhoneCode);
         AV40ResidentPhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentphonenumber;
         AssignAttri(sPrefix, false, "AV40ResidentPhoneNumber", AV40ResidentPhoneNumber);
         AV19ResidentPhone = AV11WizardData.gxTpr_Step1.gxTpr_Residentphone;
         AssignAttri(sPrefix, false, "AV19ResidentPhone", AV19ResidentPhone);
         AV44ResidentHomePhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephonecode;
         AssignAttri(sPrefix, false, "AV44ResidentHomePhoneCode", AV44ResidentHomePhoneCode);
         AV45ResidentHomePhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephonenumber;
         AssignAttri(sPrefix, false, "AV45ResidentHomePhoneNumber", AV45ResidentHomePhoneNumber);
         AV46ResidentHomePhone = AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephone;
         AssignAttri(sPrefix, false, "AV46ResidentHomePhone", AV46ResidentHomePhone);
         AV12ResidentBsnNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber;
         AssignAttri(sPrefix, false, "AV12ResidentBsnNumber", AV12ResidentBsnNumber);
         AV23ResidentTypeId = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid;
         AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
         AV25MedicalIndicationId = AV11WizardData.gxTpr_Step1.gxTpr_Medicalindicationid;
         AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
         AV24ResidentTypeName = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypename;
         AssignAttri(sPrefix, false, "AV24ResidentTypeName", AV24ResidentTypeName);
      }

      protected void S192( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         GXt_char2 = AV19ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  AV39ResidentPhoneCode,  AV40ResidentPhoneNumber, out  GXt_char2) ;
         AV19ResidentPhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV19ResidentPhone", AV19ResidentPhone);
         GXt_char2 = AV46ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  AV44ResidentHomePhoneCode,  AV45ResidentHomePhoneNumber, out  GXt_char2) ;
         AV46ResidentHomePhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV46ResidentHomePhone", AV46ResidentHomePhone);
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline1 = AV29ResidentAddressLine1;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline2 = AV30ResidentAddressLine2;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentzipcode = AV28ResidentZipCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentcity = AV27ResidentCity;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentcountry = AV26ResidentCountry;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentid = AV21ResidentId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentsalutation = AV13ResidentSalutation;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname = AV14ResidentGivenName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname = AV15ResidentLastName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgender = AV16ResidentGender;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentbirthdate = AV17ResidentBirthDate;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentemail = AV18ResidentEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphonecode = AV39ResidentPhoneCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphonenumber = AV40ResidentPhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphone = AV19ResidentPhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephonecode = AV44ResidentHomePhoneCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephonenumber = AV45ResidentHomePhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenthomephone = AV46ResidentHomePhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber = AV12ResidentBsnNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid = AV23ResidentTypeId;
         AV11WizardData.gxTpr_Step1.gxTpr_Medicalindicationid = AV25MedicalIndicationId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenttypename = AV24ResidentTypeName;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV31CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ResidentGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentgivenname_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ResidentLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentlastname_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ResidentGender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Gender", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavResidentgender_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ResidentEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ResidentBsnNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "BSN Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentbsnnumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( (Guid.Empty==AV23ResidentTypeId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_residenttypeid_Ddointernalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ResidentAddressLine1)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentaddressline1_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ResidentZipCode)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentzipcode_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ResidentCity)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentcity_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ResidentCountry)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Country", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_residentcountry_Ddointernalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ResidentEmail)) && ! GxRegex.IsMatch(AV18ResidentEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
      }

      protected void S162( )
      {
         /* 'LOADCOMBORESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV55GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV54GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV54GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV55GXV2 <= AV54GXV1.Count )
         {
            AV37ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV54GXV1.Item(AV55GXV2));
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = AV37ResidentCountry_DPItem.gxTpr_Countryname;
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(AV37ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV32ComboTitles.Add(AV37ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV36Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV33ResidentCountry_Data.Add(AV36Combo_DataItem, 0);
            AV55GXV2 = (int)(AV55GXV2+1);
         }
         AV33ResidentCountry_Data.Sort("Title");
         Combo_residentcountry_Selectedvalue_set = AV26ResidentCountry;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOMEDICALINDICATIONID' Routine */
         returnInSub = false;
         AV50MedicalIndicationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean4) ;
         Combo_medicalindicationid_Includeaddnewoption = GXt_boolean4;
         ucCombo_medicalindicationid.SendProperty(context, sPrefix, false, Combo_medicalindicationid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_medicalindicationid_Includeaddnewoption));
         /* Using cursor H006Q2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A98MedicalIndicationId = H006Q2_A98MedicalIndicationId[0];
            A99MedicalIndicationName = H006Q2_A99MedicalIndicationName[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( A98MedicalIndicationId.ToString());
            AV36Combo_DataItem.gxTpr_Title = A99MedicalIndicationName;
            AV50MedicalIndicationId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_medicalindicationid_Selectedvalue_set = ((Guid.Empty==AV25MedicalIndicationId) ? "" : StringUtil.Trim( AV25MedicalIndicationId.ToString()));
         ucCombo_medicalindicationid.SendProperty(context, sPrefix, false, Combo_medicalindicationid_Internalname, "SelectedValue_set", Combo_medicalindicationid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBORESIDENTTYPEID' Routine */
         returnInSub = false;
         AV49ResidentTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean4) ;
         Combo_residenttypeid_Includeaddnewoption = GXt_boolean4;
         ucCombo_residenttypeid.SendProperty(context, sPrefix, false, Combo_residenttypeid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_residenttypeid_Includeaddnewoption));
         /* Using cursor H006Q3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A96ResidentTypeId = H006Q3_A96ResidentTypeId[0];
            A97ResidentTypeName = H006Q3_A97ResidentTypeName[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
            AV36Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
            AV49ResidentTypeId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_residenttypeid_Selectedvalue_set = ((Guid.Empty==AV23ResidentTypeId) ? "" : StringUtil.Trim( AV23ResidentTypeId.ToString()));
         ucCombo_residenttypeid.SendProperty(context, sPrefix, false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         AV59GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV58GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV58GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV59GXV4 <= AV58GXV3.Count )
         {
            AV48ResidentHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV58GXV3.Item(AV59GXV4));
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = AV48ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(AV48ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV32ComboTitles.Add(AV48ResidentHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV36Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV47ResidentHomePhoneCode_Data.Add(AV36Combo_DataItem, 0);
            AV59GXV4 = (int)(AV59GXV4+1);
         }
         AV47ResidentHomePhoneCode_Data.Sort("Title");
         Combo_residenthomephonecode_Selectedvalue_set = AV44ResidentHomePhoneCode;
         ucCombo_residenthomephonecode.SendProperty(context, sPrefix, false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV61GXV6 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV60GXV5;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV60GXV5 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV61GXV6 <= AV60GXV5.Count )
         {
            AV42ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV60GXV5.Item(AV61GXV6));
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = AV42ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(AV42ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV32ComboTitles.Add(AV42ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV36Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV41ResidentPhoneCode_Data.Add(AV36Combo_DataItem, 0);
            AV61GXV6 = (int)(AV61GXV6+1);
         }
         AV41ResidentPhoneCode_Data.Sort("Title");
         Combo_residentphonecode_Selectedvalue_set = AV39ResidentPhoneCode;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
      }

      protected void E176Q2( )
      {
         /* Residentemail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV18ResidentEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E186Q2( )
      {
         /* Residentbsnnumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.Len( AV12ResidentBsnNumber) != 9 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "BSN is 9 digits long", ""),  "error",  edtavResidentbsnnumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E196Q2( )
      {
         /* Residentzipcode_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV28ResidentZipCode,context.GetMessage( "^\\d{4} [a-zA-Z]{2}$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Zip Code is incorrect", ""),  "error",  edtavResidentzipcode_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E206Q2( )
      {
         /* Residentphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV40ResidentPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ResidentPhoneNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavResidentphonenumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E216Q2( )
      {
         /* Residenthomephonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV45ResidentHomePhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ResidentHomePhoneNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavResidenthomephonenumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E226Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_71_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedresidenthomephonecode_Internalname, tblTablemergedresidenthomephonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_residenthomephonecode.SetProperty("Caption", Combo_residenthomephonecode_Caption);
            ucCombo_residenthomephonecode.SetProperty("Cls", Combo_residenthomephonecode_Cls);
            ucCombo_residenthomephonecode.SetProperty("EmptyItem", Combo_residenthomephonecode_Emptyitem);
            ucCombo_residenthomephonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucCombo_residenthomephonecode.SetProperty("DropDownOptionsData", AV47ResidentHomePhoneCode_Data);
            ucCombo_residenthomephonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenthomephonecode_Internalname, sPrefix+"COMBO_RESIDENTHOMEPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidenthomephonenumber_Internalname, context.GetMessage( "Resident Home Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenthomephonenumber_Internalname, AV45ResidentHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV45ResidentHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenthomephonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavResidenthomephonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_71_6Q2e( true) ;
         }
         else
         {
            wb_table2_71_6Q2e( false) ;
         }
      }

      protected void wb_table1_57_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedresidentphonecode_Internalname, tblTablemergedresidentphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_residentphonecode.SetProperty("Caption", Combo_residentphonecode_Caption);
            ucCombo_residentphonecode.SetProperty("Cls", Combo_residentphonecode_Cls);
            ucCombo_residentphonecode.SetProperty("EmptyItem", Combo_residentphonecode_Emptyitem);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsData", AV41ResidentPhoneCode_Data);
            ucCombo_residentphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentphonecode_Internalname, sPrefix+"COMBO_RESIDENTPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphonenumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonenumber_Internalname, AV40ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV40ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavResidentphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_57_6Q2e( true) ;
         }
         else
         {
            wb_table1_57_6Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA6Q2( ) ;
         WS6Q2( ) ;
         WE6Q2( ) ;
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
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createresidentandnetworkstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
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
         PA6Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6Q2( ) ;
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
         WS6Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
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
         WE6Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112914274858", true, true);
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
         context.AddJavascriptSource("wp_createresidentandnetworkstep1.js", "?2024112914274858", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResidentsalutation.Name = "vRESIDENTSALUTATION";
         cmbavResidentsalutation.WebTags = "";
         cmbavResidentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavResidentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavResidentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavResidentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
         }
         cmbavResidentgender.Name = "vRESIDENTGENDER";
         cmbavResidentgender.WebTags = "";
         cmbavResidentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavResidentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavResidentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentgender.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavResidentsalutation_Internalname = sPrefix+"vRESIDENTSALUTATION";
         edtavResidentgivenname_Internalname = sPrefix+"vRESIDENTGIVENNAME";
         edtavResidentlastname_Internalname = sPrefix+"vRESIDENTLASTNAME";
         cmbavResidentgender_Internalname = sPrefix+"vRESIDENTGENDER";
         edtavResidentbirthdate_Internalname = sPrefix+"vRESIDENTBIRTHDATE";
         edtavResidentemail_Internalname = sPrefix+"vRESIDENTEMAIL";
         lblTextblockcombo_residentphonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTPHONECODE";
         Combo_residentphonecode_Internalname = sPrefix+"COMBO_RESIDENTPHONECODE";
         edtavResidentphonenumber_Internalname = sPrefix+"vRESIDENTPHONENUMBER";
         tblTablemergedresidentphonecode_Internalname = sPrefix+"TABLEMERGEDRESIDENTPHONECODE";
         divTablesplittedresidentphonecode_Internalname = sPrefix+"TABLESPLITTEDRESIDENTPHONECODE";
         lblTextblockcombo_residenthomephonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTHOMEPHONECODE";
         Combo_residenthomephonecode_Internalname = sPrefix+"COMBO_RESIDENTHOMEPHONECODE";
         edtavResidenthomephonenumber_Internalname = sPrefix+"vRESIDENTHOMEPHONENUMBER";
         tblTablemergedresidenthomephonecode_Internalname = sPrefix+"TABLEMERGEDRESIDENTHOMEPHONECODE";
         divTablesplittedresidenthomephonecode_Internalname = sPrefix+"TABLESPLITTEDRESIDENTHOMEPHONECODE";
         edtavResidentbsnnumber_Internalname = sPrefix+"vRESIDENTBSNNUMBER";
         lblTextblockcombo_residenttypeid_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTTYPEID";
         Combo_residenttypeid_Internalname = sPrefix+"COMBO_RESIDENTTYPEID";
         divTablesplittedresidenttypeid_Internalname = sPrefix+"TABLESPLITTEDRESIDENTTYPEID";
         lblTextblockcombo_medicalindicationid_Internalname = sPrefix+"TEXTBLOCKCOMBO_MEDICALINDICATIONID";
         Combo_medicalindicationid_Internalname = sPrefix+"COMBO_MEDICALINDICATIONID";
         divTablesplittedmedicalindicationid_Internalname = sPrefix+"TABLESPLITTEDMEDICALINDICATIONID";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtavResidentaddressline1_Internalname = sPrefix+"vRESIDENTADDRESSLINE1";
         edtavResidentaddressline2_Internalname = sPrefix+"vRESIDENTADDRESSLINE2";
         edtavResidentzipcode_Internalname = sPrefix+"vRESIDENTZIPCODE";
         edtavResidentcity_Internalname = sPrefix+"vRESIDENTCITY";
         lblTextblockcombo_residentcountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTCOUNTRY";
         Combo_residentcountry_Internalname = sPrefix+"COMBO_RESIDENTCOUNTRY";
         divTablesplittedresidentcountry_Internalname = sPrefix+"TABLESPLITTEDRESIDENTCOUNTRY";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResidentphonecode_Internalname = sPrefix+"vRESIDENTPHONECODE";
         edtavResidenthomephonecode_Internalname = sPrefix+"vRESIDENTHOMEPHONECODE";
         edtavResidenttypeid_Internalname = sPrefix+"vRESIDENTTYPEID";
         edtavMedicalindicationid_Internalname = sPrefix+"vMEDICALINDICATIONID";
         edtavResidentcountry_Internalname = sPrefix+"vRESIDENTCOUNTRY";
         edtavResidentid_Internalname = sPrefix+"vRESIDENTID";
         edtavResidentphone_Internalname = sPrefix+"vRESIDENTPHONE";
         edtavResidenthomephone_Internalname = sPrefix+"vRESIDENTHOMEPHONE";
         edtavResidenttypename_Internalname = sPrefix+"vRESIDENTTYPENAME";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtavResidentphonenumber_Jsonclick = "";
         edtavResidentphonenumber_Enabled = 1;
         Combo_residentphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentphonecode_Caption = "";
         edtavResidenthomephonenumber_Jsonclick = "";
         edtavResidenthomephonenumber_Enabled = 1;
         Combo_residenthomephonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenthomephonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residenthomephonecode_Caption = "";
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         Combo_residentphonecode_Htmltemplate = "";
         Combo_residenthomephonecode_Htmltemplate = "";
         Combo_residentcountry_Htmltemplate = "";
         edtavResidenttypename_Jsonclick = "";
         edtavResidenttypename_Visible = 1;
         edtavResidenthomephone_Jsonclick = "";
         edtavResidenthomephone_Visible = 1;
         edtavResidentphone_Jsonclick = "";
         edtavResidentphone_Visible = 1;
         edtavResidentid_Jsonclick = "";
         edtavResidentid_Visible = 1;
         edtavResidentcountry_Jsonclick = "";
         edtavResidentcountry_Visible = 1;
         edtavMedicalindicationid_Jsonclick = "";
         edtavMedicalindicationid_Visible = 1;
         edtavResidenttypeid_Jsonclick = "";
         edtavResidenttypeid_Visible = 1;
         edtavResidenthomephonecode_Jsonclick = "";
         edtavResidenthomephonecode_Visible = 1;
         edtavResidentphonecode_Jsonclick = "";
         edtavResidentphonecode_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_residentcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_residentcountry_Caption = "";
         edtavResidentcity_Jsonclick = "";
         edtavResidentcity_Enabled = 1;
         edtavResidentzipcode_Jsonclick = "";
         edtavResidentzipcode_Enabled = 1;
         edtavResidentaddressline2_Jsonclick = "";
         edtavResidentaddressline2_Enabled = 1;
         edtavResidentaddressline1_Jsonclick = "";
         edtavResidentaddressline1_Enabled = 1;
         Combo_medicalindicationid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_medicalindicationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_medicalindicationid_Cls = "ExtendedCombo Attribute";
         Combo_residenttypeid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_residenttypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenttypeid_Cls = "ExtendedCombo Attribute";
         edtavResidentbsnnumber_Jsonclick = "";
         edtavResidentbsnnumber_Enabled = 1;
         edtavResidentemail_Jsonclick = "";
         edtavResidentemail_Enabled = 1;
         edtavResidentbirthdate_Jsonclick = "";
         edtavResidentbirthdate_Enabled = 1;
         cmbavResidentgender_Jsonclick = "";
         cmbavResidentgender.Enabled = 1;
         edtavResidentlastname_Jsonclick = "";
         edtavResidentlastname_Enabled = 1;
         edtavResidentgivenname_Jsonclick = "";
         edtavResidentgivenname_Enabled = 1;
         cmbavResidentsalutation_Jsonclick = "";
         cmbavResidentsalutation.Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E156Q2","iparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV14ResidentGivenName","fld":"vRESIDENTGIVENNAME"},{"av":"AV15ResidentLastName","fld":"vRESIDENTLASTNAME"},{"av":"cmbavResidentgender"},{"av":"AV16ResidentGender","fld":"vRESIDENTGENDER"},{"av":"AV18ResidentEmail","fld":"vRESIDENTEMAIL"},{"av":"AV12ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"},{"av":"AV23ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"Combo_residenttypeid_Ddointernalname","ctrl":"COMBO_RESIDENTTYPEID","prop":"DDOInternalName"},{"av":"AV29ResidentAddressLine1","fld":"vRESIDENTADDRESSLINE1"},{"av":"AV28ResidentZipCode","fld":"vRESIDENTZIPCODE"},{"av":"AV27ResidentCity","fld":"vRESIDENTCITY"},{"av":"AV26ResidentCountry","fld":"vRESIDENTCOUNTRY"},{"av":"Combo_residentcountry_Ddointernalname","ctrl":"COMBO_RESIDENTCOUNTRY","prop":"DDOInternalName"},{"av":"AV39ResidentPhoneCode","fld":"vRESIDENTPHONECODE"},{"av":"AV40ResidentPhoneNumber","fld":"vRESIDENTPHONENUMBER"},{"av":"AV44ResidentHomePhoneCode","fld":"vRESIDENTHOMEPHONECODE"},{"av":"AV45ResidentHomePhoneNumber","fld":"vRESIDENTHOMEPHONENUMBER"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV30ResidentAddressLine2","fld":"vRESIDENTADDRESSLINE2"},{"av":"AV21ResidentId","fld":"vRESIDENTID"},{"av":"cmbavResidentsalutation"},{"av":"AV13ResidentSalutation","fld":"vRESIDENTSALUTATION"},{"av":"AV17ResidentBirthDate","fld":"vRESIDENTBIRTHDATE"},{"av":"AV25MedicalIndicationId","fld":"vMEDICALINDICATIONID"},{"av":"AV24ResidentTypeName","fld":"vRESIDENTTYPENAME"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV19ResidentPhone","fld":"vRESIDENTPHONE"},{"av":"AV46ResidentHomePhone","fld":"vRESIDENTHOMEPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E166Q2","iparms":[]}""");
         setEventMetadata("COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED","""{"handler":"E126Q2","iparms":[{"av":"Combo_medicalindicationid_Selectedvalue_get","ctrl":"COMBO_MEDICALINDICATIONID","prop":"SelectedValue_get"},{"av":"Combo_medicalindicationid_Selectedtext_get","ctrl":"COMBO_MEDICALINDICATIONID","prop":"SelectedText_get"},{"av":"AV25MedicalIndicationId","fld":"vMEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"}]""");
         setEventMetadata("COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_medicalindicationid_Selectedvalue_set","ctrl":"COMBO_MEDICALINDICATIONID","prop":"SelectedValue_set"},{"av":"AV25MedicalIndicationId","fld":"vMEDICALINDICATIONID"},{"av":"AV50MedicalIndicationId_Data","fld":"vMEDICALINDICATIONID_DATA"},{"av":"Combo_medicalindicationid_Includeaddnewoption","ctrl":"COMBO_MEDICALINDICATIONID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED","""{"handler":"E116Q2","iparms":[{"av":"Combo_residenttypeid_Selectedvalue_get","ctrl":"COMBO_RESIDENTTYPEID","prop":"SelectedValue_get"},{"av":"Combo_residenttypeid_Selectedtext_get","ctrl":"COMBO_RESIDENTTYPEID","prop":"SelectedText_get"},{"av":"AV23ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"}]""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_residenttypeid_Selectedvalue_set","ctrl":"COMBO_RESIDENTTYPEID","prop":"SelectedValue_set"},{"av":"AV23ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"AV49ResidentTypeId_Data","fld":"vRESIDENTTYPEID_DATA"},{"av":"Combo_residenttypeid_Includeaddnewoption","ctrl":"COMBO_RESIDENTTYPEID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("VRESIDENTEMAIL.CONTROLVALUECHANGED","""{"handler":"E176Q2","iparms":[{"av":"AV18ResidentEmail","fld":"vRESIDENTEMAIL"}]""");
         setEventMetadata("VRESIDENTEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTBSNNUMBER.CONTROLVALUECHANGED","""{"handler":"E186Q2","iparms":[{"av":"AV12ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"}]""");
         setEventMetadata("VRESIDENTBSNNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTZIPCODE.CONTROLVALUECHANGED","""{"handler":"E196Q2","iparms":[{"av":"AV28ResidentZipCode","fld":"vRESIDENTZIPCODE"}]""");
         setEventMetadata("VRESIDENTZIPCODE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E206Q2","iparms":[{"av":"AV40ResidentPhoneNumber","fld":"vRESIDENTPHONENUMBER"}]""");
         setEventMetadata("VRESIDENTPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTHOMEPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E216Q2","iparms":[{"av":"AV45ResidentHomePhoneNumber","fld":"vRESIDENTHOMEPHONENUMBER"}]""");
         setEventMetadata("VRESIDENTHOMEPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_RESIDENTSALUTATION","""{"handler":"Validv_Residentsalutation","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTGENDER","""{"handler":"Validv_Residentgender","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTEMAIL","""{"handler":"Validv_Residentemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTTYPEID","""{"handler":"Validv_Residenttypeid","iparms":[]}""");
         setEventMetadata("VALIDV_MEDICALINDICATIONID","""{"handler":"Validv_Medicalindicationid","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTID","""{"handler":"Validv_Residentid","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         Combo_residenttypeid_Ddointernalname = "";
         Combo_residentcountry_Ddointernalname = "";
         Combo_residentcountry_Selectedvalue_get = "";
         Combo_medicalindicationid_Selectedvalue_get = "";
         Combo_medicalindicationid_Selectedtext_get = "";
         Combo_residenttypeid_Selectedvalue_get = "";
         Combo_residenttypeid_Selectedtext_get = "";
         Combo_residenthomephonecode_Selectedvalue_get = "";
         Combo_residentphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41ResidentPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV47ResidentHomePhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV49ResidentTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV50MedicalIndicationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33ResidentCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A99MedicalIndicationName = "";
         A98MedicalIndicationId = Guid.Empty;
         A97ResidentTypeName = "";
         A96ResidentTypeId = Guid.Empty;
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV13ResidentSalutation = "";
         AV14ResidentGivenName = "";
         AV15ResidentLastName = "";
         AV16ResidentGender = "";
         AV17ResidentBirthDate = DateTime.MinValue;
         AV18ResidentEmail = "";
         lblTextblockcombo_residentphonecode_Jsonclick = "";
         lblTextblockcombo_residenthomephonecode_Jsonclick = "";
         AV12ResidentBsnNumber = "";
         lblTextblockcombo_residenttypeid_Jsonclick = "";
         ucCombo_residenttypeid = new GXUserControl();
         Combo_residenttypeid_Caption = "";
         lblTextblockcombo_medicalindicationid_Jsonclick = "";
         ucCombo_medicalindicationid = new GXUserControl();
         Combo_medicalindicationid_Caption = "";
         AV29ResidentAddressLine1 = "";
         AV30ResidentAddressLine2 = "";
         AV28ResidentZipCode = "";
         AV27ResidentCity = "";
         lblTextblockcombo_residentcountry_Jsonclick = "";
         ucCombo_residentcountry = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV39ResidentPhoneCode = "";
         AV44ResidentHomePhoneCode = "";
         AV23ResidentTypeId = Guid.Empty;
         AV25MedicalIndicationId = Guid.Empty;
         AV26ResidentCountry = "";
         AV21ResidentId = Guid.Empty;
         AV19ResidentPhone = "";
         AV46ResidentHomePhone = "";
         AV24ResidentTypeName = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV40ResidentPhoneNumber = "";
         AV45ResidentHomePhoneNumber = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         ucCombo_residenthomephonecode = new GXUserControl();
         ucCombo_residentphonecode = new GXUserControl();
         AV38defaultCountry = "";
         Combo_residentcountry_Selectedtext_set = "";
         Combo_residentcountry_Selectedvalue_set = "";
         AV43defaultCountryPhoneCode = "";
         Combo_residentphonecode_Selectedtext_set = "";
         Combo_residentphonecode_Selectedvalue_set = "";
         Combo_residenthomephonecode_Selectedtext_set = "";
         Combo_residenthomephonecode_Selectedvalue_set = "";
         AV52DefaultMedicalIndicationName = "";
         AV35ComboSelectedValue = "";
         AV51Session = context.GetSession();
         Combo_medicalindicationid_Selectedvalue_set = "";
         AV53DefaultResidentTypeName = "";
         Combo_residenttypeid_Selectedvalue_set = "";
         AV11WizardData = new SdtWP_CreateResidentAndNetworkData(context);
         AV5WebSession = context.GetSession();
         GXt_char2 = "";
         AV54GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV37ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV32ComboTitles = new GxSimpleCollection<string>();
         H006Q2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H006Q2_A99MedicalIndicationName = new string[] {""} ;
         H006Q3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H006Q3_A97ResidentTypeName = new string[] {""} ;
         AV58GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV48ResidentHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV60GXV5 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV42ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep1__default(),
            new Object[][] {
                new Object[] {
               H006Q2_A98MedicalIndicationId, H006Q2_A99MedicalIndicationName
               }
               , new Object[] {
               H006Q3_A96ResidentTypeId, H006Q3_A97ResidentTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short nGXWrapped ;
      private int edtavResidentgivenname_Enabled ;
      private int edtavResidentlastname_Enabled ;
      private int edtavResidentbirthdate_Enabled ;
      private int edtavResidentemail_Enabled ;
      private int edtavResidentbsnnumber_Enabled ;
      private int edtavResidentaddressline1_Enabled ;
      private int edtavResidentaddressline2_Enabled ;
      private int edtavResidentzipcode_Enabled ;
      private int edtavResidentcity_Enabled ;
      private int edtavResidentphonecode_Visible ;
      private int edtavResidenthomephonecode_Visible ;
      private int edtavResidenttypeid_Visible ;
      private int edtavMedicalindicationid_Visible ;
      private int edtavResidentcountry_Visible ;
      private int edtavResidentid_Visible ;
      private int edtavResidentphone_Visible ;
      private int edtavResidenthomephone_Visible ;
      private int edtavResidenttypename_Visible ;
      private int AV55GXV2 ;
      private int AV59GXV4 ;
      private int AV61GXV6 ;
      private int edtavResidenthomephonenumber_Enabled ;
      private int edtavResidentphonenumber_Enabled ;
      private int idxLst ;
      private string Combo_residenttypeid_Ddointernalname ;
      private string Combo_residentcountry_Ddointernalname ;
      private string Combo_residentcountry_Selectedvalue_get ;
      private string Combo_medicalindicationid_Selectedvalue_get ;
      private string Combo_medicalindicationid_Selectedtext_get ;
      private string Combo_residenttypeid_Selectedvalue_get ;
      private string Combo_residenttypeid_Selectedtext_get ;
      private string Combo_residenthomephonecode_Selectedvalue_get ;
      private string Combo_residentphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
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
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavResidentsalutation_Internalname ;
      private string TempTags ;
      private string AV13ResidentSalutation ;
      private string cmbavResidentsalutation_Jsonclick ;
      private string edtavResidentgivenname_Internalname ;
      private string edtavResidentgivenname_Jsonclick ;
      private string edtavResidentlastname_Internalname ;
      private string edtavResidentlastname_Jsonclick ;
      private string cmbavResidentgender_Internalname ;
      private string cmbavResidentgender_Jsonclick ;
      private string edtavResidentbirthdate_Internalname ;
      private string edtavResidentbirthdate_Jsonclick ;
      private string edtavResidentemail_Internalname ;
      private string edtavResidentemail_Jsonclick ;
      private string divTablesplittedresidentphonecode_Internalname ;
      private string lblTextblockcombo_residentphonecode_Internalname ;
      private string lblTextblockcombo_residentphonecode_Jsonclick ;
      private string divTablesplittedresidenthomephonecode_Internalname ;
      private string lblTextblockcombo_residenthomephonecode_Internalname ;
      private string lblTextblockcombo_residenthomephonecode_Jsonclick ;
      private string edtavResidentbsnnumber_Internalname ;
      private string edtavResidentbsnnumber_Jsonclick ;
      private string divTablesplittedresidenttypeid_Internalname ;
      private string lblTextblockcombo_residenttypeid_Internalname ;
      private string lblTextblockcombo_residenttypeid_Jsonclick ;
      private string Combo_residenttypeid_Caption ;
      private string Combo_residenttypeid_Cls ;
      private string Combo_residenttypeid_Internalname ;
      private string divTablesplittedmedicalindicationid_Internalname ;
      private string lblTextblockcombo_medicalindicationid_Internalname ;
      private string lblTextblockcombo_medicalindicationid_Jsonclick ;
      private string Combo_medicalindicationid_Caption ;
      private string Combo_medicalindicationid_Cls ;
      private string Combo_medicalindicationid_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavResidentaddressline1_Internalname ;
      private string edtavResidentaddressline1_Jsonclick ;
      private string edtavResidentaddressline2_Internalname ;
      private string edtavResidentaddressline2_Jsonclick ;
      private string edtavResidentzipcode_Internalname ;
      private string edtavResidentzipcode_Jsonclick ;
      private string edtavResidentcity_Internalname ;
      private string edtavResidentcity_Jsonclick ;
      private string divTablesplittedresidentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Jsonclick ;
      private string Combo_residentcountry_Caption ;
      private string Combo_residentcountry_Cls ;
      private string Combo_residentcountry_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentphonecode_Internalname ;
      private string edtavResidentphonecode_Jsonclick ;
      private string edtavResidenthomephonecode_Internalname ;
      private string edtavResidenthomephonecode_Jsonclick ;
      private string edtavResidenttypeid_Internalname ;
      private string edtavResidenttypeid_Jsonclick ;
      private string edtavMedicalindicationid_Internalname ;
      private string edtavMedicalindicationid_Jsonclick ;
      private string edtavResidentcountry_Internalname ;
      private string edtavResidentcountry_Jsonclick ;
      private string edtavResidentid_Internalname ;
      private string edtavResidentid_Jsonclick ;
      private string edtavResidentphone_Internalname ;
      private string AV19ResidentPhone ;
      private string edtavResidentphone_Jsonclick ;
      private string edtavResidenthomephone_Internalname ;
      private string AV46ResidentHomePhone ;
      private string edtavResidenthomephone_Jsonclick ;
      private string edtavResidenttypename_Internalname ;
      private string edtavResidenttypename_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavResidentphonenumber_Internalname ;
      private string edtavResidenthomephonenumber_Internalname ;
      private string Combo_residentcountry_Htmltemplate ;
      private string Combo_residenthomephonecode_Htmltemplate ;
      private string Combo_residenthomephonecode_Internalname ;
      private string Combo_residentphonecode_Htmltemplate ;
      private string Combo_residentphonecode_Internalname ;
      private string Combo_residentcountry_Selectedtext_set ;
      private string Combo_residentcountry_Selectedvalue_set ;
      private string Combo_residentphonecode_Selectedtext_set ;
      private string Combo_residentphonecode_Selectedvalue_set ;
      private string Combo_residenthomephonecode_Selectedtext_set ;
      private string Combo_residenthomephonecode_Selectedvalue_set ;
      private string Combo_medicalindicationid_Selectedvalue_set ;
      private string Combo_residenttypeid_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedresidenthomephonecode_Internalname ;
      private string Combo_residenthomephonecode_Caption ;
      private string Combo_residenthomephonecode_Cls ;
      private string edtavResidenthomephonenumber_Jsonclick ;
      private string tblTablemergedresidentphonecode_Internalname ;
      private string Combo_residentphonecode_Caption ;
      private string Combo_residentphonecode_Cls ;
      private string edtavResidentphonenumber_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime AV17ResidentBirthDate ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV31CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_residenttypeid_Emptyitem ;
      private bool Combo_residenttypeid_Includeaddnewoption ;
      private bool Combo_medicalindicationid_Emptyitem ;
      private bool Combo_medicalindicationid_Includeaddnewoption ;
      private bool Combo_residentcountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool GXt_boolean4 ;
      private bool Combo_residenthomephonecode_Emptyitem ;
      private bool Combo_residentphonecode_Emptyitem ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A99MedicalIndicationName ;
      private string A97ResidentTypeName ;
      private string AV14ResidentGivenName ;
      private string AV15ResidentLastName ;
      private string AV16ResidentGender ;
      private string AV18ResidentEmail ;
      private string AV12ResidentBsnNumber ;
      private string AV29ResidentAddressLine1 ;
      private string AV30ResidentAddressLine2 ;
      private string AV28ResidentZipCode ;
      private string AV27ResidentCity ;
      private string AV39ResidentPhoneCode ;
      private string AV44ResidentHomePhoneCode ;
      private string AV26ResidentCountry ;
      private string AV24ResidentTypeName ;
      private string AV40ResidentPhoneNumber ;
      private string AV45ResidentHomePhoneNumber ;
      private string AV38defaultCountry ;
      private string AV43defaultCountryPhoneCode ;
      private string AV52DefaultMedicalIndicationName ;
      private string AV35ComboSelectedValue ;
      private string AV53DefaultResidentTypeName ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid AV23ResidentTypeId ;
      private Guid AV25MedicalIndicationId ;
      private Guid AV21ResidentId ;
      private IGxSession AV51Session ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucCombo_residenttypeid ;
      private GXUserControl ucCombo_medicalindicationid ;
      private GXUserControl ucCombo_residentcountry ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucCombo_residenthomephonecode ;
      private GXUserControl ucCombo_residentphonecode ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResidentsalutation ;
      private GXCombobox cmbavResidentgender ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41ResidentPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV47ResidentHomePhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV49ResidentTypeId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV50MedicalIndicationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33ResidentCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtWP_CreateResidentAndNetworkData AV11WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV54GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV37ResidentCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private GxSimpleCollection<string> AV32ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006Q2_A98MedicalIndicationId ;
      private string[] H006Q2_A99MedicalIndicationName ;
      private Guid[] H006Q3_A96ResidentTypeId ;
      private string[] H006Q3_A97ResidentTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV58GXV3 ;
      private SdtSDT_Country_SDT_CountryItem AV48ResidentHomePhoneCode_DPItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV60GXV5 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV42ResidentPhoneCode_DPItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_createresidentandnetworkstep1__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006Q2;
          prmH006Q2 = new Object[] {
          };
          Object[] prmH006Q3;
          prmH006Q3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006Q2", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication ORDER BY MedicalIndicationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006Q3", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
