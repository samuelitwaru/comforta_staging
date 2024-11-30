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
   public class wc_calltoaction : GXWebComponent
   {
      public wc_calltoaction( )
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

      public wc_calltoaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           Guid aP1_LocationId ,
                           Guid aP2_ProductServiceId )
      {
         this.AV65OrganisationId = aP0_OrganisationId;
         this.AV66LocationId = aP1_LocationId;
         this.AV67ProductServiceId = aP2_ProductServiceId;
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
         cmbavCalltoactiontype = new GXCombobox();
         cmbavSdt_calltoaction__calltoactiontype = new GXCombobox();
         cmbavGridactiongroup1 = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  AV65OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
                  AV66LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
                  AV67ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV65OrganisationId,(Guid)AV66LocationId,(Guid)AV67ProductServiceId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxnrGridsdt_calltoactions_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxgrGridsdt_calltoactions_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_calltoactions_newrow_invoke( )
      {
         nRC_GXsfl_82 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_82"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_82_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_82_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_82_idx = GetPar( "sGXsfl_82_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_calltoactions_newrow( ) ;
         /* End function gxnrGridsdt_calltoactions_newrow_invoke */
      }

      protected void gxgrGridsdt_calltoactions_refresh_invoke( )
      {
         subGridsdt_calltoactions_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_calltoactions_Rows"), "."), 18, MidpointRounding.ToEven));
         A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
         AV67ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
         A367CallToActionId = StringUtil.StrToGuid( GetPar( "CallToActionId"));
         A397CallToActionName = GetPar( "CallToActionName");
         A370CallToActionPhone = GetPar( "CallToActionPhone");
         A369CallToActionEmail = GetPar( "CallToActionEmail");
         A368CallToActionType = GetPar( "CallToActionType");
         A396CallToActionUrl = GetPar( "CallToActionUrl");
         A395LocationDynamicFormId = StringUtil.StrToGuid( GetPar( "LocationDynamicFormId"));
         n395LocationDynamicFormId = false;
         A208WWPFormReferenceName = GetPar( "WWPFormReferenceName");
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV68SDT_CallToAction);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_calltoactions_refresh_invoke */
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
            PA752( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_calltoaction__calltoactionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__organisationid_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__productserviceid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__productserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__calltoactionname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationdynamicformid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__wwpformreferencename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtavCalltoactionvariable_Enabled = 0;
               AssignProp(sPrefix, false, edtavCalltoactionvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               WS752( ) ;
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
            context.SendWebValue( context.GetMessage( " Trn_Call To Action", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wc_calltoaction.aspx"+UrlEncode(AV65OrganisationId.ToString()) + "," + UrlEncode(AV66LocationId.ToString()) + "," + UrlEncode(AV67ProductServiceId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_calltoaction.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_calltoaction", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_calltoaction", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Sdt_calltoaction", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_82", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_82), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV59LocationDynamicFormId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV59LocationDynamicFormId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridSDT_CallToActionsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridSDT_CallToActionsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSAPPLIEDFILTERS", AV72GridSDT_CallToActionsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV65OrganisationId", wcpOAV65OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV66LocationId", wcpOAV66LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV67ProductServiceId", wcpOAV67ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEID", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPRODUCTSERVICEID", AV67ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONID", A367CallToActionId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONNAME", A397CallToActionName);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONPHONE", StringUtil.RTrim( A370CallToActionPhone));
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONEMAIL", A369CallToActionEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONTYPE", A368CallToActionType);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONURL", A396CallToActionUrl);
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDYNAMICFORMID", A395LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV77CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV65OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", AV66LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Cls", StringUtil.RTrim( Combo_locationdynamicformid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_set", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Emptyitem", StringUtil.BoolToStr( Combo_locationdynamicformid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Class", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Next", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdt_calltoactions_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname", StringUtil.RTrim( Combo_locationdynamicformid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname", StringUtil.RTrim( Combo_locationdynamicformid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm752( )
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
         return "WC_CallToAction" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Trn_Call To Action", "") ;
      }

      protected void WB750( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_calltoaction.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(82), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuseractioninsert_Jsonclick, 7, context.GetMessage( "Insert", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11751_client"+"'", TempTags, "", 2, "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinsert_Internalname, divTableinsert_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Call to Action", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_CallToAction.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCalltoactiontype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCalltoactiontype_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCalltoactiontype, cmbavCalltoactiontype_Internalname, StringUtil.RTrim( AV52CallToActionType), 1, cmbavCalltoactiontype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCalltoactiontype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_WC_CallToAction.htm");
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", (string)(cmbavCalltoactiontype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionname_Internalname, context.GetMessage( "Label", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionname_Internalname, AV53CallToActionName, StringUtil.RTrim( context.localUtil.Format( AV53CallToActionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", edtavCalltoactionname_Invitemessage, edtavCalltoactionname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableurl_Internalname, divTableurl_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionurl_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionurl_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionurl_Internalname, context.GetMessage( "Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionurl_Internalname, AV58CallToActionUrl, StringUtil.RTrim( context.localUtil.Format( AV58CallToActionUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionurl_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divTablephone_Internalname, divTablephone_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionphone_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionphone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionphone_Internalname, StringUtil.RTrim( AV57CallToActionPhone), StringUtil.RTrim( context.localUtil.Format( AV57CallToActionPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divTableform_Internalname, divTableform_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_locationdynamicformid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_locationdynamicformid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocationdynamicformid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_locationdynamicformid_Internalname, context.GetMessage( "Form", ""), "", "", lblTextblockcombo_locationdynamicformid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationdynamicformid.SetProperty("Caption", Combo_locationdynamicformid_Caption);
            ucCombo_locationdynamicformid.SetProperty("Cls", Combo_locationdynamicformid_Cls);
            ucCombo_locationdynamicformid.SetProperty("EmptyItem", Combo_locationdynamicformid_Emptyitem);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsData", AV59LocationDynamicFormId_Data);
            ucCombo_locationdynamicformid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationdynamicformid_Internalname, sPrefix+"COMBO_LOCATIONDYNAMICFORMIDContainer");
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
            GxWebStd.gx_div_start( context, divTableemail_Internalname, divTableemail_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionemail_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionemail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionemail_Internalname, AV55CallToActionEmail, StringUtil.RTrim( context.localUtil.Format( AV55CallToActionEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractionadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(82), 2, 0)+","+"null"+");", bttBtnuseractionadd_Caption, bttBtnuseractionadd_Jsonclick, 5, context.GetMessage( "Add", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTIONADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsdt_calltoactionstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_calltoactionsContainer.SetWrapped(nGXWrapped);
            StartGridControl82( ) ;
         }
         if ( wbEnd == 82 )
         {
            wbEnd = 0;
            nRC_GXsfl_82 = (int)(nGXsfl_82_idx-1);
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV78GXV1 = nGXsfl_82_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridsdt_calltoactionspaginationbar.SetProperty("Class", Gridsdt_calltoactionspaginationbar_Class);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowFirst", Gridsdt_calltoactionspaginationbar_Showfirst);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowPrevious", Gridsdt_calltoactionspaginationbar_Showprevious);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowNext", Gridsdt_calltoactionspaginationbar_Shownext);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowLast", Gridsdt_calltoactionspaginationbar_Showlast);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagesToShow", Gridsdt_calltoactionspaginationbar_Pagestoshow);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagingButtonsPosition", Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagingCaptionPosition", Gridsdt_calltoactionspaginationbar_Pagingcaptionposition);
            ucGridsdt_calltoactionspaginationbar.SetProperty("EmptyGridClass", Gridsdt_calltoactionspaginationbar_Emptygridclass);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageSelector", Gridsdt_calltoactionspaginationbar_Rowsperpageselector);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageOptions", Gridsdt_calltoactionspaginationbar_Rowsperpageoptions);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Previous", Gridsdt_calltoactionspaginationbar_Previous);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Next", Gridsdt_calltoactionspaginationbar_Next);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Caption", Gridsdt_calltoactionspaginationbar_Caption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("EmptyGridCaption", Gridsdt_calltoactionspaginationbar_Emptygridcaption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageCaption", Gridsdt_calltoactionspaginationbar_Rowsperpagecaption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("CurrentPage", AV70GridSDT_CallToActionsCurrentPage);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PageCount", AV71GridSDT_CallToActionsPageCount);
            ucGridsdt_calltoactionspaginationbar.SetProperty("AppliedFilters", AV72GridSDT_CallToActionsAppliedFilters);
            ucGridsdt_calltoactionspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsdt_calltoactionspaginationbar_Internalname, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBARContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationdynamicformid_Internalname, AV56LocationDynamicFormId.ToString(), AV56LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationdynamicformid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationdynamicformid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_CallToAction.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionid_Internalname, AV51CallToActionId.ToString(), AV51CallToActionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCalltoactionid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_CallToAction.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpformreferencename_Internalname, AV54WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( AV54WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformreferencename_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformreferencename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
            wb_table1_105_752( true) ;
         }
         else
         {
            wb_table1_105_752( false) ;
         }
         return  ;
      }

      protected void wb_table1_105_752e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridsdt_calltoactions_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_calltoactions_empowerer_Internalname, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 82 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV78GXV1 = nGXsfl_82_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START752( )
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
            Form.Meta.addItem("description", context.GetMessage( " Trn_Call To Action", ""), 0) ;
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
               STRUP750( ) ;
            }
         }
      }

      protected void WS752( )
      {
         START752( ) ;
         EVT752( ) ;
      }

      protected void EVT752( )
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
                                 STRUP750( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_locationdynamicformid.Onoptionclicked */
                                    E12752 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdt_calltoactionspaginationbar.Changepage */
                                    E13752 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdt_calltoactionspaginationbar.Changerowsperpage */
                                    E14752 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useractiondelete.Close */
                                    E15752 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserActionAdd' */
                                    E16752 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRIDSDT_CALLTOACTIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP750( ) ;
                              }
                              nGXsfl_82_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
                              SubsflControlProps_822( ) ;
                              AV78GXV1 = (int)(nGXsfl_82_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                              if ( ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && ( AV78GXV1 > 0 ) )
                              {
                                 AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1));
                                 AV39CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                                 AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
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
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E17752 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E18752 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_calltoactions.Load */
                                          E19752 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E20752 ();
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
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP750( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
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

      protected void WE752( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm752( ) ;
            }
         }
      }

      protected void PA752( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_calltoaction.aspx")), "wc_calltoaction.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_calltoaction.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "OrganisationId");
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
               GX_FocusControl = cmbavCalltoactiontype_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_calltoactions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_822( ) ;
         while ( nGXsfl_82_idx <= nRC_GXsfl_82 )
         {
            sendrow_822( ) ;
            nGXsfl_82_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_82_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_822( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_calltoactionsContainer)) ;
         /* End function gxnrGridsdt_calltoactions_newrow */
      }

      protected void gxgrGridsdt_calltoactions_refresh( int subGridsdt_calltoactions_Rows ,
                                                        Guid A58ProductServiceId ,
                                                        Guid AV67ProductServiceId ,
                                                        Guid A367CallToActionId ,
                                                        string A397CallToActionName ,
                                                        string A370CallToActionPhone ,
                                                        string A369CallToActionEmail ,
                                                        string A368CallToActionType ,
                                                        string A396CallToActionUrl ,
                                                        Guid A395LocationDynamicFormId ,
                                                        string A208WWPFormReferenceName ,
                                                        Guid A11OrganisationId ,
                                                        Guid A29LocationId ,
                                                        GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV68SDT_CallToAction ,
                                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
         RF752( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdt_calltoactions_refresh */
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
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
            AV52CallToActionType = cmbavCalltoactiontype.getValidValue(AV52CallToActionType);
            AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF752( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      protected void RF752( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_calltoactionsContainer.ClearRows();
         }
         wbStart = 82;
         /* Execute user event: Refresh */
         E18752 ();
         nGXsfl_82_idx = 1;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_822( ) ;
         bGXsfl_82_Refreshing = true;
         Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_calltoactionsContainer.PageSize = subGridsdt_calltoactions_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_822( ) ;
            /* Execute user event: Gridsdt_calltoactions.Load */
            E19752 ();
            if ( ( subGridsdt_calltoactions_Islastpage == 0 ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord > 0 ) && ( GRIDSDT_CALLTOACTIONS_nGridOutOfScope == 0 ) && ( nGXsfl_82_idx == 1 ) )
            {
               GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
               GRIDSDT_CALLTOACTIONS_nGridOutOfScope = 1;
               subgridsdt_calltoactions_firstpage( ) ;
               /* Execute user event: Gridsdt_calltoactions.Load */
               E19752 ();
            }
            wbEnd = 82;
            WB750( ) ;
         }
         bGXsfl_82_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes752( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
      }

      protected int subGridsdt_calltoactions_fnc_Pagecount( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordcount( )
      {
         return AV68SDT_CallToAction.Count ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordsperpage( )
      {
         if ( subGridsdt_calltoactions_Rows > 0 )
         {
            return subGridsdt_calltoactions_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_calltoactions_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_calltoactions_firstpage( )
      {
         GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_nextpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ( GRIDSDT_CALLTOACTIONS_nRecordCount >= subGridsdt_calltoactions_fnc_Recordsperpage( ) ) && ( GRIDSDT_CALLTOACTIONS_nEOF == 0 ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_CALLTOACTIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_calltoactions_previouspage( )
      {
         if ( GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage >= subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage-subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_lastpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( GRIDSDT_CALLTOACTIONS_nRecordCount > subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-subGridsdt_calltoactions_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_calltoactions_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(subGridsdt_calltoactions_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP750( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17752 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_calltoaction"), AV68SDT_CallToAction);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV32DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONDYNAMICFORMID_DATA"), AV59LocationDynamicFormId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_CALLTOACTION"), AV68SDT_CallToAction);
            /* Read saved values. */
            nRC_GXsfl_82 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_82"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridSDT_CallToActionsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV71GridSDT_CallToActionsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV72GridSDT_CallToActionsAppliedFilters = cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSAPPLIEDFILTERS");
            wcpOAV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV65OrganisationId"));
            wcpOAV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV66LocationId"));
            wcpOAV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV67ProductServiceId"));
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_calltoactions_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
            Combo_locationdynamicformid_Cls = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Cls");
            Combo_locationdynamicformid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_set");
            Combo_locationdynamicformid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Emptyitem"));
            Gridsdt_calltoactionspaginationbar_Class = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Class");
            Gridsdt_calltoactionspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showfirst"));
            Gridsdt_calltoactionspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showprevious"));
            Gridsdt_calltoactionspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Shownext"));
            Gridsdt_calltoactionspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showlast"));
            Gridsdt_calltoactionspaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingbuttonsposition");
            Gridsdt_calltoactionspaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingcaptionposition");
            Gridsdt_calltoactionspaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridclass");
            Gridsdt_calltoactionspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselector"));
            Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsdt_calltoactionspaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageoptions");
            Gridsdt_calltoactionspaginationbar_Previous = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Previous");
            Gridsdt_calltoactionspaginationbar_Next = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Next");
            Gridsdt_calltoactionspaginationbar_Caption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Caption");
            Gridsdt_calltoactionspaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridcaption");
            Gridsdt_calltoactionspaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpagecaption");
            Dvelop_confirmpanel_useractiondelete_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title");
            Dvelop_confirmpanel_useractiondelete_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext");
            Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_useractiondelete_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype");
            Gridsdt_calltoactions_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Gridinternalname");
            Gridsdt_calltoactionspaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage");
            Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_useractiondelete_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result");
            Combo_locationdynamicformid_Ddointernalname = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname");
            Combo_locationdynamicformid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get");
            nRC_GXsfl_82 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_82"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_82_fel_idx = 0;
            while ( nGXsfl_82_fel_idx < nRC_GXsfl_82 )
            {
               nGXsfl_82_fel_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_82_fel_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_fel_idx+1);
               sGXsfl_82_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_822( ) ;
               AV78GXV1 = (int)(nGXsfl_82_fel_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               if ( ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && ( AV78GXV1 > 0 ) )
               {
                  AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1));
                  AV39CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_82_fel_idx == 0 )
            {
               nGXsfl_82_idx = 1;
               sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
               SubsflControlProps_822( ) ;
            }
            nGXsfl_82_fel_idx = 1;
            /* Read variables values. */
            cmbavCalltoactiontype.Name = cmbavCalltoactiontype_Internalname;
            cmbavCalltoactiontype.CurrentValue = cgiGet( cmbavCalltoactiontype_Internalname);
            AV52CallToActionType = cgiGet( cmbavCalltoactiontype_Internalname);
            AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
            AV53CallToActionName = cgiGet( edtavCalltoactionname_Internalname);
            AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
            AV58CallToActionUrl = cgiGet( edtavCalltoactionurl_Internalname);
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = cgiGet( edtavCalltoactionphone_Internalname);
            AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
            AV55CallToActionEmail = cgiGet( edtavCalltoactionemail_Internalname);
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationdynamicformid_Internalname), "") == 0 )
            {
               AV56LocationDynamicFormId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  AV56LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtavLocationdynamicformid_Internalname));
                  AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONDYNAMICFORMID");
                  GX_FocusControl = edtavLocationdynamicformid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCalltoactionid_Internalname), "") == 0 )
            {
               AV51CallToActionId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
            }
            else
            {
               try
               {
                  AV51CallToActionId = StringUtil.StrToGuid( cgiGet( edtavCalltoactionid_Internalname));
                  AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCALLTOACTIONID");
                  GX_FocusControl = edtavCalltoactionid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV54WWPFormReferenceName = cgiGet( edtavWwpformreferencename_Internalname);
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
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
         E17752 ();
         if (returnInSub) return;
      }

      protected void E17752( )
      {
         /* Start Routine */
         returnInSub = false;
         divTableinsert_Visible = 0;
         AssignProp(sPrefix, false, divTableinsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinsert_Visible), 5, 0), true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV32DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV32DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavLocationdynamicformid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationdynamicformid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationdynamicformid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONDYNAMICFORMID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         edtavCalltoactionid_Visible = 0;
         AssignProp(sPrefix, false, edtavCalltoactionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCalltoactionid_Visible), 5, 0), true);
         edtavWwpformreferencename_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformreferencename_Visible), 5, 0), true);
         Gridsdt_calltoactions_empowerer_Gridinternalname = subGridsdt_calltoactions_Internalname;
         ucGridsdt_calltoactions_empowerer.SendProperty(context, sPrefix, false, Gridsdt_calltoactions_empowerer_Internalname, "GridInternalName", Gridsdt_calltoactions_empowerer_Gridinternalname);
         subGridsdt_calltoactions_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = subGridsdt_calltoactions_Rows;
         ucGridsdt_calltoactionspaginationbar.SendProperty(context, sPrefix, false, Gridsdt_calltoactionspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Execute user subroutine: 'SET VISIBLE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E18752( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV68SDT_CallToAction.Clear();
         gx_BV82 = true;
         /* Using cursor H00752 */
         pr_default.execute(0, new Object[] {AV67ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = H00752_A206WWPFormId[0];
            A207WWPFormVersionNumber = H00752_A207WWPFormVersionNumber[0];
            A58ProductServiceId = H00752_A58ProductServiceId[0];
            A367CallToActionId = H00752_A367CallToActionId[0];
            A397CallToActionName = H00752_A397CallToActionName[0];
            A370CallToActionPhone = H00752_A370CallToActionPhone[0];
            A369CallToActionEmail = H00752_A369CallToActionEmail[0];
            A368CallToActionType = H00752_A368CallToActionType[0];
            A396CallToActionUrl = H00752_A396CallToActionUrl[0];
            A395LocationDynamicFormId = H00752_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = H00752_n395LocationDynamicFormId[0];
            A208WWPFormReferenceName = H00752_A208WWPFormReferenceName[0];
            A11OrganisationId = H00752_A11OrganisationId[0];
            A29LocationId = H00752_A29LocationId[0];
            A206WWPFormId = H00752_A206WWPFormId[0];
            A207WWPFormVersionNumber = H00752_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = H00752_A208WWPFormReferenceName[0];
            AV74GridSDT_CallToAction = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
            AV74GridSDT_CallToAction.gxTpr_Calltoactionid = A367CallToActionId;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionname = A397CallToActionName;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionphone = A370CallToActionPhone;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionemail = A369CallToActionEmail;
            AV74GridSDT_CallToAction.gxTpr_Calltoactiontype = A368CallToActionType;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionurl = A396CallToActionUrl;
            AV74GridSDT_CallToAction.gxTpr_Locationdynamicformid = A395LocationDynamicFormId;
            AV74GridSDT_CallToAction.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
            AV74GridSDT_CallToAction.gxTpr_Organisationid = A11OrganisationId;
            AV74GridSDT_CallToAction.gxTpr_Locationid = A29LocationId;
            AV74GridSDT_CallToAction.gxTpr_Productserviceid = A58ProductServiceId;
            AV68SDT_CallToAction.Add(AV74GridSDT_CallToAction, 0);
            gx_BV82 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV70GridSDT_CallToActionsCurrentPage = subGridsdt_calltoactions_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV70GridSDT_CallToActionsCurrentPage", StringUtil.LTrimStr( (decimal)(AV70GridSDT_CallToActionsCurrentPage), 10, 0));
         AV71GridSDT_CallToActionsPageCount = subGridsdt_calltoactions_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV71GridSDT_CallToActionsPageCount", StringUtil.LTrimStr( (decimal)(AV71GridSDT_CallToActionsPageCount), 10, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
      }

      private void E19752( )
      {
         /* Gridsdt_calltoactions_Load Routine */
         returnInSub = false;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV68SDT_CallToAction.Count )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
            }
            else if ( ! (Guid.Empty==((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Wwpformreferencename;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
            }
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Update", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 82;
            }
            if ( ( subGridsdt_calltoactions_Islastpage == 1 ) || ( subGridsdt_calltoactions_Rows == 0 ) || ( ( GRIDSDT_CALLTOACTIONS_nCurrentRecord >= GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord < GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage + subGridsdt_calltoactions_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_822( ) ;
            }
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(((GRIDSDT_CALLTOACTIONS_nCurrentRecord<GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, ".", "")));
            GRIDSDT_CALLTOACTIONS_nCurrentRecord = (long)(GRIDSDT_CALLTOACTIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_82_Refreshing )
            {
               DoAjaxLoad(82, Gridsdt_calltoactionsRow);
            }
            AV78GXV1 = (int)(AV78GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
      }

      protected void E13752( )
      {
         /* Gridsdt_calltoactionspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdt_calltoactionspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdt_calltoactions_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdt_calltoactionspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV69PageToGo = subGridsdt_calltoactions_fnc_Currentpage( );
            AV69PageToGo = (int)(AV69PageToGo+1);
            subgridsdt_calltoactions_gotopage( AV69PageToGo) ;
         }
         else
         {
            AV69PageToGo = (int)(Math.Round(NumberUtil.Val( Gridsdt_calltoactionspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgridsdt_calltoactions_gotopage( AV69PageToGo) ;
         }
      }

      protected void E14752( )
      {
         /* Gridsdt_calltoactionspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdt_calltoactions_Rows = Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         subgridsdt_calltoactions_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E20752( )
      {
         AV78GXV1 = (int)(nGXsfl_82_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1));
         }
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV76GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO USERACTIONDELETE' */
            S142 ();
            if (returnInSub) return;
         }
         else if ( AV76GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONUPDATE' */
            S152 ();
            if (returnInSub) return;
         }
         AV76GridActionGroup1 = 0;
         AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
         AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
      }

      protected void E15752( )
      {
         AV78GXV1 = (int)(nGXsfl_82_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1));
         }
         /* Dvelop_confirmpanel_useractiondelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractiondelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONDELETE' */
            S162 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
         nGXsfl_82_bak_idx = nGXsfl_82_idx;
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
         nGXsfl_82_idx = nGXsfl_82_bak_idx;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_822( ) ;
      }

      protected void E16752( )
      {
         /* 'DoUserActionAdd' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S172 ();
         if (returnInSub) return;
         if ( AV77CheckRequiredFieldsResult )
         {
            AV62Trn_CallToAction = new SdtTrn_CallToAction(context);
            AV62Trn_CallToAction.gxTpr_Productserviceid = AV67ProductServiceId;
            if ( (Guid.Empty==AV51CallToActionId) )
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionid = Guid.NewGuid( );
            }
            else
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionid = AV51CallToActionId;
            }
            AV62Trn_CallToAction.gxTpr_Calltoactionname = AV53CallToActionName;
            AV62Trn_CallToAction.gxTpr_Calltoactiontype = AV52CallToActionType;
            AV62Trn_CallToAction.gxTpr_Calltoactionemail = AV55CallToActionEmail;
            AV62Trn_CallToAction.gxTpr_Calltoactionphone = AV57CallToActionPhone;
            AV62Trn_CallToAction.gxTpr_Calltoactionurl = AV58CallToActionUrl;
            AV62Trn_CallToAction.gxTpr_Organisationid = AV65OrganisationId;
            AV62Trn_CallToAction.gxTpr_Locationid = AV66LocationId;
            if ( (Guid.Empty==AV56LocationDynamicFormId) )
            {
               AV62Trn_CallToAction.gxTv_SdtTrn_CallToAction_Locationdynamicformid_SetNull();
            }
            else
            {
               AV62Trn_CallToAction.gxTpr_Locationdynamicformid = AV56LocationDynamicFormId;
            }
            AV62Trn_CallToAction.InsertOrUpdate();
            if ( ! AV62Trn_CallToAction.Success() )
            {
               AV92GXV14 = 1;
               AV91GXV13 = AV62Trn_CallToAction.GetMessages();
               while ( AV92GXV14 <= AV91GXV13.Count )
               {
                  AV42Message = ((GeneXus.Utils.SdtMessages_Message)AV91GXV13.Item(AV92GXV14));
                  GX_msglist.addItem(AV42Message.gxTpr_Description);
                  AV92GXV14 = (int)(AV92GXV14+1);
               }
            }
            context.CommitDataStores("wc_calltoaction",pr_default);
            /* Execute user subroutine: 'CLEAR FORM' */
            S182 ();
            if (returnInSub) return;
            bttBtnuseractionadd_Caption = context.GetMessage( "Add", "");
            AssignProp(sPrefix, false, bttBtnuseractionadd_Internalname, "Caption", bttBtnuseractionadd_Caption, true);
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
         AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
         if ( gx_BV82 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
            nGXsfl_82_bak_idx = nGXsfl_82_idx;
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A367CallToActionId, A397CallToActionName, A370CallToActionPhone, A369CallToActionEmail, A368CallToActionType, A396CallToActionUrl, A395LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, sPrefix) ;
            nGXsfl_82_idx = nGXsfl_82_bak_idx;
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_822( ) ;
         }
      }

      protected void E12752( )
      {
         /* Combo_locationdynamicformid_Onoptionclicked Routine */
         returnInSub = false;
         AV56LocationDynamicFormId = StringUtil.StrToGuid( Combo_locationdynamicformid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S162( )
      {
         /* 'DO ACTION USERACTIONDELETE' Routine */
         returnInSub = false;
         new prc_deletecalltoaction(context ).execute(  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Organisationid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Productserviceid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionid) ;
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S152( )
      {
         /* 'DO USERACTIONUPDATE' Routine */
         returnInSub = false;
         divTableinsert_Visible = 1;
         AssignProp(sPrefix, false, divTableinsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinsert_Visible), 5, 0), true);
         AV51CallToActionId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionid;
         AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
         AV53CallToActionName = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionname;
         AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         AV57CallToActionPhone = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone;
         AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
         AV58CallToActionUrl = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
         AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
         AV56LocationDynamicFormId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid;
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         AV55CallToActionEmail = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
         AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
         AV52CallToActionType = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactiontype;
         AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
         /* Execute user subroutine: 'SET VISIBLE' */
         S132 ();
         if (returnInSub) return;
         bttBtnuseractionadd_Caption = context.GetMessage( "save", "");
         AssignProp(sPrefix, false, bttBtnuseractionadd_Internalname, "Caption", bttBtnuseractionadd_Caption, true);
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV77CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV58CallToActionUrl)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Url", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionurl_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV57CallToActionPhone)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Phone", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionphone_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 ) ) && (Guid.Empty==AV56LocationDynamicFormId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Form", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_locationdynamicformid_Ddointernalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV55CallToActionEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionemail_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 )
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp(sPrefix, false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         else
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 )
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         else
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 )
         {
            divCalltoactionphone_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp(sPrefix, false, divCalltoactionphone_cell_Internalname, "Class", divCalltoactionphone_cell_Class, true);
         }
         else
         {
            divCalltoactionphone_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divCalltoactionphone_cell_Internalname, "Class", divCalltoactionphone_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 )
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp(sPrefix, false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
         else
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLOCATIONDYNAMICFORMID' Routine */
         returnInSub = false;
         AV94GXV16 = 1;
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 = AV93GXV15;
         new dp_locationdynamicform(context ).execute( out  GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2) ;
         AV93GXV15 = GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2;
         while ( AV94GXV16 <= AV93GXV15.Count )
         {
            AV61LocationDynamicFormId_DPItem = ((SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem)AV93GXV15.Item(AV94GXV16));
            AV60Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV60Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV61LocationDynamicFormId_DPItem.gxTpr_Locationdynamicformid.ToString());
            AV60Combo_DataItem.gxTpr_Title = AV61LocationDynamicFormId_DPItem.gxTpr_Wwpformreferencename;
            AV59LocationDynamicFormId_Data.Add(AV60Combo_DataItem, 0);
            AV94GXV16 = (int)(AV94GXV16+1);
         }
         AV59LocationDynamicFormId_Data.Sort("Title");
         Combo_locationdynamicformid_Selectedvalue_set = ((Guid.Empty==AV56LocationDynamicFormId) ? "" : StringUtil.Trim( AV56LocationDynamicFormId.ToString()));
         ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
      }

      protected void S182( )
      {
         /* 'CLEAR FORM' Routine */
         returnInSub = false;
         AV51CallToActionId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
         AV53CallToActionName = "";
         AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         AV57CallToActionPhone = "";
         AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
         AV58CallToActionUrl = "";
         AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
         AV56LocationDynamicFormId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         AV55CallToActionEmail = "";
         AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
         AV52CallToActionType = "";
         AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
      }

      protected void S132( )
      {
         /* 'SET VISIBLE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Call us", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTablephone_Visible = 1;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV55CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Email us", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableemail_Visible = 1;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Fill Request Form", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 1;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
            AV55CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Visit Site", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableurl_Visible = 1;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV57CallToActionPhone", AV57CallToActionPhone);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
      }

      protected void wb_table1_105_752( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractiondelete_Internalname, tblTabledvelop_confirmpanel_useractiondelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractiondelete.SetProperty("Title", Dvelop_confirmpanel_useractiondelete_Title);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractiondelete_Confirmationtext);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractiondelete_Nobuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractiondelete_Yesbuttonposition);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmType", Dvelop_confirmpanel_useractiondelete_Confirmtype);
            ucDvelop_confirmpanel_useractiondelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractiondelete_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_105_752e( true) ;
         }
         else
         {
            wb_table1_105_752e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV65OrganisationId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
         AV66LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
         AV67ProductServiceId = (Guid)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
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
         PA752( ) ;
         WS752( ) ;
         WE752( ) ;
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
         sCtrlAV65OrganisationId = (string)((string)getParm(obj,0));
         sCtrlAV66LocationId = (string)((string)getParm(obj,1));
         sCtrlAV67ProductServiceId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA752( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_calltoaction", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA752( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV65OrganisationId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
            AV66LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
            AV67ProductServiceId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
         }
         wcpOAV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV65OrganisationId"));
         wcpOAV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV66LocationId"));
         wcpOAV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV67ProductServiceId"));
         if ( ! GetJustCreated( ) && ( ( AV65OrganisationId != wcpOAV65OrganisationId ) || ( AV66LocationId != wcpOAV66LocationId ) || ( AV67ProductServiceId != wcpOAV67ProductServiceId ) ) )
         {
            setjustcreated();
         }
         wcpOAV65OrganisationId = AV65OrganisationId;
         wcpOAV66LocationId = AV66LocationId;
         wcpOAV67ProductServiceId = AV67ProductServiceId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV65OrganisationId = cgiGet( sPrefix+"AV65OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV65OrganisationId) > 0 )
         {
            AV65OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV65OrganisationId));
            AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
         }
         else
         {
            AV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV65OrganisationId_PARM"));
         }
         sCtrlAV66LocationId = cgiGet( sPrefix+"AV66LocationId_CTRL");
         if ( StringUtil.Len( sCtrlAV66LocationId) > 0 )
         {
            AV66LocationId = StringUtil.StrToGuid( cgiGet( sCtrlAV66LocationId));
            AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
         }
         else
         {
            AV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV66LocationId_PARM"));
         }
         sCtrlAV67ProductServiceId = cgiGet( sPrefix+"AV67ProductServiceId_CTRL");
         if ( StringUtil.Len( sCtrlAV67ProductServiceId) > 0 )
         {
            AV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sCtrlAV67ProductServiceId));
            AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
         }
         else
         {
            AV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV67ProductServiceId_PARM"));
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
         PA752( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS752( ) ;
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
         WS752( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV65OrganisationId_PARM", AV65OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV65OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV65OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV65OrganisationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV66LocationId_PARM", AV66LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV66LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV66LocationId_CTRL", StringUtil.RTrim( sCtrlAV66LocationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV67ProductServiceId_PARM", AV67ProductServiceId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV67ProductServiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV67ProductServiceId_CTRL", StringUtil.RTrim( sCtrlAV67ProductServiceId));
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
         WE752( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112515561478", true, true);
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
         context.AddJavascriptSource("wc_calltoaction.js", "?2024112515561479", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_822( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_82_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_82_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_82_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_82_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_82_idx;
      }

      protected void SubsflControlProps_fel_822( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_82_fel_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_82_fel_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_82_fel_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_82_fel_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_82_fel_idx;
      }

      protected void sendrow_822( )
      {
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_822( ) ;
         WB750( ) ;
         if ( ( subGridsdt_calltoactions_Rows * 1 == 0 ) || ( nGXsfl_82_idx <= subGridsdt_calltoactions_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_calltoactionsRow = GXWebRow.GetNew(context,Gridsdt_calltoactionsContainer);
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               subGridsdt_calltoactions_Backcolor = subGridsdt_calltoactions_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Uniform";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
               subGridsdt_calltoactions_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( ((int)((nGXsfl_82_idx) % (2))) == 0 )
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_82_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__organisationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__productserviceid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Productserviceid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Productserviceid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__productserviceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__productserviceid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',82)\"";
            if ( ( cmbavSdt_calltoaction__calltoactiontype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_82_idx;
               cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
               cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
               cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
               if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
               {
                  if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype)) )
                  {
                     ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype = cmbavSdt_calltoaction__calltoactiontype.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_calltoaction__calltoactiontype,(string)cmbavSdt_calltoaction__calltoactiontype_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype),(short)1,(string)cmbavSdt_calltoaction__calltoactiontype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_calltoaction__calltoactiontype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_calltoaction__calltoactiontype.CurrentValue = StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype);
            AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Values", (string)(cmbavSdt_calltoaction__calltoactiontype.ToJavascriptSource()), !bGXsfl_82_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionname_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_calltoaction__calltoactionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphone_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionphone),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionurl_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionurl,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionurl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionurl_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionemail_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactionemail,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationdynamicformid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Locationdynamicformid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Locationdynamicformid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationdynamicformid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationdynamicformid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__wwpformreferencename_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Wwpformreferencename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__wwpformreferencename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__wwpformreferencename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCalltoactionvariable_Internalname,(string)AV39CallToActionVariable,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCalltoactionvariable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCalltoactionvariable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'" + sGXsfl_82_idx + "',82)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_82_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && (0==AV76GridActionGroup1) )
                  {
                     AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_82_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_82_Refreshing);
            send_integrity_lvl_hashes752( ) ;
            Gridsdt_calltoactionsContainer.AddRow(Gridsdt_calltoactionsRow);
            nGXsfl_82_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_82_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_822( ) ;
         }
         /* End function sendrow_822 */
      }

      protected void init_web_controls( )
      {
         cmbavCalltoactiontype.Name = "vCALLTOACTIONTYPE";
         cmbavCalltoactiontype.WebTags = "";
         cmbavCalltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavCalltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavCalltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavCalltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
         }
         GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_82_idx;
         cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
         cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
         cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
         {
            if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV78GXV1)).gxTpr_Calltoactiontype)) )
            {
            }
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_82_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV78GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV78GXV1 ) && (0==AV76GridActionGroup1) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl82( )
      {
         if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"DivS\" data-gxgridid=\"82\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_calltoactions_Internalname, subGridsdt_calltoactions_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               subGridsdt_calltoactions_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
               }
            }
            else
            {
               subGridsdt_calltoactions_Titlebackstyle = 1;
               if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
               {
                  subGridsdt_calltoactions_Titlebackcolor = subGridsdt_calltoactions_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Label", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Dynamic Form Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWPForm Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         }
         else
         {
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Header", subGridsdt_calltoactions_Header);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV39CallToActionVariable));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76GridActionGroup1), 4, 0, ".", ""))));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectedindex), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowselection), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowhovering), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnuseractioninsert_Internalname = sPrefix+"BTNUSERACTIONINSERT";
         cmbavCalltoactiontype_Internalname = sPrefix+"vCALLTOACTIONTYPE";
         edtavCalltoactionname_Internalname = sPrefix+"vCALLTOACTIONNAME";
         edtavCalltoactionurl_Internalname = sPrefix+"vCALLTOACTIONURL";
         divCalltoactionurl_cell_Internalname = sPrefix+"CALLTOACTIONURL_CELL";
         divTableurl_Internalname = sPrefix+"TABLEURL";
         edtavCalltoactionphone_Internalname = sPrefix+"vCALLTOACTIONPHONE";
         divCalltoactionphone_cell_Internalname = sPrefix+"CALLTOACTIONPHONE_CELL";
         divTablephone_Internalname = sPrefix+"TABLEPHONE";
         lblTextblockcombo_locationdynamicformid_Internalname = sPrefix+"TEXTBLOCKCOMBO_LOCATIONDYNAMICFORMID";
         Combo_locationdynamicformid_Internalname = sPrefix+"COMBO_LOCATIONDYNAMICFORMID";
         divTablesplittedlocationdynamicformid_Internalname = sPrefix+"TABLESPLITTEDLOCATIONDYNAMICFORMID";
         divCombo_locationdynamicformid_cell_Internalname = sPrefix+"COMBO_LOCATIONDYNAMICFORMID_CELL";
         divTableform_Internalname = sPrefix+"TABLEFORM";
         edtavCalltoactionemail_Internalname = sPrefix+"vCALLTOACTIONEMAIL";
         divCalltoactionemail_cell_Internalname = sPrefix+"CALLTOACTIONEMAIL_CELL";
         divTableemail_Internalname = sPrefix+"TABLEEMAIL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         bttBtnuseractionadd_Internalname = sPrefix+"BTNUSERACTIONADD";
         divTableinsert_Internalname = sPrefix+"TABLEINSERT";
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID";
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID";
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID";
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID";
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE";
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME";
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE";
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL";
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL";
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID";
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME";
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE";
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1";
         Gridsdt_calltoactionspaginationbar_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR";
         divGridsdt_calltoactionstablewithpaginationbar_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONSTABLEWITHPAGINATIONBAR";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavLocationdynamicformid_Internalname = sPrefix+"vLOCATIONDYNAMICFORMID";
         edtavCalltoactionid_Internalname = sPrefix+"vCALLTOACTIONID";
         edtavWwpformreferencename_Internalname = sPrefix+"vWWPFORMREFERENCENAME";
         Dvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE";
         tblTabledvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTIONDELETE";
         Gridsdt_calltoactions_empowerer_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_calltoactions_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS";
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
         subGridsdt_calltoactions_Allowcollapsing = 0;
         subGridsdt_calltoactions_Allowselection = 0;
         subGridsdt_calltoactions_Header = "";
         cmbavGridactiongroup1_Jsonclick = "";
         edtavCalltoactionvariable_Jsonclick = "";
         edtavCalltoactionvariable_Enabled = 1;
         edtavSdt_calltoaction__wwpformreferencename_Jsonclick = "";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Jsonclick = "";
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype_Jsonclick = "";
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Jsonclick = "";
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Jsonclick = "";
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Jsonclick = "";
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionid_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         subGridsdt_calltoactions_Class = "GridWithPaginationBar WorkWith";
         subGridsdt_calltoactions_Backcolorstyle = 0;
         edtavWwpformreferencename_Jsonclick = "";
         edtavWwpformreferencename_Visible = 1;
         edtavCalltoactionid_Jsonclick = "";
         edtavCalltoactionid_Visible = 1;
         edtavLocationdynamicformid_Jsonclick = "";
         edtavLocationdynamicformid_Visible = 1;
         bttBtnuseractionadd_Caption = context.GetMessage( "Add", "");
         edtavCalltoactionemail_Jsonclick = "";
         edtavCalltoactionemail_Enabled = 1;
         divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6";
         divTableemail_Visible = 1;
         Combo_locationdynamicformid_Caption = "";
         divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6";
         divTableform_Visible = 1;
         edtavCalltoactionphone_Jsonclick = "";
         edtavCalltoactionphone_Enabled = 1;
         divCalltoactionphone_cell_Class = "col-xs-12 col-sm-6";
         divTablephone_Visible = 1;
         edtavCalltoactionurl_Jsonclick = "";
         edtavCalltoactionurl_Enabled = 1;
         divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6";
         divTableurl_Visible = 1;
         edtavCalltoactionname_Jsonclick = "";
         edtavCalltoactionname_Invitemessage = "";
         edtavCalltoactionname_Enabled = 1;
         cmbavCalltoactiontype_Jsonclick = "";
         cmbavCalltoactiontype.Enabled = 1;
         divTableinsert_Visible = 1;
         Dvelop_confirmpanel_useractiondelete_Confirmtype = "1";
         Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractiondelete_Confirmationtext = "Are you sure you want to delete?";
         Dvelop_confirmpanel_useractiondelete_Title = context.GetMessage( "Delete", "");
         Gridsdt_calltoactionspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdt_calltoactionspaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridsdt_calltoactionspaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridsdt_calltoactionspaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdt_calltoactionspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdt_calltoactionspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = 10;
         Gridsdt_calltoactionspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdt_calltoactionspaginationbar_Pagingcaptionposition = "Left";
         Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition = "Right";
         Gridsdt_calltoactionspaginationbar_Pagestoshow = 5;
         Gridsdt_calltoactionspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdt_calltoactionspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdt_calltoactionspaginationbar_Class = "PaginationBar";
         Combo_locationdynamicformid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationdynamicformid_Cls = "ExtendedCombo Attribute";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = -1;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionemail_Enabled = -1;
         edtavSdt_calltoaction__calltoactionurl_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphone_Enabled = -1;
         edtavSdt_calltoaction__calltoactionname_Enabled = -1;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = -1;
         edtavSdt_calltoaction__productserviceid_Enabled = -1;
         edtavSdt_calltoaction__locationid_Enabled = -1;
         edtavSdt_calltoaction__organisationid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionid_Enabled = -1;
         subGridsdt_calltoactions_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A367CallToActionId","fld":"CALLTOACTIONID"},{"av":"A397CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A370CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A369CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A368CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A396CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD","""{"handler":"E19752","iparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD",""","oparms":[{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE"},{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E13752","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A367CallToActionId","fld":"CALLTOACTIONID"},{"av":"A397CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A370CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A369CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A368CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A396CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"sPrefix"},{"av":"Gridsdt_calltoactionspaginationbar_Selectedpage","ctrl":"GRIDSDT_CALLTOACTIONSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E14752","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A367CallToActionId","fld":"CALLTOACTIONID"},{"av":"A397CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A370CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A369CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A368CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A396CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"sPrefix"},{"av":"Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSDT_CALLTOACTIONSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"}]}""");
         setEventMetadata("'DOUSERACTIONINSERT'","""{"handler":"E11751","iparms":[]""");
         setEventMetadata("'DOUSERACTIONINSERT'",""","oparms":[{"av":"divTableinsert_Visible","ctrl":"TABLEINSERT","prop":"Visible"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E20752","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"divTableinsert_Visible","ctrl":"TABLEINSERT","prop":"Visible"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV57CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"},{"ctrl":"BTNUSERACTIONADD","prop":"Caption"},{"av":"edtavCalltoactionname_Invitemessage","ctrl":"vCALLTOACTIONNAME","prop":"Invitemessage"},{"av":"divTableurl_Visible","ctrl":"TABLEURL","prop":"Visible"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"av":"divTableform_Visible","ctrl":"TABLEFORM","prop":"Visible"},{"av":"divTablephone_Visible","ctrl":"TABLEPHONE","prop":"Visible"},{"av":"AV54WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE","""{"handler":"E15752","iparms":[{"av":"Dvelop_confirmpanel_useractiondelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONDELETE","prop":"Result"},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A367CallToActionId","fld":"CALLTOACTIONID"},{"av":"A397CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A370CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A369CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A368CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A396CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"sPrefix"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE",""","oparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTIONADD'","""{"handler":"E16752","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A367CallToActionId","fld":"CALLTOACTIONID"},{"av":"A397CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A370CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A369CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A368CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A396CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"sPrefix"},{"av":"AV77CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV57CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV65OrganisationId","fld":"vORGANISATIONID"},{"av":"AV66LocationId","fld":"vLOCATIONID"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"Combo_locationdynamicformid_Ddointernalname","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"DDOInternalName"}]""");
         setEventMetadata("'DOUSERACTIONADD'",""","oparms":[{"ctrl":"BTNUSERACTIONADD","prop":"Caption"},{"av":"AV77CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV57CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":82,"hsh":true},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":82},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED","""{"handler":"E12752","iparms":[{"av":"Combo_locationdynamicformid_Selectedvalue_get","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED",""","oparms":[{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"}]}""");
         setEventMetadata("VALIDV_CALLTOACTIONTYPE","""{"handler":"Validv_Calltoactiontype","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONURL","""{"handler":"Validv_Calltoactionurl","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONEMAIL","""{"handler":"Validv_Calltoactionemail","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONDYNAMICFORMID","""{"handler":"Validv_Locationdynamicformid","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONID","""{"handler":"Validv_Calltoactionid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
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
         wcpOAV65OrganisationId = Guid.Empty;
         wcpOAV66LocationId = Guid.Empty;
         wcpOAV67ProductServiceId = Guid.Empty;
         Gridsdt_calltoactionspaginationbar_Selectedpage = "";
         Dvelop_confirmpanel_useractiondelete_Result = "";
         Combo_locationdynamicformid_Ddointernalname = "";
         Combo_locationdynamicformid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A58ProductServiceId = Guid.Empty;
         A367CallToActionId = Guid.Empty;
         A397CallToActionName = "";
         A370CallToActionPhone = "";
         A369CallToActionEmail = "";
         A368CallToActionType = "";
         A396CallToActionUrl = "";
         A395LocationDynamicFormId = Guid.Empty;
         A208WWPFormReferenceName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV68SDT_CallToAction = new GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToActionItem", "Comforta_version2");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV59LocationDynamicFormId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV72GridSDT_CallToActionsAppliedFilters = "";
         Combo_locationdynamicformid_Selectedvalue_set = "";
         Gridsdt_calltoactions_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnuseractioninsert_Jsonclick = "";
         AV52CallToActionType = "";
         AV53CallToActionName = "";
         AV58CallToActionUrl = "";
         AV57CallToActionPhone = "";
         lblTextblockcombo_locationdynamicformid_Jsonclick = "";
         ucCombo_locationdynamicformid = new GXUserControl();
         AV55CallToActionEmail = "";
         bttBtnuseractionadd_Jsonclick = "";
         Gridsdt_calltoactionsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridsdt_calltoactionspaginationbar = new GXUserControl();
         AV56LocationDynamicFormId = Guid.Empty;
         AV51CallToActionId = Guid.Empty;
         AV54WWPFormReferenceName = "";
         ucGridsdt_calltoactions_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV39CallToActionVariable = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H00752_A206WWPFormId = new short[1] ;
         H00752_A207WWPFormVersionNumber = new short[1] ;
         H00752_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00752_A367CallToActionId = new Guid[] {Guid.Empty} ;
         H00752_A397CallToActionName = new string[] {""} ;
         H00752_A370CallToActionPhone = new string[] {""} ;
         H00752_A369CallToActionEmail = new string[] {""} ;
         H00752_A368CallToActionType = new string[] {""} ;
         H00752_A396CallToActionUrl = new string[] {""} ;
         H00752_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H00752_n395LocationDynamicFormId = new bool[] {false} ;
         H00752_A208WWPFormReferenceName = new string[] {""} ;
         H00752_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00752_A29LocationId = new Guid[] {Guid.Empty} ;
         AV74GridSDT_CallToAction = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         Gridsdt_calltoactionsRow = new GXWebRow();
         AV62Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV91GXV13 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV42Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV93GXV15 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         AV61LocationDynamicFormId_DPItem = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
         AV60Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         ucDvelop_confirmpanel_useractiondelete = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV65OrganisationId = "";
         sCtrlAV66LocationId = "";
         sCtrlAV67ProductServiceId = "";
         subGridsdt_calltoactions_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_calltoactionsColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__default(),
            new Object[][] {
                new Object[] {
               H00752_A206WWPFormId, H00752_A207WWPFormVersionNumber, H00752_A58ProductServiceId, H00752_A367CallToActionId, H00752_A397CallToActionName, H00752_A370CallToActionPhone, H00752_A369CallToActionEmail, H00752_A368CallToActionType, H00752_A396CallToActionUrl, H00752_A395LocationDynamicFormId,
               H00752_n395LocationDynamicFormId, H00752_A208WWPFormReferenceName, H00752_A11OrganisationId, H00752_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      private short GRIDSDT_CALLTOACTIONS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV76GridActionGroup1 ;
      private short nDonePA ;
      private short subGridsdt_calltoactions_Backcolorstyle ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short nGXWrapped ;
      private short subGridsdt_calltoactions_Backstyle ;
      private short subGridsdt_calltoactions_Titlebackstyle ;
      private short subGridsdt_calltoactions_Allowselection ;
      private short subGridsdt_calltoactions_Allowhovering ;
      private short subGridsdt_calltoactions_Allowcollapsing ;
      private short subGridsdt_calltoactions_Collapsed ;
      private int Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_82 ;
      private int subGridsdt_calltoactions_Rows ;
      private int nGXsfl_82_idx=1 ;
      private int edtavSdt_calltoaction__calltoactionid_Enabled ;
      private int edtavSdt_calltoaction__organisationid_Enabled ;
      private int edtavSdt_calltoaction__locationid_Enabled ;
      private int edtavSdt_calltoaction__productserviceid_Enabled ;
      private int edtavSdt_calltoaction__calltoactionname_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphone_Enabled ;
      private int edtavSdt_calltoaction__calltoactionurl_Enabled ;
      private int edtavSdt_calltoaction__calltoactionemail_Enabled ;
      private int edtavSdt_calltoaction__locationdynamicformid_Enabled ;
      private int edtavSdt_calltoaction__wwpformreferencename_Enabled ;
      private int edtavCalltoactionvariable_Enabled ;
      private int Gridsdt_calltoactionspaginationbar_Pagestoshow ;
      private int divTableinsert_Visible ;
      private int edtavCalltoactionname_Enabled ;
      private int divTableurl_Visible ;
      private int edtavCalltoactionurl_Enabled ;
      private int divTablephone_Visible ;
      private int edtavCalltoactionphone_Enabled ;
      private int divTableform_Visible ;
      private int divTableemail_Visible ;
      private int edtavCalltoactionemail_Enabled ;
      private int AV78GXV1 ;
      private int edtavLocationdynamicformid_Visible ;
      private int edtavCalltoactionid_Visible ;
      private int edtavWwpformreferencename_Visible ;
      private int subGridsdt_calltoactions_Islastpage ;
      private int GRIDSDT_CALLTOACTIONS_nGridOutOfScope ;
      private int nGXsfl_82_fel_idx=1 ;
      private int AV69PageToGo ;
      private int nGXsfl_82_bak_idx=1 ;
      private int AV92GXV14 ;
      private int AV94GXV16 ;
      private int idxLst ;
      private int subGridsdt_calltoactions_Backcolor ;
      private int subGridsdt_calltoactions_Allbackcolor ;
      private int subGridsdt_calltoactions_Titlebackcolor ;
      private int subGridsdt_calltoactions_Selectedindex ;
      private int subGridsdt_calltoactions_Selectioncolor ;
      private int subGridsdt_calltoactions_Hoveringcolor ;
      private long GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ;
      private long AV70GridSDT_CallToActionsCurrentPage ;
      private long AV71GridSDT_CallToActionsPageCount ;
      private long GRIDSDT_CALLTOACTIONS_nCurrentRecord ;
      private long GRIDSDT_CALLTOACTIONS_nRecordCount ;
      private string Gridsdt_calltoactionspaginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_useractiondelete_Result ;
      private string Combo_locationdynamicformid_Ddointernalname ;
      private string Combo_locationdynamicformid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_82_idx="0001" ;
      private string A370CallToActionPhone ;
      private string edtavSdt_calltoaction__calltoactionid_Internalname ;
      private string edtavSdt_calltoaction__organisationid_Internalname ;
      private string edtavSdt_calltoaction__locationid_Internalname ;
      private string edtavSdt_calltoaction__productserviceid_Internalname ;
      private string cmbavSdt_calltoaction__calltoactiontype_Internalname ;
      private string edtavSdt_calltoaction__calltoactionname_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphone_Internalname ;
      private string edtavSdt_calltoaction__calltoactionurl_Internalname ;
      private string edtavSdt_calltoaction__calltoactionemail_Internalname ;
      private string edtavSdt_calltoaction__locationdynamicformid_Internalname ;
      private string edtavSdt_calltoaction__wwpformreferencename_Internalname ;
      private string edtavCalltoactionvariable_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_locationdynamicformid_Cls ;
      private string Combo_locationdynamicformid_Selectedvalue_set ;
      private string Gridsdt_calltoactionspaginationbar_Class ;
      private string Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition ;
      private string Gridsdt_calltoactionspaginationbar_Pagingcaptionposition ;
      private string Gridsdt_calltoactionspaginationbar_Emptygridclass ;
      private string Gridsdt_calltoactionspaginationbar_Rowsperpageoptions ;
      private string Gridsdt_calltoactionspaginationbar_Previous ;
      private string Gridsdt_calltoactionspaginationbar_Next ;
      private string Gridsdt_calltoactionspaginationbar_Caption ;
      private string Gridsdt_calltoactionspaginationbar_Emptygridcaption ;
      private string Gridsdt_calltoactionspaginationbar_Rowsperpagecaption ;
      private string Dvelop_confirmpanel_useractiondelete_Title ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmationtext ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmtype ;
      private string Gridsdt_calltoactions_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnuseractioninsert_Internalname ;
      private string bttBtnuseractioninsert_Jsonclick ;
      private string divTableinsert_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableattributes_Internalname ;
      private string cmbavCalltoactiontype_Internalname ;
      private string cmbavCalltoactiontype_Jsonclick ;
      private string edtavCalltoactionname_Internalname ;
      private string edtavCalltoactionname_Invitemessage ;
      private string edtavCalltoactionname_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divTableurl_Internalname ;
      private string divCalltoactionurl_cell_Internalname ;
      private string divCalltoactionurl_cell_Class ;
      private string edtavCalltoactionurl_Internalname ;
      private string edtavCalltoactionurl_Jsonclick ;
      private string divTablephone_Internalname ;
      private string divCalltoactionphone_cell_Internalname ;
      private string divCalltoactionphone_cell_Class ;
      private string edtavCalltoactionphone_Internalname ;
      private string AV57CallToActionPhone ;
      private string edtavCalltoactionphone_Jsonclick ;
      private string divTableform_Internalname ;
      private string divCombo_locationdynamicformid_cell_Internalname ;
      private string divCombo_locationdynamicformid_cell_Class ;
      private string divTablesplittedlocationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Jsonclick ;
      private string Combo_locationdynamicformid_Caption ;
      private string Combo_locationdynamicformid_Internalname ;
      private string divTableemail_Internalname ;
      private string divCalltoactionemail_cell_Internalname ;
      private string divCalltoactionemail_cell_Class ;
      private string edtavCalltoactionemail_Internalname ;
      private string edtavCalltoactionemail_Jsonclick ;
      private string bttBtnuseractionadd_Internalname ;
      private string bttBtnuseractionadd_Caption ;
      private string bttBtnuseractionadd_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divGridsdt_calltoactionstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsdt_calltoactions_Internalname ;
      private string Gridsdt_calltoactionspaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLocationdynamicformid_Internalname ;
      private string edtavLocationdynamicformid_Jsonclick ;
      private string edtavCalltoactionid_Internalname ;
      private string edtavCalltoactionid_Jsonclick ;
      private string edtavWwpformreferencename_Internalname ;
      private string edtavWwpformreferencename_Jsonclick ;
      private string Gridsdt_calltoactions_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_82_fel_idx="0001" ;
      private string tblTabledvelop_confirmpanel_useractiondelete_Internalname ;
      private string Dvelop_confirmpanel_useractiondelete_Internalname ;
      private string sCtrlAV65OrganisationId ;
      private string sCtrlAV66LocationId ;
      private string sCtrlAV67ProductServiceId ;
      private string subGridsdt_calltoactions_Class ;
      private string subGridsdt_calltoactions_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_calltoaction__calltoactionid_Jsonclick ;
      private string edtavSdt_calltoaction__organisationid_Jsonclick ;
      private string edtavSdt_calltoaction__locationid_Jsonclick ;
      private string edtavSdt_calltoaction__productserviceid_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_calltoaction__calltoactiontype_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionname_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphone_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionurl_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionemail_Jsonclick ;
      private string edtavSdt_calltoaction__locationdynamicformid_Jsonclick ;
      private string edtavSdt_calltoaction__wwpformreferencename_Jsonclick ;
      private string edtavCalltoactionvariable_Jsonclick ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGridsdt_calltoactions_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n395LocationDynamicFormId ;
      private bool bGXsfl_82_Refreshing=false ;
      private bool AV77CheckRequiredFieldsResult ;
      private bool Combo_locationdynamicformid_Emptyitem ;
      private bool Gridsdt_calltoactionspaginationbar_Showfirst ;
      private bool Gridsdt_calltoactionspaginationbar_Showprevious ;
      private bool Gridsdt_calltoactionspaginationbar_Shownext ;
      private bool Gridsdt_calltoactionspaginationbar_Showlast ;
      private bool Gridsdt_calltoactionspaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV82 ;
      private string A397CallToActionName ;
      private string A369CallToActionEmail ;
      private string A368CallToActionType ;
      private string A396CallToActionUrl ;
      private string A208WWPFormReferenceName ;
      private string AV72GridSDT_CallToActionsAppliedFilters ;
      private string AV52CallToActionType ;
      private string AV53CallToActionName ;
      private string AV58CallToActionUrl ;
      private string AV55CallToActionEmail ;
      private string AV54WWPFormReferenceName ;
      private string AV39CallToActionVariable ;
      private Guid AV65OrganisationId ;
      private Guid AV66LocationId ;
      private Guid AV67ProductServiceId ;
      private Guid wcpOAV65OrganisationId ;
      private Guid wcpOAV66LocationId ;
      private Guid wcpOAV67ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid A367CallToActionId ;
      private Guid A395LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV56LocationDynamicFormId ;
      private Guid AV51CallToActionId ;
      private GXWebGrid Gridsdt_calltoactionsContainer ;
      private GXWebRow Gridsdt_calltoactionsRow ;
      private GXWebColumn Gridsdt_calltoactionsColumn ;
      private GXUserControl ucCombo_locationdynamicformid ;
      private GXUserControl ucGridsdt_calltoactionspaginationbar ;
      private GXUserControl ucGridsdt_calltoactions_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_useractiondelete ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCalltoactiontype ;
      private GXCombobox cmbavSdt_calltoaction__calltoactiontype ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV68SDT_CallToAction ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV32DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV59LocationDynamicFormId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00752_A206WWPFormId ;
      private short[] H00752_A207WWPFormVersionNumber ;
      private Guid[] H00752_A58ProductServiceId ;
      private Guid[] H00752_A367CallToActionId ;
      private string[] H00752_A397CallToActionName ;
      private string[] H00752_A370CallToActionPhone ;
      private string[] H00752_A369CallToActionEmail ;
      private string[] H00752_A368CallToActionType ;
      private string[] H00752_A396CallToActionUrl ;
      private Guid[] H00752_A395LocationDynamicFormId ;
      private bool[] H00752_n395LocationDynamicFormId ;
      private string[] H00752_A208WWPFormReferenceName ;
      private Guid[] H00752_A11OrganisationId ;
      private Guid[] H00752_A29LocationId ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV74GridSDT_CallToAction ;
      private SdtTrn_CallToAction AV62Trn_CallToAction ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV91GXV13 ;
      private GeneXus.Utils.SdtMessages_Message AV42Message ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> AV93GXV15 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 ;
      private SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem AV61LocationDynamicFormId_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV60Combo_DataItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wc_calltoaction__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wc_calltoaction__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wc_calltoaction__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmH00752;
       prmH00752 = new Object[] {
       new ParDef("AV67ProductServiceId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00752", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.ProductServiceId, T1.CallToActionId, T1.CallToActionName, T1.CallToActionPhone, T1.CallToActionEmail, T1.CallToActionType, T1.CallToActionUrl, T1.LocationDynamicFormId, T3.WWPFormReferenceName, T1.OrganisationId, T1.LocationId FROM ((Trn_CallToAction T1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = T1.LocationDynamicFormId AND T2.OrganisationId = T1.OrganisationId AND T2.LocationId = T1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE T1.ProductServiceId = :AV67ProductServiceId ORDER BY T1.ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00752,100, GxCacheFrequency.OFF ,false,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((Guid[]) buf[12])[0] = rslt.getGuid(12);
             ((Guid[]) buf[13])[0] = rslt.getGuid(13);
             return;
    }
 }

}

}
