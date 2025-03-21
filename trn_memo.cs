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
   public class trn_memo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A568MemoCategoryId = StringUtil.StrToGuid( GetPar( "MemoCategoryId"));
            AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A568MemoCategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A555SG_LocationId = StringUtil.StrToGuid( GetPar( "SG_LocationId"));
            AssignAttri("", false, "A555SG_LocationId", A555SG_LocationId.ToString());
            A556SG_OrganisationId = StringUtil.StrToGuid( GetPar( "SG_OrganisationId"));
            AssignAttri("", false, "A556SG_OrganisationId", A556SG_OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A62ResidentId, A555SG_LocationId, A556SG_OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_memo.aspx")), "trn_memo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_memo.aspx")))) ;
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
                  AV7MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
                  AssignAttri("", false, "AV7MemoId", AV7MemoId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vMEMOID", GetSecureSignedToken( "", AV7MemoId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Memo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMemoCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_memo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_MemoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MemoId = aP1_MemoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbResidentSalutation = new GXCombobox();
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
            return "trn_memo_Execute" ;
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
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp("", false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedmemocategoryid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmemocategoryid_Internalname, context.GetMessage( "Category", ""), "", "", lblTextblockmemocategoryid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_memocategoryid.SetProperty("Caption", Combo_memocategoryid_Caption);
         ucCombo_memocategoryid.SetProperty("Cls", Combo_memocategoryid_Cls);
         ucCombo_memocategoryid.SetProperty("DataListProc", Combo_memocategoryid_Datalistproc);
         ucCombo_memocategoryid.SetProperty("DataListProcParametersPrefix", Combo_memocategoryid_Datalistprocparametersprefix);
         ucCombo_memocategoryid.SetProperty("EmptyItem", Combo_memocategoryid_Emptyitem);
         ucCombo_memocategoryid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_memocategoryid.SetProperty("DropDownOptionsData", AV24MemoCategoryId_Data);
         ucCombo_memocategoryid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_memocategoryid_Internalname, "COMBO_MEMOCATEGORYIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoCategoryId_Internalname, context.GetMessage( "Memo Category Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoCategoryId_Internalname, A568MemoCategoryId.ToString(), A568MemoCategoryId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", edtMemoCategoryId_Visible, edtMemoCategoryId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoTitle_Internalname, A576MemoTitle, StringUtil.RTrim( context.localUtil.Format( A576MemoTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoDescription_Internalname, A577MemoDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, 1, edtMemoDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoImage_Internalname, A578MemoImage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtMemoImage_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoDocument_Internalname, A579MemoDocument, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtMemoDocument_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_label_element( context, edtMemoStartDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoStartDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoStartDateTime_Internalname, context.localUtil.TToC( A587MemoStartDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A587MemoStartDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoStartDateTime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMemoStartDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoStartDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoStartDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_label_element( context, edtMemoEndDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoEndDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoEndDateTime_Internalname, context.localUtil.TToC( A588MemoEndDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A588MemoEndDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoEndDateTime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMemoEndDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoEndDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoEndDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A589MemoDuration), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMemoDuration_Enabled!=0) ? context.localUtil.Format( (decimal)(A589MemoDuration), "ZZZ9") : context.localUtil.Format( (decimal)(A589MemoDuration), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoDuration_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_label_element( context, edtMemoRemoveDate_Internalname, context.GetMessage( "Remove Date", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoRemoveDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoRemoveDate_Internalname, context.localUtil.Format(A590MemoRemoveDate, "99/99/99"), context.localUtil.Format( A590MemoRemoveDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoRemoveDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtMemoRemoveDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoRemoveDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoRemoveDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Memo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_memocategoryid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombomemocategoryid_Internalname, AV25ComboMemoCategoryId.ToString(), AV25ComboMemoCategoryId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomemocategoryid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomemocategoryid_Visible, edtavCombomemocategoryid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoId_Internalname, A575MemoId.ToString(), A575MemoId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoId_Jsonclick, 0, "Attribute", "", "", "", "", edtMemoId_Visible, edtMemoId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Memo.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbResidentSalutation.Visible, cmbResidentSalutation.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_Trn_Memo.htm");
         cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         AssignProp("", false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGivenName_Visible, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Memo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentLastName_Visible, edtResidentLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Memo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, edtResidentGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Memo.htm");
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
         E111U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMEMOCATEGORYID_DATA"), AV24MemoCategoryId_Data);
               /* Read saved values. */
               Z575MemoId = StringUtil.StrToGuid( cgiGet( "Z575MemoId"));
               Z576MemoTitle = cgiGet( "Z576MemoTitle");
               Z577MemoDescription = cgiGet( "Z577MemoDescription");
               Z578MemoImage = cgiGet( "Z578MemoImage");
               n578MemoImage = (String.IsNullOrEmpty(StringUtil.RTrim( A578MemoImage)) ? true : false);
               Z579MemoDocument = cgiGet( "Z579MemoDocument");
               n579MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A579MemoDocument)) ? true : false);
               Z587MemoStartDateTime = context.localUtil.CToT( cgiGet( "Z587MemoStartDateTime"), 0);
               n587MemoStartDateTime = ((DateTime.MinValue==A587MemoStartDateTime) ? true : false);
               Z588MemoEndDateTime = context.localUtil.CToT( cgiGet( "Z588MemoEndDateTime"), 0);
               n588MemoEndDateTime = ((DateTime.MinValue==A588MemoEndDateTime) ? true : false);
               Z589MemoDuration = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z589MemoDuration"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n589MemoDuration = ((0==A589MemoDuration) ? true : false);
               Z590MemoRemoveDate = context.localUtil.CToD( cgiGet( "Z590MemoRemoveDate"), 0);
               Z592MemoBgColorCode = cgiGet( "Z592MemoBgColorCode");
               Z593MemoForm = cgiGet( "Z593MemoForm");
               Z568MemoCategoryId = StringUtil.StrToGuid( cgiGet( "Z568MemoCategoryId"));
               Z62ResidentId = StringUtil.StrToGuid( cgiGet( "Z62ResidentId"));
               Z555SG_LocationId = StringUtil.StrToGuid( cgiGet( "Z555SG_LocationId"));
               Z556SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "Z556SG_OrganisationId"));
               A592MemoBgColorCode = cgiGet( "Z592MemoBgColorCode");
               A593MemoForm = cgiGet( "Z593MemoForm");
               A555SG_LocationId = StringUtil.StrToGuid( cgiGet( "Z555SG_LocationId"));
               A556SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "Z556SG_OrganisationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N568MemoCategoryId = StringUtil.StrToGuid( cgiGet( "N568MemoCategoryId"));
               N62ResidentId = StringUtil.StrToGuid( cgiGet( "N62ResidentId"));
               N556SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "N556SG_OrganisationId"));
               N555SG_LocationId = StringUtil.StrToGuid( cgiGet( "N555SG_LocationId"));
               AV7MemoId = StringUtil.StrToGuid( cgiGet( "vMEMOID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_MemoCategoryId = StringUtil.StrToGuid( cgiGet( "vINSERT_MEMOCATEGORYID"));
               AV26Insert_ResidentId = StringUtil.StrToGuid( cgiGet( "vINSERT_RESIDENTID"));
               AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_ORGANISATIONID"));
               A556SG_OrganisationId = StringUtil.StrToGuid( cgiGet( "SG_ORGANISATIONID"));
               AV30Insert_SG_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_LOCATIONID"));
               A555SG_LocationId = StringUtil.StrToGuid( cgiGet( "SG_LOCATIONID"));
               A592MemoBgColorCode = cgiGet( "MEMOBGCOLORCODE");
               A593MemoForm = cgiGet( "MEMOFORM");
               A569MemoCategoryName = cgiGet( "MEMOCATEGORYNAME");
               AV31Pgmname = cgiGet( "vPGMNAME");
               Combo_memocategoryid_Objectcall = cgiGet( "COMBO_MEMOCATEGORYID_Objectcall");
               Combo_memocategoryid_Class = cgiGet( "COMBO_MEMOCATEGORYID_Class");
               Combo_memocategoryid_Icontype = cgiGet( "COMBO_MEMOCATEGORYID_Icontype");
               Combo_memocategoryid_Icon = cgiGet( "COMBO_MEMOCATEGORYID_Icon");
               Combo_memocategoryid_Caption = cgiGet( "COMBO_MEMOCATEGORYID_Caption");
               Combo_memocategoryid_Tooltip = cgiGet( "COMBO_MEMOCATEGORYID_Tooltip");
               Combo_memocategoryid_Cls = cgiGet( "COMBO_MEMOCATEGORYID_Cls");
               Combo_memocategoryid_Selectedvalue_set = cgiGet( "COMBO_MEMOCATEGORYID_Selectedvalue_set");
               Combo_memocategoryid_Selectedvalue_get = cgiGet( "COMBO_MEMOCATEGORYID_Selectedvalue_get");
               Combo_memocategoryid_Selectedtext_set = cgiGet( "COMBO_MEMOCATEGORYID_Selectedtext_set");
               Combo_memocategoryid_Selectedtext_get = cgiGet( "COMBO_MEMOCATEGORYID_Selectedtext_get");
               Combo_memocategoryid_Gamoauthtoken = cgiGet( "COMBO_MEMOCATEGORYID_Gamoauthtoken");
               Combo_memocategoryid_Ddointernalname = cgiGet( "COMBO_MEMOCATEGORYID_Ddointernalname");
               Combo_memocategoryid_Titlecontrolalign = cgiGet( "COMBO_MEMOCATEGORYID_Titlecontrolalign");
               Combo_memocategoryid_Dropdownoptionstype = cgiGet( "COMBO_MEMOCATEGORYID_Dropdownoptionstype");
               Combo_memocategoryid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Enabled"));
               Combo_memocategoryid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Visible"));
               Combo_memocategoryid_Titlecontrolidtoreplace = cgiGet( "COMBO_MEMOCATEGORYID_Titlecontrolidtoreplace");
               Combo_memocategoryid_Datalisttype = cgiGet( "COMBO_MEMOCATEGORYID_Datalisttype");
               Combo_memocategoryid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Allowmultipleselection"));
               Combo_memocategoryid_Datalistfixedvalues = cgiGet( "COMBO_MEMOCATEGORYID_Datalistfixedvalues");
               Combo_memocategoryid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Isgriditem"));
               Combo_memocategoryid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Hasdescription"));
               Combo_memocategoryid_Datalistproc = cgiGet( "COMBO_MEMOCATEGORYID_Datalistproc");
               Combo_memocategoryid_Datalistprocparametersprefix = cgiGet( "COMBO_MEMOCATEGORYID_Datalistprocparametersprefix");
               Combo_memocategoryid_Remoteservicesparameters = cgiGet( "COMBO_MEMOCATEGORYID_Remoteservicesparameters");
               Combo_memocategoryid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MEMOCATEGORYID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_memocategoryid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Includeonlyselectedoption"));
               Combo_memocategoryid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Includeselectalloption"));
               Combo_memocategoryid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Emptyitem"));
               Combo_memocategoryid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MEMOCATEGORYID_Includeaddnewoption"));
               Combo_memocategoryid_Htmltemplate = cgiGet( "COMBO_MEMOCATEGORYID_Htmltemplate");
               Combo_memocategoryid_Multiplevaluestype = cgiGet( "COMBO_MEMOCATEGORYID_Multiplevaluestype");
               Combo_memocategoryid_Loadingdata = cgiGet( "COMBO_MEMOCATEGORYID_Loadingdata");
               Combo_memocategoryid_Noresultsfound = cgiGet( "COMBO_MEMOCATEGORYID_Noresultsfound");
               Combo_memocategoryid_Emptyitemtext = cgiGet( "COMBO_MEMOCATEGORYID_Emptyitemtext");
               Combo_memocategoryid_Onlyselectedvalues = cgiGet( "COMBO_MEMOCATEGORYID_Onlyselectedvalues");
               Combo_memocategoryid_Selectalltext = cgiGet( "COMBO_MEMOCATEGORYID_Selectalltext");
               Combo_memocategoryid_Multiplevaluesseparator = cgiGet( "COMBO_MEMOCATEGORYID_Multiplevaluesseparator");
               Combo_memocategoryid_Addnewoptiontext = cgiGet( "COMBO_MEMOCATEGORYID_Addnewoptiontext");
               Combo_memocategoryid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MEMOCATEGORYID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtMemoCategoryId_Internalname), "") == 0 )
               {
                  A568MemoCategoryId = Guid.Empty;
                  AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
               }
               else
               {
                  try
                  {
                     A568MemoCategoryId = StringUtil.StrToGuid( cgiGet( edtMemoCategoryId_Internalname));
                     AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MEMOCATEGORYID");
                     AnyError = 1;
                     GX_FocusControl = edtMemoCategoryId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A576MemoTitle = cgiGet( edtMemoTitle_Internalname);
               AssignAttri("", false, "A576MemoTitle", A576MemoTitle);
               A577MemoDescription = cgiGet( edtMemoDescription_Internalname);
               AssignAttri("", false, "A577MemoDescription", A577MemoDescription);
               A578MemoImage = cgiGet( edtMemoImage_Internalname);
               n578MemoImage = false;
               AssignAttri("", false, "A578MemoImage", A578MemoImage);
               n578MemoImage = (String.IsNullOrEmpty(StringUtil.RTrim( A578MemoImage)) ? true : false);
               A579MemoDocument = cgiGet( edtMemoDocument_Internalname);
               n579MemoDocument = false;
               AssignAttri("", false, "A579MemoDocument", A579MemoDocument);
               n579MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A579MemoDocument)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtMemoStartDateTime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Memo Start Date Time", "")}), 1, "MEMOSTARTDATETIME");
                  AnyError = 1;
                  GX_FocusControl = edtMemoStartDateTime_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
                  n587MemoStartDateTime = false;
                  AssignAttri("", false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A587MemoStartDateTime = context.localUtil.CToT( cgiGet( edtMemoStartDateTime_Internalname));
                  n587MemoStartDateTime = false;
                  AssignAttri("", false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n587MemoStartDateTime = ((DateTime.MinValue==A587MemoStartDateTime) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtMemoEndDateTime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Memo End Date Time", "")}), 1, "MEMOENDDATETIME");
                  AnyError = 1;
                  GX_FocusControl = edtMemoEndDateTime_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
                  n588MemoEndDateTime = false;
                  AssignAttri("", false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A588MemoEndDateTime = context.localUtil.CToT( cgiGet( edtMemoEndDateTime_Internalname));
                  n588MemoEndDateTime = false;
                  AssignAttri("", false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n588MemoEndDateTime = ((DateTime.MinValue==A588MemoEndDateTime) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MEMODURATION");
                  AnyError = 1;
                  GX_FocusControl = edtMemoDuration_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A589MemoDuration = 0;
                  n589MemoDuration = false;
                  AssignAttri("", false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
               }
               else
               {
                  A589MemoDuration = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n589MemoDuration = false;
                  AssignAttri("", false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
               }
               n589MemoDuration = ((0==A589MemoDuration) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtMemoRemoveDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Memo Remove Date", "")}), 1, "MEMOREMOVEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtMemoRemoveDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A590MemoRemoveDate = DateTime.MinValue;
                  AssignAttri("", false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
               }
               else
               {
                  A590MemoRemoveDate = context.localUtil.CToD( cgiGet( edtMemoRemoveDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
               }
               if ( StringUtil.StrCmp(cgiGet( edtResidentId_Internalname), "") == 0 )
               {
                  A62ResidentId = Guid.Empty;
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               }
               else
               {
                  try
                  {
                     A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
                     AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               AV25ComboMemoCategoryId = StringUtil.StrToGuid( cgiGet( edtavCombomemocategoryid_Internalname));
               AssignAttri("", false, "AV25ComboMemoCategoryId", AV25ComboMemoCategoryId.ToString());
               if ( StringUtil.StrCmp(cgiGet( edtMemoId_Internalname), "") == 0 )
               {
                  A575MemoId = Guid.Empty;
                  AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
               }
               else
               {
                  try
                  {
                     A575MemoId = StringUtil.StrToGuid( cgiGet( edtMemoId_Internalname));
                     AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MEMOID");
                     AnyError = 1;
                     GX_FocusControl = edtMemoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
               A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
               AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
               A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
               AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
               A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
               AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
               A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
               AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Memo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("MemoBgColorCode", StringUtil.RTrim( context.localUtil.Format( A592MemoBgColorCode, "")));
               forbiddenHiddens.Add("MemoForm", StringUtil.RTrim( context.localUtil.Format( A593MemoForm, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A575MemoId != Z575MemoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_memo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A575MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
                  AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7MemoId) )
                  {
                     A575MemoId = AV7MemoId;
                     AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A575MemoId) && ( Gx_BScreen == 0 ) )
                     {
                        A575MemoId = Guid.NewGuid( );
                        AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
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
                     sMode115 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7MemoId) )
                     {
                        A575MemoId = AV7MemoId;
                        AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A575MemoId) && ( Gx_BScreen == 0 ) )
                        {
                           A575MemoId = Guid.NewGuid( );
                           AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                        }
                     }
                     Gx_mode = sMode115;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound115 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MEMOID");
                        AnyError = 1;
                        GX_FocusControl = edtMemoId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_MEMOCATEGORYID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_memocategoryid.Onoptionclicked */
                           E121U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E131U2 ();
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
            E131U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1U115( ) ;
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
            DisableAttributes1U115( ) ;
         }
         AssignProp("", false, edtavCombomemocategoryid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomemocategoryid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1U0( )
      {
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1U115( ) ;
            }
            else
            {
               CheckExtendedTable1U115( ) ;
               CloseExtendedTableCursors1U115( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1U0( )
      {
      }

      protected void E111U2( )
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
         Combo_memocategoryid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "GAMOAuthToken", Combo_memocategoryid_Gamoauthtoken);
         edtMemoCategoryId_Visible = 0;
         AssignProp("", false, edtMemoCategoryId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMemoCategoryId_Visible), 5, 0), true);
         AV25ComboMemoCategoryId = Guid.Empty;
         AssignAttri("", false, "AV25ComboMemoCategoryId", AV25ComboMemoCategoryId.ToString());
         edtavCombomemocategoryid_Visible = 0;
         AssignProp("", false, edtavCombomemocategoryid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomemocategoryid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMEMOCATEGORYID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "MemoCategoryId") == 0 )
               {
                  AV14Insert_MemoCategoryId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_MemoCategoryId", AV14Insert_MemoCategoryId.ToString());
                  if ( ! (Guid.Empty==AV14Insert_MemoCategoryId) )
                  {
                     AV25ComboMemoCategoryId = AV14Insert_MemoCategoryId;
                     AssignAttri("", false, "AV25ComboMemoCategoryId", AV25ComboMemoCategoryId.ToString());
                     Combo_memocategoryid_Selectedvalue_set = StringUtil.Trim( AV25ComboMemoCategoryId.ToString());
                     ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "SelectedValue_set", Combo_memocategoryid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new trn_memoloaddvcombo(context ).execute(  "MemoCategoryId",  "GET",  false,  AV7MemoId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_memocategoryid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "SelectedText_set", Combo_memocategoryid_Selectedtext_set);
                     Combo_memocategoryid_Enabled = false;
                     ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_memocategoryid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ResidentId") == 0 )
               {
                  AV26Insert_ResidentId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV26Insert_ResidentId", AV26Insert_ResidentId.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV29Insert_SG_OrganisationId", AV29Insert_SG_OrganisationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV30Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV30Insert_SG_LocationId", AV30Insert_SG_LocationId.ToString());
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
         edtMemoId_Visible = 0;
         AssignProp("", false, edtMemoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMemoId_Visible), 5, 0), true);
         cmbResidentSalutation.Visible = 0;
         AssignProp("", false, cmbResidentSalutation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Visible), 5, 0), true);
         edtResidentGivenName_Visible = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Visible), 5, 0), true);
         edtResidentLastName_Visible = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
      }

      protected void E131U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_memoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E121U2( )
      {
         /* Combo_memocategoryid_Onoptionclicked Routine */
         returnInSub = false;
         AV25ComboMemoCategoryId = StringUtil.StrToGuid( Combo_memocategoryid_Selectedvalue_get);
         AssignAttri("", false, "AV25ComboMemoCategoryId", AV25ComboMemoCategoryId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMEMOCATEGORYID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new trn_memoloaddvcombo(context ).execute(  "MemoCategoryId",  Gx_mode,  false,  AV7MemoId,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_memocategoryid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "SelectedValue_set", Combo_memocategoryid_Selectedvalue_set);
         Combo_memocategoryid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "SelectedText_set", Combo_memocategoryid_Selectedtext_set);
         AV25ComboMemoCategoryId = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV25ComboMemoCategoryId", AV25ComboMemoCategoryId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_memocategoryid_Enabled = false;
            ucCombo_memocategoryid.SendProperty(context, "", false, Combo_memocategoryid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_memocategoryid_Enabled));
         }
      }

      protected void ZM1U115( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z576MemoTitle = T001U3_A576MemoTitle[0];
               Z577MemoDescription = T001U3_A577MemoDescription[0];
               Z578MemoImage = T001U3_A578MemoImage[0];
               Z579MemoDocument = T001U3_A579MemoDocument[0];
               Z587MemoStartDateTime = T001U3_A587MemoStartDateTime[0];
               Z588MemoEndDateTime = T001U3_A588MemoEndDateTime[0];
               Z589MemoDuration = T001U3_A589MemoDuration[0];
               Z590MemoRemoveDate = T001U3_A590MemoRemoveDate[0];
               Z592MemoBgColorCode = T001U3_A592MemoBgColorCode[0];
               Z593MemoForm = T001U3_A593MemoForm[0];
               Z568MemoCategoryId = T001U3_A568MemoCategoryId[0];
               Z62ResidentId = T001U3_A62ResidentId[0];
               Z555SG_LocationId = T001U3_A555SG_LocationId[0];
               Z556SG_OrganisationId = T001U3_A556SG_OrganisationId[0];
            }
            else
            {
               Z576MemoTitle = A576MemoTitle;
               Z577MemoDescription = A577MemoDescription;
               Z578MemoImage = A578MemoImage;
               Z579MemoDocument = A579MemoDocument;
               Z587MemoStartDateTime = A587MemoStartDateTime;
               Z588MemoEndDateTime = A588MemoEndDateTime;
               Z589MemoDuration = A589MemoDuration;
               Z590MemoRemoveDate = A590MemoRemoveDate;
               Z592MemoBgColorCode = A592MemoBgColorCode;
               Z593MemoForm = A593MemoForm;
               Z568MemoCategoryId = A568MemoCategoryId;
               Z62ResidentId = A62ResidentId;
               Z555SG_LocationId = A555SG_LocationId;
               Z556SG_OrganisationId = A556SG_OrganisationId;
            }
         }
         if ( GX_JID == -19 )
         {
            Z575MemoId = A575MemoId;
            Z576MemoTitle = A576MemoTitle;
            Z577MemoDescription = A577MemoDescription;
            Z578MemoImage = A578MemoImage;
            Z579MemoDocument = A579MemoDocument;
            Z587MemoStartDateTime = A587MemoStartDateTime;
            Z588MemoEndDateTime = A588MemoEndDateTime;
            Z589MemoDuration = A589MemoDuration;
            Z590MemoRemoveDate = A590MemoRemoveDate;
            Z592MemoBgColorCode = A592MemoBgColorCode;
            Z593MemoForm = A593MemoForm;
            Z568MemoCategoryId = A568MemoCategoryId;
            Z62ResidentId = A62ResidentId;
            Z555SG_LocationId = A555SG_LocationId;
            Z556SG_OrganisationId = A556SG_OrganisationId;
            Z569MemoCategoryName = A569MemoCategoryName;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV31Pgmname = "Trn_Memo";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            edtMemoId_Enabled = 0;
            AssignProp("", false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         else
         {
            edtMemoId_Enabled = 1;
            AssignProp("", false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            edtMemoId_Enabled = 0;
            AssignProp("", false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_MemoCategoryId) )
         {
            edtMemoCategoryId_Enabled = 0;
            AssignProp("", false, edtMemoCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCategoryId_Enabled), 5, 0), true);
         }
         else
         {
            edtMemoCategoryId_Enabled = 1;
            AssignProp("", false, edtMemoCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCategoryId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV26Insert_ResidentId) )
         {
            edtResidentId_Enabled = 0;
            AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentId_Enabled = 1;
            AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV30Insert_SG_LocationId) )
         {
            A555SG_LocationId = AV30Insert_SG_LocationId;
            AssignAttri("", false, "A555SG_LocationId", A555SG_LocationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV29Insert_SG_OrganisationId) )
         {
            A556SG_OrganisationId = AV29Insert_SG_OrganisationId;
            AssignAttri("", false, "A556SG_OrganisationId", A556SG_OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV26Insert_ResidentId) )
         {
            A62ResidentId = AV26Insert_ResidentId;
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_MemoCategoryId) )
         {
            A568MemoCategoryId = AV14Insert_MemoCategoryId;
            AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
         }
         else
         {
            A568MemoCategoryId = AV25ComboMemoCategoryId;
            AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
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
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            A575MemoId = AV7MemoId;
            AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A575MemoId) && ( Gx_BScreen == 0 ) )
            {
               A575MemoId = Guid.NewGuid( );
               AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001U5 */
            pr_default.execute(3, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
            A72ResidentSalutation = T001U5_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001U5_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001U5_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A71ResidentGUID = T001U5_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            pr_default.close(3);
            /* Using cursor T001U4 */
            pr_default.execute(2, new Object[] {A568MemoCategoryId});
            A569MemoCategoryName = T001U4_A569MemoCategoryName[0];
            pr_default.close(2);
         }
      }

      protected void Load1U115( )
      {
         /* Using cursor T001U6 */
         pr_default.execute(4, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound115 = 1;
            A29LocationId = T001U6_A29LocationId[0];
            A11OrganisationId = T001U6_A11OrganisationId[0];
            A569MemoCategoryName = T001U6_A569MemoCategoryName[0];
            A576MemoTitle = T001U6_A576MemoTitle[0];
            AssignAttri("", false, "A576MemoTitle", A576MemoTitle);
            A577MemoDescription = T001U6_A577MemoDescription[0];
            AssignAttri("", false, "A577MemoDescription", A577MemoDescription);
            A578MemoImage = T001U6_A578MemoImage[0];
            n578MemoImage = T001U6_n578MemoImage[0];
            AssignAttri("", false, "A578MemoImage", A578MemoImage);
            A579MemoDocument = T001U6_A579MemoDocument[0];
            n579MemoDocument = T001U6_n579MemoDocument[0];
            AssignAttri("", false, "A579MemoDocument", A579MemoDocument);
            A587MemoStartDateTime = T001U6_A587MemoStartDateTime[0];
            n587MemoStartDateTime = T001U6_n587MemoStartDateTime[0];
            AssignAttri("", false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A588MemoEndDateTime = T001U6_A588MemoEndDateTime[0];
            n588MemoEndDateTime = T001U6_n588MemoEndDateTime[0];
            AssignAttri("", false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A589MemoDuration = T001U6_A589MemoDuration[0];
            n589MemoDuration = T001U6_n589MemoDuration[0];
            AssignAttri("", false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
            A590MemoRemoveDate = T001U6_A590MemoRemoveDate[0];
            AssignAttri("", false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
            A72ResidentSalutation = T001U6_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001U6_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001U6_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A71ResidentGUID = T001U6_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A592MemoBgColorCode = T001U6_A592MemoBgColorCode[0];
            A593MemoForm = T001U6_A593MemoForm[0];
            A568MemoCategoryId = T001U6_A568MemoCategoryId[0];
            AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
            A62ResidentId = T001U6_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A555SG_LocationId = T001U6_A555SG_LocationId[0];
            A556SG_OrganisationId = T001U6_A556SG_OrganisationId[0];
            ZM1U115( -19) ;
         }
         pr_default.close(4);
         OnLoadActions1U115( ) ;
      }

      protected void OnLoadActions1U115( )
      {
      }

      protected void CheckExtendedTable1U115( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001U4 */
         pr_default.execute(2, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_MemoCategory", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEMOCATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtMemoCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A569MemoCategoryName = T001U4_A569MemoCategoryName[0];
         pr_default.close(2);
         /* Using cursor T001U5 */
         pr_default.execute(3, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001U5_A72ResidentSalutation[0];
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = T001U5_A64ResidentGivenName[0];
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001U5_A65ResidentLastName[0];
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A71ResidentGUID = T001U5_A71ResidentGUID[0];
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1U115( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( Guid A568MemoCategoryId )
      {
         /* Using cursor T001U7 */
         pr_default.execute(5, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_MemoCategory", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEMOCATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtMemoCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A569MemoCategoryName = T001U7_A569MemoCategoryName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A569MemoCategoryName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_21( Guid A62ResidentId ,
                                Guid A555SG_LocationId ,
                                Guid A556SG_OrganisationId )
      {
         /* Using cursor T001U8 */
         pr_default.execute(6, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001U8_A72ResidentSalutation[0];
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = T001U8_A64ResidentGivenName[0];
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001U8_A65ResidentLastName[0];
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A71ResidentGUID = T001U8_A71ResidentGUID[0];
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A72ResidentSalutation))+"\""+","+"\""+GXUtil.EncodeJSConstant( A64ResidentGivenName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A65ResidentLastName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A71ResidentGUID)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1U115( )
      {
         /* Using cursor T001U9 */
         pr_default.execute(7, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound115 = 1;
         }
         else
         {
            RcdFound115 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001U3 */
         pr_default.execute(1, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U115( 19) ;
            RcdFound115 = 1;
            A575MemoId = T001U3_A575MemoId[0];
            AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
            A576MemoTitle = T001U3_A576MemoTitle[0];
            AssignAttri("", false, "A576MemoTitle", A576MemoTitle);
            A577MemoDescription = T001U3_A577MemoDescription[0];
            AssignAttri("", false, "A577MemoDescription", A577MemoDescription);
            A578MemoImage = T001U3_A578MemoImage[0];
            n578MemoImage = T001U3_n578MemoImage[0];
            AssignAttri("", false, "A578MemoImage", A578MemoImage);
            A579MemoDocument = T001U3_A579MemoDocument[0];
            n579MemoDocument = T001U3_n579MemoDocument[0];
            AssignAttri("", false, "A579MemoDocument", A579MemoDocument);
            A587MemoStartDateTime = T001U3_A587MemoStartDateTime[0];
            n587MemoStartDateTime = T001U3_n587MemoStartDateTime[0];
            AssignAttri("", false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A588MemoEndDateTime = T001U3_A588MemoEndDateTime[0];
            n588MemoEndDateTime = T001U3_n588MemoEndDateTime[0];
            AssignAttri("", false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A589MemoDuration = T001U3_A589MemoDuration[0];
            n589MemoDuration = T001U3_n589MemoDuration[0];
            AssignAttri("", false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
            A590MemoRemoveDate = T001U3_A590MemoRemoveDate[0];
            AssignAttri("", false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
            A592MemoBgColorCode = T001U3_A592MemoBgColorCode[0];
            A593MemoForm = T001U3_A593MemoForm[0];
            A568MemoCategoryId = T001U3_A568MemoCategoryId[0];
            AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
            A62ResidentId = T001U3_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A555SG_LocationId = T001U3_A555SG_LocationId[0];
            A556SG_OrganisationId = T001U3_A556SG_OrganisationId[0];
            Z575MemoId = A575MemoId;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1U115( ) ;
            if ( AnyError == 1 )
            {
               RcdFound115 = 0;
               InitializeNonKey1U115( ) ;
            }
            Gx_mode = sMode115;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound115 = 0;
            InitializeNonKey1U115( ) ;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode115;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U115( ) ;
         if ( RcdFound115 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound115 = 0;
         /* Using cursor T001U10 */
         pr_default.execute(8, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001U10_A575MemoId[0], A575MemoId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001U10_A575MemoId[0], A575MemoId, 0) > 0 ) ) )
            {
               A575MemoId = T001U10_A575MemoId[0];
               AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
               RcdFound115 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound115 = 0;
         /* Using cursor T001U11 */
         pr_default.execute(9, new Object[] {A575MemoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001U11_A575MemoId[0], A575MemoId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001U11_A575MemoId[0], A575MemoId, 0) < 0 ) ) )
            {
               A575MemoId = T001U11_A575MemoId[0];
               AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
               RcdFound115 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1U115( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMemoCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1U115( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound115 == 1 )
            {
               if ( A575MemoId != Z575MemoId )
               {
                  A575MemoId = Z575MemoId;
                  AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MEMOID");
                  AnyError = 1;
                  GX_FocusControl = edtMemoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMemoCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1U115( ) ;
                  GX_FocusControl = edtMemoCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A575MemoId != Z575MemoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMemoCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1U115( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MEMOID");
                     AnyError = 1;
                     GX_FocusControl = edtMemoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMemoCategoryId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1U115( ) ;
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
         if ( A575MemoId != Z575MemoId )
         {
            A575MemoId = Z575MemoId;
            AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MEMOID");
            AnyError = 1;
            GX_FocusControl = edtMemoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMemoCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1U115( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001U2 */
            pr_default.execute(0, new Object[] {A575MemoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z576MemoTitle, T001U2_A576MemoTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z577MemoDescription, T001U2_A577MemoDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z578MemoImage, T001U2_A578MemoImage[0]) != 0 ) || ( StringUtil.StrCmp(Z579MemoDocument, T001U2_A579MemoDocument[0]) != 0 ) || ( Z587MemoStartDateTime != T001U2_A587MemoStartDateTime[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z588MemoEndDateTime != T001U2_A588MemoEndDateTime[0] ) || ( Z589MemoDuration != T001U2_A589MemoDuration[0] ) || ( DateTimeUtil.ResetTime ( Z590MemoRemoveDate ) != DateTimeUtil.ResetTime ( T001U2_A590MemoRemoveDate[0] ) ) || ( StringUtil.StrCmp(Z592MemoBgColorCode, T001U2_A592MemoBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z593MemoForm, T001U2_A593MemoForm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z568MemoCategoryId != T001U2_A568MemoCategoryId[0] ) || ( Z62ResidentId != T001U2_A62ResidentId[0] ) || ( Z555SG_LocationId != T001U2_A555SG_LocationId[0] ) || ( Z556SG_OrganisationId != T001U2_A556SG_OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z576MemoTitle, T001U2_A576MemoTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTitle");
                  GXUtil.WriteLogRaw("Old: ",Z576MemoTitle);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A576MemoTitle[0]);
               }
               if ( StringUtil.StrCmp(Z577MemoDescription, T001U2_A577MemoDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDescription");
                  GXUtil.WriteLogRaw("Old: ",Z577MemoDescription);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A577MemoDescription[0]);
               }
               if ( StringUtil.StrCmp(Z578MemoImage, T001U2_A578MemoImage[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoImage");
                  GXUtil.WriteLogRaw("Old: ",Z578MemoImage);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A578MemoImage[0]);
               }
               if ( StringUtil.StrCmp(Z579MemoDocument, T001U2_A579MemoDocument[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDocument");
                  GXUtil.WriteLogRaw("Old: ",Z579MemoDocument);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A579MemoDocument[0]);
               }
               if ( Z587MemoStartDateTime != T001U2_A587MemoStartDateTime[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoStartDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z587MemoStartDateTime);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A587MemoStartDateTime[0]);
               }
               if ( Z588MemoEndDateTime != T001U2_A588MemoEndDateTime[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoEndDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z588MemoEndDateTime);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A588MemoEndDateTime[0]);
               }
               if ( Z589MemoDuration != T001U2_A589MemoDuration[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDuration");
                  GXUtil.WriteLogRaw("Old: ",Z589MemoDuration);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A589MemoDuration[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z590MemoRemoveDate ) != DateTimeUtil.ResetTime ( T001U2_A590MemoRemoveDate[0] ) )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoRemoveDate");
                  GXUtil.WriteLogRaw("Old: ",Z590MemoRemoveDate);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A590MemoRemoveDate[0]);
               }
               if ( StringUtil.StrCmp(Z592MemoBgColorCode, T001U2_A592MemoBgColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoBgColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z592MemoBgColorCode);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A592MemoBgColorCode[0]);
               }
               if ( StringUtil.StrCmp(Z593MemoForm, T001U2_A593MemoForm[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoForm");
                  GXUtil.WriteLogRaw("Old: ",Z593MemoForm);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A593MemoForm[0]);
               }
               if ( Z568MemoCategoryId != T001U2_A568MemoCategoryId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoCategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z568MemoCategoryId);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A568MemoCategoryId[0]);
               }
               if ( Z62ResidentId != T001U2_A62ResidentId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"ResidentId");
                  GXUtil.WriteLogRaw("Old: ",Z62ResidentId);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A62ResidentId[0]);
               }
               if ( Z555SG_LocationId != T001U2_A555SG_LocationId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"SG_LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z555SG_LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A555SG_LocationId[0]);
               }
               if ( Z556SG_OrganisationId != T001U2_A556SG_OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"SG_OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z556SG_OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A556SG_OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Memo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U115( )
      {
         if ( ! IsAuthorized("trn_memo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U115( 0) ;
            CheckOptimisticConcurrency1U115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U12 */
                     pr_default.execute(10, new Object[] {A575MemoId, A576MemoTitle, A577MemoDescription, n578MemoImage, A578MemoImage, n579MemoDocument, A579MemoDocument, n587MemoStartDateTime, A587MemoStartDateTime, n588MemoEndDateTime, A588MemoEndDateTime, n589MemoDuration, A589MemoDuration, A590MemoRemoveDate, A592MemoBgColorCode, A593MemoForm, A568MemoCategoryId, A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
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
               Load1U115( ) ;
            }
            EndLevel1U115( ) ;
         }
         CloseExtendedTableCursors1U115( ) ;
      }

      protected void Update1U115( )
      {
         if ( ! IsAuthorized("trn_memo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U13 */
                     pr_default.execute(11, new Object[] {A576MemoTitle, A577MemoDescription, n578MemoImage, A578MemoImage, n579MemoDocument, A579MemoDocument, n587MemoStartDateTime, A587MemoStartDateTime, n588MemoEndDateTime, A588MemoEndDateTime, n589MemoDuration, A589MemoDuration, A590MemoRemoveDate, A592MemoBgColorCode, A593MemoForm, A568MemoCategoryId, A62ResidentId, A555SG_LocationId, A556SG_OrganisationId, A575MemoId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U115( ) ;
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
            EndLevel1U115( ) ;
         }
         CloseExtendedTableCursors1U115( ) ;
      }

      protected void DeferredUpdate1U115( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_memo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1U115( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U115( ) ;
            AfterConfirm1U115( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U115( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001U14 */
                  pr_default.execute(12, new Object[] {A575MemoId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
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
         sMode115 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1U115( ) ;
         Gx_mode = sMode115;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1U115( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001U15 */
            pr_default.execute(13, new Object[] {A568MemoCategoryId});
            A569MemoCategoryName = T001U15_A569MemoCategoryName[0];
            pr_default.close(13);
            /* Using cursor T001U16 */
            pr_default.execute(14, new Object[] {A62ResidentId, A555SG_LocationId, A556SG_OrganisationId});
            A72ResidentSalutation = T001U16_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001U16_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001U16_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A71ResidentGUID = T001U16_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            pr_default.close(14);
         }
      }

      protected void EndLevel1U115( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U115( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_memo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_memo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1U115( )
      {
         /* Scan By routine */
         /* Using cursor T001U17 */
         pr_default.execute(15);
         RcdFound115 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound115 = 1;
            A575MemoId = T001U17_A575MemoId[0];
            AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1U115( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound115 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound115 = 1;
            A575MemoId = T001U17_A575MemoId[0];
            AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
         }
      }

      protected void ScanEnd1U115( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1U115( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U115( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U115( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U115( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U115( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U115( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U115( )
      {
         edtMemoCategoryId_Enabled = 0;
         AssignProp("", false, edtMemoCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCategoryId_Enabled), 5, 0), true);
         edtMemoTitle_Enabled = 0;
         AssignProp("", false, edtMemoTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoTitle_Enabled), 5, 0), true);
         edtMemoDescription_Enabled = 0;
         AssignProp("", false, edtMemoDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDescription_Enabled), 5, 0), true);
         edtMemoImage_Enabled = 0;
         AssignProp("", false, edtMemoImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoImage_Enabled), 5, 0), true);
         edtMemoDocument_Enabled = 0;
         AssignProp("", false, edtMemoDocument_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDocument_Enabled), 5, 0), true);
         edtMemoStartDateTime_Enabled = 0;
         AssignProp("", false, edtMemoStartDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoStartDateTime_Enabled), 5, 0), true);
         edtMemoEndDateTime_Enabled = 0;
         AssignProp("", false, edtMemoEndDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoEndDateTime_Enabled), 5, 0), true);
         edtMemoDuration_Enabled = 0;
         AssignProp("", false, edtMemoDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDuration_Enabled), 5, 0), true);
         edtMemoRemoveDate_Enabled = 0;
         AssignProp("", false, edtMemoRemoveDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoRemoveDate_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtavCombomemocategoryid_Enabled = 0;
         AssignProp("", false, edtavCombomemocategoryid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomemocategoryid_Enabled), 5, 0), true);
         edtMemoId_Enabled = 0;
         AssignProp("", false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         cmbResidentSalutation.Enabled = 0;
         AssignProp("", false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1U115( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1U0( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         GXEncryptionTmp = "trn_memo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7MemoId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_memo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Memo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("MemoBgColorCode", StringUtil.RTrim( context.localUtil.Format( A592MemoBgColorCode, "")));
         forbiddenHiddens.Add("MemoForm", StringUtil.RTrim( context.localUtil.Format( A593MemoForm, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_memo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z575MemoId", Z575MemoId.ToString());
         GxWebStd.gx_hidden_field( context, "Z576MemoTitle", Z576MemoTitle);
         GxWebStd.gx_hidden_field( context, "Z577MemoDescription", Z577MemoDescription);
         GxWebStd.gx_hidden_field( context, "Z578MemoImage", Z578MemoImage);
         GxWebStd.gx_hidden_field( context, "Z579MemoDocument", Z579MemoDocument);
         GxWebStd.gx_hidden_field( context, "Z587MemoStartDateTime", context.localUtil.TToC( Z587MemoStartDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z588MemoEndDateTime", context.localUtil.TToC( Z588MemoEndDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z589MemoDuration", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z589MemoDuration), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z590MemoRemoveDate", context.localUtil.DToC( Z590MemoRemoveDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z592MemoBgColorCode", Z592MemoBgColorCode);
         GxWebStd.gx_hidden_field( context, "Z593MemoForm", StringUtil.RTrim( Z593MemoForm));
         GxWebStd.gx_hidden_field( context, "Z568MemoCategoryId", Z568MemoCategoryId.ToString());
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z555SG_LocationId", Z555SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z556SG_OrganisationId", Z556SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N568MemoCategoryId", A568MemoCategoryId.ToString());
         GxWebStd.gx_hidden_field( context, "N62ResidentId", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "N556SG_OrganisationId", A556SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "N555SG_LocationId", A555SG_LocationId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMEMOCATEGORYID_DATA", AV24MemoCategoryId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMEMOCATEGORYID_DATA", AV24MemoCategoryId_Data);
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
         GxWebStd.gx_hidden_field( context, "vMEMOID", AV7MemoId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMEMOID", GetSecureSignedToken( "", AV7MemoId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_MEMOCATEGORYID", AV14Insert_MemoCategoryId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_RESIDENTID", AV26Insert_ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_ORGANISATIONID", AV29Insert_SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_ORGANISATIONID", A556SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_LOCATIONID", AV30Insert_SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_LOCATIONID", A555SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "MEMOBGCOLORCODE", A592MemoBgColorCode);
         GxWebStd.gx_hidden_field( context, "MEMOFORM", StringUtil.RTrim( A593MemoForm));
         GxWebStd.gx_hidden_field( context, "MEMOCATEGORYNAME", A569MemoCategoryName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Objectcall", StringUtil.RTrim( Combo_memocategoryid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Cls", StringUtil.RTrim( Combo_memocategoryid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Selectedvalue_set", StringUtil.RTrim( Combo_memocategoryid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Selectedtext_set", StringUtil.RTrim( Combo_memocategoryid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Gamoauthtoken", StringUtil.RTrim( Combo_memocategoryid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Enabled", StringUtil.BoolToStr( Combo_memocategoryid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Datalistproc", StringUtil.RTrim( Combo_memocategoryid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_memocategoryid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MEMOCATEGORYID_Emptyitem", StringUtil.BoolToStr( Combo_memocategoryid_Emptyitem));
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
         GXEncryptionTmp = "trn_memo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7MemoId.ToString());
         return formatLink("trn_memo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Memo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Memo", "") ;
      }

      protected void InitializeNonKey1U115( )
      {
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A568MemoCategoryId = Guid.Empty;
         AssignAttri("", false, "A568MemoCategoryId", A568MemoCategoryId.ToString());
         A62ResidentId = Guid.Empty;
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         A556SG_OrganisationId = Guid.Empty;
         AssignAttri("", false, "A556SG_OrganisationId", A556SG_OrganisationId.ToString());
         A555SG_LocationId = Guid.Empty;
         AssignAttri("", false, "A555SG_LocationId", A555SG_LocationId.ToString());
         A569MemoCategoryName = "";
         AssignAttri("", false, "A569MemoCategoryName", A569MemoCategoryName);
         A576MemoTitle = "";
         AssignAttri("", false, "A576MemoTitle", A576MemoTitle);
         A577MemoDescription = "";
         AssignAttri("", false, "A577MemoDescription", A577MemoDescription);
         A578MemoImage = "";
         n578MemoImage = false;
         AssignAttri("", false, "A578MemoImage", A578MemoImage);
         n578MemoImage = (String.IsNullOrEmpty(StringUtil.RTrim( A578MemoImage)) ? true : false);
         A579MemoDocument = "";
         n579MemoDocument = false;
         AssignAttri("", false, "A579MemoDocument", A579MemoDocument);
         n579MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A579MemoDocument)) ? true : false);
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         n587MemoStartDateTime = false;
         AssignAttri("", false, "A587MemoStartDateTime", context.localUtil.TToC( A587MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n587MemoStartDateTime = ((DateTime.MinValue==A587MemoStartDateTime) ? true : false);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         n588MemoEndDateTime = false;
         AssignAttri("", false, "A588MemoEndDateTime", context.localUtil.TToC( A588MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n588MemoEndDateTime = ((DateTime.MinValue==A588MemoEndDateTime) ? true : false);
         A589MemoDuration = 0;
         n589MemoDuration = false;
         AssignAttri("", false, "A589MemoDuration", StringUtil.LTrimStr( (decimal)(A589MemoDuration), 4, 0));
         n589MemoDuration = ((0==A589MemoDuration) ? true : false);
         A590MemoRemoveDate = DateTime.MinValue;
         AssignAttri("", false, "A590MemoRemoveDate", context.localUtil.Format(A590MemoRemoveDate, "99/99/99"));
         A72ResidentSalutation = "";
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = "";
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = "";
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A71ResidentGUID = "";
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A592MemoBgColorCode = "";
         AssignAttri("", false, "A592MemoBgColorCode", A592MemoBgColorCode);
         A593MemoForm = "";
         AssignAttri("", false, "A593MemoForm", A593MemoForm);
         Z576MemoTitle = "";
         Z577MemoDescription = "";
         Z578MemoImage = "";
         Z579MemoDocument = "";
         Z587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z589MemoDuration = 0;
         Z590MemoRemoveDate = DateTime.MinValue;
         Z592MemoBgColorCode = "";
         Z593MemoForm = "";
         Z568MemoCategoryId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         Z555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1U115( )
      {
         A575MemoId = Guid.NewGuid( );
         AssignAttri("", false, "A575MemoId", A575MemoId.ToString());
         InitializeNonKey1U115( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253211343328", true, true);
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
         context.AddJavascriptSource("trn_memo.js", "?20253211343331", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockmemocategoryid_Internalname = "TEXTBLOCKMEMOCATEGORYID";
         Combo_memocategoryid_Internalname = "COMBO_MEMOCATEGORYID";
         edtMemoCategoryId_Internalname = "MEMOCATEGORYID";
         divTablesplittedmemocategoryid_Internalname = "TABLESPLITTEDMEMOCATEGORYID";
         edtMemoTitle_Internalname = "MEMOTITLE";
         edtMemoDescription_Internalname = "MEMODESCRIPTION";
         edtMemoImage_Internalname = "MEMOIMAGE";
         edtMemoDocument_Internalname = "MEMODOCUMENT";
         edtMemoStartDateTime_Internalname = "MEMOSTARTDATETIME";
         edtMemoEndDateTime_Internalname = "MEMOENDDATETIME";
         edtMemoDuration_Internalname = "MEMODURATION";
         edtMemoRemoveDate_Internalname = "MEMOREMOVEDATE";
         edtResidentId_Internalname = "RESIDENTID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomemocategoryid_Internalname = "vCOMBOMEMOCATEGORYID";
         divSectionattribute_memocategoryid_Internalname = "SECTIONATTRIBUTE_MEMOCATEGORYID";
         edtMemoId_Internalname = "MEMOID";
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         edtResidentGUID_Internalname = "RESIDENTGUID";
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
         Form.Caption = context.GetMessage( "Trn_Memo", "");
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Enabled = 0;
         edtResidentGUID_Visible = 1;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Enabled = 0;
         edtResidentLastName_Visible = 1;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 0;
         edtResidentGivenName_Visible = 1;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Visible = 1;
         cmbResidentSalutation.Enabled = 0;
         edtMemoId_Jsonclick = "";
         edtMemoId_Enabled = 1;
         edtMemoId_Visible = 1;
         edtavCombomemocategoryid_Jsonclick = "";
         edtavCombomemocategoryid_Enabled = 0;
         edtavCombomemocategoryid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 1;
         edtMemoRemoveDate_Jsonclick = "";
         edtMemoRemoveDate_Enabled = 1;
         edtMemoDuration_Jsonclick = "";
         edtMemoDuration_Enabled = 1;
         edtMemoEndDateTime_Jsonclick = "";
         edtMemoEndDateTime_Enabled = 1;
         edtMemoStartDateTime_Jsonclick = "";
         edtMemoStartDateTime_Enabled = 1;
         edtMemoDocument_Enabled = 1;
         edtMemoImage_Enabled = 1;
         edtMemoDescription_Enabled = 1;
         edtMemoTitle_Jsonclick = "";
         edtMemoTitle_Enabled = 1;
         edtMemoCategoryId_Jsonclick = "";
         edtMemoCategoryId_Enabled = 1;
         edtMemoCategoryId_Visible = 1;
         Combo_memocategoryid_Emptyitem = Convert.ToBoolean( 0);
         Combo_memocategoryid_Datalistprocparametersprefix = " \"ComboName\": \"MemoCategoryId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MemoId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_memocategoryid_Datalistproc = "Trn_MemoLoadDVCombo";
         Combo_memocategoryid_Cls = "ExtendedCombo Attribute";
         Combo_memocategoryid_Caption = "";
         Combo_memocategoryid_Enabled = Convert.ToBoolean( -1);
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
         cmbResidentSalutation.Name = "RESIDENTSALUTATION";
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbResidentSalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbResidentSalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbResidentSalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         }
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

      public void Valid_Memocategoryid( )
      {
         /* Using cursor T001U15 */
         pr_default.execute(13, new Object[] {A568MemoCategoryId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_MemoCategory", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEMOCATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtMemoCategoryId_Internalname;
         }
         A569MemoCategoryName = T001U15_A569MemoCategoryName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A569MemoCategoryName", A569MemoCategoryName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7MemoId","fld":"vMEMOID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7MemoId","fld":"vMEMOID","hsh":true},{"av":"A592MemoBgColorCode","fld":"MEMOBGCOLORCODE"},{"av":"A593MemoForm","fld":"MEMOFORM"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E131U2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_MEMOCATEGORYID.ONOPTIONCLICKED","""{"handler":"E121U2","iparms":[{"av":"Combo_memocategoryid_Selectedvalue_get","ctrl":"COMBO_MEMOCATEGORYID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_MEMOCATEGORYID.ONOPTIONCLICKED",""","oparms":[{"av":"AV25ComboMemoCategoryId","fld":"vCOMBOMEMOCATEGORYID"}]}""");
         setEventMetadata("VALID_MEMOCATEGORYID","""{"handler":"Valid_Memocategoryid","iparms":[{"av":"A568MemoCategoryId","fld":"MEMOCATEGORYID"},{"av":"A569MemoCategoryName","fld":"MEMOCATEGORYNAME"}]""");
         setEventMetadata("VALID_MEMOCATEGORYID",""","oparms":[{"av":"A569MemoCategoryName","fld":"MEMOCATEGORYNAME"}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOMEMOCATEGORYID","""{"handler":"Validv_Combomemocategoryid","iparms":[]}""");
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
         wcpOAV7MemoId = Guid.Empty;
         Z575MemoId = Guid.Empty;
         Z576MemoTitle = "";
         Z577MemoDescription = "";
         Z578MemoImage = "";
         Z579MemoDocument = "";
         Z587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z590MemoRemoveDate = DateTime.MinValue;
         Z592MemoBgColorCode = "";
         Z593MemoForm = "";
         Z568MemoCategoryId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         Z555SG_LocationId = Guid.Empty;
         Z556SG_OrganisationId = Guid.Empty;
         N568MemoCategoryId = Guid.Empty;
         N62ResidentId = Guid.Empty;
         N556SG_OrganisationId = Guid.Empty;
         N555SG_LocationId = Guid.Empty;
         Combo_memocategoryid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A568MemoCategoryId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A555SG_LocationId = Guid.Empty;
         A556SG_OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A72ResidentSalutation = "";
         ClassString = "";
         StyleString = "";
         lblTextblockmemocategoryid_Jsonclick = "";
         ucCombo_memocategoryid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24MemoCategoryId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A576MemoTitle = "";
         A577MemoDescription = "";
         A578MemoImage = "";
         A579MemoDocument = "";
         A587MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A588MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A590MemoRemoveDate = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV25ComboMemoCategoryId = Guid.Empty;
         A575MemoId = Guid.Empty;
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A592MemoBgColorCode = "";
         A593MemoForm = "";
         AV14Insert_MemoCategoryId = Guid.Empty;
         AV26Insert_ResidentId = Guid.Empty;
         AV29Insert_SG_OrganisationId = Guid.Empty;
         AV30Insert_SG_LocationId = Guid.Empty;
         A569MemoCategoryName = "";
         AV31Pgmname = "";
         Combo_memocategoryid_Objectcall = "";
         Combo_memocategoryid_Class = "";
         Combo_memocategoryid_Icontype = "";
         Combo_memocategoryid_Icon = "";
         Combo_memocategoryid_Tooltip = "";
         Combo_memocategoryid_Selectedvalue_set = "";
         Combo_memocategoryid_Selectedtext_set = "";
         Combo_memocategoryid_Selectedtext_get = "";
         Combo_memocategoryid_Gamoauthtoken = "";
         Combo_memocategoryid_Ddointernalname = "";
         Combo_memocategoryid_Titlecontrolalign = "";
         Combo_memocategoryid_Dropdownoptionstype = "";
         Combo_memocategoryid_Titlecontrolidtoreplace = "";
         Combo_memocategoryid_Datalisttype = "";
         Combo_memocategoryid_Datalistfixedvalues = "";
         Combo_memocategoryid_Remoteservicesparameters = "";
         Combo_memocategoryid_Htmltemplate = "";
         Combo_memocategoryid_Multiplevaluestype = "";
         Combo_memocategoryid_Loadingdata = "";
         Combo_memocategoryid_Noresultsfound = "";
         Combo_memocategoryid_Emptyitemtext = "";
         Combo_memocategoryid_Onlyselectedvalues = "";
         Combo_memocategoryid_Selectalltext = "";
         Combo_memocategoryid_Multiplevaluesseparator = "";
         Combo_memocategoryid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode115 = "";
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
         GXt_char2 = "";
         Z569MemoCategoryName = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z71ResidentGUID = "";
         T001U5_A29LocationId = new Guid[] {Guid.Empty} ;
         T001U5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001U5_A72ResidentSalutation = new string[] {""} ;
         T001U5_A64ResidentGivenName = new string[] {""} ;
         T001U5_A65ResidentLastName = new string[] {""} ;
         T001U5_A71ResidentGUID = new string[] {""} ;
         T001U4_A569MemoCategoryName = new string[] {""} ;
         T001U6_A29LocationId = new Guid[] {Guid.Empty} ;
         T001U6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001U6_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U6_A569MemoCategoryName = new string[] {""} ;
         T001U6_A576MemoTitle = new string[] {""} ;
         T001U6_A577MemoDescription = new string[] {""} ;
         T001U6_A578MemoImage = new string[] {""} ;
         T001U6_n578MemoImage = new bool[] {false} ;
         T001U6_A579MemoDocument = new string[] {""} ;
         T001U6_n579MemoDocument = new bool[] {false} ;
         T001U6_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U6_n587MemoStartDateTime = new bool[] {false} ;
         T001U6_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U6_n588MemoEndDateTime = new bool[] {false} ;
         T001U6_A589MemoDuration = new short[1] ;
         T001U6_n589MemoDuration = new bool[] {false} ;
         T001U6_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001U6_A72ResidentSalutation = new string[] {""} ;
         T001U6_A64ResidentGivenName = new string[] {""} ;
         T001U6_A65ResidentLastName = new string[] {""} ;
         T001U6_A71ResidentGUID = new string[] {""} ;
         T001U6_A592MemoBgColorCode = new string[] {""} ;
         T001U6_A593MemoForm = new string[] {""} ;
         T001U6_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         T001U6_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001U6_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         T001U6_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001U7_A569MemoCategoryName = new string[] {""} ;
         T001U8_A29LocationId = new Guid[] {Guid.Empty} ;
         T001U8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001U8_A72ResidentSalutation = new string[] {""} ;
         T001U8_A64ResidentGivenName = new string[] {""} ;
         T001U8_A65ResidentLastName = new string[] {""} ;
         T001U8_A71ResidentGUID = new string[] {""} ;
         T001U9_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U3_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U3_A576MemoTitle = new string[] {""} ;
         T001U3_A577MemoDescription = new string[] {""} ;
         T001U3_A578MemoImage = new string[] {""} ;
         T001U3_n578MemoImage = new bool[] {false} ;
         T001U3_A579MemoDocument = new string[] {""} ;
         T001U3_n579MemoDocument = new bool[] {false} ;
         T001U3_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U3_n587MemoStartDateTime = new bool[] {false} ;
         T001U3_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U3_n588MemoEndDateTime = new bool[] {false} ;
         T001U3_A589MemoDuration = new short[1] ;
         T001U3_n589MemoDuration = new bool[] {false} ;
         T001U3_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001U3_A592MemoBgColorCode = new string[] {""} ;
         T001U3_A593MemoForm = new string[] {""} ;
         T001U3_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         T001U3_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001U3_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         T001U3_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001U10_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U11_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U2_A575MemoId = new Guid[] {Guid.Empty} ;
         T001U2_A576MemoTitle = new string[] {""} ;
         T001U2_A577MemoDescription = new string[] {""} ;
         T001U2_A578MemoImage = new string[] {""} ;
         T001U2_n578MemoImage = new bool[] {false} ;
         T001U2_A579MemoDocument = new string[] {""} ;
         T001U2_n579MemoDocument = new bool[] {false} ;
         T001U2_A587MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U2_n587MemoStartDateTime = new bool[] {false} ;
         T001U2_A588MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001U2_n588MemoEndDateTime = new bool[] {false} ;
         T001U2_A589MemoDuration = new short[1] ;
         T001U2_n589MemoDuration = new bool[] {false} ;
         T001U2_A590MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001U2_A592MemoBgColorCode = new string[] {""} ;
         T001U2_A593MemoForm = new string[] {""} ;
         T001U2_A568MemoCategoryId = new Guid[] {Guid.Empty} ;
         T001U2_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001U2_A555SG_LocationId = new Guid[] {Guid.Empty} ;
         T001U2_A556SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001U15_A569MemoCategoryName = new string[] {""} ;
         T001U16_A72ResidentSalutation = new string[] {""} ;
         T001U16_A64ResidentGivenName = new string[] {""} ;
         T001U16_A65ResidentLastName = new string[] {""} ;
         T001U16_A71ResidentGUID = new string[] {""} ;
         T001U17_A575MemoId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__default(),
            new Object[][] {
                new Object[] {
               T001U2_A575MemoId, T001U2_A576MemoTitle, T001U2_A577MemoDescription, T001U2_A578MemoImage, T001U2_n578MemoImage, T001U2_A579MemoDocument, T001U2_n579MemoDocument, T001U2_A587MemoStartDateTime, T001U2_n587MemoStartDateTime, T001U2_A588MemoEndDateTime,
               T001U2_n588MemoEndDateTime, T001U2_A589MemoDuration, T001U2_n589MemoDuration, T001U2_A590MemoRemoveDate, T001U2_A592MemoBgColorCode, T001U2_A593MemoForm, T001U2_A568MemoCategoryId, T001U2_A62ResidentId, T001U2_A555SG_LocationId, T001U2_A556SG_OrganisationId
               }
               , new Object[] {
               T001U3_A575MemoId, T001U3_A576MemoTitle, T001U3_A577MemoDescription, T001U3_A578MemoImage, T001U3_n578MemoImage, T001U3_A579MemoDocument, T001U3_n579MemoDocument, T001U3_A587MemoStartDateTime, T001U3_n587MemoStartDateTime, T001U3_A588MemoEndDateTime,
               T001U3_n588MemoEndDateTime, T001U3_A589MemoDuration, T001U3_n589MemoDuration, T001U3_A590MemoRemoveDate, T001U3_A592MemoBgColorCode, T001U3_A593MemoForm, T001U3_A568MemoCategoryId, T001U3_A62ResidentId, T001U3_A555SG_LocationId, T001U3_A556SG_OrganisationId
               }
               , new Object[] {
               T001U4_A569MemoCategoryName
               }
               , new Object[] {
               T001U5_A29LocationId, T001U5_A11OrganisationId, T001U5_A72ResidentSalutation, T001U5_A64ResidentGivenName, T001U5_A65ResidentLastName, T001U5_A71ResidentGUID
               }
               , new Object[] {
               T001U6_A29LocationId, T001U6_A11OrganisationId, T001U6_A575MemoId, T001U6_A569MemoCategoryName, T001U6_A576MemoTitle, T001U6_A577MemoDescription, T001U6_A578MemoImage, T001U6_n578MemoImage, T001U6_A579MemoDocument, T001U6_n579MemoDocument,
               T001U6_A587MemoStartDateTime, T001U6_n587MemoStartDateTime, T001U6_A588MemoEndDateTime, T001U6_n588MemoEndDateTime, T001U6_A589MemoDuration, T001U6_n589MemoDuration, T001U6_A590MemoRemoveDate, T001U6_A72ResidentSalutation, T001U6_A64ResidentGivenName, T001U6_A65ResidentLastName,
               T001U6_A71ResidentGUID, T001U6_A592MemoBgColorCode, T001U6_A593MemoForm, T001U6_A568MemoCategoryId, T001U6_A62ResidentId, T001U6_A555SG_LocationId, T001U6_A556SG_OrganisationId
               }
               , new Object[] {
               T001U7_A569MemoCategoryName
               }
               , new Object[] {
               T001U8_A29LocationId, T001U8_A11OrganisationId, T001U8_A72ResidentSalutation, T001U8_A64ResidentGivenName, T001U8_A65ResidentLastName, T001U8_A71ResidentGUID
               }
               , new Object[] {
               T001U9_A575MemoId
               }
               , new Object[] {
               T001U10_A575MemoId
               }
               , new Object[] {
               T001U11_A575MemoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001U15_A569MemoCategoryName
               }
               , new Object[] {
               T001U16_A72ResidentSalutation, T001U16_A64ResidentGivenName, T001U16_A65ResidentLastName, T001U16_A71ResidentGUID
               }
               , new Object[] {
               T001U17_A575MemoId
               }
            }
         );
         Z575MemoId = Guid.NewGuid( );
         A575MemoId = Guid.NewGuid( );
         AV31Pgmname = "Trn_Memo";
      }

      private short Z589MemoDuration ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A589MemoDuration ;
      private short Gx_BScreen ;
      private short RcdFound115 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtMemoCategoryId_Visible ;
      private int edtMemoCategoryId_Enabled ;
      private int edtMemoTitle_Enabled ;
      private int edtMemoDescription_Enabled ;
      private int edtMemoImage_Enabled ;
      private int edtMemoDocument_Enabled ;
      private int edtMemoStartDateTime_Enabled ;
      private int edtMemoEndDateTime_Enabled ;
      private int edtMemoDuration_Enabled ;
      private int edtMemoRemoveDate_Enabled ;
      private int edtResidentId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombomemocategoryid_Visible ;
      private int edtavCombomemocategoryid_Enabled ;
      private int edtMemoId_Visible ;
      private int edtMemoId_Enabled ;
      private int edtResidentGivenName_Visible ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Visible ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentGUID_Visible ;
      private int edtResidentGUID_Enabled ;
      private int Combo_memocategoryid_Datalistupdateminimumcharacters ;
      private int Combo_memocategoryid_Gxcontroltype ;
      private int AV32GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z593MemoForm ;
      private string Combo_memocategoryid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMemoCategoryId_Internalname ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedmemocategoryid_Internalname ;
      private string lblTextblockmemocategoryid_Internalname ;
      private string lblTextblockmemocategoryid_Jsonclick ;
      private string Combo_memocategoryid_Caption ;
      private string Combo_memocategoryid_Cls ;
      private string Combo_memocategoryid_Datalistproc ;
      private string Combo_memocategoryid_Datalistprocparametersprefix ;
      private string Combo_memocategoryid_Internalname ;
      private string TempTags ;
      private string edtMemoCategoryId_Jsonclick ;
      private string edtMemoTitle_Internalname ;
      private string edtMemoTitle_Jsonclick ;
      private string edtMemoDescription_Internalname ;
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
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_memocategoryid_Internalname ;
      private string edtavCombomemocategoryid_Internalname ;
      private string edtavCombomemocategoryid_Jsonclick ;
      private string edtMemoId_Internalname ;
      private string edtMemoId_Jsonclick ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string A593MemoForm ;
      private string AV31Pgmname ;
      private string Combo_memocategoryid_Objectcall ;
      private string Combo_memocategoryid_Class ;
      private string Combo_memocategoryid_Icontype ;
      private string Combo_memocategoryid_Icon ;
      private string Combo_memocategoryid_Tooltip ;
      private string Combo_memocategoryid_Selectedvalue_set ;
      private string Combo_memocategoryid_Selectedtext_set ;
      private string Combo_memocategoryid_Selectedtext_get ;
      private string Combo_memocategoryid_Gamoauthtoken ;
      private string Combo_memocategoryid_Ddointernalname ;
      private string Combo_memocategoryid_Titlecontrolalign ;
      private string Combo_memocategoryid_Dropdownoptionstype ;
      private string Combo_memocategoryid_Titlecontrolidtoreplace ;
      private string Combo_memocategoryid_Datalisttype ;
      private string Combo_memocategoryid_Datalistfixedvalues ;
      private string Combo_memocategoryid_Remoteservicesparameters ;
      private string Combo_memocategoryid_Htmltemplate ;
      private string Combo_memocategoryid_Multiplevaluestype ;
      private string Combo_memocategoryid_Loadingdata ;
      private string Combo_memocategoryid_Noresultsfound ;
      private string Combo_memocategoryid_Emptyitemtext ;
      private string Combo_memocategoryid_Onlyselectedvalues ;
      private string Combo_memocategoryid_Selectalltext ;
      private string Combo_memocategoryid_Multiplevaluesseparator ;
      private string Combo_memocategoryid_Addnewoptiontext ;
      private string hsh ;
      private string sMode115 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z72ResidentSalutation ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z587MemoStartDateTime ;
      private DateTime Z588MemoEndDateTime ;
      private DateTime A587MemoStartDateTime ;
      private DateTime A588MemoEndDateTime ;
      private DateTime Z590MemoRemoveDate ;
      private DateTime A590MemoRemoveDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_memocategoryid_Emptyitem ;
      private bool n578MemoImage ;
      private bool n579MemoDocument ;
      private bool n587MemoStartDateTime ;
      private bool n588MemoEndDateTime ;
      private bool n589MemoDuration ;
      private bool Combo_memocategoryid_Enabled ;
      private bool Combo_memocategoryid_Visible ;
      private bool Combo_memocategoryid_Allowmultipleselection ;
      private bool Combo_memocategoryid_Isgriditem ;
      private bool Combo_memocategoryid_Hasdescription ;
      private bool Combo_memocategoryid_Includeonlyselectedoption ;
      private bool Combo_memocategoryid_Includeselectalloption ;
      private bool Combo_memocategoryid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV20Combo_DataJson ;
      private string Z576MemoTitle ;
      private string Z577MemoDescription ;
      private string Z578MemoImage ;
      private string Z579MemoDocument ;
      private string Z592MemoBgColorCode ;
      private string A576MemoTitle ;
      private string A577MemoDescription ;
      private string A578MemoImage ;
      private string A579MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A592MemoBgColorCode ;
      private string A569MemoCategoryName ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string Z569MemoCategoryName ;
      private string Z64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string Z71ResidentGUID ;
      private Guid wcpOAV7MemoId ;
      private Guid Z575MemoId ;
      private Guid Z568MemoCategoryId ;
      private Guid Z62ResidentId ;
      private Guid Z555SG_LocationId ;
      private Guid Z556SG_OrganisationId ;
      private Guid N568MemoCategoryId ;
      private Guid N62ResidentId ;
      private Guid N556SG_OrganisationId ;
      private Guid N555SG_LocationId ;
      private Guid A568MemoCategoryId ;
      private Guid A62ResidentId ;
      private Guid A555SG_LocationId ;
      private Guid A556SG_OrganisationId ;
      private Guid AV7MemoId ;
      private Guid AV25ComboMemoCategoryId ;
      private Guid A575MemoId ;
      private Guid AV14Insert_MemoCategoryId ;
      private Guid AV26Insert_ResidentId ;
      private Guid AV29Insert_SG_OrganisationId ;
      private Guid AV30Insert_SG_LocationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_memocategoryid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24MemoCategoryId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001U5_A29LocationId ;
      private Guid[] T001U5_A11OrganisationId ;
      private string[] T001U5_A72ResidentSalutation ;
      private string[] T001U5_A64ResidentGivenName ;
      private string[] T001U5_A65ResidentLastName ;
      private string[] T001U5_A71ResidentGUID ;
      private string[] T001U4_A569MemoCategoryName ;
      private Guid[] T001U6_A29LocationId ;
      private Guid[] T001U6_A11OrganisationId ;
      private Guid[] T001U6_A575MemoId ;
      private string[] T001U6_A569MemoCategoryName ;
      private string[] T001U6_A576MemoTitle ;
      private string[] T001U6_A577MemoDescription ;
      private string[] T001U6_A578MemoImage ;
      private bool[] T001U6_n578MemoImage ;
      private string[] T001U6_A579MemoDocument ;
      private bool[] T001U6_n579MemoDocument ;
      private DateTime[] T001U6_A587MemoStartDateTime ;
      private bool[] T001U6_n587MemoStartDateTime ;
      private DateTime[] T001U6_A588MemoEndDateTime ;
      private bool[] T001U6_n588MemoEndDateTime ;
      private short[] T001U6_A589MemoDuration ;
      private bool[] T001U6_n589MemoDuration ;
      private DateTime[] T001U6_A590MemoRemoveDate ;
      private string[] T001U6_A72ResidentSalutation ;
      private string[] T001U6_A64ResidentGivenName ;
      private string[] T001U6_A65ResidentLastName ;
      private string[] T001U6_A71ResidentGUID ;
      private string[] T001U6_A592MemoBgColorCode ;
      private string[] T001U6_A593MemoForm ;
      private Guid[] T001U6_A568MemoCategoryId ;
      private Guid[] T001U6_A62ResidentId ;
      private Guid[] T001U6_A555SG_LocationId ;
      private Guid[] T001U6_A556SG_OrganisationId ;
      private string[] T001U7_A569MemoCategoryName ;
      private Guid[] T001U8_A29LocationId ;
      private Guid[] T001U8_A11OrganisationId ;
      private string[] T001U8_A72ResidentSalutation ;
      private string[] T001U8_A64ResidentGivenName ;
      private string[] T001U8_A65ResidentLastName ;
      private string[] T001U8_A71ResidentGUID ;
      private Guid[] T001U9_A575MemoId ;
      private Guid[] T001U3_A575MemoId ;
      private string[] T001U3_A576MemoTitle ;
      private string[] T001U3_A577MemoDescription ;
      private string[] T001U3_A578MemoImage ;
      private bool[] T001U3_n578MemoImage ;
      private string[] T001U3_A579MemoDocument ;
      private bool[] T001U3_n579MemoDocument ;
      private DateTime[] T001U3_A587MemoStartDateTime ;
      private bool[] T001U3_n587MemoStartDateTime ;
      private DateTime[] T001U3_A588MemoEndDateTime ;
      private bool[] T001U3_n588MemoEndDateTime ;
      private short[] T001U3_A589MemoDuration ;
      private bool[] T001U3_n589MemoDuration ;
      private DateTime[] T001U3_A590MemoRemoveDate ;
      private string[] T001U3_A592MemoBgColorCode ;
      private string[] T001U3_A593MemoForm ;
      private Guid[] T001U3_A568MemoCategoryId ;
      private Guid[] T001U3_A62ResidentId ;
      private Guid[] T001U3_A555SG_LocationId ;
      private Guid[] T001U3_A556SG_OrganisationId ;
      private Guid[] T001U10_A575MemoId ;
      private Guid[] T001U11_A575MemoId ;
      private Guid[] T001U2_A575MemoId ;
      private string[] T001U2_A576MemoTitle ;
      private string[] T001U2_A577MemoDescription ;
      private string[] T001U2_A578MemoImage ;
      private bool[] T001U2_n578MemoImage ;
      private string[] T001U2_A579MemoDocument ;
      private bool[] T001U2_n579MemoDocument ;
      private DateTime[] T001U2_A587MemoStartDateTime ;
      private bool[] T001U2_n587MemoStartDateTime ;
      private DateTime[] T001U2_A588MemoEndDateTime ;
      private bool[] T001U2_n588MemoEndDateTime ;
      private short[] T001U2_A589MemoDuration ;
      private bool[] T001U2_n589MemoDuration ;
      private DateTime[] T001U2_A590MemoRemoveDate ;
      private string[] T001U2_A592MemoBgColorCode ;
      private string[] T001U2_A593MemoForm ;
      private Guid[] T001U2_A568MemoCategoryId ;
      private Guid[] T001U2_A62ResidentId ;
      private Guid[] T001U2_A555SG_LocationId ;
      private Guid[] T001U2_A556SG_OrganisationId ;
      private string[] T001U15_A569MemoCategoryName ;
      private string[] T001U16_A72ResidentSalutation ;
      private string[] T001U16_A64ResidentGivenName ;
      private string[] T001U16_A65ResidentLastName ;
      private string[] T001U16_A71ResidentGUID ;
      private Guid[] T001U17_A575MemoId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_memo__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_memo__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001U2;
       prmT001U2 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U3;
       prmT001U3 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U4;
       prmT001U4 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U5;
       prmT001U5 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U6;
       prmT001U6 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U7;
       prmT001U7 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U8;
       prmT001U8 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U9;
       prmT001U9 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U10;
       prmT001U10 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U11;
       prmT001U11 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U12;
       prmT001U12 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0) ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U13;
       prmT001U13 = new Object[] {
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0) ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0) ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U14;
       prmT001U14 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U15;
       prmT001U15 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U16;
       prmT001U16 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U17;
       prmT001U17 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001U2", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId  FOR UPDATE OF Trn_Memo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U3", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U4", "SELECT MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U5", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U6", "SELECT T3.LocationId, T3.OrganisationId, TM1.MemoId, T2.MemoCategoryName, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T3.ResidentSalutation, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoCategoryId, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM ((Trn_Memo TM1 INNER JOIN Trn_MemoCategory T2 ON T2.MemoCategoryId = TM1.MemoCategoryId) INNER JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = TM1.SG_LocationId AND T3.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U7", "SELECT MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U8", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U9", "SELECT MemoId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U10", "SELECT MemoId FROM Trn_Memo WHERE ( MemoId > :MemoId) ORDER BY MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001U11", "SELECT MemoId FROM Trn_Memo WHERE ( MemoId < :MemoId) ORDER BY MemoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001U12", "SAVEPOINT gxupdate;INSERT INTO Trn_Memo(MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoCategoryId, ResidentId, SG_LocationId, SG_OrganisationId) VALUES(:MemoId, :MemoTitle, :MemoDescription, :MemoImage, :MemoDocument, :MemoStartDateTime, :MemoEndDateTime, :MemoDuration, :MemoRemoveDate, :MemoBgColorCode, :MemoForm, :MemoCategoryId, :ResidentId, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001U12)
          ,new CursorDef("T001U13", "SAVEPOINT gxupdate;UPDATE Trn_Memo SET MemoTitle=:MemoTitle, MemoDescription=:MemoDescription, MemoImage=:MemoImage, MemoDocument=:MemoDocument, MemoStartDateTime=:MemoStartDateTime, MemoEndDateTime=:MemoEndDateTime, MemoDuration=:MemoDuration, MemoRemoveDate=:MemoRemoveDate, MemoBgColorCode=:MemoBgColorCode, MemoForm=:MemoForm, MemoCategoryId=:MemoCategoryId, ResidentId=:ResidentId, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001U13)
          ,new CursorDef("T001U14", "SAVEPOINT gxupdate;DELETE FROM Trn_Memo  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001U14)
          ,new CursorDef("T001U15", "SELECT MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U16", "SELECT ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U17", "SELECT MemoId FROM Trn_Memo ORDER BY MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U17,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((short[]) buf[11])[0] = rslt.getShort(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((string[]) buf[14])[0] = rslt.getVarchar(10);
             ((string[]) buf[15])[0] = rslt.getString(11, 20);
             ((Guid[]) buf[16])[0] = rslt.getGuid(12);
             ((Guid[]) buf[17])[0] = rslt.getGuid(13);
             ((Guid[]) buf[18])[0] = rslt.getGuid(14);
             ((Guid[]) buf[19])[0] = rslt.getGuid(15);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((short[]) buf[11])[0] = rslt.getShort(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((string[]) buf[14])[0] = rslt.getVarchar(10);
             ((string[]) buf[15])[0] = rslt.getString(11, 20);
             ((Guid[]) buf[16])[0] = rslt.getGuid(12);
             ((Guid[]) buf[17])[0] = rslt.getGuid(13);
             ((Guid[]) buf[18])[0] = rslt.getGuid(14);
             ((Guid[]) buf[19])[0] = rslt.getGuid(15);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[13])[0] = rslt.wasNull(10);
             ((short[]) buf[14])[0] = rslt.getShort(11);
             ((bool[]) buf[15])[0] = rslt.wasNull(11);
             ((DateTime[]) buf[16])[0] = rslt.getGXDate(12);
             ((string[]) buf[17])[0] = rslt.getString(13, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(14);
             ((string[]) buf[19])[0] = rslt.getVarchar(15);
             ((string[]) buf[20])[0] = rslt.getVarchar(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getString(18, 20);
             ((Guid[]) buf[23])[0] = rslt.getGuid(19);
             ((Guid[]) buf[24])[0] = rslt.getGuid(20);
             ((Guid[]) buf[25])[0] = rslt.getGuid(21);
             ((Guid[]) buf[26])[0] = rslt.getGuid(22);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
