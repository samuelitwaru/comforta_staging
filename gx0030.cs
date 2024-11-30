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
   public class gx0030 : GXDataArea
   {
      public gx0030( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0030( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_pOrganisationId )
      {
         this.AV13pOrganisationId = Guid.Empty ;
         ExecuteImpl();
         aP0_pOrganisationId=this.AV13pOrganisationId;
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
            gxfirstwebparm = GetFirstPar( "pOrganisationId");
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
               gxfirstwebparm = GetFirstPar( "pOrganisationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pOrganisationId");
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
               AV13pOrganisationId = StringUtil.StrToGuid( gxfirstwebparm);
               AssignAttri("", false, "AV13pOrganisationId", AV13pOrganisationId.ToString());
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
         AV6cOrganisationId = StringUtil.StrToGuid( GetPar( "cOrganisationId"));
         AV7cOrganisationKvkNumber = GetPar( "cOrganisationKvkNumber");
         AV8cOrganisationName = GetPar( "cOrganisationName");
         AV9cOrganisationEmail = GetPar( "cOrganisationEmail");
         AV10cOrganisationPhone = GetPar( "cOrganisationPhone");
         AV11cOrganisationVATNumber = GetPar( "cOrganisationVATNumber");
         AV12cOrganisationTypeId = StringUtil.StrToGuid( GetPar( "cOrganisationTypeId"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
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
            return "gx0030_Execute" ;
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
         PA042( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START042( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0030.aspx", new object[] {UrlEncode(AV13pOrganisationId.ToString())}, new string[] {"pOrganisationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONID", AV6cOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONKVKNUMBER", AV7cOrganisationKvkNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONNAME", AV8cOrganisationName);
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONEMAIL", AV9cOrganisationEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONPHONE", StringUtil.RTrim( AV10cOrganisationPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONVATNUMBER", AV11cOrganisationVATNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCORGANISATIONTYPEID", AV12cOrganisationTypeId.ToString());
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPORGANISATIONID", AV13pOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationkvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONVATNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationvatnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONTYPEIDFILTERCONTAINER_Class", StringUtil.RTrim( divOrganisationtypeidfiltercontainer_Class));
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
            WE042( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT042( ) ;
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
         return formatLink("gx0030.aspx", new object[] {UrlEncode(AV13pOrganisationId.ToString())}, new string[] {"pOrganisationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0030" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Organisation", "") ;
      }

      protected void WB040( )
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
            GxWebStd.gx_div_start( context, divOrganisationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationidfilter_Internalname, context.GetMessage( "Organisation Id", ""), "", "", lblLblorganisationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationid_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationid_Internalname, AV6cOrganisationId.ToString(), AV6cOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationid_Visible, edtavCorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationkvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationkvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationkvknumberfilter_Internalname, context.GetMessage( "Organisation Kvk Number", ""), "", "", lblLblorganisationkvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationkvknumber_Internalname, context.GetMessage( "Organisation Kvk Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationkvknumber_Internalname, AV7cOrganisationKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV7cOrganisationKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationkvknumber_Visible, edtavCorganisationkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationnamefilter_Internalname, context.GetMessage( "Organisation Name", ""), "", "", lblLblorganisationnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationname_Internalname, context.GetMessage( "Organisation Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationname_Internalname, AV8cOrganisationName, StringUtil.RTrim( context.localUtil.Format( AV8cOrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationname_Visible, edtavCorganisationname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationemailfilter_Internalname, context.GetMessage( "Organisation Email", ""), "", "", lblLblorganisationemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationemail_Internalname, context.GetMessage( "Organisation Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationemail_Internalname, AV9cOrganisationEmail, StringUtil.RTrim( context.localUtil.Format( AV9cOrganisationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationemail_Visible, edtavCorganisationemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationphonefilter_Internalname, context.GetMessage( "Organisation Phone", ""), "", "", lblLblorganisationphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationphone_Internalname, context.GetMessage( "Organisation Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationphone_Internalname, StringUtil.RTrim( AV10cOrganisationPhone), StringUtil.RTrim( context.localUtil.Format( AV10cOrganisationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationphone_Visible, edtavCorganisationphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationvatnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationvatnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationvatnumberfilter_Internalname, context.GetMessage( "Organisation VATNumber", ""), "", "", lblLblorganisationvatnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationvatnumber_Internalname, context.GetMessage( "Organisation VATNumber", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationvatnumber_Internalname, AV11cOrganisationVATNumber, StringUtil.RTrim( context.localUtil.Format( AV11cOrganisationVATNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationvatnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationvatnumber_Visible, edtavCorganisationvatnumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divOrganisationtypeidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrganisationtypeidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorganisationtypeidfilter_Internalname, context.GetMessage( "Organisation Type Id", ""), "", "", lblLblorganisationtypeidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorganisationtypeid_Internalname, context.GetMessage( "Organisation Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorganisationtypeid_Internalname, AV12cOrganisationTypeId.ToString(), AV12cOrganisationTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorganisationtypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorganisationtypeid_Visible, edtavCorganisationtypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18041_client"+"'", TempTags, "", 2, "HLP_Gx0030.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0030.htm");
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

      protected void START042( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Organisation", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP040( ) ;
      }

      protected void WS042( )
      {
         START042( ) ;
         EVT042( ) ;
      }

      protected void EVT042( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A12OrganisationKvkNumber = cgiGet( edtOrganisationKvkNumber_Internalname);
                              A17OrganisationPhone = cgiGet( edtOrganisationPhone_Internalname);
                              A18OrganisationVATNumber = cgiGet( edtOrganisationVATNumber_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19042 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20042 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Corganisationid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV6cOrganisationId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationkvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONKVKNUMBER"), AV7cOrganisationKvkNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONNAME"), AV8cOrganisationName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONEMAIL"), AV9cOrganisationEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONPHONE"), AV10cOrganisationPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationvatnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONVATNUMBER"), AV11cOrganisationVATNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corganisationtypeid Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONTYPEID")) != AV12cOrganisationTypeId )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21042 ();
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

      protected void WE042( )
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

      protected void PA042( )
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
                                        Guid AV6cOrganisationId ,
                                        string AV7cOrganisationKvkNumber ,
                                        string AV8cOrganisationName ,
                                        string AV9cOrganisationEmail ,
                                        string AV10cOrganisationPhone ,
                                        string AV11cOrganisationVATNumber ,
                                        Guid AV12cOrganisationTypeId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF042( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
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
         RF042( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF042( )
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
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cOrganisationKvkNumber ,
                                                 AV8cOrganisationName ,
                                                 AV9cOrganisationEmail ,
                                                 AV10cOrganisationPhone ,
                                                 AV11cOrganisationVATNumber ,
                                                 AV12cOrganisationTypeId ,
                                                 A12OrganisationKvkNumber ,
                                                 A13OrganisationName ,
                                                 A16OrganisationEmail ,
                                                 A17OrganisationPhone ,
                                                 A18OrganisationVATNumber ,
                                                 A19OrganisationTypeId ,
                                                 AV6cOrganisationId } ,
                                                 new int[]{
                                                 }
            });
            lV7cOrganisationKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV7cOrganisationKvkNumber), "%", "");
            lV8cOrganisationName = StringUtil.Concat( StringUtil.RTrim( AV8cOrganisationName), "%", "");
            lV9cOrganisationEmail = StringUtil.Concat( StringUtil.RTrim( AV9cOrganisationEmail), "%", "");
            lV10cOrganisationPhone = StringUtil.PadR( StringUtil.RTrim( AV10cOrganisationPhone), 20, "%");
            /* Using cursor H00042 */
            pr_default.execute(0, new Object[] {AV6cOrganisationId, lV7cOrganisationKvkNumber, lV8cOrganisationName, lV9cOrganisationEmail, lV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A19OrganisationTypeId = H00042_A19OrganisationTypeId[0];
               A16OrganisationEmail = H00042_A16OrganisationEmail[0];
               A13OrganisationName = H00042_A13OrganisationName[0];
               A18OrganisationVATNumber = H00042_A18OrganisationVATNumber[0];
               A17OrganisationPhone = H00042_A17OrganisationPhone[0];
               A12OrganisationKvkNumber = H00042_A12OrganisationKvkNumber[0];
               A11OrganisationId = H00042_A11OrganisationId[0];
               /* Execute user event: Load */
               E20042 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB040( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes042( )
      {
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cOrganisationKvkNumber ,
                                              AV8cOrganisationName ,
                                              AV9cOrganisationEmail ,
                                              AV10cOrganisationPhone ,
                                              AV11cOrganisationVATNumber ,
                                              AV12cOrganisationTypeId ,
                                              A12OrganisationKvkNumber ,
                                              A13OrganisationName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone ,
                                              A18OrganisationVATNumber ,
                                              A19OrganisationTypeId ,
                                              AV6cOrganisationId } ,
                                              new int[]{
                                              }
         });
         lV7cOrganisationKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV7cOrganisationKvkNumber), "%", "");
         lV8cOrganisationName = StringUtil.Concat( StringUtil.RTrim( AV8cOrganisationName), "%", "");
         lV9cOrganisationEmail = StringUtil.Concat( StringUtil.RTrim( AV9cOrganisationEmail), "%", "");
         lV10cOrganisationPhone = StringUtil.PadR( StringUtil.RTrim( AV10cOrganisationPhone), 20, "%");
         /* Using cursor H00043 */
         pr_default.execute(1, new Object[] {AV6cOrganisationId, lV7cOrganisationKvkNumber, lV8cOrganisationName, lV9cOrganisationEmail, lV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId});
         GRID1_nRecordCount = H00043_AGRID1_nRecordCount[0];
         pr_default.close(1);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrganisationId, AV7cOrganisationKvkNumber, AV8cOrganisationName, AV9cOrganisationEmail, AV10cOrganisationPhone, AV11cOrganisationVATNumber, AV12cOrganisationTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtOrganisationId_Enabled = 0;
         edtOrganisationKvkNumber_Enabled = 0;
         edtOrganisationPhone_Enabled = 0;
         edtOrganisationVATNumber_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP040( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19042 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavCorganisationid_Internalname), "") == 0 )
            {
               AV6cOrganisationId = Guid.Empty;
               AssignAttri("", false, "AV6cOrganisationId", AV6cOrganisationId.ToString());
            }
            else
            {
               try
               {
                  AV6cOrganisationId = StringUtil.StrToGuid( cgiGet( edtavCorganisationid_Internalname));
                  AssignAttri("", false, "AV6cOrganisationId", AV6cOrganisationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCORGANISATIONID");
                  GX_FocusControl = edtavCorganisationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV7cOrganisationKvkNumber = cgiGet( edtavCorganisationkvknumber_Internalname);
            AssignAttri("", false, "AV7cOrganisationKvkNumber", AV7cOrganisationKvkNumber);
            AV8cOrganisationName = cgiGet( edtavCorganisationname_Internalname);
            AssignAttri("", false, "AV8cOrganisationName", AV8cOrganisationName);
            AV9cOrganisationEmail = cgiGet( edtavCorganisationemail_Internalname);
            AssignAttri("", false, "AV9cOrganisationEmail", AV9cOrganisationEmail);
            AV10cOrganisationPhone = cgiGet( edtavCorganisationphone_Internalname);
            AssignAttri("", false, "AV10cOrganisationPhone", AV10cOrganisationPhone);
            AV11cOrganisationVATNumber = cgiGet( edtavCorganisationvatnumber_Internalname);
            AssignAttri("", false, "AV11cOrganisationVATNumber", AV11cOrganisationVATNumber);
            if ( StringUtil.StrCmp(cgiGet( edtavCorganisationtypeid_Internalname), "") == 0 )
            {
               AV12cOrganisationTypeId = Guid.Empty;
               AssignAttri("", false, "AV12cOrganisationTypeId", AV12cOrganisationTypeId.ToString());
            }
            else
            {
               try
               {
                  AV12cOrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtavCorganisationtypeid_Internalname));
                  AssignAttri("", false, "AV12cOrganisationTypeId", AV12cOrganisationTypeId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCORGANISATIONTYPEID");
                  GX_FocusControl = edtavCorganisationtypeid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONID")) != AV6cOrganisationId )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONKVKNUMBER"), AV7cOrganisationKvkNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONNAME"), AV8cOrganisationName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONEMAIL"), AV9cOrganisationEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONPHONE"), AV10cOrganisationPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORGANISATIONVATNUMBER"), AV11cOrganisationVATNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCORGANISATIONTYPEID")) != AV12cOrganisationTypeId )
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
         E19042 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19042( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Organisation", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20042( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E21042 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21042( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pOrganisationId = A11OrganisationId;
         AssignAttri("", false, "AV13pOrganisationId", AV13pOrganisationId.ToString());
         context.setWebReturnParms(new Object[] {(Guid)AV13pOrganisationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pOrganisationId"});
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
         AV13pOrganisationId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV13pOrganisationId", AV13pOrganisationId.ToString());
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
         PA042( ) ;
         WS042( ) ;
         WE042( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411211549518", true, true);
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
         context.AddJavascriptSource("gx0030.js", "?202411211549518", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_idx;
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER_"+sGXsfl_84_idx;
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE_"+sGXsfl_84_idx;
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_84_fel_idx;
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER_"+sGXsfl_84_fel_idx;
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE_"+sGXsfl_84_fel_idx;
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB040( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)84,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtOrganisationKvkNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"'"+"]);";
            AssignProp("", false, edtOrganisationKvkNumber_Internalname, "Link", edtOrganisationKvkNumber_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationKvkNumber_Internalname,(string)A12OrganisationKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtOrganisationKvkNumber_Link,(string)"",(string)"",(string)"",(string)edtOrganisationKvkNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A17OrganisationPhone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationPhone_Internalname,StringUtil.RTrim( A17OrganisationPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtOrganisationPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationVATNumber_Internalname,(string)A18OrganisationVATNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationVATNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"VATNumber",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes042( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Kvk Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "VATNumber", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A12OrganisationKvkNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtOrganisationKvkNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17OrganisationPhone)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A18OrganisationVATNumber));
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
         lblLblorganisationidfilter_Internalname = "LBLORGANISATIONIDFILTER";
         edtavCorganisationid_Internalname = "vCORGANISATIONID";
         divOrganisationidfiltercontainer_Internalname = "ORGANISATIONIDFILTERCONTAINER";
         lblLblorganisationkvknumberfilter_Internalname = "LBLORGANISATIONKVKNUMBERFILTER";
         edtavCorganisationkvknumber_Internalname = "vCORGANISATIONKVKNUMBER";
         divOrganisationkvknumberfiltercontainer_Internalname = "ORGANISATIONKVKNUMBERFILTERCONTAINER";
         lblLblorganisationnamefilter_Internalname = "LBLORGANISATIONNAMEFILTER";
         edtavCorganisationname_Internalname = "vCORGANISATIONNAME";
         divOrganisationnamefiltercontainer_Internalname = "ORGANISATIONNAMEFILTERCONTAINER";
         lblLblorganisationemailfilter_Internalname = "LBLORGANISATIONEMAILFILTER";
         edtavCorganisationemail_Internalname = "vCORGANISATIONEMAIL";
         divOrganisationemailfiltercontainer_Internalname = "ORGANISATIONEMAILFILTERCONTAINER";
         lblLblorganisationphonefilter_Internalname = "LBLORGANISATIONPHONEFILTER";
         edtavCorganisationphone_Internalname = "vCORGANISATIONPHONE";
         divOrganisationphonefiltercontainer_Internalname = "ORGANISATIONPHONEFILTERCONTAINER";
         lblLblorganisationvatnumberfilter_Internalname = "LBLORGANISATIONVATNUMBERFILTER";
         edtavCorganisationvatnumber_Internalname = "vCORGANISATIONVATNUMBER";
         divOrganisationvatnumberfiltercontainer_Internalname = "ORGANISATIONVATNUMBERFILTERCONTAINER";
         lblLblorganisationtypeidfilter_Internalname = "LBLORGANISATIONTYPEIDFILTER";
         edtavCorganisationtypeid_Internalname = "vCORGANISATIONTYPEID";
         divOrganisationtypeidfiltercontainer_Internalname = "ORGANISATIONTYPEIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER";
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE";
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER";
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
         edtOrganisationVATNumber_Jsonclick = "";
         edtOrganisationPhone_Jsonclick = "";
         edtOrganisationKvkNumber_Jsonclick = "";
         edtOrganisationKvkNumber_Link = "";
         edtOrganisationId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtOrganisationVATNumber_Enabled = 0;
         edtOrganisationPhone_Enabled = 0;
         edtOrganisationKvkNumber_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtavCorganisationtypeid_Jsonclick = "";
         edtavCorganisationtypeid_Enabled = 1;
         edtavCorganisationtypeid_Visible = 1;
         edtavCorganisationvatnumber_Jsonclick = "";
         edtavCorganisationvatnumber_Enabled = 1;
         edtavCorganisationvatnumber_Visible = 1;
         edtavCorganisationphone_Jsonclick = "";
         edtavCorganisationphone_Enabled = 1;
         edtavCorganisationphone_Visible = 1;
         edtavCorganisationemail_Jsonclick = "";
         edtavCorganisationemail_Enabled = 1;
         edtavCorganisationemail_Visible = 1;
         edtavCorganisationname_Jsonclick = "";
         edtavCorganisationname_Enabled = 1;
         edtavCorganisationname_Visible = 1;
         edtavCorganisationkvknumber_Jsonclick = "";
         edtavCorganisationkvknumber_Enabled = 1;
         edtavCorganisationkvknumber_Visible = 1;
         edtavCorganisationid_Jsonclick = "";
         edtavCorganisationid_Enabled = 1;
         edtavCorganisationid_Visible = 1;
         divOrganisationtypeidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationvatnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationkvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOrganisationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Organisation", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV7cOrganisationKvkNumber","fld":"vCORGANISATIONKVKNUMBER"},{"av":"AV8cOrganisationName","fld":"vCORGANISATIONNAME"},{"av":"AV9cOrganisationEmail","fld":"vCORGANISATIONEMAIL"},{"av":"AV10cOrganisationPhone","fld":"vCORGANISATIONPHONE"},{"av":"AV11cOrganisationVATNumber","fld":"vCORGANISATIONVATNUMBER"},{"av":"AV12cOrganisationTypeId","fld":"vCORGANISATIONTYPEID"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E18041","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK","""{"handler":"E11041","iparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONIDFILTER.CLICK",""","oparms":[{"av":"divOrganisationidfiltercontainer_Class","ctrl":"ORGANISATIONIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationid_Visible","ctrl":"vCORGANISATIONID","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONKVKNUMBERFILTER.CLICK","""{"handler":"E12041","iparms":[{"av":"divOrganisationkvknumberfiltercontainer_Class","ctrl":"ORGANISATIONKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divOrganisationkvknumberfiltercontainer_Class","ctrl":"ORGANISATIONKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationkvknumber_Visible","ctrl":"vCORGANISATIONKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONNAMEFILTER.CLICK","""{"handler":"E13041","iparms":[{"av":"divOrganisationnamefiltercontainer_Class","ctrl":"ORGANISATIONNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONNAMEFILTER.CLICK",""","oparms":[{"av":"divOrganisationnamefiltercontainer_Class","ctrl":"ORGANISATIONNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationname_Visible","ctrl":"vCORGANISATIONNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONEMAILFILTER.CLICK","""{"handler":"E14041","iparms":[{"av":"divOrganisationemailfiltercontainer_Class","ctrl":"ORGANISATIONEMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONEMAILFILTER.CLICK",""","oparms":[{"av":"divOrganisationemailfiltercontainer_Class","ctrl":"ORGANISATIONEMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationemail_Visible","ctrl":"vCORGANISATIONEMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONPHONEFILTER.CLICK","""{"handler":"E15041","iparms":[{"av":"divOrganisationphonefiltercontainer_Class","ctrl":"ORGANISATIONPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONPHONEFILTER.CLICK",""","oparms":[{"av":"divOrganisationphonefiltercontainer_Class","ctrl":"ORGANISATIONPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationphone_Visible","ctrl":"vCORGANISATIONPHONE","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONVATNUMBERFILTER.CLICK","""{"handler":"E16041","iparms":[{"av":"divOrganisationvatnumberfiltercontainer_Class","ctrl":"ORGANISATIONVATNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONVATNUMBERFILTER.CLICK",""","oparms":[{"av":"divOrganisationvatnumberfiltercontainer_Class","ctrl":"ORGANISATIONVATNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationvatnumber_Visible","ctrl":"vCORGANISATIONVATNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLORGANISATIONTYPEIDFILTER.CLICK","""{"handler":"E17041","iparms":[{"av":"divOrganisationtypeidfiltercontainer_Class","ctrl":"ORGANISATIONTYPEIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLORGANISATIONTYPEIDFILTER.CLICK",""","oparms":[{"av":"divOrganisationtypeidfiltercontainer_Class","ctrl":"ORGANISATIONTYPEIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCorganisationtypeid_Visible","ctrl":"vCORGANISATIONTYPEID","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E21042","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pOrganisationId","fld":"vPORGANISATIONID"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV7cOrganisationKvkNumber","fld":"vCORGANISATIONKVKNUMBER"},{"av":"AV8cOrganisationName","fld":"vCORGANISATIONNAME"},{"av":"AV9cOrganisationEmail","fld":"vCORGANISATIONEMAIL"},{"av":"AV10cOrganisationPhone","fld":"vCORGANISATIONPHONE"},{"av":"AV11cOrganisationVATNumber","fld":"vCORGANISATIONVATNUMBER"},{"av":"AV12cOrganisationTypeId","fld":"vCORGANISATIONTYPEID"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV7cOrganisationKvkNumber","fld":"vCORGANISATIONKVKNUMBER"},{"av":"AV8cOrganisationName","fld":"vCORGANISATIONNAME"},{"av":"AV9cOrganisationEmail","fld":"vCORGANISATIONEMAIL"},{"av":"AV10cOrganisationPhone","fld":"vCORGANISATIONPHONE"},{"av":"AV11cOrganisationVATNumber","fld":"vCORGANISATIONVATNUMBER"},{"av":"AV12cOrganisationTypeId","fld":"vCORGANISATIONTYPEID"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV7cOrganisationKvkNumber","fld":"vCORGANISATIONKVKNUMBER"},{"av":"AV8cOrganisationName","fld":"vCORGANISATIONNAME"},{"av":"AV9cOrganisationEmail","fld":"vCORGANISATIONEMAIL"},{"av":"AV10cOrganisationPhone","fld":"vCORGANISATIONPHONE"},{"av":"AV11cOrganisationVATNumber","fld":"vCORGANISATIONVATNUMBER"},{"av":"AV12cOrganisationTypeId","fld":"vCORGANISATIONTYPEID"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cOrganisationId","fld":"vCORGANISATIONID"},{"av":"AV7cOrganisationKvkNumber","fld":"vCORGANISATIONKVKNUMBER"},{"av":"AV8cOrganisationName","fld":"vCORGANISATIONNAME"},{"av":"AV9cOrganisationEmail","fld":"vCORGANISATIONEMAIL"},{"av":"AV10cOrganisationPhone","fld":"vCORGANISATIONPHONE"},{"av":"AV11cOrganisationVATNumber","fld":"vCORGANISATIONVATNUMBER"},{"av":"AV12cOrganisationTypeId","fld":"vCORGANISATIONTYPEID"}]}""");
         setEventMetadata("VALIDV_CORGANISATIONID","""{"handler":"Validv_Corganisationid","iparms":[]}""");
         setEventMetadata("VALIDV_CORGANISATIONKVKNUMBER","""{"handler":"Validv_Corganisationkvknumber","iparms":[]}""");
         setEventMetadata("VALIDV_CORGANISATIONEMAIL","""{"handler":"Validv_Corganisationemail","iparms":[]}""");
         setEventMetadata("VALIDV_CORGANISATIONTYPEID","""{"handler":"Validv_Corganisationtypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Organisationvatnumber","iparms":[]}""");
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
         AV13pOrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cOrganisationId = Guid.Empty;
         AV7cOrganisationKvkNumber = "";
         AV8cOrganisationName = "";
         AV9cOrganisationEmail = "";
         AV10cOrganisationPhone = "";
         AV11cOrganisationVATNumber = "";
         AV12cOrganisationTypeId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblorganisationidfilter_Jsonclick = "";
         TempTags = "";
         lblLblorganisationkvknumberfilter_Jsonclick = "";
         lblLblorganisationnamefilter_Jsonclick = "";
         lblLblorganisationemailfilter_Jsonclick = "";
         lblLblorganisationphonefilter_Jsonclick = "";
         lblLblorganisationvatnumberfilter_Jsonclick = "";
         lblLblorganisationtypeidfilter_Jsonclick = "";
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
         AV15Linkselection_GXI = "";
         A11OrganisationId = Guid.Empty;
         A12OrganisationKvkNumber = "";
         A17OrganisationPhone = "";
         A18OrganisationVATNumber = "";
         lV7cOrganisationKvkNumber = "";
         lV8cOrganisationName = "";
         lV9cOrganisationEmail = "";
         lV10cOrganisationPhone = "";
         A13OrganisationName = "";
         A16OrganisationEmail = "";
         A19OrganisationTypeId = Guid.Empty;
         H00042_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H00042_A16OrganisationEmail = new string[] {""} ;
         H00042_A13OrganisationName = new string[] {""} ;
         H00042_A18OrganisationVATNumber = new string[] {""} ;
         H00042_A17OrganisationPhone = new string[] {""} ;
         H00042_A12OrganisationKvkNumber = new string[] {""} ;
         H00042_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00043_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0030__default(),
            new Object[][] {
                new Object[] {
               H00042_A19OrganisationTypeId, H00042_A16OrganisationEmail, H00042_A13OrganisationName, H00042_A18OrganisationVATNumber, H00042_A17OrganisationPhone, H00042_A12OrganisationKvkNumber, H00042_A11OrganisationId
               }
               , new Object[] {
               H00043_AGRID1_nRecordCount
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
      private int edtavCorganisationid_Visible ;
      private int edtavCorganisationid_Enabled ;
      private int edtavCorganisationkvknumber_Visible ;
      private int edtavCorganisationkvknumber_Enabled ;
      private int edtavCorganisationname_Visible ;
      private int edtavCorganisationname_Enabled ;
      private int edtavCorganisationemail_Visible ;
      private int edtavCorganisationemail_Enabled ;
      private int edtavCorganisationphone_Visible ;
      private int edtavCorganisationphone_Enabled ;
      private int edtavCorganisationvatnumber_Visible ;
      private int edtavCorganisationvatnumber_Enabled ;
      private int edtavCorganisationtypeid_Visible ;
      private int edtavCorganisationtypeid_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtOrganisationId_Enabled ;
      private int edtOrganisationKvkNumber_Enabled ;
      private int edtOrganisationPhone_Enabled ;
      private int edtOrganisationVATNumber_Enabled ;
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
      private string divOrganisationidfiltercontainer_Class ;
      private string divOrganisationkvknumberfiltercontainer_Class ;
      private string divOrganisationnamefiltercontainer_Class ;
      private string divOrganisationemailfiltercontainer_Class ;
      private string divOrganisationphonefiltercontainer_Class ;
      private string divOrganisationvatnumberfiltercontainer_Class ;
      private string divOrganisationtypeidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV10cOrganisationPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divOrganisationidfiltercontainer_Internalname ;
      private string lblLblorganisationidfilter_Internalname ;
      private string lblLblorganisationidfilter_Jsonclick ;
      private string edtavCorganisationid_Internalname ;
      private string TempTags ;
      private string edtavCorganisationid_Jsonclick ;
      private string divOrganisationkvknumberfiltercontainer_Internalname ;
      private string lblLblorganisationkvknumberfilter_Internalname ;
      private string lblLblorganisationkvknumberfilter_Jsonclick ;
      private string edtavCorganisationkvknumber_Internalname ;
      private string edtavCorganisationkvknumber_Jsonclick ;
      private string divOrganisationnamefiltercontainer_Internalname ;
      private string lblLblorganisationnamefilter_Internalname ;
      private string lblLblorganisationnamefilter_Jsonclick ;
      private string edtavCorganisationname_Internalname ;
      private string edtavCorganisationname_Jsonclick ;
      private string divOrganisationemailfiltercontainer_Internalname ;
      private string lblLblorganisationemailfilter_Internalname ;
      private string lblLblorganisationemailfilter_Jsonclick ;
      private string edtavCorganisationemail_Internalname ;
      private string edtavCorganisationemail_Jsonclick ;
      private string divOrganisationphonefiltercontainer_Internalname ;
      private string lblLblorganisationphonefilter_Internalname ;
      private string lblLblorganisationphonefilter_Jsonclick ;
      private string edtavCorganisationphone_Internalname ;
      private string edtavCorganisationphone_Jsonclick ;
      private string divOrganisationvatnumberfiltercontainer_Internalname ;
      private string lblLblorganisationvatnumberfilter_Internalname ;
      private string lblLblorganisationvatnumberfilter_Jsonclick ;
      private string edtavCorganisationvatnumber_Internalname ;
      private string edtavCorganisationvatnumber_Jsonclick ;
      private string divOrganisationtypeidfiltercontainer_Internalname ;
      private string lblLblorganisationtypeidfilter_Internalname ;
      private string lblLblorganisationtypeidfilter_Jsonclick ;
      private string edtavCorganisationtypeid_Internalname ;
      private string edtavCorganisationtypeid_Jsonclick ;
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
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationKvkNumber_Internalname ;
      private string A17OrganisationPhone ;
      private string edtOrganisationPhone_Internalname ;
      private string edtOrganisationVATNumber_Internalname ;
      private string lV10cOrganisationPhone ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtOrganisationId_Jsonclick ;
      private string edtOrganisationKvkNumber_Link ;
      private string edtOrganisationKvkNumber_Jsonclick ;
      private string gxphoneLink ;
      private string edtOrganisationPhone_Jsonclick ;
      private string edtOrganisationVATNumber_Jsonclick ;
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
      private string AV7cOrganisationKvkNumber ;
      private string AV8cOrganisationName ;
      private string AV9cOrganisationEmail ;
      private string AV11cOrganisationVATNumber ;
      private string AV15Linkselection_GXI ;
      private string A12OrganisationKvkNumber ;
      private string A18OrganisationVATNumber ;
      private string lV7cOrganisationKvkNumber ;
      private string lV8cOrganisationName ;
      private string lV9cOrganisationEmail ;
      private string A13OrganisationName ;
      private string A16OrganisationEmail ;
      private string AV5LinkSelection ;
      private Guid AV13pOrganisationId ;
      private Guid AV6cOrganisationId ;
      private Guid AV12cOrganisationTypeId ;
      private Guid A11OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00042_A19OrganisationTypeId ;
      private string[] H00042_A16OrganisationEmail ;
      private string[] H00042_A13OrganisationName ;
      private string[] H00042_A18OrganisationVATNumber ;
      private string[] H00042_A17OrganisationPhone ;
      private string[] H00042_A12OrganisationKvkNumber ;
      private Guid[] H00042_A11OrganisationId ;
      private long[] H00043_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid aP0_pOrganisationId ;
   }

   public class gx0030__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00042( IGxContext context ,
                                             string AV7cOrganisationKvkNumber ,
                                             string AV8cOrganisationName ,
                                             string AV9cOrganisationEmail ,
                                             string AV10cOrganisationPhone ,
                                             string AV11cOrganisationVATNumber ,
                                             Guid AV12cOrganisationTypeId ,
                                             string A12OrganisationKvkNumber ,
                                             string A13OrganisationName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone ,
                                             string A18OrganisationVATNumber ,
                                             Guid A19OrganisationTypeId ,
                                             Guid AV6cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationTypeId, OrganisationEmail, OrganisationName, OrganisationVATNumber, OrganisationPhone, OrganisationKvkNumber, OrganisationId";
         sFromString = " FROM Trn_Organisation";
         sOrderString = "";
         AddWhere(sWhereString, "(OrganisationId >= :AV6cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cOrganisationKvkNumber)) )
         {
            AddWhere(sWhereString, "(OrganisationKvkNumber like :lV7cOrganisationKvkNumber)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cOrganisationName)) )
         {
            AddWhere(sWhereString, "(OrganisationName like :lV8cOrganisationName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cOrganisationEmail)) )
         {
            AddWhere(sWhereString, "(OrganisationEmail like :lV9cOrganisationEmail)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cOrganisationPhone)) )
         {
            AddWhere(sWhereString, "(OrganisationPhone like :lV10cOrganisationPhone)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cOrganisationVATNumber)) )
         {
            AddWhere(sWhereString, "(OrganisationVATNumber >= ( :AV11cOrganisationVATNumber))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Guid.Empty==AV12cOrganisationTypeId) )
         {
            AddWhere(sWhereString, "(OrganisationTypeId >= :AV12cOrganisationTypeId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00043( IGxContext context ,
                                             string AV7cOrganisationKvkNumber ,
                                             string AV8cOrganisationName ,
                                             string AV9cOrganisationEmail ,
                                             string AV10cOrganisationPhone ,
                                             string AV11cOrganisationVATNumber ,
                                             Guid AV12cOrganisationTypeId ,
                                             string A12OrganisationKvkNumber ,
                                             string A13OrganisationName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone ,
                                             string A18OrganisationVATNumber ,
                                             Guid A19OrganisationTypeId ,
                                             Guid AV6cOrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Organisation";
         AddWhere(sWhereString, "(OrganisationId >= :AV6cOrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cOrganisationKvkNumber)) )
         {
            AddWhere(sWhereString, "(OrganisationKvkNumber like :lV7cOrganisationKvkNumber)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cOrganisationName)) )
         {
            AddWhere(sWhereString, "(OrganisationName like :lV8cOrganisationName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cOrganisationEmail)) )
         {
            AddWhere(sWhereString, "(OrganisationEmail like :lV9cOrganisationEmail)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cOrganisationPhone)) )
         {
            AddWhere(sWhereString, "(OrganisationPhone like :lV10cOrganisationPhone)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cOrganisationVATNumber)) )
         {
            AddWhere(sWhereString, "(OrganisationVATNumber >= ( :AV11cOrganisationVATNumber))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Guid.Empty==AV12cOrganisationTypeId) )
         {
            AddWhere(sWhereString, "(OrganisationTypeId >= :AV12cOrganisationTypeId)");
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
               case 0 :
                     return conditional_H00042(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (Guid)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (Guid)dynConstraints[11] , (Guid)dynConstraints[12] );
               case 1 :
                     return conditional_H00043(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (Guid)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (Guid)dynConstraints[11] , (Guid)dynConstraints[12] );
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
          Object[] prmH00042;
          prmH00042 = new Object[] {
          new ParDef("AV6cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV7cOrganisationKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cOrganisationName",GXType.VarChar,100,0) ,
          new ParDef("lV9cOrganisationEmail",GXType.VarChar,100,0) ,
          new ParDef("lV10cOrganisationPhone",GXType.Char,20,0) ,
          new ParDef("AV11cOrganisationVATNumber",GXType.VarChar,14,0) ,
          new ParDef("AV12cOrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00043;
          prmH00043 = new Object[] {
          new ParDef("AV6cOrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV7cOrganisationKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cOrganisationName",GXType.VarChar,100,0) ,
          new ParDef("lV9cOrganisationEmail",GXType.VarChar,100,0) ,
          new ParDef("lV10cOrganisationPhone",GXType.Char,20,0) ,
          new ParDef("AV11cOrganisationVATNumber",GXType.VarChar,14,0) ,
          new ParDef("AV12cOrganisationTypeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00042", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00042,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00043", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00043,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
