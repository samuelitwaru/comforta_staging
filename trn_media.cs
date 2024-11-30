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
   public class trn_media : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_media.aspx")), "trn_media.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_media.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13MediaId = StringUtil.StrToGuid( GetPar( "MediaId"));
                  AssignAttri("", false, "AV13MediaId", AV13MediaId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vMEDIAID", GetSecureSignedToken( "", AV13MediaId, context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Media", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMediaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_media( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_media( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_MediaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13MediaId = aP1_MediaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "trn_media_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Media.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMediaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMediaId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMediaId_Internalname, A409MediaId.ToString(), A409MediaId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMediaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMediaId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMediaName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMediaName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMediaName_Internalname, A410MediaName, StringUtil.RTrim( context.localUtil.Format( A410MediaName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMediaName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMediaName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgMediaImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A411MediaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000MediaImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.PathToRelativeUrl( A411MediaImage));
         GxWebStd.gx_bitmap( context, imgMediaImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgMediaImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", "", "", 0, A411MediaImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Media.htm");
         AssignProp("", false, imgMediaImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.PathToRelativeUrl( A411MediaImage)), true);
         AssignProp("", false, imgMediaImage_Internalname, "IsBlob", StringUtil.BoolToStr( A411MediaImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMediaSize_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMediaSize_Internalname, context.GetMessage( "Size", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMediaSize_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A413MediaSize), 8, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMediaSize_Enabled!=0) ? context.localUtil.Format( (decimal)(A413MediaSize), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A413MediaSize), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMediaSize_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMediaSize_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMediaType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMediaType_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMediaType_Internalname, StringUtil.RTrim( A414MediaType), StringUtil.RTrim( context.localUtil.Format( A414MediaType, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMediaType_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMediaType_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMediaUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMediaUrl_Internalname, context.GetMessage( "Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMediaUrl_Internalname, A412MediaUrl, StringUtil.RTrim( context.localUtil.Format( A412MediaUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", A412MediaUrl, "_blank", "", "", edtMediaUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMediaUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Media.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Media.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Media.htm");
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z409MediaId = StringUtil.StrToGuid( cgiGet( "Z409MediaId"));
               Z410MediaName = cgiGet( "Z410MediaName");
               Z413MediaSize = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z413MediaSize"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z414MediaType = cgiGet( "Z414MediaType");
               Z412MediaUrl = cgiGet( "Z412MediaUrl");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV13MediaId = StringUtil.StrToGuid( cgiGet( "vMEDIAID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000MediaImage_GXI = cgiGet( "MEDIAIMAGE_GXI");
               n40000MediaImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000MediaImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? true : false);
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtMediaId_Internalname), "") == 0 )
               {
                  A409MediaId = Guid.Empty;
                  AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
               }
               else
               {
                  try
                  {
                     A409MediaId = StringUtil.StrToGuid( cgiGet( edtMediaId_Internalname));
                     AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MEDIAID");
                     AnyError = 1;
                     GX_FocusControl = edtMediaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A410MediaName = cgiGet( edtMediaName_Internalname);
               AssignAttri("", false, "A410MediaName", A410MediaName);
               A411MediaImage = cgiGet( imgMediaImage_Internalname);
               n411MediaImage = false;
               AssignAttri("", false, "A411MediaImage", A411MediaImage);
               n411MediaImage = (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMediaSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMediaSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MEDIASIZE");
                  AnyError = 1;
                  GX_FocusControl = edtMediaSize_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A413MediaSize = 0;
                  AssignAttri("", false, "A413MediaSize", StringUtil.LTrimStr( (decimal)(A413MediaSize), 8, 0));
               }
               else
               {
                  A413MediaSize = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMediaSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A413MediaSize", StringUtil.LTrimStr( (decimal)(A413MediaSize), 8, 0));
               }
               A414MediaType = cgiGet( edtMediaType_Internalname);
               AssignAttri("", false, "A414MediaType", A414MediaType);
               A412MediaUrl = cgiGet( edtMediaUrl_Internalname);
               AssignAttri("", false, "A412MediaUrl", A412MediaUrl);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgMediaImage_Internalname, ref  A411MediaImage, ref  A40000MediaImage_GXI);
               n40000MediaImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000MediaImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? true : false);
               n411MediaImage = (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Media");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A409MediaId != Z409MediaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_media:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A409MediaId = StringUtil.StrToGuid( GetPar( "MediaId"));
                  AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV13MediaId) )
                  {
                     A409MediaId = AV13MediaId;
                     AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A409MediaId) && ( Gx_BScreen == 0 ) )
                     {
                        A409MediaId = Guid.NewGuid( );
                        AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode83 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV13MediaId) )
                     {
                        A409MediaId = AV13MediaId;
                        AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A409MediaId) && ( Gx_BScreen == 0 ) )
                        {
                           A409MediaId = Guid.NewGuid( );
                           AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                        }
                     }
                     Gx_mode = sMode83;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound83 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MEDIAID");
                        AnyError = 1;
                        GX_FocusControl = edtMediaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0X83( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0X83( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X83( ) ;
            }
            else
            {
               CheckExtendedTable0X83( ) ;
               CloseExtendedTableCursors0X83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0X0( )
      {
      }

      protected void E110X2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_mediaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0X83( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z410MediaName = T000X3_A410MediaName[0];
               Z413MediaSize = T000X3_A413MediaSize[0];
               Z414MediaType = T000X3_A414MediaType[0];
               Z412MediaUrl = T000X3_A412MediaUrl[0];
            }
            else
            {
               Z410MediaName = A410MediaName;
               Z413MediaSize = A413MediaSize;
               Z414MediaType = A414MediaType;
               Z412MediaUrl = A412MediaUrl;
            }
         }
         if ( GX_JID == -6 )
         {
            Z409MediaId = A409MediaId;
            Z410MediaName = A410MediaName;
            Z411MediaImage = A411MediaImage;
            Z40000MediaImage_GXI = A40000MediaImage_GXI;
            Z413MediaSize = A413MediaSize;
            Z414MediaType = A414MediaType;
            Z412MediaUrl = A412MediaUrl;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV13MediaId) )
         {
            edtMediaId_Enabled = 0;
            AssignProp("", false, edtMediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaId_Enabled), 5, 0), true);
         }
         else
         {
            edtMediaId_Enabled = 1;
            AssignProp("", false, edtMediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV13MediaId) )
         {
            edtMediaId_Enabled = 0;
            AssignProp("", false, edtMediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV13MediaId) )
         {
            A409MediaId = AV13MediaId;
            AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A409MediaId) && ( Gx_BScreen == 0 ) )
            {
               A409MediaId = Guid.NewGuid( );
               AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0X83( )
      {
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound83 = 1;
            A410MediaName = T000X4_A410MediaName[0];
            AssignAttri("", false, "A410MediaName", A410MediaName);
            A40000MediaImage_GXI = T000X4_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = T000X4_n40000MediaImage_GXI[0];
            AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
            AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
            A413MediaSize = T000X4_A413MediaSize[0];
            AssignAttri("", false, "A413MediaSize", StringUtil.LTrimStr( (decimal)(A413MediaSize), 8, 0));
            A414MediaType = T000X4_A414MediaType[0];
            AssignAttri("", false, "A414MediaType", A414MediaType);
            A412MediaUrl = T000X4_A412MediaUrl[0];
            AssignAttri("", false, "A412MediaUrl", A412MediaUrl);
            A411MediaImage = T000X4_A411MediaImage[0];
            n411MediaImage = T000X4_n411MediaImage[0];
            AssignAttri("", false, "A411MediaImage", A411MediaImage);
            AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
            AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
            ZM0X83( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0X83( ) ;
      }

      protected void OnLoadActions0X83( )
      {
      }

      protected void CheckExtendedTable0X83( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A412MediaUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Media Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MEDIAURL");
            AnyError = 1;
            GX_FocusControl = edtMediaUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0X83( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X83( )
      {
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X83( 6) ;
            RcdFound83 = 1;
            A409MediaId = T000X3_A409MediaId[0];
            AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
            A410MediaName = T000X3_A410MediaName[0];
            AssignAttri("", false, "A410MediaName", A410MediaName);
            A40000MediaImage_GXI = T000X3_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = T000X3_n40000MediaImage_GXI[0];
            AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
            AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
            A413MediaSize = T000X3_A413MediaSize[0];
            AssignAttri("", false, "A413MediaSize", StringUtil.LTrimStr( (decimal)(A413MediaSize), 8, 0));
            A414MediaType = T000X3_A414MediaType[0];
            AssignAttri("", false, "A414MediaType", A414MediaType);
            A412MediaUrl = T000X3_A412MediaUrl[0];
            AssignAttri("", false, "A412MediaUrl", A412MediaUrl);
            A411MediaImage = T000X3_A411MediaImage[0];
            n411MediaImage = T000X3_n411MediaImage[0];
            AssignAttri("", false, "A411MediaImage", A411MediaImage);
            AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
            AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
            Z409MediaId = A409MediaId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey0X83( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey0X83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X83( ) ;
         if ( RcdFound83 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound83 = 0;
         /* Using cursor T000X6 */
         pr_default.execute(4, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000X6_A409MediaId[0], A409MediaId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000X6_A409MediaId[0], A409MediaId, 0) > 0 ) ) )
            {
               A409MediaId = T000X6_A409MediaId[0];
               AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
               RcdFound83 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T000X7 */
         pr_default.execute(5, new Object[] {A409MediaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000X7_A409MediaId[0], A409MediaId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000X7_A409MediaId[0], A409MediaId, 0) < 0 ) ) )
            {
               A409MediaId = T000X7_A409MediaId[0];
               AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
               RcdFound83 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMediaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0X83( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A409MediaId != Z409MediaId )
               {
                  A409MediaId = Z409MediaId;
                  AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MEDIAID");
                  AnyError = 1;
                  GX_FocusControl = edtMediaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMediaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0X83( ) ;
                  GX_FocusControl = edtMediaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A409MediaId != Z409MediaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMediaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0X83( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MEDIAID");
                     AnyError = 1;
                     GX_FocusControl = edtMediaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMediaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0X83( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A409MediaId != Z409MediaId )
         {
            A409MediaId = Z409MediaId;
            AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MEDIAID");
            AnyError = 1;
            GX_FocusControl = edtMediaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMediaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0X83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {A409MediaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z410MediaName, T000X2_A410MediaName[0]) != 0 ) || ( Z413MediaSize != T000X2_A413MediaSize[0] ) || ( StringUtil.StrCmp(Z414MediaType, T000X2_A414MediaType[0]) != 0 ) || ( StringUtil.StrCmp(Z412MediaUrl, T000X2_A412MediaUrl[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z410MediaName, T000X2_A410MediaName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_media:[seudo value changed for attri]"+"MediaName");
                  GXUtil.WriteLogRaw("Old: ",Z410MediaName);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A410MediaName[0]);
               }
               if ( Z413MediaSize != T000X2_A413MediaSize[0] )
               {
                  GXUtil.WriteLog("trn_media:[seudo value changed for attri]"+"MediaSize");
                  GXUtil.WriteLogRaw("Old: ",Z413MediaSize);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A413MediaSize[0]);
               }
               if ( StringUtil.StrCmp(Z414MediaType, T000X2_A414MediaType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_media:[seudo value changed for attri]"+"MediaType");
                  GXUtil.WriteLogRaw("Old: ",Z414MediaType);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A414MediaType[0]);
               }
               if ( StringUtil.StrCmp(Z412MediaUrl, T000X2_A412MediaUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_media:[seudo value changed for attri]"+"MediaUrl");
                  GXUtil.WriteLogRaw("Old: ",Z412MediaUrl);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A412MediaUrl[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Media"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X83( )
      {
         if ( ! IsAuthorized("trn_media_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X83( 0) ;
            CheckOptimisticConcurrency0X83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X8 */
                     pr_default.execute(6, new Object[] {A409MediaId, A410MediaName, n411MediaImage, A411MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A413MediaSize, A414MediaType, A412MediaUrl});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0X83( ) ;
            }
            EndLevel0X83( ) ;
         }
         CloseExtendedTableCursors0X83( ) ;
      }

      protected void Update0X83( )
      {
         if ( ! IsAuthorized("trn_media_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X9 */
                     pr_default.execute(7, new Object[] {A410MediaName, A413MediaSize, A414MediaType, A412MediaUrl, A409MediaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0X83( ) ;
         }
         CloseExtendedTableCursors0X83( ) ;
      }

      protected void DeferredUpdate0X83( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000X10 */
            pr_default.execute(8, new Object[] {n411MediaImage, A411MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A409MediaId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_media_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X83( ) ;
            AfterConfirm0X83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X11 */
                  pr_default.execute(9, new Object[] {A409MediaId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X83( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0X83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X83( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_media",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_media",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X83( )
      {
         /* Scan By routine */
         /* Using cursor T000X12 */
         pr_default.execute(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A409MediaId = T000X12_A409MediaId[0];
            AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X83( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A409MediaId = T000X12_A409MediaId[0];
            AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
         }
      }

      protected void ScanEnd0X83( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0X83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X83( )
      {
         edtMediaId_Enabled = 0;
         AssignProp("", false, edtMediaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaId_Enabled), 5, 0), true);
         edtMediaName_Enabled = 0;
         AssignProp("", false, edtMediaName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaName_Enabled), 5, 0), true);
         imgMediaImage_Enabled = 0;
         AssignProp("", false, imgMediaImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgMediaImage_Enabled), 5, 0), true);
         edtMediaSize_Enabled = 0;
         AssignProp("", false, edtMediaSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaSize_Enabled), 5, 0), true);
         edtMediaType_Enabled = 0;
         AssignProp("", false, edtMediaType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaType_Enabled), 5, 0), true);
         edtMediaUrl_Enabled = 0;
         AssignProp("", false, edtMediaUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMediaUrl_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0X83( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0X0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_media.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13MediaId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_media.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Media");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_media:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z409MediaId", Z409MediaId.ToString());
         GxWebStd.gx_hidden_field( context, "Z410MediaName", Z410MediaName);
         GxWebStd.gx_hidden_field( context, "Z413MediaSize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z413MediaSize), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z414MediaType", StringUtil.RTrim( Z414MediaType));
         GxWebStd.gx_hidden_field( context, "Z412MediaUrl", Z412MediaUrl);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMEDIAID", AV13MediaId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDIAID", GetSecureSignedToken( "", AV13MediaId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MEDIAIMAGE_GXI", A40000MediaImage_GXI);
         GXCCtlgxBlob = "MEDIAIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A411MediaImage);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_media.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13MediaId.ToString());
         return formatLink("trn_media.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Media" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Media", "") ;
      }

      protected void InitializeNonKey0X83( )
      {
         A410MediaName = "";
         AssignAttri("", false, "A410MediaName", A410MediaName);
         A411MediaImage = "";
         n411MediaImage = false;
         AssignAttri("", false, "A411MediaImage", A411MediaImage);
         AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
         AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
         n411MediaImage = (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? true : false);
         A40000MediaImage_GXI = "";
         n40000MediaImage_GXI = false;
         AssignProp("", false, imgMediaImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A411MediaImage)) ? A40000MediaImage_GXI : context.convertURL( context.PathToRelativeUrl( A411MediaImage))), true);
         AssignProp("", false, imgMediaImage_Internalname, "SrcSet", context.GetImageSrcSet( A411MediaImage), true);
         A413MediaSize = 0;
         AssignAttri("", false, "A413MediaSize", StringUtil.LTrimStr( (decimal)(A413MediaSize), 8, 0));
         A414MediaType = "";
         AssignAttri("", false, "A414MediaType", A414MediaType);
         A412MediaUrl = "";
         AssignAttri("", false, "A412MediaUrl", A412MediaUrl);
         Z410MediaName = "";
         Z413MediaSize = 0;
         Z414MediaType = "";
         Z412MediaUrl = "";
      }

      protected void InitAll0X83( )
      {
         A409MediaId = Guid.NewGuid( );
         AssignAttri("", false, "A409MediaId", A409MediaId.ToString());
         InitializeNonKey0X83( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112115423048", true, true);
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
         context.AddJavascriptSource("trn_media.js", "?2024112115423048", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMediaId_Internalname = "MEDIAID";
         edtMediaName_Internalname = "MEDIANAME";
         imgMediaImage_Internalname = "MEDIAIMAGE";
         edtMediaSize_Internalname = "MEDIASIZE";
         edtMediaType_Internalname = "MEDIATYPE";
         edtMediaUrl_Internalname = "MEDIAURL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Media", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMediaUrl_Jsonclick = "";
         edtMediaUrl_Enabled = 1;
         edtMediaType_Jsonclick = "";
         edtMediaType_Enabled = 1;
         edtMediaSize_Jsonclick = "";
         edtMediaSize_Enabled = 1;
         imgMediaImage_Enabled = 1;
         edtMediaName_Jsonclick = "";
         edtMediaName_Enabled = 1;
         edtMediaId_Jsonclick = "";
         edtMediaId_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13MediaId","fld":"vMEDIAID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV13MediaId","fld":"vMEDIAID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120X2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_MEDIAID","""{"handler":"Valid_Mediaid","iparms":[]}""");
         setEventMetadata("VALID_MEDIAURL","""{"handler":"Valid_Mediaurl","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV13MediaId = Guid.Empty;
         Z409MediaId = Guid.Empty;
         Z410MediaName = "";
         Z414MediaType = "";
         Z412MediaUrl = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A409MediaId = Guid.Empty;
         A410MediaName = "";
         A411MediaImage = "";
         A40000MediaImage_GXI = "";
         sImgUrl = "";
         A414MediaType = "";
         A412MediaUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode83 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z411MediaImage = "";
         Z40000MediaImage_GXI = "";
         T000X4_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X4_A410MediaName = new string[] {""} ;
         T000X4_A40000MediaImage_GXI = new string[] {""} ;
         T000X4_n40000MediaImage_GXI = new bool[] {false} ;
         T000X4_A413MediaSize = new int[1] ;
         T000X4_A414MediaType = new string[] {""} ;
         T000X4_A412MediaUrl = new string[] {""} ;
         T000X4_A411MediaImage = new string[] {""} ;
         T000X4_n411MediaImage = new bool[] {false} ;
         T000X5_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X3_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X3_A410MediaName = new string[] {""} ;
         T000X3_A40000MediaImage_GXI = new string[] {""} ;
         T000X3_n40000MediaImage_GXI = new bool[] {false} ;
         T000X3_A413MediaSize = new int[1] ;
         T000X3_A414MediaType = new string[] {""} ;
         T000X3_A412MediaUrl = new string[] {""} ;
         T000X3_A411MediaImage = new string[] {""} ;
         T000X3_n411MediaImage = new bool[] {false} ;
         T000X6_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X7_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X2_A409MediaId = new Guid[] {Guid.Empty} ;
         T000X2_A410MediaName = new string[] {""} ;
         T000X2_A40000MediaImage_GXI = new string[] {""} ;
         T000X2_n40000MediaImage_GXI = new bool[] {false} ;
         T000X2_A413MediaSize = new int[1] ;
         T000X2_A414MediaType = new string[] {""} ;
         T000X2_A412MediaUrl = new string[] {""} ;
         T000X2_A411MediaImage = new string[] {""} ;
         T000X2_n411MediaImage = new bool[] {false} ;
         T000X12_A409MediaId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_media__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_media__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_media__default(),
            new Object[][] {
                new Object[] {
               T000X2_A409MediaId, T000X2_A410MediaName, T000X2_A40000MediaImage_GXI, T000X2_n40000MediaImage_GXI, T000X2_A413MediaSize, T000X2_A414MediaType, T000X2_A412MediaUrl, T000X2_A411MediaImage, T000X2_n411MediaImage
               }
               , new Object[] {
               T000X3_A409MediaId, T000X3_A410MediaName, T000X3_A40000MediaImage_GXI, T000X3_n40000MediaImage_GXI, T000X3_A413MediaSize, T000X3_A414MediaType, T000X3_A412MediaUrl, T000X3_A411MediaImage, T000X3_n411MediaImage
               }
               , new Object[] {
               T000X4_A409MediaId, T000X4_A410MediaName, T000X4_A40000MediaImage_GXI, T000X4_n40000MediaImage_GXI, T000X4_A413MediaSize, T000X4_A414MediaType, T000X4_A412MediaUrl, T000X4_A411MediaImage, T000X4_n411MediaImage
               }
               , new Object[] {
               T000X5_A409MediaId
               }
               , new Object[] {
               T000X6_A409MediaId
               }
               , new Object[] {
               T000X7_A409MediaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X12_A409MediaId
               }
            }
         );
         Z409MediaId = Guid.NewGuid( );
         A409MediaId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound83 ;
      private short gxajaxcallmode ;
      private int Z413MediaSize ;
      private int trnEnded ;
      private int edtMediaId_Enabled ;
      private int edtMediaName_Enabled ;
      private int imgMediaImage_Enabled ;
      private int A413MediaSize ;
      private int edtMediaSize_Enabled ;
      private int edtMediaType_Enabled ;
      private int edtMediaUrl_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z414MediaType ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMediaId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtMediaId_Jsonclick ;
      private string edtMediaName_Internalname ;
      private string edtMediaName_Jsonclick ;
      private string imgMediaImage_Internalname ;
      private string sImgUrl ;
      private string edtMediaSize_Internalname ;
      private string edtMediaSize_Jsonclick ;
      private string edtMediaType_Internalname ;
      private string A414MediaType ;
      private string edtMediaType_Jsonclick ;
      private string edtMediaUrl_Internalname ;
      private string edtMediaUrl_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string hsh ;
      private string sMode83 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A411MediaImage_IsBlob ;
      private bool n40000MediaImage_GXI ;
      private bool n411MediaImage ;
      private bool returnInSub ;
      private string Z410MediaName ;
      private string Z412MediaUrl ;
      private string A410MediaName ;
      private string A40000MediaImage_GXI ;
      private string A412MediaUrl ;
      private string Z40000MediaImage_GXI ;
      private string A411MediaImage ;
      private string Z411MediaImage ;
      private Guid wcpOAV13MediaId ;
      private Guid Z409MediaId ;
      private Guid AV13MediaId ;
      private Guid A409MediaId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000X4_A409MediaId ;
      private string[] T000X4_A410MediaName ;
      private string[] T000X4_A40000MediaImage_GXI ;
      private bool[] T000X4_n40000MediaImage_GXI ;
      private int[] T000X4_A413MediaSize ;
      private string[] T000X4_A414MediaType ;
      private string[] T000X4_A412MediaUrl ;
      private string[] T000X4_A411MediaImage ;
      private bool[] T000X4_n411MediaImage ;
      private Guid[] T000X5_A409MediaId ;
      private Guid[] T000X3_A409MediaId ;
      private string[] T000X3_A410MediaName ;
      private string[] T000X3_A40000MediaImage_GXI ;
      private bool[] T000X3_n40000MediaImage_GXI ;
      private int[] T000X3_A413MediaSize ;
      private string[] T000X3_A414MediaType ;
      private string[] T000X3_A412MediaUrl ;
      private string[] T000X3_A411MediaImage ;
      private bool[] T000X3_n411MediaImage ;
      private Guid[] T000X6_A409MediaId ;
      private Guid[] T000X7_A409MediaId ;
      private Guid[] T000X2_A409MediaId ;
      private string[] T000X2_A410MediaName ;
      private string[] T000X2_A40000MediaImage_GXI ;
      private bool[] T000X2_n40000MediaImage_GXI ;
      private int[] T000X2_A413MediaSize ;
      private string[] T000X2_A414MediaType ;
      private string[] T000X2_A412MediaUrl ;
      private string[] T000X2_A411MediaImage ;
      private bool[] T000X2_n411MediaImage ;
      private Guid[] T000X12_A409MediaId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_media__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_media__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_media__default : DataStoreHelperBase, IDataStoreHelper
{
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
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000X2;
       prmT000X2 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X3;
       prmT000X3 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X4;
       prmT000X4 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X5;
       prmT000X5 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X6;
       prmT000X6 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X7;
       prmT000X7 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X8;
       prmT000X8 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0)
       };
       Object[] prmT000X9;
       prmT000X9 = new Object[] {
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0) ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X10;
       prmT000X10 = new Object[] {
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X11;
       prmT000X11 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X12;
       prmT000X12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000X2", "SELECT MediaId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaUrl, MediaImage FROM Trn_Media WHERE MediaId = :MediaId  FOR UPDATE OF Trn_Media NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X3", "SELECT MediaId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaUrl, MediaImage FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X4", "SELECT TM1.MediaId, TM1.MediaName, TM1.MediaImage_GXI, TM1.MediaSize, TM1.MediaType, TM1.MediaUrl, TM1.MediaImage FROM Trn_Media TM1 WHERE TM1.MediaId = :MediaId ORDER BY TM1.MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X5", "SELECT MediaId FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X6", "SELECT MediaId FROM Trn_Media WHERE ( MediaId > :MediaId) ORDER BY MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000X7", "SELECT MediaId FROM Trn_Media WHERE ( MediaId < :MediaId) ORDER BY MediaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000X8", "SAVEPOINT gxupdate;INSERT INTO Trn_Media(MediaId, MediaName, MediaImage, MediaImage_GXI, MediaSize, MediaType, MediaUrl) VALUES(:MediaId, :MediaName, :MediaImage, :MediaImage_GXI, :MediaSize, :MediaType, :MediaUrl);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000X8)
          ,new CursorDef("T000X9", "SAVEPOINT gxupdate;UPDATE Trn_Media SET MediaName=:MediaName, MediaSize=:MediaSize, MediaType=:MediaType, MediaUrl=:MediaUrl  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X9)
          ,new CursorDef("T000X10", "SAVEPOINT gxupdate;UPDATE Trn_Media SET MediaImage=:MediaImage, MediaImage_GXI=:MediaImage_GXI  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X10)
          ,new CursorDef("T000X11", "SAVEPOINT gxupdate;DELETE FROM Trn_Media  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X11)
          ,new CursorDef("T000X12", "SELECT MediaId FROM Trn_Media ORDER BY MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X12,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((int[]) buf[4])[0] = rslt.getInt(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
