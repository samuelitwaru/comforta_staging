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
   public class trn_memogeneral : GXWebComponent
   {
      public trn_memogeneral( )
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

      public trn_memogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId )
      {
         this.A575MemoId = aP0_MemoId;
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
         cmbResidentSalutation = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "MemoId");
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
                  A575MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
                  AssignAttri(sPrefix, false, "A575MemoId", A575MemoId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A575MemoId});
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
                  gxfirstwebparm = GetFirstPar( "MemoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MemoId");
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
            PABF2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "Trn_MemoGeneral";
               WSBF2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Memo General", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
            GXEncryptionTmp = "trn_memogeneral.aspx"+UrlEncode(A575MemoId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_memogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA575MemoId", wcpOA575MemoId.ToString());
      }

      protected void RenderHtmlCloseFormBF2( )
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
         return "Trn_MemoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Memo General", "") ;
      }

      protected void WBBF0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_memogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoCategoryName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoCategoryName_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtMemoCategoryName_Internalname, A569MemoCategoryName, StringUtil.RTrim( context.localUtil.Format( A569MemoCategoryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtMemoCategoryName_Link, "", "", "", edtMemoCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoCategoryName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoTitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtMemoTitle_Internalname, A576MemoTitle, StringUtil.RTrim( context.localUtil.Format( A576MemoTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMemoDescription_Internalname, A577MemoDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", 0, 1, edtMemoDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoImage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoImage_Internalname, context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMemoImage_Internalname, A578MemoImage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", 0, 1, edtMemoImage_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDocument_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoDocument_Internalname, context.GetMessage( "Document", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMemoDocument_Internalname, A579MemoDocument, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", 0, 1, edtMemoDocument_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoStartDateTime_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoStartDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtMemoStartDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtMemoStartDateTime_Internalname, context.localUtil.TToC( A587MemoStartDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A587MemoStartDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoStartDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoStartDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtMemoStartDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoStartDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_MemoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoEndDateTime_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoEndDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtMemoEndDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtMemoEndDateTime_Internalname, context.localUtil.TToC( A588MemoEndDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A588MemoEndDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoEndDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoEndDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtMemoEndDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoEndDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_MemoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDuration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoDuration_Internalname, context.GetMessage( "Duration", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtMemoDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A589MemoDuration), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMemoDuration_Enabled!=0) ? context.localUtil.Format( (decimal)(A589MemoDuration), "ZZZ9") : context.localUtil.Format( (decimal)(A589MemoDuration), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoDuration_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoRemoveDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMemoRemoveDate_Internalname, context.GetMessage( "Remove Date", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtMemoRemoveDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtMemoRemoveDate_Internalname, context.localUtil.Format(A590MemoRemoveDate, "99/99/99"), context.localUtil.Format( A590MemoRemoveDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoRemoveDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoRemoveDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtMemoRemoveDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoRemoveDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_MemoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtResidentId_Internalname, context.GetMessage( "Resident", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_MemoGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_MemoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtMemoId_Internalname, A575MemoId.ToString(), A575MemoId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoId_Jsonclick, 0, "Attribute", "", "", "", "", edtMemoId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_MemoGeneral.htm");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", cmbResidentSalutation.Visible, 0, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_Trn_MemoGeneral.htm");
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGivenName_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_MemoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentLastName_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_MemoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_MemoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBF2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Memo General", ""), 0) ;
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
               STRUPBF0( ) ;
            }
         }
      }

      protected void WSBF2( )
      {
         STARTBF2( ) ;
         EVTBF2( ) ;
      }

      protected void EVTBF2( )
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
                                 STRUPBF0( ) ;
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
                                 STRUPBF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11BF2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12BF2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBF0( ) ;
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
                                 STRUPBF0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WEBF2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBF2( ) ;
            }
         }
      }

      protected void PABF2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_memogeneral.aspx")), "trn_memogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_memogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MemoId");
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
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBF2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "Trn_MemoGeneral";
      }

      protected void RFBF2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00BF2 */
            pr_default.execute(0, new Object[] {A575MemoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A555SG_LocationId = H00BF2_A555SG_LocationId[0];
               A29LocationId = H00BF2_A29LocationId[0];
               A556SG_OrganisationId = H00BF2_A556SG_OrganisationId[0];
               A11OrganisationId = H00BF2_A11OrganisationId[0];
               A568MemoCategoryId = H00BF2_A568MemoCategoryId[0];
               A71ResidentGUID = H00BF2_A71ResidentGUID[0];
               AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
               A65ResidentLastName = H00BF2_A65ResidentLastName[0];
               AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
               A64ResidentGivenName = H00BF2_A64ResidentGivenName[0];
               AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
               A72ResidentSalutation = H00BF2_A72ResidentSalutation[0];
               AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
               A62ResidentId = H00BF2_A62ResidentId[0];
               AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
               A590MemoRemoveDate = H00BF2_A590MemoRemoveDate[0];
               AssignAttri(sPrefix, false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
               A589MemoDuration = H00BF2_A589MemoDuration[0];
               n589MemoDuration = H00BF2_n589MemoDuration[0];
               AssignAttri(sPrefix, false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
               A588MemoEndDateTime = H00BF2_A588MemoEndDateTime[0];
               n588MemoEndDateTime = H00BF2_n588MemoEndDateTime[0];
               AssignAttri(sPrefix, false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A587MemoStartDateTime = H00BF2_A587MemoStartDateTime[0];
               n587MemoStartDateTime = H00BF2_n587MemoStartDateTime[0];
               AssignAttri(sPrefix, false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A579MemoDocument = H00BF2_A579MemoDocument[0];
               n579MemoDocument = H00BF2_n579MemoDocument[0];
               AssignAttri(sPrefix, false, "A579MemoDocument", A579MemoDocument);
               A578MemoImage = H00BF2_A578MemoImage[0];
               n578MemoImage = H00BF2_n578MemoImage[0];
               AssignAttri(sPrefix, false, "A578MemoImage", A578MemoImage);
               A577MemoDescription = H00BF2_A577MemoDescription[0];
               AssignAttri(sPrefix, false, "A577MemoDescription", A577MemoDescription);
               A576MemoTitle = H00BF2_A576MemoTitle[0];
               AssignAttri(sPrefix, false, "A576MemoTitle", A576MemoTitle);
               A569MemoCategoryName = H00BF2_A569MemoCategoryName[0];
               AssignAttri(sPrefix, false, "A569MemoCategoryName", A569MemoCategoryName);
               A569MemoCategoryName = H00BF2_A569MemoCategoryName[0];
               AssignAttri(sPrefix, false, "A569MemoCategoryName", A569MemoCategoryName);
               A71ResidentGUID = H00BF2_A71ResidentGUID[0];
               AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
               A65ResidentLastName = H00BF2_A65ResidentLastName[0];
               AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
               A64ResidentGivenName = H00BF2_A64ResidentGivenName[0];
               AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
               A72ResidentSalutation = H00BF2_A72ResidentSalutation[0];
               AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
               /* Execute user event: Load */
               E12BF2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBBF0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBF2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "Trn_MemoGeneral";
         edtMemoCategoryName_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCategoryName_Enabled), 5, 0), true);
         edtMemoTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoTitle_Enabled), 5, 0), true);
         edtMemoDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDescription_Enabled), 5, 0), true);
         edtMemoImage_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoImage_Enabled), 5, 0), true);
         edtMemoDocument_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDocument_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDocument_Enabled), 5, 0), true);
         edtMemoStartDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoStartDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoStartDateTime_Enabled), 5, 0), true);
         edtMemoEndDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoEndDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoEndDateTime_Enabled), 5, 0), true);
         edtMemoDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDuration_Enabled), 5, 0), true);
         edtMemoRemoveDate_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoRemoveDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoRemoveDate_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtMemoId_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         cmbResidentSalutation.Enabled = 0;
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBF0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11BF2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA575MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA575MemoId"));
            /* Read variables values. */
            A569MemoCategoryName = cgiGet( edtMemoCategoryName_Internalname);
            AssignAttri(sPrefix, false, "A569MemoCategoryName", A569MemoCategoryName);
            A576MemoTitle = cgiGet( edtMemoTitle_Internalname);
            AssignAttri(sPrefix, false, "A576MemoTitle", A576MemoTitle);
            A577MemoDescription = cgiGet( edtMemoDescription_Internalname);
            AssignAttri(sPrefix, false, "A577MemoDescription", A577MemoDescription);
            A578MemoImage = cgiGet( edtMemoImage_Internalname);
            n578MemoImage = false;
            AssignAttri(sPrefix, false, "A578MemoImage", A578MemoImage);
            A579MemoDocument = cgiGet( edtMemoDocument_Internalname);
            n579MemoDocument = false;
            AssignAttri(sPrefix, false, "A579MemoDocument", A579MemoDocument);
            A587MemoStartDateTime = context.localUtil.CToT( cgiGet( edtMemoStartDateTime_Internalname));
            n587MemoStartDateTime = false;
            AssignAttri(sPrefix, false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A588MemoEndDateTime = context.localUtil.CToT( cgiGet( edtMemoEndDateTime_Internalname));
            n588MemoEndDateTime = false;
            AssignAttri(sPrefix, false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A589MemoDuration = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n589MemoDuration = false;
            AssignAttri(sPrefix, false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
            A590MemoRemoveDate = context.localUtil.CToD( cgiGet( edtMemoRemoveDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
            A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
            cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
            A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
            AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
            AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
            A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
            AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
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
         E11BF2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11BF2( )
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

      protected void E12BF2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_memocategoryview_Execute", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_memocategoryview.aspx"+UrlEncode(A568MemoCategoryId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMemoCategoryName_Link = formatLink("trn_memocategoryview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtMemoCategoryName_Internalname, "Link", edtMemoCategoryName_Link, true);
         }
         edtMemoId_Visible = 0;
         AssignProp(sPrefix, false, edtMemoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMemoId_Visible), 5, 0), true);
         cmbResidentSalutation.Visible = 0;
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Visible), 5, 0), true);
         edtResidentGivenName_Visible = 0;
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Visible), 5, 0), true);
         edtResidentLastName_Visible = 0;
         AssignProp(sPrefix, false, edtResidentLastName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Memo";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A575MemoId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A575MemoId", A575MemoId.ToString());
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
         PABF2( ) ;
         WSBF2( ) ;
         WEBF2( ) ;
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
         sCtrlA575MemoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABF2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_memogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABF2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A575MemoId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A575MemoId", A575MemoId.ToString());
         }
         wcpOA575MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA575MemoId"));
         if ( ! GetJustCreated( ) && ( ( A575MemoId != wcpOA575MemoId ) ) )
         {
            setjustcreated();
         }
         wcpOA575MemoId = A575MemoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA575MemoId = cgiGet( sPrefix+"A575MemoId_CTRL");
         if ( StringUtil.Len( sCtrlA575MemoId) > 0 )
         {
            A575MemoId = StringUtil.StrToGuid( cgiGet( sCtrlA575MemoId));
            AssignAttri(sPrefix, false, "A575MemoId", A575MemoId.ToString());
         }
         else
         {
            A575MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"A575MemoId_PARM"));
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
         PABF2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBF2( ) ;
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
         WSBF2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A575MemoId_PARM", A575MemoId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA575MemoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A575MemoId_CTRL", StringUtil.RTrim( sCtrlA575MemoId));
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
         WEBF2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253211340290", true, true);
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
         context.AddJavascriptSource("trn_memogeneral.js", "?20253211340291", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbResidentSalutation.Name = "RESIDENTSALUTATION";
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbResidentSalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbResidentSalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbResidentSalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtMemoCategoryName_Internalname = sPrefix+"MEMOCATEGORYNAME";
         edtMemoTitle_Internalname = sPrefix+"MEMOTITLE";
         edtMemoDescription_Internalname = sPrefix+"MEMODESCRIPTION";
         edtMemoImage_Internalname = sPrefix+"MEMOIMAGE";
         edtMemoDocument_Internalname = sPrefix+"MEMODOCUMENT";
         edtMemoStartDateTime_Internalname = sPrefix+"MEMOSTARTDATETIME";
         edtMemoEndDateTime_Internalname = sPrefix+"MEMOENDDATETIME";
         edtMemoDuration_Internalname = sPrefix+"MEMODURATION";
         edtMemoRemoveDate_Internalname = sPrefix+"MEMOREMOVEDATE";
         edtResidentId_Internalname = sPrefix+"RESIDENTID";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtMemoId_Internalname = sPrefix+"MEMOID";
         cmbResidentSalutation_Internalname = sPrefix+"RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = sPrefix+"RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = sPrefix+"RESIDENTLASTNAME";
         edtResidentGUID_Internalname = sPrefix+"RESIDENTGUID";
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
         edtResidentGUID_Enabled = 0;
         edtResidentLastName_Enabled = 0;
         edtResidentGivenName_Enabled = 0;
         cmbResidentSalutation.Enabled = 0;
         edtMemoId_Enabled = 0;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Visible = 1;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Visible = 1;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Visible = 1;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Visible = 1;
         edtMemoId_Jsonclick = "";
         edtMemoId_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 0;
         edtMemoRemoveDate_Jsonclick = "";
         edtMemoRemoveDate_Enabled = 0;
         edtMemoDuration_Jsonclick = "";
         edtMemoDuration_Enabled = 0;
         edtMemoEndDateTime_Jsonclick = "";
         edtMemoEndDateTime_Enabled = 0;
         edtMemoStartDateTime_Jsonclick = "";
         edtMemoStartDateTime_Enabled = 0;
         edtMemoDocument_Enabled = 0;
         edtMemoImage_Enabled = 0;
         edtMemoDescription_Enabled = 0;
         edtMemoTitle_Jsonclick = "";
         edtMemoTitle_Enabled = 0;
         edtMemoCategoryName_Jsonclick = "";
         edtMemoCategoryName_Link = "";
         edtMemoCategoryName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A575MemoId","fld":"MEMOID"}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_MEMOID","""{"handler":"Valid_Memoid","iparms":[]}""");
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
         wcpOA575MemoId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A569MemoCategoryName = "";
         A576MemoTitle = "";
         ClassString = "";
         StyleString = "";
         A577MemoDescription = "";
         A578MemoImage = "";
         A579MemoDocument = "";
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A590MemoRemoveDate = DateTime.MinValue;
         A62ResidentId = Guid.Empty;
         bttBtncancel_Jsonclick = "";
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00BF2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         H00BF2_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BF2_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         H00BF2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BF2_A575MemoId = new Guid[] {Guid.Empty} ;
         H00BF2_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         H00BF2_A71ResidentGUID = new string[] {""} ;
         H00BF2_A65ResidentLastName = new string[] {""} ;
         H00BF2_A64ResidentGivenName = new string[] {""} ;
         H00BF2_A72ResidentSalutation = new string[] {""} ;
         H00BF2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BF2_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         H00BF2_A589MemoDuration = new short[1] ;
         H00BF2_n589MemoDuration = new bool[] {false} ;
         H00BF2_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         H00BF2_n588MemoEndDateTime = new bool[] {false} ;
         H00BF2_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         H00BF2_n587MemoStartDateTime = new bool[] {false} ;
         H00BF2_A579MemoDocument = new string[] {""} ;
         H00BF2_n579MemoDocument = new bool[] {false} ;
         H00BF2_A578MemoImage = new string[] {""} ;
         H00BF2_n578MemoImage = new bool[] {false} ;
         H00BF2_A577MemoDescription = new string[] {""} ;
         H00BF2_A576MemoTitle = new string[] {""} ;
         H00BF2_A569MemoCategoryName = new string[] {""} ;
         A555SG_LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A568MemoCategoryId = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA575MemoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memogeneral__default(),
            new Object[][] {
                new Object[] {
               H00BF2_A555SG_LocationId, H00BF2_A29LocationId, H00BF2_A556SG_OrganisationId, H00BF2_A11OrganisationId, H00BF2_A575MemoId, H00BF2_A568MemoCategoryId, H00BF2_A71ResidentGUID, H00BF2_A65ResidentLastName, H00BF2_A64ResidentGivenName, H00BF2_A72ResidentSalutation,
               H00BF2_A62ResidentId, H00BF2_A590MemoRemoveDate, H00BF2_A589MemoDuration, H00BF2_n589MemoDuration, H00BF2_A588MemoEndDateTime, H00BF2_n588MemoEndDateTime, H00BF2_A587MemoStartDateTime, H00BF2_n587MemoStartDateTime, H00BF2_A579MemoDocument, H00BF2_n579MemoDocument,
               H00BF2_A578MemoImage, H00BF2_n578MemoImage, H00BF2_A577MemoDescription, H00BF2_A576MemoTitle, H00BF2_A569MemoCategoryName
               }
            }
         );
         AV13Pgmname = "Trn_MemoGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "Trn_MemoGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A589MemoDuration ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtMemoCategoryName_Enabled ;
      private int edtMemoTitle_Enabled ;
      private int edtMemoDescription_Enabled ;
      private int edtMemoImage_Enabled ;
      private int edtMemoDocument_Enabled ;
      private int edtMemoStartDateTime_Enabled ;
      private int edtMemoEndDateTime_Enabled ;
      private int edtMemoDuration_Enabled ;
      private int edtMemoRemoveDate_Enabled ;
      private int edtResidentId_Enabled ;
      private int edtMemoId_Visible ;
      private int edtResidentGivenName_Visible ;
      private int edtResidentLastName_Visible ;
      private int edtResidentGUID_Visible ;
      private int edtMemoId_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentGUID_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtMemoCategoryName_Internalname ;
      private string TempTags ;
      private string edtMemoCategoryName_Link ;
      private string edtMemoCategoryName_Jsonclick ;
      private string edtMemoTitle_Internalname ;
      private string edtMemoTitle_Jsonclick ;
      private string edtMemoDescription_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtMemoImage_Internalname ;
      private string edtMemoDocument_Internalname ;
      private string edtMemoStartDateTime_Internalname ;
      private string edtMemoStartDateTime_Jsonclick ;
      private string edtMemoEndDateTime_Internalname ;
      private string edtMemoEndDateTime_Jsonclick ;
      private string edtMemoDuration_Internalname ;
      private string edtMemoDuration_Jsonclick ;
      private string edtMemoRemoveDate_Internalname ;
      private string edtMemoRemoveDate_Jsonclick ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMemoId_Internalname ;
      private string edtMemoId_Jsonclick ;
      private string cmbResidentSalutation_Internalname ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA575MemoId ;
      private DateTime A587MemoStartDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime A590MemoRemoveDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n589MemoDuration ;
      private bool n588MemoEndDateTime ;
      private bool n587MemoStartDateTime ;
      private bool n579MemoDocument ;
      private bool n578MemoImage ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A569MemoCategoryName ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private Guid A575MemoId ;
      private Guid wcpOA575MemoId ;
      private Guid A62ResidentId ;
      private Guid A555SG_LocationId ;
      private Guid A29LocationId ;
      private Guid A556SG_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A568MemoCategoryId ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BF2_A555SG_LocationId ;
      private Guid[] H00BF2_A29LocationId ;
      private Guid[] H00BF2_A556SG_OrganisationId ;
      private Guid[] H00BF2_A11OrganisationId ;
      private Guid[] H00BF2_A575MemoId ;
      private Guid[] H00BF2_A568MemoCategoryId ;
      private string[] H00BF2_A71ResidentGUID ;
      private string[] H00BF2_A65ResidentLastName ;
      private string[] H00BF2_A64ResidentGivenName ;
      private string[] H00BF2_A72ResidentSalutation ;
      private Guid[] H00BF2_A62ResidentId ;
      private DateTime[] H00BF2_A590MemoRemoveDate ;
      private short[] H00BF2_A589MemoDuration ;
      private bool[] H00BF2_n589MemoDuration ;
      private DateTime[] H00BF2_A588MemoEndDateTime ;
      private bool[] H00BF2_n588MemoEndDateTime ;
      private DateTime[] H00BF2_A587MemoStartDateTime ;
      private bool[] H00BF2_n587MemoStartDateTime ;
      private string[] H00BF2_A579MemoDocument ;
      private bool[] H00BF2_n579MemoDocument ;
      private string[] H00BF2_A578MemoImage ;
      private bool[] H00BF2_n578MemoImage ;
      private string[] H00BF2_A577MemoDescription ;
      private string[] H00BF2_A576MemoTitle ;
      private string[] H00BF2_A569MemoCategoryName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_memogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00BF2;
          prmH00BF2 = new Object[] {
          new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BF2", "SELECT T1.SG_LocationId, T3.LocationId, T1.SG_OrganisationId, T3.OrganisationId, T1.MemoId, T1.MemoCategoryId, T3.ResidentGUID, T3.ResidentLastName, T3.ResidentGivenName, T3.ResidentSalutation, T1.ResidentId, T1.MemoRemoveDate, T1.MemoDuration, T1.MemoEndDateTime, T1.MemoStartDateTime, T1.MemoDocument, T1.MemoImage, T1.MemoDescription, T1.MemoTitle, T2.MemoCategoryName FROM ((Trn_Memo T1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = T1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = T1.ResidentId AND T3.LocationId = T1.SG_LocationId AND T3.OrganisationId = T1.SG_OrganisationId) WHERE T1.MemoId = :MemoId ORDER BY T1.MemoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BF2,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((bool[]) buf[13])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[17])[0] = rslt.wasNull(15);
                ((string[]) buf[18])[0] = rslt.getVarchar(16);
                ((bool[]) buf[19])[0] = rslt.wasNull(16);
                ((string[]) buf[20])[0] = rslt.getVarchar(17);
                ((bool[]) buf[21])[0] = rslt.wasNull(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((string[]) buf[23])[0] = rslt.getVarchar(19);
                ((string[]) buf[24])[0] = rslt.getVarchar(20);
                return;
       }
    }

 }

}
