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
   public class trn_bulletinboard : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A29LocationId, A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_bulletinboard.aspx")), "trn_bulletinboard.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_bulletinboard.aspx")))) ;
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
                  AV7BulletinBoardId = StringUtil.StrToGuid( GetPar( "BulletinBoardId"));
                  AssignAttri("", false, "AV7BulletinBoardId", AV7BulletinBoardId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vBULLETINBOARDID", GetSecureSignedToken( "", AV7BulletinBoardId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Bulletin Board", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_bulletinboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_bulletinboard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_BulletinBoardId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BulletinBoardId = aP1_BulletinBoardId;
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
            return "trn_bulletinboard_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_BulletinBoard.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationid_Internalname, context.GetMessage( "Organisations", ""), "", "", lblTextblockorganisationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationid.SetProperty("Caption", Combo_organisationid_Caption);
         ucCombo_organisationid.SetProperty("Cls", Combo_organisationid_Cls);
         ucCombo_organisationid.SetProperty("DataListProc", Combo_organisationid_Datalistproc);
         ucCombo_organisationid.SetProperty("DataListProcParametersPrefix", Combo_organisationid_Datalistprocparametersprefix);
         ucCombo_organisationid.SetProperty("EmptyItem", Combo_organisationid_Emptyitem);
         ucCombo_organisationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_organisationid.SetProperty("DropDownOptionsData", AV16OrganisationId_Data);
         ucCombo_organisationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationid_Internalname, "COMBO_ORGANISATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklocationid_Internalname, context.GetMessage( "Location", ""), "", "", lblTextblocklocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_locationid.SetProperty("Caption", Combo_locationid_Caption);
         ucCombo_locationid.SetProperty("Cls", Combo_locationid_Cls);
         ucCombo_locationid.SetProperty("DataListProc", Combo_locationid_Datalistproc);
         ucCombo_locationid.SetProperty("EmptyItem", Combo_locationid_Emptyitem);
         ucCombo_locationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_locationid.SetProperty("DropDownOptionsData", AV24LocationId_Data);
         ucCombo_locationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationid_Internalname, "COMBO_LOCATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBulletinBoardBgColorCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBulletinBoardBgColorCode_Internalname, context.GetMessage( "Color Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBulletinBoardBgColorCode_Internalname, A585BulletinBoardBgColorCode, StringUtil.RTrim( context.localUtil.Format( A585BulletinBoardBgColorCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBulletinBoardBgColorCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBulletinBoardBgColorCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "start", true, "", "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBulletinBoardForm_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBulletinBoardForm_Internalname, context.GetMessage( "Board Form", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBulletinBoardForm_Internalname, StringUtil.RTrim( A586BulletinBoardForm), StringUtil.RTrim( context.localUtil.Format( A586BulletinBoardForm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBulletinBoardForm_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBulletinBoardForm_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_BulletinBoard.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_BulletinBoard.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_organisationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationid_Internalname, AV21ComboOrganisationId.ToString(), AV21ComboOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationid_Visible, edtavComboorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_locationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombolocationid_Internalname, AV25ComboLocationId.ToString(), AV25ComboLocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolocationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolocationid_Visible, edtavCombolocationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_BulletinBoard.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBulletinBoardId_Internalname, A574BulletinBoardId.ToString(), A574BulletinBoardId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBulletinBoardId_Jsonclick, 0, "Attribute", "", "", "", "", edtBulletinBoardId_Visible, edtBulletinBoardId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_BulletinBoard.htm");
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
         E111T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONID_DATA"), AV16OrganisationId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONID_DATA"), AV24LocationId_Data);
               /* Read saved values. */
               Z574BulletinBoardId = StringUtil.StrToGuid( cgiGet( "Z574BulletinBoardId"));
               Z585BulletinBoardBgColorCode = cgiGet( "Z585BulletinBoardBgColorCode");
               Z586BulletinBoardForm = cgiGet( "Z586BulletinBoardForm");
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               N29LocationId = StringUtil.StrToGuid( cgiGet( "N29LocationId"));
               A13OrganisationName = cgiGet( "ORGANISATIONNAME");
               A31LocationName = cgiGet( "LOCATIONNAME");
               A591BulletinBoardName = cgiGet( "BULLETINBOARDNAME");
               AV7BulletinBoardId = StringUtil.StrToGuid( cgiGet( "vBULLETINBOARDID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV14Insert_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_LOCATIONID"));
               AV27Pgmname = cgiGet( "vPGMNAME");
               Combo_organisationid_Objectcall = cgiGet( "COMBO_ORGANISATIONID_Objectcall");
               Combo_organisationid_Class = cgiGet( "COMBO_ORGANISATIONID_Class");
               Combo_organisationid_Icontype = cgiGet( "COMBO_ORGANISATIONID_Icontype");
               Combo_organisationid_Icon = cgiGet( "COMBO_ORGANISATIONID_Icon");
               Combo_organisationid_Caption = cgiGet( "COMBO_ORGANISATIONID_Caption");
               Combo_organisationid_Tooltip = cgiGet( "COMBO_ORGANISATIONID_Tooltip");
               Combo_organisationid_Cls = cgiGet( "COMBO_ORGANISATIONID_Cls");
               Combo_organisationid_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_set");
               Combo_organisationid_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_get");
               Combo_organisationid_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_set");
               Combo_organisationid_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_get");
               Combo_organisationid_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONID_Gamoauthtoken");
               Combo_organisationid_Ddointernalname = cgiGet( "COMBO_ORGANISATIONID_Ddointernalname");
               Combo_organisationid_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolalign");
               Combo_organisationid_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONID_Dropdownoptionstype");
               Combo_organisationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Enabled"));
               Combo_organisationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Visible"));
               Combo_organisationid_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolidtoreplace");
               Combo_organisationid_Datalisttype = cgiGet( "COMBO_ORGANISATIONID_Datalisttype");
               Combo_organisationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Allowmultipleselection"));
               Combo_organisationid_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONID_Datalistfixedvalues");
               Combo_organisationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Isgriditem"));
               Combo_organisationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Hasdescription"));
               Combo_organisationid_Datalistproc = cgiGet( "COMBO_ORGANISATIONID_Datalistproc");
               Combo_organisationid_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONID_Datalistprocparametersprefix");
               Combo_organisationid_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONID_Remoteservicesparameters");
               Combo_organisationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeonlyselectedoption"));
               Combo_organisationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeselectalloption"));
               Combo_organisationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Emptyitem"));
               Combo_organisationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeaddnewoption"));
               Combo_organisationid_Htmltemplate = cgiGet( "COMBO_ORGANISATIONID_Htmltemplate");
               Combo_organisationid_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluestype");
               Combo_organisationid_Loadingdata = cgiGet( "COMBO_ORGANISATIONID_Loadingdata");
               Combo_organisationid_Noresultsfound = cgiGet( "COMBO_ORGANISATIONID_Noresultsfound");
               Combo_organisationid_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONID_Emptyitemtext");
               Combo_organisationid_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONID_Onlyselectedvalues");
               Combo_organisationid_Selectalltext = cgiGet( "COMBO_ORGANISATIONID_Selectalltext");
               Combo_organisationid_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluesseparator");
               Combo_organisationid_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONID_Addnewoptiontext");
               Combo_organisationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationid_Objectcall = cgiGet( "COMBO_LOCATIONID_Objectcall");
               Combo_locationid_Class = cgiGet( "COMBO_LOCATIONID_Class");
               Combo_locationid_Icontype = cgiGet( "COMBO_LOCATIONID_Icontype");
               Combo_locationid_Icon = cgiGet( "COMBO_LOCATIONID_Icon");
               Combo_locationid_Caption = cgiGet( "COMBO_LOCATIONID_Caption");
               Combo_locationid_Tooltip = cgiGet( "COMBO_LOCATIONID_Tooltip");
               Combo_locationid_Cls = cgiGet( "COMBO_LOCATIONID_Cls");
               Combo_locationid_Selectedvalue_set = cgiGet( "COMBO_LOCATIONID_Selectedvalue_set");
               Combo_locationid_Selectedvalue_get = cgiGet( "COMBO_LOCATIONID_Selectedvalue_get");
               Combo_locationid_Selectedtext_set = cgiGet( "COMBO_LOCATIONID_Selectedtext_set");
               Combo_locationid_Selectedtext_get = cgiGet( "COMBO_LOCATIONID_Selectedtext_get");
               Combo_locationid_Gamoauthtoken = cgiGet( "COMBO_LOCATIONID_Gamoauthtoken");
               Combo_locationid_Ddointernalname = cgiGet( "COMBO_LOCATIONID_Ddointernalname");
               Combo_locationid_Titlecontrolalign = cgiGet( "COMBO_LOCATIONID_Titlecontrolalign");
               Combo_locationid_Dropdownoptionstype = cgiGet( "COMBO_LOCATIONID_Dropdownoptionstype");
               Combo_locationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Enabled"));
               Combo_locationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Visible"));
               Combo_locationid_Titlecontrolidtoreplace = cgiGet( "COMBO_LOCATIONID_Titlecontrolidtoreplace");
               Combo_locationid_Datalisttype = cgiGet( "COMBO_LOCATIONID_Datalisttype");
               Combo_locationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Allowmultipleselection"));
               Combo_locationid_Datalistfixedvalues = cgiGet( "COMBO_LOCATIONID_Datalistfixedvalues");
               Combo_locationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Isgriditem"));
               Combo_locationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Hasdescription"));
               Combo_locationid_Datalistproc = cgiGet( "COMBO_LOCATIONID_Datalistproc");
               Combo_locationid_Datalistprocparametersprefix = cgiGet( "COMBO_LOCATIONID_Datalistprocparametersprefix");
               Combo_locationid_Remoteservicesparameters = cgiGet( "COMBO_LOCATIONID_Remoteservicesparameters");
               Combo_locationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_locationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeonlyselectedoption"));
               Combo_locationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeselectalloption"));
               Combo_locationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Emptyitem"));
               Combo_locationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOCATIONID_Includeaddnewoption"));
               Combo_locationid_Htmltemplate = cgiGet( "COMBO_LOCATIONID_Htmltemplate");
               Combo_locationid_Multiplevaluestype = cgiGet( "COMBO_LOCATIONID_Multiplevaluestype");
               Combo_locationid_Loadingdata = cgiGet( "COMBO_LOCATIONID_Loadingdata");
               Combo_locationid_Noresultsfound = cgiGet( "COMBO_LOCATIONID_Noresultsfound");
               Combo_locationid_Emptyitemtext = cgiGet( "COMBO_LOCATIONID_Emptyitemtext");
               Combo_locationid_Onlyselectedvalues = cgiGet( "COMBO_LOCATIONID_Onlyselectedvalues");
               Combo_locationid_Selectalltext = cgiGet( "COMBO_LOCATIONID_Selectalltext");
               Combo_locationid_Multiplevaluesseparator = cgiGet( "COMBO_LOCATIONID_Multiplevaluesseparator");
               Combo_locationid_Addnewoptiontext = cgiGet( "COMBO_LOCATIONID_Addnewoptiontext");
               Combo_locationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOCATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
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
               if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
               {
                  A29LocationId = Guid.Empty;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
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
               A585BulletinBoardBgColorCode = cgiGet( edtBulletinBoardBgColorCode_Internalname);
               AssignAttri("", false, "A585BulletinBoardBgColorCode", A585BulletinBoardBgColorCode);
               A586BulletinBoardForm = cgiGet( edtBulletinBoardForm_Internalname);
               AssignAttri("", false, "A586BulletinBoardForm", A586BulletinBoardForm);
               AV21ComboOrganisationId = StringUtil.StrToGuid( cgiGet( edtavComboorganisationid_Internalname));
               AssignAttri("", false, "AV21ComboOrganisationId", AV21ComboOrganisationId.ToString());
               AV25ComboLocationId = StringUtil.StrToGuid( cgiGet( edtavCombolocationid_Internalname));
               AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
               if ( StringUtil.StrCmp(cgiGet( edtBulletinBoardId_Internalname), "") == 0 )
               {
                  A574BulletinBoardId = Guid.Empty;
                  AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
               }
               else
               {
                  try
                  {
                     A574BulletinBoardId = StringUtil.StrToGuid( cgiGet( edtBulletinBoardId_Internalname));
                     AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "BULLETINBOARDID");
                     AnyError = 1;
                     GX_FocusControl = edtBulletinBoardId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_BulletinBoard");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A574BulletinBoardId != Z574BulletinBoardId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_bulletinboard:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A574BulletinBoardId = StringUtil.StrToGuid( GetPar( "BulletinBoardId"));
                  AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7BulletinBoardId) )
                  {
                     A574BulletinBoardId = AV7BulletinBoardId;
                     AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A574BulletinBoardId) && ( Gx_BScreen == 0 ) )
                     {
                        A574BulletinBoardId = Guid.NewGuid( );
                        AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
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
                     sMode114 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7BulletinBoardId) )
                     {
                        A574BulletinBoardId = AV7BulletinBoardId;
                        AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A574BulletinBoardId) && ( Gx_BScreen == 0 ) )
                        {
                           A574BulletinBoardId = Guid.NewGuid( );
                           AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                        }
                     }
                     Gx_mode = sMode114;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound114 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BULLETINBOARDID");
                        AnyError = 1;
                        GX_FocusControl = edtBulletinBoardId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_organisationid.Onoptionclicked */
                           E121T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_locationid.Onoptionclicked */
                           E131T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E141T2 ();
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
            E141T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1T114( ) ;
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
            DisableAttributes1T114( ) ;
         }
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombolocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T114( ) ;
            }
            else
            {
               CheckExtendedTable1T114( ) ;
               CloseExtendedTableCursors1T114( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1T0( )
      {
      }

      protected void E111T2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_locationid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "GAMOAuthToken", Combo_locationid_Gamoauthtoken);
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         AV25ComboLocationId = Guid.Empty;
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         edtavCombolocationid_Visible = 0;
         AssignProp("", false, edtavCombolocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Visible), 5, 0), true);
         Combo_organisationid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "GAMOAuthToken", Combo_organisationid_Gamoauthtoken);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         AV21ComboOrganisationId = Guid.Empty;
         AssignAttri("", false, "AV21ComboOrganisationId", AV21ComboOrganisationId.ToString());
         edtavComboorganisationid_Visible = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOLOCATIONID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_OrganisationId", AV13Insert_OrganisationId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_OrganisationId) )
                  {
                     AV21ComboOrganisationId = AV13Insert_OrganisationId;
                     AssignAttri("", false, "AV21ComboOrganisationId", AV21ComboOrganisationId.ToString());
                     Combo_organisationid_Selectedvalue_set = StringUtil.Trim( AV21ComboOrganisationId.ToString());
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new trn_bulletinboardloaddvcombo(context ).execute(  "OrganisationId",  "GET",  false,  AV7BulletinBoardId,  A11OrganisationId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_organisationid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
                     Combo_organisationid_Enabled = false;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV14Insert_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_LocationId", AV14Insert_LocationId.ToString());
                  if ( ! (Guid.Empty==AV14Insert_LocationId) )
                  {
                     AV25ComboLocationId = AV14Insert_LocationId;
                     AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
                     Combo_locationid_Selectedvalue_set = StringUtil.Trim( AV25ComboLocationId.ToString());
                     ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedValue_set", Combo_locationid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new trn_bulletinboardloaddvcombo(context ).execute(  "LocationId",  "GET",  false,  AV7BulletinBoardId,  AV13Insert_OrganisationId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_locationid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedText_set", Combo_locationid_Selectedtext_set);
                     Combo_locationid_Enabled = false;
                     ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationid_Enabled));
                  }
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         edtBulletinBoardId_Visible = 0;
         AssignProp("", false, edtBulletinBoardId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBulletinBoardId_Visible), 5, 0), true);
      }

      protected void E141T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_bulletinboardww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E131T2( )
      {
         /* Combo_locationid_Onoptionclicked Routine */
         returnInSub = false;
         AV25ComboLocationId = StringUtil.StrToGuid( Combo_locationid_Selectedvalue_get);
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E121T2( )
      {
         /* Combo_organisationid_Onoptionclicked Routine */
         returnInSub = false;
         AV26Cond_OrganisationId = A11OrganisationId;
         AV21ComboOrganisationId = StringUtil.StrToGuid( Combo_organisationid_Selectedvalue_get);
         AssignAttri("", false, "AV21ComboOrganisationId", AV21ComboOrganisationId.ToString());
         if ( AV26Cond_OrganisationId != AV21ComboOrganisationId )
         {
            AV25ComboLocationId = Guid.Empty;
            AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
            Combo_locationid_Selectedvalue_set = "";
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedValue_set", Combo_locationid_Selectedvalue_set);
            Combo_locationid_Selectedtext_set = "";
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedText_set", Combo_locationid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONID' Routine */
         returnInSub = false;
         Combo_locationid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"LocationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BulletinBoardId\": \"00000000-0000-0000-0000-000000000000\", \"Cond_OrganisationId\": \"#%1#\"", edtOrganisationId_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "DataListProcParametersPrefix", Combo_locationid_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new trn_bulletinboardloaddvcombo(context ).execute(  "LocationId",  Gx_mode,  false,  AV7BulletinBoardId,  A11OrganisationId,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_locationid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedValue_set", Combo_locationid_Selectedvalue_set);
         Combo_locationid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "SelectedText_set", Combo_locationid_Selectedtext_set);
         AV25ComboLocationId = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV25ComboLocationId", AV25ComboLocationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_locationid_Enabled = false;
            ucCombo_locationid.SendProperty(context, "", false, Combo_locationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_locationid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOORGANISATIONID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new trn_bulletinboardloaddvcombo(context ).execute(  "OrganisationId",  Gx_mode,  false,  AV7BulletinBoardId,  A11OrganisationId,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_organisationid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
         Combo_organisationid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
         AV21ComboOrganisationId = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV21ComboOrganisationId", AV21ComboOrganisationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationid_Enabled = false;
            ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         }
      }

      protected void ZM1T114( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z585BulletinBoardBgColorCode = T001T3_A585BulletinBoardBgColorCode[0];
               Z586BulletinBoardForm = T001T3_A586BulletinBoardForm[0];
               Z11OrganisationId = T001T3_A11OrganisationId[0];
               Z29LocationId = T001T3_A29LocationId[0];
            }
            else
            {
               Z585BulletinBoardBgColorCode = A585BulletinBoardBgColorCode;
               Z586BulletinBoardForm = A586BulletinBoardForm;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z574BulletinBoardId = A574BulletinBoardId;
            Z585BulletinBoardBgColorCode = A585BulletinBoardBgColorCode;
            Z586BulletinBoardForm = A586BulletinBoardForm;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z13OrganisationName = A13OrganisationName;
            Z31LocationName = A31LocationName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV27Pgmname = "Trn_BulletinBoard";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7BulletinBoardId) )
         {
            edtBulletinBoardId_Enabled = 0;
            AssignProp("", false, edtBulletinBoardId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardId_Enabled), 5, 0), true);
         }
         else
         {
            edtBulletinBoardId_Enabled = 1;
            AssignProp("", false, edtBulletinBoardId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7BulletinBoardId) )
         {
            edtBulletinBoardId_Enabled = 0;
            AssignProp("", false, edtBulletinBoardId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            A11OrganisationId = AV13Insert_OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = AV21ComboOrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_LocationId) )
         {
            A29LocationId = AV14Insert_LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = AV25ComboLocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
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
         if ( ! (Guid.Empty==AV7BulletinBoardId) )
         {
            A574BulletinBoardId = AV7BulletinBoardId;
            AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A574BulletinBoardId) && ( Gx_BScreen == 0 ) )
            {
               A574BulletinBoardId = Guid.NewGuid( );
               AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001T4 */
            pr_default.execute(2, new Object[] {A11OrganisationId});
            A13OrganisationName = T001T4_A13OrganisationName[0];
            pr_default.close(2);
            /* Using cursor T001T5 */
            pr_default.execute(3, new Object[] {A29LocationId, A11OrganisationId});
            A31LocationName = T001T5_A31LocationName[0];
            pr_default.close(3);
            A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
            AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
         }
      }

      protected void Load1T114( )
      {
         /* Using cursor T001T6 */
         pr_default.execute(4, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound114 = 1;
            A13OrganisationName = T001T6_A13OrganisationName[0];
            A31LocationName = T001T6_A31LocationName[0];
            A585BulletinBoardBgColorCode = T001T6_A585BulletinBoardBgColorCode[0];
            AssignAttri("", false, "A585BulletinBoardBgColorCode", A585BulletinBoardBgColorCode);
            A586BulletinBoardForm = T001T6_A586BulletinBoardForm[0];
            AssignAttri("", false, "A586BulletinBoardForm", A586BulletinBoardForm);
            A11OrganisationId = T001T6_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T001T6_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            ZM1T114( -16) ;
         }
         pr_default.close(4);
         OnLoadActions1T114( ) ;
      }

      protected void OnLoadActions1T114( )
      {
         A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
         AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
      }

      protected void CheckExtendedTable1T114( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001T4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13OrganisationName = T001T4_A13OrganisationName[0];
         pr_default.close(2);
         /* Using cursor T001T5 */
         pr_default.execute(3, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A31LocationName = T001T5_A31LocationName[0];
         pr_default.close(3);
         A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
         AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
      }

      protected void CloseExtendedTableCursors1T114( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( Guid A11OrganisationId )
      {
         /* Using cursor T001T7 */
         pr_default.execute(5, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13OrganisationName = T001T7_A13OrganisationName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A13OrganisationName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_18( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T001T8 */
         pr_default.execute(6, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A31LocationName = T001T8_A31LocationName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A31LocationName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1T114( )
      {
         /* Using cursor T001T9 */
         pr_default.execute(7, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound114 = 1;
         }
         else
         {
            RcdFound114 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001T3 */
         pr_default.execute(1, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T114( 16) ;
            RcdFound114 = 1;
            A574BulletinBoardId = T001T3_A574BulletinBoardId[0];
            AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
            A585BulletinBoardBgColorCode = T001T3_A585BulletinBoardBgColorCode[0];
            AssignAttri("", false, "A585BulletinBoardBgColorCode", A585BulletinBoardBgColorCode);
            A586BulletinBoardForm = T001T3_A586BulletinBoardForm[0];
            AssignAttri("", false, "A586BulletinBoardForm", A586BulletinBoardForm);
            A11OrganisationId = T001T3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T001T3_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            Z574BulletinBoardId = A574BulletinBoardId;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1T114( ) ;
            if ( AnyError == 1 )
            {
               RcdFound114 = 0;
               InitializeNonKey1T114( ) ;
            }
            Gx_mode = sMode114;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound114 = 0;
            InitializeNonKey1T114( ) ;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode114;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T114( ) ;
         if ( RcdFound114 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound114 = 0;
         /* Using cursor T001T10 */
         pr_default.execute(8, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001T10_A574BulletinBoardId[0], A574BulletinBoardId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001T10_A574BulletinBoardId[0], A574BulletinBoardId, 0) > 0 ) ) )
            {
               A574BulletinBoardId = T001T10_A574BulletinBoardId[0];
               AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
               RcdFound114 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound114 = 0;
         /* Using cursor T001T11 */
         pr_default.execute(9, new Object[] {A574BulletinBoardId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001T11_A574BulletinBoardId[0], A574BulletinBoardId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001T11_A574BulletinBoardId[0], A574BulletinBoardId, 0) < 0 ) ) )
            {
               A574BulletinBoardId = T001T11_A574BulletinBoardId[0];
               AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
               RcdFound114 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1T114( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1T114( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound114 == 1 )
            {
               if ( A574BulletinBoardId != Z574BulletinBoardId )
               {
                  A574BulletinBoardId = Z574BulletinBoardId;
                  AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BULLETINBOARDID");
                  AnyError = 1;
                  GX_FocusControl = edtBulletinBoardId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOrganisationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1T114( ) ;
                  GX_FocusControl = edtOrganisationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A574BulletinBoardId != Z574BulletinBoardId )
               {
                  /* Insert record */
                  GX_FocusControl = edtOrganisationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1T114( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BULLETINBOARDID");
                     AnyError = 1;
                     GX_FocusControl = edtBulletinBoardId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1T114( ) ;
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
         if ( A574BulletinBoardId != Z574BulletinBoardId )
         {
            A574BulletinBoardId = Z574BulletinBoardId;
            AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BULLETINBOARDID");
            AnyError = 1;
            GX_FocusControl = edtBulletinBoardId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1T114( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001T2 */
            pr_default.execute(0, new Object[] {A574BulletinBoardId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_BulletinBoard"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z585BulletinBoardBgColorCode, T001T2_A585BulletinBoardBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z586BulletinBoardForm, T001T2_A586BulletinBoardForm[0]) != 0 ) || ( Z11OrganisationId != T001T2_A11OrganisationId[0] ) || ( Z29LocationId != T001T2_A29LocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z585BulletinBoardBgColorCode, T001T2_A585BulletinBoardBgColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_bulletinboard:[seudo value changed for attri]"+"BulletinBoardBgColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z585BulletinBoardBgColorCode);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A585BulletinBoardBgColorCode[0]);
               }
               if ( StringUtil.StrCmp(Z586BulletinBoardForm, T001T2_A586BulletinBoardForm[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_bulletinboard:[seudo value changed for attri]"+"BulletinBoardForm");
                  GXUtil.WriteLogRaw("Old: ",Z586BulletinBoardForm);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A586BulletinBoardForm[0]);
               }
               if ( Z11OrganisationId != T001T2_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_bulletinboard:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A11OrganisationId[0]);
               }
               if ( Z29LocationId != T001T2_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_bulletinboard:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A29LocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_BulletinBoard"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T114( )
      {
         if ( ! IsAuthorized("trn_bulletinboard_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T114( 0) ;
            CheckOptimisticConcurrency1T114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T12 */
                     pr_default.execute(10, new Object[] {A574BulletinBoardId, A585BulletinBoardBgColorCode, A586BulletinBoardForm, A11OrganisationId, A29LocationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
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
               Load1T114( ) ;
            }
            EndLevel1T114( ) ;
         }
         CloseExtendedTableCursors1T114( ) ;
      }

      protected void Update1T114( )
      {
         if ( ! IsAuthorized("trn_bulletinboard_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T13 */
                     pr_default.execute(11, new Object[] {A585BulletinBoardBgColorCode, A586BulletinBoardForm, A11OrganisationId, A29LocationId, A574BulletinBoardId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_BulletinBoard"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T114( ) ;
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
            EndLevel1T114( ) ;
         }
         CloseExtendedTableCursors1T114( ) ;
      }

      protected void DeferredUpdate1T114( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_bulletinboard_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1T114( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T114( ) ;
            AfterConfirm1T114( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T114( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001T14 */
                  pr_default.execute(12, new Object[] {A574BulletinBoardId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_BulletinBoard");
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
         sMode114 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1T114( ) ;
         Gx_mode = sMode114;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1T114( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001T15 */
            pr_default.execute(13, new Object[] {A11OrganisationId});
            A13OrganisationName = T001T15_A13OrganisationName[0];
            pr_default.close(13);
            /* Using cursor T001T16 */
            pr_default.execute(14, new Object[] {A29LocationId, A11OrganisationId});
            A31LocationName = T001T16_A31LocationName[0];
            pr_default.close(14);
            A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
            AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001T17 */
            pr_default.execute(15, new Object[] {A574BulletinBoardId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Memo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel1T114( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T114( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_bulletinboard",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_bulletinboard",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1T114( )
      {
         /* Scan By routine */
         /* Using cursor T001T18 */
         pr_default.execute(16);
         RcdFound114 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound114 = 1;
            A574BulletinBoardId = T001T18_A574BulletinBoardId[0];
            AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1T114( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound114 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound114 = 1;
            A574BulletinBoardId = T001T18_A574BulletinBoardId[0];
            AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
         }
      }

      protected void ScanEnd1T114( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1T114( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T114( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T114( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T114( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T114( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T114( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T114( )
      {
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtBulletinBoardBgColorCode_Enabled = 0;
         AssignProp("", false, edtBulletinBoardBgColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardBgColorCode_Enabled), 5, 0), true);
         edtBulletinBoardForm_Enabled = 0;
         AssignProp("", false, edtBulletinBoardForm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardForm_Enabled), 5, 0), true);
         edtavComboorganisationid_Enabled = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
         edtavCombolocationid_Enabled = 0;
         AssignProp("", false, edtavCombolocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolocationid_Enabled), 5, 0), true);
         edtBulletinBoardId_Enabled = 0;
         AssignProp("", false, edtBulletinBoardId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBulletinBoardId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1T114( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1T0( )
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
         GXEncryptionTmp = "trn_bulletinboard.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7BulletinBoardId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_bulletinboard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_BulletinBoard");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_bulletinboard:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z574BulletinBoardId", Z574BulletinBoardId.ToString());
         GxWebStd.gx_hidden_field( context, "Z585BulletinBoardBgColorCode", Z585BulletinBoardBgColorCode);
         GxWebStd.gx_hidden_field( context, "Z586BulletinBoardForm", StringUtil.RTrim( Z586BulletinBoardForm));
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "N29LocationId", A29LocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONID_DATA", AV16OrganisationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONID_DATA", AV16OrganisationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONID_DATA", AV24LocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONID_DATA", AV24LocationId_Data);
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
         GxWebStd.gx_hidden_field( context, "ORGANISATIONNAME", A13OrganisationName);
         GxWebStd.gx_hidden_field( context, "LOCATIONNAME", A31LocationName);
         GxWebStd.gx_hidden_field( context, "BULLETINBOARDNAME", A591BulletinBoardName);
         GxWebStd.gx_hidden_field( context, "vBULLETINBOARDID", AV7BulletinBoardId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vBULLETINBOARDID", GetSecureSignedToken( "", AV7BulletinBoardId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV13Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_LOCATIONID", AV14Insert_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Objectcall", StringUtil.RTrim( Combo_organisationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Cls", StringUtil.RTrim( Combo_organisationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_organisationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedtext_set", StringUtil.RTrim( Combo_organisationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_organisationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistproc", StringUtil.RTrim( Combo_organisationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_organisationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Emptyitem", StringUtil.BoolToStr( Combo_organisationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Objectcall", StringUtil.RTrim( Combo_locationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Cls", StringUtil.RTrim( Combo_locationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_locationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Selectedtext_set", StringUtil.RTrim( Combo_locationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_locationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Enabled", StringUtil.BoolToStr( Combo_locationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Datalistproc", StringUtil.RTrim( Combo_locationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_locationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_locationid_Emptyitem));
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
         GXEncryptionTmp = "trn_bulletinboard.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7BulletinBoardId.ToString());
         return formatLink("trn_bulletinboard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_BulletinBoard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Bulletin Board", "") ;
      }

      protected void InitializeNonKey1T114( )
      {
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A591BulletinBoardName = "";
         AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
         A13OrganisationName = "";
         AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
         A31LocationName = "";
         AssignAttri("", false, "A31LocationName", A31LocationName);
         A585BulletinBoardBgColorCode = "";
         AssignAttri("", false, "A585BulletinBoardBgColorCode", A585BulletinBoardBgColorCode);
         A586BulletinBoardForm = "";
         AssignAttri("", false, "A586BulletinBoardForm", A586BulletinBoardForm);
         Z585BulletinBoardBgColorCode = "";
         Z586BulletinBoardForm = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
      }

      protected void InitAll1T114( )
      {
         A574BulletinBoardId = Guid.NewGuid( );
         AssignAttri("", false, "A574BulletinBoardId", A574BulletinBoardId.ToString());
         InitializeNonKey1T114( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202531920415191", true, true);
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
         context.AddJavascriptSource("trn_bulletinboard.js", "?202531920415193", false, true);
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
         lblTextblockorganisationid_Internalname = "TEXTBLOCKORGANISATIONID";
         Combo_organisationid_Internalname = "COMBO_ORGANISATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divTablesplittedorganisationid_Internalname = "TABLESPLITTEDORGANISATIONID";
         lblTextblocklocationid_Internalname = "TEXTBLOCKLOCATIONID";
         Combo_locationid_Internalname = "COMBO_LOCATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         divTablesplittedlocationid_Internalname = "TABLESPLITTEDLOCATIONID";
         edtBulletinBoardBgColorCode_Internalname = "BULLETINBOARDBGCOLORCODE";
         edtBulletinBoardForm_Internalname = "BULLETINBOARDFORM";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboorganisationid_Internalname = "vCOMBOORGANISATIONID";
         divSectionattribute_organisationid_Internalname = "SECTIONATTRIBUTE_ORGANISATIONID";
         edtavCombolocationid_Internalname = "vCOMBOLOCATIONID";
         divSectionattribute_locationid_Internalname = "SECTIONATTRIBUTE_LOCATIONID";
         edtBulletinBoardId_Internalname = "BULLETINBOARDID";
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
         Form.Caption = context.GetMessage( "Trn_Bulletin Board", "");
         Combo_locationid_Datalistprocparametersprefix = "";
         edtBulletinBoardId_Jsonclick = "";
         edtBulletinBoardId_Enabled = 1;
         edtBulletinBoardId_Visible = 1;
         edtavCombolocationid_Jsonclick = "";
         edtavCombolocationid_Enabled = 0;
         edtavCombolocationid_Visible = 1;
         edtavComboorganisationid_Jsonclick = "";
         edtavComboorganisationid_Enabled = 0;
         edtavComboorganisationid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtBulletinBoardForm_Jsonclick = "";
         edtBulletinBoardForm_Enabled = 1;
         edtBulletinBoardBgColorCode_Jsonclick = "";
         edtBulletinBoardBgColorCode_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         Combo_locationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationid_Datalistproc = "Trn_BulletinBoardLoadDVCombo";
         Combo_locationid_Cls = "ExtendedCombo Attribute";
         Combo_locationid_Caption = "";
         Combo_locationid_Enabled = Convert.ToBoolean( -1);
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         Combo_organisationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationid_Datalistprocparametersprefix = " \"ComboName\": \"OrganisationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BulletinBoardId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_organisationid_Datalistproc = "Trn_BulletinBoardLoadDVCombo";
         Combo_organisationid_Cls = "ExtendedCombo Attribute";
         Combo_organisationid_Caption = "";
         Combo_organisationid_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Organisationid( )
      {
         /* Using cursor T001T15 */
         pr_default.execute(13, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
         }
         A13OrganisationName = T001T15_A13OrganisationName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
      }

      public void Valid_Locationid( )
      {
         /* Using cursor T001T16 */
         pr_default.execute(14, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         A31LocationName = T001T16_A31LocationName[0];
         pr_default.close(14);
         A591BulletinBoardName = A13OrganisationName + " - " + A31LocationName;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A31LocationName", A31LocationName);
         AssignAttri("", false, "A591BulletinBoardName", A591BulletinBoardName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7BulletinBoardId","fld":"vBULLETINBOARDID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7BulletinBoardId","fld":"vBULLETINBOARDID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E141T2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_LOCATIONID.ONOPTIONCLICKED","""{"handler":"E131T2","iparms":[{"av":"Combo_locationid_Selectedvalue_get","ctrl":"COMBO_LOCATIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_LOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV25ComboLocationId","fld":"vCOMBOLOCATIONID"}]}""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED","""{"handler":"E121T2","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"Combo_organisationid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV21ComboOrganisationId","fld":"vCOMBOORGANISATIONID"},{"av":"AV25ComboLocationId","fld":"vCOMBOLOCATIONID"},{"av":"Combo_locationid_Selectedvalue_set","ctrl":"COMBO_LOCATIONID","prop":"SelectedValue_set"},{"av":"Combo_locationid_Selectedtext_set","ctrl":"COMBO_LOCATIONID","prop":"SelectedText_set"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A13OrganisationName","fld":"ORGANISATIONNAME"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A13OrganisationName","fld":"ORGANISATIONNAME"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A13OrganisationName","fld":"ORGANISATIONNAME"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A591BulletinBoardName","fld":"BULLETINBOARDNAME"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A591BulletinBoardName","fld":"BULLETINBOARDNAME"}]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONID","""{"handler":"Validv_Comboorganisationid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOCATIONID","""{"handler":"Validv_Combolocationid","iparms":[]}""");
         setEventMetadata("VALID_BULLETINBOARDID","""{"handler":"Valid_Bulletinboardid","iparms":[]}""");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7BulletinBoardId = Guid.Empty;
         Z574BulletinBoardId = Guid.Empty;
         Z585BulletinBoardBgColorCode = "";
         Z586BulletinBoardForm = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         N29LocationId = Guid.Empty;
         Combo_locationid_Selectedvalue_get = "";
         Combo_organisationid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTextblockorganisationid_Jsonclick = "";
         ucCombo_organisationid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16OrganisationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblocklocationid_Jsonclick = "";
         ucCombo_locationid = new GXUserControl();
         AV24LocationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV21ComboOrganisationId = Guid.Empty;
         AV25ComboLocationId = Guid.Empty;
         A574BulletinBoardId = Guid.Empty;
         A13OrganisationName = "";
         A31LocationName = "";
         A591BulletinBoardName = "";
         AV13Insert_OrganisationId = Guid.Empty;
         AV14Insert_LocationId = Guid.Empty;
         AV27Pgmname = "";
         Combo_organisationid_Objectcall = "";
         Combo_organisationid_Class = "";
         Combo_organisationid_Icontype = "";
         Combo_organisationid_Icon = "";
         Combo_organisationid_Tooltip = "";
         Combo_organisationid_Selectedvalue_set = "";
         Combo_organisationid_Selectedtext_set = "";
         Combo_organisationid_Selectedtext_get = "";
         Combo_organisationid_Gamoauthtoken = "";
         Combo_organisationid_Ddointernalname = "";
         Combo_organisationid_Titlecontrolalign = "";
         Combo_organisationid_Dropdownoptionstype = "";
         Combo_organisationid_Titlecontrolidtoreplace = "";
         Combo_organisationid_Datalisttype = "";
         Combo_organisationid_Datalistfixedvalues = "";
         Combo_organisationid_Remoteservicesparameters = "";
         Combo_organisationid_Htmltemplate = "";
         Combo_organisationid_Multiplevaluestype = "";
         Combo_organisationid_Loadingdata = "";
         Combo_organisationid_Noresultsfound = "";
         Combo_organisationid_Emptyitemtext = "";
         Combo_organisationid_Onlyselectedvalues = "";
         Combo_organisationid_Selectalltext = "";
         Combo_organisationid_Multiplevaluesseparator = "";
         Combo_organisationid_Addnewoptiontext = "";
         Combo_locationid_Objectcall = "";
         Combo_locationid_Class = "";
         Combo_locationid_Icontype = "";
         Combo_locationid_Icon = "";
         Combo_locationid_Tooltip = "";
         Combo_locationid_Selectedvalue_set = "";
         Combo_locationid_Selectedtext_set = "";
         Combo_locationid_Selectedtext_get = "";
         Combo_locationid_Gamoauthtoken = "";
         Combo_locationid_Ddointernalname = "";
         Combo_locationid_Titlecontrolalign = "";
         Combo_locationid_Dropdownoptionstype = "";
         Combo_locationid_Titlecontrolidtoreplace = "";
         Combo_locationid_Datalisttype = "";
         Combo_locationid_Datalistfixedvalues = "";
         Combo_locationid_Remoteservicesparameters = "";
         Combo_locationid_Htmltemplate = "";
         Combo_locationid_Multiplevaluestype = "";
         Combo_locationid_Loadingdata = "";
         Combo_locationid_Noresultsfound = "";
         Combo_locationid_Emptyitemtext = "";
         Combo_locationid_Onlyselectedvalues = "";
         Combo_locationid_Selectalltext = "";
         Combo_locationid_Multiplevaluesseparator = "";
         Combo_locationid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode114 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         AV26Cond_OrganisationId = Guid.Empty;
         GXt_char2 = "";
         Z13OrganisationName = "";
         Z31LocationName = "";
         T001T4_A13OrganisationName = new string[] {""} ;
         T001T5_A31LocationName = new string[] {""} ;
         T001T6_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T6_A13OrganisationName = new string[] {""} ;
         T001T6_A31LocationName = new string[] {""} ;
         T001T6_A585BulletinBoardBgColorCode = new string[] {""} ;
         T001T6_A586BulletinBoardForm = new string[] {""} ;
         T001T6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001T6_A29LocationId = new Guid[] {Guid.Empty} ;
         T001T7_A13OrganisationName = new string[] {""} ;
         T001T8_A31LocationName = new string[] {""} ;
         T001T9_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T3_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T3_A585BulletinBoardBgColorCode = new string[] {""} ;
         T001T3_A586BulletinBoardForm = new string[] {""} ;
         T001T3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001T3_A29LocationId = new Guid[] {Guid.Empty} ;
         T001T10_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T11_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T2_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         T001T2_A585BulletinBoardBgColorCode = new string[] {""} ;
         T001T2_A586BulletinBoardForm = new string[] {""} ;
         T001T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001T2_A29LocationId = new Guid[] {Guid.Empty} ;
         T001T15_A13OrganisationName = new string[] {""} ;
         T001T16_A31LocationName = new string[] {""} ;
         T001T17_A575MemoId = new Guid[] {Guid.Empty} ;
         T001T18_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Z591BulletinBoardName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboard__default(),
            new Object[][] {
                new Object[] {
               T001T2_A574BulletinBoardId, T001T2_A585BulletinBoardBgColorCode, T001T2_A586BulletinBoardForm, T001T2_A11OrganisationId, T001T2_A29LocationId
               }
               , new Object[] {
               T001T3_A574BulletinBoardId, T001T3_A585BulletinBoardBgColorCode, T001T3_A586BulletinBoardForm, T001T3_A11OrganisationId, T001T3_A29LocationId
               }
               , new Object[] {
               T001T4_A13OrganisationName
               }
               , new Object[] {
               T001T5_A31LocationName
               }
               , new Object[] {
               T001T6_A574BulletinBoardId, T001T6_A13OrganisationName, T001T6_A31LocationName, T001T6_A585BulletinBoardBgColorCode, T001T6_A586BulletinBoardForm, T001T6_A11OrganisationId, T001T6_A29LocationId
               }
               , new Object[] {
               T001T7_A13OrganisationName
               }
               , new Object[] {
               T001T8_A31LocationName
               }
               , new Object[] {
               T001T9_A574BulletinBoardId
               }
               , new Object[] {
               T001T10_A574BulletinBoardId
               }
               , new Object[] {
               T001T11_A574BulletinBoardId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001T15_A13OrganisationName
               }
               , new Object[] {
               T001T16_A31LocationName
               }
               , new Object[] {
               T001T17_A575MemoId
               }
               , new Object[] {
               T001T18_A574BulletinBoardId
               }
            }
         );
         Z574BulletinBoardId = Guid.NewGuid( );
         A574BulletinBoardId = Guid.NewGuid( );
         AV27Pgmname = "Trn_BulletinBoard";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound114 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtBulletinBoardBgColorCode_Enabled ;
      private int edtBulletinBoardForm_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboorganisationid_Visible ;
      private int edtavComboorganisationid_Enabled ;
      private int edtavCombolocationid_Visible ;
      private int edtavCombolocationid_Enabled ;
      private int edtBulletinBoardId_Visible ;
      private int edtBulletinBoardId_Enabled ;
      private int Combo_organisationid_Datalistupdateminimumcharacters ;
      private int Combo_organisationid_Gxcontroltype ;
      private int Combo_locationid_Datalistupdateminimumcharacters ;
      private int Combo_locationid_Gxcontroltype ;
      private int AV28GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z586BulletinBoardForm ;
      private string Combo_locationid_Selectedvalue_get ;
      private string Combo_organisationid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOrganisationId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedorganisationid_Internalname ;
      private string lblTextblockorganisationid_Internalname ;
      private string lblTextblockorganisationid_Jsonclick ;
      private string Combo_organisationid_Caption ;
      private string Combo_organisationid_Cls ;
      private string Combo_organisationid_Datalistproc ;
      private string Combo_organisationid_Datalistprocparametersprefix ;
      private string Combo_organisationid_Internalname ;
      private string TempTags ;
      private string edtOrganisationId_Jsonclick ;
      private string divTablesplittedlocationid_Internalname ;
      private string lblTextblocklocationid_Internalname ;
      private string lblTextblocklocationid_Jsonclick ;
      private string Combo_locationid_Caption ;
      private string Combo_locationid_Cls ;
      private string Combo_locationid_Datalistproc ;
      private string Combo_locationid_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtBulletinBoardBgColorCode_Internalname ;
      private string edtBulletinBoardBgColorCode_Jsonclick ;
      private string edtBulletinBoardForm_Internalname ;
      private string A586BulletinBoardForm ;
      private string edtBulletinBoardForm_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_organisationid_Internalname ;
      private string edtavComboorganisationid_Internalname ;
      private string edtavComboorganisationid_Jsonclick ;
      private string divSectionattribute_locationid_Internalname ;
      private string edtavCombolocationid_Internalname ;
      private string edtavCombolocationid_Jsonclick ;
      private string edtBulletinBoardId_Internalname ;
      private string edtBulletinBoardId_Jsonclick ;
      private string AV27Pgmname ;
      private string Combo_organisationid_Objectcall ;
      private string Combo_organisationid_Class ;
      private string Combo_organisationid_Icontype ;
      private string Combo_organisationid_Icon ;
      private string Combo_organisationid_Tooltip ;
      private string Combo_organisationid_Selectedvalue_set ;
      private string Combo_organisationid_Selectedtext_set ;
      private string Combo_organisationid_Selectedtext_get ;
      private string Combo_organisationid_Gamoauthtoken ;
      private string Combo_organisationid_Ddointernalname ;
      private string Combo_organisationid_Titlecontrolalign ;
      private string Combo_organisationid_Dropdownoptionstype ;
      private string Combo_organisationid_Titlecontrolidtoreplace ;
      private string Combo_organisationid_Datalisttype ;
      private string Combo_organisationid_Datalistfixedvalues ;
      private string Combo_organisationid_Remoteservicesparameters ;
      private string Combo_organisationid_Htmltemplate ;
      private string Combo_organisationid_Multiplevaluestype ;
      private string Combo_organisationid_Loadingdata ;
      private string Combo_organisationid_Noresultsfound ;
      private string Combo_organisationid_Emptyitemtext ;
      private string Combo_organisationid_Onlyselectedvalues ;
      private string Combo_organisationid_Selectalltext ;
      private string Combo_organisationid_Multiplevaluesseparator ;
      private string Combo_organisationid_Addnewoptiontext ;
      private string Combo_locationid_Objectcall ;
      private string Combo_locationid_Class ;
      private string Combo_locationid_Icontype ;
      private string Combo_locationid_Icon ;
      private string Combo_locationid_Tooltip ;
      private string Combo_locationid_Selectedvalue_set ;
      private string Combo_locationid_Selectedtext_set ;
      private string Combo_locationid_Selectedtext_get ;
      private string Combo_locationid_Gamoauthtoken ;
      private string Combo_locationid_Ddointernalname ;
      private string Combo_locationid_Titlecontrolalign ;
      private string Combo_locationid_Dropdownoptionstype ;
      private string Combo_locationid_Titlecontrolidtoreplace ;
      private string Combo_locationid_Datalisttype ;
      private string Combo_locationid_Datalistfixedvalues ;
      private string Combo_locationid_Datalistprocparametersprefix ;
      private string Combo_locationid_Remoteservicesparameters ;
      private string Combo_locationid_Htmltemplate ;
      private string Combo_locationid_Multiplevaluestype ;
      private string Combo_locationid_Loadingdata ;
      private string Combo_locationid_Noresultsfound ;
      private string Combo_locationid_Emptyitemtext ;
      private string Combo_locationid_Onlyselectedvalues ;
      private string Combo_locationid_Selectalltext ;
      private string Combo_locationid_Multiplevaluesseparator ;
      private string Combo_locationid_Addnewoptiontext ;
      private string hsh ;
      private string sMode114 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_organisationid_Emptyitem ;
      private bool Combo_locationid_Emptyitem ;
      private bool Combo_organisationid_Enabled ;
      private bool Combo_organisationid_Visible ;
      private bool Combo_organisationid_Allowmultipleselection ;
      private bool Combo_organisationid_Isgriditem ;
      private bool Combo_organisationid_Hasdescription ;
      private bool Combo_organisationid_Includeonlyselectedoption ;
      private bool Combo_organisationid_Includeselectalloption ;
      private bool Combo_organisationid_Includeaddnewoption ;
      private bool Combo_locationid_Enabled ;
      private bool Combo_locationid_Visible ;
      private bool Combo_locationid_Allowmultipleselection ;
      private bool Combo_locationid_Isgriditem ;
      private bool Combo_locationid_Hasdescription ;
      private bool Combo_locationid_Includeonlyselectedoption ;
      private bool Combo_locationid_Includeselectalloption ;
      private bool Combo_locationid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV20Combo_DataJson ;
      private string Z585BulletinBoardBgColorCode ;
      private string A585BulletinBoardBgColorCode ;
      private string A13OrganisationName ;
      private string A31LocationName ;
      private string A591BulletinBoardName ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string Z13OrganisationName ;
      private string Z31LocationName ;
      private string Z591BulletinBoardName ;
      private Guid wcpOAV7BulletinBoardId ;
      private Guid Z574BulletinBoardId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid N11OrganisationId ;
      private Guid N29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV7BulletinBoardId ;
      private Guid AV21ComboOrganisationId ;
      private Guid AV25ComboLocationId ;
      private Guid A574BulletinBoardId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid AV14Insert_LocationId ;
      private Guid AV26Cond_OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_organisationid ;
      private GXUserControl ucCombo_locationid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16OrganisationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24LocationId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T001T4_A13OrganisationName ;
      private string[] T001T5_A31LocationName ;
      private Guid[] T001T6_A574BulletinBoardId ;
      private string[] T001T6_A13OrganisationName ;
      private string[] T001T6_A31LocationName ;
      private string[] T001T6_A585BulletinBoardBgColorCode ;
      private string[] T001T6_A586BulletinBoardForm ;
      private Guid[] T001T6_A11OrganisationId ;
      private Guid[] T001T6_A29LocationId ;
      private string[] T001T7_A13OrganisationName ;
      private string[] T001T8_A31LocationName ;
      private Guid[] T001T9_A574BulletinBoardId ;
      private Guid[] T001T3_A574BulletinBoardId ;
      private string[] T001T3_A585BulletinBoardBgColorCode ;
      private string[] T001T3_A586BulletinBoardForm ;
      private Guid[] T001T3_A11OrganisationId ;
      private Guid[] T001T3_A29LocationId ;
      private Guid[] T001T10_A574BulletinBoardId ;
      private Guid[] T001T11_A574BulletinBoardId ;
      private Guid[] T001T2_A574BulletinBoardId ;
      private string[] T001T2_A585BulletinBoardBgColorCode ;
      private string[] T001T2_A586BulletinBoardForm ;
      private Guid[] T001T2_A11OrganisationId ;
      private Guid[] T001T2_A29LocationId ;
      private string[] T001T15_A13OrganisationName ;
      private string[] T001T16_A31LocationName ;
      private Guid[] T001T17_A575MemoId ;
      private Guid[] T001T18_A574BulletinBoardId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_bulletinboard__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_bulletinboard__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_bulletinboard__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001T2;
       prmT001T2 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T3;
       prmT001T3 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T4;
       prmT001T4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T5;
       prmT001T5 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T6;
       prmT001T6 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T7;
       prmT001T7 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T8;
       prmT001T8 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T9;
       prmT001T9 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T10;
       prmT001T10 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T11;
       prmT001T11 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T12;
       prmT001T12 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("BulletinBoardBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("BulletinBoardForm",GXType.Char,20,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T13;
       prmT001T13 = new Object[] {
       new ParDef("BulletinBoardBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("BulletinBoardForm",GXType.Char,20,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T14;
       prmT001T14 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T15;
       prmT001T15 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T16;
       prmT001T16 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T17;
       prmT001T17 = new Object[] {
       new ParDef("BulletinBoardId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001T18;
       prmT001T18 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001T2", "SELECT BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId  FOR UPDATE OF Trn_BulletinBoard NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001T2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T3", "SELECT BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T4", "SELECT OrganisationName FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T5", "SELECT LocationName FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T6", "SELECT TM1.BulletinBoardId, T2.OrganisationName, T3.LocationName, TM1.BulletinBoardBgColorCode, TM1.BulletinBoardForm, TM1.OrganisationId, TM1.LocationId FROM ((Trn_BulletinBoard TM1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = TM1.OrganisationId) INNER JOIN Trn_Location T3 ON T3.LocationId = TM1.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.BulletinBoardId = :BulletinBoardId ORDER BY TM1.BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T7", "SELECT OrganisationName FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T8", "SELECT LocationName FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T9", "SELECT BulletinBoardId FROM Trn_BulletinBoard WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T10", "SELECT BulletinBoardId FROM Trn_BulletinBoard WHERE ( BulletinBoardId > :BulletinBoardId) ORDER BY BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001T11", "SELECT BulletinBoardId FROM Trn_BulletinBoard WHERE ( BulletinBoardId < :BulletinBoardId) ORDER BY BulletinBoardId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001T12", "SAVEPOINT gxupdate;INSERT INTO Trn_BulletinBoard(BulletinBoardId, BulletinBoardBgColorCode, BulletinBoardForm, OrganisationId, LocationId) VALUES(:BulletinBoardId, :BulletinBoardBgColorCode, :BulletinBoardForm, :OrganisationId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001T12)
          ,new CursorDef("T001T13", "SAVEPOINT gxupdate;UPDATE Trn_BulletinBoard SET BulletinBoardBgColorCode=:BulletinBoardBgColorCode, BulletinBoardForm=:BulletinBoardForm, OrganisationId=:OrganisationId, LocationId=:LocationId  WHERE BulletinBoardId = :BulletinBoardId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001T13)
          ,new CursorDef("T001T14", "SAVEPOINT gxupdate;DELETE FROM Trn_BulletinBoard  WHERE BulletinBoardId = :BulletinBoardId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001T14)
          ,new CursorDef("T001T15", "SELECT OrganisationName FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T16", "SELECT LocationName FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001T17", "SELECT MemoId FROM Trn_Memo WHERE BulletinBoardId = :BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001T18", "SELECT BulletinBoardId FROM Trn_BulletinBoard ORDER BY BulletinBoardId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T18,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
