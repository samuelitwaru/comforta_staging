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
   public class trn_organisationsetting : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"ORGANISATIONID") == 0 )
         {
            AV13Insert_OrganisationId = StringUtil.StrToGuid( GetPar( "Insert_OrganisationId"));
            AssignAttri("", false, "AV13Insert_OrganisationId", AV13Insert_OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAORGANISATIONID0F25( AV13Insert_OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_organisationsetting.aspx")), "trn_organisationsetting.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_organisationsetting.aspx")))) ;
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
                  AV7OrganisationSettingid = StringUtil.StrToGuid( GetPar( "OrganisationSettingid"));
                  AssignAttri("", false, "AV7OrganisationSettingid", AV7OrganisationSettingid.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV7OrganisationSettingid, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Organisation Settings", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = imgOrganisationSettingLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_organisationsetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationsetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_OrganisationSettingid )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7OrganisationSettingid = aP1_OrganisationSettingid;
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
            return "trn_organisationsetting_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_OrganisationSetting.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationSettingLogo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Logo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A101OrganisationSettingLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000OrganisationSettingLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.PathToRelativeUrl( A101OrganisationSettingLogo));
         GxWebStd.gx_bitmap( context, imgOrganisationSettingLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgOrganisationSettingLogo_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", "", "", 0, A101OrganisationSettingLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_OrganisationSetting.htm");
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.PathToRelativeUrl( A101OrganisationSettingLogo)), true);
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "IsBlob", StringUtil.BoolToStr( A101OrganisationSettingLogo_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationSettingFavicon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Favicon", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A102OrganisationSettingFavicon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001OrganisationSettingFavicon_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.PathToRelativeUrl( A102OrganisationSettingFavicon));
         GxWebStd.gx_bitmap( context, imgOrganisationSettingFavicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgOrganisationSettingFavicon_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", "", "", 0, A102OrganisationSettingFavicon_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_OrganisationSetting.htm");
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.PathToRelativeUrl( A102OrganisationSettingFavicon)), true);
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "IsBlob", StringUtil.BoolToStr( A102OrganisationSettingFavicon_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationsettinglanguage_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationsettinglanguage_Internalname, context.GetMessage( "Language", ""), "", "", lblTextblockorganisationsettinglanguage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_OrganisationSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationsettinglanguage.SetProperty("Caption", Combo_organisationsettinglanguage_Caption);
         ucCombo_organisationsettinglanguage.SetProperty("Cls", Combo_organisationsettinglanguage_Cls);
         ucCombo_organisationsettinglanguage.SetProperty("DataListType", Combo_organisationsettinglanguage_Datalisttype);
         ucCombo_organisationsettinglanguage.SetProperty("AllowMultipleSelection", Combo_organisationsettinglanguage_Allowmultipleselection);
         ucCombo_organisationsettinglanguage.SetProperty("DataListFixedValues", Combo_organisationsettinglanguage_Datalistfixedvalues);
         ucCombo_organisationsettinglanguage.SetProperty("IncludeOnlySelectedOption", Combo_organisationsettinglanguage_Includeonlyselectedoption);
         ucCombo_organisationsettinglanguage.SetProperty("MultipleValuesType", Combo_organisationsettinglanguage_Multiplevaluestype);
         ucCombo_organisationsettinglanguage.SetProperty("EmptyItemText", Combo_organisationsettinglanguage_Emptyitemtext);
         ucCombo_organisationsettinglanguage.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_organisationsettinglanguage.SetProperty("DropDownOptionsData", AV23OrganisationSettingLanguage_Data);
         ucCombo_organisationsettinglanguage.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationsettinglanguage_Internalname, "COMBO_ORGANISATIONSETTINGLANGUAGEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationSettingLanguage_Internalname, context.GetMessage( "Organisation Setting Language", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOrganisationSettingLanguage_Internalname, A105OrganisationSettingLanguage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", 0, 1, edtOrganisationSettingLanguage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_OrganisationSetting.htm");
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
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDdc_selectcolor.SetProperty("Caption", Ddc_selectcolor_Caption);
         ucDdc_selectcolor.SetProperty("Cls", Ddc_selectcolor_Cls);
         ucDdc_selectcolor.SetProperty("ComponentWidth", Ddc_selectcolor_Componentwidth);
         ucDdc_selectcolor.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_selectcolor_Internalname, "DDC_SELECTCOLORContainer");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationSetting.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationsettinglanguage_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtavComboorganisationsettinglanguage_Internalname, AV24ComboOrganisationSettingLanguage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, edtavComboorganisationsettinglanguage_Visible, edtavComboorganisationsettinglanguage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_OrganisationSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationSettingFontSize_Internalname, A104OrganisationSettingFontSize, StringUtil.RTrim( context.localUtil.Format( A104OrganisationSettingFontSize, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationSettingFontSize_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationSettingFontSize_Visible, edtOrganisationSettingFontSize_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationSetting.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_OrganisationSetting.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationSettingid_Internalname, A100OrganisationSettingid.ToString(), A100OrganisationSettingid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationSettingid_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationSettingid_Visible, edtOrganisationSettingid_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_OrganisationSetting.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationSettingBaseColor_Internalname, A103OrganisationSettingBaseColor, StringUtil.RTrim( context.localUtil.Format( A103OrganisationSettingBaseColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationSettingBaseColor_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationSettingBaseColor_Visible, edtOrganisationSettingBaseColor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationSetting.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0069"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0069"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
               }
               WebComp_Wwpaux_wc.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
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
         E110F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONSETTINGLANGUAGE_DATA"), AV23OrganisationSettingLanguage_Data);
               /* Read saved values. */
               Z100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( "Z100OrganisationSettingid"));
               Z103OrganisationSettingBaseColor = cgiGet( "Z103OrganisationSettingBaseColor");
               Z104OrganisationSettingFontSize = cgiGet( "Z104OrganisationSettingFontSize");
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               AV7OrganisationSettingid = StringUtil.StrToGuid( cgiGet( "vORGANISATIONSETTINGID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               A40000OrganisationSettingLogo_GXI = cgiGet( "ORGANISATIONSETTINGLOGO_GXI");
               A40001OrganisationSettingFavicon_GXI = cgiGet( "ORGANISATIONSETTINGFAVICON_GXI");
               AV29Pgmname = cgiGet( "vPGMNAME");
               Combo_organisationsettinglanguage_Objectcall = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Objectcall");
               Combo_organisationsettinglanguage_Class = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Class");
               Combo_organisationsettinglanguage_Icontype = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Icontype");
               Combo_organisationsettinglanguage_Icon = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Icon");
               Combo_organisationsettinglanguage_Caption = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Caption");
               Combo_organisationsettinglanguage_Tooltip = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Tooltip");
               Combo_organisationsettinglanguage_Cls = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Cls");
               Combo_organisationsettinglanguage_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectedvalue_set");
               Combo_organisationsettinglanguage_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectedvalue_get");
               Combo_organisationsettinglanguage_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectedtext_set");
               Combo_organisationsettinglanguage_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectedtext_get");
               Combo_organisationsettinglanguage_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Gamoauthtoken");
               Combo_organisationsettinglanguage_Ddointernalname = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Ddointernalname");
               Combo_organisationsettinglanguage_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Titlecontrolalign");
               Combo_organisationsettinglanguage_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Dropdownoptionstype");
               Combo_organisationsettinglanguage_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Enabled"));
               Combo_organisationsettinglanguage_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Visible"));
               Combo_organisationsettinglanguage_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Titlecontrolidtoreplace");
               Combo_organisationsettinglanguage_Datalisttype = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalisttype");
               Combo_organisationsettinglanguage_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Allowmultipleselection"));
               Combo_organisationsettinglanguage_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalistfixedvalues");
               Combo_organisationsettinglanguage_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Isgriditem"));
               Combo_organisationsettinglanguage_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Hasdescription"));
               Combo_organisationsettinglanguage_Datalistproc = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalistproc");
               Combo_organisationsettinglanguage_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalistprocparametersprefix");
               Combo_organisationsettinglanguage_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Remoteservicesparameters");
               Combo_organisationsettinglanguage_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationsettinglanguage_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Includeonlyselectedoption"));
               Combo_organisationsettinglanguage_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Includeselectalloption"));
               Combo_organisationsettinglanguage_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Emptyitem"));
               Combo_organisationsettinglanguage_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Includeaddnewoption"));
               Combo_organisationsettinglanguage_Htmltemplate = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Htmltemplate");
               Combo_organisationsettinglanguage_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Multiplevaluestype");
               Combo_organisationsettinglanguage_Loadingdata = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Loadingdata");
               Combo_organisationsettinglanguage_Noresultsfound = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Noresultsfound");
               Combo_organisationsettinglanguage_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Emptyitemtext");
               Combo_organisationsettinglanguage_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Onlyselectedvalues");
               Combo_organisationsettinglanguage_Selectalltext = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectalltext");
               Combo_organisationsettinglanguage_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Multiplevaluesseparator");
               Combo_organisationsettinglanguage_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Addnewoptiontext");
               Combo_organisationsettinglanguage_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONSETTINGLANGUAGE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Ddc_selectcolor_Objectcall = cgiGet( "DDC_SELECTCOLOR_Objectcall");
               Ddc_selectcolor_Class = cgiGet( "DDC_SELECTCOLOR_Class");
               Ddc_selectcolor_Enabled = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Enabled"));
               Ddc_selectcolor_Icontype = cgiGet( "DDC_SELECTCOLOR_Icontype");
               Ddc_selectcolor_Icon = cgiGet( "DDC_SELECTCOLOR_Icon");
               Ddc_selectcolor_Caption = cgiGet( "DDC_SELECTCOLOR_Caption");
               Ddc_selectcolor_Tooltip = cgiGet( "DDC_SELECTCOLOR_Tooltip");
               Ddc_selectcolor_Cls = cgiGet( "DDC_SELECTCOLOR_Cls");
               Ddc_selectcolor_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_SELECTCOLOR_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Ddc_selectcolor_Titlecontrolalign = cgiGet( "DDC_SELECTCOLOR_Titlecontrolalign");
               Ddc_selectcolor_Dropdownoptionstype = cgiGet( "DDC_SELECTCOLOR_Dropdownoptionstype");
               Ddc_selectcolor_Visible = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Visible"));
               Ddc_selectcolor_Result = cgiGet( "DDC_SELECTCOLOR_Result");
               Ddc_selectcolor_Titlecontrolidtoreplace = cgiGet( "DDC_SELECTCOLOR_Titlecontrolidtoreplace");
               Ddc_selectcolor_Showloading = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Showloading"));
               Ddc_selectcolor_Load = cgiGet( "DDC_SELECTCOLOR_Load");
               Ddc_selectcolor_Keepopened = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Keepopened"));
               Ddc_selectcolor_Trigger = cgiGet( "DDC_SELECTCOLOR_Trigger");
               Ddc_selectcolor_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_SELECTCOLOR_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A101OrganisationSettingLogo = cgiGet( imgOrganisationSettingLogo_Internalname);
               AssignAttri("", false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
               A102OrganisationSettingFavicon = cgiGet( imgOrganisationSettingFavicon_Internalname);
               AssignAttri("", false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
               A105OrganisationSettingLanguage = cgiGet( edtOrganisationSettingLanguage_Internalname);
               AssignAttri("", false, "A105OrganisationSettingLanguage", A105OrganisationSettingLanguage);
               AV24ComboOrganisationSettingLanguage = cgiGet( edtavComboorganisationsettinglanguage_Internalname);
               AssignAttri("", false, "AV24ComboOrganisationSettingLanguage", AV24ComboOrganisationSettingLanguage);
               A104OrganisationSettingFontSize = cgiGet( edtOrganisationSettingFontSize_Internalname);
               AssignAttri("", false, "A104OrganisationSettingFontSize", A104OrganisationSettingFontSize);
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationSettingid_Internalname), "") == 0 )
               {
                  A100OrganisationSettingid = Guid.Empty;
                  AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
               }
               else
               {
                  try
                  {
                     A100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( edtOrganisationSettingid_Internalname));
                     AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONSETTINGID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationSettingid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A103OrganisationSettingBaseColor = cgiGet( edtOrganisationSettingBaseColor_Internalname);
               AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgOrganisationSettingLogo_Internalname, ref  A101OrganisationSettingLogo, ref  A40000OrganisationSettingLogo_GXI);
               getMultimediaValue(imgOrganisationSettingFavicon_Internalname, ref  A102OrganisationSettingFavicon, ref  A40001OrganisationSettingFavicon_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_OrganisationSetting");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A100OrganisationSettingid != Z100OrganisationSettingid ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_organisationsetting:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A100OrganisationSettingid = StringUtil.StrToGuid( GetPar( "OrganisationSettingid"));
                  AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7OrganisationSettingid) )
                  {
                     A100OrganisationSettingid = AV7OrganisationSettingid;
                     AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A100OrganisationSettingid) && ( Gx_BScreen == 0 ) )
                     {
                        A100OrganisationSettingid = Guid.NewGuid( );
                        AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
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
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7OrganisationSettingid) )
                     {
                        A100OrganisationSettingid = AV7OrganisationSettingid;
                        AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A100OrganisationSettingid) && ( Gx_BScreen == 0 ) )
                        {
                           A100OrganisationSettingid = Guid.NewGuid( );
                           AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                        }
                     }
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ORGANISATIONSETTINGID");
                        AnyError = 1;
                        GX_FocusControl = edtOrganisationSettingid_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "DDC_SELECTCOLOR.ONLOADCOMPONENT") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_selectcolor.Onloadcomponent */
                           E120F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E130F2 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 69 )
                     {
                        OldWwpaux_wc = cgiGet( "W0069");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("W0069", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
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
            E130F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F25( ) ;
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
            DisableAttributes0F25( ) ;
         }
         AssignProp("", false, edtavComboorganisationsettinglanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationsettinglanguage_Enabled), 5, 0), true);
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F25( ) ;
            }
            else
            {
               CheckExtendedTable0F25( ) ;
               CloseExtendedTableCursors0F25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV24ComboOrganisationSettingLanguage = "";
         AssignAttri("", false, "AV24ComboOrganisationSettingLanguage", AV24ComboOrganisationSettingLanguage);
         edtavComboorganisationsettinglanguage_Visible = 0;
         AssignProp("", false, edtavComboorganisationsettinglanguage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationsettinglanguage_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONSETTINGLANGUAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV29Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV30GXV1 = 1;
            AssignAttri("", false, "AV30GXV1", StringUtil.LTrimStr( (decimal)(AV30GXV1), 8, 0));
            while ( AV30GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV30GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_OrganisationId", AV13Insert_OrganisationId.ToString());
               }
               AV30GXV1 = (int)(AV30GXV1+1);
               AssignAttri("", false, "AV30GXV1", StringUtil.LTrimStr( (decimal)(AV30GXV1), 8, 0));
            }
         }
         edtOrganisationSettingFontSize_Visible = 0;
         AssignProp("", false, edtOrganisationSettingFontSize_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingFontSize_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtOrganisationSettingid_Visible = 0;
         AssignProp("", false, edtOrganisationSettingid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Visible), 5, 0), true);
         edtOrganisationSettingBaseColor_Visible = 0;
         AssignProp("", false, edtOrganisationSettingBaseColor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingBaseColor_Visible), 5, 0), true);
      }

      protected void E130F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV12WebSession.Remove(context.GetMessage( "SelectedBaseColor", ""));
         GX_msglist.addItem(context.GetMessage( "Saved successfully", ""));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_organisationsettingww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E120F2( )
      {
         /* Ddc_selectcolor_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_Color")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_color", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_Color";
            WebComp_Wwpaux_wc_Component = "WC_Color";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0069",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOORGANISATIONSETTINGLANGUAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item2 = AV23OrganisationSettingLanguage_Data;
         new trn_organisationsettingloaddvcombo(context ).execute(  "OrganisationSettingLanguage",  Gx_mode,  AV7OrganisationSettingid, out  AV17ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item2) ;
         AV23OrganisationSettingLanguage_Data = GXt_objcol_SdtDVB_SDTComboData_Item2;
         Combo_organisationsettinglanguage_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_organisationsettinglanguage.SendProperty(context, "", false, Combo_organisationsettinglanguage_Internalname, "SelectedValue_set", Combo_organisationsettinglanguage_Selectedvalue_set);
         AV24ComboOrganisationSettingLanguage = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboOrganisationSettingLanguage", AV24ComboOrganisationSettingLanguage);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationsettinglanguage_Enabled = false;
            ucCombo_organisationsettinglanguage.SendProperty(context, "", false, Combo_organisationsettinglanguage_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationsettinglanguage_Enabled));
         }
      }

      protected void ZM0F25( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z103OrganisationSettingBaseColor = T000F3_A103OrganisationSettingBaseColor[0];
               Z104OrganisationSettingFontSize = T000F3_A104OrganisationSettingFontSize[0];
               Z11OrganisationId = T000F3_A11OrganisationId[0];
            }
            else
            {
               Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
               Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z100OrganisationSettingid = A100OrganisationSettingid;
            Z105OrganisationSettingLanguage = A105OrganisationSettingLanguage;
            Z103OrganisationSettingBaseColor = A103OrganisationSettingBaseColor;
            Z101OrganisationSettingLogo = A101OrganisationSettingLogo;
            Z40000OrganisationSettingLogo_GXI = A40000OrganisationSettingLogo_GXI;
            Z102OrganisationSettingFavicon = A102OrganisationSettingFavicon;
            Z40001OrganisationSettingFavicon_GXI = A40001OrganisationSettingFavicon_GXI;
            Z104OrganisationSettingFontSize = A104OrganisationSettingFontSize;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( 1 == 0 )
         {
            Ddc_selectcolor_Visible = true;
            ucDdc_selectcolor.SendProperty(context, "", false, Ddc_selectcolor_Internalname, "Visible", StringUtil.BoolToStr( Ddc_selectcolor_Visible));
         }
         else
         {
            if ( ! ( ( 1 == 0 ) ) )
            {
               Ddc_selectcolor_Visible = false;
               ucDdc_selectcolor.SendProperty(context, "", false, Ddc_selectcolor_Internalname, "Visible", StringUtil.BoolToStr( Ddc_selectcolor_Visible));
            }
         }
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV29Pgmname = "Trn_OrganisationSetting";
         AssignAttri("", false, "AV29Pgmname", AV29Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7OrganisationSettingid) )
         {
            edtOrganisationSettingid_Enabled = 0;
            AssignProp("", false, edtOrganisationSettingid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationSettingid_Enabled = 1;
            AssignProp("", false, edtOrganisationSettingid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7OrganisationSettingid) )
         {
            edtOrganisationSettingid_Enabled = 0;
            AssignProp("", false, edtOrganisationSettingid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), "")))) )
         {
            A103OrganisationSettingBaseColor = AV12WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), ""));
            AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            A11OrganisationId = AV13Insert_OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A11OrganisationId = GXt_guid3;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         A105OrganisationSettingLanguage = AV24ComboOrganisationSettingLanguage;
         AssignAttri("", false, "A105OrganisationSettingLanguage", A105OrganisationSettingLanguage);
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
         if ( ! (Guid.Empty==AV7OrganisationSettingid) )
         {
            A100OrganisationSettingid = AV7OrganisationSettingid;
            AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A100OrganisationSettingid) && ( Gx_BScreen == 0 ) )
            {
               A100OrganisationSettingid = Guid.NewGuid( );
               AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F25( )
      {
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
            A105OrganisationSettingLanguage = T000F5_A105OrganisationSettingLanguage[0];
            AssignAttri("", false, "A105OrganisationSettingLanguage", A105OrganisationSettingLanguage);
            A103OrganisationSettingBaseColor = T000F5_A103OrganisationSettingBaseColor[0];
            AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
            A40000OrganisationSettingLogo_GXI = T000F5_A40000OrganisationSettingLogo_GXI[0];
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
            A40001OrganisationSettingFavicon_GXI = T000F5_A40001OrganisationSettingFavicon_GXI[0];
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
            A104OrganisationSettingFontSize = T000F5_A104OrganisationSettingFontSize[0];
            AssignAttri("", false, "A104OrganisationSettingFontSize", A104OrganisationSettingFontSize);
            A11OrganisationId = T000F5_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A101OrganisationSettingLogo = T000F5_A101OrganisationSettingLogo[0];
            AssignAttri("", false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
            A102OrganisationSettingFavicon = T000F5_A102OrganisationSettingFavicon[0];
            AssignAttri("", false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
            ZM0F25( -15) ;
         }
         pr_default.close(3);
         OnLoadActions0F25( ) ;
      }

      protected void OnLoadActions0F25( )
      {
      }

      protected void CheckExtendedTable0F25( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F25( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( Guid A11OrganisationId )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0F25( )
      {
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F25( 15) ;
            RcdFound25 = 1;
            A100OrganisationSettingid = T000F3_A100OrganisationSettingid[0];
            AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
            A105OrganisationSettingLanguage = T000F3_A105OrganisationSettingLanguage[0];
            AssignAttri("", false, "A105OrganisationSettingLanguage", A105OrganisationSettingLanguage);
            A103OrganisationSettingBaseColor = T000F3_A103OrganisationSettingBaseColor[0];
            AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
            A40000OrganisationSettingLogo_GXI = T000F3_A40000OrganisationSettingLogo_GXI[0];
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
            A40001OrganisationSettingFavicon_GXI = T000F3_A40001OrganisationSettingFavicon_GXI[0];
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
            A104OrganisationSettingFontSize = T000F3_A104OrganisationSettingFontSize[0];
            AssignAttri("", false, "A104OrganisationSettingFontSize", A104OrganisationSettingFontSize);
            A11OrganisationId = T000F3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A101OrganisationSettingLogo = T000F3_A101OrganisationSettingLogo[0];
            AssignAttri("", false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
            AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
            A102OrganisationSettingFavicon = T000F3_A102OrganisationSettingFavicon[0];
            AssignAttri("", false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
            AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
            Z100OrganisationSettingid = A100OrganisationSettingid;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0F25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0F25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000F8_A100OrganisationSettingid[0], A100OrganisationSettingid, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000F8_A100OrganisationSettingid[0], A100OrganisationSettingid, 0) > 0 ) ) )
            {
               A100OrganisationSettingid = T000F8_A100OrganisationSettingid[0];
               AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
               RcdFound25 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A100OrganisationSettingid});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000F9_A100OrganisationSettingid[0], A100OrganisationSettingid, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000F9_A100OrganisationSettingid[0], A100OrganisationSettingid, 0) < 0 ) ) )
            {
               A100OrganisationSettingid = T000F9_A100OrganisationSettingid[0];
               AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
               RcdFound25 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = imgOrganisationSettingLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A100OrganisationSettingid != Z100OrganisationSettingid )
               {
                  A100OrganisationSettingid = Z100OrganisationSettingid;
                  AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORGANISATIONSETTINGID");
                  AnyError = 1;
                  GX_FocusControl = edtOrganisationSettingid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = imgOrganisationSettingLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F25( ) ;
                  GX_FocusControl = imgOrganisationSettingLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A100OrganisationSettingid != Z100OrganisationSettingid )
               {
                  /* Insert record */
                  GX_FocusControl = imgOrganisationSettingLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORGANISATIONSETTINGID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationSettingid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = imgOrganisationSettingLogo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F25( ) ;
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
         if ( A100OrganisationSettingid != Z100OrganisationSettingid )
         {
            A100OrganisationSettingid = Z100OrganisationSettingid;
            AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORGANISATIONSETTINGID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationSettingid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = imgOrganisationSettingLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A100OrganisationSettingid});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103OrganisationSettingBaseColor, T000F2_A103OrganisationSettingBaseColor[0]) != 0 ) || ( StringUtil.StrCmp(Z104OrganisationSettingFontSize, T000F2_A104OrganisationSettingFontSize[0]) != 0 ) || ( Z11OrganisationId != T000F2_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z103OrganisationSettingBaseColor, T000F2_A103OrganisationSettingBaseColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisationsetting:[seudo value changed for attri]"+"OrganisationSettingBaseColor");
                  GXUtil.WriteLogRaw("Old: ",Z103OrganisationSettingBaseColor);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A103OrganisationSettingBaseColor[0]);
               }
               if ( StringUtil.StrCmp(Z104OrganisationSettingFontSize, T000F2_A104OrganisationSettingFontSize[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisationsetting:[seudo value changed for attri]"+"OrganisationSettingFontSize");
                  GXUtil.WriteLogRaw("Old: ",Z104OrganisationSettingFontSize);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A104OrganisationSettingFontSize[0]);
               }
               if ( Z11OrganisationId != T000F2_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_organisationsetting:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationSetting"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F25( )
      {
         if ( ! IsAuthorized("trn_organisationsetting_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F25( 0) ;
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F10 */
                     pr_default.execute(8, new Object[] {A100OrganisationSettingid, A105OrganisationSettingLanguage, A103OrganisationSettingBaseColor, A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A104OrganisationSettingFontSize, A11OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
                     if ( (pr_default.getStatus(8) == 1) )
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
               Load0F25( ) ;
            }
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void Update0F25( )
      {
         if ( ! IsAuthorized("trn_organisationsetting_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F11 */
                     pr_default.execute(9, new Object[] {A105OrganisationSettingLanguage, A103OrganisationSettingBaseColor, A104OrganisationSettingFontSize, A11OrganisationId, A100OrganisationSettingid});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationSetting"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F25( ) ;
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
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void DeferredUpdate0F25( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000F12 */
            pr_default.execute(10, new Object[] {A101OrganisationSettingLogo, A40000OrganisationSettingLogo_GXI, A100OrganisationSettingid});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F13 */
            pr_default.execute(11, new Object[] {A102OrganisationSettingFavicon, A40001OrganisationSettingFavicon_GXI, A100OrganisationSettingid});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_organisationsetting_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F25( ) ;
            AfterConfirm0F25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F14 */
                  pr_default.execute(12, new Object[] {A100OrganisationSettingid});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_organisationsetting",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_organisationsetting",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F25( )
      {
         /* Scan By routine */
         /* Using cursor T000F15 */
         pr_default.execute(13);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound25 = 1;
            A100OrganisationSettingid = T000F15_A100OrganisationSettingid[0];
            AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F25( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound25 = 1;
            A100OrganisationSettingid = T000F15_A100OrganisationSettingid[0];
            AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         }
      }

      protected void ScanEnd0F25( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0F25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F25( )
      {
         /* Before Insert Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103OrganisationSettingBaseColor)) )
         {
            A103OrganisationSettingBaseColor = context.GetMessage( "Teal", "");
            AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
         }
      }

      protected void BeforeUpdate0F25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F25( )
      {
         imgOrganisationSettingLogo_Enabled = 0;
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationSettingLogo_Enabled), 5, 0), true);
         imgOrganisationSettingFavicon_Enabled = 0;
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationSettingFavicon_Enabled), 5, 0), true);
         edtOrganisationSettingLanguage_Enabled = 0;
         AssignProp("", false, edtOrganisationSettingLanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingLanguage_Enabled), 5, 0), true);
         edtavComboorganisationsettinglanguage_Enabled = 0;
         AssignProp("", false, edtavComboorganisationsettinglanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationsettinglanguage_Enabled), 5, 0), true);
         edtOrganisationSettingFontSize_Enabled = 0;
         AssignProp("", false, edtOrganisationSettingFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingFontSize_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtOrganisationSettingid_Enabled = 0;
         AssignProp("", false, edtOrganisationSettingid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Enabled), 5, 0), true);
         edtOrganisationSettingBaseColor_Enabled = 0;
         AssignProp("", false, edtOrganisationSettingBaseColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingBaseColor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "trn_organisationsetting.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7OrganisationSettingid.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_OrganisationSetting");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_organisationsetting:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z100OrganisationSettingid", Z100OrganisationSettingid.ToString());
         GxWebStd.gx_hidden_field( context, "Z103OrganisationSettingBaseColor", Z103OrganisationSettingBaseColor);
         GxWebStd.gx_hidden_field( context, "Z104OrganisationSettingFontSize", Z104OrganisationSettingFontSize);
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONSETTINGLANGUAGE_DATA", AV23OrganisationSettingLanguage_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONSETTINGLANGUAGE_DATA", AV23OrganisationSettingLanguage_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV7OrganisationSettingid.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV7OrganisationSettingid, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV13Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONSETTINGLOGO_GXI", A40000OrganisationSettingLogo_GXI);
         GxWebStd.gx_hidden_field( context, "ORGANISATIONSETTINGFAVICON_GXI", A40001OrganisationSettingFavicon_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GXCCtlgxBlob = "ORGANISATIONSETTINGLOGO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A101OrganisationSettingLogo);
         GXCCtlgxBlob = "ORGANISATIONSETTINGFAVICON" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A102OrganisationSettingFavicon);
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Objectcall", StringUtil.RTrim( Combo_organisationsettinglanguage_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Cls", StringUtil.RTrim( Combo_organisationsettinglanguage_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Selectedvalue_set", StringUtil.RTrim( Combo_organisationsettinglanguage_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Enabled", StringUtil.BoolToStr( Combo_organisationsettinglanguage_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalisttype", StringUtil.RTrim( Combo_organisationsettinglanguage_Datalisttype));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Allowmultipleselection", StringUtil.BoolToStr( Combo_organisationsettinglanguage_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Datalistfixedvalues", StringUtil.RTrim( Combo_organisationsettinglanguage_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_organisationsettinglanguage_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Multiplevaluestype", StringUtil.RTrim( Combo_organisationsettinglanguage_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONSETTINGLANGUAGE_Emptyitemtext", StringUtil.RTrim( Combo_organisationsettinglanguage_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Objectcall", StringUtil.RTrim( Ddc_selectcolor_Objectcall));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Enabled", StringUtil.BoolToStr( Ddc_selectcolor_Enabled));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Caption", StringUtil.RTrim( Ddc_selectcolor_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Cls", StringUtil.RTrim( Ddc_selectcolor_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_selectcolor_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Visible", StringUtil.BoolToStr( Ddc_selectcolor_Visible));
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
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
         GXEncryptionTmp = "trn_organisationsetting.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7OrganisationSettingid.ToString());
         return formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_OrganisationSetting" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Organisation Settings", "") ;
      }

      protected void InitializeNonKey0F25( )
      {
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A105OrganisationSettingLanguage = "";
         AssignAttri("", false, "A105OrganisationSettingLanguage", A105OrganisationSettingLanguage);
         A103OrganisationSettingBaseColor = "";
         AssignAttri("", false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
         A101OrganisationSettingLogo = "";
         AssignAttri("", false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
         A40000OrganisationSettingLogo_GXI = "";
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
         AssignProp("", false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
         A102OrganisationSettingFavicon = "";
         AssignAttri("", false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
         A40001OrganisationSettingFavicon_GXI = "";
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
         AssignProp("", false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
         A104OrganisationSettingFontSize = "";
         AssignAttri("", false, "A104OrganisationSettingFontSize", A104OrganisationSettingFontSize);
         Z103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0F25( )
      {
         A100OrganisationSettingid = Guid.NewGuid( );
         AssignAttri("", false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         InitializeNonKey0F25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411253404825", true, true);
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
         context.AddJavascriptSource("trn_organisationsetting.js", "?202411253404827", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         imgOrganisationSettingLogo_Internalname = "ORGANISATIONSETTINGLOGO";
         imgOrganisationSettingFavicon_Internalname = "ORGANISATIONSETTINGFAVICON";
         lblTextblockorganisationsettinglanguage_Internalname = "TEXTBLOCKORGANISATIONSETTINGLANGUAGE";
         Combo_organisationsettinglanguage_Internalname = "COMBO_ORGANISATIONSETTINGLANGUAGE";
         edtOrganisationSettingLanguage_Internalname = "ORGANISATIONSETTINGLANGUAGE";
         divTablesplittedorganisationsettinglanguage_Internalname = "TABLESPLITTEDORGANISATIONSETTINGLANGUAGE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Ddc_selectcolor_Internalname = "DDC_SELECTCOLOR";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboorganisationsettinglanguage_Internalname = "vCOMBOORGANISATIONSETTINGLANGUAGE";
         divSectionattribute_organisationsettinglanguage_Internalname = "SECTIONATTRIBUTE_ORGANISATIONSETTINGLANGUAGE";
         edtOrganisationSettingFontSize_Internalname = "ORGANISATIONSETTINGFONTSIZE";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtOrganisationSettingid_Internalname = "ORGANISATIONSETTINGID";
         edtOrganisationSettingBaseColor_Internalname = "ORGANISATIONSETTINGBASECOLOR";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = context.GetMessage( "Organisation Settings", "");
         Ddc_selectcolor_Visible = Convert.ToBoolean( -1);
         edtOrganisationSettingBaseColor_Jsonclick = "";
         edtOrganisationSettingBaseColor_Enabled = 1;
         edtOrganisationSettingBaseColor_Visible = 1;
         edtOrganisationSettingid_Jsonclick = "";
         edtOrganisationSettingid_Enabled = 1;
         edtOrganisationSettingid_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtOrganisationSettingFontSize_Jsonclick = "";
         edtOrganisationSettingFontSize_Enabled = 1;
         edtOrganisationSettingFontSize_Visible = 1;
         edtavComboorganisationsettinglanguage_Enabled = 0;
         edtavComboorganisationsettinglanguage_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Ddc_selectcolor_Componentwidth = 300;
         Ddc_selectcolor_Cls = "Attribute ExtendedCombo";
         Ddc_selectcolor_Caption = context.GetMessage( "Select Base Color", "");
         edtOrganisationSettingLanguage_Enabled = 1;
         Combo_organisationsettinglanguage_Emptyitemtext = "Select Languages";
         Combo_organisationsettinglanguage_Multiplevaluestype = "Tags";
         Combo_organisationsettinglanguage_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_organisationsettinglanguage_Datalistfixedvalues = "English:English,Dutch:Dutch";
         Combo_organisationsettinglanguage_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_organisationsettinglanguage_Datalisttype = "FixedValues";
         Combo_organisationsettinglanguage_Cls = "ExtendedCombo Attribute";
         Combo_organisationsettinglanguage_Caption = "";
         Combo_organisationsettinglanguage_Enabled = Convert.ToBoolean( -1);
         imgOrganisationSettingFavicon_Enabled = 1;
         imgOrganisationSettingLogo_Enabled = 1;
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

      protected void GX7ASAORGANISATIONID0F25( Guid AV13Insert_OrganisationId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            A11OrganisationId = AV13Insert_OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A11OrganisationId = GXt_guid3;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
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

      public void Valid_Organisationid( )
      {
         /* Using cursor T000F16 */
         pr_default.execute(14, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7OrganisationSettingid","fld":"vORGANISATIONSETTINGID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7OrganisationSettingid","fld":"vORGANISATIONSETTINGID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E130F2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("DDC_SELECTCOLOR.ONLOADCOMPONENT","""{"handler":"E120F2","iparms":[]""");
         setEventMetadata("DDC_SELECTCOLOR.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONSETTINGLANGUAGE","""{"handler":"Validv_Comboorganisationsettinglanguage","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_ORGANISATIONSETTINGID","""{"handler":"Valid_Organisationsettingid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONSETTINGBASECOLOR","""{"handler":"Valid_Organisationsettingbasecolor","iparms":[]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7OrganisationSettingid = Guid.Empty;
         Z100OrganisationSettingid = Guid.Empty;
         Z103OrganisationSettingBaseColor = "";
         Z104OrganisationSettingFontSize = "";
         Z11OrganisationId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         Combo_organisationsettinglanguage_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13Insert_OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A101OrganisationSettingLogo = "";
         A40000OrganisationSettingLogo_GXI = "";
         sImgUrl = "";
         A102OrganisationSettingFavicon = "";
         A40001OrganisationSettingFavicon_GXI = "";
         lblTextblockorganisationsettinglanguage_Jsonclick = "";
         ucCombo_organisationsettinglanguage = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23OrganisationSettingLanguage_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A105OrganisationSettingLanguage = "";
         ucDdc_selectcolor = new GXUserControl();
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV24ComboOrganisationSettingLanguage = "";
         A104OrganisationSettingFontSize = "";
         A100OrganisationSettingid = Guid.Empty;
         A103OrganisationSettingBaseColor = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV29Pgmname = "";
         Combo_organisationsettinglanguage_Objectcall = "";
         Combo_organisationsettinglanguage_Class = "";
         Combo_organisationsettinglanguage_Icontype = "";
         Combo_organisationsettinglanguage_Icon = "";
         Combo_organisationsettinglanguage_Tooltip = "";
         Combo_organisationsettinglanguage_Selectedvalue_set = "";
         Combo_organisationsettinglanguage_Selectedtext_set = "";
         Combo_organisationsettinglanguage_Selectedtext_get = "";
         Combo_organisationsettinglanguage_Gamoauthtoken = "";
         Combo_organisationsettinglanguage_Ddointernalname = "";
         Combo_organisationsettinglanguage_Titlecontrolalign = "";
         Combo_organisationsettinglanguage_Dropdownoptionstype = "";
         Combo_organisationsettinglanguage_Titlecontrolidtoreplace = "";
         Combo_organisationsettinglanguage_Datalistproc = "";
         Combo_organisationsettinglanguage_Datalistprocparametersprefix = "";
         Combo_organisationsettinglanguage_Remoteservicesparameters = "";
         Combo_organisationsettinglanguage_Htmltemplate = "";
         Combo_organisationsettinglanguage_Loadingdata = "";
         Combo_organisationsettinglanguage_Noresultsfound = "";
         Combo_organisationsettinglanguage_Onlyselectedvalues = "";
         Combo_organisationsettinglanguage_Selectalltext = "";
         Combo_organisationsettinglanguage_Multiplevaluesseparator = "";
         Combo_organisationsettinglanguage_Addnewoptiontext = "";
         Ddc_selectcolor_Objectcall = "";
         Ddc_selectcolor_Class = "";
         Ddc_selectcolor_Icontype = "";
         Ddc_selectcolor_Icon = "";
         Ddc_selectcolor_Tooltip = "";
         Ddc_selectcolor_Titlecontrolalign = "";
         Ddc_selectcolor_Dropdownoptionstype = "";
         Ddc_selectcolor_Result = "";
         Ddc_selectcolor_Titlecontrolidtoreplace = "";
         Ddc_selectcolor_Load = "";
         Ddc_selectcolor_Trigger = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         Z105OrganisationSettingLanguage = "";
         Z101OrganisationSettingLogo = "";
         Z40000OrganisationSettingLogo_GXI = "";
         Z102OrganisationSettingFavicon = "";
         Z40001OrganisationSettingFavicon_GXI = "";
         T000F5_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F5_A105OrganisationSettingLanguage = new string[] {""} ;
         T000F5_A103OrganisationSettingBaseColor = new string[] {""} ;
         T000F5_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         T000F5_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         T000F5_A104OrganisationSettingFontSize = new string[] {""} ;
         T000F5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000F5_A101OrganisationSettingLogo = new string[] {""} ;
         T000F5_A102OrganisationSettingFavicon = new string[] {""} ;
         T000F4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000F6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000F7_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F3_A105OrganisationSettingLanguage = new string[] {""} ;
         T000F3_A103OrganisationSettingBaseColor = new string[] {""} ;
         T000F3_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         T000F3_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         T000F3_A104OrganisationSettingFontSize = new string[] {""} ;
         T000F3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000F3_A101OrganisationSettingLogo = new string[] {""} ;
         T000F3_A102OrganisationSettingFavicon = new string[] {""} ;
         T000F8_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F9_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000F2_A105OrganisationSettingLanguage = new string[] {""} ;
         T000F2_A103OrganisationSettingBaseColor = new string[] {""} ;
         T000F2_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         T000F2_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         T000F2_A104OrganisationSettingFontSize = new string[] {""} ;
         T000F2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000F2_A101OrganisationSettingLogo = new string[] {""} ;
         T000F2_A102OrganisationSettingFavicon = new string[] {""} ;
         T000F15_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         GXt_guid3 = Guid.Empty;
         T000F16_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsetting__default(),
            new Object[][] {
                new Object[] {
               T000F2_A100OrganisationSettingid, T000F2_A105OrganisationSettingLanguage, T000F2_A103OrganisationSettingBaseColor, T000F2_A40000OrganisationSettingLogo_GXI, T000F2_A40001OrganisationSettingFavicon_GXI, T000F2_A104OrganisationSettingFontSize, T000F2_A11OrganisationId, T000F2_A101OrganisationSettingLogo, T000F2_A102OrganisationSettingFavicon
               }
               , new Object[] {
               T000F3_A100OrganisationSettingid, T000F3_A105OrganisationSettingLanguage, T000F3_A103OrganisationSettingBaseColor, T000F3_A40000OrganisationSettingLogo_GXI, T000F3_A40001OrganisationSettingFavicon_GXI, T000F3_A104OrganisationSettingFontSize, T000F3_A11OrganisationId, T000F3_A101OrganisationSettingLogo, T000F3_A102OrganisationSettingFavicon
               }
               , new Object[] {
               T000F4_A11OrganisationId
               }
               , new Object[] {
               T000F5_A100OrganisationSettingid, T000F5_A105OrganisationSettingLanguage, T000F5_A103OrganisationSettingBaseColor, T000F5_A40000OrganisationSettingLogo_GXI, T000F5_A40001OrganisationSettingFavicon_GXI, T000F5_A104OrganisationSettingFontSize, T000F5_A11OrganisationId, T000F5_A101OrganisationSettingLogo, T000F5_A102OrganisationSettingFavicon
               }
               , new Object[] {
               T000F6_A11OrganisationId
               }
               , new Object[] {
               T000F7_A100OrganisationSettingid
               }
               , new Object[] {
               T000F8_A100OrganisationSettingid
               }
               , new Object[] {
               T000F9_A100OrganisationSettingid
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
               }
               , new Object[] {
               T000F15_A100OrganisationSettingid
               }
               , new Object[] {
               T000F16_A11OrganisationId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Z100OrganisationSettingid = Guid.NewGuid( );
         A100OrganisationSettingid = Guid.NewGuid( );
         AV29Pgmname = "Trn_OrganisationSetting";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private short nCmpId ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int imgOrganisationSettingLogo_Enabled ;
      private int imgOrganisationSettingFavicon_Enabled ;
      private int edtOrganisationSettingLanguage_Enabled ;
      private int Ddc_selectcolor_Componentwidth ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboorganisationsettinglanguage_Visible ;
      private int edtavComboorganisationsettinglanguage_Enabled ;
      private int edtOrganisationSettingFontSize_Visible ;
      private int edtOrganisationSettingFontSize_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtOrganisationSettingid_Visible ;
      private int edtOrganisationSettingid_Enabled ;
      private int edtOrganisationSettingBaseColor_Visible ;
      private int edtOrganisationSettingBaseColor_Enabled ;
      private int Combo_organisationsettinglanguage_Datalistupdateminimumcharacters ;
      private int Combo_organisationsettinglanguage_Gxcontroltype ;
      private int Ddc_selectcolor_Gxcontroltype ;
      private int AV30GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_organisationsettinglanguage_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string imgOrganisationSettingLogo_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string TempTags ;
      private string sImgUrl ;
      private string imgOrganisationSettingFavicon_Internalname ;
      private string divTablesplittedorganisationsettinglanguage_Internalname ;
      private string lblTextblockorganisationsettinglanguage_Internalname ;
      private string lblTextblockorganisationsettinglanguage_Jsonclick ;
      private string Combo_organisationsettinglanguage_Caption ;
      private string Combo_organisationsettinglanguage_Cls ;
      private string Combo_organisationsettinglanguage_Datalisttype ;
      private string Combo_organisationsettinglanguage_Datalistfixedvalues ;
      private string Combo_organisationsettinglanguage_Multiplevaluestype ;
      private string Combo_organisationsettinglanguage_Emptyitemtext ;
      private string Combo_organisationsettinglanguage_Internalname ;
      private string edtOrganisationSettingLanguage_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string Ddc_selectcolor_Caption ;
      private string Ddc_selectcolor_Cls ;
      private string Ddc_selectcolor_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_organisationsettinglanguage_Internalname ;
      private string edtavComboorganisationsettinglanguage_Internalname ;
      private string edtOrganisationSettingFontSize_Internalname ;
      private string edtOrganisationSettingFontSize_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtOrganisationSettingid_Internalname ;
      private string edtOrganisationSettingid_Jsonclick ;
      private string edtOrganisationSettingBaseColor_Internalname ;
      private string edtOrganisationSettingBaseColor_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string AV29Pgmname ;
      private string Combo_organisationsettinglanguage_Objectcall ;
      private string Combo_organisationsettinglanguage_Class ;
      private string Combo_organisationsettinglanguage_Icontype ;
      private string Combo_organisationsettinglanguage_Icon ;
      private string Combo_organisationsettinglanguage_Tooltip ;
      private string Combo_organisationsettinglanguage_Selectedvalue_set ;
      private string Combo_organisationsettinglanguage_Selectedtext_set ;
      private string Combo_organisationsettinglanguage_Selectedtext_get ;
      private string Combo_organisationsettinglanguage_Gamoauthtoken ;
      private string Combo_organisationsettinglanguage_Ddointernalname ;
      private string Combo_organisationsettinglanguage_Titlecontrolalign ;
      private string Combo_organisationsettinglanguage_Dropdownoptionstype ;
      private string Combo_organisationsettinglanguage_Titlecontrolidtoreplace ;
      private string Combo_organisationsettinglanguage_Datalistproc ;
      private string Combo_organisationsettinglanguage_Datalistprocparametersprefix ;
      private string Combo_organisationsettinglanguage_Remoteservicesparameters ;
      private string Combo_organisationsettinglanguage_Htmltemplate ;
      private string Combo_organisationsettinglanguage_Loadingdata ;
      private string Combo_organisationsettinglanguage_Noresultsfound ;
      private string Combo_organisationsettinglanguage_Onlyselectedvalues ;
      private string Combo_organisationsettinglanguage_Selectalltext ;
      private string Combo_organisationsettinglanguage_Multiplevaluesseparator ;
      private string Combo_organisationsettinglanguage_Addnewoptiontext ;
      private string Ddc_selectcolor_Objectcall ;
      private string Ddc_selectcolor_Class ;
      private string Ddc_selectcolor_Icontype ;
      private string Ddc_selectcolor_Icon ;
      private string Ddc_selectcolor_Tooltip ;
      private string Ddc_selectcolor_Titlecontrolalign ;
      private string Ddc_selectcolor_Dropdownoptionstype ;
      private string Ddc_selectcolor_Result ;
      private string Ddc_selectcolor_Titlecontrolidtoreplace ;
      private string Ddc_selectcolor_Load ;
      private string Ddc_selectcolor_Trigger ;
      private string hsh ;
      private string sMode25 ;
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
      private bool A101OrganisationSettingLogo_IsBlob ;
      private bool A102OrganisationSettingFavicon_IsBlob ;
      private bool Combo_organisationsettinglanguage_Allowmultipleselection ;
      private bool Combo_organisationsettinglanguage_Includeonlyselectedoption ;
      private bool Combo_organisationsettinglanguage_Enabled ;
      private bool Combo_organisationsettinglanguage_Visible ;
      private bool Combo_organisationsettinglanguage_Isgriditem ;
      private bool Combo_organisationsettinglanguage_Hasdescription ;
      private bool Combo_organisationsettinglanguage_Includeselectalloption ;
      private bool Combo_organisationsettinglanguage_Emptyitem ;
      private bool Combo_organisationsettinglanguage_Includeaddnewoption ;
      private bool Ddc_selectcolor_Enabled ;
      private bool Ddc_selectcolor_Visible ;
      private bool Ddc_selectcolor_Showloading ;
      private bool Ddc_selectcolor_Keepopened ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private string A105OrganisationSettingLanguage ;
      private string AV24ComboOrganisationSettingLanguage ;
      private string Z105OrganisationSettingLanguage ;
      private string Z103OrganisationSettingBaseColor ;
      private string Z104OrganisationSettingFontSize ;
      private string A40000OrganisationSettingLogo_GXI ;
      private string A40001OrganisationSettingFavicon_GXI ;
      private string A104OrganisationSettingFontSize ;
      private string A103OrganisationSettingBaseColor ;
      private string AV17ComboSelectedValue ;
      private string Z40000OrganisationSettingLogo_GXI ;
      private string Z40001OrganisationSettingFavicon_GXI ;
      private string A101OrganisationSettingLogo ;
      private string A102OrganisationSettingFavicon ;
      private string Z101OrganisationSettingLogo ;
      private string Z102OrganisationSettingFavicon ;
      private Guid wcpOAV7OrganisationSettingid ;
      private Guid Z100OrganisationSettingid ;
      private Guid Z11OrganisationId ;
      private Guid N11OrganisationId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV7OrganisationSettingid ;
      private Guid A100OrganisationSettingid ;
      private Guid GXt_guid3 ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_organisationsettinglanguage ;
      private GXUserControl ucDdc_selectcolor ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23OrganisationSettingLanguage_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item2 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000F5_A100OrganisationSettingid ;
      private string[] T000F5_A105OrganisationSettingLanguage ;
      private string[] T000F5_A103OrganisationSettingBaseColor ;
      private string[] T000F5_A40000OrganisationSettingLogo_GXI ;
      private string[] T000F5_A40001OrganisationSettingFavicon_GXI ;
      private string[] T000F5_A104OrganisationSettingFontSize ;
      private Guid[] T000F5_A11OrganisationId ;
      private string[] T000F5_A101OrganisationSettingLogo ;
      private string[] T000F5_A102OrganisationSettingFavicon ;
      private Guid[] T000F4_A11OrganisationId ;
      private Guid[] T000F6_A11OrganisationId ;
      private Guid[] T000F7_A100OrganisationSettingid ;
      private Guid[] T000F3_A100OrganisationSettingid ;
      private string[] T000F3_A105OrganisationSettingLanguage ;
      private string[] T000F3_A103OrganisationSettingBaseColor ;
      private string[] T000F3_A40000OrganisationSettingLogo_GXI ;
      private string[] T000F3_A40001OrganisationSettingFavicon_GXI ;
      private string[] T000F3_A104OrganisationSettingFontSize ;
      private Guid[] T000F3_A11OrganisationId ;
      private string[] T000F3_A101OrganisationSettingLogo ;
      private string[] T000F3_A102OrganisationSettingFavicon ;
      private Guid[] T000F8_A100OrganisationSettingid ;
      private Guid[] T000F9_A100OrganisationSettingid ;
      private Guid[] T000F2_A100OrganisationSettingid ;
      private string[] T000F2_A105OrganisationSettingLanguage ;
      private string[] T000F2_A103OrganisationSettingBaseColor ;
      private string[] T000F2_A40000OrganisationSettingLogo_GXI ;
      private string[] T000F2_A40001OrganisationSettingFavicon_GXI ;
      private string[] T000F2_A104OrganisationSettingFontSize ;
      private Guid[] T000F2_A11OrganisationId ;
      private string[] T000F2_A101OrganisationSettingLogo ;
      private string[] T000F2_A102OrganisationSettingFavicon ;
      private Guid[] T000F15_A100OrganisationSettingid ;
      private Guid[] T000F16_A11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisationsetting__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisationsetting__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisationsetting__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000F2;
       prmT000F2 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F3;
       prmT000F3 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F4;
       prmT000F4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F5;
       prmT000F5 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F6;
       prmT000F6 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F7;
       prmT000F7 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F8;
       prmT000F8 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F9;
       prmT000F9 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F10;
       prmT000F10 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationSettingLanguage",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationSettingBaseColor",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingLogo"} ,
       new ParDef("OrganisationSettingFavicon",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingFavicon_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingFavicon"} ,
       new ParDef("OrganisationSettingFontSize",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F11;
       prmT000F11 = new Object[] {
       new ParDef("OrganisationSettingLanguage",GXType.LongVarChar,2097152,0) ,
       new ParDef("OrganisationSettingBaseColor",GXType.VarChar,40,0) ,
       new ParDef("OrganisationSettingFontSize",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F12;
       prmT000F12 = new Object[] {
       new ParDef("OrganisationSettingLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingLogo"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F13;
       prmT000F13 = new Object[] {
       new ParDef("OrganisationSettingFavicon",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationSettingFavicon_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_OrganisationSetting", Fld="OrganisationSettingFavicon"} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F14;
       prmT000F14 = new Object[] {
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000F15;
       prmT000F15 = new Object[] {
       };
       Object[] prmT000F16;
       prmT000F16 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000F2", "SELECT OrganisationSettingid, OrganisationSettingLanguage, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid  FOR UPDATE OF Trn_OrganisationSetting NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F3", "SELECT OrganisationSettingid, OrganisationSettingLanguage, OrganisationSettingBaseColor, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationId, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F5", "SELECT TM1.OrganisationSettingid, TM1.OrganisationSettingLanguage, TM1.OrganisationSettingBaseColor, TM1.OrganisationSettingLogo_GXI, TM1.OrganisationSettingFavicon_GXI, TM1.OrganisationSettingFontSize, TM1.OrganisationId, TM1.OrganisationSettingLogo, TM1.OrganisationSettingFavicon FROM Trn_OrganisationSetting TM1 WHERE TM1.OrganisationSettingid = :OrganisationSettingid ORDER BY TM1.OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F6", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F7", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F8", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE ( OrganisationSettingid > :OrganisationSettingid) ORDER BY OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000F9", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE ( OrganisationSettingid < :OrganisationSettingid) ORDER BY OrganisationSettingid DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000F10", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationSetting(OrganisationSettingid, OrganisationSettingLanguage, OrganisationSettingBaseColor, OrganisationSettingLogo, OrganisationSettingLogo_GXI, OrganisationSettingFavicon, OrganisationSettingFavicon_GXI, OrganisationSettingFontSize, OrganisationId) VALUES(:OrganisationSettingid, :OrganisationSettingLanguage, :OrganisationSettingBaseColor, :OrganisationSettingLogo, :OrganisationSettingLogo_GXI, :OrganisationSettingFavicon, :OrganisationSettingFavicon_GXI, :OrganisationSettingFontSize, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F10)
          ,new CursorDef("T000F11", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingLanguage=:OrganisationSettingLanguage, OrganisationSettingBaseColor=:OrganisationSettingBaseColor, OrganisationSettingFontSize=:OrganisationSettingFontSize, OrganisationId=:OrganisationId  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F11)
          ,new CursorDef("T000F12", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingLogo=:OrganisationSettingLogo, OrganisationSettingLogo_GXI=:OrganisationSettingLogo_GXI  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F12)
          ,new CursorDef("T000F13", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET OrganisationSettingFavicon=:OrganisationSettingFavicon, OrganisationSettingFavicon_GXI=:OrganisationSettingFavicon_GXI  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F13)
          ,new CursorDef("T000F14", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationSetting  WHERE OrganisationSettingid = :OrganisationSettingid;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F14)
          ,new CursorDef("T000F15", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting ORDER BY OrganisationSettingid ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F16", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F16,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
             ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
