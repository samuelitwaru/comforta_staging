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
   public class uformww : GXDataArea
   {
      public uformww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uformww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations )
      {
         this.AV5WWPFormType = aP0_WWPFormType;
         this.AV87WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridactiongroup1 = new GXCombobox();
         cmbWWPFormType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormType");
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
               gxfirstwebparm = GetFirstPar( "WWPFormType");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormType");
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
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
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
         AV33OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV35OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7ColumnsSelector);
         AV97Pgmname = GetPar( "Pgmname");
         AV5WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         AV14FilterFullText = GetPar( "FilterFullText");
         AV45TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV46TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         AV43TFWWPFormReferenceName = GetPar( "TFWWPFormReferenceName");
         AV44TFWWPFormReferenceName_Sel = GetPar( "TFWWPFormReferenceName_Sel");
         AV39TFWWPFormDate = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate"));
         AV40TFWWPFormDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate_To"));
         AV81TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV82TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV41TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV42TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV87WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV60IsAuthorized_UUpdate = StringUtil.StrToBool( GetPar( "IsAuthorized_UUpdate"));
         AV90IsAuthorized_UDelete = StringUtil.StrToBool( GetPar( "IsAuthorized_UDelete"));
         AV55FilledOutForms = (short)(Math.Round(NumberUtil.Val( GetPar( "FilledOutForms"), "."), 18, MidpointRounding.ToEven));
         AV25IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV91IsAuthorized_ExportForm = StringUtil.StrToBool( GetPar( "IsAuthorized_ExportForm"));
         AV92IsAuthorized_FillOutAForm = StringUtil.StrToBool( GetPar( "IsAuthorized_FillOutAForm"));
         AV58IsAuthorized_FilledOutForms = StringUtil.StrToBool( GetPar( "IsAuthorized_FilledOutForms"));
         AV93IsAuthorized_Copy = StringUtil.StrToBool( GetPar( "IsAuthorized_Copy"));
         AV95IsAuthorized_UCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UCopyToLocation"));
         AV96IsAuthorized_UDirectCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UDirectCopyToLocation"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56GeneralDynamicFormids);
         AV85WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         AV62LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         AV64OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         AV59IsAuthorized_UInsert = StringUtil.StrToBool( GetPar( "IsAuthorized_UInsert"));
         AV26IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV94IsAuthorized_ImportForm = StringUtil.StrToBool( GetPar( "IsAuthorized_ImportForm"));
         cmbWWPFormType.FromJSonString( GetNextPar( ));
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
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
            return "uformww_Execute" ;
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
         PAA02( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA02( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "uformww.aspx"+UrlEncode(StringUtil.LTrimStr(AV5WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV87WWPFormIsForDynamicValidations));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("uformww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UUPDATE", AV60IsAuthorized_UUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UUPDATE", GetSecureSignedToken( "", AV60IsAuthorized_UUpdate, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDELETE", AV90IsAuthorized_UDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDELETE", GetSecureSignedToken( "", AV90IsAuthorized_UDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV25IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV25IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_EXPORTFORM", AV91IsAuthorized_ExportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXPORTFORM", GetSecureSignedToken( "", AV91IsAuthorized_ExportForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLOUTAFORM", AV92IsAuthorized_FillOutAForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLOUTAFORM", GetSecureSignedToken( "", AV92IsAuthorized_FillOutAForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV58IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV58IsAuthorized_FilledOutForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COPY", AV93IsAuthorized_Copy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COPY", GetSecureSignedToken( "", AV93IsAuthorized_Copy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UCOPYTOLOCATION", AV95IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( "", AV95IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV96IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( "", AV96IsAuthorized_UDirectCopyToLocation, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV62LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV62LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UINSERT", AV59IsAuthorized_UInsert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UINSERT", GetSecureSignedToken( "", AV59IsAuthorized_UInsert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV26IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV26IsAuthorized_Insert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_IMPORTFORM", AV94IsAuthorized_ImportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_IMPORTFORM", GetSecureSignedToken( "", AV94IsAuthorized_ImportForm, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5WWPFormType), "9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV87WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV87WWPFormIsForDynamicValidations, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"UFormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("uformww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV35OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV17GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV10DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV10DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV7ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV7ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATE", context.localUtil.DToC( AV11DDO_WWPFormDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATETO", context.localUtil.DToC( AV13DDO_WWPFormDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE", AV45TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE_SEL", AV46TFWWPFormTitle_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME", AV43TFWWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME_SEL", AV44TFWWPFormReferenceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE", context.localUtil.TToC( AV39TFWWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE_TO", context.localUtil.TToC( AV40TFWWPFormDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81TFWWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMLATESTVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV35OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV87WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV87WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UUPDATE", AV60IsAuthorized_UUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UUPDATE", GetSecureSignedToken( "", AV60IsAuthorized_UUpdate, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDELETE", AV90IsAuthorized_UDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDELETE", GetSecureSignedToken( "", AV90IsAuthorized_UDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV25IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV25IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_EXPORTFORM", AV91IsAuthorized_ExportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXPORTFORM", GetSecureSignedToken( "", AV91IsAuthorized_ExportForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLOUTAFORM", AV92IsAuthorized_FillOutAForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLOUTAFORM", GetSecureSignedToken( "", AV92IsAuthorized_FillOutAForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV58IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV58IsAuthorized_FilledOutForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COPY", AV93IsAuthorized_Copy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COPY", GetSecureSignedToken( "", AV93IsAuthorized_Copy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UCOPYTOLOCATION", AV95IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( "", AV95IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV96IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( "", AV96IsAuthorized_UDirectCopyToLocation, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85WWPFormId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV20GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV20GridState);
         }
         GxWebStd.gx_hidden_field( context, "vRESULTMSG", AV65ResultMsg);
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV62LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV62LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86WWPFormId_Selected), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89WWPFormVersionNumber_Selected), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UINSERT", AV59IsAuthorized_UInsert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UINSERT", GetSecureSignedToken( "", AV59IsAuthorized_UInsert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV26IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV26IsAuthorized_Insert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_IMPORTFORM", AV94IsAuthorized_ImportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_IMPORTFORM", GetSecureSignedToken( "", AV94IsAuthorized_ImportForm, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Width", StringUtil.RTrim( Ucopytolocation_modal_Width));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Title", StringUtil.RTrim( Ucopytolocation_modal_Title));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Confirmtype", StringUtil.RTrim( Ucopytolocation_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Bodytype", StringUtil.RTrim( Ucopytolocation_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Width", StringUtil.RTrim( Importform_modal_Width));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Title", StringUtil.RTrim( Importform_modal_Title));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Confirmtype", StringUtil.RTrim( Importform_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Bodytype", StringUtil.RTrim( Importform_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Result", StringUtil.RTrim( Ucopytolocation_modal_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "UCOPYTOLOCATION_MODAL_Result", StringUtil.RTrim( Ucopytolocation_modal_Result));
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
            WEA02( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA02( ) ;
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
         GXEncryptionTmp = "uformww.aspx"+UrlEncode(StringUtil.LTrimStr(AV5WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV87WWPFormIsForDynamicValidations));
         return formatLink("uformww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "UFormWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " UForm", "") ;
      }

      protected void WBA00( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuinsert_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtnuinsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UFormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor hidden-xs hidden-sm hidden-md hidden-lg";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UFormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_UFormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnimportform_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", context.GetMessage( "WWP_DF_ImportForm", ""), bttBtnimportform_Jsonclick, 5, context.GetMessage( "WWP_DF_ImportForm", ""), "", StyleString, ClassString, bttBtnimportform_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOIMPORTFORM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UFormWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV28ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_UFormWW.htm");
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
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV18GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV19GridPageCount);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV10DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_UFormWW.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV10DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV7ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_59_A02( true) ;
         }
         else
         {
            wb_table1_59_A02( false) ;
         }
         return  ;
      }

      protected void wb_table1_59_A02e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_64_A02( true) ;
         }
         else
         {
            wb_table2_64_A02( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_A02e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_69_A02( true) ;
         }
         else
         {
            wb_table3_69_A02( false) ;
         }
         return  ;
      }

      protected void wb_table3_69_A02e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0076"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0076"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_41_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0076"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_wwpformdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpformdateauxdatetext_Internalname, AV12DDO_WWPFormDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV12DDO_WWPFormDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpformdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_UFormWW.htm");
            /* User Defined Control */
            ucTfwwpformdate_rangepicker.SetProperty("Start Date", AV11DDO_WWPFormDateAuxDate);
            ucTfwwpformdate_rangepicker.SetProperty("End Date", AV13DDO_WWPFormDateAuxDateTo);
            ucTfwwpformdate_rangepicker.Render(context, "wwp.daterangepicker", Tfwwpformdate_rangepicker_Internalname, "TFWWPFORMDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 41 )
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

      protected void STARTA02( )
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
         Form.Meta.addItem("description", context.GetMessage( " UForm", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA00( ) ;
      }

      protected void WSA02( )
      {
         STARTA02( ) ;
         EVTA02( ) ;
      }

      protected void EVTA02( )
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
                              E11A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E15A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_udelete.Close */
                              E16A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UCOPYTOLOCATION_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ucopytolocation_modal.Close */
                              E17A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ucopytolocation_modal.Onloadcomponent */
                              E18A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Close */
                              E19A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Onloadcomponent */
                              E20A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUInsert' */
                              E21A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E22A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOIMPORTFORM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoImportForm' */
                              E23A02 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname), 0);
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILLEDOUTFORMS");
                                 GX_FocusControl = edtavFilledoutforms_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV55FilledOutForms = 0;
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
                              }
                              else
                              {
                                 AV55FilledOutForms = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
                              }
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV57GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActionGroup1), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E26A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV33OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV35OrderedDsc )
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
                        if ( nCmpId == 76 )
                        {
                           OldWwpaux_wc = cgiGet( "W0076");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0076", "", sEvt);
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

      protected void WEA02( )
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

      protected void PAA02( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "uformww.aspx")), "uformww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "uformww.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5WWPFormType = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5WWPFormType", StringUtil.Str( (decimal)(AV5WWPFormType), 1, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5WWPFormType), "9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV87WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                        AssignAttri("", false, "AV87WWPFormIsForDynamicValidations", AV87WWPFormIsForDynamicValidations);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV87WWPFormIsForDynamicValidations, context));
                     }
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
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV33OrderedBy ,
                                       bool AV35OrderedDsc ,
                                       short AV29ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV7ColumnsSelector ,
                                       string AV97Pgmname ,
                                       short AV5WWPFormType ,
                                       string AV14FilterFullText ,
                                       string AV45TFWWPFormTitle ,
                                       string AV46TFWWPFormTitle_Sel ,
                                       string AV43TFWWPFormReferenceName ,
                                       string AV44TFWWPFormReferenceName_Sel ,
                                       DateTime AV39TFWWPFormDate ,
                                       DateTime AV40TFWWPFormDate_To ,
                                       short AV81TFWWPFormVersionNumber ,
                                       short AV82TFWWPFormVersionNumber_To ,
                                       short AV41TFWWPFormLatestVersionNumber ,
                                       short AV42TFWWPFormLatestVersionNumber_To ,
                                       bool AV87WWPFormIsForDynamicValidations ,
                                       bool AV60IsAuthorized_UUpdate ,
                                       bool AV90IsAuthorized_UDelete ,
                                       short AV55FilledOutForms ,
                                       bool AV25IsAuthorized_Display ,
                                       bool AV91IsAuthorized_ExportForm ,
                                       bool AV92IsAuthorized_FillOutAForm ,
                                       bool AV58IsAuthorized_FilledOutForms ,
                                       bool AV93IsAuthorized_Copy ,
                                       bool AV95IsAuthorized_UCopyToLocation ,
                                       bool AV96IsAuthorized_UDirectCopyToLocation ,
                                       GxSimpleCollection<short> AV56GeneralDynamicFormids ,
                                       short AV85WWPFormId ,
                                       Guid AV62LocationId ,
                                       Guid AV64OrganisationId ,
                                       bool AV59IsAuthorized_UInsert ,
                                       bool AV26IsAuthorized_Insert ,
                                       bool AV94IsAuthorized_ImportForm ,
                                       short A240WWPFormType )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA02( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"UFormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("uformww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFILLEDOUTFORMS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55FilledOutForms), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMREFERENCENAME", A208WWPFormReferenceName);
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
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV97Pgmname = "UFormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      protected void RFA02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E25A02 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
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
            SubsflControlProps_412( ) ;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV101Uformwwds_4_tfwwpformtitle_sel ,
                                                 AV100Uformwwds_3_tfwwpformtitle ,
                                                 AV103Uformwwds_6_tfwwpformreferencename_sel ,
                                                 AV102Uformwwds_5_tfwwpformreferencename ,
                                                 AV104Uformwwds_7_tfwwpformdate ,
                                                 AV105Uformwwds_8_tfwwpformdate_to ,
                                                 AV106Uformwwds_9_tfwwpformversionnumber ,
                                                 AV107Uformwwds_10_tfwwpformversionnumber_to ,
                                                 A209WWPFormTitle ,
                                                 A208WWPFormReferenceName ,
                                                 A231WWPFormDate ,
                                                 A207WWPFormVersionNumber ,
                                                 AV33OrderedBy ,
                                                 AV35OrderedDsc ,
                                                 AV99Uformwwds_2_filterfulltext ,
                                                 A219WWPFormLatestVersionNumber ,
                                                 AV108Uformwwds_11_tfwwpformlatestversionnumber ,
                                                 AV109Uformwwds_12_tfwwpformlatestversionnumber_to ,
                                                 A240WWPFormType ,
                                                 AV98Uformwwds_1_wwpformtype } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV100Uformwwds_3_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV100Uformwwds_3_tfwwpformtitle), "%", "");
            lV102Uformwwds_5_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV102Uformwwds_5_tfwwpformreferencename), "%", "");
            /* Using cursor H00A02 */
            pr_default.execute(0, new Object[] {AV98Uformwwds_1_wwpformtype, lV100Uformwwds_3_tfwwpformtitle, AV101Uformwwds_4_tfwwpformtitle_sel, lV102Uformwwds_5_tfwwpformreferencename, AV103Uformwwds_6_tfwwpformreferencename_sel, AV104Uformwwds_7_tfwwpformdate, AV105Uformwwds_8_tfwwpformdate_to, AV106Uformwwds_9_tfwwpformversionnumber, AV107Uformwwds_10_tfwwpformversionnumber_to});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A240WWPFormType = H00A02_A240WWPFormType[0];
               AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
               A207WWPFormVersionNumber = H00A02_A207WWPFormVersionNumber[0];
               A231WWPFormDate = H00A02_A231WWPFormDate[0];
               A208WWPFormReferenceName = H00A02_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00A02_A209WWPFormTitle[0];
               A206WWPFormId = H00A02_A206WWPFormId[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Uformwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV99Uformwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV99Uformwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV99Uformwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV99Uformwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) ) )
               {
                  if ( (0==AV108Uformwwds_11_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV108Uformwwds_11_tfwwpformlatestversionnumber ) ) )
                  {
                     if ( (0==AV109Uformwwds_12_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV109Uformwwds_12_tfwwpformlatestversionnumber_to ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E26A02 ();
                     }
                  }
               }
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WBA00( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA02( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UUPDATE", AV60IsAuthorized_UUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UUPDATE", GetSecureSignedToken( "", AV60IsAuthorized_UUpdate, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDELETE", AV90IsAuthorized_UDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDELETE", GetSecureSignedToken( "", AV90IsAuthorized_UDelete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV25IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV25IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_EXPORTFORM", AV91IsAuthorized_ExportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXPORTFORM", GetSecureSignedToken( "", AV91IsAuthorized_ExportForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLOUTAFORM", AV92IsAuthorized_FillOutAForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLOUTAFORM", GetSecureSignedToken( "", AV92IsAuthorized_FillOutAForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV58IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV58IsAuthorized_FilledOutForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COPY", AV93IsAuthorized_Copy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COPY", GetSecureSignedToken( "", AV93IsAuthorized_Copy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UCOPYTOLOCATION", AV95IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( "", AV95IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV96IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( "", AV96IsAuthorized_UDirectCopyToLocation, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV62LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV62LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UINSERT", AV59IsAuthorized_UInsert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UINSERT", GetSecureSignedToken( "", AV59IsAuthorized_UInsert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV26IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV26IsAuthorized_Insert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_IMPORTFORM", AV94IsAuthorized_ImportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_IMPORTFORM", GetSecureSignedToken( "", AV94IsAuthorized_ImportForm, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(GRID_nFirstRecordOnPage+1) ;
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
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV97Pgmname = "UFormWW";
         edtavFilledoutforms_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24A02 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV28ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV10DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV7ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV19GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV11DDO_WWPFormDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATE"), 0);
            AV13DDO_WWPFormDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATETO"), 0);
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_udelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Title");
            Dvelop_confirmpanel_udelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext");
            Dvelop_confirmpanel_udelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_udelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_udelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_udelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_udelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype");
            Ucopytolocation_modal_Width = cgiGet( "UCOPYTOLOCATION_MODAL_Width");
            Ucopytolocation_modal_Title = cgiGet( "UCOPYTOLOCATION_MODAL_Title");
            Ucopytolocation_modal_Confirmtype = cgiGet( "UCOPYTOLOCATION_MODAL_Confirmtype");
            Ucopytolocation_modal_Bodytype = cgiGet( "UCOPYTOLOCATION_MODAL_Bodytype");
            Importform_modal_Width = cgiGet( "IMPORTFORM_MODAL_Width");
            Importform_modal_Title = cgiGet( "IMPORTFORM_MODAL_Title");
            Importform_modal_Confirmtype = cgiGet( "IMPORTFORM_MODAL_Confirmtype");
            Importform_modal_Bodytype = cgiGet( "IMPORTFORM_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_udelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Result");
            Ucopytolocation_modal_Result = cgiGet( "UCOPYTOLOCATION_MODAL_Result");
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
            AV12DDO_WWPFormDateAuxDateText = cgiGet( edtavDdo_wwpformdateauxdatetext_Internalname);
            AssignAttri("", false, "AV12DDO_WWPFormDateAuxDateText", AV12DDO_WWPFormDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_41_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            if ( nGXsfl_41_idx > 0 )
            {
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILLEDOUTFORMS");
                  GX_FocusControl = edtavFilledoutforms_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  AV55FilledOutForms = 0;
                  AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
               }
               else
               {
                  AV55FilledOutForms = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
               }
               cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
               cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
               AV57GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActionGroup1), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"UFormWW");
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
            forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("uformww:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV33OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV35OrderedDsc )
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
         E24A02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24A02( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_guid2 = AV62LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
         AV62LocationId = GXt_guid2;
         AssignAttri("", false, "AV62LocationId", AV62LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV62LocationId, context));
         GXt_guid2 = AV64OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         AV64OrganisationId = GXt_guid2;
         AssignAttri("", false, "AV64OrganisationId", AV64OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV64OrganisationId, context));
         GXt_objcol_int3 = AV56GeneralDynamicFormids;
         new prc_generaldynamicform(context ).execute( out  GXt_objcol_int3) ;
         AV56GeneralDynamicFormids = GXt_objcol_int3;
         this.executeUsercontrolMethod("", false, "TFWWPFORMDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpformdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV22HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV15GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV16GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " UForm", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         cmbWWPFormType.Visible = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
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
         if ( AV33OrderedBy < 1 )
         {
            AV33OrderedBy = 1;
            AssignAttri("", false, "AV33OrderedBy", StringUtil.LTrimStr( (decimal)(AV33OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV10DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV10DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( AV5WWPFormType == 1 )
         {
            if ( AV87WWPFormIsForDynamicValidations )
            {
               Form.Caption = context.GetMessage( "WWP_DynamicValidations", "");
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
            else
            {
               Form.Caption = context.GetMessage( "WWP_DynamicSections", "");
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
         }
      }

      protected void E25A02( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV50WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV29ManageFiltersExecutionStep == 1 )
         {
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV29ManageFiltersExecutionStep == 2 )
         {
            AV29ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV38Session.Get("UFormWWColumnsSelector"), "") != 0 )
         {
            AV9ColumnsSelectorXML = AV38Session.Get("UFormWWColumnsSelector");
            AV7ColumnsSelector.FromXml(AV9ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtWWPFormTitle_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV7ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtWWPFormReferenceName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV7ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtWWPFormDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV7ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtWWPFormVersionNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV7ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtWWPFormLatestVersionNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV7ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormLatestVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0), !bGXsfl_41_Refreshing);
         AV18GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV18GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV18GridCurrentPage), 10, 0));
         AV19GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV19GridPageCount", StringUtil.LTrimStr( (decimal)(AV19GridPageCount), 10, 0));
         GXt_char5 = AV17GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV97Pgmname, out  GXt_char5) ;
         AV17GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV17GridAppliedFilters", AV17GridAppliedFilters);
         AV98Uformwwds_1_wwpformtype = AV5WWPFormType;
         AV99Uformwwds_2_filterfulltext = AV14FilterFullText;
         AV100Uformwwds_3_tfwwpformtitle = AV45TFWWPFormTitle;
         AV101Uformwwds_4_tfwwpformtitle_sel = AV46TFWWPFormTitle_Sel;
         AV102Uformwwds_5_tfwwpformreferencename = AV43TFWWPFormReferenceName;
         AV103Uformwwds_6_tfwwpformreferencename_sel = AV44TFWWPFormReferenceName_Sel;
         AV104Uformwwds_7_tfwwpformdate = AV39TFWWPFormDate;
         AV105Uformwwds_8_tfwwpformdate_to = AV40TFWWPFormDate_To;
         AV106Uformwwds_9_tfwwpformversionnumber = AV81TFWWPFormVersionNumber;
         AV107Uformwwds_10_tfwwpformversionnumber_to = AV82TFWWPFormVersionNumber_To;
         AV108Uformwwds_11_tfwwpformlatestversionnumber = AV41TFWWPFormLatestVersionNumber;
         AV109Uformwwds_12_tfwwpformlatestversionnumber_to = AV42TFWWPFormLatestVersionNumber_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E12A02( )
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
            AV36PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV36PageToGo) ;
         }
      }

      protected void E13A02( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A02( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV33OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33OrderedBy", StringUtil.LTrimStr( (decimal)(AV33OrderedBy), 4, 0));
            AV35OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV35OrderedDsc", AV35OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV45TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFWWPFormTitle", AV45TFWWPFormTitle);
               AV46TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFWWPFormTitle_Sel", AV46TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormReferenceName") == 0 )
            {
               AV43TFWWPFormReferenceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFWWPFormReferenceName", AV43TFWWPFormReferenceName);
               AV44TFWWPFormReferenceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFWWPFormReferenceName_Sel", AV44TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormDate") == 0 )
            {
               AV39TFWWPFormDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV39TFWWPFormDate", context.localUtil.TToC( AV39TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV40TFWWPFormDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV40TFWWPFormDate_To", context.localUtil.TToC( AV40TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV40TFWWPFormDate_To) )
               {
                  AV40TFWWPFormDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV40TFWWPFormDate_To)), (short)(DateTimeUtil.Month( AV40TFWWPFormDate_To)), (short)(DateTimeUtil.Day( AV40TFWWPFormDate_To)), 23, 59, 59);
                  AssignAttri("", false, "AV40TFWWPFormDate_To", context.localUtil.TToC( AV40TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormVersionNumber") == 0 )
            {
               AV81TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV81TFWWPFormVersionNumber), 4, 0));
               AV82TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV82TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormLatestVersionNumber") == 0 )
            {
               AV41TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0));
               AV42TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E26A02( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV5WWPFormType == 0 )
         {
            AV85WWPFormId = A206WWPFormId;
            AssignAttri("", false, "AV85WWPFormId", StringUtil.LTrimStr( (decimal)(AV85WWPFormId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85WWPFormId), "ZZZ9"), context));
            /* Execute user subroutine: 'COUNTFILLEDOUTFORMS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         if ( AV60IsAuthorized_UUpdate )
         {
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Update", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV90IsAuthorized_UDelete )
         {
            if ( ( AV55FilledOutForms == 0 ) && ( AV5WWPFormType == 0 ) )
            {
               cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV25IsAuthorized_Display )
         {
            cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV91IsAuthorized_ExportForm )
         {
            cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_ExportForm", ""), "fas fa-file-export", "", "", "", "", "", "", ""), 0);
         }
         if ( AV92IsAuthorized_FillOutAForm )
         {
            if ( AV5WWPFormType == 0 )
            {
               cmbavGridactiongroup1.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_FillOutAForm", ""), "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV58IsAuthorized_FilledOutForms )
         {
            if ( ( AV5WWPFormType == 0 ) && ( AV55FilledOutForms > 0 ) )
            {
               cmbavGridactiongroup1.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_ViewFilledOutForms", ""), "fab fa-wpforms", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV93IsAuthorized_Copy )
         {
            cmbavGridactiongroup1.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_CopyForm", ""), "far fa-clone", "", "", "", "", "", "", ""), 0);
         }
         if ( AV95IsAuthorized_UCopyToLocation )
         {
            cmbavGridactiongroup1.addItem("8", StringUtil.Format( "%1;%2", context.GetMessage( "Copy To Location", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
         }
         if ( AV96IsAuthorized_UDirectCopyToLocation )
         {
            cmbavGridactiongroup1.addItem("9", StringUtil.Format( "%1;%2", context.GetMessage( "Copy To Location", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactiongroup1.ItemCount == 1 )
         {
            cmbavGridactiongroup1_Class = "Invisible";
         }
         else
         {
            cmbavGridactiongroup1_Class = "ConvertToDDO";
         }
         if ( (AV56GeneralDynamicFormids.IndexOf(A206WWPFormId)>0) )
         {
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 41;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_412( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
            {
               DoAjaxLoad(41, GridRow);
            }
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0));
      }

      protected void E15A02( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV9ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV7ColumnsSelector.FromJSonString(AV9ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "UFormWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV9ColumnsSelectorXML)) ? "" : AV7ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E11A02( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
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
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("UFormWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV97Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("UFormWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char5 = AV30ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "UFormWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char5) ;
            AV30ManageFiltersXml = GXt_char5;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV97Pgmname+"GridState",  AV30ManageFiltersXml) ;
               AV20GridState.FromXml(AV30ManageFiltersXml, null, "", "");
               AV33OrderedBy = AV20GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV33OrderedBy", StringUtil.LTrimStr( (decimal)(AV33OrderedBy), 4, 0));
               AV35OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV35OrderedDsc", AV35OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
      }

      protected void E27A02( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV57GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UUPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO EXPORTFORM' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 5 )
         {
            /* Execute user subroutine: 'DO FILLOUTAFORM' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 6 )
         {
            /* Execute user subroutine: 'DO FILLEDOUTFORMS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 7 )
         {
            /* Execute user subroutine: 'DO COPY' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 8 )
         {
            /* Execute user subroutine: 'DO UCOPYTOLOCATION' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActionGroup1 == 9 )
         {
            /* Execute user subroutine: 'DO UDIRECTCOPYTOLOCATION' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV57GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E16A02( )
      {
         /* Dvelop_confirmpanel_udelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDELETE' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E18A02( )
      {
         /* Ucopytolocation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_CopyGeneralDynamicFormToLocation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_copygeneraldynamicformtolocation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_CopyGeneralDynamicFormToLocation";
            WebComp_Wwpaux_wc_Component = "WC_CopyGeneralDynamicFormToLocation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0076",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0076"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E21A02( )
      {
         /* 'DoUInsert' Routine */
         returnInSub = false;
         if ( AV59IsAuthorized_UInsert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV5WWPFormType,1,0));
            CallWebObject(formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E22A02( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV26IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV5WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E23A02( )
      {
         /* 'DoImportForm' Routine */
         returnInSub = false;
         if ( AV94IsAuthorized_ImportForm )
         {
            this.executeUsercontrolMethod("", false, "IMPORTFORM_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E20A02( )
      {
         /* Importform_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_SelectImportFile")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_selectimportfile", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_SelectImportFile";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_SelectImportFile";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0076",(string)"","WorkWithPlus.DynamicForms.WWP_FormWW",(string)"JSON",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0076"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E19A02( )
      {
         /* Importform_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7ColumnsSelector", AV7ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV33OrderedBy), 4, 0))+":"+(AV35OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV7ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         if ( AV5WWPFormType == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "WWPFormTitle",  "",  "WWP_DF_Title",  true,  "") ;
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "",  "",  "",  false,  "") ;
            AV45TFWWPFormTitle = "";
            AssignAttri("", false, "AV45TFWWPFormTitle", AV45TFWWPFormTitle);
            AV46TFWWPFormTitle_Sel = "";
            AssignAttri("", false, "AV46TFWWPFormTitle_Sel", AV46TFWWPFormTitle_Sel);
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "WWPFormReferenceName",  "",  "WWP_DF_ReferenceName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "WWPFormDate",  "",  "Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "WWPFormVersionNumber",  "",  "WWP_DF_FormVersion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV7ColumnsSelector,  "WWPFormLatestVersionNumber",  "",  "Latest Version",  true,  "") ;
         GXt_char5 = AV49UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "UFormWWColumnsSelector", out  GXt_char5) ;
         AV49UserCustomValue = GXt_char5;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49UserCustomValue)) ) )
         {
            AV8ColumnsSelectorAux.FromXml(AV49UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV8ColumnsSelectorAux, ref  AV7ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean6 = AV60IsAuthorized_UUpdate;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_uupdate", out  GXt_boolean6) ;
         AV60IsAuthorized_UUpdate = GXt_boolean6;
         AssignAttri("", false, "AV60IsAuthorized_UUpdate", AV60IsAuthorized_UUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UUPDATE", GetSecureSignedToken( "", AV60IsAuthorized_UUpdate, context));
         GXt_boolean6 = AV90IsAuthorized_UDelete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_udelete", out  GXt_boolean6) ;
         AV90IsAuthorized_UDelete = GXt_boolean6;
         AssignAttri("", false, "AV90IsAuthorized_UDelete", AV90IsAuthorized_UDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDELETE", GetSecureSignedToken( "", AV90IsAuthorized_UDelete, context));
         GXt_boolean6 = AV25IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean6) ;
         AV25IsAuthorized_Display = GXt_boolean6;
         AssignAttri("", false, "AV25IsAuthorized_Display", AV25IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV25IsAuthorized_Display, context));
         GXt_boolean6 = AV91IsAuthorized_ExportForm;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_uexport", out  GXt_boolean6) ;
         AV91IsAuthorized_ExportForm = GXt_boolean6;
         AssignAttri("", false, "AV91IsAuthorized_ExportForm", AV91IsAuthorized_ExportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_EXPORTFORM", GetSecureSignedToken( "", AV91IsAuthorized_ExportForm, context));
         GXt_boolean6 = AV92IsAuthorized_FillOutAForm;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_ufill", out  GXt_boolean6) ;
         AV92IsAuthorized_FillOutAForm = GXt_boolean6;
         AssignAttri("", false, "AV92IsAuthorized_FillOutAForm", AV92IsAuthorized_FillOutAForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLOUTAFORM", GetSecureSignedToken( "", AV92IsAuthorized_FillOutAForm, context));
         GXt_boolean6 = AV58IsAuthorized_FilledOutForms;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_ufilledoutform", out  GXt_boolean6) ;
         AV58IsAuthorized_FilledOutForms = GXt_boolean6;
         AssignAttri("", false, "AV58IsAuthorized_FilledOutForms", AV58IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV58IsAuthorized_FilledOutForms, context));
         GXt_boolean6 = AV93IsAuthorized_Copy;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_ucopy", out  GXt_boolean6) ;
         AV93IsAuthorized_Copy = GXt_boolean6;
         AssignAttri("", false, "AV93IsAuthorized_Copy", AV93IsAuthorized_Copy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COPY", GetSecureSignedToken( "", AV93IsAuthorized_Copy, context));
         GXt_boolean6 = AV95IsAuthorized_UCopyToLocation;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_copytolocation", out  GXt_boolean6) ;
         AV95IsAuthorized_UCopyToLocation = GXt_boolean6;
         AssignAttri("", false, "AV95IsAuthorized_UCopyToLocation", AV95IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( "", AV95IsAuthorized_UCopyToLocation, context));
         GXt_boolean6 = AV96IsAuthorized_UDirectCopyToLocation;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_directcopytolocation", out  GXt_boolean6) ;
         AV96IsAuthorized_UDirectCopyToLocation = GXt_boolean6;
         AssignAttri("", false, "AV96IsAuthorized_UDirectCopyToLocation", AV96IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( "", AV96IsAuthorized_UDirectCopyToLocation, context));
         GXt_boolean6 = AV59IsAuthorized_UInsert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_uinsert", out  GXt_boolean6) ;
         AV59IsAuthorized_UInsert = GXt_boolean6;
         AssignAttri("", false, "AV59IsAuthorized_UInsert", AV59IsAuthorized_UInsert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UINSERT", GetSecureSignedToken( "", AV59IsAuthorized_UInsert, context));
         if ( ! ( AV59IsAuthorized_UInsert && ( ( AV5WWPFormType == 0 ) ) ) )
         {
            bttBtnuinsert_Visible = 0;
            AssignProp("", false, bttBtnuinsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuinsert_Visible), 5, 0), true);
         }
         GXt_boolean6 = AV26IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean6) ;
         AV26IsAuthorized_Insert = GXt_boolean6;
         AssignAttri("", false, "AV26IsAuthorized_Insert", AV26IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV26IsAuthorized_Insert, context));
         if ( ! ( AV26IsAuthorized_Insert && ( ( AV5WWPFormType == 0 ) ) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean6 = AV94IsAuthorized_ImportForm;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "uform_uimport", out  GXt_boolean6) ;
         AV94IsAuthorized_ImportForm = GXt_boolean6;
         AssignAttri("", false, "AV94IsAuthorized_ImportForm", AV94IsAuthorized_ImportForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_IMPORTFORM", GetSecureSignedToken( "", AV94IsAuthorized_ImportForm, context));
         if ( ! ( AV94IsAuthorized_ImportForm ) )
         {
            bttBtnimportform_Visible = 0;
            AssignProp("", false, bttBtnimportform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnimportform_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = AV28ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "UFormWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7) ;
         AV28ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV45TFWWPFormTitle = "";
         AssignAttri("", false, "AV45TFWWPFormTitle", AV45TFWWPFormTitle);
         AV46TFWWPFormTitle_Sel = "";
         AssignAttri("", false, "AV46TFWWPFormTitle_Sel", AV46TFWWPFormTitle_Sel);
         AV43TFWWPFormReferenceName = "";
         AssignAttri("", false, "AV43TFWWPFormReferenceName", AV43TFWWPFormReferenceName);
         AV44TFWWPFormReferenceName_Sel = "";
         AssignAttri("", false, "AV44TFWWPFormReferenceName_Sel", AV44TFWWPFormReferenceName_Sel);
         AV39TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV39TFWWPFormDate", context.localUtil.TToC( AV39TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV40TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV40TFWWPFormDate_To", context.localUtil.TToC( AV40TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV81TFWWPFormVersionNumber = 0;
         AssignAttri("", false, "AV81TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV81TFWWPFormVersionNumber), 4, 0));
         AV82TFWWPFormVersionNumber_To = 0;
         AssignAttri("", false, "AV82TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0));
         AV41TFWWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "AV41TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0));
         AV42TFWWPFormLatestVersionNumber_To = 0;
         AssignAttri("", false, "AV42TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO UUPDATE' Routine */
         returnInSub = false;
         if ( AV60IsAuthorized_UUpdate )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
            CallWebObject(formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_udelete_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteFormMessage", ""), A209WWPFormTitle, "", "", "", "", "", "", "", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
         if ( AV90IsAuthorized_UDelete )
         {
            AV86WWPFormId_Selected = A206WWPFormId;
            AssignAttri("", false, "AV86WWPFormId_Selected", StringUtil.LTrimStr( (decimal)(AV86WWPFormId_Selected), 4, 0));
            AV89WWPFormVersionNumber_Selected = A207WWPFormVersionNumber;
            AssignAttri("", false, "AV89WWPFormVersionNumber_Selected", StringUtil.LTrimStr( (decimal)(AV89WWPFormVersionNumber_Selected), 4, 0));
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S302( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV86WWPFormId_Selected,  AV89WWPFormVersionNumber_Selected, out  AV32Messages) ;
         if ( AV32Messages.Count > 0 )
         {
            AV110GXV1 = 1;
            while ( AV110GXV1 <= AV32Messages.Count )
            {
               AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV32Messages.Item(AV110GXV1));
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV31Message.gxTpr_Description,  "error",  "",  "false",  ""));
               AV110GXV1 = (int)(AV110GXV1+1);
            }
         }
         gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
      }

      protected void S232( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV25IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV5WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S242( )
      {
         /* 'DO EXPORTFORM' Routine */
         returnInSub = false;
         if ( AV91IsAuthorized_ExportForm )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_export.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_df_export.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 2;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S252( )
      {
         /* 'DO FILLOUTAFORM' Routine */
         returnInSub = false;
         if ( AV92IsAuthorized_FillOutAForm )
         {
            CallWebObject(formatLink("udynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim("INS"))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S262( )
      {
         /* 'DO FILLEDOUTFORMS' Routine */
         returnInSub = false;
         if ( AV58IsAuthorized_FilledOutForms )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ufilledoutforms.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A209WWPFormTitle));
            CallWebObject(formatLink("ufilledoutforms.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO COPY' Routine */
         returnInSub = false;
         AV84WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV51CopyNumber = 1;
         AV88WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV51CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV88WWPFormReferenceName) )
         {
            AV51CopyNumber = (short)(AV51CopyNumber+1);
            AV88WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV51CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV63NewWWPForm = new SdtUForm(context);
         /* Using cursor H00A03 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A206WWPFormId = H00A03_A206WWPFormId[0];
            AV63NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV63NewWWPForm.gxTpr_Wwpformid = (short)(AV63NewWWPForm.gxTpr_Wwpformid+1);
         AV63NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV63NewWWPForm.gxTpr_Wwpformreferencename = AV88WWPFormReferenceName;
         AV63NewWWPForm.gxTpr_Wwpformtitle = AV84WWPForm.gxTpr_Wwpformtitle;
         AV63NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV63NewWWPForm.gxTpr_Wwpformiswizard = AV84WWPForm.gxTpr_Wwpformiswizard;
         AV63NewWWPForm.gxTpr_Wwpformvalidations = AV84WWPForm.gxTpr_Wwpformvalidations;
         AV63NewWWPForm.gxTpr_Wwpformresume = AV84WWPForm.gxTpr_Wwpformresume;
         AV63NewWWPForm.gxTpr_Wwpformresumemessage = AV84WWPForm.gxTpr_Wwpformresumemessage;
         AV112GXV2 = 1;
         while ( AV112GXV2 <= AV84WWPForm.gxTpr_Element.Count )
         {
            AV52Element = ((SdtUForm_Element)AV84WWPForm.gxTpr_Element.Item(AV112GXV2));
            if ( AV52Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV63NewWWPForm.gxTpr_Element.Add(AV52Element, 0);
            }
            AV112GXV2 = (int)(AV112GXV2+1);
         }
         if ( AV63NewWWPForm.Insert() )
         {
            context.CommitDataStores("uformww",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Copy_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Copy_Success", ""),  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
         }
         else
         {
            AV114GXV4 = 1;
            AV113GXV3 = AV63NewWWPForm.GetMessages();
            while ( AV114GXV4 <= AV113GXV3.Count )
            {
               AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV113GXV3.Item(AV114GXV4));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ResultMsg)) )
               {
                  AV65ResultMsg += StringUtil.NewLine( );
                  AssignAttri("", false, "AV65ResultMsg", AV65ResultMsg);
               }
               AV65ResultMsg += AV31Message.gxTpr_Description;
               AssignAttri("", false, "AV65ResultMsg", AV65ResultMsg);
               AV114GXV4 = (int)(AV114GXV4+1);
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV65ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S282( )
      {
         /* 'DO UCOPYTOLOCATION' Routine */
         returnInSub = false;
         if ( AV95IsAuthorized_UCopyToLocation )
         {
            this.executeUsercontrolMethod("", false, "UCOPYTOLOCATION_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S292( )
      {
         /* 'DO UDIRECTCOPYTOLOCATION' Routine */
         returnInSub = false;
         AV84WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV51CopyNumber = 1;
         AV88WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV51CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV88WWPFormReferenceName) )
         {
            AV51CopyNumber = (short)(AV51CopyNumber+1);
            AV88WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV51CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV63NewWWPForm = new SdtUForm(context);
         /* Using cursor H00A04 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A206WWPFormId = H00A04_A206WWPFormId[0];
            AV63NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV63NewWWPForm.gxTpr_Wwpformid = (short)(AV63NewWWPForm.gxTpr_Wwpformid+1);
         AV63NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV63NewWWPForm.gxTpr_Wwpformreferencename = AV88WWPFormReferenceName;
         AV63NewWWPForm.gxTpr_Wwpformtitle = AV84WWPForm.gxTpr_Wwpformtitle;
         AV63NewWWPForm.gxTpr_Wwpformiswizard = AV84WWPForm.gxTpr_Wwpformiswizard;
         AV63NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV63NewWWPForm.gxTpr_Wwpformvalidations = AV84WWPForm.gxTpr_Wwpformvalidations;
         AV63NewWWPForm.gxTpr_Wwpformresume = AV84WWPForm.gxTpr_Wwpformresume;
         AV63NewWWPForm.gxTpr_Wwpformresumemessage = AV84WWPForm.gxTpr_Wwpformresumemessage;
         AV116GXV5 = 1;
         while ( AV116GXV5 <= AV84WWPForm.gxTpr_Element.Count )
         {
            AV52Element = ((SdtUForm_Element)AV84WWPForm.gxTpr_Element.Item(AV116GXV5));
            if ( AV52Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV63NewWWPForm.gxTpr_Element.Add(AV52Element, 0);
            }
            AV116GXV5 = (int)(AV116GXV5+1);
         }
         if ( AV63NewWWPForm.Insert() )
         {
            context.CommitDataStores("uformww",pr_default);
            if ( ! (Guid.Empty==AV62LocationId) )
            {
               AV83Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
               AV83Trn_LocationDynamicForm.gxTpr_Locationdynamicformid = Guid.NewGuid( );
               AV83Trn_LocationDynamicForm.gxTpr_Locationid = AV62LocationId;
               AV83Trn_LocationDynamicForm.gxTpr_Organisationid = AV64OrganisationId;
               AV83Trn_LocationDynamicForm.gxTpr_Wwpformid = AV63NewWWPForm.gxTpr_Wwpformid;
               AV83Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber = AV63NewWWPForm.gxTpr_Wwpformversionnumber;
               if ( AV83Trn_LocationDynamicForm.Insert() )
               {
                  context.CommitDataStores("uformww",pr_default);
               }
               else
               {
                  AV118GXV7 = 1;
                  AV117GXV6 = AV83Trn_LocationDynamicForm.GetMessages();
                  while ( AV118GXV7 <= AV117GXV6.Count )
                  {
                     AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV117GXV6.Item(AV118GXV7));
                     GX_msglist.addItem(AV31Message.gxTpr_Description);
                     AV118GXV7 = (int)(AV118GXV7+1);
                  }
               }
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Copy_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Copy_Success", ""),  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV33OrderedBy, AV35OrderedDsc, AV29ManageFiltersExecutionStep, AV7ColumnsSelector, AV97Pgmname, AV5WWPFormType, AV14FilterFullText, AV45TFWWPFormTitle, AV46TFWWPFormTitle_Sel, AV43TFWWPFormReferenceName, AV44TFWWPFormReferenceName_Sel, AV39TFWWPFormDate, AV40TFWWPFormDate_To, AV81TFWWPFormVersionNumber, AV82TFWWPFormVersionNumber_To, AV41TFWWPFormLatestVersionNumber, AV42TFWWPFormLatestVersionNumber_To, AV87WWPFormIsForDynamicValidations, AV60IsAuthorized_UUpdate, AV90IsAuthorized_UDelete, AV55FilledOutForms, AV25IsAuthorized_Display, AV91IsAuthorized_ExportForm, AV92IsAuthorized_FillOutAForm, AV58IsAuthorized_FilledOutForms, AV93IsAuthorized_Copy, AV95IsAuthorized_UCopyToLocation, AV96IsAuthorized_UDirectCopyToLocation, AV56GeneralDynamicFormids, AV85WWPFormId, AV62LocationId, AV64OrganisationId, AV59IsAuthorized_UInsert, AV26IsAuthorized_Insert, AV94IsAuthorized_ImportForm, A240WWPFormType) ;
            CallWebObject(formatLink("wp_locationdynamicform.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV120GXV9 = 1;
            AV119GXV8 = AV63NewWWPForm.GetMessages();
            while ( AV120GXV9 <= AV119GXV8.Count )
            {
               AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV119GXV8.Item(AV120GXV9));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ResultMsg)) )
               {
                  AV65ResultMsg += StringUtil.NewLine( );
                  AssignAttri("", false, "AV65ResultMsg", AV65ResultMsg);
               }
               AV65ResultMsg += AV31Message.gxTpr_Description;
               AssignAttri("", false, "AV65ResultMsg", AV65ResultMsg);
               AV120GXV9 = (int)(AV120GXV9+1);
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV65ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get(AV97Pgmname+"GridState"), "") == 0 )
         {
            AV20GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV97Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV20GridState.FromXml(AV38Session.Get(AV97Pgmname+"GridState"), null, "", "");
         }
         AV33OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV33OrderedBy", StringUtil.LTrimStr( (decimal)(AV33OrderedBy), 4, 0));
         AV35OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV35OrderedDsc", AV35OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV20GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV20GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV20GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV121GXV10 = 1;
         while ( AV121GXV10 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV121GXV10));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV45TFWWPFormTitle = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFWWPFormTitle", AV45TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV46TFWWPFormTitle_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFWWPFormTitle_Sel", AV46TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV43TFWWPFormReferenceName = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFWWPFormReferenceName", AV43TFWWPFormReferenceName);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV44TFWWPFormReferenceName_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFWWPFormReferenceName_Sel", AV44TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV39TFWWPFormDate = context.localUtil.CToT( AV21GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV39TFWWPFormDate", context.localUtil.TToC( AV39TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV40TFWWPFormDate_To = context.localUtil.CToT( AV21GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV40TFWWPFormDate_To", context.localUtil.TToC( AV40TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV11DDO_WWPFormDateAuxDate = DateTimeUtil.ResetTime(AV39TFWWPFormDate);
               AssignAttri("", false, "AV11DDO_WWPFormDateAuxDate", context.localUtil.Format(AV11DDO_WWPFormDateAuxDate, "99/99/99"));
               AV13DDO_WWPFormDateAuxDateTo = DateTimeUtil.ResetTime(AV40TFWWPFormDate_To);
               AssignAttri("", false, "AV13DDO_WWPFormDateAuxDateTo", context.localUtil.Format(AV13DDO_WWPFormDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV81TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV81TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV81TFWWPFormVersionNumber), 4, 0));
               AV82TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV82TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV41TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0));
               AV42TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            AV121GXV10 = (int)(AV121GXV10+1);
         }
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFWWPFormTitle_Sel)),  AV46TFWWPFormTitle_Sel, out  GXt_char5) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFWWPFormReferenceName_Sel)),  AV44TFWWPFormReferenceName_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char5+"|"+GXt_char8+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFWWPFormTitle)),  AV45TFWWPFormTitle, out  GXt_char8) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFWWPFormReferenceName)),  AV43TFWWPFormReferenceName, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char5+"|"+((DateTime.MinValue==AV39TFWWPFormDate) ? "" : context.localUtil.DToC( AV11DDO_WWPFormDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV81TFWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV81TFWWPFormVersionNumber), 4, 0))+"|"+((0==AV41TFWWPFormLatestVersionNumber) ? "" : StringUtil.Str( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV40TFWWPFormDate_To) ? "" : context.localUtil.DToC( AV13DDO_WWPFormDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV82TFWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0))+"|"+((0==AV42TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV20GridState.FromXml(AV38Session.Get(AV97Pgmname+"GridState"), null, "", "");
         AV20GridState.gxTpr_Orderedby = AV33OrderedBy;
         AV20GridState.gxTpr_Ordereddsc = AV35OrderedDsc;
         AV20GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFWWPFORMTITLE",  context.GetMessage( "WWP_DF_Title", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFWWPFormTitle)),  0,  AV45TFWWPFormTitle,  AV45TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFWWPFormTitle_Sel)),  AV46TFWWPFormTitle_Sel,  AV46TFWWPFormTitle_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFWWPFORMREFERENCENAME",  context.GetMessage( "WWP_DF_ReferenceName", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFWWPFormReferenceName)),  0,  AV43TFWWPFormReferenceName,  AV43TFWWPFormReferenceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFWWPFormReferenceName_Sel)),  AV44TFWWPFormReferenceName_Sel,  AV44TFWWPFormReferenceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFWWPFORMDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV39TFWWPFormDate)&&(DateTime.MinValue==AV40TFWWPFormDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV39TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV39TFWWPFormDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFWWPFormDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV40TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV40TFWWPFormDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFWWPFormDate_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFWWPFORMVERSIONNUMBER",  context.GetMessage( "WWP_DF_FormVersion", ""),  !((0==AV81TFWWPFormVersionNumber)&&(0==AV82TFWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV81TFWWPFormVersionNumber), 4, 0)),  ((0==AV81TFWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV81TFWWPFormVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV82TFWWPFormVersionNumber_To), 4, 0)),  ((0==AV82TFWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV82TFWWPFormVersionNumber_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFWWPFORMLATESTVERSIONNUMBER",  context.GetMessage( "Latest Version", ""),  !((0==AV41TFWWPFormLatestVersionNumber)&&(0==AV42TFWWPFormLatestVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFWWPFormLatestVersionNumber), 4, 0)),  ((0==AV41TFWWPFormLatestVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV41TFWWPFormLatestVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFWWPFormLatestVersionNumber_To), 4, 0)),  ((0==AV42TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV42TFWWPFormLatestVersionNumber_To), "ZZZ9")))) ;
         if ( ! (0==AV5WWPFormType) )
         {
            AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV21GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV21GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV5WWPFormType), 1, 0);
            AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         }
         if ( ! (false==AV87WWPFormIsForDynamicValidations) )
         {
            AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV21GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV21GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV87WWPFormIsForDynamicValidations);
            AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         }
         AV20GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV20GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV97Pgmname+"GridState",  AV20GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV47TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV47TrnContext.gxTpr_Callerobject = AV97Pgmname;
         AV47TrnContext.gxTpr_Callerondelete = true;
         AV47TrnContext.gxTpr_Callerurl = AV22HTTPRequest.ScriptName+"?"+AV22HTTPRequest.QueryString;
         AV47TrnContext.gxTpr_Transactionname = "UForm";
         AV48TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV48TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV48TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV5WWPFormType), 1, 0);
         AV47TrnContext.gxTpr_Attributes.Add(AV48TrnContextAtt, 0);
         AV38Session.Set("TrnContext", AV47TrnContext.ToXml(false, true, "", ""));
      }

      protected void E17A02( )
      {
         /* Ucopytolocation_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ucopytolocation_modal_Result, context.GetMessage( "OK", "")) == 0 )
         {
            CallWebObject(formatLink("wp_locationdynamicform.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S312( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV87WWPFormIsForDynamicValidations )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
      }

      protected void S182( )
      {
         /* 'COUNTFILLEDOUTFORMS' Routine */
         returnInSub = false;
         AV55FilledOutForms = 0;
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
         /* Optimized group. */
         /* Using cursor H00A05 */
         pr_default.execute(3, new Object[] {AV85WWPFormId});
         cV55FilledOutForms = H00A05_AV55FilledOutForms[0];
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(cV55FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(cV55FilledOutForms), "ZZZ9"), context));
         pr_default.close(3);
         AV55FilledOutForms = (short)(AV55FilledOutForms+cV55FilledOutForms*1);
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV55FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9"), context));
         /* End optimized group. */
      }

      protected void wb_table3_69_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableimportform_modal_Internalname, tblTableimportform_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucImportform_modal.SetProperty("Width", Importform_modal_Width);
            ucImportform_modal.SetProperty("Title", Importform_modal_Title);
            ucImportform_modal.SetProperty("ConfirmType", Importform_modal_Confirmtype);
            ucImportform_modal.SetProperty("BodyType", Importform_modal_Bodytype);
            ucImportform_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Importform_modal_Internalname, "IMPORTFORM_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"IMPORTFORM_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_69_A02e( true) ;
         }
         else
         {
            wb_table3_69_A02e( false) ;
         }
      }

      protected void wb_table2_64_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableucopytolocation_modal_Internalname, tblTableucopytolocation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUcopytolocation_modal.SetProperty("Width", Ucopytolocation_modal_Width);
            ucUcopytolocation_modal.SetProperty("Title", Ucopytolocation_modal_Title);
            ucUcopytolocation_modal.SetProperty("ConfirmType", Ucopytolocation_modal_Confirmtype);
            ucUcopytolocation_modal.SetProperty("BodyType", Ucopytolocation_modal_Bodytype);
            ucUcopytolocation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Ucopytolocation_modal_Internalname, "UCOPYTOLOCATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"UCOPYTOLOCATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_A02e( true) ;
         }
         else
         {
            wb_table2_64_A02e( false) ;
         }
      }

      protected void wb_table1_59_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_udelete_Internalname, tblTabledvelop_confirmpanel_udelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_udelete.SetProperty("Title", Dvelop_confirmpanel_udelete_Title);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_udelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_udelete_Nobuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_udelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_udelete_Yesbuttonposition);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmType", Dvelop_confirmpanel_udelete_Confirmtype);
            ucDvelop_confirmpanel_udelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_udelete_Internalname, "DVELOP_CONFIRMPANEL_UDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_59_A02e( true) ;
         }
         else
         {
            wb_table1_59_A02e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV5WWPFormType", StringUtil.Str( (decimal)(AV5WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5WWPFormType), "9"), context));
         AV87WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri("", false, "AV87WWPFormIsForDynamicValidations", AV87WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV87WWPFormIsForDynamicValidations, context));
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
         PAA02( ) ;
         WSA02( ) ;
         WEA02( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20251222112397", true, true);
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
         context.AddJavascriptSource("uformww.js", "?2025122211240", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_41_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_41_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_41_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_41_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_41_idx;
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_41_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_41_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_41_fel_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_41_fel_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_41_fel_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_41_fel_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_41_fel_idx;
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_41_fel_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_41_fel_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         WBA00( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A209WWPFormTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormTitle_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A208WWPFormReferenceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormReferenceName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormDate_Internalname,context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormLatestVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormLatestVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormLatestVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFilledoutforms_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55FilledOutForms), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavFilledoutforms_Enabled!=0) ? context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9") : context.localUtil.Format( (decimal)(AV55FilledOutForms), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFilledoutforms_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavFilledoutforms_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_41_idx + "',41)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_41_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV57GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_41_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactiongroup1_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_41_Refreshing);
            send_integrity_lvl_hashesA02( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_41_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV57GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActionGroup1), 4, 0));
         }
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"41\">") ;
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_ReferenceName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_FormVersion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Latest Version", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactiongroup1_Class+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209WWPFormTitle));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208WWPFormReferenceName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormReferenceName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55FilledOutForms), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridActionGroup1), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactiongroup1_Class));
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
         bttBtnuinsert_Internalname = "BTNUINSERT";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnimportform_Internalname = "BTNIMPORTFORM";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER";
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
         Ucopytolocation_modal_Internalname = "UCOPYTOLOCATION_MODAL";
         tblTableucopytolocation_modal_Internalname = "TABLEUCOPYTOLOCATION_MODAL";
         Importform_modal_Internalname = "IMPORTFORM_MODAL";
         tblTableimportform_modal_Internalname = "TABLEIMPORTFORM_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_wwpformdateauxdatetext_Internalname = "vDDO_WWPFORMDATEAUXDATETEXT";
         Tfwwpformdate_rangepicker_Internalname = "TFWWPFORMDATE_RANGEPICKER";
         divDdo_wwpformdateauxdates_Internalname = "DDO_WWPFORMDATEAUXDATES";
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
         cmbavGridactiongroup1_Jsonclick = "";
         cmbavGridactiongroup1_Class = "ConvertToDDO";
         edtavFilledoutforms_Jsonclick = "";
         edtavFilledoutforms_Enabled = 1;
         edtWWPFormLatestVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtWWPFormLatestVersionNumber_Visible = -1;
         edtWWPFormVersionNumber_Visible = -1;
         edtWWPFormDate_Visible = -1;
         edtWWPFormReferenceName_Visible = -1;
         edtWWPFormTitle_Visible = -1;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpformdateauxdatetext_Jsonclick = "";
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnimportform_Visible = 1;
         bttBtninsert_Visible = 1;
         bttBtnuinsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Importform_modal_Bodytype = "WebComponent";
         Importform_modal_Confirmtype = "";
         Importform_modal_Title = context.GetMessage( "Select file to import", "");
         Importform_modal_Width = "400";
         Ucopytolocation_modal_Bodytype = "WebComponent";
         Ucopytolocation_modal_Confirmtype = "";
         Ucopytolocation_modal_Title = context.GetMessage( "Copy To Location", "");
         Ucopytolocation_modal_Width = "800";
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "WWP_DF_DeleteFormMessage";
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "WWP_DF_DeleteFormTitle", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "|||4.0|4.0";
         Ddo_grid_Datalistproc = "UFormWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||";
         Ddo_grid_Includedatalist = "T|T|||";
         Ddo_grid_Filterisrange = "||P|T|T";
         Ddo_grid_Filtertype = "Character|Character|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|1|3|4|";
         Ddo_grid_Columnids = "1:WWPFormTitle|2:WWPFormReferenceName|3:WWPFormDate|4:WWPFormVersionNumber|5:WWPFormLatestVersionNumber";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = context.GetMessage( " UForm", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E26A02","iparms":[{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbavGridactiongroup1"},{"av":"AV57GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E15A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV11DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV13DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV11DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV13DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E27A02","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV57GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME","hsh":true},{"av":"AV65ResultMsg","fld":"vRESULTMSG"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV57GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"Dvelop_confirmpanel_udelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"ConfirmationText"},{"av":"AV86WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9"},{"av":"AV89WWPFormVersionNumber_Selected","fld":"vWWPFORMVERSIONNUMBER_SELECTED","pic":"ZZZ9"},{"av":"AV65ResultMsg","fld":"vRESULTMSG"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE","""{"handler":"E16A02","iparms":[{"av":"Dvelop_confirmpanel_udelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"AV86WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9"},{"av":"AV89WWPFormVersionNumber_Selected","fld":"vWWPFORMVERSIONNUMBER_SELECTED","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT","""{"handler":"E18A02","iparms":[]""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E21A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E22A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("'DOIMPORTFORM'","""{"handler":"E23A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("'DOIMPORTFORM'",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT","""{"handler":"E20A02","iparms":[]""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE","""{"handler":"E19A02","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV33OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV35OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV5WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV43TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV44TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV39TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV40TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV81TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV82TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV41TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV42TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV87WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV55FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV85WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV62LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV64OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV7ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV18GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV19GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV17GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV60IsAuthorized_UUpdate","fld":"vISAUTHORIZED_UUPDATE","hsh":true},{"av":"AV90IsAuthorized_UDelete","fld":"vISAUTHORIZED_UDELETE","hsh":true},{"av":"AV25IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV91IsAuthorized_ExportForm","fld":"vISAUTHORIZED_EXPORTFORM","hsh":true},{"av":"AV92IsAuthorized_FillOutAForm","fld":"vISAUTHORIZED_FILLOUTAFORM","hsh":true},{"av":"AV58IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV93IsAuthorized_Copy","fld":"vISAUTHORIZED_COPY","hsh":true},{"av":"AV95IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV96IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV59IsAuthorized_UInsert","fld":"vISAUTHORIZED_UINSERT","hsh":true},{"ctrl":"BTNUINSERT","prop":"Visible"},{"av":"AV26IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV94IsAuthorized_ImportForm","fld":"vISAUTHORIZED_IMPORTFORM","hsh":true},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV20GridState","fld":"vGRIDSTATE"},{"av":"AV45TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV46TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.CLOSE","""{"handler":"E17A02","iparms":[{"av":"Ucopytolocation_modal_Result","ctrl":"UCOPYTOLOCATION_MODAL","prop":"Result"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMTITLE","""{"handler":"Valid_Wwpformtitle","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME","""{"handler":"Valid_Wwpformreferencename","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMLATESTVERSIONNUMBER","""{"handler":"Valid_Wwpformlatestversionnumber","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactiongroup1","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_udelete_Result = "";
         Ucopytolocation_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV97Pgmname = "";
         AV14FilterFullText = "";
         AV45TFWWPFormTitle = "";
         AV46TFWWPFormTitle_Sel = "";
         AV43TFWWPFormReferenceName = "";
         AV44TFWWPFormReferenceName_Sel = "";
         AV39TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV40TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV56GeneralDynamicFormids = new GxSimpleCollection<short>();
         AV62LocationId = Guid.Empty;
         AV64OrganisationId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV28ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17GridAppliedFilters = "";
         AV10DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11DDO_WWPFormDateAuxDate = DateTime.MinValue;
         AV13DDO_WWPFormDateAuxDateTo = DateTime.MinValue;
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV65ResultMsg = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnuinsert_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnimportform_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV12DDO_WWPFormDateAuxDateText = "";
         ucTfwwpformdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV100Uformwwds_3_tfwwpformtitle = "";
         lV102Uformwwds_5_tfwwpformreferencename = "";
         AV101Uformwwds_4_tfwwpformtitle_sel = "";
         AV100Uformwwds_3_tfwwpformtitle = "";
         AV103Uformwwds_6_tfwwpformreferencename_sel = "";
         AV102Uformwwds_5_tfwwpformreferencename = "";
         AV104Uformwwds_7_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV105Uformwwds_8_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         AV99Uformwwds_2_filterfulltext = "";
         H00A02_A240WWPFormType = new short[1] ;
         H00A02_A207WWPFormVersionNumber = new short[1] ;
         H00A02_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00A02_A208WWPFormReferenceName = new string[] {""} ;
         H00A02_A209WWPFormTitle = new string[] {""} ;
         H00A02_A206WWPFormId = new short[1] ;
         hsh = "";
         GXt_guid2 = Guid.Empty;
         GXt_objcol_int3 = new GxSimpleCollection<short>();
         AV22HTTPRequest = new GxHttpRequest( context);
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV15GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV9ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV30ManageFiltersXml = "";
         AV49UserCustomValue = "";
         AV8ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         AV32Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV84WWPForm = new SdtUForm(context);
         AV88WWPFormReferenceName = "";
         AV63NewWWPForm = new SdtUForm(context);
         H00A03_A207WWPFormVersionNumber = new short[1] ;
         H00A03_A206WWPFormId = new short[1] ;
         AV52Element = new SdtUForm_Element(context);
         AV113GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H00A04_A207WWPFormVersionNumber = new short[1] ;
         H00A04_A206WWPFormId = new short[1] ;
         AV83Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         AV117GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV119GXV8 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char5 = "";
         AV47TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV48TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         H00A05_AV55FilledOutForms = new short[1] ;
         ucImportform_modal = new GXUserControl();
         ucUcopytolocation_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.uformww__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.uformww__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uformww__default(),
            new Object[][] {
                new Object[] {
               H00A02_A240WWPFormType, H00A02_A207WWPFormVersionNumber, H00A02_A231WWPFormDate, H00A02_A208WWPFormReferenceName, H00A02_A209WWPFormTitle, H00A02_A206WWPFormId
               }
               , new Object[] {
               H00A03_A207WWPFormVersionNumber, H00A03_A206WWPFormId
               }
               , new Object[] {
               H00A04_A207WWPFormVersionNumber, H00A04_A206WWPFormId
               }
               , new Object[] {
               H00A05_AV55FilledOutForms
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV97Pgmname = "UFormWW";
         /* GeneXus formulas. */
         AV97Pgmname = "UFormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      private short AV5WWPFormType ;
      private short wcpOAV5WWPFormType ;
      private short GRID_nEOF ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV33OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
      private short AV81TFWWPFormVersionNumber ;
      private short AV82TFWWPFormVersionNumber_To ;
      private short AV41TFWWPFormLatestVersionNumber ;
      private short AV42TFWWPFormLatestVersionNumber_To ;
      private short AV55FilledOutForms ;
      private short AV85WWPFormId ;
      private short A240WWPFormType ;
      private short gxajaxcallmode ;
      private short AV86WWPFormId_Selected ;
      private short AV89WWPFormVersionNumber_Selected ;
      private short wbEnd ;
      private short wbStart ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short AV57GridActionGroup1 ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV106Uformwwds_9_tfwwpformversionnumber ;
      private short AV107Uformwwds_10_tfwwpformversionnumber_to ;
      private short AV108Uformwwds_11_tfwwpformlatestversionnumber ;
      private short AV109Uformwwds_12_tfwwpformlatestversionnumber_to ;
      private short AV98Uformwwds_1_wwpformtype ;
      private short GXt_int1 ;
      private short AV51CopyNumber ;
      private short cV55FilledOutForms ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnuinsert_Visible ;
      private int bttBtninsert_Visible ;
      private int bttBtnimportform_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavFilledoutforms_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormTitle_Visible ;
      private int edtWWPFormReferenceName_Visible ;
      private int edtWWPFormDate_Visible ;
      private int edtWWPFormVersionNumber_Visible ;
      private int edtWWPFormLatestVersionNumber_Visible ;
      private int AV36PageToGo ;
      private int AV110GXV1 ;
      private int AV112GXV2 ;
      private int AV114GXV4 ;
      private int AV116GXV5 ;
      private int AV118GXV7 ;
      private int AV120GXV9 ;
      private int AV121GXV10 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV18GridCurrentPage ;
      private long AV19GridPageCount ;
      private long GRID_nCurrentRecord ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string Ucopytolocation_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string AV97Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_udelete_Title ;
      private string Dvelop_confirmpanel_udelete_Confirmationtext ;
      private string Dvelop_confirmpanel_udelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_udelete_Confirmtype ;
      private string Ucopytolocation_modal_Width ;
      private string Ucopytolocation_modal_Title ;
      private string Ucopytolocation_modal_Confirmtype ;
      private string Ucopytolocation_modal_Bodytype ;
      private string Importform_modal_Width ;
      private string Importform_modal_Title ;
      private string Importform_modal_Confirmtype ;
      private string Importform_modal_Bodytype ;
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
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnimportform_Internalname ;
      private string bttBtnimportform_Jsonclick ;
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
      private string Ddo_grid_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string cmbWWPFormType_Jsonclick ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_wwpformdateauxdates_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Jsonclick ;
      private string Tfwwpformdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string edtavFilledoutforms_Internalname ;
      private string cmbavGridactiongroup1_Internalname ;
      private string GXDecQS ;
      private string hsh ;
      private string cmbavGridactiongroup1_Class ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string GXt_char8 ;
      private string GXt_char5 ;
      private string tblTableimportform_modal_Internalname ;
      private string Importform_modal_Internalname ;
      private string tblTableucopytolocation_modal_Internalname ;
      private string Ucopytolocation_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormDate_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string edtavFilledoutforms_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV39TFWWPFormDate ;
      private DateTime AV40TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private DateTime AV104Uformwwds_7_tfwwpformdate ;
      private DateTime AV105Uformwwds_8_tfwwpformdate_to ;
      private DateTime AV11DDO_WWPFormDateAuxDate ;
      private DateTime AV13DDO_WWPFormDateAuxDateTo ;
      private bool AV87WWPFormIsForDynamicValidations ;
      private bool wcpOAV87WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV35OrderedDsc ;
      private bool AV60IsAuthorized_UUpdate ;
      private bool AV90IsAuthorized_UDelete ;
      private bool AV25IsAuthorized_Display ;
      private bool AV91IsAuthorized_ExportForm ;
      private bool AV92IsAuthorized_FillOutAForm ;
      private bool AV58IsAuthorized_FilledOutForms ;
      private bool AV93IsAuthorized_Copy ;
      private bool AV95IsAuthorized_UCopyToLocation ;
      private bool AV96IsAuthorized_UDirectCopyToLocation ;
      private bool AV59IsAuthorized_UInsert ;
      private bool AV26IsAuthorized_Insert ;
      private bool AV94IsAuthorized_ImportForm ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean6 ;
      private string AV9ColumnsSelectorXML ;
      private string AV30ManageFiltersXml ;
      private string AV49UserCustomValue ;
      private string AV14FilterFullText ;
      private string AV45TFWWPFormTitle ;
      private string AV46TFWWPFormTitle_Sel ;
      private string AV43TFWWPFormReferenceName ;
      private string AV44TFWWPFormReferenceName_Sel ;
      private string AV17GridAppliedFilters ;
      private string AV65ResultMsg ;
      private string AV12DDO_WWPFormDateAuxDateText ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string lV100Uformwwds_3_tfwwpformtitle ;
      private string lV102Uformwwds_5_tfwwpformreferencename ;
      private string AV101Uformwwds_4_tfwwpformtitle_sel ;
      private string AV100Uformwwds_3_tfwwpformtitle ;
      private string AV103Uformwwds_6_tfwwpformreferencename_sel ;
      private string AV102Uformwwds_5_tfwwpformreferencename ;
      private string AV99Uformwwds_2_filterfulltext ;
      private string AV88WWPFormReferenceName ;
      private Guid AV62LocationId ;
      private Guid AV64OrganisationId ;
      private Guid GXt_guid2 ;
      private IGxSession AV38Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfwwpformdate_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GXUserControl ucImportform_modal ;
      private GXUserControl ucUcopytolocation_modal ;
      private GxHttpRequest AV22HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbWWPFormType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV7ColumnsSelector ;
      private GxSimpleCollection<short> AV56GeneralDynamicFormids ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV28ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV10DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H00A02_A240WWPFormType ;
      private short[] H00A02_A207WWPFormVersionNumber ;
      private DateTime[] H00A02_A231WWPFormDate ;
      private string[] H00A02_A208WWPFormReferenceName ;
      private string[] H00A02_A209WWPFormTitle ;
      private short[] H00A02_A206WWPFormId ;
      private GxSimpleCollection<short> GXt_objcol_int3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV16GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV50WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV8ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV32Messages ;
      private GeneXus.Utils.SdtMessages_Message AV31Message ;
      private SdtUForm AV84WWPForm ;
      private SdtUForm AV63NewWWPForm ;
      private short[] H00A03_A207WWPFormVersionNumber ;
      private short[] H00A03_A206WWPFormId ;
      private SdtUForm_Element AV52Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV113GXV3 ;
      private short[] H00A04_A207WWPFormVersionNumber ;
      private short[] H00A04_A206WWPFormId ;
      private SdtTrn_LocationDynamicForm AV83Trn_LocationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV117GXV6 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV119GXV8 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV21GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV47TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV48TrnContextAtt ;
      private short[] H00A05_AV55FilledOutForms ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class uformww__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class uformww__gam : DataStoreHelperBase, IDataStoreHelper
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

public class uformww__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H00A02( IGxContext context ,
                                          string AV101Uformwwds_4_tfwwpformtitle_sel ,
                                          string AV100Uformwwds_3_tfwwpformtitle ,
                                          string AV103Uformwwds_6_tfwwpformreferencename_sel ,
                                          string AV102Uformwwds_5_tfwwpformreferencename ,
                                          DateTime AV104Uformwwds_7_tfwwpformdate ,
                                          DateTime AV105Uformwwds_8_tfwwpformdate_to ,
                                          short AV106Uformwwds_9_tfwwpformversionnumber ,
                                          short AV107Uformwwds_10_tfwwpformversionnumber_to ,
                                          string A209WWPFormTitle ,
                                          string A208WWPFormReferenceName ,
                                          DateTime A231WWPFormDate ,
                                          short A207WWPFormVersionNumber ,
                                          short AV33OrderedBy ,
                                          bool AV35OrderedDsc ,
                                          string AV99Uformwwds_2_filterfulltext ,
                                          short A219WWPFormLatestVersionNumber ,
                                          short AV108Uformwwds_11_tfwwpformlatestversionnumber ,
                                          short AV109Uformwwds_12_tfwwpformlatestversionnumber_to ,
                                          short A240WWPFormType ,
                                          short AV98Uformwwds_1_wwpformtype )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int9 = new short[9];
      Object[] GXv_Object10 = new Object[2];
      scmdbuf = "SELECT WWPFormType, WWPFormVersionNumber, WWPFormDate, WWPFormReferenceName, WWPFormTitle, WWPFormId FROM WWP_Form";
      AddWhere(sWhereString, "(WWPFormType = :AV98Uformwwds_1_wwpformtype)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Uformwwds_4_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Uformwwds_3_tfwwpformtitle)) ) )
      {
         AddWhere(sWhereString, "(WWPFormTitle like :lV100Uformwwds_3_tfwwpformtitle)");
      }
      else
      {
         GXv_int9[1] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Uformwwds_4_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV101Uformwwds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(WWPFormTitle = ( :AV101Uformwwds_4_tfwwpformtitle_sel))");
      }
      else
      {
         GXv_int9[2] = 1;
      }
      if ( StringUtil.StrCmp(AV101Uformwwds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Uformwwds_6_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Uformwwds_5_tfwwpformreferencename)) ) )
      {
         AddWhere(sWhereString, "(WWPFormReferenceName like :lV102Uformwwds_5_tfwwpformreferencename)");
      }
      else
      {
         GXv_int9[3] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Uformwwds_6_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV103Uformwwds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV103Uformwwds_6_tfwwpformreferencename_sel))");
      }
      else
      {
         GXv_int9[4] = 1;
      }
      if ( StringUtil.StrCmp(AV103Uformwwds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormReferenceName))=0))");
      }
      if ( ! (DateTime.MinValue==AV104Uformwwds_7_tfwwpformdate) )
      {
         AddWhere(sWhereString, "(WWPFormDate >= :AV104Uformwwds_7_tfwwpformdate)");
      }
      else
      {
         GXv_int9[5] = 1;
      }
      if ( ! (DateTime.MinValue==AV105Uformwwds_8_tfwwpformdate_to) )
      {
         AddWhere(sWhereString, "(WWPFormDate <= :AV105Uformwwds_8_tfwwpformdate_to)");
      }
      else
      {
         GXv_int9[6] = 1;
      }
      if ( ! (0==AV106Uformwwds_9_tfwwpformversionnumber) )
      {
         AddWhere(sWhereString, "(WWPFormVersionNumber >= :AV106Uformwwds_9_tfwwpformversionnumber)");
      }
      else
      {
         GXv_int9[7] = 1;
      }
      if ( ! (0==AV107Uformwwds_10_tfwwpformversionnumber_to) )
      {
         AddWhere(sWhereString, "(WWPFormVersionNumber <= :AV107Uformwwds_10_tfwwpformversionnumber_to)");
      }
      else
      {
         GXv_int9[8] = 1;
      }
      scmdbuf += sWhereString;
      if ( ( AV33OrderedBy == 1 ) && ! AV35OrderedDsc )
      {
         scmdbuf += " ORDER BY WWPFormType, WWPFormReferenceName";
      }
      else if ( ( AV33OrderedBy == 1 ) && ( AV35OrderedDsc ) )
      {
         scmdbuf += " ORDER BY WWPFormType DESC, WWPFormReferenceName DESC";
      }
      else if ( ( AV33OrderedBy == 2 ) && ! AV35OrderedDsc )
      {
         scmdbuf += " ORDER BY WWPFormType, WWPFormTitle";
      }
      else if ( ( AV33OrderedBy == 2 ) && ( AV35OrderedDsc ) )
      {
         scmdbuf += " ORDER BY WWPFormType DESC, WWPFormTitle DESC";
      }
      else if ( ( AV33OrderedBy == 3 ) && ! AV35OrderedDsc )
      {
         scmdbuf += " ORDER BY WWPFormType, WWPFormDate";
      }
      else if ( ( AV33OrderedBy == 3 ) && ( AV35OrderedDsc ) )
      {
         scmdbuf += " ORDER BY WWPFormType DESC, WWPFormDate DESC";
      }
      else if ( ( AV33OrderedBy == 4 ) && ! AV35OrderedDsc )
      {
         scmdbuf += " ORDER BY WWPFormType, WWPFormVersionNumber";
      }
      else if ( ( AV33OrderedBy == 4 ) && ( AV35OrderedDsc ) )
      {
         scmdbuf += " ORDER BY WWPFormType DESC, WWPFormVersionNumber DESC";
      }
      GXv_Object10[0] = scmdbuf;
      GXv_Object10[1] = GXv_int9;
      return GXv_Object10 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_H00A02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] );
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00A03;
       prmH00A03 = new Object[] {
       };
       Object[] prmH00A04;
       prmH00A04 = new Object[] {
       };
       Object[] prmH00A05;
       prmH00A05 = new Object[] {
       new ParDef("AV85WWPFormId",GXType.Int16,4,0)
       };
       Object[] prmH00A02;
       prmH00A02 = new Object[] {
       new ParDef("AV98Uformwwds_1_wwpformtype",GXType.Int16,1,0) ,
       new ParDef("lV100Uformwwds_3_tfwwpformtitle",GXType.VarChar,100,0) ,
       new ParDef("AV101Uformwwds_4_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
       new ParDef("lV102Uformwwds_5_tfwwpformreferencename",GXType.VarChar,100,0) ,
       new ParDef("AV103Uformwwds_6_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
       new ParDef("AV104Uformwwds_7_tfwwpformdate",GXType.DateTime,8,5) ,
       new ParDef("AV105Uformwwds_8_tfwwpformdate_to",GXType.DateTime,8,5) ,
       new ParDef("AV106Uformwwds_9_tfwwpformversionnumber",GXType.Int16,4,0) ,
       new ParDef("AV107Uformwwds_10_tfwwpformversionnumber_to",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00A02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A02,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00A03", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A03,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("H00A04", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A04,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("H00A05", "SELECT COUNT(*) FROM WWP_FormInstance WHERE WWPFormId = :AV85WWPFormId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A05,1, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
