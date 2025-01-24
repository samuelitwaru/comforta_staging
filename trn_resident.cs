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
   public class trn_resident : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action49") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A67ResidentEmail = GetPar( "ResidentEmail");
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A64ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A71ResidentGUID = GetPar( "ResidentGUID");
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            AV36GAMErrorResponse = GetPar( "GAMErrorResponse");
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_49_0916( Gx_mode, A67ResidentEmail, A64ResidentGivenName, A65ResidentLastName, A71ResidentGUID, AV36GAMErrorResponse) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action51") == 0 )
         {
            A64ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_51_0916( A64ResidentGivenName, A65ResidentLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action52") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A71ResidentGUID = GetPar( "ResidentGUID");
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A64ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A445ResidentHomePhoneCode = GetPar( "ResidentHomePhoneCode");
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A446ResidentHomePhoneNumber = GetPar( "ResidentHomePhoneNumber");
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            A457ResidentImage = GetPar( "ResidentImage");
            n457ResidentImage = false;
            AssignAttri("", false, "A457ResidentImage", A457ResidentImage);
            AV36GAMErrorResponse = GetPar( "GAMErrorResponse");
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_52_0916( Gx_mode, A71ResidentGUID, A64ResidentGivenName, A65ResidentLastName, A445ResidentHomePhoneCode, A446ResidentHomePhoneNumber, A457ResidentImage, AV36GAMErrorResponse) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action54") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A71ResidentGUID = GetPar( "ResidentGUID");
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_54_0916( Gx_mode, A71ResidentGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel34"+"_"+"RESIDENTPHONE") == 0 )
         {
            A375ResidentPhoneCode = GetPar( "ResidentPhoneCode");
            AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
            A376ResidentPhoneNumber = GetPar( "ResidentPhoneNumber");
            AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX34ASARESIDENTPHONE0916( A375ResidentPhoneCode, A376ResidentPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel35"+"_"+"RESIDENTHOMEPHONE") == 0 )
         {
            A445ResidentHomePhoneCode = GetPar( "ResidentHomePhoneCode");
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A446ResidentHomePhoneNumber = GetPar( "ResidentHomePhoneNumber");
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX35ASARESIDENTHOMEPHONE0916( A445ResidentHomePhoneCode, A446ResidentHomePhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_61") == 0 )
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
            gxLoad_61( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_62") == 0 )
         {
            A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
            n96ResidentTypeId = false;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_62( A96ResidentTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_63") == 0 )
         {
            A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
            n98MedicalIndicationId = false;
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_63( A98MedicalIndicationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_resident.aspx")), "trn_resident.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_resident.aspx")))) ;
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
                  AV7ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
                  AssignAttri("", false, "AV7ResidentId", AV7ResidentId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", AV7ResidentId, context));
                  AV8LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV8LocationId", AV8LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV8LocationId, context));
                  AV9OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV9OrganisationId", AV9OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV9OrganisationId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Residents", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbResidentSalutation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_resident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_resident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ResidentId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ResidentId = aP1_ResidentId;
         this.AV8LocationId = aP2_LocationId;
         this.AV9OrganisationId = aP3_OrganisationId;
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
         cmbResidentGender = new GXCombobox();
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
            return "trn_resident_Execute" ;
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
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
            AssignProp("", false, cmbResidentGender_Internalname, "Values", cmbResidentGender.ToJavascriptSource(), true);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Resident Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentSalutation_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbResidentSalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbResidentSalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_Trn_Resident.htm");
         cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         AssignProp("", false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentGivenName_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbResidentGender_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbResidentGender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentGender, cmbResidentGender_Internalname, StringUtil.RTrim( A68ResidentGender), 1, cmbResidentGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbResidentGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Trn_Resident.htm");
         cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
         AssignProp("", false, cmbResidentGender_Internalname, "Values", (string)(cmbResidentGender.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBirthDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBirthDate_Internalname, context.GetMessage( "Birth Date", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtResidentBirthDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtResidentBirthDate_Internalname, context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"), context.localUtil.Format( A73ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBirthDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtResidentBirthDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_bitmap( context, edtResidentBirthDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtResidentBirthDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Resident.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentEmail_Internalname, A67ResidentEmail, StringUtil.RTrim( context.localUtil.Format( A67ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A67ResidentEmail, "", "", "", edtResidentEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divPhonenumber_Internalname, divPhonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableresidentphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residentphonecode.SetProperty("Caption", Combo_residentphonecode_Caption);
         ucCombo_residentphonecode.SetProperty("Cls", Combo_residentphonecode_Cls);
         ucCombo_residentphonecode.SetProperty("EmptyItem", Combo_residentphonecode_Emptyitem);
         ucCombo_residentphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residentphonecode.SetProperty("DropDownOptionsData", AV41ResidentPhoneCode_Data);
         ucCombo_residentphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentphonecode_Internalname, "COMBO_RESIDENTPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhoneCode_Internalname, context.GetMessage( "Resident Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneCode_Internalname, A375ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( A375ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPhoneCode_Visible, edtResidentPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_label_element( context, edtResidentPhoneNumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneNumber_Internalname, A376ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A376ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_div_start( context, divHomephonenumber_Internalname, divHomephonenumber_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblPhone_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblPhone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableresidenthomephonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residenthomephonecode.SetProperty("Caption", Combo_residenthomephonecode_Caption);
         ucCombo_residenthomephonecode.SetProperty("Cls", Combo_residenthomephonecode_Cls);
         ucCombo_residenthomephonecode.SetProperty("EmptyItem", Combo_residenthomephonecode_Emptyitem);
         ucCombo_residenthomephonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residenthomephonecode.SetProperty("DropDownOptionsData", AV43ResidentHomePhoneCode_Data);
         ucCombo_residenthomephonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenthomephonecode_Internalname, "COMBO_RESIDENTHOMEPHONECODEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentHomePhoneCode_Internalname, context.GetMessage( "Resident Home Phone Code", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhoneCode_Internalname, A445ResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( A445ResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentHomePhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentHomePhoneCode_Visible, edtResidentHomePhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_label_element( context, edtResidentHomePhoneNumber_Internalname, context.GetMessage( "Resident Home Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhoneNumber_Internalname, A446ResidentHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( A446ResidentHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentHomePhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentHomePhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_div_start( context, divResidentphone_cell_Internalname, 1, 0, "px", 0, "px", divResidentphone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtResidentPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhone_Internalname, context.GetMessage( "Mobile Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A70ResidentPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhone_Internalname, StringUtil.RTrim( A70ResidentPhone), StringUtil.RTrim( context.localUtil.Format( A70ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPhone_Visible, edtResidentPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divResidenthomephone_cell_Internalname, 1, 0, "px", 0, "px", divResidenthomephone_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtResidentHomePhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentHomePhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentHomePhone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A444ResidentHomePhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhone_Internalname, StringUtil.RTrim( A444ResidentHomePhone), StringUtil.RTrim( context.localUtil.Format( A444ResidentHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentHomePhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentHomePhone_Visible, edtResidentHomePhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBsnNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBsnNumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentBsnNumber_Internalname, A63ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( A63ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBsnNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine1_Internalname, A357ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( A357ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine2_Internalname, A358ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( A358ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentZipCode_Internalname, A356ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( A356ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtResidentZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCity_Internalname, A355ResidentCity, StringUtil.RTrim( context.localUtil.Format( A355ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidentcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidentcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockresidentcountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residentcountry.SetProperty("Caption", Combo_residentcountry_Caption);
         ucCombo_residentcountry.SetProperty("Cls", Combo_residentcountry_Cls);
         ucCombo_residentcountry.SetProperty("EmptyItem", Combo_residentcountry_Emptyitem);
         ucCombo_residentcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residentcountry.SetProperty("DropDownOptionsData", AV37ResidentCountry_Data);
         ucCombo_residentcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentcountry_Internalname, "COMBO_RESIDENTCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentCountry_Internalname, context.GetMessage( "Resident Country", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCountry_Internalname, A354ResidentCountry, StringUtil.RTrim( context.localUtil.Format( A354ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentCountry_Visible, edtResidentCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Resident.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_residentphonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidentphonecode_Internalname, AV39ComboResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV39ComboResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidentphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidentphonecode_Visible, edtavComboresidentphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residenthomephonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidenthomephonecode_Internalname, AV44ComboResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( AV44ComboResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidenthomephonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidenthomephonecode_Visible, edtavComboresidenthomephonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residentcountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidentcountry_Internalname, AV38ComboResidentCountry, StringUtil.RTrim( context.localUtil.Format( AV38ComboResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidentcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidentcountry_Visible, edtavComboresidentcountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentId_Visible, edtResidentId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentInitials_Internalname, StringUtil.RTrim( A66ResidentInitials), StringUtil.RTrim( context.localUtil.Format( A66ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentInitials_Visible, edtResidentInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, edtResidentGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentTypeId_Internalname, A96ResidentTypeId.ToString(), A96ResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentTypeId_Visible, edtResidentTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedicalIndicationId_Internalname, A98MedicalIndicationId.ToString(), A98MedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedicalIndicationId_Jsonclick, 0, "Attribute", "", "", "", "", edtMedicalIndicationId_Visible, edtMedicalIndicationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
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
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPHONECODE_DATA"), AV41ResidentPhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTHOMEPHONECODE_DATA"), AV43ResidentHomePhoneCode_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTCOUNTRY_DATA"), AV37ResidentCountry_Data);
               /* Read saved values. */
               Z62ResidentId = StringUtil.StrToGuid( cgiGet( "Z62ResidentId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z354ResidentCountry = cgiGet( "Z354ResidentCountry");
               Z445ResidentHomePhoneCode = cgiGet( "Z445ResidentHomePhoneCode");
               Z375ResidentPhoneCode = cgiGet( "Z375ResidentPhoneCode");
               Z66ResidentInitials = cgiGet( "Z66ResidentInitials");
               Z70ResidentPhone = cgiGet( "Z70ResidentPhone");
               Z444ResidentHomePhone = cgiGet( "Z444ResidentHomePhone");
               Z72ResidentSalutation = cgiGet( "Z72ResidentSalutation");
               Z63ResidentBsnNumber = cgiGet( "Z63ResidentBsnNumber");
               Z64ResidentGivenName = cgiGet( "Z64ResidentGivenName");
               Z65ResidentLastName = cgiGet( "Z65ResidentLastName");
               Z67ResidentEmail = cgiGet( "Z67ResidentEmail");
               Z68ResidentGender = cgiGet( "Z68ResidentGender");
               Z355ResidentCity = cgiGet( "Z355ResidentCity");
               Z356ResidentZipCode = cgiGet( "Z356ResidentZipCode");
               Z357ResidentAddressLine1 = cgiGet( "Z357ResidentAddressLine1");
               Z358ResidentAddressLine2 = cgiGet( "Z358ResidentAddressLine2");
               Z73ResidentBirthDate = context.localUtil.CToD( cgiGet( "Z73ResidentBirthDate"), 0);
               Z71ResidentGUID = cgiGet( "Z71ResidentGUID");
               Z376ResidentPhoneNumber = cgiGet( "Z376ResidentPhoneNumber");
               Z446ResidentHomePhoneNumber = cgiGet( "Z446ResidentHomePhoneNumber");
               Z96ResidentTypeId = StringUtil.StrToGuid( cgiGet( "Z96ResidentTypeId"));
               n96ResidentTypeId = ((Guid.Empty==A96ResidentTypeId) ? true : false);
               Z98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "Z98MedicalIndicationId"));
               n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N96ResidentTypeId = StringUtil.StrToGuid( cgiGet( "N96ResidentTypeId"));
               n96ResidentTypeId = ((Guid.Empty==A96ResidentTypeId) ? true : false);
               N98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "N98MedicalIndicationId"));
               n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
               AV7ResidentId = StringUtil.StrToGuid( cgiGet( "vRESIDENTID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV9OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV15Insert_ResidentTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_RESIDENTTYPEID"));
               AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "vINSERT_MEDICALINDICATIONID"));
               AV36GAMErrorResponse = cgiGet( "vGAMERRORRESPONSE");
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV42AuditingObject);
               A457ResidentImage = cgiGet( "RESIDENTIMAGE");
               n457ResidentImage = (String.IsNullOrEmpty(StringUtil.RTrim( A457ResidentImage)) ? true : false);
               A40000ResidentImage_GXI = cgiGet( "RESIDENTIMAGE_GXI");
               n40000ResidentImage_GXI = false;
               n40000ResidentImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ResidentImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A457ResidentImage)) ? true : false);
               A97ResidentTypeName = cgiGet( "RESIDENTTYPENAME");
               A99MedicalIndicationName = cgiGet( "MEDICALINDICATIONNAME");
               AV46Pgmname = cgiGet( "vPGMNAME");
               Combo_residentphonecode_Objectcall = cgiGet( "COMBO_RESIDENTPHONECODE_Objectcall");
               Combo_residentphonecode_Class = cgiGet( "COMBO_RESIDENTPHONECODE_Class");
               Combo_residentphonecode_Icontype = cgiGet( "COMBO_RESIDENTPHONECODE_Icontype");
               Combo_residentphonecode_Icon = cgiGet( "COMBO_RESIDENTPHONECODE_Icon");
               Combo_residentphonecode_Caption = cgiGet( "COMBO_RESIDENTPHONECODE_Caption");
               Combo_residentphonecode_Tooltip = cgiGet( "COMBO_RESIDENTPHONECODE_Tooltip");
               Combo_residentphonecode_Cls = cgiGet( "COMBO_RESIDENTPHONECODE_Cls");
               Combo_residentphonecode_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedvalue_set");
               Combo_residentphonecode_Selectedvalue_get = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedvalue_get");
               Combo_residentphonecode_Selectedtext_set = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedtext_set");
               Combo_residentphonecode_Selectedtext_get = cgiGet( "COMBO_RESIDENTPHONECODE_Selectedtext_get");
               Combo_residentphonecode_Gamoauthtoken = cgiGet( "COMBO_RESIDENTPHONECODE_Gamoauthtoken");
               Combo_residentphonecode_Ddointernalname = cgiGet( "COMBO_RESIDENTPHONECODE_Ddointernalname");
               Combo_residentphonecode_Titlecontrolalign = cgiGet( "COMBO_RESIDENTPHONECODE_Titlecontrolalign");
               Combo_residentphonecode_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTPHONECODE_Dropdownoptionstype");
               Combo_residentphonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Enabled"));
               Combo_residentphonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Visible"));
               Combo_residentphonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTPHONECODE_Titlecontrolidtoreplace");
               Combo_residentphonecode_Datalisttype = cgiGet( "COMBO_RESIDENTPHONECODE_Datalisttype");
               Combo_residentphonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Allowmultipleselection"));
               Combo_residentphonecode_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTPHONECODE_Datalistfixedvalues");
               Combo_residentphonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Isgriditem"));
               Combo_residentphonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Hasdescription"));
               Combo_residentphonecode_Datalistproc = cgiGet( "COMBO_RESIDENTPHONECODE_Datalistproc");
               Combo_residentphonecode_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTPHONECODE_Datalistprocparametersprefix");
               Combo_residentphonecode_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTPHONECODE_Remoteservicesparameters");
               Combo_residentphonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residentphonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Includeonlyselectedoption"));
               Combo_residentphonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Includeselectalloption"));
               Combo_residentphonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Emptyitem"));
               Combo_residentphonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPHONECODE_Includeaddnewoption"));
               Combo_residentphonecode_Htmltemplate = cgiGet( "COMBO_RESIDENTPHONECODE_Htmltemplate");
               Combo_residentphonecode_Multiplevaluestype = cgiGet( "COMBO_RESIDENTPHONECODE_Multiplevaluestype");
               Combo_residentphonecode_Loadingdata = cgiGet( "COMBO_RESIDENTPHONECODE_Loadingdata");
               Combo_residentphonecode_Noresultsfound = cgiGet( "COMBO_RESIDENTPHONECODE_Noresultsfound");
               Combo_residentphonecode_Emptyitemtext = cgiGet( "COMBO_RESIDENTPHONECODE_Emptyitemtext");
               Combo_residentphonecode_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTPHONECODE_Onlyselectedvalues");
               Combo_residentphonecode_Selectalltext = cgiGet( "COMBO_RESIDENTPHONECODE_Selectalltext");
               Combo_residentphonecode_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTPHONECODE_Multiplevaluesseparator");
               Combo_residentphonecode_Addnewoptiontext = cgiGet( "COMBO_RESIDENTPHONECODE_Addnewoptiontext");
               Combo_residentphonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residenthomephonecode_Objectcall = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Objectcall");
               Combo_residenthomephonecode_Class = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Class");
               Combo_residenthomephonecode_Icontype = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Icontype");
               Combo_residenthomephonecode_Icon = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Icon");
               Combo_residenthomephonecode_Caption = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Caption");
               Combo_residenthomephonecode_Tooltip = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Tooltip");
               Combo_residenthomephonecode_Cls = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Cls");
               Combo_residenthomephonecode_Selectedvalue_set = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_set");
               Combo_residenthomephonecode_Selectedvalue_get = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_get");
               Combo_residenthomephonecode_Selectedtext_set = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedtext_set");
               Combo_residenthomephonecode_Selectedtext_get = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectedtext_get");
               Combo_residenthomephonecode_Gamoauthtoken = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Gamoauthtoken");
               Combo_residenthomephonecode_Ddointernalname = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Ddointernalname");
               Combo_residenthomephonecode_Titlecontrolalign = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Titlecontrolalign");
               Combo_residenthomephonecode_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Dropdownoptionstype");
               Combo_residenthomephonecode_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Enabled"));
               Combo_residenthomephonecode_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Visible"));
               Combo_residenthomephonecode_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Titlecontrolidtoreplace");
               Combo_residenthomephonecode_Datalisttype = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Datalisttype");
               Combo_residenthomephonecode_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Allowmultipleselection"));
               Combo_residenthomephonecode_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Datalistfixedvalues");
               Combo_residenthomephonecode_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Isgriditem"));
               Combo_residenthomephonecode_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Hasdescription"));
               Combo_residenthomephonecode_Datalistproc = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Datalistproc");
               Combo_residenthomephonecode_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Datalistprocparametersprefix");
               Combo_residenthomephonecode_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Remoteservicesparameters");
               Combo_residenthomephonecode_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residenthomephonecode_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Includeonlyselectedoption"));
               Combo_residenthomephonecode_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Includeselectalloption"));
               Combo_residenthomephonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Emptyitem"));
               Combo_residenthomephonecode_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Includeaddnewoption"));
               Combo_residenthomephonecode_Htmltemplate = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Htmltemplate");
               Combo_residenthomephonecode_Multiplevaluestype = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Multiplevaluestype");
               Combo_residenthomephonecode_Loadingdata = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Loadingdata");
               Combo_residenthomephonecode_Noresultsfound = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Noresultsfound");
               Combo_residenthomephonecode_Emptyitemtext = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Emptyitemtext");
               Combo_residenthomephonecode_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Onlyselectedvalues");
               Combo_residenthomephonecode_Selectalltext = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Selectalltext");
               Combo_residenthomephonecode_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Multiplevaluesseparator");
               Combo_residenthomephonecode_Addnewoptiontext = cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Addnewoptiontext");
               Combo_residenthomephonecode_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTHOMEPHONECODE_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residentcountry_Objectcall = cgiGet( "COMBO_RESIDENTCOUNTRY_Objectcall");
               Combo_residentcountry_Class = cgiGet( "COMBO_RESIDENTCOUNTRY_Class");
               Combo_residentcountry_Icontype = cgiGet( "COMBO_RESIDENTCOUNTRY_Icontype");
               Combo_residentcountry_Icon = cgiGet( "COMBO_RESIDENTCOUNTRY_Icon");
               Combo_residentcountry_Caption = cgiGet( "COMBO_RESIDENTCOUNTRY_Caption");
               Combo_residentcountry_Tooltip = cgiGet( "COMBO_RESIDENTCOUNTRY_Tooltip");
               Combo_residentcountry_Cls = cgiGet( "COMBO_RESIDENTCOUNTRY_Cls");
               Combo_residentcountry_Selectedvalue_set = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedvalue_set");
               Combo_residentcountry_Selectedvalue_get = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedvalue_get");
               Combo_residentcountry_Selectedtext_set = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedtext_set");
               Combo_residentcountry_Selectedtext_get = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectedtext_get");
               Combo_residentcountry_Gamoauthtoken = cgiGet( "COMBO_RESIDENTCOUNTRY_Gamoauthtoken");
               Combo_residentcountry_Ddointernalname = cgiGet( "COMBO_RESIDENTCOUNTRY_Ddointernalname");
               Combo_residentcountry_Titlecontrolalign = cgiGet( "COMBO_RESIDENTCOUNTRY_Titlecontrolalign");
               Combo_residentcountry_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTCOUNTRY_Dropdownoptionstype");
               Combo_residentcountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Enabled"));
               Combo_residentcountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Visible"));
               Combo_residentcountry_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTCOUNTRY_Titlecontrolidtoreplace");
               Combo_residentcountry_Datalisttype = cgiGet( "COMBO_RESIDENTCOUNTRY_Datalisttype");
               Combo_residentcountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Allowmultipleselection"));
               Combo_residentcountry_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTCOUNTRY_Datalistfixedvalues");
               Combo_residentcountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Isgriditem"));
               Combo_residentcountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Hasdescription"));
               Combo_residentcountry_Datalistproc = cgiGet( "COMBO_RESIDENTCOUNTRY_Datalistproc");
               Combo_residentcountry_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTCOUNTRY_Datalistprocparametersprefix");
               Combo_residentcountry_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTCOUNTRY_Remoteservicesparameters");
               Combo_residentcountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTCOUNTRY_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residentcountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Includeonlyselectedoption"));
               Combo_residentcountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Includeselectalloption"));
               Combo_residentcountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Emptyitem"));
               Combo_residentcountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTCOUNTRY_Includeaddnewoption"));
               Combo_residentcountry_Htmltemplate = cgiGet( "COMBO_RESIDENTCOUNTRY_Htmltemplate");
               Combo_residentcountry_Multiplevaluestype = cgiGet( "COMBO_RESIDENTCOUNTRY_Multiplevaluestype");
               Combo_residentcountry_Loadingdata = cgiGet( "COMBO_RESIDENTCOUNTRY_Loadingdata");
               Combo_residentcountry_Noresultsfound = cgiGet( "COMBO_RESIDENTCOUNTRY_Noresultsfound");
               Combo_residentcountry_Emptyitemtext = cgiGet( "COMBO_RESIDENTCOUNTRY_Emptyitemtext");
               Combo_residentcountry_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTCOUNTRY_Onlyselectedvalues");
               Combo_residentcountry_Selectalltext = cgiGet( "COMBO_RESIDENTCOUNTRY_Selectalltext");
               Combo_residentcountry_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTCOUNTRY_Multiplevaluesseparator");
               Combo_residentcountry_Addnewoptiontext = cgiGet( "COMBO_RESIDENTCOUNTRY_Addnewoptiontext");
               Combo_residentcountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTCOUNTRY_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
               A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
               AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
               A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
               AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
               A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
               AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
               cmbResidentGender.CurrentValue = cgiGet( cmbResidentGender_Internalname);
               A68ResidentGender = cgiGet( cmbResidentGender_Internalname);
               AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
               if ( context.localUtil.VCDate( cgiGet( edtResidentBirthDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Resident Birth Date", "")}), 1, "RESIDENTBIRTHDATE");
                  AnyError = 1;
                  GX_FocusControl = edtResidentBirthDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A73ResidentBirthDate = DateTime.MinValue;
                  AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
               }
               else
               {
                  A73ResidentBirthDate = context.localUtil.CToD( cgiGet( edtResidentBirthDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
               }
               A67ResidentEmail = cgiGet( edtResidentEmail_Internalname);
               AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
               A375ResidentPhoneCode = cgiGet( edtResidentPhoneCode_Internalname);
               AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
               A376ResidentPhoneNumber = cgiGet( edtResidentPhoneNumber_Internalname);
               AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
               A445ResidentHomePhoneCode = cgiGet( edtResidentHomePhoneCode_Internalname);
               AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
               A446ResidentHomePhoneNumber = cgiGet( edtResidentHomePhoneNumber_Internalname);
               AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
               A70ResidentPhone = cgiGet( edtResidentPhone_Internalname);
               AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
               A444ResidentHomePhone = cgiGet( edtResidentHomePhone_Internalname);
               AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
               A63ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
               AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
               A357ResidentAddressLine1 = cgiGet( edtResidentAddressLine1_Internalname);
               AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
               A358ResidentAddressLine2 = cgiGet( edtResidentAddressLine2_Internalname);
               AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
               A356ResidentZipCode = cgiGet( edtResidentZipCode_Internalname);
               AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
               A355ResidentCity = cgiGet( edtResidentCity_Internalname);
               AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
               A354ResidentCountry = cgiGet( edtResidentCountry_Internalname);
               AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
               AV39ComboResidentPhoneCode = cgiGet( edtavComboresidentphonecode_Internalname);
               AssignAttri("", false, "AV39ComboResidentPhoneCode", AV39ComboResidentPhoneCode);
               AV44ComboResidentHomePhoneCode = cgiGet( edtavComboresidenthomephonecode_Internalname);
               AssignAttri("", false, "AV44ComboResidentHomePhoneCode", AV44ComboResidentHomePhoneCode);
               AV38ComboResidentCountry = cgiGet( edtavComboresidentcountry_Internalname);
               AssignAttri("", false, "AV38ComboResidentCountry", AV38ComboResidentCountry);
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
               A66ResidentInitials = cgiGet( edtResidentInitials_Internalname);
               AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
               A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
               AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
               if ( StringUtil.StrCmp(cgiGet( edtResidentTypeId_Internalname), "") == 0 )
               {
                  A96ResidentTypeId = Guid.Empty;
                  n96ResidentTypeId = false;
                  AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A96ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtResidentTypeId_Internalname));
                     n96ResidentTypeId = false;
                     AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n96ResidentTypeId = ((Guid.Empty==A96ResidentTypeId) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtMedicalIndicationId_Internalname), "") == 0 )
               {
                  A98MedicalIndicationId = Guid.Empty;
                  n98MedicalIndicationId = false;
                  AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
               }
               else
               {
                  try
                  {
                     A98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtMedicalIndicationId_Internalname));
                     n98MedicalIndicationId = false;
                     AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MEDICALINDICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtMedicalIndicationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Resident");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_resident:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7ResidentId) )
                  {
                     A62ResidentId = AV7ResidentId;
                     AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A62ResidentId) && ( Gx_BScreen == 0 ) )
                     {
                        A62ResidentId = Guid.NewGuid( );
                        AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
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
                     sMode16 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7ResidentId) )
                     {
                        A62ResidentId = AV7ResidentId;
                        AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A62ResidentId) && ( Gx_BScreen == 0 ) )
                        {
                           A62ResidentId = Guid.NewGuid( );
                           AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                        }
                     }
                     Gx_mode = sMode16;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound16 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RESIDENTID");
                        AnyError = 1;
                        GX_FocusControl = edtResidentId_Internalname;
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
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
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
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0916( ) ;
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
            DisableAttributes0916( ) ;
         }
         AssignProp("", false, edtavComboresidentphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentphonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboresidenthomephonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenthomephonecode_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboresidentcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentcountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_090( )
      {
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0916( ) ;
            }
            else
            {
               CheckExtendedTable0916( ) ;
               CloseExtendedTableCursors0916( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtResidentCountry_Visible = 0;
         AssignProp("", false, edtResidentCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentCountry_Visible), 5, 0), true);
         AV38ComboResidentCountry = "";
         AssignAttri("", false, "AV38ComboResidentCountry", AV38ComboResidentCountry);
         edtavComboresidentcountry_Visible = 0;
         AssignProp("", false, edtavComboresidentcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidentcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentcountry_Htmltemplate = GXt_char2;
         ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "HTMLTemplate", Combo_residentcountry_Htmltemplate);
         edtResidentHomePhoneCode_Visible = 0;
         AssignProp("", false, edtResidentHomePhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhoneCode_Visible), 5, 0), true);
         AV44ComboResidentHomePhoneCode = "";
         AssignAttri("", false, "AV44ComboResidentHomePhoneCode", AV44ComboResidentHomePhoneCode);
         edtavComboresidenthomephonecode_Visible = 0;
         AssignProp("", false, edtavComboresidenthomephonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidenthomephonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residenthomephonecode_Htmltemplate = GXt_char2;
         ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "HTMLTemplate", Combo_residenthomephonecode_Htmltemplate);
         edtResidentPhoneCode_Visible = 0;
         AssignProp("", false, edtResidentPhoneCode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhoneCode_Visible), 5, 0), true);
         AV39ComboResidentPhoneCode = "";
         AssignAttri("", false, "AV39ComboResidentPhoneCode", AV39ComboResidentPhoneCode);
         edtavComboresidentphonecode_Visible = 0;
         AssignProp("", false, edtavComboresidentphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidentphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentphonecode_Htmltemplate = GXt_char2;
         ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "HTMLTemplate", Combo_residentphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPHONECODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORESIDENTHOMEPHONECODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORESIDENTCOUNTRY' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV46Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV47GXV1 = 1;
            AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            while ( AV47GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV47GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV15Insert_ResidentTypeId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV15Insert_ResidentTypeId", AV15Insert_ResidentTypeId.ToString());
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MedicalIndicationId") == 0 )
               {
                  AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV16Insert_MedicalIndicationId", AV16Insert_MedicalIndicationId.ToString());
               }
               AV47GXV1 = (int)(AV47GXV1+1);
               AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            }
         }
         edtResidentId_Visible = 0;
         AssignProp("", false, edtResidentId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentId_Visible), 5, 0), true);
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtResidentInitials_Visible = 0;
         AssignProp("", false, edtResidentInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
         edtResidentTypeId_Visible = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Visible), 5, 0), true);
         edtMedicalIndicationId_Visible = 0;
         AssignProp("", false, edtMedicalIndicationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Visible), 5, 0), true);
         AV40defaultCountryPhoneCode = "+31";
         AssignAttri("", false, "AV40defaultCountryPhoneCode", AV40defaultCountryPhoneCode);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A375ResidentPhoneCode)) )
         {
            AV40defaultCountryPhoneCode = "+31";
            AssignAttri("", false, "AV40defaultCountryPhoneCode", AV40defaultCountryPhoneCode);
            Combo_residentphonecode_Selectedvalue_set = AV40defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
            Combo_residentphonecode_Selectedtext_set = AV40defaultCountryPhoneCode;
            ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A445ResidentHomePhoneCode)) )
         {
            Combo_residenthomephonecode_Selectedvalue_set = AV40defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
            Combo_residenthomephonecode_Selectedtext_set = AV40defaultCountryPhoneCode;
            ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedText_set", Combo_residenthomephonecode_Selectedtext_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A354ResidentCountry)) )
         {
            Combo_residentcountry_Selectedvalue_set = "Netherlands";
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
            Combo_residentcountry_Selectedtext_set = "Netherlands";
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38ComboResidentCountry)) )
         {
            AV38ComboResidentCountry = "Netherlands";
            AssignAttri("", false, "AV38ComboResidentCountry", AV38ComboResidentCountry);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ComboResidentPhoneCode)) )
         {
            AV39ComboResidentPhoneCode = AV40defaultCountryPhoneCode;
            AssignAttri("", false, "AV39ComboResidentPhoneCode", AV39ComboResidentPhoneCode);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44ComboResidentHomePhoneCode)) )
         {
            AV44ComboResidentHomePhoneCode = AV40defaultCountryPhoneCode;
            AssignAttri("", false, "AV44ComboResidentHomePhoneCode", AV44ComboResidentHomePhoneCode);
         }
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV14WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Resident Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Resident Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV14WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Resident Inserted successfully", ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
            new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV46Pgmname) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
            {
               CallWebObject(formatLink("trn_residentww.aspx") );
               context.wjLocDisableFrm = 1;
            }
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV46Pgmname) ;
            CallWebObject(formatLink("wp_locationresidents.aspx") );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtResidentPhone_Visible = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), true);
         divResidentphone_cell_Class = "Invisible";
         AssignProp("", false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         edtResidentHomePhone_Visible = 0;
         AssignProp("", false, edtResidentHomePhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Visible), 5, 0), true);
         divResidenthomephone_cell_Class = "Invisible";
         AssignProp("", false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESIDENTCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV37ResidentCountry_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentCountry",  Gx_mode,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV37ResidentCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_residentcountry_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
         AV38ComboResidentCountry = AV20ComboSelectedValue;
         AssignAttri("", false, "AV38ComboResidentCountry", AV38ComboResidentCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residentcountry_Enabled = false;
            ucCombo_residentcountry.SendProperty(context, "", false, Combo_residentcountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residentcountry_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV43ResidentHomePhoneCode_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentHomePhoneCode",  Gx_mode,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV43ResidentHomePhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_residenthomephonecode_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "SelectedValue_set", Combo_residenthomephonecode_Selectedvalue_set);
         AV44ComboResidentHomePhoneCode = AV20ComboSelectedValue;
         AssignAttri("", false, "AV44ComboResidentHomePhoneCode", AV44ComboResidentHomePhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residenthomephonecode_Enabled = false;
            ucCombo_residenthomephonecode.SendProperty(context, "", false, Combo_residenthomephonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenthomephonecode_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTPHONECODE' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV41ResidentPhoneCode_Data;
         new trn_residentloaddvcombo(context ).execute(  "ResidentPhoneCode",  Gx_mode,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV41ResidentPhoneCode_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_residentphonecode_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
         AV39ComboResidentPhoneCode = AV20ComboSelectedValue;
         AssignAttri("", false, "AV39ComboResidentPhoneCode", AV39ComboResidentPhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residentphonecode_Enabled = false;
            ucCombo_residentphonecode.SendProperty(context, "", false, Combo_residentphonecode_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residentphonecode_Enabled));
         }
      }

      protected void ZM0916( short GX_JID )
      {
         if ( ( GX_JID == 60 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z354ResidentCountry = T00093_A354ResidentCountry[0];
               Z445ResidentHomePhoneCode = T00093_A445ResidentHomePhoneCode[0];
               Z375ResidentPhoneCode = T00093_A375ResidentPhoneCode[0];
               Z66ResidentInitials = T00093_A66ResidentInitials[0];
               Z70ResidentPhone = T00093_A70ResidentPhone[0];
               Z444ResidentHomePhone = T00093_A444ResidentHomePhone[0];
               Z72ResidentSalutation = T00093_A72ResidentSalutation[0];
               Z63ResidentBsnNumber = T00093_A63ResidentBsnNumber[0];
               Z64ResidentGivenName = T00093_A64ResidentGivenName[0];
               Z65ResidentLastName = T00093_A65ResidentLastName[0];
               Z67ResidentEmail = T00093_A67ResidentEmail[0];
               Z68ResidentGender = T00093_A68ResidentGender[0];
               Z355ResidentCity = T00093_A355ResidentCity[0];
               Z356ResidentZipCode = T00093_A356ResidentZipCode[0];
               Z357ResidentAddressLine1 = T00093_A357ResidentAddressLine1[0];
               Z358ResidentAddressLine2 = T00093_A358ResidentAddressLine2[0];
               Z73ResidentBirthDate = T00093_A73ResidentBirthDate[0];
               Z71ResidentGUID = T00093_A71ResidentGUID[0];
               Z376ResidentPhoneNumber = T00093_A376ResidentPhoneNumber[0];
               Z446ResidentHomePhoneNumber = T00093_A446ResidentHomePhoneNumber[0];
               Z96ResidentTypeId = T00093_A96ResidentTypeId[0];
               Z98MedicalIndicationId = T00093_A98MedicalIndicationId[0];
            }
            else
            {
               Z354ResidentCountry = A354ResidentCountry;
               Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
               Z375ResidentPhoneCode = A375ResidentPhoneCode;
               Z66ResidentInitials = A66ResidentInitials;
               Z70ResidentPhone = A70ResidentPhone;
               Z444ResidentHomePhone = A444ResidentHomePhone;
               Z72ResidentSalutation = A72ResidentSalutation;
               Z63ResidentBsnNumber = A63ResidentBsnNumber;
               Z64ResidentGivenName = A64ResidentGivenName;
               Z65ResidentLastName = A65ResidentLastName;
               Z67ResidentEmail = A67ResidentEmail;
               Z68ResidentGender = A68ResidentGender;
               Z355ResidentCity = A355ResidentCity;
               Z356ResidentZipCode = A356ResidentZipCode;
               Z357ResidentAddressLine1 = A357ResidentAddressLine1;
               Z358ResidentAddressLine2 = A358ResidentAddressLine2;
               Z73ResidentBirthDate = A73ResidentBirthDate;
               Z71ResidentGUID = A71ResidentGUID;
               Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
               Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
               Z96ResidentTypeId = A96ResidentTypeId;
               Z98MedicalIndicationId = A98MedicalIndicationId;
            }
         }
         if ( GX_JID == -60 )
         {
            Z62ResidentId = A62ResidentId;
            Z354ResidentCountry = A354ResidentCountry;
            Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
            Z444ResidentHomePhone = A444ResidentHomePhone;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z355ResidentCity = A355ResidentCity;
            Z356ResidentZipCode = A356ResidentZipCode;
            Z357ResidentAddressLine1 = A357ResidentAddressLine1;
            Z358ResidentAddressLine2 = A358ResidentAddressLine2;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
            Z457ResidentImage = A457ResidentImage;
            Z40000ResidentImage_GXI = A40000ResidentImage_GXI;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtResidentPhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divResidentphone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divResidentphone_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divResidentphone_cell_Internalname, "Class", divResidentphone_cell_Class, true);
            }
         }
         edtResidentHomePhone_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "DLT")==0) ? 1 : 0);
         AssignProp("", false, edtResidentHomePhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            divResidenthomephone_cell_Class = context.GetMessage( "Invisible", "");
            AssignProp("", false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               divResidenthomephone_cell_Class = context.GetMessage( "col-xs-12 DataContentCell", "");
               AssignProp("", false, divResidenthomephone_cell_Internalname, "Class", divResidenthomephone_cell_Class, true);
            }
         }
         divPhonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divPhonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPhonenumber_Visible), 5, 0), true);
         divHomephonenumber_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divHomephonenumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divHomephonenumber_Visible), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV46Pgmname = "Trn_Resident";
         AssignAttri("", false, "AV46Pgmname", AV46Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7ResidentId) )
         {
            edtResidentId_Enabled = 0;
            AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentId_Enabled = 1;
            AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7ResidentId) )
         {
            edtResidentId_Enabled = 0;
            AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            A29LocationId = AV8LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            A11OrganisationId = AV9OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_ResidentTypeId) )
         {
            edtResidentTypeId_Enabled = 0;
            AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentTypeId_Enabled = 1;
            AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV16Insert_MedicalIndicationId) )
         {
            edtMedicalIndicationId_Enabled = 0;
            AssignProp("", false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
         }
         else
         {
            edtMedicalIndicationId_Enabled = 1;
            AssignProp("", false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtResidentEmail_Enabled = 0;
            AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentEmail_Enabled = 1;
            AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         }
         if ( IsUpd( )  )
         {
            edtResidentEmail_Enabled = 0;
            AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV16Insert_MedicalIndicationId) )
         {
            A98MedicalIndicationId = AV16Insert_MedicalIndicationId;
            n98MedicalIndicationId = false;
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_ResidentTypeId) )
         {
            A96ResidentTypeId = AV15Insert_ResidentTypeId;
            n96ResidentTypeId = false;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         }
         A375ResidentPhoneCode = AV39ComboResidentPhoneCode;
         AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
         A445ResidentHomePhoneCode = AV44ComboResidentHomePhoneCode;
         AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
         A354ResidentCountry = AV38ComboResidentCountry;
         AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
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
         if ( ! (Guid.Empty==AV7ResidentId) )
         {
            A62ResidentId = AV7ResidentId;
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A62ResidentId) && ( Gx_BScreen == 0 ) )
            {
               A62ResidentId = Guid.NewGuid( );
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00096 */
            pr_default.execute(4, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = T00096_A99MedicalIndicationName[0];
            pr_default.close(4);
            /* Using cursor T00095 */
            pr_default.execute(3, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            A97ResidentTypeName = T00095_A97ResidentTypeName[0];
            pr_default.close(3);
         }
      }

      protected void Load0916( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound16 = 1;
            A354ResidentCountry = T00097_A354ResidentCountry[0];
            AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
            A445ResidentHomePhoneCode = T00097_A445ResidentHomePhoneCode[0];
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A375ResidentPhoneCode = T00097_A375ResidentPhoneCode[0];
            AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
            A66ResidentInitials = T00097_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A70ResidentPhone = T00097_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A444ResidentHomePhone = T00097_A444ResidentHomePhone[0];
            AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
            A72ResidentSalutation = T00097_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T00097_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T00097_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T00097_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A67ResidentEmail = T00097_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T00097_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A355ResidentCity = T00097_A355ResidentCity[0];
            AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
            A356ResidentZipCode = T00097_A356ResidentZipCode[0];
            AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
            A357ResidentAddressLine1 = T00097_A357ResidentAddressLine1[0];
            AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
            A358ResidentAddressLine2 = T00097_A358ResidentAddressLine2[0];
            AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
            A73ResidentBirthDate = T00097_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A71ResidentGUID = T00097_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A97ResidentTypeName = T00097_A97ResidentTypeName[0];
            A99MedicalIndicationName = T00097_A99MedicalIndicationName[0];
            A376ResidentPhoneNumber = T00097_A376ResidentPhoneNumber[0];
            AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
            A446ResidentHomePhoneNumber = T00097_A446ResidentHomePhoneNumber[0];
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            A40000ResidentImage_GXI = T00097_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = T00097_n40000ResidentImage_GXI[0];
            A96ResidentTypeId = T00097_A96ResidentTypeId[0];
            n96ResidentTypeId = T00097_n96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T00097_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T00097_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            A457ResidentImage = T00097_A457ResidentImage[0];
            n457ResidentImage = T00097_n457ResidentImage[0];
            ZM0916( -60) ;
         }
         pr_default.close(5);
         OnLoadActions0916( ) ;
      }

      protected void OnLoadActions0916( )
      {
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         GXt_char2 = A444ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber, out  GXt_char2) ;
         A444ResidentHomePhone = GXt_char2;
         AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
      }

      protected void CheckExtendedTable0916( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A72ResidentSalutation, "Mr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Mrs") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Dr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Miss") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Salutation", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTSALUTATION");
            AnyError = 1;
            GX_FocusControl = cmbResidentSalutation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A63ResidentBsnNumber)) && ( StringUtil.Len( A63ResidentBsnNumber) != 9 ) )
         {
            GX_msglist.addItem(context.GetMessage( "BSN number contains 9 digits", ""), 1, "RESIDENTBSNNUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Given Name", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTGIVENNAME");
            AnyError = 1;
            GX_FocusControl = edtResidentGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         new prc_getnameinitials(context ).execute(  A64ResidentGivenName,  A65ResidentLastName, out  A66ResidentInitials) ;
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Last Name", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtResidentLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A67ResidentEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtResidentEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtResidentEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A68ResidentGender, "Male") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Female") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTGENDER");
            AnyError = 1;
            GX_FocusControl = cmbResidentGender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A356ResidentZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A356ResidentZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "RESIDENTZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtResidentZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
               GX_FocusControl = edtResidentTypeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A97ResidentTypeName = T00095_A97ResidentTypeName[0];
         pr_default.close(3);
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A99MedicalIndicationName = T00096_A99MedicalIndicationName[0];
         pr_default.close(4);
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A376ResidentPhoneNumber)) && ! GxRegex.IsMatch(A376ResidentPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char2 = A444ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber, out  GXt_char2) ;
         A444ResidentHomePhone = GXt_char2;
         AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A446ResidentHomePhoneNumber)) && ! GxRegex.IsMatch(A446ResidentHomePhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTHOMEPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentHomePhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0916( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_61( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_62( Guid A96ResidentTypeId )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
               GX_FocusControl = edtResidentTypeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A97ResidentTypeName = T00099_A97ResidentTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A97ResidentTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_63( Guid A98MedicalIndicationId )
      {
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A99MedicalIndicationName = T000910_A99MedicalIndicationName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A99MedicalIndicationName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0916( )
      {
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0916( 60) ;
            RcdFound16 = 1;
            A62ResidentId = T00093_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A354ResidentCountry = T00093_A354ResidentCountry[0];
            AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
            A445ResidentHomePhoneCode = T00093_A445ResidentHomePhoneCode[0];
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A375ResidentPhoneCode = T00093_A375ResidentPhoneCode[0];
            AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
            A66ResidentInitials = T00093_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A70ResidentPhone = T00093_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A444ResidentHomePhone = T00093_A444ResidentHomePhone[0];
            AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
            A72ResidentSalutation = T00093_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T00093_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T00093_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T00093_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A67ResidentEmail = T00093_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T00093_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A355ResidentCity = T00093_A355ResidentCity[0];
            AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
            A356ResidentZipCode = T00093_A356ResidentZipCode[0];
            AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
            A357ResidentAddressLine1 = T00093_A357ResidentAddressLine1[0];
            AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
            A358ResidentAddressLine2 = T00093_A358ResidentAddressLine2[0];
            AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
            A73ResidentBirthDate = T00093_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A71ResidentGUID = T00093_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A376ResidentPhoneNumber = T00093_A376ResidentPhoneNumber[0];
            AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
            A446ResidentHomePhoneNumber = T00093_A446ResidentHomePhoneNumber[0];
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            A40000ResidentImage_GXI = T00093_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = T00093_n40000ResidentImage_GXI[0];
            A29LocationId = T00093_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T00093_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A96ResidentTypeId = T00093_A96ResidentTypeId[0];
            n96ResidentTypeId = T00093_n96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T00093_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T00093_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            A457ResidentImage = T00093_A457ResidentImage[0];
            n457ResidentImage = T00093_n457ResidentImage[0];
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0916( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0916( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0916( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0916( ) ;
         if ( RcdFound16 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T000912 */
         pr_default.execute(10, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000912_A62ResidentId[0], A62ResidentId, 0) < 0 ) || ( T000912_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000912_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000912_A29LocationId[0] == A29LocationId ) && ( T000912_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000912_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000912_A62ResidentId[0], A62ResidentId, 0) > 0 ) || ( T000912_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000912_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000912_A29LocationId[0] == A29LocationId ) && ( T000912_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000912_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A62ResidentId = T000912_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               A29LocationId = T000912_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000912_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound16 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000913 */
         pr_default.execute(11, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000913_A62ResidentId[0], A62ResidentId, 0) > 0 ) || ( T000913_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000913_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000913_A29LocationId[0] == A29LocationId ) && ( T000913_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000913_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000913_A62ResidentId[0], A62ResidentId, 0) < 0 ) || ( T000913_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000913_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000913_A29LocationId[0] == A29LocationId ) && ( T000913_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000913_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A62ResidentId = T000913_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               A29LocationId = T000913_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000913_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound16 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0916( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbResidentSalutation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0916( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A62ResidentId = Z62ResidentId;
                  AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESIDENTID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbResidentSalutation_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0916( ) ;
                  GX_FocusControl = cmbResidentSalutation_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = cmbResidentSalutation_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0916( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESIDENTID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbResidentSalutation_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0916( ) ;
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
         if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A62ResidentId = Z62ResidentId;
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESIDENTID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbResidentSalutation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0916( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z354ResidentCountry, T00092_A354ResidentCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z445ResidentHomePhoneCode, T00092_A445ResidentHomePhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z375ResidentPhoneCode, T00092_A375ResidentPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z66ResidentInitials, T00092_A66ResidentInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z70ResidentPhone, T00092_A70ResidentPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z444ResidentHomePhone, T00092_A444ResidentHomePhone[0]) != 0 ) || ( StringUtil.StrCmp(Z72ResidentSalutation, T00092_A72ResidentSalutation[0]) != 0 ) || ( StringUtil.StrCmp(Z63ResidentBsnNumber, T00092_A63ResidentBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z64ResidentGivenName, T00092_A64ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z65ResidentLastName, T00092_A65ResidentLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z67ResidentEmail, T00092_A67ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z68ResidentGender, T00092_A68ResidentGender[0]) != 0 ) || ( StringUtil.StrCmp(Z355ResidentCity, T00092_A355ResidentCity[0]) != 0 ) || ( StringUtil.StrCmp(Z356ResidentZipCode, T00092_A356ResidentZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z357ResidentAddressLine1, T00092_A357ResidentAddressLine1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z358ResidentAddressLine2, T00092_A358ResidentAddressLine2[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( T00092_A73ResidentBirthDate[0] ) ) || ( StringUtil.StrCmp(Z71ResidentGUID, T00092_A71ResidentGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z376ResidentPhoneNumber, T00092_A376ResidentPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z446ResidentHomePhoneNumber, T00092_A446ResidentHomePhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z96ResidentTypeId != T00092_A96ResidentTypeId[0] ) || ( Z98MedicalIndicationId != T00092_A98MedicalIndicationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z354ResidentCountry, T00092_A354ResidentCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentCountry");
                  GXUtil.WriteLogRaw("Old: ",Z354ResidentCountry);
                  GXUtil.WriteLogRaw("Current: ",T00092_A354ResidentCountry[0]);
               }
               if ( StringUtil.StrCmp(Z445ResidentHomePhoneCode, T00092_A445ResidentHomePhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z445ResidentHomePhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00092_A445ResidentHomePhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z375ResidentPhoneCode, T00092_A375ResidentPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z375ResidentPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00092_A375ResidentPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z66ResidentInitials, T00092_A66ResidentInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentInitials");
                  GXUtil.WriteLogRaw("Old: ",Z66ResidentInitials);
                  GXUtil.WriteLogRaw("Current: ",T00092_A66ResidentInitials[0]);
               }
               if ( StringUtil.StrCmp(Z70ResidentPhone, T00092_A70ResidentPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhone");
                  GXUtil.WriteLogRaw("Old: ",Z70ResidentPhone);
                  GXUtil.WriteLogRaw("Current: ",T00092_A70ResidentPhone[0]);
               }
               if ( StringUtil.StrCmp(Z444ResidentHomePhone, T00092_A444ResidentHomePhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhone");
                  GXUtil.WriteLogRaw("Old: ",Z444ResidentHomePhone);
                  GXUtil.WriteLogRaw("Current: ",T00092_A444ResidentHomePhone[0]);
               }
               if ( StringUtil.StrCmp(Z72ResidentSalutation, T00092_A72ResidentSalutation[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentSalutation");
                  GXUtil.WriteLogRaw("Old: ",Z72ResidentSalutation);
                  GXUtil.WriteLogRaw("Current: ",T00092_A72ResidentSalutation[0]);
               }
               if ( StringUtil.StrCmp(Z63ResidentBsnNumber, T00092_A63ResidentBsnNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentBsnNumber");
                  GXUtil.WriteLogRaw("Old: ",Z63ResidentBsnNumber);
                  GXUtil.WriteLogRaw("Current: ",T00092_A63ResidentBsnNumber[0]);
               }
               if ( StringUtil.StrCmp(Z64ResidentGivenName, T00092_A64ResidentGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z64ResidentGivenName);
                  GXUtil.WriteLogRaw("Current: ",T00092_A64ResidentGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z65ResidentLastName, T00092_A65ResidentLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentLastName");
                  GXUtil.WriteLogRaw("Old: ",Z65ResidentLastName);
                  GXUtil.WriteLogRaw("Current: ",T00092_A65ResidentLastName[0]);
               }
               if ( StringUtil.StrCmp(Z67ResidentEmail, T00092_A67ResidentEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentEmail");
                  GXUtil.WriteLogRaw("Old: ",Z67ResidentEmail);
                  GXUtil.WriteLogRaw("Current: ",T00092_A67ResidentEmail[0]);
               }
               if ( StringUtil.StrCmp(Z68ResidentGender, T00092_A68ResidentGender[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGender");
                  GXUtil.WriteLogRaw("Old: ",Z68ResidentGender);
                  GXUtil.WriteLogRaw("Current: ",T00092_A68ResidentGender[0]);
               }
               if ( StringUtil.StrCmp(Z355ResidentCity, T00092_A355ResidentCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentCity");
                  GXUtil.WriteLogRaw("Old: ",Z355ResidentCity);
                  GXUtil.WriteLogRaw("Current: ",T00092_A355ResidentCity[0]);
               }
               if ( StringUtil.StrCmp(Z356ResidentZipCode, T00092_A356ResidentZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z356ResidentZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00092_A356ResidentZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z357ResidentAddressLine1, T00092_A357ResidentAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z357ResidentAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00092_A357ResidentAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z358ResidentAddressLine2, T00092_A358ResidentAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z358ResidentAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00092_A358ResidentAddressLine2[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( T00092_A73ResidentBirthDate[0] ) )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentBirthDate");
                  GXUtil.WriteLogRaw("Old: ",Z73ResidentBirthDate);
                  GXUtil.WriteLogRaw("Current: ",T00092_A73ResidentBirthDate[0]);
               }
               if ( StringUtil.StrCmp(Z71ResidentGUID, T00092_A71ResidentGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGUID");
                  GXUtil.WriteLogRaw("Old: ",Z71ResidentGUID);
                  GXUtil.WriteLogRaw("Current: ",T00092_A71ResidentGUID[0]);
               }
               if ( StringUtil.StrCmp(Z376ResidentPhoneNumber, T00092_A376ResidentPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z376ResidentPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00092_A376ResidentPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z446ResidentHomePhoneNumber, T00092_A446ResidentHomePhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z446ResidentHomePhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00092_A446ResidentHomePhoneNumber[0]);
               }
               if ( Z96ResidentTypeId != T00092_A96ResidentTypeId[0] )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z96ResidentTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A96ResidentTypeId[0]);
               }
               if ( Z98MedicalIndicationId != T00092_A98MedicalIndicationId[0] )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"MedicalIndicationId");
                  GXUtil.WriteLogRaw("Old: ",Z98MedicalIndicationId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A98MedicalIndicationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Resident"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0916( )
      {
         if ( ! IsAuthorized("trn_resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0916( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0916( 0) ;
            CheckOptimisticConcurrency0916( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0916( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0916( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000914 */
                     pr_default.execute(12, new Object[] {A62ResidentId, A354ResidentCountry, A445ResidentHomePhoneCode, A375ResidentPhoneCode, A66ResidentInitials, A70ResidentPhone, A444ResidentHomePhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A73ResidentBirthDate, A71ResidentGUID, A376ResidentPhoneNumber, A446ResidentHomePhoneNumber, n457ResidentImage, A457ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A29LocationId, A11OrganisationId, n96ResidentTypeId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption090( ) ;
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
               Load0916( ) ;
            }
            EndLevel0916( ) ;
         }
         CloseExtendedTableCursors0916( ) ;
      }

      protected void Update0916( )
      {
         if ( ! IsAuthorized("trn_resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0916( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0916( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0916( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0916( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000915 */
                     pr_default.execute(13, new Object[] {A354ResidentCountry, A445ResidentHomePhoneCode, A375ResidentPhoneCode, A66ResidentInitials, A70ResidentPhone, A444ResidentHomePhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A73ResidentBirthDate, A71ResidentGUID, A376ResidentPhoneNumber, A446ResidentHomePhoneNumber, n96ResidentTypeId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId, A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0916( ) ;
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
            EndLevel0916( ) ;
         }
         CloseExtendedTableCursors0916( ) ;
      }

      protected void DeferredUpdate0916( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000916 */
            pr_default.execute(14, new Object[] {n457ResidentImage, A457ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0916( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0916( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0916( ) ;
            AfterConfirm0916( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0916( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000917 */
                  pr_default.execute(15, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0916( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0916( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000918 */
            pr_default.execute(16, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            A97ResidentTypeName = T000918_A97ResidentTypeName[0];
            pr_default.close(16);
            /* Using cursor T000919 */
            pr_default.execute(17, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = T000919_A99MedicalIndicationName[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel0916( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0916( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_resident",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_resident",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0916( )
      {
         /* Scan By routine */
         /* Using cursor T000920 */
         pr_default.execute(18);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = T000920_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = T000920_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000920_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0916( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = T000920_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = T000920_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000920_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd0916( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0916( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0916( )
      {
         /* Before Insert Rules */
         AV36GAMErrorResponse = "";
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", ref  A71ResidentGUID, ref  AV36GAMErrorResponse) ;
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
         if ( IsIns( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV36GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeUpdate0916( )
      {
         /* Before Update Rules */
         AV36GAMErrorResponse = "";
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber,  A457ResidentImage,  false,  "Resident", out  AV36GAMErrorResponse) ;
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
         if ( IsUpd( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV36GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeDelete0916( )
      {
         /* Before Delete Rules */
         AV36GAMErrorResponse = "";
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A71ResidentGUID, out  AV36GAMErrorResponse) ;
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
         if ( IsDlt( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV36GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeComplete0916( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0916( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0916( )
      {
         cmbResidentSalutation.Enabled = 0;
         AssignProp("", false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         cmbResidentGender.Enabled = 0;
         AssignProp("", false, cmbResidentGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentGender.Enabled), 5, 0), true);
         edtResidentBirthDate_Enabled = 0;
         AssignProp("", false, edtResidentBirthDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBirthDate_Enabled), 5, 0), true);
         edtResidentEmail_Enabled = 0;
         AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         edtResidentPhoneCode_Enabled = 0;
         AssignProp("", false, edtResidentPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhoneCode_Enabled), 5, 0), true);
         edtResidentPhoneNumber_Enabled = 0;
         AssignProp("", false, edtResidentPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhoneNumber_Enabled), 5, 0), true);
         edtResidentHomePhoneCode_Enabled = 0;
         AssignProp("", false, edtResidentHomePhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhoneCode_Enabled), 5, 0), true);
         edtResidentHomePhoneNumber_Enabled = 0;
         AssignProp("", false, edtResidentHomePhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhoneNumber_Enabled), 5, 0), true);
         edtResidentPhone_Enabled = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), true);
         edtResidentHomePhone_Enabled = 0;
         AssignProp("", false, edtResidentHomePhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Enabled), 5, 0), true);
         edtResidentBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), true);
         edtResidentAddressLine1_Enabled = 0;
         AssignProp("", false, edtResidentAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine1_Enabled), 5, 0), true);
         edtResidentAddressLine2_Enabled = 0;
         AssignProp("", false, edtResidentAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddressLine2_Enabled), 5, 0), true);
         edtResidentZipCode_Enabled = 0;
         AssignProp("", false, edtResidentZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentZipCode_Enabled), 5, 0), true);
         edtResidentCity_Enabled = 0;
         AssignProp("", false, edtResidentCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentCity_Enabled), 5, 0), true);
         edtResidentCountry_Enabled = 0;
         AssignProp("", false, edtResidentCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentCountry_Enabled), 5, 0), true);
         edtavComboresidentphonecode_Enabled = 0;
         AssignProp("", false, edtavComboresidentphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentphonecode_Enabled), 5, 0), true);
         edtavComboresidenthomephonecode_Enabled = 0;
         AssignProp("", false, edtavComboresidenthomephonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenthomephonecode_Enabled), 5, 0), true);
         edtavComboresidentcountry_Enabled = 0;
         AssignProp("", false, edtavComboresidentcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidentcountry_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtResidentInitials_Enabled = 0;
         AssignProp("", false, edtResidentInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
         edtResidentTypeId_Enabled = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         edtMedicalIndicationId_Enabled = 0;
         AssignProp("", false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0916( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ResidentId.ToString()) + "," + UrlEncode(AV8LocationId.ToString()) + "," + UrlEncode(AV9OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Resident");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_resident:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z354ResidentCountry", Z354ResidentCountry);
         GxWebStd.gx_hidden_field( context, "Z445ResidentHomePhoneCode", Z445ResidentHomePhoneCode);
         GxWebStd.gx_hidden_field( context, "Z375ResidentPhoneCode", Z375ResidentPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z66ResidentInitials", StringUtil.RTrim( Z66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "Z70ResidentPhone", StringUtil.RTrim( Z70ResidentPhone));
         GxWebStd.gx_hidden_field( context, "Z444ResidentHomePhone", StringUtil.RTrim( Z444ResidentHomePhone));
         GxWebStd.gx_hidden_field( context, "Z72ResidentSalutation", StringUtil.RTrim( Z72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, "Z63ResidentBsnNumber", Z63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "Z64ResidentGivenName", Z64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "Z65ResidentLastName", Z65ResidentLastName);
         GxWebStd.gx_hidden_field( context, "Z67ResidentEmail", Z67ResidentEmail);
         GxWebStd.gx_hidden_field( context, "Z68ResidentGender", Z68ResidentGender);
         GxWebStd.gx_hidden_field( context, "Z355ResidentCity", Z355ResidentCity);
         GxWebStd.gx_hidden_field( context, "Z356ResidentZipCode", Z356ResidentZipCode);
         GxWebStd.gx_hidden_field( context, "Z357ResidentAddressLine1", Z357ResidentAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z358ResidentAddressLine2", Z358ResidentAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z73ResidentBirthDate", context.localUtil.DToC( Z73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z71ResidentGUID", Z71ResidentGUID);
         GxWebStd.gx_hidden_field( context, "Z376ResidentPhoneNumber", Z376ResidentPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z446ResidentHomePhoneNumber", Z446ResidentHomePhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z96ResidentTypeId", Z96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z98MedicalIndicationId", Z98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N96ResidentTypeId", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "N98MedicalIndicationId", A98MedicalIndicationId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTHOMEPHONECODE_DATA", AV43ResidentHomePhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTHOMEPHONECODE_DATA", AV43ResidentHomePhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTCOUNTRY_DATA", AV37ResidentCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTCOUNTRY_DATA", AV37ResidentCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV13TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV13TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTID", AV7ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", AV7ResidentId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV8LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV8LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV9OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV9OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_RESIDENTTYPEID", AV15Insert_ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_MEDICALINDICATIONID", AV16Insert_MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "vGAMERRORRESPONSE", AV36GAMErrorResponse);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV42AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV42AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "RESIDENTIMAGE", A457ResidentImage);
         GxWebStd.gx_hidden_field( context, "RESIDENTIMAGE_GXI", A40000ResidentImage_GXI);
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Objectcall", StringUtil.RTrim( Combo_residentphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Cls", StringUtil.RTrim( Combo_residentphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_residentphonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Enabled", StringUtil.BoolToStr( Combo_residentphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residentphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residentphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Objectcall", StringUtil.RTrim( Combo_residenthomephonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Cls", StringUtil.RTrim( Combo_residenthomephonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residenthomephonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_residenthomephonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Enabled", StringUtil.BoolToStr( Combo_residenthomephonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residenthomephonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residenthomephonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Objectcall", StringUtil.RTrim( Combo_residentcountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Cls", StringUtil.RTrim( Combo_residentcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_residentcountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_residentcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_residentcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_residentcountry_Htmltemplate));
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
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7ResidentId.ToString()) + "," + UrlEncode(AV8LocationId.ToString()) + "," + UrlEncode(AV9OrganisationId.ToString());
         return formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Resident" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Residents", "") ;
      }

      protected void InitializeNonKey0916( )
      {
         A96ResidentTypeId = Guid.Empty;
         n96ResidentTypeId = false;
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         n96ResidentTypeId = ((Guid.Empty==A96ResidentTypeId) ? true : false);
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
         A354ResidentCountry = "";
         AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
         A445ResidentHomePhoneCode = "";
         AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
         A375ResidentPhoneCode = "";
         AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV36GAMErrorResponse = "";
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         A66ResidentInitials = "";
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         A70ResidentPhone = "";
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         A444ResidentHomePhone = "";
         AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
         A72ResidentSalutation = "";
         AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
         A63ResidentBsnNumber = "";
         AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
         A64ResidentGivenName = "";
         AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = "";
         AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
         A67ResidentEmail = "";
         AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
         A68ResidentGender = "";
         AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
         A355ResidentCity = "";
         AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
         A356ResidentZipCode = "";
         AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
         A357ResidentAddressLine1 = "";
         AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
         A358ResidentAddressLine2 = "";
         AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
         A73ResidentBirthDate = DateTime.MinValue;
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A71ResidentGUID = "";
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A97ResidentTypeName = "";
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         A99MedicalIndicationName = "";
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         A376ResidentPhoneNumber = "";
         AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
         A446ResidentHomePhoneNumber = "";
         AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
         A457ResidentImage = "";
         n457ResidentImage = false;
         AssignAttri("", false, "A457ResidentImage", A457ResidentImage);
         A40000ResidentImage_GXI = "";
         n40000ResidentImage_GXI = false;
         AssignAttri("", false, "A40000ResidentImage_GXI", A40000ResidentImage_GXI);
         Z354ResidentCountry = "";
         Z445ResidentHomePhoneCode = "";
         Z375ResidentPhoneCode = "";
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
         Z444ResidentHomePhone = "";
         Z72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z67ResidentEmail = "";
         Z68ResidentGender = "";
         Z355ResidentCity = "";
         Z356ResidentZipCode = "";
         Z357ResidentAddressLine1 = "";
         Z358ResidentAddressLine2 = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         Z376ResidentPhoneNumber = "";
         Z446ResidentHomePhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
      }

      protected void InitAll0916( )
      {
         A62ResidentId = Guid.NewGuid( );
         AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey0916( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202512410553845", true, true);
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
         context.AddJavascriptSource("trn_resident.js", "?202512410553848", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         cmbResidentGender_Internalname = "RESIDENTGENDER";
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         lblPhonelabel_Internalname = "PHONELABEL";
         Combo_residentphonecode_Internalname = "COMBO_RESIDENTPHONECODE";
         edtResidentPhoneCode_Internalname = "RESIDENTPHONECODE";
         divUnnamedtableresidentphonecode_Internalname = "UNNAMEDTABLERESIDENTPHONECODE";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         edtResidentPhoneNumber_Internalname = "RESIDENTPHONENUMBER";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divPhonenumber_Internalname = "PHONENUMBER";
         lblPhone_Internalname = "PHONE";
         Combo_residenthomephonecode_Internalname = "COMBO_RESIDENTHOMEPHONECODE";
         edtResidentHomePhoneCode_Internalname = "RESIDENTHOMEPHONECODE";
         divUnnamedtableresidenthomephonecode_Internalname = "UNNAMEDTABLERESIDENTHOMEPHONECODE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         edtResidentHomePhoneNumber_Internalname = "RESIDENTHOMEPHONENUMBER";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divHomephonenumber_Internalname = "HOMEPHONENUMBER";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         divResidentphone_cell_Internalname = "RESIDENTPHONE_CELL";
         edtResidentHomePhone_Internalname = "RESIDENTHOMEPHONE";
         divResidenthomephone_cell_Internalname = "RESIDENTHOMEPHONE_CELL";
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtResidentAddressLine1_Internalname = "RESIDENTADDRESSLINE1";
         edtResidentAddressLine2_Internalname = "RESIDENTADDRESSLINE2";
         edtResidentZipCode_Internalname = "RESIDENTZIPCODE";
         edtResidentCity_Internalname = "RESIDENTCITY";
         lblTextblockresidentcountry_Internalname = "TEXTBLOCKRESIDENTCOUNTRY";
         Combo_residentcountry_Internalname = "COMBO_RESIDENTCOUNTRY";
         edtResidentCountry_Internalname = "RESIDENTCOUNTRY";
         divTablesplittedresidentcountry_Internalname = "TABLESPLITTEDRESIDENTCOUNTRY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboresidentphonecode_Internalname = "vCOMBORESIDENTPHONECODE";
         divSectionattribute_residentphonecode_Internalname = "SECTIONATTRIBUTE_RESIDENTPHONECODE";
         edtavComboresidenthomephonecode_Internalname = "vCOMBORESIDENTHOMEPHONECODE";
         divSectionattribute_residenthomephonecode_Internalname = "SECTIONATTRIBUTE_RESIDENTHOMEPHONECODE";
         edtavComboresidentcountry_Internalname = "vCOMBORESIDENTCOUNTRY";
         divSectionattribute_residentcountry_Internalname = "SECTIONATTRIBUTE_RESIDENTCOUNTRY";
         edtResidentId_Internalname = "RESIDENTID";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentGUID_Internalname = "RESIDENTGUID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID";
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
         Form.Caption = context.GetMessage( "Residents", "");
         Combo_residentphonecode_Htmltemplate = "";
         Combo_residenthomephonecode_Htmltemplate = "";
         Combo_residentcountry_Htmltemplate = "";
         edtMedicalIndicationId_Jsonclick = "";
         edtMedicalIndicationId_Enabled = 1;
         edtMedicalIndicationId_Visible = 1;
         edtResidentTypeId_Jsonclick = "";
         edtResidentTypeId_Enabled = 1;
         edtResidentTypeId_Visible = 1;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Enabled = 1;
         edtResidentGUID_Visible = 1;
         edtResidentInitials_Jsonclick = "";
         edtResidentInitials_Enabled = 1;
         edtResidentInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 1;
         edtResidentId_Visible = 1;
         edtavComboresidentcountry_Jsonclick = "";
         edtavComboresidentcountry_Enabled = 0;
         edtavComboresidentcountry_Visible = 1;
         edtavComboresidenthomephonecode_Jsonclick = "";
         edtavComboresidenthomephonecode_Enabled = 0;
         edtavComboresidenthomephonecode_Visible = 1;
         edtavComboresidentphonecode_Jsonclick = "";
         edtavComboresidentphonecode_Enabled = 0;
         edtavComboresidentphonecode_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtResidentCountry_Jsonclick = "";
         edtResidentCountry_Enabled = 1;
         edtResidentCountry_Visible = 1;
         Combo_residentcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_residentcountry_Caption = "";
         Combo_residentcountry_Enabled = Convert.ToBoolean( -1);
         edtResidentCity_Jsonclick = "";
         edtResidentCity_Enabled = 1;
         edtResidentZipCode_Jsonclick = "";
         edtResidentZipCode_Enabled = 1;
         edtResidentAddressLine2_Jsonclick = "";
         edtResidentAddressLine2_Enabled = 1;
         edtResidentAddressLine1_Jsonclick = "";
         edtResidentAddressLine1_Enabled = 1;
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentBsnNumber_Enabled = 1;
         edtResidentHomePhone_Jsonclick = "";
         edtResidentHomePhone_Enabled = 1;
         edtResidentHomePhone_Visible = 1;
         divResidenthomephone_cell_Class = "col-xs-12";
         edtResidentPhone_Jsonclick = "";
         edtResidentPhone_Enabled = 1;
         edtResidentPhone_Visible = 1;
         divResidentphone_cell_Class = "col-xs-12";
         edtResidentHomePhoneNumber_Jsonclick = "";
         edtResidentHomePhoneNumber_Enabled = 1;
         edtResidentHomePhoneCode_Jsonclick = "";
         edtResidentHomePhoneCode_Enabled = 1;
         edtResidentHomePhoneCode_Visible = 1;
         Combo_residenthomephonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenthomephonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residenthomephonecode_Caption = "";
         Combo_residenthomephonecode_Enabled = Convert.ToBoolean( -1);
         divHomephonenumber_Visible = 1;
         edtResidentPhoneNumber_Jsonclick = "";
         edtResidentPhoneNumber_Enabled = 1;
         edtResidentPhoneCode_Jsonclick = "";
         edtResidentPhoneCode_Enabled = 1;
         edtResidentPhoneCode_Visible = 1;
         Combo_residentphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentphonecode_Caption = "";
         Combo_residentphonecode_Enabled = Convert.ToBoolean( -1);
         divPhonenumber_Visible = 1;
         edtResidentEmail_Jsonclick = "";
         edtResidentEmail_Enabled = 1;
         edtResidentBirthDate_Jsonclick = "";
         edtResidentBirthDate_Enabled = 1;
         cmbResidentGender_Jsonclick = "";
         cmbResidentGender.Enabled = 1;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Enabled = 1;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 1;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Enabled = 1;
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

      protected void GX34ASARESIDENTPHONE0916( string A375ResidentPhoneCode ,
                                               string A376ResidentPhoneNumber )
      {
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A70ResidentPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX35ASARESIDENTHOMEPHONE0916( string A445ResidentHomePhoneCode ,
                                                   string A446ResidentHomePhoneNumber )
      {
         GXt_char2 = A444ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber, out  GXt_char2) ;
         A444ResidentHomePhone = GXt_char2;
         AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A444ResidentHomePhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_44_0916( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
                                 Guid A62ResidentId ,
                                 Guid A29LocationId ,
                                 Guid A11OrganisationId ,
                                 string Gx_mode )
      {
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV42AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_45_0916( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
                                 Guid A62ResidentId ,
                                 Guid A29LocationId ,
                                 Guid A11OrganisationId ,
                                 string Gx_mode )
      {
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV42AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_46_0916( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
                                 Guid A62ResidentId ,
                                 Guid A29LocationId ,
                                 Guid A11OrganisationId )
      {
         if ( IsIns( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV42AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_47_0916( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
                                 Guid A62ResidentId ,
                                 Guid A29LocationId ,
                                 Guid A11OrganisationId )
      {
         if ( IsUpd( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV42AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_49_0916( string Gx_mode ,
                                 string A67ResidentEmail ,
                                 string A64ResidentGivenName ,
                                 string A65ResidentLastName ,
                                 string A71ResidentGUID ,
                                 string AV36GAMErrorResponse )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", ref  A71ResidentGUID, ref  AV36GAMErrorResponse) ;
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A71ResidentGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( AV36GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_51_0916( string A64ResidentGivenName ,
                                 string A65ResidentLastName )
      {
         new prc_getnameinitials(context ).execute(  A64ResidentGivenName,  A65ResidentLastName, out  A66ResidentInitials) ;
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A66ResidentInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_52_0916( string Gx_mode ,
                                 string A71ResidentGUID ,
                                 string A64ResidentGivenName ,
                                 string A65ResidentLastName ,
                                 string A445ResidentHomePhoneCode ,
                                 string A446ResidentHomePhoneNumber ,
                                 string A457ResidentImage ,
                                 string AV36GAMErrorResponse )
      {
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber,  A457ResidentImage,  false,  "Resident", out  AV36GAMErrorResponse) ;
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
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

      protected void XC_54_0916( string Gx_mode ,
                                 string A71ResidentGUID )
      {
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A71ResidentGUID, out  AV36GAMErrorResponse) ;
            AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV36GAMErrorResponse)+"\"") ;
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
         cmbResidentGender.Name = "RESIDENTGENDER";
         cmbResidentGender.WebTags = "";
         cmbResidentGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbResidentGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbResidentGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
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

      public void Valid_Organisationid( )
      {
         /* Using cursor T000921 */
         pr_default.execute(19, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Residentlastname( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Last Name", ""), "", "", "", "", "", "", "", ""), 1, "RESIDENTLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtResidentLastName_Internalname;
         }
         new prc_getnameinitials(context ).execute(  A64ResidentGivenName,  A65ResidentLastName, out  A66ResidentInitials) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A66ResidentInitials", StringUtil.RTrim( A66ResidentInitials));
      }

      public void Valid_Residentphonenumber( )
      {
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A376ResidentPhoneNumber)) && ! GxRegex.IsMatch(A376ResidentPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A70ResidentPhone", StringUtil.RTrim( A70ResidentPhone));
      }

      public void Valid_Residenthomephonenumber( )
      {
         GXt_char2 = A444ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A445ResidentHomePhoneCode,  A446ResidentHomePhoneNumber, out  GXt_char2) ;
         A444ResidentHomePhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A446ResidentHomePhoneNumber)) && ! GxRegex.IsMatch(A446ResidentHomePhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTHOMEPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentHomePhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A444ResidentHomePhone", StringUtil.RTrim( A444ResidentHomePhone));
      }

      public void Valid_Residenttypeid( )
      {
         n96ResidentTypeId = false;
         /* Using cursor T000918 */
         pr_default.execute(16, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
               GX_FocusControl = edtResidentTypeId_Internalname;
            }
         }
         A97ResidentTypeName = T000918_A97ResidentTypeName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
      }

      public void Valid_Medicalindicationid( )
      {
         n98MedicalIndicationId = false;
         /* Using cursor T000919 */
         pr_default.execute(17, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
            }
         }
         A99MedicalIndicationName = T000919_A99MedicalIndicationName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"AV8LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV9OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"AV8LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV9OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV46Pgmname","fld":"vPGMNAME"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12092","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV42AuditingObject","fld":"vAUDITINGOBJECT"},{"av":"AV46Pgmname","fld":"vPGMNAME"},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_RESIDENTSALUTATION","""{"handler":"Valid_Residentsalutation","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTGIVENNAME","""{"handler":"Valid_Residentgivenname","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTLASTNAME","""{"handler":"Valid_Residentlastname","iparms":[{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"}]""");
         setEventMetadata("VALID_RESIDENTLASTNAME",""","oparms":[{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"}]}""");
         setEventMetadata("VALID_RESIDENTGENDER","""{"handler":"Valid_Residentgender","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTEMAIL","""{"handler":"Valid_Residentemail","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTPHONECODE","""{"handler":"Valid_Residentphonecode","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTPHONENUMBER","""{"handler":"Valid_Residentphonenumber","iparms":[{"av":"A375ResidentPhoneCode","fld":"RESIDENTPHONECODE"},{"av":"A376ResidentPhoneNumber","fld":"RESIDENTPHONENUMBER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"}]""");
         setEventMetadata("VALID_RESIDENTPHONENUMBER",""","oparms":[{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"}]}""");
         setEventMetadata("VALID_RESIDENTHOMEPHONECODE","""{"handler":"Valid_Residenthomephonecode","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTHOMEPHONENUMBER","""{"handler":"Valid_Residenthomephonenumber","iparms":[{"av":"A445ResidentHomePhoneCode","fld":"RESIDENTHOMEPHONECODE"},{"av":"A446ResidentHomePhoneNumber","fld":"RESIDENTHOMEPHONENUMBER"},{"av":"A444ResidentHomePhone","fld":"RESIDENTHOMEPHONE"}]""");
         setEventMetadata("VALID_RESIDENTHOMEPHONENUMBER",""","oparms":[{"av":"A444ResidentHomePhone","fld":"RESIDENTHOMEPHONE"}]}""");
         setEventMetadata("VALID_RESIDENTBSNNUMBER","""{"handler":"Valid_Residentbsnnumber","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTZIPCODE","""{"handler":"Valid_Residentzipcode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTPHONECODE","""{"handler":"Validv_Comboresidentphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTHOMEPHONECODE","""{"handler":"Validv_Comboresidenthomephonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTCOUNTRY","""{"handler":"Validv_Comboresidentcountry","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_RESIDENTGUID","""{"handler":"Valid_Residentguid","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTTYPEID","""{"handler":"Valid_Residenttypeid","iparms":[{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"}]""");
         setEventMetadata("VALID_RESIDENTTYPEID",""","oparms":[{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"}]}""");
         setEventMetadata("VALID_MEDICALINDICATIONID","""{"handler":"Valid_Medicalindicationid","iparms":[{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"}]""");
         setEventMetadata("VALID_MEDICALINDICATIONID",""","oparms":[{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"}]}""");
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
         pr_default.close(19);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ResidentId = Guid.Empty;
         wcpOAV8LocationId = Guid.Empty;
         wcpOAV9OrganisationId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z354ResidentCountry = "";
         Z445ResidentHomePhoneCode = "";
         Z375ResidentPhoneCode = "";
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
         Z444ResidentHomePhone = "";
         Z72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z67ResidentEmail = "";
         Z68ResidentGender = "";
         Z355ResidentCity = "";
         Z356ResidentZipCode = "";
         Z357ResidentAddressLine1 = "";
         Z358ResidentAddressLine2 = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         Z376ResidentPhoneNumber = "";
         Z446ResidentHomePhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         N96ResidentTypeId = Guid.Empty;
         N98MedicalIndicationId = Guid.Empty;
         Combo_residentcountry_Selectedvalue_get = "";
         Combo_residenthomephonecode_Selectedvalue_get = "";
         Combo_residentphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A67ResidentEmail = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         AV36GAMErrorResponse = "";
         A445ResidentHomePhoneCode = "";
         A446ResidentHomePhoneNumber = "";
         A457ResidentImage = "";
         A375ResidentPhoneCode = "";
         A376ResidentPhoneNumber = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A73ResidentBirthDate = DateTime.MinValue;
         lblPhonelabel_Jsonclick = "";
         ucCombo_residentphonecode = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41ResidentPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblPhone_Jsonclick = "";
         ucCombo_residenthomephonecode = new GXUserControl();
         AV43ResidentHomePhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A70ResidentPhone = "";
         A444ResidentHomePhone = "";
         A63ResidentBsnNumber = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         A356ResidentZipCode = "";
         A355ResidentCity = "";
         lblTextblockresidentcountry_Jsonclick = "";
         ucCombo_residentcountry = new GXUserControl();
         AV37ResidentCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A354ResidentCountry = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV39ComboResidentPhoneCode = "";
         AV44ComboResidentHomePhoneCode = "";
         AV38ComboResidentCountry = "";
         A62ResidentId = Guid.Empty;
         A66ResidentInitials = "";
         AV15Insert_ResidentTypeId = Guid.Empty;
         AV16Insert_MedicalIndicationId = Guid.Empty;
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A40000ResidentImage_GXI = "";
         A97ResidentTypeName = "";
         A99MedicalIndicationName = "";
         AV46Pgmname = "";
         Combo_residentphonecode_Objectcall = "";
         Combo_residentphonecode_Class = "";
         Combo_residentphonecode_Icontype = "";
         Combo_residentphonecode_Icon = "";
         Combo_residentphonecode_Tooltip = "";
         Combo_residentphonecode_Selectedvalue_set = "";
         Combo_residentphonecode_Selectedtext_set = "";
         Combo_residentphonecode_Selectedtext_get = "";
         Combo_residentphonecode_Gamoauthtoken = "";
         Combo_residentphonecode_Ddointernalname = "";
         Combo_residentphonecode_Titlecontrolalign = "";
         Combo_residentphonecode_Dropdownoptionstype = "";
         Combo_residentphonecode_Titlecontrolidtoreplace = "";
         Combo_residentphonecode_Datalisttype = "";
         Combo_residentphonecode_Datalistfixedvalues = "";
         Combo_residentphonecode_Datalistproc = "";
         Combo_residentphonecode_Datalistprocparametersprefix = "";
         Combo_residentphonecode_Remoteservicesparameters = "";
         Combo_residentphonecode_Multiplevaluestype = "";
         Combo_residentphonecode_Loadingdata = "";
         Combo_residentphonecode_Noresultsfound = "";
         Combo_residentphonecode_Emptyitemtext = "";
         Combo_residentphonecode_Onlyselectedvalues = "";
         Combo_residentphonecode_Selectalltext = "";
         Combo_residentphonecode_Multiplevaluesseparator = "";
         Combo_residentphonecode_Addnewoptiontext = "";
         Combo_residenthomephonecode_Objectcall = "";
         Combo_residenthomephonecode_Class = "";
         Combo_residenthomephonecode_Icontype = "";
         Combo_residenthomephonecode_Icon = "";
         Combo_residenthomephonecode_Tooltip = "";
         Combo_residenthomephonecode_Selectedvalue_set = "";
         Combo_residenthomephonecode_Selectedtext_set = "";
         Combo_residenthomephonecode_Selectedtext_get = "";
         Combo_residenthomephonecode_Gamoauthtoken = "";
         Combo_residenthomephonecode_Ddointernalname = "";
         Combo_residenthomephonecode_Titlecontrolalign = "";
         Combo_residenthomephonecode_Dropdownoptionstype = "";
         Combo_residenthomephonecode_Titlecontrolidtoreplace = "";
         Combo_residenthomephonecode_Datalisttype = "";
         Combo_residenthomephonecode_Datalistfixedvalues = "";
         Combo_residenthomephonecode_Datalistproc = "";
         Combo_residenthomephonecode_Datalistprocparametersprefix = "";
         Combo_residenthomephonecode_Remoteservicesparameters = "";
         Combo_residenthomephonecode_Multiplevaluestype = "";
         Combo_residenthomephonecode_Loadingdata = "";
         Combo_residenthomephonecode_Noresultsfound = "";
         Combo_residenthomephonecode_Emptyitemtext = "";
         Combo_residenthomephonecode_Onlyselectedvalues = "";
         Combo_residenthomephonecode_Selectalltext = "";
         Combo_residenthomephonecode_Multiplevaluesseparator = "";
         Combo_residenthomephonecode_Addnewoptiontext = "";
         Combo_residentcountry_Objectcall = "";
         Combo_residentcountry_Class = "";
         Combo_residentcountry_Icontype = "";
         Combo_residentcountry_Icon = "";
         Combo_residentcountry_Tooltip = "";
         Combo_residentcountry_Selectedvalue_set = "";
         Combo_residentcountry_Selectedtext_set = "";
         Combo_residentcountry_Selectedtext_get = "";
         Combo_residentcountry_Gamoauthtoken = "";
         Combo_residentcountry_Ddointernalname = "";
         Combo_residentcountry_Titlecontrolalign = "";
         Combo_residentcountry_Dropdownoptionstype = "";
         Combo_residentcountry_Titlecontrolidtoreplace = "";
         Combo_residentcountry_Datalisttype = "";
         Combo_residentcountry_Datalistfixedvalues = "";
         Combo_residentcountry_Datalistproc = "";
         Combo_residentcountry_Datalistprocparametersprefix = "";
         Combo_residentcountry_Remoteservicesparameters = "";
         Combo_residentcountry_Multiplevaluestype = "";
         Combo_residentcountry_Loadingdata = "";
         Combo_residentcountry_Noresultsfound = "";
         Combo_residentcountry_Emptyitemtext = "";
         Combo_residentcountry_Onlyselectedvalues = "";
         Combo_residentcountry_Selectalltext = "";
         Combo_residentcountry_Multiplevaluesseparator = "";
         Combo_residentcountry_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV40defaultCountryPhoneCode = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z457ResidentImage = "";
         Z40000ResidentImage_GXI = "";
         Z97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         T00096_A99MedicalIndicationName = new string[] {""} ;
         T00095_A97ResidentTypeName = new string[] {""} ;
         T00097_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00097_A354ResidentCountry = new string[] {""} ;
         T00097_A445ResidentHomePhoneCode = new string[] {""} ;
         T00097_A375ResidentPhoneCode = new string[] {""} ;
         T00097_A66ResidentInitials = new string[] {""} ;
         T00097_A70ResidentPhone = new string[] {""} ;
         T00097_A444ResidentHomePhone = new string[] {""} ;
         T00097_A72ResidentSalutation = new string[] {""} ;
         T00097_A63ResidentBsnNumber = new string[] {""} ;
         T00097_A64ResidentGivenName = new string[] {""} ;
         T00097_A65ResidentLastName = new string[] {""} ;
         T00097_A67ResidentEmail = new string[] {""} ;
         T00097_A68ResidentGender = new string[] {""} ;
         T00097_A355ResidentCity = new string[] {""} ;
         T00097_A356ResidentZipCode = new string[] {""} ;
         T00097_A357ResidentAddressLine1 = new string[] {""} ;
         T00097_A358ResidentAddressLine2 = new string[] {""} ;
         T00097_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T00097_A71ResidentGUID = new string[] {""} ;
         T00097_A97ResidentTypeName = new string[] {""} ;
         T00097_A99MedicalIndicationName = new string[] {""} ;
         T00097_A376ResidentPhoneNumber = new string[] {""} ;
         T00097_A446ResidentHomePhoneNumber = new string[] {""} ;
         T00097_A40000ResidentImage_GXI = new string[] {""} ;
         T00097_n40000ResidentImage_GXI = new bool[] {false} ;
         T00097_A29LocationId = new Guid[] {Guid.Empty} ;
         T00097_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00097_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T00097_n96ResidentTypeId = new bool[] {false} ;
         T00097_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T00097_n98MedicalIndicationId = new bool[] {false} ;
         T00097_A457ResidentImage = new string[] {""} ;
         T00097_n457ResidentImage = new bool[] {false} ;
         T00094_A29LocationId = new Guid[] {Guid.Empty} ;
         T00098_A29LocationId = new Guid[] {Guid.Empty} ;
         T00099_A97ResidentTypeName = new string[] {""} ;
         T000910_A99MedicalIndicationName = new string[] {""} ;
         T000911_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000911_A29LocationId = new Guid[] {Guid.Empty} ;
         T000911_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00093_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00093_A354ResidentCountry = new string[] {""} ;
         T00093_A445ResidentHomePhoneCode = new string[] {""} ;
         T00093_A375ResidentPhoneCode = new string[] {""} ;
         T00093_A66ResidentInitials = new string[] {""} ;
         T00093_A70ResidentPhone = new string[] {""} ;
         T00093_A444ResidentHomePhone = new string[] {""} ;
         T00093_A72ResidentSalutation = new string[] {""} ;
         T00093_A63ResidentBsnNumber = new string[] {""} ;
         T00093_A64ResidentGivenName = new string[] {""} ;
         T00093_A65ResidentLastName = new string[] {""} ;
         T00093_A67ResidentEmail = new string[] {""} ;
         T00093_A68ResidentGender = new string[] {""} ;
         T00093_A355ResidentCity = new string[] {""} ;
         T00093_A356ResidentZipCode = new string[] {""} ;
         T00093_A357ResidentAddressLine1 = new string[] {""} ;
         T00093_A358ResidentAddressLine2 = new string[] {""} ;
         T00093_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T00093_A71ResidentGUID = new string[] {""} ;
         T00093_A376ResidentPhoneNumber = new string[] {""} ;
         T00093_A446ResidentHomePhoneNumber = new string[] {""} ;
         T00093_A40000ResidentImage_GXI = new string[] {""} ;
         T00093_n40000ResidentImage_GXI = new bool[] {false} ;
         T00093_A29LocationId = new Guid[] {Guid.Empty} ;
         T00093_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00093_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T00093_n96ResidentTypeId = new bool[] {false} ;
         T00093_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T00093_n98MedicalIndicationId = new bool[] {false} ;
         T00093_A457ResidentImage = new string[] {""} ;
         T00093_n457ResidentImage = new bool[] {false} ;
         T000912_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000912_A29LocationId = new Guid[] {Guid.Empty} ;
         T000912_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000913_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000913_A29LocationId = new Guid[] {Guid.Empty} ;
         T000913_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00092_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00092_A354ResidentCountry = new string[] {""} ;
         T00092_A445ResidentHomePhoneCode = new string[] {""} ;
         T00092_A375ResidentPhoneCode = new string[] {""} ;
         T00092_A66ResidentInitials = new string[] {""} ;
         T00092_A70ResidentPhone = new string[] {""} ;
         T00092_A444ResidentHomePhone = new string[] {""} ;
         T00092_A72ResidentSalutation = new string[] {""} ;
         T00092_A63ResidentBsnNumber = new string[] {""} ;
         T00092_A64ResidentGivenName = new string[] {""} ;
         T00092_A65ResidentLastName = new string[] {""} ;
         T00092_A67ResidentEmail = new string[] {""} ;
         T00092_A68ResidentGender = new string[] {""} ;
         T00092_A355ResidentCity = new string[] {""} ;
         T00092_A356ResidentZipCode = new string[] {""} ;
         T00092_A357ResidentAddressLine1 = new string[] {""} ;
         T00092_A358ResidentAddressLine2 = new string[] {""} ;
         T00092_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T00092_A71ResidentGUID = new string[] {""} ;
         T00092_A376ResidentPhoneNumber = new string[] {""} ;
         T00092_A446ResidentHomePhoneNumber = new string[] {""} ;
         T00092_A40000ResidentImage_GXI = new string[] {""} ;
         T00092_n40000ResidentImage_GXI = new bool[] {false} ;
         T00092_A29LocationId = new Guid[] {Guid.Empty} ;
         T00092_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00092_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T00092_n96ResidentTypeId = new bool[] {false} ;
         T00092_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T00092_n98MedicalIndicationId = new bool[] {false} ;
         T00092_A457ResidentImage = new string[] {""} ;
         T00092_n457ResidentImage = new bool[] {false} ;
         T000918_A97ResidentTypeName = new string[] {""} ;
         T000919_A99MedicalIndicationName = new string[] {""} ;
         T000920_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000920_A29LocationId = new Guid[] {Guid.Empty} ;
         T000920_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000921_A29LocationId = new Guid[] {Guid.Empty} ;
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_resident__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_resident__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_resident__default(),
            new Object[][] {
                new Object[] {
               T00092_A62ResidentId, T00092_A354ResidentCountry, T00092_A445ResidentHomePhoneCode, T00092_A375ResidentPhoneCode, T00092_A66ResidentInitials, T00092_A70ResidentPhone, T00092_A444ResidentHomePhone, T00092_A72ResidentSalutation, T00092_A63ResidentBsnNumber, T00092_A64ResidentGivenName,
               T00092_A65ResidentLastName, T00092_A67ResidentEmail, T00092_A68ResidentGender, T00092_A355ResidentCity, T00092_A356ResidentZipCode, T00092_A357ResidentAddressLine1, T00092_A358ResidentAddressLine2, T00092_A73ResidentBirthDate, T00092_A71ResidentGUID, T00092_A376ResidentPhoneNumber,
               T00092_A446ResidentHomePhoneNumber, T00092_A40000ResidentImage_GXI, T00092_n40000ResidentImage_GXI, T00092_A29LocationId, T00092_A11OrganisationId, T00092_A96ResidentTypeId, T00092_n96ResidentTypeId, T00092_A98MedicalIndicationId, T00092_n98MedicalIndicationId, T00092_A457ResidentImage,
               T00092_n457ResidentImage
               }
               , new Object[] {
               T00093_A62ResidentId, T00093_A354ResidentCountry, T00093_A445ResidentHomePhoneCode, T00093_A375ResidentPhoneCode, T00093_A66ResidentInitials, T00093_A70ResidentPhone, T00093_A444ResidentHomePhone, T00093_A72ResidentSalutation, T00093_A63ResidentBsnNumber, T00093_A64ResidentGivenName,
               T00093_A65ResidentLastName, T00093_A67ResidentEmail, T00093_A68ResidentGender, T00093_A355ResidentCity, T00093_A356ResidentZipCode, T00093_A357ResidentAddressLine1, T00093_A358ResidentAddressLine2, T00093_A73ResidentBirthDate, T00093_A71ResidentGUID, T00093_A376ResidentPhoneNumber,
               T00093_A446ResidentHomePhoneNumber, T00093_A40000ResidentImage_GXI, T00093_n40000ResidentImage_GXI, T00093_A29LocationId, T00093_A11OrganisationId, T00093_A96ResidentTypeId, T00093_n96ResidentTypeId, T00093_A98MedicalIndicationId, T00093_n98MedicalIndicationId, T00093_A457ResidentImage,
               T00093_n457ResidentImage
               }
               , new Object[] {
               T00094_A29LocationId
               }
               , new Object[] {
               T00095_A97ResidentTypeName
               }
               , new Object[] {
               T00096_A99MedicalIndicationName
               }
               , new Object[] {
               T00097_A62ResidentId, T00097_A354ResidentCountry, T00097_A445ResidentHomePhoneCode, T00097_A375ResidentPhoneCode, T00097_A66ResidentInitials, T00097_A70ResidentPhone, T00097_A444ResidentHomePhone, T00097_A72ResidentSalutation, T00097_A63ResidentBsnNumber, T00097_A64ResidentGivenName,
               T00097_A65ResidentLastName, T00097_A67ResidentEmail, T00097_A68ResidentGender, T00097_A355ResidentCity, T00097_A356ResidentZipCode, T00097_A357ResidentAddressLine1, T00097_A358ResidentAddressLine2, T00097_A73ResidentBirthDate, T00097_A71ResidentGUID, T00097_A97ResidentTypeName,
               T00097_A99MedicalIndicationName, T00097_A376ResidentPhoneNumber, T00097_A446ResidentHomePhoneNumber, T00097_A40000ResidentImage_GXI, T00097_n40000ResidentImage_GXI, T00097_A29LocationId, T00097_A11OrganisationId, T00097_A96ResidentTypeId, T00097_n96ResidentTypeId, T00097_A98MedicalIndicationId,
               T00097_n98MedicalIndicationId, T00097_A457ResidentImage, T00097_n457ResidentImage
               }
               , new Object[] {
               T00098_A29LocationId
               }
               , new Object[] {
               T00099_A97ResidentTypeName
               }
               , new Object[] {
               T000910_A99MedicalIndicationName
               }
               , new Object[] {
               T000911_A62ResidentId, T000911_A29LocationId, T000911_A11OrganisationId
               }
               , new Object[] {
               T000912_A62ResidentId, T000912_A29LocationId, T000912_A11OrganisationId
               }
               , new Object[] {
               T000913_A62ResidentId, T000913_A29LocationId, T000913_A11OrganisationId
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
               T000918_A97ResidentTypeName
               }
               , new Object[] {
               T000919_A99MedicalIndicationName
               }
               , new Object[] {
               T000920_A62ResidentId, T000920_A29LocationId, T000920_A11OrganisationId
               }
               , new Object[] {
               T000921_A29LocationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         AV46Pgmname = "Trn_Resident";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentBirthDate_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int divPhonenumber_Visible ;
      private int edtResidentPhoneCode_Visible ;
      private int edtResidentPhoneCode_Enabled ;
      private int edtResidentPhoneNumber_Enabled ;
      private int divHomephonenumber_Visible ;
      private int edtResidentHomePhoneCode_Visible ;
      private int edtResidentHomePhoneCode_Enabled ;
      private int edtResidentHomePhoneNumber_Enabled ;
      private int edtResidentPhone_Visible ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentHomePhone_Visible ;
      private int edtResidentHomePhone_Enabled ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentAddressLine1_Enabled ;
      private int edtResidentAddressLine2_Enabled ;
      private int edtResidentZipCode_Enabled ;
      private int edtResidentCity_Enabled ;
      private int edtResidentCountry_Visible ;
      private int edtResidentCountry_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboresidentphonecode_Visible ;
      private int edtavComboresidentphonecode_Enabled ;
      private int edtavComboresidenthomephonecode_Visible ;
      private int edtavComboresidenthomephonecode_Enabled ;
      private int edtavComboresidentcountry_Visible ;
      private int edtavComboresidentcountry_Enabled ;
      private int edtResidentId_Visible ;
      private int edtResidentId_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtResidentInitials_Visible ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentGUID_Visible ;
      private int edtResidentGUID_Enabled ;
      private int edtResidentTypeId_Visible ;
      private int edtResidentTypeId_Enabled ;
      private int edtMedicalIndicationId_Visible ;
      private int edtMedicalIndicationId_Enabled ;
      private int Combo_residentphonecode_Datalistupdateminimumcharacters ;
      private int Combo_residentphonecode_Gxcontroltype ;
      private int Combo_residenthomephonecode_Datalistupdateminimumcharacters ;
      private int Combo_residenthomephonecode_Gxcontroltype ;
      private int Combo_residentcountry_Datalistupdateminimumcharacters ;
      private int Combo_residentcountry_Gxcontroltype ;
      private int AV47GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string Z444ResidentHomePhone ;
      private string Z72ResidentSalutation ;
      private string Combo_residentcountry_Selectedvalue_get ;
      private string Combo_residenthomephonecode_Selectedvalue_get ;
      private string Combo_residentphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbResidentSalutation_Internalname ;
      private string A72ResidentSalutation ;
      private string cmbResidentGender_Internalname ;
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
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string cmbResidentGender_Jsonclick ;
      private string edtResidentBirthDate_Internalname ;
      private string edtResidentBirthDate_Jsonclick ;
      private string edtResidentEmail_Internalname ;
      private string edtResidentEmail_Jsonclick ;
      private string divPhonenumber_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string divUnnamedtableresidentphonecode_Internalname ;
      private string Combo_residentphonecode_Caption ;
      private string Combo_residentphonecode_Cls ;
      private string Combo_residentphonecode_Internalname ;
      private string edtResidentPhoneCode_Internalname ;
      private string edtResidentPhoneCode_Jsonclick ;
      private string edtResidentPhoneNumber_Internalname ;
      private string edtResidentPhoneNumber_Jsonclick ;
      private string divHomephonenumber_Internalname ;
      private string lblPhone_Internalname ;
      private string lblPhone_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string divUnnamedtableresidenthomephonecode_Internalname ;
      private string Combo_residenthomephonecode_Caption ;
      private string Combo_residenthomephonecode_Cls ;
      private string Combo_residenthomephonecode_Internalname ;
      private string edtResidentHomePhoneCode_Internalname ;
      private string edtResidentHomePhoneCode_Jsonclick ;
      private string edtResidentHomePhoneNumber_Internalname ;
      private string edtResidentHomePhoneNumber_Jsonclick ;
      private string divResidentphone_cell_Internalname ;
      private string divResidentphone_cell_Class ;
      private string edtResidentPhone_Internalname ;
      private string gxphoneLink ;
      private string A70ResidentPhone ;
      private string edtResidentPhone_Jsonclick ;
      private string divResidenthomephone_cell_Internalname ;
      private string divResidenthomephone_cell_Class ;
      private string edtResidentHomePhone_Internalname ;
      private string A444ResidentHomePhone ;
      private string edtResidentHomePhone_Jsonclick ;
      private string edtResidentBsnNumber_Internalname ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtResidentAddressLine1_Internalname ;
      private string edtResidentAddressLine1_Jsonclick ;
      private string edtResidentAddressLine2_Internalname ;
      private string edtResidentAddressLine2_Jsonclick ;
      private string edtResidentZipCode_Internalname ;
      private string edtResidentZipCode_Jsonclick ;
      private string edtResidentCity_Internalname ;
      private string edtResidentCity_Jsonclick ;
      private string divTablesplittedresidentcountry_Internalname ;
      private string lblTextblockresidentcountry_Internalname ;
      private string lblTextblockresidentcountry_Jsonclick ;
      private string Combo_residentcountry_Caption ;
      private string Combo_residentcountry_Cls ;
      private string Combo_residentcountry_Internalname ;
      private string edtResidentCountry_Internalname ;
      private string edtResidentCountry_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_residentphonecode_Internalname ;
      private string edtavComboresidentphonecode_Internalname ;
      private string edtavComboresidentphonecode_Jsonclick ;
      private string divSectionattribute_residenthomephonecode_Internalname ;
      private string edtavComboresidenthomephonecode_Internalname ;
      private string edtavComboresidenthomephonecode_Jsonclick ;
      private string divSectionattribute_residentcountry_Internalname ;
      private string edtavComboresidentcountry_Internalname ;
      private string edtavComboresidentcountry_Jsonclick ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtResidentInitials_Internalname ;
      private string A66ResidentInitials ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeId_Jsonclick ;
      private string edtMedicalIndicationId_Internalname ;
      private string edtMedicalIndicationId_Jsonclick ;
      private string AV46Pgmname ;
      private string Combo_residentphonecode_Objectcall ;
      private string Combo_residentphonecode_Class ;
      private string Combo_residentphonecode_Icontype ;
      private string Combo_residentphonecode_Icon ;
      private string Combo_residentphonecode_Tooltip ;
      private string Combo_residentphonecode_Selectedvalue_set ;
      private string Combo_residentphonecode_Selectedtext_set ;
      private string Combo_residentphonecode_Selectedtext_get ;
      private string Combo_residentphonecode_Gamoauthtoken ;
      private string Combo_residentphonecode_Ddointernalname ;
      private string Combo_residentphonecode_Titlecontrolalign ;
      private string Combo_residentphonecode_Dropdownoptionstype ;
      private string Combo_residentphonecode_Titlecontrolidtoreplace ;
      private string Combo_residentphonecode_Datalisttype ;
      private string Combo_residentphonecode_Datalistfixedvalues ;
      private string Combo_residentphonecode_Datalistproc ;
      private string Combo_residentphonecode_Datalistprocparametersprefix ;
      private string Combo_residentphonecode_Remoteservicesparameters ;
      private string Combo_residentphonecode_Htmltemplate ;
      private string Combo_residentphonecode_Multiplevaluestype ;
      private string Combo_residentphonecode_Loadingdata ;
      private string Combo_residentphonecode_Noresultsfound ;
      private string Combo_residentphonecode_Emptyitemtext ;
      private string Combo_residentphonecode_Onlyselectedvalues ;
      private string Combo_residentphonecode_Selectalltext ;
      private string Combo_residentphonecode_Multiplevaluesseparator ;
      private string Combo_residentphonecode_Addnewoptiontext ;
      private string Combo_residenthomephonecode_Objectcall ;
      private string Combo_residenthomephonecode_Class ;
      private string Combo_residenthomephonecode_Icontype ;
      private string Combo_residenthomephonecode_Icon ;
      private string Combo_residenthomephonecode_Tooltip ;
      private string Combo_residenthomephonecode_Selectedvalue_set ;
      private string Combo_residenthomephonecode_Selectedtext_set ;
      private string Combo_residenthomephonecode_Selectedtext_get ;
      private string Combo_residenthomephonecode_Gamoauthtoken ;
      private string Combo_residenthomephonecode_Ddointernalname ;
      private string Combo_residenthomephonecode_Titlecontrolalign ;
      private string Combo_residenthomephonecode_Dropdownoptionstype ;
      private string Combo_residenthomephonecode_Titlecontrolidtoreplace ;
      private string Combo_residenthomephonecode_Datalisttype ;
      private string Combo_residenthomephonecode_Datalistfixedvalues ;
      private string Combo_residenthomephonecode_Datalistproc ;
      private string Combo_residenthomephonecode_Datalistprocparametersprefix ;
      private string Combo_residenthomephonecode_Remoteservicesparameters ;
      private string Combo_residenthomephonecode_Htmltemplate ;
      private string Combo_residenthomephonecode_Multiplevaluestype ;
      private string Combo_residenthomephonecode_Loadingdata ;
      private string Combo_residenthomephonecode_Noresultsfound ;
      private string Combo_residenthomephonecode_Emptyitemtext ;
      private string Combo_residenthomephonecode_Onlyselectedvalues ;
      private string Combo_residenthomephonecode_Selectalltext ;
      private string Combo_residenthomephonecode_Multiplevaluesseparator ;
      private string Combo_residenthomephonecode_Addnewoptiontext ;
      private string Combo_residentcountry_Objectcall ;
      private string Combo_residentcountry_Class ;
      private string Combo_residentcountry_Icontype ;
      private string Combo_residentcountry_Icon ;
      private string Combo_residentcountry_Tooltip ;
      private string Combo_residentcountry_Selectedvalue_set ;
      private string Combo_residentcountry_Selectedtext_set ;
      private string Combo_residentcountry_Selectedtext_get ;
      private string Combo_residentcountry_Gamoauthtoken ;
      private string Combo_residentcountry_Ddointernalname ;
      private string Combo_residentcountry_Titlecontrolalign ;
      private string Combo_residentcountry_Dropdownoptionstype ;
      private string Combo_residentcountry_Titlecontrolidtoreplace ;
      private string Combo_residentcountry_Datalisttype ;
      private string Combo_residentcountry_Datalistfixedvalues ;
      private string Combo_residentcountry_Datalistproc ;
      private string Combo_residentcountry_Datalistprocparametersprefix ;
      private string Combo_residentcountry_Remoteservicesparameters ;
      private string Combo_residentcountry_Htmltemplate ;
      private string Combo_residentcountry_Multiplevaluestype ;
      private string Combo_residentcountry_Loadingdata ;
      private string Combo_residentcountry_Noresultsfound ;
      private string Combo_residentcountry_Emptyitemtext ;
      private string Combo_residentcountry_Onlyselectedvalues ;
      private string Combo_residentcountry_Selectalltext ;
      private string Combo_residentcountry_Multiplevaluesseparator ;
      private string Combo_residentcountry_Addnewoptiontext ;
      private string hsh ;
      private string sMode16 ;
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
      private string GXt_char2 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n457ResidentImage ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private bool wbErr ;
      private bool Combo_residentphonecode_Emptyitem ;
      private bool Combo_residenthomephonecode_Emptyitem ;
      private bool Combo_residentcountry_Emptyitem ;
      private bool n40000ResidentImage_GXI ;
      private bool Combo_residentphonecode_Enabled ;
      private bool Combo_residentphonecode_Visible ;
      private bool Combo_residentphonecode_Allowmultipleselection ;
      private bool Combo_residentphonecode_Isgriditem ;
      private bool Combo_residentphonecode_Hasdescription ;
      private bool Combo_residentphonecode_Includeonlyselectedoption ;
      private bool Combo_residentphonecode_Includeselectalloption ;
      private bool Combo_residentphonecode_Includeaddnewoption ;
      private bool Combo_residenthomephonecode_Enabled ;
      private bool Combo_residenthomephonecode_Visible ;
      private bool Combo_residenthomephonecode_Allowmultipleselection ;
      private bool Combo_residenthomephonecode_Isgriditem ;
      private bool Combo_residenthomephonecode_Hasdescription ;
      private bool Combo_residenthomephonecode_Includeonlyselectedoption ;
      private bool Combo_residenthomephonecode_Includeselectalloption ;
      private bool Combo_residenthomephonecode_Includeaddnewoption ;
      private bool Combo_residentcountry_Enabled ;
      private bool Combo_residentcountry_Visible ;
      private bool Combo_residentcountry_Allowmultipleselection ;
      private bool Combo_residentcountry_Isgriditem ;
      private bool Combo_residentcountry_Hasdescription ;
      private bool Combo_residentcountry_Includeonlyselectedoption ;
      private bool Combo_residentcountry_Includeselectalloption ;
      private bool Combo_residentcountry_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV36GAMErrorResponse ;
      private string Z354ResidentCountry ;
      private string Z445ResidentHomePhoneCode ;
      private string Z375ResidentPhoneCode ;
      private string Z63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string Z68ResidentGender ;
      private string Z355ResidentCity ;
      private string Z356ResidentZipCode ;
      private string Z357ResidentAddressLine1 ;
      private string Z358ResidentAddressLine2 ;
      private string Z71ResidentGUID ;
      private string Z376ResidentPhoneNumber ;
      private string Z446ResidentHomePhoneNumber ;
      private string A67ResidentEmail ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A445ResidentHomePhoneCode ;
      private string A446ResidentHomePhoneNumber ;
      private string A375ResidentPhoneCode ;
      private string A376ResidentPhoneNumber ;
      private string A68ResidentGender ;
      private string A63ResidentBsnNumber ;
      private string A357ResidentAddressLine1 ;
      private string A358ResidentAddressLine2 ;
      private string A356ResidentZipCode ;
      private string A355ResidentCity ;
      private string A354ResidentCountry ;
      private string AV39ComboResidentPhoneCode ;
      private string AV44ComboResidentHomePhoneCode ;
      private string AV38ComboResidentCountry ;
      private string A40000ResidentImage_GXI ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string AV40defaultCountryPhoneCode ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z40000ResidentImage_GXI ;
      private string Z97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string A457ResidentImage ;
      private string Z457ResidentImage ;
      private Guid wcpOAV7ResidentId ;
      private Guid wcpOAV8LocationId ;
      private Guid wcpOAV9OrganisationId ;
      private Guid Z62ResidentId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid N96ResidentTypeId ;
      private Guid N98MedicalIndicationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid AV7ResidentId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A62ResidentId ;
      private Guid AV15Insert_ResidentTypeId ;
      private Guid AV16Insert_MedicalIndicationId ;
      private IGxSession AV14WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_residentphonecode ;
      private GXUserControl ucCombo_residenthomephonecode ;
      private GXUserControl ucCombo_residentcountry ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GXCombobox cmbResidentGender ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41ResidentPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43ResidentHomePhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV37ResidentCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private string[] T00096_A99MedicalIndicationName ;
      private string[] T00095_A97ResidentTypeName ;
      private Guid[] T00097_A62ResidentId ;
      private string[] T00097_A354ResidentCountry ;
      private string[] T00097_A445ResidentHomePhoneCode ;
      private string[] T00097_A375ResidentPhoneCode ;
      private string[] T00097_A66ResidentInitials ;
      private string[] T00097_A70ResidentPhone ;
      private string[] T00097_A444ResidentHomePhone ;
      private string[] T00097_A72ResidentSalutation ;
      private string[] T00097_A63ResidentBsnNumber ;
      private string[] T00097_A64ResidentGivenName ;
      private string[] T00097_A65ResidentLastName ;
      private string[] T00097_A67ResidentEmail ;
      private string[] T00097_A68ResidentGender ;
      private string[] T00097_A355ResidentCity ;
      private string[] T00097_A356ResidentZipCode ;
      private string[] T00097_A357ResidentAddressLine1 ;
      private string[] T00097_A358ResidentAddressLine2 ;
      private DateTime[] T00097_A73ResidentBirthDate ;
      private string[] T00097_A71ResidentGUID ;
      private string[] T00097_A97ResidentTypeName ;
      private string[] T00097_A99MedicalIndicationName ;
      private string[] T00097_A376ResidentPhoneNumber ;
      private string[] T00097_A446ResidentHomePhoneNumber ;
      private string[] T00097_A40000ResidentImage_GXI ;
      private bool[] T00097_n40000ResidentImage_GXI ;
      private Guid[] T00097_A29LocationId ;
      private Guid[] T00097_A11OrganisationId ;
      private Guid[] T00097_A96ResidentTypeId ;
      private bool[] T00097_n96ResidentTypeId ;
      private Guid[] T00097_A98MedicalIndicationId ;
      private bool[] T00097_n98MedicalIndicationId ;
      private string[] T00097_A457ResidentImage ;
      private bool[] T00097_n457ResidentImage ;
      private Guid[] T00094_A29LocationId ;
      private Guid[] T00098_A29LocationId ;
      private string[] T00099_A97ResidentTypeName ;
      private string[] T000910_A99MedicalIndicationName ;
      private Guid[] T000911_A62ResidentId ;
      private Guid[] T000911_A29LocationId ;
      private Guid[] T000911_A11OrganisationId ;
      private Guid[] T00093_A62ResidentId ;
      private string[] T00093_A354ResidentCountry ;
      private string[] T00093_A445ResidentHomePhoneCode ;
      private string[] T00093_A375ResidentPhoneCode ;
      private string[] T00093_A66ResidentInitials ;
      private string[] T00093_A70ResidentPhone ;
      private string[] T00093_A444ResidentHomePhone ;
      private string[] T00093_A72ResidentSalutation ;
      private string[] T00093_A63ResidentBsnNumber ;
      private string[] T00093_A64ResidentGivenName ;
      private string[] T00093_A65ResidentLastName ;
      private string[] T00093_A67ResidentEmail ;
      private string[] T00093_A68ResidentGender ;
      private string[] T00093_A355ResidentCity ;
      private string[] T00093_A356ResidentZipCode ;
      private string[] T00093_A357ResidentAddressLine1 ;
      private string[] T00093_A358ResidentAddressLine2 ;
      private DateTime[] T00093_A73ResidentBirthDate ;
      private string[] T00093_A71ResidentGUID ;
      private string[] T00093_A376ResidentPhoneNumber ;
      private string[] T00093_A446ResidentHomePhoneNumber ;
      private string[] T00093_A40000ResidentImage_GXI ;
      private bool[] T00093_n40000ResidentImage_GXI ;
      private Guid[] T00093_A29LocationId ;
      private Guid[] T00093_A11OrganisationId ;
      private Guid[] T00093_A96ResidentTypeId ;
      private bool[] T00093_n96ResidentTypeId ;
      private Guid[] T00093_A98MedicalIndicationId ;
      private bool[] T00093_n98MedicalIndicationId ;
      private string[] T00093_A457ResidentImage ;
      private bool[] T00093_n457ResidentImage ;
      private Guid[] T000912_A62ResidentId ;
      private Guid[] T000912_A29LocationId ;
      private Guid[] T000912_A11OrganisationId ;
      private Guid[] T000913_A62ResidentId ;
      private Guid[] T000913_A29LocationId ;
      private Guid[] T000913_A11OrganisationId ;
      private Guid[] T00092_A62ResidentId ;
      private string[] T00092_A354ResidentCountry ;
      private string[] T00092_A445ResidentHomePhoneCode ;
      private string[] T00092_A375ResidentPhoneCode ;
      private string[] T00092_A66ResidentInitials ;
      private string[] T00092_A70ResidentPhone ;
      private string[] T00092_A444ResidentHomePhone ;
      private string[] T00092_A72ResidentSalutation ;
      private string[] T00092_A63ResidentBsnNumber ;
      private string[] T00092_A64ResidentGivenName ;
      private string[] T00092_A65ResidentLastName ;
      private string[] T00092_A67ResidentEmail ;
      private string[] T00092_A68ResidentGender ;
      private string[] T00092_A355ResidentCity ;
      private string[] T00092_A356ResidentZipCode ;
      private string[] T00092_A357ResidentAddressLine1 ;
      private string[] T00092_A358ResidentAddressLine2 ;
      private DateTime[] T00092_A73ResidentBirthDate ;
      private string[] T00092_A71ResidentGUID ;
      private string[] T00092_A376ResidentPhoneNumber ;
      private string[] T00092_A446ResidentHomePhoneNumber ;
      private string[] T00092_A40000ResidentImage_GXI ;
      private bool[] T00092_n40000ResidentImage_GXI ;
      private Guid[] T00092_A29LocationId ;
      private Guid[] T00092_A11OrganisationId ;
      private Guid[] T00092_A96ResidentTypeId ;
      private bool[] T00092_n96ResidentTypeId ;
      private Guid[] T00092_A98MedicalIndicationId ;
      private bool[] T00092_n98MedicalIndicationId ;
      private string[] T00092_A457ResidentImage ;
      private bool[] T00092_n457ResidentImage ;
      private string[] T000918_A97ResidentTypeName ;
      private string[] T000919_A99MedicalIndicationName ;
      private Guid[] T000920_A62ResidentId ;
      private Guid[] T000920_A29LocationId ;
      private Guid[] T000920_A11OrganisationId ;
      private Guid[] T000921_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_resident__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_resident__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_resident__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00092;
       prmT00092 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00093;
       prmT00093 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00094;
       prmT00094 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00095;
       prmT00095 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00096;
       prmT00096 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00097;
       prmT00097 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00098;
       prmT00098 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00099;
       prmT00099 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000910;
       prmT000910 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000911;
       prmT000911 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000912;
       prmT000912 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000913;
       prmT000913 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000914;
       prmT000914 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=21, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000915;
       prmT000915 = new Object[] {
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000916;
       prmT000916 = new Object[] {
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000917;
       prmT000917 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000918;
       prmT000918 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000919;
       prmT000919 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000920;
       prmT000920 = new Object[] {
       };
       Object[] prmT000921;
       prmT000921 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00092", "SELECT ResidentId, ResidentCountry, ResidentHomePhoneCode, ResidentPhoneCode, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneNumber, ResidentHomePhoneNumber, ResidentImage_GXI, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId, ResidentImage FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Resident NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00093", "SELECT ResidentId, ResidentCountry, ResidentHomePhoneCode, ResidentPhoneCode, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneNumber, ResidentHomePhoneNumber, ResidentImage_GXI, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId, ResidentImage FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00094", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00095", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00096", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00097", "SELECT TM1.ResidentId, TM1.ResidentCountry, TM1.ResidentHomePhoneCode, TM1.ResidentPhoneCode, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentHomePhone, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCity, TM1.ResidentZipCode, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentBirthDate, TM1.ResidentGUID, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneNumber, TM1.ResidentImage_GXI, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId, TM1.ResidentImage FROM ((Trn_Resident TM1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00098", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00099", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000910", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000911", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000912", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ( ResidentId > :ResidentId or ResidentId = :ResidentId and LocationId > :LocationId or LocationId = :LocationId and ResidentId = :ResidentId and OrganisationId > :OrganisationId) ORDER BY ResidentId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000912,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000913", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ( ResidentId < :ResidentId or ResidentId = :ResidentId and LocationId < :LocationId or LocationId = :LocationId and ResidentId = :ResidentId and OrganisationId < :OrganisationId) ORDER BY ResidentId DESC, LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000914", "SAVEPOINT gxupdate;INSERT INTO Trn_Resident(ResidentId, ResidentCountry, ResidentHomePhoneCode, ResidentPhoneCode, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneNumber, ResidentHomePhoneNumber, ResidentImage, ResidentImage_GXI, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId) VALUES(:ResidentId, :ResidentCountry, :ResidentHomePhoneCode, :ResidentPhoneCode, :ResidentInitials, :ResidentPhone, :ResidentHomePhone, :ResidentSalutation, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentCity, :ResidentZipCode, :ResidentAddressLine1, :ResidentAddressLine2, :ResidentBirthDate, :ResidentGUID, :ResidentPhoneNumber, :ResidentHomePhoneNumber, :ResidentImage, :ResidentImage_GXI, :LocationId, :OrganisationId, :ResidentTypeId, :MedicalIndicationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000914)
          ,new CursorDef("T000915", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentCountry=:ResidentCountry, ResidentHomePhoneCode=:ResidentHomePhoneCode, ResidentPhoneCode=:ResidentPhoneCode, ResidentInitials=:ResidentInitials, ResidentPhone=:ResidentPhone, ResidentHomePhone=:ResidentHomePhone, ResidentSalutation=:ResidentSalutation, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentCity=:ResidentCity, ResidentZipCode=:ResidentZipCode, ResidentAddressLine1=:ResidentAddressLine1, ResidentAddressLine2=:ResidentAddressLine2, ResidentBirthDate=:ResidentBirthDate, ResidentGUID=:ResidentGUID, ResidentPhoneNumber=:ResidentPhoneNumber, ResidentHomePhoneNumber=:ResidentHomePhoneNumber, ResidentTypeId=:ResidentTypeId, MedicalIndicationId=:MedicalIndicationId  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000915)
          ,new CursorDef("T000916", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentImage=:ResidentImage, ResidentImage_GXI=:ResidentImage_GXI  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000916)
          ,new CursorDef("T000917", "SAVEPOINT gxupdate;DELETE FROM Trn_Resident  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000917)
          ,new CursorDef("T000918", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000919", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000920", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident ORDER BY ResidentId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000920,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000921", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000921,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[22])[0] = rslt.wasNull(22);
             ((Guid[]) buf[23])[0] = rslt.getGuid(23);
             ((Guid[]) buf[24])[0] = rslt.getGuid(24);
             ((Guid[]) buf[25])[0] = rslt.getGuid(25);
             ((bool[]) buf[26])[0] = rslt.wasNull(25);
             ((Guid[]) buf[27])[0] = rslt.getGuid(26);
             ((bool[]) buf[28])[0] = rslt.wasNull(26);
             ((string[]) buf[29])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[30])[0] = rslt.wasNull(27);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[22])[0] = rslt.wasNull(22);
             ((Guid[]) buf[23])[0] = rslt.getGuid(23);
             ((Guid[]) buf[24])[0] = rslt.getGuid(24);
             ((Guid[]) buf[25])[0] = rslt.getGuid(25);
             ((bool[]) buf[26])[0] = rslt.wasNull(25);
             ((Guid[]) buf[27])[0] = rslt.getGuid(26);
             ((bool[]) buf[28])[0] = rslt.wasNull(26);
             ((string[]) buf[29])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(22));
             ((bool[]) buf[30])[0] = rslt.wasNull(27);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((string[]) buf[23])[0] = rslt.getMultimediaUri(24);
             ((bool[]) buf[24])[0] = rslt.wasNull(24);
             ((Guid[]) buf[25])[0] = rslt.getGuid(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((Guid[]) buf[27])[0] = rslt.getGuid(27);
             ((bool[]) buf[28])[0] = rslt.wasNull(27);
             ((Guid[]) buf[29])[0] = rslt.getGuid(28);
             ((bool[]) buf[30])[0] = rslt.wasNull(28);
             ((string[]) buf[31])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(24));
             ((bool[]) buf[32])[0] = rslt.wasNull(29);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 17 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
