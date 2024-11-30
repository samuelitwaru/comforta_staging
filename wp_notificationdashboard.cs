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
   public class wp_notificationdashboard : GXDataArea
   {
      public wp_notificationdashboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_notificationdashboard( IGxContext context )
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwp_sdtnotificationsdatas") == 0 )
            {
               gxnrGridwwp_sdtnotificationsdatas_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridwwp_sdtnotificationsdatas") == 0 )
            {
               gxgrGridwwp_sdtnotificationsdatas_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridwwp_sdtnotificationsdatas_newrow_invoke( )
      {
         nRC_GXsfl_147 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_147"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_147_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_147_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_147_idx = GetPar( "sGXsfl_147_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwwp_sdtnotificationsdatas_newrow( ) ;
         /* End function gxnrGridwwp_sdtnotificationsdatas_newrow_invoke */
      }

      protected void gxgrGridwwp_sdtnotificationsdatas_refresh_invoke( )
      {
         subGridwwp_sdtnotificationsdatas_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwwp_sdtnotificationsdatas_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25WWP_SDTNotificationsData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridwwp_sdtnotificationsdatas_refresh_invoke */
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
            return GAMSecurityLevel.SecurityLow ;
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
         PA8B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8B2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_notificationdashboard.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWP_SDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV25WWP_SDTNotificationsData, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Wwp_sdtnotificationsdata", AV25WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Wwp_sdtnotificationsdata", AV25WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Wwp_sdtnotificationsdata", GetSecureSignedToken( "", AV25WWP_SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_147", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_147), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWP_SDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV25WWP_SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname));
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
            WE8B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8B2( ) ;
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
         return formatLink("wp_notificationdashboard.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_NotificationDashboard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Notification Dashboard", "") ;
      }

      protected void WB8B0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, "DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "PanelCardContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi1_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_16_8B2( true) ;
         }
         else
         {
            wb_table1_16_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_16_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi1_value_Internalname, context.GetMessage( "KPI1_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9KPI1_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9KPI1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV9KPI1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi1_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table2_28_8B2( true) ;
         }
         else
         {
            wb_table2_28_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi2_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table3_41_8B2( true) ;
         }
         else
         {
            wb_table3_41_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table3_41_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_value_Internalname, context.GetMessage( "KPI2_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12KPI2_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12KPI2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV12KPI2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table4_53_8B2( true) ;
         }
         else
         {
            wb_table4_53_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table4_53_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi3_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table5_66_8B2( true) ;
         }
         else
         {
            wb_table5_66_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table5_66_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_value_Internalname, context.GetMessage( "KPI3_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15KPI3_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15KPI3_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV15KPI3_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi3_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table6_78_8B2( true) ;
         }
         else
         {
            wb_table6_78_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table6_78_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi4_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table7_91_8B2( true) ;
         }
         else
         {
            wb_table7_91_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table7_91_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_value_Internalname, context.GetMessage( "KPI4_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18KPI4_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18KPI4_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV18KPI4_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi4_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table8_103_8B2( true) ;
         }
         else
         {
            wb_table8_103_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table8_103_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi5_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table9_116_8B2( true) ;
         }
         else
         {
            wb_table9_116_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table9_116_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_value_Internalname, context.GetMessage( "KPI5_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21KPI5_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21KPI5_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV21KPI5_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi5_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table10_128_8B2( true) ;
         }
         else
         {
            wb_table10_128_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table10_128_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, lblNotificationssubtitle_Caption, "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridwwp_sdtnotificationsdatasContainer.SetWrapped(nGXWrapped);
            StartGridControl147( ) ;
         }
         if ( wbEnd == 147 )
         {
            wbEnd = 0;
            nRC_GXsfl_147 = (int)(nGXsfl_147_idx-1);
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF", GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF);
               Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
               AV26GXV1 = nGXsfl_147_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridwwp_sdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_sdtnotificationsdatas", Gridwwp_sdtnotificationsdatasContainer, subGridwwp_sdtnotificationsdatas_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridwwp_sdtnotificationsdatasContainerData", Gridwwp_sdtnotificationsdatasContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridwwp_sdtnotificationsdatasContainerData"+"V", Gridwwp_sdtnotificationsdatasContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_sdtnotificationsdatasContainerData"+"V"+"\" value='"+Gridwwp_sdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* User Defined Control */
            ucGridwwp_sdtnotificationsdatas_empowerer.Render(context, "wwp.gridempowerer", Gridwwp_sdtnotificationsdatas_empowerer_Internalname, "GRIDWWP_SDTNOTIFICATIONSDATAS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 147 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF", GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF);
                  Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
                  AV26GXV1 = nGXsfl_147_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridwwp_sdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_sdtnotificationsdatas", Gridwwp_sdtnotificationsdatasContainer, subGridwwp_sdtnotificationsdatas_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridwwp_sdtnotificationsdatasContainerData", Gridwwp_sdtnotificationsdatasContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridwwp_sdtnotificationsdatasContainerData"+"V", Gridwwp_sdtnotificationsdatasContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_sdtnotificationsdatasContainerData"+"V"+"\" value='"+Gridwwp_sdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START8B2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Notification Dashboard", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8B0( ) ;
      }

      protected void WS8B2( )
      {
         START8B2( ) ;
         EVT8B2( ) ;
      }

      protected void EVT8B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDWWP_SDTNOTIFICATIONSDATASPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDWWP_SDTNOTIFICATIONSDATASPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridwwp_sdtnotificationsdatas_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridwwp_sdtnotificationsdatas_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridwwp_sdtnotificationsdatas_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridwwp_sdtnotificationsdatas_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 34), "GRIDWWP_SDTNOTIFICATIONSDATAS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_147_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
                              SubsflControlProps_1472( ) ;
                              AV26GXV1 = (int)(nGXsfl_147_idx+GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
                              if ( ( AV25WWP_SDTNotificationsData.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
                              {
                                 AV25WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1));
                                 AV24NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                                 AssignAttri("", false, edtavNotificationicon_Internalname, AV24NotificationIcon);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWWP_SDTNOTIFICATIONSDATAS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridwwp_sdtnotificationsdatas.Load */
                                    E128B2 ();
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

      protected void WE8B2( )
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

      protected void PA8B2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavKpi1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridwwp_sdtnotificationsdatas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1472( ) ;
         while ( nGXsfl_147_idx <= nRC_GXsfl_147 )
         {
            sendrow_1472( ) ;
            nGXsfl_147_idx = ((subGridwwp_sdtnotificationsdatas_Islastpage==1)&&(nGXsfl_147_idx+1>subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_idx+1);
            sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
            SubsflControlProps_1472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridwwp_sdtnotificationsdatasContainer)) ;
         /* End function gxnrGridwwp_sdtnotificationsdatas_newrow */
      }

      protected void gxgrGridwwp_sdtnotificationsdatas_refresh( int subGridwwp_sdtnotificationsdatas_Rows ,
                                                                GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV25WWP_SDTNotificationsData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord = 0;
         RF8B2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridwwp_sdtnotificationsdatas_refresh */
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
         RF8B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavKpi1_value_Enabled = 0;
         AssignProp("", false, edtavKpi1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_value_Enabled), 5, 0), true);
         edtavKpi1_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi1_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Enabled), 5, 0), true);
         edtavKpi2_value_Enabled = 0;
         AssignProp("", false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp("", false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp("", false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp("", false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
      }

      protected void RF8B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridwwp_sdtnotificationsdatasContainer.ClearRows();
         }
         wbStart = 147;
         nGXsfl_147_idx = 1;
         sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
         SubsflControlProps_1472( ) ;
         bGXsfl_147_Refreshing = true;
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridwwp_sdtnotificationsdatas");
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("CmpContext", "");
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Class", "WorkWith");
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
         Gridwwp_sdtnotificationsdatasContainer.PageSize = subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1472( ) ;
            /* Execute user event: Gridwwp_sdtnotificationsdatas.Load */
            E128B2 ();
            if ( ( subGridwwp_sdtnotificationsdatas_Islastpage == 0 ) && ( GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord > 0 ) && ( GRIDWWP_SDTNOTIFICATIONSDATAS_nGridOutOfScope == 0 ) && ( nGXsfl_147_idx == 1 ) )
            {
               GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord = 0;
               GRIDWWP_SDTNOTIFICATIONSDATAS_nGridOutOfScope = 1;
               subgridwwp_sdtnotificationsdatas_firstpage( ) ;
               /* Execute user event: Gridwwp_sdtnotificationsdatas.Load */
               E128B2 ();
            }
            wbEnd = 147;
            WB8B0( ) ;
         }
         bGXsfl_147_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8B2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWP_SDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV25WWP_SDTNotificationsData, context));
      }

      protected int subGridwwp_sdtnotificationsdatas_fnc_Pagecount( )
      {
         GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount = subGridwwp_sdtnotificationsdatas_fnc_Recordcount( );
         if ( ((int)((GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount) % (subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount/ (decimal)(subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount/ (decimal)(subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridwwp_sdtnotificationsdatas_fnc_Recordcount( )
      {
         return AV25WWP_SDTNotificationsData.Count ;
      }

      protected int subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )
      {
         if ( subGridwwp_sdtnotificationsdatas_Rows > 0 )
         {
            return subGridwwp_sdtnotificationsdatas_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridwwp_sdtnotificationsdatas_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage/ (decimal)(subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridwwp_sdtnotificationsdatas_firstpage( )
      {
         GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwwp_sdtnotificationsdatas_nextpage( )
      {
         GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount = subGridwwp_sdtnotificationsdatas_fnc_Recordcount( );
         if ( ( GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount >= subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ) ) && ( GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF == 0 ) )
         {
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage+subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridwwp_sdtnotificationsdatas_previouspage( )
      {
         if ( GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage >= subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ) )
         {
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage-subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwwp_sdtnotificationsdatas_lastpage( )
      {
         GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount = subGridwwp_sdtnotificationsdatas_fnc_Recordcount( );
         if ( GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount > subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount) % (subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount-subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount-((int)((GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount) % (subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridwwp_sdtnotificationsdatas_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwwp_sdtnotificationsdatas_refresh( subGridwwp_sdtnotificationsdatas_Rows, AV25WWP_SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavKpi1_value_Enabled = 0;
         AssignProp("", false, edtavKpi1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_value_Enabled), 5, 0), true);
         edtavKpi1_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi1_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Enabled), 5, 0), true);
         edtavKpi2_value_Enabled = 0;
         AssignProp("", false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp("", false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp("", false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp("", false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Wwp_sdtnotificationsdata"), AV25WWP_SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vWWP_SDTNOTIFICATIONSDATA"), AV25WWP_SDTNotificationsData);
            /* Read saved values. */
            nRC_GXsfl_147 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_147"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridwwp_sdtnotificationsdatas_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWWP_SDTNOTIFICATIONSDATAS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Rows), 6, 0, ".", "")));
            Dvpanel_tablecards_Width = cgiGet( "DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( "DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( "DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( "DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname = cgiGet( "GRIDWWP_SDTNOTIFICATIONSDATAS_EMPOWERER_Gridinternalname");
            nRC_GXsfl_147 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_147"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_147_fel_idx = 0;
            while ( nGXsfl_147_fel_idx < nRC_GXsfl_147 )
            {
               nGXsfl_147_fel_idx = ((subGridwwp_sdtnotificationsdatas_Islastpage==1)&&(nGXsfl_147_fel_idx+1>subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_fel_idx+1);
               sGXsfl_147_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1472( ) ;
               AV26GXV1 = (int)(nGXsfl_147_fel_idx+GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
               if ( ( AV25WWP_SDTNotificationsData.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
               {
                  AV25WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1));
                  AV24NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
               }
            }
            if ( nGXsfl_147_fel_idx == 0 )
            {
               nGXsfl_147_idx = 1;
               sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
               SubsflControlProps_1472( ) ;
            }
            nGXsfl_147_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI1_VALUE");
               GX_FocusControl = edtavKpi1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9KPI1_Value = 0;
               AssignAttri("", false, "AV9KPI1_Value", StringUtil.LTrimStr( (decimal)(AV9KPI1_Value), 8, 0));
            }
            else
            {
               AV9KPI1_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9KPI1_Value", StringUtil.LTrimStr( (decimal)(AV9KPI1_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi1_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi1_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI1_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi1_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8KPI1_PercentageValue = 0;
               AssignAttri("", false, "AV8KPI1_PercentageValue", StringUtil.LTrimStr( AV8KPI1_PercentageValue, 5, 2));
            }
            else
            {
               AV8KPI1_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi1_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV8KPI1_PercentageValue", StringUtil.LTrimStr( AV8KPI1_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI2_VALUE");
               GX_FocusControl = edtavKpi2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12KPI2_Value = 0;
               AssignAttri("", false, "AV12KPI2_Value", StringUtil.LTrimStr( (decimal)(AV12KPI2_Value), 8, 0));
            }
            else
            {
               AV12KPI2_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12KPI2_Value", StringUtil.LTrimStr( (decimal)(AV12KPI2_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI2_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi2_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11KPI2_PercentageValue = 0;
               AssignAttri("", false, "AV11KPI2_PercentageValue", StringUtil.LTrimStr( AV11KPI2_PercentageValue, 5, 2));
            }
            else
            {
               AV11KPI2_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV11KPI2_PercentageValue", StringUtil.LTrimStr( AV11KPI2_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI3_VALUE");
               GX_FocusControl = edtavKpi3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15KPI3_Value = 0;
               AssignAttri("", false, "AV15KPI3_Value", StringUtil.LTrimStr( (decimal)(AV15KPI3_Value), 8, 0));
            }
            else
            {
               AV15KPI3_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15KPI3_Value", StringUtil.LTrimStr( (decimal)(AV15KPI3_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI3_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi3_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14KPI3_PercentageValue = 0;
               AssignAttri("", false, "AV14KPI3_PercentageValue", StringUtil.LTrimStr( AV14KPI3_PercentageValue, 5, 2));
            }
            else
            {
               AV14KPI3_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV14KPI3_PercentageValue", StringUtil.LTrimStr( AV14KPI3_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI4_VALUE");
               GX_FocusControl = edtavKpi4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18KPI4_Value = 0;
               AssignAttri("", false, "AV18KPI4_Value", StringUtil.LTrimStr( (decimal)(AV18KPI4_Value), 8, 0));
            }
            else
            {
               AV18KPI4_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18KPI4_Value", StringUtil.LTrimStr( (decimal)(AV18KPI4_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI4_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi4_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17KPI4_PercentageValue = 0;
               AssignAttri("", false, "AV17KPI4_PercentageValue", StringUtil.LTrimStr( AV17KPI4_PercentageValue, 5, 2));
            }
            else
            {
               AV17KPI4_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV17KPI4_PercentageValue", StringUtil.LTrimStr( AV17KPI4_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI5_VALUE");
               GX_FocusControl = edtavKpi5_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21KPI5_Value = 0;
               AssignAttri("", false, "AV21KPI5_Value", StringUtil.LTrimStr( (decimal)(AV21KPI5_Value), 8, 0));
            }
            else
            {
               AV21KPI5_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21KPI5_Value", StringUtil.LTrimStr( (decimal)(AV21KPI5_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI5_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi5_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20KPI5_PercentageValue = 0;
               AssignAttri("", false, "AV20KPI5_PercentageValue", StringUtil.LTrimStr( AV20KPI5_PercentageValue, 5, 2));
            }
            else
            {
               AV20KPI5_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV20KPI5_PercentageValue", StringUtil.LTrimStr( AV20KPI5_PercentageValue, 5, 2));
            }
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
         E118B2 ();
         if (returnInSub) return;
      }

      protected void E118B2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname = subGridwwp_sdtnotificationsdatas_Internalname;
         ucGridwwp_sdtnotificationsdatas_empowerer.SendProperty(context, "", false, Gridwwp_sdtnotificationsdatas_empowerer_Internalname, "GridInternalName", Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname);
         subGridwwp_sdtnotificationsdatas_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Rows), 6, 0, ".", "")));
         if ( AV7KPI1_IsSuccessfulValue )
         {
            lblKpi1_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi1_moreinfoicon_Internalname, "Caption", lblKpi1_moreinfoicon_Caption, true);
            edtavKpi1_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi1_percentagevalue_Internalname, "Class", edtavKpi1_percentagevalue_Class, true);
         }
         else
         {
            lblKpi1_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi1_moreinfoicon_Internalname, "Caption", lblKpi1_moreinfoicon_Caption, true);
            edtavKpi1_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi1_percentagevalue_Internalname, "Class", edtavKpi1_percentagevalue_Class, true);
         }
         if ( AV10KPI2_IsSuccessfulValue )
         {
            lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
            edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
         }
         else
         {
            lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
            edtavKpi2_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
         }
         if ( AV13KPI3_IsSuccessfulValue )
         {
            lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
            edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
         }
         else
         {
            lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
            edtavKpi3_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
         }
         if ( AV16KPI4_IsSuccessfulValue )
         {
            lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
            edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
         }
         else
         {
            lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
            edtavKpi4_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
         }
         if ( AV19KPI5_IsSuccessfulValue )
         {
            lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
            edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
         }
         else
         {
            lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
            edtavKpi5_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
         }
         /* Execute user subroutine: 'LOAD GRID SDT' */
         S112 ();
         if (returnInSub) return;
      }

      private void E128B2( )
      {
         /* Gridwwp_sdtnotificationsdatas_Load Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV25WWP_SDTNotificationsData.Count )
         {
            AV25WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1));
            edtavNotificationicon_Format = 2;
            AV24NotificationIcon = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV25WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon_Internalname, AV24NotificationIcon);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 147;
            }
            if ( ( subGridwwp_sdtnotificationsdatas_Islastpage == 1 ) || ( subGridwwp_sdtnotificationsdatas_Rows == 0 ) || ( ( GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord >= GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage ) && ( GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord < GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage + subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1472( ) ;
            }
            GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF = (short)(((GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord<GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage+subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF), 1, 0, ".", "")));
            GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord = (long)(GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_147_Refreshing )
            {
               DoAjaxLoad(147, Gridwwp_sdtnotificationsdatasRow);
            }
            AV26GXV1 = (int)(AV26GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOAD GRID SDT' Routine */
         returnInSub = false;
         AV25WWP_SDTNotificationsData.Clear();
         gx_BV147 = true;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser(context ).execute( out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV147 = true;
         if ( AV25WWP_SDTNotificationsData.Count == 0 )
         {
            lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_NoNewNotifications", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else if ( AV25WWP_SDTNotificationsData.Count == 1 )
         {
            lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_OneNewNotification", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else
         {
            lblNotificationssubtitle_Caption = StringUtil.Format( context.GetMessage( "WWP_Notifications_NewNotifications", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV25WWP_SDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
      }

      protected void wb_table10_128_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_moreinfoicon_Internalname, tblTablemergedkpi5_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfoicon_Internalname, lblKpi5_moreinfoicon_Caption, "", "", lblKpi5_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_percentagevalue_Internalname, context.GetMessage( "KPI5_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV20KPI5_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV20KPI5_PercentageValue, "Z9%") : context.localUtil.Format( AV20KPI5_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_percentagevalue_Jsonclick, 0, edtavKpi5_percentagevalue_Class, "", "", "", "", 1, edtavKpi5_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi5_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_128_8B2e( true) ;
         }
         else
         {
            wb_table10_128_8B2e( false) ;
         }
      }

      protected void wb_table9_116_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_icon_Internalname, tblTablemergedkpi5_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-tag'></i>", ""), "", "", lblKpi5_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_description_Internalname, context.GetMessage( "Mentions", ""), "", "", lblKpi5_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_116_8B2e( true) ;
         }
         else
         {
            wb_table9_116_8B2e( false) ;
         }
      }

      protected void wb_table8_103_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_moreinfoicon_Internalname, tblTablemergedkpi4_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfoicon_Internalname, lblKpi4_moreinfoicon_Caption, "", "", lblKpi4_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_percentagevalue_Internalname, context.GetMessage( "KPI4_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17KPI4_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV17KPI4_PercentageValue, "Z9%") : context.localUtil.Format( AV17KPI4_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_percentagevalue_Jsonclick, 0, edtavKpi4_percentagevalue_Class, "", "", "", "", 1, edtavKpi4_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi4_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_103_8B2e( true) ;
         }
         else
         {
            wb_table8_103_8B2e( false) ;
         }
      }

      protected void wb_table7_91_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_icon_Internalname, tblTablemergedkpi4_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-heart'></i>", ""), "", "", lblKpi4_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_description_Internalname, context.GetMessage( "Views", ""), "", "", lblKpi4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_91_8B2e( true) ;
         }
         else
         {
            wb_table7_91_8B2e( false) ;
         }
      }

      protected void wb_table6_78_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_moreinfoicon_Internalname, tblTablemergedkpi3_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfoicon_Internalname, lblKpi3_moreinfoicon_Caption, "", "", lblKpi3_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_percentagevalue_Internalname, context.GetMessage( "KPI3_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14KPI3_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV14KPI3_PercentageValue, "Z9%") : context.localUtil.Format( AV14KPI3_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_percentagevalue_Jsonclick, 0, edtavKpi3_percentagevalue_Class, "", "", "", "", 1, edtavKpi3_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi3_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_78_8B2e( true) ;
         }
         else
         {
            wb_table6_78_8B2e( false) ;
         }
      }

      protected void wb_table5_66_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_icon_Internalname, tblTablemergedkpi3_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fa fa-user'></i>", ""), "", "", lblKpi3_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_description_Internalname, context.GetMessage( "Users", ""), "", "", lblKpi3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_66_8B2e( true) ;
         }
         else
         {
            wb_table5_66_8B2e( false) ;
         }
      }

      protected void wb_table4_53_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_moreinfoicon_Internalname, tblTablemergedkpi2_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfoicon_Internalname, lblKpi2_moreinfoicon_Caption, "", "", lblKpi2_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_percentagevalue_Internalname, context.GetMessage( "KPI2_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11KPI2_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV11KPI2_PercentageValue, "Z9%") : context.localUtil.Format( AV11KPI2_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_percentagevalue_Jsonclick, 0, edtavKpi2_percentagevalue_Class, "", "", "", "", 1, edtavKpi2_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi2_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_53_8B2e( true) ;
         }
         else
         {
            wb_table4_53_8B2e( false) ;
         }
      }

      protected void wb_table3_41_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_icon_Internalname, tblTablemergedkpi2_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-university'></i>", ""), "", "", lblKpi2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_description_Internalname, context.GetMessage( "Revenue", ""), "", "", lblKpi2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_41_8B2e( true) ;
         }
         else
         {
            wb_table3_41_8B2e( false) ;
         }
      }

      protected void wb_table2_28_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi1_moreinfoicon_Internalname, tblTablemergedkpi1_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_moreinfoicon_Internalname, lblKpi1_moreinfoicon_Caption, "", "", lblKpi1_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi1_percentagevalue_Internalname, context.GetMessage( "KPI1_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi1_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8KPI1_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi1_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV8KPI1_PercentageValue, "Z9%") : context.localUtil.Format( AV8KPI1_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi1_percentagevalue_Jsonclick, 0, edtavKpi1_percentagevalue_Class, "", "", "", "", 1, edtavKpi1_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi1_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_8B2e( true) ;
         }
         else
         {
            wb_table2_28_8B2e( false) ;
         }
      }

      protected void wb_table1_16_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi1_icon_Internalname, tblTablemergedkpi1_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-shopping-cart'></i>", ""), "", "", lblKpi1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_description_Internalname, context.GetMessage( "Sales", ""), "", "", lblKpi1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_16_8B2e( true) ;
         }
         else
         {
            wb_table1_16_8B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA8B2( ) ;
         WS8B2( ) ;
         WE8B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112115463531", true, true);
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
            context.AddJavascriptSource("wp_notificationdashboard.js", "?2024112115463532", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1472( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_147_idx;
      }

      protected void SubsflControlProps_fel_1472( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_147_fel_idx;
      }

      protected void sendrow_1472( )
      {
         sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
         SubsflControlProps_1472( ) ;
         WB8B0( ) ;
         if ( ( subGridwwp_sdtnotificationsdatas_Rows * 1 == 0 ) || ( nGXsfl_147_idx <= subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridwwp_sdtnotificationsdatasRow = GXWebRow.GetNew(context,Gridwwp_sdtnotificationsdatasContainer);
            if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridwwp_sdtnotificationsdatas_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridwwp_sdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Odd";
               }
            }
            else if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridwwp_sdtnotificationsdatas_Backstyle = 0;
               subGridwwp_sdtnotificationsdatas_Backcolor = subGridwwp_sdtnotificationsdatas_Allbackcolor;
               if ( StringUtil.StrCmp(subGridwwp_sdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Uniform";
               }
            }
            else if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridwwp_sdtnotificationsdatas_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridwwp_sdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Odd";
               }
               subGridwwp_sdtnotificationsdatas_Backcolor = (int)(0x0);
            }
            else if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridwwp_sdtnotificationsdatas_Backstyle = 1;
               if ( ((int)((nGXsfl_147_idx) % (2))) == 0 )
               {
                  subGridwwp_sdtnotificationsdatas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwwp_sdtnotificationsdatas_Class, "") != 0 )
                  {
                     subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Even";
                  }
               }
               else
               {
                  subGridwwp_sdtnotificationsdatas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwwp_sdtnotificationsdatas_Class, "") != 0 )
                  {
                     subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Odd";
                  }
               }
            }
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_147_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_147_idx + "',147)\"";
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,StringUtil.RTrim( AV24NotificationIcon),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)edtavNotificationicon_Format,(short)147,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationid), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWwp_sdtnotificationsdata__notificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationid), "ZZZZ9") : context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationid), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationiconclass,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_147_idx + "',147)\"";
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationtitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationdescription,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationdescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_147_idx + "',147)\"";
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationdatetime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,153);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridwwp_sdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationlink_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV25WWP_SDTNotificationsData.Item(AV26GXV1)).gxTpr_Notificationlink,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationlink_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)147,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes8B2( ) ;
            Gridwwp_sdtnotificationsdatasContainer.AddRow(Gridwwp_sdtnotificationsdatasRow);
            nGXsfl_147_idx = ((subGridwwp_sdtnotificationsdatas_Islastpage==1)&&(nGXsfl_147_idx+1>subGridwwp_sdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_idx+1);
            sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
            SubsflControlProps_1472( ) ;
         }
         /* End function sendrow_1472 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl147( )
      {
         if ( Gridwwp_sdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridwwp_sdtnotificationsdatasContainer"+"DivS\" data-gxgridid=\"147\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridwwp_sdtnotificationsdatas_Internalname, subGridwwp_sdtnotificationsdatas_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 0 )
            {
               subGridwwp_sdtnotificationsdatas_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridwwp_sdtnotificationsdatas_Class) > 0 )
               {
                  subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Title";
               }
            }
            else
            {
               subGridwwp_sdtnotificationsdatas_Titlebackstyle = 1;
               if ( subGridwwp_sdtnotificationsdatas_Backcolorstyle == 1 )
               {
                  subGridwwp_sdtnotificationsdatas_Titlebackcolor = subGridwwp_sdtnotificationsdatas_Allbackcolor;
                  if ( StringUtil.Len( subGridwwp_sdtnotificationsdatas_Class) > 0 )
                  {
                     subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridwwp_sdtnotificationsdatas_Class) > 0 )
                  {
                     subGridwwp_sdtnotificationsdatas_Linesclass = subGridwwp_sdtnotificationsdatas_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Icon Class", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Datetime", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Link", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridwwp_sdtnotificationsdatas");
         }
         else
         {
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridwwp_sdtnotificationsdatas");
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Header", subGridwwp_sdtnotificationsdatas_Header);
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Class", "WorkWith");
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("CmpContext", "");
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24NotificationIcon)));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Format), 4, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationid_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdescription_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridwwp_sdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationlink_Enabled), 5, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddColumnProperties(Gridwwp_sdtnotificationsdatasColumn);
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Selectedindex), 4, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Allowselection), 1, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Selectioncolor), 9, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Allowhovering), 1, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Hoveringcolor), 9, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Allowcollapsing), 1, 0, ".", "")));
            Gridwwp_sdtnotificationsdatasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_sdtnotificationsdatas_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblKpi1_icon_Internalname = "KPI1_ICON";
         lblKpi1_description_Internalname = "KPI1_DESCRIPTION";
         tblTablemergedkpi1_icon_Internalname = "TABLEMERGEDKPI1_ICON";
         edtavKpi1_value_Internalname = "vKPI1_VALUE";
         lblKpi1_moreinfoicon_Internalname = "KPI1_MOREINFOICON";
         edtavKpi1_percentagevalue_Internalname = "vKPI1_PERCENTAGEVALUE";
         lblKpi1_moreinfocaption_Internalname = "KPI1_MOREINFOCAPTION";
         tblTablemergedkpi1_moreinfoicon_Internalname = "TABLEMERGEDKPI1_MOREINFOICON";
         divKpi1_maintable_Internalname = "KPI1_MAINTABLE";
         lblKpi2_icon_Internalname = "KPI2_ICON";
         lblKpi2_description_Internalname = "KPI2_DESCRIPTION";
         tblTablemergedkpi2_icon_Internalname = "TABLEMERGEDKPI2_ICON";
         edtavKpi2_value_Internalname = "vKPI2_VALUE";
         lblKpi2_moreinfoicon_Internalname = "KPI2_MOREINFOICON";
         edtavKpi2_percentagevalue_Internalname = "vKPI2_PERCENTAGEVALUE";
         lblKpi2_moreinfocaption_Internalname = "KPI2_MOREINFOCAPTION";
         tblTablemergedkpi2_moreinfoicon_Internalname = "TABLEMERGEDKPI2_MOREINFOICON";
         divKpi2_maintable_Internalname = "KPI2_MAINTABLE";
         lblKpi3_icon_Internalname = "KPI3_ICON";
         lblKpi3_description_Internalname = "KPI3_DESCRIPTION";
         tblTablemergedkpi3_icon_Internalname = "TABLEMERGEDKPI3_ICON";
         edtavKpi3_value_Internalname = "vKPI3_VALUE";
         lblKpi3_moreinfoicon_Internalname = "KPI3_MOREINFOICON";
         edtavKpi3_percentagevalue_Internalname = "vKPI3_PERCENTAGEVALUE";
         lblKpi3_moreinfocaption_Internalname = "KPI3_MOREINFOCAPTION";
         tblTablemergedkpi3_moreinfoicon_Internalname = "TABLEMERGEDKPI3_MOREINFOICON";
         divKpi3_maintable_Internalname = "KPI3_MAINTABLE";
         lblKpi4_icon_Internalname = "KPI4_ICON";
         lblKpi4_description_Internalname = "KPI4_DESCRIPTION";
         tblTablemergedkpi4_icon_Internalname = "TABLEMERGEDKPI4_ICON";
         edtavKpi4_value_Internalname = "vKPI4_VALUE";
         lblKpi4_moreinfoicon_Internalname = "KPI4_MOREINFOICON";
         edtavKpi4_percentagevalue_Internalname = "vKPI4_PERCENTAGEVALUE";
         lblKpi4_moreinfocaption_Internalname = "KPI4_MOREINFOCAPTION";
         tblTablemergedkpi4_moreinfoicon_Internalname = "TABLEMERGEDKPI4_MOREINFOICON";
         divKpi4_maintable_Internalname = "KPI4_MAINTABLE";
         lblKpi5_icon_Internalname = "KPI5_ICON";
         lblKpi5_description_Internalname = "KPI5_DESCRIPTION";
         tblTablemergedkpi5_icon_Internalname = "TABLEMERGEDKPI5_ICON";
         edtavKpi5_value_Internalname = "vKPI5_VALUE";
         lblKpi5_moreinfoicon_Internalname = "KPI5_MOREINFOICON";
         edtavKpi5_percentagevalue_Internalname = "vKPI5_PERCENTAGEVALUE";
         lblKpi5_moreinfocaption_Internalname = "KPI5_MOREINFOCAPTION";
         tblTablemergedkpi5_moreinfoicon_Internalname = "TABLEMERGEDKPI5_MOREINFOICON";
         divKpi5_maintable_Internalname = "KPI5_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON";
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID";
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION";
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         divTablemain_Internalname = "TABLEMAIN";
         Gridwwp_sdtnotificationsdatas_empowerer_Internalname = "GRIDWWP_SDTNOTIFICATIONSDATAS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridwwp_sdtnotificationsdatas_Internalname = "GRIDWWP_SDTNOTIFICATIONSDATAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridwwp_sdtnotificationsdatas_Allowcollapsing = 0;
         subGridwwp_sdtnotificationsdatas_Allowselection = 0;
         subGridwwp_sdtnotificationsdatas_Header = "";
         edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavNotificationicon_Jsonclick = "";
         edtavNotificationicon_Enabled = 0;
         edtavNotificationicon_Format = 0;
         subGridwwp_sdtnotificationsdatas_Class = "WorkWith";
         subGridwwp_sdtnotificationsdatas_Backcolorstyle = 0;
         edtavKpi1_percentagevalue_Jsonclick = "";
         edtavKpi1_percentagevalue_Enabled = 1;
         edtavKpi2_percentagevalue_Jsonclick = "";
         edtavKpi2_percentagevalue_Enabled = 1;
         edtavKpi3_percentagevalue_Jsonclick = "";
         edtavKpi3_percentagevalue_Enabled = 1;
         edtavKpi4_percentagevalue_Jsonclick = "";
         edtavKpi4_percentagevalue_Enabled = 1;
         edtavKpi5_percentagevalue_Jsonclick = "";
         edtavKpi5_percentagevalue_Enabled = 1;
         edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi5_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi4_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi3_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi2_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi1_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi1_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = -1;
         lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_NewNotifications", "");
         edtavKpi5_value_Jsonclick = "";
         edtavKpi5_value_Enabled = 1;
         edtavKpi4_value_Jsonclick = "";
         edtavKpi4_value_Enabled = 1;
         edtavKpi3_value_Jsonclick = "";
         edtavKpi3_value_Enabled = 1;
         edtavKpi2_value_Jsonclick = "";
         edtavKpi2_value_Enabled = 1;
         edtavKpi1_value_Jsonclick = "";
         edtavKpi1_value_Enabled = 1;
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = context.GetMessage( "Notifications", "");
         Dvpanel_tablenotifications_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Notification Dashboard", "");
         subGridwwp_sdtnotificationsdatas_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridwwp_sdtnotificationsdatas_Rows","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]}""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS.LOAD","""{"handler":"E128B2","iparms":[{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS.LOAD",""","oparms":[{"av":"edtavNotificationicon_Format","ctrl":"vNOTIFICATIONICON","prop":"Format"},{"av":"AV24NotificationIcon","fld":"vNOTIFICATIONICON"}]}""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS_FIRSTPAGE","""{"handler":"subgridwwp_sdtnotificationsdatas_firstpage","iparms":[{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridwwp_sdtnotificationsdatas_Rows","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]}""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS_PREVPAGE","""{"handler":"subgridwwp_sdtnotificationsdatas_previouspage","iparms":[{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridwwp_sdtnotificationsdatas_Rows","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]}""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS_NEXTPAGE","""{"handler":"subgridwwp_sdtnotificationsdatas_nextpage","iparms":[{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridwwp_sdtnotificationsdatas_Rows","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]}""");
         setEventMetadata("GRIDWWP_SDTNOTIFICATIONSDATAS_LASTPAGE","""{"handler":"subgridwwp_sdtnotificationsdatas_lastpage","iparms":[{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridwwp_sdtnotificationsdatas_Rows","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":147,"hsh":true},{"av":"nGXsfl_147_idx","ctrl":"GRID","prop":"GridCurrRow","grid":147},{"av":"nRC_GXsfl_147","ctrl":"GRIDWWP_SDTNOTIFICATIONSDATAS","prop":"GridRC","grid":147}]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV25WWP_SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablecards = new GXUserControl();
         TempTags = "";
         ucDvpanel_tablenotifications = new GXUserControl();
         lblNotificationssubtitle_Jsonclick = "";
         Gridwwp_sdtnotificationsdatasContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridwwp_sdtnotificationsdatas_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV24NotificationIcon = "";
         Gridwwp_sdtnotificationsdatasRow = new GXWebRow();
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2");
         lblKpi5_moreinfoicon_Jsonclick = "";
         lblKpi5_moreinfocaption_Jsonclick = "";
         lblKpi5_icon_Jsonclick = "";
         lblKpi5_description_Jsonclick = "";
         lblKpi4_moreinfoicon_Jsonclick = "";
         lblKpi4_moreinfocaption_Jsonclick = "";
         lblKpi4_icon_Jsonclick = "";
         lblKpi4_description_Jsonclick = "";
         lblKpi3_moreinfoicon_Jsonclick = "";
         lblKpi3_moreinfocaption_Jsonclick = "";
         lblKpi3_icon_Jsonclick = "";
         lblKpi3_description_Jsonclick = "";
         lblKpi2_moreinfoicon_Jsonclick = "";
         lblKpi2_moreinfocaption_Jsonclick = "";
         lblKpi2_icon_Jsonclick = "";
         lblKpi2_description_Jsonclick = "";
         lblKpi1_moreinfoicon_Jsonclick = "";
         lblKpi1_moreinfocaption_Jsonclick = "";
         lblKpi1_icon_Jsonclick = "";
         lblKpi1_description_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridwwp_sdtnotificationsdatas_Linesclass = "";
         ROClassString = "";
         Gridwwp_sdtnotificationsdatasColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavKpi1_value_Enabled = 0;
         edtavKpi1_percentagevalue_Enabled = 0;
         edtavKpi2_value_Enabled = 0;
         edtavKpi2_percentagevalue_Enabled = 0;
         edtavKpi3_value_Enabled = 0;
         edtavKpi3_percentagevalue_Enabled = 0;
         edtavKpi4_value_Enabled = 0;
         edtavKpi4_percentagevalue_Enabled = 0;
         edtavKpi5_value_Enabled = 0;
         edtavKpi5_percentagevalue_Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
      }

      private short GRIDWWP_SDTNOTIFICATIONSDATAS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGridwwp_sdtnotificationsdatas_Backcolorstyle ;
      private short edtavNotificationicon_Format ;
      private short subGridwwp_sdtnotificationsdatas_Backstyle ;
      private short subGridwwp_sdtnotificationsdatas_Titlebackstyle ;
      private short subGridwwp_sdtnotificationsdatas_Allowselection ;
      private short subGridwwp_sdtnotificationsdatas_Allowhovering ;
      private short subGridwwp_sdtnotificationsdatas_Allowcollapsing ;
      private short subGridwwp_sdtnotificationsdatas_Collapsed ;
      private int nRC_GXsfl_147 ;
      private int subGridwwp_sdtnotificationsdatas_Rows ;
      private int nGXsfl_147_idx=1 ;
      private int AV9KPI1_Value ;
      private int edtavKpi1_value_Enabled ;
      private int AV12KPI2_Value ;
      private int edtavKpi2_value_Enabled ;
      private int AV15KPI3_Value ;
      private int edtavKpi3_value_Enabled ;
      private int AV18KPI4_Value ;
      private int edtavKpi4_value_Enabled ;
      private int AV21KPI5_Value ;
      private int edtavKpi5_value_Enabled ;
      private int AV26GXV1 ;
      private int subGridwwp_sdtnotificationsdatas_Islastpage ;
      private int edtavKpi1_percentagevalue_Enabled ;
      private int edtavKpi2_percentagevalue_Enabled ;
      private int edtavKpi3_percentagevalue_Enabled ;
      private int edtavKpi4_percentagevalue_Enabled ;
      private int edtavKpi5_percentagevalue_Enabled ;
      private int edtavNotificationicon_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationid_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdescription_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationlink_Enabled ;
      private int GRIDWWP_SDTNOTIFICATIONSDATAS_nGridOutOfScope ;
      private int nGXsfl_147_fel_idx=1 ;
      private int idxLst ;
      private int subGridwwp_sdtnotificationsdatas_Backcolor ;
      private int subGridwwp_sdtnotificationsdatas_Allbackcolor ;
      private int subGridwwp_sdtnotificationsdatas_Titlebackcolor ;
      private int subGridwwp_sdtnotificationsdatas_Selectedindex ;
      private int subGridwwp_sdtnotificationsdatas_Selectioncolor ;
      private int subGridwwp_sdtnotificationsdatas_Hoveringcolor ;
      private long GRIDWWP_SDTNOTIFICATIONSDATAS_nFirstRecordOnPage ;
      private long GRIDWWP_SDTNOTIFICATIONSDATAS_nCurrentRecord ;
      private long GRIDWWP_SDTNOTIFICATIONSDATAS_nRecordCount ;
      private decimal AV8KPI1_PercentageValue ;
      private decimal AV11KPI2_PercentageValue ;
      private decimal AV14KPI3_PercentageValue ;
      private decimal AV17KPI4_PercentageValue ;
      private decimal AV20KPI5_PercentageValue ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_147_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Gridwwp_sdtnotificationsdatas_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divKpi1_maintable_Internalname ;
      private string edtavKpi1_value_Internalname ;
      private string TempTags ;
      private string edtavKpi1_value_Jsonclick ;
      private string divKpi2_maintable_Internalname ;
      private string edtavKpi2_value_Internalname ;
      private string edtavKpi2_value_Jsonclick ;
      private string divKpi3_maintable_Internalname ;
      private string edtavKpi3_value_Internalname ;
      private string edtavKpi3_value_Jsonclick ;
      private string divKpi4_maintable_Internalname ;
      private string edtavKpi4_value_Internalname ;
      private string edtavKpi4_value_Jsonclick ;
      private string divKpi5_maintable_Internalname ;
      private string edtavKpi5_value_Internalname ;
      private string edtavKpi5_value_Jsonclick ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Caption ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string sStyleString ;
      private string subGridwwp_sdtnotificationsdatas_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Gridwwp_sdtnotificationsdatas_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV24NotificationIcon ;
      private string edtavNotificationicon_Internalname ;
      private string edtavKpi1_percentagevalue_Internalname ;
      private string edtavKpi2_percentagevalue_Internalname ;
      private string edtavKpi3_percentagevalue_Internalname ;
      private string edtavKpi4_percentagevalue_Internalname ;
      private string edtavKpi5_percentagevalue_Internalname ;
      private string sGXsfl_147_fel_idx="0001" ;
      private string lblKpi1_moreinfoicon_Caption ;
      private string lblKpi1_moreinfoicon_Internalname ;
      private string edtavKpi1_percentagevalue_Class ;
      private string lblKpi2_moreinfoicon_Caption ;
      private string lblKpi2_moreinfoicon_Internalname ;
      private string edtavKpi2_percentagevalue_Class ;
      private string lblKpi3_moreinfoicon_Caption ;
      private string lblKpi3_moreinfoicon_Internalname ;
      private string edtavKpi3_percentagevalue_Class ;
      private string lblKpi4_moreinfoicon_Caption ;
      private string lblKpi4_moreinfoicon_Internalname ;
      private string edtavKpi4_percentagevalue_Class ;
      private string lblKpi5_moreinfoicon_Caption ;
      private string lblKpi5_moreinfoicon_Internalname ;
      private string edtavKpi5_percentagevalue_Class ;
      private string tblTablemergedkpi5_moreinfoicon_Internalname ;
      private string lblKpi5_moreinfoicon_Jsonclick ;
      private string edtavKpi5_percentagevalue_Jsonclick ;
      private string lblKpi5_moreinfocaption_Internalname ;
      private string lblKpi5_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi5_icon_Internalname ;
      private string lblKpi5_icon_Internalname ;
      private string lblKpi5_icon_Jsonclick ;
      private string lblKpi5_description_Internalname ;
      private string lblKpi5_description_Jsonclick ;
      private string tblTablemergedkpi4_moreinfoicon_Internalname ;
      private string lblKpi4_moreinfoicon_Jsonclick ;
      private string edtavKpi4_percentagevalue_Jsonclick ;
      private string lblKpi4_moreinfocaption_Internalname ;
      private string lblKpi4_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi4_icon_Internalname ;
      private string lblKpi4_icon_Internalname ;
      private string lblKpi4_icon_Jsonclick ;
      private string lblKpi4_description_Internalname ;
      private string lblKpi4_description_Jsonclick ;
      private string tblTablemergedkpi3_moreinfoicon_Internalname ;
      private string lblKpi3_moreinfoicon_Jsonclick ;
      private string edtavKpi3_percentagevalue_Jsonclick ;
      private string lblKpi3_moreinfocaption_Internalname ;
      private string lblKpi3_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi3_icon_Internalname ;
      private string lblKpi3_icon_Internalname ;
      private string lblKpi3_icon_Jsonclick ;
      private string lblKpi3_description_Internalname ;
      private string lblKpi3_description_Jsonclick ;
      private string tblTablemergedkpi2_moreinfoicon_Internalname ;
      private string lblKpi2_moreinfoicon_Jsonclick ;
      private string edtavKpi2_percentagevalue_Jsonclick ;
      private string lblKpi2_moreinfocaption_Internalname ;
      private string lblKpi2_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi2_icon_Internalname ;
      private string lblKpi2_icon_Internalname ;
      private string lblKpi2_icon_Jsonclick ;
      private string lblKpi2_description_Internalname ;
      private string lblKpi2_description_Jsonclick ;
      private string tblTablemergedkpi1_moreinfoicon_Internalname ;
      private string lblKpi1_moreinfoicon_Jsonclick ;
      private string edtavKpi1_percentagevalue_Jsonclick ;
      private string lblKpi1_moreinfocaption_Internalname ;
      private string lblKpi1_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi1_icon_Internalname ;
      private string lblKpi1_icon_Internalname ;
      private string lblKpi1_icon_Jsonclick ;
      private string lblKpi1_description_Internalname ;
      private string lblKpi1_description_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Internalname ;
      private string subGridwwp_sdtnotificationsdatas_Class ;
      private string subGridwwp_sdtnotificationsdatas_Linesclass ;
      private string ROClassString ;
      private string edtavNotificationicon_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick ;
      private string subGridwwp_sdtnotificationsdatas_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_147_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV7KPI1_IsSuccessfulValue ;
      private bool AV10KPI2_IsSuccessfulValue ;
      private bool AV13KPI3_IsSuccessfulValue ;
      private bool AV16KPI4_IsSuccessfulValue ;
      private bool AV19KPI5_IsSuccessfulValue ;
      private bool gx_BV147 ;
      private GXWebGrid Gridwwp_sdtnotificationsdatasContainer ;
      private GXWebRow Gridwwp_sdtnotificationsdatasRow ;
      private GXWebColumn Gridwwp_sdtnotificationsdatasColumn ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucGridwwp_sdtnotificationsdatas_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV25WWP_SDTNotificationsData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
