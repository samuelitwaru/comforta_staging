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
   public class wp_productservicestep1 : GXWebComponent
   {
      public wp_productservicestep1( )
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

      public wp_productservicestep1( IGxContext context )
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
         this.AV37WebSessionKey = aP0_WebSessionKey;
         this.AV20PreviousStep = aP1_PreviousStep;
         this.AV14GoingBack = aP2_GoingBack;
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
         dynavLocationid = new GXCombobox();
         cmbavProductserviceclass = new GXCombobox();
         dynavProductservicegroup = new GXCombobox();
         chkavNofilteragb = new GXCheckbox();
         chkavNofiltergen = new GXCheckbox();
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
                  AV37WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
                  AV20PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
                  AV14GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV37WebSessionKey,(string)AV20PreviousStep,(bool)AV14GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvLOCATIONID722( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPRODUCTSERVICEGROUP") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDSVvPRODUCTSERVICEGROUP722( ) ;
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
            PA722( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               GXVvLOCATIONID_html722( ) ;
               GXVvPRODUCTSERVICEGROUP_html722( ) ;
               WS722( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Product Service Step1", "")) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            GXEncryptionTmp = "wp_productservicestep1.aspx"+UrlEncode(StringUtil.RTrim(AV37WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV20PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV14GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_productservicestep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV43PreferredAgbSuppliers, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV34UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV34UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERGENID_DATA", AV31SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERGENID_DATA", AV31SupplierGenId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37WebSessionKey", wcpOAV37WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20PreviousStep", wcpOAV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV14GoingBack", wcpOAV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILETYPE", AV11FileType);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV37WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENCOMPANYNAME", A44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENID", A42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERAGBNAME", A51SupplierAgbName);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERAGBID", A49SupplierAgbId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV43PreferredAgbSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTART", AV49isStart);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDGENSUPPLIERS", AV44PreferredGenSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDGENSUPPLIERS", AV44PreferredGenSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV20PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm722( )
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
         return "WP_ProductServiceStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Product Service Step1", "") ;
      }

      protected void WB720( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_productservicestep1.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Product/Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ProductServiceStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLocationid_cell_Internalname, 1, 0, "px", 0, "px", divLocationid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavLocationid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLocationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationid_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationid, dynavLocationid_Internalname, AV16LocationId.ToString(), 1, dynavLocationid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationid.Visible, dynavLocationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            dynavLocationid.CurrentValue = AV16LocationId.ToString();
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Values", (string)(dynavLocationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicename_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicename_Internalname, AV26ProductServiceName, StringUtil.RTrim( context.localUtil.Format( AV26ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicetilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicetilename_Internalname, context.GetMessage( "Tile Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicetilename_Internalname, StringUtil.RTrim( AV27ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( AV27ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicetilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicetilename_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Image", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_42_722( true) ;
         }
         else
         {
            wb_table1_42_722( false) ;
         }
         return  ;
      }

      protected void wb_table1_42_722e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProductserviceclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProductserviceclass_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductserviceclass, cmbavProductserviceclass_Internalname, StringUtil.RTrim( AV39ProductServiceClass), 1, cmbavProductserviceclass_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductserviceclass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV39ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", (string)(cmbavProductserviceclass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavProductservicegroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProductservicegroup_Internalname, context.GetMessage( "Supplier Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProductservicegroup, dynavProductservicegroup_Internalname, StringUtil.RTrim( AV22ProductServiceGroup), 1, dynavProductservicegroup_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavProductservicegroup.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV22ProductServiceGroup);
            AssignProp(sPrefix, false, dynavProductservicegroup_Internalname, "Values", (string)(dynavProductservicegroup.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesupplieragb_Internalname, divTablesupplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_supplieragbid_Internalname, context.GetMessage( "AGB Supplier", ""), "", "", lblTextblockcombo_supplieragbid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table2_76_722( true) ;
         }
         else
         {
            wb_table2_76_722( false) ;
         }
         return  ;
      }

      protected void wb_table2_76_722e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesuppliergen_Internalname, divTablesuppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_suppliergenid_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblockcombo_suppliergenid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table3_93_722( true) ;
         }
         else
         {
            wb_table3_93_722( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_722e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicedescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicedescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductservicedescription_Internalname, AV21ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtavProductservicedescription_Enabled, 0, 40, "chr", 5, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbid_Internalname, AV28SupplierAgbId.ToString(), AV28SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSupplieragbid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenid_Internalname, AV30SupplierGenId.ToString(), AV30SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSuppliergenid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductserviceid_Internalname, AV23ProductServiceId.ToString(), AV23ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProductserviceid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductserviceimagevar_Internalname, AV25ProductServiceImageVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", 0, edtavProductserviceimagevar_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START722( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Product Service Step1", ""), 0) ;
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
               STRUP720( ) ;
            }
         }
      }

      protected void WS722( )
      {
         START722( ) ;
         EVT722( ) ;
      }

      protected void EVT722( )
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
                                 STRUP720( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                                    E11722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                                    E12722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E14722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
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
                                          E15722 ();
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
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E16722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOFILTERGEN.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E18722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOFILTERAGB.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E19722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.REFRESHPREFERREDSUPPLIER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E21722 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = dynavLocationid_Internalname;
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

      protected void WE722( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm722( ) ;
            }
         }
      }

      protected void PA722( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_productservicestep1.aspx")), "wp_productservicestep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_productservicestep1.aspx")))) ;
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
               GX_FocusControl = dynavLocationid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONID722( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONID_data722( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONID_html722( )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONID_data722( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONID_data722( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H00722 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H00722_A11OrganisationId[0] == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H00722_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H00722_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDSVvPRODUCTSERVICEGROUP722( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDSVvPRODUCTSERVICEGROUP_data722( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrldescr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrldescr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPRODUCTSERVICEGROUP_html722( )
      {
         string gxdynajaxvalue;
         GXDSVvPRODUCTSERVICEGROUP_data722( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProductservicegroup.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavProductservicegroup.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDSVvPRODUCTSERVICEGROUP_data722( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Supplier Type", ""));
         GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> gxcolvPRODUCTSERVICEGROUP;
         SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem gxcolitemvPRODUCTSERVICEGROUP;
         new dp_productservicesuppliergroup(context ).execute( out  gxcolvPRODUCTSERVICEGROUP) ;
         gxcolvPRODUCTSERVICEGROUP.Sort("Sdt_productservicesuppliergroupname");
         int gxindex = 1;
         while ( gxindex <= gxcolvPRODUCTSERVICEGROUP.Count )
         {
            gxcolitemvPRODUCTSERVICEGROUP = ((SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem)gxcolvPRODUCTSERVICEGROUP.Item(gxindex));
            gxdynajaxctrlcodr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupid);
            gxdynajaxctrldescr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupname);
            gxindex = (int)(gxindex+1);
         }
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONID_html722( ) ;
            GXVvPRODUCTSERVICEGROUP_html722( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationid.ItemCount > 0 )
         {
            AV16LocationId = StringUtil.StrToGuid( dynavLocationid.getValidValue(AV16LocationId.ToString()));
            AssignAttri(sPrefix, false, "AV16LocationId", AV16LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationid.CurrentValue = AV16LocationId.ToString();
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Values", dynavLocationid.ToJavascriptSource(), true);
         }
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
            AV39ProductServiceClass = cmbavProductserviceclass.getValidValue(AV39ProductServiceClass);
            AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV39ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", cmbavProductserviceclass.ToJavascriptSource(), true);
         }
         if ( dynavProductservicegroup.ItemCount > 0 )
         {
            AV22ProductServiceGroup = dynavProductservicegroup.getValidValue(AV22ProductServiceGroup);
            AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV22ProductServiceGroup);
            AssignProp(sPrefix, false, dynavProductservicegroup_Internalname, "Values", dynavProductservicegroup.ToJavascriptSource(), true);
         }
         AV46noFilterAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV46noFilterAgb));
         AssignAttri(sPrefix, false, "AV46noFilterAgb", AV46noFilterAgb);
         AV47noFilterGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV47noFilterGen));
         AssignAttri(sPrefix, false, "AV47noFilterGen", AV47noFilterGen);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF722( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
      }

      protected void RF722( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E14722 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E21722 ();
            WB720( ) ;
         }
      }

      protected void send_integrity_lvl_hashes722( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV43PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV43PreferredAgbSuppliers, context));
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         GXVvLOCATIONID_html722( ) ;
         GXVvPRODUCTSERVICEGROUP_html722( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP720( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13722 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV34UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV9FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERAGBID_DATA"), AV29SupplierAgbId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERGENID_DATA"), AV31SupplierGenId_Data);
            /* Read saved values. */
            wcpOAV37WebSessionKey = cgiGet( sPrefix+"wcpOAV37WebSessionKey");
            wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
            wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
            Combo_suppliergenid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get");
            Combo_supplieragbid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get");
            /* Read variables values. */
            dynavLocationid.CurrentValue = cgiGet( dynavLocationid_Internalname);
            AV16LocationId = StringUtil.StrToGuid( cgiGet( dynavLocationid_Internalname));
            AssignAttri(sPrefix, false, "AV16LocationId", AV16LocationId.ToString());
            AV26ProductServiceName = cgiGet( edtavProductservicename_Internalname);
            AssignAttri(sPrefix, false, "AV26ProductServiceName", AV26ProductServiceName);
            AV27ProductServiceTileName = cgiGet( edtavProductservicetilename_Internalname);
            AssignAttri(sPrefix, false, "AV27ProductServiceTileName", AV27ProductServiceTileName);
            AV10FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            cmbavProductserviceclass.CurrentValue = cgiGet( cmbavProductserviceclass_Internalname);
            AV39ProductServiceClass = cgiGet( cmbavProductserviceclass_Internalname);
            AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
            dynavProductservicegroup.CurrentValue = cgiGet( dynavProductservicegroup_Internalname);
            AV22ProductServiceGroup = cgiGet( dynavProductservicegroup_Internalname);
            AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
            AV46noFilterAgb = StringUtil.StrToBool( cgiGet( chkavNofilteragb_Internalname));
            AssignAttri(sPrefix, false, "AV46noFilterAgb", AV46noFilterAgb);
            AV47noFilterGen = StringUtil.StrToBool( cgiGet( chkavNofiltergen_Internalname));
            AssignAttri(sPrefix, false, "AV47noFilterGen", AV47noFilterGen);
            AV21ProductServiceDescription = cgiGet( edtavProductservicedescription_Internalname);
            AssignAttri(sPrefix, false, "AV21ProductServiceDescription", AV21ProductServiceDescription);
            if ( StringUtil.StrCmp(cgiGet( edtavSupplieragbid_Internalname), "") == 0 )
            {
               AV28SupplierAgbId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            }
            else
            {
               try
               {
                  AV28SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavSupplieragbid_Internalname));
                  AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERAGBID");
                  GX_FocusControl = edtavSupplieragbid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSuppliergenid_Internalname), "") == 0 )
            {
               AV30SupplierGenId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
            }
            else
            {
               try
               {
                  AV30SupplierGenId = StringUtil.StrToGuid( cgiGet( edtavSuppliergenid_Internalname));
                  AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERGENID");
                  GX_FocusControl = edtavSuppliergenid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavProductserviceid_Internalname), "") == 0 )
            {
               AV23ProductServiceId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
            }
            else
            {
               try
               {
                  AV23ProductServiceId = StringUtil.StrToGuid( cgiGet( edtavProductserviceid_Internalname));
                  AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vPRODUCTSERVICEID");
                  GX_FocusControl = edtavProductserviceid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV25ProductServiceImageVar = cgiGet( edtavProductserviceimagevar_Internalname);
            AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXVvLOCATIONID_html722( ) ;
            GXVvPRODUCTSERVICEGROUP_html722( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13722 ();
         if (returnInSub) return;
      }

      protected void E13722( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV43PreferredAgbSuppliers;
         new prc_getpreferredagbsuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV43PreferredAgbSuppliers = GXt_objcol_guid1;
         GXt_objcol_guid1 = AV44PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV44PreferredGenSuppliers = GXt_objcol_guid1;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavSuppliergenid_Visible = 0;
         AssignProp(sPrefix, false, edtavSuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergenid_Visible), 5, 0), true);
         edtavSupplieragbid_Visible = 0;
         AssignProp(sPrefix, false, edtavSupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         edtavProductserviceid_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceid_Visible), 5, 0), true);
         edtavProductserviceimagevar_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceimagevar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceimagevar_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ProductServiceImageVar)) )
         {
            lblUseractiondelete_Visible = 0;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
         }
         else
         {
            lblUseractiondelete_Visible = 1;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
         }
         if ( (Guid.Empty==AV28SupplierAgbId) )
         {
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         else
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         if ( (Guid.Empty==AV30SupplierGenId) )
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
         else
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(AV22ProductServiceGroup, " AGB Supplier") == 0 )
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         else if ( StringUtil.StrCmp(AV22ProductServiceGroup, "General Supplier") == 0 )
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         }
         else
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         AV49isStart = true;
         AssignAttri(sPrefix, false, "AV49isStart", AV49isStart);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         GXt_SdtGAMUser2 = AV50GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser2) ;
         AV50GAMUser = GXt_SdtGAMUser2;
         if ( AV50GAMUser.checkrole("Organisation Manager") || AV50GAMUser.checkrole("Root Admin") )
         {
            dynavLocationid.Visible = 1;
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationid.Visible), 5, 0), true);
         }
         else
         {
            dynavLocationid.Visible = 0;
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationid.Visible), 5, 0), true);
         }
      }

      protected void E14722( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV14GoingBack = false;
         AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E15722 ();
         if (returnInSub) return;
      }

      protected void E15722( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S172 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV15HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S182 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E16722( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         CallWebObject(formatLink("trn_productserviceww.aspx") );
         context.wjLocDisableFrm = 1;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12722( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         AV28SupplierAgbId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewgeneralsupplier.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV30SupplierGenId.ToString());
            context.PopUp(formatLink("wp_createnewgeneralsupplier.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S132 ();
            if (returnInSub) return;
            AV7ComboSelectedValue = AV48Session.Get("SUPPLIERGENID");
            AV48Session.Remove("SUPPLIERGENID");
            Combo_suppliergenid_Selectedvalue_set = AV7ComboSelectedValue;
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
            AV30SupplierGenId = StringUtil.StrToGuid( AV7ComboSelectedValue);
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         else
         {
            AV30SupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SupplierGenId_Data", AV31SupplierGenId_Data);
      }

      protected void E11722( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV30SupplierGenId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         AV28SupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV14GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV38WizardData.FromJSonString(AV36WebSession.Get(AV37WebSessionKey), null);
         AV39ProductServiceClass = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceclass;
         AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
         AV22ProductServiceGroup = AV38WizardData.gxTpr_Step1.gxTpr_Productservicegroup;
         AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
         AV21ProductServiceDescription = AV38WizardData.gxTpr_Step1.gxTpr_Productservicedescription;
         AssignAttri(sPrefix, false, "AV21ProductServiceDescription", AV21ProductServiceDescription);
         AV30SupplierGenId = AV38WizardData.gxTpr_Step1.gxTpr_Suppliergenid;
         AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         AV47noFilterGen = AV38WizardData.gxTpr_Step1.gxTpr_Nofiltergen;
         AssignAttri(sPrefix, false, "AV47noFilterGen", AV47noFilterGen);
         AV28SupplierAgbId = AV38WizardData.gxTpr_Step1.gxTpr_Supplieragbid;
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         AV46noFilterAgb = AV38WizardData.gxTpr_Step1.gxTpr_Nofilteragb;
         AssignAttri(sPrefix, false, "AV46noFilterAgb", AV46noFilterAgb);
         AV16LocationId = AV38WizardData.gxTpr_Step1.gxTpr_Locationid;
         AssignAttri(sPrefix, false, "AV16LocationId", AV16LocationId.ToString());
         AV23ProductServiceId = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceid;
         AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
         AV26ProductServiceName = AV38WizardData.gxTpr_Step1.gxTpr_Productservicename;
         AssignAttri(sPrefix, false, "AV26ProductServiceName", AV26ProductServiceName);
         AV27ProductServiceTileName = AV38WizardData.gxTpr_Step1.gxTpr_Productservicetilename;
         AssignAttri(sPrefix, false, "AV27ProductServiceTileName", AV27ProductServiceTileName);
         AV25ProductServiceImageVar = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar;
         AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
         AV10FileName = AV38WizardData.gxTpr_Step1.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
      }

      protected void S182( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         if ( AV34UploadedFiles.Count > 0 )
         {
            AV25ProductServiceImageVar = context.FileToBase64( ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_File);
            AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
            AV10FileName = ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_Fullname;
            AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            AV11FileType = ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_Extension;
            AssignAttri(sPrefix, false, "AV11FileType", AV11FileType);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ProductServiceImageVar)) )
            {
               AV25ProductServiceImageVar = "";
               AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
               AV10FileName = "";
               AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            }
            else
            {
               AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
               AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
               AssignAttri(sPrefix, false, "AV11FileType", AV11FileType);
            }
         }
         if ( StringUtil.StrCmp(AV22ProductServiceGroup, "Location") == 0 )
         {
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         AV23ProductServiceId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
         AV38WizardData.FromJSonString(AV36WebSession.Get(AV37WebSessionKey), null);
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceclass = AV39ProductServiceClass;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicegroup = AV22ProductServiceGroup;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicedescription = AV21ProductServiceDescription;
         AV38WizardData.gxTpr_Step1.gxTpr_Suppliergenid = AV30SupplierGenId;
         AV38WizardData.gxTpr_Step1.gxTpr_Nofiltergen = AV47noFilterGen;
         AV38WizardData.gxTpr_Step1.gxTpr_Supplieragbid = AV28SupplierAgbId;
         AV38WizardData.gxTpr_Step1.gxTpr_Nofilteragb = AV46noFilterAgb;
         AV38WizardData.gxTpr_Step1.gxTpr_Locationid = AV16LocationId;
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceid = AV23ProductServiceId;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicename = AV26ProductServiceName;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicetilename = AV27ProductServiceTileName;
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar = AV25ProductServiceImageVar;
         AV38WizardData.gxTpr_Step1.gxTpr_Filename = AV10FileName;
         AV36WebSession.Set(AV37WebSessionKey, AV38WizardData.ToJSonString(false, true));
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( ( AV50GAMUser.checkrole("Organisation Manager") || AV50GAMUser.checkrole("Root Admin") ) && (Guid.Empty==AV16LocationId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Location", ""), "", "", "", "", "", "", "", ""),  "error",  dynavLocationid_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ProductServiceName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavProductservicename_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ProductServiceTileName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Tile Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavProductservicetilename_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ProductServiceClass)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavProductserviceclass_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV50GAMUser.checkrole("Organisation Manager") || AV50GAMUser.checkrole("Root Admin") )
         {
            divLocationid_cell_Class = "col-xs-12 RequiredDataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         else
         {
            divLocationid_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         AV31SupplierGenId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean3) ;
         Combo_suppliergenid_Includeaddnewoption = GXt_boolean3;
         ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_suppliergenid_Includeaddnewoption));
         /* Using cursor H00723 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A42SupplierGenId = H00723_A42SupplierGenId[0];
            A44SupplierGenCompanyName = H00723_A44SupplierGenCompanyName[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV6Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV31SupplierGenId_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV30SupplierGenId) ? "" : StringUtil.Trim( AV30SupplierGenId.ToString()));
         ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV43PreferredAgbSuppliers } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H00724 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A49SupplierAgbId = H00724_A49SupplierAgbId[0];
            A51SupplierAgbName = H00724_A51SupplierAgbName[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV6Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV29SupplierAgbId_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV28SupplierAgbId) ? "" : StringUtil.Trim( AV28SupplierAgbId.ToString()));
         ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
      }

      protected void E17722( )
      {
         /* Productservicegroup_Controlvaluechanged Routine */
         returnInSub = false;
         AV46noFilterAgb = true;
         AssignAttri(sPrefix, false, "AV46noFilterAgb", AV46noFilterAgb);
         AV47noFilterGen = true;
         AssignAttri(sPrefix, false, "AV47noFilterGen", AV47noFilterGen);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV22ProductServiceGroup, " AGB Supplier") == 0 )
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         else if ( StringUtil.StrCmp(AV22ProductServiceGroup, "General Supplier") == 0 )
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         }
         else
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29SupplierAgbId_Data", AV29SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SupplierGenId_Data", AV31SupplierGenId_Data);
      }

      protected void E18722( )
      {
         /* Nofiltergen_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29SupplierAgbId_Data", AV29SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SupplierGenId_Data", AV31SupplierGenId_Data);
      }

      protected void E19722( )
      {
         /* Nofilteragb_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29SupplierAgbId_Data", AV29SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SupplierGenId_Data", AV31SupplierGenId_Data);
      }

      protected void E20722( )
      {
         /* General\GlobalEvents_Refreshpreferredsupplier Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV44PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV44PreferredGenSuppliers = GXt_objcol_guid1;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV44PreferredGenSuppliers", AV44PreferredGenSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29SupplierAgbId_Data", AV29SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31SupplierGenId_Data", AV31SupplierGenId_Data);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID_GENID' Routine */
         returnInSub = false;
         AV29SupplierAgbId_Data.Clear();
         AV31SupplierGenId_Data.Clear();
         if ( ! AV46noFilterAgb && ( StringUtil.StrCmp(AV22ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            /* Using cursor H00725 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49SupplierAgbId = H00725_A49SupplierAgbId[0];
               A51SupplierAgbName = H00725_A51SupplierAgbName[0];
               AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV6Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV29SupplierAgbId_Data.Add(AV6Combo_DataItem, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV28SupplierAgbId) ? "" : StringUtil.Trim( AV28SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ( AV46noFilterAgb ) && ( StringUtil.StrCmp(AV22ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 A49SupplierAgbId ,
                                                 AV43PreferredAgbSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00726 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               A49SupplierAgbId = H00726_A49SupplierAgbId[0];
               A51SupplierAgbName = H00726_A51SupplierAgbName[0];
               AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV6Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV29SupplierAgbId_Data.Add(AV6Combo_DataItem, 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( ! AV49isStart )
            {
               AV28SupplierAgbId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            }
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV28SupplierAgbId) ? "" : StringUtil.Trim( AV28SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ! AV47noFilterGen && ( StringUtil.StrCmp(AV22ProductServiceGroup, "General Supplier") == 0 ) )
         {
            /* Using cursor H00727 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A42SupplierGenId = H00727_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H00727_A44SupplierGenCompanyName[0];
               AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV6Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV31SupplierGenId_Data.Add(AV6Combo_DataItem, 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV30SupplierGenId) ? "" : StringUtil.Trim( AV30SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         else if ( ( AV47noFilterGen ) && ( StringUtil.StrCmp(AV22ProductServiceGroup, "General Supplier") == 0 ) )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 A42SupplierGenId ,
                                                 AV44PreferredGenSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00728 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A42SupplierGenId = H00728_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H00728_A44SupplierGenCompanyName[0];
               AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV6Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV31SupplierGenId_Data.Add(AV6Combo_DataItem, 0);
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( ! AV49isStart )
            {
               AV30SupplierGenId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
            }
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV30SupplierGenId) ? "" : StringUtil.Trim( AV30SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         AV49isStart = false;
         AssignAttri(sPrefix, false, "AV49isStart", AV49isStart);
      }

      protected void nextLoad( )
      {
      }

      protected void E21722( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_93_722( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergenid_Internalname, tblTablemergedsuppliergenid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
            ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
            ucCombo_suppliergenid.SetProperty("EmptyItem", Combo_suppliergenid_Emptyitem);
            ucCombo_suppliergenid.SetProperty("IncludeAddNewOption", Combo_suppliergenid_Includeaddnewoption);
            ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV31SupplierGenId_Data);
            ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, sPrefix+"COMBO_SUPPLIERGENIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofiltergen_Internalname, context.GetMessage( "no Filter Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofiltergen_Internalname, StringUtil.BoolToStr( AV47noFilterGen), "", context.GetMessage( "no Filter Gen", ""), 1, chkavNofiltergen.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_722e( true) ;
         }
         else
         {
            wb_table3_93_722e( false) ;
         }
      }

      protected void wb_table2_76_722( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragbid_Internalname, tblTablemergedsupplieragbid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
            ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
            ucCombo_supplieragbid.SetProperty("EmptyItem", Combo_supplieragbid_Emptyitem);
            ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV29SupplierAgbId_Data);
            ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, sPrefix+"COMBO_SUPPLIERAGBIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofilteragb_Internalname, context.GetMessage( "no Filter Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofilteragb_Internalname, StringUtil.BoolToStr( AV46noFilterAgb), "", context.GetMessage( "no Filter Agb", ""), 1, chkavNofilteragb.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_76_722e( true) ;
         }
         else
         {
            wb_table2_76_722e( false) ;
         }
      }

      protected void wb_table1_42_722( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedusercontrol1_Internalname, tblTablemergedusercontrol1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUsercontrol1.SetProperty("AutoUpload", Usercontrol1_Autoupload);
            ucUsercontrol1.SetProperty("HideAdditionalButtons", Usercontrol1_Hideadditionalbuttons);
            ucUsercontrol1.SetProperty("TooltipText", Usercontrol1_Tooltiptext);
            ucUsercontrol1.SetProperty("EnableUploadedFileCanceling", Usercontrol1_Enableuploadedfilecanceling);
            ucUsercontrol1.SetProperty("DisableImageResize", Usercontrol1_Disableimageresize);
            ucUsercontrol1.SetProperty("MaxFileSize", Usercontrol1_Maxfilesize);
            ucUsercontrol1.SetProperty("MaxNumberOfFiles", Usercontrol1_Maxnumberoffiles);
            ucUsercontrol1.SetProperty("AutoDisableAddingFiles", Usercontrol1_Autodisableaddingfiles);
            ucUsercontrol1.SetProperty("AcceptedFileTypes", Usercontrol1_Acceptedfiletypes);
            ucUsercontrol1.SetProperty("UploadedFiles", AV34UploadedFiles);
            ucUsercontrol1.SetProperty("FailedFiles", AV9FailedFiles);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV10FileName, StringUtil.RTrim( context.localUtil.Format( AV10FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavFilename_Visible, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseractiondelete_Internalname, context.GetMessage( "<i class=\"fas fa-trash-can\"></i>", ""), "", "", lblUseractiondelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e22721_client"+"'", "", "TextBlock", 7, "", lblUseractiondelete_Visible, 1, 0, 1, "HLP_WP_ProductServiceStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_42_722e( true) ;
         }
         else
         {
            wb_table1_42_722e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV37WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
         AV20PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         AV14GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
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
         PA722( ) ;
         WS722( ) ;
         WE722( ) ;
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
         sCtrlAV37WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV20PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV14GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA722( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_productservicestep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA722( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV37WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
            AV20PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
            AV14GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         wcpOAV37WebSessionKey = cgiGet( sPrefix+"wcpOAV37WebSessionKey");
         wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
         wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV37WebSessionKey, wcpOAV37WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV20PreviousStep, wcpOAV20PreviousStep) != 0 ) || ( AV14GoingBack != wcpOAV14GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV37WebSessionKey = AV37WebSessionKey;
         wcpOAV20PreviousStep = AV20PreviousStep;
         wcpOAV14GoingBack = AV14GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV37WebSessionKey = cgiGet( sPrefix+"AV37WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV37WebSessionKey) > 0 )
         {
            AV37WebSessionKey = cgiGet( sCtrlAV37WebSessionKey);
            AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
         }
         else
         {
            AV37WebSessionKey = cgiGet( sPrefix+"AV37WebSessionKey_PARM");
         }
         sCtrlAV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV20PreviousStep) > 0 )
         {
            AV20PreviousStep = cgiGet( sCtrlAV20PreviousStep);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         }
         else
         {
            AV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_PARM");
         }
         sCtrlAV14GoingBack = cgiGet( sPrefix+"AV14GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV14GoingBack) > 0 )
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV14GoingBack));
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         else
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV14GoingBack_PARM"));
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
         PA722( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS722( ) ;
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
         WS722( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37WebSessionKey_PARM", AV37WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV37WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_PARM", AV20PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV20PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_PARM", StringUtil.BoolToStr( AV14GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_CTRL", StringUtil.RTrim( sCtrlAV14GoingBack));
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
         WE722( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411291429215", true, true);
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
         context.AddJavascriptSource("wp_productservicestep1.js", "?202411291429219", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         dynavLocationid.Name = "vLOCATIONID";
         dynavLocationid.WebTags = "";
         cmbavProductserviceclass.Name = "vPRODUCTSERVICECLASS";
         cmbavProductserviceclass.WebTags = "";
         cmbavProductserviceclass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbavProductserviceclass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbavProductserviceclass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbavProductserviceclass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
         }
         dynavProductservicegroup.Name = "vPRODUCTSERVICEGROUP";
         dynavProductservicegroup.WebTags = "";
         chkavNofilteragb.Name = "vNOFILTERAGB";
         chkavNofilteragb.WebTags = "";
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         AssignProp(sPrefix, false, chkavNofilteragb_Internalname, "TitleCaption", chkavNofilteragb.Caption, true);
         chkavNofilteragb.CheckedValue = "false";
         chkavNofiltergen.Name = "vNOFILTERGEN";
         chkavNofiltergen.WebTags = "";
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         AssignProp(sPrefix, false, chkavNofiltergen_Internalname, "TitleCaption", chkavNofiltergen.Caption, true);
         chkavNofiltergen.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavLocationid_Internalname = sPrefix+"vLOCATIONID";
         divLocationid_cell_Internalname = sPrefix+"LOCATIONID_CELL";
         edtavProductservicename_Internalname = sPrefix+"vPRODUCTSERVICENAME";
         edtavProductservicetilename_Internalname = sPrefix+"vPRODUCTSERVICETILENAME";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         lblUseractiondelete_Internalname = sPrefix+"USERACTIONDELETE";
         tblTablemergedusercontrol1_Internalname = sPrefix+"TABLEMERGEDUSERCONTROL1";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         cmbavProductserviceclass_Internalname = sPrefix+"vPRODUCTSERVICECLASS";
         dynavProductservicegroup_Internalname = sPrefix+"vPRODUCTSERVICEGROUP";
         lblTextblockcombo_supplieragbid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERAGBID";
         Combo_supplieragbid_Internalname = sPrefix+"COMBO_SUPPLIERAGBID";
         chkavNofilteragb_Internalname = sPrefix+"vNOFILTERAGB";
         tblTablemergedsupplieragbid_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGBID";
         divTablesupplieragb_Internalname = sPrefix+"TABLESUPPLIERAGB";
         lblTextblockcombo_suppliergenid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERGENID";
         Combo_suppliergenid_Internalname = sPrefix+"COMBO_SUPPLIERGENID";
         chkavNofiltergen_Internalname = sPrefix+"vNOFILTERGEN";
         tblTablemergedsuppliergenid_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGENID";
         divTablesuppliergen_Internalname = sPrefix+"TABLESUPPLIERGEN";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         edtavProductservicedescription_Internalname = sPrefix+"vPRODUCTSERVICEDESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSupplieragbid_Internalname = sPrefix+"vSUPPLIERAGBID";
         edtavSuppliergenid_Internalname = sPrefix+"vSUPPLIERGENID";
         edtavProductserviceid_Internalname = sPrefix+"vPRODUCTSERVICEID";
         edtavProductserviceimagevar_Internalname = sPrefix+"vPRODUCTSERVICEIMAGEVAR";
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
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         lblUseractiondelete_Visible = 1;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         edtavFilename_Visible = 1;
         Usercontrol1_Acceptedfiletypes = "image";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Maxfilesize = 134217728;
         Usercontrol1_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         chkavNofilteragb.Enabled = 1;
         Combo_supplieragbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbid_Cls = "ExtendedCombo Attribute";
         chkavNofiltergen.Enabled = 1;
         Combo_suppliergenid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergenid_Includeaddnewoption = Convert.ToBoolean( -1);
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavProductserviceimagevar_Visible = 1;
         edtavProductserviceid_Jsonclick = "";
         edtavProductserviceid_Visible = 1;
         edtavSuppliergenid_Jsonclick = "";
         edtavSuppliergenid_Visible = 1;
         edtavSupplieragbid_Jsonclick = "";
         edtavSupplieragbid_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         edtavProductservicedescription_Enabled = 1;
         divTablesuppliergen_Visible = 1;
         divTablesupplieragb_Visible = 1;
         dynavProductservicegroup_Jsonclick = "";
         dynavProductservicegroup.Enabled = 1;
         cmbavProductserviceclass_Jsonclick = "";
         cmbavProductserviceclass.Enabled = 1;
         edtavProductservicetilename_Jsonclick = "";
         edtavProductservicetilename_Enabled = 1;
         edtavProductservicename_Jsonclick = "";
         edtavProductservicename_Enabled = 1;
         dynavLocationid_Jsonclick = "";
         dynavLocationid.Enabled = 1;
         dynavLocationid.Visible = 1;
         divLocationid_cell_Class = "col-xs-12";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationid"},{"av":"AV16LocationId","fld":"vLOCATIONID"},{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV43PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E15722","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"dynavLocationid"},{"av":"AV16LocationId","fld":"vLOCATIONID"},{"av":"AV26ProductServiceName","fld":"vPRODUCTSERVICENAME"},{"av":"AV27ProductServiceTileName","fld":"vPRODUCTSERVICETILENAME"},{"av":"cmbavProductserviceclass"},{"av":"AV39ProductServiceClass","fld":"vPRODUCTSERVICECLASS"},{"av":"AV34UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"AV11FileType","fld":"vFILETYPE"},{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV37WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV21ProductServiceDescription","fld":"vPRODUCTSERVICEDESCRIPTION"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV11FileType","fld":"vFILETYPE"},{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV23ProductServiceId","fld":"vPRODUCTSERVICEID"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E16722","iparms":[]}""");
         setEventMetadata("'DOUSERACTIONDELETE'","""{"handler":"E22721","iparms":[]""");
         setEventMetadata("'DOUSERACTIONDELETE'",""","oparms":[{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"lblUseractiondelete_Visible","ctrl":"USERACTIONDELETE","prop":"Visible"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E12722","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV31SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_suppliergenid_Includeaddnewoption","ctrl":"COMBO_SUPPLIERGENID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E11722","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"}]}""");
         setEventMetadata("VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED","""{"handler":"E17722","iparms":[{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV43PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV49isStart","fld":"vISSTART"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV44PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"}]""");
         setEventMetadata("VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"divTablesupplieragb_Visible","ctrl":"TABLESUPPLIERAGB","prop":"Visible"},{"av":"divTablesuppliergen_Visible","ctrl":"TABLESUPPLIERGEN","prop":"Visible"},{"av":"AV29SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV31SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV49isStart","fld":"vISSTART"}]}""");
         setEventMetadata("VNOFILTERGEN.CONTROLVALUECHANGED","""{"handler":"E18722","iparms":[{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV43PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV49isStart","fld":"vISSTART"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV44PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"}]""");
         setEventMetadata("VNOFILTERGEN.CONTROLVALUECHANGED",""","oparms":[{"av":"AV29SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV31SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV49isStart","fld":"vISSTART"}]}""");
         setEventMetadata("VNOFILTERAGB.CONTROLVALUECHANGED","""{"handler":"E19722","iparms":[{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV43PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV49isStart","fld":"vISSTART"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV44PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"}]""");
         setEventMetadata("VNOFILTERAGB.CONTROLVALUECHANGED",""","oparms":[{"av":"AV29SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV31SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV49isStart","fld":"vISSTART"}]}""");
         setEventMetadata("GLOBALEVENTS.REFRESHPREFERREDSUPPLIER","""{"handler":"E20722","iparms":[{"av":"AV46noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV43PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV49isStart","fld":"vISSTART"},{"av":"AV47noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV44PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"}]""");
         setEventMetadata("GLOBALEVENTS.REFRESHPREFERREDSUPPLIER",""","oparms":[{"av":"AV44PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV29SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV31SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV49isStart","fld":"vISSTART"}]}""");
         setEventMetadata("VALIDV_LOCATIONID","""{"handler":"Validv_Locationid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERAGBID","""{"handler":"Validv_Supplieragbid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERGENID","""{"handler":"Validv_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEID","""{"handler":"Validv_Productserviceid","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV37WebSessionKey = "";
         wcpOAV20PreviousStep = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         Combo_supplieragbid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV43PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV34UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV9FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV29SupplierAgbId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31SupplierGenId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11FileType = "";
         A44SupplierGenCompanyName = "";
         A42SupplierGenId = Guid.Empty;
         A51SupplierAgbName = "";
         A49SupplierAgbId = Guid.Empty;
         AV44PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV16LocationId = Guid.Empty;
         AV26ProductServiceName = "";
         AV27ProductServiceTileName = "";
         lblProductserviceimagetext_Jsonclick = "";
         AV39ProductServiceClass = "";
         AV22ProductServiceGroup = "";
         lblTextblockcombo_supplieragbid_Jsonclick = "";
         lblTextblockcombo_suppliergenid_Jsonclick = "";
         AV21ProductServiceDescription = "";
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV28SupplierAgbId = Guid.Empty;
         AV30SupplierGenId = Guid.Empty;
         AV23ProductServiceId = Guid.Empty;
         AV25ProductServiceImageVar = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00722_A29LocationId = new Guid[] {Guid.Empty} ;
         H00722_A31LocationName = new string[] {""} ;
         H00722_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV10FileName = "";
         AV50GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser2 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV7ComboSelectedValue = "";
         AV48Session = context.GetSession();
         Combo_suppliergenid_Selectedvalue_set = "";
         ucCombo_suppliergenid = new GXUserControl();
         AV38WizardData = new SdtWP_ProductServiceData(context);
         AV36WebSession = context.GetSession();
         H00723_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00723_A44SupplierGenCompanyName = new string[] {""} ;
         AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00724_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00724_A51SupplierAgbName = new string[] {""} ;
         Combo_supplieragbid_Selectedvalue_set = "";
         ucCombo_supplieragbid = new GXUserControl();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         H00725_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00725_A51SupplierAgbName = new string[] {""} ;
         H00726_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00726_A51SupplierAgbName = new string[] {""} ;
         H00727_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00727_A44SupplierGenCompanyName = new string[] {""} ;
         H00728_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00728_A44SupplierGenCompanyName = new string[] {""} ;
         sStyleString = "";
         Combo_suppliergenid_Caption = "";
         Combo_supplieragbid_Caption = "";
         ucUsercontrol1 = new GXUserControl();
         lblUseractiondelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV37WebSessionKey = "";
         sCtrlAV20PreviousStep = "";
         sCtrlAV14GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_productservicestep1__default(),
            new Object[][] {
                new Object[] {
               H00722_A29LocationId, H00722_A31LocationName, H00722_A11OrganisationId
               }
               , new Object[] {
               H00723_A42SupplierGenId, H00723_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00724_A49SupplierAgbId, H00724_A51SupplierAgbName
               }
               , new Object[] {
               H00725_A49SupplierAgbId, H00725_A51SupplierAgbName
               }
               , new Object[] {
               H00726_A49SupplierAgbId, H00726_A51SupplierAgbName
               }
               , new Object[] {
               H00727_A42SupplierGenId, H00727_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00728_A42SupplierGenId, H00728_A44SupplierGenCompanyName
               }
            }
         );
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
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
      private int edtavFilename_Enabled ;
      private int edtavProductservicename_Enabled ;
      private int edtavProductservicetilename_Enabled ;
      private int divTablesupplieragb_Visible ;
      private int divTablesuppliergen_Visible ;
      private int edtavProductservicedescription_Enabled ;
      private int edtavSupplieragbid_Visible ;
      private int edtavSuppliergenid_Visible ;
      private int edtavProductserviceid_Visible ;
      private int edtavProductserviceimagevar_Visible ;
      private int gxdynajaxindex ;
      private int lblUseractiondelete_Visible ;
      private int Usercontrol1_Maxfilesize ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int edtavFilename_Visible ;
      private int idxLst ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFilename_Internalname ;
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
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divLocationid_cell_Internalname ;
      private string divLocationid_cell_Class ;
      private string dynavLocationid_Internalname ;
      private string TempTags ;
      private string dynavLocationid_Jsonclick ;
      private string edtavProductservicename_Internalname ;
      private string edtavProductservicename_Jsonclick ;
      private string edtavProductservicetilename_Internalname ;
      private string AV27ProductServiceTileName ;
      private string edtavProductservicetilename_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string cmbavProductserviceclass_Internalname ;
      private string cmbavProductserviceclass_Jsonclick ;
      private string dynavProductservicegroup_Internalname ;
      private string dynavProductservicegroup_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTablesupplieragb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Jsonclick ;
      private string divTablesuppliergen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Jsonclick ;
      private string edtavProductservicedescription_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSupplieragbid_Internalname ;
      private string edtavSupplieragbid_Jsonclick ;
      private string edtavSuppliergenid_Internalname ;
      private string edtavSuppliergenid_Jsonclick ;
      private string edtavProductserviceid_Internalname ;
      private string edtavProductserviceid_Jsonclick ;
      private string edtavProductserviceimagevar_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string chkavNofilteragb_Internalname ;
      private string chkavNofiltergen_Internalname ;
      private string lblUseractiondelete_Internalname ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_suppliergenid_Internalname ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string Combo_supplieragbid_Internalname ;
      private string sStyleString ;
      private string tblTablemergedsuppliergenid_Internalname ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string tblTablemergedsupplieragbid_Internalname ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string tblTablemergedusercontrol1_Internalname ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string lblUseractiondelete_Jsonclick ;
      private string sCtrlAV37WebSessionKey ;
      private string sCtrlAV20PreviousStep ;
      private string sCtrlAV14GoingBack ;
      private bool AV14GoingBack ;
      private bool wcpOAV14GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15HasValidationErrors ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool AV49isStart ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV46noFilterAgb ;
      private bool AV47noFilterGen ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Combo_suppliergenid_Includeaddnewoption ;
      private bool GXt_boolean3 ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Disableimageresize ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private string AV21ProductServiceDescription ;
      private string AV25ProductServiceImageVar ;
      private string AV37WebSessionKey ;
      private string AV20PreviousStep ;
      private string wcpOAV37WebSessionKey ;
      private string wcpOAV20PreviousStep ;
      private string AV11FileType ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private string AV26ProductServiceName ;
      private string AV39ProductServiceClass ;
      private string AV22ProductServiceGroup ;
      private string AV10FileName ;
      private string AV7ComboSelectedValue ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid AV16LocationId ;
      private Guid AV28SupplierAgbId ;
      private Guid AV30SupplierGenId ;
      private Guid AV23ProductServiceId ;
      private IGxSession AV48Session ;
      private IGxSession AV36WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXUserControl ucUsercontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationid ;
      private GXCombobox cmbavProductserviceclass ;
      private GXCombobox dynavProductservicegroup ;
      private GXCheckbox chkavNofilteragb ;
      private GXCheckbox chkavNofiltergen ;
      private GxSimpleCollection<Guid> AV43PreferredAgbSuppliers ;
      private GXBaseCollection<SdtFileUploadData> AV34UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV9FailedFiles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29SupplierAgbId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31SupplierGenId_Data ;
      private GxSimpleCollection<Guid> AV44PreferredGenSuppliers ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00722_A29LocationId ;
      private string[] H00722_A31LocationName ;
      private Guid[] H00722_A11OrganisationId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV50GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser2 ;
      private SdtWP_ProductServiceData AV38WizardData ;
      private Guid[] H00723_A42SupplierGenId ;
      private string[] H00723_A44SupplierGenCompanyName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV6Combo_DataItem ;
      private Guid[] H00724_A49SupplierAgbId ;
      private string[] H00724_A51SupplierAgbName ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private Guid[] H00725_A49SupplierAgbId ;
      private string[] H00725_A51SupplierAgbName ;
      private Guid[] H00726_A49SupplierAgbId ;
      private string[] H00726_A51SupplierAgbName ;
      private Guid[] H00727_A42SupplierGenId ;
      private string[] H00727_A44SupplierGenCompanyName ;
      private Guid[] H00728_A42SupplierGenId ;
      private string[] H00728_A44SupplierGenCompanyName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_productservicestep1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00724( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV43PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object4[0] = scmdbuf;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00726( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV43PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00728( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV44PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV44PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H00724(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 4 :
                     return conditional_H00726(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 6 :
                     return conditional_H00728(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00722;
          prmH00722 = new Object[] {
          };
          Object[] prmH00723;
          prmH00723 = new Object[] {
          };
          Object[] prmH00725;
          prmH00725 = new Object[] {
          };
          Object[] prmH00727;
          prmH00727 = new Object[] {
          };
          Object[] prmH00724;
          prmH00724 = new Object[] {
          };
          Object[] prmH00726;
          prmH00726 = new Object[] {
          };
          Object[] prmH00728;
          prmH00728 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00722", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00722,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00723", "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen ORDER BY SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00723,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00724", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00724,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00725", "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB ORDER BY SupplierAgbName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00725,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00726", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00726,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00727", "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen ORDER BY SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00727,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00728", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00728,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
