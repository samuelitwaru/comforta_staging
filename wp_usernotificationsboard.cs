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
   public class wp_usernotificationsboard : GXDataArea
   {
      public wp_usernotificationsboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_usernotificationsboard( IGxContext context )
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
         radavNotificationtypes = new GXRadio();
         cmbavActiongroup = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_47 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV58Pgmname = GetPar( "Pgmname");
         AV9FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41NotificationDefinitionIdEmptyCollection);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10WWP_SDTNotificationsData);
         AV35NotificationTypes = GetPar( "NotificationTypes");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV48MentionDefinitions);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47DiscussionDefinitions);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV46FormDefinitions);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV45AgendaDefinitions);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "wp_usernotificationsboard_Execute" ;
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
            MasterPageObj.setDataArea(this,true);
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
         PA9N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9N2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_usernotificationsboard.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV48MentionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV47DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV46FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV46FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV46FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV45AgendaDefinitions, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Wwp_sdtnotificationsdata", AV10WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Wwp_sdtnotificationsdata", AV10WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_47), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV17GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV41NotificationDefinitionIdEmptyCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV41NotificationDefinitionIdEmptyCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV10WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV10WWP_SDTNotificationsData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV48MentionDefinitions, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTNOTFICATIONGROUPFILTER", AV49CurrentNotficationGroupFilter);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV47DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV46FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV46FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV46FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV45AgendaDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV42NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV42NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONMESSAGE_Caption", StringUtil.RTrim( lblNotificationmessage_Caption));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE9N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9N2( ) ;
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
         return formatLink("wp_usernotificationsboard.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_UserNotificationsBoard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notifications", "") ;
      }

      protected void WB9N0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Notification Types", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavNotificationtypes, radavNotificationtypes_Internalname, StringUtil.RTrim( AV35NotificationTypes), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavNotificationtypes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbymentions_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbymentions_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbymentions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Mentions", ""), bttBtnfilterbymentions_Jsonclick, 5, context.GetMessage( "Mentions", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYMENTIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbydiscussions_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbydiscussions_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbydiscussions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Discussions", ""), bttBtnfilterbydiscussions_Jsonclick, 5, context.GetMessage( "Discussions", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYDISCUSSIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbydynamicforms_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbydynamicforms_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbydynamicforms_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Resident Forms", ""), bttBtnfilterbydynamicforms_Jsonclick, 5, context.GetMessage( "Resident Forms", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYDYNAMICFORMS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbyagenda_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbyagenda_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbyagenda_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Agenda", ""), bttBtnfilterbyagenda_Jsonclick, 5, context.GetMessage( "Agenda", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYAGENDA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "BtnClearActiveFilter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnclearfilters_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Clear Filters", ""), bttBtnclearfilters_Jsonclick, 5, context.GetMessage( "Clear Filters", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCLEARFILTERS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV9FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV9FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WP_UserNotificationsBoard.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationmessage_Internalname, lblNotificationmessage_Caption, "", "", lblNotificationmessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_UserNotificationsBoard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl47( ) ;
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            nRC_GXsfl_47 = (int)(nGXsfl_47_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV51GXV1 = nGXsfl_47_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV15GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV16GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV17GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV51GXV1 = nGXsfl_47_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START9N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Notifications", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9N0( ) ;
      }

      protected void WS9N2( )
      {
         START9N2( ) ;
         EVT9N2( ) ;
      }

      protected void EVT9N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E119N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E129N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYMENTIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByMentions' */
                              E139N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYDISCUSSIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByDiscussions' */
                              E149N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYDYNAMICFORMS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByDynamicForms' */
                              E159N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYAGENDA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByAgenda' */
                              E169N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEARFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoClearFilters' */
                              E179N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTIFICATIONTYPES.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E189N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Onmessage_gx1 */
                              E199N2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRID.ONLINEACTIVATE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
                              SubsflControlProps_472( ) ;
                              AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) && ( AV51GXV1 > 0 ) )
                              {
                                 AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
                                 AV11NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                                 AssignAttri("", false, edtavNotificationicon_Internalname, AV11NotificationIcon);
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV33ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV33ActionGroup), 4, 0));
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
                                    E209N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E219N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E229N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E239N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E199N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.ONLINEACTIVATE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Onlineactivate */
                                    E249N2 ();
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
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E199N2 ();
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

      protected void WE9N2( )
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

      protected void PA9N2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = radavNotificationtypes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_472( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            sendrow_472( ) ;
            nGXsfl_47_idx = ((subGrid_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV58Pgmname ,
                                       string AV9FilterFullText ,
                                       GxSimpleCollection<short> AV41NotificationDefinitionIdEmptyCollection ,
                                       GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV10WWP_SDTNotificationsData ,
                                       string AV35NotificationTypes ,
                                       GxSimpleCollection<short> AV48MentionDefinitions ,
                                       GxSimpleCollection<short> AV47DiscussionDefinitions ,
                                       GxSimpleCollection<short> AV46FormDefinitions ,
                                       GxSimpleCollection<short> AV45AgendaDefinitions )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         AssignAttri("", false, "AV35NotificationTypes", AV35NotificationTypes);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "WP_UserNotificationsBoard";
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
      }

      protected void RF9N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 47;
         /* Execute user event: Refresh */
         E219N2 ();
         nGXsfl_47_idx = 1;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         bGXsfl_47_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_472( ) ;
            /* Execute user event: Grid.Load */
            E229N2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_47_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E229N2 ();
            }
            wbEnd = 47;
            WB9N0( ) ;
         }
         bGXsfl_47_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV48MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV48MentionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV47DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV47DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV46FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV46FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV46FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV45AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV45AgendaDefinitions, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV10WWP_SDTNotificationsData.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "WP_UserNotificationsBoard";
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E209N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Wwp_sdtnotificationsdata"), AV10WWP_SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vWWP_SDTNOTIFICATIONSDATA"), AV10WWP_SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV42NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV15GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            lblNotificationmessage_Caption = cgiGet( "NOTIFICATIONMESSAGE_Caption");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_47_fel_idx = 0;
            while ( nGXsfl_47_fel_idx < nRC_GXsfl_47 )
            {
               nGXsfl_47_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_47_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_fel_idx+1);
               sGXsfl_47_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_472( ) ;
               AV51GXV1 = (int)(nGXsfl_47_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) && ( AV51GXV1 > 0 ) )
               {
                  AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
                  AV11NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV33ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_47_fel_idx == 0 )
            {
               nGXsfl_47_idx = 1;
               sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
               SubsflControlProps_472( ) ;
            }
            nGXsfl_47_fel_idx = 1;
            /* Read variables values. */
            AV35NotificationTypes = cgiGet( radavNotificationtypes_Internalname);
            AssignAttri("", false, "AV35NotificationTypes", AV35NotificationTypes);
            AV9FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV9FilterFullText", AV9FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_47_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
            AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
            if ( nGXsfl_47_idx > 0 )
            {
               AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
               if ( ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) && ( AV51GXV1 > 0 ) )
               {
                  AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
                  AV11NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                  AssignAttri("", false, edtavNotificationicon_Internalname, AV11NotificationIcon);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV33ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV33ActionGroup), 4, 0));
               }
               if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
               {
                  AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
               }
            }
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         E209N2 ();
         if (returnInSub) return;
      }

      protected void E209N2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV39NumberOfUnRead = "-";
         AV35NotificationTypes = "All";
         AssignAttri("", false, "AV35NotificationTypes", AV35NotificationTypes);
         AV49CurrentNotficationGroupFilter = "";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         new prc_getallnotificationdefinitionids(context ).execute( out  AV45AgendaDefinitions, out  AV46FormDefinitions, out  AV47DiscussionDefinitions, out  AV48MentionDefinitions) ;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Form.Caption = context.GetMessage( "Notifications", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E219N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV15GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV15GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV15GridCurrentPage), 10, 0));
         AV16GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV16GridPageCount", StringUtil.LTrimStr( (decimal)(AV16GridPageCount), 10, 0));
         GXt_char2 = AV17GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char2) ;
         AV17GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV17GridAppliedFilters", AV17GridAppliedFilters);
         /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E119N2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV14PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV14PageToGo) ;
         }
      }

      protected void E129N2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E229N2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV10WWP_SDTNotificationsData.Count )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Mark as Read", ""), "fas fa-envelope-open", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Open Link", ""), "fas fa-link", "", "", "", "", "", "", ""), 0);
            edtavNotificationicon_Format = 2;
            AV11NotificationIcon = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV10WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon_Internalname, AV11NotificationIcon);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 47;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_472( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_47_Refreshing )
            {
               DoAjaxLoad(47, GridRow);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0));
      }

      protected void E239N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV33ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO MARKASREAD' */
            S162 ();
            if (returnInSub) return;
         }
         else if ( AV33ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO OPENLINK' */
            S172 ();
            if (returnInSub) return;
         }
         AV33ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV33ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
      }

      protected void E139N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* 'DoFilterByMentions' Routine */
         returnInSub = false;
         AV49CurrentNotficationGroupFilter = "Mentions";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV48MentionDefinitions, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E149N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* 'DoFilterByDiscussions' Routine */
         returnInSub = false;
         AV49CurrentNotficationGroupFilter = "Discussions";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV47DiscussionDefinitions, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E159N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* 'DoFilterByDynamicForms' Routine */
         returnInSub = false;
         AV49CurrentNotficationGroupFilter = "Forms";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV46FormDefinitions, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E169N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* 'DoFilterByAgenda' Routine */
         returnInSub = false;
         AV49CurrentNotficationGroupFilter = "Agenda";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV45AgendaDefinitions, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E179N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* 'DoClearFilters' Routine */
         returnInSub = false;
         AV35NotificationTypes = "All";
         AssignAttri("", false, "AV35NotificationTypes", AV35NotificationTypes);
         AV49CurrentNotficationGroupFilter = "";
         AssignAttri("", false, "AV49CurrentNotficationGroupFilter", AV49CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV47 = true;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV35NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'DO MARKASREAD' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S172( )
      {
         /* 'DO OPENLINK' Routine */
         returnInSub = false;
         GX_msglist.addItem(context.GetMessage( "Link: ", "")+((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV10WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationlink);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV58Pgmname+"GridState"), "") == 0 )
         {
            AV23GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV58Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV23GridState.FromXml(AV13Session.Get(AV58Pgmname+"GridState"), null, "", "");
         }
         AV59GXV8 = 1;
         while ( AV59GXV8 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV59GXV8));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV9FilterFullText = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV9FilterFullText", AV9FilterFullText);
            }
            AV59GXV8 = (int)(AV59GXV8+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV23GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV23GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV23GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV23GridState.FromXml(AV13Session.Get(AV58Pgmname+"GridState"), null, "", "");
         AV23GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV23GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV9FilterFullText)),  0,  AV9FilterFullText,  AV9FilterFullText,  false,  "",  "") ;
         AV23GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV23GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV23GridState.ToXml(false, true, "", "")) ;
      }

      protected void E189N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* Notificationtypes_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35NotificationTypes, "Read") == 0 )
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         else if ( StringUtil.StrCmp(AV35NotificationTypes, "UnRead") == 0 )
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         else
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E199N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV35NotificationTypes, "Read") == 0 )
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         else if ( StringUtil.StrCmp(AV35NotificationTypes, "UnRead") == 0 )
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         else
         {
            GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV10WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV35NotificationTypes,  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
            AV10WWP_SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
            gx_BV47 = true;
         }
         gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
         /*  Sending Event outputs  */
         if ( gx_BV47 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10WWP_SDTNotificationsData", AV10WWP_SDTNotificationsData);
            nGXsfl_47_bak_idx = nGXsfl_47_idx;
            gxgrGrid_refresh( subGrid_Rows, AV58Pgmname, AV9FilterFullText, AV41NotificationDefinitionIdEmptyCollection, AV10WWP_SDTNotificationsData, AV35NotificationTypes, AV48MentionDefinitions, AV47DiscussionDefinitions, AV46FormDefinitions, AV45AgendaDefinitions) ;
            nGXsfl_47_idx = nGXsfl_47_bak_idx;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
      }

      protected void E249N2( )
      {
         AV51GXV1 = (int)(nGXsfl_47_idx+GRID_nFirstRecordOnPage);
         if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) )
         {
            AV10WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1));
         }
         /* Grid_Onlineactivate Routine */
         returnInSub = false;
         AV50LinkUrl = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV10WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationlink;
         CallWebObject(formatLink(AV50LinkUrl) );
         context.wjLocDisableFrm = 0;
         GXt_int3 = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV10WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationid;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadbyid( ref  GXt_int3) ;
         ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV10WWP_SDTNotificationsData.CurrentItem)).gxTpr_Notificationid = (int)(GXt_int3);
      }

      protected void S112( )
      {
         /* 'GETNUMBEROFUNREADNOTIFICATIONS' Routine */
         returnInSub = false;
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV40WWP_SDTNotificationsData_UnRead;
         new dp_getusernotifications(context ).execute(  context.GetMessage( "UnRead", ""),  AV41NotificationDefinitionIdEmptyCollection, out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV40WWP_SDTNotificationsData_UnRead = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         AV39NumberOfUnRead = StringUtil.Str( (decimal)(AV40WWP_SDTNotificationsData_UnRead.Count), 9, 0);
         lblNotificationmessage_Caption = context.GetMessage( "YOU HAVE ", "")+AV39NumberOfUnRead+context.GetMessage( " UNREAD MESSAGES", "");
         AssignProp("", false, lblNotificationmessage_Internalname, "Caption", lblNotificationmessage_Caption, true);
      }

      protected void S132( )
      {
         /* 'SETACTIVEFILTER' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV49CurrentNotficationGroupFilter, "Mentions") == 0 )
         {
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV49CurrentNotficationGroupFilter, "Discussions") == 0 )
         {
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV49CurrentNotficationGroupFilter, "Forms") == 0 )
         {
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV49CurrentNotficationGroupFilter, "Agenda") == 0 )
         {
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
         }
         else
         {
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
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
         PA9N2( ) ;
         WS9N2( ) ;
         WE9N2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112914315062", true, true);
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
         context.AddJavascriptSource("wp_usernotificationsboard.js", "?2024112914315063", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_472( )
      {
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_47_idx;
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_47_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_47_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_47_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_47_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_47_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_47_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_472( )
      {
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_47_fel_idx;
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_47_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_47_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_47_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_47_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_47_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_47_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_47_fel_idx;
      }

      protected void sendrow_472( )
      {
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         WB9N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_47_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_47_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationid), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWwp_sdtnotificationsdata__notificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationid), "ZZZZ9") : context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationid), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_47_idx + "',47)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)AV11NotificationIcon,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)edtavNotificationicon_Format,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationiconclass,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_47_idx + "',47)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationtitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_47_idx + "',47)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationdescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationdescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_47_idx + "',47)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationdatetime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationlink_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV10WWP_SDTNotificationsData.Item(AV51GXV1)).gxTpr_Notificationlink,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationlink_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_47_idx + "',47)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_47_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) && (0==AV33ActionGroup) )
                  {
                     AV33ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV33ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_47_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_47_Refreshing);
            send_integrity_lvl_hashes9N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_47_idx = ((subGrid_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         /* End function sendrow_472 */
      }

      protected void init_web_controls( )
      {
         radavNotificationtypes.Name = "vNOTIFICATIONTYPES";
         radavNotificationtypes.WebTags = "";
         radavNotificationtypes.addItem("All", context.GetMessage( "All", ""), 0);
         radavNotificationtypes.addItem("Read", context.GetMessage( "Read", ""), 0);
         radavNotificationtypes.addItem("UnRead", context.GetMessage( "UnRead", ""), 0);
         GXCCtl = "vACTIONGROUP_" + sGXsfl_47_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV51GXV1 > 0 ) && ( AV10WWP_SDTNotificationsData.Count >= AV51GXV1 ) && (0==AV33ActionGroup) )
            {
               AV33ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV33ActionGroup), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl47( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"47\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(40), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Icon Class", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date/Time", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Link", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV11NotificationIcon));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Format), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdescription_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationlink_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ActionGroup), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         radavNotificationtypes_Internalname = "vNOTIFICATIONTYPES";
         bttBtnfilterbymentions_Internalname = "BTNFILTERBYMENTIONS";
         bttBtnfilterbydiscussions_Internalname = "BTNFILTERBYDISCUSSIONS";
         bttBtnfilterbydynamicforms_Internalname = "BTNFILTERBYDYNAMICFORMS";
         bttBtnfilterbyagenda_Internalname = "BTNFILTERBYAGENDA";
         bttBtnclearfilters_Internalname = "BTNCLEARFILTERS";
         divTableactions_Internalname = "TABLEACTIONS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         lblNotificationmessage_Internalname = "NOTIFICATIONMESSAGE";
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID";
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON";
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION";
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
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
         edtavNotificationicon_Jsonclick = "";
         edtavNotificationicon_Enabled = 1;
         edtavNotificationicon_Format = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = -1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnfilterbyagenda_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbydynamicforms_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbydiscussions_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbymentions_Backcolor = (int)(0xF0F0F0);
         radavNotificationtypes_Jsonclick = "";
         lblNotificationmessage_Caption = context.GetMessage( "YOU HAVE 8 UNREAD NOTIFICATIONS", "");
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Notifications", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV15GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV16GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"lblNotificationmessage_Caption","ctrl":"NOTIFICATIONMESSAGE","prop":"Caption"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E119N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E129N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E229N2","iparms":[{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV33ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtavNotificationicon_Format","ctrl":"vNOTIFICATIONICON","prop":"Format"},{"av":"AV11NotificationIcon","fld":"vNOTIFICATIONICON"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E239N2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV33ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV33ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"lblNotificationmessage_Caption","ctrl":"NOTIFICATIONMESSAGE","prop":"Caption"}]}""");
         setEventMetadata("'DOFILTERBYMENTIONS'","""{"handler":"E139N2","iparms":[{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("'DOFILTERBYMENTIONS'",""","oparms":[{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"}]}""");
         setEventMetadata("'DOFILTERBYDISCUSSIONS'","""{"handler":"E149N2","iparms":[{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("'DOFILTERBYDISCUSSIONS'",""","oparms":[{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"}]}""");
         setEventMetadata("'DOFILTERBYDYNAMICFORMS'","""{"handler":"E159N2","iparms":[{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("'DOFILTERBYDYNAMICFORMS'",""","oparms":[{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"}]}""");
         setEventMetadata("'DOFILTERBYAGENDA'","""{"handler":"E169N2","iparms":[{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true}]""");
         setEventMetadata("'DOFILTERBYAGENDA'",""","oparms":[{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"}]}""");
         setEventMetadata("'DOCLEARFILTERS'","""{"handler":"E179N2","iparms":[{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("'DOCLEARFILTERS'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV49CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"}]}""");
         setEventMetadata("VNOTIFICATIONTYPES.CONTROLVALUECHANGED","""{"handler":"E189N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true}]""");
         setEventMetadata("VNOTIFICATIONTYPES.CONTROLVALUECHANGED",""","oparms":[{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"AV15GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV16GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"lblNotificationmessage_Caption","ctrl":"NOTIFICATIONMESSAGE","prop":"Caption"}]}""");
         setEventMetadata("GRID.ONLINEACTIVATE","""{"handler":"E249N2","iparms":[{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47}]}""");
         setEventMetadata("ONMESSAGE_GX1","""{"handler":"E199N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV9FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"radavNotificationtypes"},{"av":"AV35NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV48MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV47DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV46FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV45AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"AV42NotificationInfo","fld":"vNOTIFICATIONINFO"}]""");
         setEventMetadata("ONMESSAGE_GX1",""","oparms":[{"av":"AV10WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA","grid":47},{"av":"nGXsfl_47_idx","ctrl":"GRID","prop":"GridCurrRow","grid":47},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_47","ctrl":"GRID","prop":"GridRC","grid":47},{"av":"lblNotificationmessage_Caption","ctrl":"NOTIFICATIONMESSAGE","prop":"Caption"},{"av":"AV15GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV16GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Actiongroup","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV58Pgmname = "";
         AV9FilterFullText = "";
         AV41NotificationDefinitionIdEmptyCollection = new GxSimpleCollection<short>();
         AV10WWP_SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2");
         AV35NotificationTypes = "";
         AV48MentionDefinitions = new GxSimpleCollection<short>();
         AV47DiscussionDefinitions = new GxSimpleCollection<short>();
         AV46FormDefinitions = new GxSimpleCollection<short>();
         AV45AgendaDefinitions = new GxSimpleCollection<short>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17GridAppliedFilters = "";
         AV49CurrentNotficationGroupFilter = "";
         AV42NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnfilterbymentions_Jsonclick = "";
         bttBtnfilterbydiscussions_Jsonclick = "";
         bttBtnfilterbydynamicforms_Jsonclick = "";
         bttBtnfilterbyagenda_Jsonclick = "";
         bttBtnclearfilters_Jsonclick = "";
         lblNotificationmessage_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11NotificationIcon = "";
         AV39NumberOfUnRead = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV13Session = context.GetSession();
         AV23GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV24GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50LinkUrl = "";
         AV40WWP_SDTNotificationsData_UnRead = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version2");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         AV58Pgmname = "WP_UserNotificationsBoard";
         /* GeneXus formulas. */
         AV58Pgmname = "WP_UserNotificationsBoard";
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV33ActionGroup ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short edtavNotificationicon_Format ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_47 ;
      private int nGXsfl_47_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnfilterbymentions_Backcolor ;
      private int bttBtnfilterbydiscussions_Backcolor ;
      private int bttBtnfilterbydynamicforms_Backcolor ;
      private int bttBtnfilterbyagenda_Backcolor ;
      private int edtavFilterfulltext_Enabled ;
      private int AV51GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavWwp_sdtnotificationsdata__notificationid_Enabled ;
      private int edtavNotificationicon_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdescription_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationlink_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_47_fel_idx=1 ;
      private int AV14PageToGo ;
      private int nGXsfl_47_bak_idx=1 ;
      private int AV59GXV8 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV15GridCurrentPage ;
      private long AV16GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long GXt_int3 ;
      private string Gridpaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_47_idx="0001" ;
      private string AV58Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Grid_empowerer_Gridinternalname ;
      private string lblNotificationmessage_Caption ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavNotificationtypes_Internalname ;
      private string radavNotificationtypes_Jsonclick ;
      private string bttBtnfilterbymentions_Internalname ;
      private string bttBtnfilterbymentions_Jsonclick ;
      private string bttBtnfilterbydiscussions_Internalname ;
      private string bttBtnfilterbydiscussions_Jsonclick ;
      private string bttBtnfilterbydynamicforms_Internalname ;
      private string bttBtnfilterbydynamicforms_Jsonclick ;
      private string bttBtnfilterbyagenda_Internalname ;
      private string bttBtnfilterbyagenda_Jsonclick ;
      private string bttBtnclearfilters_Internalname ;
      private string bttBtnclearfilters_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string lblNotificationmessage_Internalname ;
      private string lblNotificationmessage_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationicon_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string AV39NumberOfUnRead ;
      private string GXt_char2 ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Jsonclick ;
      private string edtavNotificationicon_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV47 ;
      private bool gx_refresh_fired ;
      private string AV9FilterFullText ;
      private string AV35NotificationTypes ;
      private string AV17GridAppliedFilters ;
      private string AV49CurrentNotficationGroupFilter ;
      private string AV11NotificationIcon ;
      private string AV50LinkUrl ;
      private IGxSession AV13Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavNotificationtypes ;
      private GXCombobox cmbavActiongroup ;
      private GxSimpleCollection<short> AV41NotificationDefinitionIdEmptyCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV10WWP_SDTNotificationsData ;
      private GxSimpleCollection<short> AV48MentionDefinitions ;
      private GxSimpleCollection<short> AV47DiscussionDefinitions ;
      private GxSimpleCollection<short> AV46FormDefinitions ;
      private GxSimpleCollection<short> AV45AgendaDefinitions ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV42NotificationInfo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV23GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV24GridStateFilterValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV40WWP_SDTNotificationsData_UnRead ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
