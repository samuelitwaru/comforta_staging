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
   public class gx00g0 : GXDataArea
   {
      public gx00g0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00g0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_pResidentId ,
                           out Guid aP1_pLocationId ,
                           out Guid aP2_pOrganisationId )
      {
         this.AV13pResidentId = Guid.Empty ;
         this.AV14pLocationId = Guid.Empty ;
         this.AV15pOrganisationId = Guid.Empty ;
         ExecuteImpl();
         aP0_pResidentId=this.AV13pResidentId;
         aP1_pLocationId=this.AV14pLocationId;
         aP2_pOrganisationId=this.AV15pOrganisationId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavClocationid = new GXCombobox();
         dynavCorganisationid = new GXCombobox();
         cmbavCresidentsalutation = new GXCombobox();
         dynLocationId = new GXCombobox();
         dynOrganisationId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pResidentId");
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
               gxfirstwebparm = GetFirstPar( "pResidentId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pResidentId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pResidentId = StringUtil.StrToGuid( gxfirstwebparm);
               AssignAttri("", false, "AV13pResidentId", AV13pResidentId.ToString());
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pLocationId = StringUtil.StrToGuid( GetPar( "pLocationId"));
                  AssignAttri("", false, "AV14pLocationId", AV14pLocationId.ToString());
                  AV15pOrganisationId = StringUtil.StrToGuid( GetPar( "pOrganisationId"));
                  AssignAttri("", false, "AV15pOrganisationId", AV15pOrganisationId.ToString());
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cResidentId = StringUtil.StrToGuid( GetPar( "cResidentId"));
         dynavClocationid.FromJSonString( GetNextPar( ));
         AV7cLocationId = StringUtil.StrToGuid( GetPar( "cLocationId"));
         dynavCorganisationid.FromJSonString( GetNextPar( ));
         AV8cOrganisationId = StringUtil.StrToGuid( GetPar( "cOrganisationId"));
         cmbavCresidentsalutation.FromJSonString( GetNextPar( ));
         AV9cResidentSalutation = GetPar( "cResidentSalutation");
         AV10cResidentBsnNumber = GetPar( "cResidentBsnNumber");
         AV11cResidentGivenName = GetPar( "cResidentGivenName");
         AV12cResidentLastName = GetPar( "cResidentLastName");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            return "gx00g0_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
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
         PA0I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0I2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00g0.aspx", new object[] {UrlEncode(AV13pResidentId.ToString()),UrlEncode(AV14pLocationId.ToString()),UrlEncode(AV15pOrganisationId.ToString())}, new string[] {"pResidentId","pLocationId","pOrganisationId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTID", AV6cResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCLOCATIONID", AV7cLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONID", AV8cOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTSALUTATION", StringUtil.RTrim( AV9cResidentSalutation));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTBSNNUMBER", AV10cResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTGIVENNAME", AV11cResidentGivenName);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTLASTNAME", AV12cResidentLastName);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPRESIDENTID", AV13pResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "vPLOCATIONID", AV14pLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPORGANISATIONID", AV15pOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTIDFILTERCONTAINER_Class", StringUtil.RTrim( divResidentidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "LOCATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divLocationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTSALUTATIONFILTERCONTAINER_Class", StringUtil.RTrim( divResidentsalutationfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTBSNNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divResidentbsnnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTGIVENNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentgivennamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentlastnamefiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0I2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00g0.aspx", new object[] {UrlEncode(AV13pResidentId.ToString()),UrlEncode(AV14pLocationId.ToString()),UrlEncode(AV15pOrganisationId.ToString())}, new string[] {"pResidentId","pLocationId","pOrganisationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00G0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Resident" ;
      }

      protected void WB0I0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResidentidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentidfilter_Internalname, "Resident Id", "", "", lblLblresidentidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentid_Internalname, "Resident Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentid_Internalname, AV6cResidentId.ToString(), AV6cResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentid_Visible, edtavCresidentid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divLocationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divLocationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbllocationidfilter_Internalname, "Location Id", "", "", lblLbllocationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavClocationid_Internalname, "Location Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavClocationid, dynavClocationid_Internalname, AV7cLocationId.ToString(), 1, dynavClocationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavClocationid.Visible, dynavClocationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx00G0.htm");
            dynavClocationid.CurrentValue = AV7cLocationId.ToString();
            AssignProp("", false, dynavClocationid_Internalname, "Values", (string)(dynavClocationid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divOrganisationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationidfilter_Internalname, "Organisation Id", "", "", lblLblorganisationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCorganisationid_Internalname, "Organisation Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCorganisationid, dynavCorganisationid_Internalname, AV8cOrganisationId.ToString(), 1, dynavCorganisationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavCorganisationid.Visible, dynavCorganisationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx00G0.htm");
            dynavCorganisationid.CurrentValue = AV8cOrganisationId.ToString();
            AssignProp("", false, dynavCorganisationid_Internalname, "Values", (string)(dynavCorganisationid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divResidentsalutationfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentsalutationfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentsalutationfilter_Internalname, "Resident Salutation", "", "", lblLblresidentsalutationfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCresidentsalutation_Internalname, "Resident Salutation", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCresidentsalutation, cmbavCresidentsalutation_Internalname, StringUtil.RTrim( AV9cResidentSalutation), 1, cmbavCresidentsalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCresidentsalutation.Visible, cmbavCresidentsalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Gx00G0.htm");
            cmbavCresidentsalutation.CurrentValue = StringUtil.RTrim( AV9cResidentSalutation);
            AssignProp("", false, cmbavCresidentsalutation_Internalname, "Values", (string)(cmbavCresidentsalutation.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divResidentbsnnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentbsnnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentbsnnumberfilter_Internalname, "Resident Bsn Number", "", "", lblLblresidentbsnnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentbsnnumber_Internalname, "Resident Bsn Number", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentbsnnumber_Internalname, AV10cResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV10cResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentbsnnumber_Visible, edtavCresidentbsnnumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divResidentgivennamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentgivennamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentgivennamefilter_Internalname, "Resident Given Name", "", "", lblLblresidentgivennamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentgivenname_Internalname, "Resident Given Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentgivenname_Internalname, AV11cResidentGivenName, StringUtil.RTrim( context.localUtil.Format( AV11cResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentgivenname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentgivenname_Visible, edtavCresidentgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divResidentlastnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentlastnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentlastnamefilter_Internalname, "Resident Last Name", "", "", lblLblresidentlastnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentlastname_Internalname, "Resident Last Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentlastname_Internalname, AV12cResidentLastName, StringUtil.RTrim( context.localUtil.Format( AV12cResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentlastname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentlastname_Visible, edtavCresidentlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180i1_client"+"'", TempTags, "", 2, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0I2( )
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
         Form.Meta.addItem("description", "Selection List Resident", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0I0( ) ;
      }

      protected void WS0I2( )
      {
         START0I2( ) ;
         EVT0I2( ) ;
      }

      protected void EVT0I2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
                              dynLocationId.Name = dynLocationId_Internalname;
                              dynLocationId.CurrentValue = cgiGet( dynLocationId_Internalname);
                              A29LocationId = StringUtil.StrToGuid( cgiGet( dynLocationId_Internalname));
                              dynOrganisationId.Name = dynOrganisationId_Internalname;
                              dynOrganisationId.CurrentValue = cgiGet( dynOrganisationId_Internalname);
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( dynOrganisationId_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cresidentid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCRESIDENTID")) != AV6cResidentId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clocationid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCLOCATIONID")) != AV7cLocationId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV8cOrganisationId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentsalutation Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTSALUTATION"), AV9cResidentSalutation) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentbsnnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTBSNNUMBER"), AV10cResidentBsnNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentgivenname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTGIVENNAME"), AV11cResidentGivenName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentlastname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTLASTNAME"), AV12cResidentLastName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210I2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE0I2( )
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

      protected void PA0I2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCORGANISATIONID0I1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCORGANISATIONID_data0I1( ) ;
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

      protected void GXVvCORGANISATIONID_html0I1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvCORGANISATIONID_data0I1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCorganisationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavCorganisationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCorganisationid.ItemCount > 0 )
         {
            AV8cOrganisationId = StringUtil.StrToGuid( dynavCorganisationid.getValidValue(AV8cOrganisationId.ToString()));
            AssignAttri("", false, "AV8cOrganisationId", AV8cOrganisationId.ToString());
         }
      }

      protected void GXDLVvCORGANISATIONID_data0I1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H000I2_A11OrganisationId[0].ToString());
            gxdynajaxctrldescr.Add(H000I2_A13OrganisationName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvCLOCATIONID0I1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCLOCATIONID_data0I1( ) ;
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

      protected void GXVvCLOCATIONID_html0I1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvCLOCATIONID_data0I1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavClocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavClocationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavClocationid.ItemCount > 0 )
         {
            AV7cLocationId = StringUtil.StrToGuid( dynavClocationid.getValidValue(AV7cLocationId.ToString()));
            AssignAttri("", false, "AV7cLocationId", AV7cLocationId.ToString());
         }
      }

      protected void GXDLVvCLOCATIONID_data0I1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000I3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H000I3_A29LocationId[0].ToString());
            gxdynajaxctrldescr.Add(H000I3_A31LocationName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        Guid AV6cResidentId ,
                                        Guid AV7cLocationId ,
                                        Guid AV8cOrganisationId ,
                                        string AV9cResidentSalutation ,
                                        string AV10cResidentBsnNumber ,
                                        string AV11cResidentGivenName ,
                                        string AV12cResidentLastName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTID", GetSecureSignedToken( "", A62ResidentId, context));
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavCorganisationid.Name = "vCORGANISATIONID";
            dynavCorganisationid.WebTags = "";
            dynavCorganisationid.removeAllItems();
            /* Using cursor H000I4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavCorganisationid.addItem(H000I4_A11OrganisationId[0].ToString(), H000I4_A13OrganisationName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavCorganisationid.ItemCount > 0 )
            {
               AV8cOrganisationId = StringUtil.StrToGuid( dynavCorganisationid.getValidValue(AV8cOrganisationId.ToString()));
               AssignAttri("", false, "AV8cOrganisationId", AV8cOrganisationId.ToString());
            }
            dynavClocationid.Name = "vCLOCATIONID";
            dynavClocationid.WebTags = "";
            dynavClocationid.removeAllItems();
            /* Using cursor H000I5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavClocationid.addItem(H000I5_A29LocationId[0].ToString(), H000I5_A31LocationName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavClocationid.ItemCount > 0 )
            {
               AV7cLocationId = StringUtil.StrToGuid( dynavClocationid.getValidValue(AV7cLocationId.ToString()));
               AssignAttri("", false, "AV7cLocationId", AV7cLocationId.ToString());
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavClocationid.ItemCount > 0 )
         {
            AV7cLocationId = StringUtil.StrToGuid( dynavClocationid.getValidValue(AV7cLocationId.ToString()));
            AssignAttri("", false, "AV7cLocationId", AV7cLocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavClocationid.CurrentValue = AV7cLocationId.ToString();
            AssignProp("", false, dynavClocationid_Internalname, "Values", dynavClocationid.ToJavascriptSource(), true);
         }
         if ( dynavCorganisationid.ItemCount > 0 )
         {
            AV8cOrganisationId = StringUtil.StrToGuid( dynavCorganisationid.getValidValue(AV8cOrganisationId.ToString()));
            AssignAttri("", false, "AV8cOrganisationId", AV8cOrganisationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCorganisationid.CurrentValue = AV8cOrganisationId.ToString();
            AssignProp("", false, dynavCorganisationid_Internalname, "Values", dynavCorganisationid.ToJavascriptSource(), true);
         }
         if ( cmbavCresidentsalutation.ItemCount > 0 )
         {
            AV9cResidentSalutation = cmbavCresidentsalutation.getValidValue(AV9cResidentSalutation);
            AssignAttri("", false, "AV9cResidentSalutation", AV9cResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCresidentsalutation.CurrentValue = StringUtil.RTrim( AV9cResidentSalutation);
            AssignProp("", false, cmbavCresidentsalutation_Internalname, "Values", cmbavCresidentsalutation.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV9cResidentSalutation ,
                                                 AV10cResidentBsnNumber ,
                                                 AV11cResidentGivenName ,
                                                 AV12cResidentLastName ,
                                                 A72ResidentSalutation ,
                                                 A63ResidentBsnNumber ,
                                                 A64ResidentGivenName ,
                                                 A65ResidentLastName ,
                                                 AV6cResidentId ,
                                                 AV7cLocationId ,
                                                 AV8cOrganisationId } ,
                                                 new int[]{
                                                 }
            });
            lV9cResidentSalutation = StringUtil.PadR( StringUtil.RTrim( AV9cResidentSalutation), 20, "%");
            lV10cResidentBsnNumber = StringUtil.Concat( StringUtil.RTrim( AV10cResidentBsnNumber), "%", "");
            lV11cResidentGivenName = StringUtil.Concat( StringUtil.RTrim( AV11cResidentGivenName), "%", "");
            lV12cResidentLastName = StringUtil.Concat( StringUtil.RTrim( AV12cResidentLastName), "%", "");
            /* Using cursor H000I6 */
            pr_default.execute(4, new Object[] {AV6cResidentId, AV7cLocationId, AV8cOrganisationId, lV9cResidentSalutation, lV10cResidentBsnNumber, lV11cResidentGivenName, lV12cResidentLastName, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(4) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A65ResidentLastName = H000I6_A65ResidentLastName[0];
               A64ResidentGivenName = H000I6_A64ResidentGivenName[0];
               A63ResidentBsnNumber = H000I6_A63ResidentBsnNumber[0];
               A72ResidentSalutation = H000I6_A72ResidentSalutation[0];
               A11OrganisationId = H000I6_A11OrganisationId[0];
               A29LocationId = H000I6_A29LocationId[0];
               A62ResidentId = H000I6_A62ResidentId[0];
               /* Execute user event: Load */
               E200I2 ();
               pr_default.readNext(4);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(4) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(4);
            wbEnd = 84;
            WB0I0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0I2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A62ResidentId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A11OrganisationId, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV9cResidentSalutation ,
                                              AV10cResidentBsnNumber ,
                                              AV11cResidentGivenName ,
                                              AV12cResidentLastName ,
                                              A72ResidentSalutation ,
                                              A63ResidentBsnNumber ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              AV6cResidentId ,
                                              AV7cLocationId ,
                                              AV8cOrganisationId } ,
                                              new int[]{
                                              }
         });
         lV9cResidentSalutation = StringUtil.PadR( StringUtil.RTrim( AV9cResidentSalutation), 20, "%");
         lV10cResidentBsnNumber = StringUtil.Concat( StringUtil.RTrim( AV10cResidentBsnNumber), "%", "");
         lV11cResidentGivenName = StringUtil.Concat( StringUtil.RTrim( AV11cResidentGivenName), "%", "");
         lV12cResidentLastName = StringUtil.Concat( StringUtil.RTrim( AV12cResidentLastName), "%", "");
         /* Using cursor H000I7 */
         pr_default.execute(5, new Object[] {AV6cResidentId, AV7cLocationId, AV8cOrganisationId, lV9cResidentSalutation, lV10cResidentBsnNumber, lV11cResidentGivenName, lV12cResidentLastName});
         GRID1_nRecordCount = H000I7_AGRID1_nRecordCount[0];
         pr_default.close(5);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentId, AV7cLocationId, AV8cOrganisationId, AV9cResidentSalutation, AV10cResidentBsnNumber, AV11cResidentGivenName, AV12cResidentLastName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtResidentId_Enabled = 0;
         dynLocationId.Enabled = 0;
         dynOrganisationId.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCresidentid_Internalname), "") == 0 )
            {
               AV6cResidentId = Guid.Empty;
               AssignAttri("", false, "AV6cResidentId", AV6cResidentId.ToString());
            }
            else
            {
               try
               {
                  AV6cResidentId = StringUtil.StrToGuid( cgiGet( edtavCresidentid_Internalname));
                  AssignAttri("", false, "AV6cResidentId", AV6cResidentId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCRESIDENTID");
                  GX_FocusControl = edtavCresidentid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            dynavClocationid.Name = dynavClocationid_Internalname;
            dynavClocationid.CurrentValue = cgiGet( dynavClocationid_Internalname);
            AV7cLocationId = StringUtil.StrToGuid( cgiGet( dynavClocationid_Internalname));
            AssignAttri("", false, "AV7cLocationId", AV7cLocationId.ToString());
            dynavCorganisationid.Name = dynavCorganisationid_Internalname;
            dynavCorganisationid.CurrentValue = cgiGet( dynavCorganisationid_Internalname);
            AV8cOrganisationId = StringUtil.StrToGuid( cgiGet( dynavCorganisationid_Internalname));
            AssignAttri("", false, "AV8cOrganisationId", AV8cOrganisationId.ToString());
            cmbavCresidentsalutation.Name = cmbavCresidentsalutation_Internalname;
            cmbavCresidentsalutation.CurrentValue = cgiGet( cmbavCresidentsalutation_Internalname);
            AV9cResidentSalutation = cgiGet( cmbavCresidentsalutation_Internalname);
            AssignAttri("", false, "AV9cResidentSalutation", AV9cResidentSalutation);
            AV10cResidentBsnNumber = cgiGet( edtavCresidentbsnnumber_Internalname);
            AssignAttri("", false, "AV10cResidentBsnNumber", AV10cResidentBsnNumber);
            AV11cResidentGivenName = cgiGet( edtavCresidentgivenname_Internalname);
            AssignAttri("", false, "AV11cResidentGivenName", AV11cResidentGivenName);
            AV12cResidentLastName = cgiGet( edtavCresidentlastname_Internalname);
            AssignAttri("", false, "AV12cResidentLastName", AV12cResidentLastName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCRESIDENTID")) != AV6cResidentId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCLOCATIONID")) != AV7cLocationId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV8cOrganisationId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTSALUTATION"), AV9cResidentSalutation) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTBSNNUMBER"), AV10cResidentBsnNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTGIVENNAME"), AV11cResidentGivenName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTLASTNAME"), AV12cResidentLastName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E190I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190I2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Resident", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV16ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200I2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210I2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pResidentId = A62ResidentId;
         AssignAttri("", false, "AV13pResidentId", AV13pResidentId.ToString());
         AV14pLocationId = A29LocationId;
         AssignAttri("", false, "AV14pLocationId", AV14pLocationId.ToString());
         AV15pOrganisationId = A11OrganisationId;
         AssignAttri("", false, "AV15pOrganisationId", AV15pOrganisationId.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV13pResidentId,(Guid)AV14pLocationId,(Guid)AV15pOrganisationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pResidentId","AV14pLocationId","AV15pOrganisationId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pResidentId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV13pResidentId", AV13pResidentId.ToString());
         AV14pLocationId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV14pLocationId", AV14pLocationId.ToString());
         AV15pOrganisationId = (Guid)getParm(obj,2);
         AssignAttri("", false, "AV15pOrganisationId", AV15pOrganisationId.ToString());
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
         PA0I2( ) ;
         WS0I2( ) ;
         WE0I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492316274789", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx00g0.js", "?202492316274789", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_84_idx;
         dynLocationId_Internalname = "LOCATIONID_"+sGXsfl_84_idx;
         dynOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_84_fel_idx;
         dynLocationId_Internalname = "LOCATIONID_"+sGXsfl_84_fel_idx;
         dynOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB0I0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A62ResidentId.ToString())+"'"+", "+"'"+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"'"+", "+"'"+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentId_Internalname,A62ResidentId.ToString(),A62ResidentId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)84,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynLocationId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LOCATIONID_" + sGXsfl_84_idx;
               dynLocationId.Name = GXCCtl;
               dynLocationId.WebTags = "";
               dynLocationId.removeAllItems();
               /* Using cursor H000I8 */
               pr_default.execute(6);
               while ( (pr_default.getStatus(6) != 101) )
               {
                  dynLocationId.addItem(H000I8_A29LocationId[0].ToString(), H000I8_A31LocationName[0], 0);
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               if ( dynLocationId.ItemCount > 0 )
               {
                  A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynLocationId,(string)dynLocationId_Internalname,A29LocationId.ToString(),(short)1,(string)dynLocationId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp("", false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynOrganisationId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ORGANISATIONID_" + sGXsfl_84_idx;
               dynOrganisationId.Name = GXCCtl;
               dynOrganisationId.WebTags = "";
               dynOrganisationId.removeAllItems();
               /* Using cursor H000I9 */
               pr_default.execute(7);
               while ( (pr_default.getStatus(7) != 101) )
               {
                  dynOrganisationId.addItem(H000I9_A11OrganisationId[0].ToString(), H000I9_A13OrganisationName[0], 0);
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               if ( dynOrganisationId.ItemCount > 0 )
               {
                  A11OrganisationId = StringUtil.StrToGuid( dynOrganisationId.getValidValue(A11OrganisationId.ToString()));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynOrganisationId,(string)dynOrganisationId_Internalname,A11OrganisationId.ToString(),(short)1,(string)dynOrganisationId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynOrganisationId.CurrentValue = A11OrganisationId.ToString();
            AssignProp("", false, dynOrganisationId_Internalname, "Values", (string)(dynOrganisationId.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            send_integrity_lvl_hashes0I2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         dynavClocationid.Name = "vCLOCATIONID";
         dynavClocationid.WebTags = "";
         dynavClocationid.removeAllItems();
         /* Using cursor H000I10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynavClocationid.addItem(H000I10_A29LocationId[0].ToString(), H000I10_A31LocationName[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynavClocationid.ItemCount > 0 )
         {
            AV7cLocationId = StringUtil.StrToGuid( dynavClocationid.getValidValue(AV7cLocationId.ToString()));
            AssignAttri("", false, "AV7cLocationId", AV7cLocationId.ToString());
         }
         dynavCorganisationid.Name = "vCORGANISATIONID";
         dynavCorganisationid.WebTags = "";
         dynavCorganisationid.removeAllItems();
         /* Using cursor H000I11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            dynavCorganisationid.addItem(H000I11_A11OrganisationId[0].ToString(), H000I11_A13OrganisationName[0], 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         if ( dynavCorganisationid.ItemCount > 0 )
         {
            AV8cOrganisationId = StringUtil.StrToGuid( dynavCorganisationid.getValidValue(AV8cOrganisationId.ToString()));
            AssignAttri("", false, "AV8cOrganisationId", AV8cOrganisationId.ToString());
         }
         cmbavCresidentsalutation.Name = "vCRESIDENTSALUTATION";
         cmbavCresidentsalutation.WebTags = "";
         cmbavCresidentsalutation.addItem("Mr", "Mr", 0);
         cmbavCresidentsalutation.addItem("Mrs", "Mrs", 0);
         cmbavCresidentsalutation.addItem("Dr", "Dr", 0);
         cmbavCresidentsalutation.addItem("Miss", "Miss", 0);
         if ( cmbavCresidentsalutation.ItemCount > 0 )
         {
            AV9cResidentSalutation = cmbavCresidentsalutation.getValidValue(AV9cResidentSalutation);
            AssignAttri("", false, "AV9cResidentSalutation", AV9cResidentSalutation);
         }
         GXCCtl = "LOCATIONID_" + sGXsfl_84_idx;
         dynLocationId.Name = GXCCtl;
         dynLocationId.WebTags = "";
         dynLocationId.removeAllItems();
         /* Using cursor H000I12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            dynLocationId.addItem(H000I12_A29LocationId[0].ToString(), H000I12_A31LocationName[0], 0);
            pr_default.readNext(10);
         }
         pr_default.close(10);
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         GXCCtl = "ORGANISATIONID_" + sGXsfl_84_idx;
         dynOrganisationId.Name = GXCCtl;
         dynOrganisationId.WebTags = "";
         dynOrganisationId.removeAllItems();
         /* Using cursor H000I13 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            dynOrganisationId.addItem(H000I13_A11OrganisationId[0].ToString(), H000I13_A13OrganisationName[0], 0);
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( dynOrganisationId.ItemCount > 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( dynOrganisationId.getValidValue(A11OrganisationId.ToString()));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Location Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Organisation Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A62ResidentId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblresidentidfilter_Internalname = "LBLRESIDENTIDFILTER";
         edtavCresidentid_Internalname = "vCRESIDENTID";
         divResidentidfiltercontainer_Internalname = "RESIDENTIDFILTERCONTAINER";
         lblLbllocationidfilter_Internalname = "LBLLOCATIONIDFILTER";
         dynavClocationid_Internalname = "vCLOCATIONID";
         divLocationidfiltercontainer_Internalname = "LOCATIONIDFILTERCONTAINER";
         lblLblorganisationidfilter_Internalname = "LBLORGANISATIONIDFILTER";
         dynavCorganisationid_Internalname = "vCORGANISATIONID";
         divOrganisationidfiltercontainer_Internalname = "ORGANISATIONIDFILTERCONTAINER";
         lblLblresidentsalutationfilter_Internalname = "LBLRESIDENTSALUTATIONFILTER";
         cmbavCresidentsalutation_Internalname = "vCRESIDENTSALUTATION";
         divResidentsalutationfiltercontainer_Internalname = "RESIDENTSALUTATIONFILTERCONTAINER";
         lblLblresidentbsnnumberfilter_Internalname = "LBLRESIDENTBSNNUMBERFILTER";
         edtavCresidentbsnnumber_Internalname = "vCRESIDENTBSNNUMBER";
         divResidentbsnnumberfiltercontainer_Internalname = "RESIDENTBSNNUMBERFILTERCONTAINER";
         lblLblresidentgivennamefilter_Internalname = "LBLRESIDENTGIVENNAMEFILTER";
         edtavCresidentgivenname_Internalname = "vCRESIDENTGIVENNAME";
         divResidentgivennamefiltercontainer_Internalname = "RESIDENTGIVENNAMEFILTERCONTAINER";
         lblLblresidentlastnamefilter_Internalname = "LBLRESIDENTLASTNAMEFILTER";
         edtavCresidentlastname_Internalname = "vCRESIDENTLASTNAME";
         divResidentlastnamefiltercontainer_Internalname = "RESIDENTLASTNAMEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtResidentId_Internalname = "RESIDENTID";
         dynLocationId_Internalname = "LOCATIONID";
         dynOrganisationId_Internalname = "ORGANISATIONID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         dynOrganisationId_Jsonclick = "";
         dynLocationId_Jsonclick = "";
         edtResidentId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         dynOrganisationId.Enabled = 0;
         dynLocationId.Enabled = 0;
         edtResidentId_Enabled = 0;
         edtavCresidentlastname_Jsonclick = "";
         edtavCresidentlastname_Enabled = 1;
         edtavCresidentlastname_Visible = 1;
         edtavCresidentgivenname_Jsonclick = "";
         edtavCresidentgivenname_Enabled = 1;
         edtavCresidentgivenname_Visible = 1;
         edtavCresidentbsnnumber_Jsonclick = "";
         edtavCresidentbsnnumber_Enabled = 1;
         edtavCresidentbsnnumber_Visible = 1;
         cmbavCresidentsalutation_Jsonclick = "";
         cmbavCresidentsalutation.Visible = 1;
         cmbavCresidentsalutation.Enabled = 1;
         dynavCorganisationid_Jsonclick = "";
         dynavCorganisationid.Visible = 1;
         dynavCorganisationid.Enabled = 1;
         dynavClocationid_Jsonclick = "";
         dynavClocationid.Visible = 1;
         dynavClocationid.Enabled = 1;
         edtavCresidentid_Jsonclick = "";
         edtavCresidentid_Enabled = 1;
         edtavCresidentid_Visible = 1;
         divResidentlastnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentgivennamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentbsnnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentsalutationfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divLocationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Resident";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentId","fld":"vCRESIDENTID"},{"av":"cmbavCresidentsalutation"},{"av":"AV9cResidentSalutation","fld":"vCRESIDENTSALUTATION"},{"av":"AV10cResidentBsnNumber","fld":"vCRESIDENTBSNNUMBER"},{"av":"AV11cResidentGivenName","fld":"vCRESIDENTGIVENNAME"},{"av":"AV12cResidentLastName","fld":"vCRESIDENTLASTNAME"},{"av":"dynavCorganisationid"},{"av":"AV8cOrganisationId","fld":"vCORGANISATIONID"},{"av":"dynavClocationid"},{"av":"AV7cLocationId","fld":"vCLOCATIONID"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E180I1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLRESIDENTIDFILTER.CLICK","""{"handler":"E110I1","iparms":[{"av":"divResidentidfiltercontainer_Class","ctrl":"RESIDENTIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTIDFILTER.CLICK",""","oparms":[{"av":"divResidentidfiltercontainer_Class","ctrl":"RESIDENTIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentid_Visible","ctrl":"vCRESIDENTID","prop":"Visible"}]}""");
         setEventMetadata("LBLLOCATIONIDFILTER.CLICK","""{"handler":"E120I1","iparms":[{"av":"divLocationidfiltercontainer_Class","ctrl":"LOCATIONIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLLOCATIONIDFILTER.CLICK",""","oparms":[{"av":"divLocationidfiltercontainer_Class","ctrl":"LOCATIONIDFILTERCONTAINER","prop":"Class"},{"av":"dynavClocationid"}]}""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK","""{"handler":"E130I1","iparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK",""","oparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"},{"av":"dynavCorganisationid"}]}""");
         setEventMetadata("LBLRESIDENTSALUTATIONFILTER.CLICK","""{"handler":"E140I1","iparms":[{"av":"divResidentsalutationfiltercontainer_Class","ctrl":"RESIDENTSALUTATIONFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTSALUTATIONFILTER.CLICK",""","oparms":[{"av":"divResidentsalutationfiltercontainer_Class","ctrl":"RESIDENTSALUTATIONFILTERCONTAINER","prop":"Class"},{"av":"cmbavCresidentsalutation"}]}""");
         setEventMetadata("LBLRESIDENTBSNNUMBERFILTER.CLICK","""{"handler":"E150I1","iparms":[{"av":"divResidentbsnnumberfiltercontainer_Class","ctrl":"RESIDENTBSNNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTBSNNUMBERFILTER.CLICK",""","oparms":[{"av":"divResidentbsnnumberfiltercontainer_Class","ctrl":"RESIDENTBSNNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentbsnnumber_Visible","ctrl":"vCRESIDENTBSNNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTGIVENNAMEFILTER.CLICK","""{"handler":"E160I1","iparms":[{"av":"divResidentgivennamefiltercontainer_Class","ctrl":"RESIDENTGIVENNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTGIVENNAMEFILTER.CLICK",""","oparms":[{"av":"divResidentgivennamefiltercontainer_Class","ctrl":"RESIDENTGIVENNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentgivenname_Visible","ctrl":"vCRESIDENTGIVENNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTLASTNAMEFILTER.CLICK","""{"handler":"E170I1","iparms":[{"av":"divResidentlastnamefiltercontainer_Class","ctrl":"RESIDENTLASTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTLASTNAMEFILTER.CLICK",""","oparms":[{"av":"divResidentlastnamefiltercontainer_Class","ctrl":"RESIDENTLASTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentlastname_Visible","ctrl":"vCRESIDENTLASTNAME","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E210I2","iparms":[{"av":"A62ResidentId","fld":"RESIDENTID","hsh":true},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"dynOrganisationId"},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pResidentId","fld":"vPRESIDENTID"},{"av":"AV14pLocationId","fld":"vPLOCATIONID"},{"av":"AV15pOrganisationId","fld":"vPORGANISATIONID"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentId","fld":"vCRESIDENTID"},{"av":"cmbavCresidentsalutation"},{"av":"AV9cResidentSalutation","fld":"vCRESIDENTSALUTATION"},{"av":"AV10cResidentBsnNumber","fld":"vCRESIDENTBSNNUMBER"},{"av":"AV11cResidentGivenName","fld":"vCRESIDENTGIVENNAME"},{"av":"AV12cResidentLastName","fld":"vCRESIDENTLASTNAME"},{"av":"dynavCorganisationid"},{"av":"AV8cOrganisationId","fld":"vCORGANISATIONID"},{"av":"dynavClocationid"},{"av":"AV7cLocationId","fld":"vCLOCATIONID"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentId","fld":"vCRESIDENTID"},{"av":"cmbavCresidentsalutation"},{"av":"AV9cResidentSalutation","fld":"vCRESIDENTSALUTATION"},{"av":"AV10cResidentBsnNumber","fld":"vCRESIDENTBSNNUMBER"},{"av":"AV11cResidentGivenName","fld":"vCRESIDENTGIVENNAME"},{"av":"AV12cResidentLastName","fld":"vCRESIDENTLASTNAME"},{"av":"dynavCorganisationid"},{"av":"AV8cOrganisationId","fld":"vCORGANISATIONID"},{"av":"dynavClocationid"},{"av":"AV7cLocationId","fld":"vCLOCATIONID"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentId","fld":"vCRESIDENTID"},{"av":"cmbavCresidentsalutation"},{"av":"AV9cResidentSalutation","fld":"vCRESIDENTSALUTATION"},{"av":"AV10cResidentBsnNumber","fld":"vCRESIDENTBSNNUMBER"},{"av":"AV11cResidentGivenName","fld":"vCRESIDENTGIVENNAME"},{"av":"AV12cResidentLastName","fld":"vCRESIDENTLASTNAME"},{"av":"dynavCorganisationid"},{"av":"AV8cOrganisationId","fld":"vCORGANISATIONID"},{"av":"dynavClocationid"},{"av":"AV7cLocationId","fld":"vCLOCATIONID"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentId","fld":"vCRESIDENTID"},{"av":"cmbavCresidentsalutation"},{"av":"AV9cResidentSalutation","fld":"vCRESIDENTSALUTATION"},{"av":"AV10cResidentBsnNumber","fld":"vCRESIDENTBSNNUMBER"},{"av":"AV11cResidentGivenName","fld":"vCRESIDENTGIVENNAME"},{"av":"AV12cResidentLastName","fld":"vCRESIDENTLASTNAME"},{"av":"dynavCorganisationid"},{"av":"AV8cOrganisationId","fld":"vCORGANISATIONID"},{"av":"dynavClocationid"},{"av":"AV7cLocationId","fld":"vCLOCATIONID"}]}""");
         setEventMetadata("VALIDV_CRESIDENTID","""{"handler":"Validv_Cresidentid","iparms":[]}""");
         setEventMetadata("VALIDV_CLOCATIONID","""{"handler":"Validv_Clocationid","iparms":[]}""");
         setEventMetadata("VALIDV_CORGANISATIONID","""{"handler":"Validv_Corganisationid","iparms":[]}""");
         setEventMetadata("VALIDV_CRESIDENTSALUTATION","""{"handler":"Validv_Cresidentsalutation","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Organisationid","iparms":[]}""");
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
         AV13pResidentId = Guid.Empty;
         AV14pLocationId = Guid.Empty;
         AV15pOrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cResidentId = Guid.Empty;
         AV7cLocationId = Guid.Empty;
         AV8cOrganisationId = Guid.Empty;
         AV9cResidentSalutation = "";
         AV10cResidentBsnNumber = "";
         AV11cResidentGivenName = "";
         AV12cResidentLastName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblresidentidfilter_Jsonclick = "";
         TempTags = "";
         lblLbllocationidfilter_Jsonclick = "";
         lblLblorganisationidfilter_Jsonclick = "";
         lblLblresidentsalutationfilter_Jsonclick = "";
         lblLblresidentbsnnumberfilter_Jsonclick = "";
         lblLblresidentgivennamefilter_Jsonclick = "";
         lblLblresidentlastnamefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV17Linkselection_GXI = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H000I2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I2_A13OrganisationName = new string[] {""} ;
         H000I3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I3_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I3_A31LocationName = new string[] {""} ;
         H000I4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I4_A13OrganisationName = new string[] {""} ;
         H000I5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I5_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I5_A31LocationName = new string[] {""} ;
         lV9cResidentSalutation = "";
         lV10cResidentBsnNumber = "";
         lV11cResidentGivenName = "";
         lV12cResidentLastName = "";
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         H000I6_A65ResidentLastName = new string[] {""} ;
         H000I6_A64ResidentGivenName = new string[] {""} ;
         H000I6_A63ResidentBsnNumber = new string[] {""} ;
         H000I6_A72ResidentSalutation = new string[] {""} ;
         H000I6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I6_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I6_A62ResidentId = new Guid[] {Guid.Empty} ;
         H000I7_AGRID1_nRecordCount = new long[1] ;
         AV16ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         H000I8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I8_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I8_A31LocationName = new string[] {""} ;
         H000I9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I9_A13OrganisationName = new string[] {""} ;
         H000I10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I10_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I10_A31LocationName = new string[] {""} ;
         H000I11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I11_A13OrganisationName = new string[] {""} ;
         H000I12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I12_A29LocationId = new Guid[] {Guid.Empty} ;
         H000I12_A31LocationName = new string[] {""} ;
         H000I13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H000I13_A13OrganisationName = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00g0__default(),
            new Object[][] {
                new Object[] {
               H000I2_A11OrganisationId, H000I2_A13OrganisationName
               }
               , new Object[] {
               H000I3_A11OrganisationId, H000I3_A29LocationId, H000I3_A31LocationName
               }
               , new Object[] {
               H000I4_A11OrganisationId, H000I4_A13OrganisationName
               }
               , new Object[] {
               H000I5_A11OrganisationId, H000I5_A29LocationId, H000I5_A31LocationName
               }
               , new Object[] {
               H000I6_A65ResidentLastName, H000I6_A64ResidentGivenName, H000I6_A63ResidentBsnNumber, H000I6_A72ResidentSalutation, H000I6_A11OrganisationId, H000I6_A29LocationId, H000I6_A62ResidentId
               }
               , new Object[] {
               H000I7_AGRID1_nRecordCount
               }
               , new Object[] {
               H000I8_A11OrganisationId, H000I8_A29LocationId, H000I8_A31LocationName
               }
               , new Object[] {
               H000I9_A11OrganisationId, H000I9_A13OrganisationName
               }
               , new Object[] {
               H000I10_A11OrganisationId, H000I10_A29LocationId, H000I10_A31LocationName
               }
               , new Object[] {
               H000I11_A11OrganisationId, H000I11_A13OrganisationName
               }
               , new Object[] {
               H000I12_A11OrganisationId, H000I12_A29LocationId, H000I12_A31LocationName
               }
               , new Object[] {
               H000I13_A11OrganisationId, H000I13_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCresidentid_Visible ;
      private int edtavCresidentid_Enabled ;
      private int edtavCresidentbsnnumber_Visible ;
      private int edtavCresidentbsnnumber_Enabled ;
      private int edtavCresidentgivenname_Visible ;
      private int edtavCresidentgivenname_Enabled ;
      private int edtavCresidentlastname_Visible ;
      private int edtavCresidentlastname_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtResidentId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divResidentidfiltercontainer_Class ;
      private string divLocationidfiltercontainer_Class ;
      private string divOrganisationidfiltercontainer_Class ;
      private string divResidentsalutationfiltercontainer_Class ;
      private string divResidentbsnnumberfiltercontainer_Class ;
      private string divResidentgivennamefiltercontainer_Class ;
      private string divResidentlastnamefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV9cResidentSalutation ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divResidentidfiltercontainer_Internalname ;
      private string lblLblresidentidfilter_Internalname ;
      private string lblLblresidentidfilter_Jsonclick ;
      private string edtavCresidentid_Internalname ;
      private string TempTags ;
      private string edtavCresidentid_Jsonclick ;
      private string divLocationidfiltercontainer_Internalname ;
      private string lblLbllocationidfilter_Internalname ;
      private string lblLbllocationidfilter_Jsonclick ;
      private string dynavClocationid_Internalname ;
      private string dynavClocationid_Jsonclick ;
      private string divOrganisationidfiltercontainer_Internalname ;
      private string lblLblorganisationidfilter_Internalname ;
      private string lblLblorganisationidfilter_Jsonclick ;
      private string dynavCorganisationid_Internalname ;
      private string dynavCorganisationid_Jsonclick ;
      private string divResidentsalutationfiltercontainer_Internalname ;
      private string lblLblresidentsalutationfilter_Internalname ;
      private string lblLblresidentsalutationfilter_Jsonclick ;
      private string cmbavCresidentsalutation_Internalname ;
      private string cmbavCresidentsalutation_Jsonclick ;
      private string divResidentbsnnumberfiltercontainer_Internalname ;
      private string lblLblresidentbsnnumberfilter_Internalname ;
      private string lblLblresidentbsnnumberfilter_Jsonclick ;
      private string edtavCresidentbsnnumber_Internalname ;
      private string edtavCresidentbsnnumber_Jsonclick ;
      private string divResidentgivennamefiltercontainer_Internalname ;
      private string lblLblresidentgivennamefilter_Internalname ;
      private string lblLblresidentgivennamefilter_Jsonclick ;
      private string edtavCresidentgivenname_Internalname ;
      private string edtavCresidentgivenname_Jsonclick ;
      private string divResidentlastnamefiltercontainer_Internalname ;
      private string lblLblresidentlastnamefilter_Internalname ;
      private string lblLblresidentlastnamefilter_Jsonclick ;
      private string edtavCresidentlastname_Internalname ;
      private string edtavCresidentlastname_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtResidentId_Internalname ;
      private string dynLocationId_Internalname ;
      private string dynOrganisationId_Internalname ;
      private string gxwrpcisep ;
      private string lV9cResidentSalutation ;
      private string A72ResidentSalutation ;
      private string AV16ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtResidentId_Jsonclick ;
      private string GXCCtl ;
      private string dynLocationId_Jsonclick ;
      private string dynOrganisationId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV10cResidentBsnNumber ;
      private string AV11cResidentGivenName ;
      private string AV12cResidentLastName ;
      private string AV17Linkselection_GXI ;
      private string lV10cResidentBsnNumber ;
      private string lV11cResidentGivenName ;
      private string lV12cResidentLastName ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string AV5LinkSelection ;
      private Guid AV13pResidentId ;
      private Guid AV14pLocationId ;
      private Guid AV15pOrganisationId ;
      private Guid AV6cResidentId ;
      private Guid AV7cLocationId ;
      private Guid AV8cOrganisationId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavClocationid ;
      private GXCombobox dynavCorganisationid ;
      private GXCombobox cmbavCresidentsalutation ;
      private GXCombobox dynLocationId ;
      private GXCombobox dynOrganisationId ;
      private IDataStoreProvider pr_default ;
      private Guid[] H000I2_A11OrganisationId ;
      private string[] H000I2_A13OrganisationName ;
      private Guid[] H000I3_A11OrganisationId ;
      private Guid[] H000I3_A29LocationId ;
      private string[] H000I3_A31LocationName ;
      private Guid[] H000I4_A11OrganisationId ;
      private string[] H000I4_A13OrganisationName ;
      private Guid[] H000I5_A11OrganisationId ;
      private Guid[] H000I5_A29LocationId ;
      private string[] H000I5_A31LocationName ;
      private string[] H000I6_A65ResidentLastName ;
      private string[] H000I6_A64ResidentGivenName ;
      private string[] H000I6_A63ResidentBsnNumber ;
      private string[] H000I6_A72ResidentSalutation ;
      private Guid[] H000I6_A11OrganisationId ;
      private Guid[] H000I6_A29LocationId ;
      private Guid[] H000I6_A62ResidentId ;
      private long[] H000I7_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H000I8_A11OrganisationId ;
      private Guid[] H000I8_A29LocationId ;
      private string[] H000I8_A31LocationName ;
      private Guid[] H000I9_A11OrganisationId ;
      private string[] H000I9_A13OrganisationName ;
      private Guid[] H000I10_A11OrganisationId ;
      private Guid[] H000I10_A29LocationId ;
      private string[] H000I10_A31LocationName ;
      private Guid[] H000I11_A11OrganisationId ;
      private string[] H000I11_A13OrganisationName ;
      private Guid[] H000I12_A11OrganisationId ;
      private Guid[] H000I12_A29LocationId ;
      private string[] H000I12_A31LocationName ;
      private Guid[] H000I13_A11OrganisationId ;
      private string[] H000I13_A13OrganisationName ;
      private Guid aP0_pResidentId ;
      private Guid aP1_pLocationId ;
      private Guid aP2_pOrganisationId ;
   }

   public class gx00g0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000I6( IGxContext context ,
                                             string AV9cResidentSalutation ,
                                             string AV10cResidentBsnNumber ,
                                             string AV11cResidentGivenName ,
                                             string AV12cResidentLastName ,
                                             string A72ResidentSalutation ,
                                             string A63ResidentBsnNumber ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             Guid AV6cResidentId ,
                                             Guid AV7cLocationId ,
                                             Guid AV8cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentLastName, ResidentGivenName, ResidentBsnNumber, ResidentSalutation, OrganisationId, LocationId, ResidentId";
         sFromString = " FROM Trn_Resident";
         sOrderString = "";
         AddWhere(sWhereString, "(ResidentId >= :AV6cResidentId and LocationId >= :AV7cLocationId and OrganisationId >= :AV8cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentSalutation)) )
         {
            AddWhere(sWhereString, "(ResidentSalutation like :lV9cResidentSalutation)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cResidentBsnNumber)) )
         {
            AddWhere(sWhereString, "(ResidentBsnNumber like :lV10cResidentBsnNumber)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cResidentGivenName)) )
         {
            AddWhere(sWhereString, "(ResidentGivenName like :lV11cResidentGivenName)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cResidentLastName)) )
         {
            AddWhere(sWhereString, "(ResidentLastName like :lV12cResidentLastName)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY ResidentId, LocationId, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000I7( IGxContext context ,
                                             string AV9cResidentSalutation ,
                                             string AV10cResidentBsnNumber ,
                                             string AV11cResidentGivenName ,
                                             string AV12cResidentLastName ,
                                             string A72ResidentSalutation ,
                                             string A63ResidentBsnNumber ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             Guid AV6cResidentId ,
                                             Guid AV7cLocationId ,
                                             Guid AV8cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Resident";
         AddWhere(sWhereString, "(ResidentId >= :AV6cResidentId and LocationId >= :AV7cLocationId and OrganisationId >= :AV8cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentSalutation)) )
         {
            AddWhere(sWhereString, "(ResidentSalutation like :lV9cResidentSalutation)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cResidentBsnNumber)) )
         {
            AddWhere(sWhereString, "(ResidentBsnNumber like :lV10cResidentBsnNumber)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cResidentGivenName)) )
         {
            AddWhere(sWhereString, "(ResidentGivenName like :lV11cResidentGivenName)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cResidentLastName)) )
         {
            AddWhere(sWhereString, "(ResidentLastName like :lV12cResidentLastName)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_H000I6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (Guid)dynConstraints[8] , (Guid)dynConstraints[9] , (Guid)dynConstraints[10] );
               case 5 :
                     return conditional_H000I7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (Guid)dynConstraints[8] , (Guid)dynConstraints[9] , (Guid)dynConstraints[10] );
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
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000I2;
          prmH000I2 = new Object[] {
          };
          Object[] prmH000I3;
          prmH000I3 = new Object[] {
          };
          Object[] prmH000I4;
          prmH000I4 = new Object[] {
          };
          Object[] prmH000I5;
          prmH000I5 = new Object[] {
          };
          Object[] prmH000I8;
          prmH000I8 = new Object[] {
          };
          Object[] prmH000I9;
          prmH000I9 = new Object[] {
          };
          Object[] prmH000I10;
          prmH000I10 = new Object[] {
          };
          Object[] prmH000I11;
          prmH000I11 = new Object[] {
          };
          Object[] prmH000I12;
          prmH000I12 = new Object[] {
          };
          Object[] prmH000I13;
          prmH000I13 = new Object[] {
          };
          Object[] prmH000I6;
          prmH000I6 = new Object[] {
          new ParDef("AV6cResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV7cLocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV9cResidentSalutation",GXType.Char,20,0) ,
          new ParDef("lV10cResidentBsnNumber",GXType.VarChar,40,0) ,
          new ParDef("lV11cResidentGivenName",GXType.VarChar,100,0) ,
          new ParDef("lV12cResidentLastName",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000I7;
          prmH000I7 = new Object[] {
          new ParDef("AV6cResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV7cLocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV9cResidentSalutation",GXType.Char,20,0) ,
          new ParDef("lV10cResidentBsnNumber",GXType.VarChar,40,0) ,
          new ParDef("lV11cResidentGivenName",GXType.VarChar,100,0) ,
          new ParDef("lV12cResidentLastName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000I2", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I3", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I4", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I5", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I6,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I8", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I9", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I10", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I10,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I11", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I11,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I12", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I12,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I13", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I13,0, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 11 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
