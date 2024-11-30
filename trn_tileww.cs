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
   public class trn_tileww : GXDataArea
   {
      public trn_tileww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tileww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV52Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV20TFTileName = GetPar( "TFTileName");
         AV21TFTileName_Sel = GetPar( "TFTileName_Sel");
         AV22TFTileBGColor = GetPar( "TFTileBGColor");
         AV23TFTileBGColor_Sel = GetPar( "TFTileBGColor_Sel");
         AV24TFTileBGImageUrl = GetPar( "TFTileBGImageUrl");
         AV25TFTileBGImageUrl_Sel = GetPar( "TFTileBGImageUrl_Sel");
         AV26TFTileTextColor = GetPar( "TFTileTextColor");
         AV27TFTileTextColor_Sel = GetPar( "TFTileTextColor_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV29TFTileTextAlignment_Sels);
         AV30TFTileIcon = GetPar( "TFTileIcon");
         AV31TFTileIcon_Sel = GetPar( "TFTileIcon_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV33TFTileIconAlignment_Sels);
         AV34TFTileIconColor = GetPar( "TFTileIconColor");
         AV35TFTileIconColor_Sel = GetPar( "TFTileIconColor_Sel");
         AV36TFTileAction = GetPar( "TFTileAction");
         AV37TFTileAction_Sel = GetPar( "TFTileAction_Sel");
         AV47IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV48IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV49IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV45IsAuthorized_TileName = StringUtil.StrToBool( GetPar( "IsAuthorized_TileName"));
         AV50IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
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
            return "trn_tileww_Execute" ;
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
         PA842( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START842( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_tileww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV47IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV47IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV45IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV45IsAuthorized_TileName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV44GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTILENAME", AV20TFTileName);
         GxWebStd.gx_hidden_field( context, "vTFTILENAME_SEL", AV21TFTileName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTILEBGCOLOR", StringUtil.RTrim( AV22TFTileBGColor));
         GxWebStd.gx_hidden_field( context, "vTFTILEBGCOLOR_SEL", StringUtil.RTrim( AV23TFTileBGColor_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTILEBGIMAGEURL", AV24TFTileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "vTFTILEBGIMAGEURL_SEL", AV25TFTileBGImageUrl_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTCOLOR", StringUtil.RTrim( AV26TFTileTextColor));
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTCOLOR_SEL", StringUtil.RTrim( AV27TFTileTextColor_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTILETEXTALIGNMENT_SELS", AV29TFTileTextAlignment_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTILETEXTALIGNMENT_SELS", AV29TFTileTextAlignment_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTILEICON", StringUtil.RTrim( AV30TFTileIcon));
         GxWebStd.gx_hidden_field( context, "vTFTILEICON_SEL", StringUtil.RTrim( AV31TFTileIcon_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTILEICONALIGNMENT_SELS", AV33TFTileIconAlignment_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTILEICONALIGNMENT_SELS", AV33TFTileIconAlignment_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTILEICONCOLOR", StringUtil.RTrim( AV34TFTileIconColor));
         GxWebStd.gx_hidden_field( context, "vTFTILEICONCOLOR_SEL", StringUtil.RTrim( AV35TFTileIconColor_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTILEACTION", AV36TFTileAction);
         GxWebStd.gx_hidden_field( context, "vTFTILEACTION_SEL", AV37TFTileAction_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV47IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV47IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV45IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV45IsAuthorized_TileName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTALIGNMENT_SELSJSON", AV28TFTileTextAlignment_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFTILEICONALIGNMENT_SELSJSON", AV32TFTileIconAlignment_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
            WE842( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT842( ) ;
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
         return formatLink("trn_tileww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_TileWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Tile", "") ;
      }

      protected void WB840( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_TileWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_TileWW.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_TileWW.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV42GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV43GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV44GridAppliedFilters);
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
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0059"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0059"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0059"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void START842( )
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
         Form.Meta.addItem("description", context.GetMessage( " Tile", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP840( ) ;
      }

      protected void WS842( )
      {
         START842( ) ;
         EVT842( ) ;
      }

      protected void EVT842( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E11842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E14842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E16842 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A407TileId = StringUtil.StrToGuid( cgiGet( edtTileId_Internalname));
                              A400TileName = cgiGet( edtTileName_Internalname);
                              A402TileBGColor = cgiGet( edtTileBGColor_Internalname);
                              n402TileBGColor = false;
                              A403TileBGImageUrl = cgiGet( edtTileBGImageUrl_Internalname);
                              n403TileBGImageUrl = false;
                              A404TileTextColor = cgiGet( edtTileTextColor_Internalname);
                              cmbTileTextAlignment.Name = cmbTileTextAlignment_Internalname;
                              cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
                              A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
                              A401TileIcon = cgiGet( edtTileIcon_Internalname);
                              n401TileIcon = false;
                              cmbTileIconAlignment.Name = cmbTileIconAlignment_Internalname;
                              cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
                              A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
                              A438TileIconColor = cgiGet( edtTileIconColor_Internalname);
                              A436TileAction = cgiGet( edtTileAction_Internalname);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV46ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV46ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E20842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 59 )
                        {
                           OldWwpaux_wc = cgiGet( "W0059");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0059", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE842( )
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

      protected void PA842( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV52Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV20TFTileName ,
                                       string AV21TFTileName_Sel ,
                                       string AV22TFTileBGColor ,
                                       string AV23TFTileBGColor_Sel ,
                                       string AV24TFTileBGImageUrl ,
                                       string AV25TFTileBGImageUrl_Sel ,
                                       string AV26TFTileTextColor ,
                                       string AV27TFTileTextColor_Sel ,
                                       GxSimpleCollection<string> AV29TFTileTextAlignment_Sels ,
                                       string AV30TFTileIcon ,
                                       string AV31TFTileIcon_Sel ,
                                       GxSimpleCollection<string> AV33TFTileIconAlignment_Sels ,
                                       string AV34TFTileIconColor ,
                                       string AV35TFTileIconColor_Sel ,
                                       string AV36TFTileAction ,
                                       string AV37TFTileAction_Sel ,
                                       bool AV47IsAuthorized_Display ,
                                       bool AV48IsAuthorized_Update ,
                                       bool AV49IsAuthorized_Delete ,
                                       bool AV45IsAuthorized_TileName ,
                                       bool AV50IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF842( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TILEID", GetSecureSignedToken( "", A407TileId, context));
         GxWebStd.gx_hidden_field( context, "TILEID", A407TileId.ToString());
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
         RF842( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "Trn_TileWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV62Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV65Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV55Trn_tilewwds_3_tftilename_sel ,
                                              AV54Trn_tilewwds_2_tftilename ,
                                              AV57Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV56Trn_tilewwds_4_tftilebgcolor ,
                                              AV59Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV58Trn_tilewwds_6_tftilebgimageurl ,
                                              AV61Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV60Trn_tilewwds_8_tftiletextcolor ,
                                              AV62Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV64Trn_tilewwds_12_tftileicon_sel ,
                                              AV63Trn_tilewwds_11_tftileicon ,
                                              AV65Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV67Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV66Trn_tilewwds_14_tftileiconcolor ,
                                              AV69Trn_tilewwds_17_tftileaction_sel ,
                                              AV68Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV53Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV54Trn_tilewwds_2_tftilename), "%", "");
         lV56Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV56Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV58Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV58Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV60Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV60Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV63Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV63Trn_tilewwds_11_tftileicon), 20, "%");
         lV66Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV66Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV68Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV68Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor H00842 */
         pr_default.execute(0, new Object[] {lV54Trn_tilewwds_2_tftilename, AV55Trn_tilewwds_3_tftilename_sel, lV56Trn_tilewwds_4_tftilebgcolor, AV57Trn_tilewwds_5_tftilebgcolor_sel, lV58Trn_tilewwds_6_tftilebgimageurl, AV59Trn_tilewwds_7_tftilebgimageurl_sel, lV60Trn_tilewwds_8_tftiletextcolor, AV61Trn_tilewwds_9_tftiletextcolor_sel, lV63Trn_tilewwds_11_tftileicon, AV64Trn_tilewwds_12_tftileicon_sel, lV66Trn_tilewwds_14_tftileiconcolor, AV67Trn_tilewwds_15_tftileiconcolor_sel, lV68Trn_tilewwds_16_tftileaction, AV69Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A436TileAction = H00842_A436TileAction[0];
            A438TileIconColor = H00842_A438TileIconColor[0];
            A406TileIconAlignment = H00842_A406TileIconAlignment[0];
            A401TileIcon = H00842_A401TileIcon[0];
            n401TileIcon = H00842_n401TileIcon[0];
            A405TileTextAlignment = H00842_A405TileTextAlignment[0];
            A404TileTextColor = H00842_A404TileTextColor[0];
            A403TileBGImageUrl = H00842_A403TileBGImageUrl[0];
            n403TileBGImageUrl = H00842_n403TileBGImageUrl[0];
            A402TileBGColor = H00842_A402TileBGColor[0];
            n402TileBGColor = H00842_n402TileBGColor[0];
            A400TileName = H00842_A400TileName[0];
            A407TileId = H00842_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF842( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E18842 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A405TileTextAlignment ,
                                                 AV62Trn_tilewwds_10_tftiletextalignment_sels ,
                                                 A406TileIconAlignment ,
                                                 AV65Trn_tilewwds_13_tftileiconalignment_sels ,
                                                 AV55Trn_tilewwds_3_tftilename_sel ,
                                                 AV54Trn_tilewwds_2_tftilename ,
                                                 AV57Trn_tilewwds_5_tftilebgcolor_sel ,
                                                 AV56Trn_tilewwds_4_tftilebgcolor ,
                                                 AV59Trn_tilewwds_7_tftilebgimageurl_sel ,
                                                 AV58Trn_tilewwds_6_tftilebgimageurl ,
                                                 AV61Trn_tilewwds_9_tftiletextcolor_sel ,
                                                 AV60Trn_tilewwds_8_tftiletextcolor ,
                                                 AV62Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                                 AV64Trn_tilewwds_12_tftileicon_sel ,
                                                 AV63Trn_tilewwds_11_tftileicon ,
                                                 AV65Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                                 AV67Trn_tilewwds_15_tftileiconcolor_sel ,
                                                 AV66Trn_tilewwds_14_tftileiconcolor ,
                                                 AV69Trn_tilewwds_17_tftileaction_sel ,
                                                 AV68Trn_tilewwds_16_tftileaction ,
                                                 A400TileName ,
                                                 A402TileBGColor ,
                                                 A403TileBGImageUrl ,
                                                 A404TileTextColor ,
                                                 A401TileIcon ,
                                                 A438TileIconColor ,
                                                 A436TileAction ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV53Trn_tilewwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV54Trn_tilewwds_2_tftilename), "%", "");
            lV56Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV56Trn_tilewwds_4_tftilebgcolor), 20, "%");
            lV58Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV58Trn_tilewwds_6_tftilebgimageurl), "%", "");
            lV60Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV60Trn_tilewwds_8_tftiletextcolor), 20, "%");
            lV63Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV63Trn_tilewwds_11_tftileicon), 20, "%");
            lV66Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV66Trn_tilewwds_14_tftileiconcolor), 20, "%");
            lV68Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV68Trn_tilewwds_16_tftileaction), "%", "");
            /* Using cursor H00843 */
            pr_default.execute(1, new Object[] {lV54Trn_tilewwds_2_tftilename, AV55Trn_tilewwds_3_tftilename_sel, lV56Trn_tilewwds_4_tftilebgcolor, AV57Trn_tilewwds_5_tftilebgcolor_sel, lV58Trn_tilewwds_6_tftilebgimageurl, AV59Trn_tilewwds_7_tftilebgimageurl_sel, lV60Trn_tilewwds_8_tftiletextcolor, AV61Trn_tilewwds_9_tftiletextcolor_sel, lV63Trn_tilewwds_11_tftileicon, AV64Trn_tilewwds_12_tftileicon_sel, lV66Trn_tilewwds_14_tftileiconcolor, AV67Trn_tilewwds_15_tftileiconcolor_sel, lV68Trn_tilewwds_16_tftileaction, AV69Trn_tilewwds_17_tftileaction_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A436TileAction = H00843_A436TileAction[0];
               A438TileIconColor = H00843_A438TileIconColor[0];
               A406TileIconAlignment = H00843_A406TileIconAlignment[0];
               A401TileIcon = H00843_A401TileIcon[0];
               n401TileIcon = H00843_n401TileIcon[0];
               A405TileTextAlignment = H00843_A405TileTextAlignment[0];
               A404TileTextColor = H00843_A404TileTextColor[0];
               A403TileBGImageUrl = H00843_A403TileBGImageUrl[0];
               n403TileBGImageUrl = H00843_n403TileBGImageUrl[0];
               A402TileBGColor = H00843_A402TileBGColor[0];
               n402TileBGColor = H00843_n402TileBGColor[0];
               A400TileName = H00843_A400TileName[0];
               A407TileId = H00843_A407TileId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV53Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E19842 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB840( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes842( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV47IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV47IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV45IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV45IsAuthorized_TileName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TILEID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A407TileId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV52Pgmname, AV15FilterFullText, AV20TFTileName, AV21TFTileName_Sel, AV22TFTileBGColor, AV23TFTileBGColor_Sel, AV24TFTileBGImageUrl, AV25TFTileBGImageUrl_Sel, AV26TFTileTextColor, AV27TFTileTextColor_Sel, AV29TFTileTextAlignment_Sels, AV30TFTileIcon, AV31TFTileIcon_Sel, AV33TFTileIconAlignment_Sels, AV34TFTileIconColor, AV35TFTileIconColor_Sel, AV36TFTileAction, AV37TFTileAction_Sel, AV47IsAuthorized_Display, AV48IsAuthorized_Update, AV49IsAuthorized_Delete, AV45IsAuthorized_TileName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV52Pgmname = "Trn_TileWW";
         edtTileId_Enabled = 0;
         edtTileName_Enabled = 0;
         edtTileBGColor_Enabled = 0;
         edtTileBGImageUrl_Enabled = 0;
         edtTileTextColor_Enabled = 0;
         cmbTileTextAlignment.Enabled = 0;
         edtTileIcon_Enabled = 0;
         cmbTileIconAlignment.Enabled = 0;
         edtTileIconColor_Enabled = 0;
         edtTileAction_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP840( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17842 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV38DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV42GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV43GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV44GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
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
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_37_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            if ( nGXsfl_37_idx > 0 )
            {
               A407TileId = StringUtil.StrToGuid( cgiGet( edtTileId_Internalname));
               A400TileName = cgiGet( edtTileName_Internalname);
               A402TileBGColor = cgiGet( edtTileBGColor_Internalname);
               n402TileBGColor = false;
               A403TileBGImageUrl = cgiGet( edtTileBGImageUrl_Internalname);
               n403TileBGImageUrl = false;
               A404TileTextColor = cgiGet( edtTileTextColor_Internalname);
               cmbTileTextAlignment.Name = cmbTileTextAlignment_Internalname;
               cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
               A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
               A401TileIcon = cgiGet( edtTileIcon_Internalname);
               n401TileIcon = false;
               cmbTileIconAlignment.Name = cmbTileIconAlignment_Internalname;
               cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
               A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
               A438TileIconColor = cgiGet( edtTileIconColor_Internalname);
               A436TileAction = cgiGet( edtTileAction_Internalname);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV46ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV46ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E17842 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17842( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV45IsAuthorized_TileName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_tileview_Execute", out  GXt_boolean1) ;
         AV45IsAuthorized_TileName = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_TileName", AV45IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV45IsAuthorized_TileName, context));
         AV39GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV40GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV39GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Tile", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV38DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV38DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18842( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV42GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV42GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV42GridCurrentPage), 10, 0));
         AV43GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV43GridPageCount", StringUtil.LTrimStr( (decimal)(AV43GridPageCount), 10, 0));
         GXt_char3 = AV44GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV52Pgmname, out  GXt_char3) ;
         AV44GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV44GridAppliedFilters", AV44GridAppliedFilters);
         AV53Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV54Trn_tilewwds_2_tftilename = AV20TFTileName;
         AV55Trn_tilewwds_3_tftilename_sel = AV21TFTileName_Sel;
         AV56Trn_tilewwds_4_tftilebgcolor = AV22TFTileBGColor;
         AV57Trn_tilewwds_5_tftilebgcolor_sel = AV23TFTileBGColor_Sel;
         AV58Trn_tilewwds_6_tftilebgimageurl = AV24TFTileBGImageUrl;
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = AV25TFTileBGImageUrl_Sel;
         AV60Trn_tilewwds_8_tftiletextcolor = AV26TFTileTextColor;
         AV61Trn_tilewwds_9_tftiletextcolor_sel = AV27TFTileTextColor_Sel;
         AV62Trn_tilewwds_10_tftiletextalignment_sels = AV29TFTileTextAlignment_Sels;
         AV63Trn_tilewwds_11_tftileicon = AV30TFTileIcon;
         AV64Trn_tilewwds_12_tftileicon_sel = AV31TFTileIcon_Sel;
         AV65Trn_tilewwds_13_tftileiconalignment_sels = AV33TFTileIconAlignment_Sels;
         AV66Trn_tilewwds_14_tftileiconcolor = AV34TFTileIconColor;
         AV67Trn_tilewwds_15_tftileiconcolor_sel = AV35TFTileIconColor_Sel;
         AV68Trn_tilewwds_16_tftileaction = AV36TFTileAction;
         AV69Trn_tilewwds_17_tftileaction_sel = AV37TFTileAction_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12842( )
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
            AV41PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV41PageToGo) ;
         }
      }

      protected void E13842( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15842( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileName") == 0 )
            {
               AV20TFTileName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFTileName", AV20TFTileName);
               AV21TFTileName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFTileName_Sel", AV21TFTileName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileBGColor") == 0 )
            {
               AV22TFTileBGColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFTileBGColor", AV22TFTileBGColor);
               AV23TFTileBGColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFTileBGColor_Sel", AV23TFTileBGColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileBGImageUrl") == 0 )
            {
               AV24TFTileBGImageUrl = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFTileBGImageUrl", AV24TFTileBGImageUrl);
               AV25TFTileBGImageUrl_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFTileBGImageUrl_Sel", AV25TFTileBGImageUrl_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileTextColor") == 0 )
            {
               AV26TFTileTextColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFTileTextColor", AV26TFTileTextColor);
               AV27TFTileTextColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFTileTextColor_Sel", AV27TFTileTextColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileTextAlignment") == 0 )
            {
               AV28TFTileTextAlignment_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFTileTextAlignment_SelsJson", AV28TFTileTextAlignment_SelsJson);
               AV29TFTileTextAlignment_Sels.FromJSonString(AV28TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileIcon") == 0 )
            {
               AV30TFTileIcon = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFTileIcon", AV30TFTileIcon);
               AV31TFTileIcon_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFTileIcon_Sel", AV31TFTileIcon_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileIconAlignment") == 0 )
            {
               AV32TFTileIconAlignment_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFTileIconAlignment_SelsJson", AV32TFTileIconAlignment_SelsJson);
               AV33TFTileIconAlignment_Sels.FromJSonString(AV32TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileIconColor") == 0 )
            {
               AV34TFTileIconColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFTileIconColor", AV34TFTileIconColor);
               AV35TFTileIconColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFTileIconColor_Sel", AV35TFTileIconColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileAction") == 0 )
            {
               AV36TFTileAction = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFTileAction", AV36TFTileAction);
               AV37TFTileAction_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFTileAction_Sel", AV37TFTileAction_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33TFTileIconAlignment_Sels", AV33TFTileIconAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29TFTileTextAlignment_Sels", AV29TFTileTextAlignment_Sels);
      }

      private void E19842( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV47IsAuthorized_Display )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV48IsAuthorized_Update )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV49IsAuthorized_Delete )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            if ( AV45IsAuthorized_TileName )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_tileview.aspx"+UrlEncode(A407TileId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtTileName_Link = formatLink("trn_tileview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            edtTileBGImageUrl_Linktarget = "_blank";
            edtTileBGImageUrl_Link = A403TileBGImageUrl;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0));
      }

      protected void E11842( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_TileWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV52Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_TileWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_TileWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV18ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29TFTileTextAlignment_Sels", AV29TFTileTextAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33TFTileIconAlignment_Sels", AV33TFTileIconAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E20842( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV46ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV46ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV46ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV46ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV46ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E16842( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV50IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E14842( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0059",(string)"",(string)"Trn_Tile",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0059"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV47IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_tileview_Execute", out  GXt_boolean1) ;
         AV47IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Display", AV47IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV47IsAuthorized_Display, context));
         GXt_boolean1 = AV48IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Update", out  GXt_boolean1) ;
         AV48IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_Update", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GXt_boolean1 = AV49IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Delete", out  GXt_boolean1) ;
         AV49IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Delete", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GXt_boolean1 = AV50IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Insert", out  GXt_boolean1) ;
         AV50IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Insert", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         if ( ! ( AV50IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Tile",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV17ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_TileWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV20TFTileName = "";
         AssignAttri("", false, "AV20TFTileName", AV20TFTileName);
         AV21TFTileName_Sel = "";
         AssignAttri("", false, "AV21TFTileName_Sel", AV21TFTileName_Sel);
         AV22TFTileBGColor = "";
         AssignAttri("", false, "AV22TFTileBGColor", AV22TFTileBGColor);
         AV23TFTileBGColor_Sel = "";
         AssignAttri("", false, "AV23TFTileBGColor_Sel", AV23TFTileBGColor_Sel);
         AV24TFTileBGImageUrl = "";
         AssignAttri("", false, "AV24TFTileBGImageUrl", AV24TFTileBGImageUrl);
         AV25TFTileBGImageUrl_Sel = "";
         AssignAttri("", false, "AV25TFTileBGImageUrl_Sel", AV25TFTileBGImageUrl_Sel);
         AV26TFTileTextColor = "";
         AssignAttri("", false, "AV26TFTileTextColor", AV26TFTileTextColor);
         AV27TFTileTextColor_Sel = "";
         AssignAttri("", false, "AV27TFTileTextColor_Sel", AV27TFTileTextColor_Sel);
         AV29TFTileTextAlignment_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30TFTileIcon = "";
         AssignAttri("", false, "AV30TFTileIcon", AV30TFTileIcon);
         AV31TFTileIcon_Sel = "";
         AssignAttri("", false, "AV31TFTileIcon_Sel", AV31TFTileIcon_Sel);
         AV33TFTileIconAlignment_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34TFTileIconColor = "";
         AssignAttri("", false, "AV34TFTileIconColor", AV34TFTileIconColor);
         AV35TFTileIconColor_Sel = "";
         AssignAttri("", false, "AV35TFTileIconColor_Sel", AV35TFTileIconColor_Sel);
         AV36TFTileAction = "";
         AssignAttri("", false, "AV36TFTileAction", AV36TFTileAction);
         AV37TFTileAction_Sel = "";
         AssignAttri("", false, "AV37TFTileAction_Sel", AV37TFTileAction_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_Display )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_tileview.aspx"+UrlEncode(A407TileId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_tileview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV48IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A407TileId.ToString());
            CallWebObject(formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A407TileId.ToString());
            CallWebObject(formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV52Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV52Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV52Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILENAME") == 0 )
            {
               AV20TFTileName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFTileName", AV20TFTileName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILENAME_SEL") == 0 )
            {
               AV21TFTileName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFTileName_Sel", AV21TFTileName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR") == 0 )
            {
               AV22TFTileBGColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFTileBGColor", AV22TFTileBGColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR_SEL") == 0 )
            {
               AV23TFTileBGColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFTileBGColor_Sel", AV23TFTileBGColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL") == 0 )
            {
               AV24TFTileBGImageUrl = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFTileBGImageUrl", AV24TFTileBGImageUrl);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL_SEL") == 0 )
            {
               AV25TFTileBGImageUrl_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25TFTileBGImageUrl_Sel", AV25TFTileBGImageUrl_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR") == 0 )
            {
               AV26TFTileTextColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFTileTextColor", AV26TFTileTextColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR_SEL") == 0 )
            {
               AV27TFTileTextColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFTileTextColor_Sel", AV27TFTileTextColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTALIGNMENT_SEL") == 0 )
            {
               AV28TFTileTextAlignment_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFTileTextAlignment_SelsJson", AV28TFTileTextAlignment_SelsJson);
               AV29TFTileTextAlignment_Sels.FromJSonString(AV28TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICON") == 0 )
            {
               AV30TFTileIcon = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFTileIcon", AV30TFTileIcon);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICON_SEL") == 0 )
            {
               AV31TFTileIcon_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFTileIcon_Sel", AV31TFTileIcon_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICONALIGNMENT_SEL") == 0 )
            {
               AV32TFTileIconAlignment_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFTileIconAlignment_SelsJson", AV32TFTileIconAlignment_SelsJson);
               AV33TFTileIconAlignment_Sels.FromJSonString(AV32TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICONCOLOR") == 0 )
            {
               AV34TFTileIconColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFTileIconColor", AV34TFTileIconColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICONCOLOR_SEL") == 0 )
            {
               AV35TFTileIconColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFTileIconColor_Sel", AV35TFTileIconColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEACTION") == 0 )
            {
               AV36TFTileAction = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFTileAction", AV36TFTileAction);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEACTION_SEL") == 0 )
            {
               AV37TFTileAction_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFTileAction_Sel", AV37TFTileAction_Sel);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTileName_Sel)),  AV21TFTileName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFTileBGColor_Sel)),  AV23TFTileBGColor_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFTileBGImageUrl_Sel)),  AV25TFTileBGImageUrl_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFTileTextColor_Sel)),  AV27TFTileTextColor_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV29TFTileTextAlignment_Sels.Count==0),  AV28TFTileTextAlignment_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFTileIcon_Sel)),  AV31TFTileIcon_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV33TFTileIconAlignment_Sels.Count==0),  AV32TFTileIconAlignment_SelsJson, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTileIconColor_Sel)),  AV35TFTileIconColor_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTileAction_Sel)),  AV37TFTileAction_Sel, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTileName)),  AV20TFTileName, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTileBGColor)),  AV22TFTileBGColor, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTileBGImageUrl)),  AV24TFTileBGImageUrl, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTileTextColor)),  AV26TFTileTextColor, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFTileIcon)),  AV30TFTileIcon, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTileIconColor)),  AV34TFTileIconColor, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTileAction)),  AV36TFTileAction, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"||"+GXt_char8+"||"+GXt_char7+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV52Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILENAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFTileName)),  0,  AV20TFTileName,  AV20TFTileName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTileName_Sel)),  AV21TFTileName_Sel,  AV21TFTileName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEBGCOLOR",  context.GetMessage( "BGColor", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTileBGColor)),  0,  AV22TFTileBGColor,  AV22TFTileBGColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFTileBGColor_Sel)),  AV23TFTileBGColor_Sel,  AV23TFTileBGColor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEBGIMAGEURL",  context.GetMessage( "BGImage Url", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTileBGImageUrl)),  0,  AV24TFTileBGImageUrl,  AV24TFTileBGImageUrl,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFTileBGImageUrl_Sel)),  AV25TFTileBGImageUrl_Sel,  AV25TFTileBGImageUrl_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILETEXTCOLOR",  context.GetMessage( "Text Color", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTileTextColor)),  0,  AV26TFTileTextColor,  AV26TFTileTextColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFTileTextColor_Sel)),  AV27TFTileTextColor_Sel,  AV27TFTileTextColor_Sel) ;
         AV51AuxText = ((AV29TFTileTextAlignment_Sels.Count==1) ? "["+AV29TFTileTextAlignment_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTILETEXTALIGNMENT_SEL",  context.GetMessage( "Text Alignment", ""),  !(AV29TFTileTextAlignment_Sels.Count==0),  0,  AV29TFTileTextAlignment_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV51AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV51AuxText, "[center]", context.GetMessage( "center", "")), "[left]", context.GetMessage( "left", "")), "[right]", context.GetMessage( "right", ""))),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEICON",  context.GetMessage( "Icon", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFTileIcon)),  0,  AV30TFTileIcon,  AV30TFTileIcon,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFTileIcon_Sel)),  AV31TFTileIcon_Sel,  AV31TFTileIcon_Sel) ;
         AV51AuxText = ((AV33TFTileIconAlignment_Sels.Count==1) ? "["+AV33TFTileIconAlignment_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTILEICONALIGNMENT_SEL",  context.GetMessage( "Icon Alignment", ""),  !(AV33TFTileIconAlignment_Sels.Count==0),  0,  AV33TFTileIconAlignment_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV51AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV51AuxText, "[center]", context.GetMessage( "center", "")), "[left]", context.GetMessage( "left", "")), "[right]", context.GetMessage( "right", ""))),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEICONCOLOR",  context.GetMessage( "Icon Color", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTileIconColor)),  0,  AV34TFTileIconColor,  AV34TFTileIconColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTileIconColor_Sel)),  AV35TFTileIconColor_Sel,  AV35TFTileIconColor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEACTION",  context.GetMessage( "Action", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTileAction)),  0,  AV36TFTileAction,  AV36TFTileAction,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTileAction_Sel)),  AV37TFTileAction_Sel,  AV37TFTileAction_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV52Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Tile";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA842( ) ;
         WS842( ) ;
         WE842( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024119613759", true, true);
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
         context.AddJavascriptSource("trn_tileww.js", "?2024119613760", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtTileId_Internalname = "TILEID_"+sGXsfl_37_idx;
         edtTileName_Internalname = "TILENAME_"+sGXsfl_37_idx;
         edtTileBGColor_Internalname = "TILEBGCOLOR_"+sGXsfl_37_idx;
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL_"+sGXsfl_37_idx;
         edtTileTextColor_Internalname = "TILETEXTCOLOR_"+sGXsfl_37_idx;
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT_"+sGXsfl_37_idx;
         edtTileIcon_Internalname = "TILEICON_"+sGXsfl_37_idx;
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT_"+sGXsfl_37_idx;
         edtTileIconColor_Internalname = "TILEICONCOLOR_"+sGXsfl_37_idx;
         edtTileAction_Internalname = "TILEACTION_"+sGXsfl_37_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtTileId_Internalname = "TILEID_"+sGXsfl_37_fel_idx;
         edtTileName_Internalname = "TILENAME_"+sGXsfl_37_fel_idx;
         edtTileBGColor_Internalname = "TILEBGCOLOR_"+sGXsfl_37_fel_idx;
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL_"+sGXsfl_37_fel_idx;
         edtTileTextColor_Internalname = "TILETEXTCOLOR_"+sGXsfl_37_fel_idx;
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT_"+sGXsfl_37_fel_idx;
         edtTileIcon_Internalname = "TILEICON_"+sGXsfl_37_fel_idx;
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT_"+sGXsfl_37_fel_idx;
         edtTileIconColor_Internalname = "TILEICONCOLOR_"+sGXsfl_37_fel_idx;
         edtTileAction_Internalname = "TILEACTION_"+sGXsfl_37_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB840( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileId_Internalname,A407TileId.ToString(),A407TileId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileName_Internalname,(string)A400TileName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTileName_Link,(string)"",(string)"",(string)"",(string)edtTileName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileBGColor_Internalname,StringUtil.RTrim( A402TileBGColor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileBGColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileBGImageUrl_Internalname,(string)A403TileBGImageUrl,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTileBGImageUrl_Link,(string)edtTileBGImageUrl_Linktarget,(string)"",(string)"",(string)edtTileBGImageUrl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileTextColor_Internalname,StringUtil.RTrim( A404TileTextColor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileTextColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTileTextAlignment.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TILETEXTALIGNMENT_" + sGXsfl_37_idx;
               cmbTileTextAlignment.Name = GXCCtl;
               cmbTileTextAlignment.WebTags = "";
               cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
               cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
               cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
               if ( cmbTileTextAlignment.ItemCount > 0 )
               {
                  A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTileTextAlignment,(string)cmbTileTextAlignment_Internalname,StringUtil.RTrim( A405TileTextAlignment),(short)1,(string)cmbTileTextAlignment_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
            AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", (string)(cmbTileTextAlignment.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileIcon_Internalname,StringUtil.RTrim( A401TileIcon),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileIcon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTileIconAlignment.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TILEICONALIGNMENT_" + sGXsfl_37_idx;
               cmbTileIconAlignment.Name = GXCCtl;
               cmbTileIconAlignment.WebTags = "";
               cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
               cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
               cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
               if ( cmbTileIconAlignment.ItemCount > 0 )
               {
                  A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTileIconAlignment,(string)cmbTileIconAlignment_Internalname,StringUtil.RTrim( A406TileIconAlignment),(short)1,(string)cmbTileIconAlignment_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
            AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", (string)(cmbTileIconAlignment.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileIconColor_Internalname,StringUtil.RTrim( A438TileIconColor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileIconColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileAction_Internalname,(string)A436TileAction,(string)A436TileAction,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)37,(short)0,(short)0,(short)-1,(bool)true,(string)"LongDescription",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV46ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV46ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes842( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "TILETEXTALIGNMENT_" + sGXsfl_37_idx;
         cmbTileTextAlignment.Name = GXCCtl;
         cmbTileTextAlignment.WebTags = "";
         cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
         }
         GXCCtl = "TILEICONALIGNMENT_" + sGXsfl_37_idx;
         cmbTileIconAlignment.Name = GXCCtl;
         cmbTileIconAlignment.WebTags = "";
         cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
         }
         GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV46ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV46ActionGroup), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BGColor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BGImage Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Text Color", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Text Alignment", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icon", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icon Alignment", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icon Color", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A407TileId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A400TileName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTileName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A402TileBGColor)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A403TileBGImageUrl));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTileBGImageUrl_Link));
            GridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtTileBGImageUrl_Linktarget));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A404TileTextColor)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A405TileTextAlignment)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A401TileIcon)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A406TileIconAlignment)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A438TileIconColor)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A436TileAction));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46ActionGroup), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavActiongroup_Class));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtTileId_Internalname = "TILEID";
         edtTileName_Internalname = "TILENAME";
         edtTileBGColor_Internalname = "TILEBGCOLOR";
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL";
         edtTileTextColor_Internalname = "TILETEXTCOLOR";
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT";
         edtTileIcon_Internalname = "TILEICON";
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT";
         edtTileIconColor_Internalname = "TILEICONCOLOR";
         edtTileAction_Internalname = "TILEACTION";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         cmbavActiongroup_Class = "ConvertToDDO";
         edtTileAction_Jsonclick = "";
         edtTileIconColor_Jsonclick = "";
         cmbTileIconAlignment_Jsonclick = "";
         edtTileIcon_Jsonclick = "";
         cmbTileTextAlignment_Jsonclick = "";
         edtTileTextColor_Jsonclick = "";
         edtTileBGImageUrl_Jsonclick = "";
         edtTileBGImageUrl_Linktarget = "";
         edtTileBGImageUrl_Link = "";
         edtTileBGColor_Jsonclick = "";
         edtTileName_Jsonclick = "";
         edtTileName_Link = "";
         edtTileId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtTileAction_Enabled = 0;
         edtTileIconColor_Enabled = 0;
         cmbTileIconAlignment.Enabled = 0;
         edtTileIcon_Enabled = 0;
         cmbTileTextAlignment.Enabled = 0;
         edtTileTextColor_Enabled = 0;
         edtTileBGImageUrl_Enabled = 0;
         edtTileBGColor_Enabled = 0;
         edtTileName_Enabled = 0;
         edtTileId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_TileWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||center:center,left:left,right:right||center:center,left:left,right:right||";
         Ddo_grid_Allowmultipleselection = "|||||T||T||";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic|FixedValues|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T|T|T|T|T|T";
         Ddo_grid_Filtertype = "|Character|Character|Character|Character||Character||Character|Character";
         Ddo_grid_Includefilter = "|T|T|T|T||T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "0:TileId|1:TileName|2:TileBGColor|3:TileBGImageUrl|4:TileTextColor|5:TileTextAlignment|6:TileIcon|7:TileIconAlignment|8:TileIconColor|9:TileAction";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Tile", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV42GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV43GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV44GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12842","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13842","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15842","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV32TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV28TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E19842","iparms":[{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"A407TileId","fld":"TILEID","hsh":true},{"av":"A403TileBGImageUrl","fld":"TILEBGIMAGEURL"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV46ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtTileName_Link","ctrl":"TILENAME","prop":"Link"},{"av":"edtTileBGImageUrl_Linktarget","ctrl":"TILEBGIMAGEURL","prop":"Linktarget"},{"av":"edtTileBGImageUrl_Link","ctrl":"TILEBGIMAGEURL","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11842","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV28TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV32TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV32TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"},{"av":"AV28TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV42GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV43GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV44GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E20842","iparms":[{"av":"cmbavActiongroup"},{"av":"AV46ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A407TileId","fld":"TILEID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV46ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV42GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV43GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV44GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E16842","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFTileName","fld":"vTFTILENAME"},{"av":"AV21TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV22TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV23TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV24TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV25TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV26TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV27TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV29TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV30TFTileIcon","fld":"vTFTILEICON"},{"av":"AV31TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV33TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV34TFTileIconColor","fld":"vTFTILEICONCOLOR"},{"av":"AV35TFTileIconColor_Sel","fld":"vTFTILEICONCOLOR_SEL"},{"av":"AV36TFTileAction","fld":"vTFTILEACTION"},{"av":"AV37TFTileAction_Sel","fld":"vTFTILEACTION_SEL"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV45IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A407TileId","fld":"TILEID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV42GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV43GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV44GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14842","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_TILENAME","""{"handler":"Valid_Tilename","iparms":[]}""");
         setEventMetadata("VALID_TILEBGCOLOR","""{"handler":"Valid_Tilebgcolor","iparms":[]}""");
         setEventMetadata("VALID_TILEBGIMAGEURL","""{"handler":"Valid_Tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTCOLOR","""{"handler":"Valid_Tiletextcolor","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTALIGNMENT","""{"handler":"Valid_Tiletextalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEICON","""{"handler":"Valid_Tileicon","iparms":[]}""");
         setEventMetadata("VALID_TILEICONALIGNMENT","""{"handler":"Valid_Tileiconalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEICONCOLOR","""{"handler":"Valid_Tileiconcolor","iparms":[]}""");
         setEventMetadata("VALID_TILEACTION","""{"handler":"Valid_Tileaction","iparms":[]}""");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV52Pgmname = "";
         AV15FilterFullText = "";
         AV20TFTileName = "";
         AV21TFTileName_Sel = "";
         AV22TFTileBGColor = "";
         AV23TFTileBGColor_Sel = "";
         AV24TFTileBGImageUrl = "";
         AV25TFTileBGImageUrl_Sel = "";
         AV26TFTileTextColor = "";
         AV27TFTileTextColor_Sel = "";
         AV29TFTileTextAlignment_Sels = new GxSimpleCollection<string>();
         AV30TFTileIcon = "";
         AV31TFTileIcon_Sel = "";
         AV33TFTileIconAlignment_Sels = new GxSimpleCollection<string>();
         AV34TFTileIconColor = "";
         AV35TFTileIconColor_Sel = "";
         AV36TFTileAction = "";
         AV37TFTileAction_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV44GridAppliedFilters = "";
         AV38DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28TFTileTextAlignment_SelsJson = "";
         AV32TFTileIconAlignment_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A407TileId = Guid.Empty;
         A400TileName = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A401TileIcon = "";
         A406TileIconAlignment = "";
         A438TileIconColor = "";
         A436TileAction = "";
         AV53Trn_tilewwds_1_filterfulltext = "";
         AV54Trn_tilewwds_2_tftilename = "";
         AV55Trn_tilewwds_3_tftilename_sel = "";
         AV56Trn_tilewwds_4_tftilebgcolor = "";
         AV57Trn_tilewwds_5_tftilebgcolor_sel = "";
         AV58Trn_tilewwds_6_tftilebgimageurl = "";
         AV59Trn_tilewwds_7_tftilebgimageurl_sel = "";
         AV60Trn_tilewwds_8_tftiletextcolor = "";
         AV61Trn_tilewwds_9_tftiletextcolor_sel = "";
         AV62Trn_tilewwds_10_tftiletextalignment_sels = new GxSimpleCollection<string>();
         AV63Trn_tilewwds_11_tftileicon = "";
         AV64Trn_tilewwds_12_tftileicon_sel = "";
         AV65Trn_tilewwds_13_tftileiconalignment_sels = new GxSimpleCollection<string>();
         AV66Trn_tilewwds_14_tftileiconcolor = "";
         AV67Trn_tilewwds_15_tftileiconcolor_sel = "";
         AV68Trn_tilewwds_16_tftileaction = "";
         AV69Trn_tilewwds_17_tftileaction_sel = "";
         lV53Trn_tilewwds_1_filterfulltext = "";
         lV54Trn_tilewwds_2_tftilename = "";
         lV56Trn_tilewwds_4_tftilebgcolor = "";
         lV58Trn_tilewwds_6_tftilebgimageurl = "";
         lV60Trn_tilewwds_8_tftiletextcolor = "";
         lV63Trn_tilewwds_11_tftileicon = "";
         lV66Trn_tilewwds_14_tftileiconcolor = "";
         lV68Trn_tilewwds_16_tftileaction = "";
         H00842_A436TileAction = new string[] {""} ;
         H00842_A438TileIconColor = new string[] {""} ;
         H00842_A406TileIconAlignment = new string[] {""} ;
         H00842_A401TileIcon = new string[] {""} ;
         H00842_n401TileIcon = new bool[] {false} ;
         H00842_A405TileTextAlignment = new string[] {""} ;
         H00842_A404TileTextColor = new string[] {""} ;
         H00842_A403TileBGImageUrl = new string[] {""} ;
         H00842_n403TileBGImageUrl = new bool[] {false} ;
         H00842_A402TileBGColor = new string[] {""} ;
         H00842_n402TileBGColor = new bool[] {false} ;
         H00842_A400TileName = new string[] {""} ;
         H00842_A407TileId = new Guid[] {Guid.Empty} ;
         H00843_A436TileAction = new string[] {""} ;
         H00843_A438TileIconColor = new string[] {""} ;
         H00843_A406TileIconAlignment = new string[] {""} ;
         H00843_A401TileIcon = new string[] {""} ;
         H00843_n401TileIcon = new bool[] {false} ;
         H00843_A405TileTextAlignment = new string[] {""} ;
         H00843_A404TileTextColor = new string[] {""} ;
         H00843_A403TileBGImageUrl = new string[] {""} ;
         H00843_n403TileBGImageUrl = new bool[] {false} ;
         H00843_A402TileBGColor = new string[] {""} ;
         H00843_n402TileBGColor = new bool[] {false} ;
         H00843_A400TileName = new string[] {""} ;
         H00843_A407TileId = new Guid[] {Guid.Empty} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV39GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV40GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV51AuxText = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileww__default(),
            new Object[][] {
                new Object[] {
               H00842_A436TileAction, H00842_A438TileIconColor, H00842_A406TileIconAlignment, H00842_A401TileIcon, H00842_n401TileIcon, H00842_A405TileTextAlignment, H00842_A404TileTextColor, H00842_A403TileBGImageUrl, H00842_n403TileBGImageUrl, H00842_A402TileBGColor,
               H00842_n402TileBGColor, H00842_A400TileName, H00842_A407TileId
               }
               , new Object[] {
               H00843_A436TileAction, H00843_A438TileIconColor, H00843_A406TileIconAlignment, H00843_A401TileIcon, H00843_n401TileIcon, H00843_A405TileTextAlignment, H00843_A404TileTextColor, H00843_A403TileBGImageUrl, H00843_n403TileBGImageUrl, H00843_A402TileBGColor,
               H00843_n402TileBGColor, H00843_A400TileName, H00843_A407TileId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV52Pgmname = "Trn_TileWW";
         /* GeneXus formulas. */
         AV52Pgmname = "Trn_TileWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV46ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int AV62Trn_tilewwds_10_tftiletextalignment_sels_Count ;
      private int AV65Trn_tilewwds_13_tftileiconalignment_sels_Count ;
      private int edtTileId_Enabled ;
      private int edtTileName_Enabled ;
      private int edtTileBGColor_Enabled ;
      private int edtTileBGImageUrl_Enabled ;
      private int edtTileTextColor_Enabled ;
      private int edtTileIcon_Enabled ;
      private int edtTileIconColor_Enabled ;
      private int edtTileAction_Enabled ;
      private int AV41PageToGo ;
      private int AV70GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV42GridCurrentPage ;
      private long AV43GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV52Pgmname ;
      private string AV22TFTileBGColor ;
      private string AV23TFTileBGColor_Sel ;
      private string AV26TFTileTextColor ;
      private string AV27TFTileTextColor_Sel ;
      private string AV30TFTileIcon ;
      private string AV31TFTileIcon_Sel ;
      private string AV34TFTileIconColor ;
      private string AV35TFTileIconColor_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
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
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTileId_Internalname ;
      private string edtTileName_Internalname ;
      private string A402TileBGColor ;
      private string edtTileBGColor_Internalname ;
      private string edtTileBGImageUrl_Internalname ;
      private string A404TileTextColor ;
      private string edtTileTextColor_Internalname ;
      private string cmbTileTextAlignment_Internalname ;
      private string A405TileTextAlignment ;
      private string A401TileIcon ;
      private string edtTileIcon_Internalname ;
      private string cmbTileIconAlignment_Internalname ;
      private string A406TileIconAlignment ;
      private string A438TileIconColor ;
      private string edtTileIconColor_Internalname ;
      private string edtTileAction_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string AV56Trn_tilewwds_4_tftilebgcolor ;
      private string AV57Trn_tilewwds_5_tftilebgcolor_sel ;
      private string AV60Trn_tilewwds_8_tftiletextcolor ;
      private string AV61Trn_tilewwds_9_tftiletextcolor_sel ;
      private string AV63Trn_tilewwds_11_tftileicon ;
      private string AV64Trn_tilewwds_12_tftileicon_sel ;
      private string AV66Trn_tilewwds_14_tftileiconcolor ;
      private string AV67Trn_tilewwds_15_tftileiconcolor_sel ;
      private string lV56Trn_tilewwds_4_tftilebgcolor ;
      private string lV60Trn_tilewwds_8_tftiletextcolor ;
      private string lV63Trn_tilewwds_11_tftileicon ;
      private string lV66Trn_tilewwds_14_tftileiconcolor ;
      private string cmbavActiongroup_Class ;
      private string edtTileName_Link ;
      private string GXEncryptionTmp ;
      private string edtTileBGImageUrl_Linktarget ;
      private string edtTileBGImageUrl_Link ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtTileId_Jsonclick ;
      private string edtTileName_Jsonclick ;
      private string edtTileBGColor_Jsonclick ;
      private string edtTileBGImageUrl_Jsonclick ;
      private string edtTileTextColor_Jsonclick ;
      private string GXCCtl ;
      private string cmbTileTextAlignment_Jsonclick ;
      private string edtTileIcon_Jsonclick ;
      private string cmbTileIconAlignment_Jsonclick ;
      private string edtTileIconColor_Jsonclick ;
      private string edtTileAction_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV47IsAuthorized_Display ;
      private bool AV48IsAuthorized_Update ;
      private bool AV49IsAuthorized_Delete ;
      private bool AV45IsAuthorized_TileName ;
      private bool AV50IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n401TileIcon ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV28TFTileTextAlignment_SelsJson ;
      private string AV32TFTileIconAlignment_SelsJson ;
      private string A436TileAction ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV20TFTileName ;
      private string AV21TFTileName_Sel ;
      private string AV24TFTileBGImageUrl ;
      private string AV25TFTileBGImageUrl_Sel ;
      private string AV36TFTileAction ;
      private string AV37TFTileAction_Sel ;
      private string AV44GridAppliedFilters ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string AV53Trn_tilewwds_1_filterfulltext ;
      private string AV54Trn_tilewwds_2_tftilename ;
      private string AV55Trn_tilewwds_3_tftilename_sel ;
      private string AV58Trn_tilewwds_6_tftilebgimageurl ;
      private string AV59Trn_tilewwds_7_tftilebgimageurl_sel ;
      private string AV68Trn_tilewwds_16_tftileaction ;
      private string AV69Trn_tilewwds_17_tftileaction_sel ;
      private string lV53Trn_tilewwds_1_filterfulltext ;
      private string lV54Trn_tilewwds_2_tftilename ;
      private string lV58Trn_tilewwds_6_tftilebgimageurl ;
      private string lV68Trn_tilewwds_16_tftileaction ;
      private string AV51AuxText ;
      private Guid A407TileId ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTileTextAlignment ;
      private GXCombobox cmbTileIconAlignment ;
      private GXCombobox cmbavActiongroup ;
      private GxSimpleCollection<string> AV29TFTileTextAlignment_Sels ;
      private GxSimpleCollection<string> AV33TFTileIconAlignment_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV38DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV62Trn_tilewwds_10_tftiletextalignment_sels ;
      private GxSimpleCollection<string> AV65Trn_tilewwds_13_tftileiconalignment_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00842_A436TileAction ;
      private string[] H00842_A438TileIconColor ;
      private string[] H00842_A406TileIconAlignment ;
      private string[] H00842_A401TileIcon ;
      private bool[] H00842_n401TileIcon ;
      private string[] H00842_A405TileTextAlignment ;
      private string[] H00842_A404TileTextColor ;
      private string[] H00842_A403TileBGImageUrl ;
      private bool[] H00842_n403TileBGImageUrl ;
      private string[] H00842_A402TileBGColor ;
      private bool[] H00842_n402TileBGColor ;
      private string[] H00842_A400TileName ;
      private Guid[] H00842_A407TileId ;
      private string[] H00843_A436TileAction ;
      private string[] H00843_A438TileIconColor ;
      private string[] H00843_A406TileIconAlignment ;
      private string[] H00843_A401TileIcon ;
      private bool[] H00843_n401TileIcon ;
      private string[] H00843_A405TileTextAlignment ;
      private string[] H00843_A404TileTextColor ;
      private string[] H00843_A403TileBGImageUrl ;
      private bool[] H00843_n403TileBGImageUrl ;
      private string[] H00843_A402TileBGColor ;
      private bool[] H00843_n402TileBGColor ;
      private string[] H00843_A400TileName ;
      private Guid[] H00843_A407TileId ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV39GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV40GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_tileww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00842( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV62Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV65Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV55Trn_tilewwds_3_tftilename_sel ,
                                             string AV54Trn_tilewwds_2_tftilename ,
                                             string AV57Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV56Trn_tilewwds_4_tftilebgcolor ,
                                             string AV59Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV58Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV61Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV60Trn_tilewwds_8_tftiletextcolor ,
                                             int AV62Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV64Trn_tilewwds_12_tftileicon_sel ,
                                             string AV63Trn_tilewwds_11_tftileicon ,
                                             int AV65Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV67Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV66Trn_tilewwds_14_tftileiconcolor ,
                                             string AV69Trn_tilewwds_17_tftileaction_sel ,
                                             string AV68Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV53Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[14];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV54Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV55Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV55Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV56Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV57Trn_tilewwds_5_tftilebgcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV57Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Trn_tilewwds_5_tftilebgcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV58Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV59Trn_tilewwds_7_tftilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV59Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_tilewwds_7_tftilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV60Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV61Trn_tilewwds_9_tftiletextcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV61Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_tilewwds_9_tftiletextcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV62Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV62Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV63Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV64Trn_tilewwds_12_tftileicon_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV64Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_tilewwds_12_tftileicon_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV65Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV66Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV67Trn_tilewwds_15_tftileiconcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV67Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_tilewwds_15_tftileiconcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV68Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV69Trn_tilewwds_17_tftileaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV69Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_tilewwds_17_tftileaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileName, TileId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileName DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileBGColor, TileId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileBGColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileBGImageUrl, TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileBGImageUrl DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileTextColor, TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileTextColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileTextAlignment, TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileTextAlignment DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIcon, TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIcon DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIconAlignment, TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIconAlignment DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIconColor, TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIconColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileAction, TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileAction DESC, TileId";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H00843( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV62Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV65Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV55Trn_tilewwds_3_tftilename_sel ,
                                             string AV54Trn_tilewwds_2_tftilename ,
                                             string AV57Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV56Trn_tilewwds_4_tftilebgcolor ,
                                             string AV59Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV58Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV61Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV60Trn_tilewwds_8_tftiletextcolor ,
                                             int AV62Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV64Trn_tilewwds_12_tftileicon_sel ,
                                             string AV63Trn_tilewwds_11_tftileicon ,
                                             int AV65Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV67Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV66Trn_tilewwds_14_tftileiconcolor ,
                                             string AV69Trn_tilewwds_17_tftileaction_sel ,
                                             string AV68Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV53Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[14];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV54Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int15[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV55Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV55Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int15[1] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV56Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV57Trn_tilewwds_5_tftilebgcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV57Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int15[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Trn_tilewwds_5_tftilebgcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV58Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int15[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV59Trn_tilewwds_7_tftilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV59Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int15[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_tilewwds_7_tftilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV60Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV61Trn_tilewwds_9_tftiletextcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV61Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_tilewwds_9_tftiletextcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV62Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV62Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV63Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV64Trn_tilewwds_12_tftileicon_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV64Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_tilewwds_12_tftileicon_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV65Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV66Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV67Trn_tilewwds_15_tftileiconcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV67Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_tilewwds_15_tftileiconcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV68Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV69Trn_tilewwds_17_tftileaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV69Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_tilewwds_17_tftileaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileName, TileId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileName DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileBGColor, TileId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileBGColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileBGImageUrl, TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileBGImageUrl DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileTextColor, TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileTextColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileTextAlignment, TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileTextAlignment DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIcon, TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIcon DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIconAlignment, TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIconAlignment DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileIconColor, TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileIconColor DESC, TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY TileAction, TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TileAction DESC, TileId";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00842(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
               case 1 :
                     return conditional_H00843(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00842;
          prmH00842 = new Object[] {
          new ParDef("lV54Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV57Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV58Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV59Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV60Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV61Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV63Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV64Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV66Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV67Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV68Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV69Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmH00843;
          prmH00843 = new Object[] {
          new ParDef("lV54Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV57Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV58Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV59Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV60Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV61Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV63Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV64Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV66Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV67Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV68Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV69Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00842", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00842,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00843,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
