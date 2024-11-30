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
   public class wc_basecolor : GXWebComponent
   {
      public wc_basecolor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wc_basecolor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ColorName )
      {
         this.AV11ColorName = "" ;
         ExecuteImpl();
         aP0_ColorName=this.AV11ColorName;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ColorName");
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
                  AV11ColorName = GetPar( "ColorName");
                  AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV11ColorName});
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
                  gxfirstwebparm = GetFirstPar( "ColorName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ColorName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fscolor2") == 0 )
               {
                  gxnrFscolor2_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fscolor2") == 0 )
               {
                  gxgrFscolor2_refresh_invoke( ) ;
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

      protected void gxnrFscolor2_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFscolor2_newrow( ) ;
         /* End function gxnrFscolor2_newrow_invoke */
      }

      protected void gxgrFscolor2_refresh_invoke( )
      {
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
         AV8ColorItemClass = GetPar( "ColorItemClass");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10WWP_DesignSystemSettings);
         AV11ColorName = GetPar( "ColorName");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFscolor2_refresh( AV8ColorItemClass, AV10WWP_DesignSystemSettings, AV11ColorName, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFscolor2_refresh_invoke */
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
            PA3Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS3Y2( ) ;
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
            context.SendWebValue( "WC_Base Color") ;
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_basecolor.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11ColorName))}, new string[] {"ColorName"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV10WWP_DesignSystemSettings);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV10WWP_DesignSystemSettings);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subFscolor2_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORNAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3Y2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WC_BaseColor" ;
      }

      public override string GetPgmdesc( )
      {
         return "WC_Base Color" ;
      }

      protected void WB3Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_basecolor.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, divTablecontent_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingRight45", "start", "top", "", "", "div");
            /*  Grid Control  */
            Fscolor2Container.SetIsFreestyle(true);
            Fscolor2Container.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Fscolor2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Fscolor2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fscolor2", Fscolor2Container, subFscolor2_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Fscolor2ContainerData", Fscolor2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Fscolor2ContainerData"+"V", Fscolor2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Fscolor2ContainerData"+"V"+"\" value='"+Fscolor2Container.GridValuesHidden()+"'/>") ;
               }
            }
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
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Fscolor2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Fscolor2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fscolor2", Fscolor2Container, subFscolor2_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Fscolor2ContainerData", Fscolor2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Fscolor2ContainerData"+"V", Fscolor2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Fscolor2ContainerData"+"V"+"\" value='"+Fscolor2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Y2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "WC_Base Color", 0) ;
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
               STRUP3Y0( ) ;
            }
         }
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                                 STRUP3Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablecoloritem.Click */
                                    E113Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "FSCOLOR2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "TABLECOLORITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              if ( StringUtil.Len( sPrefix) == 0 )
                              {
                                 AV11ColorName = cgiGet( edtavColorname_Internalname);
                                 AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
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
                                          /* Execute user event: Start */
                                          E123Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSCOLOR2.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Fscolor2.Load */
                                          E133Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Tablecoloritem.Click */
                                          E113Y2 ();
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
                                       STRUP3Y0( ) ;
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

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Y2( ) ;
            }
         }
      }

      protected void PA3Y2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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

      protected void gxnrFscolor2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subFscolor2_Islastpage==1)&&(nGXsfl_15_idx+1>subFscolor2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Fscolor2Container)) ;
         /* End function gxnrFscolor2_newrow */
      }

      protected void gxgrFscolor2_refresh( string AV8ColorItemClass ,
                                           GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV10WWP_DesignSystemSettings ,
                                           string AV11ColorName ,
                                           string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSCOLOR2_nCurrentRecord = 0;
         RF3Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFscolor2_refresh */
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
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Fscolor2Container.ClearRows();
         }
         wbStart = 15;
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Fscolor2Container.AddObjectProperty("GridName", "Fscolor2");
         Fscolor2Container.AddObjectProperty("CmpContext", sPrefix);
         Fscolor2Container.AddObjectProperty("InMasterPage", "false");
         Fscolor2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Fscolor2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Fscolor2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Fscolor2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Fscolor2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Backcolorstyle), 1, 0, ".", "")));
         Fscolor2Container.PageSize = subFscolor2_fnc_Recordsperpage( );
         if ( subFscolor2_Islastpage != 0 )
         {
            FSCOLOR2_nFirstRecordOnPage = (long)(subFscolor2_fnc_Recordcount( )-subFscolor2_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FSCOLOR2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FSCOLOR2_nFirstRecordOnPage), 15, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("FSCOLOR2_nFirstRecordOnPage", FSCOLOR2_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Execute user event: Fscolor2.Load */
            E133Y2 ();
            wbEnd = 15;
            WB3Y0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
      }

      protected int subFscolor2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ".", ","), 18, MidpointRounding.ToEven));
            subFscolor2_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFscolor2_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E123Y2 ();
         if (returnInSub) return;
      }

      protected void E123Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablemain_Width = 300;
         AssignProp(sPrefix, false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         divTablecontent_Width = 300;
         AssignProp(sPrefix, false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         tblTablecoloritem_Width = 300;
         AssignProp(sPrefix, false, tblTablecoloritem_Internalname, "Width", StringUtil.LTrimStr( (decimal)(tblTablecoloritem_Width), 9, 0), !bGXsfl_15_Refreshing);
         edtavColorname_Visible = 0;
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_15_Refreshing);
      }

      private void E133Y2( )
      {
         /* Fscolor2_Load Routine */
         returnInSub = false;
         AV7ColorItemDefinition = "<div class=\"%1\" style=\"background-color:%2\">";
         AV11ColorName = "LightPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#b05792", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "MediumViolet";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "MediumVioletRed", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Pink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#a11a74", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "MediumPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#ED66D2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "MediumPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "MediumPurple", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "LightPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#696ef2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Purple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#7F4494", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Indigo";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "Indigo", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "LightBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#39b3d7", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Blue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#078bcd", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "SkyBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#4978b0", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Navy";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#004080", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Green";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#5CB85C", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "SeaGreen";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#08A086", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Teal";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "Teal", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Olive";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#004000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Salmon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "Salmon", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Red";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#d9534f", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Tomato";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "Tomato", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Maroon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#950000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Orange";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#FF8040", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Yellow";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#f0ad4e", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Ecru";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#B75B00", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         AV11ColorName = "Brown";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV7ColorItemDefinition, AV8ColorItemClass, "#804000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Fscolor2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E113Y2( )
      {
         /* Tablecoloritem_Click Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV10WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV10WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV10WWP_DesignSystemSettings.gxTpr_Basecolor = AV11ColorName;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV10WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
         AV12WebSession.Set("SelectedBaseColor", AV11ColorName);
         gxgrFscolor2_refresh( AV8ColorItemClass, AV10WWP_DesignSystemSettings, AV11ColorName, sPrefix) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWP_DesignSystemSettings", AV10WWP_DesignSystemSettings);
      }

      protected void S112( )
      {
         /* 'GETCOLORCLASS' Routine */
         returnInSub = false;
         AV9ColorItemBaseClass = "RuntimeSettingsColor";
         AV8ColorItemClass = ((StringUtil.StrCmp(AV10WWP_DesignSystemSettings.gxTpr_Basecolor, AV11ColorName)==0) ? AV9ColorItemBaseClass+"Selected" : AV9ColorItemBaseClass);
         AssignAttri(sPrefix, false, "AV8ColorItemClass", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11ColorName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV11ColorName = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_basecolor", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV11ColorName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV11ColorName = cgiGet( sPrefix+"AV11ColorName_CTRL");
         if ( StringUtil.Len( sCtrlAV11ColorName) > 0 )
         {
            AV11ColorName = cgiGet( sCtrlAV11ColorName);
            AssignAttri(sPrefix, false, edtavColorname_Internalname, AV11ColorName);
         }
         else
         {
            AV11ColorName = cgiGet( sPrefix+"AV11ColorName_PARM");
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
         PA3Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Y2( ) ;
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
         WS3Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11ColorName_PARM", AV11ColorName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11ColorName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11ColorName_CTRL", StringUtil.RTrim( sCtrlAV11ColorName));
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
         WE3Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491812502510", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wc_basecolor.js", "?202491812502510", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_15_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_15_fel_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB3Y0( ) ;
         Fscolor2Row = GXWebRow.GetNew(context,Fscolor2Container);
         if ( subFscolor2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFscolor2_Backstyle = 0;
            if ( StringUtil.StrCmp(subFscolor2_Class, "") != 0 )
            {
               subFscolor2_Linesclass = subFscolor2_Class+"Odd";
            }
         }
         else if ( subFscolor2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFscolor2_Backstyle = 0;
            subFscolor2_Backcolor = subFscolor2_Allbackcolor;
            if ( StringUtil.StrCmp(subFscolor2_Class, "") != 0 )
            {
               subFscolor2_Linesclass = subFscolor2_Class+"Uniform";
            }
         }
         else if ( subFscolor2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFscolor2_Backstyle = 1;
            if ( StringUtil.StrCmp(subFscolor2_Class, "") != 0 )
            {
               subFscolor2_Linesclass = subFscolor2_Class+"Odd";
            }
            subFscolor2_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFscolor2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFscolor2_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subFscolor2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFscolor2_Class, "") != 0 )
               {
                  subFscolor2_Linesclass = subFscolor2_Class+"Even";
               }
            }
            else
            {
               subFscolor2_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFscolor2_Class, "") != 0 )
               {
                  subFscolor2_Linesclass = subFscolor2_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFscolor2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Table start */
         Fscolor2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablefsfscolor2_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Fscolor2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Fscolor2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Table start */
         Fscolor2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablecoloritem_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(int)tblTablecoloritem_Width,(string)"",(string)"px",(string)"px",(string)""});
         Fscolor2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Fscolor2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Fscolor2Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblColorsquare_Internalname,(string)lblColorsquare_Caption,(string)"",(string)"",(string)lblColorsquare_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("cell");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("row");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("table");
         }
         /* End of table */
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("cell");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("row");
         }
         Fscolor2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Fscolor2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"Invisible"});
         /* Table start */
         Fscolor2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfscolor2_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Fscolor2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Fscolor2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Fscolor2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Fscolor2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,(string)"Color Name",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         Fscolor2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,(string)AV11ColorName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavColorname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavColorname_Visible,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Fscolor2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("cell");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("row");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("table");
         }
         /* End of table */
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("cell");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("row");
         }
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            Fscolor2Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes3Y2( ) ;
         /* End of Columns property logic. */
         Fscolor2Container.AddRow(Fscolor2Row);
         nGXsfl_15_idx = ((subFscolor2_Islastpage==1)&&(nGXsfl_15_idx+1>subFscolor2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( Fscolor2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Fscolor2Container"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFscolor2_Internalname, subFscolor2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Fscolor2Container.AddObjectProperty("GridName", "Fscolor2");
         }
         else
         {
            Fscolor2Container.AddObjectProperty("GridName", "Fscolor2");
            Fscolor2Container.AddObjectProperty("Header", subFscolor2_Header);
            Fscolor2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Fscolor2Container.AddObjectProperty("Class", "FreeStyleGrid");
            Fscolor2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Backcolorstyle), 1, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("CmpContext", sPrefix);
            Fscolor2Container.AddObjectProperty("InMasterPage", "false");
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Column.AddObjectProperty("Value", lblColorsquare_Caption);
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV11ColorName));
            Fscolor2Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Fscolor2Container.AddColumnProperties(Fscolor2Column);
            Fscolor2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Selectedindex), 4, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Allowselection), 1, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Selectioncolor), 9, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Allowhovering), 1, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Hoveringcolor), 9, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Allowcollapsing), 1, 0, ".", "")));
            Fscolor2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE";
         tblTablecoloritem_Internalname = sPrefix+"TABLECOLORITEM";
         edtavColorname_Internalname = sPrefix+"vCOLORNAME";
         tblUnnamedtablecontentfsfscolor2_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFSCOLOR2";
         tblUnnamedtablefsfscolor2_Internalname = sPrefix+"UNNAMEDTABLEFSFSCOLOR2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFscolor2_Internalname = sPrefix+"FSCOLOR2";
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
         subFscolor2_Allowcollapsing = 0;
         lblColorsquare_Caption = "";
         edtavColorname_Jsonclick = "";
         lblColorsquare_Caption = "";
         tblTablecoloritem_Width = 0;
         subFscolor2_Class = "FreeStyleGrid";
         subFscolor2_Backcolorstyle = 0;
         divTablecontent_Width = 0;
         divTablemain_Width = 0;
         edtavColorname_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSCOLOR2_nFirstRecordOnPage"},{"av":"FSCOLOR2_nEOF"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV11ColorName","fld":"vCOLORNAME"},{"av":"sPrefix"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]}""");
         setEventMetadata("FSCOLOR2.LOAD","""{"handler":"E133Y2","iparms":[{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV11ColorName","fld":"vCOLORNAME"}]""");
         setEventMetadata("FSCOLOR2.LOAD",""","oparms":[{"av":"AV11ColorName","fld":"vCOLORNAME"},{"av":"lblColorsquare_Caption","ctrl":"COLORSQUARE","prop":"Caption"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]}""");
         setEventMetadata("TABLECOLORITEM.CLICK","""{"handler":"E113Y2","iparms":[{"av":"FSCOLOR2_nFirstRecordOnPage"},{"av":"FSCOLOR2_nEOF"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV11ColorName","fld":"vCOLORNAME"},{"av":"sPrefix"}]""");
         setEventMetadata("TABLECOLORITEM.CLICK",""","oparms":[{"av":"AV10WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Colorname","iparms":[]}""");
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
         AV11ColorName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV8ColorItemClass = "";
         AV10WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         Fscolor2Container = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7ColorItemDefinition = "";
         Fscolor2Row = new GXWebRow();
         GXt_SdtWWP_DesignSystemSettings1 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         AV12WebSession = context.GetSession();
         AV9ColorItemBaseClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV11ColorName = "";
         subFscolor2_Linesclass = "";
         lblColorsquare_Jsonclick = "";
         ROClassString = "";
         subFscolor2_Header = "";
         Fscolor2Column = new GXWebColumn();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFscolor2_Backcolorstyle ;
      private short FSCOLOR2_nEOF ;
      private short subFscolor2_Backstyle ;
      private short subFscolor2_Allowselection ;
      private short subFscolor2_Allowhovering ;
      private short subFscolor2_Allowcollapsing ;
      private short subFscolor2_Collapsed ;
      private int edtavColorname_Visible ;
      private int nRC_GXsfl_15 ;
      private int subFscolor2_Recordcount ;
      private int nGXsfl_15_idx=1 ;
      private int divTablemain_Width ;
      private int divTablecontent_Width ;
      private int subFscolor2_Islastpage ;
      private int tblTablecoloritem_Width ;
      private int idxLst ;
      private int subFscolor2_Backcolor ;
      private int subFscolor2_Allbackcolor ;
      private int subFscolor2_Selectedindex ;
      private int subFscolor2_Selectioncolor ;
      private int subFscolor2_Hoveringcolor ;
      private long FSCOLOR2_nCurrentRecord ;
      private long FSCOLOR2_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavColorname_Internalname ;
      private string sGXsfl_15_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subFscolor2_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string tblTablecoloritem_Internalname ;
      private string lblColorsquare_Caption ;
      private string sCtrlAV11ColorName ;
      private string lblColorsquare_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subFscolor2_Class ;
      private string subFscolor2_Linesclass ;
      private string tblUnnamedtablefsfscolor2_Internalname ;
      private string lblColorsquare_Jsonclick ;
      private string tblUnnamedtablecontentfsfscolor2_Internalname ;
      private string ROClassString ;
      private string edtavColorname_Jsonclick ;
      private string subFscolor2_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV11ColorName ;
      private string AV8ColorItemClass ;
      private string AV7ColorItemDefinition ;
      private string AV9ColorItemBaseClass ;
      private GXWebGrid Fscolor2Container ;
      private GXWebRow Fscolor2Row ;
      private GXWebColumn Fscolor2Column ;
      private GXWebForm Form ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV10WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_ColorName ;
   }

}
