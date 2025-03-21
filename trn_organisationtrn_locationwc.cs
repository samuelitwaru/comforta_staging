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
   public class trn_organisationtrn_locationwc : GXWebComponent
   {
      public trn_organisationtrn_locationwc( )
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

      public trn_organisationtrn_locationwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
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
         cmbavActiongroup = new GXCombobox();
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
                  AV8OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV8OrganisationId", AV8OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV8OrganisationId});
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV44Pgmname = GetPar( "Pgmname");
         AV21TFLocationName = GetPar( "TFLocationName");
         AV22TFLocationName_Sel = GetPar( "TFLocationName_Sel");
         AV25TFLocationEmail = GetPar( "TFLocationEmail");
         AV26TFLocationEmail_Sel = GetPar( "TFLocationEmail_Sel");
         AV23TFLocationPhone = GetPar( "TFLocationPhone");
         AV24TFLocationPhone_Sel = GetPar( "TFLocationPhone_Sel");
         AV37IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV38IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV39IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV42IsAuthorized_LocationBranding = StringUtil.StrToBool( GetPar( "IsAuthorized_LocationBranding"));
         AV35IsAuthorized_LocationName = StringUtil.StrToBool( GetPar( "IsAuthorized_LocationName"));
         AV40IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PABI2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV44Pgmname = "Trn_OrganisationTrn_LocationWC";
               edtavLocationaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationaddress_Enabled), 5, 0), !bGXsfl_35_Refreshing);
               WSBI2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Organisation Trn_Location WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GXEncryptionTmp = "trn_organisationtrn_locationwc.aspx"+UrlEncode(AV8OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisationtrn_locationwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DISPLAY", AV37IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( sPrefix, AV37IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV38IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV39IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONBRANDING", AV42IsAuthorized_LocationBranding);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONBRANDING", GetSecureSignedToken( sPrefix, AV42IsAuthorized_LocationBranding, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONNAME", AV35IsAuthorized_LocationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONNAME", GetSecureSignedToken( sPrefix, AV35IsAuthorized_LocationName, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV40IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV40IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV34GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8OrganisationId", wcpOAV8OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONNAME", AV21TFLocationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONNAME_SEL", AV22TFLocationName_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONEMAIL", AV25TFLocationEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONEMAIL_SEL", AV26TFLocationEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONPHONE", StringUtil.RTrim( AV23TFLocationPhone));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOCATIONPHONE_SEL", StringUtil.RTrim( AV24TFLocationPhone_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV8OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DISPLAY", AV37IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( sPrefix, AV37IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV38IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV39IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONBRANDING", AV42IsAuthorized_LocationBranding);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONBRANDING", GetSecureSignedToken( sPrefix, AV42IsAuthorized_LocationBranding, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONNAME", AV35IsAuthorized_LocationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONNAME", GetSecureSignedToken( sPrefix, AV35IsAuthorized_LocationName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV40IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV40IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormBI2( )
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
         return "Trn_OrganisationTrn_LocationWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Organisation Trn_Location WC", "") ;
      }

      protected void WBBI0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_organisationtrn_locationwc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divLocationstable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationTrn_LocationWC.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_OrganisationTrn_LocationWC.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV32GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV33GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV34GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBI2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Organisation Trn_Location WC", ""), 0) ;
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
               STRUPBI0( ) ;
            }
         }
      }

      protected void WSBI2( )
      {
         STARTBI2( ) ;
         EVTBI2( ) ;
      }

      protected void EVTBI2( )
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
                                 STRUPBI0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11BI2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12BI2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13BI2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14BI2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E15BI2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLocationaddress_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'DOADDLOCATION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOINSERTLOCATION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBI0( ) ;
                              }
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A31LocationName = cgiGet( edtLocationName_Internalname);
                              A506LocationImage = cgiGet( edtLocationImage_Internalname);
                              AssignProp(sPrefix, false, edtLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), !bGXsfl_35_Refreshing);
                              AssignProp(sPrefix, false, edtLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
                              A359LocationCountry = cgiGet( edtLocationCountry_Internalname);
                              A338LocationCity = cgiGet( edtLocationCity_Internalname);
                              A339LocationZipCode = cgiGet( edtLocationZipCode_Internalname);
                              A340LocationAddressLine1 = cgiGet( edtLocationAddressLine1_Internalname);
                              A341LocationAddressLine2 = cgiGet( edtLocationAddressLine2_Internalname);
                              A34LocationEmail = cgiGet( edtLocationEmail_Internalname);
                              A383LocationPhoneCode = cgiGet( edtLocationPhoneCode_Internalname);
                              A384LocationPhoneNumber = cgiGet( edtLocationPhoneNumber_Internalname);
                              A35LocationPhone = cgiGet( edtLocationPhone_Internalname);
                              A36LocationDescription = cgiGet( edtLocationDescription_Internalname);
                              AV41LocationAddress = cgiGet( edtavLocationaddress_Internalname);
                              AssignAttri(sPrefix, false, edtavLocationaddress_Internalname, AV41LocationAddress);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV36ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV36ActionGroup), 4, 0));
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
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16BI2 ();
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
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E17BI2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E18BI2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E19BI2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOADDLOCATION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoAddLocation' */
                                          E20BI2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOINSERTLOCATION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoInsertLocation' */
                                          E21BI2 ();
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
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUPBI0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationaddress_Internalname;
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

      protected void WEBI2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBI2( ) ;
            }
         }
      }

      protected void PABI2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_organisationtrn_locationwc.aspx")), "trn_organisationtrn_locationwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_organisationtrn_locationwc.aspx")))) ;
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       Guid AV8OrganisationId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV44Pgmname ,
                                       string AV21TFLocationName ,
                                       string AV22TFLocationName_Sel ,
                                       string AV25TFLocationEmail ,
                                       string AV26TFLocationEmail_Sel ,
                                       string AV23TFLocationPhone ,
                                       string AV24TFLocationPhone_Sel ,
                                       bool AV37IsAuthorized_Display ,
                                       bool AV38IsAuthorized_Update ,
                                       bool AV39IsAuthorized_Delete ,
                                       bool AV42IsAuthorized_LocationBranding ,
                                       bool AV35IsAuthorized_LocationName ,
                                       bool AV40IsAuthorized_Insert ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBI2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LOCATIONID", GetSecureSignedToken( sPrefix, A29LocationId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
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
         RFBI2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "Trn_OrganisationTrn_LocationWC";
         edtavLocationaddress_Enabled = 0;
      }

      protected void RFBI2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E17BI2 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16FilterFullText ,
                                                 AV22TFLocationName_Sel ,
                                                 AV21TFLocationName ,
                                                 AV26TFLocationEmail_Sel ,
                                                 AV25TFLocationEmail ,
                                                 AV24TFLocationPhone_Sel ,
                                                 AV23TFLocationPhone ,
                                                 A31LocationName ,
                                                 A34LocationEmail ,
                                                 A35LocationPhone ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A11OrganisationId ,
                                                 AV8OrganisationId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
            lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
            lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
            lV21TFLocationName = StringUtil.Concat( StringUtil.RTrim( AV21TFLocationName), "%", "");
            lV25TFLocationEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFLocationEmail), "%", "");
            lV23TFLocationPhone = StringUtil.PadR( StringUtil.RTrim( AV23TFLocationPhone), 20, "%");
            /* Using cursor H00BI2 */
            pr_default.execute(0, new Object[] {AV8OrganisationId, lV16FilterFullText, lV16FilterFullText, lV16FilterFullText, lV21TFLocationName, AV22TFLocationName_Sel, lV25TFLocationEmail, AV26TFLocationEmail_Sel, lV23TFLocationPhone, AV24TFLocationPhone_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A36LocationDescription = H00BI2_A36LocationDescription[0];
               A35LocationPhone = H00BI2_A35LocationPhone[0];
               A384LocationPhoneNumber = H00BI2_A384LocationPhoneNumber[0];
               A383LocationPhoneCode = H00BI2_A383LocationPhoneCode[0];
               A34LocationEmail = H00BI2_A34LocationEmail[0];
               A341LocationAddressLine2 = H00BI2_A341LocationAddressLine2[0];
               A340LocationAddressLine1 = H00BI2_A340LocationAddressLine1[0];
               A339LocationZipCode = H00BI2_A339LocationZipCode[0];
               A338LocationCity = H00BI2_A338LocationCity[0];
               A359LocationCountry = H00BI2_A359LocationCountry[0];
               A40000LocationImage_GXI = H00BI2_A40000LocationImage_GXI[0];
               AssignProp(sPrefix, false, edtLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), !bGXsfl_35_Refreshing);
               AssignProp(sPrefix, false, edtLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
               A31LocationName = H00BI2_A31LocationName[0];
               A11OrganisationId = H00BI2_A11OrganisationId[0];
               A29LocationId = H00BI2_A29LocationId[0];
               A506LocationImage = H00BI2_A506LocationImage[0];
               AssignProp(sPrefix, false, edtLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), !bGXsfl_35_Refreshing);
               AssignProp(sPrefix, false, edtLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
               /* Execute user event: Grid.Load */
               E18BI2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WBBI0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBI2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DISPLAY", AV37IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( sPrefix, AV37IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV38IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV39IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONBRANDING", AV42IsAuthorized_LocationBranding);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONBRANDING", GetSecureSignedToken( sPrefix, AV42IsAuthorized_LocationBranding, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_LOCATIONNAME", AV35IsAuthorized_LocationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONNAME", GetSecureSignedToken( sPrefix, AV35IsAuthorized_LocationName, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LOCATIONID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sPrefix+sGXsfl_35_idx, A29LocationId, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV40IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV40IsAuthorized_Insert, context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV16FilterFullText ,
                                              AV22TFLocationName_Sel ,
                                              AV21TFLocationName ,
                                              AV26TFLocationEmail_Sel ,
                                              AV25TFLocationEmail ,
                                              AV24TFLocationPhone_Sel ,
                                              AV23TFLocationPhone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A11OrganisationId ,
                                              AV8OrganisationId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
         lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
         lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
         lV21TFLocationName = StringUtil.Concat( StringUtil.RTrim( AV21TFLocationName), "%", "");
         lV25TFLocationEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFLocationEmail), "%", "");
         lV23TFLocationPhone = StringUtil.PadR( StringUtil.RTrim( AV23TFLocationPhone), 20, "%");
         /* Using cursor H00BI3 */
         pr_default.execute(1, new Object[] {AV8OrganisationId, lV16FilterFullText, lV16FilterFullText, lV16FilterFullText, lV21TFLocationName, AV22TFLocationName_Sel, lV25TFLocationEmail, AV26TFLocationEmail_Sel, lV23TFLocationPhone, AV24TFLocationPhone_Sel});
         GRID_nRecordCount = H00BI3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8OrganisationId, AV20ManageFiltersExecutionStep, AV44Pgmname, AV21TFLocationName, AV22TFLocationName_Sel, AV25TFLocationEmail, AV26TFLocationEmail_Sel, AV23TFLocationPhone, AV24TFLocationPhone_Sel, AV37IsAuthorized_Display, AV38IsAuthorized_Update, AV39IsAuthorized_Delete, AV42IsAuthorized_LocationBranding, AV35IsAuthorized_LocationName, AV40IsAuthorized_Insert, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "Trn_OrganisationTrn_LocationWC";
         edtavLocationaddress_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationName_Enabled = 0;
         edtLocationImage_Enabled = 0;
         edtLocationCountry_Enabled = 0;
         edtLocationCity_Enabled = 0;
         edtLocationZipCode_Enabled = 0;
         edtLocationAddressLine1_Enabled = 0;
         edtLocationAddressLine2_Enabled = 0;
         edtLocationEmail_Enabled = 0;
         edtLocationPhoneCode_Enabled = 0;
         edtLocationPhoneNumber_Enabled = 0;
         edtLocationPhone_Enabled = 0;
         edtLocationDescription_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBI0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16BI2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV27DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV32GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV33GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV34GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV8OrganisationId"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( sPrefix+"DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E16BI2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16BI2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean1 = AV35IsAuthorized_LocationName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_locationview_Execute", out  GXt_boolean1) ;
         AV35IsAuthorized_LocationName = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV35IsAuthorized_LocationName", AV35IsAuthorized_LocationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONNAME", GetSecureSignedToken( sPrefix, AV35IsAuthorized_LocationName, context));
         AV29GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV30GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV29GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
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
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV27DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV27DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17BI2( )
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
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
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
         AV32GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV32GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridCurrentPage), 10, 0));
         AV33GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV33GridPageCount", StringUtil.LTrimStr( (decimal)(AV33GridPageCount), 10, 0));
         GXt_char3 = AV34GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV44Pgmname, out  GXt_char3) ;
         AV34GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV34GridAppliedFilters", AV34GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E12BI2( )
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
            AV31PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV31PageToGo) ;
         }
      }

      protected void E13BI2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14BI2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LocationName") == 0 )
            {
               AV21TFLocationName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFLocationName", AV21TFLocationName);
               AV22TFLocationName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFLocationName_Sel", AV22TFLocationName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LocationEmail") == 0 )
            {
               AV25TFLocationEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFLocationEmail", AV25TFLocationEmail);
               AV26TFLocationEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFLocationEmail_Sel", AV26TFLocationEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LocationPhone") == 0 )
            {
               AV23TFLocationPhone = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFLocationPhone", AV23TFLocationPhone);
               AV24TFLocationPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFLocationPhone_Sel", AV24TFLocationPhone_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18BI2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV37IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV38IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV39IsAuthorized_Delete )
         {
            cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( AV42IsAuthorized_LocationBranding )
         {
            cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Manage License", ""), "fas fa-gears", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavActiongroup.ItemCount == 1 )
         {
            cmbavActiongroup_Class = "Invisible";
         }
         else
         {
            cmbavActiongroup_Class = "ConvertToDDO";
         }
         if ( AV35IsAuthorized_LocationName )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_locationview.aspx"+UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtLocationName_Link = formatLink("trn_locationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         GXt_char3 = AV41LocationAddress;
         new prc_concatenateaddress(context ).execute(  A359LocationCountry,  A338LocationCity,  A339LocationZipCode,  A340LocationAddressLine1,  A341LocationAddressLine2, out  GXt_char3) ;
         AV41LocationAddress = GXt_char3;
         AssignAttri(sPrefix, false, edtavLocationaddress_Internalname, AV41LocationAddress);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 35;
         }
         sendrow_352( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36ActionGroup), 4, 0));
      }

      protected void E11BI2( )
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
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_OrganisationTrn_LocationWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV44Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_OrganisationTrn_LocationWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_OrganisationTrn_LocationWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV19ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E19BI2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV36ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV36ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV36ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV36ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO LOCATIONBRANDING' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV36ActionGroup = 0;
         AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV36ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36ActionGroup), 4, 0));
         AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E15BI2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV40IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createlocationandlicense.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("wp_createlocationandlicense.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV37IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_locationview_Execute", out  GXt_boolean1) ;
         AV37IsAuthorized_Display = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV37IsAuthorized_Display", AV37IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( sPrefix, AV37IsAuthorized_Display, context));
         GXt_boolean1 = AV38IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_location_Update", out  GXt_boolean1) ;
         AV38IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV38IsAuthorized_Update", AV38IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV38IsAuthorized_Update, context));
         GXt_boolean1 = AV39IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_location_Delete", out  GXt_boolean1) ;
         AV39IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV39IsAuthorized_Delete", AV39IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV39IsAuthorized_Delete, context));
         GXt_boolean1 = AV42IsAuthorized_LocationBranding;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_managelocationbranding_Execute", out  GXt_boolean1) ;
         AV42IsAuthorized_LocationBranding = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV42IsAuthorized_LocationBranding", AV42IsAuthorized_LocationBranding);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_LOCATIONBRANDING", GetSecureSignedToken( sPrefix, AV42IsAuthorized_LocationBranding, context));
         GXt_boolean1 = AV40IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_createlocationandlicense_Execute", out  GXt_boolean1) ;
         AV40IsAuthorized_Insert = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV40IsAuthorized_Insert", AV40IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV40IsAuthorized_Insert, context));
         if ( ! ( AV40IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_OrganisationTrn_LocationWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFLocationName = "";
         AssignAttri(sPrefix, false, "AV21TFLocationName", AV21TFLocationName);
         AV22TFLocationName_Sel = "";
         AssignAttri(sPrefix, false, "AV22TFLocationName_Sel", AV22TFLocationName_Sel);
         AV25TFLocationEmail = "";
         AssignAttri(sPrefix, false, "AV25TFLocationEmail", AV25TFLocationEmail);
         AV26TFLocationEmail_Sel = "";
         AssignAttri(sPrefix, false, "AV26TFLocationEmail_Sel", AV26TFLocationEmail_Sel);
         AV23TFLocationPhone = "";
         AssignAttri(sPrefix, false, "AV23TFLocationPhone", AV23TFLocationPhone);
         AV24TFLocationPhone_Sel = "";
         AssignAttri(sPrefix, false, "AV24TFLocationPhone_Sel", AV24TFLocationPhone_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV37IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_locationview.aspx"+UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_locationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV38IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_location.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_location.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV39IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_location.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_location.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S222( )
      {
         /* 'DO LOCATIONBRANDING' Routine */
         returnInSub = false;
         if ( AV42IsAuthorized_LocationBranding )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_managelocationbranding.aspx"+UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("wp_managelocationbranding.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV44Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV44Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV44Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME") == 0 )
            {
               AV21TFLocationName = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFLocationName", AV21TFLocationName);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME_SEL") == 0 )
            {
               AV22TFLocationName_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFLocationName_Sel", AV22TFLocationName_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL") == 0 )
            {
               AV25TFLocationEmail = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFLocationEmail", AV25TFLocationEmail);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL_SEL") == 0 )
            {
               AV26TFLocationEmail_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFLocationEmail_Sel", AV26TFLocationEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE") == 0 )
            {
               AV23TFLocationPhone = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFLocationPhone", AV23TFLocationPhone);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE_SEL") == 0 )
            {
               AV24TFLocationPhone_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFLocationPhone_Sel", AV24TFLocationPhone_Sel);
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)),  AV22TFLocationName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)),  AV26TFLocationEmail_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)),  AV24TFLocationPhone_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFLocationName)),  AV21TFLocationName, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFLocationEmail)),  AV25TFLocationEmail, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFLocationPhone)),  AV23TFLocationPhone, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV44Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFLOCATIONNAME",  context.GetMessage( "Location", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFLocationName)),  0,  AV21TFLocationName,  AV21TFLocationName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)),  AV22TFLocationName_Sel,  AV22TFLocationName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFLOCATIONEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFLocationEmail)),  0,  AV25TFLocationEmail,  AV25TFLocationEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)),  AV26TFLocationEmail_Sel,  AV26TFLocationEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFLOCATIONPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFLocationPhone)),  0,  AV23TFLocationPhone,  AV23TFLocationPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)),  AV24TFLocationPhone_Sel,  AV24TFLocationPhone_Sel) ;
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&ORGANISATIONID";
            AV13GridStateFilterValue.gxTpr_Value = AV8OrganisationId.ToString();
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV44Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Trn_Location";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "OrganisationId";
         AV11TrnContextAtt.gxTpr_Attributevalue = AV8OrganisationId.ToString();
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void E20BI2( )
      {
         /* 'DoAddLocation' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(AV8OrganisationId.ToString());
         CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E21BI2( )
      {
         /* 'DoInsertLocation' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(AV8OrganisationId.ToString());
         CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8OrganisationId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8OrganisationId", AV8OrganisationId.ToString());
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
         PABI2( ) ;
         WSBI2( ) ;
         WEBI2( ) ;
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
         sCtrlAV8OrganisationId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABI2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_organisationtrn_locationwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABI2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8OrganisationId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8OrganisationId", AV8OrganisationId.ToString());
         }
         wcpOAV8OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV8OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( AV8OrganisationId != wcpOAV8OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8OrganisationId = AV8OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8OrganisationId = cgiGet( sPrefix+"AV8OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV8OrganisationId) > 0 )
         {
            AV8OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV8OrganisationId));
            AssignAttri(sPrefix, false, "AV8OrganisationId", AV8OrganisationId.ToString());
         }
         else
         {
            AV8OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV8OrganisationId_PARM"));
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
         PABI2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBI2( ) ;
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
         WSBI2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8OrganisationId_PARM", AV8OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV8OrganisationId));
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
         WEBI2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253211340526", true, true);
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
         context.AddJavascriptSource("trn_organisationtrn_locationwc.js", "?20253211340528", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtLocationId_Internalname = sPrefix+"LOCATIONID_"+sGXsfl_35_idx;
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID_"+sGXsfl_35_idx;
         edtLocationName_Internalname = sPrefix+"LOCATIONNAME_"+sGXsfl_35_idx;
         edtLocationImage_Internalname = sPrefix+"LOCATIONIMAGE_"+sGXsfl_35_idx;
         edtLocationCountry_Internalname = sPrefix+"LOCATIONCOUNTRY_"+sGXsfl_35_idx;
         edtLocationCity_Internalname = sPrefix+"LOCATIONCITY_"+sGXsfl_35_idx;
         edtLocationZipCode_Internalname = sPrefix+"LOCATIONZIPCODE_"+sGXsfl_35_idx;
         edtLocationAddressLine1_Internalname = sPrefix+"LOCATIONADDRESSLINE1_"+sGXsfl_35_idx;
         edtLocationAddressLine2_Internalname = sPrefix+"LOCATIONADDRESSLINE2_"+sGXsfl_35_idx;
         edtLocationEmail_Internalname = sPrefix+"LOCATIONEMAIL_"+sGXsfl_35_idx;
         edtLocationPhoneCode_Internalname = sPrefix+"LOCATIONPHONECODE_"+sGXsfl_35_idx;
         edtLocationPhoneNumber_Internalname = sPrefix+"LOCATIONPHONENUMBER_"+sGXsfl_35_idx;
         edtLocationPhone_Internalname = sPrefix+"LOCATIONPHONE_"+sGXsfl_35_idx;
         edtLocationDescription_Internalname = sPrefix+"LOCATIONDESCRIPTION_"+sGXsfl_35_idx;
         edtavLocationaddress_Internalname = sPrefix+"vLOCATIONADDRESS_"+sGXsfl_35_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtLocationId_Internalname = sPrefix+"LOCATIONID_"+sGXsfl_35_fel_idx;
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID_"+sGXsfl_35_fel_idx;
         edtLocationName_Internalname = sPrefix+"LOCATIONNAME_"+sGXsfl_35_fel_idx;
         edtLocationImage_Internalname = sPrefix+"LOCATIONIMAGE_"+sGXsfl_35_fel_idx;
         edtLocationCountry_Internalname = sPrefix+"LOCATIONCOUNTRY_"+sGXsfl_35_fel_idx;
         edtLocationCity_Internalname = sPrefix+"LOCATIONCITY_"+sGXsfl_35_fel_idx;
         edtLocationZipCode_Internalname = sPrefix+"LOCATIONZIPCODE_"+sGXsfl_35_fel_idx;
         edtLocationAddressLine1_Internalname = sPrefix+"LOCATIONADDRESSLINE1_"+sGXsfl_35_fel_idx;
         edtLocationAddressLine2_Internalname = sPrefix+"LOCATIONADDRESSLINE2_"+sGXsfl_35_fel_idx;
         edtLocationEmail_Internalname = sPrefix+"LOCATIONEMAIL_"+sGXsfl_35_fel_idx;
         edtLocationPhoneCode_Internalname = sPrefix+"LOCATIONPHONECODE_"+sGXsfl_35_fel_idx;
         edtLocationPhoneNumber_Internalname = sPrefix+"LOCATIONPHONENUMBER_"+sGXsfl_35_fel_idx;
         edtLocationPhone_Internalname = sPrefix+"LOCATIONPHONE_"+sGXsfl_35_fel_idx;
         edtLocationDescription_Internalname = sPrefix+"LOCATIONDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtavLocationaddress_Internalname = sPrefix+"vLOCATIONADDRESS_"+sGXsfl_35_fel_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WBBI0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationName_Internalname,(string)A31LocationName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtLocationName_Link,(string)"",(string)"",(string)"",(string)edtLocationName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A506LocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A506LocationImage));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A506LocationImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationCountry_Internalname,(string)A359LocationCountry,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationCity_Internalname,(string)A338LocationCity,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationZipCode_Internalname,(string)A339LocationZipCode,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationAddressLine1_Internalname,(string)A340LocationAddressLine1,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationAddressLine2_Internalname,(string)A341LocationAddressLine2,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationEmail_Internalname,(string)A34LocationEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A34LocationEmail,(string)"",(string)"",(string)"",(string)edtLocationEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationPhoneCode_Internalname,(string)A383LocationPhoneCode,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationPhoneNumber_Internalname,(string)A384LocationPhoneNumber,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A35LocationPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationPhone_Internalname,StringUtil.RTrim( A35LocationPhone),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtLocationPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationDescription_Internalname,(string)A36LocationDescription,(string)A36LocationDescription,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)35,(short)0,(short)0,(short)-1,(bool)true,(string)"LongDescription",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationaddress_Internalname,(string)AV41LocationAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV41LocationAddress),(string)"_blank",(string)"",(string)"",(string)edtavLocationaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',35)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_35_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV36ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV36ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV36ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVACTIONGROUP.CLICK."+sGXsfl_35_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36ActionGroup), 4, 0));
            AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_35_Refreshing);
            send_integrity_lvl_hashesBI2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vACTIONGROUP_" + sGXsfl_35_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Image", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Country", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "City", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Zip Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address Line 1", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address Line 2", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A31LocationName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtLocationName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A506LocationImage));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A359LocationCountry));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A338LocationCity));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A339LocationZipCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A340LocationAddressLine1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A341LocationAddressLine2));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A34LocationEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A383LocationPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A384LocationPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A35LocationPhone)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A36LocationDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV41LocationAddress));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36ActionGroup), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtLocationId_Internalname = sPrefix+"LOCATIONID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtLocationName_Internalname = sPrefix+"LOCATIONNAME";
         edtLocationImage_Internalname = sPrefix+"LOCATIONIMAGE";
         edtLocationCountry_Internalname = sPrefix+"LOCATIONCOUNTRY";
         edtLocationCity_Internalname = sPrefix+"LOCATIONCITY";
         edtLocationZipCode_Internalname = sPrefix+"LOCATIONZIPCODE";
         edtLocationAddressLine1_Internalname = sPrefix+"LOCATIONADDRESSLINE1";
         edtLocationAddressLine2_Internalname = sPrefix+"LOCATIONADDRESSLINE2";
         edtLocationEmail_Internalname = sPrefix+"LOCATIONEMAIL";
         edtLocationPhoneCode_Internalname = sPrefix+"LOCATIONPHONECODE";
         edtLocationPhoneNumber_Internalname = sPrefix+"LOCATIONPHONENUMBER";
         edtLocationPhone_Internalname = sPrefix+"LOCATIONPHONE";
         edtLocationDescription_Internalname = sPrefix+"LOCATIONDESCRIPTION";
         edtavLocationaddress_Internalname = sPrefix+"vLOCATIONADDRESS";
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divLocationstable_Internalname = sPrefix+"LOCATIONSTABLE";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         cmbavActiongroup_Class = "ConvertToDDO";
         edtavLocationaddress_Jsonclick = "";
         edtavLocationaddress_Enabled = 1;
         edtLocationDescription_Jsonclick = "";
         edtLocationPhone_Jsonclick = "";
         edtLocationPhoneNumber_Jsonclick = "";
         edtLocationPhoneCode_Jsonclick = "";
         edtLocationEmail_Jsonclick = "";
         edtLocationAddressLine2_Jsonclick = "";
         edtLocationAddressLine1_Jsonclick = "";
         edtLocationZipCode_Jsonclick = "";
         edtLocationCity_Jsonclick = "";
         edtLocationCountry_Jsonclick = "";
         edtLocationName_Jsonclick = "";
         edtLocationName_Link = "";
         edtOrganisationId_Jsonclick = "";
         edtLocationId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtLocationDescription_Enabled = 0;
         edtLocationPhone_Enabled = 0;
         edtLocationPhoneNumber_Enabled = 0;
         edtLocationPhoneCode_Enabled = 0;
         edtLocationEmail_Enabled = 0;
         edtLocationAddressLine2_Enabled = 0;
         edtLocationAddressLine1_Enabled = 0;
         edtLocationZipCode_Enabled = 0;
         edtLocationCity_Enabled = 0;
         edtLocationCountry_Enabled = 0;
         edtLocationImage_Enabled = 0;
         edtLocationName_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_OrganisationTrn_LocationWCGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "2:LocationName|9:LocationEmail|12:LocationPhone";
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
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"sPrefix"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12BI2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13BI2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14BI2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E18BI2","iparms":[{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A359LocationCountry","fld":"LOCATIONCOUNTRY"},{"av":"A338LocationCity","fld":"LOCATIONCITY"},{"av":"A339LocationZipCode","fld":"LOCATIONZIPCODE"},{"av":"A340LocationAddressLine1","fld":"LOCATIONADDRESSLINE1"},{"av":"A341LocationAddressLine2","fld":"LOCATIONADDRESSLINE2"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV36ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtLocationName_Link","ctrl":"LOCATIONNAME","prop":"Link"},{"av":"AV41LocationAddress","fld":"vLOCATIONADDRESS"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11BI2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E19BI2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV36ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV36ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E15BI2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFLocationName","fld":"vTFLOCATIONNAME"},{"av":"AV22TFLocationName_Sel","fld":"vTFLOCATIONNAME_SEL"},{"av":"AV25TFLocationEmail","fld":"vTFLOCATIONEMAIL"},{"av":"AV26TFLocationEmail_Sel","fld":"vTFLOCATIONEMAIL_SEL"},{"av":"AV23TFLocationPhone","fld":"vTFLOCATIONPHONE"},{"av":"AV24TFLocationPhone_Sel","fld":"vTFLOCATIONPHONE_SEL"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV35IsAuthorized_LocationName","fld":"vISAUTHORIZED_LOCATIONNAME","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV37IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV38IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV39IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV42IsAuthorized_LocationBranding","fld":"vISAUTHORIZED_LOCATIONBRANDING","hsh":true},{"av":"AV40IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOADDLOCATION'","""{"handler":"E20BI2","iparms":[{"av":"AV8OrganisationId","fld":"vORGANISATIONID"}]""");
         setEventMetadata("'DOADDLOCATION'",""","oparms":[{"av":"AV8OrganisationId","fld":"vORGANISATIONID"}]}""");
         setEventMetadata("'DOINSERTLOCATION'","""{"handler":"E21BI2","iparms":[{"av":"AV8OrganisationId","fld":"vORGANISATIONID"}]""");
         setEventMetadata("'DOINSERTLOCATION'",""","oparms":[{"av":"AV8OrganisationId","fld":"vORGANISATIONID"}]}""");
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
         wcpOAV8OrganisationId = Guid.Empty;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV44Pgmname = "";
         AV21TFLocationName = "";
         AV22TFLocationName_Sel = "";
         AV25TFLocationEmail = "";
         AV26TFLocationEmail_Sel = "";
         AV23TFLocationPhone = "";
         AV24TFLocationPhone_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34GridAppliedFilters = "";
         AV27DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A31LocationName = "";
         A506LocationImage = "";
         A40000LocationImage_GXI = "";
         A359LocationCountry = "";
         A338LocationCity = "";
         A339LocationZipCode = "";
         A340LocationAddressLine1 = "";
         A341LocationAddressLine2 = "";
         A34LocationEmail = "";
         A383LocationPhoneCode = "";
         A384LocationPhoneNumber = "";
         A35LocationPhone = "";
         A36LocationDescription = "";
         AV41LocationAddress = "";
         GXDecQS = "";
         lV16FilterFullText = "";
         lV21TFLocationName = "";
         lV25TFLocationEmail = "";
         lV23TFLocationPhone = "";
         H00BI2_A36LocationDescription = new string[] {""} ;
         H00BI2_A35LocationPhone = new string[] {""} ;
         H00BI2_A384LocationPhoneNumber = new string[] {""} ;
         H00BI2_A383LocationPhoneCode = new string[] {""} ;
         H00BI2_A34LocationEmail = new string[] {""} ;
         H00BI2_A341LocationAddressLine2 = new string[] {""} ;
         H00BI2_A340LocationAddressLine1 = new string[] {""} ;
         H00BI2_A339LocationZipCode = new string[] {""} ;
         H00BI2_A338LocationCity = new string[] {""} ;
         H00BI2_A359LocationCountry = new string[] {""} ;
         H00BI2_A40000LocationImage_GXI = new string[] {""} ;
         H00BI2_A31LocationName = new string[] {""} ;
         H00BI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BI2_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BI2_A506LocationImage = new string[] {""} ;
         H00BI3_AGRID_nRecordCount = new long[1] ;
         AV29GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV30GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8OrganisationId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         gxphoneLink = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationtrn_locationwc__default(),
            new Object[][] {
                new Object[] {
               H00BI2_A36LocationDescription, H00BI2_A35LocationPhone, H00BI2_A384LocationPhoneNumber, H00BI2_A383LocationPhoneCode, H00BI2_A34LocationEmail, H00BI2_A341LocationAddressLine2, H00BI2_A340LocationAddressLine1, H00BI2_A339LocationZipCode, H00BI2_A338LocationCity, H00BI2_A359LocationCountry,
               H00BI2_A40000LocationImage_GXI, H00BI2_A31LocationName, H00BI2_A11OrganisationId, H00BI2_A29LocationId, H00BI2_A506LocationImage
               }
               , new Object[] {
               H00BI3_AGRID_nRecordCount
               }
            }
         );
         AV44Pgmname = "Trn_OrganisationTrn_LocationWC";
         /* GeneXus formulas. */
         AV44Pgmname = "Trn_OrganisationTrn_LocationWC";
         edtavLocationaddress_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV36ActionGroup ;
      private short nDonePA ;
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
      private int nRC_GXsfl_35 ;
      private int nGXsfl_35_idx=1 ;
      private int edtavLocationaddress_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationName_Enabled ;
      private int edtLocationImage_Enabled ;
      private int edtLocationCountry_Enabled ;
      private int edtLocationCity_Enabled ;
      private int edtLocationZipCode_Enabled ;
      private int edtLocationAddressLine1_Enabled ;
      private int edtLocationAddressLine2_Enabled ;
      private int edtLocationEmail_Enabled ;
      private int edtLocationPhoneCode_Enabled ;
      private int edtLocationPhoneNumber_Enabled ;
      private int edtLocationPhone_Enabled ;
      private int edtLocationDescription_Enabled ;
      private int AV31PageToGo ;
      private int AV45GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV32GridCurrentPage ;
      private long AV33GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_35_idx="0001" ;
      private string AV44Pgmname ;
      private string AV23TFLocationPhone ;
      private string AV24TFLocationPhone_Sel ;
      private string edtavLocationaddress_Internalname ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLocationstable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtLocationId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtLocationName_Internalname ;
      private string edtLocationImage_Internalname ;
      private string edtLocationCountry_Internalname ;
      private string edtLocationCity_Internalname ;
      private string edtLocationZipCode_Internalname ;
      private string edtLocationAddressLine1_Internalname ;
      private string edtLocationAddressLine2_Internalname ;
      private string edtLocationEmail_Internalname ;
      private string edtLocationPhoneCode_Internalname ;
      private string edtLocationPhoneNumber_Internalname ;
      private string A35LocationPhone ;
      private string edtLocationPhone_Internalname ;
      private string edtLocationDescription_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string GXDecQS ;
      private string lV23TFLocationPhone ;
      private string cmbavActiongroup_Class ;
      private string edtLocationName_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sCtrlAV8OrganisationId ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtLocationName_Jsonclick ;
      private string sImgUrl ;
      private string edtLocationCountry_Jsonclick ;
      private string edtLocationCity_Jsonclick ;
      private string edtLocationZipCode_Jsonclick ;
      private string edtLocationAddressLine1_Jsonclick ;
      private string edtLocationAddressLine2_Jsonclick ;
      private string edtLocationEmail_Jsonclick ;
      private string edtLocationPhoneCode_Jsonclick ;
      private string edtLocationPhoneNumber_Jsonclick ;
      private string gxphoneLink ;
      private string edtLocationPhone_Jsonclick ;
      private string edtLocationDescription_Jsonclick ;
      private string edtavLocationaddress_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV37IsAuthorized_Display ;
      private bool AV38IsAuthorized_Update ;
      private bool AV39IsAuthorized_Delete ;
      private bool AV42IsAuthorized_LocationBranding ;
      private bool AV35IsAuthorized_LocationName ;
      private bool AV40IsAuthorized_Insert ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private bool A506LocationImage_IsBlob ;
      private string A36LocationDescription ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV21TFLocationName ;
      private string AV22TFLocationName_Sel ;
      private string AV25TFLocationEmail ;
      private string AV26TFLocationEmail_Sel ;
      private string AV34GridAppliedFilters ;
      private string A31LocationName ;
      private string A40000LocationImage_GXI ;
      private string A359LocationCountry ;
      private string A338LocationCity ;
      private string A339LocationZipCode ;
      private string A340LocationAddressLine1 ;
      private string A341LocationAddressLine2 ;
      private string A34LocationEmail ;
      private string A383LocationPhoneCode ;
      private string A384LocationPhoneNumber ;
      private string AV41LocationAddress ;
      private string lV16FilterFullText ;
      private string lV21TFLocationName ;
      private string lV25TFLocationEmail ;
      private string A506LocationImage ;
      private Guid AV8OrganisationId ;
      private Guid wcpOAV8OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavActiongroup ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV27DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00BI2_A36LocationDescription ;
      private string[] H00BI2_A35LocationPhone ;
      private string[] H00BI2_A384LocationPhoneNumber ;
      private string[] H00BI2_A383LocationPhoneCode ;
      private string[] H00BI2_A34LocationEmail ;
      private string[] H00BI2_A341LocationAddressLine2 ;
      private string[] H00BI2_A340LocationAddressLine1 ;
      private string[] H00BI2_A339LocationZipCode ;
      private string[] H00BI2_A338LocationCity ;
      private string[] H00BI2_A359LocationCountry ;
      private string[] H00BI2_A40000LocationImage_GXI ;
      private string[] H00BI2_A31LocationName ;
      private Guid[] H00BI2_A11OrganisationId ;
      private Guid[] H00BI2_A29LocationId ;
      private string[] H00BI2_A506LocationImage ;
      private long[] H00BI3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV29GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_organisationtrn_locationwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BI2( IGxContext context ,
                                             string AV16FilterFullText ,
                                             string AV22TFLocationName_Sel ,
                                             string AV21TFLocationName ,
                                             string AV26TFLocationEmail_Sel ,
                                             string AV25TFLocationEmail ,
                                             string AV24TFLocationPhone_Sel ,
                                             string AV23TFLocationPhone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             Guid A11OrganisationId ,
                                             Guid AV8OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " LocationDescription, LocationPhone, LocationPhoneNumber, LocationPhoneCode, LocationEmail, LocationAddressLine2, LocationAddressLine1, LocationZipCode, LocationCity, LocationCountry, LocationImage_GXI, LocationName, OrganisationId, LocationId, LocationImage";
         sFromString = " FROM Trn_Location";
         sOrderString = "";
         AddWhere(sWhereString, "(OrganisationId = :AV8OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV16FilterFullText)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV16FilterFullText)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV16FilterFullText)))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFLocationName)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV21TFLocationName)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)) && ! ( StringUtil.StrCmp(AV22TFLocationName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV22TFLocationName_Sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFLocationName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFLocationEmail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV25TFLocationEmail)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFLocationEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV26TFLocationEmail_Sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFLocationEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFLocationPhone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV23TFLocationPhone)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)) && ! ( StringUtil.StrCmp(AV24TFLocationPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV24TFLocationPhone_Sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFLocationPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY OrganisationId, LocationName, LocationId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY OrganisationId DESC, LocationName DESC, LocationId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY OrganisationId, LocationEmail, LocationId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY OrganisationId DESC, LocationEmail DESC, LocationId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY OrganisationId, LocationPhone, LocationId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY OrganisationId DESC, LocationPhone DESC, LocationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY LocationId, OrganisationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00BI3( IGxContext context ,
                                             string AV16FilterFullText ,
                                             string AV22TFLocationName_Sel ,
                                             string AV21TFLocationName ,
                                             string AV26TFLocationEmail_Sel ,
                                             string AV25TFLocationEmail ,
                                             string AV24TFLocationPhone_Sel ,
                                             string AV23TFLocationPhone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             Guid A11OrganisationId ,
                                             Guid AV8OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV8OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV16FilterFullText)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV16FilterFullText)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV16FilterFullText)))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFLocationName)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV21TFLocationName)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFLocationName_Sel)) && ! ( StringUtil.StrCmp(AV22TFLocationName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV22TFLocationName_Sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFLocationName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFLocationEmail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV25TFLocationEmail)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFLocationEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFLocationEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV26TFLocationEmail_Sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFLocationEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFLocationPhone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV23TFLocationPhone)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFLocationPhone_Sel)) && ! ( StringUtil.StrCmp(AV24TFLocationPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV24TFLocationPhone_Sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFLocationPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H00BI2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 1 :
                     return conditional_H00BI3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
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
          Object[] prmH00BI2;
          prmH00BI2 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV21TFLocationName",GXType.VarChar,100,0) ,
          new ParDef("AV22TFLocationName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV25TFLocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV26TFLocationEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV23TFLocationPhone",GXType.Char,20,0) ,
          new ParDef("AV24TFLocationPhone_Sel",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00BI3;
          prmH00BI3 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV21TFLocationName",GXType.VarChar,100,0) ,
          new ParDef("AV22TFLocationName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV25TFLocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV26TFLocationEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV23TFLocationPhone",GXType.Char,20,0) ,
          new ParDef("AV24TFLocationPhone_Sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BI2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BI3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BI3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(11));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
