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
   public class trn_location : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action30") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_30_046( A29LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"TRN_THEMEID") == 0 )
         {
            AV25Insert_Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Insert_Trn_ThemeId"));
            AssignAttri("", false, "AV25Insert_Trn_ThemeId", AV25Insert_Trn_ThemeId.ToString());
            A247Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASATRN_THEMEID046( AV25Insert_Trn_ThemeId, A247Trn_ThemeId, Gx_BScreen) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel17"+"_"+"LOCATIONPHONE") == 0 )
         {
            A383LocationPhoneCode = GetPar( "LocationPhoneCode");
            AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
            A384LocationPhoneNumber = GetPar( "LocationPhoneNumber");
            AssignAttri("", false, "A384LocationPhoneNumber", A384LocationPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX17ASALOCATIONPHONE046( A383LocationPhoneCode, A384LocationPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A247Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A247Trn_ThemeId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_location.aspx")), "trn_location.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_location.aspx")))) ;
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
                  AV7LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV7LocationId", AV7LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV7LocationId, context));
                  AV8OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV8OrganisationId", AV8OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV8OrganisationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Location", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_location( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_location( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
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
            return "trn_location_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Location Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Location.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationName_Internalname, A31LocationName, StringUtil.RTrim( context.localUtil.Format( A31LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEmail_Internalname, A34LocationEmail, StringUtil.RTrim( context.localUtil.Format( A34LocationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A34LocationEmail, "", "", context.GetMessage( "johndoe@gmail.com", ""), edtLocationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, divUnnamedtable5_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablelocationphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationphonecode.SetProperty("Caption", Combo_locationphonecode_Caption);
         ucCombo_locationphonecode.SetProperty("Cls", Combo_locationphonecode_Cls);
         ucCombo_locationphonecode.SetProperty("EmptyItem", Combo_locationphonecode_Emptyitem);
         ucCombo_locationphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_locationphonecode.SetProperty("DropDownOptionsData", AV21LocationPhoneCode_Data);
         ucCombo_locationphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationphonecode_Internalname, "COMBO_LOCATIONPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationPhoneCode_Internalname, context.GetMessage( "Location Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhoneCode_Internalname, A383LocationPhoneCode, StringUtil.RTrim( context.localUtil.Format( A383LocationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhoneCode_Visible, edtLocationPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationPhoneNumber_Internalname, context.GetMessage( "Location Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhoneNumber_Internalname, A384LocationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A384LocationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
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
         GxWebStd.gx_div_start( context, divLocationphone_cell_Internalname, 1, 0, "px", 0, "px", divLocationphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtLocationPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A35LocationPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationPhone_Internalname, StringUtil.RTrim( A35LocationPhone), StringUtil.RTrim( context.localUtil.Format( A35LocationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtLocationPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhone_Visible, edtLocationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgLocationImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A506LocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A506LocationImage));
         GxWebStd.gx_bitmap( context, imgLocationImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgLocationImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", "", "", 0, A506LocationImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Location.htm");
         AssignProp("", false, imgLocationImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A506LocationImage)), true);
         AssignProp("", false, imgLocationImage_Internalname, "IsBlob", StringUtil.BoolToStr( A506LocationImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Locationdescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Locationdescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucLocationdescription.SetProperty("Width", Locationdescription_Width);
         ucLocationdescription.SetProperty("Height", Locationdescription_Height);
         ucLocationdescription.SetProperty("Attribute", LocationDescription);
         ucLocationdescription.SetProperty("Toolbar", Locationdescription_Toolbar);
         ucLocationdescription.SetProperty("CustomToolbar", Locationdescription_Customtoolbar);
         ucLocationdescription.SetProperty("CustomConfiguration", Locationdescription_Customconfiguration);
         ucLocationdescription.SetProperty("CaptionClass", Locationdescription_Captionclass);
         ucLocationdescription.SetProperty("CaptionStyle", Locationdescription_Captionstyle);
         ucLocationdescription.SetProperty("CaptionPosition", Locationdescription_Captionposition);
         ucLocationdescription.Render(context, "fckeditor", Locationdescription_Internalname, "LOCATIONDESCRIPTIONContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Location.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationAddressLine1_Internalname, A340LocationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A340LocationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationAddressLine2_Internalname, A341LocationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A341LocationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationZipCode_Internalname, A339LocationZipCode, StringUtil.RTrim( context.localUtil.Format( A339LocationZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtLocationZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationCity_Internalname, A338LocationCity, StringUtil.RTrim( context.localUtil.Format( A338LocationCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlocationcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklocationcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblocklocationcountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationcountry.SetProperty("Caption", Combo_locationcountry_Caption);
         ucCombo_locationcountry.SetProperty("Cls", Combo_locationcountry_Cls);
         ucCombo_locationcountry.SetProperty("EmptyItem", Combo_locationcountry_Emptyitem);
         ucCombo_locationcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_locationcountry.SetProperty("DropDownOptionsData", AV22LocationCountry_Data);
         ucCombo_locationcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationcountry_Internalname, "COMBO_LOCATIONCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationCountry_Internalname, context.GetMessage( "Location Country", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationCountry_Internalname, A359LocationCountry, StringUtil.RTrim( context.localUtil.Format( A359LocationCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationCountry_Visible, edtLocationCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnudelete_Internalname, "", context.GetMessage( "Delete", ""), bttBtnudelete_Jsonclick, 5, context.GetMessage( "Delete", ""), "", StyleString, ClassString, bttBtnudelete_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUDELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Location.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_locationphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationphonecode_Internalname, AV16ComboLocationPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV16ComboLocationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationphonecode_Visible, edtavCombolocationphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_locationcountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationcountry_Internalname, AV23ComboLocationCountry, StringUtil.RTrim( context.localUtil.Format( AV23ComboLocationCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationcountry_Visible, edtavCombolocationcountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Location.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Location.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Location.htm");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONPHONECODE_DATA"), AV21LocationPhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONCOUNTRY_DATA"), AV22LocationCountry_Data);
               /* Read saved values. */
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z359LocationCountry = cgiGet( "Z359LocationCountry");
               Z383LocationPhoneCode = cgiGet( "Z383LocationPhoneCode");
               Z35LocationPhone = cgiGet( "Z35LocationPhone");
               Z339LocationZipCode = cgiGet( "Z339LocationZipCode");
               Z31LocationName = cgiGet( "Z31LocationName");
               Z338LocationCity = cgiGet( "Z338LocationCity");
               Z340LocationAddressLine1 = cgiGet( "Z340LocationAddressLine1");
               Z341LocationAddressLine2 = cgiGet( "Z341LocationAddressLine2");
               Z34LocationEmail = cgiGet( "Z34LocationEmail");
               Z384LocationPhoneNumber = cgiGet( "Z384LocationPhoneNumber");
               Z596LocationHasMyCare = StringUtil.StrToBool( cgiGet( "Z596LocationHasMyCare"));
               Z597LocationHasMyServices = StringUtil.StrToBool( cgiGet( "Z597LocationHasMyServices"));
               Z598LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "Z598LocationHasMyLiving"));
               Z599LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "Z599LocationHasOwnBrand"));
               Z518ToolBoxDefaultProfileImage = cgiGet( "Z518ToolBoxDefaultProfileImage");
               n518ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A518ToolBoxDefaultProfileImage)) ? true : false);
               Z517ToolBoxDefaultLogo = cgiGet( "Z517ToolBoxDefaultLogo");
               n517ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A517ToolBoxDefaultLogo)) ? true : false);
               Z601ReceptionDescription = cgiGet( "Z601ReceptionDescription");
               n601ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A601ReceptionDescription)) ? true : false);
               Z247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z247Trn_ThemeId"));
               n247Trn_ThemeId = ((Guid.Empty==A247Trn_ThemeId) ? true : false);
               A596LocationHasMyCare = StringUtil.StrToBool( cgiGet( "Z596LocationHasMyCare"));
               A597LocationHasMyServices = StringUtil.StrToBool( cgiGet( "Z597LocationHasMyServices"));
               A598LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "Z598LocationHasMyLiving"));
               A599LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "Z599LocationHasOwnBrand"));
               A518ToolBoxDefaultProfileImage = cgiGet( "Z518ToolBoxDefaultProfileImage");
               n518ToolBoxDefaultProfileImage = false;
               n518ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A518ToolBoxDefaultProfileImage)) ? true : false);
               A517ToolBoxDefaultLogo = cgiGet( "Z517ToolBoxDefaultLogo");
               n517ToolBoxDefaultLogo = false;
               n517ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A517ToolBoxDefaultLogo)) ? true : false);
               A601ReceptionDescription = cgiGet( "Z601ReceptionDescription");
               n601ReceptionDescription = false;
               n601ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A601ReceptionDescription)) ? true : false);
               A247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z247Trn_ThemeId"));
               n247Trn_ThemeId = false;
               n247Trn_ThemeId = ((Guid.Empty==A247Trn_ThemeId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "N247Trn_ThemeId"));
               n247Trn_ThemeId = ((Guid.Empty==A247Trn_ThemeId) ? true : false);
               AV7LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV25Insert_Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "vINSERT_TRN_THEMEID"));
               A247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "TRN_THEMEID"));
               n247Trn_ThemeId = ((Guid.Empty==A247Trn_ThemeId) ? true : false);
               A599LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( "LOCATIONHASOWNBRAND"));
               A598LocationHasMyLiving = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYLIVING"));
               A597LocationHasMyServices = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYSERVICES"));
               A596LocationHasMyCare = StringUtil.StrToBool( cgiGet( "LOCATIONHASMYCARE"));
               AV31ReceptionDescriptionVar = cgiGet( "vRECEPTIONDESCRIPTIONVAR");
               A601ReceptionDescription = cgiGet( "RECEPTIONDESCRIPTION");
               n601ReceptionDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A601ReceptionDescription)) ? true : false);
               AV30ReceptionImageVar = cgiGet( "vRECEPTIONIMAGEVAR");
               A600ReceptionImage = cgiGet( "RECEPTIONIMAGE");
               n600ReceptionImage = false;
               n600ReceptionImage = (String.IsNullOrEmpty(StringUtil.RTrim( A600ReceptionImage)) ? true : false);
               A40000LocationImage_GXI = cgiGet( "LOCATIONIMAGE_GXI");
               A36LocationDescription = cgiGet( "LOCATIONDESCRIPTION");
               A594LocationBrandTheme = cgiGet( "LOCATIONBRANDTHEME");
               n594LocationBrandTheme = false;
               n594LocationBrandTheme = (String.IsNullOrEmpty(StringUtil.RTrim( A594LocationBrandTheme)) ? true : false);
               A595LocationCtaTheme = cgiGet( "LOCATIONCTATHEME");
               n595LocationCtaTheme = false;
               n595LocationCtaTheme = (String.IsNullOrEmpty(StringUtil.RTrim( A595LocationCtaTheme)) ? true : false);
               A518ToolBoxDefaultProfileImage = cgiGet( "TOOLBOXDEFAULTPROFILEIMAGE");
               n518ToolBoxDefaultProfileImage = (String.IsNullOrEmpty(StringUtil.RTrim( A518ToolBoxDefaultProfileImage)) ? true : false);
               A517ToolBoxDefaultLogo = cgiGet( "TOOLBOXDEFAULTLOGO");
               n517ToolBoxDefaultLogo = (String.IsNullOrEmpty(StringUtil.RTrim( A517ToolBoxDefaultLogo)) ? true : false);
               A40001ReceptionImage_GXI = cgiGet( "RECEPTIONIMAGE_GXI");
               n40001ReceptionImage_GXI = false;
               n40001ReceptionImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40001ReceptionImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A600ReceptionImage)) ? true : false);
               AV34Pgmname = cgiGet( "vPGMNAME");
               Combo_locationphonecode_Objectcall = cgiGet( "COMBO_LOCATIONPHONECODE_Objectcall");
               Combo_locationphonecode_Class = cgiGet( "COMBO_LOCATIONPHONECODE_Class");
               Combo_locationphonecode_Icontype = cgiGet( "COMBO_LOCATIONPHONECODE_Icontype");
               Combo_locationphonecode_Icon = cgiGet( "COMBO_LOCATIONPHONECODE_Icon");
               Combo_locationphonecode_Caption = cgiGet( "COMBO_LOCATIONPHONECODE_Caption");
               Combo_locationphonecode_Tooltip = cgiGet( "COMBO_LOCATIONPHONECODE_Tooltip");
               Combo_locationphonecode_Cls = cgiGet( "COMBO_LOCATIONPHONECODE_Cls");
               Combo_locationphonecode_Selectedvalue_set = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedvalue_set");
               Combo_locationphonecode_Selectedvalue_get = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedvalue_get");
               Combo_locationphonecode_Selectedtext_set = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedtext_set");
               Combo_locationphonecode_Selectedtext_get = cgiGet( "COMBO_LOCATIONPHONECODE_Selectedtext_get");
               Combo_locationphonecode_Gamoauthtoken = cgiGet( "COMBO_LOCATIONPHONECODE_Gamoauthtoken");
               Combo_locationphonecode_Ddointernalname = cgiGet( "COMBO_LOCATIONPHONECODE_Ddointernalname");
               Combo_locationphonecode_Titlecontrolalign = cgiGet( "COMBO_LOCATIONPHONECODE_Titlecontrolalign");
               Combo_locationphonecode_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONPHONECODE_Dropdownoptionstype");
               Combo_locationphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Enabled"));
               Combo_locationphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Visible"));
               Combo_locationphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONPHONECODE_Titlecontrolidtoreplace");
               Combo_locationphonecode_Datalisttype = cgiGet( "COMBO_LOCATIONPHONECODE_Datalisttype");
               Combo_locationphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Allowmultipleselection"));
               Combo_locationphonecode_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistfixedvalues");
               Combo_locationphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Isgriditem"));
               Combo_locationphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Hasdescription"));
               Combo_locationphonecode_Datalistproc = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistproc");
               Combo_locationphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONPHONECODE_Datalistprocparametersprefix");
               Combo_locationphonecode_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONPHONECODE_Remoteservicesparameters");
               Combo_locationphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeonlyselectedoption"));
               Combo_locationphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeselectalloption"));
               Combo_locationphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Emptyitem"));
               Combo_locationphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONPHONECODE_Includeaddnewoption"));
               Combo_locationphonecode_Htmltemplate = cgiGet( "COMBO_LOCATIONPHONECODE_Htmltemplate");
               Combo_locationphonecode_Multiplevaluestype = cgiGet( "COMBO_LOCATIONPHONECODE_Multiplevaluestype");
               Combo_locationphonecode_Loadingdata = cgiGet( "COMBO_LOCATIONPHONECODE_Loadingdata");
               Combo_locationphonecode_Noresultsfound = cgiGet( "COMBO_LOCATIONPHONECODE_Noresultsfound");
               Combo_locationphonecode_Emptyitemtext = cgiGet( "COMBO_LOCATIONPHONECODE_Emptyitemtext");
               Combo_locationphonecode_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONPHONECODE_Onlyselectedvalues");
               Combo_locationphonecode_Selectalltext = cgiGet( "COMBO_LOCATIONPHONECODE_Selectalltext");
               Combo_locationphonecode_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONPHONECODE_Multiplevaluesseparator");
               Combo_locationphonecode_Addnewoptiontext = cgiGet( "COMBO_LOCATIONPHONECODE_Addnewoptiontext");
               Combo_locationphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Locationdescription_Objectcall = cgiGet( "LOCATIONDESCRIPTION_Objectcall");
               Locationdescription_Class = cgiGet( "LOCATIONDESCRIPTION_Class");
               Locationdescription_Enabled = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Enabled"));
               Locationdescription_Width = cgiGet( "LOCATIONDESCRIPTION_Width");
               Locationdescription_Height = cgiGet( "LOCATIONDESCRIPTION_Height");
               Locationdescription_Skin = cgiGet( "LOCATIONDESCRIPTION_Skin");
               Locationdescription_Toolbar = cgiGet( "LOCATIONDESCRIPTION_Toolbar");
               Locationdescription_Customtoolbar = cgiGet( "LOCATIONDESCRIPTION_Customtoolbar");
               Locationdescription_Customconfiguration = cgiGet( "LOCATIONDESCRIPTION_Customconfiguration");
               Locationdescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Toolbarcancollapse"));
               Locationdescription_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Toolbarexpanded"));
               Locationdescription_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LOCATIONDESCRIPTION_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Locationdescription_Buttonpressedid = cgiGet( "LOCATIONDESCRIPTION_Buttonpressedid");
               Locationdescription_Captionvalue = cgiGet( "LOCATIONDESCRIPTION_Captionvalue");
               Locationdescription_Captionclass = cgiGet( "LOCATIONDESCRIPTION_Captionclass");
               Locationdescription_Captionstyle = cgiGet( "LOCATIONDESCRIPTION_Captionstyle");
               Locationdescription_Captionposition = cgiGet( "LOCATIONDESCRIPTION_Captionposition");
               Locationdescription_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Isabstractlayoutcontrol"));
               Locationdescription_Coltitle = cgiGet( "LOCATIONDESCRIPTION_Coltitle");
               Locationdescription_Coltitlefont = cgiGet( "LOCATIONDESCRIPTION_Coltitlefont");
               Locationdescription_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LOCATIONDESCRIPTION_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Locationdescription_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Usercontroliscolumn"));
               Locationdescription_Visible = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTION_Visible"));
               Combo_locationcountry_Objectcall = cgiGet( "COMBO_LOCATIONCOUNTRY_Objectcall");
               Combo_locationcountry_Class = cgiGet( "COMBO_LOCATIONCOUNTRY_Class");
               Combo_locationcountry_Icontype = cgiGet( "COMBO_LOCATIONCOUNTRY_Icontype");
               Combo_locationcountry_Icon = cgiGet( "COMBO_LOCATIONCOUNTRY_Icon");
               Combo_locationcountry_Caption = cgiGet( "COMBO_LOCATIONCOUNTRY_Caption");
               Combo_locationcountry_Tooltip = cgiGet( "COMBO_LOCATIONCOUNTRY_Tooltip");
               Combo_locationcountry_Cls = cgiGet( "COMBO_LOCATIONCOUNTRY_Cls");
               Combo_locationcountry_Selectedvalue_set = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedvalue_set");
               Combo_locationcountry_Selectedvalue_get = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedvalue_get");
               Combo_locationcountry_Selectedtext_set = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedtext_set");
               Combo_locationcountry_Selectedtext_get = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectedtext_get");
               Combo_locationcountry_Gamoauthtoken = cgiGet( "COMBO_LOCATIONCOUNTRY_Gamoauthtoken");
               Combo_locationcountry_Ddointernalname = cgiGet( "COMBO_LOCATIONCOUNTRY_Ddointernalname");
               Combo_locationcountry_Titlecontrolalign = cgiGet( "COMBO_LOCATIONCOUNTRY_Titlecontrolalign");
               Combo_locationcountry_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONCOUNTRY_Dropdownoptionstype");
               Combo_locationcountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Enabled"));
               Combo_locationcountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Visible"));
               Combo_locationcountry_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONCOUNTRY_Titlecontrolidtoreplace");
               Combo_locationcountry_Datalisttype = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalisttype");
               Combo_locationcountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Allowmultipleselection"));
               Combo_locationcountry_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistfixedvalues");
               Combo_locationcountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Isgriditem"));
               Combo_locationcountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Hasdescription"));
               Combo_locationcountry_Datalistproc = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistproc");
               Combo_locationcountry_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistprocparametersprefix");
               Combo_locationcountry_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONCOUNTRY_Remoteservicesparameters");
               Combo_locationcountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONCOUNTRY_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationcountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeonlyselectedoption"));
               Combo_locationcountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeselectalloption"));
               Combo_locationcountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Emptyitem"));
               Combo_locationcountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONCOUNTRY_Includeaddnewoption"));
               Combo_locationcountry_Htmltemplate = cgiGet( "COMBO_LOCATIONCOUNTRY_Htmltemplate");
               Combo_locationcountry_Multiplevaluestype = cgiGet( "COMBO_LOCATIONCOUNTRY_Multiplevaluestype");
               Combo_locationcountry_Loadingdata = cgiGet( "COMBO_LOCATIONCOUNTRY_Loadingdata");
               Combo_locationcountry_Noresultsfound = cgiGet( "COMBO_LOCATIONCOUNTRY_Noresultsfound");
               Combo_locationcountry_Emptyitemtext = cgiGet( "COMBO_LOCATIONCOUNTRY_Emptyitemtext");
               Combo_locationcountry_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONCOUNTRY_Onlyselectedvalues");
               Combo_locationcountry_Selectalltext = cgiGet( "COMBO_LOCATIONCOUNTRY_Selectalltext");
               Combo_locationcountry_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONCOUNTRY_Multiplevaluesseparator");
               Combo_locationcountry_Addnewoptiontext = cgiGet( "COMBO_LOCATIONCOUNTRY_Addnewoptiontext");
               Combo_locationcountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONCOUNTRY_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A31LocationName = cgiGet( edtLocationName_Internalname);
               AssignAttri("", false, "A31LocationName", A31LocationName);
               A34LocationEmail = cgiGet( edtLocationEmail_Internalname);
               AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
               A383LocationPhoneCode = cgiGet( edtLocationPhoneCode_Internalname);
               AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
               A384LocationPhoneNumber = cgiGet( edtLocationPhoneNumber_Internalname);
               AssignAttri("", false, "A384LocationPhoneNumber", A384LocationPhoneNumber);
               A35LocationPhone = cgiGet( edtLocationPhone_Internalname);
               AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
               A506LocationImage = cgiGet( imgLocationImage_Internalname);
               AssignAttri("", false, "A506LocationImage", A506LocationImage);
               A340LocationAddressLine1 = cgiGet( edtLocationAddressLine1_Internalname);
               AssignAttri("", false, "A340LocationAddressLine1", A340LocationAddressLine1);
               A341LocationAddressLine2 = cgiGet( edtLocationAddressLine2_Internalname);
               AssignAttri("", false, "A341LocationAddressLine2", A341LocationAddressLine2);
               A339LocationZipCode = cgiGet( edtLocationZipCode_Internalname);
               AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
               A338LocationCity = cgiGet( edtLocationCity_Internalname);
               AssignAttri("", false, "A338LocationCity", A338LocationCity);
               A359LocationCountry = cgiGet( edtLocationCountry_Internalname);
               AssignAttri("", false, "A359LocationCountry", A359LocationCountry);
               AV16ComboLocationPhoneCode = cgiGet( edtavCombolocationphonecode_Internalname);
               AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
               AV23ComboLocationCountry = cgiGet( edtavCombolocationcountry_Internalname);
               AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
               if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
               {
                  A29LocationId = Guid.Empty;
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                     n29LocationId = false;
                     AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     n11OrganisationId = false;
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgLocationImage_Internalname, ref  A506LocationImage, ref  A40000LocationImage_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Location");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("LocationHasMyCare", StringUtil.BoolToStr( A596LocationHasMyCare));
               forbiddenHiddens.Add("LocationHasMyServices", StringUtil.BoolToStr( A597LocationHasMyServices));
               forbiddenHiddens.Add("LocationHasMyLiving", StringUtil.BoolToStr( A598LocationHasMyLiving));
               forbiddenHiddens.Add("LocationHasOwnBrand", StringUtil.BoolToStr( A599LocationHasOwnBrand));
               forbiddenHiddens.Add("ToolBoxDefaultProfileImage", StringUtil.RTrim( context.localUtil.Format( A518ToolBoxDefaultProfileImage, "")));
               forbiddenHiddens.Add("ToolBoxDefaultLogo", StringUtil.RTrim( context.localUtil.Format( A517ToolBoxDefaultLogo, "")));
               forbiddenHiddens.Add("ReceptionDescription", StringUtil.RTrim( context.localUtil.Format( A601ReceptionDescription, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_location:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7LocationId) )
                  {
                     A29LocationId = AV7LocationId;
                     n29LocationId = false;
                     AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A29LocationId) && ( Gx_BScreen == 0 ) )
                     {
                        A29LocationId = Guid.NewGuid( );
                        n29LocationId = false;
                        AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7LocationId) )
                     {
                        A29LocationId = AV7LocationId;
                        n29LocationId = false;
                        AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A29LocationId) && ( Gx_BScreen == 0 ) )
                        {
                           A29LocationId = Guid.NewGuid( );
                           n29LocationId = false;
                           AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                        }
                     }
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LOCATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtLocationId_Internalname;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOUDELETE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoUDelete' */
                           E13042 ();
                           nKeyPressed = 3;
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll046( ) ;
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
            DisableAttributes046( ) ;
         }
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         AV31ReceptionDescriptionVar = context.GetMessage( "Welkom bij de receptie van onze app. Hier kunt u al uw vragen stellen en krijgt u direct hulp van ons team. Of het nu gaat om technische ondersteuning, informatie over diensten, of algemene vragen, wij zijn er om u te helpen.", "");
         AssignAttri("", false, "AV31ReceptionDescriptionVar", AV31ReceptionDescriptionVar);
         imgReceptionimagevar_gximage = "ReceptionImageFile";
         AssignProp("", false, imgReceptionimagevar_Internalname, "gximage", imgReceptionimagevar_gximage, true);
         AV30ReceptionImageVar = context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( ));
         AssignAttri("", false, "AV30ReceptionImageVar", AV30ReceptionImageVar);
         AV33Receptionimagevar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( )), context);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtLocationCountry_Visible = 0;
         AssignProp("", false, edtLocationCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationCountry_Visible), 5, 0), true);
         AV23ComboLocationCountry = "";
         AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
         edtavCombolocationcountry_Visible = 0;
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationcountry_Htmltemplate = GXt_char2;
         ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "HTMLTemplate", Combo_locationcountry_Htmltemplate);
         edtLocationPhoneCode_Visible = 0;
         AssignProp("", false, edtLocationPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhoneCode_Visible), 5, 0), true);
         AV16ComboLocationPhoneCode = "";
         AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
         edtavCombolocationphonecode_Visible = 0;
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationphonecode_Htmltemplate = GXt_char2;
         ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "HTMLTemplate", Combo_locationphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONPHONECODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOLOCATIONCOUNTRY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            while ( AV35GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV26TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "Trn_ThemeId") == 0 )
               {
                  AV25Insert_Trn_ThemeId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV25Insert_Trn_ThemeId", AV25Insert_Trn_ThemeId.ToString());
               }
               AV35GXV1 = (int)(AV35GXV1+1);
               AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            }
         }
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV20defaultCountryPhoneCode = "+31";
            AssignAttri("", false, "AV20defaultCountryPhoneCode", AV20defaultCountryPhoneCode);
            Combo_locationphonecode_Selectedtext_set = AV20defaultCountryPhoneCode;
            ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "SelectedText_set", Combo_locationphonecode_Selectedtext_set);
            Combo_locationphonecode_Selectedvalue_set = AV20defaultCountryPhoneCode;
            ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "SelectedValue_set", Combo_locationphonecode_Selectedvalue_set);
         }
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_locationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtLocationPhone_Visible = 0;
         AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
         divLocationphone_cell_Class = "Invisible";
         AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
      }

      protected void E13042( )
      {
         /* 'DoUDelete' Routine */
         returnInSub = false;
         new prc_deletecascadelocation(context ).execute(  A29LocationId,  Guid.Empty,  A11OrganisationId,  true, ref  AV28isSuccessful, ref  AV29Message) ;
         AssignAttri("", false, "AV28isSuccessful", AV28isSuccessful);
         AssignAttri("", false, "AV29Message", AV29Message);
         if ( AV28isSuccessful )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Deleted location successfully", ""),  "success",  "",  "true",  ""));
            CallWebObject(formatLink("trn_locationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Failed",  AV29Message,  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV22LocationCountry_Data;
         new trn_locationloaddvcombo(context ).execute(  "LocationCountry",  Gx_mode,  AV7LocationId,  AV8OrganisationId, out  AV18ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV22LocationCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_locationcountry_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "SelectedValue_set", Combo_locationcountry_Selectedvalue_set);
         AV23ComboLocationCountry = AV18ComboSelectedValue;
         AssignAttri("", false, "AV23ComboLocationCountry", AV23ComboLocationCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_locationcountry_Enabled = false;
            ucCombo_locationcountry.SendProperty(context, "", false, Combo_locationcountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationcountry_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLOCATIONPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV21LocationPhoneCode_Data;
         new trn_locationloaddvcombo(context ).execute(  "LocationPhoneCode",  Gx_mode,  AV7LocationId,  AV8OrganisationId, out  AV18ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV21LocationPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_locationphonecode_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "SelectedValue_set", Combo_locationphonecode_Selectedvalue_set);
         AV16ComboLocationPhoneCode = AV18ComboSelectedValue;
         AssignAttri("", false, "AV16ComboLocationPhoneCode", AV16ComboLocationPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_locationphonecode_Enabled = false;
            ucCombo_locationphonecode.SendProperty(context, "", false, Combo_locationphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationphonecode_Enabled));
         }
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z359LocationCountry = T00043_A359LocationCountry[0];
               Z383LocationPhoneCode = T00043_A383LocationPhoneCode[0];
               Z35LocationPhone = T00043_A35LocationPhone[0];
               Z339LocationZipCode = T00043_A339LocationZipCode[0];
               Z31LocationName = T00043_A31LocationName[0];
               Z338LocationCity = T00043_A338LocationCity[0];
               Z340LocationAddressLine1 = T00043_A340LocationAddressLine1[0];
               Z341LocationAddressLine2 = T00043_A341LocationAddressLine2[0];
               Z34LocationEmail = T00043_A34LocationEmail[0];
               Z384LocationPhoneNumber = T00043_A384LocationPhoneNumber[0];
               Z596LocationHasMyCare = T00043_A596LocationHasMyCare[0];
               Z597LocationHasMyServices = T00043_A597LocationHasMyServices[0];
               Z598LocationHasMyLiving = T00043_A598LocationHasMyLiving[0];
               Z599LocationHasOwnBrand = T00043_A599LocationHasOwnBrand[0];
               Z518ToolBoxDefaultProfileImage = T00043_A518ToolBoxDefaultProfileImage[0];
               Z517ToolBoxDefaultLogo = T00043_A517ToolBoxDefaultLogo[0];
               Z601ReceptionDescription = T00043_A601ReceptionDescription[0];
               Z247Trn_ThemeId = T00043_A247Trn_ThemeId[0];
            }
            else
            {
               Z359LocationCountry = A359LocationCountry;
               Z383LocationPhoneCode = A383LocationPhoneCode;
               Z35LocationPhone = A35LocationPhone;
               Z339LocationZipCode = A339LocationZipCode;
               Z31LocationName = A31LocationName;
               Z338LocationCity = A338LocationCity;
               Z340LocationAddressLine1 = A340LocationAddressLine1;
               Z341LocationAddressLine2 = A341LocationAddressLine2;
               Z34LocationEmail = A34LocationEmail;
               Z384LocationPhoneNumber = A384LocationPhoneNumber;
               Z596LocationHasMyCare = A596LocationHasMyCare;
               Z597LocationHasMyServices = A597LocationHasMyServices;
               Z598LocationHasMyLiving = A598LocationHasMyLiving;
               Z599LocationHasOwnBrand = A599LocationHasOwnBrand;
               Z518ToolBoxDefaultProfileImage = A518ToolBoxDefaultProfileImage;
               Z517ToolBoxDefaultLogo = A517ToolBoxDefaultLogo;
               Z601ReceptionDescription = A601ReceptionDescription;
               Z247Trn_ThemeId = A247Trn_ThemeId;
            }
         }
         if ( GX_JID == -32 )
         {
            Z29LocationId = A29LocationId;
            Z359LocationCountry = A359LocationCountry;
            Z383LocationPhoneCode = A383LocationPhoneCode;
            Z35LocationPhone = A35LocationPhone;
            Z339LocationZipCode = A339LocationZipCode;
            Z31LocationName = A31LocationName;
            Z506LocationImage = A506LocationImage;
            Z40000LocationImage_GXI = A40000LocationImage_GXI;
            Z338LocationCity = A338LocationCity;
            Z340LocationAddressLine1 = A340LocationAddressLine1;
            Z341LocationAddressLine2 = A341LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z384LocationPhoneNumber = A384LocationPhoneNumber;
            Z36LocationDescription = A36LocationDescription;
            Z594LocationBrandTheme = A594LocationBrandTheme;
            Z595LocationCtaTheme = A595LocationCtaTheme;
            Z596LocationHasMyCare = A596LocationHasMyCare;
            Z597LocationHasMyServices = A597LocationHasMyServices;
            Z598LocationHasMyLiving = A598LocationHasMyLiving;
            Z599LocationHasOwnBrand = A599LocationHasOwnBrand;
            Z518ToolBoxDefaultProfileImage = A518ToolBoxDefaultProfileImage;
            Z517ToolBoxDefaultLogo = A517ToolBoxDefaultLogo;
            Z600ReceptionImage = A600ReceptionImage;
            Z40001ReceptionImage_GXI = A40001ReceptionImage_GXI;
            Z601ReceptionDescription = A601ReceptionDescription;
            Z11OrganisationId = A11OrganisationId;
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtnudelete_Visible = 1;
            AssignProp("", false, bttBtnudelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Visible), 5, 0), true);
         }
         else
         {
            if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
            {
               bttBtnudelete_Visible = 0;
               AssignProp("", false, bttBtnudelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Visible), 5, 0), true);
            }
         }
         edtLocationPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divLocationphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divLocationphone_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
            }
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         AV34Pgmname = "Trn_Location";
         AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            A11OrganisationId = AV8OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A383LocationPhoneCode = AV16ComboLocationPhoneCode;
         AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
         A359LocationCountry = AV23ComboLocationCountry;
         AssignAttri("", false, "A359LocationCountry", A359LocationCountry);
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
         if ( ! (Guid.Empty==AV7LocationId) )
         {
            A29LocationId = AV7LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A29LocationId) && ( Gx_BScreen == 0 ) )
            {
               A29LocationId = Guid.NewGuid( );
               n29LocationId = false;
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            }
         }
         if ( IsIns( )  && (false==A599LocationHasOwnBrand) && ( Gx_BScreen == 0 ) )
         {
            A599LocationHasOwnBrand = false;
            AssignAttri("", false, "A599LocationHasOwnBrand", A599LocationHasOwnBrand);
         }
         if ( IsIns( )  && (false==A598LocationHasMyLiving) && ( Gx_BScreen == 0 ) )
         {
            A598LocationHasMyLiving = false;
            AssignAttri("", false, "A598LocationHasMyLiving", A598LocationHasMyLiving);
         }
         if ( IsIns( )  && (false==A597LocationHasMyServices) && ( Gx_BScreen == 0 ) )
         {
            A597LocationHasMyServices = false;
            AssignAttri("", false, "A597LocationHasMyServices", A597LocationHasMyServices);
         }
         if ( IsIns( )  && (false==A596LocationHasMyCare) && ( Gx_BScreen == 0 ) )
         {
            A596LocationHasMyCare = false;
            AssignAttri("", false, "A596LocationHasMyCare", A596LocationHasMyCare);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A601ReceptionDescription)) && ( Gx_BScreen == 0 ) )
         {
            A601ReceptionDescription = AV31ReceptionDescriptionVar;
            n601ReceptionDescription = false;
            AssignAttri("", false, "A601ReceptionDescription", A601ReceptionDescription);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A600ReceptionImage)) && ( Gx_BScreen == 0 ) )
         {
            A600ReceptionImage = AV30ReceptionImageVar;
            n600ReceptionImage = false;
            AssignAttri("", false, "A600ReceptionImage", A600ReceptionImage);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load046( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A359LocationCountry = T00046_A359LocationCountry[0];
            AssignAttri("", false, "A359LocationCountry", A359LocationCountry);
            A383LocationPhoneCode = T00046_A383LocationPhoneCode[0];
            AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
            A35LocationPhone = T00046_A35LocationPhone[0];
            AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
            A339LocationZipCode = T00046_A339LocationZipCode[0];
            AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
            A31LocationName = T00046_A31LocationName[0];
            AssignAttri("", false, "A31LocationName", A31LocationName);
            A40000LocationImage_GXI = T00046_A40000LocationImage_GXI[0];
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
            A338LocationCity = T00046_A338LocationCity[0];
            AssignAttri("", false, "A338LocationCity", A338LocationCity);
            A340LocationAddressLine1 = T00046_A340LocationAddressLine1[0];
            AssignAttri("", false, "A340LocationAddressLine1", A340LocationAddressLine1);
            A341LocationAddressLine2 = T00046_A341LocationAddressLine2[0];
            AssignAttri("", false, "A341LocationAddressLine2", A341LocationAddressLine2);
            A34LocationEmail = T00046_A34LocationEmail[0];
            AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
            A384LocationPhoneNumber = T00046_A384LocationPhoneNumber[0];
            AssignAttri("", false, "A384LocationPhoneNumber", A384LocationPhoneNumber);
            A36LocationDescription = T00046_A36LocationDescription[0];
            A594LocationBrandTheme = T00046_A594LocationBrandTheme[0];
            n594LocationBrandTheme = T00046_n594LocationBrandTheme[0];
            A595LocationCtaTheme = T00046_A595LocationCtaTheme[0];
            n595LocationCtaTheme = T00046_n595LocationCtaTheme[0];
            A596LocationHasMyCare = T00046_A596LocationHasMyCare[0];
            A597LocationHasMyServices = T00046_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = T00046_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = T00046_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = T00046_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = T00046_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = T00046_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = T00046_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = T00046_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = T00046_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = T00046_A601ReceptionDescription[0];
            n601ReceptionDescription = T00046_n601ReceptionDescription[0];
            A247Trn_ThemeId = T00046_A247Trn_ThemeId[0];
            n247Trn_ThemeId = T00046_n247Trn_ThemeId[0];
            A506LocationImage = T00046_A506LocationImage[0];
            AssignAttri("", false, "A506LocationImage", A506LocationImage);
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
            A600ReceptionImage = T00046_A600ReceptionImage[0];
            n600ReceptionImage = T00046_n600ReceptionImage[0];
            ZM046( -32) ;
         }
         pr_default.close(4);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         A339LocationZipCode = StringUtil.Upper( A339LocationZipCode);
         AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV25Insert_Trn_ThemeId) )
         {
            A247Trn_ThemeId = AV25Insert_Trn_ThemeId;
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A247Trn_ThemeId) )
            {
               A247Trn_ThemeId = Guid.Empty;
               n247Trn_ThemeId = false;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               n247Trn_ThemeId = true;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            }
            else
            {
               if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
               {
                  GXt_guid4 = A247Trn_ThemeId;
                  new prc_getdefaulttheme(context ).execute( out  GXt_guid4) ;
                  A247Trn_ThemeId = GXt_guid4;
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               }
            }
         }
      }

      protected void CheckExtendedTable046( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         A339LocationZipCode = StringUtil.Upper( A339LocationZipCode);
         AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
         if ( ! GxRegex.IsMatch(A339LocationZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A339LocationZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "LOCATIONZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtLocationZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A34LocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Location Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "LOCATIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtLocationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) && ! GxRegex.IsMatch(A34LocationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Email format is invalid", ""), 1, "LOCATIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtLocationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A384LocationPhoneNumber)) && ! GxRegex.IsMatch(A384LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "LOCATIONPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtLocationPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV25Insert_Trn_ThemeId) )
         {
            A247Trn_ThemeId = AV25Insert_Trn_ThemeId;
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A247Trn_ThemeId) )
            {
               A247Trn_ThemeId = Guid.Empty;
               n247Trn_ThemeId = false;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               n247Trn_ThemeId = true;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            }
            else
            {
               if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
               {
                  GXt_guid4 = A247Trn_ThemeId;
                  new prc_getdefaulttheme(context ).execute( out  GXt_guid4) ;
                  A247Trn_ThemeId = GXt_guid4;
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               }
            }
         }
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A247Trn_ThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Themes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_33( Guid A11OrganisationId )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_34( Guid A247Trn_ThemeId )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {n247Trn_ThemeId, A247Trn_ThemeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A247Trn_ThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Themes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey046( )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 32) ;
            RcdFound6 = 1;
            A29LocationId = T00043_A29LocationId[0];
            n29LocationId = T00043_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A359LocationCountry = T00043_A359LocationCountry[0];
            AssignAttri("", false, "A359LocationCountry", A359LocationCountry);
            A383LocationPhoneCode = T00043_A383LocationPhoneCode[0];
            AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
            A35LocationPhone = T00043_A35LocationPhone[0];
            AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
            A339LocationZipCode = T00043_A339LocationZipCode[0];
            AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
            A31LocationName = T00043_A31LocationName[0];
            AssignAttri("", false, "A31LocationName", A31LocationName);
            A40000LocationImage_GXI = T00043_A40000LocationImage_GXI[0];
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
            A338LocationCity = T00043_A338LocationCity[0];
            AssignAttri("", false, "A338LocationCity", A338LocationCity);
            A340LocationAddressLine1 = T00043_A340LocationAddressLine1[0];
            AssignAttri("", false, "A340LocationAddressLine1", A340LocationAddressLine1);
            A341LocationAddressLine2 = T00043_A341LocationAddressLine2[0];
            AssignAttri("", false, "A341LocationAddressLine2", A341LocationAddressLine2);
            A34LocationEmail = T00043_A34LocationEmail[0];
            AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
            A384LocationPhoneNumber = T00043_A384LocationPhoneNumber[0];
            AssignAttri("", false, "A384LocationPhoneNumber", A384LocationPhoneNumber);
            A36LocationDescription = T00043_A36LocationDescription[0];
            A594LocationBrandTheme = T00043_A594LocationBrandTheme[0];
            n594LocationBrandTheme = T00043_n594LocationBrandTheme[0];
            A595LocationCtaTheme = T00043_A595LocationCtaTheme[0];
            n595LocationCtaTheme = T00043_n595LocationCtaTheme[0];
            A596LocationHasMyCare = T00043_A596LocationHasMyCare[0];
            A597LocationHasMyServices = T00043_A597LocationHasMyServices[0];
            A598LocationHasMyLiving = T00043_A598LocationHasMyLiving[0];
            A599LocationHasOwnBrand = T00043_A599LocationHasOwnBrand[0];
            A518ToolBoxDefaultProfileImage = T00043_A518ToolBoxDefaultProfileImage[0];
            n518ToolBoxDefaultProfileImage = T00043_n518ToolBoxDefaultProfileImage[0];
            A517ToolBoxDefaultLogo = T00043_A517ToolBoxDefaultLogo[0];
            n517ToolBoxDefaultLogo = T00043_n517ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = T00043_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = T00043_n40001ReceptionImage_GXI[0];
            A601ReceptionDescription = T00043_A601ReceptionDescription[0];
            n601ReceptionDescription = T00043_n601ReceptionDescription[0];
            A11OrganisationId = T00043_A11OrganisationId[0];
            n11OrganisationId = T00043_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A247Trn_ThemeId = T00043_A247Trn_ThemeId[0];
            n247Trn_ThemeId = T00043_n247Trn_ThemeId[0];
            A506LocationImage = T00043_A506LocationImage[0];
            AssignAttri("", false, "A506LocationImage", A506LocationImage);
            AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
            AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
            A600ReceptionImage = T00043_A600ReceptionImage[0];
            n600ReceptionImage = T00043_n600ReceptionImage[0];
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000410_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000410_A29LocationId[0] == A29LocationId ) && ( GuidUtil.Compare(T000410_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000410_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000410_A29LocationId[0] == A29LocationId ) && ( GuidUtil.Compare(T000410_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A29LocationId = T000410_A29LocationId[0];
               n29LocationId = T000410_n29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000410_A11OrganisationId[0];
               n11OrganisationId = T000410_n11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound6 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000411_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000411_A29LocationId[0] == A29LocationId ) && ( GuidUtil.Compare(T000411_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000411_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000411_A29LocationId[0] == A29LocationId ) && ( GuidUtil.Compare(T000411_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A29LocationId = T000411_A29LocationId[0];
               n29LocationId = T000411_n29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000411_A11OrganisationId[0];
               n11OrganisationId = T000411_n11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound6 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert046( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A29LocationId = Z29LocationId;
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update046( ) ;
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert046( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLocationName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert046( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A29LocationId = Z29LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = Z11OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z359LocationCountry, T00042_A359LocationCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z383LocationPhoneCode, T00042_A383LocationPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z35LocationPhone, T00042_A35LocationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z339LocationZipCode, T00042_A339LocationZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z31LocationName, T00042_A31LocationName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z338LocationCity, T00042_A338LocationCity[0]) != 0 ) || ( StringUtil.StrCmp(Z340LocationAddressLine1, T00042_A340LocationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z341LocationAddressLine2, T00042_A341LocationAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z34LocationEmail, T00042_A34LocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z384LocationPhoneNumber, T00042_A384LocationPhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z596LocationHasMyCare != T00042_A596LocationHasMyCare[0] ) || ( Z597LocationHasMyServices != T00042_A597LocationHasMyServices[0] ) || ( Z598LocationHasMyLiving != T00042_A598LocationHasMyLiving[0] ) || ( Z599LocationHasOwnBrand != T00042_A599LocationHasOwnBrand[0] ) || ( StringUtil.StrCmp(Z518ToolBoxDefaultProfileImage, T00042_A518ToolBoxDefaultProfileImage[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z517ToolBoxDefaultLogo, T00042_A517ToolBoxDefaultLogo[0]) != 0 ) || ( StringUtil.StrCmp(Z601ReceptionDescription, T00042_A601ReceptionDescription[0]) != 0 ) || ( Z247Trn_ThemeId != T00042_A247Trn_ThemeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z359LocationCountry, T00042_A359LocationCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationCountry");
                  GXUtil.WriteLogRaw("Old: ",Z359LocationCountry);
                  GXUtil.WriteLogRaw("Current: ",T00042_A359LocationCountry[0]);
               }
               if ( StringUtil.StrCmp(Z383LocationPhoneCode, T00042_A383LocationPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z383LocationPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00042_A383LocationPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z35LocationPhone, T00042_A35LocationPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhone");
                  GXUtil.WriteLogRaw("Old: ",Z35LocationPhone);
                  GXUtil.WriteLogRaw("Current: ",T00042_A35LocationPhone[0]);
               }
               if ( StringUtil.StrCmp(Z339LocationZipCode, T00042_A339LocationZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z339LocationZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00042_A339LocationZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z31LocationName, T00042_A31LocationName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationName");
                  GXUtil.WriteLogRaw("Old: ",Z31LocationName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A31LocationName[0]);
               }
               if ( StringUtil.StrCmp(Z338LocationCity, T00042_A338LocationCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationCity");
                  GXUtil.WriteLogRaw("Old: ",Z338LocationCity);
                  GXUtil.WriteLogRaw("Current: ",T00042_A338LocationCity[0]);
               }
               if ( StringUtil.StrCmp(Z340LocationAddressLine1, T00042_A340LocationAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z340LocationAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00042_A340LocationAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z341LocationAddressLine2, T00042_A341LocationAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z341LocationAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00042_A341LocationAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z34LocationEmail, T00042_A34LocationEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationEmail");
                  GXUtil.WriteLogRaw("Old: ",Z34LocationEmail);
                  GXUtil.WriteLogRaw("Current: ",T00042_A34LocationEmail[0]);
               }
               if ( StringUtil.StrCmp(Z384LocationPhoneNumber, T00042_A384LocationPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z384LocationPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00042_A384LocationPhoneNumber[0]);
               }
               if ( Z596LocationHasMyCare != T00042_A596LocationHasMyCare[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyCare");
                  GXUtil.WriteLogRaw("Old: ",Z596LocationHasMyCare);
                  GXUtil.WriteLogRaw("Current: ",T00042_A596LocationHasMyCare[0]);
               }
               if ( Z597LocationHasMyServices != T00042_A597LocationHasMyServices[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyServices");
                  GXUtil.WriteLogRaw("Old: ",Z597LocationHasMyServices);
                  GXUtil.WriteLogRaw("Current: ",T00042_A597LocationHasMyServices[0]);
               }
               if ( Z598LocationHasMyLiving != T00042_A598LocationHasMyLiving[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasMyLiving");
                  GXUtil.WriteLogRaw("Old: ",Z598LocationHasMyLiving);
                  GXUtil.WriteLogRaw("Current: ",T00042_A598LocationHasMyLiving[0]);
               }
               if ( Z599LocationHasOwnBrand != T00042_A599LocationHasOwnBrand[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"LocationHasOwnBrand");
                  GXUtil.WriteLogRaw("Old: ",Z599LocationHasOwnBrand);
                  GXUtil.WriteLogRaw("Current: ",T00042_A599LocationHasOwnBrand[0]);
               }
               if ( StringUtil.StrCmp(Z518ToolBoxDefaultProfileImage, T00042_A518ToolBoxDefaultProfileImage[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxDefaultProfileImage");
                  GXUtil.WriteLogRaw("Old: ",Z518ToolBoxDefaultProfileImage);
                  GXUtil.WriteLogRaw("Current: ",T00042_A518ToolBoxDefaultProfileImage[0]);
               }
               if ( StringUtil.StrCmp(Z517ToolBoxDefaultLogo, T00042_A517ToolBoxDefaultLogo[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ToolBoxDefaultLogo");
                  GXUtil.WriteLogRaw("Old: ",Z517ToolBoxDefaultLogo);
                  GXUtil.WriteLogRaw("Current: ",T00042_A517ToolBoxDefaultLogo[0]);
               }
               if ( StringUtil.StrCmp(Z601ReceptionDescription, T00042_A601ReceptionDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"ReceptionDescription");
                  GXUtil.WriteLogRaw("Old: ",Z601ReceptionDescription);
                  GXUtil.WriteLogRaw("Current: ",T00042_A601ReceptionDescription[0]);
               }
               if ( Z247Trn_ThemeId != T00042_A247Trn_ThemeId[0] )
               {
                  GXUtil.WriteLog("trn_location:[seudo value changed for attri]"+"Trn_ThemeId");
                  GXUtil.WriteLogRaw("Old: ",Z247Trn_ThemeId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A247Trn_ThemeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Location"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         if ( ! IsAuthorized("trn_location_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {n29LocationId, A29LocationId, A359LocationCountry, A383LocationPhoneCode, A35LocationPhone, A339LocationZipCode, A31LocationName, A506LocationImage, A40000LocationImage_GXI, A338LocationCity, A340LocationAddressLine1, A341LocationAddressLine2, A34LocationEmail, A384LocationPhoneNumber, A36LocationDescription, n594LocationBrandTheme, A594LocationBrandTheme, n595LocationCtaTheme, A595LocationCtaTheme, A596LocationHasMyCare, A597LocationHasMyServices, A598LocationHasMyLiving, A599LocationHasOwnBrand, n518ToolBoxDefaultProfileImage, A518ToolBoxDefaultProfileImage, n517ToolBoxDefaultLogo, A517ToolBoxDefaultLogo, n600ReceptionImage, A600ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n601ReceptionDescription, A601ReceptionDescription, n11OrganisationId, A11OrganisationId, n247Trn_ThemeId, A247Trn_ThemeId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         if ( ! IsAuthorized("trn_location_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000413 */
                     pr_default.execute(11, new Object[] {A359LocationCountry, A383LocationPhoneCode, A35LocationPhone, A339LocationZipCode, A31LocationName, A338LocationCity, A340LocationAddressLine1, A341LocationAddressLine2, A34LocationEmail, A384LocationPhoneNumber, A36LocationDescription, n594LocationBrandTheme, A594LocationBrandTheme, n595LocationCtaTheme, A595LocationCtaTheme, A596LocationHasMyCare, A597LocationHasMyServices, A598LocationHasMyLiving, A599LocationHasOwnBrand, n518ToolBoxDefaultProfileImage, A518ToolBoxDefaultProfileImage, n517ToolBoxDefaultLogo, A517ToolBoxDefaultLogo, n601ReceptionDescription, A601ReceptionDescription, n247Trn_ThemeId, A247Trn_ThemeId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000414 */
            pr_default.execute(12, new Object[] {A506LocationImage, A40000LocationImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {n600ReceptionImage, A600ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_location_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000416 */
                  pr_default.execute(14, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel046( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000417 */
            pr_default.execute(15, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentPackage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_AppVersion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda/Calendar", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000420 */
            pr_default.execute(18, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000421 */
            pr_default.execute(19, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000422 */
            pr_default.execute(20, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Receptionists", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000423 */
            pr_default.execute(21, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_location",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_location",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart046( )
      {
         /* Scan By routine */
         /* Using cursor T000424 */
         pr_default.execute(22);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = T000424_A29LocationId[0];
            n29LocationId = T000424_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000424_A11OrganisationId[0];
            n11OrganisationId = T000424_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = T000424_A29LocationId[0];
            n29LocationId = T000424_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000424_A11OrganisationId[0];
            n11OrganisationId = T000424_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd046( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
         edtLocationName_Enabled = 0;
         AssignProp("", false, edtLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationName_Enabled), 5, 0), true);
         edtLocationEmail_Enabled = 0;
         AssignProp("", false, edtLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEmail_Enabled), 5, 0), true);
         edtLocationPhoneCode_Enabled = 0;
         AssignProp("", false, edtLocationPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneCode_Enabled), 5, 0), true);
         edtLocationPhoneNumber_Enabled = 0;
         AssignProp("", false, edtLocationPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneNumber_Enabled), 5, 0), true);
         edtLocationPhone_Enabled = 0;
         AssignProp("", false, edtLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Enabled), 5, 0), true);
         imgLocationImage_Enabled = 0;
         AssignProp("", false, imgLocationImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgLocationImage_Enabled), 5, 0), true);
         edtLocationAddressLine1_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine1_Enabled), 5, 0), true);
         edtLocationAddressLine2_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine2_Enabled), 5, 0), true);
         edtLocationZipCode_Enabled = 0;
         AssignProp("", false, edtLocationZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationZipCode_Enabled), 5, 0), true);
         edtLocationCity_Enabled = 0;
         AssignProp("", false, edtLocationCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCity_Enabled), 5, 0), true);
         edtLocationCountry_Enabled = 0;
         AssignProp("", false, edtLocationCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCountry_Enabled), 5, 0), true);
         edtavCombolocationphonecode_Enabled = 0;
         AssignProp("", false, edtavCombolocationphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationphonecode_Enabled), 5, 0), true);
         edtavCombolocationcountry_Enabled = 0;
         AssignProp("", false, edtavCombolocationcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationcountry_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         Locationdescription_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Locationdescription_Internalname, "Enabled", StringUtil.BoolToStr( Locationdescription_Enabled), true);
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "trn_location.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7LocationId.ToString()) + "," + UrlEncode(AV8OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_location.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Location");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("LocationHasMyCare", StringUtil.BoolToStr( A596LocationHasMyCare));
         forbiddenHiddens.Add("LocationHasMyServices", StringUtil.BoolToStr( A597LocationHasMyServices));
         forbiddenHiddens.Add("LocationHasMyLiving", StringUtil.BoolToStr( A598LocationHasMyLiving));
         forbiddenHiddens.Add("LocationHasOwnBrand", StringUtil.BoolToStr( A599LocationHasOwnBrand));
         forbiddenHiddens.Add("ToolBoxDefaultProfileImage", StringUtil.RTrim( context.localUtil.Format( A518ToolBoxDefaultProfileImage, "")));
         forbiddenHiddens.Add("ToolBoxDefaultLogo", StringUtil.RTrim( context.localUtil.Format( A517ToolBoxDefaultLogo, "")));
         forbiddenHiddens.Add("ReceptionDescription", StringUtil.RTrim( context.localUtil.Format( A601ReceptionDescription, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_location:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z359LocationCountry", Z359LocationCountry);
         GxWebStd.gx_hidden_field( context, "Z383LocationPhoneCode", Z383LocationPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z35LocationPhone", StringUtil.RTrim( Z35LocationPhone));
         GxWebStd.gx_hidden_field( context, "Z339LocationZipCode", Z339LocationZipCode);
         GxWebStd.gx_hidden_field( context, "Z31LocationName", Z31LocationName);
         GxWebStd.gx_hidden_field( context, "Z338LocationCity", Z338LocationCity);
         GxWebStd.gx_hidden_field( context, "Z340LocationAddressLine1", Z340LocationAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z341LocationAddressLine2", Z341LocationAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z34LocationEmail", Z34LocationEmail);
         GxWebStd.gx_hidden_field( context, "Z384LocationPhoneNumber", Z384LocationPhoneNumber);
         GxWebStd.gx_boolean_hidden_field( context, "Z596LocationHasMyCare", Z596LocationHasMyCare);
         GxWebStd.gx_boolean_hidden_field( context, "Z597LocationHasMyServices", Z597LocationHasMyServices);
         GxWebStd.gx_boolean_hidden_field( context, "Z598LocationHasMyLiving", Z598LocationHasMyLiving);
         GxWebStd.gx_boolean_hidden_field( context, "Z599LocationHasOwnBrand", Z599LocationHasOwnBrand);
         GxWebStd.gx_hidden_field( context, "Z518ToolBoxDefaultProfileImage", Z518ToolBoxDefaultProfileImage);
         GxWebStd.gx_hidden_field( context, "Z517ToolBoxDefaultLogo", Z517ToolBoxDefaultLogo);
         GxWebStd.gx_hidden_field( context, "Z601ReceptionDescription", Z601ReceptionDescription);
         GxWebStd.gx_hidden_field( context, "Z247Trn_ThemeId", Z247Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N247Trn_ThemeId", A247Trn_ThemeId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONPHONECODE_DATA", AV21LocationPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONPHONECODE_DATA", AV21LocationPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONCOUNTRY_DATA", AV22LocationCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONCOUNTRY_DATA", AV22LocationCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISSUCCESSFUL", AV28isSuccessful);
         GxWebStd.gx_hidden_field( context, "vMESSAGE", StringUtil.RTrim( AV29Message));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV7LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV7LocationId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV8OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV8OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TRN_THEMEID", AV25Insert_Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "TRN_THEMEID", A247Trn_ThemeId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASOWNBRAND", A599LocationHasOwnBrand);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYLIVING", A598LocationHasMyLiving);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYSERVICES", A597LocationHasMyServices);
         GxWebStd.gx_boolean_hidden_field( context, "LOCATIONHASMYCARE", A596LocationHasMyCare);
         GxWebStd.gx_hidden_field( context, "vRECEPTIONDESCRIPTIONVAR", AV31ReceptionDescriptionVar);
         GxWebStd.gx_hidden_field( context, "RECEPTIONDESCRIPTION", A601ReceptionDescription);
         GxWebStd.gx_hidden_field( context, "vRECEPTIONIMAGEVAR", AV30ReceptionImageVar);
         GxWebStd.gx_hidden_field( context, "RECEPTIONIMAGE", A600ReceptionImage);
         GxWebStd.gx_hidden_field( context, "LOCATIONIMAGE_GXI", A40000LocationImage_GXI);
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION", A36LocationDescription);
         GxWebStd.gx_hidden_field( context, "LOCATIONBRANDTHEME", A594LocationBrandTheme);
         GxWebStd.gx_hidden_field( context, "LOCATIONCTATHEME", A595LocationCtaTheme);
         GxWebStd.gx_hidden_field( context, "TOOLBOXDEFAULTPROFILEIMAGE", A518ToolBoxDefaultProfileImage);
         GxWebStd.gx_hidden_field( context, "TOOLBOXDEFAULTLOGO", A517ToolBoxDefaultLogo);
         GxWebStd.gx_hidden_field( context, "RECEPTIONIMAGE_GXI", A40001ReceptionImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GXCCtlgxBlob = "LOCATIONIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A506LocationImage);
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Objectcall", StringUtil.RTrim( Combo_locationphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Cls", StringUtil.RTrim( Combo_locationphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_locationphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_locationphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Enabled", StringUtil.BoolToStr( Combo_locationphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_locationphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_locationphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Objectcall", StringUtil.RTrim( Locationdescription_Objectcall));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Enabled", StringUtil.BoolToStr( Locationdescription_Enabled));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Width", StringUtil.RTrim( Locationdescription_Width));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Height", StringUtil.RTrim( Locationdescription_Height));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Toolbar", StringUtil.RTrim( Locationdescription_Toolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Customtoolbar", StringUtil.RTrim( Locationdescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Customconfiguration", StringUtil.RTrim( Locationdescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionclass", StringUtil.RTrim( Locationdescription_Captionclass));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionstyle", StringUtil.RTrim( Locationdescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTION_Captionposition", StringUtil.RTrim( Locationdescription_Captionposition));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Objectcall", StringUtil.RTrim( Combo_locationcountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Cls", StringUtil.RTrim( Combo_locationcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_locationcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_locationcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_locationcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_locationcountry_Htmltemplate));
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
         GXEncryptionTmp = "trn_location.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7LocationId.ToString()) + "," + UrlEncode(AV8OrganisationId.ToString());
         return formatLink("trn_location.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Location" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location", "") ;
      }

      protected void InitializeNonKey046( )
      {
         A359LocationCountry = "";
         AssignAttri("", false, "A359LocationCountry", A359LocationCountry);
         A383LocationPhoneCode = "";
         AssignAttri("", false, "A383LocationPhoneCode", A383LocationPhoneCode);
         A35LocationPhone = "";
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         A339LocationZipCode = "";
         AssignAttri("", false, "A339LocationZipCode", A339LocationZipCode);
         A31LocationName = "";
         AssignAttri("", false, "A31LocationName", A31LocationName);
         A506LocationImage = "";
         AssignAttri("", false, "A506LocationImage", A506LocationImage);
         AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
         AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
         A40000LocationImage_GXI = "";
         AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A506LocationImage))), true);
         AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A506LocationImage), true);
         A338LocationCity = "";
         AssignAttri("", false, "A338LocationCity", A338LocationCity);
         A340LocationAddressLine1 = "";
         AssignAttri("", false, "A340LocationAddressLine1", A340LocationAddressLine1);
         A341LocationAddressLine2 = "";
         AssignAttri("", false, "A341LocationAddressLine2", A341LocationAddressLine2);
         A34LocationEmail = "";
         AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
         A384LocationPhoneNumber = "";
         AssignAttri("", false, "A384LocationPhoneNumber", A384LocationPhoneNumber);
         A36LocationDescription = "";
         AssignAttri("", false, "A36LocationDescription", A36LocationDescription);
         A594LocationBrandTheme = "";
         n594LocationBrandTheme = false;
         AssignAttri("", false, "A594LocationBrandTheme", A594LocationBrandTheme);
         A595LocationCtaTheme = "";
         n595LocationCtaTheme = false;
         AssignAttri("", false, "A595LocationCtaTheme", A595LocationCtaTheme);
         A518ToolBoxDefaultProfileImage = "";
         n518ToolBoxDefaultProfileImage = false;
         AssignAttri("", false, "A518ToolBoxDefaultProfileImage", A518ToolBoxDefaultProfileImage);
         A517ToolBoxDefaultLogo = "";
         n517ToolBoxDefaultLogo = false;
         AssignAttri("", false, "A517ToolBoxDefaultLogo", A517ToolBoxDefaultLogo);
         A40001ReceptionImage_GXI = "";
         n40001ReceptionImage_GXI = false;
         AssignAttri("", false, "A40001ReceptionImage_GXI", A40001ReceptionImage_GXI);
         A247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         A596LocationHasMyCare = false;
         AssignAttri("", false, "A596LocationHasMyCare", A596LocationHasMyCare);
         A597LocationHasMyServices = false;
         AssignAttri("", false, "A597LocationHasMyServices", A597LocationHasMyServices);
         A598LocationHasMyLiving = false;
         AssignAttri("", false, "A598LocationHasMyLiving", A598LocationHasMyLiving);
         A599LocationHasOwnBrand = false;
         AssignAttri("", false, "A599LocationHasOwnBrand", A599LocationHasOwnBrand);
         A600ReceptionImage = AV30ReceptionImageVar;
         n600ReceptionImage = false;
         AssignAttri("", false, "A600ReceptionImage", A600ReceptionImage);
         A601ReceptionDescription = AV31ReceptionDescriptionVar;
         n601ReceptionDescription = false;
         AssignAttri("", false, "A601ReceptionDescription", A601ReceptionDescription);
         Z359LocationCountry = "";
         Z383LocationPhoneCode = "";
         Z35LocationPhone = "";
         Z339LocationZipCode = "";
         Z31LocationName = "";
         Z338LocationCity = "";
         Z340LocationAddressLine1 = "";
         Z341LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z384LocationPhoneNumber = "";
         Z596LocationHasMyCare = false;
         Z597LocationHasMyServices = false;
         Z598LocationHasMyLiving = false;
         Z599LocationHasOwnBrand = false;
         Z518ToolBoxDefaultProfileImage = "";
         Z517ToolBoxDefaultLogo = "";
         Z601ReceptionDescription = "";
         Z247Trn_ThemeId = Guid.Empty;
      }

      protected void InitAll046( )
      {
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A599LocationHasOwnBrand = i599LocationHasOwnBrand;
         AssignAttri("", false, "A599LocationHasOwnBrand", A599LocationHasOwnBrand);
         A598LocationHasMyLiving = i598LocationHasMyLiving;
         AssignAttri("", false, "A598LocationHasMyLiving", A598LocationHasMyLiving);
         A597LocationHasMyServices = i597LocationHasMyServices;
         AssignAttri("", false, "A597LocationHasMyServices", A597LocationHasMyServices);
         A596LocationHasMyCare = i596LocationHasMyCare;
         AssignAttri("", false, "A596LocationHasMyCare", A596LocationHasMyCare);
         A601ReceptionDescription = i601ReceptionDescription;
         n601ReceptionDescription = false;
         AssignAttri("", false, "A601ReceptionDescription", A601ReceptionDescription);
         A600ReceptionImage = i600ReceptionImage;
         n600ReceptionImage = false;
         AssignAttri("", false, "A600ReceptionImage", A600ReceptionImage);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202532113412597", true, true);
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
         context.AddJavascriptSource("trn_location.js", "?202532113412599", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtLocationName_Internalname = "LOCATIONNAME";
         edtLocationEmail_Internalname = "LOCATIONEMAIL";
         lblPhone_Internalname = "PHONE";
         Combo_locationphonecode_Internalname = "COMBO_LOCATIONPHONECODE";
         edtLocationPhoneCode_Internalname = "LOCATIONPHONECODE";
         divUnnamedtablelocationphonecode_Internalname = "UNNAMEDTABLELOCATIONPHONECODE";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         edtLocationPhoneNumber_Internalname = "LOCATIONPHONENUMBER";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         edtLocationPhone_Internalname = "LOCATIONPHONE";
         divLocationphone_cell_Internalname = "LOCATIONPHONE_CELL";
         imgLocationImage_Internalname = "LOCATIONIMAGE";
         Locationdescription_Internalname = "LOCATIONDESCRIPTION";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtLocationAddressLine1_Internalname = "LOCATIONADDRESSLINE1";
         edtLocationAddressLine2_Internalname = "LOCATIONADDRESSLINE2";
         edtLocationZipCode_Internalname = "LOCATIONZIPCODE";
         edtLocationCity_Internalname = "LOCATIONCITY";
         lblTextblocklocationcountry_Internalname = "TEXTBLOCKLOCATIONCOUNTRY";
         Combo_locationcountry_Internalname = "COMBO_LOCATIONCOUNTRY";
         edtLocationCountry_Internalname = "LOCATIONCOUNTRY";
         divTablesplittedlocationcountry_Internalname = "TABLESPLITTEDLOCATIONCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         bttBtnudelete_Internalname = "BTNUDELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombolocationphonecode_Internalname = "vCOMBOLOCATIONPHONECODE";
         divSectionattribute_locationphonecode_Internalname = "SECTIONATTRIBUTE_LOCATIONPHONECODE";
         edtavCombolocationcountry_Internalname = "vCOMBOLOCATIONCOUNTRY";
         divSectionattribute_locationcountry_Internalname = "SECTIONATTRIBUTE_LOCATIONCOUNTRY";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
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
         Form.Caption = context.GetMessage( "Location", "");
         Combo_locationphonecode_Htmltemplate = "";
         Combo_locationcountry_Htmltemplate = "";
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         edtavCombolocationcountry_Jsonclick = "";
         edtavCombolocationcountry_Enabled = 0;
         edtavCombolocationcountry_Visible = 1;
         edtavCombolocationphonecode_Jsonclick = "";
         edtavCombolocationphonecode_Enabled = 0;
         edtavCombolocationphonecode_Visible = 1;
         bttBtnudelete_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLocationCountry_Jsonclick = "";
         edtLocationCountry_Enabled = 1;
         edtLocationCountry_Visible = 1;
         Combo_locationcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_locationcountry_Caption = "";
         Combo_locationcountry_Enabled = Convert.ToBoolean( -1);
         edtLocationCity_Jsonclick = "";
         edtLocationCity_Enabled = 1;
         edtLocationZipCode_Jsonclick = "";
         edtLocationZipCode_Enabled = 1;
         edtLocationAddressLine2_Jsonclick = "";
         edtLocationAddressLine2_Enabled = 1;
         edtLocationAddressLine1_Jsonclick = "";
         edtLocationAddressLine1_Enabled = 1;
         Locationdescription_Captionposition = "Left";
         Locationdescription_Captionstyle = "";
         Locationdescription_Captionclass = "col-sm-4 AttributeLabel";
         Locationdescription_Customconfiguration = "myconfig.js";
         Locationdescription_Customtoolbar = "myToolbar";
         Locationdescription_Toolbar = "Custom";
         Locationdescription_Height = "250";
         Locationdescription_Width = "100%";
         Locationdescription_Enabled = Convert.ToBoolean( 1);
         imgLocationImage_Enabled = 1;
         edtLocationPhone_Jsonclick = "";
         edtLocationPhone_Enabled = 1;
         edtLocationPhone_Visible = 1;
         divLocationphone_cell_Class = "col-xs-12";
         edtLocationPhoneNumber_Jsonclick = "";
         edtLocationPhoneNumber_Enabled = 1;
         edtLocationPhoneCode_Jsonclick = "";
         edtLocationPhoneCode_Enabled = 1;
         edtLocationPhoneCode_Visible = 1;
         Combo_locationphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationphonecode_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_locationphonecode_Caption = "";
         Combo_locationphonecode_Enabled = Convert.ToBoolean( -1);
         divUnnamedtable5_Visible = 1;
         edtLocationEmail_Jsonclick = "";
         edtLocationEmail_Enabled = 1;
         edtLocationName_Jsonclick = "";
         edtLocationName_Enabled = 1;
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

      protected void GX10ASATRN_THEMEID046( Guid AV25Insert_Trn_ThemeId ,
                                            Guid A247Trn_ThemeId ,
                                            short Gx_BScreen )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV25Insert_Trn_ThemeId) )
         {
            A247Trn_ThemeId = AV25Insert_Trn_ThemeId;
            n247Trn_ThemeId = false;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         else
         {
            if ( (Guid.Empty==A247Trn_ThemeId) )
            {
               A247Trn_ThemeId = Guid.Empty;
               n247Trn_ThemeId = false;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               n247Trn_ThemeId = true;
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            }
            else
            {
               if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
               {
                  GXt_guid4 = A247Trn_ThemeId;
                  new prc_getdefaulttheme(context ).execute( out  GXt_guid4) ;
                  A247Trn_ThemeId = GXt_guid4;
                  n247Trn_ThemeId = false;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               }
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A247Trn_ThemeId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX17ASALOCATIONPHONE046( string A383LocationPhoneCode ,
                                              string A384LocationPhoneNumber )
      {
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A35LocationPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_30_046( Guid A29LocationId )
      {
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
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
         n11OrganisationId = false;
         /* Using cursor T000425 */
         pr_default.execute(23, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Locationphonenumber( )
      {
         GXt_char2 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A383LocationPhoneCode,  A384LocationPhoneNumber, out  GXt_char2) ;
         A35LocationPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A384LocationPhoneNumber)) && ! GxRegex.IsMatch(A384LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "LOCATIONPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtLocationPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A35LocationPhone", StringUtil.RTrim( A35LocationPhone));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV8OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A596LocationHasMyCare","fld":"LOCATIONHASMYCARE"},{"av":"A597LocationHasMyServices","fld":"LOCATIONHASMYSERVICES"},{"av":"A598LocationHasMyLiving","fld":"LOCATIONHASMYLIVING"},{"av":"A599LocationHasOwnBrand","fld":"LOCATIONHASOWNBRAND"},{"av":"A518ToolBoxDefaultProfileImage","fld":"TOOLBOXDEFAULTPROFILEIMAGE"},{"av":"A517ToolBoxDefaultLogo","fld":"TOOLBOXDEFAULTLOGO"},{"av":"A601ReceptionDescription","fld":"RECEPTIONDESCRIPTION"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("'DOUDELETE'","""{"handler":"E13042","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV28isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV29Message","fld":"vMESSAGE"}]""");
         setEventMetadata("'DOUDELETE'",""","oparms":[{"av":"AV29Message","fld":"vMESSAGE"},{"av":"AV28isSuccessful","fld":"vISSUCCESSFUL"}]}""");
         setEventMetadata("VALID_LOCATIONEMAIL","""{"handler":"Valid_Locationemail","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONPHONECODE","""{"handler":"Valid_Locationphonecode","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONPHONENUMBER","""{"handler":"Valid_Locationphonenumber","iparms":[{"av":"A383LocationPhoneCode","fld":"LOCATIONPHONECODE"},{"av":"A384LocationPhoneNumber","fld":"LOCATIONPHONENUMBER"},{"av":"A35LocationPhone","fld":"LOCATIONPHONE"}]""");
         setEventMetadata("VALID_LOCATIONPHONENUMBER",""","oparms":[{"av":"A35LocationPhone","fld":"LOCATIONPHONE"}]}""");
         setEventMetadata("VALID_LOCATIONZIPCODE","""{"handler":"Valid_Locationzipcode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONPHONECODE","""{"handler":"Validv_Combolocationphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONCOUNTRY","""{"handler":"Validv_Combolocationcountry","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
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
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7LocationId = Guid.Empty;
         wcpOAV8OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z359LocationCountry = "";
         Z383LocationPhoneCode = "";
         Z35LocationPhone = "";
         Z339LocationZipCode = "";
         Z31LocationName = "";
         Z338LocationCity = "";
         Z340LocationAddressLine1 = "";
         Z341LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z384LocationPhoneNumber = "";
         Z518ToolBoxDefaultProfileImage = "";
         Z517ToolBoxDefaultLogo = "";
         Z601ReceptionDescription = "";
         Z247Trn_ThemeId = Guid.Empty;
         N247Trn_ThemeId = Guid.Empty;
         Combo_locationcountry_Selectedvalue_get = "";
         Combo_locationphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         AV25Insert_Trn_ThemeId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         A383LocationPhoneCode = "";
         A384LocationPhoneNumber = "";
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
         A31LocationName = "";
         A34LocationEmail = "";
         lblPhone_Jsonclick = "";
         ucCombo_locationphonecode = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21LocationPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A35LocationPhone = "";
         A506LocationImage = "";
         A40000LocationImage_GXI = "";
         sImgUrl = "";
         ucLocationdescription = new GXUserControl();
         LocationDescription = "";
         A340LocationAddressLine1 = "";
         A341LocationAddressLine2 = "";
         A339LocationZipCode = "";
         A338LocationCity = "";
         lblTextblocklocationcountry_Jsonclick = "";
         ucCombo_locationcountry = new GXUserControl();
         AV22LocationCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A359LocationCountry = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         bttBtnudelete_Jsonclick = "";
         AV16ComboLocationPhoneCode = "";
         AV23ComboLocationCountry = "";
         A518ToolBoxDefaultProfileImage = "";
         A517ToolBoxDefaultLogo = "";
         A601ReceptionDescription = "";
         AV31ReceptionDescriptionVar = "";
         AV30ReceptionImageVar = "";
         A600ReceptionImage = "";
         A36LocationDescription = "";
         A594LocationBrandTheme = "";
         A595LocationCtaTheme = "";
         A40001ReceptionImage_GXI = "";
         AV34Pgmname = "";
         Combo_locationphonecode_Objectcall = "";
         Combo_locationphonecode_Class = "";
         Combo_locationphonecode_Icontype = "";
         Combo_locationphonecode_Icon = "";
         Combo_locationphonecode_Tooltip = "";
         Combo_locationphonecode_Selectedvalue_set = "";
         Combo_locationphonecode_Selectedtext_set = "";
         Combo_locationphonecode_Selectedtext_get = "";
         Combo_locationphonecode_Gamoauthtoken = "";
         Combo_locationphonecode_Ddointernalname = "";
         Combo_locationphonecode_Titlecontrolalign = "";
         Combo_locationphonecode_Dropdownoptionstype = "";
         Combo_locationphonecode_Titlecontrolidtoreplace = "";
         Combo_locationphonecode_Datalisttype = "";
         Combo_locationphonecode_Datalistfixedvalues = "";
         Combo_locationphonecode_Datalistproc = "";
         Combo_locationphonecode_Datalistprocparametersprefix = "";
         Combo_locationphonecode_Remoteservicesparameters = "";
         Combo_locationphonecode_Multiplevaluestype = "";
         Combo_locationphonecode_Loadingdata = "";
         Combo_locationphonecode_Noresultsfound = "";
         Combo_locationphonecode_Emptyitemtext = "";
         Combo_locationphonecode_Onlyselectedvalues = "";
         Combo_locationphonecode_Selectalltext = "";
         Combo_locationphonecode_Multiplevaluesseparator = "";
         Combo_locationphonecode_Addnewoptiontext = "";
         Locationdescription_Objectcall = "";
         Locationdescription_Class = "";
         Locationdescription_Skin = "";
         Locationdescription_Buttonpressedid = "";
         Locationdescription_Captionvalue = "";
         Locationdescription_Coltitle = "";
         Locationdescription_Coltitlefont = "";
         Combo_locationcountry_Objectcall = "";
         Combo_locationcountry_Class = "";
         Combo_locationcountry_Icontype = "";
         Combo_locationcountry_Icon = "";
         Combo_locationcountry_Tooltip = "";
         Combo_locationcountry_Selectedvalue_set = "";
         Combo_locationcountry_Selectedtext_set = "";
         Combo_locationcountry_Selectedtext_get = "";
         Combo_locationcountry_Gamoauthtoken = "";
         Combo_locationcountry_Ddointernalname = "";
         Combo_locationcountry_Titlecontrolalign = "";
         Combo_locationcountry_Dropdownoptionstype = "";
         Combo_locationcountry_Titlecontrolidtoreplace = "";
         Combo_locationcountry_Datalisttype = "";
         Combo_locationcountry_Datalistfixedvalues = "";
         Combo_locationcountry_Datalistproc = "";
         Combo_locationcountry_Datalistprocparametersprefix = "";
         Combo_locationcountry_Remoteservicesparameters = "";
         Combo_locationcountry_Multiplevaluestype = "";
         Combo_locationcountry_Loadingdata = "";
         Combo_locationcountry_Noresultsfound = "";
         Combo_locationcountry_Emptyitemtext = "";
         Combo_locationcountry_Onlyselectedvalues = "";
         Combo_locationcountry_Selectalltext = "";
         Combo_locationcountry_Multiplevaluesseparator = "";
         Combo_locationcountry_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         imgReceptionimagevar_gximage = "";
         imgReceptionimagevar_Internalname = "";
         AV33Receptionimagevar_GXI = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV26TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20defaultCountryPhoneCode = "";
         AV29Message = "";
         AV18ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z506LocationImage = "";
         Z40000LocationImage_GXI = "";
         Z36LocationDescription = "";
         Z594LocationBrandTheme = "";
         Z595LocationCtaTheme = "";
         Z600ReceptionImage = "";
         Z40001ReceptionImage_GXI = "";
         T00046_A29LocationId = new Guid[] {Guid.Empty} ;
         T00046_n29LocationId = new bool[] {false} ;
         T00046_A359LocationCountry = new string[] {""} ;
         T00046_A383LocationPhoneCode = new string[] {""} ;
         T00046_A35LocationPhone = new string[] {""} ;
         T00046_A339LocationZipCode = new string[] {""} ;
         T00046_A31LocationName = new string[] {""} ;
         T00046_A40000LocationImage_GXI = new string[] {""} ;
         T00046_A338LocationCity = new string[] {""} ;
         T00046_A340LocationAddressLine1 = new string[] {""} ;
         T00046_A341LocationAddressLine2 = new string[] {""} ;
         T00046_A34LocationEmail = new string[] {""} ;
         T00046_A384LocationPhoneNumber = new string[] {""} ;
         T00046_A36LocationDescription = new string[] {""} ;
         T00046_A594LocationBrandTheme = new string[] {""} ;
         T00046_n594LocationBrandTheme = new bool[] {false} ;
         T00046_A595LocationCtaTheme = new string[] {""} ;
         T00046_n595LocationCtaTheme = new bool[] {false} ;
         T00046_A596LocationHasMyCare = new bool[] {false} ;
         T00046_A597LocationHasMyServices = new bool[] {false} ;
         T00046_A598LocationHasMyLiving = new bool[] {false} ;
         T00046_A599LocationHasOwnBrand = new bool[] {false} ;
         T00046_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         T00046_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00046_A517ToolBoxDefaultLogo = new string[] {""} ;
         T00046_n517ToolBoxDefaultLogo = new bool[] {false} ;
         T00046_A40001ReceptionImage_GXI = new string[] {""} ;
         T00046_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00046_A601ReceptionDescription = new string[] {""} ;
         T00046_n601ReceptionDescription = new bool[] {false} ;
         T00046_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00046_n11OrganisationId = new bool[] {false} ;
         T00046_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00046_n247Trn_ThemeId = new bool[] {false} ;
         T00046_A506LocationImage = new string[] {""} ;
         T00046_A600ReceptionImage = new string[] {""} ;
         T00046_n600ReceptionImage = new bool[] {false} ;
         T00044_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00044_n11OrganisationId = new bool[] {false} ;
         T00045_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00045_n247Trn_ThemeId = new bool[] {false} ;
         T00047_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00047_n11OrganisationId = new bool[] {false} ;
         T00048_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00048_n247Trn_ThemeId = new bool[] {false} ;
         T00049_A29LocationId = new Guid[] {Guid.Empty} ;
         T00049_n29LocationId = new bool[] {false} ;
         T00049_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00049_n11OrganisationId = new bool[] {false} ;
         T00043_A29LocationId = new Guid[] {Guid.Empty} ;
         T00043_n29LocationId = new bool[] {false} ;
         T00043_A359LocationCountry = new string[] {""} ;
         T00043_A383LocationPhoneCode = new string[] {""} ;
         T00043_A35LocationPhone = new string[] {""} ;
         T00043_A339LocationZipCode = new string[] {""} ;
         T00043_A31LocationName = new string[] {""} ;
         T00043_A40000LocationImage_GXI = new string[] {""} ;
         T00043_A338LocationCity = new string[] {""} ;
         T00043_A340LocationAddressLine1 = new string[] {""} ;
         T00043_A341LocationAddressLine2 = new string[] {""} ;
         T00043_A34LocationEmail = new string[] {""} ;
         T00043_A384LocationPhoneNumber = new string[] {""} ;
         T00043_A36LocationDescription = new string[] {""} ;
         T00043_A594LocationBrandTheme = new string[] {""} ;
         T00043_n594LocationBrandTheme = new bool[] {false} ;
         T00043_A595LocationCtaTheme = new string[] {""} ;
         T00043_n595LocationCtaTheme = new bool[] {false} ;
         T00043_A596LocationHasMyCare = new bool[] {false} ;
         T00043_A597LocationHasMyServices = new bool[] {false} ;
         T00043_A598LocationHasMyLiving = new bool[] {false} ;
         T00043_A599LocationHasOwnBrand = new bool[] {false} ;
         T00043_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         T00043_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00043_A517ToolBoxDefaultLogo = new string[] {""} ;
         T00043_n517ToolBoxDefaultLogo = new bool[] {false} ;
         T00043_A40001ReceptionImage_GXI = new string[] {""} ;
         T00043_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00043_A601ReceptionDescription = new string[] {""} ;
         T00043_n601ReceptionDescription = new bool[] {false} ;
         T00043_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00043_n11OrganisationId = new bool[] {false} ;
         T00043_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00043_n247Trn_ThemeId = new bool[] {false} ;
         T00043_A506LocationImage = new string[] {""} ;
         T00043_A600ReceptionImage = new string[] {""} ;
         T00043_n600ReceptionImage = new bool[] {false} ;
         T000410_A29LocationId = new Guid[] {Guid.Empty} ;
         T000410_n29LocationId = new bool[] {false} ;
         T000410_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000410_n11OrganisationId = new bool[] {false} ;
         T000411_A29LocationId = new Guid[] {Guid.Empty} ;
         T000411_n29LocationId = new bool[] {false} ;
         T000411_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000411_n11OrganisationId = new bool[] {false} ;
         T00042_A29LocationId = new Guid[] {Guid.Empty} ;
         T00042_n29LocationId = new bool[] {false} ;
         T00042_A359LocationCountry = new string[] {""} ;
         T00042_A383LocationPhoneCode = new string[] {""} ;
         T00042_A35LocationPhone = new string[] {""} ;
         T00042_A339LocationZipCode = new string[] {""} ;
         T00042_A31LocationName = new string[] {""} ;
         T00042_A40000LocationImage_GXI = new string[] {""} ;
         T00042_A338LocationCity = new string[] {""} ;
         T00042_A340LocationAddressLine1 = new string[] {""} ;
         T00042_A341LocationAddressLine2 = new string[] {""} ;
         T00042_A34LocationEmail = new string[] {""} ;
         T00042_A384LocationPhoneNumber = new string[] {""} ;
         T00042_A36LocationDescription = new string[] {""} ;
         T00042_A594LocationBrandTheme = new string[] {""} ;
         T00042_n594LocationBrandTheme = new bool[] {false} ;
         T00042_A595LocationCtaTheme = new string[] {""} ;
         T00042_n595LocationCtaTheme = new bool[] {false} ;
         T00042_A596LocationHasMyCare = new bool[] {false} ;
         T00042_A597LocationHasMyServices = new bool[] {false} ;
         T00042_A598LocationHasMyLiving = new bool[] {false} ;
         T00042_A599LocationHasOwnBrand = new bool[] {false} ;
         T00042_A518ToolBoxDefaultProfileImage = new string[] {""} ;
         T00042_n518ToolBoxDefaultProfileImage = new bool[] {false} ;
         T00042_A517ToolBoxDefaultLogo = new string[] {""} ;
         T00042_n517ToolBoxDefaultLogo = new bool[] {false} ;
         T00042_A40001ReceptionImage_GXI = new string[] {""} ;
         T00042_n40001ReceptionImage_GXI = new bool[] {false} ;
         T00042_A601ReceptionDescription = new string[] {""} ;
         T00042_n601ReceptionDescription = new bool[] {false} ;
         T00042_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00042_n11OrganisationId = new bool[] {false} ;
         T00042_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T00042_n247Trn_ThemeId = new bool[] {false} ;
         T00042_A506LocationImage = new string[] {""} ;
         T00042_A600ReceptionImage = new string[] {""} ;
         T00042_n600ReceptionImage = new bool[] {false} ;
         T000417_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         T000418_A543AppVersionId = new Guid[] {Guid.Empty} ;
         T000419_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T000420_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T000420_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000420_n11OrganisationId = new bool[] {false} ;
         T000420_A29LocationId = new Guid[] {Guid.Empty} ;
         T000420_n29LocationId = new bool[] {false} ;
         T000421_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000421_A29LocationId = new Guid[] {Guid.Empty} ;
         T000421_n29LocationId = new bool[] {false} ;
         T000421_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000421_n11OrganisationId = new bool[] {false} ;
         T000422_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000422_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000422_n11OrganisationId = new bool[] {false} ;
         T000422_A29LocationId = new Guid[] {Guid.Empty} ;
         T000422_n29LocationId = new bool[] {false} ;
         T000423_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000423_A29LocationId = new Guid[] {Guid.Empty} ;
         T000423_n29LocationId = new bool[] {false} ;
         T000423_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000423_n11OrganisationId = new bool[] {false} ;
         T000424_A29LocationId = new Guid[] {Guid.Empty} ;
         T000424_n29LocationId = new bool[] {false} ;
         T000424_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000424_n11OrganisationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i601ReceptionDescription = "";
         i600ReceptionImage = "";
         GXt_guid4 = Guid.Empty;
         T000425_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000425_n11OrganisationId = new bool[] {false} ;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_location__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_location__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_location__default(),
            new Object[][] {
                new Object[] {
               T00042_A29LocationId, T00042_A359LocationCountry, T00042_A383LocationPhoneCode, T00042_A35LocationPhone, T00042_A339LocationZipCode, T00042_A31LocationName, T00042_A40000LocationImage_GXI, T00042_A338LocationCity, T00042_A340LocationAddressLine1, T00042_A341LocationAddressLine2,
               T00042_A34LocationEmail, T00042_A384LocationPhoneNumber, T00042_A36LocationDescription, T00042_A594LocationBrandTheme, T00042_n594LocationBrandTheme, T00042_A595LocationCtaTheme, T00042_n595LocationCtaTheme, T00042_A596LocationHasMyCare, T00042_A597LocationHasMyServices, T00042_A598LocationHasMyLiving,
               T00042_A599LocationHasOwnBrand, T00042_A518ToolBoxDefaultProfileImage, T00042_n518ToolBoxDefaultProfileImage, T00042_A517ToolBoxDefaultLogo, T00042_n517ToolBoxDefaultLogo, T00042_A40001ReceptionImage_GXI, T00042_n40001ReceptionImage_GXI, T00042_A601ReceptionDescription, T00042_n601ReceptionDescription, T00042_A11OrganisationId,
               T00042_A247Trn_ThemeId, T00042_n247Trn_ThemeId, T00042_A506LocationImage, T00042_A600ReceptionImage, T00042_n600ReceptionImage
               }
               , new Object[] {
               T00043_A29LocationId, T00043_A359LocationCountry, T00043_A383LocationPhoneCode, T00043_A35LocationPhone, T00043_A339LocationZipCode, T00043_A31LocationName, T00043_A40000LocationImage_GXI, T00043_A338LocationCity, T00043_A340LocationAddressLine1, T00043_A341LocationAddressLine2,
               T00043_A34LocationEmail, T00043_A384LocationPhoneNumber, T00043_A36LocationDescription, T00043_A594LocationBrandTheme, T00043_n594LocationBrandTheme, T00043_A595LocationCtaTheme, T00043_n595LocationCtaTheme, T00043_A596LocationHasMyCare, T00043_A597LocationHasMyServices, T00043_A598LocationHasMyLiving,
               T00043_A599LocationHasOwnBrand, T00043_A518ToolBoxDefaultProfileImage, T00043_n518ToolBoxDefaultProfileImage, T00043_A517ToolBoxDefaultLogo, T00043_n517ToolBoxDefaultLogo, T00043_A40001ReceptionImage_GXI, T00043_n40001ReceptionImage_GXI, T00043_A601ReceptionDescription, T00043_n601ReceptionDescription, T00043_A11OrganisationId,
               T00043_A247Trn_ThemeId, T00043_n247Trn_ThemeId, T00043_A506LocationImage, T00043_A600ReceptionImage, T00043_n600ReceptionImage
               }
               , new Object[] {
               T00044_A11OrganisationId
               }
               , new Object[] {
               T00045_A247Trn_ThemeId
               }
               , new Object[] {
               T00046_A29LocationId, T00046_A359LocationCountry, T00046_A383LocationPhoneCode, T00046_A35LocationPhone, T00046_A339LocationZipCode, T00046_A31LocationName, T00046_A40000LocationImage_GXI, T00046_A338LocationCity, T00046_A340LocationAddressLine1, T00046_A341LocationAddressLine2,
               T00046_A34LocationEmail, T00046_A384LocationPhoneNumber, T00046_A36LocationDescription, T00046_A594LocationBrandTheme, T00046_n594LocationBrandTheme, T00046_A595LocationCtaTheme, T00046_n595LocationCtaTheme, T00046_A596LocationHasMyCare, T00046_A597LocationHasMyServices, T00046_A598LocationHasMyLiving,
               T00046_A599LocationHasOwnBrand, T00046_A518ToolBoxDefaultProfileImage, T00046_n518ToolBoxDefaultProfileImage, T00046_A517ToolBoxDefaultLogo, T00046_n517ToolBoxDefaultLogo, T00046_A40001ReceptionImage_GXI, T00046_n40001ReceptionImage_GXI, T00046_A601ReceptionDescription, T00046_n601ReceptionDescription, T00046_A11OrganisationId,
               T00046_A247Trn_ThemeId, T00046_n247Trn_ThemeId, T00046_A506LocationImage, T00046_A600ReceptionImage, T00046_n600ReceptionImage
               }
               , new Object[] {
               T00047_A11OrganisationId
               }
               , new Object[] {
               T00048_A247Trn_ThemeId
               }
               , new Object[] {
               T00049_A29LocationId, T00049_A11OrganisationId
               }
               , new Object[] {
               T000410_A29LocationId, T000410_A11OrganisationId
               }
               , new Object[] {
               T000411_A29LocationId, T000411_A11OrganisationId
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
               T000417_A554ResidentPackageId
               }
               , new Object[] {
               T000418_A543AppVersionId
               }
               , new Object[] {
               T000419_A303AgendaCalendarId
               }
               , new Object[] {
               T000420_A395LocationDynamicFormId, T000420_A11OrganisationId, T000420_A29LocationId
               }
               , new Object[] {
               T000421_A58ProductServiceId, T000421_A29LocationId, T000421_A11OrganisationId
               }
               , new Object[] {
               T000422_A89ReceptionistId, T000422_A11OrganisationId, T000422_A29LocationId
               }
               , new Object[] {
               T000423_A62ResidentId, T000423_A29LocationId, T000423_A11OrganisationId
               }
               , new Object[] {
               T000424_A29LocationId, T000424_A11OrganisationId
               }
               , new Object[] {
               T000425_A11OrganisationId
               }
            }
         );
         Z599LocationHasOwnBrand = false;
         A599LocationHasOwnBrand = false;
         i599LocationHasOwnBrand = false;
         Z598LocationHasMyLiving = false;
         A598LocationHasMyLiving = false;
         i598LocationHasMyLiving = false;
         Z597LocationHasMyServices = false;
         A597LocationHasMyServices = false;
         i597LocationHasMyServices = false;
         Z596LocationHasMyCare = false;
         A596LocationHasMyCare = false;
         i596LocationHasMyCare = false;
         Z29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         AV34Pgmname = "Trn_Location";
         A600ReceptionImage = "";
         n600ReceptionImage = false;
         Z600ReceptionImage = "";
         n600ReceptionImage = false;
         i600ReceptionImage = "";
         n600ReceptionImage = false;
         Z601ReceptionDescription = "";
         n601ReceptionDescription = false;
         A601ReceptionDescription = "";
         n601ReceptionDescription = false;
         i601ReceptionDescription = "";
         n601ReceptionDescription = false;
         Z247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         N247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
         A247Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n247Trn_ThemeId = false;
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound6 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtLocationName_Enabled ;
      private int edtLocationEmail_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtLocationPhoneCode_Visible ;
      private int edtLocationPhoneCode_Enabled ;
      private int edtLocationPhoneNumber_Enabled ;
      private int edtLocationPhone_Visible ;
      private int edtLocationPhone_Enabled ;
      private int imgLocationImage_Enabled ;
      private int edtLocationAddressLine1_Enabled ;
      private int edtLocationAddressLine2_Enabled ;
      private int edtLocationZipCode_Enabled ;
      private int edtLocationCity_Enabled ;
      private int edtLocationCountry_Visible ;
      private int edtLocationCountry_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int bttBtnudelete_Visible ;
      private int edtavCombolocationphonecode_Visible ;
      private int edtavCombolocationphonecode_Enabled ;
      private int edtavCombolocationcountry_Visible ;
      private int edtavCombolocationcountry_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int Combo_locationphonecode_Datalistupdateminimumcharacters ;
      private int Combo_locationphonecode_Gxcontroltype ;
      private int Locationdescription_Color ;
      private int Locationdescription_Coltitlecolor ;
      private int Combo_locationcountry_Datalistupdateminimumcharacters ;
      private int Combo_locationcountry_Gxcontroltype ;
      private int AV35GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z35LocationPhone ;
      private string Combo_locationcountry_Selectedvalue_get ;
      private string Combo_locationphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLocationName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtLocationName_Jsonclick ;
      private string edtLocationEmail_Internalname ;
      private string edtLocationEmail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string divUnnamedtablelocationphonecode_Internalname ;
      private string Combo_locationphonecode_Caption ;
      private string Combo_locationphonecode_Cls ;
      private string Combo_locationphonecode_Internalname ;
      private string edtLocationPhoneCode_Internalname ;
      private string edtLocationPhoneCode_Jsonclick ;
      private string edtLocationPhoneNumber_Internalname ;
      private string edtLocationPhoneNumber_Jsonclick ;
      private string divLocationphone_cell_Internalname ;
      private string divLocationphone_cell_Class ;
      private string edtLocationPhone_Internalname ;
      private string gxphoneLink ;
      private string A35LocationPhone ;
      private string edtLocationPhone_Jsonclick ;
      private string imgLocationImage_Internalname ;
      private string sImgUrl ;
      private string Locationdescription_Internalname ;
      private string Locationdescription_Width ;
      private string Locationdescription_Height ;
      private string Locationdescription_Toolbar ;
      private string Locationdescription_Customtoolbar ;
      private string Locationdescription_Customconfiguration ;
      private string Locationdescription_Captionclass ;
      private string Locationdescription_Captionstyle ;
      private string Locationdescription_Captionposition ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtLocationAddressLine1_Internalname ;
      private string edtLocationAddressLine1_Jsonclick ;
      private string edtLocationAddressLine2_Internalname ;
      private string edtLocationAddressLine2_Jsonclick ;
      private string edtLocationZipCode_Internalname ;
      private string edtLocationZipCode_Jsonclick ;
      private string edtLocationCity_Internalname ;
      private string edtLocationCity_Jsonclick ;
      private string divTablesplittedlocationcountry_Internalname ;
      private string lblTextblocklocationcountry_Internalname ;
      private string lblTextblocklocationcountry_Jsonclick ;
      private string Combo_locationcountry_Caption ;
      private string Combo_locationcountry_Cls ;
      private string Combo_locationcountry_Internalname ;
      private string edtLocationCountry_Internalname ;
      private string edtLocationCountry_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string bttBtnudelete_Internalname ;
      private string bttBtnudelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_locationphonecode_Internalname ;
      private string edtavCombolocationphonecode_Internalname ;
      private string edtavCombolocationphonecode_Jsonclick ;
      private string divSectionattribute_locationcountry_Internalname ;
      private string edtavCombolocationcountry_Internalname ;
      private string edtavCombolocationcountry_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string AV34Pgmname ;
      private string Combo_locationphonecode_Objectcall ;
      private string Combo_locationphonecode_Class ;
      private string Combo_locationphonecode_Icontype ;
      private string Combo_locationphonecode_Icon ;
      private string Combo_locationphonecode_Tooltip ;
      private string Combo_locationphonecode_Selectedvalue_set ;
      private string Combo_locationphonecode_Selectedtext_set ;
      private string Combo_locationphonecode_Selectedtext_get ;
      private string Combo_locationphonecode_Gamoauthtoken ;
      private string Combo_locationphonecode_Ddointernalname ;
      private string Combo_locationphonecode_Titlecontrolalign ;
      private string Combo_locationphonecode_Dropdownoptionstype ;
      private string Combo_locationphonecode_Titlecontrolidtoreplace ;
      private string Combo_locationphonecode_Datalisttype ;
      private string Combo_locationphonecode_Datalistfixedvalues ;
      private string Combo_locationphonecode_Datalistproc ;
      private string Combo_locationphonecode_Datalistprocparametersprefix ;
      private string Combo_locationphonecode_Remoteservicesparameters ;
      private string Combo_locationphonecode_Htmltemplate ;
      private string Combo_locationphonecode_Multiplevaluestype ;
      private string Combo_locationphonecode_Loadingdata ;
      private string Combo_locationphonecode_Noresultsfound ;
      private string Combo_locationphonecode_Emptyitemtext ;
      private string Combo_locationphonecode_Onlyselectedvalues ;
      private string Combo_locationphonecode_Selectalltext ;
      private string Combo_locationphonecode_Multiplevaluesseparator ;
      private string Combo_locationphonecode_Addnewoptiontext ;
      private string Locationdescription_Objectcall ;
      private string Locationdescription_Class ;
      private string Locationdescription_Skin ;
      private string Locationdescription_Buttonpressedid ;
      private string Locationdescription_Captionvalue ;
      private string Locationdescription_Coltitle ;
      private string Locationdescription_Coltitlefont ;
      private string Combo_locationcountry_Objectcall ;
      private string Combo_locationcountry_Class ;
      private string Combo_locationcountry_Icontype ;
      private string Combo_locationcountry_Icon ;
      private string Combo_locationcountry_Tooltip ;
      private string Combo_locationcountry_Selectedvalue_set ;
      private string Combo_locationcountry_Selectedtext_set ;
      private string Combo_locationcountry_Selectedtext_get ;
      private string Combo_locationcountry_Gamoauthtoken ;
      private string Combo_locationcountry_Ddointernalname ;
      private string Combo_locationcountry_Titlecontrolalign ;
      private string Combo_locationcountry_Dropdownoptionstype ;
      private string Combo_locationcountry_Titlecontrolidtoreplace ;
      private string Combo_locationcountry_Datalisttype ;
      private string Combo_locationcountry_Datalistfixedvalues ;
      private string Combo_locationcountry_Datalistproc ;
      private string Combo_locationcountry_Datalistprocparametersprefix ;
      private string Combo_locationcountry_Remoteservicesparameters ;
      private string Combo_locationcountry_Htmltemplate ;
      private string Combo_locationcountry_Multiplevaluestype ;
      private string Combo_locationcountry_Loadingdata ;
      private string Combo_locationcountry_Noresultsfound ;
      private string Combo_locationcountry_Emptyitemtext ;
      private string Combo_locationcountry_Onlyselectedvalues ;
      private string Combo_locationcountry_Selectalltext ;
      private string Combo_locationcountry_Multiplevaluesseparator ;
      private string Combo_locationcountry_Addnewoptiontext ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string imgReceptionimagevar_gximage ;
      private string imgReceptionimagevar_Internalname ;
      private string AV29Message ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string GXt_char2 ;
      private bool Z596LocationHasMyCare ;
      private bool Z597LocationHasMyServices ;
      private bool Z598LocationHasMyLiving ;
      private bool Z599LocationHasOwnBrand ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29LocationId ;
      private bool n247Trn_ThemeId ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool Combo_locationphonecode_Emptyitem ;
      private bool A506LocationImage_IsBlob ;
      private bool Combo_locationcountry_Emptyitem ;
      private bool n518ToolBoxDefaultProfileImage ;
      private bool n517ToolBoxDefaultLogo ;
      private bool n601ReceptionDescription ;
      private bool A596LocationHasMyCare ;
      private bool A597LocationHasMyServices ;
      private bool A598LocationHasMyLiving ;
      private bool A599LocationHasOwnBrand ;
      private bool n600ReceptionImage ;
      private bool n594LocationBrandTheme ;
      private bool n595LocationCtaTheme ;
      private bool n40001ReceptionImage_GXI ;
      private bool Combo_locationphonecode_Enabled ;
      private bool Combo_locationphonecode_Visible ;
      private bool Combo_locationphonecode_Allowmultipleselection ;
      private bool Combo_locationphonecode_Isgriditem ;
      private bool Combo_locationphonecode_Hasdescription ;
      private bool Combo_locationphonecode_Includeonlyselectedoption ;
      private bool Combo_locationphonecode_Includeselectalloption ;
      private bool Combo_locationphonecode_Includeaddnewoption ;
      private bool Locationdescription_Enabled ;
      private bool Locationdescription_Toolbarcancollapse ;
      private bool Locationdescription_Toolbarexpanded ;
      private bool Locationdescription_Isabstractlayoutcontrol ;
      private bool Locationdescription_Usercontroliscolumn ;
      private bool Locationdescription_Visible ;
      private bool Combo_locationcountry_Enabled ;
      private bool Combo_locationcountry_Visible ;
      private bool Combo_locationcountry_Allowmultipleselection ;
      private bool Combo_locationcountry_Isgriditem ;
      private bool Combo_locationcountry_Hasdescription ;
      private bool Combo_locationcountry_Includeonlyselectedoption ;
      private bool Combo_locationcountry_Includeselectalloption ;
      private bool Combo_locationcountry_Includeaddnewoption ;
      private bool returnInSub ;
      private bool AV28isSuccessful ;
      private bool Gx_longc ;
      private bool i599LocationHasOwnBrand ;
      private bool i598LocationHasMyLiving ;
      private bool i597LocationHasMyServices ;
      private bool i596LocationHasMyCare ;
      private string LocationDescription ;
      private string A36LocationDescription ;
      private string A594LocationBrandTheme ;
      private string A595LocationCtaTheme ;
      private string Z36LocationDescription ;
      private string Z594LocationBrandTheme ;
      private string Z595LocationCtaTheme ;
      private string Z359LocationCountry ;
      private string Z383LocationPhoneCode ;
      private string Z339LocationZipCode ;
      private string Z31LocationName ;
      private string Z338LocationCity ;
      private string Z340LocationAddressLine1 ;
      private string Z341LocationAddressLine2 ;
      private string Z34LocationEmail ;
      private string Z384LocationPhoneNumber ;
      private string Z518ToolBoxDefaultProfileImage ;
      private string Z517ToolBoxDefaultLogo ;
      private string Z601ReceptionDescription ;
      private string A383LocationPhoneCode ;
      private string A384LocationPhoneNumber ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string A40000LocationImage_GXI ;
      private string A340LocationAddressLine1 ;
      private string A341LocationAddressLine2 ;
      private string A339LocationZipCode ;
      private string A338LocationCity ;
      private string A359LocationCountry ;
      private string AV16ComboLocationPhoneCode ;
      private string AV23ComboLocationCountry ;
      private string A518ToolBoxDefaultProfileImage ;
      private string A517ToolBoxDefaultLogo ;
      private string A601ReceptionDescription ;
      private string AV31ReceptionDescriptionVar ;
      private string A40001ReceptionImage_GXI ;
      private string AV33Receptionimagevar_GXI ;
      private string AV20defaultCountryPhoneCode ;
      private string AV18ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z40000LocationImage_GXI ;
      private string Z40001ReceptionImage_GXI ;
      private string i601ReceptionDescription ;
      private string A506LocationImage ;
      private string AV30ReceptionImageVar ;
      private string A600ReceptionImage ;
      private string Z506LocationImage ;
      private string Z600ReceptionImage ;
      private string i600ReceptionImage ;
      private Guid wcpOAV7LocationId ;
      private Guid wcpOAV8OrganisationId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z247Trn_ThemeId ;
      private Guid N247Trn_ThemeId ;
      private Guid A29LocationId ;
      private Guid AV25Insert_Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid AV7LocationId ;
      private Guid AV8OrganisationId ;
      private Guid GXt_guid4 ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_locationphonecode ;
      private GXUserControl ucLocationdescription ;
      private GXUserControl ucCombo_locationcountry ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21LocationPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22LocationCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV26TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00046_A29LocationId ;
      private bool[] T00046_n29LocationId ;
      private string[] T00046_A359LocationCountry ;
      private string[] T00046_A383LocationPhoneCode ;
      private string[] T00046_A35LocationPhone ;
      private string[] T00046_A339LocationZipCode ;
      private string[] T00046_A31LocationName ;
      private string[] T00046_A40000LocationImage_GXI ;
      private string[] T00046_A338LocationCity ;
      private string[] T00046_A340LocationAddressLine1 ;
      private string[] T00046_A341LocationAddressLine2 ;
      private string[] T00046_A34LocationEmail ;
      private string[] T00046_A384LocationPhoneNumber ;
      private string[] T00046_A36LocationDescription ;
      private string[] T00046_A594LocationBrandTheme ;
      private bool[] T00046_n594LocationBrandTheme ;
      private string[] T00046_A595LocationCtaTheme ;
      private bool[] T00046_n595LocationCtaTheme ;
      private bool[] T00046_A596LocationHasMyCare ;
      private bool[] T00046_A597LocationHasMyServices ;
      private bool[] T00046_A598LocationHasMyLiving ;
      private bool[] T00046_A599LocationHasOwnBrand ;
      private string[] T00046_A518ToolBoxDefaultProfileImage ;
      private bool[] T00046_n518ToolBoxDefaultProfileImage ;
      private string[] T00046_A517ToolBoxDefaultLogo ;
      private bool[] T00046_n517ToolBoxDefaultLogo ;
      private string[] T00046_A40001ReceptionImage_GXI ;
      private bool[] T00046_n40001ReceptionImage_GXI ;
      private string[] T00046_A601ReceptionDescription ;
      private bool[] T00046_n601ReceptionDescription ;
      private Guid[] T00046_A11OrganisationId ;
      private bool[] T00046_n11OrganisationId ;
      private Guid[] T00046_A247Trn_ThemeId ;
      private bool[] T00046_n247Trn_ThemeId ;
      private string[] T00046_A506LocationImage ;
      private string[] T00046_A600ReceptionImage ;
      private bool[] T00046_n600ReceptionImage ;
      private Guid[] T00044_A11OrganisationId ;
      private bool[] T00044_n11OrganisationId ;
      private Guid[] T00045_A247Trn_ThemeId ;
      private bool[] T00045_n247Trn_ThemeId ;
      private Guid[] T00047_A11OrganisationId ;
      private bool[] T00047_n11OrganisationId ;
      private Guid[] T00048_A247Trn_ThemeId ;
      private bool[] T00048_n247Trn_ThemeId ;
      private Guid[] T00049_A29LocationId ;
      private bool[] T00049_n29LocationId ;
      private Guid[] T00049_A11OrganisationId ;
      private bool[] T00049_n11OrganisationId ;
      private Guid[] T00043_A29LocationId ;
      private bool[] T00043_n29LocationId ;
      private string[] T00043_A359LocationCountry ;
      private string[] T00043_A383LocationPhoneCode ;
      private string[] T00043_A35LocationPhone ;
      private string[] T00043_A339LocationZipCode ;
      private string[] T00043_A31LocationName ;
      private string[] T00043_A40000LocationImage_GXI ;
      private string[] T00043_A338LocationCity ;
      private string[] T00043_A340LocationAddressLine1 ;
      private string[] T00043_A341LocationAddressLine2 ;
      private string[] T00043_A34LocationEmail ;
      private string[] T00043_A384LocationPhoneNumber ;
      private string[] T00043_A36LocationDescription ;
      private string[] T00043_A594LocationBrandTheme ;
      private bool[] T00043_n594LocationBrandTheme ;
      private string[] T00043_A595LocationCtaTheme ;
      private bool[] T00043_n595LocationCtaTheme ;
      private bool[] T00043_A596LocationHasMyCare ;
      private bool[] T00043_A597LocationHasMyServices ;
      private bool[] T00043_A598LocationHasMyLiving ;
      private bool[] T00043_A599LocationHasOwnBrand ;
      private string[] T00043_A518ToolBoxDefaultProfileImage ;
      private bool[] T00043_n518ToolBoxDefaultProfileImage ;
      private string[] T00043_A517ToolBoxDefaultLogo ;
      private bool[] T00043_n517ToolBoxDefaultLogo ;
      private string[] T00043_A40001ReceptionImage_GXI ;
      private bool[] T00043_n40001ReceptionImage_GXI ;
      private string[] T00043_A601ReceptionDescription ;
      private bool[] T00043_n601ReceptionDescription ;
      private Guid[] T00043_A11OrganisationId ;
      private bool[] T00043_n11OrganisationId ;
      private Guid[] T00043_A247Trn_ThemeId ;
      private bool[] T00043_n247Trn_ThemeId ;
      private string[] T00043_A506LocationImage ;
      private string[] T00043_A600ReceptionImage ;
      private bool[] T00043_n600ReceptionImage ;
      private Guid[] T000410_A29LocationId ;
      private bool[] T000410_n29LocationId ;
      private Guid[] T000410_A11OrganisationId ;
      private bool[] T000410_n11OrganisationId ;
      private Guid[] T000411_A29LocationId ;
      private bool[] T000411_n29LocationId ;
      private Guid[] T000411_A11OrganisationId ;
      private bool[] T000411_n11OrganisationId ;
      private Guid[] T00042_A29LocationId ;
      private bool[] T00042_n29LocationId ;
      private string[] T00042_A359LocationCountry ;
      private string[] T00042_A383LocationPhoneCode ;
      private string[] T00042_A35LocationPhone ;
      private string[] T00042_A339LocationZipCode ;
      private string[] T00042_A31LocationName ;
      private string[] T00042_A40000LocationImage_GXI ;
      private string[] T00042_A338LocationCity ;
      private string[] T00042_A340LocationAddressLine1 ;
      private string[] T00042_A341LocationAddressLine2 ;
      private string[] T00042_A34LocationEmail ;
      private string[] T00042_A384LocationPhoneNumber ;
      private string[] T00042_A36LocationDescription ;
      private string[] T00042_A594LocationBrandTheme ;
      private bool[] T00042_n594LocationBrandTheme ;
      private string[] T00042_A595LocationCtaTheme ;
      private bool[] T00042_n595LocationCtaTheme ;
      private bool[] T00042_A596LocationHasMyCare ;
      private bool[] T00042_A597LocationHasMyServices ;
      private bool[] T00042_A598LocationHasMyLiving ;
      private bool[] T00042_A599LocationHasOwnBrand ;
      private string[] T00042_A518ToolBoxDefaultProfileImage ;
      private bool[] T00042_n518ToolBoxDefaultProfileImage ;
      private string[] T00042_A517ToolBoxDefaultLogo ;
      private bool[] T00042_n517ToolBoxDefaultLogo ;
      private string[] T00042_A40001ReceptionImage_GXI ;
      private bool[] T00042_n40001ReceptionImage_GXI ;
      private string[] T00042_A601ReceptionDescription ;
      private bool[] T00042_n601ReceptionDescription ;
      private Guid[] T00042_A11OrganisationId ;
      private bool[] T00042_n11OrganisationId ;
      private Guid[] T00042_A247Trn_ThemeId ;
      private bool[] T00042_n247Trn_ThemeId ;
      private string[] T00042_A506LocationImage ;
      private string[] T00042_A600ReceptionImage ;
      private bool[] T00042_n600ReceptionImage ;
      private Guid[] T000417_A554ResidentPackageId ;
      private Guid[] T000418_A543AppVersionId ;
      private Guid[] T000419_A303AgendaCalendarId ;
      private Guid[] T000420_A395LocationDynamicFormId ;
      private Guid[] T000420_A11OrganisationId ;
      private bool[] T000420_n11OrganisationId ;
      private Guid[] T000420_A29LocationId ;
      private bool[] T000420_n29LocationId ;
      private Guid[] T000421_A58ProductServiceId ;
      private Guid[] T000421_A29LocationId ;
      private bool[] T000421_n29LocationId ;
      private Guid[] T000421_A11OrganisationId ;
      private bool[] T000421_n11OrganisationId ;
      private Guid[] T000422_A89ReceptionistId ;
      private Guid[] T000422_A11OrganisationId ;
      private bool[] T000422_n11OrganisationId ;
      private Guid[] T000422_A29LocationId ;
      private bool[] T000422_n29LocationId ;
      private Guid[] T000423_A62ResidentId ;
      private Guid[] T000423_A29LocationId ;
      private bool[] T000423_n29LocationId ;
      private Guid[] T000423_A11OrganisationId ;
      private bool[] T000423_n11OrganisationId ;
      private Guid[] T000424_A29LocationId ;
      private bool[] T000424_n29LocationId ;
      private Guid[] T000424_A11OrganisationId ;
      private bool[] T000424_n11OrganisationId ;
      private Guid[] T000425_A11OrganisationId ;
      private bool[] T000425_n11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_location__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_location__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_location__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00042;
       prmT00042 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00043;
       prmT00043 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00044;
       prmT00044 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00045;
       prmT00045 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00046;
       prmT00046 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00047;
       prmT00047 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00048;
       prmT00048 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00049;
       prmT00049 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000410;
       prmT000410 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000411;
       prmT000411 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000412;
       prmT000412 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=6, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=22, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000413;
       prmT000413 = new Object[] {
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000414;
       prmT000414 = new Object[] {
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000415;
       prmT000415 = new Object[] {
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000416;
       prmT000416 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000417;
       prmT000417 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000418;
       prmT000418 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000419;
       prmT000419 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000420;
       prmT000420 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000421;
       prmT000421 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000422;
       prmT000422 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000423;
       prmT000423 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000424;
       prmT000424 = new Object[] {
       };
       Object[] prmT000425;
       prmT000425 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T00042", "SELECT LocationId, LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Location NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00043", "SELECT LocationId, LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00044", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00045", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00046", "SELECT TM1.LocationId, TM1.LocationCountry, TM1.LocationPhoneCode, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00047", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00048", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00049", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000410", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE ( LocationId > :LocationId or LocationId = :LocationId and OrganisationId > :OrganisationId) ORDER BY LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000411", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE ( LocationId < :LocationId or LocationId = :LocationId and OrganisationId < :OrganisationId) ORDER BY LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000412", "SAVEPOINT gxupdate;INSERT INTO Trn_Location(LocationId, LocationCountry, LocationPhoneCode, LocationPhone, LocationZipCode, LocationName, LocationImage, LocationImage_GXI, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId) VALUES(:LocationId, :LocationCountry, :LocationPhoneCode, :LocationPhone, :LocationZipCode, :LocationName, :LocationImage, :LocationImage_GXI, :LocationCity, :LocationAddressLine1, :LocationAddressLine2, :LocationEmail, :LocationPhoneNumber, :LocationDescription, :LocationBrandTheme, :LocationCtaTheme, :LocationHasMyCare, :LocationHasMyServices, :LocationHasMyLiving, :LocationHasOwnBrand, :ToolBoxDefaultProfileImage, :ToolBoxDefaultLogo, :ReceptionImage, :ReceptionImage_GXI, :ReceptionDescription, :OrganisationId, :Trn_ThemeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000412)
          ,new CursorDef("T000413", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationCountry=:LocationCountry, LocationPhoneCode=:LocationPhoneCode, LocationPhone=:LocationPhone, LocationZipCode=:LocationZipCode, LocationName=:LocationName, LocationCity=:LocationCity, LocationAddressLine1=:LocationAddressLine1, LocationAddressLine2=:LocationAddressLine2, LocationEmail=:LocationEmail, LocationPhoneNumber=:LocationPhoneNumber, LocationDescription=:LocationDescription, LocationBrandTheme=:LocationBrandTheme, LocationCtaTheme=:LocationCtaTheme, LocationHasMyCare=:LocationHasMyCare, LocationHasMyServices=:LocationHasMyServices, LocationHasMyLiving=:LocationHasMyLiving, LocationHasOwnBrand=:LocationHasOwnBrand, ToolBoxDefaultProfileImage=:ToolBoxDefaultProfileImage, ToolBoxDefaultLogo=:ToolBoxDefaultLogo, ReceptionDescription=:ReceptionDescription, Trn_ThemeId=:Trn_ThemeId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000413)
          ,new CursorDef("T000414", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationImage=:LocationImage, LocationImage_GXI=:LocationImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000414)
          ,new CursorDef("T000415", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ReceptionImage=:ReceptionImage, ReceptionImage_GXI=:ReceptionImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000415)
          ,new CursorDef("T000416", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000416)
          ,new CursorDef("T000417", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE SG_LocationId = :LocationId AND SG_OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000418", "SELECT AppVersionId FROM Trn_AppVersion WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000419", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000420", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000421", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000422", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000423", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000424", "SELECT LocationId, OrganisationId FROM Trn_Location ORDER BY LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000425", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(7));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(7));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(7));
             ((string[]) buf[33])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[34])[0] = rslt.wasNull(27);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 22 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 23 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
