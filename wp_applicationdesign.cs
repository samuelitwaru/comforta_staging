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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wp_applicationdesign : GXDataArea
   {
      public wp_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId )
      {
         this.AV16Trn_PageId = aP0_Trn_PageId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            return "wp_applicationdesign_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplustoolboxmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplustoolboxmasterpage", new Object[] {context});
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
         PA472( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START472( ) ;
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
         context.AddJavascriptSource("UserControls/UC_AppToolBoxRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_applicationdesign.aspx"+UrlEncode(AV16Trn_PageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_applicationdesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PAGES", AV31SDT_Pages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PAGES", AV31SDT_Pages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PRODUCTSERVICECOLLECTION", AV37SDT_ProductServiceCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PRODUCTSERVICECOLLECTION", AV37SDT_ProductServiceCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_TEMPLATECOLLECTION", AV10BC_Trn_TemplateCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_TEMPLATECOLLECTION", AV10BC_Trn_TemplateCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_MEDIACOLLECTION", AV21BC_Trn_MediaCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_MEDIACOLLECTION", AV21BC_Trn_MediaCollection);
         }
         GxWebStd.gx_hidden_field( context, "vTRN_PAGEID", AV16Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Current_language", StringUtil.RTrim( Apptoolbox1_Current_language));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationid", StringUtil.RTrim( Apptoolbox1_Locationid));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Organisationid", StringUtil.RTrim( Apptoolbox1_Organisationid));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE472( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT472( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_applicationdesign.aspx"+UrlEncode(AV16Trn_PageId.ToString());
         return formatLink("wp_applicationdesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ApplicationDesign" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Application Design", "") ;
      }

      protected void WB470( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucApptoolbox1.SetProperty("Current_Language", Apptoolbox1_Current_language);
            ucApptoolbox1.SetProperty("SDT_Pages", AV31SDT_Pages);
            ucApptoolbox1.SetProperty("SDT_ProductServiceCollection", AV37SDT_ProductServiceCollection);
            ucApptoolbox1.SetProperty("BC_Trn_TemplateCollection", AV10BC_Trn_TemplateCollection);
            ucApptoolbox1.SetProperty("BC_Trn_ThemeCollection", AV13BC_Trn_ThemeCollection);
            ucApptoolbox1.SetProperty("BC_Trn_MediaCollection", AV21BC_Trn_MediaCollection);
            ucApptoolbox1.Render(context, "uc_apptoolbox", Apptoolbox1_Internalname, "APPTOOLBOX1Container");
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

      protected void START472( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Application Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP470( ) ;
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                              E11472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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

      protected void WE472( )
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

      protected void PA472( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_applicationdesign.aspx")), "wp_applicationdesign.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_applicationdesign.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV16Trn_PageId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV16Trn_PageId", AV16Trn_PageId.ToString());
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF472( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12472 ();
            WB470( ) ;
         }
      }

      protected void send_integrity_lvl_hashes472( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11472 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PAGES"), AV31SDT_Pages);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PRODUCTSERVICECOLLECTION"), AV37SDT_ProductServiceCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_TEMPLATECOLLECTION"), AV10BC_Trn_TemplateCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_THEMECOLLECTION"), AV13BC_Trn_ThemeCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_MEDIACOLLECTION"), AV21BC_Trn_MediaCollection);
            /* Read saved values. */
            Apptoolbox1_Current_language = cgiGet( "APPTOOLBOX1_Current_language");
            Apptoolbox1_Locationid = cgiGet( "APPTOOLBOX1_Locationid");
            Apptoolbox1_Organisationid = cgiGet( "APPTOOLBOX1_Organisationid");
            /* Read variables values. */
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
         E11472 ();
         if (returnInSub) return;
      }

      protected void E11472( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Headerrawhtml = Form.Headerrawhtml+"<link rel=\"stylesheet\" href=\"Resources/UCGrapes1/new-design/grapes/grapes.css\">"+"<link rel=\"stylesheet\" href=\"/Resources/UCGrapes1/new-design/css/styles.css\" />"+"<script src=\"Resources/UCGrapes1/new-design/grapes/grapes.js\"></script>";
         GXt_char1 = AV40UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV40UserName = GXt_char1;
         GXt_guid2 = AV41LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
         AV41LocationId = GXt_guid2;
         GXt_guid2 = AV42OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         AV42OrganisationId = GXt_guid2;
         Apptoolbox1_Locationid = AV41LocationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationId", Apptoolbox1_Locationid);
         Apptoolbox1_Organisationid = AV42OrganisationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "OrganisationId", Apptoolbox1_Organisationid);
         /* Using cursor H00472 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A278Trn_TemplateId = H00472_A278Trn_TemplateId[0];
            AV11BC_Trn_Template = new SdtTrn_Template(context);
            AV11BC_Trn_Template.Load(A278Trn_TemplateId);
            AV10BC_Trn_TemplateCollection.Add(AV11BC_Trn_Template, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV46Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         AV47Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor H00473 */
         pr_default.execute(1, new Object[] {AV46Udparg1, AV47Udparg2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = H00473_A11OrganisationId[0];
            A29LocationId = H00473_A29LocationId[0];
            A40000ProductServiceImage_GXI = H00473_A40000ProductServiceImage_GXI[0];
            A58ProductServiceId = H00473_A58ProductServiceId[0];
            A59ProductServiceName = H00473_A59ProductServiceName[0];
            A61ProductServiceImage = H00473_A61ProductServiceImage[0];
            AV36SDT_ProductService = new SdtSDT_ProductService(context);
            AV36SDT_ProductService.gxTpr_Productserviceid = A58ProductServiceId;
            AV36SDT_ProductService.gxTpr_Productservicename = A59ProductServiceName;
            AV36SDT_ProductService.gxTpr_Productserviceimage = A61ProductServiceImage;
            AV36SDT_ProductService.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
            AV37SDT_ProductServiceCollection.Add(AV36SDT_ProductService, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor H00474 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A409MediaId = H00474_A409MediaId[0];
            AV20BC_Trn_Media = new SdtTrn_Media(context);
            AV20BC_Trn_Media.Load(A409MediaId);
            AV21BC_Trn_MediaCollection.Add(AV20BC_Trn_Media, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H00475 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A248Trn_ThemeName = H00475_A248Trn_ThemeName[0];
            A247Trn_ThemeId = H00475_A247Trn_ThemeId[0];
            AV12BC_Trn_Theme = new SdtTrn_Theme(context);
            AV12BC_Trn_Theme.Load(A247Trn_ThemeId);
            AV13BC_Trn_ThemeCollection.Add(AV12BC_Trn_Theme, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor H00476 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A310Trn_PageId = H00476_A310Trn_PageId[0];
            A318Trn_PageName = H00476_A318Trn_PageName[0];
            A437PageChildren = H00476_A437PageChildren[0];
            n437PageChildren = H00476_n437PageChildren[0];
            AV32SDT_PageStructure = new SdtSDT_PageStructure(context);
            AV32SDT_PageStructure.gxTpr_Id = A310Trn_PageId;
            AV32SDT_PageStructure.gxTpr_Name = A318Trn_PageName;
            AV32SDT_PageStructure.gxTpr_Children.FromJSonString(A437PageChildren, null);
            AV31SDT_Pages.Add(AV32SDT_PageStructure, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV38Current_Language = context.GetLanguage( );
         Apptoolbox1_Current_language = AV38Current_Language;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Language", Apptoolbox1_Current_language);
      }

      protected void nextLoad( )
      {
      }

      protected void E12472( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16Trn_PageId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV16Trn_PageId", AV16Trn_PageId.ToString());
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411301452314", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_applicationdesign.js", "?202411301452315", false, true);
            context.AddJavascriptSource("UserControls/UC_AppToolBoxRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         Apptoolbox1_Internalname = "APPTOOLBOX1";
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
         Apptoolbox1_Organisationid = "";
         Apptoolbox1_Locationid = "";
         Apptoolbox1_Current_language = "english";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Application Design", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
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
         wcpOAV16Trn_PageId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV31SDT_Pages = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV37SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>( context, "SDT_ProductService", "Comforta_version2");
         AV10BC_Trn_TemplateCollection = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version2");
         AV13BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV21BC_Trn_MediaCollection = new GXBCCollection<SdtTrn_Media>( context, "Trn_Media", "Comforta_version2");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucApptoolbox1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV40UserName = "";
         GXt_char1 = "";
         AV41LocationId = Guid.Empty;
         AV42OrganisationId = Guid.Empty;
         GXt_guid2 = Guid.Empty;
         H00472_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         A278Trn_TemplateId = Guid.Empty;
         AV11BC_Trn_Template = new SdtTrn_Template(context);
         AV46Udparg1 = Guid.Empty;
         AV47Udparg2 = Guid.Empty;
         H00473_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00473_A29LocationId = new Guid[] {Guid.Empty} ;
         H00473_A40000ProductServiceImage_GXI = new string[] {""} ;
         H00473_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00473_A59ProductServiceName = new string[] {""} ;
         H00473_A61ProductServiceImage = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A58ProductServiceId = Guid.Empty;
         A59ProductServiceName = "";
         A61ProductServiceImage = "";
         AV36SDT_ProductService = new SdtSDT_ProductService(context);
         H00474_A409MediaId = new Guid[] {Guid.Empty} ;
         A409MediaId = Guid.Empty;
         AV20BC_Trn_Media = new SdtTrn_Media(context);
         H00475_A248Trn_ThemeName = new string[] {""} ;
         H00475_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A248Trn_ThemeName = "";
         A247Trn_ThemeId = Guid.Empty;
         AV12BC_Trn_Theme = new SdtTrn_Theme(context);
         H00476_A29LocationId = new Guid[] {Guid.Empty} ;
         H00476_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         H00476_A318Trn_PageName = new string[] {""} ;
         H00476_A437PageChildren = new string[] {""} ;
         H00476_n437PageChildren = new bool[] {false} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A437PageChildren = "";
         AV32SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV38Current_Language = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesign__default(),
            new Object[][] {
                new Object[] {
               H00472_A278Trn_TemplateId
               }
               , new Object[] {
               H00473_A11OrganisationId, H00473_A29LocationId, H00473_A40000ProductServiceImage_GXI, H00473_A58ProductServiceId, H00473_A59ProductServiceName, H00473_A61ProductServiceImage
               }
               , new Object[] {
               H00474_A409MediaId
               }
               , new Object[] {
               H00475_A248Trn_ThemeName, H00475_A247Trn_ThemeId
               }
               , new Object[] {
               H00476_A29LocationId, H00476_A310Trn_PageId, H00476_A318Trn_PageName, H00476_A437PageChildren, H00476_n437PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Apptoolbox1_Current_language ;
      private string Apptoolbox1_Locationid ;
      private string Apptoolbox1_Organisationid ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Apptoolbox1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private string AV38Current_Language ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n437PageChildren ;
      private string A437PageChildren ;
      private string AV40UserName ;
      private string A40000ProductServiceImage_GXI ;
      private string A59ProductServiceName ;
      private string A248Trn_ThemeName ;
      private string A318Trn_PageName ;
      private string A61ProductServiceImage ;
      private Guid AV16Trn_PageId ;
      private Guid wcpOAV16Trn_PageId ;
      private Guid AV41LocationId ;
      private Guid AV42OrganisationId ;
      private Guid GXt_guid2 ;
      private Guid A278Trn_TemplateId ;
      private Guid AV46Udparg1 ;
      private Guid AV47Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A409MediaId ;
      private Guid A247Trn_ThemeId ;
      private Guid A310Trn_PageId ;
      private GXUserControl ucApptoolbox1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV31SDT_Pages ;
      private GXBaseCollection<SdtSDT_ProductService> AV37SDT_ProductServiceCollection ;
      private GXBCCollection<SdtTrn_Template> AV10BC_Trn_TemplateCollection ;
      private GXBCCollection<SdtTrn_Theme> AV13BC_Trn_ThemeCollection ;
      private GXBCCollection<SdtTrn_Media> AV21BC_Trn_MediaCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00472_A278Trn_TemplateId ;
      private SdtTrn_Template AV11BC_Trn_Template ;
      private Guid[] H00473_A11OrganisationId ;
      private Guid[] H00473_A29LocationId ;
      private string[] H00473_A40000ProductServiceImage_GXI ;
      private Guid[] H00473_A58ProductServiceId ;
      private string[] H00473_A59ProductServiceName ;
      private string[] H00473_A61ProductServiceImage ;
      private SdtSDT_ProductService AV36SDT_ProductService ;
      private Guid[] H00474_A409MediaId ;
      private SdtTrn_Media AV20BC_Trn_Media ;
      private string[] H00475_A248Trn_ThemeName ;
      private Guid[] H00475_A247Trn_ThemeId ;
      private SdtTrn_Theme AV12BC_Trn_Theme ;
      private Guid[] H00476_A29LocationId ;
      private Guid[] H00476_A310Trn_PageId ;
      private string[] H00476_A318Trn_PageName ;
      private string[] H00476_A437PageChildren ;
      private bool[] H00476_n437PageChildren ;
      private SdtSDT_PageStructure AV32SDT_PageStructure ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_applicationdesign__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00472;
          prmH00472 = new Object[] {
          };
          Object[] prmH00473;
          prmH00473 = new Object[] {
          new ParDef("AV46Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV47Udparg2",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00474;
          prmH00474 = new Object[] {
          };
          Object[] prmH00475;
          prmH00475 = new Object[] {
          };
          Object[] prmH00476;
          prmH00476 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00472", "SELECT Trn_TemplateId FROM Trn_Template ORDER BY Trn_TemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00472,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00473", "SELECT OrganisationId, LocationId, ProductServiceImage_GXI, ProductServiceId, ProductServiceName, ProductServiceImage FROM Trn_ProductService WHERE LocationId = :AV46Udparg1 and OrganisationId = :AV47Udparg2 ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00473,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00474", "SELECT MediaId FROM Trn_Media ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00474,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00475", "SELECT Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(Trn_ThemeName))))=0) ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00475,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00476", "SELECT LocationId, Trn_PageId, Trn_PageName, PageChildren FROM Trn_Page ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00476,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
