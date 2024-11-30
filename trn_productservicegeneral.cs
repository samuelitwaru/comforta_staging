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
   public class trn_productservicegeneral : GXWebComponent
   {
      public trn_productservicegeneral( )
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

      public trn_productservicegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.A58ProductServiceId = aP0_ProductServiceId;
         this.A29LocationId = aP1_LocationId;
         this.A11OrganisationId = aP2_OrganisationId;
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
         dynLocationId = new GXCombobox();
         cmbProductServiceClass = new GXCombobox();
         chkavListgen = new GXCheckbox();
         chkavListgenpre = new GXCheckbox();
         chkavListagb = new GXCheckbox();
         chkavListagbpre = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
                  A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A58ProductServiceId,(Guid)A29LocationId,(Guid)A11OrganisationId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
               {
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLALOCATIONID5C2( A11OrganisationId) ;
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
                  gxfirstwebparm = GetFirstPar( "ProductServiceId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
            PA5C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV30Pgmname = "Trn_ProductServiceGeneral";
               chkavListgen.Enabled = 0;
               AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
               edtavSuppliergen_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
               chkavListgenpre.Enabled = 0;
               AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
               chkavListagb.Enabled = 0;
               AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
               edtavSupplieragb_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
               chkavListagbpre.Enabled = 0;
               AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
               GXALOCATIONID_html5C2( A11OrganisationId) ;
               WS5C2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Product Service General", "")) ;
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
            GXEncryptionTmp = "trn_productservicegeneral.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_productservicegeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_ProductServiceGeneral");
         forbiddenHiddens.Add("ProductServiceGroup", StringUtil.RTrim( context.localUtil.Format( A366ProductServiceGroup, "")));
         AV23ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV23ListGen));
         AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         forbiddenHiddens.Add("ListGen", StringUtil.BoolToStr( AV23ListGen));
         AV22ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV22ListAgb));
         AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         forbiddenHiddens.Add("ListAgb", StringUtil.BoolToStr( AV22ListAgb));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_productservicegeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA58ProductServiceId", wcpOA58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm5C2( )
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
         return "Trn_ProductServiceGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Product Service General", "") ;
      }

      protected void WB5C0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_productservicegeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLocationid_cell_Internalname, 1, 0, "px", 0, "px", divLocationid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynLocationId.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynLocationId_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynLocationId.Visible, dynLocationId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", true, 0, "HLP_Trn_ProductServiceGeneral.htm");
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A59ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A59ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceTileName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceTileName_Internalname, context.GetMessage( "Tile Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductServiceTileName_Internalname, StringUtil.RTrim( A301ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( A301ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceTileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceTileName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductServiceImage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
            GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProductServiceClass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProductServiceClass_Internalname, context.GetMessage( "Group", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProductServiceClass, cmbProductServiceClass_Internalname, StringUtil.RTrim( A408ProductServiceClass), 1, cmbProductServiceClass_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbProductServiceClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Trn_ProductServiceGeneral.htm");
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A408ProductServiceClass);
            AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Values", (string)(cmbProductServiceClass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceGroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceGroup_Internalname, context.GetMessage( "Supplier", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProductServiceGroup_Internalname, A366ProductServiceGroup, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtProductServiceGroup_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTransactiondetail_tablegen_Internalname, divTransactiondetail_tablegen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_suppliergen_Internalname, divTransactiondetail_suppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergencompanyname_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergencompanyname_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblocksuppliergencompanyname_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_61_5C2( true) ;
         }
         else
         {
            wb_table1_61_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_61_5C2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTransactiondetail_suppliergenpre_Internalname, divTransactiondetail_suppliergenpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergen_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergen_id_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblocksuppliergen_id_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table2_81_5C2( true) ;
         }
         else
         {
            wb_table2_81_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_81_5C2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableagb_Internalname, divTransactiondetail_tableagb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_supplieragb_Internalname, divTransactiondetail_supplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbname_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbname_Internalname, context.GetMessage( "Agb Suppliers", ""), "", "", lblTextblocksupplieragbname_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table3_104_5C2( true) ;
         }
         else
         {
            wb_table3_104_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table3_104_5C2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTransactiondetail_supplieragbpre_Internalname, divTransactiondetail_supplieragbpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragb_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragb_id_Internalname, context.GetMessage( "Supplier Agb Id", ""), "", "", lblTextblocksupplieragb_id_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table4_124_5C2( true) ;
         }
         else
         {
            wb_table4_124_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table4_124_5C2e( bool wbgen )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 40, "chr", 5, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "LongDescription", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial hidden-xs hidden-sm hidden-md hidden-lg";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault hidden-xs hidden-sm hidden-md hidden-lg";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductServiceGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5C2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Product Service General", ""), 0) ;
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
               STRUP5C0( ) ;
            }
         }
      }

      protected void WS5C2( )
      {
         START5C2( ) ;
         EVT5C2( ) ;
      }

      protected void EVT5C2( )
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
                                 STRUP5C0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E115C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E125C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E135C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E145C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5C0( ) ;
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
                                 STRUP5C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavListgen_Internalname;
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

      protected void WE5C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5C2( ) ;
            }
         }
      }

      protected void PA5C2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_productservicegeneral.aspx")), "trn_productservicegeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_productservicegeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
               GX_FocusControl = chkavListgen_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLALOCATIONID5C2( Guid A11OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data5C2( A11OrganisationId) ;
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

      protected void GXALOCATIONID_html5C2( Guid A11OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data5C2( A11OrganisationId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynLocationId.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void GXDLALOCATIONID_data5C2( Guid A11OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005C2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( A11OrganisationId == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H005C2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H005C2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXALOCATIONID_html5C2( A11OrganisationId) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
         }
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A408ProductServiceClass = cmbProductServiceClass.getValidValue(A408ProductServiceClass);
            AssignAttri(sPrefix, false, "A408ProductServiceClass", A408ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A408ProductServiceClass);
            AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Values", cmbProductServiceClass.ToJavascriptSource(), true);
         }
         AV23ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV23ListGen));
         AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         AV26ListGenPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV26ListGenPre));
         AssignAttri(sPrefix, false, "AV26ListGenPre", AV26ListGenPre);
         AV22ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV22ListAgb));
         AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         AV27ListAgbPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV27ListAgbPre));
         AssignAttri(sPrefix, false, "AV27ListAgbPre", AV27ListAgbPre);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV30Pgmname = "Trn_ProductServiceGeneral";
         chkavListgen.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         edtavSuppliergen_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
         chkavListgenpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         chkavListagb.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         edtavSupplieragb_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
         chkavListagbpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
      }

      protected void RF5C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H005C3 */
            pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A49SupplierAgbId = H005C3_A49SupplierAgbId[0];
               n49SupplierAgbId = H005C3_n49SupplierAgbId[0];
               A42SupplierGenId = H005C3_A42SupplierGenId[0];
               n42SupplierGenId = H005C3_n42SupplierGenId[0];
               A60ProductServiceDescription = H005C3_A60ProductServiceDescription[0];
               AssignAttri(sPrefix, false, "A60ProductServiceDescription", A60ProductServiceDescription);
               A51SupplierAgbName = H005C3_A51SupplierAgbName[0];
               AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
               A44SupplierGenCompanyName = H005C3_A44SupplierGenCompanyName[0];
               AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               A366ProductServiceGroup = H005C3_A366ProductServiceGroup[0];
               AssignAttri(sPrefix, false, "A366ProductServiceGroup", A366ProductServiceGroup);
               A408ProductServiceClass = H005C3_A408ProductServiceClass[0];
               AssignAttri(sPrefix, false, "A408ProductServiceClass", A408ProductServiceClass);
               A40000ProductServiceImage_GXI = H005C3_A40000ProductServiceImage_GXI[0];
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A301ProductServiceTileName = H005C3_A301ProductServiceTileName[0];
               AssignAttri(sPrefix, false, "A301ProductServiceTileName", A301ProductServiceTileName);
               A59ProductServiceName = H005C3_A59ProductServiceName[0];
               AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
               A61ProductServiceImage = H005C3_A61ProductServiceImage[0];
               AssignAttri(sPrefix, false, "A61ProductServiceImage", A61ProductServiceImage);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A51SupplierAgbName = H005C3_A51SupplierAgbName[0];
               AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
               A44SupplierGenCompanyName = H005C3_A44SupplierGenCompanyName[0];
               AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               GXALOCATIONID_html5C2( A11OrganisationId) ;
               /* Execute user event: Load */
               E125C2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB5C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5C2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV30Pgmname = "Trn_ProductServiceGeneral";
         chkavListgen.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         edtavSuppliergen_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
         chkavListgenpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         chkavListagb.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         edtavSupplieragb_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
         chkavListagbpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
         GXALOCATIONID_html5C2( A11OrganisationId) ;
         dynLocationId.Enabled = 0;
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtProductServiceName_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         edtProductServiceTileName_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceTileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         cmbProductServiceClass.Enabled = 0;
         AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductServiceClass.Enabled), 5, 0), true);
         edtProductServiceGroup_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceGroup_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceGroup_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierAgbName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbName_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115C2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA58ProductServiceId"));
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            /* Read variables values. */
            A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
            AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
            A301ProductServiceTileName = cgiGet( edtProductServiceTileName_Internalname);
            AssignAttri(sPrefix, false, "A301ProductServiceTileName", A301ProductServiceTileName);
            A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
            AssignAttri(sPrefix, false, "A61ProductServiceImage", A61ProductServiceImage);
            cmbProductServiceClass.CurrentValue = cgiGet( cmbProductServiceClass_Internalname);
            A408ProductServiceClass = cgiGet( cmbProductServiceClass_Internalname);
            AssignAttri(sPrefix, false, "A408ProductServiceClass", A408ProductServiceClass);
            A366ProductServiceGroup = cgiGet( edtProductServiceGroup_Internalname);
            AssignAttri(sPrefix, false, "A366ProductServiceGroup", A366ProductServiceGroup);
            A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
            AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            AV23ListGen = StringUtil.StrToBool( cgiGet( chkavListgen_Internalname));
            AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
            AV25SupplierGen_Id = cgiGet( edtavSuppliergen_id_Internalname);
            AssignAttri(sPrefix, false, "AV25SupplierGen_Id", AV25SupplierGen_Id);
            AV26ListGenPre = StringUtil.StrToBool( cgiGet( chkavListgenpre_Internalname));
            AssignAttri(sPrefix, false, "AV26ListGenPre", AV26ListGenPre);
            A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
            AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
            AV22ListAgb = StringUtil.StrToBool( cgiGet( chkavListagb_Internalname));
            AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
            AV24SupplierAgb_Id = cgiGet( edtavSupplieragb_id_Internalname);
            AssignAttri(sPrefix, false, "AV24SupplierAgb_Id", AV24SupplierAgb_Id);
            AV27ListAgbPre = StringUtil.StrToBool( cgiGet( chkavListagbpre_Internalname));
            AssignAttri(sPrefix, false, "AV27ListAgbPre", AV27ListAgbPre);
            A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
            AssignAttri(sPrefix, false, "A60ProductServiceDescription", A60ProductServiceDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_ProductServiceGeneral");
            A366ProductServiceGroup = cgiGet( edtProductServiceGroup_Internalname);
            AssignAttri(sPrefix, false, "A366ProductServiceGroup", A366ProductServiceGroup);
            forbiddenHiddens.Add("ProductServiceGroup", StringUtil.RTrim( context.localUtil.Format( A366ProductServiceGroup, "")));
            AV23ListGen = StringUtil.StrToBool( cgiGet( chkavListgen_Internalname));
            AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
            forbiddenHiddens.Add("ListGen", StringUtil.BoolToStr( AV23ListGen));
            AV22ListAgb = StringUtil.StrToBool( cgiGet( chkavListagb_Internalname));
            AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
            forbiddenHiddens.Add("ListAgb", StringUtil.BoolToStr( AV22ListAgb));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("trn_productservicegeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXALOCATIONID_html5C2( A11OrganisationId) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E115C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E115C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E125C2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV21TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragbview_Execute", out  GXt_boolean1) ;
         AV21TempBoolean = GXt_boolean1;
         if ( AV21TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragbview.aspx"+UrlEncode(A49SupplierAgbId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierAgbName_Link = formatLink("trn_supplieragbview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Link", edtSupplierAgbName_Link, true);
         }
         GXt_boolean1 = AV21TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergenview_Execute", out  GXt_boolean1) ;
         AV21TempBoolean = GXt_boolean1;
         if ( AV21TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergenview.aspx"+UrlEncode(A42SupplierGenId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierGenCompanyName_Link = formatLink("trn_suppliergenview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Link", edtSupplierGenCompanyName_Link, true);
         }
         edtProductServiceId_Visible = 0;
         AssignProp(sPrefix, false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productservice_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productservice_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            chkavListagbpre.Visible = 0;
            AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
            cellListagbpre_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         }
         else
         {
            chkavListagbpre.Visible = 1;
            AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
            cellListagbpre_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            chkavListagb.Visible = 0;
            AssignProp(sPrefix, false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
            cellListagb_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         }
         else
         {
            chkavListagb.Visible = 1;
            AssignProp(sPrefix, false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
            cellListagb_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            chkavListgen.Visible = 0;
            AssignProp(sPrefix, false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
            cellListgen_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         }
         else
         {
            chkavListgen.Visible = 1;
            AssignProp(sPrefix, false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
            cellListgen_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         }
         if ( ! ( ( AV29Ismanager == Convert.ToDecimal( true )) ) )
         {
            dynLocationId.Visible = 0;
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
            divLocationid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         else
         {
            dynLocationId.Visible = 1;
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
            divLocationid_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         divTransactiondetail_tablegen_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_tablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_tablegen_Visible), 5, 0), true);
         divTransactiondetail_tableagb_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_tableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_tableagb_Visible), 5, 0), true);
         divTransactiondetail_supplieragb_Visible = ((!AV22ListAgb) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_supplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_supplieragb_Visible), 5, 0), true);
         divTransactiondetail_supplieragbpre_Visible = (((AV22ListAgb)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_supplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_supplieragbpre_Visible), 5, 0), true);
         divTransactiondetail_suppliergen_Visible = ((!AV23ListGen) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_suppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_suppliergen_Visible), 5, 0), true);
         divTransactiondetail_suppliergenpre_Visible = (((AV23ListGen)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_suppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_suppliergenpre_Visible), 5, 0), true);
      }

      protected void E135C2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E145C2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV30Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_ProductService";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table4_124_5C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragb_id_Internalname, tblTablemergedsupplieragb_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSupplieragb_id_Internalname, context.GetMessage( "Supplier Agb_Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragb_id_Internalname, AV24SupplierAgb_Id, StringUtil.RTrim( context.localUtil.Format( AV24SupplierAgb_Id, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragb_id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSupplieragb_id_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListagbpre_cell_Internalname+"\"  class='"+cellListagbpre_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListagbpre_Internalname, context.GetMessage( "List Agb Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListagbpre_Internalname, StringUtil.BoolToStr( AV27ListAgbPre), "", context.GetMessage( "List Agb Pre", ""), chkavListagbpre.Visible, chkavListagbpre.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock4_Internalname, context.GetMessage( "Preffered", ""), "", "", lblTransactiondetail_textblock4_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_124_5C2e( true) ;
         }
         else
         {
            wb_table4_124_5C2e( false) ;
         }
      }

      protected void wb_table3_104_5C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragbname_Internalname, tblTablemergedsupplieragbname_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbName_Internalname, context.GetMessage( "Supplier Agb Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbName_Internalname, A51SupplierAgbName, StringUtil.RTrim( context.localUtil.Format( A51SupplierAgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSupplierAgbName_Link, "", "", "", edtSupplierAgbName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListagb_cell_Internalname+"\"  class='"+cellListagb_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListagb_Internalname, context.GetMessage( "List Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListagb_Internalname, StringUtil.BoolToStr( AV22ListAgb), "", context.GetMessage( "List Agb", ""), chkavListagb.Visible, chkavListagb.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock3_Internalname, context.GetMessage( "Preffered", ""), "", "", lblTransactiondetail_textblock3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_104_5C2e( true) ;
         }
         else
         {
            wb_table3_104_5C2e( false) ;
         }
      }

      protected void wb_table2_81_5C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergen_id_Internalname, tblTablemergedsuppliergen_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliergen_id_Internalname, context.GetMessage( "Supplier Gen_Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergen_id_Internalname, AV25SupplierGen_Id, StringUtil.RTrim( context.localUtil.Format( AV25SupplierGen_Id, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergen_id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSuppliergen_id_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListgenpre_Internalname, context.GetMessage( "List Gen Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListgenpre_Internalname, StringUtil.BoolToStr( AV26ListGenPre), "", context.GetMessage( "List Gen Pre", ""), 1, chkavListgenpre.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock2_Internalname, context.GetMessage( "Preffered", ""), "", "", lblTransactiondetail_textblock2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_81_5C2e( true) ;
         }
         else
         {
            wb_table2_81_5C2e( false) ;
         }
      }

      protected void wb_table1_61_5C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergencompanyname_Internalname, tblTablemergedsuppliergencompanyname_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, context.GetMessage( "Company Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSupplierGenCompanyName_Link, "", "", "", edtSupplierGenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListgen_cell_Internalname+"\"  class='"+cellListgen_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListgen_Internalname, context.GetMessage( "List Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListgen_Internalname, StringUtil.BoolToStr( AV23ListGen), "", context.GetMessage( "List Gen", ""), chkavListgen.Visible, chkavListgen.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock1_Internalname, context.GetMessage( "Preffered", ""), "", "", lblTransactiondetail_textblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_61_5C2e( true) ;
         }
         else
         {
            wb_table1_61_5C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A58ProductServiceId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A29LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = (Guid)getParm(obj,2);
         AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
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
         PA5C2( ) ;
         WS5C2( ) ;
         WE5C2( ) ;
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
         sCtrlA58ProductServiceId = (string)((string)getParm(obj,0));
         sCtrlA29LocationId = (string)((string)getParm(obj,1));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5C2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_productservicegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5C2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A58ProductServiceId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA58ProductServiceId"));
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A58ProductServiceId != wcpOA58ProductServiceId ) || ( A29LocationId != wcpOA29LocationId ) || ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA58ProductServiceId = A58ProductServiceId;
         wcpOA29LocationId = A29LocationId;
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA58ProductServiceId = cgiGet( sPrefix+"A58ProductServiceId_CTRL");
         if ( StringUtil.Len( sCtrlA58ProductServiceId) > 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( cgiGet( sCtrlA58ProductServiceId));
            AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            A58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"A58ProductServiceId_PARM"));
         }
         sCtrlA29LocationId = cgiGet( sPrefix+"A29LocationId_CTRL");
         if ( StringUtil.Len( sCtrlA29LocationId) > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sCtrlA29LocationId));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A29LocationId_PARM"));
         }
         sCtrlA11OrganisationId = cgiGet( sPrefix+"A11OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlA11OrganisationId) > 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlA11OrganisationId));
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A11OrganisationId_PARM"));
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
         PA5C2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5C2( ) ;
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
         WS5C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A58ProductServiceId_PARM", A58ProductServiceId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA58ProductServiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A58ProductServiceId_CTRL", StringUtil.RTrim( sCtrlA58ProductServiceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_PARM", A29LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_CTRL", StringUtil.RTrim( sCtrlA29LocationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_PARM", A11OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_CTRL", StringUtil.RTrim( sCtrlA11OrganisationId));
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
         WE5C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411291429344", true, true);
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
         context.AddJavascriptSource("trn_productservicegeneral.js", "?202411291429345", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynLocationId.Name = "LOCATIONID";
         dynLocationId.WebTags = "";
         cmbProductServiceClass.Name = "PRODUCTSERVICECLASS";
         cmbProductServiceClass.WebTags = "";
         cmbProductServiceClass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbProductServiceClass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbProductServiceClass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbProductServiceClass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
         }
         chkavListgen.Name = "vLISTGEN";
         chkavListgen.WebTags = "";
         chkavListgen.Caption = context.GetMessage( "List Gen", "");
         AssignProp(sPrefix, false, chkavListgen_Internalname, "TitleCaption", chkavListgen.Caption, true);
         chkavListgen.CheckedValue = "false";
         chkavListgenpre.Name = "vLISTGENPRE";
         chkavListgenpre.WebTags = "";
         chkavListgenpre.Caption = context.GetMessage( "List Gen Pre", "");
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "TitleCaption", chkavListgenpre.Caption, true);
         chkavListgenpre.CheckedValue = "false";
         chkavListagb.Name = "vLISTAGB";
         chkavListagb.WebTags = "";
         chkavListagb.Caption = context.GetMessage( "List Agb", "");
         AssignProp(sPrefix, false, chkavListagb_Internalname, "TitleCaption", chkavListagb.Caption, true);
         chkavListagb.CheckedValue = "false";
         chkavListagbpre.Name = "vLISTAGBPRE";
         chkavListagbpre.WebTags = "";
         chkavListagbpre.Caption = context.GetMessage( "List Agb Pre", "");
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "TitleCaption", chkavListagbpre.Caption, true);
         chkavListagbpre.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = sPrefix+"LOCATIONID";
         divLocationid_cell_Internalname = sPrefix+"LOCATIONID_CELL";
         edtProductServiceName_Internalname = sPrefix+"PRODUCTSERVICENAME";
         edtProductServiceTileName_Internalname = sPrefix+"PRODUCTSERVICETILENAME";
         imgProductServiceImage_Internalname = sPrefix+"PRODUCTSERVICEIMAGE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         cmbProductServiceClass_Internalname = sPrefix+"PRODUCTSERVICECLASS";
         edtProductServiceGroup_Internalname = sPrefix+"PRODUCTSERVICEGROUP";
         lblTextblocksuppliergencompanyname_Internalname = sPrefix+"TEXTBLOCKSUPPLIERGENCOMPANYNAME";
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME";
         chkavListgen_Internalname = sPrefix+"vLISTGEN";
         cellListgen_cell_Internalname = sPrefix+"LISTGEN_CELL";
         lblTransactiondetail_textblock1_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK1";
         tblTablemergedsuppliergencompanyname_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGENCOMPANYNAME";
         divTablesplittedsuppliergencompanyname_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGENCOMPANYNAME";
         divTransactiondetail_suppliergen_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERGEN";
         lblTextblocksuppliergen_id_Internalname = sPrefix+"TEXTBLOCKSUPPLIERGEN_ID";
         edtavSuppliergen_id_Internalname = sPrefix+"vSUPPLIERGEN_ID";
         chkavListgenpre_Internalname = sPrefix+"vLISTGENPRE";
         lblTransactiondetail_textblock2_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK2";
         tblTablemergedsuppliergen_id_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGEN_ID";
         divTablesplittedsuppliergen_id_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGEN_ID";
         divTransactiondetail_suppliergenpre_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERGENPRE";
         divTransactiondetail_tablegen_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEGEN";
         lblTextblocksupplieragbname_Internalname = sPrefix+"TEXTBLOCKSUPPLIERAGBNAME";
         edtSupplierAgbName_Internalname = sPrefix+"SUPPLIERAGBNAME";
         chkavListagb_Internalname = sPrefix+"vLISTAGB";
         cellListagb_cell_Internalname = sPrefix+"LISTAGB_CELL";
         lblTransactiondetail_textblock3_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK3";
         tblTablemergedsupplieragbname_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGBNAME";
         divTablesplittedsupplieragbname_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGBNAME";
         divTransactiondetail_supplieragb_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERAGB";
         lblTextblocksupplieragb_id_Internalname = sPrefix+"TEXTBLOCKSUPPLIERAGB_ID";
         edtavSupplieragb_id_Internalname = sPrefix+"vSUPPLIERAGB_ID";
         chkavListagbpre_Internalname = sPrefix+"vLISTAGBPRE";
         cellListagbpre_cell_Internalname = sPrefix+"LISTAGBPRE_CELL";
         lblTransactiondetail_textblock4_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK4";
         tblTablemergedsupplieragb_id_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGB_ID";
         divTablesplittedsupplieragb_id_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGB_ID";
         divTransactiondetail_supplieragbpre_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERAGBPRE";
         divTransactiondetail_tableagb_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEAGB";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         edtProductServiceDescription_Internalname = sPrefix+"PRODUCTSERVICEDESCRIPTION";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtProductServiceId_Internalname = sPrefix+"PRODUCTSERVICEID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
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
         chkavListagbpre.Caption = context.GetMessage( "List Agb Pre", "");
         chkavListagb.Caption = context.GetMessage( "List Agb", "");
         chkavListgenpre.Caption = context.GetMessage( "List Gen Pre", "");
         chkavListgen.Caption = context.GetMessage( "List Gen", "");
         chkavListgen.Enabled = 1;
         cellListgen_cell_Class = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         chkavListgenpre.Enabled = 1;
         edtavSuppliergen_id_Jsonclick = "";
         edtavSuppliergen_id_Enabled = 1;
         chkavListagb.Enabled = 1;
         cellListagb_cell_Class = "";
         edtSupplierAgbName_Jsonclick = "";
         chkavListagbpre.Enabled = 1;
         cellListagbpre_cell_Class = "";
         edtavSupplieragb_id_Jsonclick = "";
         edtavSupplieragb_id_Enabled = 1;
         chkavListgen.Visible = 1;
         chkavListagb.Visible = 1;
         chkavListagbpre.Visible = 1;
         edtSupplierGenCompanyName_Link = "";
         edtSupplierAgbName_Link = "";
         edtOrganisationId_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         imgProductServiceImage_Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtProductServiceDescription_Enabled = 0;
         divTransactiondetail_supplieragbpre_Visible = 1;
         divTransactiondetail_supplieragb_Visible = 1;
         divTransactiondetail_tableagb_Visible = 1;
         divTransactiondetail_suppliergenpre_Visible = 1;
         divTransactiondetail_suppliergen_Visible = 1;
         divTransactiondetail_tablegen_Visible = 1;
         edtProductServiceGroup_Enabled = 0;
         cmbProductServiceClass_Jsonclick = "";
         cmbProductServiceClass.Enabled = 0;
         edtProductServiceTileName_Jsonclick = "";
         edtProductServiceTileName_Enabled = 0;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Enabled = 0;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 0;
         dynLocationId.Visible = 1;
         divLocationid_cell_Class = "col-xs-12";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Valid_Organisationid( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         GXALOCATIONID_html5C2( A11OrganisationId) ;
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV26ListGenPre","fld":"vLISTGENPRE"},{"av":"AV27ListAgbPre","fld":"vLISTAGBPRE"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV22ListAgb","fld":"vLISTAGB","hsh":true},{"av":"AV23ListGen","fld":"vLISTGEN","hsh":true},{"av":"A366ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E135C2","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E145C2","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
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
         wcpOA58ProductServiceId = Guid.Empty;
         wcpOA29LocationId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV30Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         A366ProductServiceGroup = "";
         GX_FocusControl = "";
         TempTags = "";
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         ClassString = "";
         StyleString = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         A408ProductServiceClass = "";
         lblTextblocksuppliergencompanyname_Jsonclick = "";
         lblTextblocksuppliergen_id_Jsonclick = "";
         lblTextblocksupplieragbname_Jsonclick = "";
         lblTextblocksupplieragb_id_Jsonclick = "";
         A60ProductServiceDescription = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
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
         H005C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C2_A31LocationName = new string[] {""} ;
         H005C3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005C3_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H005C3_n49SupplierAgbId = new bool[] {false} ;
         H005C3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H005C3_n42SupplierGenId = new bool[] {false} ;
         H005C3_A60ProductServiceDescription = new string[] {""} ;
         H005C3_A51SupplierAgbName = new string[] {""} ;
         H005C3_A44SupplierGenCompanyName = new string[] {""} ;
         H005C3_A366ProductServiceGroup = new string[] {""} ;
         H005C3_A408ProductServiceClass = new string[] {""} ;
         H005C3_A40000ProductServiceImage_GXI = new string[] {""} ;
         H005C3_A301ProductServiceTileName = new string[] {""} ;
         H005C3_A59ProductServiceName = new string[] {""} ;
         H005C3_A61ProductServiceImage = new string[] {""} ;
         A49SupplierAgbId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A51SupplierAgbName = "";
         A44SupplierGenCompanyName = "";
         AV25SupplierGen_Id = "";
         AV24SupplierAgb_Id = "";
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Gx_mode = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         sStyleString = "";
         lblTransactiondetail_textblock4_Jsonclick = "";
         lblTransactiondetail_textblock3_Jsonclick = "";
         lblTransactiondetail_textblock2_Jsonclick = "";
         lblTransactiondetail_textblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA58ProductServiceId = "";
         sCtrlA29LocationId = "";
         sCtrlA11OrganisationId = "";
         Z29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservicegeneral__default(),
            new Object[][] {
                new Object[] {
               H005C2_A11OrganisationId, H005C2_A29LocationId, H005C2_A31LocationName
               }
               , new Object[] {
               H005C3_A58ProductServiceId, H005C3_A29LocationId, H005C3_A11OrganisationId, H005C3_A49SupplierAgbId, H005C3_n49SupplierAgbId, H005C3_A42SupplierGenId, H005C3_n42SupplierGenId, H005C3_A60ProductServiceDescription, H005C3_A51SupplierAgbName, H005C3_A44SupplierGenCompanyName,
               H005C3_A366ProductServiceGroup, H005C3_A408ProductServiceClass, H005C3_A40000ProductServiceImage_GXI, H005C3_A301ProductServiceTileName, H005C3_A59ProductServiceName, H005C3_A61ProductServiceImage
               }
            }
         );
         AV30Pgmname = "Trn_ProductServiceGeneral";
         /* GeneXus formulas. */
         AV30Pgmname = "Trn_ProductServiceGeneral";
         chkavListgen.Enabled = 0;
         edtavSuppliergen_id_Enabled = 0;
         chkavListgenpre.Enabled = 0;
         chkavListagb.Enabled = 0;
         edtavSupplieragb_id_Enabled = 0;
         chkavListagbpre.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavSuppliergen_id_Enabled ;
      private int edtavSupplieragb_id_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceTileName_Enabled ;
      private int edtProductServiceGroup_Enabled ;
      private int divTransactiondetail_tablegen_Visible ;
      private int divTransactiondetail_suppliergen_Visible ;
      private int divTransactiondetail_suppliergenpre_Visible ;
      private int divTransactiondetail_tableagb_Visible ;
      private int divTransactiondetail_supplieragb_Visible ;
      private int divTransactiondetail_supplieragbpre_Visible ;
      private int edtProductServiceDescription_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtProductServiceId_Visible ;
      private int edtOrganisationId_Visible ;
      private int gxdynajaxindex ;
      private int imgProductServiceImage_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int idxLst ;
      private decimal AV29Ismanager ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV30Pgmname ;
      private string chkavListgen_Internalname ;
      private string edtavSuppliergen_id_Internalname ;
      private string chkavListgenpre_Internalname ;
      private string chkavListagb_Internalname ;
      private string edtavSupplieragb_id_Internalname ;
      private string chkavListagbpre_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divLocationid_cell_Internalname ;
      private string divLocationid_cell_Class ;
      private string dynLocationId_Internalname ;
      private string TempTags ;
      private string dynLocationId_Jsonclick ;
      private string edtProductServiceName_Internalname ;
      private string edtProductServiceName_Jsonclick ;
      private string edtProductServiceTileName_Internalname ;
      private string A301ProductServiceTileName ;
      private string edtProductServiceTileName_Jsonclick ;
      private string imgProductServiceImage_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string divUnnamedtable2_Internalname ;
      private string cmbProductServiceClass_Internalname ;
      private string cmbProductServiceClass_Jsonclick ;
      private string edtProductServiceGroup_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divTransactiondetail_tablegen_Internalname ;
      private string divTransactiondetail_suppliergen_Internalname ;
      private string divTablesplittedsuppliergencompanyname_Internalname ;
      private string lblTextblocksuppliergencompanyname_Internalname ;
      private string lblTextblocksuppliergencompanyname_Jsonclick ;
      private string divTransactiondetail_suppliergenpre_Internalname ;
      private string divTablesplittedsuppliergen_id_Internalname ;
      private string lblTextblocksuppliergen_id_Internalname ;
      private string lblTextblocksuppliergen_id_Jsonclick ;
      private string divTransactiondetail_tableagb_Internalname ;
      private string divTransactiondetail_supplieragb_Internalname ;
      private string divTablesplittedsupplieragbname_Internalname ;
      private string lblTextblocksupplieragbname_Internalname ;
      private string lblTextblocksupplieragbname_Jsonclick ;
      private string divTransactiondetail_supplieragbpre_Internalname ;
      private string divTablesplittedsupplieragb_id_Internalname ;
      private string lblTextblocksupplieragb_id_Internalname ;
      private string lblTextblocksupplieragb_id_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierAgbName_Internalname ;
      private string hsh ;
      private string edtSupplierAgbName_Link ;
      private string edtSupplierGenCompanyName_Link ;
      private string Gx_mode ;
      private string cellListagbpre_cell_Class ;
      private string cellListagbpre_cell_Internalname ;
      private string cellListagb_cell_Class ;
      private string cellListagb_cell_Internalname ;
      private string cellListgen_cell_Class ;
      private string cellListgen_cell_Internalname ;
      private string sStyleString ;
      private string tblTablemergedsupplieragb_id_Internalname ;
      private string edtavSupplieragb_id_Jsonclick ;
      private string lblTransactiondetail_textblock4_Internalname ;
      private string lblTransactiondetail_textblock4_Jsonclick ;
      private string tblTablemergedsupplieragbname_Internalname ;
      private string edtSupplierAgbName_Jsonclick ;
      private string lblTransactiondetail_textblock3_Internalname ;
      private string lblTransactiondetail_textblock3_Jsonclick ;
      private string tblTablemergedsuppliergen_id_Internalname ;
      private string edtavSuppliergen_id_Jsonclick ;
      private string lblTransactiondetail_textblock2_Internalname ;
      private string lblTransactiondetail_textblock2_Jsonclick ;
      private string tblTablemergedsuppliergencompanyname_Internalname ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string lblTransactiondetail_textblock1_Internalname ;
      private string lblTransactiondetail_textblock1_Jsonclick ;
      private string sCtrlA58ProductServiceId ;
      private string sCtrlA29LocationId ;
      private string sCtrlA11OrganisationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22ListAgb ;
      private bool AV23ListGen ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV26ListGenPre ;
      private bool AV27ListAgbPre ;
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private bool returnInSub ;
      private bool AV21TempBoolean ;
      private bool GXt_boolean1 ;
      private string A60ProductServiceDescription ;
      private string A366ProductServiceGroup ;
      private string A59ProductServiceName ;
      private string A40000ProductServiceImage_GXI ;
      private string A408ProductServiceClass ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private string AV25SupplierGen_Id ;
      private string AV24SupplierAgb_Id ;
      private string A61ProductServiceImage ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid wcpOA58ProductServiceId ;
      private Guid wcpOA29LocationId ;
      private Guid wcpOA11OrganisationId ;
      private Guid A49SupplierAgbId ;
      private Guid A42SupplierGenId ;
      private Guid Z29LocationId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private GXCombobox cmbProductServiceClass ;
      private GXCheckbox chkavListgen ;
      private GXCheckbox chkavListgenpre ;
      private GXCheckbox chkavListagb ;
      private GXCheckbox chkavListagbpre ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005C2_A11OrganisationId ;
      private Guid[] H005C2_A29LocationId ;
      private string[] H005C2_A31LocationName ;
      private Guid[] H005C3_A58ProductServiceId ;
      private Guid[] H005C3_A29LocationId ;
      private Guid[] H005C3_A11OrganisationId ;
      private Guid[] H005C3_A49SupplierAgbId ;
      private bool[] H005C3_n49SupplierAgbId ;
      private Guid[] H005C3_A42SupplierGenId ;
      private bool[] H005C3_n42SupplierGenId ;
      private string[] H005C3_A60ProductServiceDescription ;
      private string[] H005C3_A51SupplierAgbName ;
      private string[] H005C3_A44SupplierGenCompanyName ;
      private string[] H005C3_A366ProductServiceGroup ;
      private string[] H005C3_A408ProductServiceClass ;
      private string[] H005C3_A40000ProductServiceImage_GXI ;
      private string[] H005C3_A301ProductServiceTileName ;
      private string[] H005C3_A59ProductServiceName ;
      private string[] H005C3_A61ProductServiceImage ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_productservicegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005C2;
          prmH005C2 = new Object[] {
          };
          Object[] prmH005C3;
          prmH005C3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005C2", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005C3", "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SupplierAgbId, T1.SupplierGenId, T1.ProductServiceDescription, T2.SupplierAgbName, T3.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceClass, T1.ProductServiceImage_GXI, T1.ProductServiceTileName, T1.ProductServiceName, T1.ProductServiceImage FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) LEFT JOIN Trn_SupplierGen T3 ON T3.SupplierGenId = T1.SupplierGenId) WHERE T1.ProductServiceId = :ProductServiceId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C3,1, GxCacheFrequency.OFF ,true,true )
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
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
                return;
       }
    }

 }

}
